using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SysPower_Detail_Inherit : DA_OfficeAutomation_Document_SysPower_Detail_Operate
    {
        /// <summary>
        /// 根据(汇瀚/二级市场/后勤)IT权限申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_SysPower_Detail_ID]"
                    + "                 ,[OfficeAutomation_Document_SysPower_Detail_MainID]"
                    + "                 ,[OfficeAutomation_Document_SysPower_Detail_EmployeeID]"
                    + "                 ,[OfficeAutomation_Document_SysPower_Detail_Employee]"
                    + "                 ,[OfficeAutomation_Document_SysPower_Detail_Position]"
                    + "                 ,[OfficeAutomation_Document_SysPower_Detail_Department]"
                    + "                 ,[OfficeAutomation_Document_SysPower_Detail_DepartmentID]"
                    + "                 ,[OfficeAutomation_Document_SysPower_Detail_BeginDate]"
                    + "                 ,[OfficeAutomation_Document_SysPower_Detail_ApplyTypeID]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysPower_Detail]"
                    + "      WHERE [OfficeAutomation_Document_SysPower_Detail_MainID]='" + mainID + "'"
                    + "  ORDER BY [OfficeAutomation_Document_SysPower_Detail_EmployeeID] ASC";

            return RunSQL(sql);
        }
    }
}
