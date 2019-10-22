using DataAccess.Operate;
using DataEntity;
using O2S.Components.PDFRender4NET;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_ElectronicFax_Apply_ElectronicFax_Detail : BasePage
{
    #region 变量声明及定义
    bool tpdf = false;
    public string SerialNumber = "";
    public StringBuilder SbHtml = new StringBuilder();
    public StringBuilder SbHtml2 = new StringBuilder();
    public StringBuilder SbJsHtml = new StringBuilder();
    public StringBuilder SbJs = new StringBuilder();
    public StringBuilder SbFlow = new StringBuilder();
    public StringBuilder SbJson = new StringBuilder();
    public StringBuilder SbJsonf = new StringBuilder();
    public string EmpID = string.Empty;//当前签名工号
    public string ApplyN;
    public string ApplyDisplayPart = "$(\"#btnAddFlow\").show();$(\"#btnDeleteFlow\").show();$(\"#divUploadDetailed\").show();";
    public string SkyPlay = "0";
    public string BigPicture = string.Empty;//大的图片
    string uploadPath = System.Configuration.ConfigurationManager.AppSettings["UploadPath"].Replace("\\", "\\\\");

    #endregion
    /// <summary>
    /// 上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnUpload_Click(object sender, EventArgs e)
    {
        string sSaveFileName = "";//文件保存名字
        string sFileName = "";//文件名
        string sSaveFilePath = "";//文件保存路径（含文件名）
        string sFilePath = "";
        string sJPGFileName = "";
        //if (this.txtFilePath.PostedFile.ContentType.ToString() == "image/pjpeg" ||this.txtFilePath.PostedFile.ContentType.ToString() =="image/x-png"|| this.txtFilePath.PostedFile.ContentType.ToString() == "image/png" || this.txtFilePath.PostedFile.ContentType.ToString() == "image/jpeg" || this.txtFilePath.PostedFile.ContentType.ToString() == "application/pdf")
        //if (this.txtFilePath.PostedFile.ContentType.ToString() == "image/pjpeg" || this.txtFilePath.PostedFile.ContentType.ToString() == "image/x-png" || this.txtFilePath.PostedFile.ContentType.ToString() == "image/png" || this.txtFilePath.PostedFile.ContentType.ToString() == "image/jpeg")
        if (this.txtFilePath.PostedFile.ContentType.ToString() == "image/pjpeg" || this.txtFilePath.PostedFile.ContentType.ToString() == "image/jpeg")
        {
            sFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            //sFilePath = "upload/" + DateTime.Now.Year.ToString() + "/" + sElectronicVerificationID + "/" + sFileName;
            sFilePath = "ElectronicFax/" + DateTime.Now.Year.ToString() + "/" + MainID + "/" + sFileName;
        }
        //判断文件格式
        if (string.IsNullOrEmpty(sFileName))
        {
            NewPage(MainID);
            this.Page.RegisterStartupScript("alert", "<script language=javascript>alert('只可以上传jpg格式图片,请重新选择！');</script>");
            //this.Page.RegisterStartupScript("alert", "<script language=javascript>alert('上传的文件格式错误,请重新选择！');</script>");
            return;
        }
        //创建文件夹
        if (!Directory.Exists(uploadPath + "ElectronicFax"))
        {
            Directory.CreateDirectory(uploadPath + "ElectronicFax");
        }
        if (!Directory.Exists(uploadPath + "ElectronicFax/" + DateTime.Now.Year.ToString()))
        {
            Directory.CreateDirectory(uploadPath + "ElectronicFax/" + DateTime.Now.Year.ToString());
        }
        if (!Directory.Exists(uploadPath + "ElectronicFax/" + DateTime.Now.Year.ToString() + "\\\\" + MainID))
        {
            Directory.CreateDirectory(uploadPath + "ElectronicFax/" + DateTime.Now.Year.ToString() + "\\\\" + MainID);
        }
        if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/pdf")
        {
            this.txtFilePath.PostedFile.SaveAs(uploadPath + sFilePath + ".pdf");
        }
        if (this.txtFilePath.PostedFile.ContentType.ToString() == "image/pjpeg" || this.txtFilePath.PostedFile.ContentType.ToString() == "image/x-png" || this.txtFilePath.PostedFile.ContentType.ToString() == "image/png" || this.txtFilePath.PostedFile.ContentType.ToString() == "image/jpeg" || this.txtFilePath.PostedFile.ContentType.ToString() == "application/pdf")
        //{ sJPGFileName = "\\" + sFilePath + ".jpg"; }
        { sJPGFileName = sFilePath + ".jpg"; }

      //  sFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";//文件名
     //   sSaveFileName = DateTime.Now.Year.ToString() + "/" + sMainID + "/" + sFileName;//文件夹
      //  sSaveFilePath = uploadPath + sSaveFileName;

        try
        {
            DA_OfficeAutomation_Document_Image_Inherit da_OfficeAutomation_Document_Image_Inherit = new DA_OfficeAutomation_Document_Image_Inherit();
            T_OfficeAutomation_Document_Image t_OfficeAutomation_Document_Image = new T_OfficeAutomation_Document_Image();
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_MainID = new Guid(MainID);
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_CreateTime = DateTime.Now;
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_Url = sJPGFileName;
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_IsDelete = "0";
            da_OfficeAutomation_Document_Image_Inherit.Add(t_OfficeAutomation_Document_Image);
            
            //pdf转jpg
            if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/pdf")
            {
                PDFTranImgHelp.ConvertPDF2Image(uploadPath + sFilePath + ".pdf", uploadPath + sJPGFileName, 1, 1, ImageFormat.Jpeg, Definition.Five);
            }
            else
            {
                this.txtFilePath.PostedFile.SaveAs(uploadPath + sJPGFileName);
            }
            BigPicture = "http:" + uploadPath + sJPGFileName;
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
          string  flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
          if (string.IsNullOrEmpty(flowState))
          {
              NewPage(MainID);
          }
          else
          {
              LoadPage();
          }
        }
        catch (Exception ex)
        {

            NewPage(MainID);
        }
      
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        GetManagers();
        SbJson.Append("[]");
        string UrlMainID = GetQueryString("MainID");
        SerialNumber = "";
        string BigImage = Request["BigImage"];//保存图片
       
        //if (!string.IsNullOrEmpty(BigImage))
        //{
        //    UploadPictrue(BigImage, MainID);
        //}
       // else
        {
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
                    if (Session["FLG_ReWrite44"].ToString() == "1")
                    {
                        ViewState["FLG_ReWrite"] = "1";
                        Session["FLG_ReWrite44"] = null;
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
                    NewPage("");

            }
            else
            {
                GetAllDepartment();
            }
        }
       
    }
    /// <summary>
    /// 保存申请
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region 创建对象

        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        T_OfficeAutomation_Document_Fax t_OfficeAutomation_Document_Fax = new T_OfficeAutomation_Document_Fax();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Fax_Inherit da_OfficeAutomation_Document_Fax_Inherit = new DA_OfficeAutomation_Document_Fax_Inherit();
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
                IsNewApply = false;
                RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=电子传真&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=" + hdflga.Value + "&deleteidxs=" + hddeleteidxs.Value + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");
                DataSet ds = new DataSet();

                t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = "Fax" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                t_OfficeAutomation_Main.OfficeAutomation_DocumentID = 93; //在《申请表字典表》t_Dic_OfficeAutomation_Document，找到该表的主键，这步一错则会打开别的表
                t_OfficeAutomation_Main.OfficeAutomation_Main_Creater = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_CrTime = DateTime.Now;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Apply = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Department = txtDepartment.Text;
                t_OfficeAutomation_Main.OfficeAutomation_Main_Summary = EmployeeName;
                t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate = DateTime.Now;
                t_OfficeAutomation_Document_Fax = GetModelFromPage(Guid.NewGuid());
                da_OfficeAutomation_Main_Inherit.Insert(t_OfficeAutomation_Main);
 
                da_OfficeAutomation_Document_Fax_Inherit.Add(t_OfficeAutomation_Document_Fax);//插入申请表
                InsertFaxDetailFlow(t_OfficeAutomation_Document_Fax.OfficeAutomation_Document_Fax_ID);

                Common.AddLog(EmployeeID, EmployeeName, 85, new Guid(MainID), 1);//日志，创建申请表
                Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 1);//日志，创建流程

                RunJS("alert('申请表保存成功！');var returnVaulue=window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");window.location='/Apply/Apply_Search.aspx';");
                #endregion
              
            }
            else
            {
                #region 修改编辑
                if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
                {
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainID(MainID);
                    RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=通用申请表&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=" + hdflga.Value + "&deleteidxs=" + hddeleteidxs.Value + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");

                    Update();
                    var MainObj = da_OfficeAutomation_Main_Inherit.GetModel("[OfficeAutomation_Main_ID]='" + MainID + "'");
                    //是否暂存
                    bool tempsave = MainObj.OfficeAutomation_Main_FlowStateID == 7;
                    if (tempsave)
                    {
                        MainObj.OfficeAutomation_Main_FlowStateID = 2;
                        da_OfficeAutomation_Main_Inherit.Edit(MainObj);
                        RunJS("alert('申请表保存成功！');var returnVaulue=window.showModalDialog(\"/Apply/Apply_UploadFile.aspx?MainID=" + MainID + "\", '" + MainID + "', \"dialogHeight=165px\");window.location='/Apply/Apply_Search.aspx';");
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
        catch (Exception)
        {
            
            throw;
        }
    }
    /// <summary>
    /// 修改申请
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSAlterC_Click(object sender, EventArgs e)
    {
        DataSet dsg = new DataSet(); //20150105：M_DeleteC
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
        dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
        if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            RunJS("window.location.href='" + Page.Request.Url + "';");
            return;
        }
        if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3") //M_WillAlter
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
        // DA_OfficeAutomation_Document_GeneralApply_Inherit da_OfficeAutomation_Document_GeneralApply_Inherit = new DA_OfficeAutomation_Document_GeneralApply_Inherit();
        DA_OfficeAutomation_Document_Fax_Inherit da_OfficeAutomation_Document_Fax_Inherit = new DA_OfficeAutomation_Document_Fax_Inherit();
        DataSet ds = da_OfficeAutomation_Document_Fax_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        DataRow drRow = ds.Tables[0].Rows[0];
        string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Main_Creater"].ToString();
        string employname;
        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = drRow["OfficeAutomation_Document_Name"].ToString();
        string applyUrl = Page.Request.Url.ToString();
        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
       
        if (Purview.Contains("OA_ITPower_001"))//是否有编辑权限
        {
            da_OfficeAutomation_Flow_Inherit.DeleteHaventA(MainID);

            RunJS("$.ajax({url: \"/Ajax/Flow_Handler.ashx\",type: \"post\",dataType: \"text\",async: false,cache: false,data: 'action=SaveCommonTableFlow&id=" + EmployeeID + "&tablename=电子上传申请&name=" + EmployeeName + "&purview=" + Purview + "&mainid=" + MainID + "&content=" + hdcontent.Value + "&flga=" + hdflga.Value + "&deleteidxs=" + hddeleteidxs.Value + "',success: function(info) {if (info == \"success\"){}else if (info == \"NoPower\"){alert(\"未开通修改编辑权限！\");history.go(-1);}else if (info == \"Conpleted\"){alert(\"该表已审批完毕，不能再修改了！\");history.go(-1);}else {alert(\"保存失败，审批流程中有部分人名不存在或不具备审批资格，请修改，如依然失败，请联系资讯科技部！错误代码：\"+ info);history.go(-1);}}})");
            Update();
            RunJS("alert('所有的修改已保存。');window.location='/Ajax/Editor_Flow.ashx?MainID=" + MainID + "&applyUrl=" + applyUrl + "&apply=" + apply + "&serialNumber=" + serialNumber + "&department=" + department + "&Jhref=" + Page.Request.Url + "&mid=" + EmployeeID + "';");
        }
        else
            Alert("未开通编辑修改权限。");
    }
    /// <summary>
    /// 取消签名
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelSign_Click(object sender, EventArgs e)
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

            //  string sFlowID = flows.OfficeAutomation_Flow_ID.ToString();
            string namesA = flows.OfficeAutomation_Flow_Auditor, idsA = flows.OfficeAutomation_Flow_AuditorID;
            string[] employnames;
            string email;
            string msnBody;
            string signEmployeeName = EmployeeName;
            DA_OfficeAutomation_Document_Fax_Detail_Inherit da_OfficeAutomation_Document_Fax_Detail_Inherit = new DA_OfficeAutomation_Document_Fax_Detail_Inherit();
            DA_OfficeAutomation_Document_Fax_Inherit da_OfficeAutomation_Document_Fax_Inherit = new DA_OfficeAutomation_Document_Fax_Inherit();
            DataSet ds = da_OfficeAutomation_Document_Fax_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            DataRow drRow = ds.Tables[0].Rows[0];
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Fax_Apply"].ToString();
            string employname;
            string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            string department = drRow["OfficeAutomation_Document_Fax_Department"].ToString();
            string applyUrl = Page.Request.Url.ToString();
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
            if (flows != null)
            {
             //   通知申请人
                msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已被" + signEmployeeName + "撤销审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                email = apply;
                Common.SendMessageEX(false, email, "您的申请已被" + signEmployeeName + "撤销审理", msnBody, msnBody);

             //   通知已审批的人员
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
                da_OfficeAutomation_Document_Fax_Detail_Inherit.deleteFaxDetailByFlowID(MainID, i);
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
    protected void btnShouldJump_Click(object sender, EventArgs e)
    {

    }
    protected void btnWillEndC_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnAddN_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnDelN_Click(object sender, EventArgs e)
    {

    }
  /// <summary>
  /// 另存PDF
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    protected void btnSPDF_Click(object sender, EventArgs e)
    {
        try
        {
            //因为Web 是多线程环境，避免甲产生的文件被乙下载去，所以档名http://localhost:2442/2017/都用唯一 
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
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("电子传真.pdf"));//强制下载 
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
    /// <summary>
    /// 点击标记按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSignSave_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            da_OfficeAutomation_Main_Inherit.AddSremarkByID(MainID, CommonConst.SIGN_FINANCE);
            RunJS("alert('标记成功！');window.location='" + Page.Request.Url + "'");
        }
        catch
        {
            RunJS("alert('标记失败。');window.location='" + Page.Request.Url + "'");
        }
    }
    /// <summary>
    /// 返回按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        string sUrl = "/Apply/Apply_Search.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
    }
    /// <summary>
    /// 签名
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSign_Click(object sender, EventArgs e)
    {
        string lastx = hiLastX.Value;
        string lasty = hiLastY.Value;

        DataSet dsg = new DataSet(); //20150105：M_DeleteC
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
        dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(MainID);
        if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {
            RunJS("alert('该表即将被删除，暂停签名、撤销及修改等操作');window.location.href='" + Page.Request.Url + "';");
            return;
        }

        DA_OfficeAutomation_Document_Fax_Inherit da_OfficeAutomation_Document_Fax_Inherit = new DA_OfficeAutomation_Document_Fax_Inherit();

        DataSet ds = da_OfficeAutomation_Document_Fax_Inherit.SelectByMainID(MainID);
        DataRow drRow = ds.Tables[0].Rows[0];
        ID = drRow["OfficeAutomation_Document_Fax_ID"].ToString();

        string flowIDx = "0";
        string signEmployeeName = EmployeeName;
        string signEmployeeId = EmployeeID;
        string flowID = string.Empty;
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

                        string[] auditor = drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString().Split(',');
                        string[] auditorIDs = drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Split(',');
                        string[] auditorName = drc[i]["OfficeAutomation_Flow_Employee"].ToString().Split(',');
                        flowIDx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();

                        //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                        string haveSignPowerEmployee = da_OfficeAutomation_Agent_Inherit.HaveSignPowerEmployee(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(), EmployeeName, EmployeeID);
                        if (haveSignPowerEmployee != null)
                        {
                            flowIDx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
                            signEmployeeName = haveSignPowerEmployee.Split('|')[0];
                            signEmployeeId = haveSignPowerEmployee.Split('|')[1];
                            flowID = drc[i]["OfficeAutomation_Flow_ID"].ToString();
                            break;
                        }
                    }
                }


                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();


                //是否单人审核或同时审核。
                string[] flowN;
                flowN = ViewState["FSIN"].ToString().Split(',');

                bool isSignSuccess = ((IList)flowN).Contains(flowIDx) ? da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, "1") : da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSignAndMulti(MainID, signEmployeeId, signEmployeeName, hdSuggestion.Value, flowIDx, "1");

                if (isSignSuccess)
                {
                    T_OfficeAutomation_Document_Fax_Detail t = new T_OfficeAutomation_Document_Fax_Detail();
                    t.OfficeAutomation_Document_Fax_Detail_ID = Guid.NewGuid();
                    t.OfficeAutomation_Document_Fax_Detail_Flow_ID = new Guid(flowID);
                    t.OfficeAutomation_Document_Fax_Detail_Main_ID = new Guid(ID);
                    t.OfficeAutomation_Document_Fax_Detail_CoordinateX = lastx;
                    t.OfficeAutomation_Document_Fax_Detail_CoordinateY = lasty;
                    t.OfficeAutomation_Document_Fax_Detail_AuditorID = signEmployeeId;
                    t.OfficeAutomation_Document_Fax_Detail_AuditorName = signEmployeeName;
                    DA_OfficeAutomation_Document_Fax_Detail_Inherit da_OfficeAutomation_Document_Fax_Detail_Inherit = new DA_OfficeAutomation_Document_Fax_Detail_Inherit();
                    da_OfficeAutomation_Document_Fax_Detail_Inherit.Add(t);

                    string[] employnames;
                    string email;
                    string msnBody, mailBody = "";

                    string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Fax_Apply"].ToString();
                    string employname;
                    string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
                    string department = drRow["OfficeAutomation_Document_Fax_Department"].ToString();
                    string applyUrl = Page.Request.Url.ToString();
                    applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                    applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                    //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                    //通知已审批的人员，邮件中附带申请资料。
                    StringBuilder sbMailBody = new StringBuilder();
                    sbMailBody.Append("<br/><br/>申请人：" + drRow["OfficeAutomation_Document_Fax_Apply"]);
                    sbMailBody.Append("<br/>发文部门：" + drRow["OfficeAutomation_Document_Fax_Department"]);
                    sbMailBody.Append("<br/>发文日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_Fax_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
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
                            if (EmployeeID == "0001")
                                employeeList += "黄轩明" + "||";

                            string sagree = "";
                            if (hdSuggestion.Value != "") //最后一人如有填写内容的，无论是同意，不同意，其他意见，都有邮件将审核填写的内容通知相关同事
                                sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //完成后抄送，李小清（工号：17642）、潘焕心（工号：30792）梁晶晶（工号：32188）、总经办-黄筑筠（工号：22563）  谢芃（工号：3030）
                            employname = CommonConst.EMP_GMO_NAME;
                            employnames = employname.Split(',');
                            for (int i = 0; i < employnames.Length; i++)
                            {
                                if (!employeeList.Contains(employnames[i]) && employeeList.Contains("黄轩明"))
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

                            //20160510 梁锐华签名的都给倪秀珊出提醒邮件
                            if (signEmployeeName.Contains("梁锐华"))
                            {
                                employnames = new string[] { "倪秀珊" };
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    email = employnames[i];
                                    msnBody = "您好，" + employnames[i] + "：请注意" + signEmployeeName + "有" + department + "的编号为" + serialNumber + "的" + documentName + "需要审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(false, email, "请注意" + signEmployeeName + "通过了一份电子审批需要", msnBody + mailBody, msnBody);
                                }
                            }
                            //20160510

                            //通知下一步需要审批的人员
                            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID);
                            if (!employname.Contains(EmployeeName))
                            {
                                string IsGroups = dsg.Tables[0].Rows[0]["OfficeAutomation_Main_IsGroups"].ToString();
                                if ("1".Equals(IsGroups) && "梁健菁".Equals(employname))
                                {
                                    string sAgree = hdIsAgree.Value == "1" ? "同意" : "其他意见";
                                    msnBody = "您好，梁健菁：现有一份发文部门：" + department + "的" + documentName + ",文档编号为" + serialNumber + "需报请集团审批。<br />黄生的意见是：" + sAgree + "<br />" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    string Groupsemail = "梁健菁";
                                    if (hdIsAgree.Value == "2")
                                        Common.SendMessageEX(false, Groupsemail, "其他意见", msnBody, msnBody);
                                    else
                                        Common.SendMessageEX(false, Groupsemail, "申请已同意", msnBody, msnBody);
                                }
                                else
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
    protected void btnSaveLogisticsFlow_Click(object sender, EventArgs e)
    {
    }
   
    protected void btnEditFlow_DoClick(object sender, EventArgs e)
    {
    }
    #region datagrid事件
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
    #region 私有方法
    private void Update()
    {
        T_OfficeAutomation_Document_Fax t_OfficeAutomation_Document_Fax = new T_OfficeAutomation_Document_Fax();
        DA_OfficeAutomation_Document_Fax_Inherit da_OfficeAutomation_Document_Fax_Inherit = new DA_OfficeAutomation_Document_Fax_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Fax_Inherit.SelectByMainID(MainID);
        ID = ds.Tables[0].Rows[0]["OfficeAutomation_Document_Fax_ID"].ToString();

        t_OfficeAutomation_Document_Fax = GetModelFromPage(new Guid(ID));

        string apply = EmployeeName;
        string depname = txtDepartment.Text;
        string summary = EmployeeName;
        string applydate = "";
        string mainid = MainID;

        da_OfficeAutomation_Main_Inherit.UpdateMain(mainid, depname, apply, applydate, summary);
        da_OfficeAutomation_Document_Fax_Inherit.Edit(t_OfficeAutomation_Document_Fax);//修改申请表


        DA_OfficeAutomation_Document_Fax_Detail_Flow_Inherit da_OfficeAutomation_Document_Fax_Detail_Flow_Inherit = new DA_OfficeAutomation_Document_Fax_Detail_Flow_Inherit();
        da_OfficeAutomation_Document_Fax_Detail_Flow_Inherit.DelByMainID(ID);
        InsertFaxDetailFlow(new Guid(ID));

        Common.AddLog(EmployeeID, EmployeeName, 85, new Guid(MainID), 2);//日志，修改申请表
    }
    //上传图片
    private void UploadPictrue(string Image, string sMainID)
    {
        string sSaveFileName = "";//文件保存名字
        string sFileName = "";//文件名
        string sSaveFilePath = "";//文件保存路径（含文件名）


        if (!Directory.Exists(uploadPath + DateTime.Now.Year.ToString()))
        {
            Directory.CreateDirectory(uploadPath + DateTime.Now.Year.ToString());
        }

        if (!Directory.Exists(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + MainID))
        {
            Directory.CreateDirectory(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + MainID);
        }
        sFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";//文件名
        sSaveFileName = DateTime.Now.Year.ToString() + "/" + sMainID + "/" + sFileName;//文件夹
        sSaveFilePath = uploadPath + sSaveFileName;
        try
        {
            string handleImgStr = Image;
            string extension = "";
            if (Image.Contains(","))
            {
                //data:image/png;base64,xxxxxxx;
                string[] baseHead = Image.Split(',')[0].Split('/');
                if (baseHead.Length > 1)
                {
                    extension = baseHead[1].Split(';')[0];
                }
                handleImgStr = Image.Split(',')[1];
            }


            byte[] arr = Convert.FromBase64String(handleImgStr);
            //将文件流保存成文件至服务器中
            using (FileStream myFileStream = File.Open(sSaveFilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                myFileStream.Write(arr, 0, arr.Length);
                myFileStream.Flush();
                myFileStream.Close();
            }
            DA_OfficeAutomation_Document_Image_Inherit da_OfficeAutomation_Document_Image_Inherit = new DA_OfficeAutomation_Document_Image_Inherit();
            T_OfficeAutomation_Document_Image t_OfficeAutomation_Document_Image = new T_OfficeAutomation_Document_Image();
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_MainID = new Guid(sMainID);
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_CreateTime = DateTime.Now;
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_Url = sSaveFileName;
            t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_IsDelete = "0";
            da_OfficeAutomation_Document_Image_Inherit.Add(t_OfficeAutomation_Document_Image);

            HttpContext context = null;
            context.Response.Write(sSaveFileName);
        }
        catch (Exception ex)
        {


        }

    }
    /// <summary>
    /// 新增明细表
    /// </summary>
    /// <param name="gGeneralApplyID"></param>
    private void InsertFaxDetailFlow(Guid gFaxApplyID)
    {
        if (hdDetail.Value == "")
            return;

        T_OfficeAutomation_Document_Fax_Detail_Flow t;
        DA_OfficeAutomation_Document_Fax_Detail_Flow_Inherit da_OfficeAutomation_Document_Fax_Detail_Flow_Inherit = new DA_OfficeAutomation_Document_Fax_Detail_Flow_Inherit();

        string[] details = Regex.Split(hdDetail.Value, "\\|\\|");
        for (int i = 0; i < details.Length; i++)
        {
            string[] detail = Regex.Split(details[i], "\\&\\&");
            t = new T_OfficeAutomation_Document_Fax_Detail_Flow();
            t.OfficeAutomation_Document_Fax_Detail_Flow_ID = Guid.NewGuid();
            t.OfficeAutomation_Document_Fax_Detail_Flow_MainID = gFaxApplyID;
            t.OfficeAutomation_Document_Fax_Detail_Flow_Department = detail[0];
            t.OfficeAutomation_Document_Fax_Detail_Flow_Num = int.Parse(detail[1]);
            t.OfficeAutomation_Document_Fax_Detail_Flow_Sign = int.Parse(detail[1]);//52100-2016/10/14新增
            t.OfficeAutomation_Document_Fax_Detail_Flow_Branch = detail[2];
            t.OfficeAutomation_Document_Fax_Detail_Flow_Cmodel = detail[3] == "1";
            t.OfficeAutomation_Document_Fax_Detail_Flow_IsOpen = detail[4] == "1";

            da_OfficeAutomation_Document_Fax_Detail_Flow_Inherit.Add(t);//52100-2016/10/14新增


        }
    }
    /// <summary>
    /// 页面获取值
    /// </summary>
    /// <param name="UndertakeProjID"></param>
    /// <returns></returns>
    private T_OfficeAutomation_Document_Fax GetModelFromPage(Guid UndertakeProjID)
    {
        T_OfficeAutomation_Document_Fax t = new T_OfficeAutomation_Document_Fax();
        t.OfficeAutomation_Document_Fax_ID = UndertakeProjID;
        t.OfficeAutomation_Document_Fax_MainID = new Guid(MainID);
        t.OfficeAutomation_Document_Fax_Apply = EmployeeName;
        t.OfficeAutomation_Document_Fax_ApplyDate = DateTime.Now;
        t.OfficeAutomation_Document_Fax_ApplyID = "";
        t.OfficeAutomation_Document_Fax_Department = txtDepartment.Text;

        return t;
    }
    /// <summary>
    /// 加载页面
    /// </summary>
    private void LoadPage()
    {
        IsNewApply = false;
        bool IsTempSave = false;        //是否暂存
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_Fax_Inherit da_OfficeAutomation_Document_Fax_Inherit = new DA_OfficeAutomation_Document_Fax_Inherit();
        DA_OfficeAutomation_Document_Fax_Detail_Flow_Inherit da_OfficeAutomation_Document_Fax_Detail_Flow_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Fax_Detail_Flow_Inherit();
        DA_OfficeAutomation_Document_Image_Inherit da_OfficeAutomation_Document_Image_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Image_Inherit();
        string flowState;
        try
        {
            flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
            //2016/9/9 52100
            if (flowState == "7")
            {
                IsTempSave = true;
            }
            else
            {
                // this.btnTemp.Visible = false;
            }
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
        SbJs.Append("$(\"#img_upload\").hide();");
        SbJs.Append("$(\"#trManager1\").show();");
        SbJs.Append("$(\"#trManager2\").show();");
        SbJs.Append("$(\"#trManager3\").show();");

        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Fax_Inherit.SelectByMainID(MainID);

        DataRow dr = ds.Tables[0].Rows[0];
        ID = dr["OfficeAutomation_Document_Fax_ID"].ToString();
        string applicant = dr["OfficeAutomation_Document_Fax_Apply"].ToString();
     //   ApplyN = applicant;
        txtDepartment.Text = dr["OfficeAutomation_Document_Fax_Department"].ToString();
        SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
        lblApply.Text = applicant;
        lblApplyDate.Text = DateTime.Parse(dr["OfficeAutomation_Document_Fax_ApplyDate"].ToString()).ToString("yyyy-MM-dd");
        //T_OfficeAutomation_Document_Image t_OfficeAutomation_Document_Image = da_OfficeAutomation_Document_Image_Inherit.GetModel("OfficeAutomation_Document_Image_MainID='" + MainID + "' order by OfficeAutomation_Document_Image_CreateTime desc");
        DataTable dt=  da_OfficeAutomation_Document_Image_Inherit.SearchImageDesc(MainID).Tables[0];
        if (dt.Rows.Count>0)
        {
            BigPicture = ConfigurationManager.AppSettings["EcoaFileURL"] + dt.Rows[0]["OfficeAutomation_Document_Image_Url"];
        }
        //if (t_OfficeAutomation_Document_Image != null)
        //    BigPicture = ConfigurationManager.AppSettings["EcoaFileURL"] + t_OfficeAutomation_Document_Image.OfficeAutomation_Document_Image_Url;

       

   
        #region 登录人为申请人时，上传按钮开启，如果申请表未开始审批，保存编辑按钮开启。
        SbJs.Append("$(\"#btnUpload\").show();");
        bool isApplicant = EmployeeName == applicant;
        if (isApplicant)
        {
            if (flowState == "1" || flowState == "7")
            {
                GetAllDepartment();
                btnSave.Visible = true;
                SbJs.Append("$(\"#trM0\").show();");
                SbJs.Append("$(\"#trM1\").show();");
                SbJs.Append("$(\"#div1\").show();");
                SbJs.Append("$(\"#spanUpload\").show();");
                SbJs.Append("$(\"#trManager1\").show();");
                SbJs.Append(ApplyDisplayPart);
            }
            if (flowState == "2") //20141215：M_AlterC
            {
                GetAllDepartment();
                btnSAlterC.Visible = true;
                SbJs.Append("$(\"#trM0\").show();");
                SbJs.Append("$(\"#trM1\").show();");
                SbJs.Append("$(\"#trManager1\").show();");
                SbJs.Append("$(\"#div1\").html('');");
                SbJs.Append(ApplyDisplayPart);
            }
        }
        if (!isApplicant || flowState == "3") //M_New：新功能，完成或其它人打开时可显示横向滚动条 20150603 
        {

            //ckeDescribe.Visible = false;
            //editor_id.Visible = false;
            //SbJs.Append("$(\"#editor_id\").hide();");
            SbJs.Append("$(\"#ibta\").hide();");
            //SbJs.Append("$(\"#div1\").hide();");
            SbJs.Append("$(\"#div1\").html('');");
        }

        if (!isApplicant)
        {
            #region 只有申请人才可见查阅人
            SbJs.Append("$(\"#trcansee\").hide();");
            #endregion
        }

      

        try //M_AddAnother：20150716 黄生其它意见，增加审批人
        {
            //DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
            //DataSet dsFlow2 = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);
            //DataRowCollection drcz = dsFlow2.Tables[0].Rows;
            //T_OfficeAutomation_Flow flowsa, flowst, fst3; fst3 = da_OfficeAutomation_Flow_Inheritz.SelectByMainIDAndIdx(MainID, 3);



        }
        catch
        {
        }

        #endregion

        #endregion

        //#region 登录人为特定的帐号，且流程为完成状态时，标识留档按钮开启。
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);

        //#endregion

        try
        {
            if (ViewState["FLG_ReWrite"].ToString() == "1")
            {

                DrawDetailTable(0);
                SbJs.Append(ApplyDisplayPart);
                SbJs.Append("$(\"#btnUpload\").hide();$(\"#btnPrint\").hide();");
                SbJs.Append("$(\"#trM0\").show();");
                SbJs.Append("$(\"#trM1\").show();");
                SbJs.Append("$(\"#trManager1\").hide();");
                SbJs.Append("$(\"#trManager2\").hide();");
                SbJs.Append("$(\"#trManager3\").hide();");
                SbJs.Append("</script>");
                GetAllDepartment();
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

        #region 加载自定义流程，隐藏及显示签名按钮，及签名

        //20160619 是否允许不同意，允许在input中插入allow=sayno的属性，MasterPage js中控制
        #region 是否允许不同意
        string saynostr = da_OfficeAutomation_Flow_Inherit.CanSayNo(MainID);
        SbJs.Append(saynostr);
        #endregion



        ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
        DataRowCollection drc = ds.Tables[0].Rows;
        bool flag = true;//当为true时表示，该项之前都审核通过或未开始审核的
        bool flag2 = true;//当为true时表示，当前轮到此环节进行审批
        //bool flag3 = false;//是否有后勤事务部，董事总经理环节

        if (Purview.Contains("OA_Search_002"))//789
            GetAllDepartment();

        foreach (DataRow drs in drc)
        {
            string idx = drs["OfficeAutomation_Flow_Idx"].ToString();
            if (!Regex.IsMatch(((float.Parse(idx) - 1) / 3.0).ToString(), "^[0-9]*[1-9][0-9]*$"))
                SbJs.Append("$('#divIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();$('#divTxtIDx" + drs["OfficeAutomation_Flow_Idx"] + "').toggle();");
            SbJs.Append("$('#txtIDxa" + drs["OfficeAutomation_Flow_Idx"] + "').val('" + drs["OfficeAutomation_Flow_Employee"] + ",');");
        }
        DataSet ds2 = new DataSet();
        bool x2 = false, x3 = false;
        ds2 = da_OfficeAutomation_Document_Fax_Detail_Flow_Inherit.SelectByID(ID);
        int detailCount = ds2.Tables[0].Rows.Count;
        ViewState["FSIN"] = "";
        if (detailCount == 0)
        {
            if (isApplicant)
                DrawDetailTable(0);
            SbJs.Append("$('#tho').hide();");
        }
        else
        {
            if (isApplicant)
                DrawDetailTable(detailCount / 3);
            for (int n = 0, i = 1; n < detailCount; n++, i++)
            {
                int fon = 0, y2 = 0, y3 = 0;
                dr = ds2.Tables[0].Rows[n];
                SbJs.Append("$('#txtDpm" + i + "').val('" + dr["OfficeAutomation_Document_Fax_Detail_Flow_Department"] + "');");
                SbJs.Append("$('#rdoIsCmodel" + i + "1" + (dr["OfficeAutomation_Document_Fax_Detail_Flow_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_Fax_Detail_Flow_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_Fax_Detail_Flow_Num"].ToString() + ",";
                fon = int.Parse(dr["OfficeAutomation_Document_Fax_Detail_Flow_Num"].ToString());
                n++;
                dr = ds2.Tables[0].Rows[n];
                x2 = dr["OfficeAutomation_Document_Fax_Detail_Flow_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + i + "2" + (dr["OfficeAutomation_Document_Fax_Detail_Flow_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_Fax_Detail_Flow_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_Fax_Detail_Flow_Num"].ToString() + ",";
                y2 = int.Parse(dr["OfficeAutomation_Document_Fax_Detail_Flow_Num"].ToString());
                n++;
                dr = ds2.Tables[0].Rows[n];
                x3 = dr["OfficeAutomation_Document_Fax_Detail_Flow_IsOpen"].ToString() == "True";
                SbJs.Append("$('#rdoIsCmodel" + i + "3" + (dr["OfficeAutomation_Document_Fax_Detail_Flow_Cmodel"].ToString() == "True" ? "1" : "0") + "').attr('checked','checked');");
                if (dr["OfficeAutomation_Document_Fax_Detail_Flow_Cmodel"].ToString() == "False")
                    ViewState["FSIN"] += dr["OfficeAutomation_Document_Fax_Detail_Flow_Num"].ToString() + ",";
                y3 = int.Parse(dr["OfficeAutomation_Document_Fax_Detail_Flow_Num"].ToString());
                DrawAFTable(fon, x2, x3, dr["OfficeAutomation_Document_Fax_Detail_Flow_Department"].ToString(), y2, y3);
            }
        }

        SbFlow.Append("<div class=\"flow\">");
        if (!IsTempSave) { SbFlow.Append("审批流程:"); }

        for (int i = 0; i < drc.Count; i++)
        {
            #region 显示流程示意图
            int idx = int.Parse(drc[i]["OfficeAutomation_Flow_IDx"].ToString());
            string curidx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
            string curemp = drc[i]["OfficeAutomation_Flow_Employee"].ToString();

            if (curemp.Contains(EmployeeName))
            {
                SbJs.Append("$(\"#btnUpload\").show();");
           
            }
            SbFlow.Append("<span class=\"");
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False" && flag2)//正待审理
            {
                SbFlow.Append("auditing\">待" + curemp + "审理");
                flag2 = false;

                if ((curemp.Contains("宁伟雄") || curemp.Contains("黄志超")) && !drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Contains(EmployeeID))
                {
                    SbJs.Append("$(\"[id*=lbtnAddN]\").show();$(\"[id*=lbtnDelN]\").show();");
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
            //签名列表
            var flowsignlist = da_OfficeAutomation_Flow_Inherit.GetFlowsSignList(dsFlow, EmployeeID, EmployeeName);
            if (flowsignlist != null)
            {
                this.hidSignFlowsJson.Value = Newtonsoft.Json.JsonConvert.SerializeObject(flowsignlist);
            }

            DA_OfficeAutomation_Document_Fax_Detail_Inherit da_OfficeAutomation_Document_Fax_Detail_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Fax_Detail_Inherit();
            var AuditJpg = da_OfficeAutomation_Document_Fax_Detail_Inherit.GetFaxFlowsSign(MainID, EmployeeID, EmployeeName);
            EmpID = EmployeeID;
            if (AuditJpg != null)
            {
                this.hiAuditJpg.Value = Newtonsoft.Json.JsonConvert.SerializeObject(AuditJpg);
            }
            var SignLeftTopList = da_OfficeAutomation_Document_Fax_Detail_Inherit.GetFaxFlowsSignLeftTopList(MainID);
            if (SignLeftTopList != null)
            {
                this.hiSignLeftTopListJson.Value = Newtonsoft.Json.JsonConvert.SerializeObject(SignLeftTopList);
            }
            #region 审核
            string[] auditorIDs = drc[i]["OfficeAutomation_Flow_AuditorID"].ToString().Split(',');
            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
            if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "True")
            {
                SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 20px; height: 2px; margin-left:0px;\">"
                    + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                foreach (string s in auditorIDs)
                {
                    if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                    {
                        SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                    }
                    SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" style=\"margin-left:10px;margin-top:10px;\" />");
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
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').before('<div style=\"width: 150px; line-height: 20px; height: 2px; margin-left:20px;\">"
                                        + drc[i]["OfficeAutomation_Flow_Auditor"] + "</div>");
                    foreach (string s in auditorIDs)
                    {
                        if (da_OfficeAutomation_Agent_Inherit.IsHaveCancelPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), s,
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID)) //20141202：CancelSign
                        {
                            SbJs.Append("<input type=\"button\" value=\"撤消\" onclick=\"CancelSign(" + drc[i]["OfficeAutomation_Flow_IDx"] + ")\" id=\"btnCancelSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "\"/>");
                        }
                        SbJs.Append("<img src=\"" + SignImageURL + GetGIF(s) + ".gif\" height=\"60px\" style=\"margin-left:10px;margin-top:10px;\" />");
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

                    if (string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()))
                    {

                    }
                    else
                    {
                        SbJs.Append("$('#spanDateIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + DateTime.Parse(drc[i]["OfficeAutomation_Flow_AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "');");
                    }

                }

                if (!string.IsNullOrEmpty(drc[i]["OfficeAutomation_Flow_Suggestion"].ToString()))
                    SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");

                //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                if (flag && da_OfficeAutomation_Agent_Inherit.IsHaveSignPower(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(),
                    drc[i]["OfficeAutomation_Flow_Auditor"].ToString(), drc[i]["OfficeAutomation_Flow_AuditorID"].ToString(), EmployeeName, EmployeeID))
                {
                    SbJs.Append("$('#btnSignIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').show();");

                }

                flag = false;
            }
            #endregion

            if (drc[i]["OfficeAutomation_Flow_Suggestion"].ToString() != "") //M_Suggestion：20150205
                SbJs.Append("$('#txtIDx" + drc[i]["OfficeAutomation_Flow_IDx"] + "').text('" + drc[i]["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r", "\\r").Replace("\n", "\\n") + "');");



            #endregion
        }
        SbFlow.Append("</div>");

        ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID); //20141231：M_DeleteC
        if (ds.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
        {

            ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlowsByMID(MainID);
            SbJs.Append("$('#btnADelete').before('<div id=\"SummaryOfDelete_Red\" style=\"color: red; font-size: large; font-weight: bold\">（该表即将被删除）</div>');$('h1').css('color','red');$('h1').attr('name','DeleteD');");
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
        //autoTextarea(document.getElementById(\"txtIDx2\"));autoTextarea(document.getElementById(\"txtIDx3\"));
        SbJs.Append("$.each($(\"textarea:not([id*=txtDescribe])\"), function (idx, item) { autoTextarea(this); });");
        SbJs.Append("</script>");

        LoadAttach();
    }
    private void DrawAFTable(int n, bool x2, bool x3, string department, int y2, int y3)
    {
        //string apd = "";
        //if (EmployeeID == "13545")
        //    apd = "宁伟雄";
        //else if (EmployeeID == "5585")
        //    apd = "黄志超";
        for (int i = 1; i <= 1; i++)
        {
            int j = 0, k = n;
            if (x2 && x3)
                j = 3;
            else if ((!x2 && x3) || (x2 && !x3))
                j = 2;
            else if (!x2 && !x3)
                j = 1;
            SbHtml2.Append("<tr class=\"noborder\" style=\"height: 85px;\">");


            if (JumpOrNot(department))
                SbHtml2.Append("<td rowspan=\"" + j + "\"  class=\"auto-style2\">" + department + "<br /><input type=\"button\" value=\"跳过\" onclick=\"ShouldJump('" + department + "')\" id=\"btnShouldJumpIDx" + n + "\"/></td>");
            else
                SbHtml2.Append("<td rowspan=\"" + j + "\"  class=\"auto-style2\">" + department + "</td>");

            SbHtml2.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
            SbHtml2.Append("	<input id=\"rdbYesIDx" + k + "\" type=\"radio\" name=\"agree" + k + "\" />");
            SbHtml2.Append("    <label for=\"rdbYesIDx" + k + "\">同意</label>");
            SbHtml2.Append("    <input id=\"rdbNoIDx" + k + "\" type=\"radio\" name=\"agree" + k + "\" />");
            SbHtml2.Append("    <label for=\"rdbNoIDx" + k + "\">不同意</label>");
            SbHtml2.Append("    <input id=\"rdbOtherIDx" + k + "\" type=\"radio\" name=\"agree" + k + "\" />");
            SbHtml2.Append("    <label for=\"rdbOtherIDx" + k + "\">其他意见</label>");
            SbHtml2.Append("     <div class=\"fieldsign\"></div>");
          //  if (department.Contains("财务") && (EmployeeID == "5585" || EmployeeID == "13545")) //M_AddNWX：20150511 
        //        SbHtml2.Append("　<a id=\"lbtnAddN" + k + "\" href=\"javascript:void(0)\" style=\"display: none;\" onclick=\"AddNWX()\">添加" + apd + "审批</a>　<a id=\"lbtnDelN" + k + "\" href=\"javascript:void(0)\" style=\"display: none;\" onclick=\"DelNWX()\">取消" + apd + "审批</a>");
            SbHtml2.Append("	<textarea id=\"txtIDx" + k + "\" rows=\"5\" style=\"width: 98%; overflow: auto;\"></textarea>");
            SbHtml2.Append("    <input type=\"button\" id=\"btnSignIDx" + k + "\" value=\"签署意见\" onclick=\"sign(\'" + k + "\')\" style=\"display: none;\" />");
            SbHtml2.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + k + "\">_________</span></div>");
            SbHtml2.Append("</td>");
            SbHtml2.Append("</tr>");
          
            if (x2)
            {
                SbHtml2.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtml2.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtml2.Append("	<input id=\"rdbYesIDx" + y2 + "\" type=\"radio\" name=\"agree" + y2 + "\" />");
                SbHtml2.Append("    <label for=\"rdbYesIDx" + y2 + "\">同意</label>");
                SbHtml2.Append("    <input id=\"rdbNoIDx" + y2 + "\" type=\"radio\" name=\"agree" + y2 + "\" />");
                SbHtml2.Append("    <label for=\"rdbNoIDx" + y2 + "\">不同意</label>");
                SbHtml2.Append("    <input id=\"rdbOtherIDx" + y2 + "\" type=\"radio\" name=\"agree" + y2 + "\" />");
                SbHtml2.Append("    <label for=\"rdbOtherIDx" + y2 + "\">其他意见</label>");
                SbHtml2.Append("	<textarea id=\"txtIDx" + y2 + "\" rows=\"5\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtml2.Append("    <input type=\"button\" id=\"btnSignIDx" + y2 + "\" value=\"签署意见\" onclick=\"sign(\'" + y2 + "\')\" style=\"display: none;\" />");
                SbHtml2.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + y2 + "\">_________</span></div>");
                SbHtml2.Append("</td>");
                SbHtml2.Append("</tr>");
            }
            if (x3)
            {
                SbHtml2.Append("<tr class=\"noborder\" style=\"height: 85px;\">");
                SbHtml2.Append("<td colspan=\"3\" class=\"tl PL10\" style=\" \">");
                SbHtml2.Append("	<input id=\"rdbYesIDx" + y3 + "\" type=\"radio\" name=\"agree" + y3 + "\" />");
                SbHtml2.Append("    <label for=\"rdbYesIDx" + y3 + "\">同意</label>");
                SbHtml2.Append("    <input id=\"rdbNoIDx" + y3 + "\" type=\"radio\" name=\"agree" + y3 + "\" />");
                SbHtml2.Append("    <label for=\"rdbNoIDx" + y3 + "\">不同意</label>");
                SbHtml2.Append("    <input id=\"rdbOtherIDx" + y3 + "\" type=\"radio\" name=\"agree" + y3 + "\" />");
                SbHtml2.Append("    <label for=\"rdbOtherIDx" + y3 + "\">其他意见</label>");
               
                SbHtml2.Append("	<textarea id=\"txtIDx" + y3 + "\" rows=\"5\" style=\"width: 98%; overflow: auto;\"></textarea>");
                SbHtml2.Append("    <input type=\"button\" id=\"btnSignIDx" + y3 + "\" value=\"签署意见\" onclick=\"sign(\'" + y3 + "\')\" style=\"display: none;\" />");
                SbHtml2.Append("    <div class=\"signdate\">日期：<span id=\"spanDateIDx" + y3 + "\">_________</span></div>");
                SbHtml2.Append("</td>");
                SbHtml2.Append("</tr>");
               
            }
        }
        SbJs.Append("i=" + n + ";"); 
    }
    private bool JumpOrNot(string dp)
    {
        try
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            if (dp == "行政部" && EmployeeName == "沈凯飞" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if (dp == "法律部" && EmployeeName == "陈洁丽" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if (dp == "外联部" && EmployeeName == "潘海燕" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if (dp == "营运支持" && EmployeeName == "陈晓青A" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if ((dp == "资讯科技部" || dp == "IT部") && EmployeeName == "何智峰" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if ((dp == "人力资源部" || dp == "HR") && EmployeeName == "郑纯宁" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if ((dp == "财务部" || dp == "财务") && EmployeeName == "黄洁珍" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else if (dp == "市场部" && EmployeeName == "李粤湘" && da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(MainID).Contains(EmployeeName))
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
    }
    private void DrawDetailTable(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            SbHtml.Append("<tr id=\"trDetail" + i + "\" class=\"noborder\" style=\"height: 85px;\">");
            SbHtml.Append("<td style=\"text-align: left; padding-left: 10px;\" colspan=\"4\">");
            SbHtml.Append("<div class=\"flow\">");
            SbHtml.Append("部门名称：<input type=\"text\" id=\"txtDpm" + i + "\" style=\"margin-bottom: 10px;width:250px;\" /><br/>");
            SbHtml.Append("<div id=\"divIDx" + (3 * i + 1) + "\" class=\"item2\">环节1</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (3 * i + 1) + "\" class=\"item2\">");
            SbHtml.Append("   <input type=\"text\" id=\"txtIDxa" + (3 * i + 1) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (3 * i + 1) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + i + "11\" checked=\"checked\" name=\"IsCmodel" + i + "1\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + i + "11\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + i + "10\" name=\"IsCmodel" + i + "1\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + i + "10\">单人审批</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (3 * i + 2) + "\" class=\"item2\"><input id=\"btnIDx" + i + "2\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (3 * i + 2) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + i + "2\" for=\"btnIDx" + i + "2\">环节2</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (3 * i + 2) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节2&nbsp;<input type=\"text\" id=\"txtIDxa" + (3 * i + 2) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (3 * i + 2) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + i + "21\" checked=\"checked\" name=\"IsCmodel" + i + "2\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + i + "21\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + i + "20\" name=\"IsCmodel" + i + "2\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + i + "20\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (3 * i + 2) + ")\">取消</a>");
            SbHtml.Append("</div>");
            SbHtml.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
            SbHtml.Append("<div id=\"divIDx" + (3 * i + 3) + "\" class=\"item2\"><input id=\"btnIDx" + i + "3\" class=\"forward\" type=\"image\" src=\"/Images/add.png\" onclick=\"return showOrHideIDx(" + (3 * i + 3) + ");\" />");
            SbHtml.Append("   <label id=\"lblIDx" + i + "3\" for=\"btnIDx" + i + "3\">环节3</label>");
            SbHtml.Append("</div>");
            SbHtml.Append("<div id=\"divTxtIDx" + (3 * i + 3) + "\" class=\"item2\" style=\"display:none;\">");
            SbHtml.Append("   <br/>&nbsp;环节3&nbsp;<input type=\"text\" id=\"txtIDxa" + (3 * i + 3) + "\" style=\"width:190px;\" /><input id=\"hdIDx" + (3 * i + 3) + "\" type=\"hidden\" />");
            SbHtml.Append("   <input type=\"radio\" id=\"rdoIsCmodel" + i + "31\" checked=\"checked\" name=\"IsCmodel" + i + "3\" /><label style=\"color: #0d9405\" for=\"rdoIsCmodel" + i + "31\">多人审批</label><input type=\"radio\" id=\"rdoIsCmodel" + i + "30\" name=\"IsCmodel" + i + "3\" /><label style=\"color: #186ebe\" for=\"rdoIsCmodel" + i + "30\">单人审批</label>");
            SbHtml.Append("       <a style=\"color: #FF0000\" href=\"javascript:;\" onclick=\"showOrHideIDx(" + (3 * i + 3) + ")\">取消</a>");
            SbHtml.Append("</div></div>");
            SbHtml.Append("</td>");
            SbHtml.Append("</tr>");
        }
        SbJs.Append("i=" + n + ";");
    }

    /// <summary>
    /// 新页面
    /// </summary>
    private void NewPage(string sMainID)
    {
        GetAllDepartment();
        btnSPDF.Visible = false; //M_PDF
        btnSave.Visible = true;
        lblApply.Text = EmployeeName;
        lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        SbJs.Append("<script type=\"text/javascript\">" + ApplyDisplayPart);
        DrawDetailTable(0);
        SbJs.Append("$(\"#spanUpload\").show();");
        SbJs.Append("$(\"#trM0\").show();");
        SbJs.Append("$(\"#trM1\").show();");
        SbJs.Append("$(\"#txtIDxa1\").val(\'" + EmployeeName + "\')");

        SbJs.Append("</script>");
        IsNewApply = true;
        if (!string.IsNullOrEmpty(sMainID))
        {
            MainID = sMainID;
        }
        else
        {
            MainID = Guid.NewGuid().ToString();
        }
      
        
    }
    /// <summary>
    /// 获取所有四级以上前线经理
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

}
public enum Definition
{
    One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10
}
public class PDFTranImgHelp
{
    /// <summary>
    /// 将PDF文档转换为图片的方法
    /// </summary>
    /// <param name="pdfInputPath">PDF文件路径</param>
    /// <param name="imageOutputPath">图片输出路径</param>
    /// <param name="imageName">生成图片的名字</param>
    /// <param name="startPageNum">从PDF文档的第几页开始转换</param>
    /// <param name="endPageNum">从PDF文档的第几页开始停止转换</param>
    /// <param name="imageFormat">设置所需图片格式</param>
    /// <param name="definition">设置图片的清晰度，数字越大越清晰</param>
    public static void ConvertPDF2Image(string pdfInputPath, string imageOutputPath,
        int startPageNum, int endPageNum, ImageFormat imageFormat, Definition definition)
    {
        PDFFile pdfFile = PDFFile.Open(pdfInputPath);
        //if (!Directory.Exists(imageOutputPath))
        //{
        //    Directory.CreateDirectory(imageOutputPath);
        //}
        // validate pageNum
        if (startPageNum <= 0)
        {
            startPageNum = 1;
        }
        if (endPageNum > pdfFile.PageCount)
        {
            endPageNum = pdfFile.PageCount;
        }
        if (startPageNum > endPageNum)
        {
            int tempPageNum = startPageNum;
            startPageNum = endPageNum;
            endPageNum = startPageNum;
        }
        // start to convert each page
        for (int i = startPageNum; i <= endPageNum; i++)
        {
            Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);
            //pageImage.Save(imageOutputPath + imageName + i.ToString() + "." + imageFormat.ToString(), imageFormat);
            pageImage.Save(imageOutputPath, imageFormat);
            pageImage.Dispose();
        }
        pdfFile.Dispose();
    }
}