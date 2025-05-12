using System.Windows.Forms;

namespace BeverageManagement
{
    partial class DrinkInfoManageForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewDrinks;
        private System.Windows.Forms.Button btnAddDrink;
        private System.Windows.Forms.Button btnEditDrink;
        private System.Windows.Forms.Button btnDeleteDrink;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;

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
            this.dataGridViewDrinks = new System.Windows.Forms.DataGridView();
            this.btnAddDrink = new System.Windows.Forms.Button();
            this.btnEditDrink = new System.Windows.Forms.Button();
            this.btnDeleteDrink = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrinks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDrinks
            // 
            this.dataGridViewDrinks.AllowUserToAddRows = false;
            this.dataGridViewDrinks.AllowUserToDeleteRows = false;
            this.dataGridViewDrinks.AllowUserToResizeColumns = false;
            this.dataGridViewDrinks.AllowUserToResizeRows = false;
            this.dataGridViewDrinks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDrinks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDrinks.ColumnHeadersHeight = 34;
            this.dataGridViewDrinks.Location = new System.Drawing.Point(34, 88);
            this.dataGridViewDrinks.Name = "dataGridViewDrinks";
            this.dataGridViewDrinks.ReadOnly = true;
            this.dataGridViewDrinks.RowHeadersWidth = 62;
            this.dataGridViewDrinks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDrinks.Size = new System.Drawing.Size(571, 240);
            this.dataGridViewDrinks.TabIndex = 0;
            // 
            // btnAddDrink
            // 
            this.btnAddDrink.Location = new System.Drawing.Point(640, 110);
            this.btnAddDrink.Name = "btnAddDrink";
            this.btnAddDrink.Size = new System.Drawing.Size(100, 36);
            this.btnAddDrink.TabIndex = 1;
            this.btnAddDrink.Text = "添加饮品";
            this.btnAddDrink.UseVisualStyleBackColor = true;
            this.btnAddDrink.Click += new System.EventHandler(this.btnAddDrink_Click);
            // 
            // btnEditDrink
            // 
            this.btnEditDrink.Location = new System.Drawing.Point(640, 192);
            this.btnEditDrink.Name = "btnEditDrink";
            this.btnEditDrink.Size = new System.Drawing.Size(100, 39);
            this.btnEditDrink.TabIndex = 2;
            this.btnEditDrink.Text = "编辑饮品";
            this.btnEditDrink.UseVisualStyleBackColor = true;
            this.btnEditDrink.Click += new System.EventHandler(this.btnEditDrink_Click);
            // 
            // btnDeleteDrink
            // 
            this.btnDeleteDrink.Location = new System.Drawing.Point(640, 264);
            this.btnDeleteDrink.Name = "btnDeleteDrink";
            this.btnDeleteDrink.Size = new System.Drawing.Size(100, 37);
            this.btnDeleteDrink.TabIndex = 3;
            this.btnDeleteDrink.Text = "删除饮品";
            this.btnDeleteDrink.UseVisualStyleBackColor = true;
            this.btnDeleteDrink.Click += new System.EventHandler(this.btnDeleteDrink_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(202, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 28);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(523, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "一键清空重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnResetData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "输入名或类查询";
            // 
            // DrinkInfoManageForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDeleteDrink);
            this.Controls.Add(this.btnEditDrink);
            this.Controls.Add(this.btnAddDrink);
            this.Controls.Add(this.dataGridViewDrinks);
            this.Name = "DrinkInfoManageForm";
            this.Text = "饮品信息管理";
            this.Load += new System.EventHandler(this.DrinkInfoManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrinks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button button1;
        private Label label1;
    }
}
