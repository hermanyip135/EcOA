using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess.Operate;
using System.Text;

public partial class Apply_SysLogist_Apply_SysLogist_Flow : BasePage
{
    public StringBuilder sbJS = new StringBuilder();
    public StringBuilder sbJSON = new StringBuilder();
    public StringBuilder SbDepartmentJson = new StringBuilder();

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
            //sbJSON.Append("{\"id\":\"" + dr["Code"].ToString() + "\",\"label\":\"" + dr["EmployeeName"].ToString() + "\",\"value\":\"" + dr["EmployeeName"].ToString() + "\"},");
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
        SbDepartmentJson.Append("[");
        foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        {
            SbDepartmentJson.Append("{\"id\":\"" + dr["id"] + "\",\"value\":\"" + dr["name"] + "\"},");
        }
        SbDepartmentJson.Remove(SbDepartmentJson.Length - 1, 1);
        SbDepartmentJson.Append("]");
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
            if (dr["OfficeAutomation_Flow_Idx"].ToString() == "1")
            {
                sbJS.Append("$('#divIDx1').toggle();$('#divTxtIDx1').toggle();");
                sbJS.Append("$('#txtIDx1').val('" + dr["OfficeAutomation_Flow_Employee"].ToString() + ",');$('#hdIDx1').val('" + dr["OfficeAutomation_Flow_EmployeeID"].ToString() + "');");
            }

            if (dr["OfficeAutomation_Flow_Idx"].ToString() == "2")
            {
                //sbJS.Append("$('#divIDx2').toggle();$('#divTxtIDx2').toggle();");
                sbJS.Append("$('#txtIDx2').val('" + dr["OfficeAutomation_Flow_Employee"].ToString() + ",');$('#hdIDx2').val('" + dr["OfficeAutomation_Flow_EmployeeID"].ToString() + "');");
            }
        }

        sbJS.Append("</script>");
    }
}
