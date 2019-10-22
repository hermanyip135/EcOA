using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtContract_Inherit : DA_OfficeAutomation_Document_UtContract_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// 2016/8/24 52100新增项目所在地字段：OfficeAutomation_Document_UtContract_ddlProjectAddress
        /// 2016/10/27 52100新增了没带[]号的四十个当前表字段
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT todi.* "
                           //              [OfficeAutomation_Document_UtContract_ID]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_MainID]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Apply]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ApplyDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ApplyID]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Department]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Name1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Name2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Developer]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_GroupName]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_BaseAgent]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_BaseAgentOther]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_DealType]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ProjectArea]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_LastBeginDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_LastEndDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_LastSumNum]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Turnover]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_LastResults]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CumulativeBeginDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CumulativeEndDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CumulativeNum]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_SumTurnover]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CumulativeResults]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_DealOfficeTypeIDs]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsStree]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsMarking]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsBusiness]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsBackRent]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_txtProjectAddress]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_txtReportAddress]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_DeveloperContacter]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_DeveloperContacterPosition]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_DeveloperContacterPhone]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaFollowerContacter]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaFollowerContacterPosition]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaFollowerContacterPhone]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaCheckDataer]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaCheckDataerCode]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaCheckDataerPhone]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Square]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_SetNumber]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_UnitPrice]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_TotalPrice]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsCoopWithECommerce]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CoopWithE1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CoopWithE2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CoopWithE3]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CoopWithE4]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CoopWithE5]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ECommerceName]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ECommerceName2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ProjFear]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ProjSum1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ProjSum2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ProjSum3]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_OwnerCommFixScale]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_OwnerCommAgent]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ClientCommFixScale]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ClientCommAgent]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_EBComm]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_EBCommAgent]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Remark]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Jubar1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Jubar2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Jubar3]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_HaveSingleReward]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_RewardSignHave]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AnotherRewardC]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_DeveloperConditions]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaConditions]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_PayRewardWay]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsMyPay]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaComfirn]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ReturnBackDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_TermsOfContract]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_TermsOfMajorIssues]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AgentStartDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AgentEndDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ClientGuardStartDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ClientGuardEndDate]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsProjEarlyCommBack]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_OweCommSum]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaReason]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_OrdMoney]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_OrdTaker]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_JOrT]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_SamePlaceXX1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AgencyFee1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsCashPrize1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CashPrize1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsPFear1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_PFear1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_SamePlaceXX2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AgencyFee2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsCashPrize2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_CashPrize2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsPFear2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_PFear2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_SaleMode]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaScale1]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_MainAreaScale]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_DealAreaScale]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AreaScale]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_MainAreaScale2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_DealAreaScale2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Nre]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AnotherCompany]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Rce]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_WillBreakUp]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_BreakUp]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Ncommissions]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_GuaranTime]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Flange]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Lack]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_Lack6]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_AS2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_MS2]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_PreCompleteNumber]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_PreCompleteMoney]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_PreCompleteComm]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_FtoZ]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_IsUploadF]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_OneOrTwo]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_DealS]"
                           //+ "           ,[OfficeAutomation_Document_UtContract_ddlProjectAddress]"
                           //+ "           ,OfficeAutomation_Document_UtContract_ACName"

                           // + "           ,OfficeAutomation_Document_UtContract_QRCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_QRDeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_YCCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_YCDeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_HirePurchase"
                           // + "           ,OfficeAutomation_Document_UtContract_ZFRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_FQCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_FQDeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_HousingFund"

                           // + "           ,OfficeAutomation_Document_UtContract_Hour"
                           // + "           ,OfficeAutomation_Document_UtContract_HousDeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_Downpayment"
                           // + "           ,OfficeAutomation_Document_UtContract_SFRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_SFCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_SFDeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_Loan"
                           // + "           ,OfficeAutomation_Document_UtContract_LoanRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_FKCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_FKDeadlines"

                           // + "           ,OfficeAutomation_Document_UtContract_AJ1CommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_AJ1Deadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_AJ2CommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_AJ2Deadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_AJ3CommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_AJ3Deadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_BACommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_BADeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_YHCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_YHDeadlines"

                           // + "           ,OfficeAutomation_Document_UtContract_RHCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_RHDeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_SXCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_SXDeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_DLCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_DLDeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_Evidence"
                           // + "           ,OfficeAutomation_Document_UtContract_YJCommissionRatio"
                           // + "           ,OfficeAutomation_Document_UtContract_YJDeadlines"
                           // + "           ,OfficeAutomation_Document_UtContract_Reserve"
                           // + "           ,OfficeAutomation_Document_UtContract_IsDirectContract"
                           // + "           ,OfficeAutomation_Document_UtContract_DirectContractName"
                           // + "           ,OfficeAutomation_Document_UtContract_DirectContractType"
                           // + "           ,OfficeAutomation_Document_UtContract_IsPreSale"
                        //    + "           ,OfficeAutomation_Document_UtContract_OverallScale"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtContract] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_UtContract_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_UtContract_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// 2016/8/24 52100新增项目所在地字段：OfficeAutomation_Document_UtContract_ddlProjectAddress
        /// 2016/10/27 52100新增了没带[]号的四十个当前表字段
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_UtContract_ID]"
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
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtContract] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_UtContract_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_UtContract_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据项目名称查询续约信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectContract(string i, string n)
        {
            string sql = "SELECT TOP 1 * FROM t_OfficeAutomation_Document_UtContract"
                        + " WHERE OfficeAutomation_Document_UtContract_Name" + i + " = '" + n + "'"
                        + " ORDER BY OfficeAutomation_Document_UtContract_ApplyDate DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据项目名称查询全部续约信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectContractAll(string i, string n)
        {
            string sql = "SELECT * FROM t_OfficeAutomation_Document_UtContract"
                        + " WHERE OfficeAutomation_Document_UtContract_Name" + i + " = '" + n + "'"
                        + " ORDER BY OfficeAutomation_Document_UtContract_ApplyDate DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据项目名称查询新盘信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectNewProj(string n)
        {
            string sql = "SELECT TOP 1 * FROM t_OfficeAutomation_Document_UtNewProj"
                        + " WHERE OfficeAutomation_Document_UtNewProj_Project = '" + n + "'"
                        + " ORDER BY OfficeAutomation_Document_UtNewProj_ApplyDate DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据项目名称查询全部新盘信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectNewProjAll(string n)
        {
            string sql = "SELECT * FROM t_OfficeAutomation_Document_UtNewProj"
                        + " WHERE OfficeAutomation_Document_UtNewProj_Project = '" + n + "'"
                        + " ORDER BY OfficeAutomation_Document_UtNewProj_ApplyDate DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据项目名称查询项目报备信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectNewUnderTP(string n)
        {
            string sql = "SELECT TOP 1 * FROM t_OfficeAutomation_Document_UndertakeProj"
                        + " WHERE OfficeAutomation_Document_UndertakeProj_Project = '" + n + "'"
                        + " ORDER BY OfficeAutomation_Document_UndertakeProj_ApplyDate DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据项目名称查询全部项目报备信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectNewUnderTPAll(string n)
        {
            string sql = "SELECT * FROM t_OfficeAutomation_Document_UndertakeProj"
                        + " WHERE OfficeAutomation_Document_UndertakeProj_Project = '" + n + "'"
                        + " ORDER BY OfficeAutomation_Document_UndertakeProj_ApplyDate DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据项目名称查询全部项目报数信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectReportDataAll(string n)
        {
            string sql = "SELECT * FROM t_OfficeAutomation_Document_ProjRepoData"
                        + " WHERE OfficeAutomation_Document_ProjRepoData_ProjName LIKE '" + n + "%'"
                        + " ORDER BY OfficeAutomation_Document_ProjRepoData_ApplyDate DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据项目名称查询全部项目联动报数信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectLinkReportDataAll(string n)
        {
            string sql = "SELECT * FROM t_OfficeAutomation_Document_ProjLinkRepoData"
                        + " WHERE OfficeAutomation_Document_ProjLinkRepoData_ProjName LIKE '" + n + "%'"
                        + " ORDER BY OfficeAutomation_Document_ProjLinkRepoData_ApplyDate DESC";

            return RunSQL(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_UtContract obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_UtContract_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_UtContract();
            Baseobj.OfficeAutomation_Document_UtContract_ID = obj.OfficeAutomation_Document_UtContract_ID;
            Baseobj.OfficeAutomation_Document_UtContract_MainID = obj.OfficeAutomation_Document_UtContract_MainID;
            Baseobj.OfficeAutomation_Document_UtContract_Apply = obj.OfficeAutomation_Document_UtContract_Apply;
            Baseobj.OfficeAutomation_Document_UtContract_ApplyDate = obj.OfficeAutomation_Document_UtContract_ApplyDate;
            Baseobj.OfficeAutomation_Document_UtContract_ApplyID = obj.OfficeAutomation_Document_UtContract_ApplyID;
            Baseobj.OfficeAutomation_Document_UtContract_Department = obj.OfficeAutomation_Document_UtContract_Department;
            Baseobj.OfficeAutomation_Document_UtContract_ddlProjectAddress = obj.OfficeAutomation_Document_UtContract_ddlProjectAddress;


            //obj是否已经存在
            var where = "[OfficeAutomation_Document_UtContract_MainID]='" + obj.OfficeAutomation_Document_UtContract_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_UtContract resultobj;
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
        /// 项目名 是否存在
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        public bool IsProjectNameExist( string Project)
        {
            if (string.IsNullOrEmpty(Project)) {
                return false;
            }
            string sql = string.Format("select OfficeAutomation_Document_UtNewProj_Project as ProjectName from [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj] where OfficeAutomation_Document_UtNewProj_Project='{0}'"
                        +" UNION"
                        +" SELECT  [OfficeAutomation_Document_UndertakeProj_Project]as ProjectName FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UndertakeProj] where [OfficeAutomation_Document_UndertakeProj_Project]='{0}'"
                          + " UNION"
                        +" SELECT  [OfficeAutomation_Document_ProjLinkRepoData_ProjName] as  ProjectName  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjLinkRepoData] where [OfficeAutomation_Document_ProjLinkRepoData_ProjName]='{0}'"
                        + " UNION"
                        +" SELECT  [OfficeAutomation_Document_ProjRepoData_ProjName]  as  ProjectName  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjRepoData] where [OfficeAutomation_Document_ProjRepoData_ProjName]='{0}'"
                        , Project);
          
            
            DataSet ds = RunSQL(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
