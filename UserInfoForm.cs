using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeverageManagement
{
    public partial class UserInfoForm : Form
    {
        private bool isEditMode = false; // 是否是编辑模式
        private int userId = 0; // 用于编辑时存储饮品ID
        public UserInfoForm(bool editMode = false, int id = 0, string username = "", string password = "", string realName = "", long telephone = 0, int gender = 0)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            isEditMode = editMode;
            userId = id;
            // 如果是编辑模式，加载现有用户的信息
            if (isEditMode)
            {
                txtUsername.Text = username;
                txtPassword.Text = password;
                txtRealName.Text = realName;
                txtTelephone.Text = telephone.ToString();
                cmbGender.SelectedItem = gender == 1 ? "男" : "女"; // 设置选中的性别
                btnSave.Text = "保存修改";
            }
            else
            {
                btnSave.Text = "添加用户";
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string realName = txtRealName.Text;
            string telephoneText = txtTelephone.Text;
            string genderText = cmbGender.SelectedItem?.ToString(); // 获取选中的性别

            // 检查输入是否合法
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(realName) && !string.IsNullOrEmpty(telephoneText) && !string.IsNullOrEmpty(genderText))
            {
                long telephone;
                if (!long.TryParse(telephoneText, out telephone))
                {
                    MessageBox.Show("请输入有效的电话号码。");
                    return;
                }

                int gender = genderText == "男" ? 1 : 0; // "男"为1，"女"为0
               

                if (isEditMode)
                {
                    // 编辑模式，更新用户信息
                    UpdateUser(userId,username, password, realName, telephone, gender);
                    MessageBox.Show("用户信息已更新！");
                }
                else
                {
                    // 添加模式，添加新用户
                    AddNewUser(username, password, realName, telephone, gender);
                    MessageBox.Show("用户已成功添加！");
                }
                this.Close(); // 关闭窗体
            }
            else
            {
                MessageBox.Show("请确保所有字段都已填写。");
            }
        }

        // 添加新用户
        private void AddNewUser(string username, string password, string realName, long telephone, int gender)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "INSERT INTO [dbo].[user_info] (username, password, real_name, telephone, gender, user_type) " +
                           "VALUES (@username, @password, @realName, @telephone, @gender, 0)";//uertype默认为0

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@realName", realName);
                    cmd.Parameters.AddWithValue("@telephone", telephone);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 更新用户信息
        private void UpdateUser(int id,string username, string password, string realName, long telephone, int gender)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "UPDATE [dbo].[user_info] SET username = @username, password = @password, real_name = @realName, " +
                           "telephone = @telephone, gender = @gender, user_type =0 WHERE user_id = @id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@realName", realName);
                    cmd.Parameters.AddWithValue("@telephone", telephone);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            // 可以在这里添加一些初始化的操作
        }

       
    }
}
