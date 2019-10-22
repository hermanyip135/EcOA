<%@ WebHandler Language="C#" Class="Apply_UtNewProj_Detail_New" %>

using System;
using System.Web;
using System.Data;
using DataAccess.Operate;
using Newtonsoft.Json;

public class Apply_UtNewProj_Detail_New : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string t = context.Request.QueryString["t"];
        string rValue = string.Empty;
        switch (t)
        {
            case "1":
                rValue = GetEmpInfo(context);
                break;
            default:
                break;
        }
        context.Response.Write(rValue);
    }

    protected string GetEmpInfo(HttpContext context)
    {
        string rValue = string.Empty;
        string empCode = context.Request.Form["empcode"];
        DA_Employee_Inherit empInherit = new DA_Employee_Inherit();
        DataSet ds = empInherit.GetEmployeeInfoByEmployeeID(empCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            rValue = JsonConvert.SerializeObject(ds.Tables[0]);
        }

        return rValue;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}