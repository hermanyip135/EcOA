using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OfficialSeal_Detail_Inherit : DA_OfficeAutomation_Document_OfficialSeal_Detail_Operate
    {
        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_OfficialSeal_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_TransFile]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_FileName]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_BN]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_Company]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_Use]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal_Detail]"
                          + " WHERE [OfficeAutomation_Document_OfficialSeal_Detail_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_OfficialSeal_Detail_TransFile] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_OfficialSeal_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_TransFile]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_FileName]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_BN]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_Company]"
                          + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_Use]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal_Detail]"
                          + " WHERE [OfficeAutomation_Document_OfficialSeal_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_OfficialSeal_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_OfficialSeal toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_OfficialSeal_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_OfficialSeal_Detail_TransFile] ASC";

            return RunSQL(sql);
        }
    }
}
