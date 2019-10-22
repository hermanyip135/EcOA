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

//using Excel = Microsoft.Office.Interop.Excel;//这种引用方式
//using System.Reflection; //Missing类命名空间
using System.IO;
using System.ComponentModel;
using ECOA.Common;
using DataEntity;

public partial class Apply_Apply_Search : BasePage
{
    public StringBuilder sbJSON = new StringBuilder();
    public StringBuilder sbJS = new StringBuilder();
    public StringBuilder SbJszz = new StringBuilder();
    public string islawer = "False", willDel = "False";
    public bool KeyWordAllTB = false;

    public string namesf = "简圣钊,李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,陈洁丽,李小清,甘桂芳"; //20140918++++：法律部的人审批了以后，只有names里的人及管理员才能删除
    public string[] employnamesf;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 300;
        GetAllDepartment();
        KeyWordAllTB = LoginUser.KeyWordAllTB;
        InitJS();
        if (!IsPostBack)
        {

            InitPage();
            ViewState["V_sear"] = 0;
            if (GetQueryString("do") == "waitforme")
            {
                WaitForMe();
                //BindData();//M_waitforme：20150326
            }
            else if (GetQueryString("do") == "Lawer")
            {
                IsLawer();
            }
            else if (GetQueryString("do") == "DeleteA") //M_DeleteAdd 20151230
            {
                DeleteA();
            }
            else
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
    /// 初始化JS代码
    /// </summary>
    private void InitJS()
    {
        DataSet ds = new DataSet();

        #region 类别下拉框初始化
        DA_Dic_OfficeAutomation_Document_Inherit da_Dic_OfficeAutomation_Document_Inherit = new DA_Dic_OfficeAutomation_Document_Inherit();
        ds = da_Dic_OfficeAutomation_Document_Inherit.SelectAllWithType();
        string tempType = "", type, name, id;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            type = dr["OfficeAutomation_DocumentType_Name"].ToString();
            name = dr["OfficeAutomation_Document_Name"].ToString();
            id = dr["OfficeAutomation_Document_ID"].ToString();

            if (type != tempType)
            {
                if (tempType != "")
                    sbJS.Append("</optgroup>");
                sbJS.Append("<optgroup label='" + type + "'>");
                tempType = type;
            }

            sbJS.Append("<option value='" + id + "'>" + name + "</option>");
        }
        sbJS.Append("</optgroup>");
        #endregion
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    private void InitPage()
    {
        DataSet ds = new DataSet();
        DA_Dic_OfficeAutomation_FlowState_Operate da_Dic_OfficeAutomation_FlowState_Operate = new DA_Dic_OfficeAutomation_FlowState_Operate();
        ds = da_Dic_OfficeAutomation_FlowState_Operate.SelectAll();
        DropDownListBind(ddlState, ds.Tables[0], "OfficeAutomation_FlowState_ID", "OfficeAutomation_FlowState_Name", "0", "--全部--");

        DA_Dic_OfficeAutomation_PersInterestsType_Operate da_Dic_OfficeAutomation_PersInterestsType_Operate = new DA_Dic_OfficeAutomation_PersInterestsType_Operate();
        ds = da_Dic_OfficeAutomation_PersInterestsType_Operate.SelectAll();
        DropDownListBind(ddlInterestsType, ds.Tables[0], "OfficeAutomation_PersInterestsType_ID", "OfficeAutomation_PersInterestsType_Name", "0", "--请选择利益申报类别--");
    }

    /// <summary>
    /// 加载页面
    /// </summary>
    private void LoadPage()
    {

        this.txtApplicationDepartment.Value = GetQueryString("dep");
        this.txtApplicant.Value = GetQueryString("apply");
        this.txtApplyDate.Value = GetQueryString("start");
        this.txtEndDate.Value = GetQueryString("end");
        this.hdTypeID.Value = GetQueryString("type");
        this.ddlApplyType.SelectedIndex = GetQueryInt("ctype", 0);
        this.ddlState.SelectedIndex = GetQueryInt("state", 0);
        int curpage = GetQueryInt("curpage", 0);
        this.txtSerialNumber.Value = GetQueryString("serialnumber");
        this.txtKeyWord.Value = GetQueryString("keyword");
        this.txtApprover.Value = GetQueryString("approver");
        this.txtAppTime.Value = GetQueryString("apptime");
        islawer = GetQueryString("islawer");
        willDel = GetQueryString("DeleteA");
        this.hdEmployeeID.Value = EmployeeID;//员工工号
        try //M_SelectCkd：20150310  20161221 加上公基金特殊申请表也可以批量审批
        {
            //梁健菁  58318  付金银33102
            if (EmployeeID.Equals("58318") || EmployeeID.Equals("50203") || EmployeeID.Equals("33102") || EmployeeID.Equals("5585"))
            {
                //  spIsGroups.Visible = true;
            }
            if (GetQueryString("MainID").ToString() != "")
                if ((EmployeeID == "34498"
                    || EmployeeID == "33690"
                    || EmployeeID == "15300"
                    || EmployeeID == "23799"
                    || EmployeeID == "42900"
                    ) && hdTypeID.Value == "42")
                {
                    ChkSelect.Visible = true;
                    btnSelectChecked.Visible = true;
                }
                else if ((EmployeeID == "23799" || EmployeeID == "50203") && (hdTypeID.Value == "80" || hdTypeID.Value == "95"))
                {
                    ChkSelect.Visible = true;
                    btnSelectChecked.Visible = true;
                }
                else
                {
                    ChkSelect.Visible = false;
                    btnSelectChecked.Visible = false;
                }
        }
        catch
        {
        }

        string[] hdN;
        hdN = ("70,9,10,62,63,17,14,15,16,25,29,13,42,6,24,21,23,12,55,56,77,80,84,95,30").Split(','); //主表主键 //M_Excel
        if (((IList)hdN).Contains(hdTypeID.Value))
        {
            try
            {
                if ((UnitID == "108e0f54-5070-4745-a491-37f15d5a86cc"
                    || EmployeeID == "22563" //黄筑筠
                    || EmployeeID == "3030" //谢芃
                    || EmployeeID == "11523" // 郭敏洁
                    || EmployeeID == "39647" //顾慧
                    || UnitName == "法律部"
                    || Purview.Contains("OA_Search_002")
                    )
                    && (hdTypeID.Value == "25"
                    || hdTypeID.Value == "16"
                    || hdTypeID.Value == "62"
                    || hdTypeID.Value == "63"
                    || hdTypeID.Value == "13"
                    || hdTypeID.Value == "17"
                    )) //总办和系统管理员才可导出
                    btExcel.Visible = true;
                //应收款管理组
                else if ("5c473cf7-d65a-4d64-a50e-ab17c484fc60".Equals(UnitID) || "50203".Equals(EmployeeID))
                {
                    btExcel.Visible = true;
                }
                else if ((UnitID == "108e0f54-5070-4745-a491-37f15d5a86cc"
                    || EmployeeID == "0001"
                    || UnitName == "法律部"
                    || EmployeeID == "0001"
                    || EmployeeID == "2377" //陈洁丽
                    || EmployeeID == "17257" //顾思娜
                    || EmployeeID == "39647" //顾慧
                    || EmployeeID == "3030" //谢芃
                    || EmployeeID == "3873" //林亦玲
                    || EmployeeID == "45362" //李卉
                    || Purview.Contains("OA_Search_002"))
                    && (hdTypeID.Value == "14"
                    || hdTypeID.Value == "15"
                    || hdTypeID.Value == "12"
                )) //总办、法律部人员和系统管理员才可导出
                    btExcel.Visible = true;
                else if ((EmployeeID == "17913" || EmployeeID == "16570" || EmployeeID == "2519" || EmployeeID == "54894" || Purview.Contains("OA_Search_002"))
                    && hdTypeID.Value == "29") //梁碧莹、许海燕、林曼莹
                    btExcel.Visible = true;
                else if (EmployeeID == "45362" || EmployeeID == "50203" || Purview.Contains("OA_Search_051") && hdTypeID.Value == "45")
                    btExcel.Visible = true;
                else if ((EmployeeID == "33690" || EmployeeID == "23799" || Purview.Contains("OA_Search_002"))
                    && (hdTypeID.Value == "42"
                    || hdTypeID.Value == "24"
                    || hdTypeID.Value == "21"
                    || hdTypeID.Value == "23"
                    || hdTypeID.Value == "80"
                    || hdTypeID.Value == "84"
                    || hdTypeID.Value == "95"
                    )) //张晓莹
                    btExcel.Visible = true;
                else if ((EmployeeID == "19173" //周燕妮
                    || EmployeeID == "39591" //招琛彤
                    || EmployeeID == "2696" //李凤娟
                    || EmployeeID == "16947" //文玉仪
                    || Purview.Contains("OA_Search_002"))
                    && (hdTypeID.Value == "55"
                    || hdTypeID.Value == "56"
                    ))
                    btExcel.Visible = true;
                else if ((EmployeeID == "17642")
                    && (hdTypeID.Value == "31"))
                {
                    btExcel.Visible = true;
                }
                else if ((EmployeeID == "30602" //朱晓晴
                    || EmployeeID == "33690" //张晓莹
                    //|| EmployeeID == "16945" //胡雅丝
                    || EmployeeID == "43781" //钟惠贤 2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    || EmployeeID == "50203" //胡雅丝
                    || Purview.Contains("OA_Search_002"))
                    && (hdTypeID.Value == "9"
                    || hdTypeID.Value == "10"
                    || hdTypeID.Value == "70"
                    ))
                    btExcel.Visible = true;
                else if ((EmployeeID == "20861" //麦诗铭
                        || Purview.Contains("OA_Search_002"))
                    && hdTypeID.Value == "77")
                {
                    btExcel.Visible = true;
                }

                else if ((Purview.Contains("OA_Search_002") || Purview.Contains("OA_Search_083"))
                && hdTypeID.Value == "78")
                {
                    btExcel.Visible = true;
                }
                else if (Purview.Contains("OA_Search_002")) //管理员导出
                    btExcel.Visible = true;
                else
                    btExcel.Visible = false;
            }
            catch
            {
            }
        }
        else
            btExcel.Visible = false;

        if (this.txtApplicationDepartment.Value != "" || this.txtApplicant.Value != "" || this.txtApplyDate.Value != "" || this.txtEndDate.Value != "" || hdTypeID.Value != "" || this.ddlState.SelectedIndex != 0 || txtSerialNumber.Value != "" || (hdTypeID.Value != "" && txtKeyWord.Value != "") || txtApprover.Value != "" || txtAppTime.Value != "")
            BindDataWithPageIndex(curpage);
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        if ((EmployeeID == "34498"
            || EmployeeID == "33690"
            || EmployeeID == "15300"
            || EmployeeID == "23799"
            || EmployeeID == "42900"
            ) && hdTypeID.Value == "42")
        { //M_SelectCkd：20150310
            ChkSelect.Visible = true;
            btnSelectChecked.Visible = true;
            chkSelectAll.Checked = false;
            chkCancelAll.Checked = false;
        }
        else if ((EmployeeID == "23799" || EmployeeID == "50203") && (hdTypeID.Value == "80" || hdTypeID.Value == "84" || hdTypeID.Value == "95"))
        {
            ChkSelect.Visible = true;
            btnSelectChecked.Visible = true;
            chkSelectAll.Checked = false;
            chkCancelAll.Checked = false;
        }

        //else if ((EmployeeID == "31317" || EmployeeID == "37651" || EmployeeID == "40025" || EmployeeID == "58702" || EmployeeID == "63258" || EmployeeID == "50203") && hdTypeID.Value == "8")
        //增加 岑嘉琦（71880）
        else if ((EmployeeID == "31317" || EmployeeID == "37651" || EmployeeID == "40025" || EmployeeID == "58702" || EmployeeID == "63258" || EmployeeID == "50203" || EmployeeID == "71880") && hdTypeID.Value == "8")
        {
            ChkSelect.Visible = true;
            chkSelectAll.Checked = false;
            chkCancelAll.Checked = false;
        }
        else
        {
            ChkSelect.Visible = false;
        }
        string dds;
        int sta = 10;
        if (ddlState.SelectedValue == "")
            dds = "";
        else if (int.Parse(ddlState.SelectedValue) > 3)
        {
            if (int.Parse(ddlState.SelectedValue) <= 6)
                dds = "3";
            else
                if (int.Parse(ddlState.SelectedValue) == 8)
                    dds = "8";
                else
                    dds = "";
            switch (ddlState.SelectedValue)
            {
                case "4":
                    sta = 1;
                    break;
                case "5":
                    sta = 0;
                    break;
                case "6":
                    sta = 2;
                    break;
                case "7":
                    sta = 3;
                    break;
            }
        }
        else
        {
            dds = ddlState.SelectedValue;
        }

        string intereststype = ddlInterestsType.SelectedValue;

        //ds = da_OfficeAutomation_Main_Inherit.Search_New(bool.Parse(islawer), Purview.Contains("OA_Search_002"), this.txtApplicationDepartment.Value, this.txtApplicant.Value
        //    , this.txtApplyDate.Value, this.txtEndDate.Value, hdTypeID.Value, dds, EmployeeName, EmployeeID, Purview, this.txtSerialNumber.Value.Trim(), txtKeyWord.Value, ddlApplyType.SelectedValue, sta, txtApprover.Value, txtAppTime.Value, txtAppToTime.Value, bool.Parse(willDel), intereststype);

        //20170702
        DataEntity.DTO.SearchFilterDto SearchDto = InitSearchDto(LoginUser);
        SearchDto.AppDepartment = this.txtApplicationDepartment.Value;
        SearchDto.Applicant = this.txtApplicant.Value;
        SearchDto.ApplyState = string.IsNullOrEmpty(this.ddlState.SelectedValue) ? 0 : Convert.ToInt32(this.ddlState.SelectedValue);
        SearchDto.ApplyType = string.IsNullOrEmpty(this.hdTypeID.Value) ? 0 : Convert.ToInt32(this.hdTypeID.Value);
        SearchDto.SerialNumber = this.txtSerialNumber.Value.Trim();
        SearchDto.Approver = this.txtApprover.Value.Trim();
        SearchDto.InterestsType = intereststype;
        if (!string.IsNullOrEmpty(this.txtApplyDate.Value.Trim()))
            SearchDto.BeginApplyTime = Convert.ToDateTime(this.txtApplyDate.Value.Trim());
        if (!string.IsNullOrEmpty(this.txtEndDate.Value.Trim()))
            SearchDto.EndApplyTime = Convert.ToDateTime(this.txtEndDate.Value.Trim() + " 23:59:59");
        if (!string.IsNullOrEmpty(this.txtAppTime.Value.Trim()))
            SearchDto.AppTime = Convert.ToDateTime(this.txtAppTime.Value.Trim());
        if (!string.IsNullOrEmpty(this.txtAppToTime.Value.Trim()))
            SearchDto.AppToTime = Convert.ToDateTime(this.txtAppToTime.Value.Trim() + " 23:59:59");
        SearchDto.OrderType = Convert.ToInt32(this.ddlApplyType.SelectedValue);
        SearchDto.KeyWord = this.txtKeyWord.Value;
        SearchDto.IsGroups = this.cbIsGroups.Checked;
        ds = da_OfficeAutomation_Main_Inherit.Search_New_II(SearchDto);
        gvData.DataSource = ds;
        gvData.DataBind();
    }

    private void BindDataWithPageIndex(int pageindex)
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        string dds;
        int sta = 10;
        if (ddlState.SelectedValue == "")
            dds = "";
        else if (int.Parse(ddlState.SelectedValue) > 3)
        {
            if (int.Parse(ddlState.SelectedValue) <= 6)
                dds = "3";
            else
                dds = "";
            switch (ddlState.SelectedValue)
            {
                case "4":
                    sta = 1;
                    break;
                case "5":
                    sta = 0;
                    break;
                case "6":
                    sta = 2;
                    break;
                case "7":
                    sta = 3;
                    break;
            }
        }
        else
        {
            dds = ddlState.SelectedValue;
        }

        string intereststype = ddlInterestsType.SelectedValue;

        DataEntity.DTO.SearchFilterDto SearchDto = InitSearchDto(LoginUser);
        SearchDto.ApplyState = 0;
        SearchDto.OrderType = 1;
        SearchDto.IsAdmin = false;

        if (GetQueryString("do") == "waitforme" && ViewState["V_sear"].ToString() == "0") //M_waitforme：20150326
        {
            SearchDto.ApplyState = 7;   //待我审核
            ds = da_OfficeAutomation_Main_Inherit.Search_New_II(SearchDto);//da_OfficeAutomation_Main_Inherit.Search_New(false, true, "", "", "", "", "", "", EmployeeName, EmployeeID, "", "", "", "1", 3, "", "","", false,"");
        }
        else if (GetQueryString("do") == "Lawer" && ViewState["V_sear"].ToString() == "0")
        {
            ds = da_OfficeAutomation_Main_Inherit.Search_New(true, true, "", "", "", "", "", "", LoginUser.EmpName, LoginUser.EmpID, "", "", "", "1", 3, "", "", "", false, "");
        }
        else if (GetQueryString("do") == "DeleteA" && ViewState["V_sear"].ToString() == "0") //M_DeleteAdd 20151230
        {
            SearchDto.WillDelete = true;
            ds = da_OfficeAutomation_Main_Inherit.Search_New_II(SearchDto);//da_OfficeAutomation_Main_Inherit.Search_New(false, true, "", "", "", "", "", "", EmployeeName, EmployeeID, "", "", "", "1", 10, "", "","", true,"");
        }
        else
        {
            SearchDto.AppDepartment = this.txtApplicationDepartment.Value;
            SearchDto.Applicant = this.txtApplicant.Value;
            SearchDto.ApplyState = string.IsNullOrEmpty(this.ddlState.SelectedValue) ? 0 : Convert.ToInt32(this.ddlState.SelectedValue);
            SearchDto.ApplyType = string.IsNullOrEmpty(this.hdTypeID.Value) ? 0 : Convert.ToInt32(this.hdTypeID.Value);
            SearchDto.IsAdmin = LoginUser.AdminSearch;
            SearchDto.SerialNumber = this.txtSerialNumber.Value.Trim();
            SearchDto.Approver = this.txtApprover.Value.Trim();
            if (!string.IsNullOrEmpty(this.txtApplyDate.Value.Trim()))
                SearchDto.BeginApplyTime = Convert.ToDateTime(this.txtApplyDate.Value.Trim());
            if (!string.IsNullOrEmpty(this.txtEndDate.Value.Trim()))
                SearchDto.EndApplyTime = Convert.ToDateTime(this.txtEndDate.Value.Trim());
            if (!string.IsNullOrEmpty(this.txtAppTime.Value.Trim()))
                SearchDto.AppTime = Convert.ToDateTime(this.txtAppTime.Value.Trim());
            if (!string.IsNullOrEmpty(this.txtAppToTime.Value.Trim()))
                SearchDto.AppToTime = Convert.ToDateTime(this.txtAppToTime.Value.Trim());
            SearchDto.OrderType = Convert.ToInt32(this.ddlApplyType.SelectedValue);
            SearchDto.KeyWord = this.txtKeyWord.Value;
            //ds = da_OfficeAutomation_Main_Inherit.Search_New(bool.Parse(islawer), Purview.Contains("OA_Search_002"), this.txtApplicationDepartment.Value, this.txtApplicant.Value
            //        , this.txtApplyDate.Value, this.txtEndDate.Value, hdTypeID.Value, dds, EmployeeName, EmployeeID, Purview, this.txtSerialNumber.Value.Trim(), txtKeyWord.Value, ddlApplyType.SelectedValue, sta, txtApprover.Value, txtAppTime.Value, txtAppToTime.Value, bool.Parse(willDel), intereststype);
            ds = da_OfficeAutomation_Main_Inherit.Search_New_II(SearchDto);
        }
        //ds = da_OfficeAutomation_Main_Inherit.Search(Purview.Contains("OA_Search_002"), this.txtApplicationDepartment.Value, this.txtApplicant.Value
        //        , this.txtApplyDate.Value, this.txtEndDate.Value, hdTypeID.Value, this.ddlState.SelectedValue, EmployeeName, EmployeeID, Purview, this.txtSerialNumber.Value, txtKeyWord.Value);

        gvData.DataSource = ds;
        gvData.PageIndex = pageindex;
        gvData.DataBind();
    }

