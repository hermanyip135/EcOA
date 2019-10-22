using DataAccess.Operate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_BorrowMoney_PrintBorrowMoney : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        MainID = GetQueryString("MainID");
        string UrlMainID = GetQueryString("MainID");
   //MainID= "9c2e2a57-6d8f-4992-a6ce-e9736cf98dfb";
   //string  UrlMainID = "9c2e2a57-6d8f-4992-a6ce-e9736cf98dfb";
        if (!IsPostBack)
        {
            
            try
            {
                if (Session["FLG_ReWrite73"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite73"] = null;
                }
            }
            catch
            {
            }
            if (UrlMainID != "")
            {
                MainID = UrlMainID;
                LoadPage();
            }
           

        }
    }
    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
      
        string flowState;
        try
        {
            flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
        }
        catch
        {
            Alert(CommonConst.MSG_URL_DISABLE);
            RunJS("window.location='/Apply/Apply_Search.aspx'");
            return;
        }


        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_BorrowMoney_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_BorrowMoney_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_BorrowMoney_Apply"].ToString();

        lbApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_BorrowMoney_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtApplyID.Text = dr["OfficeAutomation_Document_BorrowMoney_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_BorrowMoney_Department"].ToString();
        txtReplyPhone.Text = dr["OfficeAutomation_Document_BorrowMoney_ReplyPhone"].ToString();
        txtNeedDate.Text = dr["OfficeAutomation_Document_BorrowMoney_NeedDate"].ToString();
        //   txtReason.Text = dr["OfficeAutomation_Document_BorrowMoney_Reason"].ToString();
        this.hidDetail1.Value = dr["OfficeAutomation_Document_BorrowMoney_Reason"].ToString();
        txtAcount.Text = dr["OfficeAutomation_Document_BorrowMoney_Acount"].ToString();
        txtAname.Text = dr["OfficeAutomation_Document_BorrowMoney_Aname"].ToString();
        txtBank.Text = dr["OfficeAutomation_Document_BorrowMoney_Bank"].ToString();
        //   txtMoney.Text = dr["OfficeAutomation_Document_BorrowMoney_Money"].ToString();
        lMoney.Text = dr["OfficeAutomation_Document_BorrowMoney_Money"].ToString();
        //txtBWMoney.Text = dr["OfficeAutomation_Document_BorrowMoney_BWMoney"].ToString();
        lBWMoney.Text = dr["OfficeAutomation_Document_BorrowMoney_BWMoney"].ToString();
        txtApplyNo.Text = dr["OfficeAutomation_Document_BorrowMoney_ApplyNo"].ToString();
       // txtDialog.Text = dr["OfficeAutomation_Document_BorrowMoney_Dialog"].ToString();
        string cbt = dr["OfficeAutomation_Document_BorrowMoney_PayK"].ToString();
        if (cbt.Contains("1"))
            cbPayK1.Checked = true;
        if (cbt.Contains("2"))
            cbPayK2.Checked = true;
        if (cbt.Contains("3"))
            cbPayK3.Checked = true;

        var detailbll = new DataAccess.Operate.DA_OfficeAutomation_Document_BorrowMoney_Detail_Operate();
        var detaillist = detailbll.SelectListByMainID(ID);
        double TotalCostSum = 0;
        if (detaillist != null && detaillist.Count > 0)
        {
            var dlist = detaillist.Select(m => new
            {
                month = m.OfficeAutomation_Document_BorrowMoney_Detail_StartDate == "" ?( m.OfficeAutomation_Document_BorrowMoney_Detail_CostProject == "其他" ? "" : m.OfficeAutomation_Document_BorrowMoney_Detail_CostProject + '、') + m.OfficeAutomation_Document_BorrowMoney_Detail_Other : m.OfficeAutomation_Document_BorrowMoney_Detail_StartDate + '至' + m.OfficeAutomation_Document_BorrowMoney_Detail_EndDate + '、' + m.OfficeAutomation_Document_BorrowMoney_Detail_CostProject + '、' + m.OfficeAutomation_Document_BorrowMoney_Detail_Other,
               
                UnitPrice = m.OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice
            }).ToList();
            this.hidDetail1.Value = JsonConvert.SerializeObject(dlist);
        }
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainIDInIdx(MainID,"1");
        DataSet dsFlow2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDInIdx(MainID, "2");
        DataSet dsFlow3 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDInIdx(MainID, "3");
        if (dsFlow.Tables[0].Rows.Count>0)
        {
            txtApplyName.Text = dsFlow.Tables[0].Rows[0]["OfficeAutomation_Flow_Auditor"].ToString();
        }
        if (dsFlow2.Tables[0].Rows.Count > 0)
        {
            txtDepartmentHead.Text = dsFlow2.Tables[0].Rows[0]["OfficeAutomation_Flow_Auditor"].ToString();
        }
        if (dsFlow3.Tables[0].Rows.Count > 0)
        {
            txtHeadOfTheDepartment.Text = dsFlow3.Tables[0].Rows[0]["OfficeAutomation_Flow_Auditor"].ToString();
        }
        
        #endregion
    }
}