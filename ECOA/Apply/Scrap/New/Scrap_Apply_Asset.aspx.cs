using DataAccess.Operate;
using DataEntity;
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

public partial class Apply_Scrap_New_Scrap_Apply_Asset : BasePage
{
    public StringBuilder sbJSON = new StringBuilder();
    string SerialNumber = "";
    string applyer="";
    string[] admins = { "陈秀球", "源浩灵", "曹雄", "周松伟"};
    List<T_OfficeAutomation_Document_Scrap_Detail> list = null;
    //public StringBuilder sbJS = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 300;
        GetAllDepartment();
     //   string s = GetQueryString("Asset_Dpm");
        string mid = GetQueryString("mainID");
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string where = "[OfficeAutomation_Main_ID]='" + MainID + "'";
        var Mainobj = da_OfficeAutomation_Main_Inherit.GetModel(where);
        if (Mainobj == null)
        {
            RunJS("alert('操作有误！');window.location.href='/Apply/Apply_Search.aspx';");
            return;
        }
        ViewState["Asset_Dpm"] = Mainobj.OfficeAutomation_Main_Department;
        SerialNumber = Mainobj.OfficeAutomation_SerialNumber;
        applyer = Mainobj.OfficeAutomation_Main_Apply;
        ViewState["Asset_Admin"] = "true";
        if (EmployeeName != "陈秀球" && EmployeeName != "曹雄" && EmployeeName != "源浩灵"
            && EmployeeName != "周松伟" && EmployeeName != "梁锐华" && EmployeeName != "王燕波"
            && EmployeeName != "苏志明" && EmployeeName != "潘柏廉" && EmployeeName != "周志维"
            && EmployeeName != "许贵治" && EmployeeName != "何学峰"
            )
        {
            ViewState["Asset_Admin"] = false;
            importdiv.Style.Add("display", "none");
            this.btnSava_Cost.Visible = false;
            this.btnExport.Visible = false;
     
        }
        if (Mainobj.OfficeAutomation_Main_FlowStateID != 7 && Mainobj.OfficeAutomation_Main_FlowStateID != 1)
        {
            this.btnSava_.Visible = false;
            this.btnAgain.Visible = false;
            this.btnDel.Visible = false;
        }
        if (Mainobj.OfficeAutomation_Main_FlowStateID != 3 && (EmployeeName == "陈秀球" || EmployeeName == "曹雄"))
        {
            this.btnSava_.Visible = true;
            this.btnAgain.Visible = true;
            this.btnDel.Visible = true ;
        }
        if (applyer != EmployeeName && EmployeeName != "陈秀球" && EmployeeName != "曹雄" && EmployeeName != "源浩灵") 
        {

            this.btnSava_.Visible = false;
            this.btnAgain.Visible = false;
            this.btnDel.Visible = false;
        }
        if (!IsPostBack)
        {
            try
            {
                DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
                DataSet dsDetail = new DataSet();
                dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(mid);
                if (dsDetail.Tables[0].Rows.Count > 0)
                {
                    List<T_OfficeAutomation_Document_Scrap_Detail> tdlist = ECOA.Common.OTConverter.ConvertTableToObject<T_OfficeAutomation_Document_Scrap_Detail>(dsDetail.Tables[0]);
                  
                    ArrayList categoryIDList = new ArrayList();
                    foreach (var item in tdlist)
                    {
                        //wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                        //ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString());
                        categoryIDList.Add(new Guid(item.OfficeAutomation_Document_Scrap_Detail_AssetAID));
                        

                    }
                    if (categoryIDList != null && categoryIDList.Count > 0)
                    {
                        Session["CHECKED_ITEMS"] = categoryIDList;
                        ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(tdlist);
                    }
                    resultdiv.Style.Add("display", "block");
                    selectdiv.Style.Add("display", "none");
                    EditDataBindData();
                }
                else {
                    LoadPage();
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
        string dpm = ViewState["Asset_Dpm"].ToString();


       // dpm = "行政部";
        ds = da_OfficeAutomation_Main_Inherit.SelectAssets(dpm, "", "", "", "");
        gvData.DataSource = ds;
        gvData.DataBind();
    }

    private void BindDataWithPageIndex(string No, string Id, string St, string Et)
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string dpm = ViewState["Asset_Dpm"].ToString();
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
        list = new List<T_OfficeAutomation_Document_Scrap_Detail>();
   
        List<T_OfficeAutomation_Document_Scrap_Detail> oldlist = new List<T_OfficeAutomation_Document_Scrap_Detail>();
        if (ViewState["list"] != null && ViewState["list"].ToString() != "")
        {
            oldlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
        }
        RememberOldValues();
        if (Session["CHECKED_ITEMS"] != null)
        {
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            ArrayList categoryIDList = new ArrayList();
            DataSet ds = new DataSet();
            string st = null, rt = null;
            categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];

            for (int i = 0; i < categoryIDList.Count; i++)
            {


                ds = da_OfficeAutomation_Main_Inherit.FindAssetsByID(categoryIDList[i].ToString());
                T_OfficeAutomation_Document_Scrap_Detail t_OfficeAutomation_Document_Scrap_Detail = new T_OfficeAutomation_Document_Scrap_Detail();
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_MainID = Guid.Empty;
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTypeID = 0;
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetTag = ds.Tables[0].Rows[0]["Asset_AssetNo"].ToString().Replace("\r", "").Replace("\n", "");
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Model = ds.Tables[0].Rows[0]["txtTS"].ToString().Replace("\r", "").Replace("\n", "");
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Number = "1";
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetName = ds.Tables[0].Rows[0]["txtClasses"].ToString().Replace("\r", "").Replace("\n", "");
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID = categoryIDList[i].ToString();


                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceExp = ds.Tables[0].Rows[0]["txtPlace"].ToString();
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_DpmExp = ds.Tables[0].Rows[0]["txtDepartment"].ToString();
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceExpId = int.Parse(ds.Tables[0].Rows[0]["Asset_Place"].ToString());
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Type = ds.Tables[0].Rows[0]["txtType"].ToString();
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_DpmRec = "";
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_PlaceRec = "";
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_CreateTime = DateTime.Now;
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Cost = 0;
             //   t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse("1900-01-01");
                try
                {
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse(ds.Tables[0].Rows[0]["Asset_RecordedTime"].ToString());
                }
                catch {
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = DateTime.Parse("1900-01-01");
                }
                
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue = "已折完";
                t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_CV = ds.Tables[0].Rows[0]["cv"].ToString();
                T_OfficeAutomation_Document_Scrap_Detail oldt_OfficeAutomation_Document_Scrap_Detail = null;
                oldt_OfficeAutomation_Document_Scrap_Detail = oldlist.Where(p => p.OfficeAutomation_Document_Scrap_Detail_AssetAID == t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_AssetAID).FirstOrDefault();
                if (oldt_OfficeAutomation_Document_Scrap_Detail != null)
                {
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Cost = oldt_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Cost;
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = oldt_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate;
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue = oldt_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue;
                    t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_CreateTime = oldt_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_CreateTime;
                }

                list.Add(t_OfficeAutomation_Document_Scrap_Detail);


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
        //RunJS("window.location.href=\"/Apply/Scrap/New/Apply_Scrap_Detail.aspx?mainID=" + MainID + "\";");
    //    RunJS("window.returnValue='';window.close();");
        string sUrl = "/Apply/Scrap/New/Apply_Scrap_Detail.aspx?" + Request.QueryString;
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
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
            list = list.OrderBy(p => p.OfficeAutomation_Document_Scrap_Detail_AssetName).ThenBy(P => P.OfficeAutomation_Document_Scrap_Detail_AssetTag).ToList();
        }
        EditData.DataSource = list;
        EditData.DataBind();
        this.TotalRC.Text = list.Sum(p => p.OfficeAutomation_Document_Scrap_Detail_Cost) + "";
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
    /// 更新当前显示的报废资产信息
    /// </summary>
    /// <returns></returns>
    public bool UpadateList()
    {

        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
        foreach (GridViewRow row in EditData.Rows)
        {

            Guid index = (Guid)EditData.DataKeys[row.RowIndex].Value;
            T_OfficeAutomation_Document_Scrap_Detail model = list.Where(p => p.OfficeAutomation_Document_Scrap_Detail_ID == index).FirstOrDefault();

            string BuyTime = ((TextBox)row.Cells[7].FindControl("BuyTime")).Text.Trim();
            string ResidualCost = ((TextBox)row.Cells[8].FindControl("ResidualCost")).Text.Trim();
            string Memo = ((TextBox)row.Cells[9].FindControl("Memo")).Text;
            if (!IsDate(BuyTime) && BuyTime != "")
            {
                Alert(model.OfficeAutomation_Document_Scrap_Detail_AssetTag + "购买时间格式有误。");
                return false;
            }
            if (!IsInt(ResidualCost))
            {

                Alert(model.OfficeAutomation_Document_Scrap_Detail_AssetTag + "折旧摊分剩余费用格式有误。");
                return false;
            }
            if (model != null)
            {
                DateTime? TimeNull = null;
                model.OfficeAutomation_Document_Scrap_Detail_BuyDate = BuyTime == "" ? DateTime.Parse("1900-01-01") : DateTime.Parse(BuyTime);
                model.OfficeAutomation_Document_Scrap_Detail_Cost = decimal.Parse(ResidualCost);
                model.OfficeAutomation_Document_Scrap_Detail_SurplusValue = Memo;

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
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
        foreach (var item in list)
        {
            categoryIDList.Add(new Guid(item.OfficeAutomation_Document_Scrap_Detail_AssetAID));
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
        string msg="";
        bool b = UpadateList();
        if (!b)
        {
            return;
        }
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
        DataSet ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
        Guid id= new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString());

        decimal Total = 0;
        DataSet dsDetail = new DataSet();
        string mid = GetQueryString("mainID");
        dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(mid);
        List<T_OfficeAutomation_Document_Scrap_Detail> tdlist = ECOA.Common.OTConverter.ConvertTableToObject<T_OfficeAutomation_Document_Scrap_Detail>(dsDetail.Tables[0]);
        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
        foreach (var item in tdlist)
        {
            ws.AssetAdjustmentReject(item.OfficeAutomation_Document_Scrap_Detail_AdjustmentID.ToString());
            da_OfficeAutomation_Document_Scrap_Detail_Inherit.DeleteByID(item.OfficeAutomation_Document_Scrap_Detail_ID);
        }
        foreach (var item in list) {
            //var model = tdlist.Where(p => p.OfficeAutomation_Document_Scrap_Detail_AssetAID == item.OfficeAutomation_Document_Scrap_Detail_AssetAID).FirstOrDefault();

           
            item.OfficeAutomation_Document_Scrap_Detail_MainID = id;
            //if (model != null)
            //{
            //    item.OfficeAutomation_Document_Scrap_Detail_ID = model.OfficeAutomation_Document_Scrap_Detail_ID;
            //    da_OfficeAutomation_Document_Scrap_Detail_Inherit.Update(item);
            //}
            //else {
                string t = ws.AdjustmentWithEcoaCode(item.OfficeAutomation_Document_Scrap_Detail_AssetTag, item.OfficeAutomation_Document_Scrap_Detail_PlaceExpId, 1, item.OfficeAutomation_Document_Scrap_Detail_DpmExp, DateTime.Now.ToString(), 2, SerialNumber); //锁定资产
                if (t.Contains("*"))
                    msg = msg + item.OfficeAutomation_Document_Scrap_Detail_AssetTag + t.Replace("*", string.Empty) + ".";
                else
                    item.OfficeAutomation_Document_Scrap_Detail_AdjustmentID = new Guid(t);
                if (!string.IsNullOrEmpty(msg)) {
                    RunJS("alert('保存失败！" + msg + "')");
                    return;
                }
                da_OfficeAutomation_Document_Scrap_Detail_Inherit.Insert(item);
             
          //  }
            Total = Total + item.OfficeAutomation_Document_Scrap_Detail_Cost;
            //tdlist.Remove(model);
        }
        if (!string.IsNullOrEmpty(msg))
        {
            RunJS("alert('保存失败！"+msg+"')");
            return;
        }
     

        da_OfficeAutomation_Document_Scrap_Inherit.UpdateSurplusValueByID(ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString(), Total.ToString(), ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Suc"].ToString());
        string sUrl = "/Apply/Scrap/New/Apply_Scrap_Detail.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
        
        //RunJS("alert('保存成功！'); window.returnValue='';window.close();");
        //RunJS("alert('保存成功！');window.location.href=\"/Apply/Scrap/New/Scrap_Apply_Asset.aspx?mainID=" + GetQueryString("mainID") + "\";");
       // Alert(msg);
    }

    #region 导出列表
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportExcel();
    }


    public void ExportExcel()
    {
      /*  DataTable myDataTable = new DataTable("Excel");
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
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
        foreach (var item in list)
        {
            myDataRow = myDataTable.NewRow();
            myDataRow["资产ID"] = item.OfficeAutomation_Document_Scrap_Detail_AssetAID;
            myDataRow["使用部门"] = item.OfficeAutomation_Document_Scrap_Detail_DpmExp;
            myDataRow["存放地点"] = item.OfficeAutomation_Document_Scrap_Detail_PlaceExp;
            myDataRow["资产名称"] = item.OfficeAutomation_Document_Scrap_Detail_AssetName;
            myDataRow["财务编号"] = item.OfficeAutomation_Document_Scrap_Detail_AssetTag;
            myDataRow["规格型号"] = item.OfficeAutomation_Document_Scrap_Detail_Model;
            myDataRow["购买时间"] = item.OfficeAutomation_Document_Scrap_Detail_BuyDate != null ? ((DateTime)item.OfficeAutomation_Document_Scrap_Detail_BuyDate).ToString("yyyy-MM-dd") : "";
            myDataRow["折旧摊分剩余费用"] = item.OfficeAutomation_Document_Scrap_Detail_Cost;
            myDataRow["备注"] = item.OfficeAutomation_Document_Scrap_Detail_SurplusValue;
            myDataTable.Rows.Add(myDataRow);
        }
        this.ExportToExcel(myDataTable, "List" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".xls");
       */
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
        if (list != null)
        {

            string path = Server.MapPath("~/Temp/" + SerialNumber + "报废编辑.xls");

            string[] heads = new string[] { "资产ID", "使用部门", "存放地点", "资产名称","归属", "财务编号", "规格型号", "购买时间", "折旧摊分剩余费用", "备注" };
            string[] headValueNames = new string[] { "OfficeAutomation_Document_Scrap_Detail_AssetAID", "OfficeAutomation_Document_Scrap_Detail_DpmExp", "OfficeAutomation_Document_Scrap_Detail_PlaceExp", "OfficeAutomation_Document_Scrap_Detail_AssetName", "OfficeAutomation_Document_Scrap_Detail_Type", "OfficeAutomation_Document_Scrap_Detail_AssetTag", "OfficeAutomation_Document_Scrap_Detail_Model", "OfficeAutomation_Document_Scrap_Detail_BuyDate", "OfficeAutomation_Document_Scrap_Detail_Cost", "OfficeAutomation_Document_Scrap_Detail_SurplusValue" };

            NPOIExcel.ExportToExcel<T_OfficeAutomation_Document_Scrap_Detail>(list, heads, headValueNames, path);
            string fileName = HttpUtility.UrlEncode(SerialNumber + "报废编辑", Encoding.UTF8);
            HttpContext.Current.Response.Charset = "gb2312";

            //读取文件
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();

            //下载
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //path = path.Replace("/", "或");
            string str = "attachment;filename= " + fileName + ".xls";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", str);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.End();

            File.Delete(path);
        }
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
            EditDataBindData();
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
                        case 0: strnull = strnull + pds.Tables[0].Rows[i][5].ToString(); break;
                        case 1: strtrue = strtrue + pds.Tables[0].Rows[i][5].ToString(); break;
                        case 2: strtime = strtime + pds.Tables[0].Rows[i][5].ToString(); break;
                        case 3: strmoney = strmoney + pds.Tables[0].Rows[i][5].ToString(); break;
                        default: strother = strother + pds.Tables[0].Rows[i][5].ToString(); break;
                    }

                }
                catch
                {
                    //   WriteLogin(pds.Tables[0].Rows[i][0].ToString());
                    continue;
                }
            }
         //   msg = "成功导入的：" + strtrue + ".找不到的资产：" + strnull + ".时间格式有误:" + strtime + ".费用格式有误:" + strmoney + ".位置错误" + strother + ".";

            msg = "找不到的资产：" + strnull + ".时间格式有误:" + strtime + ".费用格式有误:" + strmoney + ".位置错误" + strother + ".";
           
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
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        string id = row[0].ToString();
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
        T_OfficeAutomation_Document_Scrap_Detail t_OfficeAutomation_Document_Scrap_Detail = list.Where(p => p.OfficeAutomation_Document_Scrap_Detail_AssetAID == id).FirstOrDefault();
        if (t_OfficeAutomation_Document_Scrap_Detail == null)
        {
            return 0;
        }
        string BuyTime = "";
        //if (!IsDate(row[6].ToString()) && row[6].ToString() != "")
        //{

        //    return 2;
        //}
        if (!IsInt(row[8].ToString()))
        {


            return 3;
        }

        try
        {
            BuyTime = row[7].ToString() == "" ? "" : DateTime.Parse(row[7].ToString()).ToString("yyyy-MM-dd");
        }
        catch
        {
            return 2;
        }
        string ResidualCost = row[8].ToString();
        string Memo = row[9].ToString();

        try
        {
            DateTime? TimeNull = null;
            t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_BuyDate = BuyTime == "" ? DateTime.Parse("1900-01-01") : DateTime.Parse(BuyTime);
            t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_Cost = decimal.Parse(ResidualCost);
            t_OfficeAutomation_Document_Scrap_Detail.OfficeAutomation_Document_Scrap_Detail_SurplusValue = Memo;
        }
        catch
        {
            return 4;
        }
        ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(list);
        return 1;
    }
    #endregion


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
    protected void btnSava_Cost_Click(object sender, EventArgs e)
    {
        string msg = "";
         bool b= UpadateList();
         if (!b) {
             return;
         }
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
        DataSet ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(MainID);
        Guid id = new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString());

        decimal Total = 0;
        DataSet dsDetail = new DataSet();
        string mid = GetQueryString("mainID");
        dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(mid);
        List<T_OfficeAutomation_Document_Scrap_Detail> tdlist = ECOA.Common.OTConverter.ConvertTableToObject<T_OfficeAutomation_Document_Scrap_Detail>(dsDetail.Tables[0]);
    
    
        foreach (var item in list)
        {
            var model = tdlist.Where(p => p.OfficeAutomation_Document_Scrap_Detail_AssetAID == item.OfficeAutomation_Document_Scrap_Detail_AssetAID).FirstOrDefault();


            item.OfficeAutomation_Document_Scrap_Detail_MainID = id;
            if (model != null)
            {
                item.OfficeAutomation_Document_Scrap_Detail_ID = model.OfficeAutomation_Document_Scrap_Detail_ID;
                da_OfficeAutomation_Document_Scrap_Detail_Inherit.Update(item);
            }
            //else {

        
            //da_OfficeAutomation_Document_Scrap_Detail_Inherit.Insert(item);

            //  }
            Total = Total + item.OfficeAutomation_Document_Scrap_Detail_Cost;
            //tdlist.Remove(model);
        }
        //if (!string.IsNullOrEmpty(msg))
        //{
        //    RunJS("alert('保存失败！" + msg + "')");
        //    return;
        //}

        Alert("保存成功！");
        da_OfficeAutomation_Document_Scrap_Inherit.UpdateSurplusValueByID(ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_ID"].ToString(), Total.ToString(), ds.Tables[0].Rows[0]["OfficeAutomation_Document_Scrap_Suc"].ToString());
        string sUrl = "/Apply/Scrap/New/Apply_Scrap_Detail.aspx?" + Request.QueryString;
        Response.Redirect(sUrl);
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
        DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
        list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T_OfficeAutomation_Document_Scrap_Detail>>(ViewState["list"].ToString());
        Guid index;
        foreach (GridViewRow row in EditData.Rows)
        {
            index = (Guid)EditData.DataKeys[row.RowIndex].Value;
            bool result = ((CheckBox)row.FindControl("ChkSelected")).Checked;
            if (result)
            {
                var model = list.Where(p => p.OfficeAutomation_Document_Scrap_Detail_ID == index).FirstOrDefault();
                bool b = ws.AssetAdjustmentReject(model.OfficeAutomation_Document_Scrap_Detail_AdjustmentID.ToString());
                da_OfficeAutomation_Document_Scrap_Detail_Inherit.DeleteByID(model.OfficeAutomation_Document_Scrap_Detail_ID);
                list.Remove(model);
            }

        }
        ViewState["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(list);
        EditDataBindData();
    }
    protected void EditData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox lb1 = (TextBox)e.Row.FindControl("BuyTime");
            TextBox lb2 = (TextBox)e.Row.FindControl("ResidualCost");
            TextBox lb3 = (TextBox)e.Row.FindControl("Memo");
            if (!admins.Contains(EmployeeName)) {
                lb1.Enabled = false;
                lb2.Enabled = false;
                lb3.Enabled = false;
            }
        
        }
    }
}
