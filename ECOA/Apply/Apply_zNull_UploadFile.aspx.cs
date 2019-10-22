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

public partial class Apply_zNull_Apply_zNull_UploadFile : BasePage
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
        string sPdfFilePath = "";
        string sFileName = "";
        string sPdfFileName = "";
        string mainid = Request.QueryString["MainID"];

        //string uploadPath = Page.Request.PhysicalApplicationPath + "Maintain\\UploadFile\\";
        string uploadPath = System.Configuration.ConfigurationManager.AppSettings["UploadPath"].Replace("\\", "\\\\");
        string uploadPDFPath = System.Configuration.ConfigurationManager.AppSettings["UploadPDFPath"].Replace("\\", "\\\\");

        if (!Directory.Exists(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + mainid))
        {
            Directory.CreateDirectory(uploadPath + DateTime.Now.Year.ToString() + "\\\\" + mainid);
        }
        if (!Directory.Exists(uploadPDFPath + DateTime.Now.Year.ToString() + "\\\\" + mainid))
        {
            Directory.CreateDirectory(uploadPDFPath + DateTime.Now.Year.ToString() + "\\\\" + mainid);
        }

        string tempName = this.txtFilePath.Value.Substring(this.txtFilePath.Value.LastIndexOf('\\') + 1);
        string bk = tempName.Substring(tempName.IndexOf('.'));
        tempName = tempName.Substring(0, tempName.IndexOf('.'));
        tempName = DateTime.Now.Year.ToString() + "/" + mainid + "/" + tempName + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/vnd.ms-excel")
        { 
            sFileName = tempName + ".xls";
            sPdfFileName = tempName + ".pdf";
        }
        else if (this.txtFilePath.PostedFile.ContentType.ToString() == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        { 
            sFileName = tempName + ".xlsx";
            sPdfFileName = tempName + ".pdf";
        }
        else if (bk == ".xls" || bk == ".xlsx")
        { 
            sFileName = tempName + bk;
            sPdfFileName = tempName + ".pdf";
        }

        if (sFileName == "")
        {
            Alert("上传的文件格式错误，应为xls或xlsx格式，请重新选择！");
            return;
        }

        if (this.txtFilePath.PostedFile.ContentLength > 10485760)
        {
            Alert("上传的文件大小超过10M,请重新上传！");
            return;
        }
        sFileName = sFileName.Replace("+", "_和_");
        sFilePath = uploadPath + sFileName;

        bool CopyFile = false;          //是否复制文件
        if (!string.IsNullOrEmpty(sPdfFileName))
        {
            sPdfFileName = sPdfFileName.Replace("+", "_和_");
            sPdfFilePath = uploadPDFPath + sPdfFileName;
        }
        else
        {
            sPdfFileName = sFileName;
            CopyFile = true;
            sPdfFilePath = uploadPDFPath + sFileName;
        }

        try
        {
            this.txtFilePath.PostedFile.SaveAs(sFilePath);

            if (CopyFile)
            {
                //copy file
                File.Copy(sFilePath, sPdfFilePath);
            }
            else
            {
                //无需copy file的话 转pdf格式
                var pdfhelper = new ECOA.Common.PDFHelper();
                if (bk == ".xls" || bk == ".xlsx")
                {
                    pdfhelper.ExcelToPDF(sFilePath, sPdfFilePath);
                }
                else if (bk == ".doc" || bk == ".docx")
                {
                    pdfhelper.WordToPDF(sFilePath, sPdfFilePath);
                }
            }

            t_OfficeAutomation_Attach.OfficeAutomation_Attach_MainID = new Guid(mainid);
            t_OfficeAutomation_Attach.OfficeAutomation_Attach_Name = "SpecialUplX" +  "（" + DateTime.Now.ToString("yyMMdd") + UnitName + " - " + EmployeeName + "上传）" + this.txtFilePath.Value.Substring(this.txtFilePath.Value.LastIndexOf('\\') + 1);
            t_OfficeAutomation_Attach.OfficeAutomation_Attach_Path = sFileName;

            //2016-04-15 插入MCOA附件
            //var mcoaAttachBll = new DA_OfficeAutomation_MCOA_Attach_Operate();
            //var Attach = new T_OfficeAutomation_MCOA_Attach();
            //Attach.OfficeAutomation_MCOA_Attach_ID = Guid.NewGuid();
            //Attach.OfficeAutomation_MCOA_Attach_MainID = new Guid(mainid);
            //Attach.OfficeAutomation_MCOA_Attach_Name = "SpecialUplX" + "（" + DateTime.Now.ToString("yyMMdd") + UnitName + " - " + EmployeeName + "上传）" + this.txtFilePath.Value.Substring(this.txtFilePath.Value.LastIndexOf('\\') + 1);
            //Attach.OfficeAutomation_MCOA_Attach_Path = sPdfFileName;
            //2016-04-15 插入MCOA附件 end

            if (da_OfficeAutomation_Attach_Inherit.Insert(t_OfficeAutomation_Attach))
            {
                try
                {
                    //mcoaAttachBll.Add(Attach);  //2016-04-15 插入MCOA附件

                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(mainid);
                }
                catch
                {
                }

                Common.AddLog(EmployeeID, EmployeeName, 4, new Guid(mainid), 7);
                Confirm("数据导入成功,点击‘确定’关闭对话框，然后编辑前线的审批流程。", "window.returnValue='" + sFilePath + "';window.close();", "");
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
