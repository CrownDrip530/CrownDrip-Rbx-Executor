using System;
using System.Windows.Forms;
using CrownDripExecutor.Modules; // 引入 Functions 模組

namespace CrownDripExecutor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // 捕捉未處理的執行緒例外狀況
            Application.ThreadException += (sender, e) => {
                Functions.Log($"[執行緒錯誤] {e.Exception.Message}\n{e.Exception.StackTrace}");
                MessageBox.Show($"程式發生錯誤，請檢查 log.txt:\n{e.Exception.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // 捕捉全域未處理的例外狀況
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => {
                if (e.ExceptionObject is Exception ex)
                {
                    Functions.Log($"[全域錯誤] {ex.Message}\n{ex.StackTrace}");
                    MessageBox.Show($"系統發生嚴重崩潰，請檢查 log.txt:\n{ex.Message}", "核心錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                Functions.Log($"[啟動錯誤] {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"無法啟動主介面，請檢查 log.txt:\n{ex.Message}", "啟動失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
