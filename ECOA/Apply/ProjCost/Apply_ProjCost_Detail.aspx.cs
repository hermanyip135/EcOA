using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using System.IO;

using DataAccess.Operate;
using DataEntity;

using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;

using System.Diagnostics; //M_PDF
using System.Web;

public partial class Apply_ProjCost_Apply_ProjCost_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public string ApplyN;

    public string sOfficeType = "";

    #endregion

    #region 页面加载及初始化

    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        SbJson.Append("[]");
        string UrlMainID = GetQueryString("MainID");
        SerialNumber = "";

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["htmltopdf"] == "Yes")  //M_PDF
                {
                    SbJs.Append("<script type=\"text/javascript\">$(\"div .flow\").hide();$(\"#PageBottom\").hide();</script>");
                    tpdf = true;
                }
            }
            catch
            { }
            try
            {
                if (Session["FLG_ReWrite15"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite15"] = null;
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
            else
                InitPage();
            
        }
        else
            GetAllDepartment();
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        IsNewApply = true;

        MainID = Guid.NewGuid().ToString();

        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        lblApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        InitListControler("");
    }

    private void InitListControler(string selectedValue)
    {
        DA_Dic_OfficeAutomation_DealOfficeType_Operate da_Dic_OfficeAutomation_DealOfficeType_Operate = new DataAccess.Operate.DA_Dic_OfficeAutomation_DealOfficeType_Operate();
        DataSet ds = da_Dic_OfficeAutomation_DealOfficeType_Operate.SelectByDocumentID(14);
        CheckBoxListBind(cblDealOfficeType, ds.Tables[0], "OfficeAutomation_DealOfficeType_ID", "OfficeAutomation_DealOfficeType_Name", selectedValue);
        for (int i = 0; i < cblDealOfficeType.Items.Count; i++)
        {
            cblDealOfficeType.Items[i].Attributes["tag"] = cblDealOfficeType.Items[i].Value;
        }
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        bool IsTempSave = false;        //是否暂存
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();

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

        SbJs.Append("<script type=\"text/javascript\">$(\"#spanApplyFor\").show();");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。如果没有显示居间人姓名的权限则隐藏tr

        if (flowState == "3")
        {
            SbJs.Append("$(\"#btnPrint\").show();");
            if (!Purview.Contains("OA_Special_001"))
            {
                SbJs.Append("$(\"#trBrokerCostReason\").hide();$(\"#trBrokerName\").hide();");
                gvAttach.Visible = false;
            }
        }

        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            //从暂存xml中读取
            var obj = new Common().GetTempSaveEntity<DataEntity.PageModel.Apply_ProjCost_Detail>("ProjCostDetail", "", Mainobj.OfficeAutomation_SerialNumber);
            ds = Common.GetPageDetailDS<DataEntity.PageModel.T_OfficeAutomation_Document_ProjCost_M>(obj.ProjCost_M, Mainobj);

            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;

            //从数据库中读取
            ds = da_OfficeAutomation_Document_ProjCost_Inherit.SelectByMainID(MainID);

        }
        if ("1".Equals(Mainobj.OfficeAutomation_Main_IsGroups))
        {
            this.laIsGroups.InnerText = "(此申请已添加集团审批)";
            DA_OfficeAutomation_Log_Inherit da_OfficeAutomation_Log_Inherit = new DA_OfficeAutomation_Log_Inherit();
            string GroupName = da_OfficeAutomation_Log_Inherit.getGroupOperate(MainID);
            if (!string.IsNullOrEmpty(GroupName))
            {
                hdGroupName.Value = "【" + GroupName + "添加集团审批】";
            }
        }
        //ds = da_OfficeAutomation_Document_ProjCost_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_ProjCost_ID"].ToString();

        #region FormIniti
        string applicant = dr["OfficeAutomation_Document_ProjCost_Apply"].ToString();
        ApplyN = applicant;
        lblApply.Text = applicant;
        txtApplyForID.Text = dr["OfficeAutomation_Document_ProjCost_ApplyForCode"].ToString();
        txtApplyFor.Value = dr["OfficeAutomation_Document_ProjCost_ApplyForName"].ToString();
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ProjCost_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtDepartment.Value = dr["OfficeAutomation_Document_ProjCost_Department"].ToString();
        hdDepartmentID.Value = dr["OfficeAutomation_Document_ProjCost_DepartmentID"].ToString();
        txtReplyPhone.Text = dr["OfficeAutomation_Document_ProjCost_ReplyPhone"].ToString();
        txtProject.Text = dr["OfficeAutomation_Document_ProjCost_Project"].ToString();
        txtDeveloper.Text = dr["OfficeAutomation_Document_ProjCost_Developer"].ToString();
        txtProjLeader.Text = dr["OfficeAutomation_Document_ProjCost_ProjLeader"].ToString();
        txtProjBusiLeader.Text = dr["OfficeAutomation_Document_ProjCost_ProjBusiLeader"].ToString();
        txtSquare.Text = dr["OfficeAutomation_Document_ProjCost_Square"].ToString();
        txtPreProjAgenceFee.Text = dr["OfficeAutomation_Document_ProjCost_PreProjAgenceFee"].ToString();
        txtBrokerCostApply.Text = dr["OfficeAutomation_Document_ProjCost_BrokerCostApply"].ToString();
        txtReceiver.Text = dr["OfficeAutomation_Document_ProjCost_Receiver"].ToString();
        txtBrokerCostReason.Text = dr["OfficeAutomation_Document_ProjCost_BrokerCostReason"].ToString();
        txtBrokerName.Text = dr["OfficeAutomation_Document_ProjCost_BrokerName"].ToString();

        //20141027+
        if (dr["OfficeAutomation_Document_ProjCost_JOrT"].ToString() == "1")
        {
            rdbJOrT1.Checked = true;
            txtSamePlaceXX1.Text = dr["OfficeAutomation_Document_ProjCost_SamePlaceXX1"].ToString();
            txtSamePlaceXX2.Text = dr["OfficeAutomation_Document_ProjCost_SamePlaceXX2"].ToString();
            txtAgencyFee1.Text = dr["OfficeAutomation_Document_ProjCost_AgencyFee1"].ToString();
            txtAgencyFee2.Text = dr["OfficeAutomation_Document_ProjCost_AgencyFee2"].ToString();
            if (dr["OfficeAutomation_Document_ProjCost_IsCashPrize1"].ToString() == "True")
            {
                rdbIsCashPrize11.Checked = true;
                txtCashPrize1.Text = dr["OfficeAutomation_Document_ProjCost_CashPrize1"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjCost_IsCashPrize1"].ToString() == "False")
                rdbIsCashPrize12.Checked = true;
            if (dr["OfficeAutomation_Document_ProjCost_IsCashPrize2"].ToString() == "True")
            {
                rdbIsCashPrize21.Checked = true;
                txtCashPrize2.Text = dr["OfficeAutomation_Document_ProjCost_CashPrize2"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjCost_IsCashPrize2"].ToString() == "False")
                rdbIsCashPrize22.Checked = true;

            if (dr["OfficeAutomation_Document_ProjCost_IsPFear1"].ToString() == "True")
            {
                rdbIsPFear11.Checked = true;
                txtPFear1.Text = dr["OfficeAutomation_Document_ProjCost_PFear1"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjCost_IsPFear1"].ToString() == "False")
                rdbIsPFear12.Checked = true;
            if (dr["OfficeAutomation_Document_ProjCost_IsPFear2"].ToString() == "True")
            {
                rdbIsPFear21.Checked = true;
                txtPFear2.Text = dr["OfficeAutomation_Document_ProjCost_PFear2"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjCost_IsPFear2"].ToString() == "False")
                rdbIsPFear22.Checked = true;
        }
        else if (dr["OfficeAutomation_Document_ProjCost_JOrT"].ToString() == "2")
        {
            rdbJOrT2.Checked = true;
            txtTurnsAgentXX1.Text = dr["OfficeAutomation_Document_ProjCost_TurnsAgentXX1"].ToString();
            txtTurnsAgentXX2.Text = dr["OfficeAutomation_Document_ProjCost_TurnsAgentXX2"].ToString();
            txtAgencyFee3.Text = dr["OfficeAutomation_Document_ProjCost_AgencyFee3"].ToString();
            txtAgencyFee4.Text = dr["OfficeAutomation_Document_ProjCost_AgencyFee4"].ToString();
            if (dr["OfficeAutomation_Document_ProjCost_IsCashPrize3"].ToString() == "True")
            {
                rdbIsCashPrize31.Checked = true;
                txtCashPrize3.Text = dr["OfficeAutomation_Document_ProjCost_CashPrize3"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjCost_IsCashPrize3"].ToString() == "False")
                rdbIsCashPrize32.Checked = true;
            if (dr["OfficeAutomation_Document_ProjCost_IsCashPrize4"].ToString() == "True")
            {
                rdbIsCashPrize41.Checked = true;
                txtCashPrize4.Text = dr["OfficeAutomation_Document_ProjCost_CashPrize4"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjCost_IsCashPrize4"].ToString() == "False")
                rdbIsCashPrize42.Checked = true;

            if (dr["OfficeAutomation_Document_ProjCost_IsPFear3"].ToString() == "True")
            {
                rdbIsPFear31.Checked = true;
                txtPFear3.Text = dr["OfficeAutomation_Document_ProjCost_PFear3"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjCost_IsPFear3"].ToString() == "False")
                rdbIsPFear32.Checked = true;
            if (dr["OfficeAutomation_Document_ProjCost_IsPFear4"].ToString() == "True")
            {
                rdbIsPFear41.Checked = true;
                txtPFear4.Text = dr["OfficeAutomation_Document_ProjCost_PFear4"].ToString();
            }
            else if (dr["OfficeAutomation_Document_ProjCost_IsPFear4"].ToString() == "False")
                rdbIsPFear42.Checked = true;
            txtAgencyBeginDate1.Text = dr["OfficeAutomation_Document_ProjCost_AgencyBeginDate1"].ToString();
            txtAgencyBeginDate2.Text = dr["OfficeAutomation_Document_ProjCost_AgencyBeginDate2"].ToString();
            txtAgencyEndDate1.Text = dr["OfficeAutomation_Document_ProjCost_AgencyEndDate1"].ToString();
            txtAgencyEndDate2.Text = dr["OfficeAutomation_Document_ProjCost_AgencyEndDate2"].ToString();
        }
        else if (dr["OfficeAutomation_Document_ProjCost_JOrT"].ToString() == "3")
            rdbJOrT3.Checked = true;
        //20141027+

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        InitListControler(dr["OfficeAutomation_Document_ProjCost_DealOfficeTypeID"].ToString());
        #endregion
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        //SbJs.Append("$(\"#btnUpload\").show();");
        if (!IsTempSave)
        {
            //非暂存才显示上传附件按钮
            SbJs.Append("$(\"#btnUpload\").show();");
        }
        if (IsTempSave)
        {
            btnSPDF.Visible = false;
        }
        bool isApplicant = EmployeeName == applicant;
        if (isApplicant || EmployeeName == CommonConst.EMP_PROJECT_CLAUSEANDPROJCOST_NAME)
        {
            //SbJs.Append("$(\"#btnUpload\").show();");
            if (flowState == "1" || flowState=="7")
            {
                GetAllDepartment();
                btnSave.Visible = true;
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
            }
        }

        try //M_AddAnother：20150716 黄生其它意见，增加审批人
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
            DataSet dsFlow = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);
            DataRowCollection drcz = dsFlow.Tables[0].Rows;
            T_OfficeAutomation_Flow flowsa, flowst, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 3);
            flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 200);
            flowst = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndEID(MainID, "0001");

            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF1\").show();");
            if (((drcz[0]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID)
                && drcz[0]["OfficeAutomation_Flow_Auditor"].ToString().Contains(EmployeeName))
                && flowst.OfficeAutomation_Flow_IsAgree == 2)
                || (EmployeeName == applicant && flowst.OfficeAutomation_Flow_IsAgree == 2) //|| (fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && flowst.OfficeAutomation_Flow_IsAgree == 2) 
                )
            {
                SbJs.Append("$(\"#trAddAnoF1\").show();");
                btnsSignIDx200.Visible = true;
                //if ((!fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) || !fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName)) && flowsa != null)
                //    btnsSignIDx200.Visible = false; //M_AlAno：20160217 ++
            }

            flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 220);
            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF3\").show();");
            if (flowst.OfficeAutomation_Flow_AuditorID.Contains(EmployeeID)
                && flowst.OfficeAutomation_Flow_Auditor.Contains(EmployeeName)
                && flowst.OfficeAutomation_Flow_IsAgree == 2
                && flowsa != null
                )
                btnsSignIDx220.Visible = true;
        }
        catch
        {
        }

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1") 
            {
                SbJs.Append("$(\"#btnPrint\").hide();");
                SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
                SbJs.Append("</script>");
                IsNewApply = true;

                MainID = Guid.NewGuid().ToString();

                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                btnSave.Visible = true;
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                flowState = "1";
                btnSAlterC.Visible = false;
                return;
            }
        }
        catch
        {
            if ((isApplicant || EmployeeName == CommonConst.EMP_PROJECT_CLAUSEANDPROJCOST_NAME) && !IsTempSave)
                btnReWrite.Visible = true; //*-+
        }

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        if ((EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "24962") && flowState == "3")
            btnSignSave.Visible = true;

        #endregion

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = ds.Tables[0].Rows;

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion

        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("审批流程:");
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            //if (curidx == "8")
            //    flag3 = true;
            if ("1000".Equals(curidx))//显示集团审核总经办
            {
                SbJs.Append("$(\"#trGeneralGroups\").show();");
            }
            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                //SbFlow.Append("auditing\">待" + curemp + "审理");
                if ("1000".Equals(curidx))
                {
                    SbFlow.Append("auditing\">待集团审理");
                }
                else
                {
                    SbFlow.Append("auditing\">待" + curemp + "审理");
                }
                flag2 = false;

                if (curemp.Contains(EmployeeName))
                {
                    switch (curidx)
                    {
                        //case "6":
                        //    //ckbAddIDx7.Visible = true;
                        //    break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                {
                    if ("1000".Equals(curidx))
                    {
                        SbFlow.Append("other\">" + "集团已完成审理");
                    }
                    else
                    {
                        SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Auditor"] + "已完成审理");
                    }
                }

                else
                {
                    if ("1000".Equals(curidx))
                    {
                        SbFlow.Append("other\">" + "集团");
                    }
                    else
                    {
                        SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Employee"]);
                    }

                }

            }
            //else
            //{
            //    if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            //        SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Auditor"] + "已完成审理");
            //    else
            //        SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Employee"]);
            //}
            SbFlow.Append("</span>");

            //箭头图片
            if (i != (drc.Count - 1))//如果不是最后一项
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                    SbFlow.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
                else
                    SbFlow.Append("<img src=\"/Images/forward_skip.png\" class=\"forward\"/>");
            }
            #endregion

            #region 显示签名人姓名，签名图片，或签名按钮

            string[] auditorIDs = drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Split(',');
            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            {
                SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:0px; float:left;\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                foreach (string s in auditorIDs)
                {
                    if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                    {
                        SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                    }
                    SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" />");
                }
                SbJs.Append("');");

                //如果是否同意为0则不同意按钮选中，为2则其他意见按钮选中，为真或空，则同意按钮选中。
                if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                    SbJs.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");
                else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                    SbJs.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");
                else
                    SbJs.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");

                if (string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').hide();");
                else
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
            }
            else
            {
                if (auditorIDs.Length > 0 && auditorIDs[0] != "")
                {
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:20px; float:left;\">"
                                       + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" />");
                    }
                    SbJs.Append("');");

                    //如果是否同意为1，则同意按钮选中，为0则不同意按钮选中，为2则其他意见按钮选中。
                    if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "1")
                        SbJs.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                        SbJs.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                        SbJs.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').attr('checked','checked');");

                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");
                    SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
                }

                if (!string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                if (flag && da_OfficeAutomation_Agent_Inherit.IsHaveSignPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(),
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID))
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').show();");

                flag = false;
            }

            if (i >= 2 && drc[i]["OfficeAutomation_Flow_Auditor"].ToString() != "") //M_AddAnother：20150716 黄生其它意见，增加审批人
            {
                SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_AuditDate"].ToString() + "');");
                SbJs.Append("$('#ctl00_ContentPlaceHolder1_txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                if (drc[i]["OfficeAutomation_Flow_AuditDate"].ToString() != "" && drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString().Contains(EmployeeID) && drc[i]["OfficeAutomation_Flow_Employee"].ToString().Contains(EmployeeName))
                { //M_RA：20151120
                    SbJs.Append("$('#ctl00_ContentPlaceHolder1_txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 98%; \">"
                               + "<br/>上一次复审意见：<br/><br/>" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "").Replace("\n", "<br/>") + "<br/><br/></div>').val('');");
                }

                if (auditorIDs.Length > 0 && auditorIDs[0] != "")
                {
                    SbJs.Append("$('#ctl00_ContentPlaceHolder1_txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').after('<div style=\"width: 200px; line-height: 55px; height: 2px; margin-left:20px; float:left;\">"
                                       + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" />");
                    }
                    SbJs.Append("');");

                    if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "1") //M_AlterM：20150820
                        SbJs.Append("$('#ctl00_ContentPlaceHolder1_rdb" + drc[i]["OfficeAutomation_Flow_IDx"] + "a1').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                        SbJs.Append("$('#ctl00_ContentPlaceHolder1_rdb" + drc[i]["OfficeAutomation_Flow_IDx"] + "a2').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                        SbJs.Append("$('#ctl00_ContentPlaceHolder1_rdb" + drc[i]["OfficeAutomation_Flow_IDx"] + "a3').attr('checked','checked');");
                }
            }

            #endregion
        }

        ////如果有后勤事务部，董事总经理流程，则显示后勤事务部，董事总经理内容
        //if (flag3)
        //    SbJs.Append("$('#trLogistics').show();$('#trGeneralManager').show();");

        //如果为未审核状态且登入人为申请人，开启编辑按钮
        if (flowState == "1" && (applicant == EmployeeName || EmployeeName == CommonConst.EMP_PROJECT_CLAUSEANDPROJCOST_NAME))
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && (applicant == EmployeeName || EmployeeName == CommonConst.EMP_PROJECT_CLAUSEANDPROJCOST_NAME) && !tpdf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;
        SbFlow.Append("</div>");

        ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID); //20141231：M_DeleteC
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlowsByMID(MainID);
            SbJs.Append("$('#btnADelete').before('<div id=\"SummaryOfDelete_Red\" style=\"color: red; font-size: large; font-weight: bold\">（该表即将被删除）</div>');$('h1').css('color','red');");
            string[] employnames;
            string employname;
            foreach (DataRow dr2 in ds.Tables[0].Rows)
            {
                employname = dr2["OfficeAutomation_DeletedFlow_AuditorID"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    if (employnames[i2] == EmployeeID)
                        SbJs.Append("$('#btnADelete').show();$('#SummaryOfDelete_Red').hide();");
                }
            }
            #region 显示删除流程示意图
            SbFlow.Length = 0;//清空审批流程
            FlowCommonMethod flowCom = new FlowCommonMethod();
            SbFlow.Append(flowCom.ShowDelFlow(MainID));
            btnEditFlow2.Visible = false;
            #endregion
        }
        else //20150225：M_DeleteC 不同意时显示最后确认时间
        {
            DA_OfficeAutomation_Document_LastSure_Inherit da_OfficeAutomation_Document_LastSure_Inherit = new DA_OfficeAutomation_Document_LastSure_Inherit();
            ds = da_OfficeAutomation_Document_LastSure_Inherit.SelectByMid(MainID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                SbJs.Append("$('#snum').prepend('<span id=\"SummaryOfDelete_Green\" style=\"color: green; float:left; font-weight: bold\">区域最后确认时间：" + ds.Tables[0].Rows[0]["OfficeAutomation_Document_LastSure_Time"].ToString() + "</span>');");
            }
        }

        #endregion

        SbJs.Append("$.each($(\"textarea:not([id*=txtDescribe])\"), function (idx, item) { autoTextarea(this); });");
        SbJs.Append("</script>");

        LoadAttach();
    }

    /// <summary>
    /// 加载附件列表
    /// </summary>
    private void LoadAttach()
    {
        //获取该单附件列表
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DataSet dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);

        gvAttach.DataSource = dsAttach;
        gvAttach.DataBind();

        //如果该单有附件，则下载按钮显示
        btnDownload.Visible = (dsAttach != null && dsAttach.Tables[0] != null && dsAttach.Tables[0].Rows.Count > 0);
    }

    #endregion

    #region 事件

    #region 按钮点击事件

    #region 保存按钮点击事件
    /// <summary>
    /// 保存按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region 创建对象

        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_ProjCost t_OfficeAutomation_Document_ProjCost = new T_OfficeAutomation_Document_ProjCost();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1") 
            {
                //MainID = "";
                //MainID = Guid.NewGuid().ToString();
                IsNewApply = true;
            }
        }
        catch
        {
        }

        try
        {
            for (int i = 0; i <= this.cblDealOfficeType.Items.Count - 1; i++)
            {
                if (this.cblDealOfficeType.Items[i].Selected == true)
                { sOfficeType = sOfficeType + this.cblDealOfficeType.Items[i].Value + "|"; }
            }
            sOfficeType = sOfficeType.Substring(0, sOfficeType.Length - 1);

            if (IsNewApply)
            {
                #region 新建
                string[] sHRTree;
                try
                {
                    sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                }
                catch
                {
                    Alert("请正确选择发文部门！");
                    return;
                }

                #region 检测是否上传了附件，无上传则不予保存操作

                //获取该单附件列表
                DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
                DataSet dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);

                if (dsAttach == null || dsAttach.Tables[0] == null || dsAttach.Tables[0].Rows.Count == 0)
                {
                    Alert("请先上传居间人身份证/名片作为附件，之后才可提交申请！");
                    return;
                }

                #endregion

                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ProjCost" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 14;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Apply = EmployeeName;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ApplyForName = txtApplyFor.Value;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ApplyForCode = txtApplyForID.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Department = txtDepartment.Value;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_DepartmentID = new Guid(hdDepartmentID.Value);
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ReplyPhone = txtReplyPhone.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Project = txtProject.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Developer = txtDeveloper.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ProjLeader = txtProjLeader.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ProjBusiLeader = txtProjBusiLeader.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_DealOfficeTypeID = sOfficeType;//hdDealOfficeType.Value; 
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Square = txtSquare.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PreProjAgenceFee = txtPreProjAgenceFee.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_BrokerCostApply = txtBrokerCostApply.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Receiver = txtReceiver.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_BrokerCostReason = txtBrokerCostReason.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_BrokerName = txtBrokerName.Text;

                //20141027+
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_JOrT = rdbJOrT1.Checked ? 1 : rdbJOrT2.Checked ? 2 : rdbJOrT3.Checked ? 3 : 0;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_SamePlaceXX1 = txtSamePlaceXX1.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_SamePlaceXX2 = txtSamePlaceXX2.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_TurnsAgentXX1 = txtTurnsAgentXX1.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_TurnsAgentXX2 = txtTurnsAgentXX2.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee1 = txtAgencyFee1.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee2 = txtAgencyFee2.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee3 = txtAgencyFee3.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee4 = txtAgencyFee4.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize1 = rdbIsCashPrize11.Checked;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize2 = rdbIsCashPrize21.Checked;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize3 = rdbIsCashPrize31.Checked;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize4 = rdbIsCashPrize41.Checked;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize1 = txtCashPrize1.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize2 = txtCashPrize2.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize3 = txtCashPrize3.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize4 = txtCashPrize4.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyBeginDate1 = txtAgencyBeginDate1.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyBeginDate2 = txtAgencyBeginDate2.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyEndDate1 = txtAgencyEndDate1.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyEndDate2 = txtAgencyEndDate2.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear1 = rdbIsPFear11.Checked;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear2 = rdbIsPFear21.Checked;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear3 = rdbIsPFear31.Checked;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear4 = rdbIsPFear41.Checked;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear1 = txtPFear1.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear2 = txtPFear2.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear3 = txtPFear3.Text;
                t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear4 = txtPFear4.Text;
                //20141027+

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Value;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtProject.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_ProjCost_Inherit.Add(t_OfficeAutomation_Document_ProjCost);//插入申请表

                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                #region 根据默认流程表中的固定环节添加流程

                ds = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString());
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (string.IsNullOrEmpty(dr["OfficeAutomation_Document_Flow_Position"].ToString()))
                        {
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = dr["OfficeAutomation_Document_Flow_AuditCode"].ToString();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = dr["OfficeAutomation_Document_Flow_AuditName"].ToString();
                        }

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(dr["OfficeAutomation_Document_Flow_Idx"].ToString());

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }

                #endregion

                #region 添加前线总监

                //int count = sHRTree[0].Split(',').Length;

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sHRTree[0].Split(',')[0];
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sHRTree[1].Split(',')[0];
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 18, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("var win=window.showModalDialog(\"Apply_ProjCost_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    string[] sHRTree;
                    try
                    {
                        sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                    }
                    catch
                    {
                        Alert("请正确选择发文部门！");
                        return;
                    }

                    #region 检测是否上传了附件，无上传则不予保存操作

                    //获取该单附件列表
                    DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
                    DataSet dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);

                    if (dsAttach == null || dsAttach.Tables[0] == null || dsAttach.Tables[0].Rows.Count == 0)
                    {
                        Alert("请先上传居间人身份证/名片作为附件，之后才可提交申请！");
                        return;
                    }

                    #endregion

                    var MainObj = da_OfficeAutomation_Main_Inherit.GetModel("[OfficeAutomation_Main_ID]='" + MainID + "'");
                    //是否暂存
                    bool tempsave = MainObj.OfficeAutomation_Main_FlowStateID == 7;
                    if (tempsave)
                    {
                        //是,更新主表状态
                        MainObj.OfficeAutomation_Main_FlowStateID = 2;
                        da_OfficeAutomation_Main_Inherit.Edit(MainObj);
                    }

                    Update();
                    //暂存第一次提交需要上传附件+编辑流程
                    if (tempsave)
                    {
                        #region 保存默认流程
                        DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                        #region 根据默认流程表中的固定环节添加流程
                        DataSet ds = new DataSet();
                        ds = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(MainID);
                        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                if (string.IsNullOrEmpty(dr["OfficeAutomation_Document_Flow_Position"].ToString()))
                                {
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = dr["OfficeAutomation_Document_Flow_AuditCode"].ToString();
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = dr["OfficeAutomation_Document_Flow_AuditName"].ToString();
                                }

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(dr["OfficeAutomation_Document_Flow_Idx"].ToString());

                                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                            }
                        }

                        #endregion

                        #region 添加前线总监

                        //int count = sHRTree[0].Split(',').Length;

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sHRTree[0].Split(',')[0];
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sHRTree[1].Split(',')[0];
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        #endregion

                        #endregion
                        RunJS("var win=window.showModalDialog(\"Apply_ProjCost_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                    }
                    else
                    {
                        RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
                    }
                }
                else
                    Alert("未开通编辑修改权限。");
                #endregion
            }
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
            Alert("保存失败！" + ex.Message);
        }
    }

    protected void btnTempSave_Click(object sender, EventArgs e) 
    {
        for (int i = 0; i <= this.cblDealOfficeType.Items.Count - 1; i++)
        {
            if (this.cblDealOfficeType.Items[i].Selected == true)
            { sOfficeType = sOfficeType + this.cblDealOfficeType.Items[i].Value + "|"; }
        }
        if (sOfficeType!="") 
        {
            sOfficeType = sOfficeType.Substring(0, sOfficeType.Length - 1);
        }
        
        var SerialNumber = "ProjCost" + DateTime.Now.ToString("yyyyMMddHHmmssfffff");
        var DocumentID = 14;
        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName, txtDepartment.Value);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }
        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();
        var ProjCost = new DataEntity.PageModel.T_OfficeAutomation_Document_ProjCost_M();
        ds = da_OfficeAutomation_Document_ProjCost_Inherit.SelectByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ProjCost = GetModelFromPage(Guid.NewGuid());
        }
        else
        {
            var ProjReDaAdd_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjCost_ID"].ToString();
            ProjCost = GetModelFromPage(new Guid(ProjReDaAdd_ID));
        }
        var obj = new DataEntity.PageModel.Apply_ProjCost_Detail();
        obj.MainEntity = t_OfficeAutomation_Main;
        //var ProjReDaAdd = GetModelMFromPage(Guid.NewGuid());
        da_OfficeAutomation_Document_ProjCost_Inherit.HandleBase(ProjCost);                      //只插入关键必填字段；

        obj.ProjCost_M = ProjCost;
        var result = new Common().SaveTempSaveFile<DataEntity.PageModel.Apply_ProjCost_Detail>(obj, "ProjCostDetail", "", t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
        if (result)
        {
            RunJS("alert('保存成功！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
        else
        {
            RunJS("alert('保存失败！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
    }
    #endregion

    #region 下载附件按钮单击事件
    /// <summary>
    /// 下载附件按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        //根据复选框的选中状态，将多个文件打包下载
        List<string> files = new List<string>();
        foreach (GridViewRow item in gvAttach.Rows)
        {
            CheckBox chk = item.FindControl("chk") as CheckBox;
            if (chk != null && chk.Checked)
            {
                HiddenField hf = item.FindControl("hfPath") as HiddenField;
                if (hf != null) files.Add(hf.Value);
            }
        }

        if (files.Count > 0)
        {
            Download(files, "Attachment-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
            Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(MainID), 8);
        }
        else
            Alert("请勾选文件再下载！");
    }
    #endregion

    #region 签名按钮点击事件
    /// <summary>
    /// 签名按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSign_Click(object sender, EventArgs e)
    {
        DataSet dsg = new DataSet(); //20150105：M_DeleteC
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
        dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
        if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
            return;
        }
        DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();

        DataSet ds = da_OfficeAutomation_Document_ProjCost_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_ProjCost_ID"].ToString();

        string flowIDx = "0";
        string signEmployeeName = EmployeeName;
        string signEmployeeId = EmployeeID;

        if (Purview.Contains("OA_ITPower_002"))
        {
            try
            {
                if (!CheckGIFIsExist(EmployeeID))
                {
                    RunJS("alert('" + CommonConst.MSG_NO_SIGNIMAGE + "');window.location.href='" + Request.RawUrl + "';");
                    return;
                }

                DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                DataRowCollection drc = dsFlow.Tables[0].Rows;
                for (int i = 0; i < drc.Count; i++)
                {
                    if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False")
                    {
                        if (i > 0 && drc[i - 1]["OfficeAutomation_Flow_Audit"].ToString() == "False")
                        {
                            RunJS("alert('您之前的审批环节已被撤销，请稍后再审。');window.location='" + Page.Request.Url + "'");
                            return;
                        }
                        DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                        //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                        string haveSignPowerEmployee = da_OfficeAutomation_Agent_Inherit.HaveSignPowerEmployee(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(), EmployeeName, EmployeeID);
                        if (haveSignPowerEmployee != null)
                        {
                            flowIDx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
                            signEmployeeName = haveSignPowerEmployee.Split('|')[0];
                            signEmployeeId = haveSignPowerEmployee.Split('|')[1];
                            break;
                        }
                    }
                }

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                bool isSignSuccess = da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjCost_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_ProjCost_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_ProjCost_ApplyForName"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_ProjCost_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ProjCost_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>回复电话：" + drRow["OfficeAutomation_Document_ProjCost_ReplyPhone"]);
                    sbMailBody.Append("<br/><br/>项目名称：" + drRow["OfficeAutomation_Document_ProjCost_Project"]);
                    sbMailBody.Append("<br/>发展商：" + drRow["OfficeAutomation_Document_ProjCost_Developer"]);
                    sbMailBody.Append("<br/>项目负责人：" + drRow["OfficeAutomation_Document_ProjCost_ProjLeader"]);
                    sbMailBody.Append("<br/>项目拓展负责人：" + drRow["OfficeAutomation_Document_ProjCost_ProjBusiLeader"]);
                    sbMailBody.Append("<br/>可售面积：" + drRow["OfficeAutomation_Document_ProjCost_Square"]);
                    sbMailBody.Append("<br/>预计项目代理费计提：" + drRow["OfficeAutomation_Document_ProjCost_PreProjAgenceFee"]);
                    sbMailBody.Append("<br/>居间费用计提申请：" + drRow["OfficeAutomation_Document_ProjCost_BrokerCostApply"]);
                    sbMailBody.Append("<br/>收款人姓名：" + drRow["OfficeAutomation_Document_ProjCost_Receiver"]);
                    sbMailBody.Append("<br/>居间费用计提原因：" + drRow["OfficeAutomation_Document_ProjCost_BrokerCostReason"]);

                    mailBody = sbMailBody.ToString();

                    if (hdIsAgree.Value != "0")//同意或其他意见
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名同意

                        //判断审批流程是否完成,通知相应人员
                        if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(MainID))
                        {
                            //审批流程完成，通知申请人
                            msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            email = apply;
                            if (hdIsAgree.Value == "2")
                                Common.SendMessageEX(false, email, "其他意见", msnBody, msnBody);
                            else
                                Common.SendMessageEX(false, email, "申请已同意", msnBody, msnBody);

                            string employeeList = "";//该字段用于防止重复发送
                            foreach (DataRow dr in dsFlow.Tables[0].Rows)
                            {
                                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    if (!employeeList.Contains(employnames[i]))
                                    {
                                        msnBody = "您好，" + employnames[i] + "：您审理过的" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        email = employnames[i];
                                        if (hdIsAgree.Value == "2")
                                            Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                        else
                                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                        employeeList += employnames[i] + "||";
                                    }
                                }
                            }

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //项目费用完成后需抄送给的人
                            employname = CommonConst.EMP_COOPCOST_COPYTO_NAME + ",宁伟雄,冯琰,黄洁珍,钟惠贤,官东升,钟惠贤,张绍欣,黄瑛,刘韵";
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    email = employnames[i];
                                    if (hdIsAgree.Value == "2")
                                        Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                    else
                                        Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                    employeeList += employnames[i] + "||";
                                }
                            }
                        }
                        else
                        {
                            //通知申请人
                            msnBody = "您好，" + apply + "：您的" + department + "的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            email = apply;
                            Common.SendMessageEX(false, email, "申请已通过" + EmployeeName + "的审理", msnBody, msnBody);

                            //通知下一步需要审批的人员
                            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
                            if (!employname.Contains(EmployeeName))
                            {
                                 string IsGroups = dsg.Tables[0].Rows[0]["OfficeAutomation_Main_IsGroups"].ToString();
                                 if ("1".Equals(IsGroups) && "梁健菁".Equals(employname))
                                 {
                                     string sAgree = hdIsAgree.Value == "1" ? "同意" : "其他意见";
                                     msnBody = "您好，梁健菁：现有一份发文部门：" + department + "的" + documentName + ",文档编号为" + serialNumber + "需报请集团审批。<br />黄生的意见是：" + sAgree + "<br />" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                     string Groupsemail = "梁健菁";
                                     if (hdIsAgree.Value == "2")
                                         Common.SendMessageEX(false, Groupsemail, "其他意见", msnBody, msnBody);
                                     else
                                         Common.SendMessageEX(false, Groupsemail, "申请已同意", msnBody, msnBody);
                                 }
                                 else
                                 {
                                     employnames = employname.Split(',');
                                     for (int i = 0; i < employnames.Length; i++)
                                     {
                                         email = employnames[i];
                                         msnBody = "您好，" + employnames[i] + "：您有" + department + "的编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                         Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody, MainID);
                                     }
                                 }
                            }

                            //当审批到总经理的时候，发份邮件通知总办2位同事
                            if (employname.Contains(CommonConst.EMP_GENERALMANAGER_NAME))
                            {
                                employname = CommonConst.EMP_GMO_NAME;
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "，编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(false, email, "请注意总经理有一份" + documentName + "需要审理", msnBody + mailBody, msnBody);
                                }
                            }
                        }

                        RunJS("alert('审批成功！');window.location='" + Page.Request.Url + "'");
                    }
                    else //不同意
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 5);//添加日志，签名不同意

                        //通知申请人
                        msnBody = "您好，" + apply + "：您的" + department + "的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        email = apply;
                        Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", msnBody, msnBody);

                        //通知已审批的人员
                        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(ID);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                msnBody = "您好，" + employnames[i] + "：您审理过的" + department + "的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                email = employnames[i];
                                Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", msnBody + mailBody, msnBody);
                            }
                        }

                        if (EmployeeID == "0001") //抄送到总办
                        {
                            string sagree = "";
                            if (hdSuggestion.Value != "")
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            employname = CommonConst.EMP_GMO_NAME;
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                email = employnames[i];
                                Common.SendMessageEX(false, email, "申请不同意", msnBody + mailBody, msnBody);
                            }
                        } //总办

                        RunJS("alert('审理成功！');window.location='" + Page.Request.Url + "'");
                    }
                }
            }
            catch
            {
                Alert("审理失败！");
            }
        }
        else
        {
            Alert("未开通审核权限！");
        }
    }
    #endregion

    #region 标记按钮点击事件

    /// <summary>
    /// 点击标记按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSignSave_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();
            if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID || EmployeeID == "24962")
                da_OfficeAutomation_Document_ProjCost_Inherit.AddRemarkByID_II(MainID, CommonConst.SIGN_FINANCE);
            RunJS("alert('标记成功。');window.location.href='" + Page.Request.Url + "';");
        }
        catch
        {
            Alert("标记失败。");
        }
    }

    #endregion

    #region 返回按钮点击事件
    protected void btnBack_Click(object sender, EventArgs e)
    {
          
        string sUrl = "/Apply/Apply_Search.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
    }
    #endregion

    #endregion

    #region datagrid事件

    /// <summary>
    /// gvAttachment的行命令操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttach_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        string commType = e.CommandName;
        switch (commType)
        {
            case "Del":
                Alert("删除附件" + (da_OfficeAutomation_Attach_Inherit.Delete(e.CommandArgument.ToString()) ? "成功!" : "失败!"));
                Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(MainID), 3);
                break;
        }

        LoadPage();
    }

    #endregion

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_ProjCost t_OfficeAutomation_Document_ProjCost = new T_OfficeAutomation_Document_ProjCost();
        DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ProjCost_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjCost_ID"].ToString();

        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ID = new Guid(ID);
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ApplyForName = txtApplyFor.Value;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ApplyForCode = txtApplyForID.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Department = txtDepartment.Value;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_DepartmentID = new Guid(hdDepartmentID.Value);
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Project = txtProject.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Developer = txtDeveloper.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ProjLeader = txtProjLeader.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ProjBusiLeader = txtProjBusiLeader.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_DealOfficeTypeID = sOfficeType; //hdDealOfficeType.Value;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Square = txtSquare.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PreProjAgenceFee = txtPreProjAgenceFee.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_BrokerCostApply = txtBrokerCostApply.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Receiver = txtReceiver.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_BrokerCostReason = txtBrokerCostReason.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_BrokerName = txtBrokerName.Text;

        //20141027+
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_JOrT = rdbJOrT1.Checked ? 1 : rdbJOrT2.Checked ? 2 : rdbJOrT3.Checked ? 3 : 0;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_SamePlaceXX1 = txtSamePlaceXX1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_SamePlaceXX2 = txtSamePlaceXX2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_TurnsAgentXX1 = txtTurnsAgentXX1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_TurnsAgentXX2 = txtTurnsAgentXX2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee1 = txtAgencyFee1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee2 = txtAgencyFee2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee3 = txtAgencyFee3.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee4 = txtAgencyFee4.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize1 = rdbIsCashPrize11.Checked;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize2 = rdbIsCashPrize21.Checked;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize3 = rdbIsCashPrize31.Checked;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize4 = rdbIsCashPrize41.Checked;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize1 = txtCashPrize1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize2 = txtCashPrize2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize3 = txtCashPrize3.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize4 = txtCashPrize4.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyBeginDate1 = txtAgencyBeginDate1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyBeginDate2 = txtAgencyBeginDate2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyEndDate1 = txtAgencyEndDate1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyEndDate2 = txtAgencyEndDate2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear1 = rdbIsPFear11.Checked;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear2 = rdbIsPFear21.Checked;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear3 = rdbIsPFear31.Checked;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear4 = rdbIsPFear41.Checked;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear1 = txtPFear1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear2 = txtPFear2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear3 = txtPFear3.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear4 = txtPFear4.Text;
        //20141027+

        string apply = "";
        string depname = txtDepartment.Value;
        string summary = txtProject.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_ProjCost_Inherit.Update(t_OfficeAutomation_Document_ProjCost);//修改申请表

        Common.AddLog(EmployeeID, EmployeeName, 18, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        if (Cache["AllDepartment"] == null)
        {
            SbJson.Remove(0, SbJson.Length);
            wsKDHR.Service service = new wsKDHR.Service();
            DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
            SbJson.Append("[");

            foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
            {
                SbJson.Append("{\"id\":\"" + dr["id"].ToString() + "\",\"value\":\"" + dr["name"].ToString() + "\"},");
            }

            SbJson.Remove(SbJson.Length - 1, 1);
            SbJson.Append("]");
            Cache["AllDepartment"] = SbJson;
        }
        else
            SbJson = (StringBuilder)Cache["AllDepartment"];
    }
    #endregion

    #region 从页面获取model数据
    private DataEntity.PageModel.T_OfficeAutomation_Document_ProjCost_M GetModelFromPage(Guid ProjCostID) 
    {
        var t_OfficeAutomation_Document_ProjCost = new DataEntity.PageModel.T_OfficeAutomation_Document_ProjCost_M();
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ID = ProjCostID.ToString();
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_MainID = MainID;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Apply = EmployeeName;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ApplyForName = txtApplyFor.Value;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ApplyForCode = txtApplyForID.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Department = txtDepartment.Value;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_DepartmentID = hdDepartmentID.Value != "" ? hdDepartmentID.Value : Guid.NewGuid().ToString();
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ApplyDate = DateTime.Now.ToString();
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Project = txtProject.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Developer = txtDeveloper.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ProjLeader = txtProjLeader.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_ProjBusiLeader = txtProjBusiLeader.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_DealOfficeTypeID = sOfficeType;//hdDealOfficeType.Value; 
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Square = txtSquare.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PreProjAgenceFee = txtPreProjAgenceFee.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_BrokerCostApply = txtBrokerCostApply.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_Receiver = txtReceiver.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_BrokerCostReason = txtBrokerCostReason.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_BrokerName = txtBrokerName.Text;

        //20141027+
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_JOrT = rdbJOrT1.Checked ? "1" : rdbJOrT2.Checked ? "2" : rdbJOrT3.Checked ? "3" : "0";
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_SamePlaceXX1 = txtSamePlaceXX1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_SamePlaceXX2 = txtSamePlaceXX2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_TurnsAgentXX1 = txtTurnsAgentXX1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_TurnsAgentXX2 = txtTurnsAgentXX2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee1 = txtAgencyFee1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee2 = txtAgencyFee2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee3 = txtAgencyFee3.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyFee4 = txtAgencyFee4.Text;
        if (rdbIsCashPrize11.Checked || rdbIsCashPrize12.Checked)
        {
            t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize1 = rdbIsCashPrize11.Checked.ToString();
        }
        if (rdbIsCashPrize21.Checked || rdbIsCashPrize22.Checked)
        {
            t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize2 = rdbIsCashPrize21.Checked.ToString();
        }
        if (rdbIsCashPrize31.Checked || rdbIsCashPrize32.Checked)
        {
            t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize3 = rdbIsCashPrize31.Checked.ToString();
        }
        if (rdbIsCashPrize41.Checked || rdbIsCashPrize42.Checked)
        {
            t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsCashPrize4 = rdbIsCashPrize41.Checked.ToString();
        }
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize1 = txtCashPrize1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize2 = txtCashPrize2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize3 = txtCashPrize3.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_CashPrize4 = txtCashPrize4.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyBeginDate1 = txtAgencyBeginDate1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyBeginDate2 = txtAgencyBeginDate2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyEndDate1 = txtAgencyEndDate1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_AgencyEndDate2 = txtAgencyEndDate2.Text;
        if (rdbIsPFear11.Checked || rdbIsPFear12.Checked) 
        {
            t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear1 = rdbIsPFear11.Checked.ToString();
        }
        if (rdbIsPFear21.Checked || rdbIsPFear22.Checked)
        {
            t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear2 = rdbIsPFear21.Checked.ToString();
        }
        if (rdbIsPFear31.Checked || rdbIsPFear32.Checked)
        {
            t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear3 = rdbIsPFear31.Checked.ToString();
        }
        if (rdbIsPFear41.Checked || rdbIsPFear42.Checked)
        {
            t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_IsPFear4 = rdbIsPFear41.Checked.ToString();
        }
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear1 = txtPFear1.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear2 = txtPFear2.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear3 = txtPFear3.Text;
        t_OfficeAutomation_Document_ProjCost.OfficeAutomation_Document_ProjCost_PFear4 = txtPFear4.Text;
        return t_OfficeAutomation_Document_ProjCost;
    }
    #endregion
    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite15"] = "1";
        Response.Write("<script>window.open('Apply_ProjCost_Detail.aspx?MainID=" + MainID + "');</script>");
    }
    protected void btnSPDF_Click(object sender, EventArgs e) //M_PDF
    {
        try
        {
            //因为Web 是多线程环境，避免甲产生的文件被乙下载去，所以档名都用唯一 
            string fileNameWithOutExtention = Guid.NewGuid().ToString();
            string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri + "&htmltopdf=Yes&EPID=" + EmployeeID + " ";
            //执行wkhtmltopdf.exe 
            Process p = System.Diagnostics.Process.Start(System.Web.HttpContext.Current.Server.MapPath("/Exe\\wkhtmltopdf.exe"), baseUrl + System.Web.HttpContext.Current.Server.MapPath("/Temp\\" + fileNameWithOutExtention + ".pdf"));
            //若不加这一行，程序就会马上执行下一句而抓不到文件发生意外：System.IO.FileNotFoundException: 找不到文件 ''。 
            p.WaitForExit();

            //把文件读进文件流 
            //FileStream fs = new FileStream(@"D:\" + fileNameWithOutExtention + ".pdf", FileMode.Open);
            FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("/Temp\\" + fileNameWithOutExtention + ".pdf"), FileMode.Open);
            byte[] file = new byte[fs.Length];
            fs.Read(file, 0, file.Length);
            fs.Close();
            File.Delete(System.Web.HttpContext.Current.Server.MapPath("/Temp\\" + fileNameWithOutExtention + ".pdf"));

            //Response给客户端下载 
            Response.Clear();
            Response.AddHeader("Content-Type", "application/pdf");
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("项目费用申请表.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
    }
    protected void btnCancelSign_Click(object sender, EventArgs e) //20141202：CancelSign
    {
        try
        {
            DataSet dsg = new DataSet(); //20150105：M_DeleteC
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
            dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
            {
                RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
            {
                RunJS("alert('该表已审批完毕，不能再撤回审核了');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

            int i = 0;
            int.TryParse(hdCancelSign.Value, out i);
            T_OfficeAutomation_Flow flows;
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, i);

            string namesA = flows.OfficeAutomation_Flow_Auditor, idsA = flows.OfficeAutomation_Flow_AuditorID;
            string[] employnames;
            string email;
            string msnBody;
            string signEmployeeName = EmployeeName;
            DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ProjCost_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjCost_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ProjCost_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
            if (flows != null)
            {
                //通知申请人
                msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已被" + signEmployeeName + "撤销审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                email = apply;
                Common.SendMessageEX(false, email, "您的申请已被" + signEmployeeName + "撤销审理", msnBody, msnBody);

                //通知已审批的人员
                ds = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAfterIdx(MainID, i);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                    employnames = employname.Split(',');
                    for (int i2 = 0; i2 < employnames.Length; i2++)
                    {
                        msnBody = "您好，" + employnames[i2] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已被" + signEmployeeName + "撤销审理，待会需要您重审。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        email = employnames[i2];if(email != "")
                        Common.SendMessageEX(false, email, "申请已被" + signEmployeeName + "撤销审理", msnBody, msnBody);
                    }
                }

                ds = da_OfficeAutomation_Flow_Inherit.SelectByMainIDDesc(MainID);
                if (ds.Tables[0].Rows[0]["OfficeAutomation_Flow_IsAgree"].ToString() != "0")
                {
                    if (idsA.IndexOf(',') != -1)
                    {
                        if (idsA.IndexOf(EmployeeID + ',') != -1)
                        {
                            idsA = idsA.Replace((EmployeeID + ','), string.Empty);
                            namesA = namesA.Replace((EmployeeName + ','), string.Empty);
                        }
                        else
                        {
                            idsA = idsA.Replace((',' + EmployeeID), string.Empty);
                            namesA = namesA.Replace((',' + EmployeeName), string.Empty);
                        }
                        da_OfficeAutomation_Flow_Inherit.UpdateByMainIDAndIdxs(MainID, i, namesA, idsA);
                        da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, i);
                    }
                    else
                        da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                }
                else
                {
                    da_OfficeAutomation_Flow_Inherit.InsertDeleteFlows(MainID);
                    if (idsA.IndexOf(',') != -1)
                    {
                        if (idsA.IndexOf(EmployeeID + ',') != -1)
                        {
                            idsA = idsA.Replace((EmployeeID + ','), string.Empty);
                            namesA = namesA.Replace((EmployeeName + ','), string.Empty);
                        }
                        else
                        {
                            idsA = idsA.Replace((',' + EmployeeID), string.Empty);
                            namesA = namesA.Replace((',' + EmployeeName), string.Empty);
                        }
                        da_OfficeAutomation_Flow_Inherit.UpdateByMainIDAndIdxs(MainID, i, namesA, idsA);
                        da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, i);
                    }
                    else
                        da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                    da_OfficeAutomation_Flow_Inherit.DDeleteFlows(MainID);
                }
                da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
                Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 3); //添加日志，撤销签名
                RunJS("alert('撤销审理成功！');window.location='" + Page.Request.Url + "'");
            }
            else
                RunJS("alert('该审批表或流程已被删除！');window.location='" + Page.Request.Url + "'");
        }
        catch (Exception ex)
        {
            Alert("撤销失败！" + ex.Message);
        }
    }
    protected void btnSAlterC_Click(object sender, EventArgs e) //20141216：M_AlterC
    {
        try
        {
            DataSet dsg = new DataSet(); //20150105：M_DeleteC
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
            dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
            {
                RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
            {
                RunJS("alert('该表已审批完毕，不能再修改了');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

            string[] employnames;
            string email;
            string msnBody;
            DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ProjCost_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjCost_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ProjCost_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
            //通知已审批的全部人员
            ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(MainID);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    msnBody = "您好，" + employnames[i2] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已被" + EmployeeName + "修改了部分内容，待会需要您重审。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                    email = employnames[i2];if(email != "")
                    Common.SendMessageEX(false, email, "该份申请已经申请人修改，请重新审批！谢谢", msnBody, msnBody);
                }
            }

            #region 修改编辑
            if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
            {
                Update();
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
                da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);//AlterC_a
                Common.SendDirectPushMessage(documentName, da_OfficeAutomation_Flow_Inherit.GetFirstByMainID(MainID)); //手机推送
                RunJS("alert('所作的修改已保存！');window.location='" + Page.Request.Url + "'");
            }
            else
                Alert("未开通编辑修改权限。");
            #endregion
        }
        catch (Exception ex)
        {
            Alert("保存失败，错误原因：" + ex.Message);
        }
    }
    protected void btnEditFlow_DoClick(object sender, EventArgs e)
    {
        try
        {
            DataSet dsg = new DataSet(); //20150105：M_DeleteC
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
            dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
            {
                RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
                return;
            }
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

            string[] employnames;
            string email;
            string msnBody;
            DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ProjCost_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjCost_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ProjCost_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
            //通知已审批的全部人员
            ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(MainID);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    msnBody = "您好，" + employnames[i2] + "：您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "已被" + EmployeeName + "修改了审批流程。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                    email = employnames[i2];if(email != "")
                    Common.SendMessageEX(false, email, "申请表已被" + EmployeeName + "修改了审批流程", msnBody, msnBody);
                }
            }
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 1); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_ProjCost_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }

    protected void Review(int index, string sug) //M_AddAnother：20150716 黄生其它意见，增加审批人
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        T_OfficeAutomation_Flow flowsa, flowsb, flowsh, fst4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1); //M_AlAno：20160217 ++
        flowsa = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, index);
        if (flowsa == null)
        {
            if (!fst4.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) || !fst4.OfficeAutomation_Flow_Employee.Contains(EmployeeName))
            { //M_AlAno：20160217 ++
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID + "," + fst4.OfficeAutomation_Flow_EmployeeID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName + "," + fst4.OfficeAutomation_Flow_Employee;
            }
            else
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName;
            }
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
            //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = index;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }
        string sisa = "2";

        if (rdb220a1.Checked) //M_AlterM：20150820
            sisa = "1";
        else if (rdb220a2.Checked)
            sisa = "0";

        if (index != 220)
        {
            flowsh = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 220);
            if (flowsh == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 220;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
            da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
        }

        flowsb = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, index);
        string se = null; //M_RA：20151120
        if (index == 220 && flowsb.OfficeAutomation_Flow_AuditDate.ToString() != "1900/1/1 0:00:00" && string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_AuditorID))
        {

            if (!flowsb.OfficeAutomation_Flow_Suggestion.Contains("---------------------------------------------------------------------"))
            {
                se = flowsb.OfficeAutomation_Flow_Suggestion
                    + "\r\n\r\n" + "　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）\r\n"
                    + "　　　　　　　　　　　　　　　　　　　　　　日期：" + flowsb.OfficeAutomation_Flow_AuditDate + "\r\n\r\n"
                    + "---------------------------------------------------------------------" + "\r\n\r\n"
                    + sug
                    + "\r\n\r\n" + "　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）\r\n"
                    + "　　　　　　　　　　　　　　　　　　　　　　日期：" + DateTime.Now.ToString() + "\r\n\r\n"
                    + "---------------------------------------------------------------------" + "\r\n\r\n";
            }
            else
            {
                se = flowsb.OfficeAutomation_Flow_Suggestion
                    + "\r\n"
                    + sug
                    + "\r\n\r\n" + "　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）\r\n"
                    + "　　　　　　　　　　　　　　　　　　　　　　日期：" + DateTime.Now.ToString() + "\r\n\r\n"
                    + "---------------------------------------------------------------------" + "\r\n\r\n";
            }
            if(!se.Contains("1900-01-01 0:00:00")) sug = se;
        }
        if (flowsb != null
    && flowsb.OfficeAutomation_Flow_Employee.Contains(fst4.OfficeAutomation_Flow_Employee) && flowsb.OfficeAutomation_Flow_EmployeeID.Contains(fst4.OfficeAutomation_Flow_EmployeeID)
    && fst4.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && fst4.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID)
    && flowsb.OfficeAutomation_Flow_EmployeeID != flowsb.OfficeAutomation_Flow_AuditorID)
            sug = !string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_Suggestion) ? flowsb.OfficeAutomation_Flow_Suggestion + "\r\n\r\n" + sug : sug; //M_AlAno：20160217 ++
        
        if (flowsb.OfficeAutomation_Flow_AuditDate.ToString() != "1900/1/1 0:00:00" && !string.IsNullOrEmpty(flowsb.OfficeAutomation_Flow_AuditorID) && flowsb.OfficeAutomation_Flow_EmployeeID == flowsb.OfficeAutomation_Flow_AuditorID) //M_AlAno：20160217 --u++m //M_RA：20151120
            da_OfficeAutomation_Flow_Inherit.UpdateFlowsSuggestionA(MainID, index.ToString(), sug, sisa); //M_AlterM：20150820
        else
            da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, EmployeeID, EmployeeName + "（复审）", sug, index.ToString(), sisa);
        if (sisa == "0")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 5); //添加日志，复审
        else if (sisa == "1")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 4); //添加日志，复审
        else
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 6); //添加日志，复审
        RunJS("alert('复审意见已保存！');window.location='" + Page.Request.Url + "'");
    }

    protected void btnSignIDx200_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        string[] employnames;
        string email;
        string msnBody;
        DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_ProjCost_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();
        DataSet ds = da_OfficeAutomation_Document_ProjCost_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjCost_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ProjCost_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
        //通知已审批的全部人员
        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainIDBeforeIdx(MainID, 200);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
            employnames = employname.Split(',');
            for (int i2 = 0; i2 < employnames.Length; i2++)
            {
                msnBody = "您好，" + employnames[i2] + EmployeeName + "已回复了您审理过的" + department + "，编号为" + serialNumber + "的" + documentName + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                email = employnames[i2]; if (email != "")
                    Common.SendMessageEX(false, email, EmployeeName + "发表了复审意见", msnBody, msnBody);
            }
        }

        Review(200, txtIDx200.Value);
    }
    protected void btnSignIDx220_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_ProjCost_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_ProjCost_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_ProjCost_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

        string employname = CommonConst.EMP_GMO_NAME;
        string[] employnames = employname.Split(',');
        string email, msnBody;
        for (int i = 0; i < employnames.Length; i++)
        {
            email = employnames[i];
            msnBody = "您好" + employnames[i] + "黄生已复审了" + department + "，编号为" + serialNumber + "的" + documentName + "。<br />黄生的意见：" + txtIDx220.Value + "<br/>申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
            Common.SendMessageEX(false, email, "请注意，总经理发表了复审意见", msnBody, msnBody);
        }

        Review(220, txtIDx220.Value);
    }
}