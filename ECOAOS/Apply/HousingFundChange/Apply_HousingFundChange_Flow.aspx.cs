using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using DataAccess.Operate;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class Apply_HousingFundChange_Apply_HousingFundChange_Flow : BasePage
{
    public StringBuilder SbJson = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetManagers();
        if (!IsPostBack)
        {
            this.hidFlowJson.Value = GetFLowJson();
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

    private string GetFLowJson()
    {
        MainID = GetQueryString("MainID");
        DataSet flowDS = new DataSet();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        flowDS = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        var json = "";
        if (flowDS != null && flowDS.Tables[0] != null && flowDS.Tables[0].Rows.Count > 0)
        {
            var flowlist = new List<CommonEntity.FlowEntity>();
            foreach (DataRow dr in flowDS.Tables[0].Rows)
            {
                flowlist.Add(new CommonEntity.FlowEntity
                {
                    Idx = dr["OfficeAutomation_Flow_Idx"].ToString(),
                    Auditor = dr["OfficeAutomation_Flow_Employee"].ToString() + ",",
                    AuditorID = dr["OfficeAutomation_Flow_EmployeeID"].ToString() + ","
                });
            }
            json = JsonConvert.SerializeObject(flowlist);
        }
        return json;
    }
}