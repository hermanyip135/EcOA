using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit : DA_OfficeAutomation_Document_AssetTransfer_Detail_Operate
    {
        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_AssetTransfer_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmExp]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmRec]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_CV]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_CreateTime]"

                    + "            ,tdoaat.OfficeAutomation_AssetType_Name"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail]"
                    + "        LEFT JOIN t_Dic_OfficeAutomation_AssetType tdoaat ON OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID=tdoaat.OfficeAutomation_AssetType_ID"
                    + "      WHERE [OfficeAutomation_Document_AssetTransfer_Detail_MainID]='" + id + "'"
                    + "  ORDER BY [OfficeAutomation_Document_AssetTransfer_Detail_AssetTag] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_AssetTransfer_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmExp]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmRec]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_CV]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_CreateTime]"
                    +"             ,OfficeAutomation_Document_AssetTransfer_Detail_TxtType"
                    + "            ,tdoaat.OfficeAutomation_AssetType_Name"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail]"
                    + "        LEFT JOIN t_Dic_OfficeAutomation_AssetType tdoaat ON OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID=tdoaat.OfficeAutomation_AssetType_ID"
                    + "      WHERE [OfficeAutomation_Document_AssetTransfer_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_AssetTransfer_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_AssetTransfer toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_AssetTransfer_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_AssetTransfer_Detail_AssetTag] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主键获取其下对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectTempByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_AssetTransfer_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmExp]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmRec]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_AssetTransfer_Detail_MainID] = '" + mainID + "'"
                    + "  ORDER BY [OfficeAutomation_Document_AssetTransfer_Detail_AssetTag] ASC";

            return RunSQL(sql);
        }

        ///// <summary>
        ///// 根据主键及财务编号获取其下对应的详情备份
        ///// </summary>
        ///// <param name="mainID"></param>
        ///// <returns></returns>
        //public DataSet SelectTempByMainIDAndNo(string mainID, string No)
        //{
        //    string sql = "SELECT [OfficeAutomation_Document_AssetTransfer_Detail_ID]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_MainID]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetName]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetAID]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTag]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Model]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Number]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmExp]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmRec]"
        //            + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec]"
        //            + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail_Temp]"
        //            + "      WHERE  [OfficeAutomation_Document_AssetTransfer_Detail_MainID] = '" + mainID + "'"
        //            + "      AND OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = '" + No + "'"
        //            + "  ORDER BY [OfficeAutomation_Document_AssetTransfer_Detail_AssetTag] ASC";

        //    return RunSQL(sql);
        //}

        /// <summary>
        /// 根据各条件获取其下对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectTempByAnother(string mainID, string Id, string No, string Mod)
        {
            string sql = "SELECT [OfficeAutomation_Document_AssetTransfer_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmExp]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmRec]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_AssetTransfer_Detail_MainID] = '" + mainID + "'"
                    + "  AND (OfficeAutomation_Document_AssetTransfer_Detail_AssetName LIKE '%" + Id + "%'"
                    + "  AND OfficeAutomation_Document_AssetTransfer_Detail_AssetTag LIKE '%" + No + "%'"
                    + "  AND OfficeAutomation_Document_AssetTransfer_Detail_Model LIKE '%" + Mod + "%')"
                    + "  ORDER BY [OfficeAutomation_Document_AssetTransfer_Detail_AssetTag] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据各条件获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByAnother(string mainID, string Id, string No, string Mod)
        {
            string sql = "SELECT [OfficeAutomation_Document_AssetTransfer_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmExp]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmRec]"
                    + "            ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail]"
                    + "      WHERE [OfficeAutomation_Document_AssetTransfer_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_AssetTransfer_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_AssetTransfer toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_AssetTransfer_MainID = '" + mainID + "')"
                    + "  AND (OfficeAutomation_Document_AssetTransfer_Detail_AssetName LIKE '%" + Id + "%'"
                    + "  AND OfficeAutomation_Document_AssetTransfer_Detail_AssetTag LIKE '%" + No + "%'"
                    + "  AND OfficeAutomation_Document_AssetTransfer_Detail_Model LIKE '%" + Mod + "%')"
                    + "  ORDER BY [OfficeAutomation_Document_AssetTransfer_Detail_AssetTag] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 删除对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool DeleteTemp(string mainID)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_AssetTransfer_Detail_MainID] = '" + mainID + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MID和财务编号删除对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool DeleteTemp(string mainID, string No)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_AssetTransfer_Detail_MainID] = '" + mainID + "'"
                    + "      AND OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = '" + No + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据ID删除对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool DeleteTempByID(string ID)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_AssetTransfer_Detail_ID] = '" + ID + "'";
            return RunNoneSQL(sql);
        }
    }
}
