using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Operate;
using DataEntity;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using DataEntity.PageModel;

public partial class Apply_Recruit_Apply_Recruit_Detail : BasePage
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
                if (Session["FLG_ReWrite74"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite74"] = null;
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
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    public void InitPage()
    {
        GetAllDepartment();
    }

    /// <summary>
    /// 新页面
    /// </summary>
    public void NewPage()
    {
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;

        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);
        SbJs.Append("</script>");
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        bool IsTempSave = false;        //是否暂存
        IsNewApply = false;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        var RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();

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

        SbJs.Append("<script type=\"text/javascript\">$(\"#uploadify\").hide();$('.btnaddRow').hide();");

        #region 流程状态为3时，表示该申请已完成。显示打印按钮。
        if (flowState == "3")
            SbJs.Append("$(\"#btnPrint\").show();");
        #endregion

        #region 加载页面数据

        DataSet dsRecruit = new DataSet();
        var DetailBLL = new DA_OfficeAutomation_Document_Recruit_Detail_Operate();
        var list1 = new List<T_OfficeAutomation_Document_Recruit_Detail>();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            //从暂存xml中读取
            var Recruitobj = new Common().GetTempSaveEntity<DataEntity.PageModel.Apply_Recruit_Detail>("RecruitDetail", "", Mainobj.OfficeAutomation_SerialNumber);
            //dsRecruit = Common.GetPageDetailDS<T_OfficeAutomation_Document_Recruit>(Recruitobj.Recruit, Mainobj);
            list1 = ECOA.Common.SerializationHelper.GetEntities<T_OfficeAutomation_Document_Recruit_Detail>(Common.GetDataSet<T_OfficeAutomation_Document_Recruit_Detail>(Recruitobj.list).Tables[0]).ToList();           
            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;

            //从数据库中读取
            //dsRecruit = RecruitBLL.SelectByMainID(MainID);
            list1 = DetailBLL.SelectListByMainID(MainID);
        }
        //主表
        dsRecruit = RecruitBLL.SelectByMainID(MainID);
        string RecruitID = dsRecruit.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_ID"].ToString();
        string applicant = dsRecruit.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_Apply"].ToString();       //申请人
        this.litSerialNumber.Text = dsRecruit.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();

        var obj = ECOA.Common.SerializationHelper.GetEntity<T_OfficeAutomation_Document_Recruit>(dsRecruit.Tables[0]);  //DataSet 转 实体
        CommonSerialization.BindObjectToControl("t_OfficeAutomation_Document_Recruit", obj, this.Page.Master.FindControl("ContentPlaceHolder1"));   //实体给form赋值

        //明细
        //var DetailBLL = new DA_OfficeAutomation_Document_Recruit_Detail_Operate();
        //var list = DetailBLL.SelectListByMainID(MainID);
        var list = list1;

        if (list != null)
        {
            var l = list.Where(m => m.OfficeAutomation_Document_Recruit_Detail_Type == "1").OrderBy(m => m.OfficeAutomation_Document_Recruit_Detail_AddTime).ToList();
            if (l != null)
            {
                this.hidDetail1.Value = JsonConvert.SerializeObject(l);
            }
            l = list.Where(m => m.OfficeAutomation_Document_Recruit_Detail_Type == "2").OrderBy(m => m.OfficeAutomation_Document_Recruit_Detail_AddTime).ToList();
            if (l != null)
            {
                this.hidDetail2.Value = JsonConvert.SerializeObject(l);
            }
        }
        this.TakeOfficeDate.Text = string.IsNullOrEmpty(this.TakeOfficeDate.Text) ? "" : Convert.ToDateTime(this.TakeOfficeDate.Text).ToString("yyyy-MM-dd");
        this.gwApplyDate.Text = string.IsNullOrEmpty(this.gwApplyDate.Text) ? "" : Convert.ToDateTime(this.gwApplyDate.Text).ToString("yyyy-MM-dd");

        //申请完成以后，有权限的人才能看到
        if (flowState == "3" && Purview.Contains("OA_Search_083"))
        {
            this.plHRHandle.Visible = true;
            var l = new DataAccess.Operate.DA_OfficeAutomation_Document_RecruitHRResult_Operate().SelectListByMainID(MainID);
            this.hidHRDetail.Value = Newtonsoft.Json.JsonConvert.SerializeObject(l);
        }
        
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。

        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;

        //SbJs.Append("$(\"#btnUpload\").show();");
        if (!IsTempSave)
        {
            //非暂存才显示上传附件按钮
            SbJs.Append("$(\"#btnUpload\").show();");
        }
        if (isApplicant)
        {
            SbJs.Append("$(\"#lbh1\").show();$(\"#lbh2\").show();$(\"#lbh3\").show();$(\"#uploadify\").show();$('.btnaddRow').show();");
            if (flowState == "1" || flowState == "7")
            {
                btnSave.Visible = true;
                SbJs.Append(ApplyDisplayPart);
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                btnSAlterC.Visible = true;
                SbJs.Append(ApplyDisplayPart);
            }
        }
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

        #region 显示流程示意图
        if (flowState!="7")
        {
            //自定义控件赋值
            var flowshowlist = da_OfficeAutomation_Flow_Inherit.GetFlowShowList(dsFlow);
            this.FlowShow1.FlowShowList = flowshowlist;
            //签名列表
            var flowsignlist = da_OfficeAutomation_Flow_Inherit.GetFlowsSignList(dsFlow, EmployeeID, EmployeeName);
            if (flowsignlist != null)
            {
                this.hidSignFlowsJson.Value = Newtonsoft.Json.JsonConvert.SerializeObject(flowsignlist);
            }
            //2019-04-11 因下面2016-08-01判断有点问题重新设置
               var idx7 = flowshowlist.Find(m => m.Idx == 7);
               var idx8 = flowshowlist.Find(m => m.Idx == 8);
               var idx9 = flowshowlist.Find(m => m.Idx == 9);
               bool IsIdx = EmployeeName == idx7.Employee || EmployeeName == idx8.Employee;
               if (IsIdx && (idx9 == null ||string.IsNullOrEmpty(idx9.AuditorID)))
            {
             //当前登陆的是人力资源的人并且营业主持总监未审核
                   
                this.lbtnAddHQ.Visible = true;
                this.lbtnDelHQ.Visible = true;
            }
            //================2016-8-1==================
            //var idx5 = flowshowlist.Find(m => m.Idx == 5);
            //if (flowState != "3" && flowshowlist.Find(m => m.Idx == 7) == null && idx5 != null && (idx5.EmployeeID + ",").Contains(EmployeeID + ","))
            //{
            //    //没有添加后勤处且当前登陆的是人力资源的人
            //    this.lbtnAddHQ.Visible = true;
            //}
            //else if (flowState != "3" && flowshowlist.Find(m => m.Idx == 10) != null && flowshowlist.Find(m => m.Idx == 8).Audit == false && (flowshowlist.Find(m => m.Idx == 7).EmployeeID + ",").Contains(EmployeeID + ","))
            //{
            //    //后勤处还没审批且当前登陆的是人力资源的人
            //    this.lbtnDelHQ.Visible = true;
            //}
            //==========================================
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
        }
        else //20150225：M_DeleteC 不同意时显示最后确认时间
        {
            DA_OfficeAutomation_Document_LastSure_Inherit da_OfficeAutomation_Document_LastSure_Inherit = new DA_OfficeAutomation_Document_LastSure_Inherit();
            dsMain = da_OfficeAutomation_Document_LastSure_Inherit.SelectByMid(MainID);
            if (dsMain.Tables[0].Rows.Count > 0)
            {
                SbJs.Append("$('#snum').prepend('<span id=\"SummaryOfDelete_Green\" style=\"color:green; float:left; font-weight: bold\">区域最后确认时间：" + dsMain.Tables[0].Rows[0]["OfficeAutomation_Document_LastSure_Time"].ToString() + "</span>');");
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

    protected void btnReWrite_Click(object sender, EventArgs e)
    {
        btnReWrite.Visible = false;
        btnSave.Visible = false;
        Session["FLG_ReWrite74"] = "1";
        Response.Write("<script>window.open('Apply_Recruit_Detail.aspx?MainID=" + MainID + "');</script>");
    }

    /// <summary>
    /// 保存按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region 创建对象
        var t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        var t_Recruit = new T_OfficeAutomation_Document_Recruit();
        var t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        var da_RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();
        var RecruitDetailBLL = new DA_OfficeAutomation_Document_Recruit_Detail_Operate();
        var da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        #endregion

        string[] sHRTree;
        string deptID = "";

        if (ApplyType.SelectedValue == "1" || ApplyType.SelectedValue == "3")
        {
            deptID = hdDepartmentID.Value;
        }
        else 
        {
            deptID = hdgwdDepartmentID.Value;
        }

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
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
                //20170608 注释掉，如果不注释掉，弹出请正确选择发文部门的提示后再点击保存会走到修改编辑
                //IsNewApply = false;

                
                try
                {
                    sHRTree = Common.GetHRTreeByDepartmentID(deptID).Split('|');
                }
                catch
                {
                    Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                    return;
                } 

                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "Recruit" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 78;
                t_Recruit.OfficeAutomation_Document_Recruit_MainID = new Guid(MainID);

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;

                

                var DID = Guid.NewGuid();
                t_Recruit = GetModelFromPage(DID);

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = this.Department.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = this.Remark.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_RecruitBLL.Add(t_Recruit);//插入申请表

                //明细
                RecruitDetailBLL.DeleteByMainID(MainID);        //清空MainID相关明细
                var list1 = GetDetailEntityList(this.hidDetail1.Value);
                var list2 = GetDetailEntityList(this.hidDetail2.Value);
                InsertDetail(list1, list2, DID);

                #region 保存默认流程

                var da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                //20170111添加  根据申请部门插入不同的hr审批人

                InsertHrFlow(deptID, MainID);


                //根据默认流程表中的固定环节添加流程
                da_OfficeAutomation_Flow_Inherit.InsertDefaultFlow(t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString());

                //项目部营业人员 职级4-5级	直属主管+隶属主管+部门负责人+人力资源部负责人
                //               6级或以上  直属主管+隶属主管+部门负责人+人力资源部负责人
                //非营业员       职级1-4级  直属主管 + 隶属主管 + 部门负责人+人力资源部负责人
                //               5级或以上  直属主管 + 隶属主管 + 部门负责人 + 人力资源部负责人+后勤事务部负责人+董事总经理
                SpeacilFlowInsert(this.DepartmentType.SelectedValue, this.Grade.SelectedValue, this.gwGrade.SelectedValue, MainID);

                #endregion

                Common.AddLog(EmployeeID, EmployeeName, 81, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程//*-

                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_Recruit_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=330px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑

                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    
                    var RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();
                    DataSet ds = RecruitBLL.SelectByMainID(MainID);

                    string departmentid = deptID;
                     string departmentName="";
                     string deptname = "";
                     if (ApplyType.SelectedValue == "1" || ApplyType.SelectedValue == "3")
                     {
                         departmentName = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_Department"].ToString();
                         //页面上的部门名称
                         deptname = Department.Text;
                     }
                     else
                     {
                         departmentName = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_gwDepartment"].ToString();
                         deptname = gwDepartment.Text;
                     }

                    if (string.IsNullOrEmpty(departmentid))
                    {
                        if (deptname != departmentName)
                        {
                            Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                            return;
                        }

                    }
                   

                    var MainObj = da_OfficeAutomation_Main_Inherit.GetModel("[OfficeAutomation_Main_ID]='" + MainID + "'");
                    //是否暂存
                    bool tempsave = MainObj.OfficeAutomation_Main_FlowStateID == 7;
                    if (tempsave)
                    {
                        //是,更新主表状态
                        MainObj.OfficeAutomation_Main_FlowStateID = 2;
                        da_OfficeAutomation_Main_Inherit.Edit(MainObj);

                        //根据默认流程表中的固定环节添加流程
                        da_OfficeAutomation_Flow_Inherit.InsertDefaultFlow(MainObj.OfficeAutomation_Main_ID.ToString());
                    }
                    Update();
                    if (tempsave)
                    {
                        RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_Recruit_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=330px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                    }
                    else {
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
            Alert("保存失败！" + ex.Message);
        }
    }

    /// <summary>
    /// 暂时保存按钮
    /// 2016/10/18-52100
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTempSave_Click(object sender, EventArgs e)
    {
        #region 创建对象
        var t_Recruit = new T_OfficeAutomation_Document_Recruit();
        var t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        var da_RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();
        var RecruitDetailBLL = new DA_OfficeAutomation_Document_Recruit_Detail_Operate();
        var da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        #endregion

         string[] sHRTree;

         DataSet ds = new DataSet();
         ds = da_RecruitBLL.SelectByMainID(MainID);
         if (ds.Tables[0].Rows.Count == 0)
         {
             string deptID = "";

             if (ApplyType.SelectedValue == "1" || ApplyType.SelectedValue == "3")
             {
                 deptID = hdDepartmentID.Value;
             }
             else
             {
                 deptID = hdgwdDepartmentID.Value;
             }

             try
             {
                 sHRTree = Common.GetHRTreeByDepartmentID(deptID).Split('|');
             }
             catch
             {
                 Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                 return;
             }
         }
         else 
         {
             string departmentid = "";
             string deptname = "";
             string department = "";
             if (ApplyType.SelectedValue == "1" || ApplyType.SelectedValue == "3")
             {
                 departmentid = hdDepartmentID.Value;
                 department = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_Department"].ToString();
                 deptname = Department.Text;
             }
             else
             {
                 departmentid = hdgwdDepartmentID.Value;
                 department = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_gwDepartment"].ToString();
                 deptname = gwDepartment.Text;
             }
            
             
             if (string.IsNullOrEmpty(departmentid))
             {
                 if (deptname != department)
                 {
                     Response.Write("<script type=\"text/javascript\">alert('请正确选择发文部门！');window.history.go(-1);</script>");
                     return;
                 }
             }
         }

        var SerialNumber = "Recruit" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
        var DocumentID = 78;
        var Creater = EmployeeName;

        //插入主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName,Department.Text);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }

        //判断是否多次点击保存按钮
        
        if (ds.Tables[0].Rows.Count == 0)
        {
            t_Recruit = GetModelFromPage(Guid.NewGuid());
            da_RecruitBLL.Add(t_Recruit);//插入申请表 
        }
        else
        {
            var Recruit_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_ID"].ToString();
            t_Recruit = GetModelFromPage(new Guid(Recruit_ID));
            da_RecruitBLL.Edit(t_Recruit);//插入申请表 
        }
        var obj = new Apply_Recruit_Detail();
        obj.MainEntity = t_OfficeAutomation_Main;
       
        
        var list = new List<T_OfficeAutomation_Document_Recruit_Detail>();
        var list1 = GetDetailEntityList(this.hidDetail1.Value);
        list.AddRange(list1);
        var list2 = GetDetailEntityList(this.hidDetail2.Value);
        list.AddRange(list2);

        obj.Recruit = t_Recruit;
        obj.list = list;

        //暂存数据保存到xml文件中
        var result = new Common().SaveTempSaveFile<Apply_Recruit_Detail>(obj, "RecruitDetail", "", t_OfficeAutomation_Main.OfficeAutomation_SerialNumber);
        if (result)
        {
            RunJS("alert('保存成功！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
        else
        {
            RunJS("alert('保存失败！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
    }
   

    /// <summary>
    /// 修改按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSAlterC_Click(object sender, EventArgs e)
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
            var RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();
            DataSet ds = RecruitBLL.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Recruit_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;

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
            Common.AddLog(EmployeeID, EmployeeName, 73, new Guid(MainID), 8);
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
        var RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();

        DataSet ds = RecruitBLL.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_Recruit_ID"].ToString();

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

                //如果为第5步流程则为其一审核即可通过，其他为同时审核。
                ViewState["FSIN"] = "";     //单人审核的Idx赋值,号分隔
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = (flowIDx == "0" || ((IList)flowN).Contains(flowIDx)) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_Recruit_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_Recruit_Apply"]);
                    sbMailBody.Append("<br/>申请表：招聘需求申请");
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_Recruit_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_Recruit_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/><br/>");

                    mailBody = sbMailBody.ToString();

                    if (hdIsAgree.Value != "0")//同意或其他意见
                    {
                        string allSuggestion = "";
                        Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(MainID), 4);//添加日志，签名同意

                        //判断审批流程是否完成,通知相应人员
                        if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(MainID))
                        {
                            #region 流程全部结束
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
                                        msnBody += allSuggestion;
                                        email = employnames[i];
                                        if (hdIsAgree.Value == "2")
                                            Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                        else
                                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                        employeeList += employnames[i] + "||";
                                    }
                                }
                            }

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            #endregion
                        }
                        else
                        {
                            #region 流程未完成
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
                            #endregion
                        }

                        RunJS("alert('审批成功！');window.location='" + Page.Request.Url + "'");
                    }
                    else //不同意
                    {
                        #region 不同意
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
                        #endregion
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
            var RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();
            DataSet ds = RecruitBLL.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Recruit_Department"].ToString();
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

    protected void btnBack_Click(object sender, EventArgs e)
    {

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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("招聘需求申请.pdf"));//强制下载 
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
    /// 修改流程
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            var RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();
            DataSet ds = RecruitBLL.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Recruit_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;

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
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 4); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_Recruit_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }

    #region gv 附件相关
    /// <summary>
    /// gvAttachment的行命令操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttach_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var da_OfficeAutomation_Attach_Inherit = new DA_OfficeAutomation_Attach_Inherit();
        var da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
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

    private T_OfficeAutomation_Document_Recruit GetModelFromPage(Guid ID)
    {
        var obj = new T_OfficeAutomation_Document_Recruit();
        obj = CommonSerialization.ReqDeserilizeAnEntity<T_OfficeAutomation_Document_Recruit>("t_OfficeAutomation_Document_Recruit", this.Page.Master.FindControl("ContentPlaceHolder1"));
        obj.OfficeAutomation_Document_Recruit_MainID = new Guid(MainID);
        obj.OfficeAutomation_Document_Recruit_ID = ID;
        obj.OfficeAutomation_Document_Recruit_ApplyDate = obj.OfficeAutomation_Document_Recruit_ApplyDate == DateTime.MinValue ? DateTime.Now : obj.OfficeAutomation_Document_Recruit_ApplyDate;
        obj.OfficeAutomation_Document_Recruit_Apply = string.IsNullOrEmpty(obj.OfficeAutomation_Document_Recruit_Apply) ? EmployeeName : obj.OfficeAutomation_Document_Recruit_Apply;
        return obj;
    }

    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        var obj = new T_OfficeAutomation_Document_Recruit();
        var RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();
        var RecruitDetailBLL = new DA_OfficeAutomation_Document_Recruit_Detail_Operate();

        

        DataSet ds = new DataSet();
        ds = RecruitBLL.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_ID"].ToString();

        obj = GetModelFromPage(new Guid(ID));

        string apply = "";
        string depname = this.Department.Text;
        string summary = this.Remark.Text;
        string applydate = "";
        string mainid = MainID;

        new DA_OfficeAutomation_Main_Inherit().UpdateMain(mainid, depname, apply, applydate, summary);

        RecruitBLL.Edit(obj);//修改申请表
        RecruitDetailBLL.DeleteByMainID(MainID);        //清空MainID相关明细
        var list1 = GetDetailEntityList(this.hidDetail1.Value);
        var list2 = GetDetailEntityList(this.hidDetail2.Value);
        InsertDetail(list1, list2, new Guid(ID));

        //20170111添加  根据申请部门插入不同的hr审批人
        DA_Department_Inherit department_Inherit = new DA_Department_Inherit();
        string departmentName = "";
        string departmentid = "";
        if (ApplyType.SelectedValue == "1" || ApplyType.SelectedValue == "3")
        {
            departmentName = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_Department"].ToString();
            departmentid = hdDepartmentID.Value;
        }
        else if (ApplyType.SelectedValue == "2")
        {
            departmentName = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_gwDepartment"].ToString();
            departmentid = hdgwdDepartmentID.Value;
        }

        if (departmentid == "")
        {
            departmentid = department_Inherit.GetDepartmentInfoByDeptName(departmentName).Tables[0].Rows[0]["dept_id"].ToString();
        }

        if (departmentid != "")
        {
            InsertHrFlow(departmentid, MainID);
        }

        //项目部营业人员 职级4-5级	直属主管+隶属主管+部门负责人+人力资源部负责人
        //               6级或以上  直属主管+隶属主管+部门负责人+人力资源部负责人
        //非营业员       职级1-4级  直属主管 + 隶属主管 + 部门负责人+人力资源部负责人
        //               5级或以上  直属主管 + 隶属主管 + 部门负责人 + 人力资源部负责人+后勤事务部负责人+董事总经理
        SpeacilFlowInsert(this.DepartmentType.SelectedValue, this.Grade.SelectedValue, this.gwGrade.SelectedValue, MainID);

        Common.AddLog(EmployeeID, EmployeeName, 81, new Guid(MainID), 2);//日志，修改申请表
    }

    private List<T_OfficeAutomation_Document_Recruit_Detail> GetDetailEntityList(string DetailJson)
    {
        if (string.IsNullOrEmpty(DetailJson))
        {
            return null;
        }
        return JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Recruit_Detail>>(DetailJson);

    }

    private void InsertDetail(List<T_OfficeAutomation_Document_Recruit_Detail> list1, List<T_OfficeAutomation_Document_Recruit_Detail> list2, Guid mID)
    {
        var RecruitDetailBLL = new DA_OfficeAutomation_Document_Recruit_Detail_Operate();
        if (list1 != null && list1.Count > 0)
        {
            foreach (var i in list1)
            {
                i.OfficeAutomation_Document_Recruit_Detail_ID = Guid.NewGuid();
                i.OfficeAutomation_Document_Recruit_Detail_MainID = mID;
                i.OfficeAutomation_Document_Recruit_Detail_AddTime = DateTime.Now;
                RecruitDetailBLL.Add(i);
            }
        }
        if (list2 != null && list2.Count > 0)
        {
            foreach (var i in list2)
            {
                i.OfficeAutomation_Document_Recruit_Detail_ID = Guid.NewGuid();
                i.OfficeAutomation_Document_Recruit_Detail_MainID = mID;
                i.OfficeAutomation_Document_Recruit_Detail_AddTime = DateTime.Now;
                RecruitDetailBLL.Add(i);
            }
        }
    }

    #region 获取部门
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        //if (Cache["AllDepartmentRecruit"] == null)
        if (Cache["AllDepartment"] == null)
        {
            SbJson.Remove(0, SbJson.Length);
            wsKDHR.Service service = new wsKDHR.Service();
            DataSet dsAllDepartment = service.HRAllDepartmentListGZNow();

            //DA_Department_Inherit department_Inherit = new DA_Department_Inherit();
            //DataSet dsAllDepartment = department_Inherit.GetDepartmentList();

            SbJson.Append("[");

            foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
            {
                SbJson.Append("{\"id\":\"" + dr["dept_id"].ToString() + "\",\"value\":\"" + dr["dept_name"].ToString() + "\"},");
            }

            SbJson.Remove(SbJson.Length - 1, 1);
            SbJson.Append("]");
            Cache["AllDepartment"] = SbJson;
           // Cache["AllDepartmentRecruit"] = SbJson;
        }
        else
            //SbJson = (StringBuilder)Cache["AllDepartmentRecruit"];
            SbJson = (StringBuilder)Cache["AllDepartment"];
    }
    #endregion

    protected void btnSignIDx200_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        string[] employnames;
        string email;
        string msnBody;
        var da_RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();
        DataSet ds = da_RecruitBLL.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Recruit_Apply"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_Recruit_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;

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

        #region 复审
        var flowManager = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);  //管理流程
        //同意1，不同意0，其他意见2
        string sisa = "2";
        sisa = string.IsNullOrEmpty(this.hdIsAgree.Value) ? sisa : this.hdIsAgree.Value;
        var result = new FlowCommonMethod().Review(this.hdSuggestion.Value, flowManager, MainID, EmployeeName, EmployeeID, sisa, 200);
        RunJS("alert('" + result.Split('|')[1] + "');window.location='" + Page.Request.Url + "'");
        #endregion

        //Review(200, txtIDx200.Value);
    }
    protected void btnSignIDx220_Click(object sender, EventArgs e)
    {
        string result = "";
        #region 总经理复审
        //同意1，不同意0，其他意见2
        string sisa = "2";
        sisa = string.IsNullOrEmpty(this.hdIsAgree.Value) ? sisa : this.hdIsAgree.Value;
        result = new FlowCommonMethod().Review_Manager(this.hdSuggestion.Value, MainID, EmployeeName, EmployeeID, sisa, 220);
        #endregion

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        var da_RecruitBLL = new DA_OfficeAutomation_Document_Recruit_Operate();
        DataSet ds = da_RecruitBLL.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_Recruit_Department"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;

        string employname = CommonConst.EMP_GMO_NAME;
        string[] employnames = employname.Split(',');
        string email, msnBody;
        string allsuggestion = da_OfficeAutomation_Flow_Inherit.GetAllSuggestion(MainID);
        for (int i = 0; i < employnames.Length; i++)
        {
            email = employnames[i];
            msnBody = "您好" + employnames[i] + "黄生已复审了" + department + "，编号为" + serialNumber + "的" + documentName + "。<br />黄生的意见：" + this.hdSuggestion.Value + "<br/>申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
            msnBody = msnBody + allsuggestion;
            Common.SendMessageEX(false, email, "请注意，总经理发表了复审意见", msnBody, msnBody);
        }

        //Review(220, txtIDx220.Value);

        if (result.Split('|')[0] == "0")
        {
            RunJS("alert('" + result.Split('|')[1] + "');window.location='" + Page.Request.Url + "'");
        }
        else
        {
            RunJS("alert('" + result.Split('|')[1] + "');");
        }
    }

    private void SpeacilFlowInsert(string DepartmentType, string Grade, string gwGrade, string MID)
    {

        if (string.IsNullOrEmpty(Grade) && !string.IsNullOrEmpty(gwGrade))
        {
            Grade = gwGrade;
        }
        else if (!string.IsNullOrEmpty(Grade) && string.IsNullOrEmpty(gwGrade))
        {
            gwGrade = Grade;
        }

        //项目部营业人员 职级4-5级	直属主管+隶属主管+部门负责人+人力资源部负责人
        //               6级或以上  直属主管+隶属主管+部门负责人+人力资源部负责人
        //非营业员       职级1-4级  直属主管 + 隶属主管 + 部门负责人+人力资源部负责人
        //               5级或以上  直属主管 + 隶属主管 + 部门负责人 + 人力资源部负责人+后勤事务部负责人+董事总经理
        var Flowbll = new DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit();
        if ((DepartmentType != "2" && int.Parse(Grade) >= 5 && int.Parse(gwGrade) >= 5))
        {
           // Flowbll.InsertNewFlow(new Guid(MID), "10054", "黄瑛", 7, false);
            Flowbll.InsertNewFlow(new Guid(MID), "0001", "黄轩明", 20, false);
        }
        else
        {
            Flowbll.DeleteByMainIDAndIdxs(MainID.ToString(), "20");
        }
    }

    public void HRSave_Click(object sender, EventArgs e)
    {
        var detail = this.hidHRDetail.Value;
        if (string.IsNullOrEmpty(detail))
        {
            Alert("请输入结果");
            return;
        }

        try
        {
            var r = new DataAccess.Operate.DA_OfficeAutomation_Document_Recruit_Operate().GetModel("OfficeAutomation_Document_Recruit_MainID='" + MainID + "'");
            var bll = new DataAccess.Operate.DA_OfficeAutomation_Document_RecruitHRResult_Operate();
            bll.DeleteByMainID(MainID);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_RecruitHRResult>>(detail);
            foreach (var i in list)
            {
                i.OfficeAutomation_Document_RecruitHRResult_Addtime = DateTime.Now;
                i.OfficeAutomation_Document_RecruitHRResult_ID = Guid.NewGuid();
                i.OfficeAutomation_Document_RecruitHRResult_MainID = r.OfficeAutomation_Document_Recruit_ID;
                i.OfficeAutomation_Document_RecruitHRResult_InputPerson = EmployeeName; //录入人
                bll.Add(i);
            }
            RunJS("alert('保存成功！');location.href='../Apply_Search.aspx'");
            return;
        }
        catch (Exception ex)
        {
            Alert("保存失败：" + ex.Message);
            return;
        }
    }

    /// <summary>
    /// 添加后勤处审核（2016-8-1）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void lbtnAddHQ_Click(object sender, EventArgs e)
    {
        var Flowbll = new DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit();
        //Flowbll.InsertNewFlow(new Guid(MainID), "10054", "黄瑛", 7, false); 
        //Flowbll.InsertNewFlow(new Guid(MainID), "0001", "黄轩明", 20, false); 
        Flowbll.InsertHrFlow(new Guid(MainID), "46156", "苏玲", 9); 
        RunJS("alert('添加成功！');window.location='" + Page.Request.Url + "'");
    }

    /// <summary>
    /// 去除后勤处审核（2016-8-1）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void lbtnDelHQ_Click(object sender, EventArgs e)
    {
        var Flowbll = new DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit();
        //Flowbll.DeleteByMainIDAndAfterIdxs(MainID, 7); 
        //Flowbll.DeleteByMainIDAndAfterIdxs(MainID, 20); 
        Flowbll.DeleteByMainIDAndIdx(MainID, 9);
        RunJS("alert('去除成功！');window.location='" + Page.Request.Url + "'");
    }
    /// <summary>
    /// 根据传入的总监名称看是属于哪个区然后再插入相应的审批人
    /// </summary>
    /// <param name="employeename">总监名称</param>
    public void InsertHrFlow(string deptId, string MID) 
    {
        var Flowbll = new DataAccess.Operate.DA_OfficeAutomation_Flow_Inherit();

        DA_Department_Inherit department_Inherit = new DA_Department_Inherit();
        DataSet ds = department_Inherit.GetDepartmentInfoByDeptId(deptId);
        string deptCode = ds.Tables[0].Rows[0]["full_dept_code"].ToString();
        //SYSREQ201903141204055682206  
        //if (deptCode.IndexOf(Common.AreaValue.xiangmubu) > -1 || deptCode.IndexOf(Common.AreaValue.YingBu) > -1 ) //项目部 网络营销部//内容运营部/品牌营销部
        //{
        //    Flowbll.InsertHrFlow(new Guid(MID), "67067", "罗斌C", 7);
        //}
        //else if (deptCode.IndexOf(Common.AreaValue.huihan) > -1)
        //{
        //    Flowbll.InsertHrFlow(new Guid(MID), "21779", "王子君", 7);
        //}
        //else if (deptCode.IndexOf(Common.AreaValue.yingyunzhichi) > -1 //非营业部营运支持中心
        //  ||Common.isExitsArea(Common.AreaValue.wuye1.ToString(),deptCode)//物业部（海珠，越秀，番禺一部，汇瀚,广州市汇瀚有限公司）
        // ||Common.isExitsArea(Common.AreaValue.wuye2.ToString(),deptCode)) //物业部（天河区，白云区，花都区，工商铺一、二部）
        //{
        //    Flowbll.InsertHrFlow(new Guid(MID), "65678", "朱素会", 7);
        //}
        //else //所有非营部业
        //{
        //    Flowbll.InsertHrFlow(new Guid(MID), "67067", "罗斌C", 7);
        //}

        #region [新架构，调整部门和区域负责人员]
        //财务部、法律部、法律及客服部、行政部、客户服务中心、企业培训部、区域助理秘书组、人力资源部、三级市场发展部、首席运营官、外联部、研究发展部（三级市场）、营运支持、应收款管理组、资讯科技部、总经办
        if (deptCode.IndexOf(Common.AreaValue.feiyingye) > 1)
        {
            if (deptCode.IndexOf(Common.AreaValue.feiyingye1) > 1)
            {
                Flowbll.InsertHrFlow(new Guid(MID), "66458", "谭丽仪A", 7);
            }
            else if (deptCode.IndexOf(Common.AreaValue.yingyunzhichizhongxin) > 1)
            {
                Flowbll.InsertHrFlow(new Guid(MID), "65678", "朱素会", 7);
            }
            else
            {
                Flowbll.InsertHrFlow(new Guid(MID), "67067", "罗斌C", 7);
            }
        }
        else
        {
            if (deptCode.IndexOf(Common.AreaValue.wuye3) > 1)
            {
                Flowbll.InsertHrFlow(new Guid(MID), "66458", "谭丽仪A", 7);
            }
            else if (deptCode.IndexOf(Common.AreaValue.wuye1) > 1)
            {
                Flowbll.InsertHrFlow(new Guid(MID), "65678", "朱素会", 7);
            }
            else if (deptCode.IndexOf(Common.AreaValue.huihan) > 1)
            {
                Flowbll.InsertHrFlow(new Guid(MID), "21779", "王子君", 7);
            }
            else
            {
                Flowbll.InsertHrFlow(new Guid(MID), "67067", "罗斌C", 7);
            }
        }
        #endregion

        //if (deptCode.IndexOf(Common.AreaValue.xiangmubu)>-1) //项目部
        //{
        //    Flowbll.InsertHrFlow(new Guid(MID), "51677", "翁文格", 7);
        //}
        //else if (Common.isExitsArea(Common.AreaValue.wuye1.ToString(),deptCode)) //物业部（海珠，越秀，番禺一部，汇瀚,广州市汇瀚有限公司）
        //{
        //    Flowbll.InsertHrFlow(new Guid(MID), "21779", "王子君", 7);
        //}
        //else if (Common.isExitsArea(Common.AreaValue.wuye2.ToString(),deptCode)) //物业部（天河区，白云区，花都区，工商铺一、二部）
        //{
        //    Flowbll.InsertHrFlow(new Guid(MID), "21779", "王子君", 7);
        //}
        //else if (deptCode.IndexOf(Common.AreaValue.yingyunzhichi) > -1) //非营业部营运支持中心
        //{
        //    Flowbll.InsertHrFlow(new Guid(MID), "50289", "李宇禧", 7);
        //}
        //else //所有非营部业
        //{
        //    Flowbll.InsertHrFlow(new Guid(MID), "51677", "翁文格", 7);
        //}

        //品牌营销的增加首席运营官审批流
        if (Common.isExitsArea(Common.AreaValue.brandmarketing.ToString(), deptCode))
        {
            Flowbll.InsertHrFlow(new Guid(MID), "0111", "黄蕙晶", 6);
        }
    }
}