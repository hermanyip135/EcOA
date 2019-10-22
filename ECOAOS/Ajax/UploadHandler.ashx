<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Web;
using System.Text;
using System.IO;
using System.Web.SessionState;

public class UploadHandler : IHttpHandler,IRequiresSessionState
{
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Charset = "utf-8";
        
        string path = System.Configuration.ConfigurationManager.AppSettings["UploadPath"];//"../upload/img/";
        string pdfpath = System.Configuration.ConfigurationManager.AppSettings["UploadPDFPath"];
        
        string urlpath = System.Configuration.ConfigurationManager.AppSettings["EcoaFileURL"];
        var MainID = context.Request.QueryString["MainID"];
        //2016-12-01
        var applytype = context.Request.QueryString["ApplyType"];
        var datumtype = context.Request.QueryString["DatumType"];
        
        if (string.IsNullOrEmpty(MainID))
        {
            context.Response.Write(0);
            context.Response.End();
        }
        
        HttpPostedFile file = context.Request.Files["Filedata"];
        string uploadPath = path + "\\" + DateTime.Now.Year.ToString() + "\\" + MainID + "\\";//HttpContext.Current.Server.MapPath(@path);
        string uploadPDFPath = pdfpath + "\\" + DateTime.Now.Year.ToString() + "\\" + MainID + "\\";
        
        urlpath = urlpath + DateTime.Now.Year.ToString() + "/" + MainID + "/";
        
        if (file != null)
        {
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            if (!Directory.Exists(uploadPDFPath))
            {
                Directory.CreateDirectory(uploadPDFPath);
            }

            string filename = "";
            if (applytype == "huihan")
            {
                filename = file.FileName.Substring(0, file.FileName.IndexOf('.')) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName.Substring(file.FileName.IndexOf('.'));
                file.SaveAs(uploadPath + filename);
                File.Copy(uploadPath + filename, uploadPDFPath + filename);
            }
            else
            {
                filename = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + file.FileName.Substring(file.FileName.IndexOf('.'));
                file.SaveAs(uploadPath + filename);
            }
            
            
            //返回{'url':'../XXX.jpg','name':'XXX.jpg'}
            StringBuilder sb = new StringBuilder();

            if (applytype == "huihan")
            {
                var loginuser = new BasePage().GetLoginUser();
                string dep = loginuser.Unit;
                string empname = loginuser.EmpName;
                
                string attchname = datumtype + "_(" + DateTime.Now.ToString("yyMMdd") + dep + " - " + empname + "上传)" + file.FileName;
                string attchpath = DateTime.Now.Year.ToString() + "/" + MainID + "/" +  Uri.EscapeDataString(filename);

                string datumtypename = datumtype == "0" ? "存量房买卖合同变更协议" : datumtype == "1" ? "网签委托确认书" : datumtype == "2" ? "新买家身份证" : datumtype == "3" ? "购房资格调查确认表" : datumtype == "4" ? "关系证明/法律部签批的变更申请" : datumtype == "5" ? "委托公证书" : datumtype == "6" ? "代理人身份证资料" : "";

                
                
                sb.Append("{");
                sb.Append("'name':");
                sb.Append("'" + Uri.EscapeDataString(attchname) + "'");
                sb.Append(",");
                sb.Append("'path':");
                sb.Append("'" + attchpath + "'");
                sb.Append(",");
                sb.Append("'datumtype':");
                sb.Append("'" + datumtype + "'");
                sb.Append(",");
                sb.Append("'datumtypename':");
                sb.Append("'" +  HttpUtility.UrlEncode(datumtypename) + "'");
                sb.Append("}");
                
                
            }
            else
            {
                sb.Append("{");
                sb.Append("'url':");
                sb.Append("'" + urlpath + filename + "'");
                sb.Append(",");
                sb.Append("'name':");
                sb.Append("'" + DateTime.Now.Year.ToString() + "/" + MainID + "/" + filename + "'");
                sb.Append("}");
            }

            //context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            //context.Response.Charset = "utf-8";
            context.Response.Write(sb.ToString());
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