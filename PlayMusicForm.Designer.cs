namespace BeverageManagement
{
    partial class PlayMusicForm
    {
        private System.ComponentModel.IContainer components = null;

       

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayMusicForm));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.lblCurrentMusic = new System.Windows.Forms.Label();
            this.listBoxMusicFiles = new System.Windows.Forms.ListBox();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(70, 424);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(132, 33);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "本地选择";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(406, 105);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(287, 274);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // lblCurrentMusic
            // 
            this.lblCurrentMusic.AutoSize = true;
            this.lblCurrentMusic.Location = new System.Drawing.Point(403, 49);
            this.lblCurrentMusic.Name = "lblCurrentMusic";
            this.lblCurrentMusic.Size = new System.Drawing.Size(98, 18);
            this.lblCurrentMusic.TabIndex = 2;
            this.lblCurrentMusic.Text = "当前音乐：";
            // 
            // listBoxMusicFiles
            // 
            this.listBoxMusicFiles.FormattingEnabled = true;
            this.listBoxMusicFiles.ItemHeight = 18;
            this.listBoxMusicFiles.Location = new System.Drawing.Point(40, 105);
            this.listBoxMusicFiles.Name = "listBoxMusicFiles";
            this.listBoxMusicFiles.Size = new System.Drawing.Size(321, 274);
            this.listBoxMusicFiles.TabIndex = 3;
            this.listBoxMusicFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxMusicFiles_SelectedIndexChanged);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(241, 424);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(120, 31);
            this.btnDeleteFile.TabIndex = 4;
            this.btnDeleteFile.Text = "删除";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "音乐详情：";
            // 
            // PlayMusicForm
            // 
            this.ClientSize = new System.Drawing.Size(838, 506);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.listBoxMusicFiles);
            this.Controls.Add(this.lblCurrentMusic);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "PlayMusicForm";
            this.Text = "音乐播放器";
            this.Load += new System.EventHandler(this.PlayMusicForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnOpenFile; // 选择音乐文件按钮
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1; // 媒体播放器控件
        private System.Windows.Forms.Label lblCurrentMusic; // 当前音乐名称显示标签
        private System.Windows.Forms.ListBox listBoxMusicFiles; // 显示音乐文件列表
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Label label1;
    }
}
