using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CostOfActivity_Inherit : DA_OfficeAutomation_Document_CostOfActivity_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_CostOfActivity_ID]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_MainID]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Apply]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_ApplyID]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Department]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Phone]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Subject]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_InDepartment]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Area]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Year]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man1]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear1]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man2]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear2]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man3]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear3]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man4]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear4]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man5]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear5]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man6]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear6]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Summary]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Cycle]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CostOfActivity] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_CostOfActivity_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_CostOfActivity_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_CostOfActivity_ID]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_MainID]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Apply]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_ApplyID]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Department]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Phone]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Subject]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_InDepartment]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Area]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Year]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man1]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear1]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man2]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear2]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man3]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear3]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Man4]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Fear4]"
                           + "           ,[OfficeAutomation_Document_CostOfActivity_Summary]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CostOfActivity] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_CostOfActivity_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_CostOfActivity_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
