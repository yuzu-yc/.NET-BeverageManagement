using System.ComponentModel;
using System.Windows.Forms;

namespace BeverageManagement
{
    partial class mainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drinkInfoManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffInfoManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitLoginMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playMusicMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QueryCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.orderInfoQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripStaffLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.welcomePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem,
            this.orderToolStripMenuItem,
            this.QueryCenter});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1179, 32);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drinkInfoManageMenuItem,
            this.staffInfoManageMenuItem,
            this.exitLoginMenuItem,
            this.exitMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.manageToolStripMenuItem.Text = "系统管理";
            // 
            // drinkInfoManageMenuItem
            // 
            this.drinkInfoManageMenuItem.Name = "drinkInfoManageMenuItem";
            this.drinkInfoManageMenuItem.Size = new System.Drawing.Size(218, 34);
            this.drinkInfoManageMenuItem.Text = "饮品信息管理";
            this.drinkInfoManageMenuItem.Click += new System.EventHandler(this.drinkInfoManageMenuItem_Click);
            // 
            // staffInfoManageMenuItem
            // 
            this.staffInfoManageMenuItem.Name = "staffInfoManageMenuItem";
            this.staffInfoManageMenuItem.Size = new System.Drawing.Size(218, 34);
            this.staffInfoManageMenuItem.Text = "员工信息管理";
            this.staffInfoManageMenuItem.Click += new System.EventHandler(this.staffInfoManageMenuItem_Click);
            // 
            // exitLoginMenuItem
            // 
            this.exitLoginMenuItem.Name = "exitLoginMenuItem";
            this.exitLoginMenuItem.Size = new System.Drawing.Size(218, 34);
            this.exitLoginMenuItem.Text = "退出登录";
            this.exitLoginMenuItem.Click += new System.EventHandler(this.exitLoginMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(218, 34);
            this.exitMenuItem.Text = "退出系统";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderMenuItem,
            this.playMusicMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.orderToolStripMenuItem.Text = "点餐服务";
            // 
            // orderMenuItem
            // 
            this.orderMenuItem.Name = "orderMenuItem";
            this.orderMenuItem.Size = new System.Drawing.Size(182, 34);
            this.orderMenuItem.Text = "点餐收银";
            this.orderMenuItem.Click += new System.EventHandler(this.orderMenuItem_Click);
            // 
            // playMusicMenuItem
            // 
            this.playMusicMenuItem.Name = "playMusicMenuItem";
            this.playMusicMenuItem.Size = new System.Drawing.Size(182, 34);
            this.playMusicMenuItem.Text = "音乐播放";
            this.playMusicMenuItem.Click += new System.EventHandler(this.playMusicMenuItem_Click);
            // 
            // QueryCenter
            // 
            this.QueryCenter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderInfoQueryMenuItem});
            this.QueryCenter.Name = "QueryCenter";
            this.QueryCenter.Size = new System.Drawing.Size(98, 28);
            this.QueryCenter.Text = "查询中心";
            // 
            // orderInfoQueryMenuItem
            // 
            this.orderInfoQueryMenuItem.Name = "orderInfoQueryMenuItem";
            this.orderInfoQueryMenuItem.Size = new System.Drawing.Size(218, 34);
            this.orderInfoQueryMenuItem.Text = "营业信息查询";
            this.orderInfoQueryMenuItem.Click += new System.EventHandler(this.orderInfoQueryMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel1,
            this.statusStripStaffLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip.Location = new System.Drawing.Point(0, 811);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 15, 0);
            this.statusStrip.Size = new System.Drawing.Size(1179, 31);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel1
            // 
            this.statusStripLabel1.Name = "statusStripLabel1";
            this.statusStripLabel1.Size = new System.Drawing.Size(104, 24);
            this.statusStripLabel1.Text = "当前操作员:";
            // 
            // statusStripStaffLabel
            // 
            this.statusStripStaffLabel.Name = "statusStripStaffLabel";
            this.statusStripStaffLabel.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(115, 24);
            this.toolStripStatusLabel1.Text = "                     ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(225, 24);
            this.toolStripStatusLabel2.Text = "                         当前时间：";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 24);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // welcomePanel
            // 
            this.welcomePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.welcomePanel.Controls.Add(this.label1);
            this.welcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomePanel.Location = new System.Drawing.Point(0, 32);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(1179, 779);
            this.welcomePanel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 28F);
            this.label1.Location = new System.Drawing.Point(66, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1088, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎来到饮品店信息管理系统！（登录用户）";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 842);
            this.Controls.Add(this.welcomePanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainForm";
            this.Text = "饮品店信息管理系统";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        // 菜单相关
        private System.Windows.Forms.ToolStripMenuItem playMusicMenuItem;  // 音乐播放菜单项
        private System.Windows.Forms.ToolStripMenuItem exitLoginMenuItem;  // 退出登录菜单项
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;  // 退出系统菜单项
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;  // 点餐服务菜单
        private System.Windows.Forms.ToolStripMenuItem orderMenuItem;  // 点餐收银菜单项
        private System.Windows.Forms.ToolStripMenuItem QueryCenter;  // 查询中心菜单
        private System.Windows.Forms.ToolStripMenuItem orderInfoQueryMenuItem;  // 营业信息查询菜单项
        private System.Windows.Forms.ToolStripMenuItem drinkInfoManageMenuItem;  // 饮品信息管理菜单项
        private System.Windows.Forms.ToolStripMenuItem staffInfoManageMenuItem;  // 员工信息管理菜单项
        private System.Windows.Forms.MenuStrip menuStrip;  // 主菜单栏
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;  // 系统管理菜单项

        // 状态条相关
     
        private System.Windows.Forms.ToolStripStatusLabel statusStripStaffLabel;  // 状态条显示当前操作员
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel1;  // 状态条标签1
        private System.Windows.Forms.StatusStrip statusStrip;  // 状态条控件

        // 控件相关



        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.Label label1;
      
    }
}