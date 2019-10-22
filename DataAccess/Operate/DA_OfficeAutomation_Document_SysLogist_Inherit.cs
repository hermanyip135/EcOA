using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SysLogist_Inherit : DA_OfficeAutomation_Document_SysLogist_Operate
    {
        ///// <summary>
        ///// 通过搜索，查询出软件系统开发需求申请表
        ///// </summary>
        ///// <param name="applicationDepartment"></param>
        ///// <param name="applicant"></param>
        ///// <param name="begin"></param>
        ///// <param name="end"></param>
        ///// <param name="applyType"></param>
        ///// <param name="state"></param>
        ///// <returns></returns>
        //public DataSet Search(string applicationDepartment, string applicant, string begin, string end, string applyType, string state)
        //{
        //    string sql = "SELECT [OfficeAutomation_Document_SysLogist_ID]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_MainID]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_DepartmentID]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_Department]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_ApplyDate]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_Apply]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_ApplyReason]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_Deal]"
        //                   + "          ,toam.OfficeAutomation_SerialNumber"
        //                   + "          ,toam.OfficeAutomation_Main_FlowStateID"
        //                   + "          ,CASE toam.OfficeAutomation_Main_FlowStateID"
        //                   + "             WHEN 1 THEN '待'+(SELECT f.OfficeAutomation_Flow_Employee"
        //                   + "                      FROM   t_OfficeAutomation_Flow f"
        //                   + "                      WHERE  f.OfficeAutomation_Flow_MainID = [OfficeAutomation_Document_SysLogist_MainID]"
        //                   + "                             AND f.OfficeAutomation_Flow_Idx = 1)+'审核'"
        //                   + "             WHEN 2 THEN '待'+(SELECT TOP 1 f.OfficeAutomation_Flow_Employee"
        //                   + "                      FROM   t_OfficeAutomation_Flow f"
        //                   + "                      WHERE  f.OfficeAutomation_Flow_MainID = [OfficeAutomation_Document_SysLogist_MainID]"
        //                   + "                             AND f.OfficeAutomation_Flow_Audit = 0"
        //                   + "                      ORDER  BY f.OfficeAutomation_Flow_Idx ASC)+'审核'"
        //                   + "             WHEN 3 THEN '已完成'"
        //                   + "           END AS [waitfor]"
        //                   + "          ,tdoad.OfficeAutomation_Document_Name"
        //                   + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist] todi"
        //                   + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysLogist_MainID"
        //                   + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysLogist_MainID"
        //                   + " LEFT JOIN t_Dic_OfficeAutomation_FlowState tdof ON toam.OfficeAutomation_Main_FlowStateID= tdof.OfficeAutomation_FlowState_ID"
        //                   + " WHERE 1=1";

        //    if (applicationDepartment != "")
        //        sql += " and OfficeAutomation_Document_SysLogist_Department = '" + applicationDepartment + "'";

        //    if (applicant != "")
        //        sql += " and OfficeAutomation_Document_SysLogist_Apply = '" + applicant + "'";

        //    if (begin != "")
        //        sql += " and OfficeAutomation_Document_SysLogist_ApplyDate >='" + begin + "'";

        //    if (end != "")
        //        sql += " and OfficeAutomation_Document_SysLogist_ApplyDate<='" + end + "'";

        //    if (state != "")
        //        sql += " and toam.OfficeAutomation_Main_FlowStateID ='" + state + "'";

        //    sql += " order by OfficeAutomation_Document_SysLogist_ApplyDate desc";

        //    return RunSQL(sql);
        //}

        ///// <summary>
        ///// 通过搜索，查询出软件系统开发需求申请表列表(只能查询录入人和审批人是自己的申请)
        ///// </summary>
        ///// <param name="applicationDepartment"></param>
        ///// <param name="applicant"></param>
        ///// <param name="begin"></param>
        ///// <param name="end"></param>
        ///// <param name="applyType"></param>
        ///// <param name="state"></param>
        ///// <param name="employee"></param>
        ///// <param name="code"></param>
        ///// <returns></returns>
        //public DataSet Search(string applicationDepartment, string applicant, string begin, string end, string applyType, string state,string employee,string code)
        //{
        //    string sql = "SELECT [OfficeAutomation_Document_SysLogist_ID]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_MainID]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_DepartmentID]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_Department]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_ApplyDate]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_Apply]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_ApplyReason]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_Deal]"
        //                   + "          ,toam.OfficeAutomation_SerialNumber"
        //                   + "          ,toam.OfficeAutomation_Main_FlowStateID"
        //                   + "          ,CASE toam.OfficeAutomation_Main_FlowStateID"
        //                   + "             WHEN 1 THEN '待'+(SELECT f.OfficeAutomation_Flow_Employee"
        //                   + "                      FROM   t_OfficeAutomation_Flow f"
        //                   + "                      WHERE  f.OfficeAutomation_Flow_MainID = [OfficeAutomation_Document_SysLogist_MainID]"
        //                   + "                             AND f.OfficeAutomation_Flow_Idx = 1)+'审核'"
        //                   + "             WHEN 2 THEN '待'+(SELECT TOP 1 f.OfficeAutomation_Flow_Employee"
        //                   + "                      FROM   t_OfficeAutomation_Flow f"
        //                   + "                      WHERE  f.OfficeAutomation_Flow_MainID = [OfficeAutomation_Document_SysLogist_MainID]"
        //                   + "                             AND f.OfficeAutomation_Flow_Audit = 0"
        //                   + "                      ORDER  BY f.OfficeAutomation_Flow_Idx ASC)+'审核'"
        //                   + "             WHEN 3 THEN '已完成'"
        //                   + "           END AS [waitfor]"
        //                   + "          ,tdoad.OfficeAutomation_Document_Name"
        //                   + "          ,toaf.auditorsum"
        //                   + "          ,toaf.auditoridsum"
        //                   + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist] todi"
        //                   + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysLogist_MainID"
        //                   + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysLogist_MainID"
        //                   + " LEFT JOIN t_Dic_OfficeAutomation_FlowState tdof ON toam.OfficeAutomation_Main_FlowStateID= tdof.OfficeAutomation_FlowState_ID"
        //                   + " LEFT JOIN (SELECT toaf.OfficeAutomation_Flow_MainID,dbo.Fun_Sum_Employee(toaf.OfficeAutomation_Flow_MainID) AS auditorsum,dbo.Fun_Sum_EmployeeID(toaf.OfficeAutomation_Flow_MainID) AS auditoridsum FROM t_OfficeAutomation_Flow toaf GROUP BY toaf.OfficeAutomation_Flow_MainID) AS toaf ON toaf.OfficeAutomation_Flow_MainID=toam.OfficeAutomation_Main_ID"
        //                   + " WHERE ((toaf.auditorsum like '%" + employee + "%' and toaf.auditoridsum like '%" + code + "%') or OfficeAutomation_Document_SysLogist_Apply='" + employee + "')";

        //    if (applicationDepartment != "")
        //        sql += " and OfficeAutomation_Document_SysLogist_Department = '" + applicationDepartment + "'";

        //    if (applicant != "")
        //        sql += " and OfficeAutomation_Document_SysLogist_Apply = '" + applicant + "'";

        //    if (begin != "")
        //        sql += " and OfficeAutomation_Document_SysLogist_ApplyDate >='" + begin + "'";

        //    if (end != "")
        //        sql += " and OfficeAutomation_Document_SysLogist_ApplyDate<='" + end + "'";

        //    if (state != "")
        //        sql += " and toam.OfficeAutomation_Main_FlowStateID ='" + state + "'";

        //    sql += " order by OfficeAutomation_Document_SysLogist_ApplyDate desc";

        //    return RunSQL(sql);
        //}

        /// <summary>
        /// 通过MainID查询软件系统开发需求申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_SysLogist_ID]"
                           + "           ,[OfficeAutomation_Document_SysLogist_MainID]"
                           + "           ,[OfficeAutomation_Document_SysLogist_DepartmentID]"
                           + "           ,[OfficeAutomation_Document_SysLogist_Department]"
                           + "           ,[OfficeAutomation_Document_SysLogist_Apply]"
                           + "           ,[OfficeAutomation_Document_SysLogist_ApplyDepHeader]"
                           + "           ,[OfficeAutomation_Document_SysLogist_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SysLogist_HopeDate]"
                           + "           ,[OfficeAutomation_Document_SysLogist_SystemName]"
                           + "           ,[OfficeAutomation_Document_SysLogist_ReqContent]"
                           + "           ,[OfficeAutomation_Document_SysLogist_Follower]"
                           + "           ,[OfficeAutomation_Document_SysLogist_PlanTime]"
                           + "           ,[OfficeAutomation_Document_SysLogist_TransferRemark]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + "          ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysLogist_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SysLogist_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询软件系统开发需求申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT [OfficeAutomation_Document_SysLogist_ID]"
                           + "           ,[OfficeAutomation_Document_SysLogist_MainID]"
                           + "           ,[OfficeAutomation_Document_SysLogist_DepartmentID]"
                           + "           ,[OfficeAutomation_Document_SysLogist_Department]"
                           + "           ,[OfficeAutomation_Document_SysLogist_Apply]"
                           + "           ,[OfficeAutomation_Document_SysLogist_ApplyDepHeader]"
                           + "           ,[OfficeAutomation_Document_SysLogist_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SysLogist_HopeDate]"
                           + "           ,[OfficeAutomation_Document_SysLogist_SystemName]"
                           + "           ,[OfficeAutomation_Document_SysLogist_ReqContent]"
                           + "           ,[OfficeAutomation_Document_SysLogist_Follower]"
                           + "           ,[OfficeAutomation_Document_SysLogist_PlanTime]"
                           + "           ,[OfficeAutomation_Document_SysLogist_TransferRemark]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysLogist_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SysLogist_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应软件系统开发需求申请表转发说明
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transferremark"></param>
        /// <returns></returns>
        public bool UpdateTransferRemarkByID(string id, string transferremark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist]"
                                + "   SET [OfficeAutomation_Document_SysLogist_TransferRemark] = '" + transferremark + "'"
                                + " WHERE [OfficeAutomation_Document_SysLogist_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应软件系统开发需求申请表IT预计完成时间
        /// </summary>
        /// <param name="id"></param>
        /// <param name="plantime"></param>
        /// <returns></returns>
        public bool UpdateITPlanTimeByID(string id, string plantime)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist]"
                                + "   SET [OfficeAutomation_Document_SysLogist_PlanTime] = '" + plantime + "'"
                                + " WHERE [OfficeAutomation_Document_SysLogist_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应软件系统开发需求申请表跟进人
        /// </summary>
        /// <param name="id"></param>
        /// <param name="follower"></param>
        /// <returns></returns>
        public bool UpdateFollowerByID(string id, string follower)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist]"
                                + "   SET [OfficeAutomation_Document_SysLogist_Follower] = '" + follower + "'"
                                + " WHERE [OfficeAutomation_Document_SysLogist_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

        ///// <summary>
        ///// 获取待该员工审核的软件系统开发需求申请表
        ///// </summary>
        ///// <param name="code"></param>
        ///// <returns></returns>
        //public DataSet WaitForMe(string employeeID, string employeeName)
        //{
        //    string sql = "SELECT [OfficeAutomation_Document_SysLogist_ID]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_MainID]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_DepartmentID]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_Department]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_ApplyDate]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_Apply]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_ApplyReason]"
        //                   + "          ,[OfficeAutomation_Document_SysLogist_Deal]"
        //                   + "          ,toam.OfficeAutomation_SerialNumber"
        //                   + "          ,toam.OfficeAutomation_Main_FlowStateID"
        //                   + "          ,CASE toam.OfficeAutomation_Main_FlowStateID"
        //                   + "             WHEN 1 THEN '待'+(SELECT f.OfficeAutomation_Flow_Employee"
        //                   + "                      FROM   t_OfficeAutomation_Flow f"
        //                   + "                      WHERE  f.OfficeAutomation_Flow_MainID = [OfficeAutomation_Document_SysLogist_MainID]"
        //                   + "                             AND f.OfficeAutomation_Flow_Idx = 1)+'审核'"
        //                   + "             WHEN 2 THEN '待'+(SELECT TOP 1 f.OfficeAutomation_Flow_Employee"
        //                   + "                      FROM   t_OfficeAutomation_Flow f"
        //                   + "                      WHERE  f.OfficeAutomation_Flow_MainID = [OfficeAutomation_Document_SysLogist_MainID]"
        //                   + "                             AND f.OfficeAutomation_Flow_Audit = 0"
        //                   + "                      ORDER  BY f.OfficeAutomation_Flow_Idx ASC)+'审核'"
        //                   + "             WHEN 3 THEN '已完成'"
        //                   + "           END AS [waitfor]"
        //                   + "          ,tdoad.OfficeAutomation_Document_Name"
        //                   + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist] todi"
        //                   + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysLogist_MainID"
        //                   + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysLogist_MainID"
        //                   + " LEFT JOIN t_Dic_OfficeAutomation_FlowState tdof ON toam.OfficeAutomation_Main_FlowStateID= tdof.OfficeAutomation_FlowState_ID"
        //                   + " WHERE todi.OfficeAutomation_Document_SysLogist_MainID IN (SELECT OfficeAutomation_Flow_MainID"
        //                   + "                                          FROM   [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
        //                   + "                                          WHERE  OfficeAutomation_Flow_EmployeeID like '%" + employeeID + "%'"
        //                   + "                                                 AND OfficeAutomation_Flow_Employee like '%" + employeeName + "%'"
        //                   + "                                                 AND OfficeAutomation_Flow_Audit = 0"
        //                   + "                                                 AND OfficeAutomation_Flow_Idx = 1"
        //                   + "                                          UNION"
        //                   + "                                          SELECT OfficeAutomation_Flow_MainID"
        //                   + "                                          FROM   (SELECT toaf.*"
        //                   + "                                                       FROM   t_OfficeAutomation_Flow toaf"
        //                   + "                                                                   RIGHT JOIN (SELECT OfficeAutomation_Flow_MainID,"
        //                   + "                                                                                                  OfficeAutomation_Flow_Idx"
        //                   + "                                                                                       FROM   [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
        //                   + "                                                                                       WHERE  OfficeAutomation_Flow_EmployeeID LIKE '%" + employeeID + "%'"
        //                   + "                                                                                                    AND OfficeAutomation_Flow_Employee LIKE '%" + employeeName + "%'"
        //                   + "                                                                                                    AND OfficeAutomation_Flow_Audit = 0"
        //                   + "                                                                                                    AND OfficeAutomation_Flow_Idx <> 1) old"
        //                   + "                                                                                 ON old.OfficeAutomation_Flow_MainID = toaf.OfficeAutomation_Flow_MainID"
        //                   + "                                                       WHERE  toaf.OfficeAutomation_Flow_Idx < old.OfficeAutomation_Flow_Idx) t1"
        //                   + "                                          WHERE  t1.OfficeAutomation_Flow_Idx = (SELECT Max(t2.OfficeAutomation_Flow_Idx)"
        //                   + "                                                                                                      FROM   (SELECT toaf.*"
        //                   + "                                                                                                                   FROM   t_OfficeAutomation_Flow toaf"
        //                   + "                                                                                                                               RIGHT JOIN (SELECT OfficeAutomation_Flow_MainID,"
        //                   + "                                                                                                                                                              OfficeAutomation_Flow_Idx"
        //                   + "                                                                                                                                                   FROM   [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
        //                   + "                                                                                                                                                   WHERE  OfficeAutomation_Flow_EmployeeID LIKE '%" + employeeID + "%'"
        //                   + "                                                                                                                                                               AND OfficeAutomation_Flow_Employee LIKE '%" + employeeName + "%'"
        //                   + "                                                                                                                                                               AND OfficeAutomation_Flow_Audit = 0"
        //                   + "                                                                                                                                                               AND OfficeAutomation_Flow_Idx <> 1) old"
        //                   + "                                                                                                                                           ON old.OfficeAutomation_Flow_MainID = toaf.OfficeAutomation_Flow_MainID"
        //                   + "                                                                                                                  WHERE  toaf.OfficeAutomation_Flow_Idx < old.OfficeAutomation_Flow_Idx)t2"
        //                   + "                                                                                                     WHERE  t2.OfficeAutomation_Flow_MainID = t1.OfficeAutomation_Flow_MainID)"
        //                   + "                                                       AND t1.OfficeAutomation_Flow_Audit = 1)";

        //    sql += " order by OfficeAutomation_Document_SysLogist_ApplyDate desc";

        //    return RunSQL(sql);
        //}
    }
}
