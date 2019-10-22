using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Operate;
using DataEntity;
using System.Data;
using System.IO;


using System.Data.SqlClient;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.txtMessage.Text = "";
        //if (Request.QueryString["test"] == "test")
        //{
        //    hh h = new hh();
        //    h.TypeContent.Add(new test
        //    {
        //        TypeContent_ID = "3",
        //        TypeContent_Name = "123"
        //    });
        //    var json = Newtonsoft.Json.JsonConvert.SerializeObject(h);
        //    Response.Write(json);

        //}
    }

    //protected void Update()
    //{
    //    //var basepath1 = @"D:\mywork\ECOA_NEW\ECOA\Temp\伊登软件报价单-广东中原地产代理有限公司20160530-20160530142716.xlsx";
    //    //var outpath1 = @"D:\mywork\ECOA_NEW\ECOA\Temp\伊登软件报价单-广东中原地产代理有限公司20160530-20160530142716.pdf";
    //    //var pdfhelper1 = new ECOA.Common.PDFHelper();
    //    //pdfhelper1.ExcelToPDF(basepath1, outpath1);
    //    //return;
    //    var attachbll = new DA_OfficeAutomation_Attach_Inherit();
    //    var mcoa_attachbll = new DA_OfficeAutomation_MCOA_Attach_Operate();

    //    //var ds = attachbll.GetAttachByMainID(this.txtMainID.Text);
    //    var ds = attachbll.GetAttachByDate(DateTime.Parse("2016-4-1"));

    //    var basepath = @"\\gzs-systemdb02\ECOA\";
    //    var outpath = @"\\gzs-systemdb02\ECOA\PDF\";

    //    if (ds != null && ds.Tables[0].Rows.Count > 0)
    //    {
    //        var path = "";
    //        var hz = "";
    //        var newfilename = "";

    //        var inputpath = "";
    //        var outputpath = "";
    //        var pdfhelper = new ECOA.Common.PDFHelper();
    //        var outdict = "";
    //        int a=ds.Tables[0].Rows.Count;
    //        foreach (DataRow dr in ds.Tables[0].Rows)
    //        {
    //            try
    //            {
    //                var IsZH = true;               //是否转换格式、copy
    //                path = dr["OfficeAutomation_Attach_Path"].ToString();       //数据库文件路径
    //                hz = path.Substring(path.LastIndexOf("."));                 //后缀名
    //                if (hz == ".xls" || hz == ".xlsx" || hz == ".doc" || hz == ".docx")
    //                {
    //                    newfilename = path.Substring(0, path.LastIndexOf(".") + 1);    //去后缀
    //                    newfilename = newfilename + "pdf";                         //+新后缀
    //                }
    //                else
    //                {
    //                    newfilename = path;
    //                }
    //                outputpath = outpath + newfilename.Replace("/", "\\");
    //                inputpath = basepath + path.Replace("/", "\\");

    //                if (!File.Exists(inputpath))
    //                {
    //                    //原文件不存在
    //                    IsZH = false;
    //                }

    //                outdict = newfilename.Substring(0, newfilename.LastIndexOf("/") + 1);
    //                outdict = outpath + outdict;
    //                if (!Directory.Exists(outdict))
    //                {
    //                    Directory.CreateDirectory(outdict);
    //                }

    //                if (IsZH)
    //                {
    //                    if (hz == ".xls" || hz == ".xlsx")
    //                    {
    //                        //excel转换
    //                        pdfhelper.ExcelToPDF(inputpath, outputpath);
    //                        //this.txtMessage.Text += "excel转换\r\n";
    //                    }
    //                    else if (hz == ".doc" || hz == ".docx")
    //                    {
    //                        //word转换
    //                        pdfhelper.WordToPDF(inputpath, outputpath);
    //                        //this.txtMessage.Text += "word转换\r\n";
    //                    }
    //                    else
    //                    {
    //                        //拷贝
    //                        outputpath = inputpath.Replace(basepath, outpath);
    //                        File.Copy(inputpath, outputpath);
    //                        //this.txtMessage.Text += "拷贝\r\n";
    //                    }
    //                }
    //                //var mcoa_attach = new T_OfficeAutomation_MCOA_Attach();
    //                //mcoa_attach.OfficeAutomation_MCOA_Attach_ID = Guid.NewGuid();
    //                //mcoa_attach.OfficeAutomation_MCOA_Attach_MainID = new Guid(dr["OfficeAutomation_Attach_MainID"].ToString());
    //                //mcoa_attach.OfficeAutomation_MCOA_Attach_Name = dr["OfficeAutomation_Attach_Name"].ToString();
    //                //mcoa_attach.OfficeAutomation_MCOA_Attach_Path = newfilename;
    //                //mcoa_attachbll.Add(mcoa_attach);
    //            }
    //            catch (Exception ex)
    //            {
    //                this.txtMessage.Text += ex.Message + "\r\n";
    //            }
    //        }
    //        this.txtMessage.Text +=  "结束\r\n";
    //    }
    //}
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    var d = this.DropDownList1.SelectedItem.Text;
    //    //Update();
    //}
}

public class hh
{
    public hh() { TypeContent = new List<test>(); }
    public List<test> TypeContent { get; set; }
}

public class test
{
    public string TypeContent_ID { get; set; }
    public string TypeContent_Name { get; set; }
}