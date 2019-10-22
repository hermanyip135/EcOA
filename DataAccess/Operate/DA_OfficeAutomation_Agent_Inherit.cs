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
        /// ��������˹��ţ���������ȡ��������������ʽ������,�żӱ򣩡���Ҫ���ڷ���֪ͨ������޴������򷵻������������
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
        /// ���������������ȡ��������������ʽ������,�żӱ򣩡���Ҫ���ڷ���֪ͨ������޴������򷵻������������
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public string SelectAgentByAuditor(string auditor,bool isa) //M_20150604���Ƿ���Ҫ������
        {
            string sql = "SELECT distinct [OfficeAutomation_Agent_agent]"
                          + "  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Agent]"
                          + " WHERE OfficeAutomation_Agent_Auditor = '" + auditor + "'"
                          + "             AND GETDATE() BETWEEN [OfficeAutomation_Agent_Start] AND  [OfficeAutomation_Agent_End]"
                          + "             AND OfficeAutomation_Agent_IsEnable = 1";

            DataSet ds = RunSQL(sql);

            string agents = "";

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0 && isa) //Alt_20150605���Ƿ���Ҫ������
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
        /// �����˻�������ڴ�����˵����������š�
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
        /// �����˻�������ڴ�����˵����������š�
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
        /// �Ƿ��������ǩ����Ȩ��(�漰������)
        /// </summary>
        /// <param name="auditor">�����������</param>
        /// <param name="auditorid">������˹���</param>
        /// <param name="employee">��ǰ��¼������(������)</param>
        /// <param name="employeeid">���ڵ�¼�˹���(������)</param>
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
        /// �Ƿ��������ǩ����Ȩ��(�漰������)����ͬʱ���������
        /// </summary>
        /// <param name="employee">�����������</param>
        /// <param name="employeeid">������˹���</param>
        /// <param name="auditor">�����������</param>
        /// <param name="auditorid">������˹���</param>
        /// <param name="user">��ǰ��¼������(������)</param>
        /// <param name="userid">��ǰ��¼�˹���(������)</param>
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
        /// �Ƿ�������˳���ǩ����Ȩ��(�漰������)����ͬʱ���������
        /// </summary>
        /// <param name="employee">�����������</param>
        /// <param name="employeeid">������˹���</param>
        /// <param name="auditor">�����������</param>
        /// <param name="auditorid">������˹���</param>
        /// <param name="user">��ǰ��¼������(������)</param>
        /// <param name="userid">��ǰ��¼�˹���(������)</param>
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
        /// �Ƿ�ӵ�����ǩ����Ȩ��(�漰������)�����ӵ��Ȩ�޷�����������������ţ�����|26242�����򷵻�null
        /// </summary>
        /// <param name="auditor">���������</param>
        /// <param name="auditorid">����˹���</param>
        /// <param name="employee">��ǰ��¼������(������)</param>
        /// <param name="employeeid">���ڵ�¼�˹���(������)</param>
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
