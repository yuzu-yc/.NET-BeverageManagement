using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeverageManagement
{
    public partial class PersonInfoForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;Integrated Security=True;Connect Timeout=30";
        private DataRow staffInfo; // 保存当前用户信息

        // 构造函数，接收登录用户信息
        public PersonInfoForm(DataRow staffInfo)
        {
            InitializeComponent();
            this.staffInfo = staffInfo;
        }

        private void PersonInfoForm_Load(object sender, EventArgs e)
        {
            if (staffInfo != null)
            {
                // 填充用户信息到控件
                textBox1.Text = staffInfo["username"].ToString(); // 用户名
                textBox2.Text = staffInfo["password"].ToString(); // 密码
                textBox4.Text = staffInfo["real_name"].ToString(); // 真实姓名
                textBox5.Text = staffInfo["telephone"].ToString(); // 电话号码

                // 性别处理：0为女，1为男
                string gender = staffInfo["gender"].ToString();
                comboBox1.SelectedItem = gender == "0" ? "女" : "男"; // 使用 ComboBox 选择性别
            }
            // 加载所有人员信息
            LoadAllStaffInfo();
        }

        // 加载所有人员信息到 DataGridView
        private void LoadAllStaffInfo()
        {
            try
            {
                string query = "SELECT user_id,real_name,  gender, telephone, username,password FROM user_info";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // 将数据绑定到 DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载人员信息时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
        // 更新用户信息到数据库
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 获取控件内容
                string realName = textBox4.Text.Trim();
                string telephone = textBox5.Text.Trim();
                string gender = comboBox1.SelectedItem.ToString() == "男" ? "1" : "0"; // 获取ComboBox选择的性别并转换为数字
                string username = textBox1.Text.Trim(); // 获取用户名
                string password = textBox2.Text.Trim(); // 获取密码

                // 构建提示框内容，展示修改后的数据
                string message = $"修改后的信息：\n\n" +
                                 $"用户名: {username}\n" +
                                 $"密码: {password}\n" +
                                 $"真实姓名: {realName}\n" +
                                 $"电话: {telephone}\n" +
                                 $"性别: {(gender == "1" ? "男" : "女")}";

                // 弹出询问框，确认是否保存修改
                DialogResult dialogResult = MessageBox.Show(message + "\n\n是否保存修改的用户信息？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // 如果用户点击了“是”，继续执行保存操作
                if (dialogResult == DialogResult.Yes)
                {
                    // SQL 更新语句
                    string updateQuery = @"
                UPDATE user_info 
                SET real_name = @realName, telephone = @telephone, gender = @gender 
                WHERE username = @username";

                    // 执行更新
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@realName", realName);
                            command.Parameters.AddWithValue("@telephone", telephone);
                            command.Parameters.AddWithValue("@gender", gender);
                            command.Parameters.AddWithValue("@username", staffInfo["username"].ToString());

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("用户信息更新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // 同步更新本地数据
                                staffInfo["real_name"] = realName;
                                staffInfo["telephone"] = telephone;
                                staffInfo["gender"] = gender;
                                // 重新加载数据
                                LoadAllStaffInfo();
                            }
                            else
                            {
                                MessageBox.Show("更新失败，请重试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    // 用户选择了“否”，取消保存操作
                    MessageBox.Show("未保存任何修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //删除
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["user_id"].Value);

                string query = "DELETE FROM user_info WHERE user_id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", userid);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("用户已删除！");
                LoadAllStaffInfo();
            }
            else
            {
                MessageBox.Show("请先选择一个用户。");
            }
        }
        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            // 点击添加按钮时弹出添加饮品窗体
           
            {
                // 弹出添加窗体
                UserInfoForm userinfoForm = new UserInfoForm();
                userinfoForm.ShowDialog();

                // 重新加载数据
                LoadAllStaffInfo();

            }

        }

        //编辑
        // 编辑按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
 
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 获取选中的用户信息
                int userid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["user_id"].Value);
                string username = dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();
                string password = dataGridView1.SelectedRows[0].Cells["password"].Value.ToString();
                string realName = dataGridView1.SelectedRows[0].Cells["real_name"].Value.ToString();
                long telephone = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["telephone"].Value);
                int gender = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["gender"].Value);
                // 弹出编辑用户信息的窗体
                UserInfoForm editForm = new UserInfoForm(true, userid, username, password,realName, telephone, gender);
                editForm.ShowDialog();

                LoadAllStaffInfo();
            }
            else
            {
                // 如果没有选中任何用户，提示用户进行选择
                MessageBox.Show("请先选择一个用户进行编辑。");
            }
        }

    }
}
