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
    public StringBuilder SbJs = new StringBuilder();
    DataSet dds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 300;
        //GetAllDepartment();
        //sdt = GetQueryString("Data");
        //string mid = GetQueryString("mainID");
        if (!IsPostBack)
        {
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            //string flowState = da_OfficeAutomation_Main_Inherit.GetFlowState(MainID);
            //if(flowState != "3" && GetQueryString("EmpName") == EmployeeName)
            //    this.btnSure.Visible = true;
            if (GetQueryString("Data") == "2" && (EmployeeName == CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME || EmployeeName == CommonConst.EMP_FINANCE_OPERATOR_NAME))
                this.btnSure.Visible = true;
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
        SbJs.Append("$(\"[id*=_txtBuyDate]\").datepicker();");
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
        RememberOldValues();

        DataSet ds = new DataSet();
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        string dpm = GetQueryString("Asset_Dpm");
        //dpm = "大同路分行"; MainID = "ACC0A2C6-6D56-44BD-BE25-69ADD6F86FCC";
        ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectTempTAsByMainID(MainID, dpm);
        if (ds.Tables[0].Rows.Count == 0)
        {
            AtInsertTemporary();
            ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectTempTAsByMainID(MainID, dpm);
        }
        gvData.DataSource = ds;
        gvData.DataBind();
        lbSum.Text = ds.Tables[0].Rows.Count.ToString();

        float f = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
            try
            {
                f += float.Parse(dr["OfficeAutomation_Document_Scrap_Detail_SurplusValue"].ToString());
            }
            catch
            {
                f += 0;
            }
        if(f != 0)
            lbSumFear.Text = "合共剩值：" + f.ToString() + "元";

        RePopulateValues();
    }

    private void BindDataWithPageIndex(string Id, string No, string Mod)
    {
        RememberOldValues();

        DataSet ds = new DataSet();
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        string dpm = GetQueryString("Asset_Dpm");
        //dpm = "大同路"; MainID = "ACC0A2C6-6D56-44BD-BE25-69ADD6F86FCC";
        ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectTempTAsdByAnother(MainID, dpm, Id, No, Mod);
        if (ds.Tables[0].Rows.Count == 0)
        {
            AtInsertTemporary();
            ds = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectTempTAsdByAnother(MainID, dpm, Id, No, Mod);
        }
        gvData.DataSource = ds;
        //gvData.PageIndex = pageindex;
        gvData.DataBind();
        lbSum.Text = ds.Tables[0].Rows.Count.ToString();
        RePopulateValues();
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
        ArrayList ctgBuyDate = new ArrayList();
        ArrayList ctgSurplusValue = new ArrayList();
        //ArrayList ctgPlaceRec = new ArrayList();
        string BuyDate, SurplusValue;
        string index;
        foreach (GridViewRow row in gvData.Rows)
        {
            index = gvData.DataKeys[row.RowIndex].Value.ToString();
            BuyDate = ((TextBox)gvData.Rows[row.RowIndex].Cells[7].FindControl("txtBuyDate")).Text.Trim();
            SurplusValue = ((TextBox)gvData.Rows[row.RowIndex].Cells[8].FindControl("txtSurplusValue")).Text.Trim();
            //PlaceRec = ((TextBox)gvData.Rows[row.RowIndex].Cells[3].FindControl("txtPlaceRec")).Text.Trim();

            //bool result = ((CheckBox)row.FindControl("ChkSelected")).Checked;
            if (Session["CHECKED_ASSNO"] != null)
            {
                categoryIDList = (ArrayList)Session["CHECKED_ASSNO"];
                ctgBuyDate = (ArrayList)Session["Se_BuyDate"];
                ctgSurplusValue = (ArrayList)Session["Se_SurplusValue"];
                //ctgPlaceRec = (ArrayList)Session["Se_PlaceRec"];
            }
            if (!categoryIDList.Contains(index))
            {
                categoryIDList.Add(index);
                ctgBuyDate.Add(BuyDate);
                ctgSurplusValue.Add(SurplusValue);
                //ctgPlaceRec.Add(PlaceRec);
            }
            else
            {
                try
                {
                    ctgBuyDate.Remove(ctgBuyDate[categoryIDList.IndexOf(index)].ToString());
                    ctgBuyDate.Add(BuyDate);
                    ctgSurplusValue.Remove(ctgSurplusValue[categoryIDList.IndexOf(index)].ToString());
                    ctgSurplusValue.Add(SurplusValue);
                    categoryIDList.Remove(index);
                    categoryIDList.Add(index);
                }
                catch
                {
                }
            }
        }
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            Session["CHECKED_ASSNO"] = categoryIDList;
            Session["Se_BuyDate"] = ctgBuyDate;
            Session["Se_SurplusValue"] = ctgSurplusValue;
            //Session["Se_PlaceRec"] = ctgPlaceRec;
        }
    }

    private void RePopulateValues()
    {
        ArrayList categoryIDList = (ArrayList)Session["CHECKED_ASSNO"];
        ArrayList ctgBuyDate = (ArrayList)Session["Se_BuyDate"];
        ArrayList ctgSurplusValue = (ArrayList)Session["Se_SurplusValue"];
        //ArrayList ctgPlaceRec = (ArrayList)Session["Se_PlaceRec"];
        string index;
        string BuyDate, SurplusValue;
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            foreach (GridViewRow row in gvData.Rows)
            {
                index = gvData.DataKeys[row.RowIndex].Value.ToString();
                if (categoryIDList.Contains(index))
                {
                    BuyDate = ctgBuyDate[categoryIDList.IndexOf(index)].ToString();
                    SurplusValue = ctgSurplusValue[categoryIDList.IndexOf(index)].ToString();
                    //PlaceRec = ctgPlaceRec[categoryIDList.IndexOf(index)].ToString();
                    TextBox txtBuyDate = (TextBox)gvData.Rows[row.RowIndex].Cells[7].FindControl("txtBuyDate");
                    txtBuyDate.Text = BuyDate;
                    TextBox txtSurplusValue = (TextBox)gvData.Rows[row.RowIndex].Cells[8].FindControl("txtSurplusValue");
                    txtSurplusValue.Text = SurplusValue;
                    //TextBox txtPlaceRec = (TextBox)gvData.Rows[row.RowIndex].Cells[3].FindControl("txtPlaceRec");
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

        //if (txtAssetNo.Text != "" || txtClassesId.Text != "" || txtModel.Text != "")
        //    BindDataWithPageIndex(txtClassesId.Text, txtAssetNo.Text, txtModel.Text);
        //else
        //    BindData();
        LoadPage();

        //RePopulateValues();
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        RememberOldValues();
        try
        {
            T_OfficeAutomation_Document_Scrap_Detail t_OfficeAutomation_Document_Scrap_Detail = new T_OfficeAutomation_Document_Scrap_Detail();
            DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
            if (Session["CHECKED_ASSNO"] != null)
            {
                DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                ArrayList categoryIDList = new ArrayList();
                DataSet ds = new DataSet();
                categoryIDList = (ArrayList)Session["CHECKED_ASSNO"];
                ArrayList ctgBuyDate = (ArrayList)Session["Se_BuyDate"];
                ArrayList ctgSurplusValue = (ArrayList)Session["Se_SurplusValue"];
                //ArrayList ctgPlaceRec = (ArrayList)Session["Se_PlaceRec"];
                string index;

                //da_OfficeAutomation_Document_Scrap_Detail_Inherit.DeleteTemp(MainID);
                if (categoryIDList != null && categoryIDList.Count > 0)
                {
                    for (int i = 0; i < categoryIDList.Count; i++)
                    {
                        index = categoryIDList[i].ToString();
                        //t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_ID = Guid.NewGuid();
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_MainID = new Guid(MainID);
                        //t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetName = gvData.Rows[row.RowIndex].Cells[4].Text.Trim();
                        //t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID = gvData.Rows[row.RowIndex].Cells[9].Text.Trim();
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag = index;
                        //t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Number = "1";
                        //t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Model = gvData.Rows[row.RowIndex].Cells[6].Text.Trim();

                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = string.IsNullOrEmpty(ctgBuyDate[categoryIDList.IndexOf(index)].ToString()) ? DateTime.Parse("1900/1/1") : DateTime.Parse(ctgBuyDate[categoryIDList.IndexOf(index)].ToString());
                        //try
                        //{
                        //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse(ctgBuyDate[categoryIDList.IndexOf(index)].ToString());
                        //}
                        //catch
                        //{
                        //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse("1900/1/1");
                        //}
                        t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue = ctgSurplusValue[categoryIDList.IndexOf(index)].ToString();
                        //t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceRec = gvData.Rows[row.RowIndex].Cells[5].Text.Trim();
                        da_OfficeAutomation_Document_Scrap_Detail_Inherit.UpdateTemp(t_OfficeAutomation_Document_Scrap_Detail);
                    }
                }
                da_OfficeAutomation_Document_Scrap_Detail_Inherit.UpdateDetail(MainID);

                //for (int i = 0; i < categoryIDList.Count; i++)
                //{
                //    ds = da_OfficeAutomation_Main_Inherit.FindAssetsByID(categoryIDList[i].ToString());

                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_ID = Guid.NewGuid();
                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_MainID = new Guid(MainID);
                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetName = ds.Tables[0].Rows[0]["txtClasses"].ToString().Replace("\r", "").Replace("\n", "");
                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID = "";
                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag = ds.Tables[0].Rows[0]["Asset_AssetNo"].ToString().Replace("\r", "").Replace("\n", "");
                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Number = "1";
                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Model = ds.Tables[0].Rows[0]["txtTS"].ToString().Replace("\r", "").Replace("\n", "");
                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_DpmBuyDate = ctgBuyDate[i].ToString();
                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_DpmSurplusValue = ctgSurplusValue[i].ToString();
                //    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceRec = ctgPlaceRec[i].ToString();

                //    da_OfficeAutomation_Document_Scrap_Detail_Inherit.InsertTemporary(t_OfficeAutomation_Document_Scrap_Detail);
                //}
                RunJS("alert('修改成功，点击“保存”或“签名”后系统会更新相关的数据！');window.returnValue='alterSuccess';window.close();");
            }
            else
            {
                Session.Remove("CHECKED_ASSNO");
                Session.Remove("Se_BuyDate");
                Session.Remove("Se_SurplusValue");
                //Session.Remove("Se_PlaceRec");
                RunJS("alert('请重新选择资产！');history.go(-1);");
            }
        }
        catch (Exception ee)
        {
            RunJS("alert('保存失败，错误原因：" + ee.Message + "');window.returnValue='" + ee.Message + "';");
        }
        finally
        {
            Session.Remove("CHECKED_ASSNO");
            Session.Remove("Se_BuyDate");
            Session.Remove("Se_SurplusValue");
            //Session.Remove("Se_PlaceRec");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //if (GetQueryString("Data") == "2")
        //{
        //    DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        //    da_OfficeAutomation_Document_Scrap_Detail_Inherit.DeleteTemp(MainID);
        //}
        Session.Remove("CHECKED_ASSNO");
        Session.Remove("Se_BuyDate");
        Session.Remove("Se_SurplusValue");
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
            //DateTime.Parse(((TextBox)gvData.Rows[e.Row.RowIndex].Cells[7].FindControl("txtBuyDate")).Text).ToString("yyyy-MM-dd");
            TextBox tb = (TextBox)e.Row.Cells[7].FindControl("txtBuyDate");
            if (tb.Text == "1900/1/1 0:00:00")
                tb.Text = "";
            else
                tb.Text = DateTime.Parse(tb.Text).ToString("yyyy-MM-dd");
            e.Row.Cells[7].Attributes.Add("onmouseover", "$(\"[id*=_txtBuyDate]\").datepicker();");
            //e.Row.Attributes.Add("onmouseover", "javascript:c=this.style.backgroundColor;this.style.background='#B0E0E6';");
        }
    }

    protected void AtInsertTemporary()
    {
        T_OfficeAutomation_Document_Scrap_Detail t_OfficeAutomation_Document_Scrap_Detail = new T_OfficeAutomation_Document_Scrap_Detail();
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        DataSet ds = new DataSet();
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
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse(dr["OfficeAutomation_Document_Scrap_Detail_BuyDate"].ToString());
            }
            catch
            {
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse("1900/1/1");
            }
            t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue = dr["OfficeAutomation_Document_Scrap_Detail_SurplusValue"].ToString();
            t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceRec = dr["OfficeAutomation_Document_Scrap_Detail_PlaceRec"].ToString();
            t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID = dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString();

            da_OfficeAutomation_Document_Scrap_Detail_Inherit.InsertTemporary(t_OfficeAutomation_Document_Scrap_Detail);
        }
    }
    protected void gvData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (GetQueryString("EmpName") != EmployeeName && EmployeeName != CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME && EmployeeName != CommonConst.EMP_FINANCE_OPERATOR_NAME)
            this.gvData.Columns[0].Visible = false;
        this.gvData.Columns[9].Visible = false;
    }
    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        ArrayList categoryIDList  = (ArrayList)Session["CHECKED_ASSNO"];
        ArrayList ctgBuyDate = (ArrayList)Session["Se_BuyDate"];
        ArrayList ctgSurplusValue = (ArrayList)Session["Se_SurplusValue"];
        string cs = e.CommandName.ToString();

        switch (cs)
        {
            case "Del":
                try
                {
                    ctgBuyDate.Remove(ctgBuyDate[categoryIDList.IndexOf(e.CommandArgument.ToString())].ToString());
                    ctgSurplusValue.Remove(ctgSurplusValue[categoryIDList.IndexOf(e.CommandArgument.ToString())].ToString());
                    categoryIDList.Remove(e.CommandArgument.ToString());
                    Session["CHECKED_ASSNO"] = categoryIDList;
                    Session["Se_BuyDate"] = ctgBuyDate;
                    Session["Se_SurplusValue"] = ctgSurplusValue;
                }
                catch
                {
                }
                da_OfficeAutomation_Document_Scrap_Detail_Inherit.DeleteTemp(MainID, e.CommandArgument.ToString());
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
