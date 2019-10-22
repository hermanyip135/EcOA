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
using System.Linq;
using Newtonsoft.Json;

public partial class Apply_BorrowMoney_Apply_BorrowMoney_Detail : BasePage
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
        lbData.Text = lbApplyDate.Text;
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
        DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
        DA_OfficeAutomation_Document_BorrowMoney_Import_Inherit dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Import_Inherit();
       
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
        {
          //  Response.Write(EmployeeID);
            SbJs.Append("$(\"#btnPrint\").show();");
            //财务签名按钮
            if (EmployeeID.Equals("0025") || EmployeeID.Equals("13545") || EmployeeID.Equals("3816") || EmployeeID.Equals("13113") || EmployeeID.Equals("45664") || EmployeeID.Equals("62707") || EmployeeID.Equals("54101") || EmployeeID.Equals("50203") || EmployeeID.Equals("65405"))
            {
           //     Response.Write(EmployeeID);
             bFinSige.Visible = true;
            }
           
            btnPrintPreview.Visible = true;
        }
        #endregion

        #region 加载页面数据

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_BorrowMoney_Inherit.SelectByMainID(MainID);
        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_BorrowMoney_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_BorrowMoney_Apply"].ToString();
        ApplyN = applicant;
        lblApply.Text = applicant;
        lbData.Text = lbApplyDate.Text;
        string sBorrowMoney = dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.getCalculationMoney(dr["OfficeAutomation_Document_BorrowMoney_ApplyID"].ToString(), "借");//借支金额
        lbApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_BorrowMoney_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtApplyID.Text = dr["OfficeAutomation_Document_BorrowMoney_ApplyID"].ToString();
        txtDepartment.Text = dr["OfficeAutomation_Document_BorrowMoney_Department"].ToString();
        txtReplyPhone.Text = dr["OfficeAutomation_Document_BorrowMoney_ReplyPhone"].ToString();
        txtNeedDate.Text = dr["OfficeAutomation_Document_BorrowMoney_NeedDate"].ToString();
     //   txtReason.Text = dr["OfficeAutomation_Document_BorrowMoney_Reason"].ToString();
      //  this.hidDetail1.Value = dr["OfficeAutomation_Document_BorrowMoney_Reason"].ToString();
        txtAcount.Text = dr["OfficeAutomation_Document_BorrowMoney_Acount"].ToString();
        txtAname.Text = dr["OfficeAutomation_Document_BorrowMoney_Aname"].ToString();
        ddlArea.SelectedValue = dr["OfficeAutomation_Document_BorrowMoney_Area"].ToString();
        txtBank.Text = dr["OfficeAutomation_Document_BorrowMoney_Bank"].ToString();
     //   txtMoney.Text = dr["OfficeAutomation_Document_BorrowMoney_Money"].ToString();
        lMoney.Text = dr["OfficeAutomation_Document_BorrowMoney_Money"].ToString();
        hilMoney.Value = dr["OfficeAutomation_Document_BorrowMoney_Money"].ToString();
        //txtBWMoney.Text = dr["OfficeAutomationdr["OfficeAutomation_Document_BorrowMoney_Money"].ToString();_Document_BorrowMoney_BWMoney"].ToString();
        lBWMoney.Text = dr["OfficeAutomation_Document_BorrowMoney_BWMoney"].ToString();
        hilBWMoney.Value = dr["OfficeAutomation_Document_BorrowMoney_BWMoney"].ToString();
        txtApplyNo.Text = dr["OfficeAutomation_Document_BorrowMoney_ApplyNo"].ToString();
        lExpenditure.Text = dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.getCalculationMoney(dr["OfficeAutomation_Document_BorrowMoney_ApplyID"].ToString(), "借");//实际已支出
        lRushedBy.Text = dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.getCalculationMoney(dr["OfficeAutomation_Document_BorrowMoney_ApplyID"].ToString(), "冲");//冲账金额
     //   txtDialog.Text = dr["OfficeAutomation_Document_BorrowMoney_Dialog"].ToString();
        lAuditMame.Text = dr["OfficeAutomation_Document_BorrowMoney_AuditorName"].ToString();//财务签名
        string IsAgree = dr["OfficeAutomation_Document_BorrowMoney_IsAgree"].ToString();//财务意见 1确认收单 0退单 2其他意见
        if (IsAgree == "1")
            radFin1.Checked = true;
        else if (IsAgree == "0")
            radFin2.Checked = true;
        else if (IsAgree == "2")
            radFin3.Checked = true;
        //不存在导入借支就显示财务确认按钮
        if (!string.IsNullOrEmpty(sBorrowMoney) && "0.00" !=(sBorrowMoney))
        {
           
            bFinSige.Visible = false;
        }
        txtSuggestion.Value = dr["OfficeAutomation_Document_BorrowMoney_Suggestion"].ToString();//财务备注
        lAuditDate.Text = dr["OfficeAutomation_Document_BorrowMoney_AuditorDate"].ToString();//财务审批时间
        string cbt = dr["OfficeAutomation_Document_BorrowMoney_PayK"].ToString();
        if (cbt.Contains("1"))
            cbPayK1.Checked = true;
        if (cbt.Contains("2"))
            cbPayK2.Checked = true;
        if (cbt.Contains("3"))
            cbPayK3.Checked = true;

        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        DA_OfficeAutomation_Document_BorrowMoney_Detail_Operate detailbll = new DataAccess.Operate.DA_OfficeAutomation_Document_BorrowMoney_Detail_Operate();
        var detaillist = detailbll.SelectListByMainID(ID);
          double TotalCostSum = 0;
        if (detaillist != null && detaillist.Count > 0)
        {
            var dlist = detaillist.Select(m => new
            {
                startDate = m.OfficeAutomation_Document_BorrowMoney_Detail_StartDate ,
               endDate =m.OfficeAutomation_Document_BorrowMoney_Detail_EndDate,
                hiCostProject = m.OfficeAutomation_Document_BorrowMoney_Detail_CostProject,
                CostProject = m.OfficeAutomation_Document_BorrowMoney_Detail_CostProject,
                hiOther = m.OfficeAutomation_Document_BorrowMoney_Detail_Other,
                txtOther = m.OfficeAutomation_Document_BorrowMoney_Detail_Other,
                UnitPrice = m.OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice
            }).ToList();
            this.hidDetail1.Value = JsonConvert.SerializeObject(dlist);
        }
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        if (dsFlow.Tables[0].Rows.Count>0)
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
            btnSignSave.Visible = true;
         
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
                lbData.Text = lbApplyDate.Text;
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
          //  if (isApplicant)
               // btnReWrite.Visible = true; 
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnprint_Click(object sender,EventArgs e)
    {
        //   RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_BorrowMoney_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
              
       // Response.Redirect("PrintBorrowMoney.aspx?MainID="+MainID);
        RunJS("window.showModalDialog(\"PrintBorrowMoney.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogWidth=800px;dialogHeight=600px\");window.location='" + Page.Request.Url + "'");
        //window.location='" + Page.Request.Url + "'" 
    }
    protected void btnFin_Click(object sender,EventArgs e)
    { 
    
    }

    #region 保存按钮点击事件
    /// <summary>
    /// 保存按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(txtNeedDate.Text.Trim()) <= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")))
        {
            RunJS("alert('需要日期不能小于申请的当前日期！');");
            return;
        }
        #region 创建对象

        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_BorrowMoney t_OfficeAutomation_Document_BorrowMoney = new T_OfficeAutomation_Document_BorrowMoney();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
          DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
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
            string[] sHRTree = null;
            try
            {
                if ("后勤".Equals(ddlArea.SelectedValue))
                {
                    sHRTree = Common.GetHRTreeByDepartmentID(hdDepartmentID.Value).Split('|');
                }
                else
                {
                    //前线人员负责人
                    sHRTree = EditAreaFlow().Split('|');
                }

            
                if (sHRTree[0] != "fail")
                {

                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 3);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                   
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sHRTree[0].Split(',')[0];
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sHRTree[1].Split(',')[0];
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;
                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                }

            }
            catch
            {
                // Alert("请正确选择发文部门！");
                // return;
            }
            //if (MainID == "")
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
                ///申请人
                try
                {
                    T_OfficeAutomation_Flow flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 1);
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != EmployeeID)
                    {

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = EmployeeName;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch (Exception)
                {
                    
                   
                }
          
              
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "BorrowMoney" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 68; //在《申请表字典表》t_Dic_OfficeAutomation_Document，找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;


                
                //MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                Guid BorrowMoneyID = Guid.NewGuid();
               // int iNum =0;
                string sFlowNumber = DateTime.Now.ToString("yyyyMM") + '-';
                DataTable dtNum = da_OfficeAutomation_Document_BorrowMoney_Inherit.getbBigFlowNumber(sFlowNumber).Tables[0];
               //  bool isflag = true;
               //do
               // {
               //     iNum++;
               //     T_OfficeAutomation_Document_BorrowMoney tempClass = da_OfficeAutomation_Document_BorrowMoney_Inherit.GetModel("OfficeAutomation_Document_BorrowMoney_ApplyID='" + sApplyDate + iNum.ToString()+"'");
               //     if (null == tempClass)
               // {
               //     isflag = false;
               // }
               
               // } while (isflag);
               //this.txtApplyID.Text = sApplyDate + iNum;
               int iflowNumber = Convert.ToInt32(dtNum.Rows[0]["num"]) + 1;
               sFlowNumber = sFlowNumber + iflowNumber;//流水号
                t_OfficeAutomation_Document_BorrowMoney = GetModelFromPage(BorrowMoneyID,sFlowNumber);
              
                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.txtDepartment.Text;
                //t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = this.txtApplyID.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = sFlowNumber;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_BorrowMoney_Inherit.Add(t_OfficeAutomation_Document_BorrowMoney);//插入申请表
                InsertDetail(this.hidDetail1.Value, BorrowMoneyID);
                //InsertBorrowMoneyDetail(t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_ID);

                #region 保存默认流程
              

             
                //#region 添加部门负责人
                //try
                //{
                //    if (sHRTree[0] != "fail")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = sHRTree[0].Split(',')[0];
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = sHRTree[1].Split(',')[0];
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch (Exception)
                //{
                    
                   
                //}
              
              
                //#endregion

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 72, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_BorrowMoney_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
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
        DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();

        DataSet ds = da_OfficeAutomation_Document_BorrowMoney_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_BorrowMoney_ID"].ToString(); 
        
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

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BorrowMoney_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_BorrowMoney_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    //sbMailBody.Append("<br/><br/>第一联：财务联<br/><br/>申请人：" + drRow["OfficeAutomation_Document_BorrowMoney_Apply"]);
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_BorrowMoney_Apply"]);
                    sbMailBody.Append("<br/>部门：" + drRow["OfficeAutomation_Document_BorrowMoney_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_BorrowMoney_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>发文编号：" + drRow["OfficeAutomation_Document_BorrowMoney_ApplyID"]);
                    sbMailBody.Append("<br/>需要日期：" + drRow["OfficeAutomation_Document_BorrowMoney_NeedDate"]);
                    sbMailBody.Append("<br/>电话/传真：" + drRow["OfficeAutomation_Document_BorrowMoney_ReplyPhone"]);


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

                            ////完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            //employname = CommonConst.EMP_GMO_NAME;
                            //employnames = employname.Split(',');
                            //for (int i = 0; i < employnames.Length; i++)
                            //{
                            //    if (!employeeList.Contains(employnames[i]))
                            //    {
                            //        msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            //        email = employnames[i];
                            //        if (hdIsAgree.Value == "2")
                            //    Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                            //        else
                            //            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                            //        employeeList += employnames[i] + "||";
                            //    }
                            //}
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
                                    Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody,MainID);
                                }
                            }

                            ////当审批到总经理的时候，发份邮件通知总办2位同事
                            //if (employname.Contains(CommonConst.EMP_GENERALMANAGER_NAME))
                            //{
                            //    employname = CommonConst.EMP_GMO_NAME;
                            //    employnames = employname.Split(',');
                            //    for (int i = 0; i < employnames.Length; i++)
                            //    {
                            //        email = employnames[i];
                            //        msnBody = "您好，" + employnames[i] + "：请注意总经理有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            //        Common.SendMessageEX(false, email, "请注意总经理有一份电子审批需要审理", msnBody + mailBody, msnBody);
                            //    }
                            //}
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

    /// <summary>
    /// 财务签名
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFinSige(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
       
        T_OfficeAutomation_Document_BorrowMoney  t_OfficeAutomation_Document_BorrowMoney = da_OfficeAutomation_Document_BorrowMoney_Inherit.GetModel(" OfficeAutomation_Document_BorrowMoney_MainID='" + MainID+"'");
        bool bFin1 = radFin1.Checked;//确认收单
        bool bFin2 = radFin2.Checked;//退单
        bool bFin3 = radFin3.Checked;//其他意见
        if (t_OfficeAutomation_Document_BorrowMoney == null)
        {
            return;
        }
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_AuditorName = EmployeeName;//财务签名姓名
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_AuditorDate = DateTime.Now.ToString();//财务签名时间
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Suggestion = txtSuggestion.Value;//财务意见
        DataSet ds = da_OfficeAutomation_Document_BorrowMoney_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BorrowMoney_Apply"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        //财务退单
        if (bFin2)
        {
           
            t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_IsAgree = radFin2.Value;
           
            da_OfficeAutomation_Document_BorrowMoney_Inherit.Edit(t_OfficeAutomation_Document_BorrowMoney);//修改财务签名
           // da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
            da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, 0);//清空所有审核人，重新行流程
            da_OfficeAutomation_Main_InheritDelete.updateFlowCancel(MainID);//财务退单状态变未审核
            
                string msnBody = "您好，" + apply + "：借用资金申请的编号为" + serialNumber + " 已通过" + EmployeeName + "的审理，状态：退单,详细内容请上电子系统查看。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                Common.SendMessageEX(false, apply, "退单", msnBody, msnBody);
            
            Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 5);//添加日志，签名不同意
        }
        else if (bFin1 || bFin3)//确认收单 、其他意见
        {
            t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_IsAgree = bFin1 ? radFin1.Value : radFin3.Value;
            da_OfficeAutomation_Document_BorrowMoney_Inherit.Edit(t_OfficeAutomation_Document_BorrowMoney);//修改财务签名
            if (bFin3)
            {
                string msnBody = "您好，" + apply + "：借用资金申请的编号为" + serialNumber + " 已通过" + EmployeeName + "的审理状态：其他意见,详细内容请上电子系统查看<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                Common.SendMessageEX(false, apply, "其他意见", msnBody , msnBody);
            }
            else if (bFin1)
            {
                string msnBody = "您好，" + apply + "：借用资金申请的编号为" + serialNumber + " 已通过" + EmployeeName + "的审理状态：确认收单,详细内容请上电子系统查看<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                Common.SendMessageEX(false, apply, "确认收单", msnBody, msnBody);
            }
            Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名同意
        }
        RunJS("alert('审理成功！');window.location='" + Page.Request.Url + "'");
    }
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
        //    DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
        //    if (EmployeeID == CommonConst.EMP_FINANCE_PUBLIC_ID)
        //        da_OfficeAutomation_Document_BorrowMoney_Inherit.AddRemarkByID(ID, CommonConst.SIGN_FINANCE);
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

    private T_OfficeAutomation_Document_BorrowMoney GetModelFromPage(Guid UndertakeProjID,string sFlowNumber)
    {
        DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
        
        T_OfficeAutomation_Document_BorrowMoney t_OfficeAutomation_Document_BorrowMoney = da_OfficeAutomation_Document_BorrowMoney_Inherit.GetModel(" OfficeAutomation_Document_BorrowMoney_ID ='" + UndertakeProjID + "'");
        if (t_OfficeAutomation_Document_BorrowMoney == null)
        {  t_OfficeAutomation_Document_BorrowMoney = new T_OfficeAutomation_Document_BorrowMoney(); }
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_ID = UndertakeProjID;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_MainID = new Guid(MainID);
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Apply = EmployeeName;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_ApplyDate = DateTime.Now;
      //  t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_ApplyDate2 = DateTime.Now.ToString("yyyy-MM-dd");

        //t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_ApplyID = txtApplyID.Text;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_ApplyID = sFlowNumber;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Department = txtDepartment.Text;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_ReplyPhone = txtReplyPhone.Text;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_NeedDate = txtNeedDate.Text;
      //  t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Reason = hidDetail1.Value;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Acount = txtAcount.Text;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Aname = txtAname.Text;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Bank = txtBank.Text;
        //t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Money = txtMoney.Text;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Money = hilMoney.Value;
        //t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_BWMoney = txtBWMoney.Text;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_BWMoney = hilBWMoney.Value;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_ApplyNo = txtApplyNo.Text;
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Area = ddlArea.SelectedValue;
        //t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_Dialog = txtDialog.Text;

        string cbt = "";
        if (cbPayK1.Checked == true)
            cbt = "|1";
        if (cbPayK2.Checked == true)
            cbt += "|2";
        if (cbPayK3.Checked == true)
            cbt += "|3";
        t_OfficeAutomation_Document_BorrowMoney.OfficeAutomation_Document_BorrowMoney_PayK = cbt;
      
       

        return t_OfficeAutomation_Document_BorrowMoney;
    }
    /// <summary>
    /// 插入Detail数据
    /// </summary>
    /// <param name="json"></param>
    /// <param name="DetailID"></param>
    /// <returns></returns>
    private void InsertDetail(string json, Guid DetailID)
    {
        //hiCostProject =费用 startDate= 起初日期 endDate=结束日期 hiOther = 其他费用  UnitPrice= 单价
        var t = new { startDate = "", endDate = "" , hiCostProject = "", hiOther = "", UnitPrice = "" };
        var l = Enumerable.Repeat(t, 1).ToList();
        var list = JsonConvert.DeserializeAnonymousType(json, l);

        var bll = new DataAccess.Operate.DA_OfficeAutomation_Document_BorrowMoney_Detail_Operate();
        bll.DelByMainID(DetailID.ToString());
        int num =1;
        foreach (var i in list)
        {
            var obj = new T_OfficeAutomation_Document_BorrowMoney_Detail
            {
                OfficeAutomation_Document_BorrowMoney_Detail_ID = Guid.NewGuid(),
                OfficeAutomation_Document_BorrowMoney_Detail_MainID = DetailID,
                OfficeAutomation_Document_BorrowMoney_Detail_StartDate = i.startDate,
                OfficeAutomation_Document_BorrowMoney_Detail_EndDate = i.endDate,
                OfficeAutomation_Document_BorrowMoney_Detail_CostProject = i.hiCostProject,
                OfficeAutomation_Document_BorrowMoney_Detail_Other = i.hiOther,
                OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice = i.UnitPrice,
                OfficeAutomation_Document_BorrowMoney_Detail_Sort = num

            };
            num++;
            bll.Add(obj);
        }
        return;
    }
    #endregion

    #region 保存、修改内容功能

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_BorrowMoney t_OfficeAutomation_Document_BorrowMoney = new T_OfficeAutomation_Document_BorrowMoney();
        DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_BorrowMoney_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BorrowMoney_ID"].ToString();

        t_OfficeAutomation_Document_BorrowMoney = GetModelFromPage(new Guid(ID), this.txtApplyID.Text);

        string apply = EmployeeName;
        string depname = this.txtDepartment.Text;
        string summary = this.txtApplyID.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_BorrowMoney_Inherit.Edit(t_OfficeAutomation_Document_BorrowMoney);//修改申请表
        InsertDetail(hidDetail1.Value,new Guid(ID));
        //DA_OfficeAutomation_Document_BorrowMoney_Detail_Inherit da_OfficeAutomation_Document_BorrowMoney_Detail_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Detail_Inherit();
        //da_OfficeAutomation_Document_BorrowMoney_Detail_Inherit.Delete(ID);
        //InsertBorrowMoneyDetail(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 72, new Guid(MainID), 2);//日志，修改申请表
    }

    #endregion

    #region 其他
    
    /// <summary>
    /// 根据选择区域审批流增加负责人
    /// </summary>
    private string  EditAreaFlow()
    {
        string FlowAudit = string.Empty;
        switch(ddlArea.SelectedValue)
        {
            case "大越秀区":
                FlowAudit = "4485|陈秋炳";
                break;
            case "白云区":
                FlowAudit = "10959|相倩倩";
                break;
            //case "大海珠区":
            //    FlowAudit = "1909|潘宇馥";
            //    break;
            case "大海珠区":
                FlowAudit = "58088|陈晓青A";
                break;
            case "大天河区":
                FlowAudit = "0091|潘婉霞";
                break;
            case "番禺一部":
                FlowAudit = "0111|黄蕙晶";
                break;
            //case "番禺二部":
            //    FlowAudit = "1909|潘宇馥";
            //    break;
            //case "花都区":
            //    FlowAudit = "1909|潘宇馥";
            case "番禺二部":
                FlowAudit = "58088|陈晓青A";
                break;
            case "花都区":
                FlowAudit = "58088|陈晓青A";
                break;
            case "芳村南海区":
                FlowAudit = "1619|张志金";
                break;
            case "工商铺一部":
                FlowAudit = "0006|罗思源";
                break;
            case "工商铺二部":
                FlowAudit = "0638|朱少娟";
                break;
            case "项目部":
                FlowAudit = "2722|易伟锋";
                break;
            //case "汇瀚":
            //    FlowAudit = "13161|曹颖思";
            case "汇瀚":
                FlowAudit = "0111|黄蕙晶";
                break;
            case "海珠东区":
                FlowAudit = "0057|杨玉筠";
                break;
            case "海珠西区":
                FlowAudit = "0019|李静思";
                break;
            default:
                FlowAudit = "fail";
                break;
        }
        return FlowAudit;
   
    }
    #region 新增明细表

    /// <summary>
    /// 新增明细表
    /// </summary>
    /// <param name="gBorrowMoneyID"></param>
    //private void InsertBorrowMoneyDetail(Guid gBorrowMoneyID)
    //{
    //    if (hdDetail.Value == "")
    //        return;

    //    T_OfficeAutomation_Document_BorrowMoney_Detail t_OfficeAutomation_Document_BorrowMoney_Detail;
    //    DA_OfficeAutomation_Document_BorrowMoney_Detail_Inherit da_OfficeAutomation_Document_BorrowMoney_Detail_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Detail_Inherit();

    //    string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
    //    try
    //    {
    //        for (int i = 0; i < details.Length; i++)
    //        {
    //            string[] detail = Regex.Split(details[i], "\\&\\&");
    //            if (detail[0] == "")
    //                continue;
    //            t_OfficeAutomation_Document_BorrowMoney_Detail = new T_OfficeAutomation_Document_BorrowMoney_Detail();
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_ID = Guid.NewGuid();
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_MainID = gBorrowMoneyID;
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_Property = detail[0];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_Controler = detail[1];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_PropertyID = detail[2];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_PropertyDate = detail[3];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_OldDeal = detail[4];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_NewDeal = detail[5];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_AjustDeal = detail[6];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_ShouldComm = detail[7];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_ActualComm = detail[8];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_AjustComm = detail[9];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_LeadReason = int.Parse(detail[10]);
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_Commitment = detail[11];
    //            t_OfficeAutomation_Document_BorrowMoney_Detail.OfficeAutomation_Document_BorrowMoney_Detail_Reason = detail[12];

    //            da_OfficeAutomation_Document_BorrowMoney_Detail_Inherit.Insert(t_OfficeAutomation_Document_BorrowMoney_Detail);
    //        }
    //    }
    //    catch (Exception ee)
    //    {
    //        Alert(ee.Message);
    //        return;
    //    }
    //}

    #endregion

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        //if (Cache["AllDepartment"] == null)
        //{
        //    SbJson.Remove(0, SbJson.Length);
        //    wsKDHR.Service service = new wsKDHR.Service();
        //    DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
        //    SbJson.Append("[");

        //    foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        //    {
        //        SbJson.Append("{\"id\":\"" + dr["id"].ToString() + "\",\"value\":\"" + dr["name"].ToString() + "\"},");
        //    }

        //    SbJson.Remove(SbJson.Length - 1, 1);
        //    SbJson.Append("]");
        //    Cache["AllDepartment"] = SbJson;
        //}
        //else
        //    SbJson = (StringBuilder)Cache["AllDepartment"];
        //--
        SbJson.Remove(0, SbJson.Length);
        wsKDHR.Service service = new wsKDHR.Service();
        DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();
        SbJson.Append("[");

        // 简单去除分行下面的组别，变分行，简单过滤重复。
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
                SbJson.Append("{\"id\":\"" + dr["id"].ToString() + "\",\"value\":\"" + name + "\"},");
        }

        //foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        //{
        //    SbJson.Append("{\"value\":\"" + dr["name"] + "\"},");
        //}

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
        Response.Write("<script>window.open('Apply_BorrowMoney_Detail.aspx?MainID=" + MainID + "');</script>");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("临时借用资金申请表.pdf"));//强制下载 
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
            DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BorrowMoney_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BorrowMoney_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BorrowMoney_Department"].ToString();
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
            DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BorrowMoney_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BorrowMoney_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BorrowMoney_Department"].ToString();
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
            DA_OfficeAutomation_Document_BorrowMoney_Inherit da_OfficeAutomation_Document_BorrowMoney_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Inherit();
            DataSet ds = da_OfficeAutomation_Document_BorrowMoney_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_BorrowMoney_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_BorrowMoney_Department"].ToString();
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
            RunJS("var win=window.showModalDialog(\"Apply_BorrowMoney_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
}