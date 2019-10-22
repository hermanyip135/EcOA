using DataAccess.Operate;
using DataEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_LinkageCoordination_Apply_LinkageCoordination_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();

    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();
    public string ApplyDisplayPart = "$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();";
    public string wyRecruit_ID = "";
    public StringBuilder SbFlow = new StringBuilder();//2016/9/23

    public int type = 0;
    public StringBuilder SBTable = new StringBuilder();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        SbJson.Append("[]");
        string UrlMainID = GetQueryString("MainID");

        SerialNumber = "";

        InitPage();

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["htmltopdf"] == "Yes")  //M_PDF
                {
                    SbJs.Append("<script type=\"text/javascript\">$(\"div .flow\").hide();$(\"#PageBottom\").hide();$('#trtpdf').append('<div class=\"signdate\"></div>');</script>");
                    tpdf = true;
                }
            }
            catch
            { }
            try
            {
                var FLG_ReWrite74 = Session["FLG_ReWrite74"] == null ? "" : Session["FLG_ReWrite74"].ToString();
                //if (Session["FLG_ReWrite74"].ToString() == "1")
                if (FLG_ReWrite74 == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite74"] = null;
                }
            }
            catch
            {
            }

            this.hidPageType.Value = GetQueryString("t");
            if (!string.IsNullOrEmpty(this.hidPageType.Value))
            {
                switch (this.hidPageType.Value)
                {
                    case "Inservice":
                        this.h1DocumentTitle.InnerText = "联动统筹中心入职申请表";
                        break;
                    case "Dimission":
                        this.h1DocumentTitle.InnerText = "联动统筹中心离职申请表";
                        break;
                    case "PersonalChange":
                        this.h1DocumentTitle.InnerText = "联动统筹中心调动申请表";
                        break;
                    default:
                        break;
                }
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
        {
            GetAllDepartment();//52100
        }
    }
    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        //this.txtApply.Attributes.Add("readonly", "readonly");
        //this.txtPosition.Attributes.Add("readonly", "readonly");
        //this.txtSecretary.Attributes.Add("readonly", "readonly");
        //this.txtSecretaryDepartment.Attributes.Add("readonly", "readonly");

        //this.txtApply.Attributes.Add("readonly", "readonly");
        //this.txtApplyDate.Attributes.Add("readonly", "readonly");
    }

    /// <summary>
    /// 新页面
    /// </summary>
    public void NewPage()
    {
        GetAllDepartment();//52100
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        this.txtApply.Value = EmployeeName;
        this.txtApplyDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);
        SbJs.Append("$(\"#remindRight\").show();");//2016/10/14-52100
        SbJs.Append("</script>");
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
        StructureHTMLTable(this.hidPageType.Value, null);
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

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

        SbJs.Append("<script type=\"text/javascript\">");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        //DataSet dsWYRecruit = new DataSet();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        //从数据库中读取
        //dsWYRecruit = WYRecruitBLL.SelectByMainID(MainID);
        //string WYRecruitID = dsWYRecruit.Tables[0].Rows[0]["OfficeAutomation_Document_WYRecruit_ID"].ToString();
        //wyRecruit_ID = WYRecruitID;//2016/8/29 52100

        T_OfficeAutomation_Document_LinkageCoordination obj = DA_OfficeAutomation_Document_LinkageCoordination_Inherit.SelectByID(MainID, "Main");


        string applicant = Mainobj.OfficeAutomation_Main_Creater;//dsWYRecruit.Tables[0].Rows[0]["OfficeAutomation_Document_WYRecruit_Apply"].ToString();       //申请人
        this.litSerialNumber.Text = Mainobj.OfficeAutomation_SerialNumber.ToString();
        this.hidPageType.Value = obj.OfficeAutomation_Document_LinkageCoordination_RecordType.ToString();
        this.txtEmpCode.Value = obj.OfficeAutomation_Document_LinkageCoordination_EmpCode.ToString();
        this.txtEmpName.Value = obj.OfficeAutomation_Document_LinkageCoordination_EmpName.ToString();
        this.txtApply.Value = Mainobj.OfficeAutomation_Main_Apply.ToString();
        this.txtApplyDate.Value = Mainobj.OfficeAutomation_Main_ApplyDate.ToString("yyyy-MM-dd");
        StructureHTMLTable(this.hidPageType.Value, obj);

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。

        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;

        SbJs.Append("$(\"#btnUpload\").show();");

        if (isApplicant)
        {
            SbJs.Append("$(\"#lbh1\").show();$(\"#lbh2\").show();$(\"#lbh3\").show();");
            if (flowState == "1" || flowState == "7")
            {
                GetAllDepartment();//52100
                btnSave.Visible = true;
                SbJs.Append(ApplyDisplayPart);
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();//52100
                btnSAlterC.Visible = true;
                SbJs.Append(ApplyDisplayPart);
            }
        }
        #endregion

        if (ViewState["FLG_ReWrite"] != null && ViewState["FLG_ReWrite"].ToString() == "1")
        {
            GetAllDepartment();//52100
            SbJs.Append(ApplyDisplayPart);
            SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
            SbJs.Append("$(\"#trAddAnoF1\").hide();$(\"#trAddAnoF3\").hide();"); //M_AddAnother：20150716 黄生其它意见，增加审批人
            SbJs.Append("</script>");
            btnSPDF.Visible = false; //M_PDF
            flowState = "1";
            btnSAlterC.Visible = false;
            btnSave.Visible = true;
            IsNewApply = true;
            MainID = Guid.NewGuid().ToString();
            return;
        }
        if (isApplicant)
        {
            //btnReWrite.Visible = true; //*-+
        }

        #region 审批已完成后当前登录人为HR时，更改实际报销情况//52100
        DataSet lastFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainIDDesc(MainID);
        //if (lastFlow.Tables[0].Rows.Count > 1)
        //{
        //    if (lastFlow.Tables[0].Rows[0]["OfficeAutomation_Flow_Employee"].ToString().Contains(EmployeeName) && dsWYRecruit.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
        //    {
        //        this.btnHRSave.Visible = true;
        //    }
        //}
        #endregion

        #region 显示流程示意图
        //自定义控件赋值
        var flowshowlist = da_OfficeAutomation_Flow_Inherit.GetFlowShowList(dsFlow);
        this.FlowShow1.FlowShowList = flowshowlist;

        //签名列表
        var flowsignlist = da_OfficeAutomation_Flow_Inherit.GetFlowsSignList(dsFlow, EmployeeID, EmployeeName);
        if (flowsignlist != null)
        {
            this.hidSignFlowsJson.Value = Newtonsoft.Json.JsonConvert.SerializeObject(flowsignlist);
        }

        #endregion

        #region 按钮是否开启
        T_OfficeAutomation_Flow flows;//789
        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 130);
        if (flows != null) { SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();"); }

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
        if (flowState == "1" && applicant == EmployeeName) { this.FlowShow1.ShowEditBtn = true; }
        if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
        {
            //btnEditFlow2.Visible = true;
        }

        DataSet dsMain = new DataSet();
        dsMain = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID); //20141231：M_DeleteC
        if (dsMain.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            dsMain = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlowsByMID(MainID);
            SbJs.Append("$('#btnADelete').before('<div id=\"SummaryOfDelete_Red\" style=\"color: red; font-size: large; font-weight: bold\">（该表即将被删除）</div>');$('h1').css('color','red');");
            string[] employnames;
            string employname;
            foreach (DataRow dr2 in dsMain.Tables[0].Rows)
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
            //btnEditFlow2.Visible = false;
            #endregion
        }
        else //20150225：M_DeleteC 不同意时显示最后确认时间
        {
            DA_OfficeAutomation_Document_LastSure_Inherit da_OfficeAutomation_Document_LastSure_Inherit = new DA_OfficeAutomation_Document_LastSure_Inherit();
            dsMain = da_OfficeAutomation_Document_LastSure_Inherit.SelectByMid(MainID);
            if (dsMain.Tables[0].Rows.Count > 0)
            {
                SbJs.Append("$('#snum').prepend('<span id=\"SummaryOfDelete_Green\" style=\"color: green; float:left; font-weight: bold\">区域最后确认时间：" + dsMain.Tables[0].Rows[0]["OfficeAutomation_Document_LastSure_Time"].ToString() + "</span>');");
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

        //gvAttach.DataSource = dsAttach;
        //gvAttach.DataBind();

        //如果该单有附件，则下载按钮显示
        //btnDownload.Visible = (dsAttach != null && dsAttach.Tables[0] != null && dsAttach.Tables[0].Rows.Count > 0);
    }


    #region 根据pagetype构造对应的table
    protected void StructureHTMLTable(string pagetype, T_OfficeAutomation_Document_LinkageCoordination obj)
    {
        switch (pagetype)
        {
            case "Inservice":
                if (obj != null)
                {
                    #region [入职申请表格]
                    SBTable.Append(" <table id=\"tbInservice\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\" rowspan=\"5\">入职申请</td> ");
                    SBTable.Append("     <td class=\"auto-style4\">部门分行</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceDeptment\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartment + "\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">职位名称</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInservicePosition\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Inservice_Position + "\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">职等名称</td> <td class=\"tl PL10\"> ");

                    //SBTable.Append("       <select id=\"sbInservicePosGrade\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> </select><option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option> </select> ");

                    SBTable.Append("       <select id=\"sbInservicePosGrade\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> ");

                    switch (obj.OfficeAutomation_Document_LinkageCoordination_Inservice_PosGrade)
                    {
                        case "1":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\" selected=\"selected\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "2":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\" selected=\"selected\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> </select><option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "3":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\" selected=\"selected\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "4":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\" selected=\"selected\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "5":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\" selected=\"selected\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "6":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\" selected=\"selected\">第六职等</option>  ");
                            break;
                        default:
                            SBTable.Append("<option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                    }

                    SBTable.Append("       </select>");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">基本工资</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceBasicSalary\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary + "\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">入职日期</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceEnterDate\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate.ToString("yyyy-MM-dd") + "\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">计佣角色</td> <td class=\"tl PL10\"> ");
                    //SBTable.Append("       <select id=\"sbInserviceEccRole\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"86B29D28-0545-4772-AF3C-17B9ABEC4D6F\">店董</option> <option value=\"8EF96719-C261-4D2F-8CC2-4133776E62B5\">组长</option> <option value=\"69462582-770A-45B0-B940-6FA48E907117\">组员</option> <option value=\"5C368720-46E6-4679-86D1-48115E52D80C\">新人</option> </select> ");

                    SBTable.Append("       <select id=\"sbInserviceEccRole\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> ");

                    switch (obj.OfficeAutomation_Document_LinkageCoordination_Inservice_EccRole)
                    {
                        case "1":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\" selected=\"selected\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> ");
                            break;
                        case "2":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\" selected=\"selected\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> ");
                            break;
                        case "3":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\" selected=\"selected\" >组员</option> <option value=\"4\">新人</option> ");
                            break;
                        case "4":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\" selected=\"selected\">新人</option> ");
                            break;
                        default:
                            SBTable.Append(" <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> ");
                            break;
                    }

                    SBTable.Append("       </select>");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">该人员最近一次离职前三个月业绩</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceLastDimissionComm\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Inservice_LastComm + "\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">亲属关系</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceRelationShip\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Inservice_Relationship + "\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">行家业绩</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceOtherComm\" type=\"text\" style=\"width: 100px;\"  runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Inservice_OtherCompanyComm + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">工作性质</td> <td class=\"tl PL10\"> ");
                    //SBTable.Append("     <select id=\"sbInserviceWorkNature\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"4ECD2706-467F-49B1-9C94-80CEFEC5DFC6\">主管</option> <option value=\"A9970ED1-64F5-4C66-BB71-C9E3463C611C\">驻场</option> <option value=\"660AAA33-739D-43EA-9EBF-82A25AB16C32\">文书对接</option> </select> ");

                    SBTable.Append("       <select id=\"sbInserviceWorkNature\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> ");

                    switch (obj.OfficeAutomation_Document_LinkageCoordination_Inservice_WorkNature)
                    {
                        case "1":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\" selected=\"selected\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\">文书对接</option> ");
                            break;
                        case "2":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\" selected=\"selected\">驻场</option> <option value=\"3\">文书对接</option> ");
                            break;
                        case "3":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\" selected=\"selected\">文书对接</option> ");
                            break;
                        default:
                            SBTable.Append(" <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\">文书对接</option> ");
                            break;
                    }

                    SBTable.Append("       </select>");
                    SBTable.Append("     </td> <td class=\"auto-style4\">直属主管</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceZSSupervisor\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_ZSSupervisor + "\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">隶属主管</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceLSSupervisor\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_LSSupervisor + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">备注</td> <td class=\"tl PL10\" colspan=\"5\"> ");
                    SBTable.Append("       <textarea id=\"txtInserviceRemark\" cols=\"20\" rows=\"3\" style=\"width: 90%;\" runat=\"server\" clientidmode=\"Static\">" + obj.OfficeAutomation_Document_LinkageCoordination_Remark + "</textarea> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append(" </table ");
                    #endregion

                }
                else
                {
                    #region [入职申请表格]
                    SBTable.Append(" <table id=\"tbInservice\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\" rowspan=\"5\">入职申请</td> ");
                    SBTable.Append("     <td class=\"auto-style4\">部门分行</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceDeptment\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">职位名称</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInservicePosition\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">职等名称</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <select id=\"sbInservicePosGrade\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option> </select> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">基本工资</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceBasicSalary\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">入职日期</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceEnterDate\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">计佣角色</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <select id=\"sbInserviceEccRole\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> </select> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">该人员最近一次离职前三个月业绩</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceLastDimissionComm\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">亲属关系</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceRelationShip\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">行家业绩</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceOtherComm\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">工作性质</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("     <select id=\"sbInserviceWorkNature\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\">文书对接</option> </select> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">直属主管</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceZSSupervisor\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">隶属主管</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtInserviceLSSupervisor\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">备注</td> <td class=\"tl PL10\" colspan=\"5\"> ");
                    SBTable.Append("       <textarea id=\"txtInserviceRemark\" cols=\"20\" rows=\"3\" style=\"width: 90%;\" runat=\"server\" clientidmode=\"Static\"></textarea> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append(" </table ");
                    #endregion
                }
                break;
            case "Dimission":
                if (obj != null)
                {
                    #region [离职申请表格]
                    SBTable.Append(" <table id=\"tbDimission\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\" rowspan=\"8\">离职申请</td> ");
                    SBTable.Append("     <td class=\"auto-style4\">部门分行</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtDimissionDeptment\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Dimission_Department + "\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">职位名称</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtDimmissionPosition\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Dimission_Position + "\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">职等名称</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtDimmissionPosGrade\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Dimission_PosGrade + "\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">入职日期</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtDimmissionEnterDate\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">离职前三个月<br />业绩明细及合计</td> <td class=\"tdDetailCss\" colspan=\"3\"> ");
                    SBTable.Append("       <table id=\"\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");
                    SBTable.Append("        <tr>  ");
                    SBTable.Append("            <td class=\"auto-style4\">2019-06</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">2019-07</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">2019-08</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">近三个月总计</td> ");
                    SBTable.Append("        </tr>  ");

                    SBTable.Append("        <tr>  ");
                    SBTable.Append("            <td class=\"auto-style4\">&nbsp;</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">&nbsp;</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">&nbsp;</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">&nbsp;</td> ");
                    SBTable.Append("        </tr>  ");

                    SBTable.Append("       </table> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">离职类别</td> <td class=\"tl PL10\" colspan=\"3\"> ");

                    //离职类型
                    var temp = obj.OfficeAutomation_Document_LinkageCoordination_Dimission_Type;
                    #region [离职类型]
                    if (temp.Contains("1"))
                    {
                        SBTable.Append("       <input id=\"rbtnDimissionType1\" type=\"radio\" name=\"DimissionType\" value=\"1\" style=\"vertical-align: middle; margin-left: 2px;\" runat=\"server\" clientidmode=\"Static\" checked=\"checked\" /> <label style=\"vertical-align: middle;\" for=\"rbtnDimissionType1\" >员工辞职</label> ");
                    }
                    else
                    {
                        SBTable.Append("       <input id=\"rbtnDimissionType1\" type=\"radio\" name=\"DimissionType\" value=\"1\" style=\"vertical-align: middle; margin-left: 2px;\" runat=\"server\" clientidmode=\"Static\" /> <label style=\"vertical-align: middle;\" for=\"rbtnDimissionType1\" >员工辞职</label> ");
                    }

                    if (temp.Contains("2"))
                    {
                        SBTable.Append("       <input id=\"rbtnDimissionType2\" type=\"radio\" name=\"DimissionType\" value=\"2\" style=\"vertical-align: middle; margin-left: 2px;\" runat=\"server\" clientidmode=\"Static\" checked=\"checked\" /> <label style=\"vertical-align: middle;\" for=\"rbtnDimissionType2\" >公司辞退</label>  ");
                    }
                    else
                    {
                        SBTable.Append("       <input id=\"rbtnDimissionType2\" type=\"radio\" name=\"DimissionType\" value=\"2\" style=\"vertical-align: middle; margin-left: 2px;\" runat=\"server\" clientidmode=\"Static\" /> <label style=\"vertical-align: middle;\" for=\"rbtnDimissionType2\" >公司辞退</label>  ");
                    }
                    #endregion

                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr> ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">离职原因</td> ");
                    SBTable.Append("     <td class=\"tdDetailCss\" colspan=\"3\" > ");

                    SBTable.Append("      <table id=\"tbDimissionReasons\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");

                    SBTable.Append("          <tr>  ");
                    SBTable.Append("            <td> ");

                    //离职原因
                    temp = obj.OfficeAutomation_Document_LinkageCoordination_Dimission_Reason;

                    #region [离职原因]
                    if (temp.Contains("1"))
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason1\" name=\"DimissionReason\" type=\"radio\" value=\"1\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason1\">私人原因</label> ");
                    }
                    else
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason1\" name=\"DimissionReason\" type=\"radio\" value=\"1\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason1\">私人原因</label> ");
                    }

                    SBTable.Append("            </td> ");
                    SBTable.Append("            <td> ");

                    if (temp.Contains("2"))
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason2\" name=\"DimissionReason\" type=\"radio\" value=\"2\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason2\">严重违反公司规章制度</label> ");
                    }
                    else
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason2\" name=\"DimissionReason\" type=\"radio\" value=\"2\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason2\">严重违反公司规章制度</label> ");
                    }

                    SBTable.Append("            </td> ");
                    SBTable.Append("          </tr>  ");
                    SBTable.Append("          <tr>  ");
                    SBTable.Append("            <td> ");

                    if (temp.Contains("3"))
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason3\" name=\"DimissionReason\" type=\"radio\" value=\"3\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason3\">劳动合同期满不再续约</label> ");
                    }
                    else
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason3\" name=\"DimissionReason\" type=\"radio\" value=\"3\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason3\">劳动合同期满不再续约</label> ");
                    }

                    SBTable.Append("            </td> ");
                    SBTable.Append("            <td> ");

                    if (temp.Contains("4"))
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason4\" name=\"DimissionReason\" type=\"radio\" value=\"4\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason4\">双方协商解除劳动合同</label> ");
                    }
                    else
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason4\" name=\"DimissionReason\" type=\"radio\" value=\"4\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason4\">双方协商解除劳动合同</label> ");
                    }

                    SBTable.Append("            </td> ");
                    SBTable.Append("          </tr>  ");
                    SBTable.Append("          <tr>  ");
                    SBTable.Append("            <td colspan=\"2\"> ");

                    if (temp.Contains("5"))
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason5\" name=\"DimissionReason\" type=\"radio\" value=\"5\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle; float:left;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason5\">其他</label> ");
                        SBTable.Append("                <input id=\"txtDimissionReason5\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; border: none; border-bottom: 1px solid black; display:block; float:left;\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Dimission_ReasonRemark + "\" /> ");
                    }
                    else
                    {
                        SBTable.Append("                <input id=\"rbtDimissionReason5\" name=\"DimissionReason\" type=\"radio\" value=\"5\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle; float:left;\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason5\">其他</label> ");
                        SBTable.Append("                <input id=\"txtDimissionReason5\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; border: none; border-bottom: 1px solid black; display:none; float:left;\"  /> ");
                    } 
                    #endregion

                    SBTable.Append("            </td> ");
                    SBTable.Append("          </tr>  ");
                    SBTable.Append("       </table ");
                    SBTable.Append("    </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">提交辞职申请日期</td> <td class=\"tl PL10\" colspan=\"\"> ");
                    SBTable.Append("       <input id=\"txtDimissionApplyDate\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate.ToString("yyyy-MM-dd") + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">最后出勤日期</td> <td class=\"tl PL10\" colspan=\"\"> ");
                    SBTable.Append("       <input id=\"txtDimissionLastDate\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate.ToString("yyyy-MM-dd") + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">直属主管</td> <td class=\"tl PL10\" colspan=\"\"> ");
                    SBTable.Append("       <input id=\"txtDimissionZSSupervisor\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_ZSSupervisor + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">隶属主管</td> <td class=\"tl PL10\" colspan=\"\"> ");
                    SBTable.Append("       <input id=\"txtDimissionLSSupervisor\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_LSSupervisor + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">备注</td> <td class=\"tl PL10\" colspan=\"3\"> ");
                    SBTable.Append("       <textarea id=\"txtDimissionRemark\" cols=\"20\" rows=\"3\" style=\"width: 90%;\" runat=\"server\" clientidmode=\"Static\">" + obj.OfficeAutomation_Document_LinkageCoordination_Remark + "</textarea> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");


                    SBTable.Append(" </table ");
                    #endregion
                }
                else
                {
                    #region [离职申请表格]
                    SBTable.Append(" <table id=\"tbDimission\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\" rowspan=\"8\">离职申请</td> ");
                    SBTable.Append("     <td class=\"auto-style4\">部门分行</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtDimissionDeptment\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">职位名称</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtDimmissionPosition\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">职等名称</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtDimmissionPosGrade\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> <td class=\"auto-style4\">入职日期</td> <td class=\"tl PL10\"> ");
                    SBTable.Append("       <input id=\"txtDimmissionEnterDate\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">离职前三个月<br />业绩明细及合计</td> <td class=\"tdDetailCss\" colspan=\"3\"> ");
                    SBTable.Append("       <table id=\"\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");
                    SBTable.Append("        <tr>  ");
                    SBTable.Append("            <td class=\"auto-style4\">2019-06</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">2019-07</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">2019-08</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">近三个月总计</td> ");
                    SBTable.Append("        </tr>  ");

                    SBTable.Append("        <tr>  ");
                    SBTable.Append("            <td class=\"auto-style4\">&nbsp;</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">&nbsp;</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">&nbsp;</td> ");
                    SBTable.Append("            <td class=\"auto-style4\">&nbsp;</td> ");
                    SBTable.Append("        </tr>  ");

                    SBTable.Append("       </table> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">离职类别</td> <td class=\"tl PL10\" colspan=\"3\"> ");
                    SBTable.Append("       <input id=\"rbtnDimissionType1\" type=\"radio\" name=\"DimissionType\" value=\"1\" style=\"vertical-align: middle; margin-left: 2px;\" runat=\"server\" clientidmode=\"Static\" /> <label style=\"vertical-align: middle;\" for=\"rbtnDimissionType1\" >员工辞职</label> <input id=\"rbtnDimissionType2\" type=\"radio\" name=\"DimissionType\" value=\"2\" style=\"vertical-align: middle; margin-left: 2px;\" runat=\"server\" clientidmode=\"Static\" /> <label style=\"vertical-align: middle;\"for=\"rbtnDimissionType2\" >公司辞退</label> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr> ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">离职原因</td> ");
                    SBTable.Append("     <td class=\"tdDetailCss\" colspan=\"3\" > ");

                    SBTable.Append("      <table id=\"tbDimissionReasons\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");
                    SBTable.Append("          <tr>  ");
                    SBTable.Append("            <td> ");
                    SBTable.Append("                <input id=\"rbtDimissionReason1\" name=\"DimissionReason\" type=\"radio\" value=\"1\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason1\">私人原因</label> ");
                    SBTable.Append("            </td> ");
                    SBTable.Append("            <td> ");
                    SBTable.Append("                <input id=\"rbtDimissionReason2\" name=\"DimissionReason\" type=\"radio\" value=\"2\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason2\">严重违反公司规章制度</label> ");
                    SBTable.Append("            </td> ");
                    SBTable.Append("          </tr>  ");
                    SBTable.Append("          <tr>  ");
                    SBTable.Append("            <td> ");
                    SBTable.Append("                <input id=\"rbtDimissionReason3\" name=\"DimissionReason\" type=\"radio\" value=\"3\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason3\">劳动合同期满不再续约</label> ");
                    SBTable.Append("            </td> ");
                    SBTable.Append("            <td> ");
                    SBTable.Append("                <input id=\"rbtDimissionReason4\" name=\"DimissionReason\" type=\"radio\" value=\"4\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason4\">双方协商解除劳动合同</label> ");
                    SBTable.Append("            </td> ");
                    SBTable.Append("          </tr>  ");
                    SBTable.Append("          <tr>  ");
                    SBTable.Append("            <td colspan=\"2\"> ");
                    SBTable.Append("                <input id=\"rbtDimissionReason5\" name=\"DimissionReason\" type=\"radio\" value=\"5\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle; \" /> <label class=\"rbtLabelCss\" for=\"rbtDimissionReason5\">其他</label> ");
                    SBTable.Append("                <input id=\"txtDimissionReason5\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; border: none; border-bottom: 1px solid black; visibility: hidden; \" /> ");
                    SBTable.Append("            </td> ");
                    SBTable.Append("          </tr>  ");
                    SBTable.Append("       </table ");
                    SBTable.Append("    </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">提交辞职申请日期</td> <td class=\"tl PL10\" colspan=\"\"> ");
                    SBTable.Append("       <input id=\"txtDimissionApplyDate\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">最后出勤日期</td> <td class=\"tl PL10\" colspan=\"\"> ");
                    SBTable.Append("       <input id=\"txtDimissionLastDate\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">直属主管</td> <td class=\"tl PL10\" colspan=\"\"> ");
                    SBTable.Append("       <input id=\"txtDimissionZSSupervisor\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">隶属主管</td> <td class=\"tl PL10\" colspan=\"\"> ");
                    SBTable.Append("       <input id=\"txtDimissionLSSupervisor\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">备注</td> <td class=\"tl PL10\" colspan=\"3\"> ");
                    SBTable.Append("       <textarea id=\"txtDimissionRemark\" cols=\"20\" rows=\"3\" style=\"width: 90%;\" runat=\"server\" clientidmode=\"Static\"></textarea> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");


                    SBTable.Append(" </table ");
                    #endregion
                }
                break;
            case "PersonalChange":
                if (obj != null)
                {
                    #region [人事调动表格]
                    SBTable.Append(" <table id=\"tbPersonalChange\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");

                    SBTable.Append("   <tr> ");
                    SBTable.Append("     <td class=\"auto-style4\" rowspan=\"11\">调动申请</td> ");
                    SBTable.Append("     <td class=\"auto-style4\" colspan=\"3\">现任</td> ");
                    SBTable.Append("     <td class=\"auto-style4\" colspan=\"3\">调整后</td> ");
                    SBTable.Append("   </tr> ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">职位名称</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangePositionOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Position + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">职位名称</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <input id=\"txtPersonalChangePositionNew\" type=\"text\" runat=\"server\" style=\"width: 100px;\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Position + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">职等名称</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangePosGradeOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PosGrade + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">职等名称</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    //SBTable.Append("       <select id=\"sbPersonalChangePosGradeNew\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option> </select> ");
                    SBTable.Append("       <select id=\"sbPersonalChangePosGradeNew\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> ");

                    switch (obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PosGrade)
                    {
                        case "1":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\" selected=\"selected\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "2":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\" selected=\"selected\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> </select><option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "3":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\" selected=\"selected\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "4":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\" selected=\"selected\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "5":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\" selected=\"selected\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                        case "6":
                            SBTable.Append("<option value=\"-1\" >--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\" selected=\"selected\">第六职等</option>  ");
                            break;
                        default:
                            SBTable.Append("<option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option>  ");
                            break;
                    }

                    SBTable.Append("       </select>");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">基本工资</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeBasicSalaryOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">基本工资</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <input id=\"txtPersonalChangeBasicSalaryNew\" type=\"text\" runat=\"server\" style=\"width: 100px;\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">直属主管</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeZSSupervisorOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">直属主管</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <input id=\"txtPersonalChangeZSSupervisorNew\" type=\"text\" runat=\"server\" style=\"width: 100px;\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_ZSSupervisor + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">隶属主管</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeLSSupervisorOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_LSSupervisor + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">隶属主管</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <input id=\"txtPersonalChangeLSSupervisorNew\" type=\"text\" runat=\"server\" style=\"width: 100px;\" clientidmode=\"Static\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_LSSupervisor + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">计佣角色</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeEccRoleOld\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; \" readonly=\"readonly\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRole + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">计佣角色</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    //SBTable.Append("       <select id=\"sbPersonalChangeEccRoleNew\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> </select> ");

                    SBTable.Append("       <select id=\"sbPersonalChangeEccRoleNew\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> ");

                    switch (obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRole)
                    {
                        case "1":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\" selected=\"selected\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> ");
                            break;
                        case "2":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\" selected=\"selected\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> ");
                            break;
                        case "3":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\" selected=\"selected\" >组员</option> <option value=\"4\">新人</option> ");
                            break;
                        case "4":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\" selected=\"selected\">新人</option> ");
                            break;
                        default:
                            SBTable.Append(" <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> ");
                            break;
                    }

                    SBTable.Append("       </select>");

                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">工作性质</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("        <input id=\"txtPersonalChangeWorkNatureOld\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; \" readonly=\"readonly\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNature + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">工作性质</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    //SBTable.Append("     <select id=\"sbPersonalChangeWorkNatureNew\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\">文书对接</option> </select> ");
                    SBTable.Append("       <select id=\"sbPersonalChangeWorkNatureNew\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> ");

                    switch (obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNature)
                    {
                        case "1":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\" selected=\"selected\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\">文书对接</option> ");
                            break;
                        case "2":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\" selected=\"selected\">驻场</option> <option value=\"3\">文书对接</option> ");
                            break;
                        case "3":
                            SBTable.Append(" <option value=\"-1\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\" selected=\"selected\">文书对接</option> ");
                            break;
                        default:
                            SBTable.Append(" <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\">文书对接</option> ");
                            break;
                    }

                    SBTable.Append("       </select>");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">生效日期</td> <td class=\"tl PL10\" colspan=\"5\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeEffectiveDate\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px;\" value=\"" + obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate + "\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    var PersonalChangeType = obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangType.ToString();

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">变动类型</td> <td colspan=\"5\" class=\"tdDetailCss\"> ");
                    SBTable.Append("        <table id=\"tbPersonalChangeType\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td> ");

                    if (PersonalChangeType.Contains("1"))
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType1\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"1\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType1\">通过试用期</label> ");
                    }
                    else
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType1\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"1\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType1\">通过试用期</label> ");
                    }

                    SBTable.Append("                </td> ");
                    SBTable.Append("                <td> ");
                    //SBTable.Append("                    <input id=\"ckbPersonalChangeType2\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"2\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType2\">升职</label> ");
                    if (PersonalChangeType.Contains("2"))
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType2\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"2\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType2\">升职</label> ");
                    }
                    else
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType2\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"2\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType2\">升职</label> ");
                    }

                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td> ");
                    //SBTable.Append("                    <input id=\"ckbPersonalChangeType3\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"3\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType3\">降职</label> ");

                    if (PersonalChangeType.Contains("3"))
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType3\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"3\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType3\">降职</label> ");
                    }
                    else
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType3\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"3\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType3\">降职</label> ");
                    }

                    SBTable.Append("                </td> ");
                    SBTable.Append("                <td> ");
                    //SBTable.Append("                    <input id=\"ckbPersonalChangeType4\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"4\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType4\">调薪</label> ");

                    if (PersonalChangeType.Contains("4"))
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType4\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"4\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType4\">调薪</label> ");
                    }
                    else
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType4\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"4\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType4\">调薪</label> ");
                    }

                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td> ");
                    //SBTable.Append("                    <input id=\"ckbPersonalChangeType5\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"5\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType5\">调职/变更隶属关系</label> ");

                    if (PersonalChangeType.Contains("5"))
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType5\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"5\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType5\">调职/变更隶属关系</label> ");
                    }
                    else
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType5\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"5\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType5\">调职/变更隶属关系</label> ");
                    }

                    SBTable.Append("                </td> ");
                    SBTable.Append("                <td> ");
                    //SBTable.Append("                    <input id=\"ckbPersonalChangeType6\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"6\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType6\">转会（部门负责人变更）</label> ");

                    if (PersonalChangeType.Contains("6"))
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType6\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"6\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType6\">转会（部门负责人变更）</label> ");
                    }
                    else
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType6\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"6\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType6\">转会（部门负责人变更）</label> ");
                    }

                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td colspan=\"2\"> ");
                    //SBTable.Append("                    <input id=\"ckbPersonalChangeType7\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"7\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType7\">实习生转试用员工</label> ");

                    if (PersonalChangeType.Contains("7"))
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType7\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"7\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType7\">实习生转试用员工</label> ");
                    }
                    else
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType7\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"7\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType7\">实习生转试用员工</label> ");
                    }

                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td colspan=\"2\"> ");
                    //SBTable.Append("                    <input id=\"ckbPersonalChangeType8\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"8\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType8\">其他</label> <input id=\"txtPersonalChangeType8\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 150px; visibility:hidden;\" /> ");

                    if (PersonalChangeType.Contains("8"))
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType8\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"8\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" checked=\"checked\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType8\">其他</label> <input id=\"txtPersonalChangeType8\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 150px; visibility:visible;\" /> ");
                    }
                    else
                    {
                        SBTable.Append("                    <input id=\"ckbPersonalChangeType8\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"8\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType8\">其他</label> <input id=\"txtPersonalChangeType8\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 150px; visibility:hidden;\" /> ");
                    }

                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");

                    SBTable.Append("        </table> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");


                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">备注</td> <td class=\"tl PL10\" colspan=\"6\"> ");
                    SBTable.Append("       <textarea id=\"txtDimissionRemark\" cols=\"20\" rows=\"3\" style=\"width: 90%;\" runat=\"server\" clientidmode=\"Static\"></textarea> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");


                    SBTable.Append(" </table ");
                    #endregion
                }
                else
                {
                    #region [人事调动表格]
                    SBTable.Append(" <table id=\"tbPersonalChange\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");

                    SBTable.Append("   <tr> ");
                    SBTable.Append("     <td class=\"auto-style4\" rowspan=\"11\">调动申请</td> ");
                    SBTable.Append("     <td class=\"auto-style4\" colspan=\"3\">现任</td> ");
                    SBTable.Append("     <td class=\"auto-style4\" colspan=\"3\">调整后</td> ");
                    SBTable.Append("   </tr> ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">职位名称</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangePositionOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">职位名称</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <input id=\"txtPersonalChangePositionNew\" type=\"text\" runat=\"server\" style=\"width: 100px;\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">职等名称</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangePosGradeOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">职等名称</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <select id=\"sbPersonalChangePosGradeNew\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">第一职等</option> <option value=\"2\">第二职等</option> <option value=\"3\">第三职等</option> <option value=\"4\">第四职等</option> <option value=\"5\">第五职等</option> <option value=\"6\">第六职等</option> </select> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">基本工资</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeBasicSalaryOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">基本工资</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <input id=\"txtPersonalChangeBasicSalaryNew\" type=\"text\" runat=\"server\" style=\"width: 100px;\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">直属主管</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeZSSupervisorOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">直属主管</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <input id=\"txtPersonalChangeZSSupervisorNew\" type=\"text\" runat=\"server\" style=\"width: 100px;\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">隶属主管</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeLSSupervisorOld\" type=\"text\" style=\"width: 100px;\" runat=\"server\" clientidmode=\"Static\" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">隶属主管</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <input id=\"txtPersonalChangeLSSupervisorNew\" type=\"text\" runat=\"server\" style=\"width: 100px;\" clientidmode=\"Static\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">计佣角色</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    //SBTable.Append("       <select id=\"sbPersonalChangeEccRoleOld\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> </select> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeEccRoleOld\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; \" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">计佣角色</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("       <select id=\"sbPersonalChangeEccRoleNew\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">店董</option> <option value=\"2\">组长</option> <option value=\"3\">组员</option> <option value=\"4\">新人</option> </select> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">工作性质</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\"> ");
                    //SBTable.Append("     <select id=\"\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\">文书对接</option> </select> ");
                    SBTable.Append("        <input id=\"txtPersonalChangeWorkNatureOld\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; \" readonly=\"readonly\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("     <td class=\"auto-style4\">工作性质</td> ");
                    SBTable.Append("     <td class=\"tl PL10\" colspan=\"2\">  ");
                    SBTable.Append("     <select id=\"sbPersonalChangeWorkNatureNew\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px; height: 24px; line-height: 22px; vertical-align: middle;\"> <option value=\"-1\" selected=\"selected\">--请选择</option> <option value=\"1\">主管</option> <option value=\"2\">驻场</option> <option value=\"3\">文书对接</option> </select> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">生效日期</td> <td class=\"tl PL10\" colspan=\"5\"> ");
                    SBTable.Append("       <input id=\"txtPersonalChangeEffectiveDate\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 100px;\" /> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");

                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">变动类型</td> <td colspan=\"5\" class=\"tdDetailCss\"> ");
                    SBTable.Append("        <table id=\"tbPersonalChangeType\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"tbDetailCss\"> ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td> ");
                    SBTable.Append("                    <input id=\"ckbPersonalChangeType1\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"1\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType1\">通过试用期</label> ");
                    SBTable.Append("                </td> ");
                    SBTable.Append("                <td> ");
                    SBTable.Append("                    <input id=\"ckbPersonalChangeType2\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"2\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType2\">升职</label> ");
                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td> ");
                    SBTable.Append("                    <input id=\"ckbPersonalChangeType3\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"3\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType3\">降职</label> ");
                    SBTable.Append("                </td> ");
                    SBTable.Append("                <td> ");
                    SBTable.Append("                    <input id=\"ckbPersonalChangeType4\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"4\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType4\">调薪</label> ");
                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td> ");
                    SBTable.Append("                    <input id=\"ckbPersonalChangeType5\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"5\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType5\">调职/变更隶属关系</label> ");
                    SBTable.Append("                </td> ");
                    SBTable.Append("                <td> ");
                    SBTable.Append("                    <input id=\"ckbPersonalChangeType6\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"6\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType6\">转会（部门负责人变更）</label> ");
                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td colspan=\"2\"> ");
                    SBTable.Append("                    <input id=\"ckbPersonalChangeType7\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"7\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType7\">实习生转试用员工</label> ");
                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");
                    SBTable.Append("            <tr>  ");
                    SBTable.Append("                <td colspan=\"2\"> ");
                    SBTable.Append("                    <input id=\"ckbPersonalChangeType8\" name=\"PersonalChangeType\" type=\"checkbox\" value=\"8\" runat=\"server\" clientidmode=\"Static\" style=\"vertical-align: middle;\" /> <label class=\"rbtLabelCss\" for=\"ckbPersonalChangeType8\">其他</label> <input id=\"txtPersonalChangeType8\" type=\"text\" runat=\"server\" clientidmode=\"Static\" style=\"width: 150px; visibility:hidden;\" /> ");
                    SBTable.Append("                </td> ");
                    SBTable.Append("            </tr>  ");

                    SBTable.Append("        </table> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");


                    SBTable.Append("   <tr>  ");
                    SBTable.Append("     <td class=\"auto-style4\">备注</td> <td class=\"tl PL10\" colspan=\"6\"> ");
                    SBTable.Append("       <textarea id=\"txtDimissionRemark\" cols=\"20\" rows=\"3\" style=\"width: 90%;\" runat=\"server\" clientidmode=\"Static\"></textarea> ");
                    SBTable.Append("     </td> ");
                    SBTable.Append("   </tr>  ");


                    SBTable.Append(" </table ");
                    #endregion
                }
                break;
            default:
                break;
        }
    }
    #endregion

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    protected void GetAllDepartment()
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
        else { SbJson = (StringBuilder)Cache["AllDepartment"]; }
    }
    #endregion

    #region 保存按钮点击事件
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region 创建对象

        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_LinkageCoordination t_OfficeAutomation_Document_LinkageCoordination = new T_OfficeAutomation_Document_LinkageCoordination();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        //DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion

        try
        {
            var FLG_ReWrite = ViewState["FLG_ReWrite"] == null || ViewState["FLG_ReWrite"] == "" ? "" : ViewState["FLG_ReWrite"].ToString();
            if (FLG_ReWrite == "1")
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
            //if (MainID == "")
            if (IsNewApply)
            {
                #region 新建
                //20170608 注释掉，如果不注释掉，弹出请正确选择发文部门的提示后再点击保存会走到修改编辑
                // IsNewApply = false;
                DataSet ds = new DataSet();

                //string[] sHRTree = null;
                //try
                //{
                //    sHRTree = Common.GetHRTreeByDepartmentID(this.hidDeptID.Value).Split('|');
                //}
                //catch
                //{
                //    Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                //    return;
                //}

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();

                //t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "LinkageCoordination" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                //t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 31; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表
                int OperateModule_ID = 0;
                switch (this.hidPageType.Value)
                {
                    case "Inservice":
                        t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "LCInservice" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                        t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 105; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表
                        OperateModule_ID = 94;
                        break;
                    case "Dimission":
                        t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "LCDimission" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                        t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 106; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表
                        OperateModule_ID = 95;
                        break;
                    case "PersonalChange":
                        t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "LCPersonalChange" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                        t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 107; //在《申请表字典表》找到该表的主键，这步一错则会打开别的表
                        OperateModule_ID = 96;
                        break;
                    default:
                        break;
                }

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_RecordType = this.hidPageType.Value;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Apply = EmployeeName;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_EmpCode = this.txtEmpCode.Value;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_EmpName = this.txtEmpName.Value;

                string[] details = Regex.Split(hidDetail.Value, "\\|\\|");
                for (int i = 0; i < details.Length; i++)
                {
                    string[] detail = Regex.Split(details[i], "\\&\\&");
                    if (detail[0] == "") continue;
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartment = detail[0];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_Position = detail[1];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_PosGrade = detail[2];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary = detail[3] == "" ? 0 : Convert.ToDecimal(detail[3]);
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate = detail[4] == "" ? DateTime.MinValue : Convert.ToDateTime(detail[4]);
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_EccRole = detail[5];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_WorkNature = detail[6];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_LastComm = detail[7];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_Relationship = detail[8];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Inservice_OtherCompanyComm = detail[9];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_ZSSupervisor = detail[10];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_LSSupervisor = detail[11];
                    t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Remark = detail[12];
                }

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = string.Empty;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = string.Empty;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;


                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Dimission_Department = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Dimission_Position = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Dimission_PosGrade = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Dimission_Type = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Dimission_Reason = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Dimission_ReasonRemark = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate = SqlDateTime.MinValue.Value;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate = SqlDateTime.MinValue.Value;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Department = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Position = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PosGrade = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary = 0;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_LSSupervisor = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRole = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNature = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Department = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Position = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PosGrade = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary = 0;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_ZSSupervisor = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_LSSupervisor = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRole = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNature = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate = SqlDateTime.MinValue.Value;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangType = string.Empty;
                t_OfficeAutomation_Document_LinkageCoordination.OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangTypeRemark = string.Empty;



                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                DA_OfficeAutomation_Document_LinkageCoordination_Inherit.InsertOrModify(t_OfficeAutomation_Document_LinkageCoordination, "Insert");//插入申请表

                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

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

                #region 根据默认流程表中的固定环节添加流程
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "20210,3873";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何穗茗,林亦玲";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 4;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 5;

                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, OperateModule_ID, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程
                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");window.location='/Apply/Apply_Search.aspx';");
                //RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_BadDebts_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                #endregion
            }
            else
            {
                //#region 修改编辑
                //if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                //{

                //    DataSet ds = new DataSet();
                //    ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID);
                //    string departmentid = hdDepartmentID.Value;

                //    string departmentName = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Department"].ToString();
                //    //页面上的部门名称
                //    string deptname = txtDepartment.Text;

                //    if (string.IsNullOrEmpty(departmentid))
                //    {
                //        if (deptname != departmentName)
                //        {
                //            Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                //            return;
                //        }

                //    }

                //    Update();

                //    RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
                //}
                //else
                //    Alert("未开通编辑修改权限。");
                //#endregion
            }
        }
        catch (Exception ex)
        {
            RunJS("alert(\"保存失败，" + ex.Message + "\");history.go(-1);");
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
        DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
        DA_OfficeAutomation_Document_BadDebts_Detail_Inherit da_OfficeAutomation_Document_BadDebts_Detail_Inherit = new DA_OfficeAutomation_Document_BadDebts_Detail_Inherit();

        DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_BadDebts_ID"].ToString();

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

                if (flowIDx == "6")
                {
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                    //if (ckbAddIDx7.Checked)//增加审批环节是否勾选，如果是则添加第7步黄志超审批
                    //{
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 7;

                    //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    //}
                }

                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                if (flowIDx == "6")
                {
                    //Update();
                    //da_OfficeAutomation_Document_BadDebts_Detail_Inherit.Delete(ID);
                    //int lh = InsertBadDebtsDetail(new Guid(ID));

                    ////string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
                    ////DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
                    //da_OfficeAutomation_Document_BadDebts_Inherit.ReplaceRemarkByID(ID, (lh > 3 ? "财务部处理" : "法律部处理"));
                }

                //如果为第四步流程则为其一审核即可通过，其他为同时审核。
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "4" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID);

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_BadDebts_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_BadDebts_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_BadDebts_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_BadDebts_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>文件主题：关于" + drRow["OfficeAutomation_Document_BadDebts_Building"].ToString() + "的坏账申请");
                    sbMailBody.Append("<br/>回复电话：020-" + drRow["OfficeAutomation_Document_BadDebts_ReplyPhone"]);
                    sbMailBody.Append("<br/>坏账原因：" + drRow["OfficeAutomation_Document_BadDebts_Reason"]);
                    sbMailBody.Append("<br/>");
                    ds = da_OfficeAutomation_Document_BadDebts_Detail_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbMailBody.Append("<br/>成交报告编号：" + dr["OfficeAutomation_Document_BadDebts_Detail_ReportID"]);
                        sbMailBody.Append("<br/>成交地址：" + dr["OfficeAutomation_Document_BadDebts_Detail_Address"]);
                        sbMailBody.Append("<br/>应收业佣：" + dr["OfficeAutomation_Document_BadDebts_Detail_Owner"]);
                        sbMailBody.Append("<br/>应收客佣：" + dr["OfficeAutomation_Document_BadDebts_Detail_Client"]);
                        sbMailBody.Append("<br/>业主坏账金额：" + dr["OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney"]);
                        sbMailBody.Append("<br/>客户坏账金额：" + dr["OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney"]);
                        sbMailBody.Append("<br/>坏账原因：" + dr["OfficeAutomation_Document_BadDebts_Detail_BadReason"]);
                        sbMailBody.Append("<br/>是否特殊调整：" + (dr["OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust"].ToString() == "True" ? "是" : "否"));
                        sbMailBody.Append("<br/>是否已自动坏账：" + (dr["OfficeAutomation_Document_BadDebts_Detail_IsAutoBad"].ToString() == "True" ? "是" : "否"));
                        sbMailBody.Append("<br/>自动坏账时间：" + dr["OfficeAutomation_Document_BadDebts_Detail_AutoBadDate"]);
                        sbMailBody.Append("<br/>成交日期：" + dr["OfficeAutomation_Document_BadDebts_Detail_DealDate"]);
                        sbMailBody.Append("<br/>坏账日期：" + dr["OfficeAutomation_Document_BadDebts_Detail_BadDate"]);
                        sbMailBody.Append("<br/>所属区域：" + dr["OfficeAutomation_Document_BadDebts_Detail_Area"]);
                        sbMailBody.Append("<br/>");
                    }

                    sbMailBody.Append("<br/>合计坏账金额：" + drRow["OfficeAutomation_Document_BadDebts_MoneyCount"]);

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

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            if (employeeList.Contains("黄轩明"))
                                employname = CommonConst.EMP_GMO_NAME + ",潘焕心";
                            else
                                employname = "潘焕心";
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

    #region 取消签名按钮点击事件
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
            DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BadDebts_Department"].ToString();
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
                        email = employnames[i2]; if (email != "")
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
                if (i < 7)
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7");
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
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
    #endregion

    #region 重新导入按钮点击事件
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite3"] = "1";
        Response.Write("<script>window.open('Apply_BadDebts_Detail.aspx?MainID=" + MainID + "');</script>");
    }
    #endregion

    #region 修改按钮点击事件
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
            DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BadDebts_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BadDebts_Department"].ToString();
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
                    email = employnames[i2]; if (email != "")
                        Common.SendMessageEX(false, email, "该份申请已经申请人修改，请重新审批！谢谢", msnBody, msnBody);
                }
            }

            #region 修改编辑
            if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
            {

                //Update();
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7");
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
    #endregion

    #region 另存为PDF按钮点击事件
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("坏账申请表.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
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

    #region datagrid事件

    /// <summary>
    /// gvAttachment的行命令操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttach_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;
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

}