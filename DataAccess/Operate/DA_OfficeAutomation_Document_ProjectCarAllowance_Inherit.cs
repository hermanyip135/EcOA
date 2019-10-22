using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ProjectCarAllowance_Inherit : DA_OfficeAutomation_Document_ProjectCarAllowance_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ProjectCarAllowance_ID]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_MainID]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Apply]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyForName]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyForCode]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_EntryDate]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Department]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Position]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Grade]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_IsPositive]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_EffectiveDate]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Remark]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyType]"
                           + "           ,(SELECT tdoamg.OfficeAutomation_MoneyGrade_Name"
                           + "             FROM t_Dic_OfficeAutomation_MoneyGrade tdoamg"
                           + "             WHERE tdoamg.OfficeAutomation_MoneyGrade_ID=todi.[OfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID]) AS MoneyGrade"
                           + "           ,(SELECT tdoamg.OfficeAutomation_MoneyGrade_Name"
                           + "             FROM t_Dic_OfficeAutomation_MoneyGrade tdoamg"
                           + "             WHERE tdoamg.OfficeAutomation_MoneyGrade_ID=todi.[OfficeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID]) AS AgreeMoneyGrade"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectCarAllowance] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjectCarAllowance_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ProjectCarAllowance_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ProjectCarAllowance_ID]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_MainID]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Apply]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyForName]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyForCode]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_EntryDate]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Department]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Position]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Grade]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_IsPositive]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_EffectiveDate]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID]"
                           + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Remark]"
                           + "           ,(SELECT tdoamg.OfficeAutomation_MoneyGrade_Name"
                           + "             FROM t_Dic_OfficeAutomation_MoneyGrade tdoamg"
                           + "             WHERE tdoamg.OfficeAutomation_MoneyGrade_ID=todi.[OfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID]) AS MoneyGrade"
                           + "           ,(SELECT tdoamg.OfficeAutomation_MoneyGrade_Name"
                           + "             FROM t_Dic_OfficeAutomation_MoneyGrade tdoamg"
                           + "             WHERE tdoamg.OfficeAutomation_MoneyGrade_ID=todi.[OfficeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID]) AS AgreeMoneyGrade"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectCarAllowance] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjectCarAllowance_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ProjectCarAllowance_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应报废申请表备注,不进行重复标注。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool AddRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectCarAllowance]"
                                + "   SET [OfficeAutomation_Document_ProjectCarAllowance_Remark] = CASE WHEN [OfficeAutomation_Document_ProjectCarAllowance_Remark] IS NULL THEN '" + remark + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_ProjectCarAllowance_Remark])!=0 THEN [OfficeAutomation_Document_ProjectCarAllowance_Remark]"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_ProjectCarAllowance_Remark] + '" + remark + "' END"
                                + " WHERE [OfficeAutomation_Document_ProjectCarAllowance_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应小汽车津贴更新AgreeMoneyGradeID值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="agreeMoneyGradeID"></param>
        /// <returns></returns>
        public bool UpdateAgreeMoneyGradeIDByID(string id, string agreeMoneyGradeID)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectCarAllowance]"
                                + "   SET [OfficeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID] =" + agreeMoneyGradeID
                                + " WHERE [OfficeAutomation_Document_ProjectCarAllowance_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }
    }
}
