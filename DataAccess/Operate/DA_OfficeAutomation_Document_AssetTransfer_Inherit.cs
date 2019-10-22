using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_AssetTransfer_Inherit : DA_OfficeAutomation_Document_AssetTransfer_Operate
    {
        /// <summary>
        /// 通过MainID查询资产调动表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_AssetTransfer_ID]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_MainID]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_Department]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_Apply]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ExportDepartment]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ImportDepartment]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ExportContacts]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ImportContacts]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ExportPlace]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ImportPlace]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_TransferReason]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_Remark]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + "          ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_AssetTransfer_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_AssetTransfer_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询资产调动表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_AssetTransfer_ID]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_MainID]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_Department]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_Apply]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ExportDepartment]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ImportDepartment]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ExportContacts]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ImportContacts]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ExportPlace]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_ImportPlace]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_TransferReason]"
                           + "           ,[OfficeAutomation_Document_AssetTransfer_Remark]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_AssetTransfer_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_AssetTransfer_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应资产调动的备注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool UpdateRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer]"
                                + "   SET [OfficeAutomation_Document_AssetTransfer_Remark] = '" + remark + "'"
                                + " WHERE [OfficeAutomation_Document_AssetTransfer_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应资产调动表备注,不进行重复标注。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool AddRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer]"
                                + "   SET [OfficeAutomation_Document_AssetTransfer_Remark] = CASE WHEN [OfficeAutomation_Document_AssetTransfer_Remark] IS NULL THEN '" + remark + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_AssetTransfer_Remark])!=0 THEN [OfficeAutomation_Document_AssetTransfer_Remark]"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_AssetTransfer_Remark] + '" + remark + "' END"
                                + " WHERE [OfficeAutomation_Document_AssetTransfer_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }

        public bool AddRemarkByID_II(string id, string remark)
        {
            string sql =
@"DECLARE @Remark nvarchar(80)
DECLARE @MainID uniqueidentifier
SELECT @Remark=OfficeAutomation_Document_AssetTransfer_Remark,@MainID=OfficeAutomation_Document_AssetTransfer_MainID FROM [t_OfficeAutomation_Document_AssetTransfer] WHERE [OfficeAutomation_Document_AssetTransfer_ID]='{0}'
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
UPDATE [t_OfficeAutomation_Document_AssetTransfer] SET OfficeAutomation_Document_AssetTransfer_Remark=@Remark WHERE [OfficeAutomation_Document_AssetTransfer_ID]='{0}'
UPDATE [t_OfficeAutomation_Main] SET [OfficeAutomation_Main_Sremark]=@Remark WHERE OfficeAutomation_Main_ID=@MainID";
            sql = string.Format(sql, id, remark);
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 是否需要特殊审核
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool IsITAsset(string mainID, string cv)
        {
            string sql = string.Format("select count(OfficeAutomation_Document_AssetTransfer_Detail_ID) from [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail] where OfficeAutomation_Document_AssetTransfer_Detail_MainID='{0}' and OfficeAutomation_Document_AssetTransfer_Detail_CV like '%{1}%'", mainID, cv);

            DataSet ds = RunSQL(sql);
            int i = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            if (i > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否需要特殊审核
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool IsAPOS(string mainID)
        {
             string sql = string.Format(@"select * from t_OfficeAutomation_Document_AssetTransfer_Detail 
                             where OfficeAutomation_Document_AssetTransfer_Detail_MainID ='{0}'
                             and OfficeAutomation_Document_AssetTransfer_Detail_AssetName like 'POS%'", mainID);
           
            DataSet ds = RunSQL(sql);
            if(ds.Tables[0].Rows.Count>0)
            {
                return true;
            }
            return false;
        }
    }
}
