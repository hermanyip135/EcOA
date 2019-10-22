using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_GeneralApply_Inherit : DA_OfficeAutomation_Document_GeneralApply_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_GeneralApply_ID]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ID]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_MainID]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Apply]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ApplyID]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Department]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ReceiveDepartment]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_CCDepartment]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Subject]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Fax]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Describe]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_GeneralApply_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_GeneralApply_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_GeneralApply_ID]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ID]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_MainID]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Apply]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ApplyID]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Department]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ReceiveDepartment]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_CCDepartment]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Subject]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Fax]"
                           + "           ,[OfficeAutomation_Document_GeneralApply_Describe]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_GeneralApply_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_GeneralApply_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(T_OfficeAutomation_Document_GeneralApply obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_GeneralApply_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_GeneralApply();
            Baseobj.OfficeAutomation_Document_GeneralApply_ID = obj.OfficeAutomation_Document_GeneralApply_ID;
            Baseobj.OfficeAutomation_Document_GeneralApply_MainID = obj.OfficeAutomation_Document_GeneralApply_MainID;
            Baseobj.OfficeAutomation_Document_GeneralApply_Apply = obj.OfficeAutomation_Document_GeneralApply_Apply;
            Baseobj.OfficeAutomation_Document_GeneralApply_ApplyDate = obj.OfficeAutomation_Document_GeneralApply_ApplyDate;
            Baseobj.OfficeAutomation_Document_GeneralApply_ApplyID = obj.OfficeAutomation_Document_GeneralApply_ApplyID;
            Baseobj.OfficeAutomation_Document_GeneralApply_Department = obj.OfficeAutomation_Document_GeneralApply_Department;

            Baseobj.OfficeAutomation_Document_GeneralApply_Subject = obj.OfficeAutomation_Document_GeneralApply_Subject;
            Baseobj.OfficeAutomation_Document_GeneralApply_ReplyPhone = obj.OfficeAutomation_Document_GeneralApply_ReplyPhone;
            Baseobj.OfficeAutomation_Document_GeneralApply_Fax = obj.OfficeAutomation_Document_GeneralApply_Fax;
            Baseobj.OfficeAutomation_Document_GeneralApply_ReceiveDepartment = obj.OfficeAutomation_Document_GeneralApply_ReceiveDepartment;
            Baseobj.OfficeAutomation_Document_GeneralApply_CCDepartment = obj.OfficeAutomation_Document_GeneralApply_CCDepartment;
            Baseobj.OfficeAutomation_Document_GeneralApply_Describe = obj.OfficeAutomation_Document_GeneralApply_Describe;

            Baseobj.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID = obj.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID;
            Baseobj.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName = obj.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName;

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_GeneralApply_MainID]='" + obj.OfficeAutomation_Document_GeneralApply_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_GeneralApply resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Add(Baseobj);
            }
            return resultobj != null;
        }

        #endregion
    }
}
