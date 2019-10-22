using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Operate;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

public partial class Apply_AssetTransfer_Apply_AssetNew : BasePage
{
    public StringBuilder sbJSON = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllDepartment();
        string s = GetQueryString("Asset_Dpm");
        string mid = GetQueryString("mainID");
        if (!IsPostBack)
        {
            try
            {
                DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                DataSet dsDetail = new DataSet();
                dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(mid);
                foreach (DataRow dr in dsDetail.Tables[0].Rows)
                {
                    wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                    ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                }
            }
            catch
            {
            }

            #region 20160322
            var tempfilepath = Server.MapPath("../../Temp/" + mid + ".xml");
            //临时xml文件(优先读)
            if (File.Exists(tempfilepath))
            {
                var list = XmlHelper.XmlDeserializeFromFile<List<CommonEntity.AssetTransferZC>>(tempfilepath, Encoding.UTF8);   //反序列化xml
                var json = JsonConvert.SerializeObject(list);
                this.hidContent.Value = json;
            }
            else
            {
                var ATDetailBLL = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                var ds = ATDetailBLL.SelectByID(mid);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<CommonEntity.AssetTransferZC> list = new List<CommonEntity.AssetTransferZC>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new CommonEntity.AssetTransferZC {
                            AssetNo = dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString(),
                        }); 
                    }
                }
            }
            #endregion

            LoadPage();
        }
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
    /// 加载页面
    /// </summary>
    private void LoadPage()
    {
        if (txtAssetNo.Text != "" || txtClassesId.Text != "" || txtBeginTime.Text != "" || txtEndTime.Text != "")
            BindDataWithPageIndex(txtAssetNo.Text, txtClassesId.Text, txtBeginTime.Text, txtEndTime.Text);
        else
            BindData();
        if (gvData.Rows.Count == 0)
            RunJS("alert('没有找到“" + GetQueryString("Asset_Dpm") + "”的相关资产，请检查该部门名称是否正确。');window.returnValue='';window.close();");
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string dpm = GetQueryString("Asset_Dpm");
        //dpm = "大同路";
        ds = da_OfficeAutomation_Main_Inherit.SelectAssets(dpm, "", "", "", "");
        gvData.DataSource = ds;
        gvData.DataBind();
    }

    private void BindDataWithPageIndex(string No, string Id, string St, string Et)
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string dpm = GetQueryString("Asset_Dpm");
        ds = da_OfficeAutomation_Main_Inherit.SelectAssets(dpm, No, Id, St, Et);

        gvData.DataSource = ds;
        gvData.DataBind();
    }

    /// <summary>
    /// 查询按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gvData.PageIndex = 0;
        LoadPage();
    }

    /// <summary>
    /// gvData页码改变事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //RememberOldValues();
        // 得到该控件
        GridView theGrid = sender as GridView;
        int newPageIndex = 0;
        if (e.NewPageIndex == -3)
        {
            newPageIndex = StrToInt(hdPagerNum.Value, 1) - 1;
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

        if (txtAssetNo.Text != "" || txtClassesId.Text != "" || txtBeginTime.Text != "" || txtEndTime.Text != "")
            BindDataWithPageIndex(txtAssetNo.Text, txtClassesId.Text, txtBeginTime.Text, txtEndTime.Text);
        else
            BindData();
        //RePopulateValues();
    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.Cells[1].Text.Contains("详见附件"))
        //    {
        //        e.Row.Cells[1].Font.Bold = true;
        //        e.Row.Cells[1].Font.Size = 14;
        //        e.Row.Cells[2].Font.Bold = true;
        //        e.Row.Cells[2].Font.Size = 14;
        //        e.Row.Cells[3].Font.Bold = true;
        //        e.Row.Cells[3].Font.Size = 14;
        //    }
        //}
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        var zcContent = this.hidContent.Value;
        var zc = JsonConvert.DeserializeObject<List<CommonEntity.AssetTransferZC>>(zcContent);
        string mid = GetQueryString("mainID");
        var tempfilepath = Server.MapPath("../../Temp/" + mid + ".xml");
        XmlHelper.XmlSerializeToFile(zc, tempfilepath, Encoding.UTF8);
        RunJS("window.returnValue='AddSuccess';window.close();");
    }
}