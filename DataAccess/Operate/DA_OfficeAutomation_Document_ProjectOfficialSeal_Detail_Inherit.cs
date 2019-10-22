using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ProjectOfficialSeal_Detail_Inherit : DA_OfficeAutomation_Document_ProjectOfficialSeal_Detail_Operate
    {
        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_ProjectOfficialSeal_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_TransFile]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_FileName]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_AgentBeginData]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_AgentEndData]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_BN]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_Company]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_Use]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectOfficialSeal_Detail]"
                          + " WHERE [OfficeAutomation_Document_ProjectOfficialSeal_Detail_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_ProjectOfficialSeal_Detail_TransFile] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_ProjectOfficialSeal_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_TransFile]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_FileName]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_AgentBeginData]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_AgentEndData]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_BN]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_Company]"
                          + "            ,[OfficeAutomation_Document_ProjectOfficialSeal_Detail_Use]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectOfficialSeal_Detail]"
                          + " WHERE [OfficeAutomation_Document_ProjectOfficialSeal_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_ProjectOfficialSeal_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_ProjectOfficialSeal toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_ProjectOfficialSeal_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_ProjectOfficialSeal_Detail_TransFile] ASC";

            return RunSQL(sql);
        }
    }
}
