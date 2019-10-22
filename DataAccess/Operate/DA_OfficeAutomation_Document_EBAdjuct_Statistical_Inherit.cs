using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_EBAdjuct_Statistical_Inherit : DA_OfficeAutomation_Document_EBAdjuct_Statistical_Operate
    {
        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_EBAdjuct_Statistical_ID]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_MainID]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_Money]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_Reason]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_Condition]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct_Statistical]"
                    + "      WHERE [OfficeAutomation_Document_EBAdjuct_Statistical_MainID]='" + id + "'"
                    + "  ORDER BY [OfficeAutomation_Document_EBAdjuct_Statistical_Money] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_EBAdjuct_Statistical_ID]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_MainID]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_Money]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_Reason]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_Statistical_Condition]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct_Statistical]"
                    + "      WHERE [OfficeAutomation_Document_EBAdjuct_Statistical_MainID]= (SELECT toads.OfficeAutomation_Document_AssetTransfer_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_AssetTransfer toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_AssetTransfer_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_EBAdjuct_Statistical_Money] ASC";

            return RunSQL(sql);
        }
    }
}