    /// <summary>
    /// 查询按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["V_sear"] = "1";
        gvData.PageIndex = 0;
        BindData();
        string[] hdN;
        hdN = ("70,9,10,62,63,17,14,15,16,25,29,13,42,6,24,21,23,12,55,56,77,78,80,8,84,31,95,45,30").Split(','); //主表主键 //M_Excel 20161221加上公基金特殊申请也可以导出数据
        if (((IList)hdN).Contains(hdTypeID.Value))
        {

            try
            {
                if ((UnitID == "108e0f54-5070-4745-a491-37f15d5a86cc"
                    || EmployeeID == "0001"
                    || EmployeeID == "22563" //黄筑筠
                    || EmployeeID == "3030" //谢芃
                    || EmployeeID == "11523" //郭敏洁
                    || EmployeeID == "50203"
                    || EmployeeID == "28614" //蓝晴
                    || EmployeeID == "54917" //张婉晴
                    || EmployeeID == "38802" //陈一鸣
                    || EmployeeID == "5703" //谭青华
                    || EmployeeID == "39647" //顾慧
                    || UnitName == "法律部"
                    || Purview.Contains("OA_Search_002"))
                    && (hdTypeID.Value == "25"
                    || hdTypeID.Value == "16"
                    || hdTypeID.Value == "62"
                    || hdTypeID.Value == "63"
                    || hdTypeID.Value == "17"
                    || hdTypeID.Value == "13")) //总办和系统管理员才可导出
                    btExcel.Visible = true;
                //应收款管理组
                else if ("5c473cf7-d65a-4d64-a50e-ab17c484fc60".Equals(UnitID) || "50203".Equals(EmployeeID))
                {
                    btExcel.Visible = true;
                }
                else if ((UnitID == "108e0f54-5070-4745-a491-37f15d5a86cc"
                    || EmployeeID == "0001"
                    || UnitName == "法律部"
                    || EmployeeID == "0001"
                    || EmployeeID == "2377" //陈洁丽
                    || EmployeeID == "17257" //顾思娜
                    || EmployeeID == "39647" //顾慧
                    || EmployeeID == "3030" //谢芃
                    || EmployeeID == "3873" //林亦玲
                    || EmployeeID == "45362" //李卉
                    || Purview.Contains("OA_Search_002"))
                    && (hdTypeID.Value == "14"
                    || hdTypeID.Value == "15"
                    || hdTypeID.Value == "12"
                    )) //总办、法律部人员和系统管理员才可导出
                    btExcel.Visible = true;
                else if ((EmployeeID == "17913" || EmployeeID == "16570" || EmployeeID == "2519" || EmployeeID == "54894" || Purview.Contains("OA_Search_002"))
                    && hdTypeID.Value == "29") //梁碧莹、许海燕、林曼莹和系统管理员才可导出
                    btExcel.Visible = true;
                else if (EmployeeID == "45362" || EmployeeID == "50203" || Purview.Contains("OA_Search_051") && hdTypeID.Value == "45")
                    btExcel.Visible = true;
                else if ((EmployeeID == "33690" || EmployeeID == "23799" || EmployeeID == "50203" || Purview.Contains("OA_Search_002"))
                    && (hdTypeID.Value == "42"
                    || hdTypeID.Value == "24"
                    || hdTypeID.Value == "21"
                    || hdTypeID.Value == "23"
                    || hdTypeID.Value == "80"
                    || hdTypeID.Value == "84"
                    || hdTypeID.Value == "95"
                    )) //张晓莹
                    btExcel.Visible = true;
                else if ((EmployeeID == "19173" //周燕妮
                    || EmployeeID == "39591" //招琛彤
                    || EmployeeID == "2696" //李凤娟
                    || EmployeeID == "16947" //文玉仪
                    || Purview.Contains("OA_Search_002"))
                    && (hdTypeID.Value == "55"
                    || hdTypeID.Value == "56"
                    ))
                    btExcel.Visible = true;
                else if ((EmployeeID == "17642")
               && (hdTypeID.Value == "31"))
                {
                    btExcel.Visible = true;
                }
                else if ((EmployeeID == "30602" //朱晓晴
                    || EmployeeID == "33690" //张晓莹
                    //|| EmployeeID == "16945" //胡雅丝 
                    || EmployeeID == "43781" //钟惠贤 2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    || Purview.Contains("OA_Search_002"))
                    && (hdTypeID.Value == "9"
                    || hdTypeID.Value == "10"
                    || hdTypeID.Value == "70"
                    ))
                    btExcel.Visible = true;
                else if ((EmployeeID == "20861" //麦诗铭
                        || Purview.Contains("OA_Search_002"))
                    && hdTypeID.Value == "77")
                {
                    btExcel.Visible = true;
                }
                else if ((Purview.Contains("OA_Search_002") || Purview.Contains("OA_Search_083"))
                    && hdTypeID.Value == "78")
                {
                    btExcel.Visible = true;
                }

                else if ((EmployeeID == "31317" || EmployeeID == "37651" || EmployeeID == "42900" || EmployeeID == "71880") && hdTypeID.Value == "8") //
                {
                    btnInterestsExcel.Visible = true;
                }

                else if (Purview.Contains("OA_Search_002")) //管理员导出
                {
                    btExcel.Visible = true;
                }
                else if ((EmployeeID == "42508" || EmployeeID == "28614" || EmployeeID == "5703" || EmployeeID == "51673" || EmployeeID == "54917" //雷安然、蓝晴
                        && hdTypeID.Value == "12"
                    ))
                {
                    btExcel.Visible = true;
                }
                else
                {
                    btExcel.Visible = false;
                    btnInterestsExcel.Visible = false;
                }
            }
            catch
            {
            }
        }
        else
        {
            btExcel.Visible = false;
            btnInterestsExcel.Visible = false;
        }
    }

