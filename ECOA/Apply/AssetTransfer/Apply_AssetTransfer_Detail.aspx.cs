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
        SerialNumber = "";
        ID = "";

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
                LoadPage();
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
        //if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
            sbJS.Append("<script type=\"text/javascript\">$(\"#btnSelect\").show();$(\"#SuSpUl\").show();"); //M_AssetAlter：20150827
        //else
        //{
        //    sbJS.Append("<script type=\"text/javascript\">$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");

        //    DrawDetailTable(1);
        //}

        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();

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
        da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.DeleteTemp(MainID); //M_NewTable：20151202 删除临时记录
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

        sbJS.Append("<script type=\"text/javascript\">$(\"#btnUpload\").show();");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            sbJS.Append("$(\"#btnPrint\").show();");
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
                //if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                    sbJS.Append("$(\"#btnSelect\").show();$(\"#DetailAsset\").show();$(\"#DetailAsset\").css(\"margin-top\",\"30px\");"); //M_NewTable：20151202 //M_AssetAlter：20150827
                //else
                //    sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
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
            //if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                sbJS.Append("$(\"#btnSelect\").show();$(\"#DetailAsset\").show();$(\"#DetailAsset\").css(\"margin-top\",\"30px\");"); //M_NewTable：20151202 //M_AssetAlter：20150827
            //else
            //    sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
            this.btnSave.Visible = true;
        }

        #endregion

        #region 登录人为行政部经办人或财务部经办人，且流程为完成状态时，标识留档按钮开启。

        if (flowState == "1" && EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
        {
            //if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                sbJS.Append("$(\"#btnSelect\").show();$(\"#DetailAsset\").show();$(\"#DetailAsset\").css(\"margin-top\",\"30px\");"); //M_NewTable：20151202 //M_AssetAlter：20150827
            //else
            //    sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
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
            sbJS.Append("$(\"#lkSpUl\").show();$(\"#btnSelect\").hide();");
        }

        #endregion

        ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByID(ID);
        int detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable(0);
        else if (detailCount <= 5 || Request.QueryString["htmltopdf"] == "Yes")
        {
            if (dsa.Tables[0].Rows.Count > 0)
                detailCount = 0;
            DrawDetailTable(detailCount);//*9

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];

                int i = n + 1;

                sbJS.Append("$('#txtAssetTag" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString() + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                sbJS.Append("$('#txtModel" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ToString() + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                sbJS.Append("$('#txtDpmExp" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmExp"].ToString() + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                sbJS.Append("$('#txtAssetName" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ToString() + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                sbJS.Append("$('#txtDpmRec" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"].ToString() + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                sbJS.Append("$('#txtPlaceRec" + i + "').val('" + dr["OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec"].ToString() + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
            }
            if (EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME || EmployeeName == CommonConst.EMP_FINANCE_OPERATOR_NAME) //M_NewTable：20151202
                sbJS.Append("$(\"#DetailAsset\").show();");
        }
        else
            sbJS.Append("$(\"#DetailAsset\").show();");

        //if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
        //{
            //for (int n = 1; n <= detailCount; n++)
            //{
            //    sbJS.Append("if($(\"#txtATag" + n + "\").val() != \"\")$(\"#txtATag" + n + "\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
            //}
            if (EmployeeName != CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME || dsa.Tables[0].Rows.Count > 0) //M_AssetAlter：20150827
                sbJS.Append("$(\"[id*=txtAsset]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtNumber]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtModel]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
        //}

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                //if (DateTime.Now > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                    sbJS.Append("$(\"#btnSelect\").show();$(\"#btnAddRow\").hide();$(\"#btnDeleteRow\").hide();$(\"#tbDetail tr[id*=trDetail]\").remove();i = 0;$(\"#SuSpUl\").show();"); //M_AssetAlter：20150827
                //else
                //    sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
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
            sbHtml.Append("     <td class=\"tl PL10\">");
            sbHtml.Append("            调出部门：<input type=\"text\" id=\"txtDpmExp" + i + "\" style=\"width:160px;\"/><br />");
            sbHtml.Append("            接收地点：<input type=\"text\" id=\"txtPlaceRec" + i + "\" style=\"width:160px;\"/><br />");
            sbHtml.Append("            财务编号：<input type=\"text\" id=\"txtAssetTag" + i + "\" style=\"width:160px;\"/><br />");
            sbHtml.Append("    </td>");
            sbHtml.Append("     <td class=\"tl PL10\">");
            sbHtml.Append("            接收部门：<input type=\"text\" id=\"txtDpmRec" + i + "\" style=\"width:160px;\"/><br />");
            sbHtml.Append("            资产名称：<input type=\"text\" id=\"txtAssetName" + i + "\" style=\"width:160px;\"/><br />");
            sbHtml.Append("            规格型号：<input type=\"text\" id=\"txtModel" + i + "\" style=\"width:160px;\"/><br />");
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
                #region 新建
                IsNewApply = false;
                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "AssetTransfer" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
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

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_AssetTransfer_Inherit.Insert(t_OfficeAutomation_Document_AssetTransfer);//插入报废申请表

                bool haveITAsset = InsertAssetTransferDetail(t_OfficeAutomation_Document_AssetTransfer.OfficeAutomation_Document_AssetTransfer_ID, t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);

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
                    RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_AssetTransfer_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=400px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                else
                    RunJS("alert(\"" + ViewState["AssetWrong"].ToString() + "\");window.location='/Apply/Apply_Search.aspx';");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    Update();
                    RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
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
                                //if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                                    mailBody += "<br/>&nbsp;&nbsp;资产名称：" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ToString();
                                //else
                                //    mailBody += "<br/>&nbsp;&nbsp;资产名称：" + da_Dic_OfficeAutomation_AssetType_Operate.SelectByID(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID"].ToString());
                                mailBody += "&nbsp;&nbsp;财务编号：" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString() + "<br/>&nbsp;&nbsp;归属：" + dr["OfficeAutomation_Document_AssetTransfer_Detail_Number"].ToString() + "&nbsp;&nbsp;规格型号：" + dr["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ToString();
                                mailBody += "<br/>";

                                wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                                if (hdIsAgree.Value == "1")
                                {
                                   bool reuslt = ws.AssetAdjustmentPass(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                                    try
                                    {
                                        LogCommonFunction.AddLog(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString(), reuslt.ToString());
                                    }
                                    catch (Exception)
                                    {
                                        
                                      
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
                            ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
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

        var MainBLL = new DA_OfficeAutomation_Main_Inherit();
        var MainObj = MainBLL.GetModel("OfficeAutomation_Main_ID='" + MainID + "'");

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ID"].ToString();

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

        MainBLL.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_AssetTransfer_Inherit.Update(t_OfficeAutomation_Document_AssetTransfer);//修改

        //DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        //da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(ID);
        bool haveITAsset = InsertAssetTransferDetail(new Guid(ID), MainObj.OfficeAutomation_SerialNumber);

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
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

    /// <summary>
    /// 新增明细,返回是否有IT类资产
    /// </summary>
    /// <param name="gAssetTransferID"></param>
    private bool InsertAssetTransferDetail(Guid gAssetTransferID, string SerialNumber) //M_NewTable：20151202
    {
        bool haveITAsset = false;
        T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DataSet ds = new DataSet();
        DataSet dsa = new DataSet();
        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();

        ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            AtInsertTemporary();
            ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByMainID(MainID);
        }
        //AtInsertTemporary();
        try //M_Alter：20150826 删除详情表前先释放在审中的资产
        {
            dsa = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);
            foreach (DataRow dr2 in dsa.Tables[0].Rows)
            {
                ws.AssetAdjustmentReject(dr2["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
            }
        }
        catch
        {
        }
        da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(gAssetTransferID.ToString());
        string s, v = "", t = "";
        
        hdIsIT.Value = "0";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = gAssetTransferID;
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = dr["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = dr["OfficeAutomation_Document_AssetTransfer_Detail_Number"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmExp"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = dr["OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec"].ToString();

            s = GetAssetPlaceByName(dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"].ToString().Trim());
            try
            {
                s = s.Substring(s.IndexOf(":") + 1, s.IndexOf(",") - s.IndexOf(":") - 1);//*-
            }
            catch
            {
                s = "0";
            }
            t = ws.NewAdjustment(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString().Trim(), int.Parse(s), 1, dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"].ToString().Trim(), txtApplyDate.Text, 1, SerialNumber); //锁定资产
            if (t.Contains("*"))
                ViewState["AssetWrong"] = t.Replace("*", string.Empty);
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = t;

            dsa = da_OfficeAutomation_Main_Inherit.FindAssetsByAssetNo(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString().Trim());
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
                //txtExportDepartment.Text = "";
                //try //M_Alter：20150826 删除详情表前先释放在审中的资产
                //{
                //    DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3 = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                //    DataSet dsDetail3 = new DataSet();
                //    dsDetail3 = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3.SelectByMainID(MainID);
                //    foreach (DataRow dr2 in dsDetail3.Tables[0].Rows)
                //    {
                //        ws.AssetAdjustmentReject(dr2["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                //    }
                //}
                //catch
                //{
                //}
                //da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(gAssetTransferID.ToString());
                v += ViewState["AssetWrong"].ToString() + " 财务编号为：" + dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString().Trim() + "\\r\\n";
            }
        }
        if (ViewState["AssetWrong"].ToString() != "")
            RunJS("alert(\"保存时有如下错误：\\r\\n\\r\\n" + v + "\\r\\n请修改后再保存，保存后需编辑前线的审批人员，以免审批流有误。\");$(\"#tbDetail tr[id*=trDetail]\").remove();history.go(-1);");
        else
            da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.DeleteTemp(MainID);
          
        return haveITAsset;
    }
    protected void AtInsertTemporary() //M_NewTable：20151202
    {
        T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = new Guid(MainID);
            //t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = dr["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = dr["OfficeAutomation_Document_AssetTransfer_Detail_Number"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmExp"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = dr["OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString();

            da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.InsertTemporary(t_OfficeAutomation_Document_AssetTransfer_Detail);
        }
    }
    //private bool InsertAssetTransferDetail(Guid gAssetTransferID) //M_S_NewTable：去除旧的功能，以资产表的形式显示 20151202
    //{
    //    bool haveITAsset = false;
    //    if (hdDetail.Value == "")
    //        return false;

    //    T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail;
    //    DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
    //    DA_Dic_OfficeAutomation_AssetType_Operate da_Dic_OfficeAutomation_AssetType_Operate = new DA_Dic_OfficeAutomation_AssetType_Operate();

    //    wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
    //    if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
    //    {
    //        try
    //        {
    //            DataSet dsDetail = new DataSet();
    //            dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);

    //            if (dsDetail.Tables[0].Rows.Count > 0 && ViewState["UpDetail"].ToString() == "0") //M_AssetAlter：20150827
    //            {
    //                ViewState["Dteail"] = dsDetail;
    //                ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ColumnName = "资产名称";
    //                ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ColumnName = "财务编号";
    //                ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ColumnName = "规格型号";
    //            }

    //            foreach (DataRow dr in dsDetail.Tables[0].Rows)
    //            {
    //                //if (!string.IsNullOrEmpty(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString()))
    //                //{
    //                //    ws.AdjustmentUpdate(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString(), dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
    //                //}
    //                //ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
    //                wsAsset.GetAssetDic ws2 = new wsAsset.GetAssetDic();
    //                ws2.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString()); //M_AssetAlter：20150827
    //            }
    //        }
    //        catch
    //        {
    //        }
    //    }

    //    //try //M_Alter：20150826 删除详情表前先释放在审中的资产
    //    //{
    //    //    DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit2 = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
    //    //    DataSet dsDetail2 = new DataSet();
    //    //    dsDetail2 = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit2.SelectByMainID(MainID);
    //    //    foreach (DataRow dr in dsDetail2.Tables[0].Rows)
    //    //    {
    //    //        wsAsset.GetAssetDic ws2 = new wsAsset.GetAssetDic();
    //    //        ws2.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
    //    //    }
    //    //}
    //    //catch
    //    //{
    //    //}


    //    da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(gAssetTransferID.ToString());

    //    DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit(); //M_AssetAlter：20150827
    //    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
    //    DataSet dsa = new DataSet();
    //    dsa = da_OfficeAutomation_Attach_Inherit.GetAttachSp(MainID);
    //    if (dsa.Tables[0].Rows.Count > 0 && hdIsIT.Value == "")
    //    {
    //        try
    //        {
    //            DataSet dsADetail = (DataSet)ViewState["Dteail"];
    //            foreach (DataRow drd in dsADetail.Tables[0].Rows)
    //            {
    //                t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = gAssetTransferID;
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = drd["资产名称"].ToString().Trim(); ;
    //                //t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;

    //                string s = GetAssetPlaceByName(drd["接收部门"].ToString().Trim()), t;
    //                try
    //                {
    //                    s = s.Substring(s.IndexOf(":") + 1, s.IndexOf(",") - s.IndexOf(":") - 1);
    //                }
    //                catch
    //                {
    //                    s = "0";
    //                }
    //                //t = ws.Adjustment(drd["财务编号"].ToString(), int.Parse(s), 1, txtImportDepartment.Text, txtApplyDate.Text, 1); //锁定资产
    //                t = ws.Adjustment(drd["财务编号"].ToString().Trim(), int.Parse(s), 1, drd["接收部门"].ToString().Trim(), txtApplyDate.Text, 1); //锁定资产
    //                if (t.Contains("*"))
    //                    ViewState["AssetWrong"] = t.Replace("*", string.Empty);
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = t;

    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = drd["财务编号"].ToString().Trim();
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = "1";
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = drd["规格型号"].ToString().Trim();

    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = "";
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = "";

    //                hdIsIT.Value = "0";
    //                dsa = da_OfficeAutomation_Main_Inherit.FindAssetsByAssetNo(drd["财务编号"].ToString().Trim());
    //                try
    //                {
    //                    if (dsa.Tables[0].Rows[0]["cv"].ToString().Contains("1")) //是否有IT类资产
    //                    {
    //                        hdIsIT.Value = "1";
    //                        haveITAsset = true;
    //                    }
    //                }
    //                catch
    //                {
    //                }

    //                if (ViewState["AssetWrong"].ToString() == "")
    //                    da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Insert(t_OfficeAutomation_Document_AssetTransfer_Detail);
    //                else
    //                {
    //                    txtExportDepartment.Text = "";
    //                    try //M_Alter：20150826 删除详情表前先释放在审中的资产
    //                    {
    //                        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3 = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
    //                        DataSet dsDetail3 = new DataSet();
    //                        dsDetail3 = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3.SelectByMainID(MainID);
    //                        foreach (DataRow dr in dsDetail3.Tables[0].Rows)
    //                        {
    //                            wsAsset.GetAssetDic ws3 = new wsAsset.GetAssetDic();
    //                            ws3.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
    //                        }
    //                    }
    //                    catch
    //                    {
    //                    }
    //                    da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(gAssetTransferID.ToString());
    //                    da_OfficeAutomation_Attach_Inherit.DeleteAttachSp(MainID);
    //                    RunJS("alert(\"" + ViewState["AssetWrong"].ToString() + "，财务编号为：" + drd["财务编号"].ToString().Trim() + "，请改正后再上传，保存后需编辑前线的审批人员，以免审批流有误。\");$(\"#tbDetail tr[id*=trDetail]\").remove();history.go(-1);");
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
    //            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
    //            T_OfficeAutomation_Flow flows;
    //            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 9);
    //            if (flows != null)
    //            {
    //                hdIsIT.Value = "1";
    //                haveITAsset = true;
    //            }
    //        }
    //    }
    //    else
    //    {

    //        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
    //        for (int i = 0; i < details.Length; i++)
    //        {
    //            string[] detail = Regex.Split(details[i], "\\&\\&");
    //            t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
    //            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
    //            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = gAssetTransferID;
    //            if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
    //            {
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = detail[0];
    //                //t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;

    //                string s = GetAssetPlaceByName(txtImportPlace.Text), t;
    //                try
    //                {
    //                    s = s.Substring(s.IndexOf(":") + 1, s.IndexOf(",") - s.IndexOf(":") - 1);
    //                }
    //                catch
    //                {
    //                    s = "0";
    //                }
    //                t = ws.Adjustment(detail[1], int.Parse(s), 1, txtImportDepartment.Text, txtApplyDate.Text, 1);
    //                if (t.Contains("*"))
    //                    ViewState["AssetWrong"] = t.Replace("*", string.Empty);
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = t;
    //                if (hdIsIT.Value == "1") //是否有IT类资产
    //                    haveITAsset = true;
    //            }
    //            else
    //            {
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = "";
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = "";
    //                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = int.Parse(detail[0]);
    //                if (da_Dic_OfficeAutomation_AssetType_Operate.IsITAssetType(detail[0])) //是否有IT类资产
    //                    haveITAsset = true;
    //            }
    //            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = detail[1];
    //            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = detail[2];
    //            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = detail[3];

    //            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = "";
    //            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = "";

    //            if (ViewState["AssetWrong"].ToString() == "")
    //                da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Insert(t_OfficeAutomation_Document_AssetTransfer_Detail);
    //            else
    //            {
    //                txtExportDepartment.Text = "";
    //                try //M_Alter：20150826 删除详情表前先释放在审中的资产
    //                {
    //                    DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3 = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
    //                    DataSet dsDetail3 = new DataSet();
    //                    dsDetail3 = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit3.SelectByMainID(MainID);
    //                    foreach (DataRow dr in dsDetail3.Tables[0].Rows)
    //                    {
    //                        wsAsset.GetAssetDic ws3 = new wsAsset.GetAssetDic();
    //                        ws3.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
    //                    }
    //                }
    //                catch
    //                {
    //                }
    //                da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(gAssetTransferID.ToString());
    //                RunJS("alert(\"" + ViewState["AssetWrong"].ToString() + "，财务编号为：" + detail[1].ToString() + "\");history.go(-1);");
    //            }
    //        }
    //    }

    //    return haveITAsset;
    //}

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
            RunJS("var win=window.showModalDialog(\"Apply_AssetTransfer_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=400px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

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

    protected void btnUploadDetails_Click(object sender, EventArgs e) //M_AssetAlter：20150827
    {
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        DataSet spa = new DataSet();

        spa = da_OfficeAutomation_Attach_Inherit.GetAttachSp(MainID);
        try
        {
            SpAttachPath = spa.Tables[0].Rows[0]["OfficeAutomation_Attach_Path"].ToString();
        }
        catch
        {
        }
        sbJS.Append("<script type=\"text/javascript\">$(\"#btnSelect\").hide();$(\"#btnAddRow\").hide();$(\"#btnDeleteRow\").hide();$(\"#SuSpUl\").show();");
        sbJS.Append("$(\"#lkSpUl\").show();");

        string path = hdFilePath.Value;
        if (path != "")
        {
            System.Data.OleDb.OleDbConnection ImportConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source=" + path + "; " + "Extended Properties='Excel 12.0;HDR=1; IMEX=1;'");
            System.Data.OleDb.OleDbDataAdapter ImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [格式$]", ImportConnection);
            DataSet dsADetail = new DataSet();
            int i = 0;
            try
            {
                ImportCommand.Fill(dsADetail);
                ViewState["Dteail"] = dsADetail;
                ViewState["UpDetail"] = "1";
            }
            catch
            {
                //if (txtExportDepartment.Text == "总部仓库" || txtExportDepartment.Text == "芳村仓库")
                //    sbJS.Append("$(\"#btnSelect\").hide();$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#SuSpUl\").show();$(\"#lkSpUl\").hide();");
                //else
                //    sbJS.Append("$(\"#btnSelect\").show();$(\"#lkSpUl\").hide();");

                da_OfficeAutomation_Attach_Inherit.DeleteAttachSp(MainID);
                Alert("格式错误，请重新下载“EXCEL版空白明细表”填写后再导入");
                sbJS.Append("history.go(-1);");
                sbJS.Append("</script>");
                return;
            }

            if (dsADetail.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string str1, str2 = "", str3;
                    int success = 0;
                    for (i = 0; i <= dsADetail.Tables[0].Rows.Count - 1 && i < 5; i++)
                    {
                        str1 = dsADetail.Tables[0].Rows[i]["资产名称"].ToString();
                        str2 = dsADetail.Tables[0].Rows[i]["财务编号"].ToString();
                        str3 = dsADetail.Tables[0].Rows[i]["规格型号"].ToString();

                        //if (!string.IsNullOrEmpty(str2))
                        //{
                            success++;
                            sbJS.Append("$('#txtAsset" + success + "').val('" + str1 + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                            sbJS.Append("$('#txtATag" + success + "').val('" + str2 + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                            sbJS.Append("$('#txtModel" + success + "').val('" + str3 + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                            sbJS.Append("$('#txtNumber" + success + "').val('1').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                            sbJS.Append("$('#ddlAsset" + success + "').val('0');");
                        //}
                    }

                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Main_Inherit.SelectAssets(txtExportDepartment.Text, str2, "", "", "");
                    try
                    {
                        //M_Warning：20150828 资产系统删除详见附件等选项时必须修改
                        txtExportPlace.Text = ds.Tables[0].Rows[3]["txtPlace"].ToString().Replace("\r", "").Replace("\n", "");
                    }
                    catch
                    {
                        txtExportPlace.Text = txtExportDepartment.Text;
                    }
                    hdIsIT.Value = "";
                    DrawDetailTable(success);
                    sbJS.Append("$(\"#SuSpUl\").css(\"margin-top\",\"10px\");");
                }
                catch (System.Exception ex)
                {
                    RunJS("alert('上传失败！" + ex.Message + "');");
                    return;
                }
            }
        }
        else
        {
            //if (txtExportDepartment.Text == "总部仓库" || txtExportDepartment.Text == "芳村仓库")
            //    sbJS.Append("$(\"#btnSelect\").hide();$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#SuSpUl\").show();$(\"#lkSpUl\").hide();");
            //else
            //    sbJS.Append("$(\"#btnSelect\").show();$(\"#lkSpUl\").hide();");

            sbJS.Append("history.go(-1);");
        }

        if (!IsNewApply)
        {
            #region 加载自定义流程，隐藏及显示签名按钮，及签名
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DataSet ds = new DataSet();
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
            string flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
            if (flowState == "1" || EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
                sbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
            //if (flowState == "2" && /*applicant == EmployeeName ||*/ EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME && !tpdf) //20141215：M_AlterC
            //    btnEditFlow2.Visible = true;
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

            sbJS.Append("$(\"[id*=txtAsset]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtNumber]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtModel]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
            #endregion

            sbJS.Append("$.each($(\"textarea:not([id*=txtDescribe])\"), function (idx, item) { autoTextarea(this); });");
        }

        //RunJS("window.location='" + Page.Request.Url + "'");
        sbJS.Append("</script>");
    }
}