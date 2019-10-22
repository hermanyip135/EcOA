<%@ WebHandler Language="C#" Class="Feasibility_Diagram" %>

using System;
using System.Web;

using DataAccess.Operate;
using DataEntity;

public class Feasibility_Diagram : IHttpHandler {

    //T_OfficeAutomation_Document_Feasibility t_OfficeAutomation_Document_Feasibility = new T_OfficeAutomation_Document_Feasibility();
    DA_OfficeAutomation_Document_Feasibility_Inherit da_OfficeAutomation_Document_Feasibility_Inherit = new DA_OfficeAutomation_Document_Feasibility_Inherit();
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        //t_OfficeAutomation_Document_Feasibility.OfficeAutomation_Document_Feasibility_MainID = context.Request.QueryString["user_name"];
        byte[] cover = da_OfficeAutomation_Document_Feasibility_Inherit.ReadPhoto(context.Request.QueryString["MainID"].ToString());
        try
        {
            context.Response.BinaryWrite(cover);
        }
        catch
        {
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}