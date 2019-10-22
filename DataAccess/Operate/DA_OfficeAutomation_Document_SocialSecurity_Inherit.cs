using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SocialSecurity_Inherit : DA_OfficeAutomation_Document_SocialSecurity_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SocialSecurity_ID]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_MainID]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Apply]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Department]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Name]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Code]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_EnterDate]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Position]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Rank]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Results]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Describe]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Money]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_SureTime]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SocialSecurity] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SocialSecurity_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SocialSecurity_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SocialSecurity_ID]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_MainID]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Apply]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Department]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Name]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Code]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_EnterDate]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Position]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Rank]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Results]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Describe]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_Money]"
                           + "           ,[OfficeAutomation_Document_SocialSecurity_SureTime]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SocialSecurity] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SocialSecurity_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SocialSecurity_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
