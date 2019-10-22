using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CommissionAdjust_Inherit : DA_OfficeAutomation_Document_CommissionAdjust_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_CommissionAdjust_ID]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_MainID]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Apply]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ApplyID]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Department]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_IsLawE]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Building]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_BadCommDate]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Property]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Controler]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_PropertyID]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_PropertyDate]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_OldDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_NewDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_AjustDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ShouldComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ActualComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_AjustComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_LeadReason]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Commitment]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumShouldComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumAjustComm]"

                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumOldDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumNewDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumAjustDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumActualComm]"

                             + "           ,[OfficeAutomation_Document_CommissionAdjust_Sign]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Reason]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_CommissionAdjust_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_CommissionAdjust_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_CommissionAdjust_ID]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_MainID]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Apply]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ApplyID]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Department]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_IsLawE]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Building]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_BadCommDate]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Property]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Controler]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_PropertyID]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_PropertyDate]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_OldDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_NewDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_AjustDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ShouldComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_ActualComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_AjustComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_LeadReason]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Commitment]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumShouldComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumAjustComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumOldDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumNewDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumAjustDeal]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_SumActualComm]"
                           + "           ,[OfficeAutomation_Document_CommissionAdjust_Reason]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_CommissionAdjust_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_CommissionAdjust_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应坏账申请表备注,不进行重复标注。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool AddRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust]"
                                + "   SET [OfficeAutomation_Document_CommissionAdjust_Remark] = CASE WHEN [OfficeAutomation_Document_CommissionAdjust_Remark] IS NULL THEN '" + remark + DateTime.Now.ToString("yyyy-MM-dd") + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_CommissionAdjust_Remark])!=0 THEN [OfficeAutomation_Document_CommissionAdjust_Remark]"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_CommissionAdjust_Remark] + ' " + remark + DateTime.Now.ToString("yyyy-MM-dd") + "' END"
                                + " WHERE [OfficeAutomation_Document_CommissionAdjust_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }

        public bool AddRemarkByID_II(string mainid, string remark)
        {
            string sql =
@"DECLARE @Remark nvarchar(80)
SELECT @Remark=OfficeAutomation_Document_CommissionAdjust_Remark FROM [t_OfficeAutomation_Document_CommissionAdjust] WHERE [OfficeAutomation_Document_CommissionAdjust_MainID]='{0}'
IF @Remark IS NULL
    BEGIN
        SET @Remark='{1}'+ '{2}'
    END
ELSE IF CHARINDEX('{1}',@Remark)!=0
    BEGIN
		SET @Remark=@Remark
	END
ELSE 
    BEGIN
        SET @Remark=@Remark + ' {1}' + ' {2}'
    END
UPDATE [t_OfficeAutomation_Document_CommissionAdjust] SET OfficeAutomation_Document_CommissionAdjust_Remark=@Remark WHERE [OfficeAutomation_Document_CommissionAdjust_MainID]='{0}'
UPDATE [t_OfficeAutomation_Main] SET [OfficeAutomation_Main_Sremark]=@Remark WHERE OfficeAutomation_Main_ID='{0}'";

            sql = string.Format(sql, mainid, remark,DateTime.Now.ToString("yyyy-MM-dd"));
            return RunNoneSQL(sql);
        }
    }
}
