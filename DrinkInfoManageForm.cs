using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace BeverageManagement
{
    public partial class DrinkInfoManageForm : Form
    {
        public DrinkInfoManageForm()
        {
            InitializeComponent();
        }

        private void DrinkInfoManageForm_Load(object sender, EventArgs e)
        {
            LoadDrinkData();
        }
        public void InitializeForm()
        {
             // 重新加载数据
            LoadDrinkData();
        }

        // 加载饮品列表
        private void LoadDrinkData()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;
Integrated Security=True;Connect Timeout=30";
            string query = "SELECT DrinkID, DrinkName, Category, Price FROM Drinks";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewDrinks.DataSource = dt;
            }
        }

        // 点击添加按钮时弹出添加饮品窗体
        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            // 弹出添加窗体
            DrinkForm addForm = new DrinkForm();
            addForm.ShowDialog();

          
            LoadDrinkData();
        }

        // 点击编辑按钮时弹出编辑饮品窗体
        private void btnEditDrink_Click(object sender, EventArgs e)
        {
            if (dataGridViewDrinks.SelectedRows.Count > 0)
            {
                int drinkId = Convert.ToInt32(dataGridViewDrinks.SelectedRows[0].Cells["DrinkID"].Value);
                string drinkName = dataGridViewDrinks.SelectedRows[0].Cells["DrinkName"].Value.ToString();
                string category = dataGridViewDrinks.SelectedRows[0].Cells["Category"].Value.ToString();
                decimal price = Convert.ToDecimal(dataGridViewDrinks.SelectedRows[0].Cells["Price"].Value);

                // 弹出编辑窗体并传入数据
                DrinkForm editForm = new DrinkForm(true, drinkId, drinkName, category, price);
                editForm.ShowDialog();

                // 重新加载数据
                LoadDrinkData();
            }
            else
            {
                MessageBox.Show("请先选择一个饮品进行编辑。");
            }
        }

        // 点击删除按钮时删除选中的饮品
        private void btnDeleteDrink_Click(object sender, EventArgs e)
        {
            if (dataGridViewDrinks.SelectedRows.Count > 0)
            {
                int drinkId = Convert.ToInt32(dataGridViewDrinks.SelectedRows[0].Cells["DrinkID"].Value);
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;
Integrated Security=True;Connect Timeout=30";
                string query = "DELETE FROM Drinks WHERE DrinkID = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", drinkId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("饮品已删除！");
                LoadDrinkData(); // 重新加载饮品列表
            }
            else
            {
                MessageBox.Show("请先选择一个饮品进行删除。");
            }
        }

        // 搜索功能
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;
Integrated Security=True;Connect Timeout=30";
            string query = "SELECT DrinkID, DrinkName, Category, Price FROM Drinks WHERE DrinkName LIKE @search OR Category LIKE @search";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewDrinks.DataSource = dt;
            }
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;
Integrated Security=True;Connect Timeout=30";

            // 清空所有记录的查询
            string deleteQuery = "DELETE FROM Drinks";
            // 重置自增计数器的查询
            string resetQuery = "DBCC CHECKIDENT ('Drinks', RESEED, 0)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 开始事务，确保操作的原子性
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 执行删除所有记录
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction);
                    deleteCmd.ExecuteNonQuery();

                    // 重置自增计数器
                    SqlCommand resetCmd = new SqlCommand(resetQuery, conn, transaction);
                    resetCmd.ExecuteNonQuery();

                    // 提交事务
                    transaction.Commit();

                    MessageBox.Show("所有数据已清空，并且自增计数器已重置。");

                    // 重新加载数据
                    LoadDrinkData();
                }
                catch (Exception ex)
                {
                    // 如果出现错误，回滚事务
                    transaction.Rollback();
                    MessageBox.Show("操作失败：" + ex.Message);
                }
            }
        }

       
    }
}
