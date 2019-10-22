using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Inherit : DA_OfficeAutomation_Document_EBAdjuct_LeaseTerm_Operate
    {
        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_EBAdjuct_LeaseTerm_ID]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_LeaseTerm_MainID]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_LeaseTerm_Money]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_LeaseTerm_Reason]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_LeaseTerm_Condition]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct_LeaseTerm]"
                    + "      WHERE [OfficeAutomation_Document_EBAdjuct_LeaseTerm_MainID]='" + id + "'"
                    + "  ORDER BY [OfficeAutomation_Document_EBAdjuct_LeaseTerm_Money] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_EBAdjuct_LeaseTerm_ID]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_LeaseTerm_MainID]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_LeaseTerm_Money]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_LeaseTerm_Reason]"
                    + "            ,[OfficeAutomation_Document_EBAdjuct_LeaseTerm_Condition]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct_LeaseTerm]"
                    + "      WHERE [OfficeAutomation_Document_EBAdjuct_LeaseTerm_MainID]= (SELECT toads.OfficeAutomation_Document_AssetTransfer_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_AssetTransfer toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_AssetTransfer_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_EBAdjuct_LeaseTerm_Money] ASC";

            return RunSQL(sql);
        }
    }
}
