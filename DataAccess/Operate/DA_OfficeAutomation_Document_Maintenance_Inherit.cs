using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Maintenance_Inherit : DA_OfficeAutomation_Document_Maintenance_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Maintenance_ID]"
                           + "           ,[OfficeAutomation_Document_Maintenance_MainID]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Apply]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Department]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ReceiveDepartment]"
                           + "           ,[OfficeAutomation_Document_Maintenance_CCDepartment]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Subject]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Fax]"
                           + "           ,[OfficeAutomation_Document_Maintenance_StartDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Cycle]"
                           + "           ,[OfficeAutomation_Document_Maintenance_DepreciationB]"
                           + "           ,[OfficeAutomation_Document_Maintenance_DContent]"
                           + "           ,[OfficeAutomation_Document_Maintenance_DueToDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_RenovationDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_RContent]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Rprice]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ResultsBeginDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ResultsEndDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ProfitBeginDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ProfitEndDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_LeaseDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ResultsCoast]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ProfitCoast]"
                           + "           ,[OfficeAutomation_Document_Maintenance_IsLease]"
                           + "           ,[OfficeAutomation_Document_Maintenance_StartDateMonth]"
                           + "           ,[OfficeAutomation_Document_Maintenance_CycleMonth]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Describe]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Maintenance] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Maintenance_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Maintenance_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Maintenance_ID]"
                           + "           ,[OfficeAutomation_Document_Maintenance_MainID]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Apply]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Department]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ReceiveDepartment]"
                           + "           ,[OfficeAutomation_Document_Maintenance_CCDepartment]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Subject]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Fax]"
                           + "           ,[OfficeAutomation_Document_Maintenance_StartDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Cycle]"
                           + "           ,[OfficeAutomation_Document_Maintenance_DepreciationB]"
                           + "           ,[OfficeAutomation_Document_Maintenance_DContent]"
                           + "           ,[OfficeAutomation_Document_Maintenance_DueToDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_RenovationDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_RContent]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Rprice]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ResultsBeginDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ResultsEndDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ProfitBeginDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ProfitEndDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_LeaseDate]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ResultsCoast]"
                           + "           ,[OfficeAutomation_Document_Maintenance_ProfitCoast]"
                           + "           ,[OfficeAutomation_Document_Maintenance_IsLease]"
                           + "           ,[OfficeAutomation_Document_Maintenance_StartDateMonth]"
                           + "           ,[OfficeAutomation_Document_Maintenance_CycleMonth]"
                           + "           ,[OfficeAutomation_Document_Maintenance_Describe]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Maintenance] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Maintenance_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Maintenance_ID='" + ID + "'";

            return RunSQL(sql);
        }

        //插入或者修改关键内容
        public bool HandleBase(T_OfficeAutomation_Document_Maintenance obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_Maintenance_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_Maintenance();
            Baseobj = obj;

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_Maintenance_MainID]='" + obj.OfficeAutomation_Document_Maintenance_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_Maintenance resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Insert(Baseobj);
            }
            return resultobj != null;
        }
    }
}
