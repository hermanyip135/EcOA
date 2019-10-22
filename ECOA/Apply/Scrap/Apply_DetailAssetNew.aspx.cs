using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Operate;
using DataEntity;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

public partial class Apply_Scrap_Apply_DetailAssetNew : BasePage
{
    public StringBuilder sbJSON = new StringBuilder();

    public string sdt;
    public string flag = "";//标记,"CanEdit":可以编辑修改,"NoEidt":不可以编辑

    protected void Page_Load(object sender, EventArgs e)
    {
        string s = GetQueryString("Asset_Dpm");
        sdt = GetQueryString("Data");
        string mid = GetQueryString("mainID");
        flag = GetQueryString("flag");
        
        if (!IsPostBack)
        {
            LoadPage();
            InitPage();
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
        //20160525
        string mid = GetQueryString("mainID");
        string json = AssetMethod.GetScrapAsset(mid);       //获取detail json
        this.hidContent.Value = json;
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
        //dpm = "大同路分行";
        ds = da_OfficeAutomation_Main_Inherit.SelectAssets(dpm, "", "", "", "");
        gvData.DataSource = ds;
        gvData.DataBind();
    }

    private void BindDataWithPageIndex(string No, string Id, string St, string Et)
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
        //RememberOldValues();
        gvData.PageIndex = 0;
        LoadPage();
        //RePopulateValues();
    }

    private void RememberOldValues()
    {
        ArrayList categoryIDList = new ArrayList();
        ArrayList ctgPlaceRec = new ArrayList();
        Guid index;
        foreach (GridViewRow row in gvData.Rows)
        {
            index = (Guid)gvData.DataKeys[row.RowIndex].Value;
            bool result = ((CheckBox)row.FindControl("ChkSelected")).Checked;
            if (Session["CHECKED_Scrap"] != null)
            {
                categoryIDList = (ArrayList)Session["CHECKED_Scrap"];
            }
            if (result)
            {
                if (!categoryIDList.Contains(index))
                {
                    categoryIDList.Add(index);
                }
                else
                {
                    try
                    {
                        ctgPlaceRec.Remove(ctgPlaceRec[categoryIDList.IndexOf(index)].ToString());
                        categoryIDList.Remove(index);
                        categoryIDList.Add(index);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                try
                {
                    ctgPlaceRec.Remove(ctgPlaceRec[categoryIDList.IndexOf(index)].ToString());
                }
                catch
                {
                }
                categoryIDList.Remove(index);
            }
        }
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            Session["CHECKED_Scrap"] = categoryIDList;
        }
    }

    private void RePopulateValues()
    {
        ArrayList categoryIDList = (ArrayList)Session["CHECKED_Scrap"];
        Guid index;
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            foreach (GridViewRow row in gvData.Rows)
            {
                index = (Guid)gvData.DataKeys[row.RowIndex].Value;
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

    protected void btnSure_Click(object sender, EventArgs e)
    {
        string content = this.hidContent.Value;
        if (string.IsNullOrEmpty(content) || content.Length < 2)
        {
            RunJS("alert('请选择资源');");
            return;
        }
        //var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<Asset>(content);
        //var obj = new T_OfficeAutomation_Document_Scrap_Detail();
        //obj.OfficeAutomation_Document_Scrap_Detail_ID = Guid.NewGuid();
        //obj.OfficeAutomation_Document_Scrap_Detail_MainID = new Guid(MainID);
        //obj.OfficeAutomation_Document_Scrap_Detail_AssetName = detail.AssetClasses;
        //obj.OfficeAutomation_Document_Scrap_Detail_AssetAID = detail.AssetID;
        //obj.OfficeAutomation_Document_Scrap_Detail_AssetTag = detail.AssetAssetNo;
        //obj.OfficeAutomation_Document_Scrap_Detail_Number = "1";
        //obj.OfficeAutomation_Document_Scrap_Detail_Model = detail.AssetTS;
        //obj.OfficeAutomation_Document_Scrap_Detail_BuyDate = Convert.ToDateTime(detail.AssetRecordedTime);
        //obj.OfficeAutomation_Document_Scrap_Detail_SurplusValue = "";
        //obj.OfficeAutomation_Document_Scrap_Detail_PlaceRec = detail.AssetType;
        //content = content.Substring(1, content.Length - 1);
        var zc = JsonConvert.DeserializeObject<List<CommonEntity.ScrapAsset>>(content);
        string mid = GetQueryString("mainID");
        var tempfilepath = CommonConst.GetTempXmlPath(mid);
        XmlHelper.XmlSerializeToFile(zc, tempfilepath, Encoding.UTF8);
        RunJS("window.returnValue='" + this.hidContent.Value + "';window.close();");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session.Remove("CHECKED_Scrap");
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

