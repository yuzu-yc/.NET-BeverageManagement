using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BeverageManagement
{
    public partial class OrderForm : Form
    {
        private Order currentOrder = new Order();  // 当前订单

        private DataRow current_staff_info;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;Integrated Security=True;Connect Timeout=30";

        public OrderForm(DataRow staff_info)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            current_staff_info = staff_info;
            LoadDrinks();
            LoadOrders(); // 初始化时加载订单列表
            // 设置默认图片
            pictureBox.Image = Image.FromFile(@"D:\BeverageManagement\Resource\point.jpg");
        }


        // 初始化或重置窗体内容
        public void InitializeForm()
        {
            // 重新加载数据
            LoadDrinks();
            LoadOrders(); // 初始化时加载订单列表
        }
        // 加载饮品信息并显示在 ListView 控件中
        private void LoadDrinks()
        {
            // 初始化 ListView 列头
            InitializeListView();
            // 创建 SQL 查询语句
            string query = "SELECT DrinkID, DrinkName, Category, Price, ImagePath FROM dbo.Drinks";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // 获取数据库中的数据
                        int drinkID = reader.GetInt32(0);
                        string drinkName = reader.GetString(1);
                        string category = reader.GetString(2);  // 获取类别
                        decimal price = reader.GetDecimal(3);
                        string imagePath = reader.IsDBNull(4) ? null : reader.GetString(4);

                        // 创建 ListViewItem 项目并设置饮品信息
                        ListViewItem item = new ListViewItem(drinkName);
                        item.SubItems.Add(price.ToString("C2"));  // 格式化价格显示
                        item.SubItems.Add(category);              // 添加类别
                        item.SubItems.Add(drinkID.ToString());    // 添加饮品ID，用于后续操作
                        item.SubItems.Add(imagePath);             // 添加图片路径，防止空值

                        // 将项目添加到 ListView 控件中
                        drinkInfoListView.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据库连接失败: " + ex.Message);
                }
            }
        }
        // 自动调整列宽，使每列适配内容的长度
        private void InitializeListView()
        {
            // 设置列头
            drinkInfoListView.Columns.Clear();
            drinkInfoListView.Columns.Add("饮品名称", 80, HorizontalAlignment.Center);
            drinkInfoListView.Columns.Add("价格", 80, HorizontalAlignment.Center);
            drinkInfoListView.Columns.Add("类别", 80, HorizontalAlignment.Center);      // 类别
            drinkInfoListView.Columns.Add("饮品ID", 80, HorizontalAlignment.Center);  // 设置为0，隐藏ID列

        }

        // 加载订单信息并显示在 ListView 控件中
        private void LoadOrders()
        {
            // 清空现有的 ListView 项目
            orderInfoListView.Items.Clear();

            // 将当前订单中的每个饮品添加到 ListView
            foreach (var item in currentOrder.Items)
            {
                ListViewItem listViewItem = new ListViewItem(item.DrinkName);
                listViewItem.SubItems.Add(item.Quantity.ToString());
                listViewItem.SubItems.Add(item.Price.ToString("C2"));
                listViewItem.SubItems.Add(item.TotalPrice.ToString("C2"));

                orderInfoListView.Items.Add(listViewItem);
            }


        }

       

        // ListView 项目选择事件，点击项目后更新下方详细信息
        private void drinkInfoListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drinkInfoListView.SelectedItems.Count > 0)
            {
                var selectedItem = drinkInfoListView.SelectedItems[0];
                label_drinkName.Text = selectedItem.Text;  // 显示饮品名称
                label4.Text = "价格：" + selectedItem.SubItems[1].Text; // 显示价格

                // 获取饮品ID，并在图片框中显示对应图片
                int drinkID = int.Parse(selectedItem.SubItems[3].Text);
                string imagePath = selectedItem.SubItems[4].Text;  // 获取图片路径（修正了索引）

                // 如果图片路径有效且存在，加载图片
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    pictureBox.Image = Image.FromFile(imagePath);  // 加载图片到 PictureBox
                }
                else
                {
                    // 如果图片路径无效，使用默认图片
                    string defaultImagePath = @"D:\BeverageManagement\Resource\OIP.jpg";
                    if (System.IO.File.Exists(defaultImagePath))
                    {
                        pictureBox.Image = Image.FromFile(defaultImagePath);
                    }
                    else
                    {
                        MessageBox.Show("默认图片未找到！");
                    }
                }
            }
        }

        private void btn_AddToOrder_Click(object sender, EventArgs e)
        {
            if (drinkInfoListView.SelectedItems.Count > 0)
            {
                // 获取选择的饮品信息
                var selectedItem = drinkInfoListView.SelectedItems[0];
                string drinkName = selectedItem.Text;
                string priceText = selectedItem.SubItems[1].Text;

                // 移除可能的货币符号或其他非数字字符
                priceText = priceText.Replace("价格：", "").Replace("¥", "").Trim();

                decimal price;
                if (decimal.TryParse(priceText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out price))
                {
                    // 成功转换为 decimal，继续操作
                }
                else
                {
                    MessageBox.Show("价格格式不正确！");
                }

                int quantity = (int)numBox_count.Value; // 获取数量（通过 numericUpDown 控件）

                //// 计算总价
                //decimal totalPrice = price * quantity;
                // 创建 OrderItem 对象
                OrderItem orderItem = new OrderItem
                {
                    DrinkName = drinkName,
                    Quantity = quantity,
                    Price = price
                };
                
                // 将饮品加入当前订单
                currentOrder.AddItem(orderItem);
            }
            else
            {
                MessageBox.Show("请先选择饮品！");
            }
            LoadOrders(); // 初始化时加载订单列表
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            // 检查当前订单是否有至少一个饮品
            if (currentOrder.Items.Count == 0)
            {
                MessageBox.Show("请至少选择一款饮品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // 退出方法，避免提交空订单
            }
            PayForm payForm = new PayForm(currentOrder,this); // 这里假设你有一个主窗体 MainForm
            payForm.ShowDialog();

            // 提交订单到数据库
            SubmitOrderToDatabase(currentOrder);

            // 清空当前订单
            currentOrder.ClearOrder();

            // 更新 UI
            LoadOrders(); 
        }

        private void SubmitOrderToDatabase(Order order)
        {
            // 在数据库中插入订单和订单项
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 开始事务
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        // 插入订单信息
                        string insertOrderQuery = "INSERT INTO Orders (OrderDate, TotalPrice,OrderStatus) VALUES (@OrderDate, @TotalPrice,@orderStatus); SELECT SCOPE_IDENTITY();";
                        SqlCommand cmd = new SqlCommand(insertOrderQuery, connection, transaction);
                        cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                        cmd.Parameters.AddWithValue("@orderStatus", order.OrderStatus);
                        int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                        // 插入订单项
                        foreach (var item in order.Items)
                        {
                            string insertOrderItemQuery = "INSERT INTO OrderItems (OrderID, DrinkName, Quantity, Price, TotalPrice) VALUES (@OrderID, @DrinkName, @Quantity, @Price, @TotalPrice)";
                            cmd = new SqlCommand(insertOrderItemQuery, connection, transaction);
                            cmd.Parameters.AddWithValue("@OrderID", orderId);
                            cmd.Parameters.AddWithValue("@DrinkName", item.DrinkName);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@Price", item.Price);
                            cmd.Parameters.AddWithValue("@TotalPrice", item.TotalPrice);
                            cmd.ExecuteNonQuery();
                        }

                        // 提交事务
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("订单提交失败: " + ex.Message);
                }
            }
        }

    }
}
