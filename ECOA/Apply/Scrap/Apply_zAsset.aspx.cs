using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;

using DataAccess.Operate;
using DataEntity;
using System.Collections;

//using Excel = Microsoft.Office.Interop.Excel;//这种引用方式
//using System.Reflection; //Missing类命名空间
using System.IO;

public partial class Apply_Apply_zAsset : BasePage
{
    public StringBuilder sbJSON = new StringBuilder();
    //public StringBuilder sbJS = new StringBuilder();
    public string sdt;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 300;
        //GetAllDepartment();
        string s = GetQueryString("Asset_Dpm");
        sdt = GetQueryString("Data");
        string mid = GetQueryString("mainID");
        if (!IsPostBack)
        {
            //try
            //{
            //    DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
            //    DataSet dsDetail = new DataSet();
            //    dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(mid);
            //    foreach (DataRow dr in dsDetail.Tables[0].Rows)
            //    {
            //        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
            //        ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
            //    }
            //}
            //catch
            //{
            //}
            Session.Remove("CHECKED_ASSNO");
            Session.Remove("Se_BuyDate");
            Session.Remove("Se_SurplusValue");
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
        //dpm = "大同路分行";
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
        //ArrayList ctgBuyDate = new ArrayList();
        //ArrayList ctgSurplusValue = new ArrayList();
        ArrayList ctgPlaceRec = new ArrayList();
        //string PlaceRec;
        Guid index;
        foreach (GridViewRow row in gvData.Rows)
        {
            index = (Guid)gvData.DataKeys[row.RowIndex].Value;
            //BuyDate = ((TextBox)gvData.Rows[row.RowIndex].Cells[1].FindControl("txtBuyDate")).Text.Trim();
            //SurplusValue = ((TextBox)gvData.Rows[row.RowIndex].Cells[2].FindControl("txtSurplusValue")).Text.Trim();
            //PlaceRec = ((TextBox)gvData.Rows[row.RowIndex].Cells[1].FindControl("txtPlaceRec")).Text.Trim();
            //if (BuyDate.Trim() == string.Empty)
            //    RunJS("alert('请填写调出部门！');history.go(-1);");
            //if (SurplusValue.Trim() == string.Empty)
            //    RunJS("alert('请填写接收部门！');history.go(-1);");

            bool result = ((CheckBox)row.FindControl("ChkSelected")).Checked;
            if (Session["CHECKED_Scrap"] != null)
            {
                categoryIDList = (ArrayList)Session["CHECKED_Scrap"];
                //ctgBuyDate = (ArrayList)Session["Se_BuyDate"];
                //ctgSurplusValue = (ArrayList)Session["Se_SurplusValue"];
                //ctgPlaceRec = (ArrayList)Session["Se_PlaceRec"];
            }
            if (result)
            {
                //if (BuyDate.Trim() == string.Empty)
                //    BuyDate = "　";
                //if (SurplusValue.Trim() == string.Empty)
                //    SurplusValue = "　";
                if (!categoryIDList.Contains(index))
                {
                    categoryIDList.Add(index);
                    //ctgBuyDate.Add(BuyDate);
                    //ctgSurplusValue.Add(SurplusValue);
                    //ctgPlaceRec.Add(PlaceRec);
                }
                else
                {
                    try
                    {
                        //ctgBuyDate.Remove(ctgBuyDate[categoryIDList.IndexOf(index)].ToString());
                        //ctgSurplusValue.Remove(ctgSurplusValue[categoryIDList.IndexOf(index)].ToString());
                        ctgPlaceRec.Remove(ctgPlaceRec[categoryIDList.IndexOf(index)].ToString());
                        //ctgBuyDate.Add(BuyDate);
                        //ctgSurplusValue.Add(SurplusValue);
                        //ctgPlaceRec.Add(PlaceRec);
                        categoryIDList.Remove(index);
                        categoryIDList.Add(index);
                    }
                    catch
                    {
                    }
                }
                //if (!ctgBuyDate.Contains(BuyDate) || BuyDate.Trim() == string.Empty)
                //    ctgBuyDate.Add(BuyDate);
                //if (!ctgSurplusValue.Contains(SurplusValue) || BuyDate.Trim() == string.Empty)
                //    ctgSurplusValue.Add(SurplusValue);
            }
            else
            {
                try
                {
                    //ctgBuyDate.Remove(ctgBuyDate[categoryIDList.IndexOf(index)].ToString());
                    //ctgSurplusValue.Remove(ctgSurplusValue[categoryIDList.IndexOf(index)].ToString());
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
            //Session["Se_BuyDate"] = ctgBuyDate;
            //Session["Se_SurplusValue"] = ctgSurplusValue;
            //Session["Se_PlaceRec"] = ctgPlaceRec;
        }
    }

    private void RePopulateValues()
    {
        ArrayList categoryIDList = (ArrayList)Session["CHECKED_Scrap"];
        //ArrayList ctgBuyDate = (ArrayList)Session["Se_BuyDate"];
        //ArrayList ctgSurplusValue = (ArrayList)Session["Se_SurplusValue"];
        //ArrayList ctgPlaceRec = (ArrayList)Session["Se_PlaceRec"];
        Guid index;
        //string PlaceRec;
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            foreach (GridViewRow row in gvData.Rows)
            {
                index = (Guid)gvData.DataKeys[row.RowIndex].Value;
                if (categoryIDList.Contains(index))
                {
                    //BuyDate = ctgBuyDate[categoryIDList.IndexOf(index)].ToString();
                    //SurplusValue = ctgSurplusValue[categoryIDList.IndexOf(index)].ToString();
                    //PlaceRec = ctgPlaceRec[categoryIDList.IndexOf(index)].ToString();
                    CheckBox myCheckBox = (CheckBox)row.FindControl("ChkSelected");
                    myCheckBox.Checked = true;
                    //TextBox txtBuyDate = (TextBox)gvData.Rows[row.RowIndex].Cells[1].FindControl("txtBuyDate");
                    //txtBuyDate.Text = BuyDate;
                    //TextBox txtSurplusValue = (TextBox)gvData.Rows[row.RowIndex].Cells[2].FindControl("txtSurplusValue");
                    //txtSurplusValue.Text = SurplusValue;
                    //TextBox txtPlaceRec = (TextBox)gvData.Rows[row.RowIndex].Cells[1].FindControl("txtPlaceRec");
                    //txtPlaceRec.Text = PlaceRec;
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
        try
        {
            T_OfficeAutomation_Document_Scrap_Detail t_OfficeAutomation_Document_Scrap_Detail = new T_OfficeAutomation_Document_Scrap_Detail();
            DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
            if (Session["CHECKED_Scrap"] != null)
            {
                DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                ArrayList categoryIDList = new ArrayList();
                DataSet ds = new DataSet();
                DataSet dst = new DataSet();
                categoryIDList = (ArrayList)Session["CHECKED_Scrap"];
                //ArrayList ctgBuyDate = (ArrayList)Session["Se_BuyDate"];
                //ArrayList ctgSurplusValue = (ArrayList)Session["Se_SurplusValue"];
                //ArrayList ctgPlaceRec = (ArrayList)Session["Se_PlaceRec"];

                ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectTempByMainID(MainID);
                if (sdt == "2" && ds.Tables[0].Rows.Count == 0)
                {
                    da_OfficeAutomation_Document_Scrap_Detail_Inherit.DeleteTemp(MainID);
                    ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(MainID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_ID = Guid.NewGuid();
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_MainID = new Guid(MainID);
                        //t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTypeID = 0;
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag = dr["OfficeAutomation_Document_Scrap_Detail_AssetTag"].ToString();
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Model = dr["OfficeAutomation_Document_Scrap_Detail_Model"].ToString();
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Number = dr["OfficeAutomation_Document_Scrap_Detail_Number"].ToString();
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetName = dr["OfficeAutomation_Document_Scrap_Detail_AssetName"].ToString();
                        try
                        {
                            t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse(dr["OfficeAutomation_Document_Scrap_Detail_DpmBuyDate"].ToString());
                        }
                        catch
                        {
                            t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse("1900/1/1");
                        }
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue = dr["OfficeAutomation_Document_Scrap_Detail_SurplusValue"].ToString();
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceRec = dr["OfficeAutomation_Document_Scrap_Detail_PlaceRec"].ToString();
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID = dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString();

                        //dst = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectTempByAnother(MainID, "", t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag, "");
                        //if (dst.Tables[0].Rows.Count > 0)
                        //    da_OfficeAutomation_Document_Scrap_Detail_Inherit.DeleteTemp(MainID, t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag);
                        da_OfficeAutomation_Document_Scrap_Detail_Inherit.InsertTemporary(t_OfficeAutomation_Document_Scrap_Detail);
                    }
                }

                for (int i = 0; i < categoryIDList.Count; i++)
                {
                    ds = da_OfficeAutomation_Main_Inherit.FindAssetsByID(categoryIDList[i].ToString());

                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_ID = Guid.NewGuid();
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_MainID = new Guid(MainID);
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetName = ds.Tables[0].Rows[0]["txtClasses"].ToString().Replace("\r", "").Replace("\n", "");
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID = categoryIDList[i].ToString();
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag = ds.Tables[0].Rows[0]["Asset_AssetNo"].ToString().Replace("\r", "").Replace("\n", "");
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Number = "1";
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Model = ds.Tables[0].Rows[0]["txtTS"].ToString().Replace("\r", "").Replace("\n", "");
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse("1900/1/1");
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue = "";
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceRec = ds.Tables[0].Rows[0]["txtType"].ToString().Replace("\r", "").Replace("\n", "");

                    dst = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectTempByAnother(MainID, "", t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag, "");
                    if(dst.Tables[0].Rows.Count > 0)
                        da_OfficeAutomation_Document_Scrap_Detail_Inherit.DeleteTemp(MainID, t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag);
                    da_OfficeAutomation_Document_Scrap_Detail_Inherit.InsertTemporary(t_OfficeAutomation_Document_Scrap_Detail);
                }

                RunJS("alert('添加成功，点击“保存”或“保存修改”后系统会将相关的资产录入！');window.returnValue='AddSuccess';window.close();");
            }
            else
            {
                RunJS("alert('请重新选择资产！');history.go(-1);");
            }
            Session.Remove("CHECKED_Scrap");
            //Session.Remove("Se_BuyDate");
            //Session.Remove("Se_SurplusValue");
            //Session.Remove("Se_PlaceRec");
        }
        catch (Exception ee)
        {
            RunJS("alert('添加失败，错误原因：');window.returnValue='" + ee.Message + "';window.close();");
        }
        finally
        {
            Session.Remove("CHECKED_Scrap");
            //Session.Remove("Se_BuyDate");
            //Session.Remove("Se_SurplusValue");
            //Session.Remove("Se_PlaceRec");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session.Remove("CHECKED_Scrap");
        //Session.Remove("Se_BuyDate");
        //Session.Remove("Se_SurplusValue");
        //Session.Remove("Se_PlaceRec");
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
