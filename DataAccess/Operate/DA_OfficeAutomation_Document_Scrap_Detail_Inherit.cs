using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Scrap_Detail_Inherit : DA_OfficeAutomation_Document_Scrap_Detail_Operate
    {
        /// <summary>
        /// 根据报废申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Scrap_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_PlaceRec]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_BuyDate]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Cost]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_CreateTime]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_PlaceExp]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_DpmExp]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_PlaceExpId]"
                    + "           ,[OfficeAutomation_Document_Scrap_Detail_DpmRec]"
                    + "           ,[OfficeAutomation_Document_Scrap_Detail_CV]"
                    + "           ,[OfficeAutomation_Document_Scrap_Detail_Type]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AdjustmentID]"
                    + "            ,tdoaat.OfficeAutomation_AssetType_Name"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail]"
                    + "        LEFT JOIN t_Dic_OfficeAutomation_AssetType tdoaat ON OfficeAutomation_Document_Scrap_Detail_AssetTypeID=tdoaat.OfficeAutomation_AssetType_ID"
                    + "      WHERE [OfficeAutomation_Document_Scrap_Detail_MainID]='" + id + "'"
                    + "  ORDER BY [OfficeAutomation_Document_Scrap_Detail_AssetTypeID] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_Scrap_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_PlaceRec]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_BuyDate]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Cost]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_CreateTime]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_PlaceExp]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_DpmExp]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_PlaceExpId]"
                    + "           ,[OfficeAutomation_Document_Scrap_Detail_DpmRec]"
                    + "           ,[OfficeAutomation_Document_Scrap_Detail_CV]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AdjustmentID]"
                    + "           ,[OfficeAutomation_Document_Scrap_Detail_Type]"
                    + "            ,tdoaat.OfficeAutomation_AssetType_Name"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail]"
                    + "        LEFT JOIN t_Dic_OfficeAutomation_AssetType tdoaat ON OfficeAutomation_Document_Scrap_Detail_AssetTypeID=tdoaat.OfficeAutomation_AssetType_ID"
                    + "      WHERE [OfficeAutomation_Document_Scrap_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_Scrap_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_Scrap toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_Scrap_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_Scrap_Detail_AssetTypeID] ASC";

            return RunSQL(sql);
        }


        /// <summary>
        /// 根据主键获取其下对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectTempByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_Scrap_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_PlaceRec]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_BuyDate]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_Scrap_Detail_MainID] = '" + mainID + "'"
                    + "  ORDER BY [OfficeAutomation_Document_Scrap_Detail_AssetTag] ASC";

            return RunSQL(sql);
        }


        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectTAsByMainID(string mainID, string dpm)
        {
            string sql = "CREATE TABLE #TpAs"
                    + "            (Asset_Id UNIQUEIDENTIFIER,"
                    + "            Asset_Company_Id NVARCHAR(80),"
                    + "            Asset_BigClass_Id NVARCHAR(80),"
                    + "            Asset_Place NVARCHAR(80),"
                    + "            Asset_AssetNo NVARCHAR(80),"
                    + "            Asset_Classes_Id NVARCHAR(80),"
                    + "            txtClasses NVARCHAR(80),"
                    + "            Asset_Type_Id NVARCHAR(80),"
                    + "            Asset_TS_Id NVARCHAR(80),"
                    + "            Asset_Number NVARCHAR(80),"
                    + "            Asset_RegionalDirector UNIQUEIDENTIFIER,"
                    + "            Asset_RecordedTime DATETIME,"
                    + "            Asset_CreateTime DATETIME,"
                    + "            Asset_IsScrap NVARCHAR(80),"
                    + "            Asset_Asset_NO NVARCHAR(80),"
                    + "            Asset_Department UNIQUEIDENTIFIER,"
                    + "            Assets_Dept_Name NVARCHAR(80),"
                    + "            txtPlace NVARCHAR(80),"
                    + "            txtTS NVARCHAR(80),"
                    + "            cv NVARCHAR(80),"
                    + "            txtType NVARCHAR(80))"
                    + "            INSERT INTO #TpAs"
                    + "            EXEC [DB_Administration].[dbo].[sp_t_Assets_Asset_Seach2]"
                    + "            @txtAsset_Department = '" + dpm + "',@Asset_AssetNo = '',@Asset_Classes = '',@beginAsset_RecordedTime = '',@endAsset_RecordedTime = ''"
                    + "            SELECT * FROM [t_OfficeAutomation_Document_Scrap_Detail] tp"
                    + "            LEFT JOIN #TpAs tpas"
                    + "            ON tp.OfficeAutomation_Document_Scrap_Detail_AssetTag = tpas.Asset_AssetNo"
                    + "            WHERE tp.[OfficeAutomation_Document_Scrap_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_Scrap_ID"
                    + "            FROM   t_OfficeAutomation_Document_Scrap toads"
                    + "            WHERE  toads.OfficeAutomation_Document_Scrap_MainID = '" + mainID + "')"
                    + "            ORDER BY tp.[OfficeAutomation_Document_Scrap_Detail_AssetTag] ASC"
                    + "            DROP TABLE #TpAs";

            return RunSQL(sql);
        }

        
        /// <summary>
        /// 根据主键获取其下对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectTempTAsByMainID(string mainID, string dpm)
        {
            string sql = "CREATE TABLE #TpAs"
                    + "            (Asset_Id UNIQUEIDENTIFIER,"
                    + "            Asset_Company_Id NVARCHAR(80),"
                    + "            Asset_BigClass_Id NVARCHAR(80),"
                    + "            Asset_Place NVARCHAR(80),"
                    + "            Asset_AssetNo NVARCHAR(80),"
                    + "            Asset_Classes_Id NVARCHAR(80),"
                    + "            txtClasses NVARCHAR(80),"
                    + "            Asset_Type_Id NVARCHAR(80),"
                    + "            Asset_TS_Id NVARCHAR(80),"
                    + "            Asset_Number NVARCHAR(80),"
                    + "            Asset_RegionalDirector UNIQUEIDENTIFIER,"
                    + "            Asset_RecordedTime DATETIME,"
                    + "            Asset_CreateTime DATETIME,"
                    + "            Asset_IsScrap NVARCHAR(80),"
                    + "            Asset_Asset_NO NVARCHAR(80),"
                    + "            Asset_Department UNIQUEIDENTIFIER,"
                    + "            Assets_Dept_Name NVARCHAR(80),"
                    + "            txtPlace NVARCHAR(80),"
                    + "            txtTS NVARCHAR(80),"
                    + "            cv NVARCHAR(80),"
                    + "            txtType NVARCHAR(80))"
                    + "            INSERT INTO #TpAs"
                    + "            EXEC [DB_Administration].[dbo].[sp_t_Assets_Asset_Seach2]"
                    + "            @txtAsset_Department = '" + dpm + "',@Asset_AssetNo = '',@Asset_Classes = '',@beginAsset_RecordedTime = '',@endAsset_RecordedTime = ''"
                    + "            SELECT * FROM [t_OfficeAutomation_Document_Scrap_Detail_Temp] tp"
                    + "            LEFT JOIN #TpAs tpas"
                    + "            ON tp.OfficeAutomation_Document_Scrap_Detail_AssetTag = tpas.Asset_AssetNo"
                    + "            WHERE tp.OfficeAutomation_Document_Scrap_Detail_MainID = '" + mainID + "'"
                    + "            ORDER BY tp.[OfficeAutomation_Document_Scrap_Detail_AssetTag] ASC"
                    + "            DROP TABLE #TpAs";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据各条件获取其下对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectTempTAsdByAnother(string mainID, string dpm, string Id, string No, string Mod)
        {
            string sql = "CREATE TABLE #TpAsd"
                    + "            (Asset_Id UNIQUEIDENTIFIER,"
                    + "            Asset_Company_Id NVARCHAR(80),"
                    + "            Asset_BigClass_Id NVARCHAR(80),"
                    + "            Asset_Place NVARCHAR(80),"
                    + "            Asset_AssetNo NVARCHAR(80),"
                    + "            Asset_Classes_Id NVARCHAR(80),"
                    + "            txtClasses NVARCHAR(80),"
                    + "            Asset_Type_Id NVARCHAR(80),"
                    + "            Asset_TS_Id NVARCHAR(80),"
                    + "            Asset_Number NVARCHAR(80),"
                    + "            Asset_RegionalDirector UNIQUEIDENTIFIER,"
                    + "            Asset_RecordedTime DATETIME,"
                    + "            Asset_CreateTime DATETIME,"
                    + "            Asset_IsScrap NVARCHAR(80),"
                    + "            Asset_Asset_NO NVARCHAR(80),"
                    + "            Asset_Department UNIQUEIDENTIFIER,"
                    + "            Assets_Dept_Name NVARCHAR(80),"
                    + "            txtPlace NVARCHAR(80),"
                    + "            txtTS NVARCHAR(80),"
                    + "            cv NVARCHAR(80),"
                    + "            txtType NVARCHAR(80))"
                    + "            INSERT INTO #TpAsd"
                    + "            EXEC [DB_Administration].[dbo].[sp_t_Assets_Asset_Seach2]"
                    + "            @txtAsset_Department = '" + dpm + "',@Asset_AssetNo = '',@Asset_Classes = '',@beginAsset_RecordedTime = '',@endAsset_RecordedTime = ''"
                    + "            SELECT * FROM [t_OfficeAutomation_Document_Scrap_Detail_Temp] tp"
                    + "            LEFT JOIN #TpAsd tpas"
                    + "            ON tp.OfficeAutomation_Document_Scrap_Detail_AssetTag = tpas.Asset_AssetNo"
                    + "      WHERE  tp.[OfficeAutomation_Document_Scrap_Detail_MainID] = '" + mainID + "'"
                    + "  AND (tp.OfficeAutomation_Document_Scrap_Detail_AssetName LIKE '%" + Id + "%'"
                    + "  AND tp.OfficeAutomation_Document_Scrap_Detail_AssetTag LIKE '%" + No + "%'"
                    + "  AND tp.OfficeAutomation_Document_Scrap_Detail_Model LIKE '%" + Mod + "%')"
                    + "  ORDER BY tp.[OfficeAutomation_Document_Scrap_Detail_AssetTag] ASC"
                    + "  DROP TABLE #TpAsd";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据各条件获取其下对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectTempByAnother(string mainID, string Id, string No, string Mod)
        {
            string sql = "SELECT [OfficeAutomation_Document_Scrap_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_PlaceRec]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_BuyDate]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_Scrap_Detail_MainID] = '" + mainID + "'"
                    + "  AND (OfficeAutomation_Document_Scrap_Detail_AssetName LIKE '%" + Id + "%'"
                    + "  AND OfficeAutomation_Document_Scrap_Detail_AssetTag LIKE '%" + No + "%'"
                    + "  AND OfficeAutomation_Document_Scrap_Detail_Model LIKE '%" + Mod + "%')"
                    + "  ORDER BY [OfficeAutomation_Document_Scrap_Detail_AssetTag] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据各条件获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByAnother(string mainID, string Id, string No, string Mod)
        {
            string sql = "SELECT [OfficeAutomation_Document_Scrap_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTypeID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetTag]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Model]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetName]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_PlaceRec]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_AssetAID]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_Number]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_BuyDate]"
                    + "            ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail]"
                    + "      WHERE [OfficeAutomation_Document_Scrap_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_Scrap_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_Scrap toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_Scrap_MainID = '" + mainID + "')"
                    + "  AND (OfficeAutomation_Document_Scrap_Detail_AssetName LIKE '%" + Id + "%'"
                    + "  AND OfficeAutomation_Document_Scrap_Detail_AssetTag LIKE '%" + No + "%'"
                    + "  AND OfficeAutomation_Document_Scrap_Detail_Model LIKE '%" + Mod + "%')"
                    + "  ORDER BY [OfficeAutomation_Document_Scrap_Detail_AssetTag] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 删除对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool DeleteTemp(string mainID)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_Scrap_Detail_MainID] = '" + mainID + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MID和财务编号删除对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool DeleteTemp(string mainID, string No)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_Scrap_Detail_MainID] = '" + mainID + "'"
                    + "      AND OfficeAutomation_Document_Scrap_Detail_AssetTag = '" + No + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据ID删除对应的详情备份
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool DeleteTempByID(string ID)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail_Temp]"
                    + "      WHERE  [OfficeAutomation_Document_Scrap_Detail_ID] = '" + ID + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 把临时记录更新到详情表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool UpdateDetail(string MID)
        {
            string sql = "EXEC pr_Update_ScrapDetail_BAS '" + MID + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 是否需要特殊审核
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool IsITAsset(string mainID,string cv)
        {
            string sql = string.Format("select count(OfficeAutomation_Document_Scrap_Detail_ID) from [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail] where OfficeAutomation_Document_Scrap_Detail_MainID='{0}' and OfficeAutomation_Document_Scrap_Detail_CV like '%{1}%'", mainID,cv);

            DataSet ds= RunSQL(sql);
            int i = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            if (i > 0) {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool IsAPOS(string mainID)
        {
            string sql = string.Format(@"select *
                                             from [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail] 
                                             where OfficeAutomation_Document_Scrap_Detail_MainID='{0}' and OfficeAutomation_Document_Scrap_Detail_AssetName like 'POS%'
                                            ", mainID);
            DataSet ds = RunSQL(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 检查明细报废物业是否超过1000
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool IsBeyond1K(string mainID)
        {
            string sql = string.Format(@"SELECT * 
                                                FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail]  d
                                                WHERE EXISTS (SELECT OfficeAutomation_Document_Scrap_ID FROM t_OfficeAutomation_Document_Scrap m
		                                                      WHERE m.OfficeAutomation_Document_Scrap_ID = d.OfficeAutomation_Document_Scrap_Detail_MainID 
		                                                      AND  OfficeAutomation_Document_Scrap_MainID= '{0}')
                                                AND OfficeAutomation_Document_Scrap_Detail_Cost>=1000
		  										
                               ", mainID);
            DataSet ds = RunSQL(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
