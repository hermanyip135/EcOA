using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;

using DataAccess.Operate;
using DataEntity;

using ICSharpCode.SharpZipLib.Zip;
using System.Drawing;

using System.Diagnostics; //M_PDF

public partial class Apply_AssetTransfer_Apply_AssetTransfer_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    //public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#divUploadBadDebts\").show();";
    public static string SerialNumber = "";
    public string ddlselect = "";
    public StringBuilder sbHtml = new StringBuilder();
    public StringBuilder sbJS = new StringBuilder();
    public StringBuilder sbFlow = new StringBuilder();
    public StringBuilder sbJSON = new StringBuilder();//部门组别
    public StringBuilder sbATJSON = new StringBuilder();//资产类型
    public string ApplyN;

    public string SpAttachPath = ""; //M_AssetAlter：20150827

    public StringBuilder SbDepartmentJson = new StringBuilder();

    #endregion

    #region 页面加载及初始化

    #region 页面加载事件

    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        sbJSON.Append("[]");
        sbATJSON.Append("[]");
        string UrlMainID = GetQueryString("MainID");
        //SerialNumber = "";
        //ID = "";

        if (!IsPostBack)
        {
            ViewState["UpDetail"] = "0";
            ViewState["AssetWrong"] = "";
            try
            {
                if (Request.QueryString["htmltopdf"] == "Yes")  //M_PDF
                {
                    sbJS.Append("<script type=\"text/javascript\">$(\"div .flow\").hide();$(\"#PageBottom\").hide();</script>");
                    tpdf = true;
                }
            }
            catch
            { }
            try
            {
                if (Session["FLG_ReWrite1"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite1"] = null;
                }
            }
            catch
            {
            }
            if (UrlMainID != "")
            {
                MainID = UrlMainID;
                this.txtDepartment.ReadOnly = true;
                this.txtExportDepartment.ReadOnly = true;
                LoadPage();
                if (txtExportDepartment.Text.ToString().Contains("仓库"))
                {
                    this.txtExportDepartment.ReadOnly = false;
                }
             
            }
            else
                InitPage();

        }
        else
        {
            GetAssetType();
            GetAssetPlace();
            GetAllDepartment();
        }
    }

    #endregion

    #region 初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        GetAssetType();
        GetAssetPlace();
        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        this.txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        this.txtExportContacts.Text = EmployeeName;
        this.txtImportContacts.Text = EmployeeName;
        this.btnSave.Visible = true;
        this.btnLook.Visible = false;
        if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
            sbJS.Append("<script type=\"text/javascript\">$(\"#btnSelect\").show();$(\"#SuSpUl\").show();$(\"#btndeleterow2\").show();"); //M_AssetAlter：20150827
        else
        {
            sbJS.Append("<script type=\"text/javascript\">$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");

            DrawDetailTable(0);
        }

        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
        this.btnLook.Visible = false;

        sbJS.Append("</script>");
    }

    #endregion

    #region 加载页面

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        GetAssetPlace();
        string flowState = "";
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
        this.FlowStateID.Value = flowState;
        sbJS.Append("<script type=\"text/javascript\">$(\"#btnUpload\").show();");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            sbJS.Append("$(\"#btnPrint\").show();");
        if (flowState == "7")
        {
            this.btnSave.Visible = true;
            this.btnLook.Visible = false;
        }
        else {
            this.btnSelect.Visible = false;
        }

        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_AssetTransfer_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_AssetTransfer_Apply"].ToString();
        ApplyN = applicant;
        this.txtDepartment.Text = dr["OfficeAutomation_Document_AssetTransfer_Department"].ToString();
        this.txtExportDepartment.Text = dr["OfficeAutomation_Document_AssetTransfer_ExportDepartment"].ToString();
        this.txtImportDepartment.Text = dr["OfficeAutomation_Document_AssetTransfer_ImportDepartment"].ToString();
        this.txtExportContacts.Text = dr["OfficeAutomation_Document_AssetTransfer_ExportContacts"].ToString();
        this.txtImportContacts.Text = dr["OfficeAutomation_Document_AssetTransfer_ImportContacts"].ToString();
        this.txtExportPlace.Text = dr["OfficeAutomation_Document_AssetTransfer_ExportPlace"].ToString();
        this.txtImportPlace.Text = dr["OfficeAutomation_Document_AssetTransfer_ImportPlace"].ToString();
        this.txtApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_AssetTransfer_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        //if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
            
        this.txtTransferReason.Text = dr["OfficeAutomation_Document_AssetTransfer_TransferReason"].ToString();
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        //sbJS.Append("$(\"#btnUpload\").show();");
        bool IsApplicant = EmployeeName == dr["OfficeAutomation_Document_AssetTransfer_Apply"].ToString();
        if (IsApplicant)
        {
            //sbJS.Append("$(\"#btnUpload\").show();");
            if (flowState == "1")
            {
                GetAllDepartment();
                if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                    sbJS.Append("$(\"#btnSelect\").show();$(\"#SuSpUl\").show();$(\"#btndeleterow2\").show();"); //M_AssetAlter：20150827
                else
                    sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
                this.btnSave.Visible = true;
            }
            //if (flowState == "2") //20141215：M_AlterC
            //{
            //    GetAllDepartment();
            //    btnSAlterC.Visible = true;
            //    sbJS.Append("$(\"#btnSelect\").show();");
            //}
        }
        if (EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
        {
            GetAllDepartment();
            if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                sbJS.Append("$(\"#btnSelect\").show();$(\"#SuSpUl\").show();"); //M_AssetAlter：20150827
            else
                sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
            this.btnSave.Visible = true;
        }

        #endregion

        #region 登录人为行政部经办人或财务部经办人，且流程为完成状态时，标识留档按钮开启。

        if (flowState == "1" && EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
        {
            if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                sbJS.Append("$(\"#btnSelect\").show();$(\"#SuSpUl\").show();$(\"#btndeleterow2\").show();"); //M_AssetAlter：20150827
            else
                sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
        }
        if (flowState == "3")
        {
            if (EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)//登录人为行政部经办人，且流程为完成状态时，标识留档按钮开启。
                sbJS.Append("$(\"#btnSignSave\").show();");
            if (EmployeeName == CommonConst.EMP_FINANCE_OPERATOR_NAME)//登录人为财务部经办人，且流程为完成状态时，标识留档按钮开启。
                sbJS.Append("$(\"#btnSignSaveForFinance\").show();");
        }

        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit(); //M_AssetAlter：20150827
        DataSet dsa = new DataSet();
        dsa = da_OfficeAutomation_Attach_Inherit.GetAttachSp(MainID);
        if (dsa.Tables[0].Rows.Count > 0)
        {
            sbJS.Append("$(\"#lkSpUl\").show();$(\"#btnSelect\").hide();$(\"#btndeleterow2\").hide();");
        }

        #endregion

        ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByID(ID);
        if (ds.Tables[0].Rows.Count > 5 && flowState == "3")
        {
            this.btnAssetToPDF.Visible = true;
        }

        int detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable(0);
        else
        {
            if (detailCount > 5)
                detailCount = 0;
            DrawDetailTable(detailCount);//*9

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];

                int i = n + 1;

                if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                    sbJS.Append("$('#txtAsset" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ToString() + "');");
                ddlselect += "$('#ddlAsset" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID"].ToString() + "');";
                sbJS.Append("$('#txtATag" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString() + "');");
                sbJS.Append("$('#txtNumber" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_Number"].ToString() + "');");
                sbJS.Append("$('#txtModel" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ToString() + "');");
                sbJS.Append("$('#hidAssetID" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString() + "');");
            }
        }

        if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
        {
            for (int n = 1; n <= detailCount; n++)
            {
                sbJS.Append("if($(\"#txtATag" + n + "\").val() != \"\")$(\"#txtATag" + n + "\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
            }
            if (EmployeeName != CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME || dsa.Tables[0].Rows.Count > 0) //M_AssetAlter：20150827
                sbJS.Append("$(\"[id*=txtAsset]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtNumber]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtModel]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
        }

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                if (DateTime.Now > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                    sbJS.Append("$(\"#btnSelect\").show();$(\"#btnAddRow\").hide();$(\"#btnDeleteRow\").hide();$(\"#tbDetail tr[id*=trDetail]\").remove();i = 0;$(\"#SuSpUl\").show();$(\"#btndeleterow2\").show();"); //M_AssetAlter：20150827
                else
                    sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
                //if (DateTime.Parse(txtApplyDate.Text) <= DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                //    sbJS.Append("$(\"#tbDetail tr[id*=trDetail]\").remove();i = 0;");
                sbJS.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();$(\"#lkSpUl\").hide();");
                sbJS.Append("</script>");
                GetAssetType();
                GetAllDepartment();
                IsNewApply = true;
                btnSPDF.Visible = false; //M_PDF
                this.txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.txtExportContacts.Text = EmployeeName;
                this.txtImportContacts.Text = EmployeeName;
                this.btnSave.Visible = true;
                MainID = Guid.NewGuid().ToString();
                flowState = "1";
                btnSAlterC.Visible = false;
                return;
            }
        }
        catch
        {
            if (IsApplicant)
                btnReWrite.Visible = true; 
        }

        #region 加载自定义流程，隐藏及显示签名按钮，及签名
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        sbJS.Append(saynostr);
        #endregion

        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        bool flag3 = false;//是否有it环节
        sbFlow.Append("<div class=\"flow\">");
        sbFlow.Append("审批流程:");
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            if (curidx == "9")
                flag3 = true;

            sbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                sbFlow.Append("auditing\">待" + curemp + "审理");

                flag2 = false;

                if (curemp.Contains(EmployeeName))
                {
                    switch (curidx)
                    {
                        case "1":
                            this.cbkToIT.Visible = true;

                            DataSet dsFlow = new DataSet();
                            dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                            foreach (DataRow drFlow in dsFlow.Tables[0].Rows)
                            {
                                if (drFlow["OfficeAutomation_Flow_Idx"].ToString() == "9" || drFlow["OfficeAutomation_Flow_Idx"].ToString() == "10")
                                {
                                    this.cbkToIT.Checked = true;
                                    break;
                                }
                            }
                            break;
                        case "13":
                            sbJS.Append("$(\"#btnSaveAndEnd\").show();$(\"#btnPrint\").show();");
                            break;
                        case "12":
                            if (EmployeeID == "13545") //M_AddNWX：20150511
                                lbtnAddN.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                    sbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Auditor"].ToString() + "已完成审理");
                else
                    sbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Employee"].ToString());
            }
            sbFlow.Append("</span>");

            //箭头图片
            if (i != (drc.Count - 1))//如果不是最后一项
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                    sbFlow.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
                else
                    sbFlow.Append("<img src=\"/Images/forward_skip.png\" class=\"forward\"/>");
            }
            #endregion

            #region 显示签名人姓名，签名图片，或签名按钮
            string[] auditorIDs = drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Split(',');
            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            {
                if (curidx == "2" || curidx == "3" || curidx == "4" || curidx == "5" || curidx == "6" || curidx == "7")
                {
                    sbJS.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 150px; line-height: 20px; height: 20px; margin:0 auto;\">"
                        + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            sbJS.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        sbJS.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"50px\" />");
                    }
                    sbJS.Append("<br />');");
                }
                else
                {
                    sbJS.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 150px; line-height: 65px; height: 0px; margin-left:0px; *float:left;\">"
                        + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            sbJS.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        sbJS.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"50px\" />");
                    }
                    sbJS.Append("');");
                }

                //如果是否同意为0则不同意按钮选中，为2则其他意见按钮选中，为真或空，则同意按钮选中。
                if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                    sbJS.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                    sbJS.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                else
                    sbJS.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");

                if (string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    sbJS.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').hide();");
                else
                    sbJS.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString() + "');");

                sbJS.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
            }
            else
            {
                if (auditorIDs.Length > 0 && auditorIDs[0] != "")
                {
                    sbJS.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 150px; line-height: 20px; height: 20px; margin-left:0px; \">"
                                       + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            sbJS.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        sbJS.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"50px\" />");
                    }
                    sbJS.Append("');");

                    //如果是否同意为1，则同意按钮选中，为0则不同意按钮选中，为2则其他意见按钮选中。
                    if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "1")
                        sbJS.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                        sbJS.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                        sbJS.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                    
                    sbJS.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString() + "');");
                    sbJS.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
                }

                if (!string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    sbJS.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                if (flag && da_OfficeAutomation_Agent_Inherit.IsHaveSignPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(),
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID))
                    sbJS.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').show();");

                flag = false;
            }
            #endregion
        }

        if (!flag3)
            sbJS.Append("$('#trIT1').hide();$('#trIT2').hide();$('#trIT3').hide();$('#trIT4').hide();");

        //流程为未审核状态，且登录人为申请人或行政部经办人。
        if (flowState == "1" && (applicant == EmployeeName || EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME))
            sbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && /*applicant == EmployeeName ||*/ EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME && !tpdf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;
        sbFlow.Append("</div>");

        ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID); //20141231：M_DeleteC
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlowsByMID(MainID);
            sbJS.Append("$('#btnADelete').before('<div id=\"SummaryOfDelete_Red\" style=\"color: red; font-size: large; font-weight: bold\">（该表即将被删除）</div>');$('h1').css('color','red');");
            string[] employnames;
            string employname;
            foreach (DataRow dr2 in ds.Tables[0].Rows)
            {
                employname = dr2["OfficeAutomation_DeletedFlow_AuditorID"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    if (employnames[i2] == EmployeeID)
                        sbJS.Append("$('#btnADelete').show();$('#SummaryOfDelete_Red').hide();");
                }
            }
            #region 显示删除流程示意图
            sbFlow.Length = 0;//清空审批流程
            FlowCommonMethod flowCom = new FlowCommonMethod();
            sbFlow.Append(flowCom.ShowDelFlow(MainID));
            btnEditFlow2.Visible = false;
            #endregion
        }
        else //20150225：M_DeleteC 不同意时显示最后确认时间
        {
            DA_OfficeAutomation_Document_LastSure_Inherit da_OfficeAutomation_Document_LastSure_Inherit = new DA_OfficeAutomation_Document_LastSure_Inherit();
            ds = da_OfficeAutomation_Document_LastSure_Inherit.SelectByMid(MainID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                sbJS.Append("$('#snum').prepend('<span id=\"SummaryOfDelete_Green\" style=\"color: green; float:left; font-weight: bold\">区域最后确认时间：" + ds.Tables[0].Rows[0]["OfficeAutomation_Document_LastSure_Time"].ToString() + "</span>');");
            }
        }

        #endregion

        sbJS.Append("$.each($(\"textarea:not([id*=txtDescribe])\"), function (idx, item) { autoTextarea(this); });");
        sbJS.Append("</script>");

        LoadAttach();
    }

    #endregion

    #region 加载附件列表

    /// <summary>
    /// 加载附件列表
    /// </summary>
    private void LoadAttach()
    {
        //获取该单附件列表
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DataSet dsAttach = new DataSet(); 
        //dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);

        dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachBesidessSp(MainID); //M_AssetAlter：20150827
        DataSet spa = new DataSet();
        spa = da_OfficeAutomation_Attach_Inherit.GetAttachSp(MainID);
        try
        {
            SpAttachPath = spa.Tables[0].Rows[0]["OfficeAutomation_Attach_Path"].ToString();
        }
        catch
        {
        }

        gvAttach.DataSource = dsAttach;
        gvAttach.DataBind();

        //如果该单有附件，则下载按钮显示
        this.btnDownload.Visible = (dsAttach != null && dsAttach.Tables[0] != null && dsAttach.Tables[0].Rows.Count > 0);
    }

    #endregion

    #region 绘制详情表格内容

    /// <summary>
    /// 绘制详情表格内容
    /// </summary>
    /// <param name="n">行数</param>
    public void DrawDetailTable(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            sbHtml.Append("<tr id='trDetail" + i + "' class=\"noborder\">");
            sbHtml.Append("     <td class=\"tl PL10\" style=\"width:200px\"><input type='hidden' id='hidAssetID" + i + "' />");
            if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                sbHtml.Append("            *资产名称  <input type=\"text\" id=\"txtAsset" + i + "\" style=\"width:120px;\"/><select id=\"ddlAsset" + i + "\" style=\"width:120px;display:none;\" onchange=\"checkasset(this," + i + ");\"></select><br />");
            else
                sbHtml.Append("            *资产名称  <select id=\"ddlAsset" + i + "\" style=\"width:120px;\" onchange=\"checkasset(this," + i + ");\"></select><br />");
            sbHtml.Append("            *数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;量 <input type=\"text\" id=\"txtNumber" + i + "\" style=\"width:120px;\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\" onblur=\"checknum(this," + i + ");\"/><br />");
            sbHtml.Append("    </td>");
            sbHtml.Append("     <td class=\"tl PL10\">");
            sbHtml.Append("            *财务编号 <input type=\"text\" id=\"txtATag" + i + "\" style=\"width:200px;\"/><br />");
            sbHtml.Append("            *规格型号 <input type=\"text\" id=\"txtModel" + i + "\" style=\"width:200px;\"/><br />");
            sbHtml.Append("    </td>");
            sbHtml.Append("</tr>");
        }
        sbJS.Append("i=" + n + ";");
    }

    #endregion

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
        T_OfficeAutomation_Document_AssetTransfer t_OfficeAutomation_Document_AssetTransfer = new T_OfficeAutomation_Document_AssetTransfer();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
       


        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1") 
            {
                //MainID = "";
                IsNewApply = true;
            }
        }
        catch
        {
        }

        try
        {
            if (IsNewApply)
            {
               Alert("操作有误。");
               return;

                #region 新建
                IsNewApply = false;
                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "AssetTransfer" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 5;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_Apply = EmployeeName;
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportDepartment = this.txtExportDepartment.Text;
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ImportDepartment = this.txtImportDepartment.Text;
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportContacts = this.txtExportContacts.Text;
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ImportContacts = this.txtImportContacts.Text;
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportPlace = this.txtExportPlace.Text;
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ImportPlace = this.txtImportPlace.Text;
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);
                t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_TransferReason = this.txtTransferReason.Text;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = "";

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_AssetTransfer_Inherit.Insert(t_OfficeAutomation_Document_AssetTransfer);//插入报废申请表

                bool haveITAsset = da_OfficeAutomation_Document_AssetTransfer_Inherit.IsITAsset(t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ID.ToString(), "1"); 
                //是否有APOS
                bool IsAPOS = da_OfficeAutomation_Document_AssetTransfer_Inherit.IsAPOS(t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ID.ToString());
                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                #region 根据默认流程表中的固定环节添加流程
                ds = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString());
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
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
                    //如果有APOS资产名称则添加宁伟雄审核
                    if (IsAPOS)
                    {
                       
                            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 12);
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545,5585";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超,宁伟雄";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 12;
                            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                       

                    }
                    if (haveITAsset)//是否有IT类资产，如果有则添加2步IT流程：第9步IT部维护组主管意见，第10步IT部负责人意见
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1236";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "梁锐华";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3808";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何智峰";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }

                    if (t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportDepartment.Contains("仓库"))//如果调出部门包含“仓库”二字，则添加第12步流程
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_ADMINISTRATION_OPERATOR_ID;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 13;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 8, new Guid(MainID), 1);//日志，创建资产调动表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程
                if (ViewState["AssetWrong"].ToString() == "")
                    RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_AssetTransfer_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                else
                    RunJS("alert(\"" + ViewState["AssetWrong"].ToString() + "\");window.location='/Apply/Apply_Search.aspx';");
                #endregion
            }
            else
            {


                DataSet dsAssetTransfer = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    var MainObj = da_OfficeAutomation_Main_Inherit.GetModel("[OfficeAutomation_Main_ID]='" + MainID + "'");
                    //是否暂存
                    bool tempsave = MainObj.OfficeAutomation_Main_FlowStateID == 7;
            
                    var assetTransfer=da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
                    DataSet dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByID(assetTransfer.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ID"].ToString());
                    if (dsDetail.Tables[0].Rows.Count < 1) {
                        Alert("请选择或填写所要调动的资产！");
                        return;
                    }
                    if (tempsave)
                    {
                        //是,更新主表状态
                        MainObj.OfficeAutomation_Main_FlowStateID = 1;
                        da_OfficeAutomation_Main_Inherit.Edit(MainObj);
                    }

                    Update();

                    if (tempsave)
                    {
                        #region 保存默认流程
                        DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = MainObj.OfficeAutomation_Main_ID;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                        #region 根据默认流程表中的固定环节添加流程
                        DataSet ds = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(MainObj.OfficeAutomation_Main_ID.ToString());
                        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
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
                            /*
                            bool haveITAsset = da_OfficeAutomation_Document_AssetTransfer_Inherit.IsITAsset(ID, "1"); ;
                            if (haveITAsset)//是否有IT类资产，如果有则添加2步IT流程：第9步IT部维护组主管意见，第10步IT部负责人意见
                            {
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1236";
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "梁锐华";
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;

                                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3808";
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何智峰";
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                            }*/

                            if (dsAssetTransfer.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ExportDepartment"].ToString().Contains("仓库"))//如果调出部门包含“仓库”二字，则添加第12步流程
                            {
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_ADMINISTRATION_OPERATOR_ID;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 13;

                                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                            }
                        }
                        #endregion
                        RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_AssetTransfer_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                        #endregion
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
            txtExportDepartment.Text = "";
            RunJS("alert(\"" + "保存失败！" + ex.Message.Replace("\r", "\\r").Replace("\n", "\\n") + "\");history.go(-1);");
            //Alert("保存失败！" + ex.Message.Replace("\r", "\\r").Replace("\n", "\\n"));
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
            System.Web.UI.WebControls.CheckBox chk = item.FindControl("chk") as System.Web.UI.WebControls.CheckBox;
            if (chk.Checked)
            {
                HiddenField hf = item.FindControl("hfPath") as HiddenField;
                files.Add(hf.Value);
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
        DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ID"].ToString(); 

        string flowIDx = "0";
        string signEmployeeName = EmployeeName;
        string signEmployeeID = EmployeeID;
        string idx6name = null, idx7name = null;

        if (Purview.Contains("OA_ITPower_002"))
        {
            //try
            //{
                if (!CheckGIFIsExist(EmployeeID))
                {
                    RunJS("alert('"+CommonConst.MSG_NO_SIGNIMAGE+"');window.location.href='" + Request.RawUrl + "';");
                    return;
                }

                DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                DataRowCollection drc = ds.Tables[0].Rows;
                for (int i = 0; i < drc.Count; i++)
                {
                    if (drc[i]["OfficeAutomation_Flow_IDx"].ToString() == "6")
                        idx6name = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

                    if (drc[i]["OfficeAutomation_Flow_IDx"].ToString() == "7")
                        idx7name = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

                    if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flowIDx == "0")
                    {
                        DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                        //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                        string haveSignPowerEmployee = da_OfficeAutomation_Agent_Inherit.HaveSignPowerEmployee(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(), EmployeeName, EmployeeID);
                        if (haveSignPowerEmployee != null)
                        {
                            flowIDx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
                            signEmployeeName = haveSignPowerEmployee.Split('|')[0];
                            signEmployeeID = haveSignPowerEmployee.Split('|')[1];
                        }
                    }
                }

                if (flowIDx == "1")
                {
                    Update();

                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                    if (cbkToIT.Checked)//转IT审核是否勾选，如果是且流程中无9、10步则添加2步IT流程：第9步IT部维护组主管意见，第10步IT部负责人意见
                    {
                        bool flagHaveIT = false;
                        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["OfficeAutomation_Flow_Idx"].ToString() == "9" || dr["OfficeAutomation_Flow_Idx"].ToString() == "10")
                            {
                                flagHaveIT = true;
                                break;
                            }
                        }

                        if (!flagHaveIT)
                        {
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1236";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "梁锐华";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;

                            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3808";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何智峰";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                        }
                    }
                }
                if (flowIDx == "13")
                {
                    Update();
                }

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                if (da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeID, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value))
                {
                    string[] employnames;
                    string email = "";
                    string messageBody;

                    ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_Apply"].ToString();
                    string employname;
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);

                    if (hdIsAgree.Value != "0")//同意或其他意见
                    {
                        if (idx6name != null && idx7name != null && idx6name == idx7name && flowIDx == "6")
                            da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeID, signEmployeeName, hdSuggestion.Value, "7", hdIsAgree.Value);

                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名同意

                        //判断审批流程是否完成,通知相应人员
                        if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(MainID))
                        {
                            string sended = "";
                            //通知申请人
                            messageBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。申请表地址为：" + Page.Request.Url.ToString();
                            email = apply;
                            sended += email;
                            if (hdIsAgree.Value == "2")
                                Common.SendMessageEX(false, email, "其他意见", messageBody, messageBody);
                            else
                                Common.SendMessageEX(false, email, "申请已同意", messageBody, messageBody);

                            //通知已审批的人员，邮件中附带报废申请的申请资料。
                            DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                            DA_Dic_OfficeAutomation_AssetType_Operate da_Dic_OfficeAutomation_AssetType_Operate = new DA_Dic_OfficeAutomation_AssetType_Operate();
                            DataRow drAssetTransfer = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID).Tables[0].Rows[0];
                            DataSet dsDetail = new DataSet();
                            dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);
                            string msnBody = "";
                            string mailBody = "<br/><br/>申请人：" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_Apply"].ToString()
                                + "<br/>申请日期：" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ApplyDate"].ToString()
                                + "<br/>调出部门或分行名称：" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ExportDepartment"].ToString()
                                + "<br/>调出联系人：" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ExportContacts"].ToString()
                                + "<br/>调出摆放地点：" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ExportPlace"].ToString()
                                + "<br/>接收部门或分行名称：" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ImportDepartment"].ToString()
                                + "<br/>接收联系人：" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ImportContacts"].ToString()
                                + "<br/>接收摆放地点：" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ImportPlace"].ToString()
                                + "<br/>调动原因：" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_TransferReason"].ToString()
                                + "<br/><br/>调动详细情况：";
                            foreach (DataRow dr in dsDetail.Tables[0].Rows)
                            {
                                if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                                    mailBody += "<br/>&nbsp;&nbsp;资产名称：" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ToString();
                                else
                                    mailBody += "<br/>&nbsp;&nbsp;资产名称：" + da_Dic_OfficeAutomation_AssetType_Operate.SelectByID(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID"].ToString());
                                mailBody += "&nbsp;&nbsp;财务编号：" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString() + "<br/>&nbsp;&nbsp;数量：" + dr["OfficeAutomation_Document_AssetTransfer_Detail_Number"].ToString() + "&nbsp;&nbsp;规格型号：" + dr["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ToString();
                                mailBody += "<br/>";

                                wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                                if (hdIsAgree.Value == "1")
                                {
                                    try{
                                        bool result = ws.AssetAdjustmentPass(dr["OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID"].ToString());
                                        LogCommonFunction.AddLog("访问接口：AssetAdjustmentPass 字段：OfficeAutomation_Document_AssetTransfer_Detail_AssetAID=" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString()+"|结果："+(result?"成功":"失败"), "资产调动");
                                    }catch(Exception ex){
                                        LogCommonFunction.AddLog("访问接口：AssetAdjustmentPass 字段：OfficeAutomation_Document_AssetTransfer_Detail_AssetAID=" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString()+"|结果：失败——"+ex.Message, "资产调动");
                                    }
                                }
                                
                            }
                         
                            ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(MainID);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                string idx = dr["OfficeAutomation_Flow_Idx"].ToString();
                                if (idx != "2" && idx != "3" && idx != "4" && idx != "5" && idx != "6" && idx != "7")
                                //if (idx == "8")
                                {
                                    employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                                    employnames = employname.Split(',');
                                    for (int i = 0; i < employnames.Length; i++)
                                    {
                                        if (employnames[i] != CommonConst.EMP_LOGISTICS_MANAGER_NAME && employnames[i] != "")
                                        {
                                            msnBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。申请表地址为：" + Page.Request.Url.ToString();
                                            email = employnames[i];
                                            if (!sended.Contains(email))
                                            {
                                                sended += "|" + email;
                                                if (hdIsAgree.Value == "2")
                                                    Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                                else
                                                    Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);
                                            }
                                        }
                                    }
                                }

                                if (idx == "9")
                                {
                                    msnBody = "您好，" + CommonConst.EMP_IT_OPERATOR_NAME + "：编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。申请表地址为：" + Page.Request.Url.ToString();
                                    email = CommonConst.EMP_IT_OPERATOR_NAME;
                                    if (!sended.Contains(email))
                                    {
                                        sended += "|" + email;
                                        if (hdIsAgree.Value == "2")
                                            Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                        else
                                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);
                                    }
                                }
                            }

                            msnBody = "您好，" + CommonConst.EMP_FINANCE_OPERATOR_NAME + "：编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。申请表地址为：" + Page.Request.Url.ToString();
                            email = CommonConst.EMP_FINANCE_OPERATOR_NAME;
                            if (!sended.Contains(email))
                            {
                                sended += "|" + email;
                                if (hdIsAgree.Value == "2")
                                    Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                else
                                    Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);
                            }

                            msnBody = "您好，" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ExportContacts"].ToString() + "：编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。申请表地址为：" + Page.Request.Url.ToString();
                            email = drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ExportContacts"].ToString();
                            if (!sended.Contains(email))
                            {
                                sended += "|" + email;
                                if (hdIsAgree.Value == "2")
                                    Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                else
                                    Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);
                            }

                            msnBody = "您好，" + drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ImportContacts"].ToString() + "：编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。申请表地址为：" + Page.Request.Url.ToString();
                            email = drAssetTransfer["OfficeAutomation_Document_AssetTransfer_ImportContacts"].ToString();
                            if (!sended.Contains(email))
                            {
                                if (hdIsAgree.Value == "2")
                                    Common.SendMessageEX(false, email, "其他意见", messageBody, messageBody);
                                else
                                    Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);
                            }
                        }
                        else
                        {
                            //通知申请人
                            messageBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。申请表地址为：" + Page.Request.Url.ToString();
                            email = apply;
                            Common.SendMessageEX(false, email, "申请已通过" + EmployeeName + "的审理", messageBody, messageBody);

                            //通知下一步需要审批的人员
                            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);

                            if (employname == CommonConst.EMP_FINANCE_OPERATOR_NAME)//如果下一步为财务部经办人，则自动审核通过
                            {
                                T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_FINANCE_OPERATOR_NAME;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_FINANCE_OPERATOR_ID;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Audit = true;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_AuditDate = DateTime.Now;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Auditor = CommonConst.EMP_FINANCE_OPERATOR_NAME;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_AuditorID = CommonConst.EMP_FINANCE_OPERATOR_ID;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_IsAgree = 1;

                                da_OfficeAutomation_Flow_Inherit.UpdateByMainIDAndIdx(t_OfficeAutomation_Flow);

                                employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
                            }

                            if (!employname.Contains(EmployeeName))
                            {
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    messageBody = "您好，" + employnames[i] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审理。申请表地址为：" + Page.Request.Url.ToString();
                                    Common.SendMessageEX(true, documentName, email, "请审理", messageBody, messageBody,MainID);
                                }
                            }
                        }

                        RunJS("alert('审批成功！');window.location='" + Page.Request.Url.ToString() + "'");
                    }
                    else //不同意
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 5);//添加日志，签名不同意

                        //通知申请人
                        messageBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。申请表地址为：" + Page.Request.Url.ToString();
                        email = apply;
                        Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", messageBody, messageBody);

                        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                        DataSet dsDetail = new DataSet();
                        dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);
                        foreach (DataRow dr in dsDetail.Tables[0].Rows)
                        {
                            wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                            ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID"].ToString());
                        }

                        //通知已审批的人员
                        ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(MainID);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                messageBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。申请表地址为：" + Page.Request.Url.ToString();
                                email = employnames[i];
                                Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", messageBody, messageBody);
                            }
                        }

                        //if (EmployeeID == "0001") //抄送到总办
                        //{
                        //    string sagree = "";
                        //    if (hdSuggestion.Value != "")
                        //        sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                        //    employname = CommonConst.EMP_GMO_NAME;
                        //    employnames = employname.Split(',');
                        //    for (int i = 0; i < employnames.Length; i++)
                        //    {
                        //        msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        //        email = employnames[i];
                        //        Common.SendMessageEX(false, email, "申请不同意", msnBody + mailBody, msnBody);
                        //    }
                        //} //总办

                        RunJS("alert('审理成功！');window.location='" + Page.Request.Url.ToString() + "'");
                    }
                }
            //}
            //catch
            //{
            //    Alert("审理失败！");
            //}
        }
        else
        {
            Alert("未开通审核权限！");
        }
    }

    #endregion

    #region 返回按钮点击事件
    protected void btnBack_Click(object sender, EventArgs e)
    {
          
        string sUrl = "/Apply/Apply_Search.aspx?" + Request.QueryString.ToString();
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
        string commType = e.CommandName.ToString();
        switch (commType)
        {
            case "Del":
                Alert("删除附件" + (da_OfficeAutomation_Attach_Inherit.Delete(e.CommandArgument.ToString()) ? "成功!" : "失败!"));
                Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(MainID), 3);
                break;
            default:
                break;
        }

        LoadPage();
    }

    #endregion

    #endregion

    #region 保存、修改内容功能

    #region 更新修改内容

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_AssetTransfer t_OfficeAutomation_Document_AssetTransfer = new T_OfficeAutomation_Document_AssetTransfer();
        DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ID"].ToString();

        var Mainbll = new DA_OfficeAutomation_Main_Inherit();
        var mainobj = Mainbll.GetModel("OfficeAutomation_Main_ID='" + MainID+ "'");

        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ID = new Guid(ID);
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_Department = this.txtDepartment.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportDepartment = this.txtExportDepartment.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ImportDepartment = this.txtImportDepartment.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportContacts = this.txtExportContacts.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ImportContacts = this.txtImportContacts.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportPlace = this.txtExportPlace.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ImportPlace = this.txtImportPlace.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_TransferReason = this.txtTransferReason.Text;

        string apply = "";
        string depname = this.txtDepartment.Text;
        string summary = "";
        string applydate = this.txtApplyDate.Text;
        string mainid = MainID;

        Mainbll.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_AssetTransfer_Inherit.Update(t_OfficeAutomation_Document_AssetTransfer);//修改

        //DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        //da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(ID);
        bool haveITAsset = da_OfficeAutomation_Document_AssetTransfer_Inherit.IsITAsset(ID, "1");
        //是否有APOS
        bool IsAPOS = da_OfficeAutomation_Document_AssetTransfer_Inherit.IsAPOS(t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ID.ToString());
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        if (IsAPOS)
        {

            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 12);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545,5585";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超,宁伟雄";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 12;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);


        }
        if (haveITAsset)//是否有IT类资产，如果有则添加2步IT流程：第9步IT部维护组主管意见，第10步IT部负责人意见
        {
            T_OfficeAutomation_Flow flows;
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 9);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1236";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "梁锐华";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3808";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何智峰";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
        }
        //else
        else if (!string.IsNullOrEmpty(hdIsIT.Value)) //M_Warning：发布新功能时需更换 20150601
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,10");
        if (t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportDepartment.Contains("仓库"))//如果调出部门包含“仓库”二字，则添加第12步流程
        {
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 13);

            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_ADMINISTRATION_OPERATOR_ID;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 13;

            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }
        else
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 13);

        Common.AddLog(EmployeeID, EmployeeName, 8, new Guid(MainID), 2);//日志，修改资产调动表
    }

    #endregion

    #region  新增明细,返回是否有IT类资产
    /*
    /// <summary>
    /// 新增明细,返回是否有IT类资产
    /// </summary>
    /// <param name="gAssetTransferID"></param>
    private bool InsertAssetTransferDetail(Guid gAssetTransferID, string SerialNumber)
    {
        bool haveITAsset = false;
        if (hdDetail.Value == "")
            return false;

        T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail;
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        DA_Dic_OfficeAutomation_AssetType_Operate da_Dic_OfficeAutomation_AssetType_Operate = new DA_Dic_OfficeAutomation_AssetType_Operate();

        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
        if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
        {
            try
            {
                DataSet dsDetail = new DataSet();
                dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);

                if (dsDetail.Tables[0].Rows.Count > 0 && ViewState["UpDetail"].ToString() == "0") //M_AssetAlter：20150827
                {
                    ViewState["Dteail"] = dsDetail;
                    ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ColumnName = "资产名称";
                    ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ColumnName = "财务编号";
                    ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ColumnName = "规格型号";
                }

                foreach (DataRow dr in dsDetail.Tables[0].Rows)
                {
                    //if (!string.IsNullOrEmpty(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString()))
                    //{
                    //    ws.AdjustmentUpdate(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString(), dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                    //}
                    //ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                    wsAsset.GetAssetDic ws2 = new wsAsset.GetAssetDic();
                    ws2.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString()); //M_AssetAlter：20150827
                }
            }
            catch
            {
            }
        }

        //try //M_Alter：20150826 删除详情表前先释放在审中的资产
        //{
        //    DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit2 = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        //    DataSet dsDetail2 = new DataSet();
        //    dsDetail2 = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit2.SelectByMainID(MainID);
        //    foreach (DataRow dr in dsDetail2.Tables[0].Rows)
        //    {
        //        wsAsset.GetAssetDic ws2 = new wsAsset.GetAssetDic();
        //        ws2.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
        //    }
        //}
        //catch
        //{
        //}


        da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(gAssetTransferID.ToString());//*-

        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit(); //M_AssetAlter：20150827
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DataSet dsa = new DataSet();
        dsa = da_OfficeAutomation_Attach_Inherit.GetAttachSp(MainID);
        if (dsa.Tables[0].Rows.Count > 0 && hdIsIT.Value == "")
        {
            int i = 0;
            try
            {
                DataSet dsADetail = (DataSet)ViewState["Dteail"];
                foreach (DataRow drd in dsADetail.Tables[0].Rows)
                {
                    i++;
                    t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = gAssetTransferID;
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = drd["资产名称"].ToString().Trim(); ;
                    //t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;
                    string acceptdept = drd["接收部门"].ToString().Trim();
                    string s = GetAssetPlaceByName(acceptdept), t;
                    try
                    {
                        s = s.Substring(s.IndexOf(":") + 1, s.IndexOf(",") - s.IndexOf(":") - 1);
                    }
                    catch
                    {
                        s = "0";
                    }

                    if (string.IsNullOrEmpty(acceptdept))
                    {
                        continue;
                    }
                    string assetNo=drd["财务编号"].ToString();
                    //t = ws.Adjustment(drd["财务编号"].ToString(), int.Parse(s), 1, txtImportDepartment.Text, txtApplyDate.Text, 1); //锁定资产
                    // t = ws.Adjustment(assetNo, int.Parse(s), 1, acceptdept, txtApplyDate.Text, 1); //锁定资产
                   // t = ws.NewAdjustment(drd["二维码"].ToString().Trim(), int.Parse(s), 1, acceptdept, txtApplyDate.Text, 1, SerialNumber); //锁定资产
                    t = ws.AdjustmentWithEcoaCode(assetNo, int.Parse(s), 1, acceptdept, txtApplyDate.Text, 1, SerialNumber); //锁定资产
                    try
                    {
                        LogCommonFunction.AddLog(assetNo + int.Parse(s).ToString() + 1 + acceptdept + txtApplyDate.Text + 1 + " 文档编号" + SerialNumber + "返回值：" + t, "锁定资产");  
                    }
                    catch (Exception)
                    {
                        
                    
                    }
                  
                    if (t.Contains("*"))
                        ViewState["AssetWrong"] = t.Replace("*", string.Empty);
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = t;

                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = drd["财务编号"].ToString().Trim();
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = "1";
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = drd["规格型号"].ToString().Trim();

                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = "";
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = "";
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = "";

                    hdIsIT.Value = "0";
                    dsa = da_OfficeAutomation_Main_Inherit.FindAssetsByAssetNo(drd["财务编号"].ToString().Trim());
                    try
                    {
                        if (dsa.Tables[0].Rows[0]["cv"].ToString().Contains("1")) //是否有IT类资产
                        {
                            hdIsIT.Value = "1";
                            haveITAsset = true;
                        }
                    }
                    catch
                    {
                    }

                    if (ViewState["AssetWrong"].ToString() == "")
                        da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Insert(t_OfficeAutomation_Document_AssetTransfer_Detail);
                    else
                    {
                        txtExportDepartment.Text = "";
                        try //M_Alter：20150826 删除详情表前先释放在审中的资产
                        {
                            DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3 = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                            DataSet dsDetail3 = new DataSet();
                            dsDetail3 = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3.SelectByMainID(MainID);
                            foreach (DataRow dr in dsDetail3.Tables[0].Rows)
                            {
                                wsAsset.GetAssetDic ws3 = new wsAsset.GetAssetDic();
                                ws3.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                            }
                        }
                        catch
                        {
                        }
                        da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(gAssetTransferID.ToString());
                        da_OfficeAutomation_Attach_Inherit.DeleteAttachSp(MainID);
                        RunJS("alert(\"" + ViewState["AssetWrong"].ToString() + "，财务编号为：" + drd["财务编号"].ToString().Trim() + "，请改正后再上传，保存后需编辑前线的审批人员，以免审批流有误。\");$(\"#tbDetail tr[id*=trDetail]\").remove();history.go(-1);");
                    }
                }
            }
            catch
            {
                DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                T_OfficeAutomation_Flow flows;
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 9);
                if (flows != null)
                {
                    hdIsIT.Value = "1";
                    haveITAsset = true;
                }
            }
        }
        else
        {

            string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = gAssetTransferID;
                if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                {
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = detail[0];
                    //t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;

                    string s = GetAssetPlaceByName(txtImportPlace.Text), t;
                    try
                    {
                        s = s.Substring(s.IndexOf(":") + 1, s.IndexOf(",") - s.IndexOf(":") - 1);
                    }
                    catch
                    {
                        s = "0";
                    }
                   // t = ws.NewAdjustment(detail[4], int.Parse(s), 1, txtImportDepartment.Text, txtApplyDate.Text, 1, SerialNumber);
                    t = ws.AdjustmentWithEcoaCode(detail[1], int.Parse(s), 1, txtImportDepartment.Text, txtApplyDate.Text, 1, SerialNumber);
                    try
                    {
                        LogCommonFunction.AddLog(detail[1] + int.Parse(s).ToString() + 1 + txtImportDepartment.Text + txtApplyDate.Text + 1 + " 文档编号" + SerialNumber, "锁定资产");  
                    }
                    catch (Exception)
                    {
                        
                        
                    }
                 
                    if (t.Contains("*"))
                        ViewState["AssetWrong"] = t.Replace("*", string.Empty);
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = t;
                    if (hdIsIT.Value == "1") //是否有IT类资产
                        haveITAsset = true;
                }
                else
                {
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = detail[4];
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = "";
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = int.Parse(detail[0]);
                    if (da_Dic_OfficeAutomation_AssetType_Operate.IsITAssetType(detail[0])) //是否有IT类资产
                        haveITAsset = true;
                }
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = detail[1];
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = detail[2];
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = detail[3];

                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = "";
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = "";
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = "";

                if (ViewState["AssetWrong"].ToString() == "")
                    da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Insert(t_OfficeAutomation_Document_AssetTransfer_Detail);
                else
                {
                    txtExportDepartment.Text = "";
                    try //M_Alter：20150826 删除详情表前先释放在审中的资产
                    {
                        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3 = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                        DataSet dsDetail3 = new DataSet();
                        dsDetail3 = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3.SelectByMainID(MainID);
                        foreach (DataRow dr in dsDetail3.Tables[0].Rows)
                        {
                            wsAsset.GetAssetDic ws3 = new wsAsset.GetAssetDic();
                            ws3.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                        }
                    }
                    catch
                    {
                    }
                    da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(gAssetTransferID.ToString());
                    RunJS("alert(\"" + ViewState["AssetWrong"].ToString() + "，财务编号为：" + detail[1].ToString() + "\");history.go(-1);");
                }
            }
        }

        return haveITAsset;
    }
    */
    #endregion

    #endregion

    #region 其他

    #region 获取资产类型

    /// <summary>
    /// 获取资产类型
    /// </summary>
    private void GetAssetType()
    {
        sbATJSON.Remove(0, sbATJSON.Length);
        DA_Dic_OfficeAutomation_AssetType_Operate da_Dic_OfficeAutomation_AssetType_Operate = new DA_Dic_OfficeAutomation_AssetType_Operate();
        DataSet dsAT = da_Dic_OfficeAutomation_AssetType_Operate.SelectAll();
        sbATJSON.Append("[");
        foreach (DataRow dr in dsAT.Tables[0].Rows)
        {
            sbATJSON.Append("{\"id\":\"" + dr["OfficeAutomation_AssetType_ID"].ToString() + "\",\"value\":\"" + dr["OfficeAutomation_AssetType_Name"].ToString() + "\"},");
        }
        sbATJSON.Remove(sbATJSON.Length - 1, 1);
        sbATJSON.Append("]");
    }

    #endregion

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        sbJSON.Remove(0, sbJSON.Length);
        wsKDHR.Service service = new wsKDHR.Service();
        DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
        sbJSON.Append("[");

        //简单去除分行下面的组别，变分行，简单过滤重复。
        string name;
        foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        {
            name = dr["name"].ToString();
            Match m = Regex.Match(name, "[A-Z]{1}组");
            if (m.Success)//去除组别
                name = name.Substring(0, m.Index);

            m = Regex.Match(name, "(\\(|（)+\\w+(\\)|）)+");
            if (m.Success)//去除括号
                name = name.Substring(0, m.Index);

            m = Regex.Match(name, "[A-D]$");
            if (m.Success)//去除名称尾部的ABCD
                name = name.Substring(0, m.Index);

            if (!sbJSON.ToString().Contains(name))
                sbJSON.Append("{\"value\":\"" + name + "\"},");
        }

        sbJSON.Remove(sbJSON.Length - 1, 1);
        sbJSON.Append("]");
    }
    #endregion

    public void GetAssetPlace()
    {
        try
        {
            wsAsset.GetAssetDic service = new wsAsset.GetAssetDic();
            string s = service.GetKeyValue("place", "").Replace("Dic_Assets_Id", "id").Replace("Dic_Assets_Text", "value");
            if(string.IsNullOrEmpty(s))
                s = "[]";
            SbDepartmentJson.Append(s);
        }
        catch
        {
            SbDepartmentJson.Append("[]");
        }
    }

    private string GetAssetPlaceByName(string nam)
    {
        try
        {
            wsAsset.GetAssetDic service = new wsAsset.GetAssetDic();
            string s = service.GetKeyValue("place", nam).Replace("Dic_Assets_Id", "id").Replace("Dic_Assets_Text", "value");
            return s;
        }
        catch
        {
            return "";
        }
    }

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite1"] = "1";
        Response.Write("<script>window.open('Apply_AssetTransfer_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("资产调动表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
            DataSet ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_AssetTransfer_Department"].ToString();
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
                if (i == 1)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,10");
                if (i <= 12 && EmployeeID == "13545") //M_AddNWX：20150511
                {
                    da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "黄志超", "13545");
                    da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                }



                DataSet dsDetail = new DataSet();
                wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);
                foreach (DataRow dr in dsDetail.Tables[0].Rows)
                {
                    ws.RegainAdjustment(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                }
                
                

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
            DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
            DataSet ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_AssetTransfer_Department"].ToString();
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
                if (ViewState["AssetWrong"].ToString() == "")
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,10");
                    da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);
                    t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                    t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                    da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);//AlterC_a
                    Common.SendDirectPushMessage(documentName, da_OfficeAutomation_Flow_Inherit.GetFirstByMainID(MainID)); //手机推送
                    RunJS("alert('所作的修改已保存！');window.location='" + Page.Request.Url + "'");
                }
                else
                {
                    txtExportDepartment.Text = "";
                    RunJS("alert(\"" + ViewState["AssetWrong"].ToString() + "\");history.go(-1);");
                }
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
            DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
            DataSet ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_AssetTransfer_Department"].ToString();
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
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,10");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 7); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_AssetTransfer_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=320px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }

    protected void lbtnAddN_Click(object sender, EventArgs e) //M_AddNWX：20150511
    {
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "宁伟雄,黄志超", "5585,13545");

        //string applyUrl = Page.Request.Url.ToString();
        //applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        //applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
        //string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        //string messageBody = "您好，宁伟雄：黄志超转了一份" + documentName + "给您的审理。申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
        //Common.SendMessageEX(true, documentName, "宁伟雄", "黄志超转了一份" + documentName + "给您的审理", messageBody, messageBody);
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1); //添加日志，添加流程
        RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    }


    protected void btnSelect_Click(object sender, EventArgs e)
    {
        
        T_OfficeAutomation_Document_AssetTransfer t_OfficeAutomation_Document_AssetTransfer = new T_OfficeAutomation_Document_AssetTransfer();
       
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
        SerialNumber = "AssetTransfer" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        var DocumentID = 5;

         
        var Creater = EmployeeName;
     
      
        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName, txtDepartment.Text);
        SerialNumber = t_OfficeAutomation_Main.OfficeAutomation_SerialNumber;
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }


        //判断是否多次点击保存按钮
        DataSet ds = new DataSet();
        
 
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_Department = this.txtDepartment.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_Apply = EmployeeName;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportDepartment = this.txtExportDepartment.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ImportDepartment = this.txtImportDepartment.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportContacts = this.txtExportContacts.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ImportContacts = this.txtImportContacts.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ExportPlace = this.txtExportPlace.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ImportPlace = this.txtImportPlace.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_TransferReason = this.txtTransferReason.Text;
        t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ApplyID = EmployeeID;
        ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
        bool result = false;
        if (ds.Tables[0].Rows.Count == 0)
        {

            t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ID = Guid.NewGuid();
            result = da_OfficeAutomation_Document_AssetTransfer_Inherit.Insert(t_OfficeAutomation_Document_AssetTransfer);
        }
        else
        {
            t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ID = new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ID"].ToString());
         
            result = da_OfficeAutomation_Document_AssetTransfer_Inherit.Update(t_OfficeAutomation_Document_AssetTransfer);
        }






        if (result)
        {
        //    RunJS("window.showModalDialog(\"/Apply/AssetTransfer/New/AssetTransfer_Apply_Asset.aspx?mainID=" + MainID + "\",\"\",\"dialogHeight=\"+screen.height+\"px;dialogWidth=\"+screen.width+\"px;\")");
            string sUrl;
            if (Request.QueryString.ToString() == "")
            {
                sUrl = "/Apply/AssetTransfer/New/AssetTransfer_Apply_Asset.aspx?" + "mainID=" + MainID;
                Response.Redirect(sUrl);
                return;
            }

            sUrl = "/Apply/AssetTransfer/New/AssetTransfer_Apply_Asset.aspx?" + Request.QueryString;
            Response.Redirect(sUrl);
            
            //    RunJS("alert('保存成功！');window.location.href=\"/Apply/AssetTransfer/New/AssetTransfer_Apply_Asset.aspx?mainID=" + MainID + "\";");
            return;
        }
        else
        {
            //RunJS("alert('保存失败！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
    }
    protected void btnLook_Click(object sender, EventArgs e)
    {
        string sUrl;
        if (Request.QueryString.ToString() == "")
        {
            sUrl = "/Apply/AssetTransfer/New/AssetTransfer_Apply_Asset.aspx?" + "mainID=" + MainID;
            Response.Redirect(sUrl);
            return;
        }

        sUrl = "/Apply/AssetTransfer/New/AssetTransfer_Apply_Asset.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
    }

    #region  导出资产列表PDF

    protected void TOPDF(string serialNumber, System.Data.DataTable dt)
    {

        string fileNameWithOutExtention = Guid.NewGuid().ToString();
        string path = Server.MapPath("../../../Temp") + "//" + fileNameWithOutExtention + ".pdf";
        try
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 20, 20);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            PdfPageHelper pageHelper = new PdfPageHelper();
            writer.PageEvent = pageHelper;
            document.Open();
            iTextSharp.text.pdf.BaseFont bfChinese = iTextSharp.text.pdf.BaseFont.CreateFont("C://WINDOWS//Fonts//simsun.ttc,1", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontChinese = new iTextSharp.text.Font(bfChinese, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontChinesebig = new iTextSharp.text.Font(bfChinese, 12, iTextSharp.text.Font.BOLD);


            iTextSharp.text.Phrase myPhrase = new iTextSharp.text.Phrase("               文档编号：" + serialNumber, fontChinesebig);

            myPhrase.Add("\n");
            myPhrase.Add(new iTextSharp.text.Phrase("               一共调用" + (dt.Rows.Count-1) + "件资产", fontChinesebig));
            document.Add(myPhrase);
            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(dt.Columns.Count);
            //float[] f = new float[10] { 48, 48, 100, 48, 48, 48, 48, 88, 58, 68 };
            //table.SetTotalWidth(f);


            foreach (DataColumn dc in dt.Columns)
            { table.AddCell(new iTextSharp.text.Phrase(dc.ColumnName, fontChinesebig)); }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    table.AddCell(new iTextSharp.text.Phrase(dt.Rows[i][j].ToString(), fontChinese));
                }
            }
            document.Add(table);




            document.Close();
            writer.Close();
            downloadfile(path);

            File.Delete(path);
        }
        catch (iTextSharp.text.DocumentException de)
        {

            Response.Write(de.ToString());
        }
    }
    /// <summary>
    /// 指定要下载文件的虚拟路径及文件名
    /// </summary>
    /// <param name="FileName"></param>
    public void downloadfile(string FileName)
    {

        //打开要下载的文件 
        System.IO.FileStream r = new System.IO.FileStream(FileName, System.IO.FileMode.Open);
        //设置基本信息 
        Response.Buffer = false;
        Response.AddHeader("Connection", "Keep-Alive");
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + System.IO.Path.GetFileName(FileName));
        Response.AddHeader("Content-Length", r.Length.ToString());


        while (true)
        {
            //开辟缓冲区空间 
            byte[] buffer = new byte[1024];
            //读取文件的数据 
            int leng = r.Read(buffer, 0, 1024);
            if (leng == 0)//到文件尾，结束 
                break;
            if (leng == 1024)//读出的文件数据长度等于缓冲区长度，直接将缓冲区数据写入 
                Response.BinaryWrite(buffer);
            else
            {
                //读出文件数据比缓冲区小，重新定义缓冲区大小，只用于读取文件的最后一个数据块 
                byte[] b = new byte[leng];
                for (int i = 0; i < leng; i++)
                    b[i] = buffer[i];
                Response.BinaryWrite(b);
            }
        }
        r.Close();//关闭下载文件 
        Response.End();//结束文件下载 
    }

    protected void btnAssetToPDF_Click(object sender, EventArgs e)
    {

        DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();




        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        string id = dr["OfficeAutomation_Document_AssetTransfer_ID"].ToString();
        string serialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByID(id);

        System.Data.DataTable myDataTable = new System.Data.DataTable("Excel");
        DataColumn myDataColumn;
        DataRow myDataRow;

        myDataColumn = new DataColumn("序号");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("调出部门");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("调出地点");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("接收部门");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("接收地点");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("资产名称");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("财务编号");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("规格型号");
        myDataTable.Columns.Add(myDataColumn);
       
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            myDataRow = myDataTable.NewRow();
            myDataRow["序号"] = i + 1;
            myDataRow["调出部门"] = ds.Tables[0].Rows[i]["OfficeAutomation_Document_AssetTransfer_Detail_DpmExp"].ToString();
            myDataRow["调出地点"] = ds.Tables[0].Rows[i]["OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp"].ToString();

            myDataRow["接收部门"] = ds.Tables[0].Rows[i]["OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"].ToString();
            myDataRow["接收地点"] = ds.Tables[0].Rows[i]["OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec"].ToString();

            myDataRow["资产名称"] = ds.Tables[0].Rows[i]["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ToString();
            myDataRow["财务编号"] = ds.Tables[0].Rows[i]["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString();
            myDataRow["规格型号"] = ds.Tables[0].Rows[i]["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ToString();
           
        
            myDataTable.Rows.Add(myDataRow);
        }
        TOPDF(serialNumber, myDataTable);
    }
    #endregion
}