using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PersInterests_Inherit : DA_OfficeAutomation_Document_PersInterests_Operate
    {
        /// <summary>
        /// 通过MainID查询员工个人利益申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PersInterests_ID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_MainID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_DepartmentTypeID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Department]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Apply]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyDate]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyForID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyFor]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyForDate]"
                             + "         ,[OfficeAutomation_Document_PersInterests_InterestsTypeID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_FollowerID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Follower]"
                             + "         ,[OfficeAutomation_Document_PersInterests_FollowerDepartment]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Address]"
                             + "         ,[OfficeAutomation_Document_PersInterests_DealTypeID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Relative]"
                             + "         ,[OfficeAutomation_Document_PersInterests_RelativeDepartment]"
                             + "         ,[OfficeAutomation_Document_PersInterests_RelativePosition]"
                             + "         ,[OfficeAutomation_Document_PersInterests_RelativeRelation]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyDetail]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Remark]"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + "         ,tdodt.OfficeAutomation_DepartmentType_Name"
                             + "         ,tdopit.OfficeAutomation_PersInterestsType_Name"
                             + "         ,tdodt2.OfficeAutomation_DealType_Name"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PersInterests] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PersInterests_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DepartmentType tdodt ON tdodt.OfficeAutomation_DepartmentType_ID = todi.OfficeAutomation_Document_PersInterests_DepartmentTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_PersInterestsType tdopit ON tdopit.OfficeAutomation_PersInterestsType_ID = todi.OfficeAutomation_Document_PersInterests_InterestsTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DealType tdodt2 ON tdodt2.OfficeAutomation_DealType_ID = todi.OfficeAutomation_Document_PersInterests_DealTypeID"
                             + " WHERE OfficeAutomation_Document_PersInterests_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询员工个人利益申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PersInterests_ID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_MainID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_DepartmentTypeID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Department]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Apply]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyDate]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyForID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyFor]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyForDate]"
                             + "         ,[OfficeAutomation_Document_PersInterests_InterestsTypeID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_FollowerID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Follower]"
                             + "         ,[OfficeAutomation_Document_PersInterests_FollowerDepartment]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Address]"
                             + "         ,[OfficeAutomation_Document_PersInterests_DealTypeID]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Relative]"
                             + "         ,[OfficeAutomation_Document_PersInterests_RelativeDepartment]"
                             + "         ,[OfficeAutomation_Document_PersInterests_RelativePosition]"
                             + "         ,[OfficeAutomation_Document_PersInterests_RelativeRelation]"
                             + "         ,[OfficeAutomation_Document_PersInterests_ApplyDetail]"
                             + "         ,[OfficeAutomation_Document_PersInterests_Remark]"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + "         ,tdodt.OfficeAutomation_DepartmentType_Name"
                             + "         ,tdopit.OfficeAutomation_PersInterestsType_Name"
                             + "         ,tdodt2.OfficeAutomation_DealType_Name"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PersInterests] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PersInterests_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DepartmentType tdodt ON tdodt.OfficeAutomation_DepartmentType_ID = todi.OfficeAutomation_Document_PersInterests_DepartmentTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_PersInterestsType tdopit ON tdopit.OfficeAutomation_PersInterestsType_ID = todi.OfficeAutomation_Document_PersInterests_InterestsTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DealType tdodt2 ON tdodt2.OfficeAutomation_DealType_ID = todi.OfficeAutomation_Document_PersInterests_DealTypeID"
                             + " WHERE OfficeAutomation_Document_PersInterests_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应个人利益申请表的备注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool UpdateRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PersInterests]"
                                + "   SET [OfficeAutomation_Document_PersInterests_Remark] = '" + remark + "'"
                                + " WHERE [OfficeAutomation_Document_PersInterests_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }


    }
}
