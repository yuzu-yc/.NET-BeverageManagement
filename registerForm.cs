using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BeverageManagement
{
    public partial class registerForm : Form
    {
        private loginForm _loginForm;  // 声明一个登录页面实例
        public registerForm(loginForm loginForm)
        {
            InitializeComponent();
            // 设置窗体初始位置为屏幕中心
            this.StartPosition = FormStartPosition.CenterScreen;
            _loginForm = loginForm;  // 保存登录页面实例
        }

        // 注册按钮事件
        private void btn_register_Click(object sender, EventArgs e)
        {
            // 获取用户输入的数据
            string username = txtBox_username.Text.Trim();
            string password = txtBox_password.Text.Trim();
            string realName = txtBox_name.Text.Trim();
            int? gender = btn_male.Checked ? 0 : (btn_female.Checked ? 1 : (int?)null);  // 男为0，女为1，未选择为null
            string telephone = txtBox_telephone.Text.Trim();

            // 输入验证
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(realName) || !gender.HasValue || string.IsNullOrEmpty(telephone))
            {
                MessageBox.Show("所有字段都必须填写", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 验证电话号码格式（简单示例，可以根据需要进一步验证）
            if (!Regex.IsMatch(telephone, @"^1[3-9]\d{9}$"))
            {
                MessageBox.Show("请输入有效的电话号码", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 使用 DBOperator 进行数据库操作
            DBOperator dbOperator = DBOperator.Instance;
            dbOperator.ConnectDB();  // 确保数据库连接已打开

            try
            {
                // 检查用户名是否已存在
                if (dbOperator.UserExists(username))
                {
                    MessageBox.Show("该用户名已被注册", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 插入新用户数据
                string insertQuery = "INSERT INTO user_info (username, password, real_name, gender, telephone, user_type) " +
                                     "VALUES (@username, @password, @real_name, @gender, @telephone, 0)"; // 默认user_type为0（普通用户）

                SqlParameter[] parameters = {//加N支持中文   
                    new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
                    new SqlParameter("@password", SqlDbType.VarChar) { Value = password },  // 密码存储时，建议加密处理
                    new SqlParameter("@real_name", SqlDbType.NVarChar) { Value = realName },
                    new SqlParameter("@gender", SqlDbType.Int) { Value = gender.HasValue ? (object)gender.Value : DBNull.Value },
                    new SqlParameter("@telephone", SqlDbType.VarChar) { Value = telephone }
                };

                int rowsAffected = dbOperator.TableExecuteWithParams(insertQuery, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 注册成功后关闭注册窗口并返回登录窗口
                    this.Close();  
                    _loginForm.Show(); 
                }
                else
                {
                    MessageBox.Show("注册失败，请稍后重试", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbOperator.CloseDB();  // 关闭数据库连接
            }
        }

        // 返回登录页面
        private void button1_Click(object sender, EventArgs e)
        {
            _loginForm.Show();  
            this.Close(); 
        }

        
    }
}
