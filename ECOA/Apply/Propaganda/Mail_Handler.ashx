<%@ WebHandler Language="C#" Class="Mail_Handler" %>

using System;
using System.Web;

public class Mail_Handler : IHttpHandler{
    
    public void ProcessRequest (HttpContext context) {
        string action = BasePage.GetFormString("action");

        switch (action)
        {
            case "sendMail":
                sendMail(context);
                break;

            default:
                break;
        }
    }
    public void sendMail(HttpContext context)
    {
        string MainId = BasePage.GetFormString("MainId");
        string textarea = BasePage.GetFormString("textarea");
         string EmployeeName = BasePage.GetFormString("EmployeeName");
         string EmployeeID = BasePage.GetFormString("EmployeeID");
         string idx = BasePage.GetFormString("idx");
         if (MainId != "")
         {


             DataAccess.Operate.DA_OfficeAutomation_Log_Inherit dA_OfficeAutomation_Log_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Log_Inherit();
             DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit();
             DataAccess.Operate.DA_OfficeAutomation_Main_Inherit dA_OfficeAutomation_Main_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Main_Inherit();
            System.Data.DataSet dsMain = dA_OfficeAutomation_Main_Inherit.SelectByMainID(MainId);
            string serialNumber = dsMain.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            System.Data.DataSet dsLog = dA_OfficeAutomation_Log_Inherit.getOneLog(MainId,1,59);
            string applicant = dsLog.Tables[0].Rows[0]["OfficeAutomation_Log_EmployeeName"].ToString();
            string applicantNO = dsLog.Tables[0].Rows[0]["OfficeAutomation_Log_EmployeeID"].ToString();
             DataEntity.T_OfficeAutomation_Flow flows;
           DataEntity.T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new DataEntity.T_OfficeAutomation_Flow();
           t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainId);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainId, 19);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = applicantNO;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = applicant;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 19;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
             string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainId);
             string url = System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString();

             da_OfficeAutomation_Flow_Inherit.Updatespecial(MainId, textarea, Convert.ToInt32(idx));
             string email = applicant;
             string messageBody = "您好，" + applicant + "： 由" + EmployeeName + "通知您，有编号为" + serialNumber + "的" + documentName + "由于" + textarea + "，并通知"
                 + EmployeeName + "，否则该申请将不予通过.登录地址为：" + url;
             Common.SendMessageEX(false, email, "广告宣传需求申请", messageBody, messageBody);
             return;
         }
        context.Response.Write("fail");
        }

        
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}