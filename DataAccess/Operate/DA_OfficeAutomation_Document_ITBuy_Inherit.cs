using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ITBuy_Inherit : DA_OfficeAutomation_Document_ITBuy_Operate
    {
        /// <summary>
        /// 通过MainID查询计算机及相关设备购买申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ITBuy_ID]"
                           + "           ,[OfficeAutomation_Document_ITBuy_MainID]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Department]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Apply]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Buy1]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Unit1]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Buy2]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Unit2]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Buy3]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Unit3]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ReasonTypeID]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Reason]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ScrapURL]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Remark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + "           ,tdoadot.OfficeAutomation_ITBuyReasonType_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITBuy] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ITBuy_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_ITBuyReasonType tdoadot ON tdoadot.OfficeAutomation_ITBuyReasonType_ID = todi.OfficeAutomation_Document_ITBuy_ReasonTypeID"
                           + " WHERE OfficeAutomation_Document_ITBuy_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询计算机及相关设备购买申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ITBuy_ID]"
                           + "           ,[OfficeAutomation_Document_ITBuy_MainID]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Department]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Apply]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Buy1]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Unit1]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Buy2]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Unit2]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Buy3]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Unit3]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ReasonTypeID]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Reason]"
                           + "           ,[OfficeAutomation_Document_ITBuy_ScrapURL]"
                           + "           ,[OfficeAutomation_Document_ITBuy_Remark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,tdoadot.OfficeAutomation_ITBuyReasonType_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITBuy] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ITBuy_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_ITBuyReasonType tdoadot ON tdoadot.OfficeAutomation_ITBuyReasonType_ID = todi.OfficeAutomation_Document_ITBuy_ReasonTypeID"
                           + " WHERE OfficeAutomation_Document_ITBuy_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应计算机及相关设备购买表的备注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool UpdateRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [t_OfficeAutomation_Document_ITBuy]"
                                + "   SET [OfficeAutomation_Document_ITBuy_Remark] = '" + remark + "'"
                                + " WHERE [OfficeAutomation_Document_ITBuy_ID]='" + id + "'";
            if (!string.IsNullOrEmpty(remark))
            {
                sql +=
@"UPDATE m SET m.[OfficeAutomation_Main_Sremark]='{0}'
FROM t_OfficeAutomation_Main m 
LEFT JOIN t_OfficeAutomation_Document_ITBuy itbuy ON itbuy.OfficeAutomation_Document_ITBuy_MainID=m.OfficeAutomation_Main_ID
WHERE itbuy.[OfficeAutomation_Document_ITBuy_ID]='" + id + "'";
            }
            sql = string.Format(sql, remark);
            return RunNoneSQL(sql);
        }
    }
}
