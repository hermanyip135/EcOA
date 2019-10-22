using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
   public class DA_OfficeAutomation_Document_Fax_Detail_Inherit : DA_OfficeAutomation_Document_Fax_Detail_Operate
    {
       /// <summary>
       /// 加载图片位置
       /// </summary>
       /// <returns></returns>
       public List<LoadLeftTop> GetFaxFlowsSignLeftTopList(string MainID)
       {
           DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
           //   string sql=@"select d.*,f.OfficeAutomation_Flow_AuditorID,f.OfficeAutomation_Flow_Auditor
           //   from t_OfficeAutomation_Flow f 
           // inner join t_OfficeAutomation_Document_Fax_Detail d on d.OfficeAutomation_Document_Fax_Detail_Flow_ID = f.OfficeAutomation_Flow_ID
           //   inner join t_OfficeAutomation_Document_Fax fa on fa.OfficeAutomation_Document_Fax_ID = d.OfficeAutomation_Document_Fax_Detail_Main_ID
           //   where fa.OfficeAutomation_Document_Fax_MainID ='" + MainID + "'";
           string sql = @"select d.*,OfficeAutomation_Document_Fax_Detail_AuditorID OfficeAutomation_Flow_AuditorID,OfficeAutomation_Document_Fax_Detail_AuditorName OfficeAutomation_Flow_Auditor
   from t_OfficeAutomation_Flow f 
 inner join t_OfficeAutomation_Document_Fax_Detail d on d.OfficeAutomation_Document_Fax_Detail_Flow_ID = f.OfficeAutomation_Flow_ID
   inner join t_OfficeAutomation_Document_Fax fa on fa.OfficeAutomation_Document_Fax_ID = d.OfficeAutomation_Document_Fax_Detail_Main_ID
   where fa.OfficeAutomation_Document_Fax_MainID ='" + MainID + "'";
           DataSet ds = OperationSQL(sql);
           var list = new List<LoadLeftTop>();
           var signpath = DA_OfficeAutomation_Flow_Inherit.GetAppString("SignImageURL");
           foreach (DataRow dr in ds.Tables[0].Rows)
           {
               var o = new LoadLeftTop();

               o.Auditors = signpath + dr["OfficeAutomation_Flow_AuditorID"].ToString() + ".gif";
               o.Auditorx = dr["OfficeAutomation_Document_Fax_Detail_CoordinateX"].ToString();
               o.Auditory = dr["OfficeAutomation_Document_Fax_Detail_CoordinateY"].ToString();
               list.Add(o);
           }
           return list;
       }
       public void deleteFaxDetailByFlowID(string sMainID,int iFlowID)
       {
           string sql = @"delete t_OfficeAutomation_Document_Fax_Detail where OfficeAutomation_Document_Fax_Detail_Flow_ID in(
    select OfficeAutomation_Flow_ID from t_OfficeAutomation_Flow where OfficeAutomation_Flow_MainID ='{0}'
    and OfficeAutomation_Flow_Idx>={1})";
           sql = string.Format(sql, sMainID, iFlowID);
           OperationSQL(sql);
       }
       public List<DataEntity.Model.FlowsSignEntity> GetFaxFlowsSign(string MainID,string EmployeeID, string EmployeeName)
       {
            string sql= @"select * from (
            select top 1* from t_OfficeAutomation_Flow
            where OfficeAutomation_Flow_MainID='"+MainID+"'and (OfficeAutomation_Flow_Audit is null or OfficeAutomation_Flow_Audit ='') order by OfficeAutomation_Flow_Idx )t where OfficeAutomation_Flow_EmployeeID like'%" + EmployeeID + "%'";
           DataSet ds =OperationSQL(sql);

           if (ds == null || ds.Tables[0].Rows.Count == 0)
           {
               return null;
           }
           DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new Operate.DA_OfficeAutomation_Flow_Inherit();
           var list = new List<DataEntity.Model.FlowsSignEntity>();
           var flag = true;
           foreach (DataRow dr in ds.Tables[0].Rows)
           {
               var o = new DataEntity.Model.FlowsSignEntity();
               o.AuditDate = "";
               if (!string.IsNullOrEmpty(dr["OfficeAutomation_Flow_AuditDate"].ToString()))
               {
                   o.AuditDate = Convert.ToDateTime(dr["OfficeAutomation_Flow_AuditDate"]).ToString("yyyy-MM-dd HH:mm:ss");
               }

               o.Idx = Convert.ToInt32(dr["OfficeAutomation_Flow_Idx"]);
               o.Suggestion = dr["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r\n", "</br>");
               o.Audit = Convert.ToBoolean(dr["OfficeAutomation_Flow_Audit"]);
               o.IsAgree = dr["OfficeAutomation_Flow_IsAgree"].ToString();
               o.Employee = dr["OfficeAutomation_Flow_Employee"].ToString();
               o.EmployeeID = dr["OfficeAutomation_Flow_EmployeeID"].ToString();
               //o.Auditors = GetSignEmpList(dr["OfficeAutomation_Flow_AuditorID"].ToString(), dr["OfficeAutomation_Flow_Auditor"].ToString(), EmployeeID, EmployeeName);
               o.Auditors = da_OfficeAutomation_Flow_Inherit.GetSignEmpList(dr["OfficeAutomation_Flow_EmployeeID"].ToString(), dr["OfficeAutomation_Flow_Employee"].ToString(), EmployeeID, EmployeeName);
               DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
               DataSet ds1 = da_OfficeAutomation_Agent_Inherit.GetMyAgencyForAgent(EmployeeName, EmployeeID);//查代理人
               o.SignbtnShow = false;
               //到审核流程
               if (flag && !o.Audit)
               {
                   //登录人需要签名，但还没签的，显示签名按钮
                   var needsign = (o.Employee + ",").Contains(EmployeeName + ",") && (o.EmployeeID + ",").Contains(EmployeeID + ",");  //是否需要登录人签名
                   var issigned = (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(EmployeeName + ",") || (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(EmployeeName + "（复审）,") && (dr["OfficeAutomation_Flow_AuditorID"] + ",").Contains(EmployeeID + ",");    //是否已经签名
                   if (needsign && !issigned)
                   {
                       o.SignbtnShow = true;
                   }
                   string sAgentName = string.Empty;//代理人名称
                   string sAgentID = string.Empty;//代理人工号
                   //代理人
                   if (ds1 != null && ds1.Tables != null && ds1.Tables[0].Rows.Count > 0)
                   {
                       foreach (DataRow dr1 in ds1.Tables[0].Rows)
                       {
                           sAgentName = dr1["OfficeAutomation_Agent_Auditor"].ToString();
                           sAgentID = dr1["OfficeAutomation_Agent_AuditorID"].ToString();
                           var needsign1 = (o.Employee + ",").Contains(sAgentName + ",") && (o.EmployeeID + ",").Contains(sAgentID + ",");
                           var issigned1 = (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(sAgentName + ",") || (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(sAgentName + "（复审）,") && (dr["OfficeAutomation_Flow_AuditorID"] + ",").Contains(sAgentID + ",");    //是否已经签名
                           if (needsign1 && !issigned1)
                           {
                               o.SignbtnShow = true;
                           }
                       }

                   }
                   flag = false;
               }
               list.Add(o);
           }
           return list;
       }
    }
   public class LoadLeftTop
   {
       public string Auditors { get; set; }
       public string Auditorx { get; set; }
       public string Auditory { get; set; }
   }
}
