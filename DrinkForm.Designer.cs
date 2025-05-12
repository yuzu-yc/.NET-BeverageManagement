namespace BeverageManagement
{
    partial class DrinkForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtDrinkName;
        private System.Windows.Forms.ComboBox cmbCategory;  // 使用 ComboBox 代替 TextBox
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDrinkName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtDrinkName = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();  // 初始化 ComboBox 控件
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDrinkName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDrinkName
            // 
            this.txtDrinkName.Location = new System.Drawing.Point(130, 30);
            this.txtDrinkName.Name = "txtDrinkName";
            this.txtDrinkName.Size = new System.Drawing.Size(200, 20);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // 设置为下拉列表
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new string[] { "碳酸", "果汁", "乳制", "茶", "功能性","酒" ,"咖啡","其他"}); // 添加选项
            this.cmbCategory.Location = new System.Drawing.Point(130, 70);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 21); // 设置大小
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(130, 110);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 20);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDrinkName
            // 
            this.lblDrinkName.AutoSize = true;
            this.lblDrinkName.Location = new System.Drawing.Point(40, 30);
            this.lblDrinkName.Name = "lblDrinkName";
            this.lblDrinkName.Size = new System.Drawing.Size(56, 13);
            this.lblDrinkName.Text = "饮品名称:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(40, 70);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(56, 13);
            this.lblCategory.Text = "饮品类别:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(40, 110);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(56, 13);
            this.lblPrice.Text = "饮品价格:";
            // 
            // DrinkForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDrinkName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cmbCategory);  // 添加 ComboBox 控件到窗体
            this.Controls.Add(this.txtDrinkName);
            this.Name = "DrinkForm";
            this.Text = "添加/编辑饮品";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
