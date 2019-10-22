using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_TotalRev_Inherit : DA_OfficeAutomation_Document_TotalRev_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_TotalRev_ID]"
                            + "           ,[OfficeAutomation_Document_TotalRev_MainID]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Apply]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ApplyDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ApplyID]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Department]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Subject]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ReplyPhone]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ReplyFax]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Address]"
                            + "           ,[OfficeAutomation_Document_TotalRev_BranchName]"
                            + "           ,[OfficeAutomation_Document_TotalRev_BSquare]"
                            + "           ,[OfficeAutomation_Document_TotalRev_CSquare]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Rent]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Percent]"
                            + "           ,[OfficeAutomation_Document_TotalRev_1hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_2hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_3hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_4hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_5hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentMonth]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentBeginDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentEndDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OBeginDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OEndDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OCount]"
                            + "           ,[OfficeAutomation_Document_TotalRev_McoastMonth]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Mcoast]"
                            + "           ,[OfficeAutomation_Document_TotalRev_MProvide]"
                            + "           ,[OfficeAutomation_Document_TotalRev_WaterCost]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ElectCost]"
                            + "           ,[OfficeAutomation_Document_TotalRev_WEProvide]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Tbranch]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Tcoast]"
                            + "           ,[OfficeAutomation_Document_TotalRev_1BC]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FirstRentBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentTaxBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FirstMonthBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_DepositBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_WEDBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ManageBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_SendBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OtherBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_1SumBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_2BC]"
                            + "           ,[OfficeAutomation_Document_TotalRev_PhotoBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_DecorateProjectBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FurnitureBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_StationeryBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_AirConditioningBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ConputerBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_SignatureBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_CertificateBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OpticalFiberBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ForestBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_MonthCleanBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_YearInsuranceBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RegistrationBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_2SumBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_3BC]"
                            + "           ,[OfficeAutomation_Document_TotalRev_BasisBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_AddElectricBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FireBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_3SumBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FirstRentRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentTaxRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FirstMonthRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_DepositRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_WEDRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ManageRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_SendRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OtherRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_PhotoRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_DecorateProjectRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FurnitureRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_StationeryRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_AirConditioningRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ConputerRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_SignatureRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_CertificateRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OpticalFiberRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ForestRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_MonthCleanRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_YearInsuranceRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RegistrationRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_BasisRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_AddElectricRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FireRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Part3OtherBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Part3OtherRemark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_TotalRev] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_TotalRev_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_TotalRev_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_TotalRev_ID]"
                            + "           ,[OfficeAutomation_Document_TotalRev_MainID]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Apply]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ApplyDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ApplyID]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Department]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Subject]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ReplyPhone]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ReplyFax]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Address]"
                            + "           ,[OfficeAutomation_Document_TotalRev_BranchName]"
                            + "           ,[OfficeAutomation_Document_TotalRev_BSquare]"
                            + "           ,[OfficeAutomation_Document_TotalRev_CSquare]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Rent]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Percent]"
                            + "           ,[OfficeAutomation_Document_TotalRev_1hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_2hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_3hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_4hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_5hYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentYear]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentMonth]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentBeginDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentEndDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OBeginDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OEndDate]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OCount]"
                            + "           ,[OfficeAutomation_Document_TotalRev_McoastMonth]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Mcoast]"
                            + "           ,[OfficeAutomation_Document_TotalRev_MProvide]"
                            + "           ,[OfficeAutomation_Document_TotalRev_WaterCost]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ElectCost]"
                            + "           ,[OfficeAutomation_Document_TotalRev_WEProvide]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Tbranch]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Tcoast]"
                            + "           ,[OfficeAutomation_Document_TotalRev_1BC]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FirstRentBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentTaxBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FirstMonthBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_DepositBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_WEDBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ManageBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_SendBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OtherBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_1SumBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_2BC]"
                            + "           ,[OfficeAutomation_Document_TotalRev_PhotoBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_DecorateProjectBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FurnitureBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_StationeryBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_AirConditioningBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ConputerBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_SignatureBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_CertificateBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OpticalFiberBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ForestBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_MonthCleanBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_YearInsuranceBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RegistrationBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_2SumBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_3BC]"
                            + "           ,[OfficeAutomation_Document_TotalRev_BasisBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_AddElectricBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FireBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_3SumBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FirstRentRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RentTaxRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FirstMonthRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_DepositRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_WEDRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ManageRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_SendRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OtherRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_PhotoRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_DecorateProjectRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FurnitureRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_StationeryRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_AirConditioningRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ConputerRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_SignatureRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_CertificateRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_OpticalFiberRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_ForestRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_MonthCleanRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_YearInsuranceRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_RegistrationRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_BasisRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_AddElectricRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_FireRemark]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Part3OtherBudget]"
                            + "           ,[OfficeAutomation_Document_TotalRev_Part3OtherRemark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_TotalRev] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_TotalRev_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_TotalRev_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 自定义

        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_TotalRev obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_TotalRev_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_TotalRev();
            Baseobj.OfficeAutomation_Document_TotalRev_ID = obj.OfficeAutomation_Document_TotalRev_ID;
            Baseobj.OfficeAutomation_Document_TotalRev_MainID = obj.OfficeAutomation_Document_TotalRev_MainID;
            Baseobj.OfficeAutomation_Document_TotalRev_Apply = obj.OfficeAutomation_Document_TotalRev_Apply;
            Baseobj.OfficeAutomation_Document_TotalRev_ApplyDate = obj.OfficeAutomation_Document_TotalRev_ApplyDate;
            Baseobj.OfficeAutomation_Document_TotalRev_ApplyID = obj.OfficeAutomation_Document_TotalRev_ApplyID;

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_TotalRev_MainID]='" + obj.OfficeAutomation_Document_TotalRev_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_TotalRev resultobj;
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
