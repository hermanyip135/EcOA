using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PortAssessment_Inherit : DA_OfficeAutomation_Document_PortAssessment_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PortAssessment_ID]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_MainID]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_Apply]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_ApplyID]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_Department]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PortAssessment] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PortAssessment_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_PortAssessment_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PortAssessment_ID]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_MainID]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_Apply]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_ApplyID]"
                           + "           ,[OfficeAutomation_Document_PortAssessment_Department]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PortAssessment] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PortAssessment_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_PortAssessment_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
