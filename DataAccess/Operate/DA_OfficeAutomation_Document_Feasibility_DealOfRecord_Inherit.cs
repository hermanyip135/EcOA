using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Feasibility_DealOfRecord_Inherit : DA_OfficeAutomation_Document_Feasibility_DealOfRecord_Operate
    {
        /// <summary>
        /// 根据获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_DealOfRecord_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_MainID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_DealOfRecord]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_DealOfRecord_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_DealOfRecord_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_MainID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet]"
                          + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_DealOfRecord]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_DealOfRecord_MainID]= (SELECT toads.OfficeAutomation_Document_Feasibility_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_Feasibility toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_Feasibility_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding] ASC";

            return RunSQL(sql);
        }
    }
}
