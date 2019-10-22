using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Propaganda_Inherit : DA_OfficeAutomation_Document_Propaganda_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Propaganda_ID]"
                           + "           ,[OfficeAutomation_Document_Propaganda_MainID]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Apply]"
                           + "           ,[OfficeAutomation_Document_Propaganda_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Propaganda_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Department]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Conneter]"
                           + "           ,[OfficeAutomation_Document_Propaganda_BranchAddress]"
                           + "           ,[OfficeAutomation_Document_Propaganda_SumPrice]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfAdvertising]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherAdvertising]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfPrinting]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherPrinting]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfMaterial]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherMaterial]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfActivity]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherActivity]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfMap]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherMap]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfGift]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherGift]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfSend]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherSend]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfAnother]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherAnother]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Summary]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Width]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Height]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Count]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Package]"
                           + "           ,[OfficeAutomation_Document_Propaganda_DemandDate]"
                           + "           ,[OfficeAutomation_Document_Propaganda_PaySituation]"
                           + "           ,[OfficeAutomation_Document_Propaganda_PayProjectName]"
                           + "           ,[OfficeAutomation_Document_Propaganda_FearNo]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AcceptDate]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Accepter]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Designer]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Reason]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Verifyer]"
                           + "           ,[OfficeAutomation_Document_Propaganda_TNo]"
                           + "           ,[OfficeAutomation_Document_Propaganda_VerifyDate]"
                           + "           ,[OfficeAutomation_Document_Propaganda_PayAnother]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Grade]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Propaganda_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Propaganda_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Propaganda_ID]"
                           + "           ,[OfficeAutomation_Document_Propaganda_MainID]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Apply]"
                           + "           ,[OfficeAutomation_Document_Propaganda_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Propaganda_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Department]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Conneter]"
                           + "           ,[OfficeAutomation_Document_Propaganda_BranchAddress]"
                           + "           ,[OfficeAutomation_Document_Propaganda_SumPrice]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfAdvertising]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherAdvertising]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfPrinting]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherPrinting]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfMaterial]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherMaterial]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfActivity]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherActivity]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfMap]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherMap]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfGift]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherGift]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfSend]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherSend]"
                           + "           ,[OfficeAutomation_Document_Propaganda_KindOfAnother]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AnotherAnother]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Summary]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Width]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Height]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Count]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Package]"
                           + "           ,[OfficeAutomation_Document_Propaganda_DemandDate]"
                           + "           ,[OfficeAutomation_Document_Propaganda_PaySituation]"
                           + "           ,[OfficeAutomation_Document_Propaganda_PayProjectName]"
                           + "           ,[OfficeAutomation_Document_Propaganda_FearNo]"
                           + "           ,[OfficeAutomation_Document_Propaganda_AcceptDate]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Accepter]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Designer]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Reason]"
                           + "           ,[OfficeAutomation_Document_Propaganda_Verifyer]"
                           + "           ,[OfficeAutomation_Document_Propaganda_TNo]"
                           + "           ,[OfficeAutomation_Document_Propaganda_VerifyDate]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Propaganda_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Propaganda_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据广告宣传类别查找每天生产的数量
        /// </summary>
        /// <param name="propagandatype"></param>
        /// <returns></returns>
        public int GetPropagandaTypeCountToday(int propagandatype)
        {
            string sql = "select count(*) from (select f.OfficeAutomation_Flow_MainID from t_OfficeAutomation_Flow as f "
                        + " left join t_OfficeAutomation_Main as m on f.OfficeAutomation_Flow_MainID=m.OfficeAutomation_Main_ID"
                        + " left join t_OfficeAutomation_Document_Propaganda as p on f.OfficeAutomation_Flow_MainID=p.OfficeAutomation_Document_Propaganda_MainID"
                        + " where CONVERT(varchar, OfficeAutomation_Flow_AuditDate,23)= CONVERT(varchar, GETDATE(),23) and m.OfficeAutomation_DocumentID=55 "
                        + " and OfficeAutomation_Main_FlowStateID=3 and p.OfficeAutomation_Document_Propaganda_SumPrice like '%"+propagandatype+"%' group by f.OfficeAutomation_Flow_MainID )t";
            return RunCountSQL(sql);
        }

        /// <summary>
        /// 更新广告宣传需求申请表某个字段
        /// </summary>
        /// <param name="tno"></param>
        /// <param name="grade"></param>
        /// <param name="designer"></param>
        /// <param name="id"></param>
        /// <returns></returns>
         public bool updateTNoAndGradeByID(string grade,string designer,string id) 
        {
            string sql = "update t_OfficeAutomation_Document_Propaganda set OfficeAutomation_Document_Propaganda_Grade='" + grade + "',OfficeAutomation_Document_Propaganda_Designer='" + designer + "' where OfficeAutomation_Document_Propaganda_ID='" + id + "'";
            return RunNoneSQL(sql);
        }
         public bool updateTNoAndGradeByID(string tno, string grade, string designer, string id)
         {
             string sql = "update t_OfficeAutomation_Document_Propaganda set OfficeAutomation_Document_Propaganda_TNo='" + tno + "',OfficeAutomation_Document_Propaganda_Grade='" + grade + "',OfficeAutomation_Document_Propaganda_Designer='" + designer + "' where OfficeAutomation_Document_Propaganda_ID='" + id + "'";
             return RunNoneSQL(sql);
         }
        /// <summary>
        /// 保存申请编号
        /// </summary>
        /// <returns></returns>
        public bool saveToNO(string sNo, string id)
        {
            string sql = "update t_OfficeAutomation_Document_Propaganda set OfficeAutomation_Document_Propaganda_TNo='" + sNo + "'  where OfficeAutomation_Document_Propaganda_ID='" + id + "'";
            return RunNoneSQL(sql);
        }
    }
}
