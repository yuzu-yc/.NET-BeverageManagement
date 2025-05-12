using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeverageManagement
{
    public partial class DrinkForm : Form
    {
        private bool isEditMode = false;
        private int drinkId = 0; // 用于编辑时存储饮品ID

        public DrinkForm(bool editMode = false, int id = 0, string drinkName = "", string category = "", decimal price = 0)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            isEditMode = editMode;
            drinkId = id;

            // 如果是编辑模式，加载现有饮品的信息
            if (isEditMode)
            {
                txtDrinkName.Text = drinkName;
                cmbCategory.SelectedItem = category; // 设置选中的类别
                txtPrice.Text = price.ToString();
                btnSave.Text = "保存修改";
            }
            else
            {
                btnSave.Text = "添加饮品";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string drinkName = txtDrinkName.Text;
            string category = cmbCategory.SelectedItem?.ToString(); // 获取选中的类别
            decimal price = decimal.TryParse(txtPrice.Text, out decimal parsedPrice) ? parsedPrice : 0;

            if (!string.IsNullOrEmpty(drinkName) && !string.IsNullOrEmpty(category) && price > 0)
            {
                // 获取饮料类型的图片路径
                string imagePath = GetDefaultImagePath(category);
                if (isEditMode)
                {
                    // 编辑模式，更新饮品
                    UpdateDrink(drinkId, drinkName, category, price, imagePath);
                    MessageBox.Show("饮品信息已更新！");
                }
                else
                {
                    // 添加模式，添加新饮品
                    AddNewDrink(drinkName, category, price,imagePath);
                    MessageBox.Show("饮品已成功添加！");
                }
                this.Close();  // 关闭窗体
            }
            else
            {
                MessageBox.Show("请确保所有字段都已填写且价格有效。");
            }
        }

        private void AddNewDrink(string name, string category, decimal price, string imagePath)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;
Integrated Security=True;Connect Timeout=30";
            string query = "INSERT INTO Drinks (DrinkName, Category, Price,ImagePath) VALUES (@name, @category, @price,@imagepath)";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@imagePath", imagePath); // 更新图片路径
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private string GetDefaultImagePath(string category)
        {
            // 根据饮料类型设置默认图片路径
            switch (category)
            {
                case "碳酸":
                    return @"D:\BeverageManagement\Resource\Sodas.jpg"; // 你可以根据实际路径修改
                case "果汁":
                    return @"D:\BeverageManagement\Resource\ade.jpg";
                case "茶":
                    return @"D:\BeverageManagement\Resource\tea.jpg";
                case "乳制":
                    return @"D:\BeverageManagement\Resource\milk.jpg";
                case"酒":
                    return @"D:\BeverageManagement\Resource\wine.jpg";
                case "功能性":
                    return @"D:\BeverageManagement\Resource\ernergy.jpg";
                case "咖啡":
                    return @"D:\BeverageManagement\Resource\coffee.jpg";
                default://其他
                    return @"D:\BeverageManagement\Resource\other.jpg"; // 默认其他图片
            }
        }

        private void UpdateDrink(int id, string name, string category, decimal price, string imagePath)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;
Integrated Security=True;Connect Timeout=30";
            string query = "UPDATE Drinks SET DrinkName = @name, Category = @category, Price = @price,ImagePath = @imagepath WHERE DrinkID = @id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@imagePath", imagePath); // 更新图片路径
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
