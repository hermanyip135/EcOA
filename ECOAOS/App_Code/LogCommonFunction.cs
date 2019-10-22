using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public static class LogCommonFunction
{
    public static void AddLog(string datas, string message)
    {
        try
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("log/") + "log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

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
                sw.Write("" + datas + "\r\n\r\n");
                sw.Write("log:" + message + "\r\n");
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

    public static void AddErrorLog(string datas, string message, string filename)
    {
        try
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("log/") + filename + "_errorlog" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

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
                sw.Write("" + datas + "\r\n\r\n");
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