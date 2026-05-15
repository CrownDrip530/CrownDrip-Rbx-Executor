public static object CallExploitApiFunction(string functionName, params object[] args)
{
    try
    {
        string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wearedevs_exploit_api.dll");
        
        if (!File.Exists(dllPath))
        {
            Log($"錯誤：找不到 DLL 檔案，路徑應為: {dllPath}");
            return null;
        }

        // 載入 DLL
        System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(dllPath);

        // 取得類別
        System.Type type = assembly.GetType("WeAreDevs.ExploitAPI");
        if (type == null)
        {
            Log("錯誤：在 DLL 中找不到 'WeAreDevs.ExploitAPI' 類別。");
            return null;
        }

        // 取得方法
        System.Reflection.MethodInfo methodInfo = type.GetMethod(functionName);
        if (methodInfo == null)
        {
            Log($"錯誤：在 API 中找不到名為 '{functionName}' 的方法。");
            return null;
        }

        // 執行方法
        return methodInfo.Invoke(null, args);
    }
    catch (Exception ex)
    {
        // 將所有可能發生的錯誤記錄到 log.txt 中
        Log($"執行 API 函數 '{functionName}' 時發生致命錯誤: {ex.Message}\n{ex.StackTrace}");
        return null;
    }
}
