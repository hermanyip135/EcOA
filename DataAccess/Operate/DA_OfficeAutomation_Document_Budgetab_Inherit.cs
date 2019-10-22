using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Budgetab_Inherit : DA_OfficeAutomation_Document_Budgetab_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Budgetab_ID]"
                           + "           ,[OfficeAutomation_Document_Budgetab_MainID]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Apply]"
                           + "           ,[OfficeAutomation_Document_Budgetab_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Budgetab_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Department]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Phone]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AProject]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Akind]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Aitem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AdjustableKind]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AdjustableItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Price]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AdvertisingItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AdvertisingPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_PrintingItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_PrintingPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_MaterialItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_MaterialPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_ActivityItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_ActivityPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AnotherItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AnotherPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Reason]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Statement]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Budgetab] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Budgetab_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Budgetab_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Budgetab_ID]"
                           + "           ,[OfficeAutomation_Document_Budgetab_MainID]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Apply]"
                           + "           ,[OfficeAutomation_Document_Budgetab_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Budgetab_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Department]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Phone]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AProject]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Akind]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Aitem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AdjustableKind]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AdjustableItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Price]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AdvertisingItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AdvertisingPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_PrintingItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_PrintingPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_MaterialItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_MaterialPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_ActivityItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_ActivityPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AnotherItem]"
                           + "           ,[OfficeAutomation_Document_Budgetab_AnotherPrice]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Reason]"
                           + "           ,[OfficeAutomation_Document_Budgetab_Statement]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Budgetab] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Budgetab_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Budgetab_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
