using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ITPower_Detail_Inherit : DA_OfficeAutomation_Document_ITPower_Detail_Operate
    {
        /// <summary>
        /// 根据IT权限表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_ITPower_Detail_ID]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_MainID]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_EmployeeID]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_Employee]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_Position]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_Department]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_DepartmentID]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_BeginDate]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_ApplyTypeID]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_Client]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_House]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_ImportDepartment]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_ImportDepartmentID]"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_ExportDepartment]"
                   + "                 ,OfficeAutomation_Document_ITPower_Detail_ANumber"
                    + "                 ,[OfficeAutomation_Document_ITPower_Detail_ExportDepartmentID]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITPower_Detail]"
                    + "      WHERE [OfficeAutomation_Document_ITPower_Detail_MainID]='" + mainID + "'"
                    + "  ORDER BY [OfficeAutomation_Document_ITPower_Detail_EmployeeID] ASC";

            return RunSQL(sql);
        }
    }
}
