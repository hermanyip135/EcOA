using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OweSubmit_Inherit : DA_OfficeAutomation_Document_OweSubmit_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_OweSubmit_ID]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_MainID]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Apply]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_ApplyID]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Department]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Subject]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Name]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Branch]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Position]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_InductionDate]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Detail]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Certificate]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Affiliated]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Why]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_SupplementaryDate]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Opinion]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Hukouxz]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Hujidz]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_HouseholderName]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OweSubmit] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_OweSubmit_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_OweSubmit_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_OweSubmit_ID]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_MainID]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Apply]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_ApplyID]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Department]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Subject]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Name]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Branch]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Position]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_InductionDate]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Detail]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Certificate]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Affiliated]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Why]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_SupplementaryDate]"
                           + "           ,[OfficeAutomation_Document_OweSubmit_Opinion]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OweSubmit] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_OweSubmit_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_OweSubmit_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
