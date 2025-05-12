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
    public partial class PayForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;Integrated Security=True;Connect Timeout=30";
        private Order currentOrder;  // 存储当前订单对象
        private OrderForm orderForm;  // 订单表单引用
        public PayForm(Order order, OrderForm form)
        {
            InitializeComponent();
            // 设置窗体初始位置为屏幕中心
            this.StartPosition = FormStartPosition.CenterScreen;
            this.currentOrder = order;  // 保存订单信息
        }

        private void PayForm_Load(object sender, EventArgs e)
        {
            // 显示当前订单的总金额
            textBox1.Text = currentOrder.TotalPrice.ToString("F2");  // 保留两位小数
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 模拟支付逻辑，假设支付成功
            bool paymentSuccessful = true;  // 假设支付成功，你可以根据实际情况进行修改

            if (paymentSuccessful)
            {
                // 更新订单状态为已支付
                currentOrder.OrderStatus = "已支付";

                // 调用 OrderForm 中的更新订单状态方法
                UpdateOrderStatusInDatabase(currentOrder.OrderID, "已支付");

                // 弹出感谢购买的消息
                MessageBox.Show("感谢你的购买。", "支付成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 关闭支付窗体
                this.Close();
            }
            else
            {
                // 如果支付失败
                MessageBox.Show("支付失败，请稍后再试。", "支付失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // OrderForm 中的更新订单状态方法
        public void UpdateOrderStatusInDatabase(int orderId, string newStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE Orders SET OrderStatus = @OrderStatus WHERE OrderID = @OrderID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@OrderStatus", "已支付");
                        cmd.Parameters.AddWithValue("@OrderID", orderId);

                        cmd.ExecuteNonQuery();  // 执行更新操作
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新订单状态失败: " + ex.Message);
                }
            }
        }

    }
}
