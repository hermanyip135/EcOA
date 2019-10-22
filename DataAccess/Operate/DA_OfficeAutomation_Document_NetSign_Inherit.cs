using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_NetSign_Inherit : DA_OfficeAutomation_Document_NetSign_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_NetSign_ID]"
                           + "           ,[OfficeAutomation_Document_NetSign_MainID]"
                           + "           ,[OfficeAutomation_Document_NetSign_Apply]"
                           + "           ,[OfficeAutomation_Document_NetSign_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_NetSign_ApplyID]"
                           + "           ,[OfficeAutomation_Document_NetSign_Department]"
                           + "           ,[OfficeAutomation_Document_NetSign_KindOfApply]"
                           + "           ,[OfficeAutomation_Document_NetSign_HHManage]"
                           + "           ,[OfficeAutomation_Document_NetSign_BudingAddress]"
                           + "           ,[OfficeAutomation_Document_NetSign_TakeBranch]"
                           + "           ,[OfficeAutomation_Document_NetSign_ZYFollows]"
                           + "           ,[OfficeAutomation_Document_NetSign_SendBank]"
                           + "           ,[OfficeAutomation_Document_NetSign_Borrower]"
                           + "           ,[OfficeAutomation_Document_NetSign_Price]"
                           + "           ,[OfficeAutomation_Document_NetSign_DealPrice]"
                           + "           ,[OfficeAutomation_Document_NetSign_Loan]"
                           + "           ,[OfficeAutomation_Document_NetSign_Company1]"
                           + "           ,[OfficeAutomation_Document_NetSign_Assessment1]"
                           + "           ,[OfficeAutomation_Document_NetSign_Company2]"
                           + "           ,[OfficeAutomation_Document_NetSign_Assessment2]"
                           + "           ,[OfficeAutomation_Document_NetSign_Company3]"
                           + "           ,[OfficeAutomation_Document_NetSign_Assessment3]"
                           + "           ,[OfficeAutomation_Document_NetSign_Describe]"
                           + "           ,[OfficeAutomation_Document_NetSign_Space]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NetSign] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_NetSign_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_NetSign_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_NetSign_ID]"
                           + "           ,[OfficeAutomation_Document_NetSign_MainID]"
                           + "           ,[OfficeAutomation_Document_NetSign_Apply]"
                           + "           ,[OfficeAutomation_Document_NetSign_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_NetSign_ApplyID]"
                           + "           ,[OfficeAutomation_Document_NetSign_Department]"
                           + "           ,[OfficeAutomation_Document_NetSign_KindOfApply]"
                           + "           ,[OfficeAutomation_Document_NetSign_HHManage]"
                           + "           ,[OfficeAutomation_Document_NetSign_BudingAddress]"
                           + "           ,[OfficeAutomation_Document_NetSign_TakeBranch]"
                           + "           ,[OfficeAutomation_Document_NetSign_ZYFollows]"
                           + "           ,[OfficeAutomation_Document_NetSign_SendBank]"
                           + "           ,[OfficeAutomation_Document_NetSign_Borrower]"
                           + "           ,[OfficeAutomation_Document_NetSign_Price]"
                           + "           ,[OfficeAutomation_Document_NetSign_DealPrice]"
                           + "           ,[OfficeAutomation_Document_NetSign_Loan]"
                           + "           ,[OfficeAutomation_Document_NetSign_Company1]"
                           + "           ,[OfficeAutomation_Document_NetSign_Assessment1]"
                           + "           ,[OfficeAutomation_Document_NetSign_Company2]"
                           + "           ,[OfficeAutomation_Document_NetSign_Assessment2]"
                           + "           ,[OfficeAutomation_Document_NetSign_Company3]"
                           + "           ,[OfficeAutomation_Document_NetSign_Assessment3]"
                           + "           ,[OfficeAutomation_Document_NetSign_Describe]"
                           + "           ,[OfficeAutomation_Document_NetSign_Space]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NetSign] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_NetSign_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_NetSign_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
