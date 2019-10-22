using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CommissionOfMonth_Inherit : DA_OfficeAutomation_Document_CommissionOfMonth_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_CommissionOfMonth_ID]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_MainID]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Apply]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_ApplyID]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Department]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Name]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Code]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_EnterDate]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Position]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Rank]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Results]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Describe]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionOfMonth] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_CommissionOfMonth_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_CommissionOfMonth_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_CommissionOfMonth_ID]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_MainID]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Apply]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_ApplyID]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Department]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Name]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Code]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_EnterDate]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Position]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Rank]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Results]"
                           + "           ,[OfficeAutomation_Document_CommissionOfMonth_Describe]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionOfMonth] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_CommissionOfMonth_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_CommissionOfMonth_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
