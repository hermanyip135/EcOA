using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PullafewTwo_LeaseTerm_Inherit : DA_OfficeAutomation_Document_PullafewTwo_LeaseTerm_Operate
    {
        /// <summary>
        /// 根据退佣申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_PullafewTwo_LeaseTerm_ID]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_MainID]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1a]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1b]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1c]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1d]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1e]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1f]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1g]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1h]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1i]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo_LeaseTerm]"
                          + " WHERE [OfficeAutomation_Document_PullafewTwo_LeaseTerm_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_PullafewTwo_LeaseTerm_1a] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_PullafewTwo_LeaseTerm_ID]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_MainID]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1a]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1b]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1c]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1d]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1e]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1f]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1g]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_LeaseTerm_1h]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo_LeaseTerm]"
                          + " WHERE [OfficeAutomation_Document_PullafewTwo_LeaseTerm_MainID]= (SELECT toads.OfficeAutomation_Document_PullafewTwo_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_PullafewTwo toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_PullafewTwo_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_PullafewTwo_LeaseTerm_1a] ASC";

            return RunSQL(sql);
        }
    }
}
