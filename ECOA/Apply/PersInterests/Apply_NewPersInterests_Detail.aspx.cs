﻿using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using System.IO;

using DataAccess.Operate;
using DataEntity;

using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;
using System.Collections;//789

using System.Diagnostics; //M_PDF
using System.Web;

public partial class Apply_NewPersInterests_Apply_NewPersInterests_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();
    public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#divUploadDetailed\").show();";
    List<string> OneTypes = new List<string>{"","亲兄弟", "亲兄妹", "亲姐妹", "亲姐弟", "夫妻", "父女", "父子", "母女", "母子"};
    List<string> TwoTypes = new List<string> {"堂兄弟", "堂兄妹", "堂姐弟", "堂姐妹", "表兄弟", "表兄妹", "表姐弟", "表姐妹", "其他" };

    /// <summary>
    /// 申请人是否为直属黄生的人员
    /// </summary>
    public bool isImmediste = false;

    //public string[] sHRTree = null;

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

        //MainID = GetQueryString("MainID");
        string UrlMainID = GetQueryString("MainID");
        
        SerialNumber = "";

        InitPage();

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
                if (Session["FLG_ReWrite54"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite54"] = null;
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
                NewPage();
            
        }       
        else
            GetAllDepartment();
    }

    /// <summary>
    /// 新页面
    /// </summary>
    public void NewPage()
    {
        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        lblApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        txtApplyForDate.Text = lblApplyDate.Text;

        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);
        DrawDetailTable(1);
        SbJs.Append("</script>");
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
        DataSet ds = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentID(8);

        DropDownListBind(ddlDepartmentType, ds.Tables[0], "OfficeAutomation_DepartmentType_ID", "OfficeAutomation_DepartmentType_Name", "0", "--请选择部门性质--");

        DA_Dic_OfficeAutomation_PersInterestsType_Operate da_Dic_OfficeAutomation_PersInterestsType_Operate = new DA_Dic_OfficeAutomation_PersInterestsType_Operate();
        ds = da_Dic_OfficeAutomation_PersInterestsType_Operate.SelectAll();

        DropDownListBind(ddlInterestsType, ds.Tables[0], "OfficeAutomation_PersInterestsType_ID", "OfficeAutomation_PersInterestsType_Name", "0", "--请选择利益申报类别--");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
        DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit da_OfficeAutomation_Document_NewPersInterests_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit();

        string flowState;
        try
        {
             flowState= da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
        }
        catch
        {
            Alert(CommonConst.MSG_URL_DISABLE);
            RunJS("window.location='/Apply/Apply_Search.aspx'");
            return;
        }

        SbJs.Append("<script type=\"text/javascript\">");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_NewPersInterests_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_NewPersInterests_Apply"].ToString();
        string Craeter = dr["OfficeAutomation_Main_Creater"].ToString();
        ApplyN = applicant;

        if (dr["OfficeAutomation_Document_NewPersInterests_DepartmentTypeID"].ToString() == "1" || dr["OfficeAutomation_Document_NewPersInterests_DepartmentTypeID"].ToString() == "3" || dr["OfficeAutomation_Document_NewPersInterests_DepartmentTypeID"].ToString() == "5") {
            DA_Dic_OfficeAutomation_DepartmentType_Operate da_Dic_OfficeAutomation_DepartmentType_Operate = new DA_Dic_OfficeAutomation_DepartmentType_Operate();
            DataSet dstype = da_Dic_OfficeAutomation_DepartmentType_Operate.SelectByDocumentIDCompatible(8,int.Parse(dr["OfficeAutomation_Document_NewPersInterests_DepartmentTypeID"].ToString()));

            DropDownListBind(ddlDepartmentType, dstype.Tables[0], "OfficeAutomation_DepartmentType_ID", "OfficeAutomation_DepartmentType_Name", "0", "--请选择部门性质--");
        
        }
    
        ddlDepartmentType.SelectedValue = dr["OfficeAutomation_Document_NewPersInterests_DepartmentTypeID"].ToString();

        if ("1" == dr["OfficeAutomation_Document_NewPersInterests_IsInApply"].ToString())
       {
           this.rbInApply.Checked = true;
       }
        else if ("0" == dr["OfficeAutomation_Document_NewPersInterests_IsInApply"].ToString())
        {
            this.rbNoInApply.Checked = true;
        }
        txtRelationship1.Text = dr["OfficeAutomation_Document_NewPersInterests_Relationship1"].ToString();
        
        if ("1" == dr["OfficeAutomation_Document_NewPersInterests_IsCompanyStaff"].ToString())
        {
            rbCompanyStaff.Checked = true;
        }
        else if ("0" == dr["OfficeAutomation_Document_NewPersInterests_IsCompanyStaff"].ToString())
        {
            rbNoCompanyStaff.Checked = true;
        }
        txtTfid2.Text = dr["OfficeAutomation_Document_NewPersInterests_Department"].ToString();

        txtTfid1.Text = dr["OfficeAutomation_Document_NewPersInterests_txtTfid1"].ToString();
        txtTfid3.Text = dr["OfficeAutomation_Document_NewPersInterests_possition"].ToString();
        txtTfid4.Text = dr["OfficeAutomation_Document_NewPersInterests_EntryDate"].ToString();
        txtTfid5.Text = dr["OfficeAutomation_Document_NewPersInterests_ProbationDate"].ToString();
        txtApplyFor.Text = dr["OfficeAutomation_Document_NewPersInterests_Apply"].ToString();
        this.txtApplyForID.Text = dr["OfficeAutomation_Document_NewPersInterests_ApplyForID"].ToString();
        this.txtApplyForDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_NewPersInterests_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        lblApply.Text = dr["OfficeAutomation_Document_NewPersInterests_ApplyID"].ToString();
        lblApplyDate.Text = txtApplyForDate.Text;
        int intereststypeid =Convert.ToInt32(dr["OfficeAutomation_Document_NewPersInterests_InterestsTypeID"].ToString());
        ddlInterestsType.SelectedValue = intereststypeid == 1 ? "7" : intereststypeid == 2 ? "9" : intereststypeid == 3 ? "9" : intereststypeid == 4 ? "8" : intereststypeid == 5 ? "10" : intereststypeid == 6 ? "11" : intereststypeid.ToString();
        txtPhone.Text = dr["OfficeAutomation_Document_NewPersInterests_Phone"].ToString();

        string cbt = dr["OfficeAutomation_Document_NewPersInterests_ApplyContent"].ToString();
        if (cbt.Contains("1"))
        {
            cbApplyContent1.Checked = true;
        }
        if (cbt.Contains("2"))
        {
            cbApplyContent2.Checked = true;
        }
        if (cbt.Contains("3"))
        {
            cbApplyContent3.Checked = true;
        }
        if (cbt.Contains("4"))
        {
            cbApplyContent4.Checked = true;
        }
        if (cbt.Contains("5"))
        {
            cbApplyContent5.Checked = true;
        }
        if (cbt.Contains("6"))
        {
            cbApplyContent6.Checked = true;
        }

        switch (dr["OfficeAutomation_Document_NewPersInterests_DealKind"].ToString())//1++
        {
            case "1":
                rdbDealKind1.Checked = true;
                break;
            case "2":
                rdbDealKind2.Checked = true;
                break;
            case "3":
                rdbDealKind3.Checked = true;
                break;
            case "4":
                rdbDealKind4.Checked = true;
                break;
            default:
                break;
        }
        if (rdbDealKind1.Checked == true) {
            rdbDealKind1.Visible = true;
            rdbDealKind3.Visible = false;
            rdbDealKind4.Visible = false;
        }
        switch (dr["OfficeAutomation_Document_NewPersInterests_DealProperty"].ToString())
        {
            case "1":
                rdbDealProperty1.Checked = true;
                break;
            case "2":
                rdbDealProperty2.Checked = true;
                break;
            default:
                break;
        }
        txtFollowerNo.Text = dr["OfficeAutomation_Document_NewPersInterests_FollowerNo"].ToString();
        switch (dr["OfficeAutomation_Document_NewPersInterests_PropertyHander"].ToString())
        {
            case "1":
                rdbPropertyHander1.Checked = true;
                break;
            case "2":
                rdbPropertyHander2.Checked = true;
                break;
            case "3":
                rdbPropertyHander3.Checked = true;
                break;
            default:
                break;
        }
        txtMeAndHim.Text = dr["OfficeAutomation_Document_NewPersInterests_MeAndHim"].ToString();
        txtRelationship.Text = dr["OfficeAutomation_Document_NewPersInterests_Relationship"].ToString();
        txtRelationName.Text = dr["OfficeAutomation_Document_NewPersInterests_RelationName"].ToString();
        txtBuilding.Text = dr["OfficeAutomation_Document_NewPersInterests_Building"].ToString();
        DeclaredNum.InnerText = dr["OfficeAutomation_Document_NewPersInterests_AddressNum"].ToString();
        txtSquare.Text = dr["OfficeAutomation_Document_NewPersInterests_Square"].ToString();
        txtPriceScope.Text = dr["OfficeAutomation_Document_NewPersInterests_PriceScope"].ToString();
        txtLeaseTerm.Text = dr["OfficeAutomation_Document_NewPersInterests_LeaseTerm"].ToString();
        switch (dr["OfficeAutomation_Document_NewPersInterests_PayWay"].ToString())
        {
            case "1":
                rdbPayWay1.Checked = true;
                break;
            case "2":
                rdbPayWay2.Checked = true;
                break;
            default:
                break;
        }
        txtRequirements.Text = dr["OfficeAutomation_Document_NewPersInterests_Requirements"].ToString();
        switch (dr["OfficeAutomation_Document_NewPersInterests_FollowWay"].ToString())
        {
            case "1":
                rdbFollowWay1.Checked = true;
                break;
            case "2":
                rdbFollowWay2.Checked = true;
                break;
            default:
                break;
        }//++1

        DataSet dsd = da_OfficeAutomation_Document_NewPersInterests_Detail_Inherit.SelectByID(ID);//2++
        DataRow drd = ds.Tables[0].Rows[0];
        int detailCount = dsd.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable(1);
        else
        {
            DrawDetailTable(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                drd = dsd.Tables[0].Rows[n];
                int i = n + 1;
                if ("1" == drd["OfficeAutomation_Document_NewPersInterests_Detail_rdInApply"].ToString())
                {
                    SbJs.Append("$('#txtDetail_rdInApply" + i + "').prop('checked','checked');");
                    SbJs.Append("$('#txtDetail_txtApplyForID" + i + "').val('" + drd["OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID"] + "');");
                    SbJs.Append("$('#txtDetail_rbNoInApply" + i + "').prop('checked','');");
                }
                else if ("0" == drd["OfficeAutomation_Document_NewPersInterests_Detail_rdInApply"].ToString())
                {
                    SbJs.Append("$('#txtDetail_rdInApply" + i + "').prop('checked','');");
                    SbJs.Append("$('#txtDetail_rbNoInApply" + i + "').prop('checked','checked');");
                }
                else {

                    SbJs.Append("$('#txtDetail_rdInApply" + i + "').prop('checked','');");
                    SbJs.Append("$('#txtDetail_rbNoInApply" + i + "').prop('checked','');");
                }
                SbJs.Append("$('#txtDetail_RelativesName" + i + "').val('" + drd["OfficeAutomation_Document_NewPersInterests_Detail_RelativesName"] + "');");
                SbJs.Append("$('#txtDetail_InDepartment" + i + "').val('" + drd["OfficeAutomation_Document_NewPersInterests_Detail_InDepartment"] + "');");
                SbJs.Append("$('#txtDetail_Position" + i + "').val('" + drd["OfficeAutomation_Document_NewPersInterests_Detail_Position"] + "');");
                SbJs.Append("$('#txtDetail_txtTfid" + i + "').val('" + drd["OfficeAutomation_Document_NewPersInterests_Detail_txtTfid"] + "');");
                string relationship = drd["OfficeAutomation_Document_NewPersInterests_Detail_Relationship"].ToString();
                if (OneTypes.Contains(relationship)) 
                {
                    if (relationship != "")
                    {
                        SbJs.Append(" $(\"#relationshipOne" + i + "\").val(\"直系亲属\");");
                        SbJs.Append(" $(\"#relationshipTwo" + i + "\").val(\"" + relationship + "\");");
                    }
                    else {
                        SbJs.Append("  $(\"#relationshipTwo" + i + "\").empty();");
                    }
                   
                }
                else if (TwoTypes.Contains(relationship))
                {

                    SbJs.Append("  $(\"#relationshipTwo" + i + "\").empty();");
                    foreach (var item in TwoTypes)
                    {

                        SbJs.Append(" $(\"<option value='" + item + "'>" + item + "</option>\").appendTo(\"#relationshipTwo" + i + "\");");
                    }
                    SbJs.Append(" $(\"#relationshipOne" + i + "\").val(\"次直系亲属\");");
                    SbJs.Append(" $(\"#relationshipTwo" + i + "\").val(\"" + relationship + "\");");
                }
                else {
                    SbJs.Append(" $(\"#relationshipOne" + i + "\").val(\"其他\");");

                    
                        SbJs.Append("  $(\"#relationshipTwo"+i+"\").empty();");
                        foreach (var item in TwoTypes) {

                            SbJs.Append(" $(\"<option value='"+item+"'>"+item+"</option>\").appendTo(\"#relationshipTwo"+i+"\");");
                        }

                    SbJs.Append(" $(\"#relationshipTwo" + i + "\").val(\"其他\");");
                   
                    SbJs.Append(" $(\"#txtDetail_Relationship" + i + "\").css('display','');");
                }
                SbJs.Append("$('#txtDetail_Relationship" + i + "').val('" + drd["OfficeAutomation_Document_NewPersInterests_Detail_Relationship"] + "');");
            }
        }//++2

        switch (dr["OfficeAutomation_Document_NewPersInterests_ApplySomething"].ToString())//3++
        {
            case "1":
                rdbApplySomething1.Checked = true;
                break;
            case "2":
                rdbApplySomething2.Checked = true;
                break;
            case "3":
                rdbApplySomething3.Checked = true;
                break;
            default:
                break;
        }
        txtGiftName.Text = dr["OfficeAutomation_Document_NewPersInterests_GiftName"].ToString();
        txtGiftPrice.Text = dr["OfficeAutomation_Document_NewPersInterests_GiftPrice"].ToString();
        txtCrashOrCard.Text = dr["OfficeAutomation_Document_NewPersInterests_CrashOrCard"].ToString();
        txtAnotherName.Text = dr["OfficeAutomation_Document_NewPersInterests_AnotherName"].ToString();
        txtAnotherPrice.Text = dr["OfficeAutomation_Document_NewPersInterests_AnotherPrice"].ToString();
        txtGiverOrCompany.Text = dr["OfficeAutomation_Document_NewPersInterests_GiverOrCompany"].ToString();//++3

        switch (dr["OfficeAutomation_Document_NewPersInterests_Entrust"].ToString())//4++
        {
            case "1":
                rdbEntrust1.Checked = true;
                break;
            case "2":
                rdbEntrust2.Checked = true;
                break;
            default:
                break;
        }
        switch (dr["OfficeAutomation_Document_NewPersInterests_BuildingKind"].ToString())
        {
            case "1":
                rdbBuildingKind1.Checked = true;
                break;
            case "2":
                rdbBuildingKind2.Checked = true;
                break;
            case "3":
                rdbBuildingKind3.Checked = true;
                break;
            default:
                break;
        }
        txtAnotherBuilding.Text = dr["OfficeAutomation_Document_NewPersInterests_AnotherBuilding"].ToString();
        txtEntrustNo.Text = dr["OfficeAutomation_Document_NewPersInterests_EntrustNo"].ToString();//++4

        switch (dr["OfficeAutomation_Document_NewPersInterests_AnotherActivity"].ToString())//5++
        {
            case "1":
                rdbAnotherActivity1.Checked = true;
                break;
            case "2":
                rdbAnotherActivity2.Checked = true;
                break;
            default:
                break;
        }
        txtInvestment.Text = dr["OfficeAutomation_Document_NewPersInterests_Investment"].ToString();
        txtIpossition.Text = dr["OfficeAutomation_Document_NewPersInterests_Ipossition"].ToString();//++5

        txtAnotherSummary.Text = dr["OfficeAutomation_Document_NewPersInterests_AnotherSummary"].ToString();//6++++6

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        bool isCraeter= EmployeeName ==Craeter;
        if (isApplicant || isCraeter)
        {
            //SbJs.Append("$(\"#btnUpload\").show();");
            if (flowState == "1")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                SbJs.Append(ApplyDisplayPart);
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
                SbJs.Append(ApplyDisplayPart);
            }

        }
        //if ((EmployeeName == "杨斯敏" || EmployeeName == "林亦玲" || EmployeeName == "郑纯宁") && flowState != "3")
        //{
        //    this.addhq.Visible = true;
        //    this.cleanhq.Visible = true;
        //    SbJs.Append("$(\"#addSpan\").show();");
        //    //SbJs.Append("$('#addSpan').show();");
        //}

        //2019-08-19 业务调整，杨斯敏 改成 岑嘉琦
        if ((EmployeeName == "岑嘉琦" || EmployeeName == "林亦玲" || EmployeeName == "郑纯宁") && flowState != "3")
        {
            this.addhq.Visible = true;
            this.cleanhq.Visible = true;
            SbJs.Append("$(\"#addSpan\").show();");
            //SbJs.Append("$('#addSpan').show();");
        }

        try //M_AddAnother：20150716 黄生其它意见，增加审批人
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
            DataSet dsFlow2 = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);
            DataRowCollection drcz = dsFlow2.Tables[0].Rows;
            T_OfficeAutomation_Flow flowsa, flowst, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 3);
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

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        //if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
        //    btnSignSave.Visible = true;
         
        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
                SbJs.Append("</script>");
                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                //DrawDetailTable(1);
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtApplyForDate.Text = lblApplyDate.Text;
                flowState = "1";
                btnSAlterC.Visible = false;
                btnSave.Visible = true;
                IsNewApply = true;
                MainID = Guid.NewGuid().ToString();
                return;
            }
        }
        catch
        {
            if (isApplicant)
                btnReWrite.Visible = true; //*-+
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
        bool flag3 = false;//是否有后勤事务部
        bool flag4 = false;//董事总经理环节
        bool flag5 = false;//苏玲环节
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
        
        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("审批流程:");
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            if (curidx == "17")
                flag3 = true;
            if (curidx == "18")
                flag4 = true;
            if (curidx == "10")
                flag5 = true;
            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                SbFlow.Append("auditing\">待" + curemp + "审理");

                flag2 = false;

                if (curemp.Contains(EmployeeName))
                {
                    //switch (curidx)
                    //{
                    //    case "10":
                    //        ckbAddIDx10.Visible = true;
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
            else
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                    SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Auditor"] + "已完成审理");
                else
                    SbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Employee"]);
            }
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
                SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:0px;\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                foreach (string s in auditorIDs)
                {
                    if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                    {
                        SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                    }
                    SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" style=\"margin-left:10px;margin-top:20px;\" />");
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
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 65px; height: 2px; margin-left:20px;\">"
                                       + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" style=\"margin-left:10px;margin-top:20px;\" />");
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

        //如果有后勤事务部流程及董事总经理流程，则显示后勤事务部内容及董事总经理内容
        if (flag3)
            SbJs.Append("$('#trLogistics').show();");
        if (flag4)
            SbJs.Append("$('#trGeneralManager').show();");
        if (flag5)
            SbJs.Append("$('#trYY').show();");

        T_OfficeAutomation_Flow flows,flows1;//789
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        if (flows != null)
            SbJs.Append("$('#trLogistics').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && (applicant == EmployeeName || Craeter == EmployeeName))
            SbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && (applicant == EmployeeName || Craeter == EmployeeName) && !tpdf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;
        SbFlow.Append("</div>");

        if (EmployeeID == "10054" || EmployeeID == "34498") //M_WinnEnd：20150204
        {
            btnWillEnd.Visible = true;
            btnWillEnd2.Visible = true;
        }

        //20170206修改  注释Emma的审批
        //if (EmployeeName == "张绍欣") //M_EmmaJump：20160118
        //    btnShouldJumpIDxEmma.Visible = true;

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndEID(MainID, "0001");
        if (flows == null)
            SbJs.Append("$('#trGeneralManager').hide();$('#tlsc2').hide();");
        flows1 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 8);
        if (flows1 != null)
        {
            SbJs.Append("$('#trOrder').show();");
            txtHeaderIDx3.Text = flows1.OfficeAutomation_Flow_Employee.ToString();
        }
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

        //if (DateTime.Parse(lblApplyDate.Text) > DateTime.Parse("2015-03-20 11:35:00.000"))
        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "5"); //M_Del21392：20150320

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

    public void DrawDetailTable(int n)
    {
        DataSet dsApplyDetail = new DataSet();
        DataSet dsApplyType = new DataSet();

        DA_Dic_OfficeAutomation_ApplyDetail_Operate da_Dic_OfficeAutomation_ApplyDetail_Operate = new DA_Dic_OfficeAutomation_ApplyDetail_Operate();
        dsApplyDetail = da_Dic_OfficeAutomation_ApplyDetail_Operate.SelectAll(1);
        DA_Dic_OfficeAutomation_ApplyType_Operate da_Dic_OfficeAutomation_ApplyType_Operate = new DA_Dic_OfficeAutomation_ApplyType_Operate();
        dsApplyType = da_Dic_OfficeAutomation_ApplyType_Operate.SelectAll();

        for (int i = 1; i <= n; i++)
        {

            /// 
            //SbHtml.Append("<tr id=\"trDetail" + i + "\">");
            SbHtml.Append("<tr class=\"trDetail\">");
            SbHtml.Append("<td class=\"tl PL10\" style=\"line-height: 30px\" >");
            //加
            SbHtml.Append("<input type=\"radio\" id=\"txtDetail_rdInApply" + i + "\" name=\"rdApply" + i + "\"/>在职/劳务,工号<input type=\"text\" id=\"txtDetail_txtApplyForID" + i + "\" style=\"width:50px\" onblur=\"getCommEmployee(this," + i + ");\"/>");
            SbHtml.Append("<input type=\"radio\" id=\"txtDetail_rbNoInApply" + i + "\" name=\"rdApply" + i + "\"/>尚未入职<br/>");
            SbHtml.Append("亲属姓名：<input type=\"text\" id=\"txtDetail_RelativesName" + i + "\" style=\"width:150px;\"/>");
            SbHtml.Append("　所在部门：<input type=\"text\" id=\"txtDetail_InDepartment" + i + "\" style=\"width:200px;\"/><br />");
            SbHtml.Append("担任职位：<input type=\"text\" id=\"txtDetail_Position" + i + "\" style=\"width:200px;\"/>");
            //加
            SbHtml.Append("身份证：<input type=\"text\" id=\"txtDetail_txtTfid" + i + "\" style=\"width:200px;\"/> <br/>");
            SbHtml.Append("亲属关系：<select id=\"relationshipOne" + i + "\" onchange=\"relationshipOneOnchange(this)\" style=\"width:100px;\"><option value =\"\"></option><option value =\"直系亲属\">直系亲属</option><option value =\"次直系亲属\">次直系亲属</option><option value=\"其他\">其他</option></select>");
            SbHtml.Append("<select id=\"relationshipTwo" + i + "\" onchange=\"relationshipTwoOnchange(this)\" style=\"width:100px;\"><option value =\"\"></option><option value =\"亲兄弟\">亲兄弟</option><option value =\"亲兄妹\">亲兄妹</option><option value =\"亲姐妹\">亲姐妹</option><option value =\"亲姐弟\">亲姐弟</option><option value =\"夫妻\">夫妻</option><option value =\"父女\">父女</option><option value =\"父子\">父子</option><option value =\"母女\">母女</option><option value =\"母子\">母子</option></select>");
            SbHtml.Append(" <input type=\"text\"  id=\"txtDetail_Relationship" + i + "\" style=\"width:150px;display:none\"/></td>");
			SbHtml.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
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
        T_OfficeAutomation_Document_NewPersInterests t_OfficeAutomation_Document_NewPersInterests = new T_OfficeAutomation_Document_NewPersInterests();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1") 
            {
                //MainID = "";//*+
                IsNewApply = true;
            }
        }
        catch
        {
        }

        try
        {
            //if (MainID == "")
            //{
            if (IsNewApply)
            {
                #region 新建
                IsNewApply = false;
                DataSet ds = new DataSet();

                //string[] sHRTree = null;
                //try
                //{
                //    sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                //}
                //catch
                //{
                //    Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                //    return;
                //}

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "NewPersInterests" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 49; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                t_OfficeAutomation_Document_NewPersInterests = GetModelFromPage(Guid.NewGuid());

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtTfid2.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtBuilding.Text;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_NewPersInterests_Inherit.Insert(t_OfficeAutomation_Document_NewPersInterests);//插入申请表
                InsertNewPersInterestsDetail(t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_ID); //新增详情表

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

                //如果申请人为直属上司为黄生的人员，则添加2步流程：7后勤事务部经理，8董事总经理
                string[] immediateboss = CommonConst.EMP_IMMEDIATEBOSS_NAME.Split('|');

                foreach (string boss in immediateboss)
                {
                    if (txtApplyFor.Text == boss)
                    {
                        isImmediste = true;
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 7;

                        //da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "46156";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "苏玲";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 18;

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(MainID);

                        string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);

                        //通知HR经办人审核
                        string email = CommonConst.EMP_HR_OPERATOR_NAME;
                        string messageBody = "您好，" + CommonConst.EMP_HR_OPERATOR_NAME + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。申请表地址为：" + Page.Request.Url.ToString();
                        Common.SendMessageEX(false, email, "请审批", messageBody, messageBody);

                        break;
                    }
                }

                #endregion

                #endregion

                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "5"); //M_Del21392：20150320

                Common.AddLog(EmployeeID, EmployeeName, 53, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_PersInterests_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=340px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
            Alert("保存失败！" + ex.Message);
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
            Common.AddLog(EmployeeID, EmployeeName, 53, new Guid(MainID), 8);
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
        DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
        DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit da_OfficeAutomation_Document_NewPersInterests_Detail_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_NewPersInterests_ID"].ToString(); 
        
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

                //if (flowIDx == "10")
                //{
                //    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                //    if (ckbAddIDx10.Checked)//增加审批环节是否勾选，如果是则添加第11步黄志超审批
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;

                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                //如果为第0步流程则为其一审核即可通过，其他为同时审核。
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "0" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_NewPersInterests_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_NewPersInterests_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + hdApply.Value);
                    sbMailBody.Append("<br/>发文部门：" + drRow["OfficeAutomation_Document_NewPersInterests_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_NewPersInterests_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>身份证号：" + txtTfid1.Text);
                    sbMailBody.Append("<br/>联系电话：" + txtPhone.Text);
                    sbMailBody.Append("<br/>部门分行：" + txtTfid2.Text);
                    sbMailBody.Append("<br/>职位：" + txtTfid3.Text);
                    sbMailBody.Append("<br/>入职日期：" + txtTfid4.Text);
                    sbMailBody.Append("<br/>通过试用期日期：" + txtTfid5.Text);
                    sbMailBody.Append("<br/>利益申报类别：" + ddlInterestsType.SelectedItem.Text);
                    sbMailBody.Append("<br/><br/>");

                    //sbMailBody.Append("<br/>详细情况：<br/>");

                    //ds = da_OfficeAutomation_Document_NewPersInterests_Detail_Inherit.SelectByMainID(MainID);
                    //foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                    //    sbMailBody.Append("<br/>第" + dr["OfficeAutomation_Document_NewPersInterests_Detail_No"].ToString() + "条的");
                    //    sbMailBody.Append("第" + dr["OfficeAutomation_Document_NewPersInterests_Detail_Point"].ToString() + "点");
                    //    sbMailBody.Append("(条款名：" + dr["OfficeAutomation_Document_NewPersInterests_Detail_Terms"].ToString() + ")");
                    //    sbMailBody.Append("<br/>");
                    //}

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
                                        msnBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        email = employnames[i];
                                        if (hdIsAgree.Value == "2")
                                            Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                        else
                                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                        employeeList += employnames[i] + "||";
                                    }
                                }
                            }
                            if (EmployeeID == "0001")
                                employeeList += "黄轩明" + "||";

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）梁晶晶（工号：32188）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            if(employeeList.Contains("黄轩明"))
                                employname = CommonConst.EMP_GMO_NAME + ",李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                            else
                                employname = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
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
                            msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            email = apply;
                            Common.SendMessageEX(false, email, "申请已通过" + EmployeeName + "的审理", msnBody, msnBody);

                            //通知下一步需要审批的人员
                            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
                            if (!employname.Contains(EmployeeName))
                            {
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    msnBody = "您好，" + employnames[i] + "：您有" + department
                                        + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody, MainID);
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
                                    msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody + mailBody, msnBody);
                                }
                            }
                        }

                        RunJS("alert('审批成功！');window.location='" + Page.Request.Url + "'");
                    }
                    else //不同意
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 5);//添加日志，签名不同意

                        //通知申请人
                        msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                        email = apply;
                        Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", msnBody, msnBody);

                        //通知已审批的人员
                        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                msnBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + hdSuggestion.Value + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
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
        //try
        //{
        //    DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_NewPersInterests_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
        //    Alert("标记成功。");
        //}
        //catch
        //{
        //    Alert("标记失败。");
        //}
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

    #region 从页面中获得model

    private T_OfficeAutomation_Document_NewPersInterests GetModelFromPage(Guid UndertakeProjID)
    {
        DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_NewPersInterests_Inherit();
        T_OfficeAutomation_Document_NewPersInterests t_OfficeAutomation_Document_NewPersInterests = new T_OfficeAutomation_Document_NewPersInterests();
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_ID = UndertakeProjID;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_IsInApply = this.rbInApply.Checked ? "1" : "0";//申请人是否在职
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Relationship1 = txtRelationship1.Text;//本人及联名人关系
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_IsCompanyStaff = rbCompanyStaff.Checked ? "1" : "0";//业权联名人是否同为公司员工
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Apply = txtApplyFor.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_txtTfid1 = txtTfid1.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_possition = txtTfid3.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_EntryDate = txtTfid4.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_ProbationDate = txtTfid5.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_ApplyID = lblApply.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Department = txtTfid2.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_DepartmentTypeID = int.Parse(hdDepartmentType.Value);
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_InterestsTypeID = int.Parse(hdInterestsType.Value);
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_ApplyForID = txtApplyForID.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Phone = txtPhone.Text;

        string cbt = "";
        if (cbApplyContent1.Checked == true)
            cbt = "|1";
        if (cbApplyContent2.Checked == true)
            cbt += "|2";
        if (cbApplyContent3.Checked == true)
            cbt += "|3";
        if (cbApplyContent4.Checked == true)
            cbt += "|4";
        if (cbApplyContent5.Checked == true)
            cbt += "|5";
        if (cbApplyContent6.Checked == true)
            cbt += "|6";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_ApplyContent = cbt;

        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_DealKind = rdbDealKind1.Checked ? "1" : rdbDealKind2.Checked ? "2" : rdbDealKind3.Checked ? "3" : rdbDealKind4.Checked ? "4" : "0";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_DealProperty = rdbDealProperty1.Checked ? "1" : rdbDealProperty2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_FollowerNo = txtFollowerNo.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_PropertyHander = rdbPropertyHander1.Checked ? "1" : rdbPropertyHander2.Checked ? "2" : rdbPropertyHander3.Checked ? "3" : "0";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_MeAndHim = txtMeAndHim.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Relationship = txtRelationship.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_RelationName = txtRelationName.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Building = txtBuilding.Text.Trim();
        if (!string.IsNullOrEmpty(txtBuilding.Text.Trim()))//物业地址
        {
            t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_AddressNum = (da_OfficeAutomation_Document_NewPersInterests_Inherit.SearchBuildingNum(txtBuilding.Text.Trim(), MainID) + 1).ToString();
        }
        else {
            t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_AddressNum = "0";
        }
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Square = txtSquare.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_PriceScope = txtPriceScope.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_LeaseTerm = txtLeaseTerm.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_PayWay = rdbPayWay1.Checked ? "1" : rdbPayWay2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Requirements = txtRequirements.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_FollowWay = rdbFollowWay1.Checked ? "1" : rdbFollowWay2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_ApplySomething = rdbApplySomething1.Checked ? "1" : rdbApplySomething2.Checked ? "2" : rdbApplySomething3.Checked ? "3" : "0";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_GiftName = txtGiftName.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_GiftPrice = txtGiftPrice.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_CrashOrCard = txtCrashOrCard.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_AnotherName = txtAnotherName.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_AnotherPrice = txtAnotherPrice.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_GiverOrCompany = txtGiverOrCompany.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Entrust = rdbEntrust1.Checked ? "1" : rdbEntrust2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_BuildingKind = rdbBuildingKind1.Checked ? "1" : rdbBuildingKind2.Checked ? "2" : rdbBuildingKind3.Checked ? "3" : "0";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_AnotherBuilding = txtAnotherBuilding.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_EntrustNo = txtEntrustNo.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_AnotherActivity = rdbAnotherActivity1.Checked ? "1" : rdbAnotherActivity2.Checked ? "2" : "0";
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Investment = txtInvestment.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_Ipossition = txtIpossition.Text;
        t_OfficeAutomation_Document_NewPersInterests.OfficeAutomation_Document_NewPersInterests_AnotherSummary = txtAnotherSummary.Text;
      
        return t_OfficeAutomation_Document_NewPersInterests;
    }

    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_NewPersInterests t_OfficeAutomation_Document_NewPersInterests = new T_OfficeAutomation_Document_NewPersInterests();
        DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_NewPersInterests_ID"].ToString();

        t_OfficeAutomation_Document_NewPersInterests = GetModelFromPage(new Guid(ID));

        string apply = EmployeeName;
        string depname = txtTfid2.Text;
        string summary = txtBuilding.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_NewPersInterests_Inherit.Update(t_OfficeAutomation_Document_NewPersInterests); //修改申请表

        //先删除后增加详情表
        DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit da_OfficeAutomation_Document_NewPersInterests_Detail_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit();
        da_OfficeAutomation_Document_NewPersInterests_Detail_Inherit.Delete(ID);
        InsertNewPersInterestsDetail(new Guid(ID));

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        //如果申请人为直属上司为黄生的人员，则添加2步流程：6后勤事务部经理，7董事总经理
        string[] immediateboss = CommonConst.EMP_IMMEDIATEBOSS_NAME.Split('|');
        foreach (string boss in immediateboss)
        {
            if (txtApplyFor.Text == boss)
            {
                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7,8");
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "10,18");

                isImmediste = true;
                T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_LOGISTICS_MANAGER_ID;
                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_LOGISTICS_MANAGER_NAME;
                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 17;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "46156";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "苏玲";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 10;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 18;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                break;
            }
        }

        if (!isImmediste)
        {
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 7);
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 8);
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 10);
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 18);
        }

        Common.AddLog(EmployeeID, EmployeeName, 53, new Guid(MainID), 2); //日志，修改申请表
    }

    #endregion

    #region 其他

    #region 新增详情表

    /// <summary>
    /// 新增详情表
    /// </summary>
    /// <param name="gNewPersInterestsID"></param>
    private void InsertNewPersInterestsDetail(Guid gNewPersInterestsID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_NewPersInterests_Detail t_OfficeAutomation_Document_NewPersInterests_Detail;
        DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit da_OfficeAutomation_Document_NewPersInterests_Detail_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        try
        {
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\&\\&");
                if (detail[0] == "")
                    continue;
                t_OfficeAutomation_Document_NewPersInterests_Detail = new T_OfficeAutomation_Document_NewPersInterests_Detail();
                t_OfficeAutomation_Document_NewPersInterests_Detail.OfficeAutomation_Document_NewPersInterests_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_NewPersInterests_Detail.OfficeAutomation_Document_NewPersInterests_Detail_MainID = gNewPersInterestsID;
                t_OfficeAutomation_Document_NewPersInterests_Detail.OfficeAutomation_Document_NewPersInterests_Detail_RelativesName = detail[0];
                t_OfficeAutomation_Document_NewPersInterests_Detail.OfficeAutomation_Document_NewPersInterests_Detail_InDepartment = detail[1];
                t_OfficeAutomation_Document_NewPersInterests_Detail.OfficeAutomation_Document_NewPersInterests_Detail_Position = detail[2];
                t_OfficeAutomation_Document_NewPersInterests_Detail.OfficeAutomation_Document_NewPersInterests_Detail_Relationship = detail[3];
                t_OfficeAutomation_Document_NewPersInterests_Detail.OfficeAutomation_Document_NewPersInterests_Detail_rdInApply = detail[4];
                t_OfficeAutomation_Document_NewPersInterests_Detail.OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID = detail[5];
                t_OfficeAutomation_Document_NewPersInterests_Detail.OfficeAutomation_Document_NewPersInterests_Detail_txtTfid = detail[6];
                da_OfficeAutomation_Document_NewPersInterests_Detail_Inherit.Insert(t_OfficeAutomation_Document_NewPersInterests_Detail);
            }
        }
        catch(Exception ee)
        {
            Alert(ee.Message);
            return;
        }
    }

    #endregion

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

        //SbJson.Remove(0, SbJson.Length);
        //wsKDHR.Service service = new wsKDHR.Service();
        //DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
        //SbJson.Append("[");

        //////简单去除分行下面的组别，变分行，简单过滤重复。
        ////string name;
        ////foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        ////{
        ////    name = dr["name"].ToString();
        ////    Match m = Regex.Match(name, "[A-Z]{1}组");
        ////    if (m.Success)//去除组别
        ////        name = name.Substring(0, m.Index);

        ////    m = Regex.Match(name, "(\\(|（)+\\w+(\\)|）)+");
        ////    if (m.Success)//去除括号
        ////        name = name.Substring(0, m.Index);

        ////    m = Regex.Match(name, "[A-D]$");
        ////    if (m.Success)//去除名称尾部的ABCD
        ////        name = name.Substring(0, m.Index);

        ////    if (!sbJSON.ToString().Contains(name))
        ////        sbJSON.Append("{\"value\":\"" + name + "\"},");
        ////}

        //foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        //{
        //    SbJson.Append("{\"value\":\"" + dr["name"] + "\"},");
        //}

        //SbJson.Remove(SbJson.Length - 1, 1);
        //SbJson.Append("]");
    }
    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite54"] = "1";
        Response.Write("<script>window.open('Apply_NewPersInterests_Detail.aspx?MainID=" + MainID + "');</script>");
    }
    #region 自动导入详情表
    /// <summary>
    /// 自动导入详情表
    /// </summary>
    protected void btnUploadDetailed_Click(object sender, EventArgs e)
    {
        //SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);

        //string path = hdFilePath.Value;
        //if (path != "")
        //{
        //    System.Data.OleDb.OleDbConnection ImportConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source=" + path + "; " + "Extended Properties='Excel 12.0;HDR=1; IMEX=1;'");
        //    System.Data.OleDb.OleDbDataAdapter ImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [格式$]", ImportConnection);
        //    DataSet ds = new DataSet();
        //    int i = 0;
        //    try
        //    {
        //        ImportCommand.Fill(ds);
        //    }
        //    catch
        //    {
        //        Alert("格式错误");
        //        DrawDetailTable(1);
        //        //txtMoneyCount.Text = "";
        //        SbJs.Append("</script>");
        //        return;
        //    }

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        try
        //        {
        //            string sReportID, sAddress, sOwnerBadMoney, sClientBadMoney, sBadReason;
        //            //bool bIsSpecialAdjust;
        //            int success = 0;
        //            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        //            {
        //                sReportID = ds.Tables[0].Rows[i]["报数时间"].ToString();
        //                sAddress = ds.Tables[0].Rows[i]["成交编号"].ToString();
        //                sOwnerBadMoney = ds.Tables[0].Rows[i]["物业地址"].ToString();
        //                sClientBadMoney = ds.Tables[0].Rows[i]["变更情况"].ToString();
        //                sBadReason = ds.Tables[0].Rows[i]["变更事由"].ToString();
        //                //bIsSpecialAdjust = ds.Tables[0].Rows[i]["是否特殊调整"].ToString() == "是" ? true : false;

        //                if (!string.IsNullOrEmpty(sReportID) && !string.IsNullOrEmpty(sAddress))
        //                {
        //                    success++;
        //                    SbJs.Append("$('#txtCountOffTime" + success + "').val('" + sReportID + "');");
        //                    SbJs.Append("$('#txtDealNo" + success + "').val('" + sAddress + "');");
        //                    SbJs.Append("$('#txtOtherDataAddress" + success + "').val('" + sOwnerBadMoney + "');");
        //                    SbJs.Append("$('#txtChangeSituation" + success + "').val('" + sClientBadMoney + "');");
        //                    SbJs.Append("$('#txtChangeReason" + success + "').val('" + sBadReason + "');");
        //                    //SbJs.Append("$('#rdoIsSpecialAdjust" + success + (bIsSpecialAdjust ? "1" : "0") + "').attr('checked','checked');");
        //                }

        //                //if (sReportID == "业、客坏账金额合计：")
        //                //    txtMoneyCount.Text = sOwnerBadMoney;
        //            }

        //            DrawDetailTable(success);
        //        }
        //        catch (System.Exception ex)
        //        {
        //            Alert(ex.Message);
        //        }
        //    }
        //}
        //else
        //    DrawDetailTable(1);
        //SbJs.Append("</script>");
    }
    #endregion
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

        DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_NewPersInterests_ID"].ToString(); //在不同的表要注意修改

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

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID; //在不同的表要注意删除
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 131;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("员工个人利益申报表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
            DataSet ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_NewPersInterests_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_NewPersInterests_Department"].ToString();
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
                //if (i < 11)
                //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
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
            DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
            DataSet ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_NewPersInterests_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_NewPersInterests_Department"].ToString();
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
                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
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
            DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
            DataSet ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_NewPersInterests_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_NewPersInterests_Department"].ToString();
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
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 3); //在不同的表中要修改，开发新表时要注意
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_PersInterests_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=340px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

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
        T_OfficeAutomation_Flow flowsa, flowsb, flowsh, fst4 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3); //M_AlAno：20160217 ++
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
        DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
        DataSet ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_NewPersInterests_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_NewPersInterests_Department"].ToString();
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
        DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_NewPersInterests_Department"].ToString();
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

    /// <summary>
    /// 增加审核人
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void addhq_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
        DataSet ds = new DataSet();

        #region 判断流程中人名是否存在，或为管理层，如果不是则该流程不允许保存
        try
        {


            string[] names = this.txtHeaderIDx3.Text.Split(',');
            string name = "";
            string code = "";
            string email, messageBody;

            for (int n = 0; n < names.Length; n++)
            {
                name += "'" + names[n] + "',";
            }

            name = name.Substring(0, name.Length - 1);
            //ds = ws.GetManagesByNames(name);

            //2016-12-19修改为所有员工都可以设置为转审批人
            ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeName(name);

            name = "";

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 8);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //code += dr["code"].ToString() + ",";
                    //name += dr["employeename"].ToString() + ",";
                    code += dr["Code"].ToString() + ",";
                    name += dr["EmployeeName"].ToString() + ",";
                }
                code = code.Substring(0, code.Length - 1);
                name = name.Substring(0, name.Length - 1);
                //增加一个流程环节
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 8;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 2);
                RunJS("alert('添加成功！');window.location='" + Page.Request.Url + "'");
            }
            else
                RunJS("alert('该负责人不存在，请重新填选负责人！');window.location='" + Page.Request.Url + "'");

        }
        catch (Exception ex)
        {
            RunJS("alert('转发失败');window.location='" + Page.Request.Url + "'");
        }
        #endregion
    }

    /// <summary>
    /// 取消审核人
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cleanhq_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 8);
            RunJS("alert('添加成功！');window.location='" + Page.Request.Url + "'");
        }
        catch (Exception ex)
        {
            RunJS("alert('" +ex.Message+ "');window.location='" + Page.Request.Url + "'");
            
        }
    
    }
}