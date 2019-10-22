using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ProjBaComm_Detail_Inherit : DA_OfficeAutomation_Document_ProjBaComm_Detail_Operate
    {
        /// <summary>
        /// 根据退佣申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_ProjBaComm_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_pNo]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_ReportNo]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_DealDate]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_Address]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_Bname]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_BackMoney]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_IsOnJob]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_IsPayComm]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjBaComm_Detail]"
                          + " WHERE [OfficeAutomation_Document_ProjBaComm_Detail_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_ProjBaComm_Detail_pNo] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_ProjBaComm_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_pNo]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_ReportNo]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_DealDate]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_Address]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_Bname]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_BackMoney]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_IsOnJob]"
                          + "            ,[OfficeAutomation_Document_ProjBaComm_Detail_IsPayComm]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjBaComm_Detail]"
                          + " WHERE [OfficeAutomation_Document_ProjBaComm_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_ProjBaComm_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_ProjBaComm toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_ProjBaComm_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_ProjBaComm_Detail_pNo] ASC";

            return RunSQL(sql);
        }
    }
}
