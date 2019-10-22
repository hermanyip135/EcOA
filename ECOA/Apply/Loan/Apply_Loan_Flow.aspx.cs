using DataAccess.Operate;
using DataEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_Loan_Apply_Loan_Flow : BasePage
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
        DA_OfficeAutomation_Document_Loan_Detail_Inherit bllDetailInherit = new DA_OfficeAutomation_Document_Loan_Detail_Inherit();
        DA_OfficeAutomation_Document_Loan_Inherit bllInherit = new DA_OfficeAutomation_Document_Loan_Inherit();
        Decimal money = bllDetailInherit.LoanMoneyByMainID(MainID);
        T_OfficeAutomation_Document_Loan loanClass =  bllInherit.GetModel(MainID);
        //若放款原因为挞订转佣，需增加区域负责人的审批,若申请放款的金额大于或等于10000元，增加区域负责人
        if (loanClass.OfficeAutomation_Document_Loan_LoanReason.Contains("6"))
        {
            money = 10000;
        }
        this.hfMoney.Value = money.ToString();
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