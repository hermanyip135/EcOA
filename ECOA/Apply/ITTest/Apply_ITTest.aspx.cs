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

public partial class Apply_ITTest_Apply_ITTest : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public static string SerialNumber = "";
    public StringBuilder sbJS = new StringBuilder();
    public StringBuilder sbFlow = new StringBuilder();
    public StringBuilder sbJSON = new StringBuilder();
    public StringBuilder sbManagerJSON = new StringBuilder();
    public StringBuilder sbFollowerJSON = new StringBuilder();
    public string ApplyN;
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
        sbFollowerJSON.Append("[]");

        MainID = GetQueryString("MainID");
        ID = "";
        SerialNumber = "";

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
                if (Session["FLG_ReWrite25"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite25"] = null;
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
        this.txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        this.txtApplicant.Text = EmployeeName;
        this.btnSave.Visible = true;

        DA_Dic_OfficeAutomation_SoftSystem_Operate da_Dic_OfficeAutomation_SoftSystem_Operate = new DA_Dic_OfficeAutomation_SoftSystem_Operate();
        DataSet ds = da_Dic_OfficeAutomation_SoftSystem_Operate.SelectAllbyCache();

        DropDownListBind(ddlSystemName, ds.Tables[0], "OfficeAutomation_SoftSystem_ID", "OfficeAutomation_SoftSystem_Name", "1");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        GetSoftwareTeamStaff();

        DA_Dic_OfficeAutomation_SoftSystem_Operate da_Dic_OfficeAutomation_SoftSystem_Operate = new DA_Dic_OfficeAutomation_SoftSystem_Operate();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ITTest_Inherit da_OfficeAutomation_Document_ITTest_Inherit = new DA_OfficeAutomation_Document_ITTest_Inherit();

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



        #region 加载页面数据
        DataSet ds = new DataSet();
        DataSet dsSoftSystem = da_Dic_OfficeAutomation_SoftSystem_Operate.SelectAllbyCache();
        ds = da_OfficeAutomation_Document_ITTest_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_ITTest_ID"].ToString();
        this.txtDispatchDepartment.Text = dr["OfficeAutomation_Document_ITTest_Department"].ToString();
        this.hdDispatchDepartmentID.Value = dr["OfficeAutomation_Document_ITTest_DepartmentID"].ToString();
        this.txtApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ITTest_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        this.txtHopeDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ITTest_HopeDate"].ToString()).ToString("yyyy-MM-dd");
        this.txtApplicant.Text = dr["OfficeAutomation_Document_ITTest_Apply"].ToString();

        this.txtReceive.Text = dr["OfficeAutomation_Document_ITTest_Receiver"].ToString();
        this.txtReply.Text = dr["OfficeAutomation_Document_ITTest_ReqReply"].ToString();
        this.lRepl.Text = dr["OfficeAutomation_Document_ITTest_ReqReply"].ToString();
        this.lbDescribe.Text = dr["OfficeAutomation_Document_ITTest_ReqContent"].ToString(); ;
        this.txtContent.Text = dr["OfficeAutomation_Document_ITTest_ReqContent"].ToString(); 
        ApplyN = dr["OfficeAutomation_Document_ITTest_Apply"].ToString();
        DropDownListBind(ddlSystemName, dsSoftSystem.Tables[0], "OfficeAutomation_SoftSystem_ID", "OfficeAutomation_SoftSystem_Name", dr["OfficeAutomation_Document_ITTest_SystemName"].ToString());
   
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();

        if (EmployeeName == dr["OfficeAutomation_Document_ITTest_Receiver"].ToString())
        {
            this.btnSavaReply.Visible = true;
            this.btnEnd.Visible = true;

            this.pRepl.Visible = false;
            this.txtReply.Visible = true;
        }
        else {
            this.pRepl.Visible = true;
            this.txtReply.Visible = false;
        }


        if (flowState == "3")
        {
            this.btnSavaReply.Visible = false;
            this.btnEnd.Visible = false;
        
        }

        bool isApplicant = EmployeeName == ApplyN;
        if (!isApplicant || flowState == "3")
        {
            pnDescribe.Visible = true;
            txtContent.Visible = false;

         

        }
        sbJS.Append("<script type=\"text/javascript\">");


        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
        {
            sbJS.Append("$(\"#btnPrint\").show();");
        }
        #endregion
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        //sbJS.Append("$(\"#btnUpload\").show();");

        if (EmployeeName == dr["OfficeAutomation_Document_ITTest_Apply"].ToString())
        {

            if (flowState == "1")
            {
                GetAllDepartment();
                this.btnSave.Visible = true;
            }
            //if (flowState == "2") //20141215：M_AlterC
            //{
            //    GetAllDepartment();
            //    btnSAlterC.Visible = true;
           // }
        }
        //  只有申请人和测试人才能上传附件， 
        if (EmployeeName == dr["OfficeAutomation_Document_ITTest_Apply"].ToString() || EmployeeName == dr["OfficeAutomation_Document_ITTest_Receiver"].ToString())
        {
            sbJS.Append("$(\"#btnUpload\").show();");
        }
        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                sbJS.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                sbJS.Append("</script>");
                GetAllDepartment();
                btnSPDF.Visible = false; //M_PDF
                this.txtApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.txtApplicant.Text = EmployeeName;
                this.btnSave.Visible = true;
                flowState = "1";
            
                return;
            }
        }
        catch
        {
            if (EmployeeName == dr["OfficeAutomation_Document_ITTest_Apply"].ToString())
                btnReWrite.Visible = true; //*-+
        }

      /*   
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
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            sbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审批
            {
                if (idx <= 3)
                    sbFlow.Append("auditing\">待" + drc[i]["OfficeAutomation_Flow_Employee"].ToString() + "审批");
                else
                    sbFlow.Append("auditing\">待资讯科技部审批");

                flag2 = false;

                if (drc[i]["OfficeAutomation_Flow_IDx"].ToString() == "4" && drc[i]["OfficeAutomation_Flow_Employee"].ToString().Contains(EmployeeName))
                {
                    GetManagers();
                  
                }
            }
            else
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                {
                    if (idx <= 3)
                        sbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Auditor"].ToString() + "已完成审批");
                    else if (idx == 4)
                    {
                        sbFlow.Append("other\">资讯科技部已完成审批");
                    }
                }
                else
                {
                    if (idx <= 3)
                        sbFlow.Append("other\">" + drc[i]["OfficeAutomation_Flow_Employee"].ToString());
                    else if (idx == 4)
                    {
                        sbFlow.Append("other\">资讯科技部");
                    }
                }
            }
            sbFlow.Append("</span>");

            //箭头图片
            if (idx <= 3)//如果不是最后一项
            {
                if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
                    sbFlow.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
                else
                    sbFlow.Append("<img src=\"/Images/forward_skip.png\" class=\"forward\"/>");
            }
            #endregion

     

     
        }

        if (this.txtHeaderIDx3.Text.Trim() != "")
            this.btnTransmit.Visible = false;

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
        */
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
        T_OfficeAutomation_Document_ITTest t_OfficeAutomation_Document_ITTest = new T_OfficeAutomation_Document_ITTest();
     //   T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ITTest_Inherit da_OfficeAutomation_Document_ITTest_Inherit = new DA_OfficeAutomation_Document_ITTest_Inherit();
     //   DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
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
             
                string dispatchDepartmentID = this.hdDispatchDepartmentID.Value;
                if (dispatchDepartmentID == "")
                {
                    Alert("发文部门，请填写关键字后点选部门！");
                    return;
                }

              

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ITTEST" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 88;

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;


                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();


                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_DepartmentID = new Guid(this.hdDispatchDepartmentID.Value);
                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_Department = this.txtDispatchDepartment.Text;
                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_Apply = this.txtApplicant.Text;

                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);
                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_HopeDate = DateTime.Parse(this.txtHopeDate.Text);
                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_SystemName = this.ddlSystemName.SelectedValue;
                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_ReqContent = this.txtContent.Text;
                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_Receiver = this.txtReceive.Text;
                t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_ReqReply = ""; 
                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_Apply;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_Department;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = this.ddlSystemName.SelectedItem.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_ApplyDate;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);//插入公文主表
                da_OfficeAutomation_Document_ITTest_Inherit.Insert(t_OfficeAutomation_Document_ITTest);//插入软件系统开发需求申请表

                #region 保存默认流程
           
                T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();


                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "54861";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "彭嘉敏A";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx =1;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);


                        string messageBody;

                        string email = t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee;
                        messageBody = "您好，" + t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee + "：您有编号为" + t_OfficeAutomation_Main.OfficeAutomation_SerialNumber + "的软件系统测试需求申请表" + "需要您的测试。申请表地址为：" + Page.Request.Url.ToString() + "?MainID=" + t_OfficeAutomation_Main .OfficeAutomation_Main_ID+ "&islawer=False&dep=&apply=&start=&end=&type=88&state=&ctype=0&curpage=0&serialnumber=&keyword=&approver=&apptime=&DeleteA=False";
                        Common.SendMessageEX(false, email, EmployeeName+"申请了需要您参与测试的需求", messageBody, messageBody);
                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 88, new Guid(MainID), 1);//日志，创建软件系统开发需求申请表

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");"
                  //  + "var win=window.showModalDialog(\"Apply_ITTest_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=250px\");"
                  //  + "if(win=='success'){alert('软件系统开发需求申请创建成功，已发通知给部门负责人提醒审批，请耐心等待。');window.location='/Apply/Apply_Search.aspx'; }");
                        +"alert('软件系统测试需求申请创建成功，待测试人员测试，请耐心等待。');window.location='/Apply/Apply_Search.aspx'; ");            
                   #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_ITTest_Inherit.SelectByMainID(MainID);
                    ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ITTest_ID"].ToString();
                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_ID =new Guid(ID);
                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID;
                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_DepartmentID = new Guid(this.hdDispatchDepartmentID.Value);
                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_Department = this.txtDispatchDepartment.Text;
                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_Apply = this.txtApplicant.Text;

                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_Receiver = this.txtReceive.Text;
                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_ApplyDate = DateTime.Parse(this.txtApplyDate.Text);
                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_HopeDate = DateTime.Parse(this.txtHopeDate.Text);
                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_SystemName = this.ddlSystemName.SelectedValue;
                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_ReqContent = this.txtContent.Text;

                    t_OfficeAutomation_Document_ITTest.OfficeAutomation_Document_ITTest_ReqReply = this.txtReply.Text ; 


                    string apply = this.txtApplicant.Text;
                    string depname = this.txtDispatchDepartment.Text;
                    string summary = this.ddlSystemName.SelectedItem.Text;
                    string applydate = this.txtApplyDate.Text;
                    string mainid = MainID;

                    da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
                    da_OfficeAutomation_Document_ITTest_Inherit.Update(t_OfficeAutomation_Document_ITTest);//修改软件系统开发需求申请表

                    Common.AddLog(EmployeeID, EmployeeName, 88, new Guid(MainID), 2);//日志，修改软件系统开发需求申请表
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

 

    #region 返回按钮点击事件
    protected void btnBack_Click(object sender, EventArgs e)
    {

        string sUrl = "/Apply/Apply_Search.aspx?" + Request.QueryString.ToString();
        Response.Redirect(sUrl);
    }
    #endregion

    #endregion

    #region 其他

    #region 获取部门及四级以上经理数据
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

    /// <summary>
    /// 获取所有四级以上前线经理
    /// </summary>
    //private void GetManagers()
    //{
    //    wsFinance.Service service = new wsFinance.Service();
    //    DataSet dsManagers = service.GetManages();
    //    sbManagerJSON.Append("[");
    //    foreach (DataRow dr in dsManagers.Tables[0].Rows)
    //    {
    //        sbManagerJSON.Append("\"" + dr["EmployeeName"] + "\",");
    //    }
    //    sbManagerJSON.Remove(sbManagerJSON.Length - 1, 1);
    //    sbManagerJSON.Append("]");
    //}
    private void GetManagers()
    {
        sbManagerJSON.Remove(0, sbManagerJSON.Length);
        wsFinance.Service service = new wsFinance.Service();
        //DataSet dsManagers = service.GetManages();

        //2016-12-19修改为转审批人可以转所有在职员工
        DataSet dsEmployees = service.GetEmployee();

        sbManagerJSON.Append("[");
        foreach (DataRow dr in dsEmployees.Tables[0].Rows)
        {
            //sbManagerJSON.Append("{\"id\":\"" + dr["Code"].ToString() + "\",\"label\":\"" + dr["EmployeeName"].ToString() + "\",\"value\":\"" + dr["EmployeeName"].ToString() + "\"},");
            sbManagerJSON.Append("\"" + dr["EmployeeName"].ToString() + "\",");
        }
        sbManagerJSON.Remove(sbManagerJSON.Length - 1, 1);
        sbManagerJSON.Append("]");
    }

    /// <summary>
    /// 获取资讯科技部软件组同事
    /// </summary>
    private void GetSoftwareTeamStaff()
    {
        sbFollowerJSON.Remove(0, sbFollowerJSON.Length);
        DA_Dic_OfficeAutomation_ITStaff_Operate da_Dic_OfficeAutomation_ITStaff_Operate = new DA_Dic_OfficeAutomation_ITStaff_Operate();
        DataSet dsFollowers = da_Dic_OfficeAutomation_ITStaff_Operate.SelectByTeam(1);
        sbFollowerJSON.Append("[");
        foreach (DataRow dr in dsFollowers.Tables[0].Rows)
        {
            sbFollowerJSON.Append("{\"id\":\"" + dr["OfficeAutomation_ITStaff_Code"].ToString() + "\",\"value\":\"" + dr["OfficeAutomation_ITStaff_Name"].ToString() + "\"},");
        }
        sbFollowerJSON.Remove(sbFollowerJSON.Length - 1, 1);
        sbFollowerJSON.Append("]");
    }
    #endregion

    #endregion
    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite25"] = "1";
        Response.Write("<script>window.open('Apply_SysReq_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("软件系统测试需求申请表.pdf"));//强制下载 
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(file);
            Response.End();
        }
        catch (Exception ex)
        {
            Alert("生成文件失败！" + ex.Message);
        }
    }

    
 
    protected void btnSavaReply_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Document_ITTest_Inherit da_OfficeAutomation_Document_ITTest_Inherit = new DA_OfficeAutomation_Document_ITTest_Inherit();
      
       
        da_OfficeAutomation_Document_ITTest_Inherit.ReqReplyITTest(this.txtReply.Text, MainID);
        RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
   
    }
    protected void btnEnd_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Document_ITTest_Inherit da_OfficeAutomation_Document_ITTest_Inherit = new DA_OfficeAutomation_Document_ITTest_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        da_OfficeAutomation_Document_ITTest_Inherit.ReqReplyITTest(this.txtReply.Text, MainID);
        bool isSignSuccess = da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, "54861", "彭嘉敏A", "", "1", "1");
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        DataSet ds = da_OfficeAutomation_Document_ITTest_Inherit.SelectByMainID(MainID);
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ITTest_Apply"].ToString();
        string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();


        string email = "";
        string messageBody;


        messageBody = "您好，" + this.txtApplicant.Text + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + EmployeeName + "的测试。申请表地址为：" + Page.Request.Url.ToString();
        email = apply;
        Common.SendMessageEX(false, email, "申请已通过" + EmployeeName + "的测试", messageBody, messageBody);

        RunJS("alert('保存成功！');window.location='/Apply/Apply_Search.aspx';");
    }
}