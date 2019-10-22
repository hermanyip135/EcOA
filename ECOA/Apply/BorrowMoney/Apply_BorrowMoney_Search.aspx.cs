using DataAccess.Operate;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_BorrowMoney_Apply_BorrowMoney_Search : BasePage
{
    public StringBuilder sbJSON = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllDepartment();
    }
    /// <summary>
    /// 获取所有部门
    /// </summary>
    private void GetAllDepartment()
    {
        wsKDHR.Service service = new wsKDHR.Service();
        DataSet dsAllDepartment = service.HRAllDepartmentListGZ();
        sbJSON.Append("[");
        foreach (DataRow dr in dsAllDepartment.Tables[0].Rows)
        {
            sbJSON.Append("{\"id\":\"" + dr["id"].ToString() + "\",\"label\":\"" + dr["name"].ToString() + "\",\"value\":\"" + dr["name"].ToString() + "\"},");
        }
        sbJSON.Remove(sbJSON.Length - 1, 1);
        sbJSON.Append("]");
    }
    /// <summary>
    /// 查询汇总
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender,EventArgs e)
    {
        DataSet ds = gvDataBind();

        string strSum = ds.Tables[0].Compute("sum(BalanceMoney)", "true").ToString(); //类型参照上面自己转
        gvDatarows.InnerText = "总共：" + ds.Tables[0].Rows.Count + "条。";
        if (string.IsNullOrEmpty(strSum)) strSum = "0";
        gvDataSumMoney.InnerText = "总借支余额：" + strSum + "元";
        gvData.DataSource = ds;
        gvData.DataBind();
    }
    private DataSet gvDataBind()
    {
        string sDepartment = txtApplicationDepartment.Value;//部门
        string sApplicant = txtApplicant.Value;//申请人
        string sBeginDate = txtBeginDate.Value;//余额开始日期
        string sEndDate = txtEndDate.Value;//余额结束日期
        string sApplyID = txtApplyID.Value;//流水号
        DA_OfficeAutomation_Document_BorrowMoney_Search_Inherit da_OfficeAutomation_Document_BorrowMoney_Search_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Search_Inherit();
        DataSet ds = da_OfficeAutomation_Document_BorrowMoney_Search_Inherit.getBorrowMoneyBalance(sBeginDate, sEndDate, sDepartment, sApplicant, sApplyID);
        return ds;
    }
    /// <summary>
    /// 查询申请事项明细
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
     protected void btnSearch1_Click(object sender,EventArgs e)
    {
        DataSet ds = gvData1Bind();
        gvData1rows.InnerText = "总共：" + ds.Tables[0].Rows.Count + '条';
        gvData1.DataSource = ds;
        gvData1.DataBind();
       
    }
    //申请事项详情
     private DataSet gvData1Bind()
     {
         string sDepartment = txtApplicationDepartment1.Value;//部门
         string sApplicant = txtApplicant1.Value;//申请人
         string sBeginDate = txtBeginDate1.Value;//余额开始日期
         string sEndDate = txtEndDate1.Value;//余额结束日期
         string sApplyID = txtApplyID1.Value;//流水号
         string sDateType = ddlDateType.SelectedValue;//日期类型
         DA_OfficeAutomation_Document_BorrowMoney_Search_Inherit da_OfficeAutomation_Document_BorrowMoney_Search_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Search_Inherit();
         DataSet ds = da_OfficeAutomation_Document_BorrowMoney_Search_Inherit.getBorrowMoneyDetail(sBeginDate, sEndDate, sDateType, sDepartment, sApplicant, sApplyID);
         return ds;
        
     }
     /// <summary>
     /// 查询申请事项明细
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     protected void btnSearch2_Click(object sender, EventArgs e)
     {
         DataSet ds = gvData2Bind();
         gvData2rows.InnerText = "总共：" + ds.Tables[0].Rows.Count + '条';
         gvData2.DataSource = ds;
         gvData2.DataBind();

     }
    /// <summary>
     /// 已收单未未付款
    /// </summary>
    /// <returns></returns>
     private DataSet gvData2Bind()
     {
         DA_OfficeAutomation_Document_BorrowMoney_Search_Inherit da_OfficeAutomation_Document_BorrowMoney_Search_Inherit = new DA_OfficeAutomation_Document_BorrowMoney_Search_Inherit();
         DataSet ds = da_OfficeAutomation_Document_BorrowMoney_Search_Inherit.SearchReceiptUnpaid();
         return ds;
     }
     protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         // 得到该控件
         GridView theGrid = sender as GridView;
         int newPageIndex = 0;
         if (e.NewPageIndex == -3)
         {
             newPageIndex = StrToInt(hdPagerNum1.Value, 1) - 1;
         }
         else
         {
             //点击了其他的按钮
             newPageIndex = e.NewPageIndex;
         }
         //防止新索引溢出
         newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
         newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

         //得到新的值
         theGrid.PageIndex = newPageIndex;
         gvData.DataSource = gvDataBind();
         gvData.DataBind();
     }
     /// <summary>
     /// gvData1页码改变事件
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     protected void gvData1_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         // 得到该控件
         GridView theGrid = sender as GridView;
         int newPageIndex = 0;
         if (e.NewPageIndex == -3)
         {
             newPageIndex = StrToInt(hdPagerNum1.Value, 1) - 1;
         }
         else
         {
             //点击了其他的按钮
             newPageIndex = e.NewPageIndex;
         }
         //防止新索引溢出
         newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
         newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

         //得到新的值
         theGrid.PageIndex = newPageIndex;
         gvData1.DataSource = gvData1Bind();
         gvData1.DataBind();
          
     }
     /// <summary>
     /// gvData2页码改变事件
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     protected void gvData2_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         // 得到该控件
         GridView theGrid = sender as GridView;
         int newPageIndex = 0;
         if (e.NewPageIndex == -3)
         {
             newPageIndex = StrToInt(hdPagerNum1.Value, 1) - 1;
         }
         else
         {
             //点击了其他的按钮
             newPageIndex = e.NewPageIndex;
         }
         //防止新索引溢出
         newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
         newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

         //得到新的值
         theGrid.PageIndex = newPageIndex;
         gvData2.DataSource = gvData2Bind();
         gvData2.DataBind();

     }
     protected void btExcel_Click(object sender, EventArgs e)
     {
         DataTable dt = gvDataBind().Tables[0];
         dt.Columns["ApplyID"].ColumnName = "流水号";
         dt.Columns["Department"].ColumnName = "分行名称";
         dt.Columns["BalanceMoney"].ColumnName = "借支余额";
         dt.Columns["ImportDate"].ColumnName = "借额日期";
         ExcelExport(dt, "借支余额汇总");
     }
     protected void btExcel1_Click(object sender, EventArgs e)
     {
         DataTable dt = gvData1Bind().Tables[0];

         dt.Columns["ApplyID"].ColumnName = "流水号";
         dt.Columns["Department"].ColumnName = "分行名称";
         dt.Columns["Rent"].ColumnName = "租金";
         dt.Columns["RentTax"].ColumnName = "租金税费";
         dt.Columns["ManaExpense"].ColumnName = "管理费";
         dt.Columns["ElectricityFees"].ColumnName = "电费";
         dt.Columns["water"].ColumnName = "水费";
         dt.Columns["Other"].ColumnName = "其他";

         ExcelExport(dt, "借支申请项明细");
     }
     protected void btExcel2_Click(object sender, EventArgs e)
     {
         DataTable dt = gvData2Bind().Tables[0];

         dt.Columns["ApplyID"].ColumnName = "流水号";
         dt.Columns["Department"].ColumnName = "分行名称";
         dt.Columns["abstract"].ColumnName = "摘要(汇总)";
         dt.Columns["PriceSum"].ColumnName = "借支金额合计";
         dt.Columns["BorrowMoneyState"].ColumnName = "审核状态";
         dt.Columns["AuditorDate"].ColumnName = "收单时间";
         dt.Columns["Person"].ColumnName = "部门负责人";
         dt.Columns["ApplyPoper"].ColumnName = "申请人";
         ExcelExport(dt, "已收单未付款明细");
     }
     private void ExcelExport(DataTable dt, string exportFileName)
     {
         StringWriter sw = GetStringWriter(dt);

         HttpContext.Current.Response.Charset = "gb2312";

         HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
         exportFileName = exportFileName.Replace("/", "或");
         string fileName = HttpUtility.UrlEncode(exportFileName, Encoding.UTF8);
         string str = "attachment;filename= " + fileName + ".xls";

         HttpContext.Current.Response.AppendHeader("Content-Disposition", str);
         HttpContext.Current.Response.ContentType = "application/ms-excel";
         HttpContext.Current.Response.Write(sw);
         HttpContext.Current.Response.End();
     }
     private StringWriter GetStringWriter(DataTable dt)
     {
         StringWriter sw = new StringWriter();
         foreach (DataColumn dc in dt.Columns)
         {
             sw.Write(dc.ColumnName + "\t");
         }
         sw.Write(sw.NewLine);
         if (dt != null)
         {
             foreach (DataRow dr in dt.Rows)
             {
                 for (int i = 0; i < dt.Columns.Count; i++)
                 {

                     sw.Write(dr[i].ToString()
                     .Replace("\r\n", " ")
                     .Replace("\t", " ")
                     + "\t");


                 }
                 sw.Write(sw.NewLine);
             }
         }
         sw.Close();
         return sw;
     }
}