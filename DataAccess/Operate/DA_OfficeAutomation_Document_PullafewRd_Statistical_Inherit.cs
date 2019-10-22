using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PullafewRd_Statistical_Inherit : DA_OfficeAutomation_Document_PullafewRd_Statistical_Operate
    {
        /// <summary>
        /// 根据退佣申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_PullafewRd_Statistical_ID]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_MainID]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1a]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1b]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1c]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1d]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1e]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1f]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1g]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1h]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1i]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1j]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1jk]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1k]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1l]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1m]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewRd_Statistical]"
                          + " WHERE [OfficeAutomation_Document_PullafewRd_Statistical_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_PullafewRd_Statistical_1a] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_PullafewRd_Statistical_ID]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_MainID]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1a]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1b]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1c]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1d]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1e]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1f]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1g]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1h]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1i]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1j]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1jk]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1k]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1l]"
                          + "            ,[OfficeAutomation_Document_PullafewRd_Statistical_1m]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewRd_Statistical]"
                          + " WHERE [OfficeAutomation_Document_PullafewRd_Statistical_MainID]= (SELECT toads.OfficeAutomation_Document_BackComm_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_BackComm toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_BackComm_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_PullafewRd_Statistical_1a] ASC";

            return RunSQL(sql);
        }
    }
}
