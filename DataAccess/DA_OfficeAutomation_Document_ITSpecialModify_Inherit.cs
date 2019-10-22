using DataAccess.Operate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ITSpecialModify_Inherit : DA_OfficeAutomation_Document_ITSpecialModify_Operate
    {
      

        /// <summary>
        /// 通过MainID查询软件系统特殊修改申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_ITSpecialModify_ID]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_MainID]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_DepartmentID]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_Department]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_Apply]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_ApplyDepHeader]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_HopeDate]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_SystemName]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_ReqContent]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_Follower]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_PlanTime]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_TransferRemark]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + "          ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITSpecialModify] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ITSpecialModify_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ITSpecialModify_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询软件系统特殊修改申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT [OfficeAutomation_Document_ITSpecialModify_ID]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_MainID]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_DepartmentID]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_Department]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_Apply]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_ApplyDepHeader]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_HopeDate]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_SystemName]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_ReqContent]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_Follower]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_PlanTime]"
                           + "           ,[OfficeAutomation_Document_ITSpecialModify_TransferRemark]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITSpecialModify] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ITSpecialModify_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ITSpecialModify_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应软件系统特殊修改申请表转发说明
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transferremark"></param>
        /// <returns></returns>
        public bool UpdateTransferRemarkByID(string id, string transferremark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITSpecialModify]"
                                + "   SET [OfficeAutomation_Document_ITSpecialModify_TransferRemark] = '" + transferremark + "'"
                                + " WHERE [OfficeAutomation_Document_ITSpecialModify_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应软件系统特殊修改申请表IT预计完成时间
        /// </summary>
        /// <param name="id"></param>
        /// <param name="plantime"></param>
        /// <returns></returns>
        public bool UpdateITPlanTimeByID(string id, string plantime)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITSpecialModify]"
                                + "   SET [OfficeAutomation_Document_ITSpecialModify_PlanTime] = '" + plantime + "'"
                                + " WHERE [OfficeAutomation_Document_ITSpecialModify_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应软件系统特殊修改申请表跟进人
        /// </summary>
        /// <param name="id"></param>
        /// <param name="follower"></param>
        /// <returns></returns>
        public bool UpdateFollowerByID(string id, string follower)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITSpecialModify]"
                                + "   SET [OfficeAutomation_Document_ITSpecialModify_Follower] = '" + follower + "'"
                                + " WHERE [OfficeAutomation_Document_ITSpecialModify_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

       
    }
}
