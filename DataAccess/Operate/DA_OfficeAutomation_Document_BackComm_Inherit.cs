﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BackComm_Inherit : DA_OfficeAutomation_Document_BackComm_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BackComm_ID]"
                           + "           ,[OfficeAutomation_Document_BackComm_MainID]"
                           + "           ,[OfficeAutomation_Document_BackComm_Apply]"
                           + "           ,[OfficeAutomation_Document_BackComm_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BackComm_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BackComm_Department]"
                           + "           ,[OfficeAutomation_Document_BackComm_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_BackComm_Building]"
                           + "           ,[OfficeAutomation_Document_BackComm_Reason]"
                           + "           ,[OfficeAutomation_Document_BackComm_MoneyCount]"
                           + "           ,[OfficeAutomation_Document_BackComm_Measure]"
                           + "           ,[OfficeAutomation_Document_BackComm_Remark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BackComm] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BackComm_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BackComm_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BackComm_ID]"
                           + "           ,[OfficeAutomation_Document_BackComm_MainID]"
                           + "           ,[OfficeAutomation_Document_BackComm_Apply]"
                           + "           ,[OfficeAutomation_Document_BackComm_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BackComm_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BackComm_Department]"
                           + "           ,[OfficeAutomation_Document_BackComm_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_BackComm_Building]"
                           + "           ,[OfficeAutomation_Document_BackComm_Reason]"
                           + "           ,[OfficeAutomation_Document_BackComm_MoneyCount]"
                           + "           ,[OfficeAutomation_Document_BackComm_Measure]"
                           + "           ,[OfficeAutomation_Document_BackComm_Remark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BackComm] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BackComm_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BackComm_ID='" + ID + "'";

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
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BackComm]"
                                + "   SET [OfficeAutomation_Document_BackComm_Remark] = CASE WHEN [OfficeAutomation_Document_BackComm_Remark] IS NULL THEN '" + remark + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_BackComm_Remark])!=0 THEN [OfficeAutomation_Document_BackComm_Remark]"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_BackComm_Remark] + '" + remark + "' END"
                                + " WHERE [OfficeAutomation_Document_BackComm_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }

        public bool AddRemarkByID_II(string id, string remark)
        {
            string sql =
@"DECLARE @Remark nvarchar(80)
DECLARE @MainID uniqueidentifier
SELECT @Remark=OfficeAutomation_Document_BackComm_Remark,@MainID=OfficeAutomation_Document_BackComm_MainID FROM [t_OfficeAutomation_Document_BackComm] WHERE [OfficeAutomation_Document_BackComm_MainID]='{0}'
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
UPDATE [t_OfficeAutomation_Document_BackComm] SET [OfficeAutomation_Document_BackComm_Remark]=@Remark WHERE [OfficeAutomation_Document_BackComm_MainID]='{0}'
UPDATE [t_OfficeAutomation_Main] SET [OfficeAutomation_Main_Sremark]=@Remark WHERE OfficeAutomation_Main_ID=@MainID";
            sql = string.Format(sql, id, remark);
            return RunNoneSQL(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_BackComm obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_BackComm_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_BackComm();
            Baseobj.OfficeAutomation_Document_BackComm_ID = obj.OfficeAutomation_Document_BackComm_ID;
            Baseobj.OfficeAutomation_Document_BackComm_MainID = obj.OfficeAutomation_Document_BackComm_MainID;
            Baseobj.OfficeAutomation_Document_BackComm_Apply = obj.OfficeAutomation_Document_BackComm_Apply;
            Baseobj.OfficeAutomation_Document_BackComm_ApplyDate = obj.OfficeAutomation_Document_BackComm_ApplyDate;
            Baseobj.OfficeAutomation_Document_BackComm_Department = obj.OfficeAutomation_Document_BackComm_Department;
            Baseobj.OfficeAutomation_Document_BackComm_ReplyPhone = obj.OfficeAutomation_Document_BackComm_ReplyPhone;
            Baseobj.OfficeAutomation_Document_BackComm_Building = obj.OfficeAutomation_Document_BackComm_Building;
            Baseobj.OfficeAutomation_Document_BackComm_Reason = obj.OfficeAutomation_Document_BackComm_Reason;
            Baseobj.OfficeAutomation_Document_BackComm_Measure = obj.OfficeAutomation_Document_BackComm_Measure;
            Baseobj.OfficeAutomation_Document_BackComm_ApplyID = obj.OfficeAutomation_Document_BackComm_ApplyID; 

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_BackComm_MainID]='" + obj.OfficeAutomation_Document_BackComm_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_BackComm resultobj;
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
    }
}
