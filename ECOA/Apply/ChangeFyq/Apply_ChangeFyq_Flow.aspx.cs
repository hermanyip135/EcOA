using DataAccess.Operate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_ChangeFyq_Apply_ChangeFyq_Flow : BasePage
{
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbDepartmentJson = new StringBuilder();
    public string did = "", flod = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        GetManagers();
        GetAllDepartment();

        string flo = GetQueryString("flowsadd"), dpm = GetQueryString("dpm");
        SbJs.Append("<script type=\"text/javascript\">");
        if (flo.Contains("3")) // && txtIDx3.Value != ""
            SbJs.Append("$('#ddl3').show();");
        if (flo.Contains("4"))
            SbJs.Append("$('#ddl4').show();");
        if (flo.Contains("5"))
            SbJs.Append("$('#ddl5').show();");
        //SbJs.Append("$('#txtDepartment').val(" + dpm + ");");
        txtDepartment.Value = dpm;
        did = GetDpmID(dpm);
        flod = flo;
        SbJs.Append("</script>");

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
        SbJson.Append("[");
        foreach (DataRow dr in dsManagers.Tables[0].Rows)
        {
            SbJson.Append("\"" + dr["EmployeeName"] + "\",");
        }
        SbJson.Remove(SbJson.Length - 1, 1);
        SbJson.Append("]");
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

    protected string GetDpmID(string dpm)
    {
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
        DataSet ds = da_Employee_Inherit.GetEmployeeInfoByUnitName(dpm);
        try
        {
            return ds.Tables[0].Rows[0]["UnitID"].ToString();
        }
        catch
        {
            return "";
        }
    }

    private void LoadFlow()
    {
        MainID = GetQueryString("MainID");
        DataSet flowDS = new DataSet();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        flowDS = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = flowDS.Tables[0].Rows;

        SbJs.Append("<script type=\"text/javascript\">");
        foreach (DataRow dr in drc)
        {
            //string idx = dr["OfficeAutomation_Flow_Idx"].ToString();
            //if (idx == "3")
            //{
            SbJs.Append("$('#txtIDx" + dr["OfficeAutomation_Flow_Idx"] + "').val('" + dr["OfficeAutomation_Flow_Employee"] + ",');");
            SbJs.Append("$('#hdIDx" + dr["OfficeAutomation_Flow_Idx"] + "').val('" + dr["OfficeAutomation_Flow_EmployeeID"] + "');");
            //}
            //else if (idx == "1" || idx == "2")
            //{
            //    SbJs.Append("$('#divIDx" + dr["OfficeAutomation_Flow_Idx"] + "').toggle();$('#divTxtIDx" + dr["OfficeAutomation_Flow_Idx"] + "').toggle();");
            //    SbJs.Append("$('#txtIDx" + dr["OfficeAutomation_Flow_Idx"] + "').val('" + dr["OfficeAutomation_Flow_Employee"] + ",');");
            //    SbJs.Append("$('#hdIDx" + dr["OfficeAutomation_Flow_Idx"] + "').val('" + dr["OfficeAutomation_Flow_EmployeeID"] + "');");
            //}
        }
        SbJs.Append("</script>");
    }
}