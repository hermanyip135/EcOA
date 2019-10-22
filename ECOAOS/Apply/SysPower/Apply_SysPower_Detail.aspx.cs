using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using DataEntity;
using DataAccess.Operate;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;

using System.Diagnostics; //M_PDF
using System.Web;

public partial class Apply_SysPower_Apply_SysPower_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public static string SerialNumber = "";
    public StringBuilder sbHtml = new StringBuilder();
    public StringBuilder sbJS = new StringBuilder();
    public StringBuilder sbJSHtml = new StringBuilder();
    public StringBuilder sbFlow = new StringBuilder();
    public StringBuilder sbJSON = new StringBuilder();
    public StringBuilder sbManagerJSON = new StringBuilder();
    public string ApplyN;
    public bool haveMCOA = false;

    #endregion

    #region 页面加载及初始化

    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        sbJSON.Append("[]");
        sbManagerJSON.Append("[]");

        MainID = GetQueryString("MainID");
        SerialNumber = "";
        ID = "";
        InitJSHtml();
        if (!IsPostBack)
        {
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
                if (Session["FLG_ReWrite24"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite24"] = null;
                }
            }
            catch
            {
            }
            if (MainID != "")
                LoadPage();
            else
                InitPage();
            
        }
        else
            GetAllDepartment();
    }

    public void InitJSHtml()
    {
        DataSet dsApplyDetail = new DataSet();
        DataSet dsApplyType = new DataSet();

        DA_Dic_OfficeAutomation_ApplyDetail_Operate da_Dic_OfficeAutomation_ApplyDetail_Operate = new DA_Dic_OfficeAutomation_ApplyDetail_Operate();
        dsApplyDetail = da_Dic_OfficeAutomation_ApplyDetail_Operate.SelectAll(3);
        DA_Dic_OfficeAutomation_ApplyType_Operate da_Dic_OfficeAutomation_ApplyType_Operate = new DA_Dic_OfficeAutomation_ApplyType_Operate();
        dsApplyType = da_Dic_OfficeAutomation_ApplyType_Operate.SelectAll();

        sbJSHtml.Append("+ \"        <td class='tl'>\"");
        foreach (DataRow dr in dsApplyDetail.Tables[0].Rows)
            sbJSHtml.Append("+ \"            <input id='chkSys\" + i + \"" + dr["OfficeAutomation_ApplyDetail_ID"].ToString() + "' type='checkbox' value='" 
                + dr["OfficeAutomation_ApplyDetail_ID"].ToString() + "'/><label for='chkSys\" + i + \"" + dr["OfficeAutomation_ApplyDetail_ID"].ToString() + "'>" 
                + dr["OfficeAutomation_ApplyDetail_Name"].ToString() + "</label>\"");
        sbJSHtml.Append("+ \"        </td>\"");
        sbJSHtml.Append("+ \"        <td>\"");
        foreach (DataRow dr in dsApplyType.Tables[0].Rows)
            sbJSHtml.Append("+ \"            <input type='radio' id='rdoApplyType\" + i + \"" + dr["OfficeAutomation_ApplyType_ID"].ToString() + "' name='ApplyType\" + i + \"' value='" 
                + dr["OfficeAutomation_ApplyType_ID"].ToString() + "' /><label for='rdoApplyType\" + i + \"" + dr["OfficeAutomation_ApplyType_ID"].ToString() + "'>" 
                + dr["OfficeAutomation_ApplyType_Name"].ToString() + "</label><br />\"");
        sbJSHtml.Append("+ \"        </td>\"");
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        this.txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        this.txtApplicant.Text = EmployeeName;
        this.btnSave.Visible = true;
        sbJS.Append("<script type=\"text/javascript\">$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");

        DA_Dic_OfficeAutomation_ITStaff_Operate da_Dic_OfficeAutomation_ITStaff_Operate = new DA_Dic_OfficeAutomation_ITStaff_Operate();
        DataSet ds = da_Dic_OfficeAutomation_ITStaff_Operate.SelectByTeam(2);
        DropDownListBind(ddlFollower, ds.Tables[0], "OfficeAutomation_ITStaff_Code", "OfficeAutomation_ITStaff_Name", "0","跟进人");

        DrawDetailTable(1);
        sbJS.Append("</script>");
    }

    public void DrawDetailTable(int n)
    {
        DataSet dsApplyDetail = new DataSet();
        DataSet dsApplyType = new DataSet();

        DA_Dic_OfficeAutomation_ApplyDetail_Operate da_Dic_OfficeAutomation_ApplyDetail_Operate = new DA_Dic_OfficeAutomation_ApplyDetail_Operate();
        dsApplyDetail = da_Dic_OfficeAutomation_ApplyDetail_Operate.SelectAll(3);
        DA_Dic_OfficeAutomation_ApplyType_Operate da_Dic_OfficeAutomation_ApplyType_Operate = new DA_Dic_OfficeAutomation_ApplyType_Operate();
        dsApplyType = da_Dic_OfficeAutomation_ApplyType_Operate.SelectAll();

        for (int i = 1; i <= n; i++)
        {
            sbHtml.Append("<tr id='trDetail" + i + "'>");
            sbHtml.Append("     <td class=\"tl\">");
            sbHtml.Append("            工号：<input type=\"text\" id=\"txtCode" + i + "\" onkeyup=\"this.value=this.value.replace(/[^\\d|//.]/g,'');\" onblur=\"getEmployee(this," + i + ");\"/>");
            sbHtml.Append("            姓名：<input type=\"text\" id=\"txtName" + i + "\"/><br />");
            sbHtml.Append("            部门：<input type=\"text\" id=\"txtDepartment" + i + "\"/><input type=\"hidden\" id=\"hdDepartmentID" + i + "\" />");
            sbHtml.Append("            职位：<input type=\"text\" id=\"txtPosition" + i + "\"/><br />");
            sbHtml.Append("            生效日期：<input type=\"text\" id=\"txtEffectiveDate" + i + "\"/>");
            sbHtml.Append("    </td>");
            sbHtml.Append("    <td class=\"tl\">");
            foreach (DataRow dr in dsApplyDetail.Tables[0].Rows)
                sbHtml.Append("        <input id='chkSys" + i + dr["OfficeAutomation_ApplyDetail_ID"].ToString() + "' type=\"checkbox\" value=\"" + dr["OfficeAutomation_ApplyDetail_ID"].ToString()
                    + "\"/><label for='chkSys" + i + "" + dr["OfficeAutomation_ApplyDetail_ID"].ToString() + "'>" + dr["OfficeAutomation_ApplyDetail_Name"].ToString() + "</label>");
            sbHtml.Append("    </td>");
            sbHtml.Append("    <td>");
            foreach (DataRow dr in dsApplyType.Tables[0].Rows)
                sbHtml.Append("        <input type=\"radio\" id='rdoApplyType" + i + dr["OfficeAutomation_ApplyType_ID"].ToString() + "' name='ApplyType" + i + "' value=\"" 
                    + dr["OfficeAutomation_ApplyType_ID"].ToString() + "\" /><label for='rdoApplyType" + i + "" + dr["OfficeAutomation_ApplyType_ID"].ToString() + "'>" 
                    + dr["OfficeAutomation_ApplyType_Name"].ToString() + "</label><br />");
            sbHtml.Append("    </td>");
            sbHtml.Append("</tr>");
        }
        sbJS.Append("i=" + n + ";");
    }
    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        DA_Dic_OfficeAutomation_ITStaff_Operate da_Dic_OfficeAutomation_ITStaff_Operate = new DA_Dic_OfficeAutomation_ITStaff_Operate();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_SysPower_Inherit da_OfficeAutomation_Document_SysPower_Inherit = new DA_OfficeAutomation_Document_SysPower_Inherit();
        DA_OfficeAutomation_Document_SysPower_Detail_Inherit da_OfficeAutomation_Document_SysPower_Detail_Inherit = new DA_OfficeAutomation_Document_SysPower_Detail_Inherit();
        DA_OfficeAutomation_Document_SysPower_Detail_Apply_Inherit da_OfficeAutomation_Document_SysPower_Detail_Apply_Inherit = new DA_OfficeAutomation_Document_SysPower_Detail_Apply_Inherit();

        string flowState = "";
        try
        {
            flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
        }
        catch
        {
            Alert(CommonConst.MSG_URL_DISABLE);
            RunJS("window.location='/Apply/Apply.aspx'");
            return;
        }

        sbJS.Append("<script type=\"text/javascript\">");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
        {
            sbJS.Append("$(\"#btnPrint\").show();");
        }
        #endregion

        #region 加载页面数据
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_SysPower_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_SysPower_ID"].ToString();
        this.txtDispatchDepartment.Text = dr["OfficeAutomation_Document_SysPower_Department"].ToString();
        this.hdDispatchDepartmentID.Value = dr["OfficeAutomation_Document_SysPower_DepartmentID"].ToString();
        this.txtApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_SysPower_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        this.txtApplicant.Text = dr["OfficeAutomation_Document_SysPower_Apply"].ToString();
        ApplyN = dr["OfficeAutomation_Document_SysPower_Apply"].ToString();
        this.txtReqContent.Text = dr["OfficeAutomation_Document_SysPower_ReqContent"].ToString();
        this.txtPhone.Text = dr["OfficeAutomation_Document_SysPower_Phone"].ToString();
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        this.txtDeal.Text = dr["OfficeAutomation_Document_SysPower_Deal"].ToString();

        if (ApplyN == "邱灶群")
            sbJS.Append("$(\"#trLogistics1\").show();$(\"#trLogistics2\").show();");

        DataSet dsITStaff = da_Dic_OfficeAutomation_ITStaff_Operate.SelectByTeam(2);
        DropDownListBind(ddlFollower, dsITStaff.Tables[0], "OfficeAutomation_ITStaff_Code", "OfficeAutomation_ITStaff_Name", "0", "跟进人");
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        //sbJS.Append("$(\"#btnUpload\").show();");
        bool IsApplicant = EmployeeName == dr["OfficeAutomation_Document_SysPower_Apply"].ToString();

        if (EmployeeName == dr["OfficeAutomation_Document_SysPower_Apply"].ToString())
        {

            if (flowState == "1")
            {
                GetAllDepartment();
                sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
                this.btnSave.Visible = true;
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
                sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
            }
        }

        //2016-12-19修改 之前是只有申请人才能上传附件，现在修改为申请人和审批人都可以上传附件
        if (EmployeeName == dr["OfficeAutomation_Document_SysPower_Apply"].ToString() || Common.IsShowBtnUpload(EmployeeID, MainID))
        {
            sbJS.Append("$(\"#btnUpload\").show();");
        }
        #endregion

        ds = da_OfficeAutomation_Document_SysPower_Detail_Inherit.SelectByMainID(ID);

        int detailCount = ds.Tables[0].Rows.Count;
        if (detailCount == 0)
            DrawDetailTable(1);
        else
        {
            DrawDetailTable(detailCount);

            for (int n = 0; n < detailCount; n++)
            {
                dr = ds.Tables[0].Rows[n];

                int i = n + 1;

                sbJS.Append("$('#txtName" + i + "').val('" + dr["OfficeAutomation_Document_SysPower_Detail_Employee"].ToString() + "');");
                sbJS.Append("$('#txtCode" + i + "').val('" + dr["OfficeAutomation_Document_SysPower_Detail_EmployeeID"].ToString() + "');");
                sbJS.Append("$('#txtDepartment" + i + "').val('" + dr["OfficeAutomation_Document_SysPower_Detail_Department"].ToString() + "');");
                sbJS.Append("$('#hdDepartmentID" + i + "').val('" + dr["OfficeAutomation_Document_SysPower_Detail_DepartmentID"].ToString() + "');");
                sbJS.Append("$('#txtPosition" + i + "').val('" + dr["OfficeAutomation_Document_SysPower_Detail_Position"].ToString() + "');");
                sbJS.Append("$('#txtEffectiveDate" + i + "').val('" + DateTime.Parse(dr["OfficeAutomation_Document_SysPower_Detail_BeginDate"].ToString()).ToString("yyyy-MM-dd") + "');");

                DataSet tempDS = new DataSet();
                tempDS = da_OfficeAutomation_Document_SysPower_Detail_Apply_Inherit.SelectByMainID(dr["OfficeAutomation_Document_SysPower_Detail_ID"].ToString());
                for (int x = 0; x < tempDS.Tables[0].Rows.Count; x++)
                {
                    sbJS.Append("$('#chkSys" + i + tempDS.Tables[0].Rows[x]["OfficeAutomation_Document_SysPower_Detail_Apply_ApplyDetailID"].ToString() + "').attr('checked','checked');");
                }

                sbJS.Append("$('#rdoApplyType" + i + dr["OfficeAutomation_Document_SysPower_Detail_ApplyTypeID"].ToString() + "').attr('checked','true');");
            }
        }

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                sbJS.Append("$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();");
                sbJS.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                sbJS.Append("</script>");
                btnSPDF.Visible = false; //M_PDF
                GetAllDepartment();

                this.txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.txtApplicant.Text = EmployeeName;
                this.btnSave.Visible = true;
                flowState = "1";
                btnSAlterC.Visible = false;
                return;
            }
        }
        catch
        {
            if (IsApplicant)
                btnReWrite.Visible = true; //*-+
        }

        if (EmployeeName == "梁锐华")
        {
            sbJS.Append("$('#divAssign').show();");
            this.btnAssign.Visible = true;//下派跟进人处理按钮显示
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
        sbFlow.Append("<div class=\"flow\">");
        sbFlow.Append("审批流程:");
        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            sbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
                string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();
                sbFlow.Append("auditing\">待" + curemp + "审理");

                flag2 = false;

                if (curemp.Contains(EmployeeName) || EmployeeName.Contains("霍志成") || EmployeeName.Contains("梁锐华"))
                {
                    switch (curidx)
                    {
                        case "4":
                            sbJS.Append("$('#divTransmit').show();");
                            break;
                        case "5":
                            sbJS.Append("$('#btnSaveDeal').show();");
                            if (EmployeeName == "梁锐华")
                            {
                                sbJS.Append("$('#divAssign').show();");
                                this.btnAssign.Visible = true;//下派跟进人处理按钮显示
                            }
                            break;
                        default:
                            break;
                    }
                }

                //if ((drc[i]["OfficeAutomation_Flow_IDx"].ToString() == "5" || drc[i]["OfficeAutomation_Flow_IDx"].ToString() == "6") && drc[i]["OfficeAutomation_Flow_Employee"].ToString().Contains(EmployeeName))
                //    sbJS.Append("$('#btnSaveDeal').show();");
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
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            {
                DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                sbJS.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 120px; line-height: 65px; height: 2px; margin-left:0px; float:left;\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                for (int x = 0; x < auditorIDs.Length; x++)
                {
                    if (/*auditorIDs[x] == EmployeeID || */da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), auditorIDs[x],
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                    {
                        sbJS.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                    }
                    sbJS.Append("<img src=\"" + SignImageURL + GetGIF(auditorIDs[x]) + ".gif\" height=\"60px\" " + (x == 0 ? "style=\"margin-left:120px;\"" : "") + "/>");
                }
                sbJS.Append("');");

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
                    sbJS.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                sbJS.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");

                if (string.IsNullOrEmpty(this.txtDeal.Text) && drc[i]["OfficeAutomation_Flow_IDx"].ToString() == "5")
                    this.txtDeal.Visible = false;
            }
            else
            {
                DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                if (auditorIDs.Length > 0 && auditorIDs[0] != "")
                {
                    sbJS.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').before('<div style=\"width: 120px; line-height: 65px; height: 2px; margin-left:20px; float:left;\">"
                                       + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    for (int x = 0; x < auditorIDs.Length; x++)
                    {
                        if (/*auditorIDs[x] == EmployeeID || */da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), auditorIDs[x],
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            sbJS.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        sbJS.Append("<img src=\"" + SignImageURL + GetGIF(auditorIDs[x]) + ".gif\" height=\"60px\" " + (x == 0 ? "style=\"margin-left:120px;\"" : "") + "/>");
                    }
                    sbJS.Append("');");
                    sbJS.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");
                    sbJS.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
                }

                if (!string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    sbJS.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                if (flag && da_OfficeAutomation_Agent_Inherit.IsHaveSignPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(),
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID))
                    sbJS.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').show();");

                try //20150104：被下派人员随时可审
                {
                    if (drc[i - 1]["OfficeAutomation_Flow_IDx"].ToString() == "5")
                    {
                        string[] employnames;
                        string employname,epm2;
                        employname = drc[i - 1]["OfficeAutomation_Flow_Auditor"].ToString();
                        epm2 = drc[i]["OfficeAutomation_Flow_Employee"].ToString();
                        employnames = employname.Split(',');
                        for (int i2 = 0; i2 < employnames.Length; i2++)
                        {
                            if (employnames[i2] == "梁锐华" && epm2 == EmployeeName)
                                sbJS.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"].ToString() + "').show();");
                        }
                    }
                }
                catch
                {
                }

                flag = false;
            }

            #endregion

            #region 显示被转发到的负责人
            if (drc[i]["OfficeAutomation_Flow_IDx"].ToString() == "6")
            {
                for (int x = 1; x < ddlFollower.Items.Count; x++)
                {
                    if (ddlFollower.Items[x].Text == drc[i]["OfficeAutomation_Flow_Employee"].ToString())
                    {
                        this.ddlFollower.SelectedIndex = x;
                        break;
                    }
                }
            }
            #endregion
        }
        if (flowState == "1" && txtApplicant.Text == EmployeeName)
            sbFlow.Append("<input type=\"button\" id=\"btnEditFlow\" onclick=\"editflow();\" style=\"margin-left:10px;\" value=\"编辑流程\">");
        if (flowState == "2" && txtApplicant.Text == EmployeeName && !tpdf) //20141215：M_AlterC
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

    /// <summary>
    /// 加载附件列表
    /// </summary>
    private void LoadAttach()
    {
        //获取该单附件列表
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DataSet dsAttach = new DataSet();
        dsAttach = da_OfficeAutomation_Attach_Inherit.GetAttachByMainID(MainID);

        gvAttach.DataSource = dsAttach;
        gvAttach.DataBind();

        //如果该单有附件，则下载按钮显示
        this.btnDownload.Visible = (dsAttach != null && dsAttach.Tables[0] != null && dsAttach.Tables[0].Rows.Count > 0);
    }

    #endregion

    #region GridView事件

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

    #region 按钮事件

    /// <summary>
    /// 保存按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region 创建对象
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_SysPower t_OfficeAutomation_Document_SysPower = new T_OfficeAutomation_Document_SysPower();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_SysPower_Inherit da_OfficeAutomation_Document_SysPower_Inherit = new DA_OfficeAutomation_Document_SysPower_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1") 
            {
                MainID = "";
                 
            }
        }
        catch
        {
        }

        try
        {
            if (MainID == "")
            {
                #region 新建
                string[] units, unitids;
                string dispatchDepartmentID = this.hdDispatchDepartmentID.Value;
                if (dispatchDepartmentID == "")
                {
                    Alert("发文部门，请填写关键字后点选部门！");
                    return;
                }
                wsFinance.Service wsf = new wsFinance.Service();
                DataSet ds = wsf.GetHRStructure(dispatchDepartmentID, this.txtApplyDate.Text);//根据发文部门ID及申请日期获得该部门人事树（前线）
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    units = ds.Tables[0].Rows[0]["HRStructure_Unit"].ToString().Split('/');
                    unitids = ds.Tables[0].Rows[0]["HRStructure_UnitID"].ToString().Split('/');
                }
                else
                {
                    wsHR.HR wshr = new wsHR.HR();
                    units = wshr.GetDepartmentManager(dispatchDepartmentID).Split('/');//根据发文部门ID获得该部门负责人名称（非前线）
                    if (units.Length == 0)
                    {
                        Alert("发文部门不存在，无法生成申请表！");
                        return;
                    }
                    else
                    {
                        unitids = wshr.GetDepartmentManagerCode(dispatchDepartmentID).Split('/');
                    }
                }


                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "SYSPOWER" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 3;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_DepartmentID = new Guid(dispatchDepartmentID);
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Department = this.txtDispatchDepartment.Text;
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Apply = this.txtApplicant.Text;
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Phone = this.txtPhone.Text;
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ReqContent = this.txtReqContent.Text;
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Deal = this.txtDeal.Text;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = this.txtApplicant.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDispatchDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = this.txtDeal.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_SysPower_Inherit.Insert(t_OfficeAutomation_Document_SysPower);//插入(汇瀚/二级市场/后勤)IT权限申请表

                InsertSysPowerDetail(t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ID);

                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                #region 根据发文部门的人事树层级，保存不同的流程。
                for (int i = 0; i < units.Length; i++)
                {
                    if (units.Length == 4 && i == 0)
                        continue;

                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = unitids[i].Replace(CommonConst.EMP_GENERALMANAGER_ID, "");
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = units[i].Replace(CommonConst.EMP_GENERALMANAGER_NAME, "");
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = units.Length == 4 ? (4 - i) : (3 - i);

                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }
                #endregion

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
                }
                #endregion

                #region 如果申请内容中有MCOA，则增加IT部经理流程 2014-3-31

                if (haveMCOA)
                {
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_IT_MANAGER_ID;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_IT_MANAGER_NAME;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 6;
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }

                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 6, new Guid(MainID), 1);//日志，创建(汇瀚/二级市场/后勤)IT权限申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程
                RunJS("window.showModalDialog(\"../Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_SysPower_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='../Apply.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_SysPower_Inherit.SelectByMainID(MainID);
                    ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SysPower_ID"].ToString();

                    t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ID = new Guid(ID);
                    t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_DepartmentID = new Guid(this.hdDispatchDepartmentID.Value);
                    t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Department = this.txtDispatchDepartment.Text;
                    t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Apply = this.txtApplicant.Text;
                    t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Phone = this.txtPhone.Text;
                    t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);
                    t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ReqContent = this.txtReqContent.Text;
                    t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Deal = this.txtDeal.Text;

                    string apply = this.txtApplicant.Text;
                    string depname = this.txtDispatchDepartment.Text;
                    string summary = this.txtDeal.Text;
                    string applydate = this.txtApplyDate.Text;
                    string mainid = MainID;

                    da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
                    da_OfficeAutomation_Document_SysPower_Inherit.Update(t_OfficeAutomation_Document_SysPower);//修改(汇瀚/二级市场/后勤)IT权限申请表

                    DA_OfficeAutomation_Document_SysPower_Detail_Inherit da_OfficeAutomation_Document_SysPower_Detail_Inherit = new DA_OfficeAutomation_Document_SysPower_Detail_Inherit();
                    da_OfficeAutomation_Document_SysPower_Detail_Inherit.Delete(ID);
                    InsertSysPowerDetail(new Guid(ID));

                    Common.AddLog(EmployeeID, EmployeeName, 6, new Guid(MainID), 2);//日志，修改(汇瀚/二级市场/后勤)IT权限申请表
                    RunJS("alert('保存成功！');window.location='../Apply.aspx';");
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
            DA_OfficeAutomation_Document_SysPower_Inherit da_OfficeAutomation_Document_SysPower_Inherit = new DA_OfficeAutomation_Document_SysPower_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            ds = da_OfficeAutomation_Document_SysPower_Inherit.SelectByMainID(MainID);
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SysPower_Apply"].ToString();
            SerialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string follower = "";

            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 6);
            if (ddlFollower.SelectedIndex != 0)
            {
                //增加一个流程环节
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 6;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = ddlFollower.Items[ddlFollower.SelectedIndex].Value;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = ddlFollower.Items[ddlFollower.SelectedIndex].Text;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                if (follower != "")
                    follower += ",";
                follower += t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee;
            }
            da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
            da_OfficeAutomation_Main_Inherit.SetNullAuditorWhenFlow(MainID); //清空Main表中的最终审批人记录

            //通知申请人已安排跟进人
            string email = apply;
            string messageBody = "您好，" + apply + "：您有编号为" + SerialNumber + "的" + da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID) + "已安排" + follower + "负责跟进。申请表地址为：" + Page.Request.Url.ToString();
            //Common.SendMessageEX(false, "(后勤/汇瀚/二级市场)IT权限申请表", email, "跟进预告", messageBody, messageBody);
            Common.SendMessageEX(false, email, "跟进预告", messageBody, messageBody);

            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 2);
            RunJS("alert('下派成功！');window.location='/Apply/SysPower/Apply_SysPower_Detail.aspx?MainID=" + MainID + "'");

        }
        catch (Exception ex)
        {
            Alert("下派失败，" + ex.Message);
        }
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
            CheckBox chk = item.FindControl("chk") as CheckBox;
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
        DA_OfficeAutomation_Document_SysPower_Inherit da_OfficeAutomation_Document_SysPower_Inherit = new DA_OfficeAutomation_Document_SysPower_Inherit();
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
                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                DataSet ds = new DataSet();
                ds = da_OfficeAutomation_Document_SysPower_Inherit.SelectByMainID(MainID);
                string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SysPower_Apply"].ToString();
                string employname;
                string[] employnames;
                string email = "";
                string messageBody;
                string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);

                ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                DataRowCollection drc = ds.Tables[0].Rows;
                for (int i = 0; i < drc.Count; i++)
                {
                    if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False")
                    {
                        if (i > 0 && drc[i - 1]["OfficeAutomation_Flow_Audit"].ToString() == "False" && i != 3)  //20150104
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

                if (flowIDx == "4")
                {
                    string empid = "", empname = "";
                    if (cbkSetComputer.Checked)
                    {
                        empid += (empid == "" ? "" : ",") + "1236";
                        empname += (empname == "" ? "" : ",") + "梁锐华";
                    }

                    if (cbkEFax.Checked)
                    {
                        empid += (empid == "" ? "" : ",") + "17292";
                        empname += (empname == "" ? "" : ",") + "周丽兰";
                    }

                    if (cbkInerWeb.Checked)
                    {
                        empid += (empid == "" ? "" : ",") + "52575";
                        empname += (empname == "" ? "" : ",") + "郑嘉伦";
                    }

                    if(cbkAssetManageSystem.Checked)
                    {
                        empid += (empid == "" ? "" : ",") + "5128";
                        empname += (empname == "" ? "" : ",") + "霍志成";
                    }

                    if (empid != "")
                    {
                        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = empid;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = empname;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                        //通知申请人已安排跟进人
                        email = apply;
                        messageBody = "您好，" + apply + "：您有编号为" + serialNumber + "的" + da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID) + "已安排" + empname + "负责跟进。申请表地址为：" + Page.Request.Url.ToString();
                        //Common.SendMessageEX(false, "(后勤/汇瀚/二级市场)IT权限申请表", email, "跟进预告", messageBody, messageBody);
                        Common.SendMessageEX(false, email, "跟进预告", messageBody, messageBody);
                        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 2);
                    }
                }


                if (da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeID, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value))
                {
                    if (hdIsAgree.Value != "0")//同意或其他意见
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名批准

                        //当IT部经理审批通过后，通知负责MCOA同事设置MCOA权限 2014-3-31
                        if (signEmployeeName == CommonConst.EMP_IT_MANAGER_NAME)
                        {
                            //审批流程完成，通知申请人
                            email = CommonConst.EMP_IT_MCOA_NAME;
                            messageBody = "您好，" + email + "：您有编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审批，需要您设置MCOA权限。申请表地址为：" + Page.Request.Url.ToString();
                            Common.SendMessageEX(false, email, "有份MCOA权限需要您设置", messageBody, messageBody);
                        }

                        //判断审批流程是否完成,通知相应人员
                        if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(MainID))
                        {
                            //审批流程完成，通知申请人
                            messageBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。申请表地址为：" + Page.Request.Url.ToString();
                            email = apply;
                            if (hdIsAgree.Value == "2")
                                Common.SendMessageEX(false, email, "其他意见", messageBody, messageBody);
                            else
                                Common.SendMessageEX(false, email, "申请已同意", messageBody, messageBody);
                        }
                        else
                        {
                            //通知申请人
                            messageBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。申请表地址为：" + Page.Request.Url.ToString();
                            email = apply;
                            Common.SendMessageEX(false, email, "申请已通过" + signEmployeeName + "的审理", messageBody, messageBody);

                            //通知下一步需要审批的人员
                            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
                            if (!employname.Contains(EmployeeName))
                            {
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    messageBody = "您好，" + employnames[i] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审理。申请表地址为：" + Page.Request.Url.ToString();
                                    email = employnames[i];
                                    Common.SendMessageEX(true, documentName, email, "请审理", messageBody, messageBody,MainID);
                                }
                            }
                        }

                        RunJS("alert('审理成功！');window.location='" + Page.Request.Url.ToString() + "'");
                    }
                    else //不同意
                    {
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 5);//添加日志，签名不同意
                        //通知申请人
                        messageBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + (flowIDx == "5" ? txtDeal.Text : hdSuggestion.Value) + "。申请表地址为：" + Page.Request.Url.ToString();
                        email = apply;
                        Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", messageBody, messageBody);

                        //通知已审批的人员
                        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                messageBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + (flowIDx == "5" ? txtDeal.Text : hdSuggestion.Value) + "。申请表地址为：" + Page.Request.Url.ToString();
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
            }
            catch(Exception ex)
            {
                Alert("审理失败！" + ex.Message);
            }
        }
        else
        {
            Alert("未开通审核权限！");
        }
    }

    #region 返回按钮点击事件
    protected void btnBack_Click(object sender, EventArgs e)
    {
          
        string sUrl = "../Apply.aspx?" + Request.QueryString.ToString();
        Response.Redirect(sUrl);
    }
    #endregion

    #endregion

    #region 其他

    /// <summary>
    /// 新增(汇瀚/二级市场/后勤)IT权限申请明细
    /// </summary>
    /// <param name="gSysPowerID"></param>
    private void InsertSysPowerDetail(Guid gSysPowerID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_SysPower_Detail t_OfficeAutomation_Document_SysPower_Detail;
        T_OfficeAutomation_Document_SysPower_Detail_Apply t_OfficeAutomation_Document_SysPower_Detail_Apply;
        DA_OfficeAutomation_Document_SysPower_Detail_Inherit da_OfficeAutomation_Document_SysPower_Detail_Inherit = new DA_OfficeAutomation_Document_SysPower_Detail_Inherit();
        DA_OfficeAutomation_Document_SysPower_Detail_Apply_Inherit da_OfficeAutomation_Document_SysPower_Detail_Apply_Inherit = new DA_OfficeAutomation_Document_SysPower_Detail_Apply_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t_OfficeAutomation_Document_SysPower_Detail = new T_OfficeAutomation_Document_SysPower_Detail();
            t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_MainID = gSysPowerID;
            t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_EmployeeID = detail[0];
            t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_Employee = detail[1];
            t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_Position = detail[4];
            t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_Department = detail[2];
            t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_DepartmentID = detail[3] != "" ? new Guid(detail[3]) : new Guid();
            t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_BeginDate = DateTime.Parse(detail[5]);
            t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_ApplyTypeID = int.Parse(detail[7]);

            da_OfficeAutomation_Document_SysPower_Detail_Inherit.Insert(t_OfficeAutomation_Document_SysPower_Detail);

            string[] types = detail[6].Split(';');
            for (int x = 0; x < types.Length; x++)
            {
                if (types[x] == "20")
                    haveMCOA = true;

                t_OfficeAutomation_Document_SysPower_Detail_Apply = new T_OfficeAutomation_Document_SysPower_Detail_Apply();
                t_OfficeAutomation_Document_SysPower_Detail_Apply.OfficeAutomation_Document_SysPower_Detail_Apply_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_SysPower_Detail_Apply.OfficeAutomation_Document_SysPower_Detail_Apply_MainID = t_OfficeAutomation_Document_SysPower_Detail.OfficeAutomation_Document_SysPower_Detail_ID;
                t_OfficeAutomation_Document_SysPower_Detail_Apply.OfficeAutomation_Document_SysPower_Detail_Apply_ApplyDetailID = int.Parse(types[x]);

                da_OfficeAutomation_Document_SysPower_Detail_Apply_Inherit.Insert(t_OfficeAutomation_Document_SysPower_Detail_Apply);
            }
        }
    }

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
        foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        {
            sbJSON.Append("{\"id\":\"" + dr["id"].ToString() + "\",\"label\":\"" + dr["name"].ToString() + "\",\"value\":\"" + dr["name"].ToString() + "\"},");
        }
        sbJSON.Remove(sbJSON.Length - 1, 1);
        sbJSON.Append("]");
    }
    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite24"] = "1";
        Response.Write("<script>window.open('Apply_SysPower_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("(后勤/汇瀚/二级市场)IT权限申请表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_SysPower_Inherit da_OfficeAutomation_Document_SysPower_Inherit = new DA_OfficeAutomation_Document_SysPower_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SysPower_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SysPower_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_SysPower_Department"].ToString();
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
                    else if (i == 5) //20150104
                        da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndIdxs(MainID, i);
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
                    else if (i == 5) //20150104
                        da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndIdxs(MainID, i);
                    else
                        da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, i);
                    da_OfficeAutomation_Flow_Inherit.DDeleteFlows(MainID);
                }
                da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);
                if (i < 6 && EmployeeName == "梁锐华")  //20150104
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "6");
                if (i < 5)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "5,6");
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
            DA_OfficeAutomation_Document_SysPower_Inherit da_OfficeAutomation_Document_SysPower_Inherit = new DA_OfficeAutomation_Document_SysPower_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SysPower_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SysPower_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_SysPower_Department"].ToString();
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
                T_OfficeAutomation_Document_SysPower t_OfficeAutomation_Document_SysPower = new T_OfficeAutomation_Document_SysPower();
                ds = da_OfficeAutomation_Document_SysPower_Inherit.SelectByMainID(MainID);
                ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SysPower_ID"].ToString();

                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ID = new Guid(ID);
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_DepartmentID = new Guid(this.hdDispatchDepartmentID.Value);
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Department = this.txtDispatchDepartment.Text;
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Apply = this.txtApplicant.Text;
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Phone = this.txtPhone.Text;
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_ReqContent = this.txtReqContent.Text;
                t_OfficeAutomation_Document_SysPower.OfficeAutomation_Document_SysPower_Deal = this.txtDeal.Text;

                da_OfficeAutomation_Document_SysPower_Inherit.Update(t_OfficeAutomation_Document_SysPower);//修改(汇瀚/二级市场/后勤)IT权限申请表

                DA_OfficeAutomation_Document_SysPower_Detail_Inherit da_OfficeAutomation_Document_SysPower_Detail_Inherit = new DA_OfficeAutomation_Document_SysPower_Detail_Inherit();
                da_OfficeAutomation_Document_SysPower_Detail_Inherit.Delete(ID);
                InsertSysPowerDetail(new Guid(ID));
                da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "5,6");
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);//AlterC_a
                Common.SendDirectPushMessage(documentName, da_OfficeAutomation_Flow_Inherit.GetFirstByMainID(MainID)); //手机推送
                Common.AddLog(EmployeeID, EmployeeName, 6, new Guid(MainID), 2);//日志，修改(汇瀚/二级市场/后勤)IT权限申请表
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
            DA_OfficeAutomation_Document_SysPower_Inherit da_OfficeAutomation_Document_SysPower_Inherit = new DA_OfficeAutomation_Document_SysPower_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SysPower_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SysPower_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_SysPower_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "5,6");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 4); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_SysPower_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
}
