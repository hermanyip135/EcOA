using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using DataAccess.Operate;
using DataEntity;
using System.Data;

/// <summary>
/// EBAdjuct 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class EBAdjuct : System.Web.Services.WebService {

    public EBAdjuct () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod(Description = "输入文档编码，有效期（起始～结束）和现金奖总额")]
    public string GetSomeThingFromEBAdjuct(string serialNumber)
    {
        DA_OfficeAutomation_Document_EBAdjuct_Inherit da_OfficeAutomation_Document_EBAdjuct_Inherit = new DA_OfficeAutomation_Document_EBAdjuct_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Main_Inherit.SelectBySerialNumber(serialNumber);
        string MainID = ds.Tables[0].Rows[0]["OfficeAutomation_Main_ID"].ToString();
        ds = da_OfficeAutomation_Document_EBAdjuct_Inherit.SelectByMainID(MainID);

        string rs = ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_ValidityBeginDate"].ToString()
            + "," + ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_ValidityEndDate"].ToString()
            + "," + ds.Tables[0].Rows[0]["OfficeAutomation_Document_EBAdjuct_BonusMoney"].ToString();

        return rs;
    }
    
}
