using System;
using System.IO;
using System.Windows.Forms;
using CrownDripExecutor.Modules; // 引入您修復好的 Functions 模組

namespace CrownDripExecutor
{
    public partial class MainForm : Form
    {
        // 核心修正：移除會導致開機閃退的 [DllImport] 宣告
        // 改由 Functions.CallExploitApiFunction 動態呼叫

        public MainForm()
        {
            this.Text = "CrownDrip Executor";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(300, 200);

            // 安全讀取圖示，即使找不到 icon 也不會導致程式打不開
            try
            {
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "icon.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(iconPath);
                }
                else
                {
                    // 嘗試尋找根目錄的 icon.ico
                    iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icon.ico");
                    if (File.Exists(iconPath))
                    {
                        this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(iconPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Functions.Log($"[警告] 無法載入圖示: {ex.Message}");
            }
            
            // 呼叫視窗設計工具的初始化（必須確保元件如 attachButton 被正確建立）
            InitializeComponent();
        }

        private void AttachToRobloxClick(object sender, EventArgs e)
        {
            // 安全地動態呼叫 WeAreDevs API 的注入函數
            // 請確保 "LaunchExploit" 是該 DLL 正確的函數名稱（舊版通常為 LaunchExploit）
            object result = Functions.CallExploitApiFunction("LaunchExploit"); 

            MessageBox.Show("已嘗試注入 Roblox！請檢查遊戲是否成功載入。");
            
            if (attachButton != null)
            {
                attachButton.BackColor = System.Drawing.Color.Green;
            }
        }

        private void DetachFromRobloxClick(object sender, EventArgs e)
        {
            // 動態呼叫關閉函數（依據您的 DLL 版本函數名調整，若無此函數可留空）
            Functions.CallExploitApiFunction("OnProgramClosing");

            MessageBox.Show("已中斷與 Roblox 的連接！");
            
            if (attachButton != null)
            {
                attachButton.BackColor = System.Drawing.SystemColors.Control;
            }
        }
    }
}
