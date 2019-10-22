using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BackComm_Detail_Inherit : DA_OfficeAutomation_Document_BackComm_Detail_Operate
    {
        /// <summary>
        /// 根据退佣申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_BackComm_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_Department]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_Sales]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_Team]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_BackMoney]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_IsOnJob]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_IsPayComm]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BackComm_Detail]"
                          + " WHERE [OfficeAutomation_Document_BackComm_Detail_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_BackComm_Detail_ID] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_BackComm_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_Department]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_Sales]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_Team]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_BackMoney]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_IsOnJob]"
                          + "            ,[OfficeAutomation_Document_BackComm_Detail_IsPayComm]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BackComm_Detail]"
                          + " WHERE [OfficeAutomation_Document_BackComm_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_BackComm_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_BackComm toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_BackComm_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_BackComm_Detail_ID] ASC";

            return RunSQL(sql);
        }
    }
}
