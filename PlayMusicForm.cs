using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace BeverageManagement
{
    public partial class PlayMusicForm : Form
    {
        private BindingList<string> musicFiles = new BindingList<string>(); // 使用 BindingList 来支持数据绑定

        public PlayMusicForm()
        {
            InitializeComponent();
        }

        private void PlayMusicForm_Load(object sender, EventArgs e)
        {
          
            // 检查并加载音乐文件
            string musicDirectory = @"D:\BeverageManagement\Resource";
            string filePath = Path.Combine(musicDirectory, "musicFiles.txt");

            // 检查目录是否存在，不存在则创建
            if (!Directory.Exists(musicDirectory))
            {
                Directory.CreateDirectory(musicDirectory); // 创建目录
            }

            // 如果文件不存在，则创建并初始化
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose(); // 创建空的文件
            }

            // 读取保存的音乐文件路径并显示
            List<string> musicFileList = new List<string>(File.ReadAllLines(filePath));
            // 绑定到 musicFiles（BindingList）上，ListBox 会自动更新
            foreach (var music in musicFileList)
            {
                musicFiles.Add(music);
            }

            // 将 musicFiles 绑定到 ListBox 控件
            listBoxMusicFiles.DataSource = musicFiles;
        }

        // 点击按钮选择音乐文件
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "音频文件 (*.mp3;*.wav;*.mp4;*.midi)|*.mp3;*.m4a,*.wav;*.mp4;*.midi", // 支持多种格式
                Title = "选择音频文件"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // 播放音乐
                axWindowsMediaPlayer1.URL = filePath;
                axWindowsMediaPlayer1.Ctlcontrols.play();

                // 获取保存路径并更新音乐文件列表
                string musicFilesPath = @"D:\BeverageManagement\Resource\musicFiles.txt";

                // 读取现有的音乐文件路径列表
                List<string> musicFileList = new List<string>(File.ReadAllLines(musicFilesPath));

                // 如果该文件路径还没有被添加到列表中，则添加它
                if (!musicFileList.Contains(filePath))
                {
                    musicFileList.Add(filePath);
                    File.WriteAllLines(musicFilesPath, musicFileList); // 保存更新后的列表
                }

                // 将更新后的音乐列表绑定到 ListBox 上
                musicFiles.Clear();
                foreach (var music in musicFileList)
                {
                    musicFiles.Add(music);
                }
            }
        }

        // 当选择某个音乐文件时播放
        private void listBoxMusicFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMusicFiles.SelectedIndex >= 0)
            {
                string selectedFilePath = musicFiles[listBoxMusicFiles.SelectedIndex];
                axWindowsMediaPlayer1.URL = selectedFilePath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                lblCurrentMusic.Text = $"当前音乐：{Path.GetFileName(selectedFilePath)}";
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
          
            
                if (listBoxMusicFiles.SelectedIndex >= 0)
                {
                    // 获取选中的音乐文件路径
                    string selectedFilePath = musicFiles[listBoxMusicFiles.SelectedIndex];
                    string musicFileName = Path.GetFileName(selectedFilePath); // 获取文件名

                    // 从 BindingList 中删除
                    musicFiles.Remove(selectedFilePath);

                    // 删除音乐文件路径
                    string musicFilesPath = @"D:\BeverageManagement\Resource\musicFiles.txt";
                    List<string> musicFileList = new List<string>(File.ReadAllLines(musicFilesPath));

                    // 从列表中删除该音乐文件路径
                    musicFileList.Remove(selectedFilePath);

                    // 保存更新后的文件路径列表
                    File.WriteAllLines(musicFilesPath, musicFileList);

                    // 刷新 ListBox 显示
                    listBoxMusicFiles.DataSource = null;
                    listBoxMusicFiles.DataSource = musicFiles;

           
                    MessageBox.Show($"音乐文件 '{musicFileName}' 已删除！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("请先选择一个音乐文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }
    }
    
}
