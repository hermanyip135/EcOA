using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

    public class LogCommonFunction
    {
        public static void AddErrorLog(string message)
        {
            try
            {
                string apppath = System.IO.Directory.GetCurrentDirectory();             //程序所在路径
                string path = apppath + "\\log\\" + "log.txt";

                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                FileInfo fileinfo = new FileInfo(path);

                using (FileStream fs = fileinfo.OpenWrite())
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.Write("Date:" + DateTime.Now.ToString() + "\r\n");
                    sw.Write("error:" + message + "\r\n");
                    sw.WriteLine("=====================================");
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }