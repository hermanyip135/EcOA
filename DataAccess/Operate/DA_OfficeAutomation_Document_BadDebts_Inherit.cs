using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BadDebts_Inherit : DA_OfficeAutomation_Document_BadDebts_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BadDebts_ID]"
                           + "           ,[OfficeAutomation_Document_BadDebts_MainID]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Apply]"
                           + "           ,[OfficeAutomation_Document_BadDebts_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BadDebts_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Department]"
                           + "           ,[OfficeAutomation_Document_BadDebts_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Building]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Reason]"
                           + "           ,[OfficeAutomation_Document_BadDebts_OneOrTwo]"
                           + "           ,[OfficeAutomation_Document_BadDebts_SumBDMoney]"
                           + "           ,[OfficeAutomation_Document_BadDebts_MoneyCount]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Remark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BadDebts_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BadDebts_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BadDebts_ID]"
                           + "           ,[OfficeAutomation_Document_BadDebts_MainID]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Apply]"
                           + "           ,[OfficeAutomation_Document_BadDebts_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BadDebts_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Department]"
                           + "           ,[OfficeAutomation_Document_BadDebts_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Building]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Reason]"
                           + "           ,[OfficeAutomation_Document_BadDebts_OneOrTwo]"
                           + "           ,[OfficeAutomation_Document_BadDebts_SumBDMoney]"
                           + "           ,[OfficeAutomation_Document_BadDebts_MoneyCount]"
                           + "           ,[OfficeAutomation_Document_BadDebts_Remark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BadDebts_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BadDebts_ID='" + ID + "'";

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
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts]"
                                + "   SET [OfficeAutomation_Document_BadDebts_Remark] = CASE WHEN [OfficeAutomation_Document_BadDebts_Remark] IS NULL THEN '" + remark + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_BadDebts_Remark])!=0 THEN [OfficeAutomation_Document_BadDebts_Remark]"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_BadDebts_Remark] + ' " + remark + "' END"
                                + " WHERE [OfficeAutomation_Document_BadDebts_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }
        public bool AddRemarkByID_II(string id, string remark)
        {
            string sql =
@"DECLARE @Remark nvarchar(80)
DECLARE @MainID uniqueidentifier
SELECT @Remark=OfficeAutomation_Document_BadDebts_Remark,@MainID=OfficeAutomation_Document_BadDebts_MainID FROM [t_OfficeAutomation_Document_BadDebts] WHERE [OfficeAutomation_Document_BadDebts_MainID]='{0}'
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
UPDATE [t_OfficeAutomation_Document_BadDebts] SET OfficeAutomation_Document_BadDebts_Remark=@Remark,OfficeAutomation_Document_BadDebts_BadSignTime=GETDATE() WHERE [OfficeAutomation_Document_BadDebts_MainID]='{0}'
UPDATE [t_OfficeAutomation_Main] SET [OfficeAutomation_Main_Sremark]=@Remark WHERE OfficeAutomation_Main_ID=@MainID";
            sql = string.Format(sql, id, remark);
            return RunNoneSQL(sql);
        }


        /// <summary>
        /// 根据id给对应坏账申请表替换备注。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool ReplaceRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts]"
                                + "   SET [OfficeAutomation_Document_BadDebts_Remark] = '" + remark + "'"
                                + " WHERE [OfficeAutomation_Document_BadDebts_ID]='" + id + "'";
            sql +=
@"UPDATE m SET m.OfficeAutomation_Main_Summary='{0}' FROM [t_OfficeAutomation_Main] m 
LEFT JOIN [t_OfficeAutomation_Document_BadDebts] b ON b.OfficeAutomation_Document_BadDebts_MainID=m.OfficeAutomation_Main_ID
WHERE b.OfficeAutomation_Document_BadDebts_ID='{1}'";
            sql = string.Format(sql, remark, id);
            return RunNoneSQL(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_BadDebts obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_BadDebts_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_BadDebts();
            Baseobj.OfficeAutomation_Document_BadDebts_ID = obj.OfficeAutomation_Document_BadDebts_ID;
            Baseobj.OfficeAutomation_Document_BadDebts_MainID = obj.OfficeAutomation_Document_BadDebts_MainID;
            Baseobj.OfficeAutomation_Document_BadDebts_Apply = obj.OfficeAutomation_Document_BadDebts_Apply;
            Baseobj.OfficeAutomation_Document_BadDebts_ApplyDate = obj.OfficeAutomation_Document_BadDebts_ApplyDate;
            Baseobj.OfficeAutomation_Document_BadDebts_ApplyID = obj.OfficeAutomation_Document_BadDebts_ApplyID;
            Baseobj.OfficeAutomation_Document_BadDebts_Department = obj.OfficeAutomation_Document_BadDebts_Department;
            Baseobj.OfficeAutomation_Document_BadDebts_ReplyPhone = obj.OfficeAutomation_Document_BadDebts_ReplyPhone;
            Baseobj.OfficeAutomation_Document_BadDebts_Building = obj.OfficeAutomation_Document_BadDebts_Building;
            Baseobj.OfficeAutomation_Document_BadDebts_Reason = obj.OfficeAutomation_Document_BadDebts_Reason;
            Baseobj.OfficeAutomation_Document_BadDebts_MoneyCount = obj.OfficeAutomation_Document_BadDebts_MoneyCount;
            Baseobj.OfficeAutomation_Document_BadDebts_Remark = obj.OfficeAutomation_Document_BadDebts_Remark;
            Baseobj.OfficeAutomation_Document_BadDebts_OneOrTwo = obj.OfficeAutomation_Document_BadDebts_OneOrTwo;
            Baseobj.OfficeAutomation_Document_BadDebts_SumBDMoney = obj.OfficeAutomation_Document_BadDebts_SumBDMoney;
            

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_BadDebts_MainID]='" + obj.OfficeAutomation_Document_BadDebts_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_BadDebts resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Add(Baseobj);
            }
            return resultobj != null;
        }

        #endregion

        #region  根据mainid查找坏账明细表的reportid
        public string GetReportIdByMainId(string mainID)
        {
            string reportid = "";
            string sql = "SELECT todid.*"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts_Detail] todid"
                           + " LEFT JOIN t_OfficeAutomation_Document_BadDebts todi ON todid.OfficeAutomation_Document_BadDebts_Detail_MainID=todi.OfficeAutomation_Document_BadDebts_ID"
                           + " LEFT JOIN t_OfficeAutomation_Main tom ON todi.OfficeAutomation_Document_BadDebts_MainID=tom.OfficeAutomation_Main_ID"
                           + " WHERE tom.OfficeAutomation_Main_ID='" + mainID + "'";

            DataSet ds= RunSQL(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[0].Rows.Count; i++) 
                {
                    reportid += ds.Tables[0].Rows[i]["OfficeAutomation_Document_BadDebts_Detail_ReportID"] + ",";
                }

                reportid = reportid.Substring(0, reportid.Length - 1);
            }

            return reportid;
        }
        #endregion
    }
}
