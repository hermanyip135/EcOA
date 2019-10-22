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

public partial class Apply_WYRecruit_Apply_WYRecruit_Flow : BasePage
{
    public StringBuilder SbJson = new StringBuilder();
    #region 默认总监、总助
    public string zongjian = "";
    public string zongzhu = "";
    public int type = 0;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        GetManagers();
        if (!IsPostBack)
        {
            type =Convert.ToInt32(GetQueryString("type"));
            this.hidFlowJson.Value = GetFLowJson();
            if (type != 1) 
            {
                SetDirector();
            }
            
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

    #region 自定义
    /// <summary>
    /// 默认总监、总助
    /// </summary>
    private void SetDirector() 
    {
        var main = GetQueryString("MainID");
        DA_OfficeAutomation_Document_WYRecruit_Operate WYRecruit_Operate = new DA_OfficeAutomation_Document_WYRecruit_Operate();
        string sql = "OfficeAutomation_Document_WYRecruit_MainID='"+main+"'";
        var Region = WYRecruit_Operate.GetModel(sql).OfficeAutomation_Document_WYRecruit_Region;
        switch (Region)
        {
            case "大天河区":
                zongjian = "潘婉霞";
                zongzhu = "陈素玲";
                break;
            case "大海珠区":
                zongjian = "朱伟洲";
                zongzhu = "潘广宁";
                break;
            case "大白云区":
                zongjian = "陈宋林";
                zongzhu = "蔡立";
                break;
            case "大越秀区":
                zongjian = "陈秋炳";
                zongzhu = "梁妙娥";
                break;
            case "番禺一部":
                zongjian = "叶国安";
                zongzhu = "陆洁琪";
                break;
            case "花都区":
                zongjian = "杜燕玲";
                zongzhu = "黎冰";
                break;
            case "工商铺一部":
                zongjian = "罗思源";
                zongzhu = "黎雅丽";
                break;
            case "工商铺二部":
                zongjian = "朱少娟";
                zongzhu = "单振翀";
                break;
            default:
                break;
        }
    }
    #endregion
}