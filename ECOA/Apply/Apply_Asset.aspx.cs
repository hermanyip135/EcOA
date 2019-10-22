using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;

using DataAccess.Operate;
using System.Collections;
using System.IO;

public partial class Apply_Apply_Asset : BasePage
{
    public StringBuilder sbJSON = new StringBuilder();
    //public StringBuilder sbJS = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 300;
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
    /// 初始化页面
    /// </summary>
    private void InitPage()
    {

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
        if(gvData.Rows.Count==0)
            RunJS("alert('没有找到“"+GetQueryString("Asset_Dpm")+"”的相关资产，请检查该部门名称是否正确。');window.returnValue='';window.close();");
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

    private void BindDataWithPageIndex(string No,string Id,string St,string Et)
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string dpm = GetQueryString("Asset_Dpm");
        //dpm = "大同路";
        ds = da_OfficeAutomation_Main_Inherit.SelectAssets(dpm, No, Id, St, Et);

        gvData.DataSource = ds;
        //gvData.PageIndex = pageindex;
        gvData.DataBind();
    }

    /// <summary>
    /// 查询按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        RememberOldValues();
        gvData.PageIndex = 0;
        LoadPage();
        RePopulateValues();
    }

    private void RememberOldValues()
    {
        ArrayList categoryIDList = new ArrayList();
        Guid index;
        foreach (GridViewRow row in gvData.Rows)
        {
            index = (Guid)gvData.DataKeys[row.RowIndex].Value;
            bool result = ((CheckBox)row.FindControl("ChkSelected")).Checked;
            if (Session["CHECKED_ITEMS"] != null)
                categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
            if (result)
            {
                if (!categoryIDList.Contains(index))
                    categoryIDList.Add(index);
            }
            else
                categoryIDList.Remove(index);
        }
        if (categoryIDList != null && categoryIDList.Count > 0)
            Session["CHECKED_ITEMS"] = categoryIDList;
    }

    private void RePopulateValues()
    {
        ArrayList categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            foreach (GridViewRow row in gvData.Rows)
            {
                Guid index = (Guid)gvData.DataKeys[row.RowIndex].Value;
                if (categoryIDList.Contains(index))
                {
                    CheckBox myCheckBox = (CheckBox)row.FindControl("ChkSelected");
                    myCheckBox.Checked = true;
                }
            }
        }
    }

    /// <summary>
    /// gvData页码改变事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RememberOldValues();
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
        RePopulateValues();
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        RememberOldValues();
        if (Session["CHECKED_ITEMS"] != null)
        {
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            ArrayList categoryIDList = new ArrayList();
            DataSet ds = new DataSet();
            string st = null, rt = null;
            categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
            if (categoryIDList.Count > 5)
                RunJS("alert('所选择的资产不能超过5项，如有需要请上传EXCEL格式的明细表作为附件！');history.go(-1);");
            else
            {
                rt = "{\"Assets\":[";
                for (int i = 0; i < categoryIDList.Count; i++)
                {
                    ds = da_OfficeAutomation_Main_Inherit.FindAssetsByID(categoryIDList[i].ToString());
                    //rt += categoryIDList[i].ToString() + ",";
                    rt += "{\"txtClasses\":" + "\"" + ds.Tables[0].Rows[0]["txtClasses"].ToString().Replace("\r","").Replace("\n","") + "\","
                        + "\"Asset_AssetNo\":" + "\"" + ds.Tables[0].Rows[0]["Asset_AssetNo"].ToString().Replace("\r", "").Replace("\n", "") + "\","
                        + "\"txtTS\":" + "\"" + ds.Tables[0].Rows[0]["txtTS"].ToString().Replace("\r", "").Replace("\n", "") + "\","
                        + "\"txtPlace\":" + "\"" + ds.Tables[0].Rows[0]["txtPlace"].ToString().Replace("\r", "").Replace("\n", "") + "\","
                        + "\"Asset_RecordedTime\":" + "\"" + ds.Tables[0].Rows[0]["Asset_RecordedTime"].ToString().Replace("\r", "").Replace("\n", "") + "\","
                        + "\"Asset_Id\":" + "\"" + categoryIDList[i].ToString() + "\","
                        + "\"cv\":" + "\"" + ds.Tables[0].Rows[0]["cv"].ToString().Replace("\r", "").Replace("\n", "") + "\"},";
                    st += ds.Tables[0].Rows[0]["Asset_AssetNo"].ToString().Replace("\r", "").Replace("\n", "") + "\\r\\n";
                }
                rt = rt.Remove(rt.Length - 1, 1);
                rt += "]}";
                RunJS("if(confirm('确实要将以下资产：\\r\\n\\r\\n" + st + "\\r\\n添加到列表中吗？')){window.returnValue='" + rt + "';window.close();}");
            }
            Session.Remove("CHECKED_ITEMS");
        }
        else
        {
            Session.Remove("CHECKED_ITEMS");
            RunJS("alert('请重新选择资产！');history.go(-1);");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        RunJS("window.returnValue='';window.close();");
    }
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Contains("详见附件"))
            {
                e.Row.Cells[1].Font.Bold = true;
                e.Row.Cells[1].Font.Size = 14;
                e.Row.Cells[2].Font.Bold = true;
                e.Row.Cells[2].Font.Size = 14;
                e.Row.Cells[3].Font.Bold = true;
                e.Row.Cells[3].Font.Size = 14;
            }
        }
    }
}
