using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BorrowMoney_Inherit : DA_OfficeAutomation_Document_BorrowMoney_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BorrowMoney_ID]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_MainID]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Apply]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Department]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_NeedDate]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Reason]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_PayK]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Acount]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Aname]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Bank]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Money]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_BWMoney]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ApplyNo]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Dialog]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_AuditorName]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_IsAgree]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Suggestion]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_AuditorDate]"
                           +"            ,OfficeAutomation_Document_BorrowMoney_Area"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_ApplyDate2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_ApplyID2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_Department2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_ReplyPhone2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_NeedDate2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_Reason2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_PayK2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_Acount2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_Aname2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_Bank2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_Money2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_BWMoney2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_ApplyNo2]"
                           //+ "           ,[OfficeAutomation_Document_BorrowMoney_Dialog2]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BorrowMoney] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BorrowMoney_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BorrowMoney_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BorrowMoney_ID]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_MainID]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Apply]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Department]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_NeedDate]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Reason]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_PayK]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Acount]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Aname]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Bank]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Money]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_BWMoney]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ApplyNo]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Dialog]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ApplyDate2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ApplyID2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Department2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ReplyPhone2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_NeedDate2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Reason2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_PayK2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Acount2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Aname2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Bank2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Money2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_BWMoney2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_ApplyNo2]"
                           + "           ,[OfficeAutomation_Document_BorrowMoney_Dialog2]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BorrowMoney] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BorrowMoney_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BorrowMoney_ID='" + ID + "'";

            return RunSQL(sql);
        }

        //获取当前月份最大数
        public DataSet getbBigFlowNumber(string sFlowNumber)
        {
            string sql = @"SELECT ISNULL(MAX(num),0)num 
                             FROM (
                                SELECT  LEFT (OfficeAutomation_Document_BorrowMoney_ApplyID , 7) FlowNumber ,
                                   Convert(INT, SUBSTRING(OfficeAutomation_Document_BorrowMoney_ApplyID,CHARINDEX('-',OfficeAutomation_Document_BorrowMoney_ApplyID)+1,LEN(OfficeAutomation_Document_BorrowMoney_ApplyID)-CHARINDEX('-',OfficeAutomation_Document_BorrowMoney_ApplyID))) num
                                FROM t_OfficeAutomation_Document_BorrowMoney
                                WHERE LEFT (OfficeAutomation_Document_BorrowMoney_ApplyID , 7)='{0}'
                                )A";
            sql = string.Format(sql, sFlowNumber);
            return OperationSQL(sql);
        }
    }
}
