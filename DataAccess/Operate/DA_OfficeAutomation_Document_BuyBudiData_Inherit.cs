using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BuyBudiData_Inherit : DA_OfficeAutomation_Document_BuyBudiData_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BuyBudiData_ID]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_MainID]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Apply]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Department]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Area]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Writer]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Phone]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Bname]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Baddress]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_DealOfficeOther]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_BDCount]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_BSDCount]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Purpose]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Way]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_HaventTax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_HaveTax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Tax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_AvgHaventTax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_AvgHaveTax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RealP]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_CanUseP]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_EntryP]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Another]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month1]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month2]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month3]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month4]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month5]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month6]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount1]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount2]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount3]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount4]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount5]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount6]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult1]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult2]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult3]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult4]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult5]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult6]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits1]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits2]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits3]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits4]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits5]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits6]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SumRCount]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SumSCresult]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_ApplyNo]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SumProfits]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBudiData] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BuyBudiData_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BuyBudiData_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BuyBudiData_ID]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_MainID]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Apply]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Department]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Area]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Writer]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Phone]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Bname]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Baddress]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_DealOfficeOther]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_BDCount]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_BSDCount]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Purpose]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Way]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_HaventTax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_HaveTax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Tax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_AvgHaventTax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_AvgHaveTax]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RealP]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_CanUseP]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_EntryP]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Another]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month1]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month2]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month3]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month4]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month5]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Month6]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount1]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount2]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount3]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount4]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount5]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_RCount6]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult1]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult2]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult3]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult4]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult5]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult6]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits1]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits2]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits3]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits4]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits5]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_Profits6]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SumRCount]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SumSCresult]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_ApplyNo]"
                           + "           ,[OfficeAutomation_Document_BuyBudiData_SumProfits]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBudiData] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BuyBudiData_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BuyBudiData_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
