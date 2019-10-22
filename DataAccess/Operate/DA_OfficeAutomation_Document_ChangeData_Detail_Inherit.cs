using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ChangeData_Detail_Inherit : DA_OfficeAutomation_Document_ChangeData_Detail_Operate
    {
        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_ChangeData_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_pNo]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_CountOffTime]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_DealNo]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_OtherDataAddress]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_ChangeSituation]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_ChangeReason]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_ProjectName]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_Cname]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_ChangeCname]"
                          + "           ,[OfficeAutomation_Document_ChangeData_Detail_Type]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeData_Detail]"
                          + " WHERE [OfficeAutomation_Document_ChangeData_Detail_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_ChangeData_Detail_pNo] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_ChangeData_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_pNo]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_CountOffTime]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_DealNo]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_OtherDataAddress]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_ChangeSituation]"
                          + "            ,[OfficeAutomation_Document_ChangeData_Detail_ChangeReason]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeData_Detail]"
                          + " WHERE [OfficeAutomation_Document_ChangeData_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_ChangeData_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_ChangeData toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_ChangeData_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_ChangeData_Detail_pNo] ASC";

            return RunSQL(sql);
        }
    }
}
