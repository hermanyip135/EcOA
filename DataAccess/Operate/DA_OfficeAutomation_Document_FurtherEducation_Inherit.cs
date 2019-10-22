using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_FurtherEducation_Inherit : DA_OfficeAutomation_Document_FurtherEducation_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_FurtherEducation_ID]"

                           + "           ,[OfficeAutomation_Document_FurtherEducation_MainID]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Apply]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ApplyID]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Department]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_No]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_InData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_OnData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Position]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Rank]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Srecord]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Welfare]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_IDData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_School]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Subjects]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_BeginData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_During]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_EndData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Fees]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ShouldAllowance]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ApplyAllowance]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ActualyAllowance]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Conditions]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_AllowData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_A]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Name]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Remark]"

                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_FurtherEducation] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_FurtherEducation_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_FurtherEducation_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_FurtherEducation_ID]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_MainID]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Apply]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ApplyID]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Department]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_No]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_InData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_OnData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Position]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Rank]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Srecord]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Welfare]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_IDData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_School]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Subjects]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_BeginData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_During]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_EndData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Fees]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ShouldAllowance]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ApplyAllowance]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_ActualyAllowance]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Conditions]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_AllowData]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_A]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Name]"
                           + "           ,[OfficeAutomation_Document_FurtherEducation_Remark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_FurtherEducation] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_FurtherEducation_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_FurtherEducation_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
