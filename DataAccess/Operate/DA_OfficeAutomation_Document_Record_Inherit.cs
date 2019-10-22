using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Record_Inherit : DA_OfficeAutomation_Document_Record_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Record_ID]"
                           + "           ,[OfficeAutomation_Document_Record_MainID]"
                           + "           ,[OfficeAutomation_Document_Record_Apply]"
                           + "           ,[OfficeAutomation_Document_Record_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Record_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Record_Department]"
                           + "           ,[OfficeAutomation_Document_Record_Address]"
                           + "           ,[OfficeAutomation_Document_Record_AName]"
                           + "           ,[OfficeAutomation_Document_Record_APhone]"
                           + "           ,[OfficeAutomation_Document_Record_Bname]"
                           + "           ,[OfficeAutomation_Document_Record_Bphone]"
                           + "           ,[OfficeAutomation_Document_Record_Clerk]"
                           + "           ,[OfficeAutomation_Document_Record_Master]"
                           + "           ,[OfficeAutomation_Document_Record_TurnDate]"
                           + "           ,[OfficeAutomation_Document_Record_Reason]"
                           + "           ,[OfficeAutomation_Document_Record_Business]"
                           + "           ,[OfficeAutomation_Document_Record_Tname]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Record] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Record_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Record_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Record_ID]"
                           + "           ,[OfficeAutomation_Document_Record_MainID]"
                           + "           ,[OfficeAutomation_Document_Record_Apply]"
                           + "           ,[OfficeAutomation_Document_Record_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Record_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Record_Department]"
                           + "           ,[OfficeAutomation_Document_Record_Address]"
                           + "           ,[OfficeAutomation_Document_Record_AName]"
                           + "           ,[OfficeAutomation_Document_Record_APhone]"
                           + "           ,[OfficeAutomation_Document_Record_Bname]"
                           + "           ,[OfficeAutomation_Document_Record_Bphone]"
                           + "           ,[OfficeAutomation_Document_Record_Clerk]"
                           + "           ,[OfficeAutomation_Document_Record_Master]"
                           + "           ,[OfficeAutomation_Document_Record_TurnDate]"
                           + "           ,[OfficeAutomation_Document_Record_Reason]"
                           + "           ,[OfficeAutomation_Document_Record_Business]"
                           + "           ,[OfficeAutomation_Document_Record_Tname]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Record] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Record_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Record_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
