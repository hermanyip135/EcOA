using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_AfterCommission_Inherit : DA_OfficeAutomation_Document_AfterCommission_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_AfterCommission_ID]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_MainID]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Apply]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_ApplyID]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Department]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Subject]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Name]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_HasCommission]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_CommissionMoney]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Contact]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Address]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Reason]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Data]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AfterCommission] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_AfterCommission_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_AfterCommission_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_AfterCommission_ID]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_MainID]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Apply]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_ApplyID]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Department]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Subject]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Name]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_HasCommission]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_CommissionMoney]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Contact]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Address]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Reason]"
                           + "           ,[OfficeAutomation_Document_AfterCommission_Data]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AfterCommission] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_AfterCommission_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_AfterCommission_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
