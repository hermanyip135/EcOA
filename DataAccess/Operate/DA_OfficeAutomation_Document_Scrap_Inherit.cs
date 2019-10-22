using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Scrap_Inherit : DA_OfficeAutomation_Document_Scrap_Operate
    {
        /// <summary>
        /// 通过MainID查询报废申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Scrap_ID]"
                           + "           ,[OfficeAutomation_Document_Scrap_MainID]"
                           + "           ,[OfficeAutomation_Document_Scrap_Department]"
                           + "           ,[OfficeAutomation_Document_Scrap_Apply]"
                           + "           ,[OfficeAutomation_Document_Scrap_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Scrap_UserName]"
                           + "           ,[OfficeAutomation_Document_Scrap_UserTeam]"
                           + "           ,[OfficeAutomation_Document_Scrap_ReqReason]"
                           + "           ,[OfficeAutomation_Document_Scrap_SurplusValue]"
                           + "           ,[OfficeAutomation_Document_Scrap_Suc]"
                           + "           ,[OfficeAutomation_Document_Scrap_Remark]"
                           + "           ,[OfficeAutomation_Document_Scrap_SurplusValueNotify]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + "          ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Scrap_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Scrap_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询报废申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Scrap_ID]"
                           + "           ,[OfficeAutomation_Document_Scrap_MainID]"
                           + "           ,[OfficeAutomation_Document_Scrap_Department]"
                           + "           ,[OfficeAutomation_Document_Scrap_Apply]"
                           + "           ,[OfficeAutomation_Document_Scrap_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Scrap_UserName]"
                           + "           ,[OfficeAutomation_Document_Scrap_UserTeam]"
                           + "           ,[OfficeAutomation_Document_Scrap_ReqReason]"
                           + "           ,[OfficeAutomation_Document_Scrap_SurplusValue]"
                           + "           ,[OfficeAutomation_Document_Scrap_Suc]"
                           + "           ,[OfficeAutomation_Document_Scrap_Remark]"
                           + "           ,[OfficeAutomation_Document_Scrap_SurplusValueNotify]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Scrap_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Scrap_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应报废申请表备注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool UpdateRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap]"
                                + "   SET [OfficeAutomation_Document_Scrap_Remark] = '" + remark + "'"
                                + " WHERE [OfficeAutomation_Document_Scrap_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应报废申请表备注,不进行重复标注。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool AddRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap]"
                                + "   SET [OfficeAutomation_Document_Scrap_Remark] = CASE WHEN [OfficeAutomation_Document_Scrap_Remark] IS NULL THEN '" + remark + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_Scrap_Remark])!=0 THEN [OfficeAutomation_Document_Scrap_Remark]"
                                +"                                                                                        ELSE  [OfficeAutomation_Document_Scrap_Remark] + '" + remark + "' END"
                                + " WHERE [OfficeAutomation_Document_Scrap_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }

        public bool AddRemarkByID_II(string id, string remark)
        {
            string sql =
@"DECLARE @Remark nvarchar(80)
DECLARE @MainID uniqueidentifier
SELECT @Remark=OfficeAutomation_Document_Scrap_Remark,@MainID=OfficeAutomation_Document_Scrap_MainID FROM [t_OfficeAutomation_Document_Scrap] WHERE [OfficeAutomation_Document_Scrap_ID]='{0}'
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
UPDATE [t_OfficeAutomation_Document_Scrap] SET OfficeAutomation_Document_Scrap_Remark=@Remark WHERE [OfficeAutomation_Document_Scrap_ID]='{0}'
UPDATE [t_OfficeAutomation_Main] SET [OfficeAutomation_Main_Sremark]=@Remark WHERE OfficeAutomation_Main_ID=@MainID";

            sql = string.Format(sql, id, remark);
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应报废申请表净值知会函
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool UpdateSurplusValueNotifyByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap]"
                                + "   SET [OfficeAutomation_Document_Scrap_SurplusValueNotify] = '" + remark + "'"
                                + " WHERE [OfficeAutomation_Document_Scrap_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应报废申请表总经理是否同意
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool UpdateGeneralManagerAgreeByID(string id, string isAgree)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap]"
                                + "   SET [OfficeAutomation_Document_Scrap_GeneralManagerAgree] = '" + isAgree + "'"
                                + " WHERE [OfficeAutomation_Document_Scrap_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应报废申请表折旧摊分总剩余费用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="surplusValue"></param>
        /// <returns></returns>
        public bool UpdateSurplusValueByID(string id, string surplusValue, string suc)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap]"
                                + "   SET [OfficeAutomation_Document_Scrap_SurplusValue] = '" + surplusValue + "'"
                                + "   ,[OfficeAutomation_Document_Scrap_Suc] = '" + suc + "'"
                                + " WHERE [OfficeAutomation_Document_Scrap_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }
    }
}
