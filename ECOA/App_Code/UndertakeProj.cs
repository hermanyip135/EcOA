using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using DataAccess.Operate;
using DataEntity;
using System.Data;

/// <summary>
/// UndertakeProj 获取项目报备信息
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class UndertakeProj : System.Web.Services.WebService {

    public UndertakeProj () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod(Description = "输入文档编码，获取单套现金奖其他情况")]
    public string GetAnotherCondition(string serialNumber)
    {
        DA_OfficeAutomation_Document_UndertakeProj_Inherit da_OfficeAutomation_Document_UndertakeProj_Inherit = new DA_OfficeAutomation_Document_UndertakeProj_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Main_Inherit.SelectBySerialNumber(serialNumber);
        string MainID = ds.Tables[0].Rows[0]["OfficeAutomation_Main_ID"].ToString();
        ds = da_OfficeAutomation_Document_UndertakeProj_Inherit.SelectByMainID(MainID);

        return ds.Tables[0].Rows[0]["OfficeAutomation_Document_UndertakeProj_AnotherRewardC"].ToString();
    }

    [WebMethod(Description = "输入文档编码，获取有效期（起始～结束）和现金奖总额")]
    public string GetSomeThingFromEBAdjuct(string serialNumber)
    {
        DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Main_Inherit.SelectBySerialNumber(serialNumber);
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() != "3")
            return "该申请还未审批完毕。";
        string MainID = ds.Tables[0].Rows[0]["OfficeAutomation_Main_ID"].ToString();
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainIDDesc(MainID);

        string rs;
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Flow_IsAgree"].ToString() != "0")
        {
            ds = da_OfficeAutomation_Document_EBAdjuct_Inherit.SelectByMainID(MainID);
            rs = ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_ValidityBeginDate"].ToString()
                + "," + ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_ValidityEndDate"].ToString()
                + "," + ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_BonusMoney"].ToString();
        }
        else
            rs = "该申请表未通过审核。";
        return rs;
    }
}
