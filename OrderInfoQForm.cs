using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeverageManagement
{
    public partial class OrderInfoQForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;
Integrated Security=True;Connect Timeout=30";
        public OrderInfoQForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            pictureBoxPopularDrink.Image = Image.FromFile(@"D:\BeverageManagement\Resource\win.png");
        }

      
        private void OrderInfoQForm_Load(object sender, EventArgs e)
        {
            // 加载所有订单到DataGridView
            LoadAllOrders();
        }

      
       private void buttonQuery_Click(object sender, EventArgs e)
{
    // 获取开始和结束日期
    DateTime startDate = dateTimePickerStart.Value.Date;
    DateTime endDate = dateTimePickerEnd.Value.Date;

    // 查询数据库，获取订单统计数据
    int orderCount;
    decimal totalSales;
    int totalQuantity;
    string popularDrinkName;
    int popularDrinkQuantity;
    string popularDrinkImage;

    // 调用查询方法获取数据
    GetOrderStatistics(startDate, endDate, out orderCount, out totalSales, out totalQuantity, out popularDrinkName, out popularDrinkQuantity, out popularDrinkImage);

    // 更新UI，显示统计数据
    labelOrderCount.Text = $"订单总数: {orderCount}";
    labelTotalSales.Text = $"总销售额: {totalSales:C}";
    labelTotalQuantity.Text = $"总销售数量: {totalQuantity}";

    // 显示最受欢迎饮料
    labelPopularDrinkName.Text = $"最受欢迎饮料: {popularDrinkName}";
    labelPopularDrinkQuantity.Text = $"销售数量: {popularDrinkQuantity}";

            // 如果图片路径有效且存在，加载图片
            if (!string.IsNullOrEmpty(popularDrinkImage) && System.IO.File.Exists(popularDrinkImage))
            {
                pictureBoxPopularDrink.Image = Image.FromFile(popularDrinkImage);  // 加载图片到 PictureBox
            }
            else
            {
                // 如果图片路径无效，使用默认图片
                string defaultImagePath = @"D:\BeverageManagement\Resource\win.png";
                if (System.IO.File.Exists(defaultImagePath))
                {
                    pictureBoxPopularDrink.Image = Image.FromFile(defaultImagePath);
                }
                else
                {
                    MessageBox.Show("默认图片未找到！");
                }
            }
        }


        // 获取订单统计数据
        private void GetOrderStatistics(DateTime startDate, DateTime endDate, out int orderCount, out decimal totalSales, out int totalQuantity, out string popularDrinkName, out int popularDrinkQuantity, out string popularDrinkImage)
        {
            // 初始化统计数据
            orderCount = 0;
            totalSales = 0;
            totalQuantity = 0;
            popularDrinkName = string.Empty;
            popularDrinkQuantity = 0;
            popularDrinkImage = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL查询语句：统计在指定日期范围内的订单数据，增加最受欢迎饮料的查询
                    string query = @"
                SELECT 
                    COUNT(DISTINCT o.OrderID) AS OrderCount, 
                    SUM(DISTINCT o.TotalPrice) AS TotalSales,
                    SUM(ISNULL(oi.Quantity, 0)) AS TotalQuantity
                FROM Orders o
                LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
                WHERE o.OrderDate BETWEEN @StartDate AND @EndDate;
                
                -- 查询最受欢迎饮料
                SELECT TOP 1 
                    d.DrinkName,
                    SUM(oi.Quantity) AS TotalSold,
                    d.ImagePath
                FROM OrderItems oi
                INNER JOIN Drinks d ON oi.DrinkName = d.DrinkName  -- 根据 DrinkName 连接
                LEFT JOIN Orders o ON oi.OrderID = o.OrderID
                WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                GROUP BY d.DrinkName, d.ImagePath
                ORDER BY TotalSold DESC;
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 参数化查询，防止SQL注入
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 读取统计数据
                            if (reader.Read())
                            {
                                orderCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                totalSales = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                                totalQuantity = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                            }

                            // 读取最受欢迎饮料信息
                            if (reader.NextResult() && reader.Read())
                            {
                                popularDrinkName = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                                popularDrinkQuantity = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                popularDrinkImage = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                // 输出调试信息
                                Console.WriteLine("读取的饮料图片路径: " + popularDrinkImage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询数据库时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void LoadAllOrders()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 查询所有订单
                    string query = @"
                SELECT 
                    OrderID ,OrderDate ,TotalPrice , OrderStatus FROM Orders";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 清空 DataGridView 中的所有行
                            dataGridViewOrders.Rows.Clear();

                            // 遍历查询结果并逐行填充
                            while (reader.Read())
                            {
                                // 从数据库中读取数据并填充到 DataGridView 中
                                int orderId = reader.GetInt32(0);
                                DateTime orderDate = reader.GetDateTime(1);
                                decimal totalPrice = reader.GetDecimal(2);
                                string orderStatus = reader.GetString(3);

                                // 添加新行
                                dataGridViewOrders.Rows.Add(orderId, orderDate.ToString("yyyy-MM-dd"), totalPrice.ToString("C2"), orderStatus);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单列表时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadOrderItems(int orderId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 查询订单项
                    string query = @"
                        SELECT 
                            oi.OrderItemID, oi.DrinkName, oi.Quantity, oi.Price, oi.TotalPrice
                        FROM OrderItems oi
                        WHERE oi.OrderID = @OrderID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 清空 ListView 中的所有项
                            orderInfoListView.Items.Clear();

                            // 遍历查询结果并逐行填充 
                            while (reader.Read())
                            {
                                // 创建新的 ListViewItem，添加饮品名称
                                ListViewItem item = new ListViewItem(reader["DrinkName"].ToString());

                                // 添加数量、单价和总价
                                item.SubItems.Add(reader["Quantity"].ToString());
                                item.SubItems.Add(reader["Price"].ToString());
                                item.SubItems.Add(reader["TotalPrice"].ToString());

                                // 将该行数据添加到 ListView 中
                                orderInfoListView.Items.Add(item);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单项时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DataGridView行点击事件，加载订单详情
        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dataGridViewOrders.Rows[e.RowIndex].Cells[0].Value);
                LoadOrderItems(orderId);
            }
        }

       
    }
}
