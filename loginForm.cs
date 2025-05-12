using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace BeverageManagement
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            // 设置窗体初始位置为屏幕中心
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadImage();  // 调用加载图片的方法
        }

        // 登录按钮事件
        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txtBox_username.Text.Trim();
            string password = txtBox_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入用户名和密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 使用 DBOperator 来执行数据库操作
            try
            {
                DBOperator dbOperator = DBOperator.Instance;
                dbOperator.ConnectDB();

                // 查询用户名和密码是否匹配
                string query = "SELECT * FROM user_info WHERE username = @username AND password = @password";
                SqlParameter[] parameters = {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password)  
                };

                // 执行查询并获取结果
                DataTable userInfoTable = dbOperator.TableQueryWithParams(query, parameters);

                if (userInfoTable.Rows.Count == 1)
                {
                    // 登录成功，获取用户详细信息
                    DataRow current_staff_info = userInfoTable.Rows[0];

                    MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 登录成功后跳转到主界面
                    this.Hide();
                    mainForm mainForm = new mainForm(current_staff_info, this);  
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 注册按钮事件
        private void btn_register_Click(object sender, EventArgs e)
        {
            this.Hide();  // 隐藏当前登录窗体
            registerForm registerForm = new registerForm(this);  // 传递注册的窗体
            registerForm.Show();
        }

        // 退出按钮事件
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();  // 退出应用程序
        }

        private void LoadImage()
        {
            try
            {
                // 这里使用绝对路径加载图片
                string imagePath = @"D:\BeverageManagement\Resource\OIP.jpg";
                this.pictureBox1.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载图片时发生错误: " + ex.Message);
            }
        }

       
    }
}
