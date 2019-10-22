<%@ WebHandler Language="C#" Class="UploadFilesHandler" %>

using System;
using System.Web;
using System.Text;
using System.IO;

public class UploadFilesHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Charset = "utf-8";
        string path = System.Configuration.ConfigurationManager.AppSettings["UploadPath"];//"../upload/img/";

        string urlpath = System.Configuration.ConfigurationManager.AppSettings["EcoaFileURL"];
        var MainID = context.Request.QueryString["MainID"];
        if (string.IsNullOrEmpty(MainID))
        {
            context.Response.Write(0);
            context.Response.End();
        }
        HttpPostedFile file = context.Request.Files["Filedata"];
        string uploadPath = path + "\\" + DateTime.Now.Year.ToString() + "\\" + MainID + "\\";//HttpContext.Current.Server.MapPath(@path);
        urlpath = urlpath + DateTime.Now.Year.ToString() + "/" + MainID + "/";

        if (file != null)
        {
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < context.Request.Files.Count; ++i)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + file.FileName.Substring(file.FileName.IndexOf('.'));
                file.SaveAs(uploadPath + filename);
                
                //返回{'url':'../XXX.jpg','name':'XXX.jpg'}
                sb.Append("{");
                sb.Append("'url':");
                sb.Append("'" + urlpath + filename + "'");
                sb.Append(",");
                sb.Append("'name':");
                sb.Append("'" + DateTime.Now.Year.ToString() + "/" + MainID + "/" + filename + "'");
                sb.Append("},");
            }

            string json = sb.ToString().TrimEnd(',');
            json = json + "]";

            context.Response.Write(json);
            context.Response.End();
        }
        else
        {
            context.Response.Write("0");
            context.Response.End();
        }  
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}