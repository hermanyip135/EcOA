<%@ WebHandler Language="C#" Class="CCAI_Handler" %>

using System;
using System.Web;

public class CCAI_Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string action = BasePage.GetFormString("action");

        switch (action)
        {
            case "getReport":
                getReport(context);
                break;
            
            default:
                break;
        }
    }
    public void getReport(HttpContext context)
    {
        string code = BasePage.GetFormString("code");
        if (code != "")
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            DataAccess.Operate.DA_OfficeAutomation_Document_Loan_Inherit bllInherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Loan_Inherit();
            ds = bllInherit.SelectByReportNO(code);
         
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                System.Data.DataRow dr = ds.Tables[0].Rows[0];
              
                context.Response.Write(dr["Report_Main_Price"].ToString() + "|"
                    + dr["Report_Detail_Client1"].ToString() + "|"
                    + dr["Report_Main_Address"].ToString() + "|"
                 
                    );
                return;
            }
        }

        context.Response.Write("fail");
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}