    /// <summary>
    /// gvData行数据绑定事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string url = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Text = e.Row.Cells[7].Text.Replace("&amp;#x0D;", "，");
            if (e.Row.Cells[6].Text.Contains("（1）"))
                e.Row.Cells[6].Text = "未审批";
            else if (e.Row.Cells[6].Text.Contains("（2）"))
                e.Row.Cells[6].Text = "审批中";
            else if (e.Row.Cells[6].Text.Contains("（7）"))
                e.Row.Cells[6].Text = "暂时保存中";
            else if (e.Row.Cells[6].Text.Contains("（8）"))
                e.Row.Cells[6].Text = "已过期";
            e.Row.Attributes.Add("onmouseover", "javascript:c=this.style.backgroundColor;this.style.background='#B0E0E6';");
            e.Row.Attributes.Add("onmouseout", "javascript:this.style.background=c;");
            DataRowView drv = (DataRowView)e.Row.DataItem;

            ImageButton imageBtn = (ImageButton)e.Row.Cells[7].FindControl("iBtnDelete"); //20141219：M_DeleteC 根据情况进行删除提示
            //DataSet dsd = new DataSet();
            //DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inheritd = new DA_OfficeAutomation_Main_Inherit();
            //dsd = da_OfficeAutomation_Main_Inheritd.SelectBySerialNumber(drv.Row["OfficeAutomation_SerialNumber"].ToString()); //20141231：M_DeleteC
            try
            {
                //if (dsd.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "1")
                //if (ViewState["V_DeleteC"].ToString() == "1")
                if (drv.Row["OfficeAutomation_Main_FlowStateID"].ToString() == "1" || drv.Row["OfficeAutomation_Main_FlowStateID"].ToString() == "8")//2016/8/31 52100
                    imageBtn.Attributes.Add("onclick", "return confirm('确定要删吗？');");
                //e.Row.Attributes.Add("onmouseover", "javascript:c=this.style.backgroundColor;this.style.background='#C0E1B6';");
                else
                    imageBtn.Attributes.Add("onclick", "return confirm('该操作需要已审批的人员全部同意后才能删除，确认要删除吗？');");
            }
            catch
            {
            }

            if (e.Row.RowIndex > -1)
            {
                //为表体提供鼠标单击弹出功能
                string applypath = "";

                //======2016-8-15 JohnMingle======
                string[] result = Common.getDocumentLink(drv.Row["OfficeAutomation_Document_Name"].ToString(), drv.Row["ApplyDate"].ToString()).Split('|');

                applypath = result[0];
                ViewState["F_Model"] = result[1];
                //================================

                #region 注释掉的

                //switch (drv.Row["OfficeAutomation_Document_Name"].ToString())
                //{
                //    case "(物业部/工商铺)IT权限申请表":
                //        applypath = "ITPower/Apply_ITPower_Detail";
                //        ViewState["F_Model"] = "1";
                //        break;
                //    case "软件系统开发需求申请表":
                //        applypath = "SysReq/Apply_SysReq_Detail";
                //        ViewState["F_Model"] = "5";
                //        break;
                //    case "(后勤/汇瀚/二级市场)IT权限申请表":
                //        applypath = "SysPower/Apply_SysPower_Detail";
                //        ViewState["F_Model"] = "6";
                //        break;
                //    case "报废申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse("2015-12-07 12:30:00.999"))
                //            applypath = "Scrap/Old/Apply_Scrap_Detail";
                //        else
                //            applypath = "Scrap/Old/Apply_Scrap_Detail";

                //        ViewState["F_Model"] = "7";
                //        break;
                //    case "资产调动表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse("3015-12-07 12:30:00.999"))
                //            applypath = "AssetTransfer/Apply_AssetTransfer_Detail";
                //        else
                //            applypath = "AssetTransfer/Old/Apply_AssetTransfer_Detail";

                //        ViewState["F_Model"] = "8";
                //        break;
                //    case "物业部成交商铺/写字楼备案申请表":
                //        applypath = "DealOffice/Apply_DealOffice_Detail";
                //        ViewState["F_Model"] = "10";
                //        break;
                //    case "计算机及相关设备购买申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse("2015-12-07 12:30:00.999"))
                //            applypath = "ITBuy/20151207/Apply_ITBuy_Detail";
                //        else
                //            applypath = "ITBuy/Apply_ITBuy_Detail";

                //        ViewState["F_Model"] = "11";
                //        break;
                //    case "员工个人利益申报表":
                //        applypath = "PersInterests/Apply_PersInterests_Detail";
                //        ViewState["F_Model"] = "12";
                //        break;
                //    case "员工个人利益申报表 ":
                //        applypath = "PersInterests/Apply_NewPersInterests_Detail";
                //        ViewState["F_Model"] = "53";
                //        break;
                //    case "员工购租楼宇申报及免佣福利申请表":
                //        applypath = "BuyBuilding/Apply_BuyBuilding_Detail";
                //        ViewState["F_Model"] = "13";
                //        break;
                //    case "小汽车津贴申请表":
                //        applypath = "CarAllowance/Apply_CarAllowance_Detail";
                //        ViewState["F_Model"] = "14";
                //        break;
                //    case "退佣申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                //            applypath = "BackComm/Apply_BackComm_Detail";
                //        else
                //            applypath = "Old/BackComm/Apply_BackComm_Detail";

                //        ViewState["F_Model"] = "15";
                //        break;
                //    case "坏账申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                //            applypath = "BadDebts/Apply_BadDebts_Detail";
                //        else
                //            applypath = "Old/BadDebts/Apply_BadDebts_Detail";
                //        ViewState["F_Model"] = "16";
                //        break;
                //    case "减佣/让佣申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse(CommonConst.REDUCECOMM_OLD_TIME))
                //            applypath = "ReduceComm/Apply_NewReduceComm_Detail";
                //        else
                //            applypath = "ReduceComm/Apply_ReduceComm_Detail";
                //        ViewState["F_Model"] = "17";
                //        break;
                //    case "项目费用申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                //            applypath = "ProjCost/Apply_ProjCost_Detail";
                //        else
                //            applypath = "Old/ProjCost/Apply_ProjCost_Detail";
                //        ViewState["F_Model"] = "18";
                //        break;
                //    case "合作费申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                //            applypath = "CoopCost/Apply_CoopCost_Detail";
                //        else
                //            applypath = "Old/CoopCost/Apply_CoopCost_Detail";
                //        ViewState["F_Model"] = "19";
                //        break;
                //    case "物业部承接项目报备申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse("2014-08-07 16:15:00.999"))
                //            applypath = "UndertakeProj/Apply_NewUndertakeProj_Detail";
                //        else
                //            applypath = "UndertakeProj/Apply_UndertakeProj_Detail";
                //        ViewState["F_Model"] = "20";
                //        break;
                //    case "项目发展商额外奖金报备":
                //        applypath = "ExtraBonus/Apply_ExtraBonus_Detail";
                //        ViewState["F_Model"] = "21";
                //        break;
                //    case "恢复营业申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                //            applypath = "ResumeBusi/Apply_ResumeBusi_Detail";
                //        else
                //            applypath = "Old/ResumeBusi/Apply_ResumeBusi_Detail";
                //        ViewState["F_Model"] = "22";
                //        break;
                //    case "撤铺/转铺申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse("2015-11-12 23:59:59.999"))
                //            applypath = "WithdrawShop/Apply_WithdrawShop_Detail";
                //        else
                //            applypath = "WithdrawShop/Old/Apply_WithdrawShop_Detail";
                //        ViewState["F_Model"] = "23";
                //        break;
                //    case "暂停营业申请表":
                //        //applypath = "SuspendBusi/Apply_SuspendBusi_Detail";
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse("2015-08-06"))
                //        {
                //            if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                //                applypath = "SuspendBusi/Apply_SuspendBusi_Detail";
                //            else
                //                applypath = "Old/SuspendBusi/Apply_SuspendBusi_Detail";
                //        }
                //        else
                //            applypath = "SuspendBusi/Temp/Apply_SuspendBusi_Detail";
                //        ViewState["F_Model"] = "24";
                //        break;
                //    case "项目销售代理合同条款申请表":
                //        applypath = "ProjAgentClause/Apply_ProjAgentClause_Detail";
                //        ViewState["F_Model"] = "25";
                //        break;
                //    case "项目工衣申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                //            applypath = "ProjWorkCloth/Apply_ProjWorkCloth_Detail";
                //        else
                //            applypath = "Old/ProjWorkCloth/Apply_ProjWorkCloth_Detail";
                //        ViewState["F_Model"] = "26";
                //        break;
                //    case "项目宿舍及津贴费用申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                //            applypath = "ProjDormSubsiby/Apply_ProjDormSubsiby_Detail";
                //        else
                //            applypath = "Old/ProjDormSubsiby/Apply_ProjDormSubsiby_Detail";
                //        ViewState["F_Model"] = "27";
                //        break;
                //    case "项目报数申请表":
                //        applypath = "ProjRepoData/Apply_ProjRepoData_Detail";
                //        ViewState["F_Model"] = "28";
                //        break;
                //    case "项目联动报数申请表":
                //        applypath = "ProjLinkRepoData/Apply_ProjLinkRepoData_Detail";
                //        ViewState["F_Model"] = "29";
                //        break;

