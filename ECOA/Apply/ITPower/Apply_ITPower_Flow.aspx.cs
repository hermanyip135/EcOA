using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess.Operate;
using System.Text;

public partial class Apply_ITPower_Apply_ITPower_Flow : BasePage
{
    public StringBuilder sbJS = new StringBuilder();
    public StringBuilder sbJSON = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetManagers();
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
            switch (dr["OfficeAutomation_Flow_Idx"].ToString())
            {
                case "2":
                case "4":
                    sbJS.Append("$('#divIDx" + dr["OfficeAutomation_Flow_Idx"].ToString() + "').toggle();$('#divTxtIDx" + dr["OfficeAutomation_Flow_Idx"].ToString() + "').toggle();");
                    break;
                default:
                    break;
            }
            sbJS.Append("$('#txtIDx" + dr["OfficeAutomation_Flow_Idx"].ToString() + "').val('" + dr["OfficeAutomation_Flow_Employee"].ToString() + ",');$('#hdIDx" + dr["OfficeAutomation_Flow_Idx"].ToString() + "').val('" + dr["OfficeAutomation_Flow_EmployeeID"].ToString() + "');");
        }
        sbJS.Append("</script>");
    }
}
