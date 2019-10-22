/*
* DA_OfficeAutomation_Document_UndertakeProj_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_UndertakeProj_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/8 11:41:58    张榕     初版
*
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
	/// <summary>
	/// 数据访问类:DA_OfficeAutomation_Document_UndertakeProj_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_UndertakeProj_Operate
	{
		public DA_OfficeAutomation_Document_UndertakeProj_Operate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_UndertakeProj_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_UndertakeProj");
			strSql.Append(" where OfficeAutomation_Document_UndertakeProj_ID=@OfficeAutomation_Document_UndertakeProj_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_UndertakeProj_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_UndertakeProj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_UndertakeProj(");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_ID,OfficeAutomation_Document_UndertakeProj_MainID,OfficeAutomation_Document_UndertakeProj_Apply,OfficeAutomation_Document_UndertakeProj_ApplyForName,OfficeAutomation_Document_UndertakeProj_ApplyForCode,OfficeAutomation_Document_UndertakeProj_Department,OfficeAutomation_Document_UndertakeProj_DepartmentID,OfficeAutomation_Document_UndertakeProj_ApplyDate,OfficeAutomation_Document_UndertakeProj_ReplyPhone,OfficeAutomation_Document_UndertakeProj_DepartmentTypeID,OfficeAutomation_Document_UndertakeProj_Project,OfficeAutomation_Document_UndertakeProj_Developer,OfficeAutomation_Document_UndertakeProj_GroupName,OfficeAutomation_Document_UndertakeProj_ProjectPropertyID,OfficeAutomation_Document_UndertakeProj_DealTypeID,OfficeAutomation_Document_UndertakeProj_AgentPropertyID,OfficeAutomation_Document_UndertakeProj_ProjectArea,OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs,OfficeAutomation_Document_UndertakeProj_ProjectAddress,OfficeAutomation_Document_UndertakeProj_DeveloperContacter,OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition,OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone,OfficeAutomation_Document_UndertakeProj_AreaCheckDataer,OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode,OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone,OfficeAutomation_Document_UndertakeProj_Square,OfficeAutomation_Document_UndertakeProj_SetNumber,OfficeAutomation_Document_UndertakeProj_UnitPrice,OfficeAutomation_Document_UndertakeProj_TotalPrice,OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale,OfficeAutomation_Document_UndertakeProj_ClientCommFixScale,OfficeAutomation_Document_UndertakeProj_AgentStartDate,OfficeAutomation_Document_UndertakeProj_AgentEndDate,OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate,OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate,OfficeAutomation_Document_UndertakeProj_PreCompleteNumber,OfficeAutomation_Document_UndertakeProj_PreCompleteMoney,OfficeAutomation_Document_UndertakeProj_PreCompleteComm,OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack,OfficeAutomation_Document_UndertakeProj_OweCommSum,OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate,OfficeAutomation_Document_UndertakeProj_HaveSingleReward,OfficeAutomation_Document_UndertakeProj_IsAllJumpBar,OfficeAutomation_Document_UndertakeProj_IsMallSplit,OfficeAutomation_Document_UndertakeProj_IsMallOpen,OfficeAutomation_Document_UndertakeProj_IsExistMortgage,OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules,OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses,OfficeAutomation_Document_UndertakeProj_IsUniteAgent,OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract,OfficeAutomation_Document_UndertakeProj_SaleModeID,OfficeAutomation_Document_UndertakeProj_AreaScale,OfficeAutomation_Document_UndertakeProj_MainAreaScale,OfficeAutomation_Document_UndertakeProj_DealAreaScale,OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce,OfficeAutomation_Document_UndertakeProj_ECommerceName,OfficeAutomation_Document_UndertakeProj_IsNeedExtension,OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast,OfficeAutomation_Document_UndertakeProj_LastBeginDate,OfficeAutomation_Document_UndertakeProj_LastEndDate,OfficeAutomation_Document_UndertakeProj_LastSumNum,OfficeAutomation_Document_UndertakeProj_LastResults,OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate,OfficeAutomation_Document_UndertakeProj_CumulativeEndDate,OfficeAutomation_Document_UndertakeProj_CumulativeNum,OfficeAutomation_Document_UndertakeProj_CumulativeResults,OfficeAutomation_Document_UndertakeProj_Turnover,OfficeAutomation_Document_UndertakeProj_SumTurnover,OfficeAutomation_Document_UndertakeProj_JOrT,OfficeAutomation_Document_UndertakeProj_SamePlaceXX1,OfficeAutomation_Document_UndertakeProj_SamePlaceXX2,OfficeAutomation_Document_UndertakeProj_SamePlaceXX3,OfficeAutomation_Document_UndertakeProj_SamePlaceXX4,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4,OfficeAutomation_Document_UndertakeProj_AgencyFee1,OfficeAutomation_Document_UndertakeProj_AgencyFee2,OfficeAutomation_Document_UndertakeProj_AgencyFee3,OfficeAutomation_Document_UndertakeProj_AgencyFee4,OfficeAutomation_Document_UndertakeProj_IsCashPrize1,OfficeAutomation_Document_UndertakeProj_IsCashPrize2,OfficeAutomation_Document_UndertakeProj_IsCashPrize3,OfficeAutomation_Document_UndertakeProj_IsCashPrize4,OfficeAutomation_Document_UndertakeProj_CashPrize1,OfficeAutomation_Document_UndertakeProj_CashPrize2,OfficeAutomation_Document_UndertakeProj_CashPrize3,OfficeAutomation_Document_UndertakeProj_CashPrize4,OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1,OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2,OfficeAutomation_Document_UndertakeProj_AgencyEndDate1,OfficeAutomation_Document_UndertakeProj_AgencyEndDate2,OfficeAutomation_Document_UndertakeProj_IsPFear1,OfficeAutomation_Document_UndertakeProj_IsPFear2,OfficeAutomation_Document_UndertakeProj_IsPFear3,OfficeAutomation_Document_UndertakeProj_IsPFear4,OfficeAutomation_Document_UndertakeProj_PFear1,OfficeAutomation_Document_UndertakeProj_PFear2,OfficeAutomation_Document_UndertakeProj_PFear3,OfficeAutomation_Document_UndertakeProj_PFear4,OfficeAutomation_Document_UndertakeProj_SubmitReward,OfficeAutomation_Document_UndertakeProj_OwnerCommJump,OfficeAutomation_Document_UndertakeProj_ClientCommJump,OfficeAutomation_Document_UndertakeProj_EBCommJump,OfficeAutomation_Document_UndertakeProj_RewardSignHave,OfficeAutomation_Document_UndertakeProj_RewardSignHavent,OfficeAutomation_Document_UndertakeProj_DeveloperConditions,OfficeAutomation_Document_UndertakeProj_AreaConditions,OfficeAutomation_Document_UndertakeProj_PayRewardWay,OfficeAutomation_Document_UndertakeProj_ReceiveRewardName,OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo,OfficeAutomation_Document_UndertakeProj_IsMyPay,OfficeAutomation_Document_UndertakeProj_OtherCondtion,OfficeAutomation_Document_UndertakeProj_AreaComfirn,OfficeAutomation_Document_UndertakeProj_ReturnBackDate,OfficeAutomation_Document_UndertakeProj_AnotherRewardC,OfficeAutomation_Document_UndertakeProj_PCDeduct,OfficeAutomation_Document_UndertakeProj_EBDeduct,OfficeAutomation_Document_UndertakeProj_BaseAgent,OfficeAutomation_Document_UndertakeProj_BaseAgentOther,OfficeAutomation_Document_UndertakeProj_IsUploadPlan,OfficeAutomation_Document_UndertakeProj_Flange,OfficeAutomation_Document_UndertakeProj_AnotherCompany,OfficeAutomation_Document_UndertakeProj_Referral,OfficeAutomation_Document_UndertakeProj_BreakUp,OfficeAutomation_Document_UndertakeProj_NCommissions,OfficeAutomation_Document_UndertakeProj_HasAtt,OfficeAutomation_Document_UndertakeProj_WillBreakUp,OfficeAutomation_Document_UndertakeProj_Remark,OfficeAutomation_Document_UndertakeProj_TermsOfContract,OfficeAutomation_Document_UndertakeProj_ReportAddress,OfficeAutomation_Document_UndertakeProj_ProjectCost,OfficeAutomation_Document_UndertakeProj_PCDeveloper,OfficeAutomation_Document_UndertakeProj_EBDeveloper,OfficeAutomation_Document_UndertakeProj_CooperationWay,OfficeAutomation_Document_UndertakeProj_NHComm,OfficeAutomation_Document_UndertakeProj_NHName,OfficeAutomation_Document_UndertakeProj_OwnerCommAgent,OfficeAutomation_Document_UndertakeProj_ClientCommAgent,OfficeAutomation_Document_UndertakeProj_EBComm,OfficeAutomation_Document_UndertakeProj_EBCommAgent,OfficeAutomation_Document_UndertakeProj_NHTime,OfficeAutomation_Document_UndertakeProj_Here,OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues)"); 
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_UndertakeProj_ID,@OfficeAutomation_Document_UndertakeProj_MainID,@OfficeAutomation_Document_UndertakeProj_Apply,@OfficeAutomation_Document_UndertakeProj_ApplyForName,@OfficeAutomation_Document_UndertakeProj_ApplyForCode,@OfficeAutomation_Document_UndertakeProj_Department,@OfficeAutomation_Document_UndertakeProj_DepartmentID,@OfficeAutomation_Document_UndertakeProj_ApplyDate,@OfficeAutomation_Document_UndertakeProj_ReplyPhone,@OfficeAutomation_Document_UndertakeProj_DepartmentTypeID,@OfficeAutomation_Document_UndertakeProj_Project,@OfficeAutomation_Document_UndertakeProj_Developer,@OfficeAutomation_Document_UndertakeProj_GroupName,@OfficeAutomation_Document_UndertakeProj_ProjectPropertyID,@OfficeAutomation_Document_UndertakeProj_DealTypeID,@OfficeAutomation_Document_UndertakeProj_AgentPropertyID,@OfficeAutomation_Document_UndertakeProj_ProjectArea,@OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs,@OfficeAutomation_Document_UndertakeProj_ProjectAddress,@OfficeAutomation_Document_UndertakeProj_DeveloperContacter,@OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition,@OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone,@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter,@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition,@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone,@OfficeAutomation_Document_UndertakeProj_AreaCheckDataer,@OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode,@OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone,@OfficeAutomation_Document_UndertakeProj_Square,@OfficeAutomation_Document_UndertakeProj_SetNumber,@OfficeAutomation_Document_UndertakeProj_UnitPrice,@OfficeAutomation_Document_UndertakeProj_TotalPrice,@OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale,@OfficeAutomation_Document_UndertakeProj_ClientCommFixScale,@OfficeAutomation_Document_UndertakeProj_AgentStartDate,@OfficeAutomation_Document_UndertakeProj_AgentEndDate,@OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate,@OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate,@OfficeAutomation_Document_UndertakeProj_PreCompleteNumber,@OfficeAutomation_Document_UndertakeProj_PreCompleteMoney,@OfficeAutomation_Document_UndertakeProj_PreCompleteComm,@OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack,@OfficeAutomation_Document_UndertakeProj_OweCommSum,@OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate,@OfficeAutomation_Document_UndertakeProj_HaveSingleReward,@OfficeAutomation_Document_UndertakeProj_IsAllJumpBar,@OfficeAutomation_Document_UndertakeProj_IsMallSplit,@OfficeAutomation_Document_UndertakeProj_IsMallOpen,@OfficeAutomation_Document_UndertakeProj_IsExistMortgage,@OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules,@OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses,@OfficeAutomation_Document_UndertakeProj_IsUniteAgent,@OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract,@OfficeAutomation_Document_UndertakeProj_SaleModeID,@OfficeAutomation_Document_UndertakeProj_AreaScale,@OfficeAutomation_Document_UndertakeProj_MainAreaScale,@OfficeAutomation_Document_UndertakeProj_DealAreaScale,@OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce,@OfficeAutomation_Document_UndertakeProj_ECommerceName,@OfficeAutomation_Document_UndertakeProj_IsNeedExtension,@OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast,@OfficeAutomation_Document_UndertakeProj_LastBeginDate,@OfficeAutomation_Document_UndertakeProj_LastEndDate,@OfficeAutomation_Document_UndertakeProj_LastSumNum,@OfficeAutomation_Document_UndertakeProj_LastResults,@OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate,@OfficeAutomation_Document_UndertakeProj_CumulativeEndDate,@OfficeAutomation_Document_UndertakeProj_CumulativeNum,@OfficeAutomation_Document_UndertakeProj_CumulativeResults,@OfficeAutomation_Document_UndertakeProj_Turnover,@OfficeAutomation_Document_UndertakeProj_SumTurnover,@OfficeAutomation_Document_UndertakeProj_JOrT,@OfficeAutomation_Document_UndertakeProj_SamePlaceXX1,@OfficeAutomation_Document_UndertakeProj_SamePlaceXX2,@OfficeAutomation_Document_UndertakeProj_SamePlaceXX3,@OfficeAutomation_Document_UndertakeProj_SamePlaceXX4,@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1,@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2,@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3,@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4,@OfficeAutomation_Document_UndertakeProj_AgencyFee1,@OfficeAutomation_Document_UndertakeProj_AgencyFee2,@OfficeAutomation_Document_UndertakeProj_AgencyFee3,@OfficeAutomation_Document_UndertakeProj_AgencyFee4,@OfficeAutomation_Document_UndertakeProj_IsCashPrize1,@OfficeAutomation_Document_UndertakeProj_IsCashPrize2,@OfficeAutomation_Document_UndertakeProj_IsCashPrize3,@OfficeAutomation_Document_UndertakeProj_IsCashPrize4,@OfficeAutomation_Document_UndertakeProj_CashPrize1,@OfficeAutomation_Document_UndertakeProj_CashPrize2,@OfficeAutomation_Document_UndertakeProj_CashPrize3,@OfficeAutomation_Document_UndertakeProj_CashPrize4,@OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1,@OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2,@OfficeAutomation_Document_UndertakeProj_AgencyEndDate1,@OfficeAutomation_Document_UndertakeProj_AgencyEndDate2,@OfficeAutomation_Document_UndertakeProj_IsPFear1,@OfficeAutomation_Document_UndertakeProj_IsPFear2,@OfficeAutomation_Document_UndertakeProj_IsPFear3,@OfficeAutomation_Document_UndertakeProj_IsPFear4,@OfficeAutomation_Document_UndertakeProj_PFear1,@OfficeAutomation_Document_UndertakeProj_PFear2,@OfficeAutomation_Document_UndertakeProj_PFear3,@OfficeAutomation_Document_UndertakeProj_PFear4,@OfficeAutomation_Document_UndertakeProj_SubmitReward,@OfficeAutomation_Document_UndertakeProj_OwnerCommJump,@OfficeAutomation_Document_UndertakeProj_ClientCommJump,@OfficeAutomation_Document_UndertakeProj_EBCommJump,@OfficeAutomation_Document_UndertakeProj_RewardSignHave,@OfficeAutomation_Document_UndertakeProj_RewardSignHavent,@OfficeAutomation_Document_UndertakeProj_DeveloperConditions,@OfficeAutomation_Document_UndertakeProj_AreaConditions,@OfficeAutomation_Document_UndertakeProj_PayRewardWay,@OfficeAutomation_Document_UndertakeProj_ReceiveRewardName,@OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo,@OfficeAutomation_Document_UndertakeProj_IsMyPay,@OfficeAutomation_Document_UndertakeProj_OtherCondtion,@OfficeAutomation_Document_UndertakeProj_AreaComfirn,@OfficeAutomation_Document_UndertakeProj_ReturnBackDate,@OfficeAutomation_Document_UndertakeProj_AnotherRewardC,@OfficeAutomation_Document_UndertakeProj_PCDeduct,@OfficeAutomation_Document_UndertakeProj_EBDeduct,@OfficeAutomation_Document_UndertakeProj_BaseAgent,@OfficeAutomation_Document_UndertakeProj_BaseAgentOther,@OfficeAutomation_Document_UndertakeProj_IsUploadPlan,@OfficeAutomation_Document_UndertakeProj_Flange,@OfficeAutomation_Document_UndertakeProj_AnotherCompany,@OfficeAutomation_Document_UndertakeProj_Referral,@OfficeAutomation_Document_UndertakeProj_BreakUp,@OfficeAutomation_Document_UndertakeProj_NCommissions,@OfficeAutomation_Document_UndertakeProj_HasAtt,@OfficeAutomation_Document_UndertakeProj_WillBreakUp,@OfficeAutomation_Document_UndertakeProj_Remark,@OfficeAutomation_Document_UndertakeProj_TermsOfContract,@OfficeAutomation_Document_UndertakeProj_ReportAddress,@OfficeAutomation_Document_UndertakeProj_ProjectCost,@OfficeAutomation_Document_UndertakeProj_PCDeveloper,@OfficeAutomation_Document_UndertakeProj_EBDeveloper,@OfficeAutomation_Document_UndertakeProj_CooperationWay,@OfficeAutomation_Document_UndertakeProj_NHComm,@OfficeAutomation_Document_UndertakeProj_NHName,@OfficeAutomation_Document_UndertakeProj_OwnerCommAgent,@OfficeAutomation_Document_UndertakeProj_ClientCommAgent,@OfficeAutomation_Document_UndertakeProj_EBComm,@OfficeAutomation_Document_UndertakeProj_EBCommAgent,@OfficeAutomation_Document_UndertakeProj_NHTime,@OfficeAutomation_Document_UndertakeProj_Here,@OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues)");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ApplyForCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DepartmentID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Project", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Developer", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_GroupName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ProjectPropertyID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DealTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgentPropertyID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ProjectArea", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ProjectAddress", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DeveloperContacter", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaCheckDataer", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Square", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SetNumber", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_UnitPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TotalPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientCommFixScale", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PreCommTotal", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgentStartDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgentEndDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PreCompleteNumber", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PreCompleteMoney", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PreCompleteComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack", SqlDbType.SmallInt,2),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OweCommSum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_HaveSingleReward", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsAllJumpBar", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsMallSplit", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsMallOpen", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsExistMortgage", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsUniteAgent", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SaleModeID", SqlDbType.Int,4),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_MainAreaScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DealAreaScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ECommerceName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsNeedExtension", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_LastBeginDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_LastEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_LastSumNum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_LastResults", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CumulativeEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CumulativeNum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CumulativeResults", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Turnover", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SumTurnover", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Remark", SqlDbType.NVarChar,2000),     
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TermsOfContract", SqlDbType.NVarChar,2000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReportAddress", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ProjectCost", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PCDeveloper", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBDeveloper", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CooperationWay", SqlDbType.Int,4),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_NHComm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_NHName", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OwnerCommAgent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientCommAgent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBComm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBCommAgent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_NHTime", SqlDbType.DateTime,8),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Here", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_JOrT", SqlDbType.Int,4),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SamePlaceXX1", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SamePlaceXX2", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SamePlaceXX3", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SamePlaceXX4", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyFee1", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyFee2", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyFee3", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyFee4", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCashPrize1", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCashPrize2", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCashPrize3", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCashPrize4", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CashPrize1", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CashPrize2", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CashPrize3", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CashPrize4", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyEndDate1", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyEndDate2", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsPFear1", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsPFear2", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsPFear3", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsPFear4", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PFear1", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PFear2", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PFear3", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PFear4", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SubmitReward", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OwnerCommJump", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientCommJump", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBCommJump", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_RewardSignHave", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_RewardSignHavent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DeveloperConditions", SqlDbType.NVarChar,2000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaConditions", SqlDbType.NVarChar,2000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PayRewardWay", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReceiveRewardName", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsMyPay", SqlDbType.Int,4),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OtherCondtion", SqlDbType.NVarChar,1000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaComfirn", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReturnBackDate", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AnotherRewardC", SqlDbType.NVarChar,1500),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PCDeduct", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBDeduct", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_BaseAgent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_BaseAgentOther", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsUploadPlan", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Flange", SqlDbType.NVarChar,2000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AnotherCompany", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Referral", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_BreakUp", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_NCommissions", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_HasAtt", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_WillBreakUp", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues", SqlDbType.NVarChar,2000)};

            parameters[0].Value = model.OfficeAutomation_Document_UndertakeProj_ID;
            parameters[1].Value = model.OfficeAutomation_Document_UndertakeProj_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_UndertakeProj_Apply;
			parameters[3].Value = model.OfficeAutomation_Document_UndertakeProj_ApplyForName;
			parameters[4].Value = model.OfficeAutomation_Document_UndertakeProj_ApplyForCode;
			parameters[5].Value = model.OfficeAutomation_Document_UndertakeProj_Department;
            parameters[6].Value = model.OfficeAutomation_Document_UndertakeProj_DepartmentID;
			parameters[7].Value = model.OfficeAutomation_Document_UndertakeProj_ApplyDate;
			parameters[8].Value = model.OfficeAutomation_Document_UndertakeProj_ReplyPhone;
			parameters[9].Value = model.OfficeAutomation_Document_UndertakeProj_DepartmentTypeID;
			parameters[10].Value = model.OfficeAutomation_Document_UndertakeProj_Project;
            parameters[11].Value = model.OfficeAutomation_Document_UndertakeProj_Developer;
            parameters[12].Value = model.OfficeAutomation_Document_UndertakeProj_GroupName;
			parameters[13].Value = model.OfficeAutomation_Document_UndertakeProj_ProjectPropertyID;
			parameters[14].Value = model.OfficeAutomation_Document_UndertakeProj_DealTypeID;
			parameters[15].Value = model.OfficeAutomation_Document_UndertakeProj_AgentPropertyID;
			parameters[16].Value = model.OfficeAutomation_Document_UndertakeProj_ProjectArea;
			parameters[17].Value = model.OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs;
			parameters[18].Value = model.OfficeAutomation_Document_UndertakeProj_ProjectAddress;
			parameters[19].Value = model.OfficeAutomation_Document_UndertakeProj_DeveloperContacter;
			parameters[20].Value = model.OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition;
			parameters[21].Value = model.OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone;
			parameters[22].Value = model.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter;
			parameters[23].Value = model.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition;
			parameters[24].Value = model.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone;
			parameters[25].Value = model.OfficeAutomation_Document_UndertakeProj_AreaCheckDataer;
			parameters[26].Value = model.OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode;
			parameters[27].Value = model.OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone;
			parameters[28].Value = model.OfficeAutomation_Document_UndertakeProj_Square;
			parameters[29].Value = model.OfficeAutomation_Document_UndertakeProj_SetNumber;
			parameters[30].Value = model.OfficeAutomation_Document_UndertakeProj_UnitPrice;
			parameters[31].Value = model.OfficeAutomation_Document_UndertakeProj_TotalPrice;
			parameters[32].Value = model.OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale;
			parameters[33].Value = model.OfficeAutomation_Document_UndertakeProj_ClientCommFixScale;
			//parameters[34].Value = model.OfficeAutomation_Document_UndertakeProj_PreCommTotal;
			parameters[34].Value = model.OfficeAutomation_Document_UndertakeProj_AgentStartDate;
			parameters[35].Value = model.OfficeAutomation_Document_UndertakeProj_AgentEndDate;
			parameters[36].Value = model.OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate;
			parameters[37].Value = model.OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate;
			parameters[38].Value = model.OfficeAutomation_Document_UndertakeProj_PreCompleteNumber;
			parameters[39].Value = model.OfficeAutomation_Document_UndertakeProj_PreCompleteMoney;
			parameters[40].Value = model.OfficeAutomation_Document_UndertakeProj_PreCompleteComm;
			parameters[41].Value = model.OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack;
			parameters[42].Value = model.OfficeAutomation_Document_UndertakeProj_OweCommSum;
			parameters[43].Value = model.OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate;
			parameters[44].Value = model.OfficeAutomation_Document_UndertakeProj_HaveSingleReward;
			parameters[45].Value = model.OfficeAutomation_Document_UndertakeProj_IsAllJumpBar;
			parameters[46].Value = model.OfficeAutomation_Document_UndertakeProj_IsMallSplit;
			parameters[47].Value = model.OfficeAutomation_Document_UndertakeProj_IsMallOpen;
			parameters[48].Value = model.OfficeAutomation_Document_UndertakeProj_IsExistMortgage;
			parameters[49].Value = model.OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules;
			parameters[50].Value = model.OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses;
			parameters[51].Value = model.OfficeAutomation_Document_UndertakeProj_IsUniteAgent;
			parameters[52].Value = model.OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract;
			parameters[53].Value = model.OfficeAutomation_Document_UndertakeProj_SaleModeID;

            parameters[54].Value = model.OfficeAutomation_Document_UndertakeProj_AreaScale;

			parameters[55].Value = model.OfficeAutomation_Document_UndertakeProj_MainAreaScale;
			parameters[56].Value = model.OfficeAutomation_Document_UndertakeProj_DealAreaScale;
            parameters[57].Value = model.OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce ;
            parameters[58].Value = model.OfficeAutomation_Document_UndertakeProj_ECommerceName;
            parameters[59].Value = model.OfficeAutomation_Document_UndertakeProj_IsNeedExtension;
			parameters[60].Value = model.OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast;
			parameters[61].Value = model.OfficeAutomation_Document_UndertakeProj_LastBeginDate;
			parameters[62].Value = model.OfficeAutomation_Document_UndertakeProj_LastEndDate;
			parameters[63].Value = model.OfficeAutomation_Document_UndertakeProj_LastSumNum;
			parameters[64].Value = model.OfficeAutomation_Document_UndertakeProj_LastResults;
			parameters[65].Value = model.OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate;
			parameters[66].Value = model.OfficeAutomation_Document_UndertakeProj_CumulativeEndDate;
			parameters[67].Value = model.OfficeAutomation_Document_UndertakeProj_CumulativeNum;
            parameters[68].Value = model.OfficeAutomation_Document_UndertakeProj_CumulativeResults;
            parameters[69].Value = model.OfficeAutomation_Document_UndertakeProj_Turnover;
            parameters[70].Value = model.OfficeAutomation_Document_UndertakeProj_SumTurnover;
			parameters[71].Value = model.OfficeAutomation_Document_UndertakeProj_Remark;
            parameters[72].Value = model.OfficeAutomation_Document_UndertakeProj_TermsOfContract;
            parameters[73].Value = model.OfficeAutomation_Document_UndertakeProj_ReportAddress;
            parameters[74].Value = model.OfficeAutomation_Document_UndertakeProj_ProjectCost;
            parameters[75].Value = model.OfficeAutomation_Document_UndertakeProj_PCDeveloper;
            parameters[76].Value = model.OfficeAutomation_Document_UndertakeProj_EBDeveloper;
            parameters[77].Value = model.OfficeAutomation_Document_UndertakeProj_CooperationWay;
            parameters[78].Value = model.OfficeAutomation_Document_UndertakeProj_NHComm;
            parameters[79].Value = model.OfficeAutomation_Document_UndertakeProj_NHName;
            parameters[80].Value = model.OfficeAutomation_Document_UndertakeProj_OwnerCommAgent;
            parameters[81].Value = model.OfficeAutomation_Document_UndertakeProj_ClientCommAgent;
            parameters[82].Value = model.OfficeAutomation_Document_UndertakeProj_EBComm;
            parameters[83].Value = model.OfficeAutomation_Document_UndertakeProj_EBCommAgent;
            parameters[84].Value = model.OfficeAutomation_Document_UndertakeProj_NHTime;
            parameters[85].Value = model.OfficeAutomation_Document_UndertakeProj_Here;
            parameters[86].Value = model.OfficeAutomation_Document_UndertakeProj_JOrT;
            parameters[87].Value = model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX1;
            parameters[88].Value = model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX2;
            parameters[89].Value = model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX3;
            parameters[90].Value = model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX4;
            parameters[91].Value = model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1;
            parameters[92].Value = model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2;
            parameters[93].Value = model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3;
            parameters[94].Value = model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4;

            parameters[95].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyFee1;
            parameters[96].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyFee2;
            parameters[97].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyFee3;
            parameters[98].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyFee4;
            parameters[99].Value = model.OfficeAutomation_Document_UndertakeProj_IsCashPrize1;
            parameters[100].Value = model.OfficeAutomation_Document_UndertakeProj_IsCashPrize2;
            parameters[101].Value = model.OfficeAutomation_Document_UndertakeProj_IsCashPrize3;
            parameters[102].Value = model.OfficeAutomation_Document_UndertakeProj_IsCashPrize4;
            parameters[103].Value = model.OfficeAutomation_Document_UndertakeProj_CashPrize1;
            parameters[104].Value = model.OfficeAutomation_Document_UndertakeProj_CashPrize2;
            parameters[105].Value = model.OfficeAutomation_Document_UndertakeProj_CashPrize3;
            parameters[106].Value = model.OfficeAutomation_Document_UndertakeProj_CashPrize4;
            parameters[107].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1;
            parameters[108].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2;
            parameters[109].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyEndDate1;
            parameters[110].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyEndDate2;
            parameters[111].Value = model.OfficeAutomation_Document_UndertakeProj_IsPFear1;
            parameters[112].Value = model.OfficeAutomation_Document_UndertakeProj_IsPFear2;
            parameters[113].Value = model.OfficeAutomation_Document_UndertakeProj_IsPFear3;
            parameters[114].Value = model.OfficeAutomation_Document_UndertakeProj_IsPFear4;
            parameters[115].Value = model.OfficeAutomation_Document_UndertakeProj_PFear1;
            parameters[116].Value = model.OfficeAutomation_Document_UndertakeProj_PFear2;
            parameters[117].Value = model.OfficeAutomation_Document_UndertakeProj_PFear3;
            parameters[118].Value = model.OfficeAutomation_Document_UndertakeProj_PFear4;
            parameters[119].Value = model.OfficeAutomation_Document_UndertakeProj_SubmitReward;
            parameters[120].Value = model.OfficeAutomation_Document_UndertakeProj_OwnerCommJump;
            parameters[121].Value = model.OfficeAutomation_Document_UndertakeProj_ClientCommJump;
            parameters[122].Value = model.OfficeAutomation_Document_UndertakeProj_EBCommJump;
            parameters[123].Value = model.OfficeAutomation_Document_UndertakeProj_RewardSignHave;
            parameters[124].Value = model.OfficeAutomation_Document_UndertakeProj_RewardSignHavent;

            //parameters[123].Precision = 28;
            //parameters[123].Scale = 10;
            //parameters[124].Precision = 28;
            //parameters[124].Scale = 10;

            parameters[125].Value = model.OfficeAutomation_Document_UndertakeProj_DeveloperConditions;
            parameters[126].Value = model.OfficeAutomation_Document_UndertakeProj_AreaConditions;
            parameters[127].Value = model.OfficeAutomation_Document_UndertakeProj_PayRewardWay;
            parameters[128].Value = model.OfficeAutomation_Document_UndertakeProj_ReceiveRewardName;
            parameters[129].Value = model.OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo;
            parameters[130].Value = model.OfficeAutomation_Document_UndertakeProj_IsMyPay;
            parameters[131].Value = model.OfficeAutomation_Document_UndertakeProj_OtherCondtion;
            parameters[132].Value = model.OfficeAutomation_Document_UndertakeProj_AreaComfirn;
            parameters[133].Value = model.OfficeAutomation_Document_UndertakeProj_ReturnBackDate;
            parameters[134].Value = model.OfficeAutomation_Document_UndertakeProj_AnotherRewardC;
            parameters[135].Value = model.OfficeAutomation_Document_UndertakeProj_PCDeduct;
            parameters[136].Value = model.OfficeAutomation_Document_UndertakeProj_EBDeduct;
            parameters[137].Value = model.OfficeAutomation_Document_UndertakeProj_BaseAgent;
            parameters[138].Value = model.OfficeAutomation_Document_UndertakeProj_BaseAgentOther;
            parameters[139].Value = model.OfficeAutomation_Document_UndertakeProj_IsUploadPlan;
            parameters[140].Value = model.OfficeAutomation_Document_UndertakeProj_Flange;
            parameters[141].Value = model.OfficeAutomation_Document_UndertakeProj_AnotherCompany;
            parameters[142].Value = model.OfficeAutomation_Document_UndertakeProj_Referral;
            parameters[143].Value = model.OfficeAutomation_Document_UndertakeProj_BreakUp;
            parameters[144].Value = model.OfficeAutomation_Document_UndertakeProj_NCommissions;
            parameters[145].Value = model.OfficeAutomation_Document_UndertakeProj_HasAtt;
            parameters[146].Value = model.OfficeAutomation_Document_UndertakeProj_WillBreakUp;

            parameters[147].Value = model.OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DataEntity.T_OfficeAutomation_Document_UndertakeProj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_UndertakeProj set ");
            //strSql.Append("OfficeAutomation_Document_UndertakeProj_MainID=@OfficeAutomation_Document_UndertakeProj_MainID,");
            //strSql.Append("OfficeAutomation_Document_UndertakeProj_Apply=@OfficeAutomation_Document_UndertakeProj_Apply,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_ApplyForName=@OfficeAutomation_Document_UndertakeProj_ApplyForName,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_ApplyForCode=@OfficeAutomation_Document_UndertakeProj_ApplyForCode,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_Department=@OfficeAutomation_Document_UndertakeProj_Department,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_DepartmentID=@OfficeAutomation_Document_UndertakeProj_DepartmentID,");
            //strSql.Append("OfficeAutomation_Document_UndertakeProj_ApplyDate=@OfficeAutomation_Document_UndertakeProj_ApplyDate,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_ReplyPhone=@OfficeAutomation_Document_UndertakeProj_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_DepartmentTypeID=@OfficeAutomation_Document_UndertakeProj_DepartmentTypeID,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_Project=@OfficeAutomation_Document_UndertakeProj_Project,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_Developer=@OfficeAutomation_Document_UndertakeProj_Developer,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_GroupName=@OfficeAutomation_Document_UndertakeProj_GroupName,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_ProjectPropertyID=@OfficeAutomation_Document_UndertakeProj_ProjectPropertyID,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_DealTypeID=@OfficeAutomation_Document_UndertakeProj_DealTypeID,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AgentPropertyID=@OfficeAutomation_Document_UndertakeProj_AgentPropertyID,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_ProjectArea=@OfficeAutomation_Document_UndertakeProj_ProjectArea,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs=@OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_ProjectAddress=@OfficeAutomation_Document_UndertakeProj_ProjectAddress,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_DeveloperContacter=@OfficeAutomation_Document_UndertakeProj_DeveloperContacter,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition=@OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone=@OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter=@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition=@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone=@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaCheckDataer=@OfficeAutomation_Document_UndertakeProj_AreaCheckDataer,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode=@OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone=@OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_Square=@OfficeAutomation_Document_UndertakeProj_Square,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_SetNumber=@OfficeAutomation_Document_UndertakeProj_SetNumber,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_UnitPrice=@OfficeAutomation_Document_UndertakeProj_UnitPrice,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_TotalPrice=@OfficeAutomation_Document_UndertakeProj_TotalPrice,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale=@OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_ClientCommFixScale=@OfficeAutomation_Document_UndertakeProj_ClientCommFixScale,");
			//strSql.Append("OfficeAutomation_Document_UndertakeProj_PreCommTotal=@OfficeAutomation_Document_UndertakeProj_PreCommTotal,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AgentStartDate=@OfficeAutomation_Document_UndertakeProj_AgentStartDate,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AgentEndDate=@OfficeAutomation_Document_UndertakeProj_AgentEndDate,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate=@OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate=@OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_PreCompleteNumber=@OfficeAutomation_Document_UndertakeProj_PreCompleteNumber,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_PreCompleteMoney=@OfficeAutomation_Document_UndertakeProj_PreCompleteMoney,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_PreCompleteComm=@OfficeAutomation_Document_UndertakeProj_PreCompleteComm,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack=@OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_OweCommSum=@OfficeAutomation_Document_UndertakeProj_OweCommSum,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate=@OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_HaveSingleReward=@OfficeAutomation_Document_UndertakeProj_HaveSingleReward,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_IsAllJumpBar=@OfficeAutomation_Document_UndertakeProj_IsAllJumpBar,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_IsMallSplit=@OfficeAutomation_Document_UndertakeProj_IsMallSplit,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_IsMallOpen=@OfficeAutomation_Document_UndertakeProj_IsMallOpen,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_IsExistMortgage=@OfficeAutomation_Document_UndertakeProj_IsExistMortgage,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules=@OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses=@OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_IsUniteAgent=@OfficeAutomation_Document_UndertakeProj_IsUniteAgent,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract=@OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_SaleModeID=@OfficeAutomation_Document_UndertakeProj_SaleModeID,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaScale=@OfficeAutomation_Document_UndertakeProj_AreaScale,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_MainAreaScale=@OfficeAutomation_Document_UndertakeProj_MainAreaScale,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_DealAreaScale=@OfficeAutomation_Document_UndertakeProj_DealAreaScale,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce=@OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_ECommerceName=@OfficeAutomation_Document_UndertakeProj_ECommerceName,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsNeedExtension=@OfficeAutomation_Document_UndertakeProj_IsNeedExtension,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast=@OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_LastBeginDate=@OfficeAutomation_Document_UndertakeProj_LastBeginDate,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_LastEndDate=@OfficeAutomation_Document_UndertakeProj_LastEndDate,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_LastSumNum=@OfficeAutomation_Document_UndertakeProj_LastSumNum,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_LastResults=@OfficeAutomation_Document_UndertakeProj_LastResults,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate=@OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_CumulativeEndDate=@OfficeAutomation_Document_UndertakeProj_CumulativeEndDate,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_CumulativeNum=@OfficeAutomation_Document_UndertakeProj_CumulativeNum,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_CumulativeResults=@OfficeAutomation_Document_UndertakeProj_CumulativeResults,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_Turnover=@OfficeAutomation_Document_UndertakeProj_Turnover,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_SumTurnover=@OfficeAutomation_Document_UndertakeProj_SumTurnover,");
			strSql.Append("OfficeAutomation_Document_UndertakeProj_Remark=@OfficeAutomation_Document_UndertakeProj_Remark,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_TermsOfContract=@OfficeAutomation_Document_UndertakeProj_TermsOfContract,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_ReportAddress=@OfficeAutomation_Document_UndertakeProj_ReportAddress,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_ProjectCost=@OfficeAutomation_Document_UndertakeProj_ProjectCost,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_PCDeveloper=@OfficeAutomation_Document_UndertakeProj_PCDeveloper,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_EBDeveloper=@OfficeAutomation_Document_UndertakeProj_EBDeveloper,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_CooperationWay=@OfficeAutomation_Document_UndertakeProj_CooperationWay,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_NHComm=@OfficeAutomation_Document_UndertakeProj_NHComm,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_NHName=@OfficeAutomation_Document_UndertakeProj_NHName,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_OwnerCommAgent=@OfficeAutomation_Document_UndertakeProj_OwnerCommAgent,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_ClientCommAgent=@OfficeAutomation_Document_UndertakeProj_ClientCommAgent,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_EBComm=@OfficeAutomation_Document_UndertakeProj_EBComm,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_EBCommAgent=@OfficeAutomation_Document_UndertakeProj_EBCommAgent,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_NHTime=@OfficeAutomation_Document_UndertakeProj_NHTime,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_Here=@OfficeAutomation_Document_UndertakeProj_Here,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_JOrT=@OfficeAutomation_Document_UndertakeProj_JOrT,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_SamePlaceXX1=@OfficeAutomation_Document_UndertakeProj_SamePlaceXX1,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_SamePlaceXX2=@OfficeAutomation_Document_UndertakeProj_SamePlaceXX2,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_SamePlaceXX3=@OfficeAutomation_Document_UndertakeProj_SamePlaceXX3,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_SamePlaceXX4=@OfficeAutomation_Document_UndertakeProj_SamePlaceXX4,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1=@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2=@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3=@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4=@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4,");

            strSql.Append("OfficeAutomation_Document_UndertakeProj_AgencyFee1=@OfficeAutomation_Document_UndertakeProj_AgencyFee1,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AgencyFee2=@OfficeAutomation_Document_UndertakeProj_AgencyFee2,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AgencyFee3=@OfficeAutomation_Document_UndertakeProj_AgencyFee3,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AgencyFee4=@OfficeAutomation_Document_UndertakeProj_AgencyFee4,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsCashPrize1=@OfficeAutomation_Document_UndertakeProj_IsCashPrize1,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsCashPrize2=@OfficeAutomation_Document_UndertakeProj_IsCashPrize2,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsCashPrize3=@OfficeAutomation_Document_UndertakeProj_IsCashPrize3,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsCashPrize4=@OfficeAutomation_Document_UndertakeProj_IsCashPrize4,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_CashPrize1=@OfficeAutomation_Document_UndertakeProj_CashPrize1,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_CashPrize2=@OfficeAutomation_Document_UndertakeProj_CashPrize2,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_CashPrize3=@OfficeAutomation_Document_UndertakeProj_CashPrize3,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_CashPrize4=@OfficeAutomation_Document_UndertakeProj_CashPrize4,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1=@OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2=@OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AgencyEndDate1=@OfficeAutomation_Document_UndertakeProj_AgencyEndDate1,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AgencyEndDate2=@OfficeAutomation_Document_UndertakeProj_AgencyEndDate2,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsPFear1=@OfficeAutomation_Document_UndertakeProj_IsPFear1,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsPFear2=@OfficeAutomation_Document_UndertakeProj_IsPFear2,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsPFear3=@OfficeAutomation_Document_UndertakeProj_IsPFear3,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsPFear4=@OfficeAutomation_Document_UndertakeProj_IsPFear4,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_PFear1=@OfficeAutomation_Document_UndertakeProj_PFear1,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_PFear2=@OfficeAutomation_Document_UndertakeProj_PFear2,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_PFear3=@OfficeAutomation_Document_UndertakeProj_PFear3,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_PFear4=@OfficeAutomation_Document_UndertakeProj_PFear4,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_SubmitReward=@OfficeAutomation_Document_UndertakeProj_SubmitReward,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_OwnerCommJump=@OfficeAutomation_Document_UndertakeProj_OwnerCommJump,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_ClientCommJump=@OfficeAutomation_Document_UndertakeProj_ClientCommJump,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_EBCommJump=@OfficeAutomation_Document_UndertakeProj_EBCommJump,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_RewardSignHave=@OfficeAutomation_Document_UndertakeProj_RewardSignHave,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_RewardSignHavent=@OfficeAutomation_Document_UndertakeProj_RewardSignHavent,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_DeveloperConditions=@OfficeAutomation_Document_UndertakeProj_DeveloperConditions,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaConditions=@OfficeAutomation_Document_UndertakeProj_AreaConditions,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_PayRewardWay=@OfficeAutomation_Document_UndertakeProj_PayRewardWay,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_ReceiveRewardName=@OfficeAutomation_Document_UndertakeProj_ReceiveRewardName,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo=@OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsMyPay=@OfficeAutomation_Document_UndertakeProj_IsMyPay,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_OtherCondtion=@OfficeAutomation_Document_UndertakeProj_OtherCondtion,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AreaComfirn=@OfficeAutomation_Document_UndertakeProj_AreaComfirn,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_ReturnBackDate=@OfficeAutomation_Document_UndertakeProj_ReturnBackDate,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AnotherRewardC=@OfficeAutomation_Document_UndertakeProj_AnotherRewardC,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_PCDeduct=@OfficeAutomation_Document_UndertakeProj_PCDeduct,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_EBDeduct=@OfficeAutomation_Document_UndertakeProj_EBDeduct,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_BaseAgent=@OfficeAutomation_Document_UndertakeProj_BaseAgent,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_BaseAgentOther=@OfficeAutomation_Document_UndertakeProj_BaseAgentOther,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_IsUploadPlan=@OfficeAutomation_Document_UndertakeProj_IsUploadPlan,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_Flange=@OfficeAutomation_Document_UndertakeProj_Flange,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_AnotherCompany=@OfficeAutomation_Document_UndertakeProj_AnotherCompany,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_Referral=@OfficeAutomation_Document_UndertakeProj_Referral,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_BreakUp=@OfficeAutomation_Document_UndertakeProj_BreakUp,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_NCommissions=@OfficeAutomation_Document_UndertakeProj_NCommissions,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_HasAtt=@OfficeAutomation_Document_UndertakeProj_HasAtt,");
            strSql.Append("OfficeAutomation_Document_UndertakeProj_WillBreakUp=@OfficeAutomation_Document_UndertakeProj_WillBreakUp,");

            strSql.Append("OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues=@OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues");
			strSql.Append(" where OfficeAutomation_Document_UndertakeProj_ID=@OfficeAutomation_Document_UndertakeProj_ID ");
			SqlParameter[] parameters = {
                    //new SqlParameter("@OfficeAutomation_Document_UndertakeProj_MainID", SqlDbType.UniqueIdentifier,16),
                    //new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ApplyForCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DepartmentID", SqlDbType.UniqueIdentifier,16),
                    //new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Project", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Developer", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_GroupName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ProjectPropertyID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DealTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgentPropertyID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ProjectArea", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ProjectAddress", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DeveloperContacter", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaCheckDataer", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Square", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SetNumber", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_UnitPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TotalPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientCommFixScale", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PreCommTotal", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgentStartDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgentEndDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PreCompleteNumber", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PreCompleteMoney", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PreCompleteComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack", SqlDbType.SmallInt,2),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OweCommSum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate", SqlDbType.DateTime,3),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_HaveSingleReward", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsAllJumpBar", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsMallSplit", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsMallOpen", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsExistMortgage", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsUniteAgent", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SaleModeID", SqlDbType.Int,4),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_MainAreaScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DealAreaScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ECommerceName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsNeedExtension", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_LastBeginDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_LastEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_LastSumNum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_LastResults", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CumulativeEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CumulativeNum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CumulativeResults", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Turnover", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SumTurnover", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Remark", SqlDbType.NVarChar,2000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TermsOfContract", SqlDbType.NVarChar,2000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReportAddress", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ProjectCost", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PCDeveloper", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBDeveloper", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CooperationWay", SqlDbType.Int,4),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_NHComm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_NHName", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OwnerCommAgent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientCommAgent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBComm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBCommAgent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_NHTime", SqlDbType.DateTime,8),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Here", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SamePlaceXX3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SamePlaceXX4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PFear4", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_SubmitReward", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OwnerCommJump", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ClientCommJump", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBCommJump", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_RewardSignHave", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_RewardSignHavent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_DeveloperConditions", SqlDbType.NVarChar,2000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaConditions", SqlDbType.NVarChar,2000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PayRewardWay", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReceiveRewardName", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsMyPay", SqlDbType.Int,4),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_OtherCondtion", SqlDbType.NVarChar,1000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AreaComfirn", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ReturnBackDate", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AnotherRewardC", SqlDbType.NVarChar,1500),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_PCDeduct", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_EBDeduct", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_BaseAgent", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_BaseAgentOther", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_IsUploadPlan", SqlDbType.Bit,1),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Flange", SqlDbType.NVarChar,2000),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_AnotherCompany", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_Referral", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_BreakUp", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_NCommissions", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_HasAtt", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_WillBreakUp", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues", SqlDbType.NVarChar,2000),
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ID", SqlDbType.UniqueIdentifier,16)};
            //parameters[0].Value = model.OfficeAutomation_Document_UndertakeProj_MainID;
            //parameters[1].Value = model.OfficeAutomation_Document_UndertakeProj_Apply;
			parameters[0].Value = model.OfficeAutomation_Document_UndertakeProj_ApplyForName;
			parameters[1].Value = model.OfficeAutomation_Document_UndertakeProj_ApplyForCode;
			parameters[2].Value = model.OfficeAutomation_Document_UndertakeProj_Department;
			parameters[3].Value = model.OfficeAutomation_Document_UndertakeProj_DepartmentID;
            //parameters[6].Value = model.OfficeAutomation_Document_UndertakeProj_ApplyDate;
			parameters[4].Value = model.OfficeAutomation_Document_UndertakeProj_ReplyPhone;
			parameters[5].Value = model.OfficeAutomation_Document_UndertakeProj_DepartmentTypeID;
			parameters[6].Value = model.OfficeAutomation_Document_UndertakeProj_Project;
            parameters[7].Value = model.OfficeAutomation_Document_UndertakeProj_Developer;
            parameters[8].Value = model.OfficeAutomation_Document_UndertakeProj_GroupName;
			parameters[9].Value = model.OfficeAutomation_Document_UndertakeProj_ProjectPropertyID;
			parameters[10].Value = model.OfficeAutomation_Document_UndertakeProj_DealTypeID;
			parameters[11].Value = model.OfficeAutomation_Document_UndertakeProj_AgentPropertyID;
			parameters[12].Value = model.OfficeAutomation_Document_UndertakeProj_ProjectArea;
			parameters[13].Value = model.OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs;
			parameters[14].Value = model.OfficeAutomation_Document_UndertakeProj_ProjectAddress;
			parameters[15].Value = model.OfficeAutomation_Document_UndertakeProj_DeveloperContacter;
			parameters[16].Value = model.OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition;
			parameters[17].Value = model.OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone;
			parameters[18].Value = model.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter;
			parameters[19].Value = model.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition;
			parameters[20].Value = model.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone;
			parameters[21].Value = model.OfficeAutomation_Document_UndertakeProj_AreaCheckDataer;
			parameters[22].Value = model.OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode;
			parameters[23].Value = model.OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone;
			parameters[24].Value = model.OfficeAutomation_Document_UndertakeProj_Square;
			parameters[25].Value = model.OfficeAutomation_Document_UndertakeProj_SetNumber;
			parameters[26].Value = model.OfficeAutomation_Document_UndertakeProj_UnitPrice;
			parameters[27].Value = model.OfficeAutomation_Document_UndertakeProj_TotalPrice;
			parameters[28].Value = model.OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale;
			parameters[29].Value = model.OfficeAutomation_Document_UndertakeProj_ClientCommFixScale;
			//parameters[30].Value = model.OfficeAutomation_Document_UndertakeProj_PreCommTotal;
			parameters[30].Value = model.OfficeAutomation_Document_UndertakeProj_AgentStartDate;
			parameters[31].Value = model.OfficeAutomation_Document_UndertakeProj_AgentEndDate;
			parameters[32].Value = model.OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate;
			parameters[33].Value = model.OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate;
			parameters[34].Value = model.OfficeAutomation_Document_UndertakeProj_PreCompleteNumber;
			parameters[35].Value = model.OfficeAutomation_Document_UndertakeProj_PreCompleteMoney;
			parameters[36].Value = model.OfficeAutomation_Document_UndertakeProj_PreCompleteComm;
			parameters[37].Value = model.OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack;
			parameters[38].Value = model.OfficeAutomation_Document_UndertakeProj_OweCommSum;
			parameters[39].Value = model.OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate;
			parameters[40].Value = model.OfficeAutomation_Document_UndertakeProj_HaveSingleReward;
			parameters[41].Value = model.OfficeAutomation_Document_UndertakeProj_IsAllJumpBar;
			parameters[42].Value = model.OfficeAutomation_Document_UndertakeProj_IsMallSplit;
			parameters[43].Value = model.OfficeAutomation_Document_UndertakeProj_IsMallOpen;
			parameters[44].Value = model.OfficeAutomation_Document_UndertakeProj_IsExistMortgage;
			parameters[45].Value = model.OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules;
			parameters[46].Value = model.OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses;
			parameters[47].Value = model.OfficeAutomation_Document_UndertakeProj_IsUniteAgent;
			parameters[48].Value = model.OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract;
			parameters[49].Value = model.OfficeAutomation_Document_UndertakeProj_SaleModeID;
            parameters[50].Value = model.OfficeAutomation_Document_UndertakeProj_AreaScale;
			parameters[51].Value = model.OfficeAutomation_Document_UndertakeProj_MainAreaScale;
			parameters[52].Value = model.OfficeAutomation_Document_UndertakeProj_DealAreaScale;
            parameters[53].Value = model.OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce;
            parameters[54].Value = model.OfficeAutomation_Document_UndertakeProj_ECommerceName;
            parameters[55].Value = model.OfficeAutomation_Document_UndertakeProj_IsNeedExtension;
			parameters[56].Value = model.OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast;
			parameters[57].Value = model.OfficeAutomation_Document_UndertakeProj_LastBeginDate;
			parameters[58].Value = model.OfficeAutomation_Document_UndertakeProj_LastEndDate;
			parameters[59].Value = model.OfficeAutomation_Document_UndertakeProj_LastSumNum;
			parameters[60].Value = model.OfficeAutomation_Document_UndertakeProj_LastResults;
			parameters[61].Value = model.OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate;
			parameters[62].Value = model.OfficeAutomation_Document_UndertakeProj_CumulativeEndDate;
			parameters[63].Value = model.OfficeAutomation_Document_UndertakeProj_CumulativeNum;
            parameters[64].Value = model.OfficeAutomation_Document_UndertakeProj_CumulativeResults;
            parameters[65].Value = model.OfficeAutomation_Document_UndertakeProj_Turnover;
            parameters[66].Value = model.OfficeAutomation_Document_UndertakeProj_SumTurnover;
			parameters[67].Value = model.OfficeAutomation_Document_UndertakeProj_Remark;
            parameters[68].Value = model.OfficeAutomation_Document_UndertakeProj_TermsOfContract;
            parameters[69].Value = model.OfficeAutomation_Document_UndertakeProj_ReportAddress;
            parameters[70].Value = model.OfficeAutomation_Document_UndertakeProj_ProjectCost;
            parameters[71].Value = model.OfficeAutomation_Document_UndertakeProj_PCDeveloper;
            parameters[72].Value = model.OfficeAutomation_Document_UndertakeProj_EBDeveloper;
            parameters[73].Value = model.OfficeAutomation_Document_UndertakeProj_CooperationWay;
            parameters[74].Value = model.OfficeAutomation_Document_UndertakeProj_NHComm;
            parameters[75].Value = model.OfficeAutomation_Document_UndertakeProj_NHName;
            parameters[76].Value = model.OfficeAutomation_Document_UndertakeProj_OwnerCommAgent;
            parameters[77].Value = model.OfficeAutomation_Document_UndertakeProj_ClientCommAgent;
            parameters[78].Value = model.OfficeAutomation_Document_UndertakeProj_EBComm;
            parameters[79].Value = model.OfficeAutomation_Document_UndertakeProj_EBCommAgent;
            parameters[80].Value = model.OfficeAutomation_Document_UndertakeProj_NHTime;
            parameters[81].Value = model.OfficeAutomation_Document_UndertakeProj_Here;
            parameters[82].Value = model.OfficeAutomation_Document_UndertakeProj_JOrT;
            parameters[83].Value = model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX1;
            parameters[84].Value = model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX2;
            parameters[85].Value = model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX3;
            parameters[86].Value = model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX4;
            parameters[87].Value = model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1;
            parameters[88].Value = model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2;
            parameters[89].Value = model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3;
            parameters[90].Value = model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4;

            parameters[91].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyFee1;
            parameters[92].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyFee2;
            parameters[93].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyFee3;
            parameters[94].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyFee4;
            parameters[95].Value = model.OfficeAutomation_Document_UndertakeProj_IsCashPrize1;
            parameters[96].Value = model.OfficeAutomation_Document_UndertakeProj_IsCashPrize2;
            parameters[97].Value = model.OfficeAutomation_Document_UndertakeProj_IsCashPrize3;
            parameters[98].Value = model.OfficeAutomation_Document_UndertakeProj_IsCashPrize4;
            parameters[99].Value = model.OfficeAutomation_Document_UndertakeProj_CashPrize1;
            parameters[100].Value = model.OfficeAutomation_Document_UndertakeProj_CashPrize2;
            parameters[101].Value = model.OfficeAutomation_Document_UndertakeProj_CashPrize3;
            parameters[102].Value = model.OfficeAutomation_Document_UndertakeProj_CashPrize4;
            parameters[103].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1;
            parameters[104].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2;
            parameters[105].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyEndDate1;
            parameters[106].Value = model.OfficeAutomation_Document_UndertakeProj_AgencyEndDate2;
            parameters[107].Value = model.OfficeAutomation_Document_UndertakeProj_IsPFear1;
            parameters[108].Value = model.OfficeAutomation_Document_UndertakeProj_IsPFear2;
            parameters[109].Value = model.OfficeAutomation_Document_UndertakeProj_IsPFear3;
            parameters[110].Value = model.OfficeAutomation_Document_UndertakeProj_IsPFear4;
            parameters[111].Value = model.OfficeAutomation_Document_UndertakeProj_PFear1;
            parameters[112].Value = model.OfficeAutomation_Document_UndertakeProj_PFear2;
            parameters[113].Value = model.OfficeAutomation_Document_UndertakeProj_PFear3;
            parameters[114].Value = model.OfficeAutomation_Document_UndertakeProj_PFear4;
            parameters[115].Value = model.OfficeAutomation_Document_UndertakeProj_SubmitReward;
            parameters[116].Value = model.OfficeAutomation_Document_UndertakeProj_OwnerCommJump;
            parameters[117].Value = model.OfficeAutomation_Document_UndertakeProj_ClientCommJump;
            parameters[118].Value = model.OfficeAutomation_Document_UndertakeProj_EBCommJump;
            parameters[119].Value = model.OfficeAutomation_Document_UndertakeProj_RewardSignHave;
            parameters[120].Value = model.OfficeAutomation_Document_UndertakeProj_RewardSignHavent;

            //parameters[119].Precision = 28;
            //parameters[119].Scale = 10;
            //parameters[120].Precision = 28;
            //parameters[120].Scale = 10;

            parameters[121].Value = model.OfficeAutomation_Document_UndertakeProj_DeveloperConditions;
            parameters[122].Value = model.OfficeAutomation_Document_UndertakeProj_AreaConditions;
            parameters[123].Value = model.OfficeAutomation_Document_UndertakeProj_PayRewardWay;
            parameters[124].Value = model.OfficeAutomation_Document_UndertakeProj_ReceiveRewardName;
            parameters[125].Value = model.OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo;
            parameters[126].Value = model.OfficeAutomation_Document_UndertakeProj_IsMyPay;
            parameters[127].Value = model.OfficeAutomation_Document_UndertakeProj_OtherCondtion;
            parameters[128].Value = model.OfficeAutomation_Document_UndertakeProj_AreaComfirn;
            parameters[129].Value = model.OfficeAutomation_Document_UndertakeProj_ReturnBackDate;
            parameters[130].Value = model.OfficeAutomation_Document_UndertakeProj_AnotherRewardC;
            parameters[131].Value = model.OfficeAutomation_Document_UndertakeProj_PCDeduct;
            parameters[132].Value = model.OfficeAutomation_Document_UndertakeProj_EBDeduct;
            parameters[133].Value = model.OfficeAutomation_Document_UndertakeProj_BaseAgent;
            parameters[134].Value = model.OfficeAutomation_Document_UndertakeProj_BaseAgentOther;
            parameters[135].Value = model.OfficeAutomation_Document_UndertakeProj_IsUploadPlan;
            parameters[136].Value = model.OfficeAutomation_Document_UndertakeProj_Flange;
            parameters[137].Value = model.OfficeAutomation_Document_UndertakeProj_AnotherCompany;
            parameters[138].Value = model.OfficeAutomation_Document_UndertakeProj_Referral;
            parameters[139].Value = model.OfficeAutomation_Document_UndertakeProj_BreakUp;
            parameters[140].Value = model.OfficeAutomation_Document_UndertakeProj_NCommissions;
            parameters[141].Value = model.OfficeAutomation_Document_UndertakeProj_HasAtt;
            parameters[142].Value = model.OfficeAutomation_Document_UndertakeProj_WillBreakUp;

            parameters[143].Value = model.OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues;
			parameters[144].Value = model.OfficeAutomation_Document_UndertakeProj_ID;
        
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string OfficeAutomation_Document_UndertakeProj_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("dbo.[pr_UndertakeProj_Delete]");
			SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = new Guid(OfficeAutomation_Document_UndertakeProj_ID);

            int rows;
            DbHelperSQL.RunProcedure(strSql.ToString(), parameters, out rows);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string OfficeAutomation_Document_UndertakeProj_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_UndertakeProj ");
			strSql.Append(" where OfficeAutomation_Document_UndertakeProj_ID in ("+OfficeAutomation_Document_UndertakeProj_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DataEntity.T_OfficeAutomation_Document_UndertakeProj GetModel(Guid OfficeAutomation_Document_UndertakeProj_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_UndertakeProj_ID,OfficeAutomation_Document_UndertakeProj_MainID,OfficeAutomation_Document_UndertakeProj_Apply,OfficeAutomation_Document_UndertakeProj_ApplyForName,OfficeAutomation_Document_UndertakeProj_ApplyForCode,OfficeAutomation_Document_UndertakeProj_Department,OfficeAutomation_Document_UndertakeProj_DepartmentID,OfficeAutomation_Document_UndertakeProj_ApplyDate,OfficeAutomation_Document_UndertakeProj_ReplyPhone,OfficeAutomation_Document_UndertakeProj_DepartmentTypeID,OfficeAutomation_Document_UndertakeProj_Project,OfficeAutomation_Document_UndertakeProj_Developer,OfficeAutomation_Document_UndertakeProj_ProjectPropertyID,OfficeAutomation_Document_UndertakeProj_DealTypeID,OfficeAutomation_Document_UndertakeProj_AgentPropertyID,OfficeAutomation_Document_UndertakeProj_ProjectArea,OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs,OfficeAutomation_Document_UndertakeProj_ProjectAddress,OfficeAutomation_Document_UndertakeProj_DeveloperContacter,OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition,OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone,OfficeAutomation_Document_UndertakeProj_AreaCheckDataer,OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode,OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone,OfficeAutomation_Document_UndertakeProj_Square,OfficeAutomation_Document_UndertakeProj_SetNumber,OfficeAutomation_Document_UndertakeProj_UnitPrice,OfficeAutomation_Document_UndertakeProj_TotalPrice,OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale,OfficeAutomation_Document_UndertakeProj_ClientCommFixScale,OfficeAutomation_Document_UndertakeProj_AgentStartDate,OfficeAutomation_Document_UndertakeProj_AgentEndDate,OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate,OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate,OfficeAutomation_Document_UndertakeProj_PreCompleteNumber,OfficeAutomation_Document_UndertakeProj_PreCompleteMoney,OfficeAutomation_Document_UndertakeProj_PreCompleteComm,OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack,OfficeAutomation_Document_UndertakeProj_OweCommSum,OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate,OfficeAutomation_Document_UndertakeProj_HaveSingleReward,OfficeAutomation_Document_UndertakeProj_IsAllJumpBar,OfficeAutomation_Document_UndertakeProj_IsMallSplit,OfficeAutomation_Document_UndertakeProj_IsMallOpen,OfficeAutomation_Document_UndertakeProj_IsExistMortgage,OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules,OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses,OfficeAutomation_Document_UndertakeProj_IsUniteAgent,OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract,OfficeAutomation_Document_UndertakeProj_SaleModeID,OfficeAutomation_Document_UndertakeProj_AreaScale,OfficeAutomation_Document_UndertakeProj_MainAreaScale,OfficeAutomation_Document_UndertakeProj_DealAreaScale,OfficeAutomation_Document_UndertakeProj_IsNeedExtension,OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast,OfficeAutomation_Document_UndertakeProj_TermsOfContract,OfficeAutomation_Document_UndertakeProj_ReportAddress,OfficeAutomation_Document_UndertakeProj_ProjectCost,OfficeAutomation_Document_UndertakeProj_PCDeveloper,OfficeAutomation_Document_UndertakeProj_EBDeveloper,OfficeAutomation_Document_UndertakeProj_CooperationWay,OfficeAutomation_Document_UndertakeProj_NHComm,OfficeAutomation_Document_UndertakeProj_NHName,OfficeAutomation_Document_UndertakeProj_OwnerCommAgent,OfficeAutomation_Document_UndertakeProj_ClientCommAgent,OfficeAutomation_Document_UndertakeProj_EBComm,OfficeAutomation_Document_UndertakeProj_EBCommAgent,OfficeAutomation_Document_UndertakeProj_NHTime,OfficeAutomation_Document_UndertakeProj_Here,OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues,OfficeAutomation_Document_UndertakeProj_LastBeginDate,OfficeAutomation_Document_UndertakeProj_LastEndDate,OfficeAutomation_Document_UndertakeProj_LastSumNum,OfficeAutomation_Document_UndertakeProj_LastResults,OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate,OfficeAutomation_Document_UndertakeProj_CumulativeEndDate,OfficeAutomation_Document_UndertakeProj_CumulativeNum,OfficeAutomation_Document_UndertakeProj_CumulativeResults,OfficeAutomation_Document_UndertakeProj_Turnover,OfficeAutomation_Document_UndertakeProj_SumTurnover,OfficeAutomation_Document_UndertakeProj_JOrT,OfficeAutomation_Document_UndertakeProj_SamePlaceXX1,OfficeAutomation_Document_UndertakeProj_SamePlaceXX2,OfficeAutomation_Document_UndertakeProj_SamePlaceXX3,OfficeAutomation_Document_UndertakeProj_SamePlaceXX4,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4,OfficeAutomation_Document_UndertakeProj_AgencyFee1,OfficeAutomation_Document_UndertakeProj_AgencyFee2,OfficeAutomation_Document_UndertakeProj_AgencyFee3,OfficeAutomation_Document_UndertakeProj_AgencyFee4,OfficeAutomation_Document_UndertakeProj_IsCashPrize1,OfficeAutomation_Document_UndertakeProj_IsCashPrize2,OfficeAutomation_Document_UndertakeProj_IsCashPrize3,OfficeAutomation_Document_UndertakeProj_IsCashPrize4,OfficeAutomation_Document_UndertakeProj_CashPrize1,OfficeAutomation_Document_UndertakeProj_CashPrize2,OfficeAutomation_Document_UndertakeProj_CashPrize3,OfficeAutomation_Document_UndertakeProj_CashPrize4,OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1,OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2,OfficeAutomation_Document_UndertakeProj_AgencyEndDate1,OfficeAutomation_Document_UndertakeProj_AgencyEndDate2,OfficeAutomation_Document_UndertakeProj_IsPFear1,OfficeAutomation_Document_UndertakeProj_IsPFear2,OfficeAutomation_Document_UndertakeProj_IsPFear3,OfficeAutomation_Document_UndertakeProj_IsPFear4,OfficeAutomation_Document_UndertakeProj_PFear1,OfficeAutomation_Document_UndertakeProj_PFear2,OfficeAutomation_Document_UndertakeProj_PFear3,OfficeAutomation_Document_UndertakeProj_PFear4,OfficeAutomation_Document_UndertakeProj_SubmitReward,OfficeAutomation_Document_UndertakeProj_OwnerCommJump,OfficeAutomation_Document_UndertakeProj_ClientCommJump,OfficeAutomation_Document_UndertakeProj_EBCommJump,OfficeAutomation_Document_UndertakeProj_RewardSignHave,OfficeAutomation_Document_UndertakeProj_RewardSignHavent,OfficeAutomation_Document_UndertakeProj_DeveloperConditions,OfficeAutomation_Document_UndertakeProj_AreaConditions,OfficeAutomation_Document_UndertakeProj_PayRewardWay,OfficeAutomation_Document_UndertakeProj_ReceiveRewardName,OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo,OfficeAutomation_Document_UndertakeProj_IsMyPay,OfficeAutomation_Document_UndertakeProj_OtherCondtion,OfficeAutomation_Document_UndertakeProj_AreaComfirn,OfficeAutomation_Document_UndertakeProj_ReturnBackDate,OfficeAutomation_Document_UndertakeProj_AnotherRewardC,OfficeAutomation_Document_UndertakeProj_PCDeduct,OfficeAutomation_Document_UndertakeProj_EBDeduct,OfficeAutomation_Document_UndertakeProj_BaseAgent,OfficeAutomation_Document_UndertakeProj_BaseAgentOther,OfficeAutomation_Document_UndertakeProj_IsUploadPlan,OfficeAutomation_Document_UndertakeProj_Flange,OfficeAutomation_Document_UndertakeProj_AnotherCompany,OfficeAutomation_Document_UndertakeProj_Referral,OfficeAutomation_Document_UndertakeProj_BreakUp,OfficeAutomation_Document_UndertakeProj_NCommissions,OfficeAutomation_Document_UndertakeProj_HasAtt,OfficeAutomation_Document_UndertakeProj_WillBreakUp,OfficeAutomation_Document_UndertakeProj_Remark from t_OfficeAutomation_Document_UndertakeProj ");
			strSql.Append(" where OfficeAutomation_Document_UndertakeProj_ID=@OfficeAutomation_Document_UndertakeProj_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_UndertakeProj_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_UndertakeProj_ID;

			DataEntity.T_OfficeAutomation_Document_UndertakeProj model=new DataEntity.T_OfficeAutomation_Document_UndertakeProj();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DataEntity.T_OfficeAutomation_Document_UndertakeProj DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_UndertakeProj model=new DataEntity.T_OfficeAutomation_Document_UndertakeProj();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_UndertakeProj_ID"]!=null && row["OfficeAutomation_Document_UndertakeProj_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_ID= new Guid(row["OfficeAutomation_Document_UndertakeProj_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_MainID"]!=null && row["OfficeAutomation_Document_UndertakeProj_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_MainID= new Guid(row["OfficeAutomation_Document_UndertakeProj_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_Apply"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_Apply=row["OfficeAutomation_Document_UndertakeProj_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ApplyForName"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_ApplyForName=row["OfficeAutomation_Document_UndertakeProj_ApplyForName"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ApplyForCode"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_ApplyForCode=row["OfficeAutomation_Document_UndertakeProj_ApplyForCode"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_Department"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_Department=row["OfficeAutomation_Document_UndertakeProj_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_DepartmentID"]!=null && row["OfficeAutomation_Document_UndertakeProj_DepartmentID"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_DepartmentID= new Guid(row["OfficeAutomation_Document_UndertakeProj_DepartmentID"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ApplyDate"]!=null && row["OfficeAutomation_Document_UndertakeProj_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_UndertakeProj_ApplyDate"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ReplyPhone"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_ReplyPhone=row["OfficeAutomation_Document_UndertakeProj_ReplyPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_DepartmentTypeID"]!=null && row["OfficeAutomation_Document_UndertakeProj_DepartmentTypeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_DepartmentTypeID=int.Parse(row["OfficeAutomation_Document_UndertakeProj_DepartmentTypeID"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_Project"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_Project=row["OfficeAutomation_Document_UndertakeProj_Project"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_Developer"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_Developer=row["OfficeAutomation_Document_UndertakeProj_Developer"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ProjectPropertyID"]!=null && row["OfficeAutomation_Document_UndertakeProj_ProjectPropertyID"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_ProjectPropertyID=int.Parse(row["OfficeAutomation_Document_UndertakeProj_ProjectPropertyID"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_DealTypeID"]!=null && row["OfficeAutomation_Document_UndertakeProj_DealTypeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_DealTypeID=int.Parse(row["OfficeAutomation_Document_UndertakeProj_DealTypeID"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_AgentPropertyID"]!=null && row["OfficeAutomation_Document_UndertakeProj_AgentPropertyID"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_AgentPropertyID=int.Parse(row["OfficeAutomation_Document_UndertakeProj_AgentPropertyID"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ProjectArea"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_ProjectArea=row["OfficeAutomation_Document_UndertakeProj_ProjectArea"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs=row["OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ProjectAddress"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_ProjectAddress=row["OfficeAutomation_Document_UndertakeProj_ProjectAddress"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_DeveloperContacter"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_DeveloperContacter=row["OfficeAutomation_Document_UndertakeProj_DeveloperContacter"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition=row["OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone=row["OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter=row["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition=row["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone=row["OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_AreaCheckDataer"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_AreaCheckDataer=row["OfficeAutomation_Document_UndertakeProj_AreaCheckDataer"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode=row["OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone=row["OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_Square"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_Square=row["OfficeAutomation_Document_UndertakeProj_Square"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_SetNumber"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_SetNumber=row["OfficeAutomation_Document_UndertakeProj_SetNumber"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_UnitPrice"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_UnitPrice=row["OfficeAutomation_Document_UndertakeProj_UnitPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_TotalPrice"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_TotalPrice=row["OfficeAutomation_Document_UndertakeProj_TotalPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale=row["OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ClientCommFixScale"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_ClientCommFixScale=row["OfficeAutomation_Document_UndertakeProj_ClientCommFixScale"].ToString();
				}
                //if(row["OfficeAutomation_Document_UndertakeProj_PreCommTotal"]!=null)
                //{
                //    model.OfficeAutomation_Document_UndertakeProj_PreCommTotal=row["OfficeAutomation_Document_UndertakeProj_PreCommTotal"].ToString();
                //}
				if(row["OfficeAutomation_Document_UndertakeProj_AgentStartDate"]!=null && row["OfficeAutomation_Document_UndertakeProj_AgentStartDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_AgentStartDate=DateTime.Parse(row["OfficeAutomation_Document_UndertakeProj_AgentStartDate"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_AgentEndDate"]!=null && row["OfficeAutomation_Document_UndertakeProj_AgentEndDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_AgentEndDate=DateTime.Parse(row["OfficeAutomation_Document_UndertakeProj_AgentEndDate"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate"]!=null && row["OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate=DateTime.Parse(row["OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate"]!=null && row["OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate=DateTime.Parse(row["OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_PreCompleteNumber"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_PreCompleteNumber=row["OfficeAutomation_Document_UndertakeProj_PreCompleteNumber"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_PreCompleteMoney"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_PreCompleteMoney=row["OfficeAutomation_Document_UndertakeProj_PreCompleteMoney"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_PreCompleteComm"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_PreCompleteComm=row["OfficeAutomation_Document_UndertakeProj_PreCompleteComm"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack=1;
					}
                    else if (row["OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack"].ToString() == "2")
                    {
                        model.OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack = 2;
                    }
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack=0;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_OweCommSum"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_OweCommSum=row["OfficeAutomation_Document_UndertakeProj_OweCommSum"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate"]!=null && row["OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate=DateTime.Parse(row["OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_HaveSingleReward"]!=null && row["OfficeAutomation_Document_UndertakeProj_HaveSingleReward"].ToString()!="")
				{
                    model.OfficeAutomation_Document_UndertakeProj_HaveSingleReward = int.Parse(row["OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate"].ToString());
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsAllJumpBar"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsAllJumpBar"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsAllJumpBar"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsAllJumpBar"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsAllJumpBar=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsAllJumpBar=false;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsMallSplit"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsMallSplit"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsMallSplit"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsMallSplit"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsMallSplit=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsMallSplit=false;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsMallOpen"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsMallOpen"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsMallOpen"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsMallOpen"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsMallOpen=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsMallOpen=false;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsExistMortgage"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsExistMortgage"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsExistMortgage"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsExistMortgage"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsExistMortgage=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsExistMortgage=false;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules=false;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses"]!=null && row["OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses=false;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsUniteAgent"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsUniteAgent"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsUniteAgent"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsUniteAgent"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsUniteAgent=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsUniteAgent=false;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract=false;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_SaleModeID"]!=null && row["OfficeAutomation_Document_UndertakeProj_SaleModeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_UndertakeProj_SaleModeID=int.Parse(row["OfficeAutomation_Document_UndertakeProj_SaleModeID"].ToString());
				}

                if (row["OfficeAutomation_Document_UndertakeProj_AreaScale"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AreaScale = row["OfficeAutomation_Document_UndertakeProj_AreaScale"].ToString();
                }

				if(row["OfficeAutomation_Document_UndertakeProj_MainAreaScale"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_MainAreaScale=row["OfficeAutomation_Document_UndertakeProj_MainAreaScale"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_DealAreaScale"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_DealAreaScale=row["OfficeAutomation_Document_UndertakeProj_DealAreaScale"].ToString();
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsNeedExtension"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsNeedExtension"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsNeedExtension"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsNeedExtension"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsNeedExtension=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsNeedExtension=false;
					}
				}
				if(row["OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast"]!=null && row["OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast"].ToString()=="1")||(row["OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast=true;
					}
					else
					{
						model.OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast=false;
					}
				}

                if (row["OfficeAutomation_Document_UndertakeProj_LastBeginDate"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_LastBeginDate = row["OfficeAutomation_Document_UndertakeProj_LastBeginDate"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_LastEndDate"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_LastEndDate = row["OfficeAutomation_Document_UndertakeProj_LastEndDate"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_LastSumNum"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_LastSumNum = row["OfficeAutomation_Document_UndertakeProj_LastSumNum"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_LastResults"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_LastResults = row["OfficeAutomation_Document_UndertakeProj_LastResults"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate = row["OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_CumulativeEndDate"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_CumulativeEndDate = row["OfficeAutomation_Document_UndertakeProj_CumulativeEndDate"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_CumulativeNum"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_CumulativeNum = row["OfficeAutomation_Document_UndertakeProj_CumulativeNum"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_CumulativeResults"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_CumulativeResults = row["OfficeAutomation_Document_UndertakeProj_CumulativeResults"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_Turnover"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_Turnover = row["OfficeAutomation_Document_UndertakeProj_Turnover"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_SumTurnover"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_SumTurnover = row["OfficeAutomation_Document_UndertakeProj_SumTurnover"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_JOrT"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_JOrT = int.Parse( row["OfficeAutomation_Document_UndertakeProj_JOrT"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_SamePlaceXX1"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX1 = row["OfficeAutomation_Document_UndertakeProj_SamePlaceXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_SamePlaceXX2"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX2 = row["OfficeAutomation_Document_UndertakeProj_SamePlaceXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_SamePlaceXX3"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX3 = row["OfficeAutomation_Document_UndertakeProj_SamePlaceXX3"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_SamePlaceXX4"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_SamePlaceXX4 = row["OfficeAutomation_Document_UndertakeProj_SamePlaceXX4"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1 = row["OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2 = row["OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3 = row["OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4 = row["OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_AgencyFee1"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AgencyFee1 = row["OfficeAutomation_Document_UndertakeProj_AgencyFee1"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AgencyFee2"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AgencyFee2 = row["OfficeAutomation_Document_UndertakeProj_AgencyFee2"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AgencyFee3"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AgencyFee3 = row["OfficeAutomation_Document_UndertakeProj_AgencyFee3"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AgencyFee4"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AgencyFee4 = row["OfficeAutomation_Document_UndertakeProj_AgencyFee4"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_IsCashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsCashPrize1 = bool.Parse( row["OfficeAutomation_Document_UndertakeProj_IsCashPrize1"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_IsCashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsCashPrize2 = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_IsCashPrize2"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_IsCashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsCashPrize3 = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_IsCashPrize3"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_IsCashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsCashPrize4 = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_IsCashPrize4"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_CashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_CashPrize1 = row["OfficeAutomation_Document_UndertakeProj_CashPrize1"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_CashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_CashPrize2 = row["OfficeAutomation_Document_UndertakeProj_CashPrize2"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_CashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_CashPrize3 = row["OfficeAutomation_Document_UndertakeProj_CashPrize3"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_CashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_CashPrize4 = row["OfficeAutomation_Document_UndertakeProj_CashPrize4"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1 = row["OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2 = row["OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AgencyEndDate1"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AgencyEndDate1 = row["OfficeAutomation_Document_UndertakeProj_AgencyEndDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AgencyEndDate2"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AgencyEndDate2 = row["OfficeAutomation_Document_UndertakeProj_AgencyEndDate2"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_IsPFear1"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsPFear1 = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_IsPFear1"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_IsPFear2"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsPFear2 = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_IsPFear2"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_IsPFear3"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsPFear3 = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_IsPFear3"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_IsPFear4"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsPFear4 = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_IsPFear4"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_PFear1"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_PFear1 = row["OfficeAutomation_Document_UndertakeProj_PFear1"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_PFear2"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_PFear2 = row["OfficeAutomation_Document_UndertakeProj_PFear2"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_PFear3"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_PFear3 = row["OfficeAutomation_Document_UndertakeProj_PFear3"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_PFear4"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_PFear4 = row["OfficeAutomation_Document_UndertakeProj_PFear4"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_SubmitReward"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_SubmitReward = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_SubmitReward"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_OwnerCommJump"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_OwnerCommJump = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_OwnerCommJump"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_ClientCommJump"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_ClientCommJump = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_ClientCommJump"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_EBCommJump"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_EBCommJump = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_EBCommJump"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_RewardSignHave"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_RewardSignHave = row["OfficeAutomation_Document_UndertakeProj_RewardSignHave"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_RewardSignHavent"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_RewardSignHavent = row["OfficeAutomation_Document_UndertakeProj_RewardSignHavent"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_DeveloperConditions"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_DeveloperConditions = row["OfficeAutomation_Document_UndertakeProj_DeveloperConditions"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AreaConditions"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AreaConditions = row["OfficeAutomation_Document_UndertakeProj_AreaConditions"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_PayRewardWay"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_PayRewardWay = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_PayRewardWay"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_ReceiveRewardName"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_ReceiveRewardName = row["OfficeAutomation_Document_UndertakeProj_ReceiveRewardName"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo = row["OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_IsMyPay"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsMyPay = int.Parse(row["OfficeAutomation_Document_UndertakeProj_IsMyPay"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_OtherCondtion"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_OtherCondtion = row["OfficeAutomation_Document_UndertakeProj_OtherCondtion"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AreaComfirn"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AreaComfirn = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_AreaComfirn"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_ReturnBackDate"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_ReturnBackDate = row["OfficeAutomation_Document_UndertakeProj_ReturnBackDate"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_AnotherRewardC"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AnotherRewardC = row["OfficeAutomation_Document_UndertakeProj_AnotherRewardC"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_PCDeduct"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_PCDeduct = row["OfficeAutomation_Document_UndertakeProj_PCDeduct"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_EBDeduct"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_EBDeduct = row["OfficeAutomation_Document_UndertakeProj_EBDeduct"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_BaseAgent"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_BaseAgent = row["OfficeAutomation_Document_UndertakeProj_BaseAgent"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_BaseAgentOther"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_BaseAgentOther = row["OfficeAutomation_Document_UndertakeProj_BaseAgentOther"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_IsUploadPlan"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_IsUploadPlan = bool.Parse(row["OfficeAutomation_Document_UndertakeProj_IsUploadPlan"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_Flange"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_Flange = row["OfficeAutomation_Document_UndertakeProj_Flange"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_AnotherCompany"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_AnotherCompany = row["OfficeAutomation_Document_UndertakeProj_AnotherCompany"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_Referral"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_Referral = row["OfficeAutomation_Document_UndertakeProj_Referral"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_BreakUp"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_BreakUp = row["OfficeAutomation_Document_UndertakeProj_BreakUp"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_NCommissions"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_NCommissions = row["OfficeAutomation_Document_UndertakeProj_NCommissions"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_HasAtt"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_HasAtt = row["OfficeAutomation_Document_UndertakeProj_HasAtt"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_WillBreakUp"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_WillBreakUp = row["OfficeAutomation_Document_UndertakeProj_WillBreakUp"].ToString();
                }

				if(row["OfficeAutomation_Document_UndertakeProj_Remark"]!=null)
				{
					model.OfficeAutomation_Document_UndertakeProj_Remark=row["OfficeAutomation_Document_UndertakeProj_Remark"].ToString();
				}

                if (row["OfficeAutomation_Document_UndertakeProj_TermsOfContract"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_TermsOfContract = row["OfficeAutomation_Document_UndertakeProj_TermsOfContract"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_ReportAddress"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_ReportAddress = row["OfficeAutomation_Document_UndertakeProj_ReportAddress"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_ProjectCost"] != null && row["OfficeAutomation_Document_UndertakeProj_ProjectCost"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_UndertakeProj_ProjectCost"].ToString() == "1") || (row["OfficeAutomation_Document_UndertakeProj_ProjectCost"].ToString().ToLower() == "true"))
                    {
                        model.OfficeAutomation_Document_UndertakeProj_ProjectCost = true;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_UndertakeProj_ProjectCost = false;
                    }
                }
                if (row["OfficeAutomation_Document_UndertakeProj_PCDeveloper"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_PCDeveloper = row["OfficeAutomation_Document_UndertakeProj_PCDeveloper"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_EBDeveloper"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_EBDeveloper = row["OfficeAutomation_Document_UndertakeProj_EBDeveloper"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_CooperationWay"] != null && row["OfficeAutomation_Document_UndertakeProj_CooperationWay"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_UndertakeProj_CooperationWay"].ToString() == "0"))
                    {
                        model.OfficeAutomation_Document_UndertakeProj_CooperationWay = 0;
                    }
                    else if (row["OfficeAutomation_Document_UndertakeProj_CooperationWay"].ToString() == "1")
                    {
                        model.OfficeAutomation_Document_UndertakeProj_CooperationWay = 1;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_UndertakeProj_CooperationWay = 2;
                    }
                }
                if (row["OfficeAutomation_Document_UndertakeProj_NHComm"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_NHComm = row["OfficeAutomation_Document_UndertakeProj_NHComm"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_NHName"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_NHName = row["OfficeAutomation_Document_UndertakeProj_NHName"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_OwnerCommAgent"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_OwnerCommAgent = row["OfficeAutomation_Document_UndertakeProj_OwnerCommAgent"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_ClientCommAgent"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_ClientCommAgent = row["OfficeAutomation_Document_UndertakeProj_ClientCommAgent"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_EBComm"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_EBComm = row["OfficeAutomation_Document_UndertakeProj_EBComm"].ToString();
                }
                if (row["OfficeAutomation_Document_UndertakeProj_EBCommAgent"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_EBCommAgent = row["OfficeAutomation_Document_UndertakeProj_EBCommAgent"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_NHTime"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_NHTime = DateTime.Parse(row["OfficeAutomation_Document_UndertakeProj_NHTime"].ToString());
                }
                if (row["OfficeAutomation_Document_UndertakeProj_Here"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_Here = row["OfficeAutomation_Document_UndertakeProj_Here"].ToString();
                }

                if (row["OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues"] != null)
                {
                    model.OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues = row["OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues"].ToString();
                }

			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select OfficeAutomation_Document_UndertakeProj_ID,OfficeAutomation_Document_UndertakeProj_MainID,OfficeAutomation_Document_UndertakeProj_Apply,OfficeAutomation_Document_UndertakeProj_ApplyForName,OfficeAutomation_Document_UndertakeProj_ApplyForCode,OfficeAutomation_Document_UndertakeProj_Department,OfficeAutomation_Document_UndertakeProj_DepartmentID,OfficeAutomation_Document_UndertakeProj_ApplyDate,OfficeAutomation_Document_UndertakeProj_ReplyPhone,OfficeAutomation_Document_UndertakeProj_DepartmentTypeID,OfficeAutomation_Document_UndertakeProj_Project,OfficeAutomation_Document_UndertakeProj_Developer,OfficeAutomation_Document_UndertakeProj_ProjectPropertyID,OfficeAutomation_Document_UndertakeProj_DealTypeID,OfficeAutomation_Document_UndertakeProj_AgentPropertyID,OfficeAutomation_Document_UndertakeProj_ProjectArea,OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs,OfficeAutomation_Document_UndertakeProj_ProjectAddress,OfficeAutomation_Document_UndertakeProj_DeveloperContacter,OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition,OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone,OfficeAutomation_Document_UndertakeProj_AreaCheckDataer,OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode,OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone,OfficeAutomation_Document_UndertakeProj_Square,OfficeAutomation_Document_UndertakeProj_SetNumber,OfficeAutomation_Document_UndertakeProj_UnitPrice,OfficeAutomation_Document_UndertakeProj_TotalPrice,OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale,OfficeAutomation_Document_UndertakeProj_ClientCommFixScale,OfficeAutomation_Document_UndertakeProj_AgentStartDate,OfficeAutomation_Document_UndertakeProj_AgentEndDate,OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate,OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate,OfficeAutomation_Document_UndertakeProj_PreCompleteNumber,OfficeAutomation_Document_UndertakeProj_PreCompleteMoney,OfficeAutomation_Document_UndertakeProj_PreCompleteComm,OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack,OfficeAutomation_Document_UndertakeProj_OweCommSum,OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate,OfficeAutomation_Document_UndertakeProj_HaveSingleReward,OfficeAutomation_Document_UndertakeProj_IsAllJumpBar,OfficeAutomation_Document_UndertakeProj_IsMallSplit,OfficeAutomation_Document_UndertakeProj_IsMallOpen,OfficeAutomation_Document_UndertakeProj_IsExistMortgage,OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules,OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses,OfficeAutomation_Document_UndertakeProj_IsUniteAgent,OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract,OfficeAutomation_Document_UndertakeProj_SaleModeID,OfficeAutomation_Document_UndertakeProj_AreaScale,OfficeAutomation_Document_UndertakeProj_MainAreaScale,OfficeAutomation_Document_UndertakeProj_DealAreaScale,OfficeAutomation_Document_UndertakeProj_IsNeedExtension,OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast,OfficeAutomation_Document_UndertakeProj_TermsOfContract,OfficeAutomation_Document_UndertakeProj_ReportAddress,OfficeAutomation_Document_UndertakeProj_ProjectCost,OfficeAutomation_Document_UndertakeProj_PCDeveloper,OfficeAutomation_Document_UndertakeProj_EBDeveloper,OfficeAutomation_Document_UndertakeProj_CooperationWay,OfficeAutomation_Document_UndertakeProj_NHComm,OfficeAutomation_Document_UndertakeProj_NHName,OfficeAutomation_Document_UndertakeProj_OwnerCommAgent,OfficeAutomation_Document_UndertakeProj_ClientCommAgent,OfficeAutomation_Document_UndertakeProj_EBComm,OfficeAutomation_Document_UndertakeProj_EBCommAgent,OfficeAutomation_Document_UndertakeProj_NHTime,OfficeAutomation_Document_UndertakeProj_Here,OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues,OfficeAutomation_Document_UndertakeProj_LastBeginDate,OfficeAutomation_Document_UndertakeProj_LastEndDate,OfficeAutomation_Document_UndertakeProj_LastSumNum,OfficeAutomation_Document_UndertakeProj_LastResults,OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate,OfficeAutomation_Document_UndertakeProj_CumulativeEndDate,OfficeAutomation_Document_UndertakeProj_CumulativeNum,OfficeAutomation_Document_UndertakeProj_CumulativeResults,OfficeAutomation_Document_UndertakeProj_Turnover,OfficeAutomation_Document_UndertakeProj_SumTurnover,OfficeAutomation_Document_UndertakeProj_JOrT,OfficeAutomation_Document_UndertakeProj_SamePlaceXX1,OfficeAutomation_Document_UndertakeProj_SamePlaceXX2,OfficeAutomation_Document_UndertakeProj_SamePlaceXX3,OfficeAutomation_Document_UndertakeProj_SamePlaceXX4,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4,OfficeAutomation_Document_UndertakeProj_AgencyFee1,OfficeAutomation_Document_UndertakeProj_AgencyFee2,OfficeAutomation_Document_UndertakeProj_AgencyFee3,OfficeAutomation_Document_UndertakeProj_AgencyFee4,OfficeAutomation_Document_UndertakeProj_IsCashPrize1,OfficeAutomation_Document_UndertakeProj_IsCashPrize2,OfficeAutomation_Document_UndertakeProj_IsCashPrize3,OfficeAutomation_Document_UndertakeProj_IsCashPrize4,OfficeAutomation_Document_UndertakeProj_CashPrize1,OfficeAutomation_Document_UndertakeProj_CashPrize2,OfficeAutomation_Document_UndertakeProj_CashPrize3,OfficeAutomation_Document_UndertakeProj_CashPrize4,OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1,OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2,OfficeAutomation_Document_UndertakeProj_AgencyEndDate1,OfficeAutomation_Document_UndertakeProj_AgencyEndDate2,OfficeAutomation_Document_UndertakeProj_IsPFear1,OfficeAutomation_Document_UndertakeProj_IsPFear2,OfficeAutomation_Document_UndertakeProj_IsPFear3,OfficeAutomation_Document_UndertakeProj_IsPFear4,OfficeAutomation_Document_UndertakeProj_PFear1,OfficeAutomation_Document_UndertakeProj_PFear2,OfficeAutomation_Document_UndertakeProj_PFear3,OfficeAutomation_Document_UndertakeProj_PFear4,OfficeAutomation_Document_UndertakeProj_SubmitReward,OfficeAutomation_Document_UndertakeProj_OwnerCommJump,OfficeAutomation_Document_UndertakeProj_ClientCommJump,OfficeAutomation_Document_UndertakeProj_EBCommJump,OfficeAutomation_Document_UndertakeProj_RewardSignHave,OfficeAutomation_Document_UndertakeProj_RewardSignHavent,OfficeAutomation_Document_UndertakeProj_DeveloperConditions,OfficeAutomation_Document_UndertakeProj_AreaConditions,OfficeAutomation_Document_UndertakeProj_PayRewardWay,OfficeAutomation_Document_UndertakeProj_ReceiveRewardName,OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo,OfficeAutomation_Document_UndertakeProj_IsMyPay,OfficeAutomation_Document_UndertakeProj_OtherCondtion,OfficeAutomation_Document_UndertakeProj_AreaComfirn,OfficeAutomation_Document_UndertakeProj_ReturnBackDate,OfficeAutomation_Document_UndertakeProj_AnotherRewardC,OfficeAutomation_Document_UndertakeProj_PCDeduct,OfficeAutomation_Document_UndertakeProj_EBDeduct,OfficeAutomation_Document_UndertakeProj_BaseAgent,OfficeAutomation_Document_UndertakeProj_BaseAgentOther,OfficeAutomation_Document_UndertakeProj_IsUploadPlan,OfficeAutomation_Document_UndertakeProj_Flange,OfficeAutomation_Document_UndertakeProj_AnotherCompany,OfficeAutomation_Document_UndertakeProj_Referral,OfficeAutomation_Document_UndertakeProj_BreakUp,OfficeAutomation_Document_UndertakeProj_NCommissions,OfficeAutomation_Document_UndertakeProj_HasAtt,OfficeAutomation_Document_UndertakeProj_WillBreakUp,OfficeAutomation_Document_UndertakeProj_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_UndertakeProj ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" OfficeAutomation_Document_UndertakeProj_ID,OfficeAutomation_Document_UndertakeProj_MainID,OfficeAutomation_Document_UndertakeProj_Apply,OfficeAutomation_Document_UndertakeProj_ApplyForName,OfficeAutomation_Document_UndertakeProj_ApplyForCode,OfficeAutomation_Document_UndertakeProj_Department,OfficeAutomation_Document_UndertakeProj_DepartmentID,OfficeAutomation_Document_UndertakeProj_ApplyDate,OfficeAutomation_Document_UndertakeProj_ReplyPhone,OfficeAutomation_Document_UndertakeProj_DepartmentTypeID,OfficeAutomation_Document_UndertakeProj_Project,OfficeAutomation_Document_UndertakeProj_Developer,OfficeAutomation_Document_UndertakeProj_ProjectPropertyID,OfficeAutomation_Document_UndertakeProj_DealTypeID,OfficeAutomation_Document_UndertakeProj_AgentPropertyID,OfficeAutomation_Document_UndertakeProj_ProjectArea,OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs,OfficeAutomation_Document_UndertakeProj_ProjectAddress,OfficeAutomation_Document_UndertakeProj_DeveloperContacter,OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition,OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition,OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone,OfficeAutomation_Document_UndertakeProj_AreaCheckDataer,OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode,OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone,OfficeAutomation_Document_UndertakeProj_Square,OfficeAutomation_Document_UndertakeProj_SetNumber,OfficeAutomation_Document_UndertakeProj_UnitPrice,OfficeAutomation_Document_UndertakeProj_TotalPrice,OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale,OfficeAutomation_Document_UndertakeProj_ClientCommFixScale,OfficeAutomation_Document_UndertakeProj_AgentStartDate,OfficeAutomation_Document_UndertakeProj_AgentEndDate,OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate,OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate,OfficeAutomation_Document_UndertakeProj_PreCompleteNumber,OfficeAutomation_Document_UndertakeProj_PreCompleteMoney,OfficeAutomation_Document_UndertakeProj_PreCompleteComm,OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack,OfficeAutomation_Document_UndertakeProj_OweCommSum,OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate,OfficeAutomation_Document_UndertakeProj_HaveSingleReward,OfficeAutomation_Document_UndertakeProj_IsAllJumpBar,OfficeAutomation_Document_UndertakeProj_IsMallSplit,OfficeAutomation_Document_UndertakeProj_IsMallOpen,OfficeAutomation_Document_UndertakeProj_IsExistMortgage,OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules,OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses,OfficeAutomation_Document_UndertakeProj_IsUniteAgent,OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract,OfficeAutomation_Document_UndertakeProj_SaleModeID,OfficeAutomation_Document_UndertakeProj_AreaScale,OfficeAutomation_Document_UndertakeProj_MainAreaScale,OfficeAutomation_Document_UndertakeProj_DealAreaScale,OfficeAutomation_Document_UndertakeProj_IsNeedExtension,OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast,OfficeAutomation_Document_UndertakeProj_TermsOfContract,OfficeAutomation_Document_UndertakeProj_ReportAddress,OfficeAutomation_Document_UndertakeProj_ProjectCost,OfficeAutomation_Document_UndertakeProj_PCDeveloper,OfficeAutomation_Document_UndertakeProj_EBDeveloper,OfficeAutomation_Document_UndertakeProj_CooperationWay,OfficeAutomation_Document_UndertakeProj_NHComm,OfficeAutomation_Document_UndertakeProj_NHName,OfficeAutomation_Document_UndertakeProj_OwnerCommAgent,OfficeAutomation_Document_UndertakeProj_ClientCommAgent,OfficeAutomation_Document_UndertakeProj_EBComm,OfficeAutomation_Document_UndertakeProj_EBCommAgent,OfficeAutomation_Document_UndertakeProj_NHTime,OfficeAutomation_Document_UndertakeProj_Here,OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues,OfficeAutomation_Document_UndertakeProj_LastBeginDate,OfficeAutomation_Document_UndertakeProj_LastEndDate,OfficeAutomation_Document_UndertakeProj_LastSumNum,OfficeAutomation_Document_UndertakeProj_LastResults,OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate,OfficeAutomation_Document_UndertakeProj_CumulativeEndDate,OfficeAutomation_Document_UndertakeProj_CumulativeNum,OfficeAutomation_Document_UndertakeProj_CumulativeResults,OfficeAutomation_Document_UndertakeProj_Turnover,OfficeAutomation_Document_UndertakeProj_SumTurnover,OfficeAutomation_Document_UndertakeProj_JOrT,OfficeAutomation_Document_UndertakeProj_SamePlaceXX1,OfficeAutomation_Document_UndertakeProj_SamePlaceXX2,OfficeAutomation_Document_UndertakeProj_SamePlaceXX3,OfficeAutomation_Document_UndertakeProj_SamePlaceXX4,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3,OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4,OfficeAutomation_Document_UndertakeProj_AgencyFee1,OfficeAutomation_Document_UndertakeProj_AgencyFee2,OfficeAutomation_Document_UndertakeProj_AgencyFee3,OfficeAutomation_Document_UndertakeProj_AgencyFee4,OfficeAutomation_Document_UndertakeProj_IsCashPrize1,OfficeAutomation_Document_UndertakeProj_IsCashPrize2,OfficeAutomation_Document_UndertakeProj_IsCashPrize3,OfficeAutomation_Document_UndertakeProj_IsCashPrize4,OfficeAutomation_Document_UndertakeProj_CashPrize1,OfficeAutomation_Document_UndertakeProj_CashPrize2,OfficeAutomation_Document_UndertakeProj_CashPrize3,OfficeAutomation_Document_UndertakeProj_CashPrize4,OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1,OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2,OfficeAutomation_Document_UndertakeProj_AgencyEndDate1,OfficeAutomation_Document_UndertakeProj_AgencyEndDate2,OfficeAutomation_Document_UndertakeProj_IsPFear1,OfficeAutomation_Document_UndertakeProj_IsPFear2,OfficeAutomation_Document_UndertakeProj_IsPFear3,OfficeAutomation_Document_UndertakeProj_IsPFear4,OfficeAutomation_Document_UndertakeProj_PFear1,OfficeAutomation_Document_UndertakeProj_PFear2,OfficeAutomation_Document_UndertakeProj_PFear3,OfficeAutomation_Document_UndertakeProj_PFear4,OfficeAutomation_Document_UndertakeProj_SubmitReward,OfficeAutomation_Document_UndertakeProj_OwnerCommJump,OfficeAutomation_Document_UndertakeProj_ClientCommJump,OfficeAutomation_Document_UndertakeProj_EBCommJump,OfficeAutomation_Document_UndertakeProj_RewardSignHave,OfficeAutomation_Document_UndertakeProj_RewardSignHavent,OfficeAutomation_Document_UndertakeProj_DeveloperConditions,OfficeAutomation_Document_UndertakeProj_AreaConditions,OfficeAutomation_Document_UndertakeProj_PayRewardWay,OfficeAutomation_Document_UndertakeProj_ReceiveRewardName,OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo,OfficeAutomation_Document_UndertakeProj_IsMyPay,OfficeAutomation_Document_UndertakeProj_OtherCondtion,OfficeAutomation_Document_UndertakeProj_AreaComfirn,OfficeAutomation_Document_UndertakeProj_ReturnBackDate,OfficeAutomation_Document_UndertakeProj_AnotherRewardC,OfficeAutomation_Document_UndertakeProj_PCDeduct,OfficeAutomation_Document_UndertakeProj_EBDeduct,OfficeAutomation_Document_UndertakeProj_BaseAgent,OfficeAutomation_Document_UndertakeProj_BaseAgentOther,OfficeAutomation_Document_UndertakeProj_IsUploadPlan,OfficeAutomation_Document_UndertakeProj_Flange,OfficeAutomation_Document_UndertakeProj_AnotherCompany,OfficeAutomation_Document_UndertakeProj_Referral,OfficeAutomation_Document_UndertakeProj_BreakUp,OfficeAutomation_Document_UndertakeProj_NCommissions,OfficeAutomation_Document_UndertakeProj_HasAtt,OfficeAutomation_Document_UndertakeProj_WillBreakUp,OfficeAutomation_Document_UndertakeProj_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_UndertakeProj ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_UndertakeProj ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.OfficeAutomation_Document_UndertakeProj_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_UndertakeProj T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_OfficeAutomation_Document_UndertakeProj";
			parameters[1].Value = "OfficeAutomation_Document_UndertakeProj_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}

    /// <summary>
    /// 项目性质字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_ProjectProperty_Operate
    {
        public DataSet SelectByDocumentID(int documentID)
        {
            string sql = "SELECT [OfficeAutomation_ProjectProperty_ID]"
                            + "         ,[OfficeAutomation_ProjectProperty_Name]"
                            + "         ,[OfficeAutomation_ProjectProperty_DocumentID]"
                            + "         ,[OfficeAutomation_ProjectProperty_IsEnable]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_ProjectProperty]"
                            + "  where OfficeAutomation_ProjectProperty_DocumentID = " + documentID
                            + "            and OfficeAutomation_ProjectProperty_IsEnable = 1";

            return DbHelperSQL.Query(sql);
        }
    }

    /// <summary>
    /// 代理性质性质字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_AgentProperty_Operate
    {
        public DataSet SelectByDocumentID(int documentID)
        {
            string sql = "SELECT [OfficeAutomation_AgentProperty_ID]"
                            + "         ,[OfficeAutomation_AgentProperty_Name]"
                            + "         ,[OfficeAutomation_AgentProperty_DocumentID]"
                            + "         ,[OfficeAutomation_AgentProperty_IsEnable]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_AgentProperty]"
                            + "  where OfficeAutomation_AgentProperty_DocumentID = " + documentID
                            + "            and OfficeAutomation_AgentProperty_IsEnable = 1";

            return DbHelperSQL.Query(sql);
        }
    }

    /// <summary>
    /// 销售类型字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_SaleMode_Operate
    {
        public DataSet SelectByDocumentID(int documentID)
        {
            string sql = "SELECT [OfficeAutomation_SaleMode_ID]"
                            + "         ,[OfficeAutomation_SaleMode_Name]"
                            + "         ,[OfficeAutomation_SaleMode_DocumentID]"
                            + "         ,[OfficeAutomation_SaleMode_IsEnable]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_SaleMode]"
                            + "  where OfficeAutomation_SaleMode_DocumentID = " + documentID
                            + "            and OfficeAutomation_SaleMode_IsEnable = 1";

            return DbHelperSQL.Query(sql);
        }
    }
}

