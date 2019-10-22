<%@ WebHandler Language="C#" Class="HR_Handler" %>

using System;
using System.Data;
using System.Web;

public class HR_Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string action = BasePage.GetFormString("action");

        switch (action)
        {
            case "getEmployee":
                GetEmployee(context);
                break;
            case "getEmployeeByCodes":
                GetEmployeeByCodes(context);
                break;
            case "getHRTreeByDepartmentID":
                GetHRTreeByDepartmentID(context);
                break;
            case "getEmpInfoByEmpName":
                GetEmpInfoByEmpName(context);
                break;
            default:
                break;
        }
    }
 
    public void GetEmployee(HttpContext context)
    {
        string code = BasePage.GetFormString("code");
        if (code != "")
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            DataAccess.Operate.DA_Employee_Inherit da_Employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();
            ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeID(code);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                System.Data.DataRow dr = ds.Tables[0].Rows[0];
                string s = "";
                try
                {
                    s = DateTime.Parse(dr["InDueDate"].ToString()).ToString("yyyy-MM-dd");
                }
                catch
                {
                    s = "";
                }
                string sex = dr["Sex"].ToString() == "1" ? "男" : "女";
                context.Response.Write(dr["Code"].ToString() + "|" 
                    + dr["EmployeeName"].ToString() + "|" 
                    + dr["DepartmentName"].ToString() + "|" 
                    + dr["UnitID"].ToString() + "|" 
                    + dr["PositionName"].ToString() + "|" 
                    + dr["JobGrade"] + "|" 
                    + DateTime.Parse(dr["EnterDate"].ToString()).ToString("yyyy-MM-dd") + "|" 
                    + s + "|"
                    + dr["CardID"] + "|"
                       + sex
                    );
                return;
            }
        }
        
        context.Response.Write("fail");
    }

    /// <summary>
    /// 通过多个工号，获得多个姓名
    /// 输入参数格式"code=26242,3189,3808"
    /// 输出结果格式"26242,3189,3808|张榕,何旭晖,何智峰"
    /// </summary>
    /// <param name="context"></param>
    public void GetEmployeeByCodes(HttpContext context)
    {
        string[] codes = BasePage.GetFormString("code").Split(',');
        if (codes.Length > 0)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            DataAccess.Operate.DA_Employee_Inherit da_Employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();
            string code="", name="";
            for (int i = 0; i < codes.Length; i++)
            {
                ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeID(codes[i]);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    System.Data.DataRow dr = ds.Tables[0].Rows[0];
                    code += dr["Code"].ToString() + ",";
                    name += dr["EmployeeName"].ToString() + ",";
                }
            }
            
            if(code.Length>0)
            {
                code=code.Substring(0,code.Length-1);
                name=name.Substring(0,name.Length-1);
            }

            context.Response.Write(code + "|" + name);
            return;
        }

        context.Response.Write("fail");
    }

    /// <summary>
    /// 通过departmentid获得该部门或组别的人事树架构
    /// 输入参数格式"departmentid=ae9c9858-830f-493e-94c4-90e31ec5bed6"
    /// 输出结果格式"26242,3189,3808|张榕,何旭晖,何智峰"
    /// </summary>
    /// <param name="context"></param>
    public void GetHRTreeByDepartmentID(HttpContext context)
    {
        string departmentid = BasePage.GetFormString("departmentid");

        string units = "", unitids = "",dpm = "";
        wsFinance.Service wsf = new wsFinance.Service();
        System.Data.DataSet ds = wsf.GetHRStructure(departmentid, DateTime.Now.ToString("yyyy-MM-dd"));
        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        {
            units = ds.Tables[0].Rows[0]["HRStructure_Unit"].ToString().Replace('/', ',');
            unitids = ds.Tables[0].Rows[0]["HRStructure_UnitID"].ToString().Replace('/', ',');
            dpm = ds.Tables[0].Rows[0]["Role_DescInECOA"].ToString().Replace('/', ',');
            context.Response.Write(unitids + "|" + units + "|" + dpm);
        }
        else
        {
            wsHR.HR wshr = new wsHR.HR();
            units = wshr.GetDepartmentManager(departmentid);
            if (string.IsNullOrEmpty(units))
            {
                context.Response.Write("fail");
            }
            else
            {
                unitids = wshr.GetDepartmentManagerCode(departmentid);
                context.Response.Write(unitids + "|" + units + "|0000");
            }
        }
    }

    public void GetEmpInfoByEmpName(HttpContext context)
    {
        DataAccess.Operate.DA_Employee_Inherit employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();
        string empnames = context.Request.Form["empname"];

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        
        bool flag = true;
        
        var emparr = empnames.Split(',');
        string empcode = "";
        if (empnames != "")
        {
            for (var i = 0; i < emparr.Length; i++)
            {
                if (!string.IsNullOrEmpty(emparr[i]))
                {
                    DataSet ds = employee_Inherit.GetEmployeeInfoByEmployeeNames(emparr[i]);
                    if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                    {
                        context.Response.Write("fail");
                        flag = false;
                        break;
                    }
                    else
                    {
                        empcode += ds.Tables[0].Rows[0]["Code"].ToString() + ",";

                    }
                }
            }

            if (flag)
            {
                empcode = empcode.Substring(0, empcode.Length - 1);

                sb.Append("{");
                sb.Append("\"empcode\":\"" + empcode + "\",\"message\":\"success\"");
                sb.Append("}");

                context.Response.Write(sb.ToString());
            }
            
        }
        else
        {
            context.Response.Write("success");
        }
        
        
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }
}