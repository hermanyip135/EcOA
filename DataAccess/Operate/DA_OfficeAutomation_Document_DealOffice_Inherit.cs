using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_DealOffice_Inherit : DA_OfficeAutomation_Document_DealOffice_Operate
    {
        /// <summary>
        /// 通过MainID查询成交商铺/写字楼备案申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_DealOffice_ID]"
                           + "           ,[OfficeAutomation_Document_DealOffice_MainID]"
                           + "           ,[OfficeAutomation_Document_DealOffice_Apply]"
                           + "           ,[OfficeAutomation_Document_DealOffice_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_DealOffice_Department]"
                           + "           ,[OfficeAutomation_Document_DealOffice_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_DealOffice_ReplyFax]"
                           + "           ,[OfficeAutomation_Document_DealOffice_WorkArea]"
                           + "           ,[OfficeAutomation_Document_DealOffice_Branch]"
                           + "           ,[OfficeAutomation_Document_DealOffice_TypeID]"
                           + "           ,[OfficeAutomation_Document_DealOffice_OfficeArea]"
                           + "           ,[OfficeAutomation_Document_DealOffice_OfficeAddress]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealArea]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealPrice]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealOwnerMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealOwnerPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealClientMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealClientPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseArea]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeasePrice]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseOwnerMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseOwnerPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseClientMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseClientPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeasePercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_CrossAreaRemark]"
                           + "           ,[OfficeAutomation_Document_DealOffice_MoneyRemark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + "           ,tdoadot.OfficeAutomation_DealOfficeType_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_DealOffice] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_DealOffice_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_DealOfficeType tdoadot ON tdoadot.OfficeAutomation_DealOfficeType_ID = todi.OfficeAutomation_Document_DealOffice_TypeID"
                           + " WHERE OfficeAutomation_Document_DealOffice_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询成交商铺/写字楼备案申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_DealOffice_ID]"
                           + "           ,[OfficeAutomation_Document_DealOffice_MainID]"
                           + "           ,[OfficeAutomation_Document_DealOffice_Apply]"
                           + "           ,[OfficeAutomation_Document_DealOffice_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_DealOffice_Department]"
                           + "           ,[OfficeAutomation_Document_DealOffice_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_DealOffice_ReplyFax]"
                           + "           ,[OfficeAutomation_Document_DealOffice_WorkArea]"
                           + "           ,[OfficeAutomation_Document_DealOffice_Branch]"
                           + "           ,[OfficeAutomation_Document_DealOffice_TypeID]"
                           + "           ,[OfficeAutomation_Document_DealOffice_OfficeArea]"
                           + "           ,[OfficeAutomation_Document_DealOffice_OfficeAddress]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealArea]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealPrice]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealOwnerMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealOwnerPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealClientMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealClientPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_DealPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseArea]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeasePrice]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseOwnerMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseOwnerPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseClientMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseClientPercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeaseMoney]"
                           + "           ,[OfficeAutomation_Document_DealOffice_LeasePercent]"
                           + "           ,[OfficeAutomation_Document_DealOffice_CrossAreaRemark]"
                           + "           ,[OfficeAutomation_Document_DealOffice_MoneyRemark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,tdoadot.OfficeAutomation_DealOfficeType_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_DealOffice] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_DealOffice_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_DealOfficeType tdoadot ON tdoadot.OfficeAutomation_DealOfficeType_ID = todi.OfficeAutomation_Document_DealOffice_TypeID"
                           + " WHERE OfficeAutomation_Document_DealOffice_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