                //    case "变更资料申请表":
                //        applypath = "ChangeData/Apply_ChangeData_Detail";
                //        ViewState["F_Model"] = "30";
                //        break;
                //    case "应收佣金调整报告":
                //        applypath = "CommissionAdjust/Apply_CommissionAdjust_Detail";
                //        ViewState["F_Model"] = "31";
                //        break;
                //    case "无线固话申请表":
                //        applypath = "WirelessFixedLine/Apply_WirelessFixedLine_Detail";
                //        ViewState["F_Model"] = "32";
                //        break;
                //    case "进修津贴申请表":
                //        applypath = "FurtherEducation/Apply_FurtherEducation_Detail";
                //        ViewState["F_Model"] = "33";
                //        break;
                //    case "特殊上数申请表":
                //        applypath = "SpecialNumber/Apply_SpecialNumber_Detail";
                //        ViewState["F_Model"] = "34";
                //        break;
                //    case "公章使用申请表":
                //        applypath = "OfficialSeal/Apply_OfficialSeal_Detail";
                //        ViewState["F_Model"] = "35";
                //        break;
                //    case "分行续约申请报告":
                //        applypath = "BranchContract/Apply_BranchContract_Detail";
                //        ViewState["F_Model"] = "36";
                //        break;
                //    case "营运部门自组织外出活动申请":
                //        applypath = "Tourism/Apply_Tourism_Detail";
                //        ViewState["F_Model"] = "37";
                //        break;
                //    case "延缓提交入职资料申请":
                //        applypath = "OweSubmit/Apply_OweSubmit_Detail";
                //        ViewState["F_Model"] = "38";
                //        break;
                //    case "新分行总启费用申请表":
                //        applypath = "TotalRev/Apply_TotalRev_Detail";
                //        ViewState["F_Model"] = "39";
                //        break;
                //    case "新建分行可行性报告":
                //        applypath = "Feasibility/Apply_Feasibility_Detail";
                //        ViewState["F_Model"] = "40";
                //        break;
                //    case "物业部一手项目追佣申请表":
                //        applypath = "AfterCommission/Apply_AfterCommission_Detail";
                //        ViewState["F_Model"] = "41";
                //        break;
                //    case "法律部追佣合作费处理申请":
                //        applypath = "LegalCommission/Apply_LegalCommission_Detail";
                //        ViewState["F_Model"] = "42";
                //        break;
                //    case "通用申请表":
                //        applypath = "GeneralApply/Apply_GeneralApply_Detail";
                //        ViewState["F_Model"] = "43";
                //        break;
                //    case "合同条款申请表":
                //        applypath = "ContractTerms/Apply_ContractTerms_Detail";
                //        ViewState["F_Model"] = "44";
                //        break;
                //    case "超成数备案":
                //        applypath = "NetSign/Apply_NetSign_Detail";
                //        ViewState["F_Model"] = "45";
                //        break;
                //    case "关于享受本月佣金按全年一次性奖金发放申请表":
                //        applypath = "CommissionOfMonth/Apply_CommissionOfMonth_Detail";
                //        ViewState["F_Model"] = "46";
                //        break;
                //    case "市场推广费用申请":
                //        applypath = "Marketing/Apply_Marketing_Detail";
                //        ViewState["F_Model"] = "47";
                //        break;
                //    case "资产借调申请表":
                //        applypath = "Secondment/Apply_Secondment_Detail";
                //        ViewState["F_Model"] = "48";
                //        break;
                //    case "三级市场季会活用费用申请表":
                //        applypath = "CostOfActivity/Apply_CostOfActivity_Detail";
                //        ViewState["F_Model"] = "49";
                //        break;
                //    case "项目部代理合同扣罚条款签名确认表":
                //        applypath = "PunishTerms/Apply_PunishTerms_Detail";
                //        ViewState["F_Model"] = "50";
                //        break;
                //    case "网签变更、特殊申请表":
                //        applypath = "ChangeNS/Apply_ChangeNS_Detail";
                //        ViewState["F_Model"] = "51";
                //        break;
                //    case "特殊个案申请表":
                //        applypath = "SpecialCase/Apply_SpecialCase_Detail";
                //        ViewState["F_Model"] = "52";
                //        break;
                //    case "社保公积金特殊缴纳申请表":
                //        applypath = "SocialSecurity/Apply_SocialSecurity_Detail";
                //        ViewState["F_Model"] = "54";
                //        break;
                //    //case "网络端口考核数据确认表":
                //    //    applypath = "PortAssessment/Apply_PortAssessment_Detail";
                //    //    ViewState["F_Model"] = "55";
                //    //    break;
                //    case "小汽车津贴申请表（项目部）":
                //        applypath = "ProjectCarAllowance/Apply_ProjectCarAllowance_Detail";
                //        ViewState["F_Model"] = "56";
                //        break;
                //    case "大额维修申请表":
                //        applypath = "Maintenance/Apply_Maintenance_Detail";
                //        ViewState["F_Model"] = "57";
                //        break;
                //    case "新增、维修项目报价（结算）明细表":
                //        applypath = "Repair/Apply_Repair_Detail";
                //        ViewState["F_Model"] = "58";
                //        break;
                //    case "广告宣传需求申请表":
                //        applypath = "Propaganda/Apply_Propaganda_Detail";
                //        ViewState["F_Model"] = "59";
                //        break;
                //    case "广告宣传预算使用异常申请表":
                //        applypath = "Budgetab/Apply_Budgetab_Detail";
                //        ViewState["F_Model"] = "60";
                //        break;
                //    case "发展商额外奖金新增申请及调整申请":
                //        applypath = "EBAdjuct/Apply_EBAdjuct_Detail";
                //        ViewState["F_Model"] = "61";
                //        break;
                //    case "担保申请":
                //        applypath = "Guarantee/Apply_Guarantee_Detail";
                //        ViewState["F_Model"] = "62";
                //        break;
                //    case "关于签署两方版本担保协议书的申请":
                //        applypath = "SignedG/Apply_SignedG_Detail";
                //        ViewState["F_Model"] = "63";
                //        break;
                //    case "三级市场一手项目欠必要性文件拉数申请":
                //        applypath = "PullafewRd/Apply_PullafewRd_Detail";
                //        ViewState["F_Model"] = "64";
                //        break;
                //    case "二级市场一手项目欠必要性文件拉数申请":
                //        applypath = "PullafewTwo/Apply_PullafewTwo_Detail";
                //        ViewState["F_Model"] = "65";
                //        break;
                //    case "物业部项目续约申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse("2015-10-28 23:50:00.999"))
                //            applypath = "UndertakeProj/201510/Apply_UtContract_Detail";
                //        else
                //            applypath = "UndertakeProj/201509/Apply_UtContract_Detail";
                //        ViewState["F_Model"] = "66";
                //        break;
                //    case "物业部承接新项目申请表":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) > DateTime.Parse("2015-10-28 23:50:00.999"))
                //            applypath = "UndertakeProj/201510/Apply_UtNewProj_Detail";
                //        else
                //            applypath = "UndertakeProj/201509/Apply_UtNewProj_Detail";
                //        ViewState["F_Model"] = "67";
                //        break;
                //    case "项目报数申请表(物业部加签)":
                //        applypath = "ProjReDaAdd/Apply_ProjReDaAdd_Detail";
                //        ViewState["F_Model"] = "68";
                //        break;
                //    case "错存帐户调整申请表":
                //        applypath = "WrongSave/Apply_WrongSave_Detail";
                //        ViewState["F_Model"] = "69";
                //        break;
                //    case "物业部购买楼盘资料申请":
                //        applypath = "BuyBudiData/Apply_BuyBudiData_Detail";
                //        ViewState["F_Model"] = "70";
                //        break;
                //    case "项目部实收佣金调整申请表":
                //        applypath = "ProjBaComm/Apply_ProjBaComm_Detail";
                //        ViewState["F_Model"] = "71";
                //        break;
                //    case "临时借用资金申请表":
                //        applypath = "BorrowMoney/Apply_BorrowMoney_Detail";
                //        ViewState["F_Model"] = "72";
                //        break;
                //    case "特殊增编申请表":
                //        applypath = "SpecialAdd/Apply_SpecialAdd_Detail";
                //        ViewState["F_Model"] = "73";
                //        break;
                //    case "薪酬福利类证明开具申请表":
                //        applypath = "OpenProve/Apply_OpenProve_Detail";
                //        ViewState["F_Model"] = "74";
                //        break;
                //    case "项目部兼职申请":
                //        applypath = "PartTime/Apply_PartTime_Detail";
                //        ViewState["F_Model"] = "75";
                //        break;
                //    case "申请内容修改申请表":
                //        applypath = "SysLogist/Apply_SysLogist_Detail";
                //        ViewState["F_Model"] = "76";
                //        break;
                //    case "物业部批量解hold申请":
                //        applypath = "SolHold/Apply_SolHold_Detail";
                //        ViewState["F_Model"] = "77";
                //        break;
                //    case "解除汇瀚HOLD佣申请":
                //        if (DateTime.Parse(drv.Row["ApplyDate"].ToString()) >= DateTime.Parse("2016-07-26"))
                //        {
                //            applypath = "HoldCoisn/20160712/Apply_HoldCoisn_Detail";
                //        }
                //        else
                //        {
                //            applypath = "HoldCoisn/Apply_HoldCoisn_Detail";
                //        }
                //        ViewState["F_Model"] = "78";
                //        break;
                //    case "备案必须的内容":
                //        applypath = "Record/Apply_Record_Detail";
                //        ViewState["F_Model"] = "79";
                //        break;
                //    case "新建呼叫中心可行性报告":
                //        applypath = "CallCenterFeasibility/Apply_CallCenterFeasibility_Detail";
                //        ViewState["F_Model"] = "80";
                //        break;
                //    case "物业部自主招聘申请":
                //        applypath = "WYRecruit/Apply_WYRecruit_Detail";
                //        ViewState["F_Model"] = "81";
                //        break;
                //    case "招聘需求申请":
                //        applypath = "Recruit/Apply_Recruit_Detail";
                //        ViewState["F_Model"] = "82";
                //        break;
                //    case "项目部佣金分配指引":
                //        applypath = "CommissionAssign/Apply_CommissionAssign_Detail";
                //        ViewState["F_Model"] = "83";
                //        break;
                //    case "公积金特殊申请表":
                //        applypath = "HousingFundChange/Apply_HousingFundChange_Detail";
                //        ViewState["F_Model"] = "84";
                //        break;
                //    default:
                //        break;
                //}

