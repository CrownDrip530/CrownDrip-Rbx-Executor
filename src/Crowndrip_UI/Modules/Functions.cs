using System;
using System.IO;

namespace CrownDripExecutor.Modules
{
    public static class Functions
    {
        /// <summary>
        /// Writes a log message to a file.
        /// </summary>
        /// <param name="message">The log message to write.</param>
        public static void Log(string message)
        {
            try
            {
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch
            {
                // 靜默忽略日誌寫入失敗，避免二次崩潰
            }
        }

        /// <summary>
        /// Calls a function from the wearedevs_exploit_api.dll safely using reflection.
        /// </summary>
        /// <param name="functionName">The name of the function to call.</param>
        /// <param name="args">The arguments to pass to the function.</param>
        /// <returns>The result of the function call, or null if it fails.</returns>
        public static object CallExploitApiFunction(string functionName, params object[] args)
        {
            try
            {
                // 確保從 .exe 相同的輸出目錄尋找 DLL
                string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wearedevs_exploit_api.dll");

                if (!File.Exists(dllPath))
                {
                    Log($"[錯誤] 找不到 API 檔案。請確保該檔案存在於此路徑: {dllPath}");
                    return null;
                }

                // 動態載入 C++ 包裝的 DLL
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(dllPath);

                // 取得 WeAreDevs 核心類別
                System.Type type = assembly.GetType("WeAreDevs.ExploitAPI");
                if (type == null)
                {
                    Log("[錯誤] 在 DLL 中找不到類別 'WeAreDevs.ExploitAPI'。請確認 DLL 版本是否正確。");
                    return null;
                }

                // 取得指定的方法名稱
                System.Reflection.MethodInfo methodInfo = type.GetMethod(functionName);
                if (methodInfo == null)
                {
                    Log($"[錯誤] 在 API 中找不到名為 '{functionName}' 的方法。請檢查是否拼字錯誤。");
                    return null;
                }

                // 安全執行該方法
                return methodInfo.Invoke(null, args);
            }
            catch (Exception ex)
            {
                // 補獲所有如：防毒軟體攔截、記憶體拒絕存取等致命錯誤，並寫入日誌
                Log($"[系統崩潰] 執行 '{functionName}' 時發生未預期錯誤: {ex.Message}\n{ex.StackTrace}");
                return null;
            }
        }
    }
}
