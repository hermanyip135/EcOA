using DataAccess.Operate;
using DataEntity;
using ECOA.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_BorrowMoney_Apply_BorrowMoney_Import : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //导入
            ImportRemind.Enabled = false;
        }
    }
    #region 借用资金导入
    private string sPageNow = "Apply_BorrowMoney_Import.aspx";
    DataTable errorBorrowMoneyTable = SetBorrowMoneyTable("流水号", "实际支出", "入账时间", "类型", "错误原因");//入账确认错误信息
    DataTable errorCBorrowMoneyTable = SetBorrowMoneyTable("流水号", "冲账金额", "冲账时间", "类型", "错误原因");//冲账错误信息
    //获取域名
    string swUrl = "http://" + HttpContext.Current.Request.Url.Host.ToString() + ":" + HttpContext.Current.Request.Url.Port;
    OutInfo outInfo = new OutInfo();//返回信息
    //借用资金上传
    protected void lbtnUpload_Click(object sender, EventArgs e)
    {
        this.lbMsg.Text = "";

        if (!this.FileUpload1.HasFile)
        {
            this.lbMsg.Text = "请先选择要上传的文件!";
            return;
        }

        string type = this.FileUpload1.FileName.Substring(this.FileUpload1.FileName.LastIndexOf('.') + 1); //文件名后缀;

        if (type != "xls" && type != "xlsx")
        {
            this.lbMsg.Text = "只能上传.xls和.xlsx格式的数据文件!";
            return;
        }
        string path = Server.MapPath(sPageNow);
        path = path.Substring(0, path.Length - sPageNow.Length) + "Downloads\\";
        string fileName = DateTime.Now.ToString("yyyyMMddHHmm") + DateTime.Now.Millisecond + "." + type;

        this.FileUpload1.SaveAs(path + fileName);
        ViewState["filePath"] = path + fileName;
        ViewState["fileName"] = fileName;
        this.ddlSheetName.Items.Clear();
        ExcelHelper excelHelper = new ExcelHelper();
        foreach (string tableName in excelHelper.fnGetSheetNamesByExcel(path + fileName))
        {
            this.ddlSheetName.Items.Add(new ListItem(tableName, tableName));
        }

    }
    /// <summary>
    /// 检测
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnTestingExcel_Click(object sender, EventArgs e)
    {
        ExcelHelper excelHelper = new ExcelHelper();
        if (this.ddlSheetName.Items.Count <= 0)
        {
            this.lbMsg.Text = "请先上传文件,或者该文件没有数据!请确认后再导入!";
            return;
        }
        DataTable dt = excelHelper.fnGetDataSetByExcel(ViewState["filePath"].ToString(), ddlSheetName.SelectedValue).Tables[0];
        //检查异常        
        if (dt.Rows.Count == 0)
        {
            this.lbMsg.Text = "导入失败！请检查excel文件数据！";
            return;
        }
        #region 检查入账确认标题
        if (ddlType.SelectedValue.Contains("入账确认"))
        {
            if (!dt.Columns.Contains("流水号"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少流水号";
                return;
            }
            if (!dt.Columns.Contains("实际支出"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少实际支出";
                return;
            }
            if (!dt.Columns.Contains("入账时间"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少入账时间";
                return;
            }
            if (!dt.Columns.Contains("类型"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少类型";
                return;
            }
        }
        #endregion
        #region 检查冲借支标题
        else if (ddlType.SelectedValue.Contains("冲借支"))
        {
            if (!dt.Columns.Contains("流水号"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少流水号";
                return;
            }
            if (!dt.Columns.Contains("冲账金额"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少冲账金额";
                return;
            }
            if (!dt.Columns.Contains("冲账时间"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少冲账时间";
                return;
            }
            if (!dt.Columns.Contains("类型"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少入账时间";
                return;
            }
           
        }
        #endregion

        TestingExcel(dt);//检测入账内容
        string errorReportNoSum = "";
        //文件夹名
        string wjName = "/borrowMoney" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
        //保存excel路径
        string urlName = AppDomain.CurrentDomain.BaseDirectory + "Apply\\BorrowMoney\\Downloads\\" + wjName;

        //从服务器导出  最终路径+文件夹名+文件名
        string endUrl = swUrl + "/Apply/BorrowMoney/Downloads" + wjName;

        errorReportNoSum = outInfo.ErrorReportNo.ToString();
        string formula = string.Empty;
        //创建excel
        if (ddlType.SelectedValue.Contains("入账确认"))
        {
            formula = "(公式;借支金额 -本次实际支出 -以往实际支出)";
            NPOIExcel.NPOIExportExcel(errorBorrowMoneyTable, urlName);
        }
        else if (ddlType.SelectedValue.Contains("冲借支"))
        {
            formula = "(公式：本次冲账金额+以往冲账金额-实际支出金额)";
            NPOIExcel.NPOIExportExcel(errorCBorrowMoneyTable, urlName);
        }

        //导出赋值路径
        this.LinkErrorAn.NavigateUrl = endUrl;

        this.lbMsg.Text = ddlType.SelectedValue.ToString() + formula + "<br/>检测成功:" + outInfo.InsertCout + "条！检查成功合计金额：" + outInfo.InsertMoney+"元！检测有问题" + outInfo.ErrorCount + "条！<br/>" + errorReportNoSum;
       //导入
        ImportRemind.Enabled = true;
    }
    /// <summary>
    /// 检查excel借支内容
    /// </summary>
    /// <param name="dt"></param>
    private void TestingExcel(DataTable dt)
    {
        DA_OfficeAutomation_Document_BorrowMoney_Inherit dA_OfficeAutomation_Document_BorrowMoney_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_BorrowMoney_Inherit();
        DA_OfficeAutomation_Document_BorrowMoney_Import_Inherit dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Import_Inherit();
        outInfo.ErrorReportNo = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            string sSerialNumber = dr["流水号"].ToString().Trim();
            string sType = dr["类型"].ToString().Trim();
            if (!string.IsNullOrEmpty(sSerialNumber))
            {
                //查询借支申请主表
                T_OfficeAutomation_Document_BorrowMoney tempClass = dA_OfficeAutomation_Document_BorrowMoney_Inherit.GetModel("OfficeAutomation_Document_BorrowMoney_ApplyID='" + sSerialNumber + "'");
                if (ddlType.SelectedValue.Contains("入账确认"))
                {
                    #region 入账确认
                    string sPrice = dr["实际支出"].ToString().Trim();
                    string sSumPrice = dt.Compute("sum(实际支出)", "流水号='" + sSerialNumber + "'").ToString();//同样流水号合计实际支出
                    string sDate = dr["入账时间"].ToString().Trim();
                   

                    //实际已支出
                    string sBorrowMoney = dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.getCalculationMoney(sSerialNumber, "借");
                    if (tempClass == null)
                    {
                        outInfo.ErrorCount++;
                        outInfo.MsgError = "没有此流水号";
                        outInfo.ErrorReportNo.Append(sSerialNumber + ":" + outInfo.MsgError + "</br>");
                        AddErrorTable("入账确认", sSerialNumber, sPrice, sDate, sType, outInfo.MsgError);
                        continue;
                    }
                    else
                    {
                        //判断财务部有没确认收单
                        if ("1" != tempClass.OfficeAutomation_Document_BorrowMoney_IsAgree)
                        {
                            outInfo.ErrorCount++;
                            outInfo.MsgError = "财务部没确认收单";
                            outInfo.ErrorReportNo.Append(sSerialNumber + ":" + outInfo.MsgError + "</br>");
                            AddErrorTable("入账确认", sSerialNumber, sPrice, sDate, sType, outInfo.MsgError);
                        }
                        else if (!string.IsNullOrEmpty(sPrice))
                        {
                            //检查借支金额是否小于实际支出
                            if (Convert.ToDouble(tempClass.OfficeAutomation_Document_BorrowMoney_Money) < (Convert.ToDouble(sPrice) + Convert.ToDouble(sBorrowMoney)))
                            {
                                outInfo.ErrorCount++;
                                outInfo.MsgError = "借支金额小于实际支出、借支金额：" + tempClass.OfficeAutomation_Document_BorrowMoney_Money + " 本次实际支出：" + sSumPrice + " 以往实际支出：" + sBorrowMoney;
                                outInfo.ErrorReportNo.Append(sSerialNumber + ":" + outInfo.MsgError + "</br>");
                                AddErrorTable("入账确认", sSerialNumber, sPrice, sDate, sType, outInfo.MsgError);
                            }
                            else
                            {
                                outInfo.InsertCout++;
                                outInfo.InsertMoney += Convert.ToDecimal(sPrice);
                                AddErrorTable("入账确认", sSerialNumber, sPrice, sDate, sType, "");
                            }
                        }
                    }
                    #endregion
                }
                else if (ddlType.SelectedValue.Contains("冲借支"))
                {
                    #region 冲借支
                    string sPrice = dr["冲账金额"].ToString().Trim();
                    string sSumPrice = dt.Compute("sum(冲账金额)", "流水号='" + sSerialNumber + "'").ToString();
                    string sDate = dr["冲账时间"].ToString().Trim();
                    string sPunchingMoney = dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.getCalculationMoney(sSerialNumber, "冲");//冲账金额
                    string sBorrowMoney = dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.getCalculationMoney(sSerialNumber, "借");//实际已支出
                    if (tempClass == null)
                    {
                        outInfo.ErrorCount++;
                        outInfo.MsgError = "没有此流水号";
                        outInfo.ErrorReportNo.Append(sSerialNumber + ":" + outInfo.MsgError + "</br>");
                        AddErrorTable("冲借支", sSerialNumber, sPrice, sDate, sType, outInfo.MsgError);
                        continue;
                    }
                    else
                    {
                        if ("1" != tempClass.OfficeAutomation_Document_BorrowMoney_IsAgree)
                        {
                            outInfo.ErrorCount++;
                            outInfo.MsgError = "财务部没确认收单";
                            outInfo.ErrorReportNo.Append(sSerialNumber + ":" + outInfo.MsgError + "</br>");
                            AddErrorTable("入账确认", sSerialNumber, sPrice, sDate, sType, outInfo.MsgError);
                        }
                        else if (!string.IsNullOrEmpty(sPrice))
                        {
                            //检查本次冲账金额+以往冲账金额-实际支出金额大于0
                            decimal s = (Convert.ToDecimal(sPrice) + Convert.ToDecimal(sPunchingMoney)) - Convert.ToDecimal(sBorrowMoney);
                            if (s > 0)
                            {
                                outInfo.ErrorCount++;
                                outInfo.MsgError = "冲账金额大于实际支出、本次冲账金额：" + sSumPrice + " 以往冲账金额：" + sPunchingMoney + "  实际支出金额：" + sBorrowMoney;
                                outInfo.ErrorReportNo.Append(sSerialNumber + ":" + outInfo.MsgError + "</br>");
                                AddErrorTable("冲借支", sSerialNumber, sPrice, sDate, sType, outInfo.MsgError);
                            }
                            else
                            {
                                outInfo.InsertCout++;
                                outInfo.InsertMoney += Convert.ToDecimal(sPrice);
                                AddErrorTable("冲借支", sSerialNumber, sPrice, sDate, sType, "");
                            }
                        }
                    }
                    #endregion
                }
            }
        }
    }

    /// <summary>
    /// 导入借资申请金额
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtImportBorrowMoney_Click(object sender, EventArgs e)
    {
        ExcelHelper excelHelper = new ExcelHelper();
        if (this.ddlSheetName.Items.Count <= 0)
        {
            this.lbMsg.Text = "请先上传文件,或者该文件没有数据!请确认后再导入!";
            return;
        }
        DataTable dt = excelHelper.fnGetDataSetByExcel(ViewState["filePath"].ToString(), ddlSheetName.SelectedValue).Tables[0];
        //检查异常        
        if (dt.Rows.Count == 0)
        {
            this.lbMsg.Text = "导入失败！请检查excel文件数据！";
            return;
        }
        #region 检查入账确认标题
        if (ddlType.SelectedValue.Contains("入账确认"))
        {
            if (!dt.Columns.Contains("流水号"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少流水号";
                return;
            }
            if (!dt.Columns.Contains("实际支出"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少实际支出";
                return;
            }
            if (!dt.Columns.Contains("入账时间"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少入账时间";
                return;
            }
            if (!dt.Columns.Contains("类型"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少类型";
                return;
            }
        }
        #endregion
        #region 检查冲借支标题
        else if (ddlType.SelectedValue.Contains("冲借支"))
        {
            if (!dt.Columns.Contains("流水号"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少流水号";
                return;
            }
            if (!dt.Columns.Contains("冲账金额"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少冲账金额";
                return;
            }
            if (!dt.Columns.Contains("冲账时间"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少冲账时间";
                return;
            }
            if (!dt.Columns.Contains("类型"))
            {
                this.lbMsg.Text = "文件格式不正确，缺少入账时间";
                return;
            }
        }
        #endregion
        T_OfficeAutomation_Document_BorrowMoney_Import t_OfficeAutomation_Document_BorrowMoney_Import = new T_OfficeAutomation_Document_BorrowMoney_Import();
        DA_OfficeAutomation_Document_BorrowMoney_Inherit dA_OfficeAutomation_Document_BorrowMoney_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_BorrowMoney_Inherit();
        DA_OfficeAutomation_Document_BorrowMoney_Import_Inherit dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Import_Inherit();
      //查询借支申请主表
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            string sSerialNumber = dr["流水号"].ToString().Trim();
            T_OfficeAutomation_Document_BorrowMoney tempClass = dA_OfficeAutomation_Document_BorrowMoney_Inherit.GetModel("OfficeAutomation_Document_BorrowMoney_ApplyID='" + sSerialNumber + "'"); 
            if (!string.IsNullOrEmpty(sSerialNumber))
            {
                //财务没确认收单
                if ("1" != tempClass.OfficeAutomation_Document_BorrowMoney_IsAgree)
                {
                    continue;
                }
                else if (ddlType.SelectedValue.Contains("入账确认"))
                {
                    double dPrice = Convert.ToDouble(dr["实际支出"].ToString().Trim());
                    t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_ID = Guid.NewGuid();
                    t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_ApplyID = sSerialNumber;
                    t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_Money = dPrice;
                    t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_Date = Convert.ToDateTime(dr["入账时间"].ToString().Trim());
                    t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_Type = dr["类型"].ToString().Trim();
                    t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_ImportDate = DateTime.Now;
                    dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.Add(t_OfficeAutomation_Document_BorrowMoney_Import);
                }
                else if (ddlType.SelectedValue.Contains("冲借支"))
                {
                    //string sSumPrice = dt.Compute("sum(冲账金额)", "流水号='" + sSerialNumber + "'").ToString() == "" ? "0" : dt.Compute("sum(冲账金额)", "流水号='" + sSerialNumber + "'").ToString();
                    
                   
                    double dPrice = Convert.ToDouble(dr["冲账金额"].ToString().Trim() == "" ? "0" : dr["冲账金额"].ToString().Trim());
                    string sPunchingMoney = dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.getCalculationMoney(sSerialNumber, "冲");//冲账金额
                    string sBorrowMoney = dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.getCalculationMoney(sSerialNumber, "借");//实际已支出
                    //检查本次冲账金额+以往冲账金额-实际支出金额大于0
                    //if ((Convert.ToDouble(sSumPrice) + Convert.ToDouble(sPunchingMoney)) - Convert.ToDouble(sBorrowMoney) <= 0)
                    if ((Convert.ToDecimal(dPrice) + Convert.ToDecimal(sPunchingMoney)) - Convert.ToDecimal(sBorrowMoney) <= 0)
                    {
                        t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_ID = Guid.NewGuid();
                        t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_ApplyID = sSerialNumber;
                        t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_Money = dPrice;
                        t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_Date =Convert.ToDateTime(dr["冲账时间"].ToString().Trim());
                        t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_Type = dr["类型"].ToString().Trim();
                        t_OfficeAutomation_Document_BorrowMoney_Import.OfficeAutomation_Document_BorrowMoney_Import_ImportDate = DateTime.Now;
                        dA_OfficeAutomation_Document_BorrowMoney_Import_Inherit.Add(t_OfficeAutomation_Document_BorrowMoney_Import);
                    }
                }
            }
        }
        
        this.lbMsg.Text = "导入成功";
    }
    public void AddErrorTable(string sTypeName, string SerialNumber, string sParam1, string sParam2, string sParam3, string sReason)
    {
        if ("入账确认".Equals(sTypeName))
        {
            DataRow dr = errorBorrowMoneyTable.NewRow();
            dr["流水号"] = SerialNumber;
            dr["实际支出"] = sParam1;
            dr["入账时间"] = sParam2;
            dr["类型"] = sParam3;
            dr["错误原因"] = sReason;
            errorBorrowMoneyTable.Rows.Add(dr);
        }
        else if ("冲借支".Equals(sTypeName))
        {

            DataRow dr = errorCBorrowMoneyTable.NewRow();
            dr["流水号"] = SerialNumber;
            dr["冲账金额"] = sParam1;
            dr["冲账时间"] = sParam2;
            dr["类型"] = sParam3;
            dr["错误原因"] = sReason;
            errorCBorrowMoneyTable.Rows.Add(dr);
        }
    }
    /// <summary>
    /// 错误入账确认table
    /// </summary>
    /// <param name="sTitle1">流水号</param>
    /// <param name="sTitle2">实际支出</param>
    /// <param name="sTitle3">入账时间</param>
    /// <param name="sTitle4">类型</param>
    /// <param name="sTitle5">错误原因</param>
    /// <returns></returns>
    public static DataTable SetBorrowMoneyTable(string sTitle1, string sTitle2, string sTitle3, string sTitle4, string sTitle5)
    {
        //"流水号", "实际支出", "入账时间", "类型", "错误原因"
        DataTable errorTable = new DataTable();

        DataColumn dc1 = new DataColumn(sTitle1, Type.GetType("System.String"));
        DataColumn dc2 = new DataColumn(sTitle2, Type.GetType("System.String"));
        DataColumn dc3 = new DataColumn(sTitle3, Type.GetType("System.String"));
        DataColumn dc4 = new DataColumn(sTitle4, Type.GetType("System.String"));
        DataColumn dc5 = new DataColumn(sTitle5, Type.GetType("System.String"));
        errorTable.Columns.Add(dc1);
        errorTable.Columns.Add(dc2);
        errorTable.Columns.Add(dc3);
        errorTable.Columns.Add(dc4);
        errorTable.Columns.Add(dc5);
        return errorTable;
    }
    #endregion
    public class OutInfo
    {
        private int insertCout;
        private int errorCount;
        private decimal insertMoney;
        public string msgError;
        public StringBuilder errorReportNo;

        public decimal InsertMoney
        {
            get { return this.insertMoney; }
            set { this.insertMoney = value; }
        }
        public int InsertCout
        {
            get { return this.insertCout; }
            set { this.insertCout = value; }
        }
        public int ErrorCount
        {
            get { return this.errorCount; }
            set { this.errorCount = value; }
        }
        public string MsgError
        {
            get { return this.msgError; }
            set { this.msgError = value; }
        }
        public StringBuilder ErrorReportNo
        {
            get { return this.errorReportNo; }
            set { this.errorReportNo = value; }
        }

    }
}