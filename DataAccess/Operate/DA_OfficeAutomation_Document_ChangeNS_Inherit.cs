using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ChangeNS_Inherit : DA_OfficeAutomation_Document_ChangeNS_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ChangeNS_ID]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_MainID]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Apply]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Department]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Phone]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Area]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Location]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Master]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Buyers]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_IsContract]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_IsCommission]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_CDate]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_SpecialApply]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_PayWay]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_WhoKeep]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_SurePrice]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_CompareP]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_HandleDate]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Others]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Detailed]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_CNS]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Relationship]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_PriceChange]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_CompareOfChange]"
                           + "           ,toam.OfficeAutomation_Main_Creater"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeNS] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ChangeNS_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ChangeNS_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ChangeNS_ID]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_MainID]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Apply]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Department]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Phone]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Area]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Location]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Master]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Buyers]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_IsContract]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_IsCommission]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_CDate]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_SpecialApply]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_PayWay]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_WhoKeep]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_SurePrice]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_CompareP]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_HandleDate]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Others]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Detailed]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_CNS]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_Relationship]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_PriceChange]"
                           + "           ,[OfficeAutomation_Document_ChangeNS_CompareOfChange]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeNS] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ChangeNS_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ChangeNS_ID='" + ID + "'";

            return RunSQL(sql);
        }

        public DataSet GetInfoByApplyID(string applyID) 
        {
            string sql = "SELECT  [Report_Main_ID] ,[Report_Main_ReportNO] ,[Report_Main_Address],d.Report_Detail_Client1 ,d.Report_Detail_Owner1 FROM [gzs-fineccdb01].[DB_EcCommission].[dbo].[t_Report_Main] m LEFT JOIN [gzs-fineccdb01].[DB_EcCommission].[dbo].t_Report_Detail d ON d.Report_Detail_ReportMainID = m.Report_Main_ID WHERE m.Report_Main_ReportNO='" + applyID + "'";
            return RunSQL(sql);
        }
    }
}
