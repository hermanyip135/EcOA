using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using System.Collections;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Agent_Inherit : DA_OfficeAutomation_Agent_Operate
    {
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Agent_ID]"
                         + "           ,[OfficeAutomation_Agent_Auditor]"
                         + "           ,[OfficeAutomation_Agent_AuditorID]"
                         + "           ,[OfficeAutomation_Agent_Agent]"
                         + "           ,[OfficeAutomation_Agent_AgentID]"
                         + "           ,[OfficeAutomation_Agent_Start]"
                         + "           ,[OfficeAutomation_Agent_End]"
                         + "           ,[OfficeAutomation_Agent_IsEnable]"
                         + "           ,[OfficeAutomaiton_Agent_CreateTime]"
                         + "  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Agent]"
                         + " WHERE OfficeAutomation_Agent_ID = " + id;

            return RunSQL(sql);
        }

        public DataSet SelectByAuditorID(string auditorid)
        {
            string sql = "SELECT [OfficeAutomation_Agent_ID]"
                         + "           ,[OfficeAutomation_Agent_Auditor]"
                         + "           ,[OfficeAutomation_Agent_AuditorID]"
                         + "           ,[OfficeAutomation_Agent_Agent]"
                         + "           ,[OfficeAutomation_Agent_AgentID]"
                         + "           ,[OfficeAutomation_Agent_Start]"
                         + "           ,[OfficeAutomation_Agent_End]"
                         + "           ,[OfficeAutomation_Agent_IsEnable]"
                         + "           ,[OfficeAutomaiton_Agent_CreateTime]"
                         + "  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Agent]"
                         + " WHERE OfficeAutomation_Agent_AuditorID = " + auditorid
                         + " ORDER BY OfficeAutomaiton_Agent_CreateTime DESC";

            return RunSQL(sql);
        }

        public DataSet SelectByAgentAndAgentID(string agent, string agentid)
        {
            string sql = "SELECT [OfficeAutomation_Agent_ID]"
                         + "           ,[OfficeAutomation_Agent_Auditor]"
                         + "           ,[OfficeAutomation_Agent_AuditorID]"
                         + "           ,[OfficeAutomation_Agent_Agent]"
                         + "           ,[OfficeAutomation_Agent_AgentID]"
                         + "           ,[OfficeAutomation_Agent_Start]"
                         + "           ,[OfficeAutomation_Agent_End]"
                         + "           ,[OfficeAutomation_Agent_IsEnable]"
                         + "           ,[OfficeAutomaiton_Agent_CreateTime]"
                         + "  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Agent]"
                         + " WHERE OfficeAutomation_Agent_AgentID LIKE '%" + agentid + "%'"
                         + "     AND OfficeAutomation_Agent_Agent LIKE '%" + agent + "%'"
                         + " ORDER BY OfficeAutomaiton_Agent_CreateTime DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据审核人工号，和姓名获取代理人姓名（格式：张榕,张加彬）。主要用于发送通知。如果无代理人则返回审核人姓名。
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public string SelectAgentByAuditor(string auditorid, string auditor)
        {
            string sql = "SELECT distinct [OfficeAutomation_Agent_agent]"
                          + "  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Agent]"
                          + " WHERE OfficeAutomation_Agent_AuditorID = '" + auditorid + "'"
                          + "             AND GETDATE() BETWEEN [OfficeAutomation_Agent_Start] AND  [OfficeAutomation_Agent_End]"
                          + "             AND OfficeAutomation_Agent_IsEnable = 1";

            DataSet ds= RunSQL(sql);

            string agents = "";

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    agents += dr[0].ToString() + ",";
                }

                agents = agents.Substring(0, agents.Length - 1);
            }
            else
                agents = auditor;

            return agents;
        }

        /// <summary>
        /// 根据审核人姓名获取代理人姓名（格式：张榕,张加彬）。主要用于发送通知。如果无代理人则返回审核人姓名。
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public string SelectAgentByAuditor(string auditor,bool isa) //M_20150604：是否需要代理人
        {
            string sql = "SELECT distinct [OfficeAutomation_Agent_agent]"
                          + "  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Agent]"
                          + " WHERE OfficeAutomation_Agent_Auditor = '" + auditor + "'"
                          + "             AND GETDATE() BETWEEN [OfficeAutomation_Agent_Start] AND  [OfficeAutomation_Agent_End]"
                          + "             AND OfficeAutomation_Agent_IsEnable = 1";

            DataSet ds = RunSQL(sql);

            string agents = "";

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0 && isa) //Alt_20150605：是否需要代理人
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    agents += dr[0].ToString() + ",";
                }

                agents = agents.Substring(0, agents.Length - 1);
            }
            else
                agents = auditor;

            return agents;
        }

        /// <summary>
        /// 代理人获得其正在代理的人的姓名，工号。
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public DataSet GetMyAgencyForAgent(string agent, string agentid)
        {
            string sql = "SELECT [OfficeAutomation_Agent_Auditor],[OfficeAutomation_Agent_AuditorID],[OfficeAutomation_Agent_AgentID],[OfficeAutomation_Agent_Agent]"
                         + " FROM [t_OfficeAutomation_Agent]"
                         + " WHERE OfficeAutomation_Agent_AgentID LIKE '%" + agentid + "%'"
                         + "     AND OfficeAutomation_Agent_Agent LIKE '%" + agent + "%'"
                         + "     AND OfficeAutomation_Agent_Start <= convert(varchar(10),getdate(),120)"
                         + "     AND OfficeAutomation_Agent_End >= convert(varchar(10),getdate(),120)"
                         + "     AND OfficeAutomation_Agent_IsEnable = 1"
                         + " GROUP BY OfficeAutomation_Agent_Auditor,[OfficeAutomation_Agent_AgentID],[OfficeAutomation_Agent_Agent],OfficeAutomation_Agent_AuditorID";
            return RunSQL(sql);
        }

        public string GetMyAgencyForSQL(string agent, string agentid)
        {
            string sReturn = "";
            DataSet ds = GetMyAgencyForAgent(agent, agentid);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    sReturn += " OR (OfficeAutomation_Flow_EmployeeID LIKE '%" + dr["OfficeAutomation_Agent_AuditorID"].ToString() 
                        + "%' AND OfficeAutomation_Flow_Employee LIKE '%" + dr["OfficeAutomation_Agent_Auditor"].ToString() + "%')"
                        //+ " AND ISNULL(toam.OfficeAutomation_Main_FlowStateID,0) != 3)"
                        ;
                }
            }

            return sReturn;
        }

        /// <summary>
        /// 代理人获得其正在代理的人的姓名，工号。
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public DataSet GetMyAgencyForAgent_II(string agent, string agentid)
        {
            string sql = "SELECT [OfficeAutomation_Agent_Auditor],[OfficeAutomation_Agent_AuditorID],[OfficeAutomation_Agent_AgentID],[OfficeAutomation_Agent_Agent]"
                         + " FROM [t_OfficeAutomation_Agent] "
                         + " WHERE [OfficeAutomation_Agent_AgentID]='" + agentid + "'"
                         + "     AND [OfficeAutomation_Agent_Agent]='" + agent + "'"
                         + "     AND [OfficeAutomation_Agent_Start]<=convert(varchar(10),getdate(),120)"
                         + "     AND [OfficeAutomation_Agent_End]>=convert(varchar(10),getdate(),120)"
                         + "     AND [OfficeAutomation_Agent_IsEnable]=1"
                         + " GROUP BY [OfficeAutomation_Agent_Auditor],[OfficeAutomation_Agent_AgentID],[OfficeAutomation_Agent_Agent],[OfficeAutomation_Agent_AuditorID]";
            return RunSQL(sql);
        }

        /// <summary>
        /// 是否用于审核签名的权限(涉及代理人)
        /// </summary>
        /// <param name="auditor">待审核人姓名</param>
        /// <param name="auditorid">待审核人工号</param>
        /// <param name="employee">当前登录人姓名(代理人)</param>
        /// <param name="employeeid">当期登录人工号(代理人)</param>
        /// <returns></returns>
        public bool IsHaveSignPower(string auditor, string auditorid, string employee, string employeeid)
        {
            if (auditor.Contains(employee) && auditorid.Contains(employeeid))
                return true;

            DataSet ds = GetMyAgencyForAgent(employee, employeeid);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (auditor.Contains(dr["OfficeAutomation_Agent_Auditor"].ToString()) && auditorid.Contains(dr["OfficeAutomation_Agent_AuditorID"].ToString()))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否用于审核签名的权限(涉及代理人)多人同时审批的情况
        /// </summary>
        /// <param name="employee">待审核人姓名</param>
        /// <param name="employeeid">待审核人工号</param>
        /// <param name="auditor">已审核人姓名</param>
        /// <param name="auditorid">已审核人工号</param>
        /// <param name="user">当前登录人姓名(代理人)</param>
        /// <param name="userid">当前登录人工号(代理人)</param>
        /// <returns></returns>
        public bool IsHaveSignPower(string employee, string employeeid,string auditor, string auditorid, string user, string userid)
        {
            DataSet ds = GetMyAgencyForAgent(user, userid);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (auditor.Contains(dr["OfficeAutomation_Agent_Auditor"].ToString()) && auditorid.Contains(dr["OfficeAutomation_Agent_AuditorID"].ToString()))
                        return false;

                    if (employee.Contains(dr["OfficeAutomation_Agent_Auditor"].ToString()) && employeeid.Contains(dr["OfficeAutomation_Agent_AuditorID"].ToString()))
                        return true;
                }
            }

            if (auditor.Contains(user) && auditorid.Contains(userid))
                return false;

            if (employee.Contains(user) && employeeid.Contains(userid))
                return true;

            return false;
        }

        /// <summary>
        /// 是否用于审核撤销签名的权限(涉及代理人)多人同时审批的情况
        /// </summary>
        /// <param name="employee">待审核人姓名</param>
        /// <param name="employeeid">待审核人工号</param>
        /// <param name="auditor">已审核人姓名</param>
        /// <param name="auditorid">已审核人工号</param>
        /// <param name="user">当前登录人姓名(代理人)</param>
        /// <param name="userid">当前登录人工号(代理人)</param>
        /// <returns></returns>
        public bool IsHaveCancelPower(string employee, string employeeid, string auditor, string auditorid, string user, string userid)
        {
            if (auditor.Contains(user) && auditorid.Contains(userid) && employeeid == userid)
                return true;

            DataSet ds = GetMyAgencyForAgent(user, userid);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //if (auditor.Contains(dr["OfficeAutomation_Agent_Auditor"].ToString()) && auditorid.Contains(dr["OfficeAutomation_Agent_AuditorID"].ToString()))
                    //    return true;

                    if (employee.Contains(dr["OfficeAutomation_Agent_Auditor"].ToString()) && employeeid.Contains(dr["OfficeAutomation_Agent_AuditorID"].ToString()))
                        return true;
                }
            }

            //if (employee.Contains(user) && employeeid.Contains(userid))
            //    return true;

            return false;
        }

        /// <summary>
        /// 是否拥有审核签名的权限(涉及代理人)，如果拥有权限返回审核人姓名及工号：张榕|26242，否则返回null
        /// </summary>
        /// <param name="auditor">审核人姓名</param>
        /// <param name="auditorid">审核人工号</param>
        /// <param name="employee">当前登录人姓名(代理人)</param>
        /// <param name="employeeid">当期登录人工号(代理人)</param>
        /// <returns></returns>
        public string HaveSignPowerEmployee(string auditor, string auditorid, string employee, string employeeid)
        {
            if (auditor.Contains(employee) && auditorid.Contains(employeeid))
                return employee + "|" + employeeid;

            DataSet ds = GetMyAgencyForAgent(employee, employeeid);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (auditor.Contains(dr["OfficeAutomation_Agent_Auditor"].ToString()) && auditorid.Contains(dr["OfficeAutomation_Agent_AuditorID"].ToString()))
                        return dr["OfficeAutomation_Agent_Agent"].ToString() + "|" + dr["OfficeAutomation_Agent_AgentID"].ToString();
                }
            }

            return null;
        }
    }
}
