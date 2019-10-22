using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtNewProj_Inherit : DA_OfficeAutomation_Document_UtNewProj_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// 2016/8/24 52100新增项目所在地字段：OfficeAutomation_Document_UtContract_ddlProjectAddress
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  todi.* "
                           //[OfficeAutomation_Document_UtNewProj_ID]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_MainID]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Apply]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ApplyDate]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ApplyID]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Department]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Project]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Developer]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_GroupName]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_BaseAgent]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_BaseAgentOther]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_DealType]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ProjectArea]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_DealOfficeTypeIDs]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsStree]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsMarking]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsBusiness]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsBackRent]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_txtProjectAddress]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_txtReportAddress]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_DeveloperContacter]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_DeveloperContacterPosition]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_DeveloperContacterPhone]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaFollowerContacter]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPosition]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaFollowerContacterPhone]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaCheckDataer]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaCheckDataerCode]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaCheckDataerPhone]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Square]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_SetNumber]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_UnitPrice]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_TotalPrice]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsCoopWithECommerce]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE3]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE4]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_CoopWithE5]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ECommerceName]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ECommerceName2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ProjFear]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ProjSum1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ProjSum2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ProjSum3]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_OwnerCommFixScale]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_OwnerCommAgent]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ClientCommFixScale]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ClientCommAgent]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_EBComm]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_EBCommAgent]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Remark]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Jubar1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Jubar2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Jubar3]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_HaveSingleReward]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_RewardSignHave]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AnotherRewardC]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_DeveloperConditions]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaConditions]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_PayRewardWay]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsMyPay]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaComfirn]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ReturnBackDate]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_TermsOfContract]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AgentStartDate]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AgentEndDate]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ClientGuardStartDate]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ClientGuardEndDate]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_JOrT]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_SamePlaceXX1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AgencyFee1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsCashPrize1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_CashPrize1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsPFear1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_PFear1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_SamePlaceXX2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AgencyFee2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsCashPrize2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_CashPrize2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsPFear2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_PFear2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_SaleMode]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaScale1]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_MainAreaScale]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_DealAreaScale]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AreaScale]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_MainAreaScale2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_DealAreaScale2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Nre]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AnotherCompany]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Rce]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_WillBreakUp]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_BreakUp]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Ncommissions]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Lack]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_Lack6]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_AS2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_MS2]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_PreCompleteNumber]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_PreCompleteMoney]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_PreCompleteComm]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_FtoZ]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_IsUploadF]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_OneOrTwo]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_DealS]"
                           //+ "           ,[OfficeAutomation_Document_UtNewProj_ddlProjectAddress]"

                           // + "           ,OfficeAutomation_Document_UtNewProj_ACName"
                           // + "           ,OfficeAutomation_Document_UtNewProj_QRCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_QRDeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_YCCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_YCDeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_HirePurchase"
                           // + "           ,OfficeAutomation_Document_UtNewProj_ZFRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_FQCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_FQDeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_HousingFund"

                           // + "           ,OfficeAutomation_Document_UtNewProj_Hour"
                           // + "           ,OfficeAutomation_Document_UtNewProj_HousDeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_Downpayment"
                           // + "           ,OfficeAutomation_Document_UtNewProj_SFRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_SFCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_SFDeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_Loan"
                           // + "           ,OfficeAutomation_Document_UtNewProj_LoanRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_FKCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_FKDeadlines"

                           // + "           ,OfficeAutomation_Document_UtNewProj_AJ1CommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_AJ1Deadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_AJ2CommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_AJ2Deadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_AJ3CommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_AJ3Deadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_BACommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_BADeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_YHCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_YHDeadlines"

                           // + "           ,OfficeAutomation_Document_UtNewProj_RHCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_RHDeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_SXCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_SXDeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_DLCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_DLDeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_Evidence"
                           // + "           ,OfficeAutomation_Document_UtNewProj_YJCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtNewProj_YJDeadlines"
                           // + "           ,OfficeAutomation_Document_UtNewProj_Reserve"
                           // +"            ,OfficeAutomation_Document_UtNewProj_IsDirectContract"
                           // + "           ,OfficeAutomation_Document_UtNewProj_DirectContractName"
                           // + "           ,OfficeAutomation_Document_UtNewProj_DirectContractType"
                           // + "           ,OfficeAutomation_Document_UtNewProj_IsPreSale"
                          //   + "           ,OfficeAutomation_Document_UtNewProj_OverallScale"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_UtNewProj_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_UtNewProj_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_UtNewProj_ID]"
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
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_UtNewProj_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_UtNewProj_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_UtNewProj obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_UtNewProj_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_UtNewProj();
            Baseobj.OfficeAutomation_Document_UtNewProj_ID = obj.OfficeAutomation_Document_UtNewProj_ID;
            Baseobj.OfficeAutomation_Document_UtNewProj_MainID = obj.OfficeAutomation_Document_UtNewProj_MainID;
            Baseobj.OfficeAutomation_Document_UtNewProj_Apply = obj.OfficeAutomation_Document_UtNewProj_Apply;
            Baseobj.OfficeAutomation_Document_UtNewProj_ApplyDate = obj.OfficeAutomation_Document_UtNewProj_ApplyDate;
            Baseobj.OfficeAutomation_Document_UtNewProj_ApplyID = obj.OfficeAutomation_Document_UtNewProj_ApplyID;
            Baseobj.OfficeAutomation_Document_UtNewProj_Department = obj.OfficeAutomation_Document_UtNewProj_Department;
            Baseobj.OfficeAutomation_Document_UtNewProj_ddlProjectAddress = obj.OfficeAutomation_Document_UtNewProj_ddlProjectAddress;


            //obj是否已经存在
            var where = "[OfficeAutomation_Document_UtNewProj_MainID]='" + obj.OfficeAutomation_Document_UtNewProj_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_UtNewProj resultobj;
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

        /// <summary>
        /// 新建项目名是否存在
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="Project"></param>
        /// <returns></returns>
        public bool IsRepeat(string mainid, string Project)
        {
            string sql = string.Format(@"select u.* 
                            from [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj] u
                            inner join t_OfficeAutomation_Main m on  m.OfficeAutomation_Main_ID= u.OfficeAutomation_Document_UtNewProj_MainID 
                             where OfficeAutomation_Main_IsDelete=0 and u.OfficeAutomation_Document_UtNewProj_MainID!='{0}' 
                            and  u.OfficeAutomation_Document_UtNewProj_Project='{1}'", mainid, Project);
            DataSet ds = RunSQL(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else {
                return false;
            }
        
        }
    }
}
