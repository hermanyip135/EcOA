using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_EBAdjuct_Inherit : DA_OfficeAutomation_Document_EBAdjuct_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  "
                           //+ "             [OfficeAutomation_Document_EBAdjuct_ID]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_MainID]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_Apply]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_ApplyDate]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_ApplyID]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_ApplyName]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_Department]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_BonusC1]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_ProjectPCMomey]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_ProjectEBMomey]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_Bonus4]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_ValidityBeginDate]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_ValidityEndDate]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_Bonus5]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_BonusSituation]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_WholeName]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_Position]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_Phone]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_AccountName]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_No]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_IsTax]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_BonusMoney]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_IsConfirm]"
                           //+ "           ,[OfficeAutomation_Document_EBAdjuct_SubmitDate]"
                           +"           todi.*"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_EBAdjuct_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_EBAdjuct_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT "
                          //+"               [OfficeAutomation_Document_EBAdjuct_ID]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_MainID]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_Apply]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_ApplyDate]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_ApplyID]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_ApplyName]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_Department]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_BonusC1]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_ProjectPCMomey]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_ProjectEBMomey]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_Bonus4]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_ValidityBeginDate]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_ValidityEndDate]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_Bonus5]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_BonusSituation]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_WholeName]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_Position]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_Phone]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_AccountName]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_No]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_IsTax]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_BonusMoney]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_IsConfirm]"
                          // + "           ,[OfficeAutomation_Document_EBAdjuct_SubmitDate]"
                          +"          todi.*"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_EBAdjuct_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_EBAdjuct_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
