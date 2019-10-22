using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Propaganda_Statistical_Inherit : DA_OfficeAutomation_Document_Propaganda_Statistical_Operate
    {
        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Propaganda_Statistical_ID]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_MainID]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_SNo]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_SDepartment]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_Address]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_SCount]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda_Statistical]"
                          + " WHERE [OfficeAutomation_Document_Propaganda_Statistical_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_Propaganda_Statistical_SNo] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_Propaganda_Statistical_ID]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_MainID]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_SNo]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_SDepartment]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_Address]"
                          + "            ,[OfficeAutomation_Document_Propaganda_Statistical_SCount]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda_Statistical]"
                          + " WHERE [OfficeAutomation_Document_Propaganda_Statistical_MainID]= (SELECT toads.OfficeAutomation_Document_Propaganda_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_Propaganda toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_Propaganda_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_Propaganda_Statistical_SNo] ASC";

            return RunSQL(sql);
        }
    }
}
