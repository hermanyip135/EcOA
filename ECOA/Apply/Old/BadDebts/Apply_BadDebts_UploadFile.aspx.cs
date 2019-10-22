using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using DataAccess.Operate;
using DataEntity;
using System.Data;

public partial class Apply_BadDebts_Apply_BadDebts_UploadFile : BasePage
{
    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    #endregion

    #region 上传

    /// <summary>
    /// 上传按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        DataAccess.Operate.DA_OfficeAutomation_Attach_Inherit da_OfficeAutomation_Attach_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Attach_Inherit();
        DataEntity.T_OfficeAutomation_Attach t_OfficeAutomation_Attach = new DataEntity.T_OfficeAutomation_Attach();

        string sFilePath = "";
        string sFileName = "";
        string mainid = Request.QueryString["MainID"];

        //string uploadPath = Page.Request.PhysicalApplicationPath + "Maintain\\UploadFile\\";
        string uploadPath = System.Configuration.ConfigurationManager.AppSettings["UploadPath"].Replace("\\", "\\\\");

        if (!Directory.Exists(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + mainid))
        {
            Directory.CreateDirectory(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + mainid);
        }

        string tempName = this.txtFilePath.Value.Substring(this.txtFilePath.Value.LastIndexOf('\\') + 1);
        string bk = tempName.Substring(tempName.IndexOf('.'));
        tempName = tempName.Substring(0, tempName.IndexOf('.'));
        tempName = DateTime.Now.Year.ToString() + "/" + mainid + "/" + tempName + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/vnd.ms-excel")
        { sFileName = tempName + ".xls"; }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        { sFileName = tempName + ".xlsx"; }
        else if (bk == ".xls" || bk == ".xlsx")
        { sFileName = tempName + bk; }

        if (sFileName == "")
        {
            Alert("上传的文件格式错误，应为xls或xlsx格式，请重新选择！");
            return;
        }

        if (this.txtFilePath.PostedFile.ContentLength > 2097152)
        {
            Alert("上传的文件大小超过2M,请重新上传！");
            return;
        }
        sFileName = sFileName.Replace("+", "_和_");
        sFilePath = uploadPath + sFileName;
        
        try
        {
            this.txtFilePath.PostedFile.SaveAs(sFilePath);

            string addn = ""; //M_AlterM：20150820
            T_OfficeAutomation_Flow flowst;
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            flowst = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndEID(mainid, "0001");
            try
            {
                if (flowst.OfficeAutomation_Flow_IsAgree == 2)
                    addn = "【补充资料】";
            }
            catch
            {
            }

            t_OfficeAutomation_Attach.OfficeAutomation_Attach_MainID = new Guid(mainid);
            t_OfficeAutomation_Attach.OfficeAutomation_Attach_Name = addn+"（" + DateTime.Now.ToString("yyMMdd") + UnitName + " - " + EmployeeName + "上传）" + this.txtFilePath.Value.Substring(this.txtFilePath.Value.LastIndexOf('\\') + 1);
            t_OfficeAutomation_Attach.OfficeAutomation_Attach_Path = sFileName;
            if(da_OfficeAutomation_Attach_Inherit.Insert(t_OfficeAutomation_Attach))
            {
                try
                {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(mainid);

                    string aun = Request.QueryString["AUpload"].ToString();

                    if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        if (!string.IsNullOrEmpty(aun))
                        {
                            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                            string employname, email, mailBody = "", employeeList = "";
                            string serialNumber = dsg.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();

                            DataSet ds = new DataSet();
                            string[] employnames;
                            ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(mainid);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                employname = dr["OfficeAutomation_Flow_Employee"].ToString();
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    if (!employeeList.Contains(employnames[i]) && dr["OfficeAutomation_Flow_IsAgree"].ToString() == "0")
                                    {
                                        mailBody = "您好" + employnames[i] + "，" + EmployeeName + "在" + documentName + "中添加了附件：" + this.txtFilePath.Value.Substring(this.txtFilePath.Value.LastIndexOf('\\') + 1)
                                            + "<br />文档编码为：" + serialNumber + "<br />申请表地址：" + Request.QueryString["href"].ToString() + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        email = employnames[i];
                                        Common.SendMessageEX(false, email, "关于" + documentName + "的补充附件说明", mailBody, mailBody);
                                    }
                                    //employeeList += employnames[i] + "||";
                                }
                            }
                            //mailBody = "您好" + aun + "，" + EmployeeName + "在" + documentName + "中添加了附件：" + this.txtFilePath.Value.Substring(this.txtFilePath.Value.LastIndexOf('\\') + 1)
                            //    + "<br />文档编码为：" + serialNumber + "<br />申请表地址：" + Request.QueryString["href"].ToString() + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            //Common.SendMessageEX(false, aun, "关于" + documentName + "的补充附件说明。", mailBody, mailBody);
                        }
                    }
                }
                catch
                {
                }

                Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(mainid), 7);
                Confirm("文件上传成功,点击‘确定’关闭对话框，系统将自动加载数据", "window.returnValue='"+sFilePath+"';window.close();", "");
            }
        }
        catch
        {
            Alert("文件上传失败！");
        }

        //hFilePath.Value = sFilePath;
    }

    #endregion
}