                #endregion

                //张绍欣 要求该份申请急加营运中心
                if (gvData.DataKeys[e.Row.RowIndex][0].ToString() == "786bc3db-b25e-4f4e-b1ca-2b35c9ca61d0")
                {
                    applypath = "Tourism/new/Apply_Tourism_Detail";
                }
                else
                {

                    var F_Model = ViewState["F_Model"].ToString();

                    switch (F_Model)
                    {
                        case "105":
                            url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString() + "&t=2";
                            break;
                        case "108":
                            url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString() + "&t=Inservice";
                            break;
                        case "109":
                            url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString() + "&t=Dimission";
                            break;
                        case "110":
                            url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString() + "&t=PersonalChange";
                            break;
                        default:
                            url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString();
                            break;
                    }




                    //if (ViewState["F_Model"].ToString() == "105")
                    //{
                    //    url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString() + "&t=2";
                    //}

                    //#region [人事事务类-联动统筹中心申请]
                    //if (ViewState["F_Model"].ToString() == "108")
                    //{
                    //    url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString() + "&t=Inservice";
                    //}

                    //if (ViewState["F_Model"].ToString() == "109")
                    //{
                    //    url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString() + "&t=Dimission";
                    //}

                    //if (ViewState["F_Model"].ToString() == "110")
                    //{
                    //    url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString() + "&t=PersonalChange";
                    //}
                    //#endregion


                    //url = applypath + ".aspx?MainID=" + gvData.DataKeys[e.Row.RowIndex][0].ToString();
                }

