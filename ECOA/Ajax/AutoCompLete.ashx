<%@ WebHandler Language="C#" Class="AutoCompLete" %>

using System;
using System.Text;
using System.Data;
using System.Web;
using DataAccess.Operate;

public class AutoCompLete : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        DataSet ds = new DataSet();
        DA_Employee_Inherit employee_Inhert = new DA_Employee_Inherit();
        string empname = context.Request.QueryString["EmpName"];

        StringBuilder sbjson = new StringBuilder();
        
        if (empname.LastIndexOf(',') > -1) 
        {
            empname = empname.Substring(empname.LastIndexOf(',')+1);
        }

        if (!string.IsNullOrEmpty(empname))
        {
            ds = employee_Inhert.getEmpInfoByEmpName(empname);
            
            sbjson.Append("[");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sbjson.Append("{\"code\":\"" + dr["Code"].ToString() + "\",\"value\":\"" + dr["EmployeeName"].ToString() + "\"},");
            }
            sbjson.Remove(sbjson.Length - 1, 1);
            sbjson.Append("]");
        }
        
        

        context.Response.Write(sbjson);
        context.Response.End();
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}