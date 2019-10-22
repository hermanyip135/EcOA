using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Feasibility_Statistical_Inherit : DA_OfficeAutomation_Document_Feasibility_Statistical_Operate
    {
        /// <summary>
        /// 根据获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_Statistical_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_MainID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_Bname]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_GzspsNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_GzspsRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_RichNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_RichRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_EveryNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_EveryRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_YuFengNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_YuFengRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_OtherNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_OtherRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_FreeNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_FreeRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_AllSum]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Statistical]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_Statistical_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_Statistical_Bname] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_Statistical_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_MainID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_Bname]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_GzspsNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_GzspsRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_RichNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_RichRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_EveryNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_EveryRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_YuFengNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_YuFengRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_OtherNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_OtherRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_FreeNum]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_FreeRate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Statistical_AllSum]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Statistical]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_Statistical_MainID]= (SELECT toads.OfficeAutomation_Document_Feasibility_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_Feasibility toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_Feasibility_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_Statistical_Bname] ASC";

            return RunSQL(sql);
        }
    }
}
