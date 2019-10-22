using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using AppCommon.Model;
using DataEntity.Json.CCES;
using JsonOutEstateList = DataEntity.Json.CCES.JsonOutEstateList;
using JsonOutPropertyList = DataEntity.Json.CCES.JsonOutPropertyList;

namespace DataAccess.Operate
{
    public class DA_CCES_Inherit
    {
        #region 变量定义
        private JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
        //private AppCommon.Function_Json js = new AppCommon.Function_Json();
        private WS_CCES.ContractService_GZ _wsCCES = new WS_CCES.ContractService_GZ();
        //private DA_Report_Main_Inherit _Report_Main_Inherit = new DA_Report_Main_Inherit();
        #endregion

        #region fnGetPropertyList 获取房间信息列表
        /// <summary>
        /// 获取房间信息列表
        /// </summary>
        public List<JsonOutPropertyList.rows> fnGetPropertyList(string sJsonIn)
        {
            string sJsonOut = _wsCCES.GetPropertyList(sJsonIn, "json").InnerText;
            js.MaxJsonLength = 1000000000;
            JsonOutPropertyList.JsonOut jsonOut = js.Deserialize<JsonOutPropertyList.JsonOut>(sJsonOut);

            return jsonOut.Obj.rows;
        }
        #endregion

        #region fnGetPropertyListString 获取房间信息列表
        /// <summary>
        /// 获取房间信息列表
        /// </summary>
        public string fnGetPropertyListString(string sJsonIn)
        {
            //List<string> listEd = _Report_Main_Inherit.fnGetAllCcesPropertyIDList(gReportID == "" ? Guid.NewGuid() : new Guid(gReportID));

            StringBuilder sReturn = new StringBuilder("{");
            foreach (JsonOutPropertyList.rows row in fnGetPropertyList(sJsonIn))
            {
                //if (listEd.Contains(row.PropertyID))
                //    continue;

                sReturn.Append("'");
                sReturn.Append(row.PropertyID);
                sReturn.Append("':'");
                sReturn.Append(row.PropertyName);
                sReturn.Append("',");
            }
            string result = sReturn.ToString().TrimEnd(new char[] { ',' });
            result = result + "}";

            return result;
        }
        #endregion

        #region fnGetEstateList 获取楼盘列表
        /// <summary>
        /// 获取楼盘列表
        /// </summary>
        public List<JsonOutEstateList.rows> fnGetEstateList(string sJsonIn)
        {
            string sJsonOut = _wsCCES.GetEstateList(sJsonIn, "json").InnerText;
            JsonOutEstateList.JsonOut jsonOut = js.Deserialize<JsonOutEstateList.JsonOut>(sJsonOut);

            return jsonOut.Obj.rows;
        }
        #endregion

        #region fnGetEstateListString 获取楼盘列表
        /// <summary>
        /// 获取楼盘列表
        /// </summary>
        public string fnGetEstateListString(string sJsonIn)
        {
            StringBuilder sReturn = new StringBuilder("[");
            foreach (JsonOutEstateList.rows row in fnGetEstateList(sJsonIn))
            {
                sReturn.Append("{'id':'");
                sReturn.Append(row.EstateID);
                sReturn.Append("','value':'");
                sReturn.Append(row.EstateName);
                sReturn.Append("'},");
            }
            string result = sReturn.ToString().TrimEnd(new char[] { ',' });
            result = result + "]";

            //return js.Serialize(jsonOut.Obj.rows.Select(m => new { EstateID = m.EstateID, EstateName = m.EstateName }).ToList());
            return result;
        }
        #endregion

        #region fnGetEstateList 获取楼盘列表
        /// <summary>
        /// 获取楼盘列表
        /// </summary>
        public string fnGetEstateListString2(string sJsonIn)
        {
            string sJsonOut = _wsCCES.GetEstateList(sJsonIn, "json").InnerText;

            return sJsonOut;
        }
        #endregion

        #region fnGetJsonIn 组合查询条件Json
        /// <summary>
        /// 组合查询条件Json，默认50条数据
        /// </summary>
        /// <returns>返回Json格式字符串</returns>
        public string fnGetJsonIn(List<DbTable> listLike, List<DbTable> listNotLike)
        {
            List<DbTable> listEqual = new List<DbTable>();
            return fnGetJsonIn(listLike, listNotLike, listEqual, "50");
        }

        /// <summary>
        /// 组合查询条件Json，默认50条数据
        /// </summary>
        /// <returns>返回Json格式字符串</returns>
        public string fnGetJsonIn(List<DbTable> listLike)
        {
            List<DbTable> listNotLike = new List<DbTable>();
            List<DbTable> listEqual = new List<DbTable>();
            return fnGetJsonIn(listLike, listNotLike, listEqual, "999999999");
        }

        /// <summary>
        /// 组合查询条件Json，默认50条数据
        /// </summary>
        /// <returns>返回Json格式字符串</returns>
        public string fnGetJsonIn(List<DbTable> listEqual, bool bEqual)
        {
            List<DbTable> listNotLike = new List<DbTable>();
            List<DbTable> listLike = new List<DbTable>();
            return fnGetJsonIn(listLike, listNotLike, listEqual, "50");
        }

        /// <summary>
        /// 组合查询条件Json
        /// </summary>
        /// <returns>返回Json格式字符串</returns>
        public string fnGetJsonIn(List<DbTable> listLike, string sPageSize)
        {
            List<DbTable> listNotLike = new List<DbTable>();
            List<DbTable> listEqual = new List<DbTable>();
            return fnGetJsonIn(listLike, listNotLike, listEqual, sPageSize);
        }

        /// <summary>
        /// 组合查询条件Json
        /// </summary>
        /// <returns>返回Json格式字符串</returns>
        public string fnGetJsonIn(List<DbTable> listLike, List<DbTable> listNotLike, List<DbTable> listEqual, string sPageSize)
        {
            //list.Add(new DbTable("DeptPath", "100"));   // 公司路径【测试001；正式100】

            JsonIn jsonIn = new JsonIn();
            jsonIn.PageIndex = "1";
            jsonIn.PageSize = sPageSize;

            foreach (DbTable dbTable in listLike)
            {
                QueryWhere queryWhere = new QueryWhere();
                queryWhere.Name = dbTable.ColumnName;
                queryWhere.Value = "%" + dbTable.ColumnValue;
                queryWhere.Rel = "like";
                queryWhere.Logic = "and";
                jsonIn.QueryWhere.Add(queryWhere);
            }

            foreach (DbTable dbTable in listNotLike)
            {
                QueryWhere queryWhere = new QueryWhere();
                queryWhere.Name = dbTable.ColumnName;
                queryWhere.Value = "%" + dbTable.ColumnValue;
                queryWhere.Rel = "not like";
                queryWhere.Logic = "and";
                jsonIn.QueryWhere.Add(queryWhere);
            }

            foreach (DbTable dbTable in listEqual)
            {
                QueryWhere queryWhere = new QueryWhere();
                queryWhere.Name = dbTable.ColumnName;
                queryWhere.Value = dbTable.ColumnValue;
                queryWhere.Rel = "=";
                queryWhere.Logic = "and";
                jsonIn.QueryWhere.Add(queryWhere);
            }

            return js.Serialize(jsonIn);
        }
        #endregion
    }
}
