using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_Dic_OfficeAutomation_AssetType_Operate : SqlInteractionBase
    {
        /// <summary>
        /// 获得正在使用的资产类型
        /// </summary>
        /// <returns></returns>
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_AssetType_ID]"
                            + "         ,[OfficeAutomation_AssetType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_AssetType]"
                            + "  WHERE [OfficeAutomation_AssetType_IsEnable]=1"
                            +"  ORDER BY [OfficeAutomation_AssetType_OrderID] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过资产主键，获得资产名称
        /// </summary>
        /// <returns></returns>
        public string SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_AssetType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_AssetType]"
                            + "  WHERE [OfficeAutomation_AssetType_ID]=" + id;

            DataSet ds = RunSQL(sql);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][0].ToString();
            else
                return null;
        }

        /// <summary>
        /// 资产类型是否为IT类
        /// </summary>
        /// <param name="typeID">类型ID</param>
        /// <returns></returns>
        public bool IsITAssetType(string typeID)
        {
            string sql = "SELECT [OfficeAutomation_AssetType_IsIT]"
                        + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_AssetType]"
                        + "  WHERE [OfficeAutomation_AssetType_ID]=" + typeID;

            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][0].ToString() == "True";

            return false;
        }
    }
}
