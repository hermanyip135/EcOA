using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;

using DataAccess.Operate;
using DataEntity;

using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Office.Interop.Word;
using System.Collections;//789

using System.Diagnostics; //M_PDF
using System.Web;

public partial class Apply_Scrap_Apply_Scrap_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public static string SerialNumber = "";
    public string DdlSelect = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbJsEX = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbAtJson = new StringBuilder();//资产类型

    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public string SpAttachPath = ""; //M_AssetAlter：20150827
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();
    //public bool flgt = false;

    #endregion

    #region 页面加载及初始化

    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        GetManagers();//789
        SbJson.Append("[]");
        SbAtJson.Append("[]");
        string UrlMainID = GetQueryString("MainID");
        SerialNumber = "";
        ID = "";
        
        //InitJSHtml();
        if (!IsPostBack)
        {
            ViewState["UpDetail"] = "0";
            ViewState["AssetWrong"] = "";
            try
            {
                if (Session["FLG_ReWrite22"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite22"] = null;
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
            GetAllDepartment();
        }
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        GetAssetType();
        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        txtApplicant.Text = EmployeeName;
        btnSave.Visible = true;
        if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
            SbJs.Append("<script type=\"text/javascript\">$(\"#btnSelect\").show();$(\"#tabs\").tabs();$(\"#SuSpUl\").show();"); //M_AssetAlter：20150827
        else
        {
            SbJs.Append("<script type=\"text/javascript\">$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#tabs\").tabs();");
            DrawDetailTable(1, true);
        }
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
        SbJs.Append("</script>");

        DA_Dic_OfficeAutomation_ITStaff_Operate da_Dic_OfficeAutomation_ITStaff_Operate = new DA_Dic_OfficeAutomation_ITStaff_Operate();
        DataSet ds = da_Dic_OfficeAutomation_ITStaff_Operate.SelectByTeam(2);
        DropDownListBind(ddlFollower, ds.Tables[0], "OfficeAutomation_ITStaff_Code", "OfficeAutomation_ITStaff_Name", "0", "跟进人");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        DA_Dic_OfficeAutomation_ITStaff_Operate da_Dic_OfficeAutomation_ITStaff_Operate = new DA_Dic_OfficeAutomation_ITStaff_Operate();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();

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

        SbJs.Append("<script type=\"text/javascript\">$(\"#btnUpload\").show();");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_Scrap_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_Scrap_Apply"].ToString();
        ApplyN = applicant;
        this.txtDispatchDepartment.Text = dr["OfficeAutomation_Document_Scrap_Department"].ToString();
        this.txtApplicant.Text = applicant;
        this.txtApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_Scrap_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        this.txtScrapReason.Text = dr["OfficeAutomation_Document_Scrap_ReqReason"].ToString();
        this.txtUserName.Text = dr["OfficeAutomation_Document_Scrap_UserName"].ToString();
        this.txtUserTeam.Text = dr["OfficeAutomation_Document_Scrap_UserTeam"].ToString();
        this.txtRemainingsCostsTotal.Text = dr["OfficeAutomation_Document_Scrap_SurplusValue"].ToString();
        txtSuc.Text = dr["OfficeAutomation_Document_Scrap_Suc"].ToString();
        this.lblRemainingCostsTotal.Text = dr["OfficeAutomation_Document_Scrap_SurplusValue"].ToString();
        this.txtSurplusValueNotify.Text = dr["OfficeAutomation_Document_Scrap_SurplusValueNotify"].ToString();
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        DataSet dsITStaff = da_Dic_OfficeAutomation_ITStaff_Operate.SelectByTeam(2);
        DropDownListBind(ddlFollower, dsITStaff.Tables[0], "OfficeAutomation_ITStaff_Code", "OfficeAutomation_ITStaff_Name", "0", "跟进人");
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        //SbJs.Append("$(\"#btnUpload\").show();");
        bool IsApplicant = EmployeeName == dr["OfficeAutomation_Document_Scrap_Apply"].ToString();
        if (IsApplicant)
        {
            if (flowState == "1")
            {
                GetAllDepartment();
                if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                    SbJs.Append("$(\"#btnSelect\").show();$(\"#SuSpUl\").show();"); //M_AssetAlter：20150827
                else
                    SbJs.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
                this.btnSave.Visible = true;
            }
            //if (flowState == "2") //20141215：M_AlterC
            //{
            //    GetAllDepartment();
            //    btnSAlterC.Visible = true;
            //    SbJs.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
            //}
        }
        if (EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
        {
            GetAllDepartment();
            //btnSAlterC.Visible = true;
            this.btnSave.Visible = true;
            if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                SbJs.Append("$(\"#btnSelect\").show();$(\"#SuSpUl\").show();"); //M_AssetAlter：20150827
            else
                SbJs.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
        }
        try //M_AddAnother：20150716 黄生其它意见，增加审批人
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
            DataSet dsFlow2 = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);
            DataRowCollection drcz = dsFlow2.Tables[0].Rows;
            T_OfficeAutomation_Flow flowsa, flowst, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 8);
            flowsa = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 200);
            flowst = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndEID(MainID, "0001");

            if (flowsa != null)
                SbJs.Append("$(\"#trAddAnoF1\").show();");
            if (((drcz[0]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID)
                && drcz[0]["OfficeAutomation_Flow_Auditor"].ToString().Contains(EmployeeName))
                && flowst.OfficeAutomation_Flow_IsAgree == 2)
                || (EmployeeName == applicant && flowst.OfficeAutomation_Flow_IsAgree == 2) || (fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && flowst.OfficeAutomation_Flow_IsAgree == 2) 
                )
            {
                SbJs.Append("$(\"#trAddAnoF1\").show();");
                btnsSignIDx200.Visible = true;
                if ((!fst3.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) || !fst3.OfficeAutomation_Flow_Employee.Contains(EmployeeName)) && flowsa != null)
                    btnsSignIDx200.Visible = false; //M_AlAno：20160217 ++
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

        #region 登录人为行政部经办人或财务部经办人，且流程为完成状态时，标识留档按钮开启。

        //if (flowState == "1" && EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
        //    SbJs.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
        if (flowState == "3")
        {
            if (EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)//登录人为行政部经办人，且流程为完成状态时，标识留档按钮开启。
                SbJs.Append("$(\"#btnSignSave\").show();");
            if (EmployeeName == CommonConst.EMP_FINANCE_OPERATOR_NAME || EmployeeName == "源浩灵")//登录人为财务部经办人，且流程为完成状态时，标识留档按钮开启。
                SbJs.Append("$(\"#btnSignSaveForFinance\").show();");
        }

        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit(); //M_AssetAlter：20150827
        DataSet dsa = new DataSet();
        dsa = da_OfficeAutomation_Attach_Inherit.GetAttachSp(MainID);
        if (dsa.Tables[0].Rows.Count > 0)
        {
            SbJs.Append("$(\"#lkSpUl\").show();$(\"#btnSelect\").hide();");//*8
            if (EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME || EmployeeName == CommonConst.EMP_FINANCE_OPERATOR_NAME || EmployeeName == "源浩灵")
                SbJs.Append("$(\"#SuSpUl\").show();");
        }

        #endregion


        ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByID(ID);

        rptRemainingCosts.DataSource = ds;
        rptRemainingCosts.DataBind();

        int detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable(0, IsApplicant);
        else
        {
            if (dsa.Tables[0].Rows.Count > 0)
                detailCount = 0;
            DrawDetailTable(detailCount, IsApplicant);

            bool isAttachment = false;//是否“详见附件”

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];

                int i = n + 1;

                if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                    SbJs.Append("$('#txtAsset" + i + "').val('" + dr["OfficeAutomation_Document_Scrap_Detail_AssetName"].ToString() + "');");
                DdlSelect += "$('#ddlAsset" + i + "').val('" + dr["OfficeAutomation_Document_Scrap_Detail_AssetTypeID"].ToString() + "');";
                //SbJs.Append("$('#ddlAsset" + i + "').val('" + dr["OfficeAutomation_Document_Scrap_Detail_AssetTypeID"].ToString() + "');");
                SbJs.Append("$('#txtATag" + i + "').val('" + dr["OfficeAutomation_Document_Scrap_Detail_AssetTag"].ToString() + "');");
                SbJs.Append("$('#txtNumber" + i + "').val('" + dr["OfficeAutomation_Document_Scrap_Detail_Number"].ToString() + "');");
                SbJs.Append("$('#txtModel" + i + "').val('" + dr["OfficeAutomation_Document_Scrap_Detail_Model"].ToString() + "');");
                string date = DateTime.Parse(dr["OfficeAutomation_Document_Scrap_Detail_BuyDate"].ToString()).ToString("yyyy-MM-dd");
                date = date == "1900-01-01" ? "" : date;
                date = (date == "" && dr["OfficeAutomation_Document_Scrap_Detail_SurplusValue"].ToString() == "详见附件") ? "详见附件" : date;
                SbJs.Append("$('#txtBuyTime" + i + "').val('" + date + "');");
                SbJs.Append("$('#txtRemainingCosts" + i + "').val('" + dr["OfficeAutomation_Document_Scrap_Detail_SurplusValue"].ToString() + "');");

                if (dr["OfficeAutomation_Document_Scrap_Detail_AssetTag"].ToString() == "详见附件")
                    isAttachment = true;
            }

            if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
            {
                for (int n = 1; n <= detailCount; n++)
                {
                    SbJs.Append("if($(\"#txtATag" + n + "\").val() != \"\")$(\"#txtATag" + n + "\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                }//*9
                if (EmployeeName != CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME || dsa.Tables[0].Rows.Count > 0) //M_AssetAlter：20150827
                {
                    SbJs.Append("$(\"[id*=txtAsset]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtNumber]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtModel]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                    if (dsa.Tables[0].Rows.Count > 0)
                        SbJs.Append("$(\"[id*=txtBuyTime]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtRemainingCosts]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                }
            }

            if (isAttachment)
                this.txtSurplusValueNotify.Visible =  true;
            else
                rptRemainingCosts.Visible = true;
        }

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                //if (EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
                if (DateTime.Now > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                    SbJs.Append("$(\"#btnSelect\").show();$(\"#btnAddRow\").hide();$(\"#btnDeleteRow\").hide();$(\"#tbDetail tr[id*=trDetail]\").remove();i = 0;$(\"#SuSpUl\").show();$(\"#lkSpUl\").hide();"); //M_AssetAlter：20150827
                else
                    SbJs.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
                //if (DateTime.Parse(txtApplyDate.Text) <= DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                //    SbJs.Append("$(\"#tbDetail tr[id*=trDetail]\").remove();i = 0;");
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();$(\"#tabs\").tabs();");
                SbJs.Append("$(\"[id*=txtBuyTime]\").val('');$(\"[id*=txtRemainingCosts]\").val('');");
                SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
                SbJs.Append("</script>");
                MainID = Guid.NewGuid().ToString();
                flowState = "1";
                btnSAlterC.Visible = false;
                GetAssetType();
                GetAllDepartment();
                IsNewApply = true;
                btnSPDF.Visible = false; //M_PDF
                txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtApplicant.Text = EmployeeName;
                btnSave.Visible = true;

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
        SbJs.Append(saynostr);
        #endregion

        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        bool flag3 = false;//是否有it环节
        bool flag4 = false;//是否已完成it报废证明填写环节
        bool flag5 = false;//是否有财务部经办人环节
        bool flag6 = false;//是否有董事总经理环节
        bool flg7 = false;//是否有后勤事务部环节

        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        if (Purview.Contains("OA_Search_002"))//789
            GetAllDepartment();
        if (EmployeeID == "10054")
            SbJs.Append("$(\"#afa\").show();$(\"#dfd\").show();");
        //foreach (DataRow drs in drc)
        //{
        //    string idx = drs["OfficeAutomation_Flow_Idx"].ToString();
        //    if (!Regex.IsMatch(((float.Parse(idx) - 1) / 3.0).ToString(), "^[0-9]*[1-9][0-9]*$"))
        //        SbJs.Append("$('#divIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();$('#divTxtIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();");
        //    SbJs.Append("$('#txtIDxa" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_Employee"] + ",');");
        //    //SbJs.Append("$('#hdIDx" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_EmployeeID"] + "');");
        //}
        DataSet ds2 = new DataSet();
        bool x2 = false, x3 = false;
        ds2 = da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.SelectByID(ID);
        int LogisticsFlowCount = ds2.Tables[0].Rows.Count;
        ViewState["FSIN"] = "";
        if (LogisticsFlowCount == 0)
        {
            //if (isApplicant)
            //    DrawDetailTable(1);
        }
        else
        {
            //if (isApplicant)
            //    DrawDetailTable(LogisticsFlowCount / 3);
            for (int n = 0, i = 1; n < LogisticsFlowCount; n++, i++)
            {
                dr = ds2.Tables[0].Rows[n];
                SbJs.Append("$('#txtDpm" + i + "').val('" + dr["OfficeAutomation_Document_GeneralApply_Detail_Department"] + "');");
                SbJs.Append("$('#rdoIsCmodel" + i + "1" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                n++;
                dr = ds2.Tables[0].Rows[n];
                x2 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + i + "2" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                n++;
                dr = ds2.Tables[0].Rows[n];
                x3 = dr["OfficeAutomation_Document_GeneralApply_Detail_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + i + "3" + (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_GeneralApply_Detail_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_GeneralApply_Detail_Num"].ToString() + ",";
                DrawAFTable(i, x2, x3, dr["OfficeAutomation_Document_GeneralApply_Detail_Department"].ToString());
            }
        }//987


        //自定义控件赋值
        var flowshowlist = da_OfficeAutomation_Flow_Inherit.GetFlowShowList(ds);
        this.FlowShow1.FlowShowList = flowshowlist;

        //SbFlow.Append("<div class=\"flow\">");
        //SbFlow.Append("审批流程:");
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            if (curidx == "2")
                flag5 = true;

            if (curidx == "2" && EmployeeName==CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
                this.btnSaveSurplusValueNotify.Visible = true;

            if (curidx == "9" && drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                flag4 = true;

            if (curidx == "10")
                flag3 = true;

            if (curidx == "17")
                flag6 = true;
            if (curidx == "16")
                flg7 = true;

            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                flag2 = false;
                if (curemp.Contains(EmployeeName))
                {
                    switch (curidx)
                    {
                        case "1":
                            lbAddLg1.Visible = true;
                            lbDelLg1.Visible = true;
                            this.btnRemindPhoto.Visible = true;//提醒申请人上传资产照片
                            this.btnRemindScrap.Visible = true;//提醒申请人上传报废证明
                            this.cbkToFinance.Visible = true;
                            this.cbkToIT.Visible = true;
                            this.btnSaveSurplusValueNotify.Visible = true;
                            //this.btnSave.Visible = true;

                            DataSet dsFlow = new DataSet();
                            dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                            foreach (DataRow drFlow in dsFlow.Tables[0].Rows)
                            {
                                if (drFlow["OfficeAutomation_Flow_Idx"].ToString() == "10" || drFlow["OfficeAutomation_Flow_Idx"].ToString() == "12")
                                {
                                    this.cbkToIT.Checked = true;
                                    break;
                                }
                            }
                            break;
                        case "2":
                            this.btnRemindPhoto2.Visible = true;//提醒申请人上传资产照片
                            this.btnSaveSurplusValueNotify.Visible = true;
                            //this.btnSave.Visible = true;
                            this.lbAddLg3.Visible = true;
                            this.lbDelLg3.Visible = true;
                            break;
                        case "3":
                        case "5":
                        case "7":
                            //SbJsEX.Append("$('#ui-id-2').click();");
                            SbJsEX.Append("$('#Scarp_z').click();");
                            break;
                        case "9":
                        case "11":
                            //SbJs.Append("$('#tabs-1').hide();$('#tabs-3').show();");
                            SbJsEX.Append("$('#Scarp_i').click();");
                            break;
                        case "10":
                            if (!flag4)
                            {
                                SbJs.Append("$('#divAssign').show();");
                                this.btnAssign.Visible = true;//下派跟进人处理按钮显示
                            }
                            break;
                        case "13":
                            lbAddLg2.Visible = true;
                            lbDelLg2.Visible = true;
                            break;
                        case "14":
                            if (EmployeeID == "13545") //M_AddNWX：20150511
                                lbtnAddN.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (applicant == EmployeeName && curidx == "1")
                        this.btnRemindUploadedPhoto.Visible = this.btnRemindUploadedPhoto2.Visible = true;
                }
            }
            #endregion

            #region 显示签名人姓名，签名图片，或签名按钮
            string[] auditorIDs = drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Split(',');
            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            {
                /*SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 60px; line-height: 65px; height: 2px; margin-left:80px\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + (drc[i]["OfficeAutomation_Flow_Employee"].ToString().Contains(drc[i]["OfficeAutomation_Flow_Auditor"].ToString()) ? "" : "(代)")
                    + "</div><img src=\"" + SignImageURL + GetGIF(employeeID) + ".gif\" height=\"60px\" />');");*/
                SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:0px; float:left;\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");//<img src=\"" + SignImageURL + GetGIF(employeeID) + ".gif\" height=\"60px\" />');");
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
                    SbJs.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                    SbJs.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                else
                    SbJs.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");

                if (string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').hide();");
                else
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
            }
            else
            {
                if (auditorIDs.Length > 0 && auditorIDs[0] != "")
                {
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:20px; float:left;\">"
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
                        SbJs.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                        SbJs.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                        SbJs.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");

                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString() + "');");
                    SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
                }

                if (idx == 2)
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                if (!string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                if (flag && da_OfficeAutomation_Agent_Inherit.IsHaveSignPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(),
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID))
                {
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').show();");
                }

                flag = false;
            }

            if (i >= 2 && int.Parse(drc[i]["OfficeAutomation_Flow_Idx"].ToString()) >= 200) //M_AddAnother：20150716 黄生其它意见，增加审批人
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

        bool htpd = false;
        try
        {
            if (Request.QueryString["htmltopdf"] == "Yes") //M_PDF 
            {
                SbJs.Append("$(\"div .flow\").hide();$(\"#PageBottom\").hide();$(\"#btnPrint1\").hide();$(\"#btnPrint2\").hide();");
                htpd = true;
            }
            else
                SbJs.Append("$(\"#tabs\").tabs();");
        }
        catch
        {
            SbJs.Append("$(\"#tabs\").tabs();");
        }

        if (!flag3)
            SbJs.Append("$('#trIT1').hide();$('#trIT2').hide();$('#trIT3').hide();$('#trIT4').hide();");
        else if (flag3 && htpd)
            SbJs.Append("$('#ulTabs').hide();$('#tabs-2').hide();"); 
        else
            SbJs.Append("$('#ulTabs').show();$('#liTabs3').show();");

        if (htpd && flag5)
            SbJs.Append("$('#ulTabs').hide();$('#tabs-3').hide();");
        else if (flag5)
            SbJs.Append("$('#ulTabs').show();$('#liTabs2').show();");
        else
            SbJs.Append("$('#trMoney1').hide();$('#trMoney2').hide();");

        if (htpd && flag3 && flag5)
            SbJs.Append("$('#ulTabs').hide();$('#tabs-2').show();$('#tabs-3').show();");

        if (htpd && !flag3 && !flag5)
            SbJs.Append("$('#ulTabs').hide();$('#tabs-2').hide();$('#tabs-3').hide();");

        if (flag6)
            SbJs.Append("$('#trManager1').show();$('#trManager2').show();");
        if (flg7)
            SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();");

        T_OfficeAutomation_Flow flows;//789
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        if (flows != null)
            SbJs.Append("$('#trLogistics1').hide();$('#trLogistics2').hide();$('#trManager1').hide();$('#trManager2').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //流程为未审核状态，且登录人为申请人或行政部经办人。
        if (flowState == "1" && (applicant == EmployeeName || EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME))
            this.FlowShow1.ShowEditBtn = true;
        if (flowState == "2" && /*applicant == EmployeeName ||*/ EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME && !htpd) //20141215：M_AlterC
            btnEditFlow2.Visible = true;

        if (EmployeeID == "10054" || EmployeeID == "34498") //M_WinnEnd：20150204
        {
            btnWillEnd.Visible = true;
            btnWillEnd2.Visible = true;
        }

        //20170206注释
        //if (EmployeeName == "张绍欣") //M_EmmaJump：20160118
        //    btnShouldJumpIDxEmma.Visible = true;

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndEID(MainID, "0001");
        if (flows == null)
            SbJs.Append("$('#trManager1').hide();$('#trManager2').hide();$('#tlsc2').hide();"); //trManager1 trGeneralManager

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
            FlowShow1.Visible = false;
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

    /// <summary>
    /// 绘制详情表格内容
    /// </summary>
    /// <param name="n">行数</param>
    public void DrawDetailTable(int n,bool isApplicant)
    {
        if (EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME || EmployeeName == "源浩灵" || EmployeeName == "源浩灵")
            isApplicant = false;

        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id='trDetail" + i + "' class=\"noborder\">");
            SbHtml.Append("     <td class=\"tl PL10\" style=\"width:200px\">");
            if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                SbHtml.Append("            *报废物品  <input type=\"text\" id=\"txtAsset" + i + "\" style=\"width:120px;\"/><select id=\"ddlAsset" + i + "\" style=\"width:120px;display:none;\" onchange=\"checkasset(this," + i + ");\"></select><br />");
            else
                SbHtml.Append("            *报废物品  <select id=\"ddlAsset" + i + "\" style=\"width:120px;\" onchange=\"checkasset(this," + i + ");\"></select><br />");
            SbHtml.Append("            *数　　量 <input type=\"text\" id=\"txtNumber" + i + "\" style=\"width:120px;\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\" onblur=\"checknum(this," + i + ");\"/><br />");
            SbHtml.Append("            &nbsp;&nbsp;购买时间 <input type=\"text\" id=\"txtBuyTime" + i + "\" style=\"width:120px;" + (isApplicant ? "background-color:#e3e3e3;\" disabled=\"disabled\"" : "\"") + " onblur=\"if($('#txtBuyTime" + i + "').val()=='详见附件'){$('#txtRemainingCosts" + i + "').val('详见附件');}\"/>");
            SbHtml.Append("    </td>");
            SbHtml.Append("     <td class=\"tl PL10\">");
            SbHtml.Append("            *财　务　编　号 <input type=\"text\" id=\"txtATag" + i + "\" style=\"width:190px;*width:175px;\"/><br />");
            SbHtml.Append("            *规　格　型　号 <input type=\"text\" id=\"txtModel" + i + "\" style=\"width:190px;*width:175px;\"/><br />");
            SbHtml.Append("            &nbsp;&nbsp;折旧摊分剩余费用 <input type=\"text\" id=\"txtRemainingCosts" + i + "\" style=\"width:178px;*width:163px;" + (isApplicant ? "background-color:#e3e3e3;\" disabled=\"disabled\"" : "\"") + " onblur=\"if($('#txtRemainingCosts" + i + "').val()=='详见附件'){$('#txtBuyTime" + i + "').val('详见附件');}\"/>");
            SbHtml.Append("    </td>");
            SbHtml.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    #endregion

    #region 事件

    #region 按钮点击事件

    /// <summary>
    /// 保存按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region 创建对象
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_Scrap t_OfficeAutomation_Document_Scrap = new T_OfficeAutomation_Document_Scrap();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
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

        //try
        //{
            if (IsNewApply)
            {
                #region 新建
                IsNewApply = false;
                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "Scrap" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 4;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_Department = txtDispatchDepartment.Text;
                t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_Apply = txtApplicant.Text;
                t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_ApplyDate = DateTime.Parse(txtApplyDate.Text);
                t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_UserName = txtUserName.Text;
                t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_UserTeam = txtUserTeam.Text;
                t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_ReqReason = txtScrapReason.Text;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = txtApplicant.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDispatchDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtUserName.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Parse(txtApplyDate.Text);

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_Scrap_Inherit.Insert(t_OfficeAutomation_Document_Scrap);//插入报废申请表

                var result = InsertScrapDetail(t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_ID, t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
                bool haveITAsset = result.haveITAsset;

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

                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "10,12");
                    if (haveITAsset)//是否有IT类资产，如果有则添加2步IT流程：第10步IT部维护组主管意见，第12步IT部负责人意见
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1236";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "梁锐华";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3808";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何智峰";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 12;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }

                    if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                    {
                        if (hdIsL.Value.Contains("3"))
                        {
                            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                        }
                        else if (!string.IsNullOrEmpty(hdIsL.Value))
                            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
                    }
                    else
                    {
                        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
                        ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
                        string id = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString(), sc = "4,12,17,19,20,22,25,26,27,29,30,32,33,34,35,36,38,39,40,41,42,43,44,55,56";
                        ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByID(id);
                        int detailCount = ds.Tables[0].Rows.Count;
                        string[] fn = sc.Split(',');
                        for (int n = 0; n < detailCount; n++)
                        {
                            if (!((IList)fn).Contains(ds.Tables[0].Rows[n]["OfficeAutomation_Document_Scrap_Detail_AssetTypeID"].ToString()))
                            {
                                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                                break;
                            }
                            else
                                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
                        }
                    }
                }
                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 7, new Guid(MainID), 1);//日志，创建报废申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程
                if (ViewState["AssetWrong"].ToString() == "")
                    RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_Scrap_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
        //}
        //catch (Exception ex)
        //{
        //    RunJS("alert(\"" + "保存失败！" + ex.Message.Replace("\r", "\\r").Replace("\n", "\\n") + "\");history.go(-1);");
        //    //Alert("保存失败！" + ex.Message.Replace("\r", "\\r").Replace("\n", "\\n"));
        //}
    }

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
        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit=new DA_OfficeAutomation_Document_Scrap_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString(); 
        
        string flowIDx = "0";
        string signEmployeeName = EmployeeName;
        string signEmployeeID = EmployeeID;

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
                ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                DataRowCollection drc = ds.Tables[0].Rows;
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
                            signEmployeeID = haveSignPowerEmployee.Split('|')[1];
                            break;
                        }
                    }
                }

                T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                if (flowIDx == "1")
                {
                    //flgt = true;
                    var result = Update();

                    if (cbkToFinance.Checked)
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_FINANCE_OPERATOR_ID;
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_FINANCE_OPERATOR_NAME;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "45664";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "源浩灵";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 2;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        da_OfficeAutomation_Flow_Inherit.InsertSurplusValueFlow(MainID);
                    }

                    if (cbkToIT.Checked)//转IT审核是否勾选，如果是且流程中无10、12步则添加2步IT流程：第10步IT部维护组主管意见，第12步IT部负责人意见
                    {
                        bool flagHaveIT = false;
                        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["OfficeAutomation_Flow_Idx"].ToString() == "10" || dr["OfficeAutomation_Flow_Idx"].ToString() == "12")
                            {
                                flagHaveIT = true;
                                break;
                            }
                        }

                        if (!flagHaveIT)
                        {
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_IT_HARDWARE_MANAGER_ID;
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_IT_HARDWARE_MANAGER_NAME;
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_IT_MANAGER_ID;
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_IT_MANAGER_NAME;
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 12;

                            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                        }
                    }

                    //20160512 是否增加sky与黄生的流程
                    AddSkyFlow(result);
                }

                if (flowIDx == "2")
                {
                    var result = Update();
                    Match m = Regex.Match(txtRemainingsCostsTotal.Text,"(([1-9]\\d{0,9})|0)(\\.\\d{1,2})?");
                    decimal d = 0;
                    try
                    {
                        d = decimal.Parse(m.Value);
                    }
                    catch
                    {
                        d = 0;
                    }
                    result.totalSurplusValue = d;   //折旧总结以手工填写的为准
                    AddSkyFlow(result);
                }

                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = ((IList)flowN).Contains(flowIDx) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeID, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeID, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email = "";
                    string messageBody;

                    ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
                    string employname;
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Department"].ToString();
                    //通知已审批的人员，邮件中附带报废申请的申请资料。
                    DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
                    DA_Dic_OfficeAutomation_AssetType_Operate da_Dic_OfficeAutomation_AssetType_Operate = new DA_Dic_OfficeAutomation_AssetType_Operate();
                    DataRow drScrap = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID).Tables[0].Rows[0];
                    DataSet dsDetail = new DataSet();
                    dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(MainID);
                    string msnBody = "";
                    string mailBody = "<br/><br/>申请部门或分行名称：" + drScrap["OfficeAutomation_Document_Scrap_Department"]
                        + "<br/>填写人：" + drScrap["OfficeAutomation_Document_Scrap_Apply"]
                        + "<br/>递交时间：" + DateTime.Parse(drScrap["OfficeAutomation_Document_Scrap_ApplyDate"].ToString()).ToString("yyyy-MM-dd")
                        + "<br/>报废物品使用人姓名：" + drScrap["OfficeAutomation_Document_Scrap_UserName"]
                        + "<br/>职称及所属级别：" + drScrap["OfficeAutomation_Document_Scrap_UserTeam"]
                        + "<br/>申请报废原因：" + drScrap["OfficeAutomation_Document_Scrap_ReqReason"]
                        + "<br/><br/>报废详细情况：";

                    foreach (DataRow dr in dsDetail.Tables[0].Rows)
                    {
                        if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                            mailBody += "<br/>&nbsp;&nbsp;报废物品：" + dr["OfficeAutomation_Document_Scrap_Detail_AssetName"].ToString();
                        else
                            mailBody += "<br/>&nbsp;&nbsp;报废物品：" + da_Dic_OfficeAutomation_AssetType_Operate.SelectByID(dr["OfficeAutomation_Document_Scrap_Detail_AssetTypeID"].ToString()) + "&nbsp;&nbsp;财务编号：" + dr["OfficeAutomation_Document_Scrap_Detail_AssetTag"];
                        mailBody += "<br/>&nbsp;&nbsp;数量：" + dr["OfficeAutomation_Document_Scrap_Detail_Number"] + "&nbsp;&nbsp;规格型号：" + dr["OfficeAutomation_Document_Scrap_Detail_Model"];
                        mailBody += "<br/>&nbsp;&nbsp;购买时间：" + DateTime.Parse(dr["OfficeAutomation_Document_Scrap_Detail_BuyDate"].ToString()).ToString("yyyy-MM-dd") + "&nbsp;&nbsp;折旧摊分剩余费用：" + dr["OfficeAutomation_Document_Scrap_Detail_SurplusValue"];
                        mailBody += "<br/>";
                    }
                    if (hdIsAgree.Value != "0")//同意或其他意见
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名同意

                        //判断审批流程是否完成,通知相应人员
                        if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(MainID))
                        {
                            foreach (DataRow dr in dsDetail.Tables[0].Rows)
                            {
                                wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                                if (hdIsAgree.Value == "1")
                                {
                                    try
                                    {
                                        LogCommonFunction.AddLog(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString(), "报废资产前");
                                    }
                                    catch (Exception)
                                    {


                                    }
                                  bool reuslt =  ws.AssetAdjustmentPass(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
                                    try
                                    {
                                        LogCommonFunction.AddLog(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString(), reuslt.ToString());
                                    }
                                    catch (Exception)
                                    {
                                        
                                       
                                    }
                                }
                                   
                            }
                            //审批流程完成，通知申请人
                            messageBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。申请表地址为：" + Page.Request.Url.ToString();
                            email = apply;
                            if (hdIsAgree.Value == "2")
                                Common.SendMessageEX(false, email, "其他意见", messageBody, messageBody);
                            else
                                Common.SendMessageEX(false, email, "申请已同意", messageBody, messageBody);

                            string employeeList = "";//该字段用于防止重复发送
                            ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    //if (dr["OfficeAutomation_Flow_Idx"].ToString() == "8")
                                    if (!employeeList.Contains(employnames[i]) && employnames[i] != CommonConst.EMP_LOGISTICS_MANAGER_NAME && employnames[i] != "")
                                    {
                                        msnBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。申请表地址为：" + Page.Request.Url;
                                        email = employnames[i];
                                        if (hdIsAgree.Value == "2")
                                            Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                        else
                                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                        employeeList += employnames[i] + "||";
                                    }
                                }

                                if (dr["OfficeAutomation_Flow_Idx"].ToString() == "10")
                                {
                                    msnBody = "您好，" + CommonConst.EMP_IT_OPERATOR_NAME + "：编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。申请表地址为：" + Page.Request.Url;
                                    email = CommonConst.EMP_IT_OPERATOR_NAME;
                                    if (hdIsAgree.Value == "2")
                                        Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                    else
                                        Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);
                                }
                            }
                            if (EmployeeID == "0001")
                                employeeList += "黄轩明" + "||";

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //完成后抄送
                            //employname = CommonConst.EMP_GMO_NAME + ",黄凤珊";
                            if (employeeList.Contains("黄轩明"))
                                employname = CommonConst.EMP_GMO_NAME + ",黄凤珊";
                            else
                                employname = "黄凤珊";
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。" + sagree + "<br />申请表" + Page.Request.Url.ToString();
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
                            messageBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。申请表地址为：" + Page.Request.Url;
                            email = apply;
                            Common.SendMessageEX(false, email, "申请已通过" + EmployeeName + "的审理", messageBody, messageBody);

                            //通知下一步需要审批的人员
                            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
                            if (!employname.Contains(EmployeeName))
                            {
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    messageBody = "您好，" + employnames[i] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审理。申请表地址为：" + Page.Request.Url;
                                    Common.SendMessageEX(true, documentName, email, "请审理", messageBody, messageBody, MainID);
                                }
                            }
                            if ((flowIDx == "13" || flowIDx == "15") && hdIsAgree.Value == "2")
                            {
                                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                            }
                            //当审批到总经理的时候，发份邮件通知总办2位同事
                            if (employname.Contains(CommonConst.EMP_GENERALMANAGER_NAME))
                            {
                                employname = CommonConst.EMP_GMO_NAME;
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + Page.Request.Url.ToString();
                                    Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody + mailBody, msnBody);
                                }
                            }
                        }

                        if (flowIDx == "3" || flowIDx == "5" || flowIDx == "7")
                            RunJS("alert('审批成功！您还需要对申请表进行审核签名！');window.location='" + Page.Request.Url + "'");
                        else
                            RunJS("alert('审批成功！');window.location='" + Page.Request.Url + "'");
                    }
                    else //不同意
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 5);//添加日志，签名不同意

                        //通知申请人
                        messageBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。申请表地址为：" + Page.Request.Url;
                        email = apply;
                        Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", messageBody, messageBody);

                        //DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
                        //DataSet dsDetail = new DataSet();
                        dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(MainID);
                        foreach (DataRow dr in dsDetail.Tables[0].Rows)
                        {
                            wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                            ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
                        }

                        //通知已审批的人员
                        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                messageBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。申请表地址为：" + Page.Request.Url;
                                email = employnames[i];
                                Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", messageBody, messageBody);
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
                                msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。" + sagree + "<br />申请表" + Page.Request.Url;
                                email = employnames[i];
                                Common.SendMessageEX(false, email, "申请不同意", msnBody + mailBody, msnBody);
                            }
                        } //总办

                        RunJS("alert('审理成功！');window.location='" + Page.Request.Url + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                Alert("审理失败！" + ex.Message);
            }
        }
        else
        {
            Alert("未开通审核权限！");
        }
    }

    /// <summary>
    /// 通知上传照片按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemindPhoto_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
            string applicant = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);

            string email = applicant;
            string messageBody = "您好，" + applicant + "：行政部" + EmployeeName + "通知您，有编号为" + serialNumber + "的" + documentName + "由于非IT类资产报废3件或以上需提供报废资产照片，并通知"
                + EmployeeName + "，否则该申请将不予通过。申请表地址为：" + Page.Request.Url;
            Common.SendMessageEX(false, email, "请上传附件", messageBody, messageBody);

            //Alert(CommonConst.MSG_SEND_SUCCESS);
            Response.Write("<script>alert('已成功发送通知。');window.history.go(-1);</script>");
        }
        catch
        {
            //Alert(CommonConst.MSG_SEND_FAIL);
            Response.Write("<script>alert('发送通知失败！');window.history.go(-1);</script>");
        }
    }

    /// <summary>
    /// 通知上传照片2按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemindPhoto2_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
            ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString();

            var MainBLL = new DA_OfficeAutomation_Main_Inherit();
            var MainObj = MainBLL.GetModel("OfficeAutomation_Main_ID='" + MainID + "'");

            //DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
            //da_OfficeAutomation_Document_Scrap_Detail_Inherit.Delete(ID);
            InsertScrapDetail(new Guid(ID), MainObj.OfficeAutomation_SerialNumber);

            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

            da_OfficeAutomation_Flow_Inherit.UpdateSuggestionByMainIDAndIdx(MainID, 2, hdSuggestion.Value);
            da_OfficeAutomation_Document_Scrap_Inherit.UpdateSurplusValueByID(ID, txtRemainingsCostsTotal.Text, txtSuc.Text);
                
            ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
            string applicant = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);

            string email = applicant;
            string messageBody = "您好，" + applicant + "：财务部" + EmployeeName + "通知您，有编号为" + serialNumber + "的" + documentName + "由于“"+hdSuggestion.Value+"”需提供报废资产照片，上传之后通知"
                + EmployeeName + "，否则该申请将不予通过。申请表地址为：" + Page.Request.Url;
            Common.SendMessageEX(false, email, "请上传附件", messageBody, messageBody);

            //Alert(CommonConst.MSG_SEND_SUCCESS);
            //RunJS("window.location.href='" + Request.RawUrl + "';");
            Response.Write("<script>alert('已成功发送通知。');window.history.go(-1);</script>");
        }
        catch
        {
            //Alert(CommonConst.MSG_SEND_FAIL);
            Response.Write("<script>alert('发送通知失败！');window.history.go(-1);</script>");
        }
    }

    /// <summary>
    /// 通知秘书上传报废证明按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemindScrap_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
            string applicant = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);

            string email = applicant;
            string messageBody = "您好，" + applicant + "：行政部" + EmployeeName + "通知您，有编号为" + serialNumber + "的" + documentName + "需提供由维修商开具的报废证明，否则该申请将不予通过。申请表地址为：" + Page.Request.Url;
            Common.SendMessageEX(false, email, "请上传报废证明", messageBody, messageBody);

            //Alert(CommonConst.MSG_SEND_SUCCESS);
            Response.Write("<script>alert('已成功发送通知。');window.history.go(-1);</script>");
        }
        catch
        {
            //Alert(CommonConst.MSG_SEND_FAIL);
            Response.Write("<script>alert('发送通知失败！');window.history.go(-1);</script>");
        }
    }

    /// <summary>
    /// 通知行政部已经上传了照片按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemindUploadedPhoto_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
            string applicant = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);

            string email = CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME;
            string messageBody = "您好，" + CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME + "：" + applicant + "通知您，已将编号为" + serialNumber + "的" + documentName
                + "的相关附件上传，请及时审理。申请表地址为：" + Page.Request.Url;
            Common.SendMessageEX(false, email, "已上传附件", messageBody, messageBody);

            //Alert(CommonConst.MSG_SEND_SUCCESS);
            Response.Write("<script>alert('已成功发送通知。');window.history.go(-1);</script>");
        }
        catch
        {
            //Alert(CommonConst.MSG_SEND_FAIL);
            Response.Write("<script>alert('发送通知失败！');window.history.go(-1);</script>");
        }
    }

    /// <summary>
    /// 通知财务部已经上传了照片按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemindUploadedPhoto2_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
            string applicant = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);

            //string email = CommonConst.EMP_FINANCE_OPERATOR_NAME;
            string email = "源浩灵";
            string messageBody = "您好，源浩灵：" + applicant + "通知您，已将编号为" + serialNumber + "的" + documentName
                + "的相关附件上传，请及时审理。申请表地址为：" + Page.Request.Url;
            Common.SendMessageEX(false, email, "已上传附件", messageBody, messageBody);

            //Alert(CommonConst.MSG_SEND_SUCCESS);
            Response.Write("<script>alert('已成功发送通知。');window.history.go(-1);</script>");
        }
        catch
        {
            //Alert(CommonConst.MSG_SEND_FAIL);
            Response.Write("<script>alert('发送通知失败！');window.history.go(-1);</script>");
        }
    }

    #region 返回按钮点击事件
    protected void btnBack_Click(object sender, EventArgs e)
    {
          
        string sUrl = "/Apply/Apply_Search.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
    }
    #endregion

    /// <summary>
    /// 下派按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
            ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
            SerialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string follower = "";

            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 9);
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 11);
            if (ddlFollower.SelectedIndex != 0)
            {
                follower = ddlFollower.Items[ddlFollower.SelectedIndex].Text;
                //增加一个流程环节,it部维护组同事跟进
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 9;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = ddlFollower.Items[ddlFollower.SelectedIndex].Value;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = follower;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                //通知跟进人填写报废证明
                string email = follower;
                string messageBody = "您好，" + follower + "：您有编号为" + SerialNumber + "的" + da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID) + "需要您负责跟进填写IT报废证明。申请表地址为：" + Page.Request.Url.ToString();
                Common.SendMessageEX(false, email, "填写报废证明提醒", messageBody, messageBody);

                //增加一个流程环节,leo签署报废证明
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_IT_MANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_IT_MANAGER_NAME;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                if (follower != "")
                    follower += ",";

                follower += t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee;
            }

            ////通知申请人已安排跟进人
            //string email = apply;
            //string messageBody = "您好，" + apply + "：您有编号为" + SerialNumber + "的" + da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID) + "已安排" + follower + "负责跟进。申请表地址为：" + Page.Request.Url.ToString();
            //Common.SendMessageEX(false, email, "跟进预告", messageBody, messageBody);

            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 2);
            RunJS("alert('下派成功！');window.location='/Apply/Scrap/Apply_Scrap_Detail.aspx?MainID=" + MainID + "'");
        }
        catch (Exception ex)
        {
            Alert("下派失败，" + ex.Message);
        }
    }

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
    private InsertScrapDetailBack Update()
    {
        T_OfficeAutomation_Document_Scrap t_OfficeAutomation_Document_Scrap = new T_OfficeAutomation_Document_Scrap();
        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString();

        t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_ID = new Guid(ID);
        t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_Department = txtDispatchDepartment.Text;
        t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_Apply = txtApplicant.Text;
        t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_ApplyDate = DateTime.Parse(txtApplyDate.Text);
        t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_UserName = txtUserName.Text;
        t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_UserTeam = txtUserTeam.Text;
        t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_ReqReason = txtScrapReason.Text;
        t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_SurplusValue = txtRemainingsCostsTotal.Text;
        t_OfficeAutomation_Document_Scrap.OfficeAutomation_Document_Scrap_Suc = txtSuc.Text;

        string apply = txtApplicant.Text;
        string depname = txtDispatchDepartment.Text;
        string summary = txtUserName.Text;
        string applydate = txtApplyDate.Text;
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_Scrap_Inherit.Update(t_OfficeAutomation_Document_Scrap);//修改报废申请表

        var MainBLL = new DA_OfficeAutomation_Main_Inherit();
        var MainObj = MainBLL.GetModel("OfficeAutomation_Main_ID='" + MainID + "'");

        //DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        //da_OfficeAutomation_Document_Scrap_Detail_Inherit.Delete(ID);

        var result = InsertScrapDetail(new Guid(ID), MainObj.OfficeAutomation_SerialNumber);
        bool haveITAsset = result.haveITAsset;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        if (haveITAsset)//是否有IT类资产，如果有则添加2步IT流程：第10步IT部维护组主管意见，第12步IT部负责人意见
        {
            T_OfficeAutomation_Flow flows;
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 10);
            if (flows == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_IT_HARDWARE_MANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_IT_HARDWARE_MANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_IT_MANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_IT_MANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 12;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
        }
        //else
        else if (!string.IsNullOrEmpty(hdIsIT.Value)) //M_Warning：发布新功能时需更换 20150601
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "10,12");

        if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
        {
            if (hdIsL.Value.Contains("3"))
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
            else if (!string.IsNullOrEmpty(hdIsL.Value))
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
        }
        else
        {
            DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
            ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
            string id = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString(), sc = "4,12,17,19,20,22,25,26,27,29,30,32,33,34,35,36,38,39,40,41,42,43,44,55,56";
            ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByID(id);
            int detailCount = ds.Tables[0].Rows.Count;
            string[] fn = sc.Split(',');
            for (int n = 0; n < detailCount; n++)
            {
                if (!((IList)fn).Contains(ds.Tables[0].Rows[n]["OfficeAutomation_Document_Scrap_Detail_AssetTypeID"].ToString()))
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    break;
                }
                else
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
            }
        }

        Common.AddLog(EmployeeID, EmployeeName, 7, new Guid(MainID), 2);//日志，修改报废申请表
        return result;
    }

    /// <summary>
    /// 新增报废申请明细,返回是否有IT类资产
    /// </summary>
    /// <param name="gScrapID"></param>
    private InsertScrapDetailBack InsertScrapDetail(Guid gScrapID, string SerialNumber)
    {
        var result = new InsertScrapDetailBack();
        bool haveITAsset = false;
        result.maxSurplusValue = 0;
        result.totalSurplusValue = 0;
        if (hdDetail.Value == "")
        {
            result.haveITAsset = false;
            return result;
        }

        T_OfficeAutomation_Document_Scrap_Detail t_OfficeAutomation_Document_Scrap_Detail;
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        DA_Dic_OfficeAutomation_AssetType_Operate da_Dic_OfficeAutomation_AssetType_Operate = new DA_Dic_OfficeAutomation_AssetType_Operate();

        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
        if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
        {
            try
            {
                DataSet dsDetail = new DataSet();
                dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(MainID);

                if (dsDetail.Tables[0].Rows.Count > 0 && ViewState["UpDetail"].ToString() == "0") //M_AssetAlter：20150827
                {
                    ViewState["Dteail"] = dsDetail;
                    ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_Scrap_Detail_AssetName"].ColumnName = "报废物品";
                    ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_Scrap_Detail_AssetTag"].ColumnName = "财务编号";
                    ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_Scrap_Detail_Model"].ColumnName = "规格型号";
                    ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_Scrap_Detail_BuyDate"].ColumnName = "购买时间(由审批人填写)";
                    ((DataSet)ViewState["Dteail"]).Tables[0].Columns["OfficeAutomation_Document_Scrap_Detail_SurplusValue"].ColumnName = "折旧摊分剩余费用(由审批人填写)";
                }

                foreach (DataRow dr in dsDetail.Tables[0].Rows)
                {
                    //if (!string.IsNullOrEmpty(dr["OfficeAutomation_Document_Scrap_Detail_AssetTag"].ToString()))
                    //{
                    //    ws.AdjustmentUpdate(dr["OfficeAutomation_Document_Scrap_Detail_AssetTag"].ToString(), dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
                    //}
                    //ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
                    wsAsset.GetAssetDic ws2 = new wsAsset.GetAssetDic();
                    ws2.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString()); //M_AssetAlter：20150827
                }
            }
            catch
            {
            }
        }

        //try //M_Alter：20150826 删除详情表前先释放在审中的资产
        //{
        //    DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit2 = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        //    DataSet dsDetail2 = new DataSet();
        //    dsDetail2 = da_OfficeAutomation_Document_Scrap_Detail_Inherit2.SelectByMainID(MainID);
        //    foreach (DataRow dr in dsDetail2.Tables[0].Rows)
        //    {
        //        wsAsset.GetAssetDic ws2 = new wsAsset.GetAssetDic();
        //        ws2.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
        //    }
        //}
        //catch
        //{
        //}

        da_OfficeAutomation_Document_Scrap_Detail_Inherit.Delete(gScrapID.ToString());
        
        DateTime dtTemp = new DateTime();
        
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit(); //M_AssetAlter：20150827
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DataSet dsa = new DataSet();
        dsa = da_OfficeAutomation_Attach_Inherit.GetAttachSp(MainID);

        decimal SurplusValue = 0;

        if (dsa.Tables[0].Rows.Count > 0 && hdIsIT.Value == "")
        {
            try
            {
                DataSet dsADetail = (DataSet)ViewState["Dteail"];//*-

                string pattern = @"\d{1,10}(\.\d{1,2})?$"; //正则，找金额
                foreach (DataRow drd in dsADetail.Tables[0].Rows)
                {
                    t_OfficeAutomation_Document_Scrap_Detail = new T_OfficeAutomation_Document_Scrap_Detail();
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_ID = Guid.NewGuid();
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_MainID = gScrapID;
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetName = drd["报废物品"].ToString();
                    //t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTypeID = 0;
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceRec = "";

                    string s = GetAssetPlaceByName(txtDispatchDepartment.Text), t;
                    try
                    {
                        s = s.Substring(s.IndexOf(":") + 1, s.IndexOf(",") - s.IndexOf(":") - 1);
                    }
                    catch
                    {
                        s = "0";
                    }
                    string assetNo = drd["财务编号"].ToString();
                   // t = ws.NewAdjustment(drd["二维码"].ToString(), int.Parse(s), 1, txtDispatchDepartment.Text, txtApplyDate.Text, 2, SerialNumber); //锁定资产
                    t = ws.AdjustmentWithEcoaCode(assetNo, int.Parse(s), 1, txtDispatchDepartment.Text, txtApplyDate.Text, 2, SerialNumber); //锁定资产
                    if (t.Contains("*"))
                        ViewState["AssetWrong"] = t.Replace("*", string.Empty);
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID = t;

                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag = drd["财务编号"].ToString();
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Number = "1";
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Model = drd["规格型号"].ToString();
                    if (string.IsNullOrEmpty(drd["购买时间(由审批人填写)"].ToString()) || drd["购买时间(由审批人填写)"].ToString() == "详见附件")
                        dtTemp = DateTime.Parse("1900/1/1");
                    else
                    {
                        try
                        {
                            dtTemp = DateTime.Parse(drd["购买时间(由审批人填写)"].ToString());
                        }
                        catch
                        {
                            dtTemp = DateTime.Parse("1900/1/1");
                        }
                    }
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = dtTemp;
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue = drd["折旧摊分剩余费用(由审批人填写)"].ToString();

                    var regex = new System.Text.RegularExpressions.Regex(pattern);
                    var mc = regex.Matches(t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue);
                    if (mc != null && mc.Count > 0)
                    {
                        //折旧价
                        SurplusValue = decimal.Parse(mc[0].Value);
                    }
                    else
                    {
                        SurplusValue = 0;
                    }

                    if (result.maxSurplusValue < SurplusValue)
                    {
                        result.maxSurplusValue = SurplusValue;
                    }
                    result.totalSurplusValue += SurplusValue;       //计算总折旧价

                    hdIsIT.Value = "0";
                    dsa = da_OfficeAutomation_Main_Inherit.FindAssetsByAssetNo(drd["财务编号"].ToString());
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
                        da_OfficeAutomation_Document_Scrap_Detail_Inherit.Insert(t_OfficeAutomation_Document_Scrap_Detail);
                    else
                    {
                        //txtExportDepartment.Text = "";
                        try //M_Alter：20150826 删除详情表前先释放在审中的资产
                        {
                            DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit3 = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
                            DataSet dsDetail3 = new DataSet();
                            dsDetail3 = da_OfficeAutomation_Document_Scrap_Detail_Inherit3.SelectByMainID(MainID);
                            foreach (DataRow dr in dsDetail3.Tables[0].Rows)
                            {
                                wsAsset.GetAssetDic ws3 = new wsAsset.GetAssetDic();
                                ws3.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
                            }
                        }
                        catch
                        {
                        }
                        da_OfficeAutomation_Document_Scrap_Detail_Inherit.Delete(gScrapID.ToString());
                        da_OfficeAutomation_Attach_Inherit.DeleteAttachSp(MainID);
                        RunJS("alert(\"" + ViewState["AssetWrong"].ToString() + "，财务编号为：" + drd["财务编号"].ToString() + "，请改正后再上传，保存后需编辑前线的审批人员，以免审批流有误。\");$(\"#tbDetail tr[id*=trDetail]\").remove();history.go(-1);");
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
            string pattern = @"\d{1,10}(\.\d{1,2})?$"; //正则，找金额
            string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                t_OfficeAutomation_Document_Scrap_Detail = new T_OfficeAutomation_Document_Scrap_Detail();
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_MainID = gScrapID;
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceRec = "";
                //t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTypeID = int.Parse(detail[0]);
                //if (da_Dic_OfficeAutomation_AssetType_Operate.IsITAssetType(detail[0]))
                //    haveITAsset = true;

                if (DateTime.Parse(txtApplyDate.Text) > DateTime.Parse(CommonConst.ASSET_OLD_TIME))
                {
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetName = detail[0];
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTypeID = 0;
                    
                    string s = GetAssetPlaceByName(txtDispatchDepartment.Text), t;
                    try
                    {
                        s = s.Substring(s.IndexOf(":") + 1, s.IndexOf(",") - s.IndexOf(":") - 1);
                    }
                    catch
                    {
                        s = "0";
                    }
                   // t = ws.NewAdjustment(detail[6], int.Parse(s), 1, txtDispatchDepartment.Text, txtApplyDate.Text, 2, SerialNumber);
                    t = ws.AdjustmentWithEcoaCode(detail[1], int.Parse(s), 1, txtDispatchDepartment.Text, txtApplyDate.Text, 2, SerialNumber);

                    if (t.Contains("*"))
                        ViewState["AssetWrong"] = t.Replace("*", string.Empty);
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID = t;
                    if (hdIsIT.Value.Contains("1")) //是否有IT类资产
                        haveITAsset = true;
                }
                else
                {
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID = detail[6];
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetName = "";
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTypeID = int.Parse(detail[0]);
                    if (da_Dic_OfficeAutomation_AssetType_Operate.IsITAssetType(detail[0])) //是否有IT类资产
                        haveITAsset = true;
                }

                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag = detail[1];
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Number = detail[2];
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Model = detail[3];
                if (string.IsNullOrEmpty(detail[4]) || detail[4] == "详见附件")
                    dtTemp = DateTime.Parse("1900/1/1");
                else
                {
                    try
                    {
                        dtTemp = DateTime.Parse(detail[4]);
                    }
                    catch
                    {
                        dtTemp = DateTime.Parse("1900/1/1");
                    }
                }
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = dtTemp;
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue = detail[5];

                var regex = new System.Text.RegularExpressions.Regex(pattern);
                var mc = regex.Matches(t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue);
                if (mc != null && mc.Count > 0)
                {
                    //折旧价
                    SurplusValue = decimal.Parse(mc[0].Value);
                }
                else
                {
                    SurplusValue = 0;
                }

                if (result.maxSurplusValue < SurplusValue)
                {
                    result.maxSurplusValue = SurplusValue;
                }
                result.totalSurplusValue += SurplusValue;       //计算总折旧价

                if (ViewState["AssetWrong"].ToString() == "")
                    da_OfficeAutomation_Document_Scrap_Detail_Inherit.Insert(t_OfficeAutomation_Document_Scrap_Detail);
                else
                {
                    try //M_Alter：20150826 删除详情表前先释放在审中的资产
                    {
                        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit3 = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
                        DataSet dsDetail3 = new DataSet();
                        dsDetail3 = da_OfficeAutomation_Document_Scrap_Detail_Inherit3.SelectByMainID(MainID);
                        foreach (DataRow dr in dsDetail3.Tables[0].Rows)
                        {
                            wsAsset.GetAssetDic ws3 = new wsAsset.GetAssetDic();
                            ws3.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
                        }
                    }
                    catch
                    {
                    }
                    da_OfficeAutomation_Document_Scrap_Detail_Inherit.Delete(gScrapID.ToString());
                    RunJS("alert(\"" + ViewState["AssetWrong"].ToString() + "\");history.go(-1);");
                }
            }
        }

        result.haveITAsset = haveITAsset;
        return result;
    }

    #endregion

    #region 其他

    #region 获取资产类型

    /// <summary>
    /// 获取资产类型
    /// </summary>
    private void GetAssetType()
    {
        SbAtJson.Remove(0, SbAtJson.Length);
        DA_Dic_OfficeAutomation_AssetType_Operate da_Dic_OfficeAutomation_AssetType_Operate = new DA_Dic_OfficeAutomation_AssetType_Operate();
        DataSet dsAT = da_Dic_OfficeAutomation_AssetType_Operate.SelectAll();
        SbAtJson.Append("[");
        foreach (DataRow dr in dsAT.Tables[0].Rows)
        {
            SbAtJson.Append("{\"id\":\"" + dr["OfficeAutomation_AssetType_ID"] + "\",\"value\":\"" + dr["OfficeAutomation_AssetType_Name"] + "\"},");
        }
        SbAtJson.Remove(SbAtJson.Length - 1, 1);
        SbAtJson.Append("]");
    }

    #endregion

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        SbJson.Remove(0, SbJson.Length);
        wsKDHR.Service service = new wsKDHR.Service();
        DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
        SbJson.Append("[");

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

            if (!SbJson.ToString().Contains(name))
                SbJson.Append("{\"value\":\"" + name + "\"},");
        }

        SbJson.Remove(SbJson.Length - 1, 1);
        SbJson.Append("]");
    }
    #endregion

    private string GetAssetPlaceByName(string nam)
    {
        wsAsset.GetAssetDic service = new wsAsset.GetAssetDic();
        string s = service.GetKeyValue("place", nam).Replace("Dic_Assets_Id", "id").Replace("Dic_Assets_Text", "value");
        return s;
    }

    #region 生成净值知会函

    /// <summary>
    /// 生成净值知会函
    /// </summary>
    public void GenerateNotifyLetter()
    {
        //flgt = true;
        Update();

        string uploadPath = System.Configuration.ConfigurationManager.AppSettings["UploadPath"].Replace("\\", "\\\\");

        if (!Directory.Exists(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + MainID))
        {
            Directory.CreateDirectory(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + MainID);
        }

        Application wordApp = new ApplicationClass();
        object missing = System.Reflection.Missing.Value;

        object tempName = Page.Request.PhysicalApplicationPath + "Apply\\Scrap\\Temp.dot";  // 模板名称，本例中的模板如后面的图
        object docName = uploadPath + DateTime.Now.Year.ToString() + "\\" + MainID + "\\净值知会函" + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";

        Document MyDoc = wordApp.Documents.Add(ref tempName, ref missing, ref missing, ref missing);

        wordApp.Visible = true;
        MyDoc.Activate();

        wordApp.Selection.Font.Size = 20;           // 字体大小
        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;  // 居中
        wordApp.Selection.Font.Name = "宋体";
        wordApp.Selection.Font.Underline = WdUnderline.wdUnderlineSingle;

        wordApp.Selection.TypeText(this.txtDispatchDepartment.Text);

        wordApp.Selection.MoveDown(ref missing, ref missing, ref missing);
        wordApp.Selection.HomeKey(ref missing, ref missing);
        wordApp.Selection.Font.Underline = WdUnderline.wdUnderlineSingle;
        wordApp.Selection.TypeText(this.txtDispatchDepartment.Text);

        wordApp.Selection.EndKey(ref missing, ref missing);
        wordApp.Selection.TypeText("\n");

        T_OfficeAutomation_Document_Scrap t_OfficeAutomation_Document_Scrap = new T_OfficeAutomation_Document_Scrap();
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(MainID);

        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                wordApp.Selection.TypeText("\t" + dr["OfficeAutomation_AssetType_Name"].ToString() + "\t");
                wordApp.Selection.TypeText(dr["OfficeAutomation_Document_Scrap_Detail_AssetTag"].ToString() + "\t");
                wordApp.Selection.TypeText(dr["OfficeAutomation_Document_Scrap_Detail_SurplusValue"].ToString() + "\n");
            }
        }

        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
        ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);

        wordApp.Selection.MoveDown(ref missing, ref missing, ref missing);
        wordApp.Selection.MoveDown(ref missing, ref missing, ref missing);
        wordApp.Selection.EndKey(ref missing, ref missing);
        wordApp.Selection.TypeText(ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_SurplusValue"].ToString() + "元" + ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Suc"].ToString());

        // 保存word文档
        MyDoc.SaveAs(ref docName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

        // 关闭，释放
        MyDoc.Close(ref missing, ref missing, ref missing);
        wordApp.Quit(ref missing, ref missing, ref missing);
        MyDoc = null;
        wordApp = null;

        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        T_OfficeAutomation_Attach t_OfficeAutomation_Attach = new T_OfficeAutomation_Attach();
        t_OfficeAutomation_Attach.OfficeAutomation_Attach_MainID = new Guid(MainID);
        t_OfficeAutomation_Attach.OfficeAutomation_Attach_Name = "净值知会函.doc";
        t_OfficeAutomation_Attach.OfficeAutomation_Attach_Path = docName.ToString().Substring(docName.ToString().IndexOf(DateTime.Now.Year.ToString()));
        da_OfficeAutomation_Attach_Inherit.Insert(t_OfficeAutomation_Attach);
    }

    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite22"] = "1";
        Response.Write("<script>window.open('Apply_Scrap_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("报废申请表.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
    }

    /// <summary>
    /// 获取所有四级以上前线经理//789
    /// </summary>
    private void GetManagers()
    {
        wsFinance.Service service = new wsFinance.Service();
        DataSet dsManagers = service.GetManages();
        SbJsonf.Append("[");
        foreach (DataRow dr in dsManagers.Tables[0].Rows)
        {
            SbJsonf.Append("\"" + dr["EmployeeName"] + "\",");
        }
        SbJsonf.Remove(SbJsonf.Length - 1, 1);
        SbJsonf.Append("]");
    }
    protected void btnSaveLogisticsFlow_Click(object sender, EventArgs e)
    {
        if (hdLogisticsFlow.Value == "")
            return;
        T_OfficeAutomation_Document_GeneralApply_Detail t_OfficeAutomation_Document_GeneralApply_Detail;
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();

        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString(); //在不同的表要注意修改

        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Delete(ID);
        string[] details = Regex.Split(hdLogisticsFlow.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_GeneralApply_Detail = new T_OfficeAutomation_Document_GeneralApply_Detail();
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_MainID = new Guid(ID);
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Department = detail[0];
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Num = int.Parse(detail[1]);
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Branch = detail[2];
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_Cmodel = detail[3] == "1";
            t_OfficeAutomation_Document_GeneralApply_Detail.OfficeAutomation_Document_GeneralApply_Detail_IsOpen = detail[4] == "1";
            if (detail[0].ToString() != "董事总经理" && detail[0].ToString() != "总经办")
            da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.Insert(t_OfficeAutomation_Document_GeneralApply_Detail);
        }
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 130;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

        Match m = Regex.Match(txtRemainingsCostsTotal.Text, "(([1-9]\\d{0,9})|0)(\\.\\d{1,2})?");
        double d = 0;
        try
        {
            d = double.Parse(m.Value);
        }
        catch
        {
            d = 0;
        }
        if (d >= 20000)
        {
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID; //在不同的表要注意删除
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 131;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        }

        RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    }
    protected void btnWillEnd_Click(object sender, EventArgs e) //M_WinnEnd：20150204
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "0001");
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "总经办");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "董事总经理");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "董事总经理审批");
        da_OfficeAutomation_Main_Inherit.UpdateFlowStateForAudit(MainID);
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，删除流程
        RunJS("alert('已删除总经办的审批环节！');window.location='" + Page.Request.Url + "'");
    }
    protected void btnJumpEmma_Click(object sender, EventArgs e) //M_EmmaJump：20160118
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "23514");

        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

        string msnBody;
        msnBody = "您好黄瑛，由于张绍欣跳过了她的审批环节，所以现有一份《" + documentName + "》需要您来审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
        Common.SendMessageEX(true, documentName, "黄瑛", "请审理", msnBody, msnBody, MainID);

        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，删除流程
        RunJS("alert('已跳过您所在的审批环节！');window.location='" + Page.Request.Url + "'");
    }
    public void DrawAFTable(int n, bool x2, bool x3, string department)
    {
        for (int i = 1; i <= 1; i++)
        {
            int j = 0, k = 3 * n;
            if (x2 && x3)
                j = 3;
            else if ((!x2 && x3) || (x2 && !x3))
                j = 2;
            else if (!x2 && !x3)
                j = 1;
            SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
            SbHtmlLogisticsFlow.Append("<td rowspan=\"" + j + "\"  class=\"auto-style1\">" + department + "</td>");
            SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
            SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 3 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 2) + "\" />");
            SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 3 * 20 - 2) + "\">同意</label>");
            SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 3 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 2) + "\" />");
            SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 3 * 20 - 2) + "\">不同意</label>");
            SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 3 * 20 - 2) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 2) + "\" />");
            SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 3 * 20 - 2) + "\">其他意见</label>");
            SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 3 * 20 - 2) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
            SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 3 * 20 - 2) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 3 * 20 - 2) + "\')\" style=\"display: none;\" />");
            SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 3 * 20 - 2) + "\">_________</span></div>");
            SbHtmlLogisticsFlow.Append("</td>");
            SbHtmlLogisticsFlow.Append("</tr>");
            if (x2)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 3 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 1) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 3 * 20 - 1) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 3 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 1) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 3 * 20 - 1) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 3 * 20 - 1) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20 - 1) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 3 * 20 - 1) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 3 * 20 - 1) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 3 * 20 - 1) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 3 * 20 - 1) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 3 * 20 - 1) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
            if (x3)
            {
                SbHtmlLogisticsFlow.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtmlLogisticsFlow.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtmlLogisticsFlow.Append("	<input id=\"rdbYesIDx" + (k + 3 * 20) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbYesIDx" + (k + 3 * 20) + "\">同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbNoIDx" + (k + 3 * 20) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbNoIDx" + (k + 3 * 20) + "\">不同意</label>");
                SbHtmlLogisticsFlow.Append("    <input id=\"rdbOtherIDx" + (k + 3 * 20) + "\" type=\"radio\" name=\"agree" + (k + 3 * 20) + "\" />");
                SbHtmlLogisticsFlow.Append("    <label for=\"rdbOtherIDx" + (k + 3 * 20) + "\">其他意见</label>");
                SbHtmlLogisticsFlow.Append("	<textarea id=\"txtIDx" + (k + 3 * 20) + "\" rows=\"3\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtmlLogisticsFlow.Append("    <input type=\"button\" id=\"btnSignIDx" + (k + 3 * 20) + "\" value=\"签署意见\" onclick=\"sign(\'" + (k + 3 * 20) + "\')\" style=\"display: none;\" />");
                SbHtmlLogisticsFlow.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + (k + 3 * 20) + "\">_________</span></div>");
                SbHtmlLogisticsFlow.Append("</td>");
                SbHtmlLogisticsFlow.Append("</tr>");
            }
        }
        SbJs.Append("i=" + n + ";");
    }//987
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
            DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Scrap_Department"].ToString();
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
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "2,3,5,7,10,12");
                if (i < 9)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,11");
                if (i <= 14 && EmployeeID == "13545") //M_AddNWX：20150511
                {
                    da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "黄志超", "13545");
                    da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                }

                DataSet dsDetail = new DataSet();
                wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
                dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(MainID);
                foreach (DataRow dr in dsDetail.Tables[0].Rows)
                {
                    ws.RegainAdjustment(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
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
            DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Scrap_Department"].ToString();
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
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "2,10,12");
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,11");
                    da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);
                    t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                    t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                    da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);//AlterC_a
                    Common.SendDirectPushMessage(documentName, da_OfficeAutomation_Flow_Inherit.GetFirstByMainID(MainID)); //手机推送
                    RunJS("alert('所作的修改已保存！');window.location='" + Page.Request.Url + "'");
                }
                else
                {
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
            DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Scrap_Department"].ToString();
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
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "10,12");
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,11");
            //da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 8); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_Scrap_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

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
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1); //添加日志，添加流程
        RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    }
    protected void lbAddLg_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow flows;
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
        if (flows == null)
        {
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            RunJS("alert('后勤事务部的审批环节已增加。');window.location='" + Page.Request.Url + "'");
        }
        else
            RunJS("alert('后勤事务部的审批环节已增加！');window.location='" + Page.Request.Url + "'");
    }
    protected void lbDelLg_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
        RunJS("alert('已删除后勤事务部的审批环节！');window.location='" + Page.Request.Url + "'");
    }

    protected void Review(int index, string sug) //M_AddAnother：20150716 黄生其它意见，增加审批人
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        T_OfficeAutomation_Flow flowsa, flowsb, flowsh, fst4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8); //M_AlAno：20160217 ++
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
            da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, 220); //M_AlterM：20150826
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
        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
        DataSet ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_Scrap_Department"].ToString();
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
        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_Scrap_Department"].ToString();
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

    protected void btnUploadDetails_Click(object sender, EventArgs e) //M_AssetAlter：20150827
    {
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        DataSet spa = new DataSet();

        spa = da_OfficeAutomation_Attach_Inherit.GetAttachSp(MainID);
        try
        {
            SpAttachPath = spa.Tables[0].Rows[0]["OfficeAutomation_Attach_Path"].ToString();
        }
        catch
        {
        }
        SbJs.Append("<script type=\"text/javascript\">$(\"#btnSelect\").hide();$(\"#btnAddRow\").hide();$(\"#btnDeleteRow\").hide();$(\"#SuSpUl\").show();");
        SbJs.Append("$('#tabs-2').hide();$('#tabs-3').hide();");
        SbJs.Append("$(\"#lkSpUl\").show();");

        string path = hdFilePath.Value;
        if (path != "")
        {
            System.Data.OleDb.OleDbConnection ImportConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source=" + path + "; " + "Extended Properties='Excel 12.0;HDR=1; IMEX=1;'");
            System.Data.OleDb.OleDbDataAdapter ImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [格式$]", ImportConnection);
            DataSet dsADetail = new DataSet();
            int i = 0;
            try
            {
                ImportCommand.Fill(dsADetail);//*-
                ViewState["Dteail"] = dsADetail;
                ViewState["UpDetail"] = "1";
            }
            catch
            {
                da_OfficeAutomation_Attach_Inherit.DeleteAttachSp(MainID);
                Alert("格式错误，请重新下载“EXCEL版空白明细表”填写后再导入");
                SbJs.Append("history.go(-1);");
                SbJs.Append("</script>");
                return;
            }

            if (dsADetail.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string str1, str2 = "", str3, str4, str5,str6;
                    int success = 0;
                    for (i = 0; i <= dsADetail.Tables[0].Rows.Count - 1 && i < 5; i++)
                    {
                        str1 = dsADetail.Tables[0].Rows[i]["报废物品"].ToString();
                        str2 = dsADetail.Tables[0].Rows[i]["财务编号"].ToString();
                        str3 = dsADetail.Tables[0].Rows[i]["规格型号"].ToString();
                        str4 = dsADetail.Tables[0].Rows[i]["购买时间(由审批人填写)"].ToString();
                        str5 = dsADetail.Tables[0].Rows[i]["折旧摊分剩余费用(由审批人填写)"].ToString();
                        str6 = dsADetail.Tables[0].Rows[i]["二维码"].ToString();

                        //if (!string.IsNullOrEmpty(str2))
                        //{
                        success++;
                        SbJs.Append("$('#hidAssetID" + success + "').val('" + str6 + "');");
                        SbJs.Append("$('#txtAsset" + success + "').val('" + str1 + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                        SbJs.Append("$('#txtATag" + success + "').val('" + str2 + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                        SbJs.Append("$('#txtModel" + success + "').val('" + str3 + "').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                        SbJs.Append("$('#txtNumber" + success + "').val('1').css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
                        string date;
                        if (str4 != "")
                        {
                            date = DateTime.Parse(str4).ToString("yyyy-MM-dd");
                            date = date == "1900-01-01" ? "" : date;
                            date = (date == "" && str4 == "详见附件") ? "详见附件" : date;
                        }
                        else
                            date = "";
                        SbJs.Append("$('#txtBuyTime" + success + "').val('" + date + "');");
                        SbJs.Append("$('#txtRemainingCosts" + success + "').val('" + str5 + "');");
                        SbJs.Append("$('#ddlAsset" + success + "').val('0');");
                        //}
                    }

                    hdIsIT.Value = "";
                    DrawDetailTable(success,true);
                    SbJs.Append("$(\"#SuSpUl\").css(\"margin-top\",\"10px\");");
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
            //    SbJs.Append("$(\"#btnSelect\").hide();$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#SuSpUl\").show();$(\"#lkSpUl\").hide();");
            //else
            //    SbJs.Append("$(\"#btnSelect\").show();$(\"#lkSpUl\").hide();");

            SbJs.Append("history.go(-1);");
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
            bool flag4 = false;//是否已完成it报废证明填写环节
            bool flag5 = false;//是否有财务部经办人环节
            bool flag6 = false;//是否有董事总经理环节
            bool flg7 = false;//是否有后勤事务部环节

            DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();

            //自定义控件赋值
            var flowshowlist = da_OfficeAutomation_Flow_Inherit.GetFlowShowList(ds);
            this.FlowShow1.FlowShowList = flowshowlist;
            for (int i = 0; i < drc.Count; i++)
            {
                #region 显示流程示意图
                int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
                string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
                string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

                if (curidx == "2")
                    flag5 = true;

                if (curidx == "2" && EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
                    this.btnSaveSurplusValueNotify.Visible = true;

                if (curidx == "9" && drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                    flag4 = true;

                if (curidx == "10")
                    flag3 = true;

                if (curidx == "17")
                    flag6 = true;
                if (curidx == "16")
                    flg7 = true;

                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
                {
                    flag2 = false;

                    if (curemp.Contains(EmployeeName))
                    {
                        switch (curidx)
                        {
                            case "1":
                                lbAddLg1.Visible = true;
                                lbDelLg1.Visible = true;
                                this.btnRemindPhoto.Visible = true;//提醒申请人上传资产照片
                                this.btnRemindScrap.Visible = true;//提醒申请人上传报废证明
                                this.cbkToFinance.Visible = true;
                                this.cbkToIT.Visible = true;
                                this.btnSaveSurplusValueNotify.Visible = true;
                                //this.btnSave.Visible = true;

                                DataSet dsFlow = new DataSet();
                                dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                                foreach (DataRow drFlow in dsFlow.Tables[0].Rows)
                                {
                                    if (drFlow["OfficeAutomation_Flow_Idx"].ToString() == "10" || drFlow["OfficeAutomation_Flow_Idx"].ToString() == "12")
                                    {
                                        this.cbkToIT.Checked = true;
                                        break;
                                    }
                                }
                                break;
                            case "2":
                                this.btnRemindPhoto2.Visible = true;//提醒申请人上传资产照片
                                this.btnSaveSurplusValueNotify.Visible = true;
                                //this.btnSave.Visible = true;
                                lbAddLg3.Visible = true;
                                lbDelLg3.Visible = true;
                                break;
                            case "3":
                            case "5":
                            case "7":
                                //SbJsEX.Append("$('#ui-id-2').click();");
                                SbJsEX.Append("$('#Scarp_z').click();");
                                break;
                            case "9":
                            case "11":
                                //SbJs.Append("$('#tabs-1').hide();$('#tabs-3').show();");
                                SbJsEX.Append("$('#Scarp_i').click();");
                                break;
                            case "10":
                                if (!flag4)
                                {
                                    SbJs.Append("$('#divAssign').show();");
                                    this.btnAssign.Visible = true;//下派跟进人处理按钮显示
                                }
                                break;
                            case "13":
                                lbAddLg2.Visible = true;
                                lbDelLg2.Visible = true;
                                break;
                            case "14":
                                if (EmployeeID == "13545") //M_AddNWX：20150511
                                    lbtnAddN.Visible = true;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        //if (applicant == EmployeeName && curidx == "1")
                        //    this.btnRemindUploadedPhoto.Visible = this.btnRemindUploadedPhoto2.Visible = true;
                    }
                }
                #endregion

                #region 显示签名人姓名，签名图片，或签名按钮
                string[] auditorIDs = drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Split(',');
                DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                {
                    /*SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 60px; line-height: 65px; height: 2px; margin-left:80px\">"
                        + drc[i]["OfficeAutomation_Flow_Auditor"] + (drc[i]["OfficeAutomation_Flow_Employee"].ToString().Contains(drc[i]["OfficeAutomation_Flow_Auditor"].ToString()) ? "" : "(代)")
                        + "</div><img src=\"" + SignImageURL + GetGIF(employeeID) + ".gif\" height=\"60px\" />');");*/
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:0px; float:left;\">"
                        + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");//<img src=\"" + SignImageURL + GetGIF(employeeID) + ".gif\" height=\"60px\" />');");
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
                        SbJs.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                    else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                        SbJs.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                    else
                        SbJs.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");

                    if (string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                        SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').hide();");
                    else
                        SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                    SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
                }
                else
                {
                    if (auditorIDs.Length > 0 && auditorIDs[0] != "")
                    {
                        SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:20px; float:left;\">"
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
                            SbJs.Append("$('#rdbYesIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                        else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                            SbJs.Append("$('#rdbNoIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");
                        else if (drc[i]["OfficeAutomation_Flow_IsAgree"].ToString() == "2")
                            SbJs.Append("$('#rdbOtherIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').attr('checked','checked');");

                        SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString() + "');");
                        SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
                    }

                    if (idx == 2)
                        SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                    if (!string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                        SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                    //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                    if (flag && da_OfficeAutomation_Agent_Inherit.IsHaveSignPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(),
                        drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID))
                    {
                        SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').show();");
                    }

                    flag = false;
                }

                if (i >= 2 && int.Parse(drc[i]["OfficeAutomation_Flow_Idx"].ToString()) >= 200) //M_AddAnother：20150716 黄生其它意见，增加审批人
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

            bool htpd = false;
            try
            {
                if (Request.QueryString["htmltopdf"] == "Yes") //M_PDF 
                {
                    SbJs.Append("$(\"div .flow\").hide();$(\"#PageBottom\").hide();$(\"#btnPrint1\").hide();$(\"#btnPrint2\").hide();");
                    htpd = true;
                }
                else
                    SbJs.Append("$(\"#tabs\").tabs();");
            }
            catch
            {
                SbJs.Append("$(\"#tabs\").tabs();");
            }

            if (!flag3)
                SbJs.Append("$('#trIT1').hide();$('#trIT2').hide();$('#trIT3').hide();$('#trIT4').hide();");
            else if (flag3 && htpd)
                SbJs.Append("$('#ulTabs').hide();$('#tabs-2').hide();");
            else
                SbJs.Append("$('#ulTabs').show();$('#liTabs3').show();");

            if (htpd && flag5)
                SbJs.Append("$('#ulTabs').hide();$('#tabs-3').hide();");
            else if (flag5)
                SbJs.Append("$('#ulTabs').show();$('#liTabs2').show();");
            else
                SbJs.Append("$('#trMoney1').hide();$('#trMoney2').hide();");

            if (htpd && flag3 && flag5)
                SbJs.Append("$('#ulTabs').hide();$('#tabs-2').show();$('#tabs-3').show();");

            if (htpd && !flag3 && !flag5)
                SbJs.Append("$('#ulTabs').hide();$('#tabs-2').hide();$('#tabs-3').hide();");

            if (flag6)
                SbJs.Append("$('#trManager1').show();$('#trManager2').show();");
            if (flg7)
                SbJs.Append("$('#trLogistics1').show();$('#trLogistics2').show();");

            T_OfficeAutomation_Flow flows;//789
            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
            if (flows != null)
                SbJs.Append("$('#trLogistics1').hide();$('#trLogistics2').hide();$('#trManager1').hide();$('#trManager2').hide();$('#tlsc1').show();$('#tlsc2').show();");

            //流程为未审核状态，且登录人为申请人或行政部经办人。
            string flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
            if (flowState == "1" || EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
                this.FlowShow1.ShowEditBtn = true;
            //if (flowState == "2" && /*applicant == EmployeeName ||*/ EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME && !htpd) //20141215：M_AlterC
            //    btnEditFlow2.Visible = true;

            if (EmployeeID == "10054" || EmployeeID == "34498") //M_WinnEnd：20150204
            {
                btnWillEnd.Visible = true;
                btnWillEnd2.Visible = true;
            }

            //20170206注释
            //if (EmployeeName == "张绍欣") //M_EmmaJump：20160118
            //    btnShouldJumpIDxEmma.Visible = true;

            flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndEID(MainID, "0001");
            if (flows == null)
                SbJs.Append("$('#trManager1').hide();$('#trManager2').hide();$('#tlsc2').hide();"); //trManager1 trGeneralManager

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

            SbJs.Append("$(\"[id*=txtBuyTime]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtRemainingCosts]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtAsset]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtNumber]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");$(\"[id*=txtModel]\").css(\"background-color\",\"#e3e3e3\").attr(\"readonly\",\"readonly\");");
            #endregion

            SbJs.Append("$.each($(\"textarea:not([id*=txtDescribe])\"), function (idx, item) { autoTextarea(this); });");
        }
        SbJs.Append("</script>");
    }

    private void AddSkyFlow(InsertScrapDetailBack result)
    {
        var da_OfficeAutomation_Flow_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit();
        var t_OfficeAutomation_Flow = new DataEntity.T_OfficeAutomation_Flow();
        //20160511 SYSREQ201605101532160391670
        //折旧总加>2w 增加sky 黄生审批流程
        if (result.totalSurplusValue > 20000)
        {
            //sky 增加审核流程
            T_OfficeAutomation_Flow temp = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
            if (temp == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }

            //增加黄生审核流程
            temp = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
            if (temp == null)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 17;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
            }
        }
        else if (result.totalSurplusValue <= 20000)
        {
            //资产报废净值 <= 1000 只需固定流程idx=13审核 无需idx=16、17审核 
            if (result.maxSurplusValue <= 1000)
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16,17");
            }
            else if (result.maxSurplusValue > 1000)
            {
                //资产报废净值>1000 需要增加idx=16审核，无需idx=17审核
                T_OfficeAutomation_Flow temp = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
                if (temp == null)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "17");
            }
            //20160511 SYSREQ201605101532160391670 end
        }
        else
        {
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16,17");
        }
    }
}

public class InsertScrapDetailBack
{
    //是否it部资产
    public bool haveITAsset { get; set; }
    //折旧总结
    public decimal totalSurplusValue { get; set; }
    //最高折旧价
    public decimal maxSurplusValue { get; set; }
}
