using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UIReq_Inherit : DA_OfficeAutomation_Document_UIReq_Operate
    {
        /// <summary>
        /// 通过MainID查询软件系统开发需求申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = @"    SELECT todi.*
                                    ,toam.OfficeAutomation_SerialNumber
                                    ,tdoad.OfficeAutomation_Document_Name
                                   ,toam.OfficeAutomation_Main_FlowStateID
                           FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UIReq] todi
                           LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_UIReq_MainID
                            LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID
                           WHERE OfficeAutomation_Document_UIReq_MainID='" + mainID + "'";

            return RunSQL(sql);
        }
        /// <summary>
        /// 通过ID查询软件系统开发需求申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = @"    SELECT todi.*
                                    ,toam.OfficeAutomation_SerialNumber
                                     ,tdoad.OfficeAutomation_Document_Name
                            FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UIReq] todi
                            LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_UIReq_MainID
                            LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID
                            WHERE OfficeAutomation_Document_UIReq_ID='" + ID + "'";

            return RunSQL(sql);
        }
        /// <summary>
        /// 根据id给对应软件系统开发需求申请表IT预计完成时间
        /// </summary>
        /// <param name="id"></param>
        /// <param name="plantime"></param>
        /// <returns></returns>
        public bool UpdateITPlanTimeByID(string id, string plantime)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UIReq]"
                                + "   SET [OfficeAutomation_Document_UIReq_PlanTime] = '" + plantime + "'"
                                + " WHERE [OfficeAutomation_Document_UIReq_ID]='" + id + "'";
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
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UIReq]"
                                + "   SET [OfficeAutomation_Document_UIReq_Follower] = '" + follower + "'"
                                + " WHERE [OfficeAutomation_Document_UIReq_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }
    }
}
