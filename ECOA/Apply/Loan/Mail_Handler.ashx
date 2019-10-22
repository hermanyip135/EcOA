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
            
           // System.Data.DataSet ds = new System.Data.DataSet();
            DataAccess.Operate.DA_OfficeAutomation_Document_Loan_Inherit bllInherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Loan_Inherit();
            DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit();
            DataAccess.Operate.DA_OfficeAutomation_Main_Inherit dA_OfficeAutomation_Main_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Main_Inherit();
            // System.Data.DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainId);
            System.Data.DataSet dsLoan = bllInherit.SelectByMainID(MainId);
           
            //通知填写标记 null表示不修改该字段
            dA_OfficeAutomation_Main_Inherit.UpdateRemarks("▲", null, MainId);
            string applicant = dsLoan.Tables[0].Rows[0]["OfficeAutomation_Document_Loan_Apply"].ToString();
             string serialNumber = dsLoan.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
             string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainId);
             string url = System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString();
            //System.Data.DataRowCollection drc = dsFlow.Tables[0].Rows;
            //string flowIDx = "0";
            //for (int i = 0; i < drc.Count; i++) {
            //    if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False")
            //    {
            //        DataAccess.Operate.DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Agent_Inherit();
            //         string haveSignPowerEmployee = da_OfficeAutomation_Agent_Inherit.HaveSignPowerEmployee(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(), EmployeeName, EmployeeID);
            //         if (haveSignPowerEmployee != null)
            //         {
            //             flowIDx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            //         }
            //    }
            //}
            //da_OfficeAutomation_Flow_Inherit.Updatespecial(MainId, textarea, Convert.ToInt32(flowIDx));
            da_OfficeAutomation_Flow_Inherit.Updatespecial(MainId, textarea, Convert.ToInt32(idx));
            string email = applicant;
            string messageBody = "您好，" + applicant + "： 由" + EmployeeName + "通知您，有编号为" + serialNumber + "的" + documentName + "由于"+textarea+"，并通知"
                + EmployeeName + "，否则该申请将不予通过.登录地址为：" + url;
            Common.SendMessageEX(false, email, "请上传附件", messageBody, messageBody);
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