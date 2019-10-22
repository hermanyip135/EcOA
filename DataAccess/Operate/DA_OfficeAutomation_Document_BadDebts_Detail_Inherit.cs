using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BadDebts_Detail_Inherit : DA_OfficeAutomation_Document_BadDebts_Detail_Operate
    {
        /// <summary>
        /// 根据退佣申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_BadDebts_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_ReportID]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_Address]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_Owner]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_Client]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_BadReason]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_IsAutoBad]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_AutoBadDate]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_DealDate]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_BadDate]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_Area]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_No]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts_Detail]"
                          + " WHERE [OfficeAutomation_Document_BadDebts_Detail_MainID]='" + id + "'"
                          + " ORDER BY CONVERT(INT,OfficeAutomation_Document_BadDebts_Detail_No) ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_BadDebts_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_ReportID]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_Address]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_Owner]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_Client]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_BadReason]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_IsAutoBad]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_AutoBadDate]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_DealDate]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_BadDate]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_Area]"
                          + "            ,[OfficeAutomation_Document_BadDebts_Detail_No]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts_Detail]"
                          + " WHERE [OfficeAutomation_Document_BadDebts_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_BadDebts_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_BadDebts toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_BadDebts_MainID = '" + mainID + "')"
                          + " ORDER BY CONVERT(INT,OfficeAutomation_Document_BadDebts_Detail_No) ASC";

            return RunSQL(sql);
        }
    }
}
