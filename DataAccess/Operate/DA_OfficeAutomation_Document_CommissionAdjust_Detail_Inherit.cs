using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CommissionAdjust_Detail_Inherit : DA_OfficeAutomation_Document_CommissionAdjust_Detail_Operate
    {
        /// <summary>
        /// 根据获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_CommissionAdjust_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_pNo]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Property]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Controler]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Cname]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Commitment]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Reason]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_DealType]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_ChangeType]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust_Detail]"
                          + " WHERE [OfficeAutomation_Document_CommissionAdjust_Detail_MainID]='" + id + "'"
                          + " ORDER BY convert(int,[OfficeAutomation_Document_CommissionAdjust_Detail_pNo]) ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_CommissionAdjust_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_pNo]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Property]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Controler]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Cname]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Commitment]"
                          + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Reason]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust_Detail]"
                          + " WHERE [OfficeAutomation_Document_CommissionAdjust_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_CommissionAdjust_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_CommissionAdjust toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_CommissionAdjust_MainID = '" + mainID + "')"
                          + " ORDER BY convert(int,[OfficeAutomation_Document_CommissionAdjust_Detail_pNo]) ASC";

            return RunSQL(sql);
        }
    }
}
