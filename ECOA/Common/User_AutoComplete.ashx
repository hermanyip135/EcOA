<%@ WebHandler Language="C#" Class="User_AutoComplete" %>

using System;
using System.Web;
using System.Collections.Generic;
using AppCommon.Model;
using DataAccess.Operate;

public class User_AutoComplete : IHttpHandler
{
    //DataAccess.Operate.DA_Report_Building_Inherit _buildingDAL = new DataAccess.Operate.DA_Report_Building_Inherit();
    //DataAccess.Operate.DA_User_Department_Inherit _userDepartmentDAL = new DataAccess.Operate.DA_User_Department_Inherit();
    //KDHR.Service _wsKDHR = new KDHR.Service();
    private DA_CCES_Inherit _CCES_Inherit = new DA_CCES_Inherit();
            
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Cache.SetNoStore();
        
        string key = context.Request.QueryString["mask"].ToString();
        string d = context.Request.QueryString["d"].ToString();
        string mode = context.Request.QueryString["t"].ToString();
        string result = "{'HelloWorld':'Hello World','b':'sfsd','c':'fghfg'}";
        
        List<DbTable> list = new List<DbTable>();
        List<DbTable> listNotLike = new List<DbTable>();
        string sJsonIn = "";
        
       switch (mode)
        {
            //case "building":
            //    result = GetBuildings(key, d);
            //    break;
            //case "dep":
            //    result = GetDepartments(key, d);
            //    break;
            //case "allBuilding":
            //    result = GetBuildings(key);
            //    break;
            //case "getDate":
            //    result = GetBuildingDate(d);
            //    break;

            case "GetEstate":
                list.Clear();
                list.Add(new DbTable("EstateName", key));
                sJsonIn = _CCES_Inherit.fnGetJsonIn(list);
                result = _CCES_Inherit.fnGetEstateListString(sJsonIn);
                break;
            case "GetProperty":
                if (d != "")
                {
                    list.Clear();
                    listNotLike.Clear();
                    list.Add(new DbTable("EstateID", d));
                    list.Add(new DbTable("PropertyName", key));
                    list.Add(new DbTable("SaleStatus", "可售"));
                    listNotLike.Add(new DbTable("PropertyName", "旧"));
                    sJsonIn = _CCES_Inherit.fnGetJsonIn(list, listNotLike);
                    result = _CCES_Inherit.fnGetPropertyListString(sJsonIn);
                }
                else
                { result = ""; }
                break;
        }
        context.Response.ContentType = "text/plain";
        context.Response.Write(result);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    //public string GetBuildingDate(string id)
    //{
    //    //string id = context.Request.QueryString["mask"].ToString();
    //    System.Data.DataSet ds = _buildingDAL.GetByID(int.Parse(id));
    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        string endDate = ds.Tables[0].Rows[0]["Building_EndDate"].ToString();
    //        DateTime date;
    //        if (DateTime.TryParse(endDate, out date))
    //        {
    //            return date.ToString("yyyy-MM-dd");
    //        }
    //    }
    //    return "";
        
    //}
    
    #region 获取楼盘名称

    //public string GetBuildings(string key)
    //{
    //    if (string.IsNullOrEmpty(key))
    //    {
    //        return "";
    //    }
    //    System.Data.DataSet ds = _buildingDAL.FindLibrary(key);
    //    string result = GetBuildingStr(ds);
    //    return result;
    //}
    
    //public string GetBuildings(string key, string type)
    //{
    //    if (string.IsNullOrEmpty(key))
    //    {
    //        return "";
    //    }
    //    if (type == "undefined" || string.IsNullOrEmpty(type))
    //    {
    //        return "";
    //    }
    //    System.Data.DataSet ds = _buildingDAL.FindLibrary(key, int.Parse(type));
    //    if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
    //    {
    //        //return "";
    //        ds = _buildingDAL.FindLibrary(int.Parse(type));
    //    }
    //    string result = GetBuildingStr(ds);
    //    return result;
    //}

    private  string GetBuildingStr(System.Data.DataSet ds)
    {
        System.Text.StringBuilder strJSArr = new System.Text.StringBuilder("{");
        foreach (System.Data.DataRow row in ds.Tables[0].Rows)
        {

            strJSArr.Append("'");
            strJSArr.Append(row["Building_ID"].ToString());
            strJSArr.Append("':'");
            strJSArr.Append(row["Building_Name"].ToString());
            strJSArr.Append("',");

        }
        string result = strJSArr.ToString().TrimEnd(new char[] { ',' });
        result = result + "}";
        return result;
    }
    #endregion

    #region 获取部门名称

    public string GetDepartments(string key, string type)
    {
        if (string.IsNullOrEmpty(key))
        {
            return "";
        }
        if (type == "undefined" || string.IsNullOrEmpty(type))
        {
            return "";
        }
        System.Text.StringBuilder strJSArr = new System.Text.StringBuilder("{");

        System.Data.DataTable dtQuestions = null;
        
        if (type != "-1")
        {
            //dtQuestions = _userDepartmentDAL.getUserDepartment(int.Parse(type));
            ////dtQuestions.DefaultView.RowFilter = "User_Department like '%" + key.ToLower() + "%'";

            //System.Data.DataRow[] rows = dtQuestions.Select("User_Department like '%" + key.ToLower() + "%'");
            //foreach (System.Data.DataRow row in rows)
            //{

            //    strJSArr.Append("'");
            //    strJSArr.Append(row["User_Departmentid"].ToString());
            //    strJSArr.Append("':'");
            //    strJSArr.Append(row["User_Department"].ToString());
            //    strJSArr.Append("',");

            //}
        }
        else
        {
            //dtQuestions = _wsKDHR.HRDepartmentList().Tables[0];
            ////dtQuestions.DefaultView.RowFilter = "Name like '%" + key.ToLower() + "%'";

            //System.Data.DataRow[] rows = dtQuestions.Select("Name like '%" + key.ToLower() + "%'");
            //foreach (System.Data.DataRow row in rows)
            //{

            //    strJSArr.Append("'");
            //    strJSArr.Append(row["id"].ToString());
            //    strJSArr.Append("':'");
            //    strJSArr.Append(row["Name"].ToString());
            //    strJSArr.Append("',");

            //}
        }

        
        string result = strJSArr.ToString().TrimEnd(new char[] { ',' });
        result = result + "}";
        return result;
    }
    
    #endregion  
}