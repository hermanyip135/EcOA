using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Repair_Inherit : DA_OfficeAutomation_Document_Repair_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Repair_ID]"
                           + "           ,[OfficeAutomation_Document_Repair_MainID]"
                           + "           ,[OfficeAutomation_Document_Repair_Apply]"
                           + "           ,[OfficeAutomation_Document_Repair_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Repair_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Repair_Department]"
                           + "           ,[OfficeAutomation_Document_Repair_SumBrand]"
                           + "           ,[OfficeAutomation_Document_Repair_SumUnit]"
                           + "           ,[OfficeAutomation_Document_Repair_SumPrice]"
                           + "           ,[OfficeAutomation_Document_Repair_SumNum]"
                           + "           ,[OfficeAutomation_Document_Repair_SumMoney]"
                           + "           ,[OfficeAutomation_Document_Repair_SummarySum]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxBrand]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxUnit]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxPrice]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxNum]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxMoney]"
                           + "           ,[OfficeAutomation_Document_Repair_SummaryTax]"
                           + "           ,[OfficeAutomation_Document_Repair_CouBrand]"
                           + "           ,[OfficeAutomation_Document_Repair_CouUnit]"
                           + "           ,[OfficeAutomation_Document_Repair_CouPrice]"
                           + "           ,[OfficeAutomation_Document_Repair_CouNum]"
                           + "           ,[OfficeAutomation_Document_Repair_CouMoney]"
                           + "           ,[OfficeAutomation_Document_Repair_SummaryCou]"
                           + "           ,[OfficeAutomation_Document_Repair_RealBrand]"
                           + "           ,[OfficeAutomation_Document_Repair_RealUnit]"
                           + "           ,[OfficeAutomation_Document_Repair_RealPrice]"
                           + "           ,[OfficeAutomation_Document_Repair_RealNum]"
                           + "           ,[OfficeAutomation_Document_Repair_RealMoney]"
                           + "           ,[OfficeAutomation_Document_Repair_SummaryReal]"
                           + "           ,[OfficeAutomation_Document_Repair_Merchant]"
                           + "           ,[OfficeAutomation_Document_Repair_Conneter]"
                           + "           ,[OfficeAutomation_Document_Repair_Phone]"
                           + "           ,[OfficeAutomation_Document_Repair_Tax]"
                           + "           ,[OfficeAutomation_Document_Repair_Ctime]"
                           + "           ,[OfficeAutomation_Document_Repair_Cname]"
                           + "           ,[OfficeAutomation_Document_Repair_Email]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Repair] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Repair_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Repair_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Repair_ID]"
                           + "           ,[OfficeAutomation_Document_Repair_MainID]"
                           + "           ,[OfficeAutomation_Document_Repair_Apply]"
                           + "           ,[OfficeAutomation_Document_Repair_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Repair_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Repair_Department]"
                           + "           ,[OfficeAutomation_Document_Repair_SumBrand]"
                           + "           ,[OfficeAutomation_Document_Repair_SumUnit]"
                           + "           ,[OfficeAutomation_Document_Repair_SumPrice]"
                           + "           ,[OfficeAutomation_Document_Repair_SumNum]"
                           + "           ,[OfficeAutomation_Document_Repair_SumMoney]"
                           + "           ,[OfficeAutomation_Document_Repair_SummarySum]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxBrand]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxUnit]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxPrice]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxNum]"
                           + "           ,[OfficeAutomation_Document_Repair_TaxMoney]"
                           + "           ,[OfficeAutomation_Document_Repair_SummaryTax]"
                           + "           ,[OfficeAutomation_Document_Repair_CouBrand]"
                           + "           ,[OfficeAutomation_Document_Repair_CouUnit]"
                           + "           ,[OfficeAutomation_Document_Repair_CouPrice]"
                           + "           ,[OfficeAutomation_Document_Repair_CouNum]"
                           + "           ,[OfficeAutomation_Document_Repair_CouMoney]"
                           + "           ,[OfficeAutomation_Document_Repair_SummaryCou]"
                           + "           ,[OfficeAutomation_Document_Repair_RealBrand]"
                           + "           ,[OfficeAutomation_Document_Repair_RealUnit]"
                           + "           ,[OfficeAutomation_Document_Repair_RealPrice]"
                           + "           ,[OfficeAutomation_Document_Repair_RealNum]"
                           + "           ,[OfficeAutomation_Document_Repair_RealMoney]"
                           + "           ,[OfficeAutomation_Document_Repair_SummaryReal]"
                           + "           ,[OfficeAutomation_Document_Repair_Merchant]"
                           + "           ,[OfficeAutomation_Document_Repair_Conneter]"
                           + "           ,[OfficeAutomation_Document_Repair_Phone]"
                           + "           ,[OfficeAutomation_Document_Repair_Tax]"
                           + "           ,[OfficeAutomation_Document_Repair_Ctime]"
                           + "           ,[OfficeAutomation_Document_Repair_Cname]"
                           + "           ,[OfficeAutomation_Document_Repair_Email]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Repair] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Repair_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Repair_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
