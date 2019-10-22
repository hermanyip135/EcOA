using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_WrongSave_Inherit : DA_OfficeAutomation_Document_WrongSave_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_WrongSave_ID]"
                           + "           ,[OfficeAutomation_Document_WrongSave_MainID]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Apply]"
                           + "           ,[OfficeAutomation_Document_WrongSave_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_WrongSave_ApplyID]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Department]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Address]"
                           + "           ,[OfficeAutomation_Document_WrongSave_ADNo]"
                           + "           ,[OfficeAutomation_Document_WrongSave_WSDate]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfM]"
                           + "           ,[OfficeAutomation_Document_WrongSave_BigSMoney]"
                           + "           ,[OfficeAutomation_Document_WrongSave_SmallSMoney]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWS]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSA]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSB]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSC]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSD]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldS]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldSA]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldSB]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldSC]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldSD]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Wname]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Wposition]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Opinion]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WrongSave] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_WrongSave_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_WrongSave_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_WrongSave_ID]"
                           + "           ,[OfficeAutomation_Document_WrongSave_MainID]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Apply]"
                           + "           ,[OfficeAutomation_Document_WrongSave_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_WrongSave_ApplyID]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Department]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Address]"
                           + "           ,[OfficeAutomation_Document_WrongSave_ADNo]"
                           + "           ,[OfficeAutomation_Document_WrongSave_WSDate]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfM]"
                           + "           ,[OfficeAutomation_Document_WrongSave_BigSMoney]"
                           + "           ,[OfficeAutomation_Document_WrongSave_SmallSMoney]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWS]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSA]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSB]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSC]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSD]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldS]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldSA]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldSB]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldSC]"
                           + "           ,[OfficeAutomation_Document_WrongSave_KShouldSD]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Wname]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Wposition]"
                           + "           ,[OfficeAutomation_Document_WrongSave_Opinion]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WrongSave] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_WrongSave_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_WrongSave_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
