using DataAccess.Operate;
using DataEntity;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Apply_AssetTransfer_AssetTransfer_Apply_Asset : BasePage
{
    public StringBuilder sbJSON = new StringBuilder();
    public StringBuilder placeJSON = new StringBuilder();
    public StringBuilder AssetJSON = new StringBuilder();

    string applyer = "";
    string SerialNumber = "";
    List<T_OfficeAutomation_Document_AssetTransfer_Detail> list = null;
    //public StringBuilder sbJS = new StringBuilder();
    string[] admins = { "陈秀球", "源浩灵", "曹雄", "周松伟", "梁锐华", "王燕波", "苏志明", "潘柏廉", "周志维", "许贵治", "何学峰" };
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 300;
        GetAllDepartment();
        GetAssetPlace();
        GetAssetName();
        //   string s = GetQueryString("Asset_Dpm");
        string mid = GetQueryString("mainID");
        DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        DataSet dsAssetTransfer = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
        if (Mainobj == null)
        {
            RunJS("alert('操作有误！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
        applyer = Mainobj.OfficeAutomation_Main_Apply;
        //如果已经保存不能再修改
        if (Mainobj.OfficeAutomation_Main_FlowStateID != 7 && Mainobj.OfficeAutomation_Main_FlowStateID != 1)
        {
           // this.btnSava_.Visible = false;
            this.btnAgain.Visible = false;
            this.btnDel.Visible = false;
            selectdiv.Style.Add("btnaddview", "none");
        }
        if (Mainobj.OfficeAutomation_Main_FlowStateID != 3 && (EmployeeName == "陈秀球" || EmployeeName == "曹雄"))
        {
           // this.btnSava_.Visible = true;
            this.btnAgain.Visible = true;
            this.btnDel.Visible = true;
            selectdiv.Style.Add("btnaddview", "block");
        }
        if (Mainobj.OfficeAutomation_Main_FlowStateID == 3) {

            this.btnSava_.Visible = false;
        }

        //只有开发者和陈秀球可以修改选中部门
        if (EmployeeName != "陈秀球" && EmployeeName != "曹雄") {
            this.txtDept.Enabled = false;
        }
        //if ((Mainobj.OfficeAutomation_Main_Creater == EmployeeName || EmployeeName == "陈秀球" || EmployeeName == "曹雄") && Mainobj.OfficeAutomation_Main_FlowStateID != 3 && Mainobj.OfficeAutomation_Main_FlowStateID != 7)
        //{
        //    this.btnSavaDpt.Visible = true;
        //}
        if (applyer != EmployeeName &&!admins.Contains(EmployeeName))
        {

            this.btnSava_.Visible = false;
            this.btnAgain.Visible = false;
            this.btnDel.Visible = false;
            selectdiv.Style.Add("btnaddview", "none");
        }
        if (admins.Contains(EmployeeName)) {

            this.btnExport.Visible = true;
        }
        ViewState["Asset_Dpm"] = dsAssetTransfer.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ExportDepartment"].ToString();
        SerialNumber = Mainobj.OfficeAutomation_SerialNumber;
        this.txtDept.Text = this.txtDept.Text == "" ? ViewState["Asset_Dpm"].ToString() : this.txtDept.Text;
        if (!IsPostBack)
        {
            try
            {
                
                DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                DataSet dsDetail = new DataSet();
                dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(mid);
                if (!ViewState["Asset_Dpm"].ToString().Contains("仓库"))
                {
                    if (dsDetail.Tables[0].Rows.Count > 0)
                    {
                        List<T_OfficeAutomation_Document_AssetTransfer_Detail> tdlist = ECOA.Common.OTConverter.ConvertTableToObject<T_OfficeAutomation_Document_AssetTransfer_Detail>(dsDetail.Tables[0]);
                      
                        ArrayList categoryIDList = new ArrayList();
                        foreach (var item in tdlist)
                        {
                            //wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                            //ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                            categoryIDList.Add(new Guid(item.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID));


                        }
                        if (categoryIDList != null && categoryIDList.Count > 0)
                        {
                            Session["CHECKED_ITEMS"] = categoryIDList;
                            ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(tdlist);
                        }
                        resultdiv.Style.Add("display", "block");
                        selectdiv.Style.Add("display", "none");
                        EditDataBindData();
                        //btnSure_Click(null, null);
                    }
                    else
                    {
                        LoadPage();
                    }
                    btnaddview.Style.Add("display", "none");
                }
                else 
                {
                    if (dsDetail.Tables[0].Rows.Count > 0)
                    {
                        List<T_OfficeAutomation_Document_AssetTransfer_Detail> tdlist = ECOA.Common.OTConverter.ConvertTableToObject<T_OfficeAutomation_Document_AssetTransfer_Detail>(dsDetail.Tables[0]);
                        ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(tdlist);
                        EditDataBindData();
                    }
                    this.btnAgain.Visible = false;
                    resultdiv.Style.Add("display", "block");
                    selectdiv.Style.Add("display", "none");

                }
            }
            catch
            {
            }

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
    /// 存放地点
    /// </summary>
    public void GetAssetPlace()
    {
        try
        {
            wsAsset.GetAssetDic service = new wsAsset.GetAssetDic();
            string s = service.GetKeyValue("place", "").Replace("Dic_Assets_Id", "id").Replace("Dic_Assets_Text", "value");
            if (string.IsNullOrEmpty(s))
                s = "[]";
            placeJSON.Append(s);
        }
        catch
        {
            placeJSON.Append("[]");
        }
    }

    /// <summary>
    /// 资产名称
    /// </summary>
    public void GetAssetName()
    {
        try
        {
            wsAsset.GetAssetDic service = new wsAsset.GetAssetDic();
            string s = service.GetKeyValue("Classes", "").Replace("Dic_Assets_Id", "id").Replace("Dic_Assets_Text", "value");
            if (string.IsNullOrEmpty(s))
                s = "[]";
            AssetJSON.Append(s);
        }
        catch
        {
            AssetJSON.Append("[]");
        }
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    private void InitPage()
    {

    }
    /// <summary>
    ///显示已隐藏
    /// </summary>
    private void EditDataColuDisplay()
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
     //   string dpm = ViewState["Asset_Dpm"].ToString();

        string dpm = this.txtDept.Text;
        // dpm = "行政部";
        ds = da_OfficeAutomation_Main_Inherit.SelectAssets(dpm, "", "", "", "");
        gvData.DataSource = ds;
        gvData.DataBind();
    }

    private void BindDataWithPageIndex(string No, string Id, string St, string Et)
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
       // string dpm = ViewState["Asset_Dpm"].ToString();
        string dpm = this.txtDept.Text;
        // dpm = "大同路";
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


    /// <summary>
    /// 确定选取
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSure_Click(object sender, EventArgs e)
    {
        list = new List<T_OfficeAutomation_Document_AssetTransfer_Detail>();

        List<T_OfficeAutomation_Document_AssetTransfer_Detail> oldlist = new List<T_OfficeAutomation_Document_AssetTransfer_Detail>();
        if (ViewState["list"] != null && ViewState["list"].ToString() != "")
        {
            oldlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        }
        RememberOldValues();
        if (Session["CHECKED_ITEMS"] != null)
        {
            DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            ArrayList categoryIDList = new ArrayList();
            DataSet ds = new DataSet();
            DataSet dsAssetTransfer = new DataSet();
            string st = null, rt = null;
            categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
            dsAssetTransfer = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);
            for (int i = 0; i < categoryIDList.Count; i++)
            {


                ds = da_OfficeAutomation_Main_Inherit.FindAssetsByID(categoryIDList[i].ToString());
                T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = new Guid(dsAssetTransfer.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ID"].ToString());
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = ds.Tables[0].Rows[0]["Asset_AssetNo"].ToString().Replace("\r", "").Replace("\n", "");
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = ds.Tables[0].Rows[0]["txtTS"].ToString().Replace("\r", "").Replace("\n", "");
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = "1";
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = ds.Tables[0].Rows[0]["txtClasses"].ToString().Replace("\r", "").Replace("\n", "");
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = categoryIDList[i].ToString();


                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp = ds.Tables[0].Rows[0]["txtPlace"].ToString();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = ds.Tables[0].Rows[0]["txtDepartment"].ToString();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = dsAssetTransfer.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ImportDepartment"].ToString();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = dsAssetTransfer.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ImportPlace"].ToString();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_CreateTime = DateTime.Now;
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_TxtType = ds.Tables[0].Rows[0]["txtType"].ToString().Replace("\r", "").Replace("\n", "");
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_CV = ds.Tables[0].Rows[0]["cv"].ToString();
                T_OfficeAutomation_Document_AssetTransfer_Detail oldt_OfficeAutomation_Document_AssetTransfer_Detail = null;
                    oldt_OfficeAutomation_Document_AssetTransfer_Detail = oldlist.Where(p => p.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID == t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID).FirstOrDefault();
                    if (oldt_OfficeAutomation_Document_AssetTransfer_Detail != null)
                {

                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = oldt_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec;
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = oldt_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec;
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_CreateTime = oldt_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_CreateTime;
                }

                list.Add(t_OfficeAutomation_Document_AssetTransfer_Detail);


            }
            ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            EditDataBindData();
            resultdiv.Style.Add("display", "block");
            selectdiv.Style.Add("display", "none");
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
      //  RunJS("window.location.href=\"/Apply/AssetTransfer/New/Apply_AssetTransfer_Detail.aspx?mainID=" + MainID + "\";");

        string sUrl = "/Apply/AssetTransfer/New/Apply_AssetTransfer_Detail.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
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

    /// <summary>
    /// EditData绑定数据
    /// </summary>
    public void EditDataBindData()
    {
        if (ViewState["list"] != "")
        {
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
            list = list.OrderBy(p => p.OfficeAutomation_Document_AssetTransfer_Detail_AssetName).ThenBy(P => P.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag).ToList();
        }
        EditData.DataSource = list;
        EditData.DataBind();
      
    }

    /// <summary>
    /// EditData页码改变事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void EditData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

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

        bool b = UpadateList();
        if (b == false)
            return;
        EditDataBindData();


    }

    /// <summary>
    /// 更新当前显示的调动资产信息
    /// </summary>
    /// <returns></returns>
    public bool UpadateList()
    {

        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        foreach (GridViewRow row in EditData.Rows)
        {
            Guid index = (Guid)EditData.DataKeys[row.RowIndex].Value;
            T_OfficeAutomation_Document_AssetTransfer_Detail model = list.Where(p => p.OfficeAutomation_Document_AssetTransfer_Detail_ID == index).FirstOrDefault();


            string DpmRe = ((TextBox)row.Cells[8].FindControl("DpmRe")).Text;
            string PlaceRec = ((TextBox)row.Cells[8].FindControl("PlaceRec")).Text;
            string AssetName = ((TextBox)row.Cells[8].FindControl("AssetName")).Text;
            string DetailModel = ((TextBox)row.Cells[8].FindControl("DetailModel")).Text;
            string txtType = ((TextBox)row.Cells[8].FindControl("txtType")).Text;
            if (model != null)
            {
               
                model.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = DpmRe;
                model.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = PlaceRec;
                model.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = AssetName;
                model.OfficeAutomation_Document_AssetTransfer_Detail_Model = DetailModel;
                model.OfficeAutomation_Document_AssetTransfer_Detail_TxtType = txtType;
            }


        }
        ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(list);
        return true;
    }


    /// <summary>
    /// 重选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAgain_Click(object sender, EventArgs e)
    {
        ArrayList categoryIDList = new ArrayList();
        bool b = UpadateList();
        if (b == false)
            return;
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        foreach (var item in list)
        {
            categoryIDList.Add(new Guid(item.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID));
        }
        if (categoryIDList != null && categoryIDList.Count > 0)
            Session["CHECKED_ITEMS"] = categoryIDList;
        resultdiv.Style.Add("display", "none");
        selectdiv.Style.Add("display", "block");
        BindData();
        RePopulateValues();
    }









    //
    protected void btnSava_Click(object sender, EventArgs e)
    {
        string msg = "";
        UpadateList();
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
       
     //   DataSet ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
     //   Guid id = new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString());

      
        DataSet dsDetail = new DataSet();
        string mid = GetQueryString("mainID");
        dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(mid);
      

        List<T_OfficeAutomation_Document_AssetTransfer_Detail> tdlist = ECOA.Common.OTConverter.ConvertTableToObject<T_OfficeAutomation_Document_AssetTransfer_Detail>(dsDetail.Tables[0]);
       List<ValueAndId>  places=   JsonConvert.DeserializeObject<List<ValueAndId>>(placeJSON.ToString());
     
        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();

        foreach (var item in tdlist)
        {
            bool b = ws.AssetAdjustmentReject(item.OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID.ToString());
            da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.DeleteByID(item.OfficeAutomation_Document_AssetTransfer_Detail_ID.ToString());
        }

        foreach (var item in list)
        {
           // var model = tdlist.Where(p => p.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID == item.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID).FirstOrDefault();


           // item.OfficeAutomation_Document_AssetTransfer_Detail_MainID = id;
            //if (model != null)
            //{
            //    item.OfficeAutomation_Document_AssetTransfer_Detail_ID = model.OfficeAutomation_Document_AssetTransfer_Detail_ID;
            //    da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Update(item);
            //}
            //else
            //{
            int placeid = 0;
            try
            {
                 placeid = places.Where(p => p.value == item.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec).First().id;
            }
            catch {
                msg = item.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag + "存放地点有误！";
                Alert("alert('保存失败！" + msg + "')");
                return;
            }

            if (item.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID!="")
            {
                string t = ws.AdjustmentWithEcoaCode(item.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag, placeid, 1, item.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec, DateTime.Now.ToString(), 1, SerialNumber); //锁定资产
            if (t.Contains("*"))
                msg = msg + item.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag + t.Replace("*", string.Empty) + ".";
            else
                item.OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID = new Guid(t);
                if (!string.IsNullOrEmpty(msg))
                {
                    RunJS("alert('保存失败！" + msg + "')");
                    return;
                }
            }
                da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Insert(item);

           // }
             
          //  tdlist.Remove(model);
        }
        if (!string.IsNullOrEmpty(msg))
        {
            RunJS("alert('保存失败！" + msg + "')");
            return;
        }
        //foreach (var item in tdlist)
        //{
        //    // ws.AssetAdjustmentReject(item.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID);
        //    da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.DeleteByID(item.OfficeAutomation_Document_AssetTransfer_Detail_ID.ToString());
        //}


      //  RunJS("alert('保存成功！'); window.returnValue='';window.close();");
        string sUrl = "/Apply/AssetTransfer/New/Apply_AssetTransfer_Detail.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
        // Alert(msg);
    }

    protected void btnSavaDpt_Click(object sender, EventArgs e)
    {
        string msg = "";
        UpadateList();
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();

 
        DataSet dsDetail = new DataSet();
        string mid = GetQueryString("mainID");
        dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(mid);


        List<T_OfficeAutomation_Document_AssetTransfer_Detail> tdlist = ECOA.Common.OTConverter.ConvertTableToObject<T_OfficeAutomation_Document_AssetTransfer_Detail>(dsDetail.Tables[0]);
      

 
        foreach (var item in list)
        {
             var model = tdlist.Where(p => p.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID == item.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID).FirstOrDefault();



             if (model != null)
             {
                 item.OfficeAutomation_Document_AssetTransfer_Detail_ID = model.OfficeAutomation_Document_AssetTransfer_Detail_ID;
                 da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Update(item);
             }
             
           
            

          
        }
       

        string sUrl = "/Apply/AssetTransfer/New/Apply_AssetTransfer_Detail.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
      
    }

    /*
    #region 导出列表
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportExcel();
    }


    public void ExportExcel()
    {
        DataTable myDataTable = new DataTable("Excel");
        DataColumn myDataColumn;
        DataRow myDataRow;


        myDataColumn = new DataColumn("资产ID");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("使用部门");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("存放地点");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("资产名称");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("财务编号");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("规格型号");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("购买时间");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("折旧摊分剩余费用");
        myDataTable.Columns.Add(myDataColumn);
        myDataColumn = new DataColumn("备注");
        myDataTable.Columns.Add(myDataColumn);
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        foreach (var item in list)
        {
            myDataRow = myDataTable.NewRow();
            myDataRow["资产ID"] = item.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID;
            myDataRow["使用部门"] = item.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp;
            myDataRow["存放地点"] = item.OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp;
            myDataRow["资产名称"] = item.OfficeAutomation_Document_AssetTransfer_Detail_AssetName;
            myDataRow["财务编号"] = item.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag;
            myDataRow["规格型号"] = item.OfficeAutomation_Document_AssetTransfer_Detail_Model;
            myDataRow["购买时间"] = item.OfficeAutomation_Document_AssetTransfer_Detail_BuyDate != null ? ((DateTime)item.OfficeAutomation_Document_AssetTransfer_Detail_BuyDate).ToString("yyyy-MM-dd") : "";
            myDataRow["折旧摊分剩余费用"] = item.OfficeAutomation_Document_AssetTransfer_Detail_Cost;
            myDataRow["备注"] = item.OfficeAutomation_Document_AssetTransfer_Detail_SurplusValue;
            myDataTable.Rows.Add(myDataRow);
        }
        this.ExportToExcel(myDataTable, "List" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".xls");
    }



    /// <summary> 
    /// 将datatable中的数据导出到指定的excel文件中 
    /// </summary> 
    /// <param name="page">web页面对象</param> 
    /// <param name="tab">包含被导出数据的datatable对象</param> 
    /// <param name="filename">excel文件的名称</param> 
    public void ExportToExcel(System.Data.DataTable tab, string filename)
    {


        System.Web.UI.WebControls.DataGrid datagrid = new DataGrid();
        datagrid.DataSource = tab.DefaultView;
        datagrid.AllowPaging = false;
        datagrid.HeaderStyle.BackColor = System.Drawing.Color.White;
        datagrid.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        datagrid.HeaderStyle.Font.Bold = true;

        datagrid.DataBind();

        this.Response.AppendHeader("content-disposition", "inline;attachment;filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8)); //filename="*.xls"; 
        this.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        // this.Response.Charset = "gb2312";  
        this.Response.ContentType = "application/vnd.ms-excel";
        System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);
        System.IO.StringWriter tw = new StringWriter(myCItrad);

        System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(tw);

        datagrid.RenderControl(hw);
        tw.Close();
        hw.Close();
        GC.Collect();
        this.Response.Write("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=gb2312\"/>" + tw.ToString());
        this.Response.End();
    }


    #endregion


    # region 导入修改信息
    protected void BtnImport_Click(object sender, System.EventArgs e)
    {
        string filename = string.Empty;
        try
        {
            filename = UpLoadXls(FileExcel);//上传XLS文件
            ImportXlsToData(filename);//将XLS文件的数据导入数据库                
            if (filename != string.Empty && System.IO.File.Exists(filename))
            {
                System.IO.File.Delete(filename);//删除上传的XLS文件
            }
            LblMessage.Text = "数据导入成功！";
        }
        catch (Exception ex)
        {
            LblMessage.Text = ex.Message;
        }
    }


    /// <summary>
    /// 上传Excel文件
    /// </summary>
    /// <param name="inputfile">上传的控件名</param>
    /// <returns></returns>
    private string UpLoadXls(System.Web.UI.HtmlControls.HtmlInputFile inputfile)
    {
        string orifilename = string.Empty;
        string uploadfilepath = string.Empty;
        string modifyfilename = string.Empty;
        string fileExtend = "";//文件扩展名
        int fileSize = 0;//文件大小
        try
        {
            if (inputfile.Value != string.Empty)
            {
                //得到文件的大小
                fileSize = inputfile.PostedFile.ContentLength;
                if (fileSize == 0)
                {
                    throw new Exception("导入的Excel文件大小为0，请检查是否正确！");
                }
                //得到扩展名
                fileExtend = inputfile.Value.Substring(inputfile.Value.LastIndexOf(".") + 1);
                if (fileExtend.ToLower() != "xls")
                {
                    throw new Exception("你选择的文件格式不正确，只能导入EXCEL文件！");
                }
                //路径
                uploadfilepath = Server.MapPath("~/UpLoadsExcel");
                //新文件名
                modifyfilename = System.Guid.NewGuid().ToString();
                modifyfilename += "." + inputfile.Value.Substring(inputfile.Value.LastIndexOf(".") + 1);
                //判断是否有该目录
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(uploadfilepath);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                orifilename = uploadfilepath + "\\" + modifyfilename;
                //如果存在,删除文件
                if (File.Exists(orifilename))
                {
                    File.Delete(orifilename);
                }
                // 上传文件
                inputfile.PostedFile.SaveAs(orifilename);
            }
            else
            {
                throw new Exception("请选择要导入的Excel文件!");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return orifilename;
    }

    //// <summary>
    /// 从Excel提取数据--》Dataset
    /// </summary>
    /// <param name="filename">Excel文件路径名</param>
    private void ImportXlsToData(string fileName)
    {
        try
        {
            if (fileName == string.Empty)
            {
                throw new ArgumentNullException("Excel文件上传失败！");
            }

            string oleDBConnString = String.Empty;
            oleDBConnString = "Provider=Microsoft.Jet.OLEDB.4.0;";
            oleDBConnString += "Data Source=";
            oleDBConnString += fileName;
            oleDBConnString += ";Extended Properties=Excel 8.0;";
            OleDbConnection oleDBConn = null;
            OleDbDataAdapter oleAdMaster = null;
            DataTable m_tableName = new DataTable();
            DataSet ds = new DataSet();

            oleDBConn = new OleDbConnection(oleDBConnString);
            oleDBConn.Open();
            m_tableName = oleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (m_tableName != null && m_tableName.Rows.Count > 0)
            {

                m_tableName.TableName = m_tableName.Rows[0]["TABLE_NAME"].ToString();

            }
            string sqlMaster;
            sqlMaster = " SELECT *  FROM [" + m_tableName.TableName + "]";
            oleAdMaster = new OleDbDataAdapter(sqlMaster, oleDBConn);
            oleAdMaster.Fill(ds, "m_tableName");
            oleAdMaster.Dispose();
            oleDBConn.Close();
            oleDBConn.Dispose();

            AddDatasetToSQL(ds, 9);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 将Dataset的数据导入数据库
    /// </summary>
    /// <param name="pds">数据集</param>
    /// <param name="Cols">数据集列数</param>
    /// <returns></returns>
    private bool AddDatasetToSQL(DataSet pds, int Cols)
    {
        int ic, ir;
        ic = pds.Tables[0].Columns.Count;
        if (pds.Tables[0].Columns.Count < Cols)
        {
            throw new Exception("导入Excel格式错误！Excel只有" + ic.ToString() + "列");
        }
        ir = pds.Tables[0].Rows.Count;
        string msg = "";
        string strnull = "";
        string strtrue = "";
        string strtime = "";
        string strmoney = "";
        string strother = "";
        if (pds != null && pds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < pds.Tables[0].Rows.Count; i++)
            {
                try
                {

                    int b = Update(pds.Tables[0].Rows[i]);
                    switch (b)
                    {
                        case 0: strnull = strnull + pds.Tables[0].Rows[i][4].ToString(); break;
                        case 1: strtrue = strtrue + pds.Tables[0].Rows[i][4].ToString(); break;
                        case 2: strtime = strtime + pds.Tables[0].Rows[i][4].ToString(); break;
                        case 3: strmoney = strmoney + pds.Tables[0].Rows[i][4].ToString(); break;
                        default: strother = strother + pds.Tables[0].Rows[i][4].ToString(); break;
                    }

                }
                catch
                {
                    //   WriteLogin(pds.Tables[0].Rows[i][0].ToString());
                    continue;
                }
            }
            msg = "成功导入的：" + strtrue + ".找不到的资产：" + strnull + ".时间格式有误:" + strtime + ".费用格式有误:" + strmoney + ".位置错误" + strother + ".";
            Alert(msg);
        }
        else
        {
            throw new Exception("导入数据为空！");
        }
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="row"></param>
    /// <param name="msg"></param>
    /// <returns></returns>
    public int Update(DataRow row)
    {

        string id = row[0].ToString();
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail = list.Where(p => p.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID == id).FirstOrDefault();
        if (t_OfficeAutomation_Document_AssetTransfer_Detail == null)
        {
            return 0;
        }
        string BuyTime = "";
        //if (!IsDate(row[6].ToString()) && row[6].ToString() != "")
        //{

        //    return 2;
        //}
        if (!IsInt(row[7].ToString()))
        {


            return 3;
        }

        try
        {
            BuyTime = row[6].ToString() == "" ? "" : DateTime.Parse(row[6].ToString()).ToString("yyyy-MM-dd");
        }
        catch
        {
            return 2;
        }
        string ResidualCost = row[7].ToString();
        string Memo = row[8].ToString();

        try
        {
            DateTime? TimeNull = null;
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_BuyDate = BuyTime == "" ? DateTime.Parse("1900-01-01") : DateTime.Parse(BuyTime);
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Cost = decimal.Parse(ResidualCost);
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_SurplusValue = Memo;
        }
        catch
        {
            return 4;
        }
        return 1;
    }
    #endregion
    */

    #region 验证格式
    /// <summary>
    /// 是否为日期型字符串
    /// </summary>
    /// <param name="StrSource">日期字符串(2008-05-08)</param>
    /// <returns></returns>
    public static bool IsDate(string StrSource)
    {
        return Regex.IsMatch(StrSource, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
    }

    //是否是整数
    public static bool IsInt(string StrSource)
    {
        return Regex.IsMatch(StrSource, @"^(?!0\d)\d+(\.\d{1,2})?$");
    }
    #endregion
    protected void btnSavaAsset_Click(object sender, EventArgs e)
    {
        DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
       
        DataSet dsAssetTransfer = new DataSet();
        dsAssetTransfer = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(MainID);

        int number = int.Parse(this.Number.Text.Trim());
        string assetName = this.txtAssetName.Text;
        string txtmodel = this.txtModel.Text;
        List<T_OfficeAutomation_Document_AssetTransfer_Detail> addlist = new List<T_OfficeAutomation_Document_AssetTransfer_Detail>();
        for (int i = 0; i < number; i++) {
            T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = new Guid(dsAssetTransfer.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ID"].ToString());
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = "";
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = txtmodel;
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = "1";
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = assetName;
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = "";
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_TxtType = "";

            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp = "";
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = "";
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = dsAssetTransfer.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ImportDepartment"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = dsAssetTransfer.Tables[0].Rows[0]["OfficeAutomation_Document_AssetTransfer_ImportPlace"].ToString();
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_CreateTime = DateTime.Now;
            t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_CV = "";
            T_OfficeAutomation_Document_AssetTransfer_Detail oldt_OfficeAutomation_Document_AssetTransfer_Detail = null;

            addlist.Add(t_OfficeAutomation_Document_AssetTransfer_Detail);
        
        }
        if (ViewState["list"] != null)
        {
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        }
        else {
            list = new List<T_OfficeAutomation_Document_AssetTransfer_Detail>();
        }
            list.AddRange(addlist);
        
    
        
        ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(list);
        EditDataBindData();
        this.txtAssetName.Text = "";
        this.Number.Text = "";
        this.txtModel.Text = "";
        sample.Style.Add("display", "none");
        //resultdiv.Style.Add("display", "block");
        //selectdiv.Style.Add("display", "none");
      
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
 
        int index = (btn.NamingContainer as GridViewRow).RowIndex ;
        string id=EditData.DataKeys[index].Value.ToString();
 
        string tbxText = EditData.Rows[index].Cells[6].Text.ToString();
        this.CopyAssetName.Value = tbxText;
        this.CopyId.Value = id;
        this.CopyAssetNo.Text = "";
        copydiv.Style.Add("display", "block");

    }
    protected void btnCopySava_Click(object sender, EventArgs e)
    {
        string asset = this.CopyAssetNo.Text;
        string assetName = this.CopyAssetName.Value;
        Guid id =new Guid( this.CopyId.Value);

        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DataSet ds = da_OfficeAutomation_Main_Inherit.SelectAssets(ViewState["Asset_Dpm"].ToString(), asset, assetName, "", "");
       list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
       var t_OfficeAutomation_Document_AssetTransfer_Detail = list.Where(p => p.OfficeAutomation_Document_AssetTransfer_Detail_ID == id).FirstOrDefault();
       if (ds.Tables[0].Rows.Count < 1) {
           Alert("资产编号有误！");
           return;
       }

        t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
 
       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;
       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = ds.Tables[0].Rows[0]["Asset_AssetNo"].ToString().Replace("\r", "").Replace("\n", "");
       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = ds.Tables[0].Rows[0]["txtTS"].ToString().Replace("\r", "").Replace("\n", "");
       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = "1";
       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = ds.Tables[0].Rows[0]["txtClasses"].ToString().Replace("\r", "").Replace("\n", "");
       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = ds.Tables[0].Rows[0]["Asset_Id"].ToString();


       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp = ds.Tables[0].Rows[0]["txtPlace"].ToString();
       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = ds.Tables[0].Rows[0]["Assets_Dept_Name"].ToString();
       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_CreateTime = DateTime.Now;
       t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_CV = ds.Tables[0].Rows[0]["cv"].ToString();

       ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(list);
       EditDataBindData();
       copydiv.Style.Add("display", "none");
    }
    protected void EditData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        Button but = (Button)e.Row.Cells[7].FindControl("CopySelect");
        Label la = (Label)e.Row.Cells[7].FindControl("lable1");
        if (la.Text != "") {
            but.Visible = false;
        }
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        Guid index;
        foreach (GridViewRow row in EditData.Rows)
        {
            index = (Guid)EditData.DataKeys[row.RowIndex].Value;
            bool result = ((CheckBox)row.FindControl("ChkSelected")).Checked;
            if (result) {
                var model = list.Where(p => p.OfficeAutomation_Document_AssetTransfer_Detail_ID == index).FirstOrDefault();
                bool b = ws.AssetAdjustmentReject(model.OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID.ToString());
                da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.DeleteByID(model.OfficeAutomation_Document_AssetTransfer_Detail_ID.ToString());
                list.Remove(model);
            }
        
        }
        ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(list);
        EditDataBindData();
    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportExcel();
    }


    public void ExportExcel()
    {

        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_AssetTransfer_Detail>>(ViewState["list"].ToString());
        if (list != null)
        {

            string path = Server.MapPath("~/Temp/" + SerialNumber + "调动详情.xls");

            string[] heads = new string[] { "调出部门", "调出地点", "接收部门", "接收地点", "资产名称", "财务编号", "规格型号","归属" };
            string[] headValueNames = new string[] { "OfficeAutomation_Document_AssetTransfer_Detail_DpmExp", "OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp", "OfficeAutomation_Document_AssetTransfer_Detail_DpmRec", "OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec", "OfficeAutomation_Document_AssetTransfer_Detail_AssetName", "OfficeAutomation_Document_AssetTransfer_Detail_AssetTag", "OfficeAutomation_Document_AssetTransfer_Detail_Model", "OfficeAutomation_Document_AssetTransfer_Detail_TxtType" };

            NPOIExcel.ExportToExcel<T_OfficeAutomation_Document_AssetTransfer_Detail>(list, heads, headValueNames, path);
            string fileName = HttpUtility.UrlEncode(SerialNumber + "调动详情", Encoding.UTF8);
            HttpContext.Current.Response.Charset = "gb2312";

            //读取文件
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();

            File.Delete(path);
            //下载
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //path = path.Replace("/", "或");
            string str = "attachment;filename= " + fileName + ".xls";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", str);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.End();

           
        }
    }
}
class ValueAndId {
   public  int id { get; set; }
   public string value { get; set; }
}