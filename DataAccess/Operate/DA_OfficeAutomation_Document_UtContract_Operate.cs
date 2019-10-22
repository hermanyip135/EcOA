using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtContract_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_UtContract _objMessage = null;
        private DAL.DalBase<T_OfficeAutomation_Document_UtContract> dal;
        #endregion
        public DA_OfficeAutomation_Document_UtContract_Operate() 
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_UtContract>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtContract]"
                                                        + "           ([OfficeAutomation_Document_UtContract_ID]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_MainID]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Apply]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Department]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Name1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Name2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Developer]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_GroupName]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_BaseAgent]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_BaseAgentOther]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_DealType]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ProjectArea]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_LastBeginDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_LastEndDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_LastSumNum]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Turnover]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_LastResults]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CumulativeBeginDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CumulativeEndDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CumulativeNum]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_SumTurnover]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CumulativeResults]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_DealOfficeTypeIDs]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsStree]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsMarking]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsBusiness]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsBackRent]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_txtProjectAddress]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_txtReportAddress]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_DeveloperContacter]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_DeveloperContacterPosition]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_DeveloperContacterPhone]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaFollowerContacter]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaCheckDataer]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaCheckDataerCode]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaCheckDataerPhone]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Square]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_SetNumber]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_UnitPrice]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_TotalPrice]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsCoopWithECommerce]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CoopWithE1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CoopWithE2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CoopWithE3]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CoopWithE4]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CoopWithE5]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ECommerceName]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ECommerceName2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ProjFear]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ProjSum1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ProjSum2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ProjSum3]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_OwnerCommFixScale]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_OwnerCommAgent]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ClientCommFixScale]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ClientCommAgent]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_EBComm]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_EBCommAgent]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Remark]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Jubar1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Jubar2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Jubar3]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_HaveSingleReward]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_RewardSignHave]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AnotherRewardC]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_DeveloperConditions]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaConditions]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_PayRewardWay]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsMyPay]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaComfirn]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ReturnBackDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_TermsOfContract]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_TermsOfMajorIssues]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AgentStartDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AgentEndDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ClientGuardStartDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ClientGuardEndDate]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsProjEarlyCommBack]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_OweCommSum]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaReason]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_OrdMoney]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_OrdTaker]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_JOrT]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_SamePlaceXX1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AgencyFee1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsCashPrize1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CashPrize1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsPFear1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_PFear1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_SamePlaceXX2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AgencyFee2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsCashPrize2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_CashPrize2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsPFear2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_PFear2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_SaleMode]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaScale1]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_MainAreaScale]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_DealAreaScale]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AreaScale]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_MainAreaScale2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_DealAreaScale2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Nre]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AnotherCompany]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Rce]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_WillBreakUp]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_BreakUp]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Ncommissions]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_GuaranTime]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Flange]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Lack]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_Lack6]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_AS2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_MS2]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_PreCompleteNumber]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_PreCompleteMoney]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_PreCompleteComm]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_FtoZ]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_IsUploadF]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_OneOrTwo]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_DealS]"
                                                        + "           ,[OfficeAutomation_Document_UtContract_ddlProjectAddress]"

                                                        + "           ,OfficeAutomation_Document_UtContract_ACName"
                                                        + "           ,OfficeAutomation_Document_UtContract_QRCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_QRDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_YCCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_YCDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_HirePurchase"
                                                        + "           ,OfficeAutomation_Document_UtContract_ZFRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_FQCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_FQDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_HousingFund"
                                                        + "           ,OfficeAutomation_Document_UtContract_Hour"
                                                        + "           ,OfficeAutomation_Document_UtContract_HousDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_Downpayment"
                                                        + "           ,OfficeAutomation_Document_UtContract_SFRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_SFCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_SFDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_Loan"
                                                        + "           ,OfficeAutomation_Document_UtContract_LoanRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_FKCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_FKDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_AJ1CommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_AJ1Deadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_AJ2CommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_AJ2Deadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_AJ3CommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_AJ3Deadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_BACommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_BADeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_YHCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_YHDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_RHCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_RHDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_SXCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_SXDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_DLCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_DLDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_Evidence"
                                                        + "           ,OfficeAutomation_Document_UtContract_YJCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtContract_YJDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtContract_Reserve"
                                                        + "           ,OfficeAutomation_Document_UtContract_IsDirectContract"
                                                        + "           ,OfficeAutomation_Document_UtContract_DirectContractName"
                                                        + "           ,OfficeAutomation_Document_UtContract_DirectContractType"
                                                        + "           ,OfficeAutomation_Document_UtContract_IsPreSale"
                                                        + "           ,OfficeAutomation_Document_UtContract_IslimitBuy"
                                                        + "           ,OfficeAutomation_Document_UtContract_IslimitSign"
                                                        + "           ,OfficeAutomation_Document_UtContract_DiskSource"
            //2019-08-08 CREATE BY HERMAN：新增两列
                                                        + "           ,OfficeAutomation_Document_UtContract_ECommerceReason" 
                                                        + "           ,OfficeAutomation_Document_UtContract_DiscountMoney"

                                                        + ")"
                //      + "           ,OfficeAutomation_Document_UtContract_OverallScale)"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_UtContract_ID"
                                                        + "           ,@OfficeAutomation_Document_UtContract_MainID"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Apply"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Department"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Name1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Name2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Developer"
                                                        + "           ,@OfficeAutomation_Document_UtContract_GroupName"
                                                        + "           ,@OfficeAutomation_Document_UtContract_BaseAgent"
                                                        + "           ,@OfficeAutomation_Document_UtContract_BaseAgentOther"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DealType"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ProjectArea"
                                                        + "           ,@OfficeAutomation_Document_UtContract_LastBeginDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_LastEndDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_LastSumNum"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Turnover"
                                                        + "           ,@OfficeAutomation_Document_UtContract_LastResults"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CumulativeBeginDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CumulativeEndDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CumulativeNum"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SumTurnover"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CumulativeResults"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DealOfficeTypeIDs"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsStree"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsMarking"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsBusiness"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsBackRent"
                                                        + "           ,@OfficeAutomation_Document_UtContract_txtProjectAddress"
                                                        + "           ,@OfficeAutomation_Document_UtContract_txtReportAddress"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DeveloperContacter"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DeveloperContacterPosition"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DeveloperContacterPhone"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaFollowerContacter"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaCheckDataer"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaCheckDataerCode"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaCheckDataerPhone"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Square"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SetNumber"
                                                        + "           ,@OfficeAutomation_Document_UtContract_UnitPrice"
                                                        + "           ,@OfficeAutomation_Document_UtContract_TotalPrice"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsCoopWithECommerce"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CoopWithE1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CoopWithE2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CoopWithE3"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CoopWithE4"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CoopWithE5"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ECommerceName"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ECommerceName2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ProjFear"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ProjSum1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ProjSum2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ProjSum3"
                                                        + "           ,@OfficeAutomation_Document_UtContract_OwnerCommFixScale"
                                                        + "           ,@OfficeAutomation_Document_UtContract_OwnerCommAgent"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ClientCommFixScale"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ClientCommAgent"
                                                        + "           ,@OfficeAutomation_Document_UtContract_EBComm"
                                                        + "           ,@OfficeAutomation_Document_UtContract_EBCommAgent"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Remark"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Jubar1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Jubar2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Jubar3"
                                                        + "           ,@OfficeAutomation_Document_UtContract_HaveSingleReward"
                                                        + "           ,@OfficeAutomation_Document_UtContract_RewardSignHave"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AnotherRewardC"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DeveloperConditions"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaConditions"
                                                        + "           ,@OfficeAutomation_Document_UtContract_PayRewardWay"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsMyPay"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaComfirn"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ReturnBackDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_TermsOfContract"
                                                        + "           ,@OfficeAutomation_Document_UtContract_TermsOfMajorIssues"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AgentStartDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AgentEndDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ClientGuardStartDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ClientGuardEndDate"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsProjEarlyCommBack"
                                                        + "           ,@OfficeAutomation_Document_UtContract_OweCommSum"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaReason"
                                                        + "           ,@OfficeAutomation_Document_UtContract_OrdMoney"
                                                        + "           ,@OfficeAutomation_Document_UtContract_OrdTaker"
                                                        + "           ,@OfficeAutomation_Document_UtContract_JOrT"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SamePlaceXX1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AgencyFee1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsCashPrize1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CashPrize1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsPFear1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_PFear1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SamePlaceXX2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AgencyFee2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsCashPrize2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_CashPrize2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsPFear2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_PFear2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SaleMode"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaScale1"
                                                        + "           ,@OfficeAutomation_Document_UtContract_MainAreaScale"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DealAreaScale"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AreaScale"
                                                        + "           ,@OfficeAutomation_Document_UtContract_MainAreaScale2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DealAreaScale2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Nre"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AnotherCompany"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Rce"
                                                        + "           ,@OfficeAutomation_Document_UtContract_WillBreakUp"
                                                        + "           ,@OfficeAutomation_Document_UtContract_BreakUp"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Ncommissions"
                                                        + "           ,@OfficeAutomation_Document_UtContract_GuaranTime"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Flange"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Lack"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Lack6"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AS2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_MS2"
                                                        + "           ,@OfficeAutomation_Document_UtContract_PreCompleteNumber"
                                                        + "           ,@OfficeAutomation_Document_UtContract_PreCompleteMoney"
                                                        + "           ,@OfficeAutomation_Document_UtContract_PreCompleteComm"
                                                        + "           ,@OfficeAutomation_Document_UtContract_FtoZ"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsUploadF"
                                                        + "           ,@OfficeAutomation_Document_UtContract_OneOrTwo"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DealS"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ddlProjectAddress"

                                                        + "           ,@OfficeAutomation_Document_UtContract_ACName"
                                                        + "           ,@OfficeAutomation_Document_UtContract_QRCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_QRDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_YCCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_YCDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_HirePurchase"
                                                        + "           ,@OfficeAutomation_Document_UtContract_ZFRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_FQCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_FQDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_HousingFund"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Hour"
                                                        + "           ,@OfficeAutomation_Document_UtContract_HousDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Downpayment"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SFRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SFCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SFDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Loan"
                                                        + "           ,@OfficeAutomation_Document_UtContract_LoanRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_FKCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_FKDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AJ1CommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AJ1Deadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AJ2CommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AJ2Deadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AJ3CommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_AJ3Deadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_BACommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_BADeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_YHCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_YHDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_RHCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_RHDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SXCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_SXDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DLCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DLDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Evidence"
                                                        + "           ,@OfficeAutomation_Document_UtContract_YJCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtContract_YJDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtContract_Reserve"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsDirectContract"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DirectContractName"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DirectContractType"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IsPreSale"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IslimitBuy"
                                                        + "           ,@OfficeAutomation_Document_UtContract_IslimitSign"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DiskSource"

            //2019-08-08 CREATE BY HERMAN：新增两列
                                                        + "           ,@OfficeAutomation_Document_UtContract_ECommerceReason"
                                                        + "           ,@OfficeAutomation_Document_UtContract_DiscountMoney"
                                                         + ")";
                                                     //   + "           ,@OfficeAutomation_Document_UtContract_OverallScale)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtContract)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Name1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Name1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Name2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Name2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Developer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Developer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_GroupName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_GroupName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BaseAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BaseAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BaseAgentOther", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BaseAgentOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealType", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjectArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjectArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LastBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LastBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LastEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LastEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LastSumNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LastSumNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Turnover", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Turnover));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LastResults", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LastResults));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CumulativeBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CumulativeBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CumulativeEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CumulativeEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CumulativeNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CumulativeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SumTurnover", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SumTurnover));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CumulativeResults", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CumulativeResults));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsStree", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsStree));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsMarking", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsMarking));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsBusiness", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsBusiness));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsBackRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsBackRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_txtProjectAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_txtProjectAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_txtReportAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_txtReportAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DeveloperContacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DeveloperContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DeveloperContacterPosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DeveloperContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DeveloperContacterPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DeveloperContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaFollowerContacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaFollowerContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaCheckDataer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaCheckDataer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaCheckDataerCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaCheckDataerCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaCheckDataerPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaCheckDataerPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Square", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Square));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SetNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SetNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_UnitPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_UnitPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_TotalPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_TotalPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsCoopWithECommerce", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsCoopWithECommerce));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ECommerceName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ECommerceName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ECommerceName2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ECommerceName2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjFear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjFear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjSum1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjSum1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjSum2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjSum2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjSum3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjSum3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OwnerCommFixScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OwnerCommFixScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OwnerCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OwnerCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ClientCommFixScale", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ClientCommFixScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ClientCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ClientCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_EBComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_EBComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_EBCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_EBCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Remark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Remark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Jubar1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Jubar1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Jubar2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Jubar2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Jubar3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Jubar3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_HaveSingleReward", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_HaveSingleReward));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_RewardSignHave", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_RewardSignHave));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AnotherRewardC", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AnotherRewardC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DeveloperConditions", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DeveloperConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaConditions", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PayRewardWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PayRewardWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsMyPay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsMyPay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaComfirn", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaComfirn));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ReturnBackDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ReturnBackDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_TermsOfContract", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_TermsOfContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_TermsOfMajorIssues", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_TermsOfMajorIssues));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AgentStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AgentStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AgentEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AgentEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ClientGuardStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ClientGuardStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ClientGuardEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ClientGuardEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsProjEarlyCommBack", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsProjEarlyCommBack));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OweCommSum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OweCommSum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaReason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OrdMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OrdMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OrdTaker", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OrdTaker));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_JOrT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_JOrT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SamePlaceXX1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SamePlaceXX1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AgencyFee1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AgencyFee1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsCashPrize1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsCashPrize1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CashPrize1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CashPrize1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsPFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsPFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SamePlaceXX2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SamePlaceXX2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AgencyFee2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AgencyFee2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsCashPrize2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsCashPrize2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CashPrize2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CashPrize2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsPFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsPFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SaleMode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SaleMode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaScale1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaScale1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_MainAreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_MainAreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealAreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealAreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_MainAreaScale2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_MainAreaScale2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealAreaScale2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealAreaScale2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Nre", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Nre));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AnotherCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AnotherCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Rce", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Rce));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_WillBreakUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_WillBreakUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BreakUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BreakUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Ncommissions", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Ncommissions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_GuaranTime", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_GuaranTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Flange", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Flange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Lack", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Lack));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Lack6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Lack6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_MS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_MS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PreCompleteNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PreCompleteNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PreCompleteMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PreCompleteMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PreCompleteComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PreCompleteComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FtoZ", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FtoZ));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsUploadF", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsUploadF));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OneOrTwo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OneOrTwo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ddlProjectAddress", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ddlProjectAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsDirectContract", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsDirectContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DirectContractName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DirectContractName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DirectContractType", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DirectContractType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsPreSale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsPreSale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IslimitBuy", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IslimitBuy));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IslimitSign", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IslimitSign));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DiskSource", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DiskSource));
                #region 2016/10/27 52100 
                 cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ACName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ACName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_QRCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_QRCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_QRDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_QRDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YCCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YCCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YCDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YCDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_HirePurchase", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_HirePurchase));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ZFRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ZFRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FQCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FQCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FQDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FQDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_HousingFund", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_HousingFund));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Hour", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Hour));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_HousDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_HousDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Downpayment", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Downpayment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SFRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SFRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SFCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SFCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SFDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SFDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Loan", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Loan));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LoanRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LoanRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FKCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FKCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FKDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FKDeadlines));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ1CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ1CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ1Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ1Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ2CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ2CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ2Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ2Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ3CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ3CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ3Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ3Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BACommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BACommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BADeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BADeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YHCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YHCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YHDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YHDeadlines));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_RHCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_RHCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_RHDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_RHDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SXCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SXCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SXDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SXDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DLCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DLCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DLDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DLDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Evidence", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Evidence));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YJCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YJCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YJDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YJDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Reserve", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Reserve));
                #endregion

                #region [2019-08-08 CREATE BY HERMAN：新增两列]
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ECommerceReason", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ECommerceReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DiscountMoney", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DiscountMoney));
                #endregion

              //  cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OverallScale", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OverallScale));
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
            cmdToExecute.CommandText = "dbo.[pr_UtContract_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtContract]"
                                + "         SET [OfficeAutomation_Document_UtContract_ApplyID] = @OfficeAutomation_Document_UtContract_ApplyID"
                                + "         ,[OfficeAutomation_Document_UtContract_Department] = @OfficeAutomation_Document_UtContract_Department"

                                + "         ,[OfficeAutomation_Document_UtContract_Name1] = @OfficeAutomation_Document_UtContract_Name1"
                                + "         ,[OfficeAutomation_Document_UtContract_Name2] = @OfficeAutomation_Document_UtContract_Name2"
                                + "         ,[OfficeAutomation_Document_UtContract_Developer] = @OfficeAutomation_Document_UtContract_Developer"
                                + "         ,[OfficeAutomation_Document_UtContract_GroupName] = @OfficeAutomation_Document_UtContract_GroupName"
                                + "         ,[OfficeAutomation_Document_UtContract_BaseAgent] = @OfficeAutomation_Document_UtContract_BaseAgent"
                                + "         ,[OfficeAutomation_Document_UtContract_BaseAgentOther] = @OfficeAutomation_Document_UtContract_BaseAgentOther"
                                + "         ,[OfficeAutomation_Document_UtContract_DealType] = @OfficeAutomation_Document_UtContract_DealType"
                                + "         ,[OfficeAutomation_Document_UtContract_ProjectArea] = @OfficeAutomation_Document_UtContract_ProjectArea"
                                + "         ,[OfficeAutomation_Document_UtContract_LastBeginDate] = @OfficeAutomation_Document_UtContract_LastBeginDate"
                                + "         ,[OfficeAutomation_Document_UtContract_LastEndDate] = @OfficeAutomation_Document_UtContract_LastEndDate"
                                + "         ,[OfficeAutomation_Document_UtContract_LastSumNum] = @OfficeAutomation_Document_UtContract_LastSumNum"
                                + "         ,[OfficeAutomation_Document_UtContract_Turnover] = @OfficeAutomation_Document_UtContract_Turnover"
                                + "         ,[OfficeAutomation_Document_UtContract_LastResults] = @OfficeAutomation_Document_UtContract_LastResults"
                                + "         ,[OfficeAutomation_Document_UtContract_CumulativeBeginDate] = @OfficeAutomation_Document_UtContract_CumulativeBeginDate"
                                + "         ,[OfficeAutomation_Document_UtContract_CumulativeEndDate] = @OfficeAutomation_Document_UtContract_CumulativeEndDate"
                                + "         ,[OfficeAutomation_Document_UtContract_CumulativeNum] = @OfficeAutomation_Document_UtContract_CumulativeNum"
                                + "         ,[OfficeAutomation_Document_UtContract_SumTurnover] = @OfficeAutomation_Document_UtContract_SumTurnover"
                                + "         ,[OfficeAutomation_Document_UtContract_CumulativeResults] = @OfficeAutomation_Document_UtContract_CumulativeResults"
                                + "         ,[OfficeAutomation_Document_UtContract_DealOfficeTypeIDs] = @OfficeAutomation_Document_UtContract_DealOfficeTypeIDs"
                                + "         ,[OfficeAutomation_Document_UtContract_IsStree] = @OfficeAutomation_Document_UtContract_IsStree"
                                + "         ,[OfficeAutomation_Document_UtContract_IsMarking] = @OfficeAutomation_Document_UtContract_IsMarking"
                                + "         ,[OfficeAutomation_Document_UtContract_IsBusiness] = @OfficeAutomation_Document_UtContract_IsBusiness"
                                + "         ,[OfficeAutomation_Document_UtContract_IsBackRent] = @OfficeAutomation_Document_UtContract_IsBackRent"
                                + "         ,[OfficeAutomation_Document_UtContract_txtProjectAddress] = @OfficeAutomation_Document_UtContract_txtProjectAddress"
                                + "         ,[OfficeAutomation_Document_UtContract_txtReportAddress] = @OfficeAutomation_Document_UtContract_txtReportAddress"
                                + "         ,[OfficeAutomation_Document_UtContract_DeveloperContacter] = @OfficeAutomation_Document_UtContract_DeveloperContacter"
                                + "         ,[OfficeAutomation_Document_UtContract_DeveloperContacterPosition] = @OfficeAutomation_Document_UtContract_DeveloperContacterPosition"
                                + "         ,[OfficeAutomation_Document_UtContract_DeveloperContacterPhone] = @OfficeAutomation_Document_UtContract_DeveloperContacterPhone"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaFollowerContacter] = @OfficeAutomation_Document_UtContract_AreaFollowerContacter"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition] = @OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone] = @OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaCheckDataer] = @OfficeAutomation_Document_UtContract_AreaCheckDataer"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaCheckDataerCode] = @OfficeAutomation_Document_UtContract_AreaCheckDataerCode"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaCheckDataerPhone] = @OfficeAutomation_Document_UtContract_AreaCheckDataerPhone"
                                + "         ,[OfficeAutomation_Document_UtContract_Square] = @OfficeAutomation_Document_UtContract_Square"
                                + "         ,[OfficeAutomation_Document_UtContract_SetNumber] = @OfficeAutomation_Document_UtContract_SetNumber"
                                + "         ,[OfficeAutomation_Document_UtContract_UnitPrice] = @OfficeAutomation_Document_UtContract_UnitPrice"
                                + "         ,[OfficeAutomation_Document_UtContract_TotalPrice] = @OfficeAutomation_Document_UtContract_TotalPrice"
                                + "         ,[OfficeAutomation_Document_UtContract_IsCoopWithECommerce] = @OfficeAutomation_Document_UtContract_IsCoopWithECommerce"
                                + "         ,[OfficeAutomation_Document_UtContract_CoopWithE1] = @OfficeAutomation_Document_UtContract_CoopWithE1"
                                + "         ,[OfficeAutomation_Document_UtContract_CoopWithE2] = @OfficeAutomation_Document_UtContract_CoopWithE2"
                                + "         ,[OfficeAutomation_Document_UtContract_CoopWithE3] = @OfficeAutomation_Document_UtContract_CoopWithE3"
                                + "         ,[OfficeAutomation_Document_UtContract_CoopWithE4] = @OfficeAutomation_Document_UtContract_CoopWithE4"
                                + "         ,[OfficeAutomation_Document_UtContract_CoopWithE5] = @OfficeAutomation_Document_UtContract_CoopWithE5"
                                + "         ,[OfficeAutomation_Document_UtContract_ECommerceName] = @OfficeAutomation_Document_UtContract_ECommerceName"
                                + "         ,[OfficeAutomation_Document_UtContract_ECommerceName2] = @OfficeAutomation_Document_UtContract_ECommerceName2"
                                + "         ,[OfficeAutomation_Document_UtContract_ProjFear] = @OfficeAutomation_Document_UtContract_ProjFear"
                                + "         ,[OfficeAutomation_Document_UtContract_ProjSum1] = @OfficeAutomation_Document_UtContract_ProjSum1"
                                + "         ,[OfficeAutomation_Document_UtContract_ProjSum2] = @OfficeAutomation_Document_UtContract_ProjSum2"
                                + "         ,[OfficeAutomation_Document_UtContract_ProjSum3] = @OfficeAutomation_Document_UtContract_ProjSum3"
                                + "         ,[OfficeAutomation_Document_UtContract_OwnerCommFixScale] = @OfficeAutomation_Document_UtContract_OwnerCommFixScale"
                                + "         ,[OfficeAutomation_Document_UtContract_OwnerCommAgent] = @OfficeAutomation_Document_UtContract_OwnerCommAgent"
                                + "         ,[OfficeAutomation_Document_UtContract_ClientCommFixScale] = @OfficeAutomation_Document_UtContract_ClientCommFixScale"
                                + "         ,[OfficeAutomation_Document_UtContract_ClientCommAgent] = @OfficeAutomation_Document_UtContract_ClientCommAgent"
                                + "         ,[OfficeAutomation_Document_UtContract_EBComm] = @OfficeAutomation_Document_UtContract_EBComm"
                                + "         ,[OfficeAutomation_Document_UtContract_EBCommAgent] = @OfficeAutomation_Document_UtContract_EBCommAgent"
                                + "         ,[OfficeAutomation_Document_UtContract_Remark] = @OfficeAutomation_Document_UtContract_Remark"
                                + "         ,[OfficeAutomation_Document_UtContract_Jubar1] = @OfficeAutomation_Document_UtContract_Jubar1"
                                + "         ,[OfficeAutomation_Document_UtContract_Jubar2] = @OfficeAutomation_Document_UtContract_Jubar2"
                                + "         ,[OfficeAutomation_Document_UtContract_Jubar3] = @OfficeAutomation_Document_UtContract_Jubar3"
                                + "         ,[OfficeAutomation_Document_UtContract_HaveSingleReward] = @OfficeAutomation_Document_UtContract_HaveSingleReward"
                                + "         ,[OfficeAutomation_Document_UtContract_RewardSignHave] = @OfficeAutomation_Document_UtContract_RewardSignHave"
                                + "         ,[OfficeAutomation_Document_UtContract_AnotherRewardC] = @OfficeAutomation_Document_UtContract_AnotherRewardC"
                                + "         ,[OfficeAutomation_Document_UtContract_DeveloperConditions] = @OfficeAutomation_Document_UtContract_DeveloperConditions"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaConditions] = @OfficeAutomation_Document_UtContract_AreaConditions"
                                + "         ,[OfficeAutomation_Document_UtContract_PayRewardWay] = @OfficeAutomation_Document_UtContract_PayRewardWay"
                                + "         ,[OfficeAutomation_Document_UtContract_IsMyPay] = @OfficeAutomation_Document_UtContract_IsMyPay"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaComfirn] = @OfficeAutomation_Document_UtContract_AreaComfirn"
                                + "         ,[OfficeAutomation_Document_UtContract_ReturnBackDate] = @OfficeAutomation_Document_UtContract_ReturnBackDate"
                                + "         ,[OfficeAutomation_Document_UtContract_TermsOfContract] = @OfficeAutomation_Document_UtContract_TermsOfContract"
                                + "         ,[OfficeAutomation_Document_UtContract_TermsOfMajorIssues] = @OfficeAutomation_Document_UtContract_TermsOfMajorIssues"
                                + "         ,[OfficeAutomation_Document_UtContract_AgentStartDate] = @OfficeAutomation_Document_UtContract_AgentStartDate"
                                + "         ,[OfficeAutomation_Document_UtContract_AgentEndDate] = @OfficeAutomation_Document_UtContract_AgentEndDate"
                                + "         ,[OfficeAutomation_Document_UtContract_ClientGuardStartDate] = @OfficeAutomation_Document_UtContract_ClientGuardStartDate"
                                + "         ,[OfficeAutomation_Document_UtContract_ClientGuardEndDate] = @OfficeAutomation_Document_UtContract_ClientGuardEndDate"
                                + "         ,[OfficeAutomation_Document_UtContract_IsProjEarlyCommBack] = @OfficeAutomation_Document_UtContract_IsProjEarlyCommBack"
                                + "         ,[OfficeAutomation_Document_UtContract_OweCommSum] = @OfficeAutomation_Document_UtContract_OweCommSum"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaReason] = @OfficeAutomation_Document_UtContract_AreaReason"
                                + "         ,[OfficeAutomation_Document_UtContract_OrdMoney] = @OfficeAutomation_Document_UtContract_OrdMoney"
                                + "         ,[OfficeAutomation_Document_UtContract_OrdTaker] = @OfficeAutomation_Document_UtContract_OrdTaker"
                                + "         ,[OfficeAutomation_Document_UtContract_JOrT] = @OfficeAutomation_Document_UtContract_JOrT"
                                + "         ,[OfficeAutomation_Document_UtContract_SamePlaceXX1] = @OfficeAutomation_Document_UtContract_SamePlaceXX1"
                                + "         ,[OfficeAutomation_Document_UtContract_AgencyFee1] = @OfficeAutomation_Document_UtContract_AgencyFee1"
                                + "         ,[OfficeAutomation_Document_UtContract_IsCashPrize1] = @OfficeAutomation_Document_UtContract_IsCashPrize1"
                                + "         ,[OfficeAutomation_Document_UtContract_CashPrize1] = @OfficeAutomation_Document_UtContract_CashPrize1"
                                + "         ,[OfficeAutomation_Document_UtContract_IsPFear1] = @OfficeAutomation_Document_UtContract_IsPFear1"
                                + "         ,[OfficeAutomation_Document_UtContract_PFear1] = @OfficeAutomation_Document_UtContract_PFear1"
                                + "         ,[OfficeAutomation_Document_UtContract_SamePlaceXX2] = @OfficeAutomation_Document_UtContract_SamePlaceXX2"
                                + "         ,[OfficeAutomation_Document_UtContract_AgencyFee2] = @OfficeAutomation_Document_UtContract_AgencyFee2"
                                + "         ,[OfficeAutomation_Document_UtContract_IsCashPrize2] = @OfficeAutomation_Document_UtContract_IsCashPrize2"
                                + "         ,[OfficeAutomation_Document_UtContract_CashPrize2] = @OfficeAutomation_Document_UtContract_CashPrize2"
                                + "         ,[OfficeAutomation_Document_UtContract_IsPFear2] = @OfficeAutomation_Document_UtContract_IsPFear2"
                                + "         ,[OfficeAutomation_Document_UtContract_PFear2] = @OfficeAutomation_Document_UtContract_PFear2"
                                + "         ,[OfficeAutomation_Document_UtContract_SaleMode] = @OfficeAutomation_Document_UtContract_SaleMode"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaScale1] = @OfficeAutomation_Document_UtContract_AreaScale1"
                                + "         ,[OfficeAutomation_Document_UtContract_MainAreaScale] = @OfficeAutomation_Document_UtContract_MainAreaScale"
                                + "         ,[OfficeAutomation_Document_UtContract_DealAreaScale] = @OfficeAutomation_Document_UtContract_DealAreaScale"
                                + "         ,[OfficeAutomation_Document_UtContract_AreaScale] = @OfficeAutomation_Document_UtContract_AreaScale"
                                + "         ,[OfficeAutomation_Document_UtContract_MainAreaScale2] = @OfficeAutomation_Document_UtContract_MainAreaScale2"
                                + "         ,[OfficeAutomation_Document_UtContract_DealAreaScale2] = @OfficeAutomation_Document_UtContract_DealAreaScale2"
                                + "         ,[OfficeAutomation_Document_UtContract_Nre] = @OfficeAutomation_Document_UtContract_Nre"
                                + "         ,[OfficeAutomation_Document_UtContract_AnotherCompany] = @OfficeAutomation_Document_UtContract_AnotherCompany"
                                + "         ,[OfficeAutomation_Document_UtContract_Rce] = @OfficeAutomation_Document_UtContract_Rce"
                                + "         ,[OfficeAutomation_Document_UtContract_WillBreakUp] = @OfficeAutomation_Document_UtContract_WillBreakUp"
                                + "         ,[OfficeAutomation_Document_UtContract_BreakUp] = @OfficeAutomation_Document_UtContract_BreakUp"
                                + "         ,[OfficeAutomation_Document_UtContract_Ncommissions] = @OfficeAutomation_Document_UtContract_Ncommissions"
                                + "         ,[OfficeAutomation_Document_UtContract_GuaranTime] = @OfficeAutomation_Document_UtContract_GuaranTime"
                                + "         ,[OfficeAutomation_Document_UtContract_Flange] = @OfficeAutomation_Document_UtContract_Flange"
                                + "         ,[OfficeAutomation_Document_UtContract_Lack] = @OfficeAutomation_Document_UtContract_Lack"
                                + "         ,[OfficeAutomation_Document_UtContract_Lack6] = @OfficeAutomation_Document_UtContract_Lack6"
                                + "         ,[OfficeAutomation_Document_UtContract_AS2] = @OfficeAutomation_Document_UtContract_AS2"
                                + "         ,[OfficeAutomation_Document_UtContract_MS2] = @OfficeAutomation_Document_UtContract_MS2"
                                + "         ,[OfficeAutomation_Document_UtContract_PreCompleteNumber] = @OfficeAutomation_Document_UtContract_PreCompleteNumber"
                                + "         ,[OfficeAutomation_Document_UtContract_PreCompleteMoney] = @OfficeAutomation_Document_UtContract_PreCompleteMoney"
                                + "         ,[OfficeAutomation_Document_UtContract_PreCompleteComm] = @OfficeAutomation_Document_UtContract_PreCompleteComm"
                                + "         ,[OfficeAutomation_Document_UtContract_FtoZ] = @OfficeAutomation_Document_UtContract_FtoZ"
                                + "         ,[OfficeAutomation_Document_UtContract_IsUploadF] = @OfficeAutomation_Document_UtContract_IsUploadF"
                                + "         ,[OfficeAutomation_Document_UtContract_OneOrTwo] = @OfficeAutomation_Document_UtContract_OneOrTwo"
                                + "         ,[OfficeAutomation_Document_UtContract_DealS] = @OfficeAutomation_Document_UtContract_DealS"
                                + "         ,[OfficeAutomation_Document_UtContract_ddlProjectAddress] = @OfficeAutomation_Document_UtContract_ddlProjectAddress"
                                + "           ,[OfficeAutomation_Document_UtContract_ACName]=@OfficeAutomation_Document_UtContract_ACName"
                                + "           ,[OfficeAutomation_Document_UtContract_QRCommissionRatio]=@OfficeAutomation_Document_UtContract_QRCommissionRatio"
                                + "           ,[OfficeAutomation_Document_UtContract_QRDeadlines]=@OfficeAutomation_Document_UtContract_QRDeadlines"
                                + "           ,[OfficeAutomation_Document_UtContract_YCCommissionRatio]=@OfficeAutomation_Document_UtContract_YCCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_YCDeadlines]=@OfficeAutomation_Document_UtContract_YCDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_HirePurchase]=@OfficeAutomation_Document_UtContract_HirePurchase"
                              + "           ,[OfficeAutomation_Document_UtContract_ZFRatio]=@OfficeAutomation_Document_UtContract_ZFRatio"
                                + "           ,[OfficeAutomation_Document_UtContract_FQCommissionRatio]=@OfficeAutomation_Document_UtContract_FQCommissionRatio"
                                + "           ,[OfficeAutomation_Document_UtContract_FQDeadlines]=@OfficeAutomation_Document_UtContract_FQDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_HousingFund]=@OfficeAutomation_Document_UtContract_HousingFund"
                                + "           ,[OfficeAutomation_Document_UtContract_Hour]=@OfficeAutomation_Document_UtContract_Hour"
                               + "           ,[OfficeAutomation_Document_UtContract_HousDeadlines]=@OfficeAutomation_Document_UtContract_HousDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_Downpayment]=@OfficeAutomation_Document_UtContract_Downpayment"
                               + "           ,[OfficeAutomation_Document_UtContract_SFRatio]=@OfficeAutomation_Document_UtContract_SFRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_SFCommissionRatio]=@OfficeAutomation_Document_UtContract_SFCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_SFDeadlines]=@OfficeAutomation_Document_UtContract_SFDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_Loan]=@OfficeAutomation_Document_UtContract_Loan"
                               + "           ,[OfficeAutomation_Document_UtContract_LoanRatio]=@OfficeAutomation_Document_UtContract_LoanRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_FKCommissionRatio]=@OfficeAutomation_Document_UtContract_FKCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_FKDeadlines]=@OfficeAutomation_Document_UtContract_FKDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_AJ1CommissionRatio]=@OfficeAutomation_Document_UtContract_AJ1CommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_AJ1Deadlines]=@OfficeAutomation_Document_UtContract_AJ1Deadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_AJ2CommissionRatio]=@OfficeAutomation_Document_UtContract_AJ2CommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_AJ2Deadlines]=@OfficeAutomation_Document_UtContract_AJ2Deadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_AJ3CommissionRatio]=@OfficeAutomation_Document_UtContract_AJ3CommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_AJ3Deadlines]=@OfficeAutomation_Document_UtContract_AJ3Deadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_BACommissionRatio]=@OfficeAutomation_Document_UtContract_BACommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_BADeadlines]=@OfficeAutomation_Document_UtContract_BADeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_YHCommissionRatio]=@OfficeAutomation_Document_UtContract_YHCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_YHDeadlines]=@OfficeAutomation_Document_UtContract_YHDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_RHCommissionRatio]=@OfficeAutomation_Document_UtContract_RHCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_RHDeadlines]=@OfficeAutomation_Document_UtContract_RHDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_SXCommissionRatio]=@OfficeAutomation_Document_UtContract_SXCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_SXDeadlines]=@OfficeAutomation_Document_UtContract_SXDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_DLCommissionRatio]=@OfficeAutomation_Document_UtContract_DLCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_DLDeadlines]=@OfficeAutomation_Document_UtContract_DLDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_Evidence]=@OfficeAutomation_Document_UtContract_Evidence"
                               + "           ,[OfficeAutomation_Document_UtContract_YJCommissionRatio]=@OfficeAutomation_Document_UtContract_YJCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtContract_YJDeadlines]=@OfficeAutomation_Document_UtContract_YJDeadlines"
                               + "           ,[OfficeAutomation_Document_UtContract_Reserve]=@OfficeAutomation_Document_UtContract_Reserve"
                               + "           ,[OfficeAutomation_Document_UtContract_IsDirectContract]=@OfficeAutomation_Document_UtContract_IsDirectContract"
                               + "           ,[OfficeAutomation_Document_UtContract_DirectContractName]=@OfficeAutomation_Document_UtContract_DirectContractName"
                               + "           ,[OfficeAutomation_Document_UtContract_DirectContractType]=@OfficeAutomation_Document_UtContract_DirectContractType"
                               + "         ,[OfficeAutomation_Document_UtContract_IsPreSale] = @OfficeAutomation_Document_UtContract_IsPreSale"
                               + "         ,[OfficeAutomation_Document_UtContract_IslimitBuy] = @OfficeAutomation_Document_UtContract_IslimitBuy"
                                + "         ,[OfficeAutomation_Document_UtContract_IslimitSign] = @OfficeAutomation_Document_UtContract_IslimitSign"
                                 + "         ,[OfficeAutomation_Document_UtContract_DiskSource] = @OfficeAutomation_Document_UtContract_DiskSource"
                                 //2019-08-08 CREATE BY HERMAN：新增两列
                                 + "         ,[OfficeAutomation_Document_UtContract_ECommerceReason] = @OfficeAutomation_Document_UtContract_ECommerceReason"
                                 + "         ,[OfficeAutomation_Document_UtContract_DiscountMoney] = @OfficeAutomation_Document_UtContract_DiscountMoney"
                                //+ "           ,[OfficeAutomation_Document_UtContract_OverallScale]=@OfficeAutomation_Document_UtContract_OverallScale"
                                + "         WHERE [OfficeAutomation_Document_UtContract_ID]=@OfficeAutomation_Document_UtContract_ID"
                                + "         AND [OfficeAutomation_Document_UtContract_MainID]=@OfficeAutomation_Document_UtContract_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtContract)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Name1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Name1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Name2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Name2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Developer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Developer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_GroupName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_GroupName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BaseAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BaseAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BaseAgentOther", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BaseAgentOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealType", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjectArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjectArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LastBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LastBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LastEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LastEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LastSumNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LastSumNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Turnover", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Turnover));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LastResults", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LastResults));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CumulativeBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CumulativeBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CumulativeEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CumulativeEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CumulativeNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CumulativeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SumTurnover", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SumTurnover));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CumulativeResults", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CumulativeResults));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsStree", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsStree));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsMarking", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsMarking));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsBusiness", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsBusiness));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsBackRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsBackRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_txtProjectAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_txtProjectAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_txtReportAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_txtReportAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DeveloperContacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DeveloperContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DeveloperContacterPosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DeveloperContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DeveloperContacterPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DeveloperContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaFollowerContacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaFollowerContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaCheckDataer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaCheckDataer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaCheckDataerCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaCheckDataerCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaCheckDataerPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaCheckDataerPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Square", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Square));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SetNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SetNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_UnitPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_UnitPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_TotalPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_TotalPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsCoopWithECommerce", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsCoopWithECommerce));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CoopWithE5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CoopWithE5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ECommerceName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ECommerceName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ECommerceName2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ECommerceName2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjFear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjFear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjSum1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjSum1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjSum2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjSum2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ProjSum3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ProjSum3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OwnerCommFixScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OwnerCommFixScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OwnerCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OwnerCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ClientCommFixScale", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ClientCommFixScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ClientCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ClientCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_EBComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_EBComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_EBCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_EBCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Remark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Remark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Jubar1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Jubar1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Jubar2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Jubar2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Jubar3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Jubar3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_HaveSingleReward", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_HaveSingleReward));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_RewardSignHave", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_RewardSignHave));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AnotherRewardC", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AnotherRewardC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DeveloperConditions", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DeveloperConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaConditions", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PayRewardWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PayRewardWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsMyPay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsMyPay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaComfirn", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaComfirn));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ReturnBackDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ReturnBackDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_TermsOfContract", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_TermsOfContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_TermsOfMajorIssues", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_TermsOfMajorIssues));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AgentStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AgentStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AgentEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AgentEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ClientGuardStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ClientGuardStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ClientGuardEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ClientGuardEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsProjEarlyCommBack", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsProjEarlyCommBack));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OweCommSum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OweCommSum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaReason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OrdMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OrdMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OrdTaker", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OrdTaker));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_JOrT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_JOrT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SamePlaceXX1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SamePlaceXX1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AgencyFee1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AgencyFee1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsCashPrize1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsCashPrize1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CashPrize1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CashPrize1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsPFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsPFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SamePlaceXX2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SamePlaceXX2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AgencyFee2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AgencyFee2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsCashPrize2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsCashPrize2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_CashPrize2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_CashPrize2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsPFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsPFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SaleMode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SaleMode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaScale1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaScale1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_MainAreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_MainAreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealAreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealAreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_MainAreaScale2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_MainAreaScale2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealAreaScale2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealAreaScale2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Nre", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Nre));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AnotherCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AnotherCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Rce", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Rce));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_WillBreakUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_WillBreakUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BreakUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BreakUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Ncommissions", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Ncommissions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_GuaranTime", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_GuaranTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Flange", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Flange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Lack", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Lack));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Lack6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Lack6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_MS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_MS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PreCompleteNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PreCompleteNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PreCompleteMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PreCompleteMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_PreCompleteComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_PreCompleteComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FtoZ", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FtoZ));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsUploadF", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsUploadF));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OneOrTwo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OneOrTwo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DealS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DealS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ddlProjectAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ddlProjectAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsDirectContract", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsDirectContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DirectContractName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DirectContractName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DirectContractType", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DirectContractType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IsPreSale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IsPreSale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IslimitBuy", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IslimitBuy));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_IslimitSign", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_IslimitSign));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DiskSource", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DiskSource));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_OverallScale", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_OverallScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_MainID));

                #region 2016/10/27 52100
                 cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ACName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ACName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_QRCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_QRCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_QRDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_QRDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YCCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YCCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YCDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YCDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_HirePurchase", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_HirePurchase));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ZFRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ZFRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FQCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FQCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FQDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FQDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_HousingFund", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_HousingFund));				
				cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Hour", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Hour));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_HousDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_HousDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Downpayment", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Downpayment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SFRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SFRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SFCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SFCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SFDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SFDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Loan", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Loan));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_LoanRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_LoanRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FKCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FKCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_FKDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_FKDeadlines));				
				cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ1CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ1CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ1Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ1Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ2CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ2CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ2Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ2Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ3CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ3CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_AJ3Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_AJ3Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BACommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BACommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_BADeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_BADeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YHCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YHCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YHDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YHDeadlines));			
				cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_RHCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_RHCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_RHDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_RHDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SXCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SXCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_SXDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_SXDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DLCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DLCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DLDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DLDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Evidence", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Evidence));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YJCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YJCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_YJDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_YJDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_Reserve", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_Reserve));
                #endregion

                #region [2019-08-08 CREATE BY HERMAN：新增两列]
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_ECommerceReason", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_ECommerceReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtContract_DiscountMoney", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtContract_DiscountMoney));
                #endregion

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
        public T_OfficeAutomation_Document_UtContract Add(T_OfficeAutomation_Document_UtContract t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_UtContract Edit(T_OfficeAutomation_Document_UtContract t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_UtContract t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_UtContract GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_UtContract>(where);
        }
        #endregion 
    }
}
