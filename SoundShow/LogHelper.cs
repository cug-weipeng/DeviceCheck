using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundShow
{
    static class  LogHelper
    {
        static string logPath;
        public static void PrepareLog()
        {
            string BasePath = AppDomain.CurrentDomain.BaseDirectory;
            string dir = Path.Combine(BasePath, "log");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            logPath = Path.Combine(dir,DateTime.Now.ToString("yyyyMMdd")+".log");
        }
        public static void LogInfo(string info)
        {
            
            using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")}:{info}");
                sw.Flush();
            }
        }
        public static void LogErro(Exception err)
        {
            using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine("*********ERROR*********");
                if (err == null)
                    sw.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")}:异常信息为空");
                else
                    sw.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")}:异常信息：{err.Message};堆栈：{err.StackTrace}");
                sw.WriteLine("************************");
                sw.Flush();
            }
        }
        public static void LogAndConsole(string msg)
        {
            LogInfo(msg);
            Console.WriteLine(msg);
        }
    }
}