                //if (GetQueryString("do") == "waitforme")
                //    url += "&do=waitforme";
                if (GetQueryString("do") == "waitforme" && ViewState["V_sear"].ToString() == "0") //M_waitforme：20150326
                    url += "&islawer=False&dep=&apply=&start=&end=&type=&state=7&ctype=0&curpage=" + gvData.PageIndex + "&serialnumber=&keyword=&approver=&apptime=&DeleteA=False";
                else if (GetQueryString("do") == "Lawer" && ViewState["V_sear"].ToString() == "0")
                    url += "&islawer=True&dep=&apply=&start=&end=&type=&state=7&ctype=0&curpage=" + gvData.PageIndex + "&serialnumber=&keyword=&approver=&apptime=&DeleteA=False";
                else if (GetQueryString("do") == "DeleteA" && ViewState["V_sear"].ToString() == "0") //M_DeleteAdd 20151230
                    url += "&islawer=False&dep=&apply=&start=&end=&type=&state=10&ctype=0&curpage=" + gvData.PageIndex + "&serialnumber=&keyword=&approver=&apptime=&DeleteA=True";
                else
                    url += "&islawer=" + bool.Parse(islawer) + "&dep=" + this.txtApplicationDepartment.Value + "&apply=" + Server.UrlEncode(txtApplicant.Value) + "&start=" + txtApplyDate.Value + "&end=" + txtEndDate.Value + "&type=" + hdTypeID.Value + "&state=" + ddlState.SelectedValue + "&ctype=" + ddlApplyType.SelectedIndex + "&curpage=" + gvData.PageIndex + "&serialnumber=" + txtSerialNumber.Value + "&keyword=" + Server.UrlEncode(txtKeyWord.Value) + "&approver=" + Server.UrlEncode(txtApprover.Value) + "&apptime=" + txtAppTime.Value + "&DeleteA=" + bool.Parse(willDel);
                e.Row.Attributes.Add("onDblClick", @"window.location='" + url + "'");
            }

            ImageButton iBtn = e.Row.FindControl("iBtnDelete") as ImageButton;
            CheckBox cbx = e.Row.FindControl("ChkSelected") as CheckBox;
            //string names = "简圣钊,李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,陈洁丽"; //20140918++++：法律部的人审批了以后，只有names里的人及管理员才能删除
            //string[] employnames;
            //employnames = names.Split(',');
            if (Purview.Contains("OA_Search_003"))//管理员删除
            {
                imageBtn.Attributes.Add("name", "DeleteD"); //M_nWarning+：发布时需开启
                imageBtn.Attributes.Remove("onclick");
                imageBtn.Attributes.Add("onclick", "return confirm('确定要删除吗？');"); //M_nWarning-
                iBtn.Visible = true;
            }
            else if (drv.Row["Apply"].ToString().Contains(EmployeeName) && drv.Row["OfficeAutomation_Main_FlowStateID"].ToString() != "3")//2014-3-24修改为只要申请表不为已完成状态，申请人可删除
            {
                if (drv.Row["waitfor"].ToString() == "待陈洁丽审核" || drv.Row["waitfor"].ToString() == "待黄轩明审核"/* || drv.Row["waitfor"].ToString() == "已完成"*/)
                    iBtn.Visible = false;
                else
                    iBtn.Visible = true;
            }

            try //M_SelectCkd：20150310
            {
                if (((EmployeeName == "吴卓霖" && drv.Row["waitfor"].ToString().Contains("吴卓霖"))
                    || (EmployeeName == "张晓莹" && drv.Row["waitfor"].ToString().Contains("张晓莹"))
                    || (EmployeeName == "郑纯宁" && drv.Row["waitfor"].ToString().Contains("郑纯宁"))
                    || (EmployeeName == "邱超琼" && drv.Row["waitfor"].ToString().Contains("邱超琼"))
                    || (EmployeeName == "李小霞" && drv.Row["waitfor"].ToString().Contains("李小霞"))
                    || (EmployeeName == "陈一鸣" && drv.Row["waitfor"].ToString().Contains("陈一鸣"))
                    || (EmployeeName == "周松伟" && drv.Row["waitfor"].ToString().Contains("周松伟"))
                     || (EmployeeName == "曹雄" && drv.Row["waitfor"].ToString().Contains("曹雄"))
                    )
                    && (drv.Row["OfficeAutomation_Document_Name"].ToString() == "关于享受本月佣金按全年一次性奖金发放申请表" || drv.Row["OfficeAutomation_Document_Name"].ToString() == "公积金特殊申请表" || drv.Row["OfficeAutomation_Document_Name"].ToString() == "公积金缴存比例年度调整申请表")
                    )
                    cbx.Visible = true;
                else if ((EmployeeID == "31317" || EmployeeID == "37651" || EmployeeID == "42900" || EmployeeID == "50203" || EmployeeID == "71880") && hdTypeID.Value == "8")
                {

                    cbx.Visible = true;
                }
                else if ((EmployeeID == "50203" || EmployeeID == "23799" || EmployeeID == "33102") && hdTypeID.Value == "95")
                {
                    cbx.Visible = true;
                }
                //陈慧明 11322 黎新枝 54723 许乐怡 42666 黄丹敏 5940 宁伟雄 5585   雷启成 58455
                else if ((EmployeeID == "50203" || EmployeeID == "11322" || EmployeeID == "54723" || EmployeeID == "42666" || EmployeeID == "5940" || EmployeeID == "5585" || EmployeeID == "58455") && (hdTypeID.Value == "85" || hdTypeID.Value == "65"))
                {
                    cbx.Visible = true;
                }
                else
                {
                    cbx.Visible = false;
                }
            }
            catch
            {
            }

            employnamesf = namesf.Split(',');
            for (int i = 0; i < employnamesf.Length; i++)
            {
                if (EmployeeName.Contains(employnamesf[i]))
                {
                    if (drv.Row["waitfor"].ToString() == "待陈洁丽审核" || drv.Row["waitfor"].ToString() == "待黄轩明审核"/* || drv.Row["waitfor"].ToString() == "已完成"*/)
                    {
                        imageBtn.Attributes.Remove("onclick");
                        imageBtn.Attributes.Add("onclick", "return confirm('确定要删除该表吗？');");
                        imageBtn.Attributes.Add("name", "DeleteD");
                        iBtn.Visible = true;
                    }
                }
            }

            ImageButton iBtnDetail = e.Row.FindControl("iBtnDetail") as ImageButton;
            iBtnDetail.PostBackUrl = url;
            //ViewState["url"] = url;
        }
    }
    /// <summary>
    /// gvData行命令事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        string commType = e.CommandName.ToString();
        if (e.CommandName == "Pageindex")
        {
            string d = hdPagerNum.Value;
        }
        switch (commType)
        {
            case "Del":
                if (Purview.Contains("OA_Search_001"))
                {
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(e.CommandArgument.ToString());
                    string ys = ds.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString();
                    //string ys = "2";
                    if (ys != "3" || Purview.Contains("OA_Search_003"))//*-
                    {
                        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                        ImageButton imageBtn = (ImageButton)gvr.Cells[1].FindControl("iBtnDelete");
                        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(e.CommandArgument.ToString());
                        if (ds.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "1" || ds.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "7" || imageBtn.Attributes["name"] == "DeleteD" || ds.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "8")
                        {


                            if (documentName == "资产调动表")
                            {
                                DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                                DataSet dsDetail = new DataSet();
                                dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(e.CommandArgument.ToString());
                                foreach (DataRow dr in dsDetail.Tables[0].Rows)
                                {
                                    try
                                    {
                                        LogCommonFunction.AddLog(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString(), "资产调动删除前");
                                    }
                                    catch (Exception)
                                    {

                                    }
                                    wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                                    bool reuslt = true;
                                    string s = dr["OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID"].ToString();
                                    if (!string.IsNullOrEmpty(s))
                                    {
                                        reuslt = ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID"].ToString());

                                    }
                                    try
                                    {
                                        LogCommonFunction.AddLog(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString(), "资产调动删除 " + reuslt.ToString());
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                            }
                            if (documentName == "报废申请表")
                            {
                                DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
                                DataSet dsDetail = new DataSet();
                                dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(e.CommandArgument.ToString());
                                foreach (DataRow dr in dsDetail.Tables[0].Rows)
                                {
                                    try
                                    {
                                        LogCommonFunction.AddLog(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString(), "报废资产删除前");
                                    }
                                    catch (Exception)
                                    {

                                    }
                                    wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                                    string s = dr["OfficeAutomation_Document_Scrap_Detail_AdjustmentID"].ToString();
                                    bool reuslt = true;
                                    if (!string.IsNullOrEmpty(s))
                                    {
                                        reuslt = ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AdjustmentID"].ToString());
                                    }
                                    try
                                    {
                                        LogCommonFunction.AddLog(dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString(), "报废资产删除" + reuslt.ToString());
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                            }

                            if (documentName == "资产借调申请表")
                            {
                                DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();
                                DataSet dst = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(MainID);
                                DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
                                da_OfficeAutomation_Document_Assets_Inherit.UpdateToggleZero(dst.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_ApplyID"].ToString(), 1);
                                var detail = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit().SelectByMainID(e.CommandArgument.ToString());
                                wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                                foreach (DataRow dr in detail.Tables[0].Rows)
                                {
                                    try
                                    {
                                        LogCommonFunction.AddLog(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString(), "资产借调删除前");
                                    }
                                    catch (Exception)
                                    {

                                    }
                                    bool reuslt = ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString());
                                    try
                                    {
                                        LogCommonFunction.AddLog(dr["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString(), "资产借调删除" + reuslt.ToString());
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                            }
                            if ("物业部项目续约申请表".Equals(documentName) || "物业部承接新项目申请表".Equals(documentName))
                            {
                                if (da_OfficeAutomation_Main_Inherit.IsUtDelete(ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString()))
                                {
                                    Alert("此报备编号已在佣金系统使用。");
                                    return;
                                }

                            }
                            BindData();
                            RunJS("alert('删除记录" + (da_OfficeAutomation_Main_Inherit.LogicDelete(e.CommandArgument.ToString()) ? "成功!" : "失败!") + "');window.location.href='Apply_Search.aspx?do=DeleteA';");
                            Common.AddLog(EmployeeID, EmployeeName, int.Parse(ViewState["F_Model"].ToString()), new Guid(e.CommandArgument.ToString()), 3);

                        }
                        else //20141219：M_DeleteC
                        {
                            if ("物业部项目续约申请表".Equals(documentName) || "物业部承接新项目申请表".Equals(documentName))
                            {
                                if (da_OfficeAutomation_Main_Inherit.IsUtDelete(ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString()))
                                {
                                    Alert("此报备编号已在佣金系统使用。");
                                    return;
                                }

                            }
                            ImageButton iBtnDetail = (ImageButton)gvr.Cells[1].FindControl("iBtnDetail");
                            RunJS("if(window.showModalDialog(\"Apply_DeleteDialog.aspx?mainID=" + e.CommandArgument.ToString() + "&url=" + iBtnDetail.PostBackUrl + "\", '" + e.CommandArgument.ToString() + "', \"dialogHeight=260px;dialogWidth=665px;\") == 'success')window.location.href=window.location.href;");
                        }
                    }
                    else
                        RunJS("alert('该表已审批完成，不能再删除了。');window.location.href=window.location.href;");
                }
                else
                    Alert("未开通删除权限。");
                break;
            //case "Detail":
            //    Alert("!!!!!!!!!!!!!!!。");
            //    break;
        }

        if (this.gvData.PageIndex + 1 > this.gvData.PageCount)
        {
            this.gvData.PageIndex = this.gvData.PageCount - 1;
        }

    }

    /// <summary>
    /// gvData页码改变事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        try
        {
            if (GetQueryString("islawer") != "")
                islawer = GetQueryString("islawer");
        }
        catch
        {
        }

        try
        {
            if (GetQueryString("DeleteA") != "")
                willDel = GetQueryString("DeleteA");
        }
        catch
        {
        }

        //重新绑定
        if (GetQueryString("do") == "waitforme" && ViewState["V_sear"].ToString() == "0")
        {
            WaitForMe();
            //BindData();//M_waitforme：20150326
        }
        else if (GetQueryString("do") == "Lawer" && ViewState["V_sear"].ToString() == "0")
        {
            IsLawer();
        }
        else if (GetQueryString("do") == "DeleteA" && ViewState["V_sear"].ToString() == "0") //M_DeleteAdd 20151230
        {
            DeleteA();
        }
        else
            BindData();
    }

    /// <summary>
    /// 法律部查询
    /// </summary>
    private void IsLawer()
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        islawer = "True";
        willDel = "False";
        //if (EmployeeID == "34498"
        //    || EmployeeID == "33690"
        //    || EmployeeID == "15300"
        //    ) //M_SelectCkd：20150310
        //{
        //    ChkSelect.Visible = true;
        //    btnSelectChecked.Visible = true;
        //    chkSelectAll.Checked = false;
        //    chkCancelAll.Checked = false;
        //}
        //else
        //{
        //    ChkSelect.Visible = false;
        //    btnSelectChecked.Visible = false;
        //}
        //ds = da_OfficeAutomation_Main_Inherit.Search_New(true, true, "", ""
        //                , "", "", "", "", EmployeeName, EmployeeID, "", "", "", "1", 3, "", "", "", false, "");
        DataEntity.DTO.SearchFilterDto SearchDto = InitSearchDto(LoginUser);
        SearchDto.ApplyState = 7;   //待我审核
        SearchDto.OrderType = 1;
        SearchDto.WillDelete = false;
        SearchDto.IsLawer = true;
        ds = da_OfficeAutomation_Main_Inherit.Search_Lawer(SearchDto);
        gvData.DataSource = ds;
        gvData.DataBind();
    }

    /// <summary>
    /// 删除查询
    /// </summary>
    private void DeleteA() //M_DeleteAdd 20151230
    {
        willDel = "True";
        islawer = "False";
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        //ds = da_OfficeAutomation_Main_Inherit.Search_New(false, true, "", ""
        //                , "", "", "", "", EmployeeName, EmployeeID, "", "", "", "1", 10, "", "","", true,"");

        //20170702
        DataEntity.DTO.SearchFilterDto SearchDto = InitSearchDto(LoginUser);
        SearchDto.ApplyState = 0;   //待我审核
        SearchDto.OrderType = 1;
        SearchDto.WillDelete = true;

        //代理人
        //if (LoginUser != null && LoginUser.Agents != null && LoginUser.Agents.Count > 0)
        //{
        //    SearchDto.Agents = ChangeAgentDtos(LoginUser.Agents);
        //}
        ds = da_OfficeAutomation_Main_Inherit.Search_New_II(SearchDto);
        gvData.DataSource = ds;
        gvData.DataBind();
    }

    /// <summary>
    /// 待我审核列表数据绑定
    /// </summary>
    private void WaitForMe()
    {
        //DataSet ds = new DataSet();
        //DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        //ds = da_OfficeAutomation_Main_Inherit.WaitForMe(EmployeeID, EmployeeName);
        //gvData.DataSource = ds;
        //gvData.PageIndex = GetQueryInt("curpage", 0);
        //gvData.DataBind();
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        islawer = "False";
        willDel = "False";

        //2101223 注释掉，点击待我审批不显示批量审批按钮，只有选择类型之后才会显示批量审批按钮
        //if (EmployeeID == "34498" 
        //    || EmployeeID == "33690"
        //    || EmployeeID == "15300"
        //    || EmployeeID == "23799"
        //    ) //M_SelectCkd：20150310
        //{ 
        //    ChkSelect.Visible = true;
        //    btnSelectChecked.Visible = true;
        //    chkSelectAll.Checked = false;
        //    chkCancelAll.Checked = false;
        //}
        //else
        //{
        //    ChkSelect.Visible = false;
        //    btnSelectChecked.Visible = false;
        //}
        //注释从这里结束，下面的是之前注释掉的


        //string dds;
        //int sta = 10;
        //if (ddlState.SelectedValue == "")
        //    dds = "";
        //else if (int.Parse(ddlState.SelectedValue) > 3)
        //{
        //    if (int.Parse(ddlState.SelectedValue) <= 6)
        //        dds = "3";
        //    else
        //        dds = "";
        //    switch (ddlState.SelectedValue)
        //    {
        //        case "4":
        //            sta = 1;
        //            break;
        //        case "5":
        //            sta = 0;
        //            break;
        //        case "6":
        //            sta = 2;
        //            break;
        //        case "7":
        //            sta = 3;
        //            break;
        //    }
        //}
        //else
        //{
        //    dds = ddlState.SelectedValue;
        //}
        //ds = da_OfficeAutomation_Main_Inherit.Search_New(false, true, "", ""
        //, "", "", "", "", EmployeeName, EmployeeID, "", "", "", "1", 3, "", "","", false,"");
        //20170702
        DataEntity.DTO.SearchFilterDto SearchDto = InitSearchDto(LoginUser);
        SearchDto.ApplyState = 7;   //待我审核
        SearchDto.OrderType = 1;

        ds = da_OfficeAutomation_Main_Inherit.Search_New_II(SearchDto);
        gvData.DataSource = ds;
        //gvData.PageIndex = GetQueryInt("curpage", 0);
        gvData.DataBind();
    }

    /// <summary>
    /// 导出Excel
    /// </summary>
    protected void btExcel_Click(object sender, EventArgs e)  //M_Excel
    {
        try
        {
            DataSet ds = new DataSet();
            string sname = null;
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

            string dds;
            int sta = 10;
            if (ddlState.SelectedValue == "")
                dds = "";
            else if (int.Parse(ddlState.SelectedValue) > 3)
            {
                if (int.Parse(ddlState.SelectedValue) <= 6)
                    dds = "3";
                else
                    dds = "";
                switch (ddlState.SelectedValue)
                {
                    case "4":
                        sta = 1;
                        break;
                    case "5":
                        sta = 0;
                        break;
                    case "6":
                        sta = 2;
                        break;
                    case "7":
                        sta = 3;
                        break;
                }
            }
            else
            {
                dds = ddlState.SelectedValue;
            }
            //ds = da_OfficeAutomation_Main_Inherit.SummaryData(EmployeeID,ddlApplyType.SelectedValue, Purview.Contains("OA_Search_002"), this.txtApplicationDepartment.Value, this.txtApplicant.Value, this.txtApplyDate.Value, this.txtEndDate.Value, hdTypeID.Value, dds, EmployeeName, EmployeeID, Purview, this.txtSerialNumber.Value.Trim(), txtKeyWord.Value, sta, txtApprover.Value, txtAppTime.Value);

            ds = da_OfficeAutomation_Main_Inherit.SummaryData(EmployeeID, ddlApplyType.SelectedValue, Purview.Contains("OA_Search_002"), this.txtApplicationDepartment.Value, this.txtApplicant.Value, this.txtApplyDate.Value, this.txtEndDate.Value, hdTypeID.Value, dds, EmployeeName, EmployeeID, Purview, this.txtSerialNumber.Value.Trim(), txtKeyWord.Value, sta, txtApprover.Value, txtAppTime.Value, this.txtAppToTime.Value);

            switch (hdTypeID.Value) //t_Dic_OfficeAutomation_Document，主表主键号
            {
                case "70":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "薪酬福利类证明开具申请表";
                    break;
                case "9":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "员工购租楼宇申报及免佣福利申请表";
                    break;
                case "10":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "小汽车津贴申请表";
                    break;
                case "62":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "物业部项目续约申请表";
                    break;
                case "63":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "物业部承接新项目申请表";
                    break;
                case "17":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "项目发展商额外奖金报备汇总";
                    break;
                case "14":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "项目费用申请表汇总";
                    break;
                case "15":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "合作费申请表汇总";
                    break;
                case "16":
                    ds.Tables[0].Columns.Remove("Apply");
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    ds.Tables[0].Columns.Remove("Department");
                    sname = "项目报备表数据汇总";
                    break;
                case "25":
                    ds.Tables[0].Columns.Remove("Apply");
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    ds.Tables[0].Columns.Remove("Department");
                    sname = "项目联动报数申请表汇总";
                    break;
                case "29":
                    ds.Tables[0].Columns.Remove("Apply");
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "进修津贴申请表";
                    break;
                case "13":
                    ds.Tables[0].Columns.Remove("Apply");
                    ds.Tables[0].Columns["Department"].ColumnName = "申请部门";
                    ds.Tables[0].Columns.Remove("ApplyDate");
                    sname = "减让佣/现金奖申请表";
                    break;
                case "42":
                    ds.Tables[0].Columns["Department"].ColumnName = "现任职部门";
                    ds.Tables[0].Columns["Apply"].ColumnName = "填写人";
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "填写日期";
                    sname = "关于享受本月佣金按全年一次性奖金发放申请表";
                    break;
                case "6":
                    ds.Tables[0].Columns["Department"].ColumnName = "申请部门";
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    ds.Tables[0].Columns["Apply"].ColumnName = "申请人";
                    sname = "物业部成交商铺写字楼备案申请表";
                    break;

                case "24":
                    ds.Tables[0].Columns["Department"].ColumnName = "部门名称";
                    ds.Tables[0].Columns["Apply"].ColumnName = "填写人";
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "项目报数申请表";
                    break;
                case "21":
                    ds.Tables[0].Columns["Department"].ColumnName = "部门名称";
                    ds.Tables[0].Columns["Apply"].ColumnName = "填写人";
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "项目销售代理合同条款申请表";
                    break;
                case "23":
                    ds.Tables[0].Columns["Department"].ColumnName = "部门名称";
                    ds.Tables[0].Columns["Apply"].ColumnName = "填写人";
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "项目宿舍及津贴费用申请表";
                    break;
                case "12":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "发文日期";
                    sname = "坏账申请表";
                    break;
                case "55":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "广告宣传需求申请表";
                    break;
                case "56":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "广告宣传预算使用异常申请表";
                    break;
                case "77":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "物业部自主招聘申请";
                    //ds.Tables[0] = WYRecruitTBChange(ds.Tables[0]);
                    string tempval = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        tempval = ds.Tables[0].Rows[i]["招聘形式"].ToString();
                        ds.Tables[0].Rows[i]["招聘形式"] = RemoveStr(tempval, '|');
                        tempval = ds.Tables[0].Rows[i]["举办机构名称"].ToString();
                        ds.Tables[0].Rows[i]["举办机构名称"] = RemoveStr(tempval, '|');
                    }
                    break;
                case "78":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    ds = RecruitTBChange(ds);
                    //
                    sname = "招聘需求申请";
                    break;

                case "80":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "公积金特殊申请";
                    break;
                case "84":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "公积金缴存比例年度调整申请表";
                    break;
                case "31":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "公章使用申请";
                    break;
                case "95":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "公积金缴存基数年度调整申请表";
                    break;
                case "45":
                    ds.Tables[0].Columns["ApplyDate"].ColumnName = "申请日期";
                    sname = "三级市场活动费用申请表";
                    break;
                case "30":
                    ds.Tables[0].Columns.Remove("ApplyDate");
                    sname = "特殊上数申请表";
                    break;
            }

            ds.Tables[0].Columns.Remove("ID");
            ds.Tables[0].Columns.Remove("MainID");

            DataTable dt = ds.Tables[0];
            if (hdTypeID.Value == "17")
            {
                List<string> files = new List<string>();
                DataTable dt2 = ds.Tables[1], dt3 = ds.Tables[2];
                ExcelExport2(dt, "项目发展商额外奖金报备（项目代理标准）");
                ExcelExport2(dt2, "项目发展商额外奖金报备（现金奖发放条件）");
                ExcelExport2(dt3, "项目发展商额外奖金报备（发放方式）");
                files.Add(System.Web.HttpContext.Current.Server.MapPath("/Temp\\项目发展商额外奖金报备（项目代理标准）.xls"));
                files.Add(System.Web.HttpContext.Current.Server.MapPath("/Temp\\项目发展商额外奖金报备（现金奖发放条件）.xls"));
                files.Add(System.Web.HttpContext.Current.Server.MapPath("/Temp\\项目发展商额外奖金报备（发放方式）.xls"));
                Download7z(files, "项目发展商额外奖金报备汇总.zip");
            }
            else
                ExcelExport(dt, sname);
        }
        catch (Exception ex)
        {
            RunJS("alert('没有找到相关的汇总数据，" + ex.Message + "！');history.go(-1);");
        }
    }
    //导出放款错存
    protected void btnLoanWrongSaveExcel_Click(object sender, EventArgs e)
    {
        //陈慧明 11322 黎新枝 54723 许乐怡 42666 黄丹敏 5940 宁伟雄 5585  雷启成 58455
        if (EmployeeID == "50203" || EmployeeID == "11322" || EmployeeID == "54723" || EmployeeID == "42666" || EmployeeID == "5940" || EmployeeID == "58455" || EmployeeID == "5585" || EmployeeID == "39151")
        {
            string[] HeadName = { "Number", "BranchName", "PayeeName", "PayeeNum", "Money", "PayeeBankName", "SerialNumber" };
            string sMainID = this.hdMainID.Value;//获取文档编号
            if (!string.IsNullOrEmpty(sMainID))
            {
                sMainID = sMainID.Substring(0, sMainID.Length - 1);
                sMainID = sMainID.Replace(",", "','");
            }
            List<string> files = new List<string>();
            DA_OfficeAutomation_Document_Loan_Inherit bll = new DA_OfficeAutomation_Document_Loan_Inherit();
            DataSet ds = bll.exportLoanWrongSave(sMainID);//读出放款申请与错存可导出数据
            Common.WriteLogin(EmployeeName + "放款申请与错存可导出数据:" + sMainID, Server.MapPath("~/Log/"));
            if (ds != null)
            {
                bll.UpdateLoanWrongSaveRemarks(sMainID);//修改放款申请与错存可导出数据改出已导出
                string path = Server.MapPath("~/Temp/" + DateTime.Now.ToString("yyyy年MM月dd日") + "放款及错存数据.xls");
                List<Common.LoanWrongSave> renthouselist = new List<Common.LoanWrongSave>();
                renthouselist = Common.ReturnLoanWrongSave(ds.Tables[0]);
                NPOIExcel.NPOIExportExcelTitle<Common.LoanWrongSave>(renthouselist, HeadName, DateTime.Now.ToString("yyyy年MM月dd日") + "广东中原放款明细", path);
                string fileName = HttpUtility.UrlEncode(DateTime.Now.ToString("yyyy年MM月dd日") + "放款及错存数据", Encoding.UTF8);

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
            }

        }
    }
    /// <summary>
    /// 对于多个文件进行打包压缩下载
    /// </summary>
    /// <param name="files">文件路径集合</param>
    /// <param name="zipFileName">压缩包名</param>
    public void Download7z(IEnumerable<string> files, string zipFileName)
    {
        //根据所选文件打包下载
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        byte[] buffer = null;

        using (ICSharpCode.SharpZipLib.Zip.ZipFile file = ICSharpCode.SharpZipLib.Zip.ZipFile.Create(ms))
        {
            file.BeginUpdate();
            file.NameTransform = new MyNameTransfom();//通过这个名称格式化器，可以将里面的文件名进行一些处理。默认情况下，会自动根据文件的路径在zip中创建有关的文件夹。

            foreach (string item in files)
                file.Add(item);

            file.CommitUpdate();

            buffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(buffer, 0, buffer.Length);
        }
        foreach (string item in files)
            File.Delete(item);
        Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(zipFileName, Encoding.UTF8));
        Response.BinaryWrite(buffer);
        Response.Flush();
        Response.End();
    }

    private void ExcelExport2(DataTable dt, string exportFileName)
    {
        StringWriter sw = GetStringWriter(dt);
        System.IO.StreamWriter swobj = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("/Temp\\" + exportFileName + ".xls"), true, Encoding.GetEncoding("GB2312"));

        swobj.WriteLine(sw);
        swobj.Flush();
        swobj.Close();
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

    //private DataTable WYRecruitTBChange(DataTable dt)
    //{
    //    if (dt == null && dt.Rows.Count == 0)
    //    {
    //        return dt;
    //    }
    //    string tempval = "";
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        tempval = dt.Rows[i]["招聘形式"].ToString();
    //        dt.Rows[i]["招聘形式"] = RemoveStr(tempval,'|');
    //        dt.Rows[i]["举办机构名称"] = RemoveStr(tempval, '|');
    //    }
    //    return dt;
    //}

    private DataSet RecruitTBChange(DataSet dss)
    {
        if (dss == null && dss.Tables[0] == null && dss.Tables[0].Rows.Count == 0)
        {
            return dss;
        }
        var bll = new DataAccess.Operate.DA_OfficeAutomation_Document_RecruitHRResult_Operate();
        string IDs = "";
        var list = new List<DataEntity.T_OfficeAutomation_Document_RecruitHRResult>();
        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
        {
            var ID = dss.Tables[0].Rows[i]["ID"].ToString();
            IDs += "'" + ID + "',";

        }
        list = bll.SelectByMainIDs(IDs.TrimEnd(','));
        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
        {
            var ID = new Guid(dss.Tables[0].Rows[i]["ID"].ToString());
            var l = list.Where(m => m.OfficeAutomation_Document_RecruitHRResult_MainID == ID).ToList();

            if (l != null && l.Count > 0)
            {
                var Deps = "";
                var Poss = "";
                var Names = "";
                var Dates = "";
                var Payments = "";
                var Grades = "";
                foreach (var item in l)
                {
                    Deps += item.OfficeAutomation_Document_RecruitHRResult_Dep + ",";
                    Poss += item.OfficeAutomation_Document_RecruitHRResult_Pos + ",";
                    Names += item.OfficeAutomation_Document_RecruitHRResult_Name + ",";
                    Dates += item.OfficeAutomation_Document_RecruitHRResult_Date + ",";
                    Payments += item.OfficeAutomation_Document_RecruitHRResult_Payment + ",";
                    Grades += item.OfficeAutomation_Document_RecruitHRResult_Grade + ",";
                }
                dss.Tables[0].Rows[i]["入职部门"] = Deps.TrimEnd(',');
                dss.Tables[0].Rows[i]["入职岗位"] = Poss.TrimEnd(',');
                dss.Tables[0].Rows[i]["入职者姓名"] = Names.TrimEnd(',');
                dss.Tables[0].Rows[i]["入职日期"] = Dates.TrimEnd(',');
                dss.Tables[0].Rows[i]["薪金"] = Payments.TrimEnd(',');
                dss.Tables[0].Rows[i]["处理结果职级"] = Grades.TrimEnd(',');
            }
        }

        return dss;
    }

    private string RemoveStr(string text, char c)
    {
        string result = "";
        var vals = text.Split(c);
        foreach (var s in vals)
        {
            if (!string.IsNullOrEmpty(s))
                result += s + ",";
        }
        if (result.Length > 0)
        {
            result = result.TrimEnd(',');
        }
        return result;
    }
    //public static void CheckAll(GridView gv, object sender)
    //{
    //    CheckBox cball = sender as CheckBox;
    //    if (cball != null)
    //    {
    //        for (int i = 0; i < gv.Rows.Count; i++)
    //        {
    //            if (gv.Rows[i].RowType == DataControlRowType.DataRow)
    //            {
    //                CheckBox cb = gv.Rows[i].FindControl("ChkSelected") as CheckBox;
    //                if (cb != null)
    //                    cb.Checked = cball.Checked;
    //            }
    //        }
    //    }
    //} 
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e) //M_SelectCkd：20150310
    {
        for (int i = 0; i <= gvData.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)gvData.Rows[i].FindControl("ChkSelected");
            if (chkSelectAll.Checked == true)
            {
                cbox.Checked = true;
                chkCancelAll.Checked = false;
            }
            else
            {
                cbox.Checked = false;
            }
        }
        //CheckAll(gvData, sender);
    }
    protected void chkCancelAll_CheckedChanged(object sender, EventArgs e) //M_SelectCkd：20150310
    {
        for (int i = 0; i <= gvData.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)gvData.Rows[i].FindControl("ChkSelected");
            if (chkCancelAll.Checked == true)
            {
                chkSelectAll.Checked = false;
                cbox.Checked = false;
            }

        }
    }
    protected void btnSelectChecked_Click(object sender, EventArgs e) //M_SelectCkd：20150310
    {
        bool isc = false;
        string MID = "", st, s;
        string applyType = hdTypeID.Value;

        if (chkSelectAll.Checked == true)
        {

            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DataSet ds = da_OfficeAutomation_Main_Inherit.Search_New(bool.Parse(islawer), true, "", ""
                            , "", "", applyType, "", EmployeeName, EmployeeID, "", "", "", "1", 3, "", "", "", false, "");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                MID += ds.Tables[0].Rows[i]["MainID"].ToString() + ",";
                isc = true;
            }
        }

        for (int i = 0; i < gvData.Rows.Count; i++)
        {
            GridViewRow row = gvData.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("ChkSelected")).Checked;
            bool vis = ((CheckBox)row.FindControl("ChkSelected")).Visible;
            if (!isChecked && vis && chkSelectAll.Checked == true)
            {
                s = gvData.DataKeys[gvData.Rows[i].DataItemIndex - gvData.PageIndex * 20].Value.ToString(); //修改一页所显示的行数时要注意
                MID = MID.Replace((s + ","), string.Empty);
            }
            else if (isChecked && vis && chkSelectAll.Checked == false)
            {
                st = gvData.DataKeys[gvData.Rows[i].DataItemIndex - gvData.PageIndex * 20].Value.ToString() + ","; //修改一页所显示的行数时要注意
                if (!MID.Contains(st))
                {
                    MID += st;
                    isc = true;
                }
            }
        }
        if (isc)
        {
            //RunJS("alert('*" + MID + "*');");
            MID = MID.Remove(MID.Length - 1);
            RunJS("var va = window.showModalDialog(\"Apply_SelectChecked.aspx?ApplyType=" + applyType + "&MainID=" + MID + "\", '" + MID + "', \"dialogWidth=660px;dialogHeight=260px\"); if(va=='success'){window.location.href=window.location.href;}");
        }
        else
        {
            RunJS("alert('没有选择到需要审批的表！');history.go(-1);");
        }
    }

    protected void btnInterestsExcel_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        if (ddlInterestsType.SelectedValue == "")
        {
            RunJS("alert('请选择申报类别！')");
        }
        else
        {
            bool isc = false;
            string MID = "", st, s;
            string applyType = hdTypeID.Value;

            if (chkSelectAll.Checked == true)
            {
                string dds;
                int sta = 10;
                if (ddlState.SelectedValue == "")
                    dds = "";
                else if (int.Parse(ddlState.SelectedValue) > 3)
                {
                    if (int.Parse(ddlState.SelectedValue) <= 6)
                        dds = "3";
                    else
                        dds = "";
                    switch (ddlState.SelectedValue)
                    {
                        case "4":
                            sta = 1;
                            break;
                        case "5":
                            sta = 0;
                            break;
                        case "6":
                            sta = 2;
                            break;
                        case "7":
                            sta = 3;
                            break;
                    }
                }
                else
                {
                    dds = ddlState.SelectedValue;
                }

                string intereststype = ddlInterestsType.SelectedValue;

                ds = da_OfficeAutomation_Main_Inherit.Search_New(bool.Parse(islawer), Purview.Contains("OA_Search_002"), this.txtApplicationDepartment.Value, this.txtApplicant.Value
                    , this.txtApplyDate.Value, this.txtEndDate.Value, hdTypeID.Value, dds, EmployeeName, EmployeeID, Purview, this.txtSerialNumber.Value.Trim(), txtKeyWord.Value, ddlApplyType.SelectedValue, sta, txtApprover.Value, txtAppTime.Value, txtAppToTime.Value, bool.Parse(willDel), intereststype);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MID += ds.Tables[0].Rows[i]["MainID"].ToString() + ",";
                    isc = true;
                }
            }

            for (int i = 0; i < gvData.Rows.Count; i++)
            {
                GridViewRow row = gvData.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("ChkSelected")).Checked;
                bool vis = ((CheckBox)row.FindControl("ChkSelected")).Visible;

                if (!isChecked && vis && chkSelectAll.Checked == true)
                {
                    s = gvData.DataKeys[gvData.Rows[i].DataItemIndex - gvData.PageIndex * 20].Value.ToString(); //修改一页所显示的行数时要注意
                    MID = MID.Replace((s + ","), string.Empty);
                }
                else if (isChecked && vis && chkSelectAll.Checked == false)
                {
                    st = gvData.DataKeys[gvData.Rows[i].DataItemIndex - gvData.PageIndex * 20].Value.ToString() + ","; //修改一页所显示的行数时要注意
                    if (!MID.Contains(st))
                    {
                        MID += st;
                        isc = true;
                    }
                }
            }
            if (isc)
            {
                //RunJS("alert('*" + MID + "*');");
                MID = MID.Remove(MID.Length - 1);
                GetData(MID, ddlInterestsType.SelectedValue);
            }
            else
            {
                RunJS("alert('请选择需要导出的项！');history.go(-1);");
            }
        }
    }
    protected void ddlInterestsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindData();
        //if (EmployeeID == "42900" && hdTypeID.Value == "8")
        //{
        //    btnInterestsExcel.Visible = true;
        //}
        //else 
        //{
        //    btnInterestsExcel.Visible = false;
        //}
    }

    //导出数据
    public void GetData(string mainids, string intereststypeid)
    {
        DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit newpersinterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit();
        DA_Dic_OfficeAutomation_PersInterestsType_Operate da_Dic_OfficeAutomation_PersInterestsType_Operate = new DA_Dic_OfficeAutomation_PersInterestsType_Operate();

        string newmainids = "";
        string orderids = "";
        string interestsTypeName = da_Dic_OfficeAutomation_PersInterestsType_Operate.GetInterestsType(Convert.ToInt32(intereststypeid));
        string[] mainidarr = mainids.Split(',');
        for (var i = 0; i < mainidarr.Length; i++)
        {
            newmainids += "'" + mainidarr[i] + "',";
        }
        newmainids = newmainids.Remove(newmainids.Length - 1);

        for (var i = mainidarr.Length - 1; i >= 0; i--)
        {

            orderids += mainidarr[i] + ",";
        }
        orderids = orderids.Remove(orderids.Length - 1);

        DataSet ds = newpersinterests_Inherit.GetInterestsInfoByMainIDs(newmainids, Convert.ToInt32(intereststypeid), orderids);

        //ds.Tables[0].Columns.Add("总监", typeof(string));

        //for (var i = 0; i < ds.Tables[0].Rows.Count; i++) 
        //{
        //    string deptid = ds.Tables[0].Rows[i]["dept_id"].ToString();
        //    string managername = "";
        //    wsFinance.Service wsf = new wsFinance.Service();
        //    wsHR.HR wshr = new wsHR.HR();
        //    if (deptid != "")
        //    {
        //        DataSet dsmanager = wsf.GetHRStructure(deptid, DateTime.Now.ToString("yyyy-MM-dd"));
        //        if (dsmanager != null && dsmanager.Tables != null && dsmanager.Tables[0].Rows.Count > 0)
        //        {
        //            managername = dsmanager.Tables[0].Rows[0]["HRStructure_Unit"].ToString().Replace('/', ',');

        //        }
        //        else
        //        {
        //            managername = wshr.GetDepartmentManager(deptid);
        //        }
        //    }

        //    ds.Tables[0].Rows[i]["总监"] = managername;
        //}

        ds.Tables[0].Columns.Remove("dept_id");


        string sname = "员工个人利益申报表之" + interestsTypeName + "类别";
        ExcelExportNew(ds.Tables[0], sname, Convert.ToInt32(intereststypeid));

    }

    //导出员工个人利益申报数据
    private void ExcelExportNew(DataTable dt, string exportFileName, int type)
    {
        string[] HeadName = Common.ReturnarrByType(type);
        string path = Server.MapPath("~/Temp/员工个人利益申报.xls");
        if (type == 7)
        {
            List<Common.RentHouse> renthouselist = new List<Common.RentHouse>();
            renthouselist = Common.ReturnRentHouseListByType(dt);
            NPOIExcel.NPOIExportExcel<Common.RentHouse>(renthouselist, HeadName, path);
        }
        else if (type == 8)
        {
            List<Common.FamilyRelation> familyrelationlist = new List<Common.FamilyRelation>();
            familyrelationlist = Common.ReturnFRListByType(dt);
            NPOIExcel.NPOIExportExcel<Common.FamilyRelation>(familyrelationlist, HeadName, path);
        }
        else if (type == 9)
        {
            List<Common.LiWu> liwulist = new List<Common.LiWu>();
            liwulist = Common.ReturnLiWuListByType(dt);
            NPOIExcel.NPOIExportExcel<Common.LiWu>(liwulist, HeadName, path);
        }
        else if (type == 10)
        {
            List<Common.CommercialActivities> cactivatieslist = new List<Common.CommercialActivities>();
            cactivatieslist = Common.ReturnCAListByType(dt);
            NPOIExcel.NPOIExportExcel<Common.CommercialActivities>(cactivatieslist, HeadName, path);
        }
        else if (type == 11)
        {
            List<Common.PartTiemJob> partimejoblist = new List<Common.PartTiemJob>();
            partimejoblist = Common.ReturnPartTimeJobListByType(dt);
            NPOIExcel.NPOIExportExcel<Common.PartTiemJob>(partimejoblist, HeadName, path);
        }

        string fileName = HttpUtility.UrlEncode(exportFileName, Encoding.UTF8);

        HttpContext.Current.Response.Charset = "gb2312";

        //读取文件
        FileStream fs = new FileStream(path, FileMode.Open);
        byte[] bytes = new byte[(int)fs.Length];
        fs.Read(bytes, 0, bytes.Length);
        fs.Close();

        //下载
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        exportFileName = exportFileName.Replace("/", "或");
        string str = "attachment;filename= " + fileName + ".xls";
        HttpContext.Current.Response.AppendHeader("Content-Disposition", str);
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.BinaryWrite(bytes);
        // HttpContext.Current.Response.End();
        Session.Timeout = 300;
        GetAllDepartment();

        InitJS();
    }


    private DataEntity.DTO.SearchFilterDto InitSearchDto(UserInfo user)
    {
        DataEntity.DTO.SearchFilterDto result = new DataEntity.DTO.SearchFilterDto();
        //代理人
        if (user != null && user.Agents != null && user.Agents.Count > 0)
        {
            result.Agents = Common.ChangeAgentDtos(user.Agents);
        }

        result.IsAdmin = (user.AdminSearch);
        result.AllowIDS = user.DocIDs.Split('|')[0];
        result.NotAllowIDS = user.DocIDs.Split('|')[1];
        result.KeyWordAllTB = user.KeyWordAllTB;
        result.Employee = user.EmpName;
        result.EmployeeCode = user.EmpID;

        if (user.EmpID == "44962")
        {
            result.AllowIDS += "105,106,107";
        }
        return result;
    }

}