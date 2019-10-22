using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Feasibility_YearRent_Inherit : DA_OfficeAutomation_Document_Feasibility_YearRent_Operate
    {
        /// <summary>
        /// 根据获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_YearRent_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_MainID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_YearNo]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_NoTaxRent]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_HasTaxRent]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_RentCoast]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_RateOfAdd]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_RentOfAdd]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_YearRent]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_YearRent_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_YearRent_YearNo] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_YearRent_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_MainID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_YearNo]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_NoTaxRent]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_HasTaxRent]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_RentCoast]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_RateOfAdd]"
                          + "            ,[OfficeAutomation_Document_Feasibility_YearRent_RentOfAdd]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_YearRent]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_YearRent_MainID]= (SELECT toads.OfficeAutomation_Document_Feasibility_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_Feasibility toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_Feasibility_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_YearRent_YearNo] ASC";

            return RunSQL(sql);
        }
    }
}
