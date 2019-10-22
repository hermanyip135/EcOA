<%@ WebHandler Language="C#" Class="ReadExcel_Handler" %>

using System;
using System.Web;
using System.Collections.Generic;

public class ReadExcel_Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        if (!string.IsNullOrEmpty(context.Request.QueryString["MainID"]) && !string.IsNullOrEmpty(context.Request.Form["path"]))
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["UploadPath"];
            path = path + context.Request.Form["path"].Replace("/","\\");
            var ds = ECOA.Common.ExcelHelper.ReadExcel(path, "Sheet1");
            var list = new List<DataEntity.T_OfficeAutomation_Document_CommissionAssign_Detail>();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                var i = 0;
                foreach(System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(dr["类别"].ToString()) && !string.IsNullOrEmpty(dr["职位"].ToString()) && !string.IsNullOrEmpty(dr["工号"].ToString()))
                    {
                        var obj = new DataEntity.T_OfficeAutomation_Document_CommissionAssign_Detail();
                        obj.OfficeAutomation_Document_CommissionAssign_Detail_Class = dr["类别"].ToString();
                        obj.OfficeAutomation_Document_CommissionAssign_Detail_Position = dr["职位"].ToString();
                        obj.OfficeAutomation_Document_CommissionAssign_Detail_EmpoyeeID = dr["工号"].ToString();
                        obj.OfficeAutomation_Document_CommissionAssign_Detail_Empoyee = dr["姓名"].ToString();
                        obj.OfficeAutomation_Document_CommissionAssign_Detail_AgentProject = dr["销售代理项目"].ToString();
                        obj.OfficeAutomation_Document_CommissionAssign_Detail_AdviserProject = dr["策划/顾问项目"].ToString();
                        obj.OfficeAutomation_Document_CommissionAssign_Detail_OtherProject = dr["其他"].ToString();
                        obj.OfficeAutomation_Document_CommissionAssign_Detail_Sort = i;
                        list.Add(obj);
                    }
                    i++;
                }
            }
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(list));
            context.Response.End();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}