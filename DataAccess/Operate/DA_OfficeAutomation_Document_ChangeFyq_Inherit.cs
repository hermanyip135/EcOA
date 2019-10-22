using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ChangeFyq_Inherit : DA_OfficeAutomation_Document_ChangeFyq_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ChangeFyq_ID]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_MainID]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Apply]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Department]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Phone]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Area]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Location]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Master]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Buyers]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_IsContract]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_IsCommission]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_CDate]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_SpecialApply]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_PayWay]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_WhoKeep]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_SurePrice]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_CompareP]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_HandleDate]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Others]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Detailed]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_CNS]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Relationship]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_PriceChange]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_CompareOfChange]"
                           + "           ,toam.OfficeAutomation_Main_Creater"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeFyq] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ChangeFyq_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ChangeFyq_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ChangeFyq_ID]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_MainID]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Apply]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Department]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Phone]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Area]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Location]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Master]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Buyers]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_IsContract]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_IsCommission]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_CDate]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_SpecialApply]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_PayWay]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_WhoKeep]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_SurePrice]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_CompareP]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_HandleDate]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Others]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Detailed]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_CNS]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_Relationship]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_PriceChange]"
                           + "           ,[OfficeAutomation_Document_ChangeFyq_CompareOfChange]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeFyq] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ChangeFyq_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ChangeFyq_ID='" + ID + "'";

            return RunSQL(sql);
        }

        public DataSet GetInfoByApplyID(string applyID) 
        {
            string sql = "SELECT  [Report_Main_ID] ,[Report_Main_ReportNO] ,[Report_Main_Address],d.Report_Detail_Client1 ,d.Report_Detail_Owner1 FROM [gzs-fineccdb01].[DB_EcCommission].[dbo].[t_Report_Main] m LEFT JOIN [gzs-fineccdb01].[DB_EcCommission].[dbo].t_Report_Detail d ON d.Report_Detail_ReportMainID = m.Report_Main_ID WHERE m.Report_Main_ReportNO='" + applyID + "'";
            return RunSQL(sql);
        }
    }
}
