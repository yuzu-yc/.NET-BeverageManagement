using System.ComponentModel;
using System.Windows.Forms;

namespace BeverageManagement
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.drinkInfoListView = new System.Windows.Forms.ListView();
            this.orderInfoListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_drinkName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numBox_count = new System.Windows.Forms.NumericUpDown();
            this.btn_AddToOrder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBox_count)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(48, 48);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择饮品";
            // 
            // drinkInfoListView
            // 
            this.drinkInfoListView.HideSelection = false;
            this.drinkInfoListView.LargeImageList = this.imageList;
            this.drinkInfoListView.Location = new System.Drawing.Point(18, 41);
            this.drinkInfoListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drinkInfoListView.MultiSelect = false;
            this.drinkInfoListView.Name = "drinkInfoListView";
            this.drinkInfoListView.Size = new System.Drawing.Size(486, 420);
            this.drinkInfoListView.TabIndex = 1;
            this.drinkInfoListView.UseCompatibleStateImageBehavior = false;
            this.drinkInfoListView.View = System.Windows.Forms.View.Details;
            this.drinkInfoListView.SelectedIndexChanged += new System.EventHandler(this.drinkInfoListView_SelectedIndexChanged);
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
            this.orderInfoListView.Location = new System.Drawing.Point(554, 41);
            this.orderInfoListView.MultiSelect = false;
            this.orderInfoListView.Name = "orderInfoListView";
            this.orderInfoListView.Size = new System.Drawing.Size(506, 322);
            this.orderInfoListView.TabIndex = 4;
            this.orderInfoListView.UseCompatibleStateImageBehavior = false;
            this.orderInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "数量";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "单价";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "总价";
            this.columnHeader4.Width = 80;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(18, 538);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(191, 204);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 581);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "饮品名称：";
            // 
            // label_drinkName
            // 
            this.label_drinkName.AutoSize = true;
            this.label_drinkName.Location = new System.Drawing.Point(315, 581);
            this.label_drinkName.Name = "label_drinkName";
            this.label_drinkName.Size = new System.Drawing.Size(0, 18);
            this.label_drinkName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 638);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "价格：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 691);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "数量：";
            // 
            // numBox_count
            // 
            this.numBox_count.Location = new System.Drawing.Point(292, 686);
            this.numBox_count.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numBox_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBox_count.Name = "numBox_count";
            this.numBox_count.Size = new System.Drawing.Size(87, 28);
            this.numBox_count.TabIndex = 15;
            this.numBox_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBox_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_AddToOrder
            // 
            this.btn_AddToOrder.Location = new System.Drawing.Point(459, 670);
            this.btn_AddToOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_AddToOrder.Name = "btn_AddToOrder";
            this.btn_AddToOrder.Size = new System.Drawing.Size(93, 55);
            this.btn_AddToOrder.TabIndex = 18;
            this.btn_AddToOrder.Text = "加入订单";
            this.btn_AddToOrder.UseVisualStyleBackColor = true;
            this.btn_AddToOrder.Click += new System.EventHandler(this.btn_AddToOrder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(731, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 40);
            this.button1.TabIndex = 19;
            this.button1.Text = "确认订单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 784);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_AddToOrder);
            this.Controls.Add(this.numBox_count);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_drinkName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.drinkInfoListView);
            this.Controls.Add(this.orderInfoListView);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OrderForm";
            this.Text = "点餐收银";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBox_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private System.Windows.Forms.Button btn_AddToOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numBox_count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_drinkName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView drinkInfoListView;
        private System.Windows.Forms.ListView orderInfoListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList imageList;
        private Button button1;
        #endregion


    }
}