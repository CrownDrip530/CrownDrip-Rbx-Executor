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
            string logFilePath = "log.txt";
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        /// <summary>
        /// Calls a function from the wearedevs_exploit_api.dll.
        /// </summary>
        /// <param name="functionName">The name of the function to call.</param>
        /// <param name="args">The arguments to pass to the function.</param>
        /// <returns>The result of the function call.</returns>
        public static object CallExploitApiFunction(string functionName, params object[] args)
        {
            // Load the DLL
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom("wearedevs_exploit_api.dll");

            // Get the type of the class containing the function
            System.Type type = assembly.GetType("WeAreDevs.ExploitAPI");

            // Get the method info
            System.Reflection.MethodInfo methodInfo = type.GetMethod(functionName);

            // Invoke the method
            return methodInfo.Invoke(null, args);
        }
    }
}
