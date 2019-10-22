using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Tourism_Inherit : DA_OfficeAutomation_Document_Tourism_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Tourism_ID]"
                           + "           ,[OfficeAutomation_Document_Tourism_MainID]"
                           + "           ,[OfficeAutomation_Document_Tourism_Apply]"
                           + "           ,[OfficeAutomation_Document_Tourism_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Tourism_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Tourism_Department]"
                           + "           ,[OfficeAutomation_Document_Tourism_Subject]"
                           + "           ,[OfficeAutomation_Document_Tourism_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_Tourism_Reason]"
                           + "           ,[OfficeAutomation_Document_Tourism_ActivityData]"
                           + "           ,[OfficeAutomation_Document_Tourism_ActivityEndData]"
                           + "           ,[OfficeAutomation_Document_Tourism_ActivityPlace]"
                           + "           ,[OfficeAutomation_Document_Tourism_Insurance]"
                           + "           ,[OfficeAutomation_Document_Tourism_NoInsurance]"
                           + "           ,[OfficeAutomation_Document_Tourism_Operating]"
                           + "           ,[OfficeAutomation_Document_Tourism_OperatingArrange]"
                           + "           ,[OfficeAutomation_Document_Tourism_Area]"
                           + "           ,[OfficeAutomation_Document_Tourism_Attendance]"
                           + "           ,[OfficeAutomation_Document_Tourism_Organizer]"
                           + "           ,[OfficeAutomation_Document_Tourism_OtherMemo]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Tourism] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Tourism_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Tourism_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Tourism_ID]"
                           + "           ,[OfficeAutomation_Document_Tourism_MainID]"
                           + "           ,[OfficeAutomation_Document_Tourism_Apply]"
                           + "           ,[OfficeAutomation_Document_Tourism_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Tourism_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Tourism_Department]"
                           + "           ,[OfficeAutomation_Document_Tourism_Subject]"
                           + "           ,[OfficeAutomation_Document_Tourism_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_Tourism_Reason]"
                           + "           ,[OfficeAutomation_Document_Tourism_ActivityData]"
                           + "           ,[OfficeAutomation_Document_Tourism_ActivityEndData]"
                           + "           ,[OfficeAutomation_Document_Tourism_ActivityPlace]"
                           + "           ,[OfficeAutomation_Document_Tourism_Insurance]"
                           + "           ,[OfficeAutomation_Document_Tourism_NoInsurance]"
                           + "           ,[OfficeAutomation_Document_Tourism_Operating]"
                           + "           ,[OfficeAutomation_Document_Tourism_OperatingArrange]"
                           + "           ,[OfficeAutomation_Document_Tourism_Area]"
                           + "           ,[OfficeAutomation_Document_Tourism_Attendance]"
                           + "           ,[OfficeAutomation_Document_Tourism_Organizer]"
                           + "           ,[OfficeAutomation_Document_Tourism_OtherMemo]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Tourism] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Tourism_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Tourism_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
