using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;

using DataAccess.Operate;

public partial class Apply_ITBuy_Apply_ITBuy_Flow : BasePage
{
    public StringBuilder sbJS = new StringBuilder();
    public StringBuilder sbJSON = new StringBuilder();
    public StringBuilder sbDepartmentJSON = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetManagers();
        GetAllDepartment();
        if (!IsPostBack)
        {
            LoadFlow();
        }
    }

    /// <summary>
    /// 获取所有四级以上前线经理
    /// </summary>
    private void GetManagers()
    {
        wsFinance.Service service = new wsFinance.Service();
        DataSet dsManagers = service.GetManages();
        sbJSON.Append("[");
        foreach (DataRow dr in dsManagers.Tables[0].Rows)
        {
            sbJSON.Append("\"" + dr["EmployeeName"].ToString() + "\",");
        }
        sbJSON.Remove(sbJSON.Length - 1, 1);
        sbJSON.Append("]");
    }

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        wsKDHR.Service service = new wsKDHR.Service();
        DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
        sbDepartmentJSON.Append("[");
        foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        {
            sbDepartmentJSON.Append("{\"id\":\"" + dr["id"].ToString() + "\",\"value\":\"" + dr["name"].ToString() + "\"},");
        }
        sbDepartmentJSON.Remove(sbDepartmentJSON.Length - 1, 1);
        sbDepartmentJSON.Append("]");
    }
    #endregion

    private void LoadFlow()
    {
        MainID = GetQueryString("MainID");
        DataSet flowDS = new DataSet();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        flowDS = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = flowDS.Tables[0].Rows;

        sbJS.Append("<script type=\"text/javascript\">");
        foreach (DataRow dr in drc)
        {
            string idx = dr["OfficeAutomation_Flow_Idx"].ToString();
            if (idx == "1" || idx == "2" || idx == "3")
            {
                sbJS.Append("$('#divIDx" + dr["OfficeAutomation_Flow_Idx"].ToString() + "').toggle();$('#divTxtIDx" + dr["OfficeAutomation_Flow_Idx"].ToString() + "').toggle();");
                sbJS.Append("$('#txtIDx" + dr["OfficeAutomation_Flow_Idx"].ToString() + "').val('" + dr["OfficeAutomation_Flow_Employee"].ToString() + ",');");
                sbJS.Append("$('#hdIDx" + dr["OfficeAutomation_Flow_Idx"].ToString() + "').val('" + dr["OfficeAutomation_Flow_EmployeeID"].ToString() + "');");
            }
        }
        sbJS.Append("</script>");
    }
}
