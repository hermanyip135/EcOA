using DataAccess.Operate;
using DataEntity;
using DataEntity.PageModel;
using ECOA.Common;
using Newtonsoft.Json;
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
using Excel = Microsoft.Office.Interop.Excel;

public partial class Apply_ExemptionBadDebt_Apply_ExemptionBadDebt_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbHtml3 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();

    public string ApplyN;
    public StringBuilder SbHtmlLogisticsFlow = new StringBuilder();

    public string ApplyDisplayPart = "$(\"#btnAddRow\").show();$(\"#btnDeleteRow\").show();$(\"#btnAddRow2\").show();$(\"#btnDeleteRow2\").show();$(\"#btnAddRow3\").show();$(\"#btnDeleteRow3\").show();";


    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        string UrlMainID = GetQueryString("MainID");

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
                if (Session["FLG_ReWrite65"].ToString() == "1")
                {
                    ViewState["FLG_ReWrite"] = "1";
                    Session["FLG_ReWrite65"] = null;
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
    ///保存申请
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {

        #region 创建对象

        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_ExemptionBadDebt t_OfficeAutomation_Document_ExemptionBadDebt = new T_OfficeAutomation_Document_ExemptionBadDebt();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit();
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
            if (IsNewApply)
            {
                #region 新建
                IsNewApply = false;
                DataSet ds = new DataSet();
                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Guid.NewGuid();
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "ExemptionBadDebt" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 99;  //在《申请表字典表》t_Dic_OfficeAutomation_Document，找到该表的主键，这步一错则会打开别的表

                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;



                MainID = t_OfficeAutomation_Main.OfficeAutomation_Main_ID.ToString();
                Guid ExemptionBadDebtID = Guid.NewGuid();
                t_OfficeAutomation_Document_ExemptionBadDebt = GetModelFromPage(ExemptionBadDebtID);

                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = lblDeparment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = txtApplyID.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;

                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
                da_OfficeAutomation_Document_ExemptionBadDebt_Inherit.Add(t_OfficeAutomation_Document_ExemptionBadDebt);
                AddExemptionBadDebtDetail(ExemptionBadDebtID);//豁免自动坏项目统计：
                AddExemptionBadDebtAreaComm(ExemptionBadDebtID);//三级市场自接项目各成交区域实际豁免业绩见下表

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

                #endregion
                #endregion
                Common.AddLog(EmployeeID, EmployeeName, 90, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程
                RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ExemptionBadDebt_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                #endregion
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    var MainObj = da_OfficeAutomation_Main_Inherit.GetModel("[OfficeAutomation_Main_ID]='" + MainID + "'");
                    //是否暂存
                    bool tempsave = MainObj.OfficeAutomation_Main_FlowStateID == 7;
                    if (tempsave)
                    {
                        //是,更新主表状态
                        MainObj.OfficeAutomation_Main_FlowStateID = 2;
                        da_OfficeAutomation_Main_Inherit.Edit(MainObj);
                    }
                    //更新Detail表
                    Update();
                    //暂存第一次提交需要上传附件+编辑流程
                    if (tempsave)
                    {
                        #region 保存默认流程
                        DataSet ds = new DataSet();
                        DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();

                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                        #region 根据默认流程表中的固定环节添加流程

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

                        #endregion

                        #endregion
                        RunJS("window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");var win=window.showModalDialog(\"Apply_ExemptionBadDebt_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=800px;dialogHeight=320px\");if(win=='success'){window.location='/Apply/Apply_Search.aspx'; }");
                    }
                    else
                    {
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
    /// 修改
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
            DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ExemptionBadDebt_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExemptionBadDebt_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ExemptionBadDebt_Department"].ToString();
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
                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7");
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
    /// <summary>
    /// 临时保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTempSave_Click(object sender, EventArgs e)
    {
        var SerialNumber = "ExemptionBadDebt" + DateTime.Now.ToString("yyyyMMddHHmmssfffff");
        var DocumentID = 99;
        var Creater = EmployeeName;
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        var ExemptionBadDebt_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit();

        //插入公共主表
        var t_OfficeAutomation_Main = da_OfficeAutomation_Main_Inherit.InsertMain(MainID, SerialNumber, DocumentID, EmployeeName, lblDeparment.Text);
        if (t_OfficeAutomation_Main == null)
        {
            Alert("保存失败！");
            return;
        }
        try
        {
            //判断是否多次点击保存按钮
            DataSet ds = new DataSet();
            T_OfficeAutomation_Document_ExemptionBadDebt ExemptionBadDebt = new T_OfficeAutomation_Document_ExemptionBadDebt();
            ds = ExemptionBadDebt_Inherit.SelectByMainID(MainID);
            if (ds.Tables[0].Rows.Count == 0)
            {
                ExemptionBadDebt = GetModelFromPage(Guid.NewGuid());
                ExemptionBadDebt_Inherit.Add(ExemptionBadDebt);
            }
            else
            {
                var ExemptionBadDebt_ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExemptionBadDebt_ID"].ToString();
                ExemptionBadDebt = GetModelFromPage(new Guid(ExemptionBadDebt_ID));
                ExemptionBadDebt_Inherit.Edit(ExemptionBadDebt);
            }

            AddExemptionBadDebtDetail(ExemptionBadDebt.OfficeAutomation_Document_ExemptionBadDebt_ID);
            AddExemptionBadDebtAreaComm(ExemptionBadDebt.OfficeAutomation_Document_ExemptionBadDebt_ID);
            RunJS("alert('保存成功！');window.location.href='/Apply/Apply_Search.aspx';");
        }
        catch (Exception ex)
        {

            RunJS("alert('保存失败！'"+ex.Message+");window.location.href='/Apply/Apply_Search.aspx';");
        }
       
            
     

    }
    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {

        string sUrl = "/Apply/Apply_Search.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
    }
    /// <summary>
    /// 下载附件
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
            Common.AddLog(EmployeeID, EmployeeName, 64, new Guid(MainID), 8);
        }
        else
            Alert("请勾选文件再下载！");
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
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;
        string commType = e.CommandName;
        switch (commType)
        {
            case "Del":
                //if (drc[4]["OfficeAutomation_Flow_AuditorID"].ToString() != "") //法律部的人开始审批
                //{
                //    RunJS("alert('因为法律部人员已经审批完毕，所以附件不能删除！');history.go(-1);");
                //    break;
                //}
                Alert("删除附件" + (da_OfficeAutomation_Attach_Inherit.Delete(e.CommandArgument.ToString()) ? "成功!" : "失败!"));
                Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(MainID), 3);
                break;
        }

        LoadPage();
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
        DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit();
    
        DataSet ds = da_OfficeAutomation_Document_ExemptionBadDebt_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_ExemptionBadDebt_ID"].ToString();

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
                //string[] flowN;
                //flowN = ViewState["FSIN"].ToString().Split(',');//789
                bool isSignSuccess = flowIDx == "4" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);
                //bool isSignSuccess = flowIDx == "5" ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value) : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, hdIsAgree.Value);

                if (isSignSuccess)
                {
                    string[] employnames;
                    string email;
                    string msnBody, mailBody;

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExemptionBadDebt_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_ExemptionBadDebt_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_ExemptionBadDebt_Apply"]);
                    sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_ExemptionBadDebt_Department"]);
                    sbMailBody.Append("<br/>申请日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_ExemptionBadDebt_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    sbMailBody.Append("<br/>发文编号: " + drRow["OfficeAutomation_Document_ExemptionBadDebt_ApplyID"].ToString());
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

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）梁晶晶（工号：32188）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            employname = CommonConst.EMP_GMO_NAME;
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]))
                                {
                                    msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
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
    /// <summary>
    /// 撤销审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ExemptionBadDebt_Inherit.SelectByMainID(MainID); //在不同的表中要修改
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
    /// <summary>
    /// 编辑审批流
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
            DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit();
            DataSet ds = da_OfficeAutomation_Document_ExemptionBadDebt_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExemptionBadDebt_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_ExemptionBadDebt_Department"].ToString();
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
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(MainID, "7");
            da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(MainID, 10000); //在不同的表中要修改
            //在不同的表中要修改
            RunJS("var win=window.showModalDialog(\"Apply_ExemptionBadDebt_Flow.aspx?MainID=" + MainID + "\",\"\",\"dialogWidth=830px;dialogHeight=280px\");if(win=='success'){window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "'; }");

        }
        catch (Exception ex)
        {
            Alert("修改失败，错误原因：" + ex.Message);
        }
    }
    /// <summary>
    /// 另存PDF
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("三级市场一手项目豁免自动坏申请.pdf"));//强制下载 
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
    /// 导入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImport_Click(object sender, EventArgs e)
    {
          ExcelHelper excelHelper = new ExcelHelper();
        //SbJs.Append("<script type=\"text/javascript\">$(\"#btnUpload\").show();" + ApplyDisplayPart);
        string path = hdFilePath.Value;
        if (string.IsNullOrEmpty(path))
        {
            Alert("请导入豁免自动坏申请excel");
            return;
        }
        try
        {
            #region 豁免自动坏项目统计
            DataTable dt = excelHelper.fnGetDataSetByExcel(path, "豁免自动坏项目统计").Tables[0];
        List<T_OfficeAutomation_Document_ExemptionBadDebt_Detail> detaillist = new List<T_OfficeAutomation_Document_ExemptionBadDebt_Detail>();
        if(dt.Rows.Count>0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["统筹区域"].ToString()))
                {
                    if ("合计".Equals(dr["统筹区域"].ToString()))
                    {
                        txtUnitSum.Text = dr["成交宗数"].ToString();
                        txtCommSum.Text = dr["成交总佣"].ToString();
                        txtApplyUnitSum.Text = dr["申请宗数"].ToString();
                        txtApplyCommSum.Text = dr["XXXX年XX月_申请总额"].ToString();
                    }
                    else
                    {
                        T_OfficeAutomation_Document_ExemptionBadDebt_Detail t = new T_OfficeAutomation_Document_ExemptionBadDebt_Detail();
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_a = dr["统筹区域"].ToString();
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_b = dr["项目名称"].ToString();
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_c = dr["项目所在地"].ToString();
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_d = IsNUllByThis(dr["成交宗数"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_e = IsNUllByThis(dr["成交总佣"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_f = IsNUllByThis(dr["申请宗数"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_g = IsNUllByThis(dr["XXXX年XX月_申请总额"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_h = dr["未签约原因"].ToString();
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_i = dr["应收款管理组网络核查结果"].ToString();
                        t.OfficeAutomation_Document_ExemptionBadDebt_Detail_j = dr["项目统筹人"].ToString();
                        detaillist.Add(t);
                    }
                }
            }
            BingDetail1(detaillist);
        }
            #endregion
        DataTable dtComm = excelHelper.fnGetDataSetByExcel(path, "三级市场自接项目各成交区域实际豁免业绩").Tables[0];
        List<T_OfficeAutomation_Document_ExemptionBadDebt_AreaComm> dtCommlist = new List<T_OfficeAutomation_Document_ExemptionBadDebt_AreaComm>();
        if (dtComm.Rows.Count > 0)
        {

            foreach (DataRow dr in dtComm.Rows)
            {
                if (!string.IsNullOrEmpty(dr["项目名称"].ToString().Trim()))
                {
                    if ("合计".Equals(dr["项目名称"].ToString().Trim()))
                    {
                        txtApplyTotalSum.Text = dr["申请总额"].ToString();
                        txtHZTotalSum.Text = dr["大海珠区"].ToString();
                        txtTHTotalSum.Text = dr["大天河区"].ToString();
                        txtBYTotalSum.Text = dr["大白云区"].ToString();
                        txtYXTotalSum.Text = dr["大越秀区"].ToString();
                        txtHDTotalSum.Text = dr["花都区"].ToString();
                        txtPYTotalSum.Text = dr["番禺一部"].ToString();
                        txtPY2TotalSum.Text = dr["番禺二部"].ToString();
                        txtGS1TotalSum.Text = dr["工商铺一部"].ToString();
                        txtGS2TotalSum.Text = dr["工商铺二部"].ToString();
                        txtFCTotalSum.Text = dr["芳村南海"].ToString();
                    }
                    else
                    {
                        T_OfficeAutomation_Document_ExemptionBadDebt_AreaComm t = new T_OfficeAutomation_Document_ExemptionBadDebt_AreaComm();
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_a = dr["项目名称"].ToString();
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_b = IsNUllByThis(dr["申请总额"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_c = IsNUllByThis(dr["大海珠区"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_d = IsNUllByThis(dr["大天河区"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_e = IsNUllByThis(dr["大白云区"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_f = IsNUllByThis(dr["大越秀区"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_g = IsNUllByThis(dr["花都区"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_h = IsNUllByThis(dr["番禺一部"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_i = IsNUllByThis(dr["工商铺一部"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_j = IsNUllByThis(dr["工商铺二部"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_k = IsNUllByThis(dr["番禺二部"].ToString());
                        t.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_l = IsNUllByThis(dr["芳村南海"].ToString());
                        dtCommlist.Add(t);
                    }
               }
            }
            BingDetail2(dtCommlist);
        }
        }
        catch (Exception ex)
        {

            Alert("导入失败：" + ex.Message.ToString());
        }
    }
    /// <summary>
    /// 加载页面
    /// </summary>
    public void LoadPage()
    {
        bool IsTempSave = false;        //是否暂存
        IsNewApply = false;
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit();
        DA_OfficeAutomation_Document_ExemptionBadDebt_Detail_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_Detail_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Detail_Inherit();
        DA_OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Inherit();

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

        DataSet ds = new DataSet();
        DataSet ExemptionBadDebt = new DataSet();

        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
       ExemptionBadDebt = da_OfficeAutomation_Document_ExemptionBadDebt_Inherit.SelectByMainID(MainID);
        ID = ExemptionBadDebt.Tables[0].Rows[0]["OfficeAutomation_Document_ExemptionBadDebt_ID"].ToString();
        var detaillist = da_OfficeAutomation_Document_ExemptionBadDebt_Detail_Inherit.SelectListByMainID(ID);
        var detail_AreaCommlist = da_OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Inherit.SelectListByMainID(ID);
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 7)
        {
            IsTempSave = true;
        }
        else
        {
            //隐藏暂存按钮
            this.btnTemp.Visible = false;
        }

        #region 获取当前申请主表数据
        //获取当前申请主表数据填充ds
        ds = ExemptionBadDebt;
        DataRow dr = ds.Tables[0].Rows[0];
        string applicant = dr["OfficeAutomation_Document_ExemptionBadDebt_Apply"].ToString();
        ApplyN = applicant;
        txtApplyID.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_ApplyID"].ToString();
        lblDeparment.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_Department"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExemptionBadDebt_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        txtTerm.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_Term"].ToString();
        txtHopeDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_ExemptionBadDebt_HopeDate"].ToString()).ToString("yyyy-MM-dd");
        txt1Y.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_1Y"].ToString();
        txt1M.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_1M"].ToString();
        txt2Y.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_2Y"].ToString();
        txt2M.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_2M"].ToString();
        txtUnitSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_UnitSum"].ToString() == "0.00" ? "0" : Convert.ToInt32(dr["OfficeAutomation_Document_ExemptionBadDebt_UnitSum"].ToString().Split('.')[0]).ToString() ;
        txtCommSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_CommSum"].ToString();
        txtApplyTotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_ApplyTotalSum"].ToString();
        txtHZTotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_HZTotalSum"].ToString();
        txtTHTotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_THTotalSum"].ToString();
        txtBYTotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_BYTotalSum"].ToString();
        txtYXTotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_YXTotalSum"].ToString();
        txtHDTotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_HDTotalSum"].ToString();
        txtPYTotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_PYTotalSum"].ToString();
        txtGS1TotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_GS1TotalSum"].ToString();
        txtGS2TotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_GS2TotalSum"].ToString();
        txtFCTotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_FCTotalSum"].ToString();
        txtPY2TotalSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_PY2TotalSum"].ToString();
        txtApplyUnitSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_ApplyUnitSum"].ToString() == "0.00" ? "0" : Convert.ToInt32(dr["OfficeAutomation_Document_ExemptionBadDebt_ApplyUnitSum"].ToString().Split('.')[0]).ToString();
        txtApplyCommSum.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_ApplyCommSum"].ToString()  ;
        txtContent.Text = dr["OfficeAutomation_Document_ExemptionBadDebt_Content"].ToString();
      
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        #endregion
        #region 豁免自动坏项目统计：
        BingDetail1(detaillist);
        #endregion

        #region 三级市场自接项目各成交区域实际豁免业绩见下表：

        BingDetail2(detail_AreaCommlist);
        #endregion
   
        #endregion

        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。

        bool isApplicant = EmployeeName == applicant;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = dsFlow.Tables[0].Rows;

        if (!IsTempSave)
        {
            //非暂存才显示上传附件按钮
            SbJs.Append("$(\"#btnUpload\").show();");
        }
        if (IsTempSave)
        {
            btnSPDF.Visible = false;
        }
        if (isApplicant)
        {
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

        #region 登录人为财务部公共帐号，且流程为完成状态时，标识留档按钮开启。


        #endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {
                SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("</script>");
                //txtDepartment.Text = "";
                btnSPDF.Visible = false; //M_PDF
                lblApply.Text = EmployeeName;
                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
        // if (flowState == "1" && applicant == EmployeeName)
        //  this.FlowShow1.ShowEditBtn = true;
        //if (flowState == "2" && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
        if ((flowState == "1" || flowState == "2") && applicant == EmployeeName && !tpdf) //20141215：M_AlterC
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
    #region 绑定页面详情
    /// <summary>
    /// 豁免自动坏项目统计
    /// </summary>
    private void BingDetail1(IList<T_OfficeAutomation_Document_ExemptionBadDebt_Detail> detaillist)
    {
        if (detaillist != null && detaillist.Count > 0)
        {
            var dlist = detaillist.Select(m => new
            {
                txtDetail_a = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_a,
                txtDetail_b = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_b,
                txtDetail_c = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_c,
                txtDetail_j = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_j,
                txtDetail_d = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_d,
                txtDetail_e = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_e,
                txtDetail_f = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_f,
                txtDetail_g = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_g,
                txtDetail_h = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_h,
                txtDetail_i = m.OfficeAutomation_Document_ExemptionBadDebt_Detail_i,
              

            }).ToList();
            this.hidDetail1.Value = JsonConvert.SerializeObject(dlist);
        }
    }

    /// <summary>
    /// 三级市场自接项目各成交区域实际豁免业绩见下表
    /// </summary>
    /// <param name="detail_AreaCommlist"></param>
    private void BingDetail2(IList<T_OfficeAutomation_Document_ExemptionBadDebt_AreaComm> detail_AreaCommlist)
    {
        #region 三级市场自接项目各成交区域实际豁免业绩见下表：
        if (detail_AreaCommlist != null && detail_AreaCommlist.Count > 0)
        {
            var dlist = detail_AreaCommlist.Select(m => new
            {
                txtDetail2_a = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_a,
                txtDetail2_b = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_b,
                txtDetail2_c = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_c,
                txtDetail2_d = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_d,
                txtDetail2_e = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_e,
                txtDetail2_f = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_f,
                txtDetail2_g = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_g,
                txtDetail2_h = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_h,
                txtDetail2_i = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_i,
                txtDetail2_j = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_j,
                txtDetail2_k = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_k,
                txtDetail2_l = m.OfficeAutomation_Document_ExemptionBadDebt_AreaComm_l,

            }).ToList();
            this.hidDetail2.Value = JsonConvert.SerializeObject(dlist);
        }

        #endregion
    }
    #endregion

    /// <summary>
    /// 新页面
    /// </summary>
    private void NewPage()
    {
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        lblApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        lblDeparment.Text = UnitName;
        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);
        SbJs.Append("</script>");
        IsNewApply = true;
        MainID = Guid.NewGuid().ToString();
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
    /// <summary>
    /// 更新修改内容
    /// </summary>
    private void Update()
    {
        T_OfficeAutomation_Document_ExemptionBadDebt t_OfficeAutomation_Document_ExemptionBadDebt = new T_OfficeAutomation_Document_ExemptionBadDebt();
        DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_ExemptionBadDebt_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ExemptionBadDebt_ID"].ToString();

        t_OfficeAutomation_Document_ExemptionBadDebt = GetModelFromPage(new Guid(ID));

        string apply = EmployeeName;
        string depname = this.lblDeparment.Text;
        string summary = this.txtApplyID.Text;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_ExemptionBadDebt_Inherit.Edit(t_OfficeAutomation_Document_ExemptionBadDebt);//修改申请表

        AddExemptionBadDebtDetail(new Guid(ID));//豁免自动坏项目统计

        AddExemptionBadDebtAreaComm(new Guid(ID));//三级市场自接项目各成交区域实际豁免业绩见下表


        Common.AddLog(EmployeeID, EmployeeName, 90, new Guid(MainID), 2);//日志，修改申请表
    }
    /// <summary>
    /// 豁免自动坏项目统计
    /// </summary>
    /// <param name="gExemptionBadDebtID"></param>
    private void AddExemptionBadDebtDetail(Guid gExemptionBadDebtID)
    {
        if (string.IsNullOrEmpty(hidDetail1.Value))
        {
            return;
        }
        var t = new { txtDetail_a = "", txtDetail_b = "", txtDetail_c = "", txtDetail_d = "", txtDetail_e = ""
            , txtDetail_f = "", txtDetail_g = "", txtDetail_h = "", txtDetail_i = "", txtDetail_j = "" };
        var l = Enumerable.Repeat(t, 1).ToList();
        var list = JsonConvert.DeserializeAnonymousType(hidDetail1.Value, l);
        DA_OfficeAutomation_Document_ExemptionBadDebt_Detail_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_Detail_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_Detail_Inherit();
        da_OfficeAutomation_Document_ExemptionBadDebt_Detail_Inherit.DelByMainID(gExemptionBadDebtID.ToString());//删除表
        int num = 1;
        foreach (var i in list)
        {
            var obj = new T_OfficeAutomation_Document_ExemptionBadDebt_Detail
            {
                OfficeAutomation_Document_ExemptionBadDebt_Detail_ID = Guid.NewGuid(),
                OfficeAutomation_Document_ExemptionBadDebt_Detail_MainID = gExemptionBadDebtID,
                OfficeAutomation_Document_ExemptionBadDebt_Detail_a = i.txtDetail_a,
                OfficeAutomation_Document_ExemptionBadDebt_Detail_b = i.txtDetail_b,
                OfficeAutomation_Document_ExemptionBadDebt_Detail_c = i.txtDetail_c,
                OfficeAutomation_Document_ExemptionBadDebt_Detail_d = IsNUllByThis(i.txtDetail_d),
                OfficeAutomation_Document_ExemptionBadDebt_Detail_e = IsNUllByThis(i.txtDetail_e),
                OfficeAutomation_Document_ExemptionBadDebt_Detail_f = IsNUllByThis(i.txtDetail_f),
                OfficeAutomation_Document_ExemptionBadDebt_Detail_g = IsNUllByThis(i.txtDetail_g),
                OfficeAutomation_Document_ExemptionBadDebt_Detail_h = i.txtDetail_h,
                OfficeAutomation_Document_ExemptionBadDebt_Detail_i = i.txtDetail_i,
                OfficeAutomation_Document_ExemptionBadDebt_Detail_j = i.txtDetail_j,
                OfficeAutomation_Document_ExemptionBadDebt_Detail_Sort = num
            };
            num++;
            da_OfficeAutomation_Document_ExemptionBadDebt_Detail_Inherit.Add(obj);//添加
        }
        return;
    }

    /// <summary>
    /// 三级市场自接项目各成交区域实际豁免业绩见下表
    /// </summary>
    /// <param name="gExemptionBadDebtID"></param>
    private void AddExemptionBadDebtAreaComm(Guid gExemptionBadDebtID)
    {
        if (string.IsNullOrEmpty(hidDetail2.Value))
        {
            return;
        }
        var t = new { txtDetail2_a = "", txtDetail2_b = "", txtDetail2_c = "", txtDetail2_d = "", txtDetail2_e = "", txtDetail2_f = "", txtDetail2_g = "", txtDetail2_h = "", txtDetail2_i = "", txtDetail2_j = "", txtDetail2_k = "", txtDetail2_l = "" };
        var l = Enumerable.Repeat(t, 1).ToList();
        var list = JsonConvert.DeserializeAnonymousType(hidDetail2.Value, l);
        DA_OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Inherit da_OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Inherit = new DA_OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Inherit();
        da_OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Inherit.DelByMainID(gExemptionBadDebtID.ToString());//删除表
        int num = 1;
        foreach (var i in list)
        {
            var obj = new T_OfficeAutomation_Document_ExemptionBadDebt_AreaComm
            {
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_ID = Guid.NewGuid(),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_MainID = gExemptionBadDebtID,
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_a = i.txtDetail2_a,
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_b = IsNUllByThis(i.txtDetail2_b),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_c = IsNUllByThis(i.txtDetail2_c),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_d = IsNUllByThis(i.txtDetail2_d),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_e = IsNUllByThis(i.txtDetail2_e),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_f = IsNUllByThis(i.txtDetail2_f),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_g = IsNUllByThis(i.txtDetail2_g),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_h = IsNUllByThis(i.txtDetail2_h),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_i = IsNUllByThis(i.txtDetail2_i),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_j = IsNUllByThis(i.txtDetail2_j),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_k = IsNUllByThis(i.txtDetail2_k),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_l = IsNUllByThis(i.txtDetail2_l),
                OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Sort = num
            };
            num++;
            da_OfficeAutomation_Document_ExemptionBadDebt_AreaComm_Inherit.Add(obj);//添加
        }
        return;
    }
    /// <summary>
    /// 获取页面值
    /// </summary>
    /// <param name="ExemptionBadDebtID"></param>
    /// <returns></returns>
    private T_OfficeAutomation_Document_ExemptionBadDebt GetModelFromPage(Guid ExemptionBadDebtID)
    {
        T_OfficeAutomation_Document_ExemptionBadDebt t = new T_OfficeAutomation_Document_ExemptionBadDebt();
        t.OfficeAutomation_Document_ExemptionBadDebt_ID = ExemptionBadDebtID;
        t.OfficeAutomation_Document_ExemptionBadDebt_MainID = new Guid(MainID);
        t.OfficeAutomation_Document_ExemptionBadDebt_Apply = lblApply.Text;
        t.OfficeAutomation_Document_ExemptionBadDebt_ApplyID = txtApplyID.Text;
        t.OfficeAutomation_Document_ExemptionBadDebt_Department = lblDeparment.Text;
        t.OfficeAutomation_Document_ExemptionBadDebt_ApplyDate = DateTime.Now;
        t.OfficeAutomation_Document_ExemptionBadDebt_Term = txtTerm.Text;
        t.OfficeAutomation_Document_ExemptionBadDebt_HopeDate = DateTime.Parse(this.txtHopeDate.Text);

        t.OfficeAutomation_Document_ExemptionBadDebt_1Y = txt1Y.Text;
        t.OfficeAutomation_Document_ExemptionBadDebt_1M = txt1M.Text;
        t.OfficeAutomation_Document_ExemptionBadDebt_2Y = txt2Y.Text;
        t.OfficeAutomation_Document_ExemptionBadDebt_2M = txt2M.Text;
        t.OfficeAutomation_Document_ExemptionBadDebt_UnitSum = IsNUllByThis(txtUnitSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_CommSum = IsNUllByThis(txtCommSum.Text);
     
        t.OfficeAutomation_Document_ExemptionBadDebt_ApplyTotalSum = IsNUllByThis(txtApplyTotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_HZTotalSum = IsNUllByThis(txtHZTotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_THTotalSum = IsNUllByThis(txtTHTotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_BYTotalSum = IsNUllByThis(txtBYTotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_YXTotalSum = IsNUllByThis(txtYXTotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_HDTotalSum = IsNUllByThis(txtHDTotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_PYTotalSum = IsNUllByThis(txtPYTotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_PY2TotalSum = IsNUllByThis(txtPY2TotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_GS1TotalSum = IsNUllByThis(txtGS1TotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_GS2TotalSum = IsNUllByThis(txtGS2TotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_FCTotalSum = IsNUllByThis(txtFCTotalSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_ApplyUnitSum = IsNUllByThis(txtApplyUnitSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_ApplyCommSum = IsNUllByThis(txtApplyCommSum.Text);
        t.OfficeAutomation_Document_ExemptionBadDebt_Content = txtContent.Text;
        return t;
    }
    /// <summary>
    /// 当前是否有数据没有 返回0.00
    /// </summary>
    /// <param name="thisText"></param>
    /// <returns></returns>
    private decimal IsNUllByThis(string thisText)
    {
        if (string.IsNullOrEmpty(thisText))
        {
            return Convert.ToDecimal(0.00);
        }
        return Convert.ToDecimal(thisText);
    }
}