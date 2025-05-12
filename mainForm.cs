using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BeverageManagement
{
    public partial class mainForm : Form
    {
        // 存储已打开的子窗体实例
        private Dictionary<string, Form> openForms = new Dictionary<string, Form>();

        private DataRow current_staff_info;
        private loginForm login_form;


        private bool isWelcomeMessageVisible = true; // 标志位，记录是否显示欢迎信息

        public mainForm(DataRow staff_info, loginForm login_form)
        {
            InitializeComponent();
            this.IsMdiContainer = true;  // 设置主窗体为MDI容器
            this.StartPosition = FormStartPosition.CenterScreen; // 设置窗体初始位置为屏幕中心
            current_staff_info = staff_info;
            this.login_form = login_form;
            initialize_status_strip();
            string real_name = current_staff_info["real_name"].ToString();
            label1.Text = $"欢迎来到饮品信息管理系统 ！{real_name}";
            this.MdiChildActivate += MainForm_MdiChildActivate; // 监听MDI子窗体激活事件
        }

        
        // 显示或隐藏欢迎信息
        private void ToggleWelcomeMessage(bool show)
        {
           
            isWelcomeMessageVisible = show;
            if (welcomePanel != null)
            {
                welcomePanel.Visible = show;
            }
        }

        // 初始化状态栏
        private void initialize_status_strip()
        {
            string real_name = current_staff_info["real_name"].ToString();
            string username = current_staff_info["username"].ToString();
            statusStripStaffLabel.Text = $"{real_name} (用户名: {username})";
          
        }

        // 打开订单管理子窗体
        private void orderMenuItem_Click(object sender, EventArgs e)
        {
            string formKey = "OrderForm";

            // 如果子窗体不存在或已被关闭，则创建并显示新窗体
            if (!openForms.ContainsKey(formKey) || openForms[formKey].IsDisposed)
            {
                var orderForm = new OrderForm(current_staff_info)
                {
                    MdiParent = this, 
                    WindowState = FormWindowState.Maximized 
                };
                orderForm.FormClosed += (s, args) => ToggleWelcomeMessage(true); 
                orderForm.SizeChanged += OrderForm_SizeChanged; 
                orderForm.Show();
                openForms[formKey] = orderForm; 
                ToggleWelcomeMessage(false); 
            }
            else
            {
                openForms[formKey].Activate();
                openForms[formKey].WindowState = FormWindowState.Maximized; 
            }
        }

        // 打开员工信息管理子窗体
        private void staffInfoManageMenuItem_Click(object sender, EventArgs e)
        {
            string formKey = "PersonInfoForm";

           
            if (!openForms.ContainsKey(formKey) || openForms[formKey].IsDisposed)
            {
                var staffInfoForm = new PersonInfoForm(current_staff_info)
                {
                    MdiParent = this, 
                    WindowState = FormWindowState.Maximized 
                };
                staffInfoForm.FormClosed += (s, args) => ToggleWelcomeMessage(true); 
                staffInfoForm.SizeChanged += OrderForm_SizeChanged; 
                staffInfoForm.Show(); 
                openForms[formKey] = staffInfoForm; 
                ToggleWelcomeMessage(false); 
            }
            else
            {
                openForms[formKey].Activate(); //
                openForms[formKey].WindowState = FormWindowState.Maximized; 
            }
        }

        // 子窗体的大小改变时处理逻辑
        private void OrderForm_SizeChanged(object sender, EventArgs e)
        {
            var form = sender as Form;
            if (form.WindowState != FormWindowState.Maximized)
            {
                // 子窗体不是全屏时，恢复欢迎信息并设置窗体为非全屏
                ToggleWelcomeMessage(true); // 显示欢迎信息
            }
            else
            {
                // 子窗体为全屏时，隐藏欢迎信息
                ToggleWelcomeMessage(false); // 隐藏欢迎信息
            }
        }

        // 打开饮品信息管理子窗体
        private void drinkInfoManageMenuItem_Click(object sender, EventArgs e)
        {
            string formKey = "DrinkInfoManageForm";

           
            if (!openForms.ContainsKey(formKey) || openForms[formKey].IsDisposed)
            {
                var drinkInfoForm = new DrinkInfoManageForm
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized 
                };
                drinkInfoForm.FormClosed += (s, args) => ToggleWelcomeMessage(true);
                drinkInfoForm.SizeChanged += OrderForm_SizeChanged; 
                drinkInfoForm.Show(); 
                openForms[formKey] = drinkInfoForm;
                ToggleWelcomeMessage(false);
            }
            else
            {
                openForms[formKey].Activate();
                openForms[formKey].WindowState = FormWindowState.Maximized; 
            }
        }

        // 打开订单查询子窗体
        private void orderInfoQueryMenuItem_Click(object sender, EventArgs e)
        {
            string formKey = "OrderInfoQForm";

           
            if (!openForms.ContainsKey(formKey) || openForms[formKey].IsDisposed)
            {
                var orderqForm = new OrderInfoQForm()
                {
                    MdiParent = this, 
                    WindowState = FormWindowState.Maximized 
                };
                orderqForm.FormClosed += (s, args) => ToggleWelcomeMessage(true); 
                orderqForm.SizeChanged += OrderForm_SizeChanged; 
                orderqForm.Show(); 
                openForms[formKey] = orderqForm; 
                ToggleWelcomeMessage(false); 
            }
            else
            {
                openForms[formKey].Activate(); 
                openForms[formKey].WindowState = FormWindowState.Maximized; 
            }
        }
        // 播放音乐菜单项
        private void playMusicMenuItem_Click(object sender, EventArgs e)
        {
            string formKey = "PlayMusicForm";

            
            if (!openForms.ContainsKey(formKey) || openForms[formKey].IsDisposed)
            {
                var musicForm = new PlayMusicForm()
                {
                    MdiParent = this, 
                    WindowState = FormWindowState.Maximized 
                };
                musicForm.FormClosed += (s, args) => ToggleWelcomeMessage(true);
                musicForm.Show();
                openForms[formKey] = musicForm; 
                ToggleWelcomeMessage(false);
            }
            else
            {
                openForms[formKey].Activate();
                openForms[formKey].WindowState = FormWindowState.Maximized; 
            }
        }

        // 更新状态栏时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString();
        }

        // 当子窗体关闭时，自动恢复欢迎信息
       // 监听MDI子窗体的激活事件
        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                // 如果没有活动的子窗体，显示欢迎信息
                ToggleWelcomeMessage(true);
            }
            else
            {
                // 激活子窗体时，将其显示在欢迎信息面板之上
                this.ActiveMdiChild.BringToFront();  // 将子窗体置于最前面
            }
        }

        // 退出应用
        
        private void exitLoginMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
            loginForm login = new loginForm();
            login.Show();

        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {

               Application.Exit();  
        }
    }
}
