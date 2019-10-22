using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ProjBaComm_Inherit : DA_OfficeAutomation_Document_ProjBaComm_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ProjBaComm_ID]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_MainID]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Apply]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Department]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Building]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Reason]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_MoneyCount]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Measure]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Remark]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_BDeveloper]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_TurnBack]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjBaComm] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjBaComm_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ProjBaComm_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ProjBaComm_ID]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_MainID]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Apply]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Department]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Building]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Reason]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_MoneyCount]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Measure]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_Remark]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_BDeveloper]"
                           + "           ,[OfficeAutomation_Document_ProjBaComm_TurnBack]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjBaComm] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjBaComm_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ProjBaComm_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应退佣申请表备注,不进行重复标注。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool AddRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjBaComm]"
                                + "   SET [OfficeAutomation_Document_ProjBaComm_Remark] = CASE WHEN [OfficeAutomation_Document_ProjBaComm_Remark] IS NULL THEN '" + remark + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_ProjBaComm_Remark])!=0 THEN [OfficeAutomation_Document_ProjBaComm_Remark]"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_ProjBaComm_Remark] + '" + remark + "' END"
                                + " WHERE [OfficeAutomation_Document_ProjBaComm_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }

        public bool AddRemarkByID_II(string id, string remark)
        {
            string sql =
@"DECLARE @Remark nvarchar(80)
DECLARE @MainID uniqueidentifier
SELECT @Remark=OfficeAutomation_Document_ProjBaComm_Remark,@MainID=OfficeAutomation_Document_ProjBaComm_MainID FROM [t_OfficeAutomation_Document_ProjBaComm] WHERE [OfficeAutomation_Document_ProjBaComm_ID]='{0}'
IF @Remark IS NULL
    BEGIN
        SET @Remark='{1}'
    END
ELSE IF CHARINDEX('{1}',@Remark)!=0
    BEGIN
		SET @Remark=@Remark
	END
ELSE 
    BEGIN
        SET @Remark=@Remark+'{1}'
    END
UPDATE [t_OfficeAutomation_Document_ProjBaComm] SET OfficeAutomation_Document_ProjBaComm_Remark=@Remark WHERE [OfficeAutomation_Document_ProjBaComm_ID]='{0}'
UPDATE [t_OfficeAutomation_Main] SET [OfficeAutomation_Main_Sremark]=@Remark WHERE OfficeAutomation_Main_ID=@MainID";

            sql = string.Format(sql, id, remark);
            return RunNoneSQL(sql);
        }
    }
}
