﻿using System;

using System.Text;
using System.Data; 

using DataAccess.Operate;
using DataEntity;

public partial class Apply_WrongSave_Apply_WrongSave_Flow : BasePage
{
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbDepartmentJson = new StringBuilder();

    public DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
    public T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
    public T_OfficeAutomation_Flow flows;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetManagers();
        GetAllDepartment();

        //string flo = GetQueryString("dpm");
        //SbJs.Append("<script type=\"text/javascript\">");
        //if (flo == "事业四部")
        //    SbJs.Append("$('#txtIDx2').val('陈锵成');$('#txtIDx2').css(\"background-color\",\"Silver\").attr(\"readonly\",\"readonly\");");
        //else if (flo == "事业一部" || flo == "事业二部" || flo == "事业三部" || flo == "事业十部")
        //    SbJs.Append("$('#txtIDx2').val('黄韬');$('#txtIDx2').css(\"background-color\",\"Silver\").attr(\"readonly\",\"readonly\");");
        //else if (flo == "拓展部" || flo == "项目部")
        //    SbJs.Append("$('#txtIDx2').val('易伟锋');$('#txtIDx2').css(\"background-color\",\"Silver\").attr(\"readonly\",\"readonly\");");
        //else if (flo == "事业六部")
        //    SbJs.Append("$('#txtIDx2').val('钟卫文');$('#txtIDx2').css(\"background-color\",\"Silver\").attr(\"readonly\",\"readonly\");");
        //SbJs.Append("</script>");

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
            //if (idx == "1" || idx == "5" || idx == "6" || idx == "7")
            //{
                //SbJs.Append("$('#txtIDx" + dr["OfficeAutomation_Flow_Idx"] + "').val('" + dr["OfficeAutomation_Flow_Employee"] + ",');");
                //SbJs.Append("$('#hdIDx" + dr["OfficeAutomation_Flow_Idx"] + "').val('" + dr["OfficeAutomation_Flow_EmployeeID"] + "');");
            //}
            //else if (idx == "2" || idx == "3" || idx == "4")
            //{
            SbJs.Append("$('#divIDx" + dr["OfficeAutomation_Flow_Idx"] + "').toggle();$('#divTxtIDx" + dr["OfficeAutomation_Flow_Idx"] + "').toggle();");
            SbJs.Append("$('#txtIDx" + dr["OfficeAutomation_Flow_Idx"] + "').val('" + dr["OfficeAutomation_Flow_Employee"] + ",');");
            SbJs.Append("$('#hdIDx" + dr["OfficeAutomation_Flow_Idx"] + "').val('" + dr["OfficeAutomation_Flow_EmployeeID"] + "');");
            //}
        }
        SbJs.Append("</script>");
    }
}
