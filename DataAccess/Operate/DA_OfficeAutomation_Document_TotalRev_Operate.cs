using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_TotalRev_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_TotalRev _objMessage = null;
        
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_TotalRev> dal;
        public DA_OfficeAutomation_Document_TotalRev_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_TotalRev>();
        }
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_TotalRev]"
                                                        + "           ([OfficeAutomation_Document_TotalRev_ID]"
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
                                                        + "           ,[OfficeAutomation_Document_TotalRev_Part3OtherBudget]"
                                                        + "           ,[OfficeAutomation_Document_TotalRev_Part3OtherRemark]"
                                                        + "           ,[OfficeAutomation_Document_TotalRev_FireRemark])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_TotalRev_ID"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_MainID"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Apply"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Department"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Subject"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ReplyPhone"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ReplyFax"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Address"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_BranchName"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_BSquare"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_CSquare"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Rent"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Percent"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_1hYear"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_2hYear"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_3hYear"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_4hYear"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_5hYear"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_RentYear"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_RentMonth"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_RentBeginDate"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_RentEndDate"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_OBeginDate"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_OEndDate"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_OCount"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_McoastMonth"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Mcoast"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_MProvide"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_WaterCost"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ElectCost"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_WEProvide"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Tbranch"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Tcoast"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_1BC"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_FirstRentBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_RentTaxBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_FirstMonthBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_DepositBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_WEDBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ManageBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_SendBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_OtherBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_1SumBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_2BC"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_PhotoBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_DecorateProjectBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_FurnitureBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_StationeryBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_AirConditioningBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ConputerBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_SignatureBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_CertificateBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_OpticalFiberBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ForestBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_MonthCleanBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_YearInsuranceBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_RegistrationBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_2SumBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_3BC"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_BasisBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_AddElectricBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_FireBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_3SumBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_FirstRentRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_RentTaxRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_FirstMonthRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_DepositRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_WEDRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ManageRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_SendRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_OtherRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_PhotoRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_DecorateProjectRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_FurnitureRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_StationeryRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_AirConditioningRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ConputerRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_SignatureRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_CertificateRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_OpticalFiberRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_ForestRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_MonthCleanRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_YearInsuranceRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_RegistrationRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_BasisRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_AddElectricRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Part3OtherBudget"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_Part3OtherRemark"
                                                        + "           ,@OfficeAutomation_Document_TotalRev_FireRemark)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_TotalRev)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ReplyFax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ReplyFax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_BranchName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_BranchName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_BSquare", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_BSquare));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_CSquare", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_CSquare));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Rent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Rent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Percent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Percent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_1hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_1hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_2hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_2hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_3hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_3hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_4hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_4hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_5hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_5hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_McoastMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_McoastMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Mcoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Mcoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_MProvide", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_MProvide));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_WaterCost", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_WaterCost));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ElectCost", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ElectCost));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_WEProvide", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_WEProvide));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Tbranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Tbranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Tcoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Tcoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_1BC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_1BC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FirstRentBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FirstRentBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentTaxBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentTaxBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FirstMonthBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FirstMonthBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_DepositBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_DepositBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_WEDBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_WEDBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ManageBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ManageBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_SendBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_SendBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OtherBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OtherBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_1SumBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_1SumBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_2BC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_2BC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_PhotoBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_PhotoBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_DecorateProjectBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_DecorateProjectBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FurnitureBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FurnitureBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_StationeryBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_StationeryBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_AirConditioningBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_AirConditioningBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ConputerBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ConputerBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_SignatureBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_SignatureBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_CertificateBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_CertificateBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OpticalFiberBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OpticalFiberBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ForestBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ForestBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_MonthCleanBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_MonthCleanBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_YearInsuranceBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_YearInsuranceBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RegistrationBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RegistrationBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_2SumBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_2SumBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_3BC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_3BC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_BasisBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_BasisBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_AddElectricBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_AddElectricBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FireBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FireBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_3SumBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_3SumBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FirstRentRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FirstRentRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentTaxRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentTaxRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FirstMonthRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FirstMonthRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_DepositRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_DepositRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_WEDRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_WEDRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ManageRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ManageRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_SendRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_SendRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OtherRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OtherRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_PhotoRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_PhotoRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_DecorateProjectRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_DecorateProjectRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FurnitureRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FurnitureRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_StationeryRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_StationeryRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_AirConditioningRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_AirConditioningRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ConputerRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ConputerRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_SignatureRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_SignatureRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_CertificateRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_CertificateRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OpticalFiberRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OpticalFiberRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ForestRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ForestRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_MonthCleanRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_MonthCleanRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_YearInsuranceRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_YearInsuranceRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RegistrationRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RegistrationRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_BasisRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_BasisRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_AddElectricRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_AddElectricRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FireRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FireRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Part3OtherBudget", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Part3OtherBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Part3OtherRemark",this._objMessage.OfficeAutomation_Document_TotalRev_Part3OtherRemark));
                
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public bool Delete(string mainID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_TotalRev_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sMainID", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, mainID));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }

                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }
        #endregion

        #region 更新记录
        public override bool Update(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_TotalRev]"
                                + "         SET [OfficeAutomation_Document_TotalRev_ApplyID] = @OfficeAutomation_Document_TotalRev_ApplyID"
                                + "         ,[OfficeAutomation_Document_TotalRev_Department] = @OfficeAutomation_Document_TotalRev_Department"
                                + "         ,[OfficeAutomation_Document_TotalRev_Subject] = @OfficeAutomation_Document_TotalRev_Subject"
                                + "         ,[OfficeAutomation_Document_TotalRev_ReplyPhone] = @OfficeAutomation_Document_TotalRev_ReplyPhone"
                                + "         ,[OfficeAutomation_Document_TotalRev_ReplyFax] = @OfficeAutomation_Document_TotalRev_ReplyFax"
                                + "         ,[OfficeAutomation_Document_TotalRev_Address] = @OfficeAutomation_Document_TotalRev_Address"
                                + "         ,[OfficeAutomation_Document_TotalRev_BranchName] = @OfficeAutomation_Document_TotalRev_BranchName"
                                + "         ,[OfficeAutomation_Document_TotalRev_BSquare] = @OfficeAutomation_Document_TotalRev_BSquare"
                                + "         ,[OfficeAutomation_Document_TotalRev_CSquare] = @OfficeAutomation_Document_TotalRev_CSquare"
                                + "         ,[OfficeAutomation_Document_TotalRev_Rent] = @OfficeAutomation_Document_TotalRev_Rent"
                                + "         ,[OfficeAutomation_Document_TotalRev_Percent] = @OfficeAutomation_Document_TotalRev_Percent"
                                + "         ,[OfficeAutomation_Document_TotalRev_1hYear] = @OfficeAutomation_Document_TotalRev_1hYear"
                                + "         ,[OfficeAutomation_Document_TotalRev_2hYear] = @OfficeAutomation_Document_TotalRev_2hYear"
                                + "         ,[OfficeAutomation_Document_TotalRev_3hYear] = @OfficeAutomation_Document_TotalRev_3hYear"
                                + "         ,[OfficeAutomation_Document_TotalRev_4hYear] = @OfficeAutomation_Document_TotalRev_4hYear"
                                + "         ,[OfficeAutomation_Document_TotalRev_5hYear] = @OfficeAutomation_Document_TotalRev_5hYear"
                                + "         ,[OfficeAutomation_Document_TotalRev_RentYear] = @OfficeAutomation_Document_TotalRev_RentYear"
                                + "         ,[OfficeAutomation_Document_TotalRev_RentMonth] = @OfficeAutomation_Document_TotalRev_RentMonth"
                                + "         ,[OfficeAutomation_Document_TotalRev_RentBeginDate] = @OfficeAutomation_Document_TotalRev_RentBeginDate"
                                + "         ,[OfficeAutomation_Document_TotalRev_RentEndDate] = @OfficeAutomation_Document_TotalRev_RentEndDate"
                                + "         ,[OfficeAutomation_Document_TotalRev_OBeginDate] = @OfficeAutomation_Document_TotalRev_OBeginDate"
                                + "         ,[OfficeAutomation_Document_TotalRev_OEndDate] = @OfficeAutomation_Document_TotalRev_OEndDate"
                                + "         ,[OfficeAutomation_Document_TotalRev_OCount] = @OfficeAutomation_Document_TotalRev_OCount"
                                + "         ,[OfficeAutomation_Document_TotalRev_McoastMonth] = @OfficeAutomation_Document_TotalRev_McoastMonth"
                                + "         ,[OfficeAutomation_Document_TotalRev_Mcoast] = @OfficeAutomation_Document_TotalRev_Mcoast"
                                + "         ,[OfficeAutomation_Document_TotalRev_MProvide] = @OfficeAutomation_Document_TotalRev_MProvide"
                                + "         ,[OfficeAutomation_Document_TotalRev_WaterCost] = @OfficeAutomation_Document_TotalRev_WaterCost"
                                + "         ,[OfficeAutomation_Document_TotalRev_ElectCost] = @OfficeAutomation_Document_TotalRev_ElectCost"
                                + "         ,[OfficeAutomation_Document_TotalRev_WEProvide] = @OfficeAutomation_Document_TotalRev_WEProvide"
                                + "         ,[OfficeAutomation_Document_TotalRev_Tbranch] = @OfficeAutomation_Document_TotalRev_Tbranch"
                                + "         ,[OfficeAutomation_Document_TotalRev_Tcoast] = @OfficeAutomation_Document_TotalRev_Tcoast"
                                + "         ,[OfficeAutomation_Document_TotalRev_1BC] = @OfficeAutomation_Document_TotalRev_1BC"
                                + "         ,[OfficeAutomation_Document_TotalRev_FirstRentBudget] = @OfficeAutomation_Document_TotalRev_FirstRentBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_RentTaxBudget] = @OfficeAutomation_Document_TotalRev_RentTaxBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_FirstMonthBudget] = @OfficeAutomation_Document_TotalRev_FirstMonthBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_DepositBudget] = @OfficeAutomation_Document_TotalRev_DepositBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_WEDBudget] = @OfficeAutomation_Document_TotalRev_WEDBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_ManageBudget] = @OfficeAutomation_Document_TotalRev_ManageBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_SendBudget] = @OfficeAutomation_Document_TotalRev_SendBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_OtherBudget] = @OfficeAutomation_Document_TotalRev_OtherBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_1SumBudget] = @OfficeAutomation_Document_TotalRev_1SumBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_2BC] = @OfficeAutomation_Document_TotalRev_2BC"
                                + "         ,[OfficeAutomation_Document_TotalRev_PhotoBudget] = @OfficeAutomation_Document_TotalRev_PhotoBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_DecorateProjectBudget] = @OfficeAutomation_Document_TotalRev_DecorateProjectBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget] = @OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_FurnitureBudget] = @OfficeAutomation_Document_TotalRev_FurnitureBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_StationeryBudget] = @OfficeAutomation_Document_TotalRev_StationeryBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_AirConditioningBudget] = @OfficeAutomation_Document_TotalRev_AirConditioningBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_ConputerBudget] = @OfficeAutomation_Document_TotalRev_ConputerBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_SignatureBudget] = @OfficeAutomation_Document_TotalRev_SignatureBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_CertificateBudget] = @OfficeAutomation_Document_TotalRev_CertificateBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_OpticalFiberBudget] = @OfficeAutomation_Document_TotalRev_OpticalFiberBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_ForestBudget] = @OfficeAutomation_Document_TotalRev_ForestBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_MonthCleanBudget] = @OfficeAutomation_Document_TotalRev_MonthCleanBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_YearInsuranceBudget] = @OfficeAutomation_Document_TotalRev_YearInsuranceBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_RegistrationBudget] = @OfficeAutomation_Document_TotalRev_RegistrationBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_2SumBudget] = @OfficeAutomation_Document_TotalRev_2SumBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_3BC] = @OfficeAutomation_Document_TotalRev_3BC"
                                + "         ,[OfficeAutomation_Document_TotalRev_BasisBudget] = @OfficeAutomation_Document_TotalRev_BasisBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_AddElectricBudget] = @OfficeAutomation_Document_TotalRev_AddElectricBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_FireBudget] = @OfficeAutomation_Document_TotalRev_FireBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_3SumBudget] = @OfficeAutomation_Document_TotalRev_3SumBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_FirstRentRemark] = @OfficeAutomation_Document_TotalRev_FirstRentRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_RentTaxRemark] = @OfficeAutomation_Document_TotalRev_RentTaxRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_FirstMonthRemark] = @OfficeAutomation_Document_TotalRev_FirstMonthRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_DepositRemark] = @OfficeAutomation_Document_TotalRev_DepositRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_WEDRemark] = @OfficeAutomation_Document_TotalRev_WEDRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_ManageRemark] = @OfficeAutomation_Document_TotalRev_ManageRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_SendRemark] = @OfficeAutomation_Document_TotalRev_SendRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_OtherRemark] = @OfficeAutomation_Document_TotalRev_OtherRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_PhotoRemark] = @OfficeAutomation_Document_TotalRev_PhotoRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_DecorateProjectRemark] = @OfficeAutomation_Document_TotalRev_DecorateProjectRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark] = @OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_FurnitureRemark] = @OfficeAutomation_Document_TotalRev_FurnitureRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_StationeryRemark] = @OfficeAutomation_Document_TotalRev_StationeryRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_AirConditioningRemark] = @OfficeAutomation_Document_TotalRev_AirConditioningRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_ConputerRemark] = @OfficeAutomation_Document_TotalRev_ConputerRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_SignatureRemark] = @OfficeAutomation_Document_TotalRev_SignatureRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_CertificateRemark] = @OfficeAutomation_Document_TotalRev_CertificateRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_OpticalFiberRemark] = @OfficeAutomation_Document_TotalRev_OpticalFiberRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_ForestRemark] = @OfficeAutomation_Document_TotalRev_ForestRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_MonthCleanRemark] = @OfficeAutomation_Document_TotalRev_MonthCleanRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_YearInsuranceRemark] = @OfficeAutomation_Document_TotalRev_YearInsuranceRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_RegistrationRemark] = @OfficeAutomation_Document_TotalRev_RegistrationRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_BasisRemark] = @OfficeAutomation_Document_TotalRev_BasisRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_AddElectricRemark] = @OfficeAutomation_Document_TotalRev_AddElectricRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_FireRemark] = @OfficeAutomation_Document_TotalRev_FireRemark"
                                + "         ,[OfficeAutomation_Document_TotalRev_ID] = @OfficeAutomation_Document_TotalRev_ID"
                                + "         ,[OfficeAutomation_Document_TotalRev_MainID] = @OfficeAutomation_Document_TotalRev_MainID"
                                + "         ,[OfficeAutomation_Document_TotalRev_Part3OtherBudget] = @OfficeAutomation_Document_TotalRev_Part3OtherBudget"
                                + "         ,[OfficeAutomation_Document_TotalRev_Part3OtherRemark] = @OfficeAutomation_Document_TotalRev_Part3OtherRemark"
                                + "         WHERE [OfficeAutomation_Document_TotalRev_ID]=@OfficeAutomation_Document_TotalRev_ID"
                                + "         AND [OfficeAutomation_Document_TotalRev_MainID]=@OfficeAutomation_Document_TotalRev_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_TotalRev)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ReplyFax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ReplyFax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_BranchName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_BranchName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_BSquare", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_BSquare));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_CSquare", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_CSquare));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Rent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Rent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Percent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Percent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_1hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_1hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_2hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_2hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_3hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_3hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_4hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_4hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_5hYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_5hYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_McoastMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_McoastMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Mcoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Mcoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_MProvide", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_MProvide));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_WaterCost", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_WaterCost));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ElectCost", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ElectCost));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_WEProvide", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_WEProvide));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Tbranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Tbranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Tcoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Tcoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_1BC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_1BC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FirstRentBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FirstRentBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentTaxBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentTaxBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FirstMonthBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FirstMonthBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_DepositBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_DepositBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_WEDBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_WEDBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ManageBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ManageBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_SendBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_SendBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OtherBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OtherBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_1SumBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_1SumBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_2BC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_2BC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_PhotoBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_PhotoBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_DecorateProjectBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_DecorateProjectBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FurnitureBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FurnitureBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_StationeryBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_StationeryBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_AirConditioningBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_AirConditioningBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ConputerBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ConputerBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_SignatureBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_SignatureBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_CertificateBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_CertificateBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OpticalFiberBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OpticalFiberBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ForestBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ForestBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_MonthCleanBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_MonthCleanBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_YearInsuranceBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_YearInsuranceBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RegistrationBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RegistrationBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_2SumBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_2SumBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_3BC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_3BC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_BasisBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_BasisBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_AddElectricBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_AddElectricBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FireBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FireBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_3SumBudget", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_3SumBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FirstRentRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FirstRentRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RentTaxRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RentTaxRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FirstMonthRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FirstMonthRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_DepositRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_DepositRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_WEDRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_WEDRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ManageRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ManageRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_SendRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_SendRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OtherRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OtherRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_PhotoRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_PhotoRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_DecorateProjectRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_DecorateProjectRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FurnitureRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FurnitureRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_StationeryRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_StationeryRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_AirConditioningRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_AirConditioningRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ConputerRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ConputerRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_SignatureRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_SignatureRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_CertificateRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_CertificateRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_OpticalFiberRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_OpticalFiberRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ForestRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ForestRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_MonthCleanRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_MonthCleanRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_YearInsuranceRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_YearInsuranceRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_RegistrationRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_RegistrationRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_BasisRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_BasisRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_AddElectricRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_AddElectricRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_FireRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_FireRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Part3OtherBudget", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_TotalRev_Part3OtherBudget));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_TotalRev_Part3OtherRemark", this._objMessage.OfficeAutomation_Document_TotalRev_Part3OtherRemark));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }
        #endregion

        #region 自定义方法
        public T_OfficeAutomation_Document_TotalRev Add(T_OfficeAutomation_Document_TotalRev t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_TotalRev Edit(T_OfficeAutomation_Document_TotalRev t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_TotalRev t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_TotalRev GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_TotalRev>(where);
        }
        #endregion
    }
}
