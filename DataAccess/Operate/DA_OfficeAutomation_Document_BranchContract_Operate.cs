using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BranchContract_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_BranchContract _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BranchContract> dal;
        #endregion
        public DA_OfficeAutomation_Document_BranchContract_Operate() 
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_BranchContract>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BranchContract]"
                                                        + "           ([OfficeAutomation_Document_BranchContract_ID]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_MainID]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_Apply]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_Department]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_Telephone]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_Name]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ApplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_Branch]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ContractEndDate]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LastMonthRent]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_FirstYearRent]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_RentAmplitude]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ContractPeriod]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_BranchSuqare]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_BranchAddress]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_StampDuty]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_RentDP]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ManagementDP]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ManagementDPAnother]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LeaseDeposit]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_OtherFees]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ResponsibleName]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ResponsibleCall]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_RecentlyBeginData]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_RecentlyEndData]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_CumulativePerformance]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_CumulativeProfits]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LastYear]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LastYearResults]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LastYearProfit]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ThisYearAsOfData]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ThisYearCP]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_ThisYearPS2]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_AmortizationBeginData]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_AmortizationMoney]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_AmortizationEndData]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_StatisticalBeginData]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_StatisticalEndData]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumCount]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumGzspsNum]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumGzspsRate]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumEveryNum]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumEveryRate]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumRichNum]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumRichRate]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumYuFengNum]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumYuFengRate]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumFreeNum]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumFreeRate]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumOtherNum]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumOtherRate]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_SumQFangNum]"
                                                       + "           ,[OfficeAutomation_Document_BranchContract_SumQFangRate]"
                                                       + "           ,[OfficeAutomation_Document_BranchContract_AreaPart]"
                                                       + "           ,[OfficeAutomation_Document_BranchContract_AreaSumOfBuild]"
                                                       + "           ,[OfficeAutomation_Document_BranchContract_AreaCNo]"
                                                       + "           ,[OfficeAutomation_Document_BranchContract_AreaCRate]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_OtherSummy]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_Reason]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementContent]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementPS]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementAward]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementPercentage]"
                                                        + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementCharge])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_BranchContract_ID"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_MainID"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_Apply"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_Department"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_Telephone"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_Name"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ApplyPhone"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_Branch"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ContractEndDate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LastMonthRent"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_FirstYearRent"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_RentAmplitude"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ContractPeriod"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_BranchSuqare"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_BranchAddress"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_StampDuty"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_RentDP"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ManagementDP"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ManagementDPAnother"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LeaseDeposit"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_OtherFees"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ResponsibleName"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ResponsibleCall"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_RecentlyBeginData"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_RecentlyEndData"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_CumulativePerformance"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_CumulativeProfits"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LastYear"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LastYearResults"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LastYearProfit"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ThisYearAsOfData"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ThisYearCP"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_ThisYearPS2"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_AmortizationBeginData"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_AmortizationMoney"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_AmortizationEndData"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_StatisticalBeginData"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_StatisticalEndData"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumCount"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumGzspsNum"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumGzspsRate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumEveryNum"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumEveryRate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumRichNum"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumRichRate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumYuFengNum"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumYuFengRate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumFreeNum"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumFreeRate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumOtherNum"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumOtherRate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumQFangNum"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_SumQFangRate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_AreaPart"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_AreaSumOfBuild"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_AreaCNo"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_AreaCRate"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_OtherSummy"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_Reason"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LossAgreementContent"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LossAgreementPS"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LossAgreementAward"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LossAgreementPercentage"
                                                        + "           ,@OfficeAutomation_Document_BranchContract_LossAgreementCharge)";






            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BranchContract)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Telephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Telephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ApplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ApplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ContractEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ContractEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LastMonthRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LastMonthRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_FirstYearRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_FirstYearRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_RentAmplitude", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_RentAmplitude));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ContractPeriod", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ContractPeriod));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_BranchSuqare", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_BranchSuqare));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_BranchAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_BranchAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_StampDuty", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_StampDuty));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_RentDP", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_RentDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ManagementDP", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ManagementDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ManagementDPAnother", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ManagementDPAnother));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LeaseDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LeaseDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_OtherFees", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_OtherFees));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ResponsibleName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ResponsibleName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ResponsibleCall", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ResponsibleCall));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_RecentlyBeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_RecentlyBeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_RecentlyEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_RecentlyEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_CumulativePerformance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_CumulativePerformance));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_CumulativeProfits", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_CumulativeProfits));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LastYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LastYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LastYearResults", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LastYearResults));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LastYearProfit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LastYearProfit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ThisYearAsOfData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ThisYearAsOfData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ThisYearCP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ThisYearCP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ThisYearPS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ThisYearPS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AmortizationBeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AmortizationBeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AmortizationMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AmortizationMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AmortizationEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AmortizationEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_StatisticalBeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_StatisticalBeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_StatisticalEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_StatisticalEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumGzspsNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumGzspsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumGzspsRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumGzspsRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumEveryNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumEveryNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumEveryRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumEveryRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumRichNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumRichNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumRichRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumRichRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumYuFengNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumYuFengNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumYuFengRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumYuFengRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumFreeNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumFreeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumFreeRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumFreeRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumOtherNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumOtherNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumOtherRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumOtherRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumQFangNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumQFangNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumQFangRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumQFangRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AreaPart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AreaPart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AreaSumOfBuild", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AreaSumOfBuild));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AreaCNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AreaCNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AreaCRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AreaCRate));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_OtherSummy", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_OtherSummy));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Reason));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementContent) ? (Object)DBNull.Value : this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementContent));
                if (this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementPS == null)
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementPS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value)); }
                else
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementPS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementPS)); }
                if (this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementAward == null)
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementAward", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value)); }
                else
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementAward", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementAward)); }
                if (this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementPercentage == null)
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementPercentage", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value)); }
                else
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementPercentage", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementPercentage)); }

                if (this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementCharge == null)
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementCharge", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value)); }
                else
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementCharge", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementCharge)); }
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
            cmdToExecute.CommandText = "dbo.[pr_BranchContract_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BranchContract]"
                                                        + "     SET  [OfficeAutomation_Document_BranchContract_ApplyID]=@OfficeAutomation_Document_BranchContract_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_Department]=@OfficeAutomation_Document_BranchContract_Department"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_Telephone]=@OfficeAutomation_Document_BranchContract_Telephone"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_Name]=@OfficeAutomation_Document_BranchContract_Name"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ApplyPhone]=@OfficeAutomation_Document_BranchContract_ApplyPhone"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_Branch]=@OfficeAutomation_Document_BranchContract_Branch"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ContractEndDate]=@OfficeAutomation_Document_BranchContract_ContractEndDate"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LastMonthRent]=@OfficeAutomation_Document_BranchContract_LastMonthRent"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_FirstYearRent]=@OfficeAutomation_Document_BranchContract_FirstYearRent"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_RentAmplitude]=@OfficeAutomation_Document_BranchContract_RentAmplitude"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ContractPeriod]=@OfficeAutomation_Document_BranchContract_ContractPeriod"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_BranchSuqare]=@OfficeAutomation_Document_BranchContract_BranchSuqare"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_BranchAddress]=@OfficeAutomation_Document_BranchContract_BranchAddress"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_StampDuty]=@OfficeAutomation_Document_BranchContract_StampDuty"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_RentDP]=@OfficeAutomation_Document_BranchContract_RentDP"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ManagementDP]=@OfficeAutomation_Document_BranchContract_ManagementDP"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ManagementDPAnother]=@OfficeAutomation_Document_BranchContract_ManagementDPAnother"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LeaseDeposit]=@OfficeAutomation_Document_BranchContract_LeaseDeposit"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_OtherFees]=@OfficeAutomation_Document_BranchContract_OtherFees"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ResponsibleName]=@OfficeAutomation_Document_BranchContract_ResponsibleName"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ResponsibleCall]=@OfficeAutomation_Document_BranchContract_ResponsibleCall"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_RecentlyBeginData]=@OfficeAutomation_Document_BranchContract_RecentlyBeginData"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_RecentlyEndData]=@OfficeAutomation_Document_BranchContract_RecentlyEndData"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_CumulativePerformance]=@OfficeAutomation_Document_BranchContract_CumulativePerformance"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_CumulativeProfits]=@OfficeAutomation_Document_BranchContract_CumulativeProfits"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LastYear]=@OfficeAutomation_Document_BranchContract_LastYear"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LastYearResults]=@OfficeAutomation_Document_BranchContract_LastYearResults"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LastYearProfit]=@OfficeAutomation_Document_BranchContract_LastYearProfit"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ThisYearAsOfData]=@OfficeAutomation_Document_BranchContract_ThisYearAsOfData"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData]=@OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ThisYearCP]=@OfficeAutomation_Document_BranchContract_ThisYearCP"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_ThisYearPS2]=@OfficeAutomation_Document_BranchContract_ThisYearPS2"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_AmortizationBeginData]=@OfficeAutomation_Document_BranchContract_AmortizationBeginData"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_AmortizationMoney]=@OfficeAutomation_Document_BranchContract_AmortizationMoney"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_AmortizationEndData]=@OfficeAutomation_Document_BranchContract_AmortizationEndData"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_StatisticalBeginData]=@OfficeAutomation_Document_BranchContract_StatisticalBeginData"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_StatisticalEndData]=@OfficeAutomation_Document_BranchContract_StatisticalEndData"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumCount]=@OfficeAutomation_Document_BranchContract_SumCount"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumGzspsNum]=@OfficeAutomation_Document_BranchContract_SumGzspsNum"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumGzspsRate]=@OfficeAutomation_Document_BranchContract_SumGzspsRate"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumEveryNum]=@OfficeAutomation_Document_BranchContract_SumEveryNum"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumEveryRate]=@OfficeAutomation_Document_BranchContract_SumEveryRate"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumRichNum]=@OfficeAutomation_Document_BranchContract_SumRichNum"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumRichRate]=@OfficeAutomation_Document_BranchContract_SumRichRate"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumYuFengNum]=@OfficeAutomation_Document_BranchContract_SumYuFengNum"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumYuFengRate]=@OfficeAutomation_Document_BranchContract_SumYuFengRate"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumFreeNum]=@OfficeAutomation_Document_BranchContract_SumFreeNum"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumFreeRate]=@OfficeAutomation_Document_BranchContract_SumFreeRate"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumOtherNum]=@OfficeAutomation_Document_BranchContract_SumOtherNum"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumOtherRate]=@OfficeAutomation_Document_BranchContract_SumOtherRate"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumQFangNum]=@OfficeAutomation_Document_BranchContract_SumQFangNum"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_SumQFangRate]=@OfficeAutomation_Document_BranchContract_SumQFangRate"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_AreaPart]=@OfficeAutomation_Document_BranchContract_AreaPart"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_AreaSumOfBuild]=@OfficeAutomation_Document_BranchContract_AreaSumOfBuild"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_AreaCNo]=@OfficeAutomation_Document_BranchContract_AreaCNo"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_AreaCRate]=@OfficeAutomation_Document_BranchContract_AreaCRate"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_OtherSummy]=@OfficeAutomation_Document_BranchContract_OtherSummy"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_Reason]=@OfficeAutomation_Document_BranchContract_Reason"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LossAgreementContent]=@OfficeAutomation_Document_BranchContract_LossAgreementContent"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LossAgreementPS]=@OfficeAutomation_Document_BranchContract_LossAgreementPS"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LossAgreementAward]=@OfficeAutomation_Document_BranchContract_LossAgreementAward"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LossAgreementPercentage]=@OfficeAutomation_Document_BranchContract_LossAgreementPercentage"
                                                        + "            ,[OfficeAutomation_Document_BranchContract_LossAgreementCharge]=@OfficeAutomation_Document_BranchContract_LossAgreementCharge"
                                                        + " WHERE [OfficeAutomation_Document_BranchContract_ID]=@OfficeAutomation_Document_BranchContract_ID"
                                                        + "     AND [OfficeAutomation_Document_BranchContract_MainID] = @OfficeAutomation_Document_BranchContract_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BranchContract)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Telephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Telephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ApplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ApplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ContractEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ContractEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LastMonthRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LastMonthRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_FirstYearRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_FirstYearRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_RentAmplitude", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_RentAmplitude));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ContractPeriod", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ContractPeriod));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_BranchSuqare", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_BranchSuqare));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_BranchAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_BranchAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_StampDuty", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_StampDuty));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_RentDP", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_RentDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ManagementDP", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ManagementDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ManagementDPAnother", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ManagementDPAnother));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LeaseDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LeaseDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_OtherFees", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_OtherFees));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ResponsibleName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ResponsibleName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ResponsibleCall", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ResponsibleCall));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_RecentlyBeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_RecentlyBeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_RecentlyEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_RecentlyEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_CumulativePerformance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_CumulativePerformance));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_CumulativeProfits", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_CumulativeProfits));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LastYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LastYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LastYearResults", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LastYearResults));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LastYearProfit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LastYearProfit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ThisYearAsOfData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ThisYearAsOfData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ThisYearCP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ThisYearCP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ThisYearPS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ThisYearPS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AmortizationBeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AmortizationBeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AmortizationMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AmortizationMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AmortizationEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AmortizationEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_StatisticalBeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_StatisticalBeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_StatisticalEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_StatisticalEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumGzspsNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumGzspsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumGzspsRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumGzspsRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumEveryNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumEveryNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumEveryRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumEveryRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumRichNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumRichNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumRichRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumRichRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumYuFengNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumYuFengNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumYuFengRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumYuFengRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumFreeNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumFreeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumFreeRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumFreeRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumOtherNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumOtherNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumOtherRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumOtherRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumQFangNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumQFangNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SumQFangRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SumQFangRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AreaPart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AreaPart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AreaSumOfBuild", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AreaSumOfBuild));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AreaCNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AreaCNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AreaCRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AreaCRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_OtherSummy", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_OtherSummy));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementContent));

                if (this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementPS == null)
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementPS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value)); }
                else
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementPS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementPS)); }
                if (this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementAward == null)
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementAward", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value)); }
                else
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementAward", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementAward)); }
                if (this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementPercentage == null)
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementPercentage", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value)); }
                else
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementPercentage", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementPercentage)); }

                if (this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementCharge == null)
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementCharge", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value)); }
                else
                { cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_LossAgreementCharge", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_LossAgreementCharge));}
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

        #region 自定义
        public T_OfficeAutomation_Document_BranchContract Add(T_OfficeAutomation_Document_BranchContract t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_BranchContract Edit(T_OfficeAutomation_Document_BranchContract t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_BranchContract t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_BranchContract GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_BranchContract>(where);
        }
        #endregion 
    }
}
