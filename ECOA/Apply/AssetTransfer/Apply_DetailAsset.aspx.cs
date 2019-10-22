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

public partial class Apply_Apply_DetailAsset : BasePage
{
    public StringBuilder sbJSON = new StringBuilder();
    //public StringBuilder sbJS = new StringBuilder();
    DataSet dds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 300;
        //GetAllDepartment();
        //sdt = GetQueryString("Data");
        //string mid = GetQueryString("mainID");
        if (!IsPostBack)
        {
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
        if (txtAssetNo.Text != "" || txtClassesId.Text != "" || txtModel.Text != "")
            BindDataWithPageIndex(txtClassesId.Text, txtAssetNo.Text, txtModel.Text);
        else
            BindData();
        if(gvData.Rows.Count==0)
            RunJS("alert('没有找到的相关资产。');window.returnValue='';window.close();");
        //if (GetQueryString("EmpName") == EmployeeName || EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
        //{
        //    btnSure.Visible = true;
        //    plSearch.Visible = false;
        //}
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        //string dpm = GetQueryString("Asset_Dpm");
        //dpm = "大同路分行";
        //if(sdt == "2")
        //    ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);
        //else
        //    ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByMainID(MainID);
        //ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByMainID(MainID);
        //if (ds.Tables[0].Rows.Count == 0)
        //    ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);
        //MainID = "6EF3D8C5-A1D1-40E5-8DC8-D16757C0C4F0";
        ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByMainID(MainID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            AtInsertTemporary();
            ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByMainID(MainID);
        }
        gvData.DataSource = ds;
        gvData.DataBind();
        lbSum.Text = ds.Tables[0].Rows.Count.ToString();
    }

    private void BindDataWithPageIndex(string Id, string No, string Mod)
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        //string dpm = GetQueryString("Asset_Dpm");
        //dpm = "大同路";
        //if (sdt == "1")
        //    ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByAnother(MainID, Id, No, Mod);
        //else
        //    ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByAnother(MainID, Id, No, Mod);
        //ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByAnother(MainID, Id, No, Mod);
        //if (ds.Tables[0].Rows.Count == 0)
        //    ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByAnother(MainID, Id, No, Mod);
        ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByAnother(MainID, Id, No, Mod);
        if (ds.Tables[0].Rows.Count == 0)
        {
            AtInsertTemporary();
            ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectTempByAnother(MainID, Id, No, Mod);
        }
        gvData.DataSource = ds;
        //gvData.PageIndex = pageindex;
        gvData.DataBind();
        lbSum.Text = ds.Tables[0].Rows.Count.ToString();
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
        //ArrayList categoryIDList = new ArrayList();
        //ArrayList ctgExp = new ArrayList();
        //ArrayList ctgRec = new ArrayList();
        //ArrayList ctgPlaceRec = new ArrayList();
        //string Exp, Rec, PlaceRec;
        //string index;
        //foreach (GridViewRow row in gvData.Rows)
        //{
        //    index = gvData.DataKeys[row.RowIndex].Value.ToString();
        //    Exp = ((TextBox)gvData.Rows[row.RowIndex].Cells[1].FindControl("txtDpmExp")).Text.Trim();
        //    Rec = ((TextBox)gvData.Rows[row.RowIndex].Cells[2].FindControl("txtDpmRec")).Text.Trim();
        //    PlaceRec = ((TextBox)gvData.Rows[row.RowIndex].Cells[3].FindControl("txtPlaceRec")).Text.Trim();

