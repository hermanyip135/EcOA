
using DataAccess.Operate;
using DataEntity;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_BusinessTravel_Apply_BusinessTravel_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbOptions = new StringBuilder();
    public string ApplyDisplayPart = "";
    public StringBuilder SbJsonf = new StringBuilder();//789
    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();

    public string sOfficeType = "";

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        GetManagers();//789
        SbJson.Append("[]");
        GetAllDepartment();
        MainID = GetQueryString("MainID");
        SerialNumber = "";

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
                if (Session["FLG_ReWrite74"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite74"] = null;
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
    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        txtApply.Text = EmployeeName;
        lDispatchDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        IsNewApply = true;
        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);
        SbJs.Append("</script>");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        bool IsTempSave = false;        //是否暂存
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_BusinessTravel_Inherit da_OfficeAutomation_Document_BusinessTravel_Inherit = new DA_OfficeAutomation_Document_BusinessTravel_Inherit();

        string flowState;
        try
        {
            flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
            //20170417
            if (flowState == "7")
            {
                IsTempSave = true;
            }
        }
        catch
        {
            Alert(CommonConst.MSG_URL_DISABLE);
            RunJS("window.location='/Apply/Apply_Search.aspx'");
            return;
        }

        SbJs.Append("<script type=\"text/javascript\">$(\"#uploadify\").hide();");
        // SbJs.Append("<script type=\"text/javascript\">");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_BusinessTravel_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_BusinessTravel_ID"].ToString();

        string applicant = dr["OfficeAutomation_Document_BusinessTravel_Apply"].ToString();
        ApplyN = applicant;
        txtApply.Text = applicant;
        txtReceiveDepartment.Text = dr["OfficeAutomation_Document_BusinessTravel_ReceiveDepartment"].ToString();
        txtDispatchDepartment.Text = dr["OfficeAutomation_Document_BusinessTravel_DispatchDepartment"].ToString();
        lDispatchDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_BusinessTravel_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtApplyID.Text = dr["OfficeAutomation_Document_BusinessTravel_ApplyID"].ToString();
        txtFollowPhone.Text = dr["OfficeAutomation_Document_BusinessTravel_FollowPhone"].ToString();
        txtTheme.Text = dr["OfficeAutomation_Document_BusinessTravel_Theme"].ToString();

        txtAddress.Text = dr["OfficeAutomation_Document_BusinessTravel_Address"].ToString();
        txtBeginDate.Text = dr["OfficeAutomation_Document_BusinessTravel_BeginDate"].ToString();
        txtEndDate.Text = dr["OfficeAutomation_Document_BusinessTravel_EndDate"].ToString();
        txtDays.Text = dr["OfficeAutomation_Document_BusinessTravel_Days"].ToString();
        txtNight.Text = dr["OfficeAutomation_Document_BusinessTravel_Night"].ToString();
        txtReason.Text = dr["OfficeAutomation_Document_BusinessTravel_Reason"].ToString();
        txtInspectionProject.Text = dr["OfficeAutomation_Document_BusinessTravel_InspectionProject"].ToString();

        this.hidDetail.Value = dr["OfficeAutomation_Document_BusinessTravel_StaffInfo"].ToString();
        this.hidDetail1.Value = dr["OfficeAutomation_Document_BusinessTravel_liveInfo"].ToString();
        this.hidDetail2.Value = dr["OfficeAutomation_Document_BusinessTravel_Mode"].ToString();
        this.txtCarCompanyName.Value = dr["OfficeAutomation_Document_BusinessTravel_CarCompanyName"].ToString();
        this.txtCarBrand.Value = dr["OfficeAutomation_Document_BusinessTravel_CarBrand"].ToString();
        this.txtCarModels.Value = dr["OfficeAutomation_Document_BusinessTravel_CarModels"].ToString();
        this.txtCarRent.Value = dr["OfficeAutomation_Document_BusinessTravel_CarRent"].ToString();
        this.txtCarLeaseBeginDate.Value = dr["OfficeAutomation_Document_BusinessTravel_CarLeaseBeginDate"].ToString();
        this.txtCarLeaseEndDate.Value = dr["OfficeAutomation_Document_BusinessTravel_CarLeaseEndDate"].ToString();
        this.txtCarLeaseDays.Value = dr["OfficeAutomation_Document_BusinessTravel_CarLeaseDays"].ToString();
        this.txtCarMoney.Value = dr["OfficeAutomation_Document_BusinessTravel_CarMoney"].ToString();
        this.hidDetail3.Value = dr["OfficeAutomation_Document_BusinessTravel_CurrencyProjectInfo"].ToString();
        this.txtOtherExplain.Text = dr["OfficeAutomation_Document_BusinessTravel_OtherExplain"].ToString();
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        //string[] sStaffInfo = Regex.Split(dr["OfficeAutomation_Document_BusinessTravel_StaffInfo"].ToString(), "\\|\\|");//出差人员明细    
        //for (int i = 0; i < sStaffInfo.Length; i++)
        //{

        //    if (sStaffInfo[i] != "")
        //    {
        //        string[] info = Regex.Split(sStaffInfo[i], "\\&\\&");
        //        var dlist = new { EmployeeID = info[0], EmployeeName = info[1], UnitName = info[2], startdate = info[3], enddate = info[4], Sex = info[5] };

        //    }

        //}

        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。

        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRow dtFlow = dsFlow.Tables[0].Rows[0];
        DataRowCollection drc = dsFlow.Tables[0].Rows;


        //2016-12-19修改 之前是只有申请人才能上传附件，现在修改为申请人和审批人都可以上传附件
        if (EmployeeName == applicant || Common.IsShowBtnUpload(EmployeeID, MainID))
        {
            SbJs.Append("$(\"#btnUpload\").show();");
        }

        if (isApplicant || EmployeeID == "41083")
        {
            SbJs.Append("$(\"#lbh1\").show();$(\"#lbh2\").show();$(\"#lbh3\").show();$(\"#uploadify\").show();");
            if (flowState == "1" || flowState == "7")
            {
                btnSave.Visible = true;
                SbJs.Append(ApplyDisplayPart);
                //  GetAllDepartment();
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                btnSAlterC.Visible = true;
                SbJs.Append(ApplyDisplayPart);
                //   GetAllDepartment();
            }
        }
        //SbJs.Append("$(\"#btnUpload\").show();");
        //bool isApplicant = EmployeeName == applicant;
        //if (isApplicant)
        //{
        //    //SbJs.Append("$(\"#btnUpload\").show();");
        //    if (flowState == "1")
        //    {
        //        GetAllDepartment();
        //        btnSave.Visible = true;
        //    }
        //    if (flowState == "2") //20141215：M_AlterC
        //    {
        //        GetAllDepartment();
        //        btnSAlterC.Visible = true;
        //    }
        //}



        #endregion

        if (ViewState["FLG_ReWrite"] != null && ViewState["FLG_ReWrite"].ToString() == "1")
        {
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
        if (isApplicant && !IsTempSave)
            btnReWrite.Visible = true; //*-+



        //#endregion
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
        if (flows != null)
            SbJs.Append("$('#trLogistics2').hide();$('#trGeneralManager').hide();$('#tlsc1').show();$('#tlsc2').show();");

        //如果为未审核状态且登入人为申请人且申请人不为直属黄生人员时，开启编辑按钮
       // if (flowState == "1" && applicant == EmployeeName)
          //  this.FlowShow1.ShowEditBtn = true;
        //if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
        if (flowState == "2" && "41083" == EmployeeID && !tpdf) //20141215：M_AlterC
            btnEditFlow2.Visible = true;

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
            btnEditFlow2.Visible = false;
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

        gvAttach.DataSource = dsAttach;
        gvAttach.DataBind();

        //如果该单有附件，则下载按钮显示
        btnDownload.Visible = (dsAttach != null && dsAttach.Tables[0] != null && dsAttach.Tables[0].Rows.Count > 0);
    }

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
        T_OfficeAutomation_Document_BusinessTravel t_OfficeAutomation_Document_BusinessTravel = new T_OfficeAutomation_Document_BusinessTravel();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_BusinessTravel_Inherit da_OfficeAutomation_Document_BusinessTravel_Inherit = new DA_OfficeAutomation_Document_BusinessTravel_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        #endregion
        try
        {
            string flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
            if (flowState == "3")
            {
                RunJS("alert('该表已审批完毕，不能再修改了！');window.location.href='" + Page.Request.Url + "';");
                return;
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
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "BusinessTravel" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 92;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDispatchDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtTheme.Text;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);

                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();

                var DetailID = Guid.NewGuid();
                t_OfficeAutomation_Document_BusinessTravel = GetModelFromPage(DetailID);
                da_OfficeAutomation_Document_BusinessTravel_Inherit.Add(t_OfficeAutomation_Document_BusinessTravel);//插入申请表

                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                da_OfficeAutomation_Flow_Inherit.InsertNewFlow(new Guid(MainID), EmployeeID, EmployeeName, 1, true);  //申请人
                #region 根据默认流程表中的固定环节添加流程
                da_OfficeAutomation_Flow_Inherit.InsertDefaultFlow(t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString());
                //20000元＜总费用≤100000元审批至董事总经理
                var val = decimal.Parse(this.hiTotal.Value);
                if (20000 < val && val <= 100000)
                {
                    da_OfficeAutomation_Flow_Inherit.InsertNewFlow(new Guid(MainID), "0001", "黄轩明", 16, true);  //总经理
                }
                else
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
                }

                #endregion

                #endregion
                Common.AddLog(EmployeeID, EmployeeName, 92, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("var win=window.showModalDialog(\"../Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");if(win=='success'){alert('保存成功！');window.location='../Apply.aspx'; }else{alert('保存成功！');window.location='../Apply.aspx';}");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {

                    Update();
                    var MainObj = da_OfficeAutomation_Main_Inherit.GetModel("[OfficeAutomation_Main_ID]='" + MainID + "'");
                    //是否暂存
                    bool tempsave = MainObj.OfficeAutomation_Main_FlowStateID == 7;
                    if (tempsave)
                    {
                        //是,更新主表状态
                        MainObj.OfficeAutomation_Main_FlowStateID = 2;
                        da_OfficeAutomation_Main_Inherit.Edit(MainObj);
                        //根据默认流程表中的固定环节添加流程
                        da_OfficeAutomation_Flow_Inherit.InsertDefaultFlow(MainID);
                        RunJS("var win=window.showModalDialog(\"../Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");;if(win=='success'){window.location='../Apply.aspx'; }");
                    }
                    //20000元＜总费用≤100000元审批至董事总经理
                    var val = decimal.Parse(this.hiTotal.Value);
                    if (20000 < val && val <= 100000)
                    {
                        da_OfficeAutomation_Flow_Inherit.InsertNewFlow(new Guid(MainID), "0001", "黄轩明", 16, true);  //总经理
                    }
                    else
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "16");
                    }
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
    #endregion
    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        if (Cache["AllDepartmentSimple"] == null)
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

                m = Regex.Match(name, "[A-Z]$");
                if (m.Success)//去除名称尾部的ABCD
                    name = name.Substring(0, m.Index);

                if (!SbJson.ToString().Contains(name))
                    SbJson.Append("{\"value\":\"" + name + "\"},");
            }

            SbJson.Remove(SbJson.Length - 1, 1);
            SbJson.Append("]");
            Cache["AllDepartmentSimple"] = SbJson;
        }
        else
            SbJson = (StringBuilder)Cache["AllDepartmentSimple"];
    }
    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite75"] = "1";
        Response.Write("<script>window.open('Apply_BusinessTravel_Detail.aspx?MainID=" + MainID + "');</script>");
    }
    #region 从页面中获得model

    private T_OfficeAutomation_Document_BusinessTravel GetModelFromPage(Guid BusinessTravelID)
    {
        DataEntity.T_OfficeAutomation_Document_BusinessTravel model = new DataEntity.T_OfficeAutomation_Document_BusinessTravel();

        model.OfficeAutomation_Document_BusinessTravel_ID = BusinessTravelID;
        model.OfficeAutomation_Document_BusinessTravel_MainID = new Guid(MainID);
        model.OfficeAutomation_Document_BusinessTravel_DispatchDepartment = txtDispatchDepartment.Text;
        model.OfficeAutomation_Document_BusinessTravel_ApplyDate = DateTime.Now;
        model.OfficeAutomation_Document_BusinessTravel_Apply = EmployeeName;
        model.OfficeAutomation_Document_BusinessTravel_ApplyID = txtApplyID.Text;
        model.OfficeAutomation_Document_BusinessTravel_ReceiveDepartment = txtReceiveDepartment.Text;
        model.OfficeAutomation_Document_BusinessTravel_FollowPhone = txtFollowPhone.Text;
        model.OfficeAutomation_Document_BusinessTravel_Theme = txtTheme.Text;
        model.OfficeAutomation_Document_BusinessTravel_Address = txtAddress.Text;
        model.OfficeAutomation_Document_BusinessTravel_BeginDate = txtBeginDate.Text;
        model.OfficeAutomation_Document_BusinessTravel_EndDate = txtEndDate.Text;
        model.OfficeAutomation_Document_BusinessTravel_Days = txtDays.Text;
        model.OfficeAutomation_Document_BusinessTravel_Night = txtNight.Text;
        model.OfficeAutomation_Document_BusinessTravel_Reason = txtReason.Text;
        model.OfficeAutomation_Document_BusinessTravel_InspectionProject = txtInspectionProject.Text;
        model.OfficeAutomation_Document_BusinessTravel_StaffInfo = this.hidDetail.Value;
        model.OfficeAutomation_Document_BusinessTravel_liveInfo = hidDetail1.Value;
        model.OfficeAutomation_Document_BusinessTravel_Mode = hidDetail2.Value;
        model.OfficeAutomation_Document_BusinessTravel_CarCompanyName = this.txtCarCompanyName.Value;
        model.OfficeAutomation_Document_BusinessTravel_CarBrand = this.txtCarBrand.Value;
        model.OfficeAutomation_Document_BusinessTravel_CarModels = this.txtCarModels.Value;
        model.OfficeAutomation_Document_BusinessTravel_CarRent = this.txtCarRent.Value;
        model.OfficeAutomation_Document_BusinessTravel_CarLeaseBeginDate = this.txtCarLeaseBeginDate.Value;
        model.OfficeAutomation_Document_BusinessTravel_CarLeaseEndDate = this.txtCarLeaseEndDate.Value;
        model.OfficeAutomation_Document_BusinessTravel_CarLeaseDays = this.txtCarLeaseDays.Value;
        model.OfficeAutomation_Document_BusinessTravel_CarMoney = this.txtCarMoney.Value;
        model.OfficeAutomation_Document_BusinessTravel_CurrencyProjectInfo = this.hidDetail3.Value;
        model.OfficeAutomation_Document_BusinessTravel_OtherExplain = this.txtOtherExplain.Text;
        model.OfficeAutomation_Document_BusinessTravel_liveSum = this.hiLiveInfoSum.Value;
        model.OfficeAutomation_Document_BusinessTravel_CarSum = hiModeCarSum.Value;
        model.OfficeAutomation_Document_BusinessTravel_HighSpeedSum = hiModeHighSpeedSum.Value;
        model.OfficeAutomation_Document_BusinessTravel_AircraftSum = hiModeAircraftSum.Value;
        model.OfficeAutomation_Document_BusinessTravel_CurrencyProjectSum = hiCurrencySum.Value;
        return model;
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
    protected void btnSPDF_Click(object sender, EventArgs e) //M_PDF
    {
        try
        {
            //因为Web 是多线程环境，避免甲产生的文件被乙下载去，所以档名都用唯一 
            string fileNameWithOutExtention = Guid.NewGuid().ToString();
            string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri + "&htmltopdf=Yes&EPID=" + EmployeeID + " ";
            //执行wkhtmltopdf.exe 
            Process p = System.Diagnostics.Process.Start(System.Web.HttpContext.Current.Server.MapPath("/Exe\\wkhtmltopdf"), baseUrl + System.Web.HttpContext.Current.Server.MapPath("/Temp\\" + fileNameWithOutExtention + ".pdf"));
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("项目部兼职申请.pdf"));//强制下载 
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
            var bll = new DA_OfficeAutomation_Document_BusinessTravel_Inherit();
            DataSet ds = bll.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BusinessTravel_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BusinessTravel_DispatchDepartment"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;

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
            DA_OfficeAutomation_Document_BusinessTravel_Inherit da_OfficeAutomation_Document_BusinessTravel_Inherit = new DA_OfficeAutomation_Document_BusinessTravel_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BusinessTravel_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BusinessTravel_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BusinessTravel_DispatchDepartment"].ToString();
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
                        Common.SendMessageEX(false, email, "该份申请已修改，请重新审批！谢谢", msnBody, msnBody);
                }
            }

            #region 修改编辑
            if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
            {

                Update();
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
            DA_OfficeAutomation_Document_BusinessTravel_Inherit da_OfficeAutomation_Document_BusinessTravel_Inherit = new DA_OfficeAutomation_Document_BusinessTravel_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BusinessTravel_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BusinessTravel_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BusinessTravel_DispatchDepartment"].ToString();
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
                    email = employnames[i2]; if (email != "")
                        Common.SendMessageEX(false, email, "申请表已被" + EmployeeName + "修改了审批流程", msnBody, msnBody);
                }
            }
            //da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 3); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_BusinessTravel_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
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
        DA_OfficeAutomation_Document_BusinessTravel_Inherit da_OfficeAutomation_DocumentBusinessTravel_Inherit = new DA_OfficeAutomation_Document_BusinessTravel_Inherit();

        DataSet ds = da_OfficeAutomation_DocumentBusinessTravel_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_BusinessTravel_ID"].ToString();

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

                //bool isSignSuccess = flowIDx == "6" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value)
                //    : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                bool isSignSuccess = Convert.ToInt32(flowIDx) >= 17 ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);


                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody = "";

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BusinessTravel_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_BusinessTravel_DispatchDepartment"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_BusinessTravel_Apply"]);
                    sbMailBody.Append("<br/>申请分行/部门：" + drRow["OfficeAutomation_Document_BusinessTravel_DispatchDepartment"]);
                    sbMailBody.Append("<br/>填写日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_BusinessTravel_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));

                    sbMailBody.Append("<br/>申请表：项目部差旅申请表");
                    sbMailBody.Append("<br/><br/>");

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

    #region 返回按钮点击事件
    protected void btnBack_Click(object sender, EventArgs e)
    {

        string sUrl = "/Apply/Apply_Search.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
    }
    #endregion








    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_BusinessTravel t_OfficeAutomation_Document_BusinessTravel = new T_OfficeAutomation_Document_BusinessTravel();
        DA_OfficeAutomation_Document_BusinessTravel_Inherit da_OfficeAutomation_Document_BusinessTravel_Inherit = new DA_OfficeAutomation_Document_BusinessTravel_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_BusinessTravel_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BusinessTravel_ID"].ToString();

        t_OfficeAutomation_Document_BusinessTravel = GetModelFromPage(new Guid(ID));

        string apply = "";
        string depname = this.txtDispatchDepartment.Text;
        string summary = txtTheme.Text;
        string applydate = "";
        string mainid = MainID;

        new DA_OfficeAutomation_Main_Inherit().UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_BusinessTravel_Inherit.Edit(t_OfficeAutomation_Document_BusinessTravel);//修改申请表

        Common.AddLog(EmployeeID, EmployeeName, 89, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion
    #region 获取列表
    /// <summary>
    /// 出差人员明细
    /// </summary>
    /// <param name="json"></param>
    //private void getHidDetail(string json, T_OfficeAutomation_Document_BusinessTravel t_OfficeAutomation_Document_BusinessTravel)
    //{
    //    var t = new { EmployeeID = "", EmployeeName = "", UnitName = "", startdate = "", enddate = "", Sex = "" };
    //    var l = Enumerable.Repeat(t, 1).ToList();
    //    var list = JsonConvert.DeserializeAnonymousType(json, l);
    //    foreach (var i in list)
    //    {
    //        t_OfficeAutomation_Document_BusinessTravel.OfficeAutomation_Document_BusinessTravel_StaffInfo += i.EmployeeID + "&&" + i.EmployeeName + "&&" + i.UnitName + "&&" + i.startdate + "&&" + i.enddate + "&&" + i.Sex+"||";
    //    }
    //}
    #endregion

    //protected void lbtnAddN_Click(object sender, EventArgs e) //M_AddNWX：20150511
    //{
    //    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
    //    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
    //    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

    //    da_OfficeAutomation_Flow_Inherit.UpdateEIDByMainIDAndEName(MainID, "13545", "宁伟雄,黄志超", "5585,13545");
    //    Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1); //添加日志，添加流程
    //    RunJS("alert('审理环节已增加！');window.location='" + Page.Request.Url + "'");
    //}
    protected void btnSaveLogisticsFlow_Click(object sender, EventArgs e)
    {
        RunJS("var win=window.showModalDialog(\"Apply_BusinessTravel_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='" + Page.Request.Url + "' }else{window.location='" + Page.Request.Url + "'}");


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
    protected void btnWillEnd_Click(object sender, EventArgs e) //M_WinnEnd：20150204
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        da_OfficeAutomation_Flow_Inherit.DeleteFlowsByME(MainID, "0001");
        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(MainID, 200);
        DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit da_OfficeAutomation_Document_GeneralApply_Detail_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit();
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "总经办");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "董事总经理");
        da_OfficeAutomation_Document_GeneralApply_Detail_Inherit.DeleteByDpmAndMID(MainID, "董事总经理审批");
        da_OfficeAutomation_Main_Inherit.UpdateFlowStateForAudit(MainID);
        Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 3); //添加日志，删除流程
        RunJS("alert('已删除总经办的审批环节！');window.location='" + Page.Request.Url + "'");
    }

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
}