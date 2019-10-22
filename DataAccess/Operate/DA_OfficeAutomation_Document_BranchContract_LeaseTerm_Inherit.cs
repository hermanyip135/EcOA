using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BranchContract_LeaseTerm_Inherit : DA_OfficeAutomation_Document_BranchContract_LeaseTerm_Operate
    {
        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_BranchContract_LeaseTerm_ID]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_MainID]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_BeginData]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_EndData]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_TaxRent]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_Rent]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BranchContract_LeaseTerm]"
                          + " WHERE [OfficeAutomation_Document_BranchContract_LeaseTerm_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_BranchContract_LeaseTerm_BeginData] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_BranchContract_LeaseTerm_ID]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_MainID]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_BeginData]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_EndData]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_TaxRent]"
                          + "            ,[OfficeAutomation_Document_BranchContract_LeaseTerm_Rent]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BranchContract_LeaseTerm]"
                          + " WHERE [OfficeAutomation_Document_BranchContract_LeaseTerm_MainID]= (SELECT toads.OfficeAutomation_Document_BranchContract_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_BranchContract toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_BranchContract_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_BranchContract_LeaseTerm_BeginData] ASC";

            return RunSQL(sql);
        }
    }
}