        //    //bool result = ((CheckBox)row.FindControl("ChkSelected")).Checked;
        //    if (Session["CHECKED_ITEMS"] != null)
        //    {
        //        categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        //        ctgExp = (ArrayList)Session["Se_Exp"];
        //        ctgRec = (ArrayList)Session["Se_Rec"];
        //        ctgPlaceRec = (ArrayList)Session["Se_PlaceRec"];
        //    }
        //    if (!categoryIDList.Contains(index))
        //    {
        //        categoryIDList.Add(index);
        //        ctgExp.Add(Exp);
        //        ctgRec.Add(Rec);
        //        ctgPlaceRec.Add(PlaceRec);
        //    }
        //}
        //if (categoryIDList != null && categoryIDList.Count > 0)
        //{
        //    Session["CHECKED_ITEMS"] = categoryIDList;
        //    Session["Se_Exp"] = ctgExp;
        //    Session["Se_Rec"] = ctgRec;
        //    Session["Se_PlaceRec"] = ctgPlaceRec;
        //}
    }

    private void RePopulateValues()
    {
        //ArrayList categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        //ArrayList ctgExp = (ArrayList)Session["Se_Exp"];
        //ArrayList ctgRec = (ArrayList)Session["Se_Rec"];
        //ArrayList ctgPlaceRec = (ArrayList)Session["Se_PlaceRec"];
        //string index;
        //string Exp, Rec, PlaceRec;
        //if (categoryIDList != null && categoryIDList.Count > 0)
        //{
        //    foreach (GridViewRow row in gvData.Rows)
        //    {
        //        index = gvData.DataKeys[row.RowIndex].Value.ToString();
        //        if (categoryIDList.Contains(index))
        //        {
        //            Exp = ctgExp[categoryIDList.IndexOf(index)].ToString();
        //            Rec = ctgRec[categoryIDList.IndexOf(index)].ToString();
        //            PlaceRec = ctgPlaceRec[categoryIDList.IndexOf(index)].ToString();
        //            TextBox txtExp = (TextBox)gvData.Rows[row.RowIndex].Cells[1].FindControl("txtDpmExp");
        //            txtExp.Text = Exp;
        //            TextBox txtRec = (TextBox)gvData.Rows[row.RowIndex].Cells[2].FindControl("txtDpmRec");
        //            txtRec.Text = Rec;
        //            TextBox txtPlaceRec = (TextBox)gvData.Rows[row.RowIndex].Cells[3].FindControl("txtPlaceRec");
        //            txtPlaceRec.Text = PlaceRec;
        //        }
        //    }
        //}
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

        //if (txtAssetNo.Text != "" || txtClassesId.Text != "" || txtModel.Text != "")
        //    BindDataWithPageIndex(txtClassesId.Text, txtAssetNo.Text, txtModel.Text);
        //else
        //    BindData();
        LoadPage();

        RePopulateValues();
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        RememberOldValues();
        try
        {
            T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
            DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
            if (Session["CHECKED_ITEMS"] != null)
            {
                DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                ArrayList categoryIDList = new ArrayList();
                DataSet ds = new DataSet();
                categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
                ArrayList ctgExp = (ArrayList)Session["Se_Exp"];
                ArrayList ctgRec = (ArrayList)Session["Se_Rec"];
                ArrayList ctgPlaceRec = (ArrayList)Session["Se_PlaceRec"];
                string index;

                da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.DeleteTemp(MainID);
                if (categoryIDList != null && categoryIDList.Count > 0)
                {
                    foreach (GridViewRow row in gvData.Rows)
                    {
                        index = gvData.DataKeys[row.RowIndex].Value.ToString();
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = new Guid(MainID);
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = gvData.Rows[row.RowIndex].Cells[5].Text.Trim();
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = "";
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = gvData.Rows[row.RowIndex].Cells[4].Text.Trim();
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = gvData.Rows[row.RowIndex].Cells[6].Text.Trim();
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = gvData.Rows[row.RowIndex].Cells[7].Text.Trim();
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = ctgExp[categoryIDList.IndexOf(index)].ToString();
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = ctgRec[categoryIDList.IndexOf(index)].ToString();
                        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = ctgPlaceRec[categoryIDList.IndexOf(index)].ToString();
                        
                        da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.InsertTemporary(t_OfficeAutomation_Document_AssetTransfer_Detail);
                    }
                }
                //for (int i = 0; i < categoryIDList.Count; i++)
                //{
                //    ds = da_OfficeAutomation_Main_Inherit.FindAssetsByID(categoryIDList[i].ToString());

                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = new Guid(MainID);
                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = ds.Tables[0].Rows[0]["txtClasses"].ToString().Replace("\r", "").Replace("\n", "");
                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = "";
                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = ds.Tables[0].Rows[0]["Asset_AssetNo"].ToString().Replace("\r", "").Replace("\n", "");
                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = "1";
                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = ds.Tables[0].Rows[0]["txtTS"].ToString().Replace("\r", "").Replace("\n", "");
                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = ctgExp[i].ToString();
                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = ctgRec[i].ToString();
                //    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = ctgPlaceRec[i].ToString();

                //    da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.InsertTemporary(t_OfficeAutomation_Document_AssetTransfer_Detail);
                //}
                RunJS("alert('已修改，点击“保存”或“保存修改”后系统会将相关的资产录入！');window.returnValue='alterSuccess';window.close();");
            }
            else
            {
                Session.Remove("CHECKED_ITEMS");
                Session.Remove("Se_Exp");
                Session.Remove("Se_Rec");
                Session.Remove("Se_PlaceRec");
                RunJS("alert('请重新选择资产！');history.go(-1);");
            }
        }
        catch (Exception ee)
        {
            RunJS("alert('修改失败，错误原因：');window.returnValue='" + ee.Message + "';");
        }
        finally
        {
            Session.Remove("CHECKED_ITEMS");
            Session.Remove("Se_Exp");
            Session.Remove("Se_Rec");
            Session.Remove("Se_PlaceRec");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //Session.Remove("CHECKED_ITEMS");
        //Session.Remove("Se_Exp");
        //Session.Remove("Se_Rec");
        //Session.Remove("Se_PlaceRec");
        if (txtAssetNo.Text != "" || txtClassesId.Text != "" || txtModel.Text != "")
        {
            txtAssetNo.Text = "";
            txtClassesId.Text = "";
            txtModel.Text = "";
            LoadPage();
        }
        else
            RunJS("window.returnValue='';window.close();");
    }
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if (e.Row.Cells[1].Text.Contains("详见附件"))
            //{
            //    e.Row.Cells[1].Font.Bold = true;
            //    e.Row.Cells[1].Font.Size = 14;
            //    e.Row.Cells[2].Font.Bold = true;
            //    e.Row.Cells[2].Font.Size = 14;
            //    e.Row.Cells[3].Font.Bold = true;
            //    e.Row.Cells[3].Font.Size = 14;
            //}
        }
    }

    protected void AtInsertTemporary()
    {
        T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = new Guid(MainID);
            //t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetTag"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = dr["OfficeAutomation_Document_AssetTransfer_Detail_Model"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = dr["OfficeAutomation_Document_AssetTransfer_Detail_Number"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetName"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmExp"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = dr["OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = dr["OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString();

            da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.InsertTemporary(t_OfficeAutomation_Document_AssetTransfer_Detail);
        }
    }
    protected void gvData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (GetQueryString("EmpName") != EmployeeName && EmployeeName != CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME)
        {
            this.gvData.Columns[0].Visible = false;
        }
    }
    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        string cs = e.CommandName.ToString();
        switch (cs)
        {
            case "Del":
                da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.DeleteTempByID(e.CommandArgument.ToString());
                break;
        }

        if (this.gvData.PageIndex + 1 > this.gvData.PageCount)
        {
            this.gvData.PageIndex = this.gvData.PageCount - 1;
        }
        txtAssetNo.Text = "";
        txtClassesId.Text = "";
        txtModel.Text = "";
        BindData();
    }
}
