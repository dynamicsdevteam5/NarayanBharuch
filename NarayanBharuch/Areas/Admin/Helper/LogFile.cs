using System;
using System.IO;

namespace NarayanBharuch.Areas.Admin.Helper
{
    public static class LogFile
    {
        public static void AddException(string methodName, string sExceptionName)
        {
            var filename = string.Format("{0:yyyy-MM-dd}__{1}", DateTime.Now, "LogFile.txt");
            var path = AppDomain.CurrentDomain.BaseDirectory + "/Areas/Admin/Logs/" + filename;
            if (!File.Exists(path))
            {
                using (var sw = File.CreateText(path))
                {
                    sw.WriteLine(DateTime.Now + ": Method: " + methodName + ", Exception: " + sExceptionName + Environment.NewLine);
                }
            }
            else
            {
                File.AppendAllText(path, DateTime.Now + ": Method: " + methodName + ", Exception: " + sExceptionName + Environment.NewLine);
            }
        }
    }
}