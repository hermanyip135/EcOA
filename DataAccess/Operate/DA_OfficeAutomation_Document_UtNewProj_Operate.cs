using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtNewProj_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_UtNewProj _objMessage = null;
        private DAL.DalBase<T_OfficeAutomation_Document_UtNewProj> dal;
        #endregion

        public DA_OfficeAutomation_Document_UtNewProj_Operate() 
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_UtNewProj>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj]"
                                                        + "           ([OfficeAutomation_Document_UtNewProj_ID]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_MainID]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Apply]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Department]"

                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Project]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Developer]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_GroupName]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_BaseAgent]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_BaseAgentOther]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_DealType]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ProjectArea]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_DealOfficeTypeIDs]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsStree]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsMarking]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsBusiness]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsBackRent]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_txtProjectAddress]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_txtReportAddress]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_DeveloperContacter]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_DeveloperContacterPosition]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_DeveloperContacterPhone]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaFollowerContacter]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPosition]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPhone]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaCheckDataer]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaCheckDataerCode]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaCheckDataerPhone]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Square]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_SetNumber]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_UnitPrice]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_TotalPrice]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsCoopWithECommerce]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE3]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE4]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE5]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ECommerceName]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ECommerceName2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ProjFear]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ProjSum1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ProjSum2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ProjSum3]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_OwnerCommFixScale]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_OwnerCommAgent]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ClientCommFixScale]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ClientCommAgent]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_EBComm]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_EBCommAgent]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Remark]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Jubar1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Jubar2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Jubar3]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_HaveSingleReward]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_RewardSignHave]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AnotherRewardC]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_DeveloperConditions]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaConditions]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_PayRewardWay]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsMyPay]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaComfirn]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ReturnBackDate]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_TermsOfContract]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AgentStartDate]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AgentEndDate]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ClientGuardStartDate]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ClientGuardEndDate]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_JOrT]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_SamePlaceXX1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AgencyFee1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsCashPrize1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_CashPrize1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsPFear1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_PFear1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_SamePlaceXX2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AgencyFee2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsCashPrize2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_CashPrize2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsPFear2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_PFear2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_SaleMode]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaScale1]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_MainAreaScale]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_DealAreaScale]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AreaScale]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_MainAreaScale2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_DealAreaScale2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Nre]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AnotherCompany]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Rce]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_WillBreakUp]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_BreakUp]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Ncommissions]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Lack]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Lack6]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_AS2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_MS2]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_PreCompleteNumber]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_PreCompleteMoney]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_PreCompleteComm]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_FtoZ]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_IsUploadF]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_OneOrTwo]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_DealS]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_ddlProjectAddress]"

                                                        + "           ,OfficeAutomation_Document_UtNewProj_ACName"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_QRCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_QRDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_YCCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_YCDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_HirePurchase"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_ZFRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_FQCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_FQDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_HousingFund"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_Hour"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_HousDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_Downpayment"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_SFRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_SFCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_SFDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_Loan"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_LoanRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_FKCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_FKDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_AJ1CommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_AJ1Deadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_AJ2CommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_AJ2Deadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_AJ3CommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_AJ3Deadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_BACommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_BADeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_YHCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_YHDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_RHCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_RHDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_SXCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_SXDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_DLCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_DLDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_Evidence"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_YJCommissionRatio"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_YJDeadlines"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_Reserve"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_IsDirectContract"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_DirectContractName"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_DirectContractType"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_IsPreSale"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_IslimitBuy"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_IslimitSign"
                                                        + "           ,OfficeAutomation_Document_UtNewProj_DiskSource"
                                                        //2019-08-08 CREATE BY HERMAN：新增两列
                                                        + ",OfficeAutomation_Document_UtNewProj_ECommerceReason"
                                                        + ",OfficeAutomation_Document_UtNewProj_DiscountMoney"
                                                        + ")"
                //    + "           ,OfficeAutomation_Document_UtNewProj_OverallScale)"

                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_UtNewProj_ID"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_MainID"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Apply"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Department"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Project"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Developer"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_GroupName"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_BaseAgent"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_BaseAgentOther"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DealType"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ProjectArea"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DealOfficeTypeIDs"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsStree"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsMarking"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsBusiness"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsBackRent"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_txtProjectAddress"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_txtReportAddress"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DeveloperContacter"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DeveloperContacterPosition"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DeveloperContacterPhone"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaFollowerContacter"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPosition"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPhone"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaCheckDataer"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaCheckDataerCode"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaCheckDataerPhone"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Square"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_SetNumber"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_UnitPrice"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_TotalPrice"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsCoopWithECommerce"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_CoopWithE1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_CoopWithE2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_CoopWithE3"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_CoopWithE4"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_CoopWithE5"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ECommerceName"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ECommerceName2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ProjFear"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ProjSum1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ProjSum2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ProjSum3"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_OwnerCommFixScale"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_OwnerCommAgent"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ClientCommFixScale"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ClientCommAgent"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_EBComm"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_EBCommAgent"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Remark"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Jubar1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Jubar2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Jubar3"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_HaveSingleReward"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_RewardSignHave"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AnotherRewardC"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DeveloperConditions"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaConditions"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_PayRewardWay"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsMyPay"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaComfirn"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ReturnBackDate"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_TermsOfContract"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AgentStartDate"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AgentEndDate"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ClientGuardStartDate"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ClientGuardEndDate"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_JOrT"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_SamePlaceXX1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AgencyFee1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsCashPrize1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_CashPrize1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsPFear1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_PFear1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_SamePlaceXX2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AgencyFee2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsCashPrize2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_CashPrize2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsPFear2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_PFear2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_SaleMode"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaScale1"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_MainAreaScale"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DealAreaScale"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AreaScale"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_MainAreaScale2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DealAreaScale2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Nre"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AnotherCompany"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Rce"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_WillBreakUp"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_BreakUp"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Ncommissions"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Lack"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Lack6"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AS2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_MS2"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_PreCompleteNumber"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_PreCompleteMoney"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_PreCompleteComm"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_FtoZ"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsUploadF"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_OneOrTwo"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DealS"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ddlProjectAddress"

                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ACName"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_QRCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_QRDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_YCCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_YCDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_HirePurchase"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ZFRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_FQCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_FQDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_HousingFund"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Hour"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_HousDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Downpayment"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_SFRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_SFCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_SFDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Loan"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_LoanRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_FKCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_FKDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AJ1CommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AJ1Deadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AJ2CommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AJ2Deadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AJ3CommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_AJ3Deadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_BACommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_BADeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_YHCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_YHDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_RHCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_RHDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_SXCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_SXDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DLCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DLDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Evidence"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_YJCommissionRatio"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_YJDeadlines"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Reserve"
                                                        +"            ,@OfficeAutomation_Document_UtNewProj_IsDirectContract"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DirectContractName"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DirectContractType"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IsPreSale"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IslimitBuy"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_IslimitSign"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DiskSource"
                                                        //2019-08-08 CREATE BY HERMAN：新增两列
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_ECommerceReason"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_DiscountMoney"
                                                        + ")";
                                                   //     + "           ,@OfficeAutomation_Document_UtNewProj_OverallScale)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtNewProj)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Project", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Project));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Developer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Developer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_GroupName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_GroupName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BaseAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BaseAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BaseAgentOther", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BaseAgentOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealType", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjectArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjectArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsStree", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsStree));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsMarking", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsMarking));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsBusiness", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsBusiness));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsBackRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsBackRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_txtProjectAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_txtProjectAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_txtReportAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_txtReportAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DeveloperContacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DeveloperContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DeveloperContacterPosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DeveloperContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DeveloperContacterPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DeveloperContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaFollowerContacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaFollowerContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaCheckDataer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaCheckDataer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaCheckDataerCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaCheckDataerCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaCheckDataerPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaCheckDataerPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Square", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Square));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SetNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SetNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_UnitPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_UnitPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_TotalPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_TotalPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsCoopWithECommerce", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsCoopWithECommerce));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ECommerceName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ECommerceName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ECommerceName2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ECommerceName2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjFear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjFear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjSum1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjSum1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjSum2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjSum2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjSum3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjSum3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_OwnerCommFixScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_OwnerCommFixScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_OwnerCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_OwnerCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ClientCommFixScale", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ClientCommFixScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ClientCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ClientCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_EBComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_EBComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_EBCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_EBCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Remark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Remark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Jubar1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Jubar1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Jubar2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Jubar2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Jubar3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Jubar3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_HaveSingleReward", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_HaveSingleReward));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_RewardSignHave", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_RewardSignHave));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AnotherRewardC", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AnotherRewardC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DeveloperConditions", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DeveloperConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaConditions", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PayRewardWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PayRewardWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsMyPay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsMyPay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaComfirn", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaComfirn));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ReturnBackDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ReturnBackDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_TermsOfContract", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_TermsOfContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AgentStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AgentStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AgentEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AgentEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ClientGuardStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ClientGuardStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ClientGuardEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ClientGuardEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_JOrT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_JOrT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SamePlaceXX1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SamePlaceXX1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AgencyFee1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AgencyFee1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsCashPrize1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsCashPrize1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CashPrize1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CashPrize1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsPFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsPFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SamePlaceXX2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SamePlaceXX2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AgencyFee2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AgencyFee2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsCashPrize2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsCashPrize2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CashPrize2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CashPrize2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsPFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsPFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SaleMode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SaleMode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaScale1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaScale1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_MainAreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_MainAreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealAreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealAreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_MainAreaScale2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_MainAreaScale2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealAreaScale2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealAreaScale2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Nre", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Nre));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AnotherCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AnotherCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Rce", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Rce));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_WillBreakUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_WillBreakUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BreakUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BreakUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Ncommissions", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Ncommissions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Lack", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Lack));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Lack6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Lack6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_MS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_MS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PreCompleteNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PreCompleteNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PreCompleteMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PreCompleteMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PreCompleteComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PreCompleteComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FtoZ", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FtoZ));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsUploadF", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsUploadF));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_OneOrTwo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_OneOrTwo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ddlProjectAddress", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ddlProjectAddress));

                #region 2016/10/27 52100
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ACName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ACName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_QRCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_QRCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_QRDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_QRDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YCCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YCCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YCDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YCDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_HirePurchase", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_HirePurchase));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ZFRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ZFRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FQCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FQCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FQDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FQDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_HousingFund", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_HousingFund));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Hour", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Hour));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_HousDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_HousDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Downpayment", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Downpayment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SFRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SFRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SFCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SFCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SFDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SFDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Loan", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Loan));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_LoanRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_LoanRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FKCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FKCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FKDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FKDeadlines));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ1CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ1CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ1Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ1Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ2CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ2CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ2Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ2Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ3CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ3CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ3Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ3Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BACommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BACommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BADeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BADeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YHCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YHCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YHDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YHDeadlines));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_RHCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_RHCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_RHDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_RHDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SXCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SXCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SXDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SXDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DLCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DLCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DLDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DLDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Evidence", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Evidence));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YJCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YJCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YJDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YJDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Reserve", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Reserve));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsDirectContract", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsDirectContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DirectContractName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DirectContractName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DirectContractType", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DirectContractType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsPreSale", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsPreSale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IslimitBuy", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IslimitBuy));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IslimitSign", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IslimitSign));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DiskSource", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DiskSource));
                #endregion

                #region [2019-08-08 CREATE BY HERMAN：新增两列]
                var ECommerceReason = this._objMessage.OfficeAutomation_Document_UtNewProj_ECommerceReason;
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ECommerceReason", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(ECommerceReason) == true ? "" : ECommerceReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DiscountMoney", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DiscountMoney));
                #endregion

             //   cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_OverallScale", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_OverallScale));
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
            cmdToExecute.CommandText = "dbo.[pr_UtNewProj_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj]"
                                + "         SET [OfficeAutomation_Document_UtNewProj_ApplyID] = @OfficeAutomation_Document_UtNewProj_ApplyID"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Department] = @OfficeAutomation_Document_UtNewProj_Department"

                                + "         ,[OfficeAutomation_Document_UtNewProj_Project] = @OfficeAutomation_Document_UtNewProj_Project"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Developer] = @OfficeAutomation_Document_UtNewProj_Developer"
                                + "         ,[OfficeAutomation_Document_UtNewProj_GroupName] = @OfficeAutomation_Document_UtNewProj_GroupName"
                                + "         ,[OfficeAutomation_Document_UtNewProj_BaseAgent] = @OfficeAutomation_Document_UtNewProj_BaseAgent"
                                + "         ,[OfficeAutomation_Document_UtNewProj_BaseAgentOther] = @OfficeAutomation_Document_UtNewProj_BaseAgentOther"
                                + "         ,[OfficeAutomation_Document_UtNewProj_DealType] = @OfficeAutomation_Document_UtNewProj_DealType"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ProjectArea] = @OfficeAutomation_Document_UtNewProj_ProjectArea"
                                + "         ,[OfficeAutomation_Document_UtNewProj_DealOfficeTypeIDs] = @OfficeAutomation_Document_UtNewProj_DealOfficeTypeIDs"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsStree] = @OfficeAutomation_Document_UtNewProj_IsStree"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsMarking] = @OfficeAutomation_Document_UtNewProj_IsMarking"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsBusiness] = @OfficeAutomation_Document_UtNewProj_IsBusiness"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsBackRent] = @OfficeAutomation_Document_UtNewProj_IsBackRent"
                                + "         ,[OfficeAutomation_Document_UtNewProj_txtProjectAddress] = @OfficeAutomation_Document_UtNewProj_txtProjectAddress"
                                + "         ,[OfficeAutomation_Document_UtNewProj_txtReportAddress] = @OfficeAutomation_Document_UtNewProj_txtReportAddress"
                                + "         ,[OfficeAutomation_Document_UtNewProj_DeveloperContacter] = @OfficeAutomation_Document_UtNewProj_DeveloperContacter"
                                + "         ,[OfficeAutomation_Document_UtNewProj_DeveloperContacterPosition] = @OfficeAutomation_Document_UtNewProj_DeveloperContacterPosition"
                                + "         ,[OfficeAutomation_Document_UtNewProj_DeveloperContacterPhone] = @OfficeAutomation_Document_UtNewProj_DeveloperContacterPhone"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaFollowerContacter] = @OfficeAutomation_Document_UtNewProj_AreaFollowerContacter"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPosition] = @OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPosition"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPhone] = @OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPhone"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaCheckDataer] = @OfficeAutomation_Document_UtNewProj_AreaCheckDataer"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaCheckDataerCode] = @OfficeAutomation_Document_UtNewProj_AreaCheckDataerCode"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaCheckDataerPhone] = @OfficeAutomation_Document_UtNewProj_AreaCheckDataerPhone"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Square] = @OfficeAutomation_Document_UtNewProj_Square"
                                + "         ,[OfficeAutomation_Document_UtNewProj_SetNumber] = @OfficeAutomation_Document_UtNewProj_SetNumber"
                                + "         ,[OfficeAutomation_Document_UtNewProj_UnitPrice] = @OfficeAutomation_Document_UtNewProj_UnitPrice"
                                + "         ,[OfficeAutomation_Document_UtNewProj_TotalPrice] = @OfficeAutomation_Document_UtNewProj_TotalPrice"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsCoopWithECommerce] = @OfficeAutomation_Document_UtNewProj_IsCoopWithECommerce"
                                + "         ,[OfficeAutomation_Document_UtNewProj_CoopWithE1] = @OfficeAutomation_Document_UtNewProj_CoopWithE1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_CoopWithE2] = @OfficeAutomation_Document_UtNewProj_CoopWithE2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_CoopWithE3] = @OfficeAutomation_Document_UtNewProj_CoopWithE3"
                                + "         ,[OfficeAutomation_Document_UtNewProj_CoopWithE4] = @OfficeAutomation_Document_UtNewProj_CoopWithE4"
                                + "         ,[OfficeAutomation_Document_UtNewProj_CoopWithE5] = @OfficeAutomation_Document_UtNewProj_CoopWithE5"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ECommerceName] = @OfficeAutomation_Document_UtNewProj_ECommerceName"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ECommerceName2] = @OfficeAutomation_Document_UtNewProj_ECommerceName2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ProjFear] = @OfficeAutomation_Document_UtNewProj_ProjFear"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ProjSum1] = @OfficeAutomation_Document_UtNewProj_ProjSum1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ProjSum2] = @OfficeAutomation_Document_UtNewProj_ProjSum2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ProjSum3] = @OfficeAutomation_Document_UtNewProj_ProjSum3"
                                + "         ,[OfficeAutomation_Document_UtNewProj_OwnerCommFixScale] = @OfficeAutomation_Document_UtNewProj_OwnerCommFixScale"
                                + "         ,[OfficeAutomation_Document_UtNewProj_OwnerCommAgent] = @OfficeAutomation_Document_UtNewProj_OwnerCommAgent"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ClientCommFixScale] = @OfficeAutomation_Document_UtNewProj_ClientCommFixScale"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ClientCommAgent] = @OfficeAutomation_Document_UtNewProj_ClientCommAgent"
                                + "         ,[OfficeAutomation_Document_UtNewProj_EBComm] = @OfficeAutomation_Document_UtNewProj_EBComm"
                                + "         ,[OfficeAutomation_Document_UtNewProj_EBCommAgent] = @OfficeAutomation_Document_UtNewProj_EBCommAgent"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Remark] = @OfficeAutomation_Document_UtNewProj_Remark"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Jubar1] = @OfficeAutomation_Document_UtNewProj_Jubar1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Jubar2] = @OfficeAutomation_Document_UtNewProj_Jubar2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Jubar3] = @OfficeAutomation_Document_UtNewProj_Jubar3"
                                + "         ,[OfficeAutomation_Document_UtNewProj_HaveSingleReward] = @OfficeAutomation_Document_UtNewProj_HaveSingleReward"
                                + "         ,[OfficeAutomation_Document_UtNewProj_RewardSignHave] = @OfficeAutomation_Document_UtNewProj_RewardSignHave"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AnotherRewardC] = @OfficeAutomation_Document_UtNewProj_AnotherRewardC"
                                + "         ,[OfficeAutomation_Document_UtNewProj_DeveloperConditions] = @OfficeAutomation_Document_UtNewProj_DeveloperConditions"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaConditions] = @OfficeAutomation_Document_UtNewProj_AreaConditions"
                                + "         ,[OfficeAutomation_Document_UtNewProj_PayRewardWay] = @OfficeAutomation_Document_UtNewProj_PayRewardWay"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsMyPay] = @OfficeAutomation_Document_UtNewProj_IsMyPay"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaComfirn] = @OfficeAutomation_Document_UtNewProj_AreaComfirn"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ReturnBackDate] = @OfficeAutomation_Document_UtNewProj_ReturnBackDate"
                                + "         ,[OfficeAutomation_Document_UtNewProj_TermsOfContract] = @OfficeAutomation_Document_UtNewProj_TermsOfContract"
                                + "         ,[OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues] = @OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AgentStartDate] = @OfficeAutomation_Document_UtNewProj_AgentStartDate"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AgentEndDate] = @OfficeAutomation_Document_UtNewProj_AgentEndDate"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ClientGuardStartDate] = @OfficeAutomation_Document_UtNewProj_ClientGuardStartDate"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ClientGuardEndDate] = @OfficeAutomation_Document_UtNewProj_ClientGuardEndDate"
                                + "         ,[OfficeAutomation_Document_UtNewProj_JOrT] = @OfficeAutomation_Document_UtNewProj_JOrT"
                                + "         ,[OfficeAutomation_Document_UtNewProj_SamePlaceXX1] = @OfficeAutomation_Document_UtNewProj_SamePlaceXX1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AgencyFee1] = @OfficeAutomation_Document_UtNewProj_AgencyFee1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsCashPrize1] = @OfficeAutomation_Document_UtNewProj_IsCashPrize1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_CashPrize1] = @OfficeAutomation_Document_UtNewProj_CashPrize1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsPFear1] = @OfficeAutomation_Document_UtNewProj_IsPFear1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_PFear1] = @OfficeAutomation_Document_UtNewProj_PFear1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_SamePlaceXX2] = @OfficeAutomation_Document_UtNewProj_SamePlaceXX2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AgencyFee2] = @OfficeAutomation_Document_UtNewProj_AgencyFee2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsCashPrize2] = @OfficeAutomation_Document_UtNewProj_IsCashPrize2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_CashPrize2] = @OfficeAutomation_Document_UtNewProj_CashPrize2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsPFear2] = @OfficeAutomation_Document_UtNewProj_IsPFear2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_PFear2] = @OfficeAutomation_Document_UtNewProj_PFear2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_SaleMode] = @OfficeAutomation_Document_UtNewProj_SaleMode"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaScale1] = @OfficeAutomation_Document_UtNewProj_AreaScale1"
                                + "         ,[OfficeAutomation_Document_UtNewProj_MainAreaScale] = @OfficeAutomation_Document_UtNewProj_MainAreaScale"
                                + "         ,[OfficeAutomation_Document_UtNewProj_DealAreaScale] = @OfficeAutomation_Document_UtNewProj_DealAreaScale"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AreaScale] = @OfficeAutomation_Document_UtNewProj_AreaScale"
                                + "         ,[OfficeAutomation_Document_UtNewProj_MainAreaScale2] = @OfficeAutomation_Document_UtNewProj_MainAreaScale2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_DealAreaScale2] = @OfficeAutomation_Document_UtNewProj_DealAreaScale2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Nre] = @OfficeAutomation_Document_UtNewProj_Nre"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AnotherCompany] = @OfficeAutomation_Document_UtNewProj_AnotherCompany"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Rce] = @OfficeAutomation_Document_UtNewProj_Rce"
                                + "         ,[OfficeAutomation_Document_UtNewProj_WillBreakUp] = @OfficeAutomation_Document_UtNewProj_WillBreakUp"
                                + "         ,[OfficeAutomation_Document_UtNewProj_BreakUp] = @OfficeAutomation_Document_UtNewProj_BreakUp"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Ncommissions] = @OfficeAutomation_Document_UtNewProj_Ncommissions"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Lack] = @OfficeAutomation_Document_UtNewProj_Lack"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Lack6] = @OfficeAutomation_Document_UtNewProj_Lack6"
                                + "         ,[OfficeAutomation_Document_UtNewProj_AS2] = @OfficeAutomation_Document_UtNewProj_AS2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_MS2] = @OfficeAutomation_Document_UtNewProj_MS2"
                                + "         ,[OfficeAutomation_Document_UtNewProj_PreCompleteNumber] = @OfficeAutomation_Document_UtNewProj_PreCompleteNumber"
                                + "         ,[OfficeAutomation_Document_UtNewProj_PreCompleteMoney] = @OfficeAutomation_Document_UtNewProj_PreCompleteMoney"
                                + "         ,[OfficeAutomation_Document_UtNewProj_PreCompleteComm] = @OfficeAutomation_Document_UtNewProj_PreCompleteComm"
                                + "         ,[OfficeAutomation_Document_UtNewProj_FtoZ] = @OfficeAutomation_Document_UtNewProj_FtoZ"
                                + "         ,[OfficeAutomation_Document_UtNewProj_IsUploadF] = @OfficeAutomation_Document_UtNewProj_IsUploadF"
                                + "         ,[OfficeAutomation_Document_UtNewProj_OneOrTwo] = @OfficeAutomation_Document_UtNewProj_OneOrTwo"
                                + "         ,[OfficeAutomation_Document_UtNewProj_DealS] = @OfficeAutomation_Document_UtNewProj_DealS"
                                + "         ,[OfficeAutomation_Document_UtNewProj_ddlProjectAddress] = @OfficeAutomation_Document_UtNewProj_ddlProjectAddress"

                                + "           ,[OfficeAutomation_Document_UtNewProj_ACName]=@OfficeAutomation_Document_UtNewProj_ACName"
                                + "           ,[OfficeAutomation_Document_UtNewProj_QRCommissionRatio]=@OfficeAutomation_Document_UtNewProj_QRCommissionRatio"
                                + "           ,[OfficeAutomation_Document_UtNewProj_QRDeadlines]=@OfficeAutomation_Document_UtNewProj_QRDeadlines"
                                + "           ,[OfficeAutomation_Document_UtNewProj_YCCommissionRatio]=@OfficeAutomation_Document_UtNewProj_YCCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_YCDeadlines]=@OfficeAutomation_Document_UtNewProj_YCDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_HirePurchase]=@OfficeAutomation_Document_UtNewProj_HirePurchase"
                               + "           ,[OfficeAutomation_Document_UtNewProj_ZFRatio]=@OfficeAutomation_Document_UtNewProj_ZFRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_FQCommissionRatio]=@OfficeAutomation_Document_UtNewProj_FQCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_FQDeadlines]=@OfficeAutomation_Document_UtNewProj_FQDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_HousingFund]=@OfficeAutomation_Document_UtNewProj_HousingFund"
                               + "           ,[OfficeAutomation_Document_UtNewProj_Hour]=@OfficeAutomation_Document_UtNewProj_Hour"
                               + "           ,[OfficeAutomation_Document_UtNewProj_HousDeadlines]=@OfficeAutomation_Document_UtNewProj_HousDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_Downpayment]=@OfficeAutomation_Document_UtNewProj_Downpayment"
                               + "           ,[OfficeAutomation_Document_UtNewProj_SFRatio]=@OfficeAutomation_Document_UtNewProj_SFRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_SFCommissionRatio]=@OfficeAutomation_Document_UtNewProj_SFCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_SFDeadlines]=@OfficeAutomation_Document_UtNewProj_SFDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_Loan]=@OfficeAutomation_Document_UtNewProj_Loan"
                               + "           ,[OfficeAutomation_Document_UtNewProj_LoanRatio]=@OfficeAutomation_Document_UtNewProj_LoanRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_FKCommissionRatio]=@OfficeAutomation_Document_UtNewProj_FKCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_FKDeadlines]=@OfficeAutomation_Document_UtNewProj_FKDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_AJ1CommissionRatio]=@OfficeAutomation_Document_UtNewProj_AJ1CommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_AJ1Deadlines]=@OfficeAutomation_Document_UtNewProj_AJ1Deadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_AJ2CommissionRatio]=@OfficeAutomation_Document_UtNewProj_AJ2CommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_AJ2Deadlines]=@OfficeAutomation_Document_UtNewProj_AJ2Deadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_AJ3CommissionRatio]=@OfficeAutomation_Document_UtNewProj_AJ3CommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_AJ3Deadlines]=@OfficeAutomation_Document_UtNewProj_AJ3Deadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_BACommissionRatio]=@OfficeAutomation_Document_UtNewProj_BACommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_BADeadlines]=@OfficeAutomation_Document_UtNewProj_BADeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_YHCommissionRatio]=@OfficeAutomation_Document_UtNewProj_YHCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_YHDeadlines]=@OfficeAutomation_Document_UtNewProj_YHDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_RHCommissionRatio]=@OfficeAutomation_Document_UtNewProj_RHCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_RHDeadlines]=@OfficeAutomation_Document_UtNewProj_RHDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_SXCommissionRatio]=@OfficeAutomation_Document_UtNewProj_SXCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_SXDeadlines]=@OfficeAutomation_Document_UtNewProj_SXDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_DLCommissionRatio]=@OfficeAutomation_Document_UtNewProj_DLCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_DLDeadlines]=@OfficeAutomation_Document_UtNewProj_DLDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_Evidence]=@OfficeAutomation_Document_UtNewProj_Evidence"
                               + "           ,[OfficeAutomation_Document_UtNewProj_YJCommissionRatio]=@OfficeAutomation_Document_UtNewProj_YJCommissionRatio"
                               + "           ,[OfficeAutomation_Document_UtNewProj_YJDeadlines]=@OfficeAutomation_Document_UtNewProj_YJDeadlines"
                               + "           ,[OfficeAutomation_Document_UtNewProj_Reserve]=@OfficeAutomation_Document_UtNewProj_Reserve"
                               + "           ,[OfficeAutomation_Document_UtNewProj_IsDirectContract] =@OfficeAutomation_Document_UtNewProj_IsDirectContract"
                               +"            ,[OfficeAutomation_Document_UtNewProj_DirectContractName] =@OfficeAutomation_Document_UtNewProj_DirectContractName"
                               + "            ,[OfficeAutomation_Document_UtNewProj_DirectContractType] =@OfficeAutomation_Document_UtNewProj_DirectContractType"
                               + "            ,[OfficeAutomation_Document_UtNewProj_IsPreSale] =@OfficeAutomation_Document_UtNewProj_IsPreSale"
                                + "            ,[OfficeAutomation_Document_UtNewProj_IslimitBuy] =@OfficeAutomation_Document_UtNewProj_IslimitBuy"
                                 + "           ,[OfficeAutomation_Document_UtNewProj_IslimitSign] =@OfficeAutomation_Document_UtNewProj_IslimitSign"
                                  + "           ,[OfficeAutomation_Document_UtNewProj_DiskSource] =@OfficeAutomation_Document_UtNewProj_DiskSource"
                                 //2019-08-08 CREATE BY HERMAN：新增两列
                                 + "         ,[OfficeAutomation_Document_UtNewProj_ECommerceReason] = @OfficeAutomation_Document_UtNewProj_ECommerceReason"
                                 + "         ,[OfficeAutomation_Document_UtNewProj_DiscountMoney] = @OfficeAutomation_Document_UtNewProj_DiscountMoney"


                            //     + "           ,[OfficeAutomation_Document_UtNewProj_OverallScale]=@OfficeAutomation_Document_UtNewProj_OverallScale"
                                + "         WHERE [OfficeAutomation_Document_UtNewProj_ID]=@OfficeAutomation_Document_UtNewProj_ID"
                                + "         AND [OfficeAutomation_Document_UtNewProj_MainID]=@OfficeAutomation_Document_UtNewProj_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtNewProj)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Project", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Project));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Developer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Developer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_GroupName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_GroupName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BaseAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BaseAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BaseAgentOther", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BaseAgentOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealType", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjectArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjectArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsStree", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsStree));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsMarking", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsMarking));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsBusiness", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsBusiness));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsBackRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsBackRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_txtProjectAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_txtProjectAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_txtReportAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_txtReportAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DeveloperContacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DeveloperContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DeveloperContacterPosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DeveloperContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DeveloperContacterPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DeveloperContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaFollowerContacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaFollowerContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaCheckDataer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaCheckDataer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaCheckDataerCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaCheckDataerCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaCheckDataerPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaCheckDataerPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Square", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Square));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SetNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SetNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_UnitPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_UnitPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_TotalPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_TotalPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsCoopWithECommerce", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsCoopWithECommerce));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CoopWithE5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CoopWithE5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ECommerceName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ECommerceName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ECommerceName2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ECommerceName2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjFear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjFear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjSum1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjSum1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjSum2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjSum2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ProjSum3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ProjSum3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_OwnerCommFixScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_OwnerCommFixScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_OwnerCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_OwnerCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ClientCommFixScale", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ClientCommFixScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ClientCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ClientCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_EBComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_EBComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_EBCommAgent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_EBCommAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Remark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Remark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Jubar1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Jubar1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Jubar2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Jubar2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Jubar3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Jubar3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_HaveSingleReward", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_HaveSingleReward));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_RewardSignHave", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_RewardSignHave));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AnotherRewardC", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AnotherRewardC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DeveloperConditions", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DeveloperConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaConditions", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PayRewardWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PayRewardWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsMyPay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsMyPay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaComfirn", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaComfirn));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ReturnBackDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ReturnBackDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_TermsOfContract", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_TermsOfContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AgentStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AgentStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AgentEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AgentEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ClientGuardStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ClientGuardStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ClientGuardEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ClientGuardEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_JOrT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_JOrT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SamePlaceXX1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SamePlaceXX1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AgencyFee1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AgencyFee1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsCashPrize1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsCashPrize1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CashPrize1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CashPrize1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsPFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsPFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SamePlaceXX2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SamePlaceXX2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AgencyFee2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AgencyFee2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsCashPrize2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsCashPrize2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_CashPrize2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_CashPrize2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsPFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsPFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SaleMode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SaleMode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaScale1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaScale1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_MainAreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_MainAreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealAreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealAreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AreaScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AreaScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_MainAreaScale2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_MainAreaScale2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealAreaScale2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealAreaScale2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Nre", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Nre));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AnotherCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AnotherCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Rce", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Rce));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_WillBreakUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_WillBreakUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BreakUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BreakUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Ncommissions", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Ncommissions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Lack", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Lack));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Lack6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Lack6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_MS2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_MS2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PreCompleteNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PreCompleteNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PreCompleteMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PreCompleteMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_PreCompleteComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_PreCompleteComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FtoZ", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FtoZ));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsUploadF", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsUploadF));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_OneOrTwo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_OneOrTwo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DealS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DealS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ddlProjectAddress", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ddlProjectAddress));

                #region 2016/10/27 52100
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ACName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ACName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_QRCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_QRCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_QRDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_QRDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YCCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YCCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YCDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YCDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_HirePurchase", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_HirePurchase));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ZFRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ZFRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FQCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FQCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FQDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FQDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_HousingFund", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_HousingFund));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Hour", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Hour));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_HousDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_HousDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Downpayment", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Downpayment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SFRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SFRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SFCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SFCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SFDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SFDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Loan", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Loan));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_LoanRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_LoanRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FKCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FKCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_FKDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_FKDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ1CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ1CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ1Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ1Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ2CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ2CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ2Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ2Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ3CommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ3CommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_AJ3Deadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_AJ3Deadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BACommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BACommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_BADeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_BADeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YHCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YHCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YHDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YHDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_RHCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_RHCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_RHDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_RHDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SXCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SXCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_SXDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_SXDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DLCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DLCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DLDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DLDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Evidence", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Evidence));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YJCommissionRatio", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YJCommissionRatio));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_YJDeadlines", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_YJDeadlines));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Reserve", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Reserve));
                #endregion
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsDirectContract", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsDirectContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DirectContractName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DirectContractName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DirectContractType", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DirectContractType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IsPreSale", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IsPreSale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IslimitBuy", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IslimitBuy));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_IslimitSign", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_IslimitSign));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DiskSource", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DiskSource));
                //  cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_OverallScale", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_OverallScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_MainID));

                #region [2019-08-08 CREATE BY HERMAN：新增两列]
                var ECommerceReason = this._objMessage.OfficeAutomation_Document_UtNewProj_ECommerceReason;
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_ECommerceReason", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(ECommerceReason) == true ? "" : ECommerceReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_DiscountMoney", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_DiscountMoney));
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
        public T_OfficeAutomation_Document_UtNewProj Add(T_OfficeAutomation_Document_UtNewProj t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_UtNewProj Edit(T_OfficeAutomation_Document_UtNewProj t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_UtNewProj t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_UtNewProj GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_UtNewProj>(where);
        }
        #endregion 
    }
}
