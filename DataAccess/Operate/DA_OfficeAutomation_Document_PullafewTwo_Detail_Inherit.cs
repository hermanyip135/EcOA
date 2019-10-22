using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PullafewTwo_Detail_Inherit : DA_OfficeAutomation_Document_PullafewTwo_Detail_Operate
    {
        /// <summary>
        /// 根据退佣申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_PullafewTwo_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1a]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1b]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1c]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1d]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1e]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1f]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1ff]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1g]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1h]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo_Detail]"
                          + " WHERE [OfficeAutomation_Document_PullafewTwo_Detail_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_PullafewTwo_Detail_1a] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_PullafewTwo_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1a]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1b]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1c]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1d]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1e]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1f]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1ff]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1g]"
                          + "            ,[OfficeAutomation_Document_PullafewTwo_Detail_1h]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo_Detail]"
                          + " WHERE [OfficeAutomation_Document_PullafewTwo_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_PullafewTwo_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_PullafewTwo toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_PullafewTwo_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_PullafewTwo_Detail_1a] ASC";

            return RunSQL(sql);
        }
    }
}
