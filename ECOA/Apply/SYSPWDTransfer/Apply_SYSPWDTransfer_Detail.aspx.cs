using DataAccess.Operate;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_SYSPWDTransfer_Apply_SYSPWDTransfer_Detail : BasePage
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
        lbApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
      //  lbData.Text = lbApplyDate.Text;
        SbJs.Append("<script type=\"text/javascript\">");
        //DrawDetailTable(0);
        //SbJs.Append("$(\"#btnUpload\").show();");
        SbJs.Append("</script>");
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {

    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit da_OfficeAutomation_Document_SYSPWDTransfer_Inherit = new DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit();

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
        {
            SbJs.Append("$(\"#btnPrint\").show();");
        }
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_SYSPWDTransfer_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_SYSPWDTransfer_ID"].ToString();
        string applicant = dr["OfficeAutomation_Main_Apply"].ToString();
        T_OfficeAutomation_Document_SYSPWDTransfer obj = da_OfficeAutomation_Document_SYSPWDTransfer_Inherit.GetModel("OfficeAutomation_Document_SYSPWDTransfer_ID='" + ID + "'");
    
        CommonSerialization.BindObjectToControl("T_OfficeAutomation_Document_SYSPWDTransfer", obj, this.Page.Master.FindControl("ContentPlaceHolder1"));   //实体给form赋值

        //this.txtBootUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_BootUser;
        //this.txtBootPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_BootPwd;
        //this.txtLoginUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_LoginUser;
        //this.txtLoginPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_LoginPwd;
        //this.txtReceivablesSysUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSysUser;
        //this.txtReceivablesSysPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSysPwd;
        //this.txtInvoiceSysUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_InvoiceSysUser;
        //this.txtInvoiceSysPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_InvoiceSysPwd;
        //this.txtIntranetSysUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IntranetSysUser;
        //this.txtIntranetSysPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IntranetSysPwd;
        //this.txtTimeSysUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_TimeSysUser;
        //this.txtTimeSysPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_TimeSysPwd;
        //this.txtGatewaySysUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_GatewaySysUser;
        //this.txtGatewaySysPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_GatewaySysPwd;
        //this.txtIWordsSysUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IWordsSysUser;
        //this.txtIWordsSysPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IWordsSysPwd;
        //this.txtMarketKeyUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_MarketKeyUser;
        //this.txtMarketKeyPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_MarketKeyPwd;
        //this.txtPostMachineUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_PostMachineUser;
        //this.txtPostMachinePwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_PostMachinePwd;
        //this.txtLeaseDeliverySysUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_LeaseDeliverySysUser;
        //this.txtLeaseDeliverySysPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_LeaseDeliverySysPwd;
        //this.txtMessageUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_MessageUser;
        //this.txtMessagePwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_MessagePwd;
        //this.txtSafeDepositBoxPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_SafeDepositBoxPwd;
        //this.txtWIFIPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_WIFIPwd;
        //this.txtReceivablesSpareGoldUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSpareGoldUser;
        //this.txtReceivablesSpareGoldPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSpareGoldPwd;
        //this.txtIntercourseSpareGoldUser.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IntercourseSpareGoldUser;
        //this.txtIntercourseSpareGoldPwd.Text = t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IntercourseSpareGoldPwd;
        ApplyN = applicant;
        lblApply.Text = applicant;
      //  lbData.Text = lbApplyDate.Text;

        lbApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Main_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Main_Department"].ToString();
      
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        if (dsFlow.Tables[0].Rows.Count > 0)
        {
            DataRow dtFlow = dsFlow.Tables[0].Rows[0];
            DataRowCollection drc = dsFlow.Tables[0].Rows;
        }

        if (isApplicant)
        {
            //SbJs.Append("$(\"#btnUpload\").show();");
            if (flowState == "1")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                //SbJs.Append(ApplyDisplayPart);
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
            }
        }

        #endregion

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。

        if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID && flowState == "3")
           // btnSignSave.Visible = true;

        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                //SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnPrint\").hide();$(\"#btnUpload\").hide();");
                SbJs.Append("</script>");
                GetAllDepartment();
                //txtDepartment.Text = "";
                btnSPDF.Visible = false; //M_PDF
                lblApply.Text = EmployeeName;
                lbApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
              //  lbData.Text = lbApplyDate.Text;
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
                btnReWrite.Visible = true;
        }

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
        if (flowState == "1" && applicant == EmployeeName)
            this.FlowShow1.ShowEditBtn = true;
        if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
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
        T_OfficeAutomation_Document_SYSPWDTransfer t_OfficeAutomation_Document_SYSPWDTransfer = new T_OfficeAutomation_Document_SYSPWDTransfer();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit da_OfficeAutomation_Document_SYSPWDTransfer_Inherit = new DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit();
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
            //if (MainID == "")
            if (IsNewApply)
            {
                #region 新建
                IsNewApply = false;
                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "SYSPWDTransfer" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 96; //在《申请表字典表》t_Dic_OfficeAutomation_Document，找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;



                //MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                Guid BorrowMoneyID = Guid.NewGuid();

                t_OfficeAutomation_Document_SYSPWDTransfer = GetModelFromPage(BorrowMoneyID);

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = this.lblApply.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_Apply = EmployeeName;
                t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_Department = this.txtDepartment.Text;
                t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ApplyDate = DateTime.Now;
                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_SYSPWDTransfer_Inherit.Add(t_OfficeAutomation_Document_SYSPWDTransfer);//插入申请表
             
                //InsertBorrowMoneyDetail(t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_ID);

                #region 保存默认流程
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";


                #region 添加申请人
                try
                {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    
                }
                catch (Exception)
                {


                }


                #endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 85, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_SYSPWDTransfer_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
        DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit da_OfficeAutomation_Document_SYSPWDTransfer_Inherit = new DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit();

        DataSet ds = da_OfficeAutomation_Document_SYSPWDTransfer_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_SYSPWDTransfer_ID"].ToString();

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

                //如果为第0步流程则为其一审核即可通过，其他为同时审核。
                bool isSignSuccess = flowIDx == "0" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody = "";

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Main_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Main_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    //sbMailBody.Append("<br/><br/>第一联：财务联<br/><br/>申请人：" + drRow["OfficeAutomation_Document_BorrowMoney_Apply"]);
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Main_Apply"]);
                    sbMailBody.Append("<br/>部门：" + drRow["OfficeAutomation_Main_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Main_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    //sbMailBody.Append("<br/>发文编号：" + drRow["OfficeAutomation_Document_BorrowMoney_ApplyID"]);
                    //sbMailBody.Append("<br/>需要日期：" + drRow["OfficeAutomation_Document_BorrowMoney_NeedDate"]);
                    //sbMailBody.Append("<br/>电话/传真：" + drRow["OfficeAutomation_Document_BorrowMoney_ReplyPhone"]);


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

    private T_OfficeAutomation_Document_SYSPWDTransfer GetModelFromPage(Guid SYSPWDTransfer_ID)
    {
        T_OfficeAutomation_Document_SYSPWDTransfer t_OfficeAutomation_Document_SYSPWDTransfer = new T_OfficeAutomation_Document_SYSPWDTransfer();
        t_OfficeAutomation_Document_SYSPWDTransfer = CommonSerialization.ReqDeserilizeAnEntity<T_OfficeAutomation_Document_SYSPWDTransfer>("T_OfficeAutomation_Document_SYSPWDTransfer", this.Page.Master.FindControl("ContentPlaceHolder1"));
        t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ID = SYSPWDTransfer_ID;
        t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_BootUser = this.BootUser.Text;
        t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ApplyDate = DateTime.Now;
        t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_Apply = EmployeeName;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_BootPwd = this.txtBootPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_LoginUser = this.txtLoginUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_LoginPwd = this.txtLoginPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSysUser = this.txtReceivablesSysUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSysPwd = this.txtReceivablesSysPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_InvoiceSysUser = this.txtInvoiceSysUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_InvoiceSysPwd = this.txtInvoiceSysPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IntranetSysUser = this.txtIntranetSysUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IntranetSysPwd = this.txtIntranetSysPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_TimeSysUser = this.txtTimeSysUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_TimeSysPwd = this.txtTimeSysPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_GatewaySysUser = this.txtGatewaySysUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_GatewaySysPwd = this.txtGatewaySysPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IWordsSysUser = this.txtIWordsSysUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IWordsSysPwd = this.txtIWordsSysPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_MarketKeyUser = this.txtMarketKeyUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_MarketKeyPwd = this.txtMarketKeyPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_PostMachineUser = this.txtPostMachineUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_PostMachinePwd = this.txtPostMachinePwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_LeaseDeliverySysUser = this.txtLeaseDeliverySysUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_LeaseDeliverySysPwd = this.txtLeaseDeliverySysPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_MessageUser = this.txtMessageUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_MessagePwd = this.txtMessagePwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_SafeDepositBoxPwd = this.txtSafeDepositBoxPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_WIFIPwd = this.txtWIFIPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSpareGoldUser = this.txtReceivablesSpareGoldUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSpareGoldPwd = this.txtReceivablesSpareGoldPwd.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IntercourseSpareGoldUser = this.txtIntercourseSpareGoldUser.Text;
        //t_OfficeAutomation_Document_SYSPWDTransfer.OfficeAutomation_Document_SYSPWDTransfer_IntercourseSpareGoldPwd = this.txtIntercourseSpareGoldPwd.Text;
        return t_OfficeAutomation_Document_SYSPWDTransfer;
    }
   
    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_SYSPWDTransfer t_OfficeAutomation_Document_SYSPWDTransfer = new T_OfficeAutomation_Document_SYSPWDTransfer();
        DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit da_OfficeAutomation_Document_SYSPWDTransfer_Inherit = new DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_SYSPWDTransfer_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_SYSPWDTransfer_ID"].ToString();

        t_OfficeAutomation_Document_SYSPWDTransfer = GetModelFromPage(new Guid(ID));

        string apply = EmployeeName;
        string depname = this.txtDepartment.Text;
        string summary = this.lblApply.Text;
        
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_SYSPWDTransfer_Inherit.Edit(t_OfficeAutomation_Document_SYSPWDTransfer);//修改申请表
      

        Common.AddLog(EmployeeID, EmployeeName, 85, new Guid(MainID), 2);//日志，修改申请表
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

  

   
        SbJson.Remove(SbJson.Length - 1, 1);
        SbJson.Append("]");
    }
    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite73"] = "1";
        Response.Write("<script>window.open('Apply_SYSPWDTransfer_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("系统及密码交接表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit da_OfficeAutomation_Document_SYSPWDTransfer_Inherit = new DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SYSPWDTransfer_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Main_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Main_Department"].ToString();
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
                //if (i == 1) //删除添加的流程
                //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "2,10,12");
                //if (i < 9)
                //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "9,11");
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
            DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit da_OfficeAutomation_Document_SYSPWDTransfer_Inherit = new DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SYSPWDTransfer_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Main_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Main_Department"].ToString();
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
                Update();
                //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11"); //删除可能添加的流程
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
            DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit da_OfficeAutomation_Document_SYSPWDTransfer_Inherit = new DA_OfficeAutomation_Document_SYSPWDTransfer_Inherit();
            DataSet ds = da_OfficeAutomation_Document_SYSPWDTransfer_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Main_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Main_Department"].ToString();
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
            //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "11");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 3); //在不同的表中要修改，开发新表时要注意
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_SYSPWDTransfer_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
}