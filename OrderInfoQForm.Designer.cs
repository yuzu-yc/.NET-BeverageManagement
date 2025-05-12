using System.Windows.Forms;

namespace BeverageManagement
{
    partial class OrderInfoQForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBoxPopularDrink = new System.Windows.Forms.PictureBox();
            this.labelPopularDrinkQuantity = new System.Windows.Forms.Label();
            this.labelPopularDrinkName = new System.Windows.Forms.Label();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelTotalQuantity = new System.Windows.Forms.Label();
            this.labelTotalSales = new System.Windows.Forms.Label();
            this.labelOrderCount = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.orderInfoListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPopularDrink)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1076, 723);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBoxPopularDrink);
            this.tabPage1.Controls.Add(this.labelPopularDrinkQuantity);
            this.tabPage1.Controls.Add(this.labelPopularDrinkName);
            this.tabPage1.Controls.Add(this.buttonQuery);
            this.tabPage1.Controls.Add(this.dateTimePickerEnd);
            this.tabPage1.Controls.Add(this.dateTimePickerStart);
            this.tabPage1.Controls.Add(this.labelTotalQuantity);
            this.tabPage1.Controls.Add(this.labelTotalSales);
            this.tabPage1.Controls.Add(this.labelOrderCount);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1068, 691);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "订单统计";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPopularDrink
            // 
            this.pictureBoxPopularDrink.Location = new System.Drawing.Point(823, 54);
            this.pictureBoxPopularDrink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxPopularDrink.Name = "pictureBoxPopularDrink";
            this.pictureBoxPopularDrink.Size = new System.Drawing.Size(191, 204);
            this.pictureBoxPopularDrink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPopularDrink.TabIndex = 2;
            this.pictureBoxPopularDrink.TabStop = false;
            // 
            // labelPopularDrinkQuantity
            // 
            this.labelPopularDrinkQuantity.AutoSize = true;
            this.labelPopularDrinkQuantity.Location = new System.Drawing.Point(540, 240);
            this.labelPopularDrinkQuantity.Name = "labelPopularDrinkQuantity";
            this.labelPopularDrinkQuantity.Size = new System.Drawing.Size(98, 18);
            this.labelPopularDrinkQuantity.TabIndex = 7;
            this.labelPopularDrinkQuantity.Text = "销冠数量：";
            // 
            // labelPopularDrinkName
            // 
            this.labelPopularDrinkName.AutoSize = true;
            this.labelPopularDrinkName.Location = new System.Drawing.Point(519, 96);
            this.labelPopularDrinkName.Name = "labelPopularDrinkName";
            this.labelPopularDrinkName.Size = new System.Drawing.Size(152, 18);
            this.labelPopularDrinkName.TabIndex = 6;
            this.labelPopularDrinkName.Text = "最受欢迎的饮料：";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(389, 498);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(128, 58);
            this.buttonQuery.TabIndex = 5;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(438, 396);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerEnd.TabIndex = 4;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(161, 396);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerStart.TabIndex = 3;
            // 
            // labelTotalQuantity
            // 
            this.labelTotalQuantity.AutoSize = true;
            this.labelTotalQuantity.Location = new System.Drawing.Point(158, 254);
            this.labelTotalQuantity.Name = "labelTotalQuantity";
            this.labelTotalQuantity.Size = new System.Drawing.Size(125, 18);
            this.labelTotalQuantity.TabIndex = 2;
            this.labelTotalQuantity.Text = "总销售数量: 0";
            // 
            // labelTotalSales
            // 
            this.labelTotalSales.AutoSize = true;
            this.labelTotalSales.Location = new System.Drawing.Point(158, 171);
            this.labelTotalSales.Name = "labelTotalSales";
            this.labelTotalSales.Size = new System.Drawing.Size(107, 18);
            this.labelTotalSales.TabIndex = 1;
            this.labelTotalSales.Text = "总销售额: 0";
            // 
            // labelOrderCount
            // 
            this.labelOrderCount.AutoSize = true;
            this.labelOrderCount.Location = new System.Drawing.Point(158, 72);
            this.labelOrderCount.Name = "labelOrderCount";
            this.labelOrderCount.Size = new System.Drawing.Size(107, 18);
            this.labelOrderCount.TabIndex = 0;
            this.labelOrderCount.Text = "订单总数: 0";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.orderInfoListView);
            this.tabPage2.Controls.Add(this.dataGridViewOrders);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1068, 691);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "订单详情";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "单个订单详细数据：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "订单总数据：";
            // 
            // orderInfoListView
            // 
            this.orderInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.orderInfoListView.FullRowSelect = true;
            this.orderInfoListView.GridLines = true;
            this.orderInfoListView.HideSelection = false;
            this.orderInfoListView.Location = new System.Drawing.Point(18, 417);
            this.orderInfoListView.MultiSelect = false;
            this.orderInfoListView.Name = "orderInfoListView";
            this.orderInfoListView.Size = new System.Drawing.Size(593, 201);
            this.orderInfoListView.TabIndex = 4;
            this.orderInfoListView.UseCompatibleStateImageBehavior = false;
            this.orderInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "数量";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "单价";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "总价";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewOrders.Location = new System.Drawing.Point(18, 77);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 62;
            this.dataGridViewOrders.RowTemplate.Height = 30;
            this.dataGridViewOrders.Size = new System.Drawing.Size(659, 268);
            this.dataGridViewOrders.TabIndex = 0;
            this.dataGridViewOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "订单编号";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "下单日期";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "总价格";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "订单状态";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            // 
            // OrderInfoQForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 729);
            this.Controls.Add(this.tabControl1);
            this.Name = "OrderInfoQForm";
            this.Text = "营业信息查询";
            this.Load += new System.EventHandler(this.OrderInfoQForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPopularDrink)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelOrderCount;
        private System.Windows.Forms.Label labelTotalSales;
        private System.Windows.Forms.Label labelTotalQuantity;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView orderInfoListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private PictureBox pictureBoxPopularDrink;
        private Label labelPopularDrinkQuantity;
        private Label labelPopularDrinkName;
    }
}
