/*
* DA_OfficeAutomation_Document_ExtraBonus_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ExtraBonus_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/10 16:25:40    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_ExtraBonus_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_ExtraBonus_Operate
	{
		public DA_OfficeAutomation_Document_ExtraBonus_Operate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ExtraBonus_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ExtraBonus");
			strSql.Append(" where OfficeAutomation_Document_ExtraBonus_ID=@OfficeAutomation_Document_ExtraBonus_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ExtraBonus_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ExtraBonus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_ExtraBonus(");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_ID,OfficeAutomation_Document_ExtraBonus_MainID,OfficeAutomation_Document_ExtraBonus_Apply,OfficeAutomation_Document_ExtraBonus_ApplyForName,OfficeAutomation_Document_ExtraBonus_ApplyForCode,OfficeAutomation_Document_ExtraBonus_Department,OfficeAutomation_Document_ExtraBonus_DepartmentID,OfficeAutomation_Document_ExtraBonus_ApplyDate,OfficeAutomation_Document_ExtraBonus_ReplyPhone,OfficeAutomation_Document_ExtraBonus_Project,OfficeAutomation_Document_ExtraBonus_AgentStartDate,OfficeAutomation_Document_ExtraBonus_AgentEndDate,OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate,OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate,OfficeAutomation_Document_ExtraBonus_AgentRule,OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate,OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate,OfficeAutomation_Document_ExtraBonus_IsFullPay,OfficeAutomation_Document_ExtraBonus_RewardRule,OfficeAutomation_Document_ExtraBonus_RewardPayTypeID,OfficeAutomation_Document_ExtraBonus_PayerName,OfficeAutomation_Document_ExtraBonus_PayerPosition,OfficeAutomation_Document_ExtraBonus_PayerPhone,OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName,OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts,OfficeAutomation_Document_ExtraBonus_IsNeedPayFee,OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase,OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation,OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate,OfficeAutomation_Document_ExtraBonus_JOrT,OfficeAutomation_Document_ExtraBonus_SamePlaceXX1,OfficeAutomation_Document_ExtraBonus_SamePlaceXX2,OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1,OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2,OfficeAutomation_Document_ExtraBonus_AgencyFee1,OfficeAutomation_Document_ExtraBonus_AgencyFee2,OfficeAutomation_Document_ExtraBonus_AgencyFee3,OfficeAutomation_Document_ExtraBonus_AgencyFee4,OfficeAutomation_Document_ExtraBonus_IsCashPrize1,OfficeAutomation_Document_ExtraBonus_IsCashPrize2,OfficeAutomation_Document_ExtraBonus_IsCashPrize3,OfficeAutomation_Document_ExtraBonus_IsCashPrize4,OfficeAutomation_Document_ExtraBonus_CashPrize1,OfficeAutomation_Document_ExtraBonus_CashPrize2,OfficeAutomation_Document_ExtraBonus_CashPrize3,OfficeAutomation_Document_ExtraBonus_CashPrize4,OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1,OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2,OfficeAutomation_Document_ExtraBonus_AgencyEndDate1,OfficeAutomation_Document_ExtraBonus_AgencyEndDate2,OfficeAutomation_Document_ExtraBonus_IsPFear1,OfficeAutomation_Document_ExtraBonus_IsPFear2,OfficeAutomation_Document_ExtraBonus_IsPFear3,OfficeAutomation_Document_ExtraBonus_IsPFear4,OfficeAutomation_Document_ExtraBonus_PFear1,OfficeAutomation_Document_ExtraBonus_PFear2,OfficeAutomation_Document_ExtraBonus_PFear3,OfficeAutomation_Document_ExtraBonus_PFear4,OfficeAutomation_Document_ExtraBonus_Remark)");
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ExtraBonus_ID,@OfficeAutomation_Document_ExtraBonus_MainID,@OfficeAutomation_Document_ExtraBonus_Apply,@OfficeAutomation_Document_ExtraBonus_ApplyForName,@OfficeAutomation_Document_ExtraBonus_ApplyForCode,@OfficeAutomation_Document_ExtraBonus_Department,@OfficeAutomation_Document_ExtraBonus_DepartmentID,@OfficeAutomation_Document_ExtraBonus_ApplyDate,@OfficeAutomation_Document_ExtraBonus_ReplyPhone,@OfficeAutomation_Document_ExtraBonus_Project,@OfficeAutomation_Document_ExtraBonus_AgentStartDate,@OfficeAutomation_Document_ExtraBonus_AgentEndDate,@OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate,@OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate,@OfficeAutomation_Document_ExtraBonus_AgentRule,@OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate,@OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate,@OfficeAutomation_Document_ExtraBonus_IsFullPay,@OfficeAutomation_Document_ExtraBonus_RewardRule,@OfficeAutomation_Document_ExtraBonus_RewardPayTypeID,@OfficeAutomation_Document_ExtraBonus_PayerName,@OfficeAutomation_Document_ExtraBonus_PayerPosition,@OfficeAutomation_Document_ExtraBonus_PayerPhone,@OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName,@OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts,@OfficeAutomation_Document_ExtraBonus_IsNeedPayFee,@OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase,@OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation,@OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate,@OfficeAutomation_Document_ExtraBonus_JOrT,@OfficeAutomation_Document_ExtraBonus_SamePlaceXX1,@OfficeAutomation_Document_ExtraBonus_SamePlaceXX2,@OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1,@OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2,@OfficeAutomation_Document_ExtraBonus_AgencyFee1,@OfficeAutomation_Document_ExtraBonus_AgencyFee2,@OfficeAutomation_Document_ExtraBonus_AgencyFee3,@OfficeAutomation_Document_ExtraBonus_AgencyFee4,@OfficeAutomation_Document_ExtraBonus_IsCashPrize1,@OfficeAutomation_Document_ExtraBonus_IsCashPrize2,@OfficeAutomation_Document_ExtraBonus_IsCashPrize3,@OfficeAutomation_Document_ExtraBonus_IsCashPrize4,@OfficeAutomation_Document_ExtraBonus_CashPrize1,@OfficeAutomation_Document_ExtraBonus_CashPrize2,@OfficeAutomation_Document_ExtraBonus_CashPrize3,@OfficeAutomation_Document_ExtraBonus_CashPrize4,@OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1,@OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2,@OfficeAutomation_Document_ExtraBonus_AgencyEndDate1,@OfficeAutomation_Document_ExtraBonus_AgencyEndDate2,@OfficeAutomation_Document_ExtraBonus_IsPFear1,@OfficeAutomation_Document_ExtraBonus_IsPFear2,@OfficeAutomation_Document_ExtraBonus_IsPFear3,@OfficeAutomation_Document_ExtraBonus_IsPFear4,@OfficeAutomation_Document_ExtraBonus_PFear1,@OfficeAutomation_Document_ExtraBonus_PFear2,@OfficeAutomation_Document_ExtraBonus_PFear3,@OfficeAutomation_Document_ExtraBonus_PFear4,@OfficeAutomation_Document_ExtraBonus_Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyForCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_DepartmentID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Project", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgentStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgentEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgentRule", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsFullPay", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RewardRule", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RewardPayTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PayerName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PayerPosition", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PayerPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsNeedPayFee", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate", SqlDbType.DateTime),

                    new SqlParameter("@OfficeAutomation_Document_ExtraBonus_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PFear4", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Remark", SqlDbType.NVarChar,80)};
            parameters[0].Value = model.OfficeAutomation_Document_ExtraBonus_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ExtraBonus_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_ExtraBonus_Apply;
			parameters[3].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyForName;
			parameters[4].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyForCode;
			parameters[5].Value = model.OfficeAutomation_Document_ExtraBonus_Department;
            parameters[6].Value = model.OfficeAutomation_Document_ExtraBonus_DepartmentID;
			parameters[7].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyDate;
            parameters[8].Value = model.OfficeAutomation_Document_ExtraBonus_ReplyPhone;
            parameters[9].Value = model.OfficeAutomation_Document_ExtraBonus_Project;
			parameters[10].Value = model.OfficeAutomation_Document_ExtraBonus_AgentStartDate;
			parameters[11].Value = model.OfficeAutomation_Document_ExtraBonus_AgentEndDate;
			parameters[12].Value = model.OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate;
			parameters[13].Value = model.OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate;
			parameters[14].Value = model.OfficeAutomation_Document_ExtraBonus_AgentRule;
			parameters[15].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate;
			parameters[16].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate;
			parameters[17].Value = model.OfficeAutomation_Document_ExtraBonus_IsFullPay;
			parameters[18].Value = model.OfficeAutomation_Document_ExtraBonus_RewardRule;
			parameters[19].Value = model.OfficeAutomation_Document_ExtraBonus_RewardPayTypeID;
			parameters[20].Value = model.OfficeAutomation_Document_ExtraBonus_PayerName;
			parameters[21].Value = model.OfficeAutomation_Document_ExtraBonus_PayerPosition;
			parameters[22].Value = model.OfficeAutomation_Document_ExtraBonus_PayerPhone;
			parameters[23].Value = model.OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName;
			parameters[24].Value = model.OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts;
			parameters[25].Value = model.OfficeAutomation_Document_ExtraBonus_IsNeedPayFee;
			parameters[26].Value = model.OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase;
			parameters[27].Value = model.OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation;
			parameters[28].Value = model.OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate;

            parameters[29].Value = model.OfficeAutomation_Document_ExtraBonus_JOrT;
            parameters[30].Value = model.OfficeAutomation_Document_ExtraBonus_SamePlaceXX1;
            parameters[31].Value = model.OfficeAutomation_Document_ExtraBonus_SamePlaceXX2;
            parameters[32].Value = model.OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1;
            parameters[33].Value = model.OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2;
            parameters[34].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyFee1;
            parameters[35].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyFee2;
            parameters[36].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyFee3;
            parameters[37].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyFee4;
            parameters[38].Value = model.OfficeAutomation_Document_ExtraBonus_IsCashPrize1;
            parameters[39].Value = model.OfficeAutomation_Document_ExtraBonus_IsCashPrize2;
            parameters[40].Value = model.OfficeAutomation_Document_ExtraBonus_IsCashPrize3;
            parameters[41].Value = model.OfficeAutomation_Document_ExtraBonus_IsCashPrize4;
            parameters[42].Value = model.OfficeAutomation_Document_ExtraBonus_CashPrize1;
            parameters[43].Value = model.OfficeAutomation_Document_ExtraBonus_CashPrize2;
            parameters[44].Value = model.OfficeAutomation_Document_ExtraBonus_CashPrize3;
            parameters[45].Value = model.OfficeAutomation_Document_ExtraBonus_CashPrize4;
            parameters[46].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1;
            parameters[47].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2;
            parameters[48].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyEndDate1;
            parameters[49].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyEndDate2;
            parameters[50].Value = model.OfficeAutomation_Document_ExtraBonus_IsPFear1;
            parameters[51].Value = model.OfficeAutomation_Document_ExtraBonus_IsPFear2;
            parameters[52].Value = model.OfficeAutomation_Document_ExtraBonus_IsPFear3;
            parameters[53].Value = model.OfficeAutomation_Document_ExtraBonus_IsPFear4;
            parameters[54].Value = model.OfficeAutomation_Document_ExtraBonus_PFear1;
            parameters[55].Value = model.OfficeAutomation_Document_ExtraBonus_PFear2;
            parameters[56].Value = model.OfficeAutomation_Document_ExtraBonus_PFear3;
            parameters[57].Value = model.OfficeAutomation_Document_ExtraBonus_PFear4;

			parameters[58].Value = model.OfficeAutomation_Document_ExtraBonus_Remark;

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
		public bool Update(DataEntity.T_OfficeAutomation_Document_ExtraBonus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ExtraBonus set ");
			//strSql.Append("OfficeAutomation_Document_ExtraBonus_MainID=@OfficeAutomation_Document_ExtraBonus_MainID,");
			//strSql.Append("OfficeAutomation_Document_ExtraBonus_Apply=@OfficeAutomation_Document_ExtraBonus_Apply,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_ApplyForName=@OfficeAutomation_Document_ExtraBonus_ApplyForName,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_ApplyForCode=@OfficeAutomation_Document_ExtraBonus_ApplyForCode,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Department=@OfficeAutomation_Document_ExtraBonus_Department,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_DepartmentID=@OfficeAutomation_Document_ExtraBonus_DepartmentID,");
			//strSql.Append("OfficeAutomation_Document_ExtraBonus_ApplyDate=@OfficeAutomation_Document_ExtraBonus_ApplyDate,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_ReplyPhone=@OfficeAutomation_Document_ExtraBonus_ReplyPhone,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_Project=@OfficeAutomation_Document_ExtraBonus_Project,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_AgentStartDate=@OfficeAutomation_Document_ExtraBonus_AgentStartDate,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_AgentEndDate=@OfficeAutomation_Document_ExtraBonus_AgentEndDate,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate=@OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate=@OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_AgentRule=@OfficeAutomation_Document_ExtraBonus_AgentRule,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate=@OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate=@OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_IsFullPay=@OfficeAutomation_Document_ExtraBonus_IsFullPay,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_RewardRule=@OfficeAutomation_Document_ExtraBonus_RewardRule,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_RewardPayTypeID=@OfficeAutomation_Document_ExtraBonus_RewardPayTypeID,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_PayerName=@OfficeAutomation_Document_ExtraBonus_PayerName,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_PayerPosition=@OfficeAutomation_Document_ExtraBonus_PayerPosition,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_PayerPhone=@OfficeAutomation_Document_ExtraBonus_PayerPhone,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName=@OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts=@OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_IsNeedPayFee=@OfficeAutomation_Document_ExtraBonus_IsNeedPayFee,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase=@OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation=@OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate=@OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate,");

            strSql.Append("OfficeAutomation_Document_ExtraBonus_JOrT=@OfficeAutomation_Document_ExtraBonus_JOrT,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_SamePlaceXX1=@OfficeAutomation_Document_ExtraBonus_SamePlaceXX1,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_SamePlaceXX2=@OfficeAutomation_Document_ExtraBonus_SamePlaceXX2,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1=@OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2=@OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_AgencyFee1=@OfficeAutomation_Document_ExtraBonus_AgencyFee1,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_AgencyFee2=@OfficeAutomation_Document_ExtraBonus_AgencyFee2,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_AgencyFee3=@OfficeAutomation_Document_ExtraBonus_AgencyFee3,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_AgencyFee4=@OfficeAutomation_Document_ExtraBonus_AgencyFee4,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_IsCashPrize1=@OfficeAutomation_Document_ExtraBonus_IsCashPrize1,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_IsCashPrize2=@OfficeAutomation_Document_ExtraBonus_IsCashPrize2,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_IsCashPrize3=@OfficeAutomation_Document_ExtraBonus_IsCashPrize3,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_IsCashPrize4=@OfficeAutomation_Document_ExtraBonus_IsCashPrize4,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_CashPrize1=@OfficeAutomation_Document_ExtraBonus_CashPrize1,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_CashPrize2=@OfficeAutomation_Document_ExtraBonus_CashPrize2,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_CashPrize3=@OfficeAutomation_Document_ExtraBonus_CashPrize3,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_CashPrize4=@OfficeAutomation_Document_ExtraBonus_CashPrize4,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1=@OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2=@OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_AgencyEndDate1=@OfficeAutomation_Document_ExtraBonus_AgencyEndDate1,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_AgencyEndDate2=@OfficeAutomation_Document_ExtraBonus_AgencyEndDate2,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_IsPFear1=@OfficeAutomation_Document_ExtraBonus_IsPFear1,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_IsPFear2=@OfficeAutomation_Document_ExtraBonus_IsPFear2,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_IsPFear3=@OfficeAutomation_Document_ExtraBonus_IsPFear3,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_IsPFear4=@OfficeAutomation_Document_ExtraBonus_IsPFear4,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_PFear1=@OfficeAutomation_Document_ExtraBonus_PFear1,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_PFear2=@OfficeAutomation_Document_ExtraBonus_PFear2,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_PFear3=@OfficeAutomation_Document_ExtraBonus_PFear3,");
            strSql.Append("OfficeAutomation_Document_ExtraBonus_PFear4=@OfficeAutomation_Document_ExtraBonus_PFear4");

			//strSql.Append("OfficeAutomation_Document_ExtraBonus_Remark=@OfficeAutomation_Document_ExtraBonus_Remark");
			strSql.Append(" where OfficeAutomation_Document_ExtraBonus_ID=@OfficeAutomation_Document_ExtraBonus_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ExtraBonus_MainID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyForCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_DepartmentID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Project", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgentStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgentEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgentRule", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsFullPay", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RewardRule", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RewardPayTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PayerName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PayerPosition", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PayerPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsNeedPayFee", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate", SqlDbType.DateTime),

                    new SqlParameter("@OfficeAutomation_Document_ExtraBonus_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_PFear4", SqlDbType.NVarChar,80),

					//new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Remark", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_ExtraBonus_MainID;
			//parameters[1].Value = model.OfficeAutomation_Document_ExtraBonus_Apply;
			parameters[0].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyForName;
			parameters[1].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyForCode;
			parameters[2].Value = model.OfficeAutomation_Document_ExtraBonus_Department;
			parameters[3].Value = model.OfficeAutomation_Document_ExtraBonus_DepartmentID;
			//parameters[6].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyDate;
            parameters[4].Value = model.OfficeAutomation_Document_ExtraBonus_ReplyPhone;
            parameters[5].Value = model.OfficeAutomation_Document_ExtraBonus_Project;
			parameters[6].Value = model.OfficeAutomation_Document_ExtraBonus_AgentStartDate;
			parameters[7].Value = model.OfficeAutomation_Document_ExtraBonus_AgentEndDate;
			parameters[8].Value = model.OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate;
			parameters[9].Value = model.OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate;
			parameters[10].Value = model.OfficeAutomation_Document_ExtraBonus_AgentRule;
			parameters[11].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate;
			parameters[12].Value = model.OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate;
			parameters[13].Value = model.OfficeAutomation_Document_ExtraBonus_IsFullPay;
			parameters[14].Value = model.OfficeAutomation_Document_ExtraBonus_RewardRule;
			parameters[15].Value = model.OfficeAutomation_Document_ExtraBonus_RewardPayTypeID;
			parameters[16].Value = model.OfficeAutomation_Document_ExtraBonus_PayerName;
			parameters[17].Value = model.OfficeAutomation_Document_ExtraBonus_PayerPosition;
			parameters[18].Value = model.OfficeAutomation_Document_ExtraBonus_PayerPhone;
			parameters[19].Value = model.OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName;
			parameters[20].Value = model.OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts;
			parameters[21].Value = model.OfficeAutomation_Document_ExtraBonus_IsNeedPayFee;
			parameters[22].Value = model.OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase;
			parameters[23].Value = model.OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation;
			parameters[24].Value = model.OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate;

            parameters[25].Value = model.OfficeAutomation_Document_ExtraBonus_JOrT;
            parameters[26].Value = model.OfficeAutomation_Document_ExtraBonus_SamePlaceXX1;
            parameters[27].Value = model.OfficeAutomation_Document_ExtraBonus_SamePlaceXX2;
            parameters[28].Value = model.OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1;
            parameters[29].Value = model.OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2;
            parameters[30].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyFee1;
            parameters[31].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyFee2;
            parameters[32].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyFee3;
            parameters[33].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyFee4;
            parameters[34].Value = model.OfficeAutomation_Document_ExtraBonus_IsCashPrize1;
            parameters[35].Value = model.OfficeAutomation_Document_ExtraBonus_IsCashPrize2;
            parameters[36].Value = model.OfficeAutomation_Document_ExtraBonus_IsCashPrize3;
            parameters[37].Value = model.OfficeAutomation_Document_ExtraBonus_IsCashPrize4;
            parameters[38].Value = model.OfficeAutomation_Document_ExtraBonus_CashPrize1;
            parameters[39].Value = model.OfficeAutomation_Document_ExtraBonus_CashPrize2;
            parameters[40].Value = model.OfficeAutomation_Document_ExtraBonus_CashPrize3;
            parameters[41].Value = model.OfficeAutomation_Document_ExtraBonus_CashPrize4;
            parameters[42].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1;
            parameters[43].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2;
            parameters[44].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyEndDate1;
            parameters[45].Value = model.OfficeAutomation_Document_ExtraBonus_AgencyEndDate2;
            parameters[46].Value = model.OfficeAutomation_Document_ExtraBonus_IsPFear1;
            parameters[47].Value = model.OfficeAutomation_Document_ExtraBonus_IsPFear2;
            parameters[48].Value = model.OfficeAutomation_Document_ExtraBonus_IsPFear3;
            parameters[49].Value = model.OfficeAutomation_Document_ExtraBonus_IsPFear4;
            parameters[50].Value = model.OfficeAutomation_Document_ExtraBonus_PFear1;
            parameters[51].Value = model.OfficeAutomation_Document_ExtraBonus_PFear2;
            parameters[52].Value = model.OfficeAutomation_Document_ExtraBonus_PFear3;
            parameters[53].Value = model.OfficeAutomation_Document_ExtraBonus_PFear4;

			//parameters[34].Value = model.OfficeAutomation_Document_ExtraBonus_Remark;
			parameters[54].Value = model.OfficeAutomation_Document_ExtraBonus_ID;

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
		public bool Delete(string OfficeAutomation_Document_ExtraBonus_MainID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("dbo.[pr_ExtraBonus_Delete]");
			SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ExtraBonus_MainID);

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
		public bool DeleteList(string OfficeAutomation_Document_ExtraBonus_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ExtraBonus ");
			strSql.Append(" where OfficeAutomation_Document_ExtraBonus_ID in ("+OfficeAutomation_Document_ExtraBonus_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_ExtraBonus GetModel(Guid OfficeAutomation_Document_ExtraBonus_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_ExtraBonus_ID,OfficeAutomation_Document_ExtraBonus_MainID,OfficeAutomation_Document_ExtraBonus_Apply,OfficeAutomation_Document_ExtraBonus_ApplyForName,OfficeAutomation_Document_ExtraBonus_ApplyForCode,OfficeAutomation_Document_ExtraBonus_Department,OfficeAutomation_Document_ExtraBonus_DepartmentID,OfficeAutomation_Document_ExtraBonus_ApplyDate,OfficeAutomation_Document_ExtraBonus_ReplyPhone,OfficeAutomation_Document_ExtraBonus_Project,OfficeAutomation_Document_ExtraBonus_AgentStartDate,OfficeAutomation_Document_ExtraBonus_AgentEndDate,OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate,OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate,OfficeAutomation_Document_ExtraBonus_AgentRule,OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate,OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate,OfficeAutomation_Document_ExtraBonus_IsFullPay,OfficeAutomation_Document_ExtraBonus_RewardRule,OfficeAutomation_Document_ExtraBonus_RewardPayTypeID,OfficeAutomation_Document_ExtraBonus_PayerName,OfficeAutomation_Document_ExtraBonus_PayerPosition,OfficeAutomation_Document_ExtraBonus_PayerPhone,OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName,OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts,OfficeAutomation_Document_ExtraBonus_IsNeedPayFee,OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase,OfficeAutomation_Document_ExtraBonus_AllowMoney,OfficeAutomation_Document_ExtraBonus_SalesMoney,OfficeAutomation_Document_ExtraBonus_ManagerMoney,OfficeAutomation_Document_ExtraBonus_AreaManagerMoney,OfficeAutomation_Document_ExtraBonus_MajordomoMoney,OfficeAutomation_Document_ExtraBonus_CompanyMoney,OfficeAutomation_Document_ExtraBonus_TotalMoney,OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation,OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate,OfficeAutomation_Document_ExtraBonus_JOrT,OfficeAutomation_Document_ExtraBonus_SamePlaceXX1,OfficeAutomation_Document_ExtraBonus_SamePlaceXX2,OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1,OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2,OfficeAutomation_Document_ExtraBonus_AgencyFee1,OfficeAutomation_Document_ExtraBonus_AgencyFee2,OfficeAutomation_Document_ExtraBonus_AgencyFee3,OfficeAutomation_Document_ExtraBonus_AgencyFee4,OfficeAutomation_Document_ExtraBonus_IsCashPrize1,OfficeAutomation_Document_ExtraBonus_IsCashPrize2,OfficeAutomation_Document_ExtraBonus_IsCashPrize3,OfficeAutomation_Document_ExtraBonus_IsCashPrize4,OfficeAutomation_Document_ExtraBonus_CashPrize1,OfficeAutomation_Document_ExtraBonus_CashPrize2,OfficeAutomation_Document_ExtraBonus_CashPrize3,OfficeAutomation_Document_ExtraBonus_CashPrize4,OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1,OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2,OfficeAutomation_Document_ExtraBonus_AgencyEndDate1,OfficeAutomation_Document_ExtraBonus_AgencyEndDate2,OfficeAutomation_Document_ExtraBonus_IsPFear1,OfficeAutomation_Document_ExtraBonus_IsPFear2,OfficeAutomation_Document_ExtraBonus_IsPFear3,OfficeAutomation_Document_ExtraBonus_IsPFear4,OfficeAutomation_Document_ExtraBonus_PFear1,OfficeAutomation_Document_ExtraBonus_PFear2,OfficeAutomation_Document_ExtraBonus_PFear3,OfficeAutomation_Document_ExtraBonus_PFear4,OfficeAutomation_Document_ExtraBonus_Remark from t_OfficeAutomation_Document_ExtraBonus ");
			strSql.Append(" where OfficeAutomation_Document_ExtraBonus_ID=@OfficeAutomation_Document_ExtraBonus_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ExtraBonus_ID;

			DataEntity.T_OfficeAutomation_Document_ExtraBonus model=new DataEntity.T_OfficeAutomation_Document_ExtraBonus();
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
		public DataEntity.T_OfficeAutomation_Document_ExtraBonus DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_ExtraBonus model=new DataEntity.T_OfficeAutomation_Document_ExtraBonus();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_ExtraBonus_ID"]!=null && row["OfficeAutomation_Document_ExtraBonus_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_ID= new Guid(row["OfficeAutomation_Document_ExtraBonus_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_MainID"]!=null && row["OfficeAutomation_Document_ExtraBonus_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_MainID= new Guid(row["OfficeAutomation_Document_ExtraBonus_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Apply"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Apply=row["OfficeAutomation_Document_ExtraBonus_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_ApplyForName"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_ApplyForName=row["OfficeAutomation_Document_ExtraBonus_ApplyForName"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_ApplyForCode"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_ApplyForCode=row["OfficeAutomation_Document_ExtraBonus_ApplyForCode"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Department"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Department=row["OfficeAutomation_Document_ExtraBonus_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_DepartmentID"]!=null && row["OfficeAutomation_Document_ExtraBonus_DepartmentID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_DepartmentID= new Guid(row["OfficeAutomation_Document_ExtraBonus_DepartmentID"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_ApplyDate"]!=null && row["OfficeAutomation_Document_ExtraBonus_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_ExtraBonus_ApplyDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_ReplyPhone"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_ReplyPhone = row["OfficeAutomation_Document_ExtraBonus_ReplyPhone"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_Project"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_Project = row["OfficeAutomation_Document_ExtraBonus_Project"].ToString();
                }
				if(row["OfficeAutomation_Document_ExtraBonus_AgentStartDate"]!=null && row["OfficeAutomation_Document_ExtraBonus_AgentStartDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_AgentStartDate=DateTime.Parse(row["OfficeAutomation_Document_ExtraBonus_AgentStartDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_AgentEndDate"]!=null && row["OfficeAutomation_Document_ExtraBonus_AgentEndDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_AgentEndDate=DateTime.Parse(row["OfficeAutomation_Document_ExtraBonus_AgentEndDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate"]!=null && row["OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate=DateTime.Parse(row["OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate"]!=null && row["OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate=DateTime.Parse(row["OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_AgentRule"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_AgentRule=row["OfficeAutomation_Document_ExtraBonus_AgentRule"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate"]!=null && row["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate=DateTime.Parse(row["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate"]!=null && row["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate=DateTime.Parse(row["OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_IsFullPay"]!=null && row["OfficeAutomation_Document_ExtraBonus_IsFullPay"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_ExtraBonus_IsFullPay"].ToString()=="1")||(row["OfficeAutomation_Document_ExtraBonus_IsFullPay"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_ExtraBonus_IsFullPay=true;
					}
					else
					{
						model.OfficeAutomation_Document_ExtraBonus_IsFullPay=false;
					}
				}
				if(row["OfficeAutomation_Document_ExtraBonus_RewardRule"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_RewardRule=row["OfficeAutomation_Document_ExtraBonus_RewardRule"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_RewardPayTypeID"]!=null && row["OfficeAutomation_Document_ExtraBonus_RewardPayTypeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_RewardPayTypeID=int.Parse(row["OfficeAutomation_Document_ExtraBonus_RewardPayTypeID"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_PayerName"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_PayerName=row["OfficeAutomation_Document_ExtraBonus_PayerName"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_PayerPosition"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_PayerPosition=row["OfficeAutomation_Document_ExtraBonus_PayerPosition"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_PayerPhone"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_PayerPhone=row["OfficeAutomation_Document_ExtraBonus_PayerPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName=row["OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts=row["OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_IsNeedPayFee"]!=null && row["OfficeAutomation_Document_ExtraBonus_IsNeedPayFee"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_ExtraBonus_IsNeedPayFee"].ToString()=="1")||(row["OfficeAutomation_Document_ExtraBonus_IsNeedPayFee"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_ExtraBonus_IsNeedPayFee=true;
					}
					else
					{
						model.OfficeAutomation_Document_ExtraBonus_IsNeedPayFee=false;
					}
				}
				if(row["OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase=row["OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation"]!=null && row["OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation"].ToString()=="1")||(row["OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation=true;
					}
					else
					{
						model.OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation=false;
					}
				}
				if(row["OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate"]!=null && row["OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate=DateTime.Parse(row["OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate"].ToString());
				}

                if (row["OfficeAutomation_Document_ExtraBonus_JOrT"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_JOrT = int.Parse(row["OfficeAutomation_Document_ExtraBonus_JOrT"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_SamePlaceXX1"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_SamePlaceXX1 = row["OfficeAutomation_Document_ExtraBonus_SamePlaceXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_SamePlaceXX2"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_SamePlaceXX2 = row["OfficeAutomation_Document_ExtraBonus_SamePlaceXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1 = row["OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2 = row["OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_AgencyFee1"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_AgencyFee1 = row["OfficeAutomation_Document_ExtraBonus_AgencyFee1"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_AgencyFee2"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_AgencyFee2 = row["OfficeAutomation_Document_ExtraBonus_AgencyFee2"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_AgencyFee3"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_AgencyFee3 = row["OfficeAutomation_Document_ExtraBonus_AgencyFee3"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_AgencyFee4"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_AgencyFee4 = row["OfficeAutomation_Document_ExtraBonus_AgencyFee4"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_IsCashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_IsCashPrize1 = bool.Parse(row["OfficeAutomation_Document_ExtraBonus_IsCashPrize1"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_IsCashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_IsCashPrize2 = bool.Parse(row["OfficeAutomation_Document_ExtraBonus_IsCashPrize2"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_IsCashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_IsCashPrize3 = bool.Parse(row["OfficeAutomation_Document_ExtraBonus_IsCashPrize3"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_IsCashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_IsCashPrize4 = bool.Parse(row["OfficeAutomation_Document_ExtraBonus_IsCashPrize4"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_CashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_CashPrize1 = row["OfficeAutomation_Document_ExtraBonus_CashPrize1"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_CashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_CashPrize2 = row["OfficeAutomation_Document_ExtraBonus_CashPrize2"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_CashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_CashPrize3 = row["OfficeAutomation_Document_ExtraBonus_CashPrize3"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_CashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_CashPrize4 = row["OfficeAutomation_Document_ExtraBonus_CashPrize4"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1 = row["OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2 = row["OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_AgencyEndDate1"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_AgencyEndDate1 = row["OfficeAutomation_Document_ExtraBonus_AgencyEndDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_AgencyEndDate2"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_AgencyEndDate2 = row["OfficeAutomation_Document_ExtraBonus_AgencyEndDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_IsPFear1"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_IsPFear1 = bool.Parse(row["OfficeAutomation_Document_ExtraBonus_IsPFear1"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_IsPFear2"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_IsPFear2 = bool.Parse(row["OfficeAutomation_Document_ExtraBonus_IsPFear2"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_IsPFear3"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_IsPFear3 = bool.Parse(row["OfficeAutomation_Document_ExtraBonus_IsPFear3"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_IsPFear4"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_IsPFear4 = bool.Parse(row["OfficeAutomation_Document_ExtraBonus_IsPFear4"].ToString());
                }
                if (row["OfficeAutomation_Document_ExtraBonus_PFear1"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_PFear1 = row["OfficeAutomation_Document_ExtraBonus_PFear1"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_PFear2"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_PFear2 = row["OfficeAutomation_Document_ExtraBonus_PFear2"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_PFear3"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_PFear3 = row["OfficeAutomation_Document_ExtraBonus_PFear3"].ToString();
                }
                if (row["OfficeAutomation_Document_ExtraBonus_PFear4"] != null)
                {
                    model.OfficeAutomation_Document_ExtraBonus_PFear4 = row["OfficeAutomation_Document_ExtraBonus_PFear4"].ToString();
                }

				if(row["OfficeAutomation_Document_ExtraBonus_Remark"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Remark=row["OfficeAutomation_Document_ExtraBonus_Remark"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_ExtraBonus_ID,OfficeAutomation_Document_ExtraBonus_MainID,OfficeAutomation_Document_ExtraBonus_Apply,OfficeAutomation_Document_ExtraBonus_ApplyForName,OfficeAutomation_Document_ExtraBonus_ApplyForCode,OfficeAutomation_Document_ExtraBonus_Department,OfficeAutomation_Document_ExtraBonus_DepartmentID,OfficeAutomation_Document_ExtraBonus_ApplyDate,OfficeAutomation_Document_ExtraBonus_ReplyPhone,OfficeAutomation_Document_ExtraBonus_AgentStartDate,OfficeAutomation_Document_ExtraBonus_AgentEndDate,OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate,OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate,OfficeAutomation_Document_ExtraBonus_AgentRule,OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate,OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate,OfficeAutomation_Document_ExtraBonus_IsFullPay,OfficeAutomation_Document_ExtraBonus_RewardRule,OfficeAutomation_Document_ExtraBonus_RewardPayTypeID,OfficeAutomation_Document_ExtraBonus_PayerName,OfficeAutomation_Document_ExtraBonus_PayerPosition,OfficeAutomation_Document_ExtraBonus_PayerPhone,OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName,OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts,OfficeAutomation_Document_ExtraBonus_IsNeedPayFee,OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase,OfficeAutomation_Document_ExtraBonus_AllowMoney,OfficeAutomation_Document_ExtraBonus_SalesMoney,OfficeAutomation_Document_ExtraBonus_ManagerMoney,OfficeAutomation_Document_ExtraBonus_AreaManagerMoney,OfficeAutomation_Document_ExtraBonus_MajordomoMoney,OfficeAutomation_Document_ExtraBonus_CompanyMoney,OfficeAutomation_Document_ExtraBonus_TotalMoney,OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation,OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate,OfficeAutomation_Document_ExtraBonus_JOrT,OfficeAutomation_Document_ExtraBonus_SamePlaceXX1,OfficeAutomation_Document_ExtraBonus_SamePlaceXX2,OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1,OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2,OfficeAutomation_Document_ExtraBonus_AgencyFee1,OfficeAutomation_Document_ExtraBonus_AgencyFee2,OfficeAutomation_Document_ExtraBonus_AgencyFee3,OfficeAutomation_Document_ExtraBonus_AgencyFee4,OfficeAutomation_Document_ExtraBonus_IsCashPrize1,OfficeAutomation_Document_ExtraBonus_IsCashPrize2,OfficeAutomation_Document_ExtraBonus_IsCashPrize3,OfficeAutomation_Document_ExtraBonus_IsCashPrize4,OfficeAutomation_Document_ExtraBonus_CashPrize1,OfficeAutomation_Document_ExtraBonus_CashPrize2,OfficeAutomation_Document_ExtraBonus_CashPrize3,OfficeAutomation_Document_ExtraBonus_CashPrize4,OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1,OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2,OfficeAutomation_Document_ExtraBonus_AgencyEndDate1,OfficeAutomation_Document_ExtraBonus_AgencyEndDate2,OfficeAutomation_Document_ExtraBonus_IsPFear1,OfficeAutomation_Document_ExtraBonus_IsPFear2,OfficeAutomation_Document_ExtraBonus_IsPFear3,OfficeAutomation_Document_ExtraBonus_IsPFear4,OfficeAutomation_Document_ExtraBonus_PFear1,OfficeAutomation_Document_ExtraBonus_PFear2,OfficeAutomation_Document_ExtraBonus_PFear3,OfficeAutomation_Document_ExtraBonus_PFear4,OfficeAutomation_Document_ExtraBonus_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ExtraBonus ");
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
            strSql.Append(" OfficeAutomation_Document_ExtraBonus_ID,OfficeAutomation_Document_ExtraBonus_MainID,OfficeAutomation_Document_ExtraBonus_Apply,OfficeAutomation_Document_ExtraBonus_ApplyForName,OfficeAutomation_Document_ExtraBonus_ApplyForCode,OfficeAutomation_Document_ExtraBonus_Department,OfficeAutomation_Document_ExtraBonus_DepartmentID,OfficeAutomation_Document_ExtraBonus_ApplyDate,OfficeAutomation_Document_ExtraBonus_ReplyPhone,OfficeAutomation_Document_ExtraBonus_Project,OfficeAutomation_Document_ExtraBonus_AgentStartDate,OfficeAutomation_Document_ExtraBonus_AgentEndDate,OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate,OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate,OfficeAutomation_Document_ExtraBonus_AgentRule,OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate,OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate,OfficeAutomation_Document_ExtraBonus_IsFullPay,OfficeAutomation_Document_ExtraBonus_RewardRule,OfficeAutomation_Document_ExtraBonus_RewardPayTypeID,OfficeAutomation_Document_ExtraBonus_PayerName,OfficeAutomation_Document_ExtraBonus_PayerPosition,OfficeAutomation_Document_ExtraBonus_PayerPhone,OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName,OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts,OfficeAutomation_Document_ExtraBonus_IsNeedPayFee,OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase,OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation,OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate,OfficeAutomation_Document_ExtraBonus_JOrT,OfficeAutomation_Document_ExtraBonus_SamePlaceXX1,OfficeAutomation_Document_ExtraBonus_SamePlaceXX2,OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1,OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2,OfficeAutomation_Document_ExtraBonus_AgencyFee1,OfficeAutomation_Document_ExtraBonus_AgencyFee2,OfficeAutomation_Document_ExtraBonus_AgencyFee3,OfficeAutomation_Document_ExtraBonus_AgencyFee4,OfficeAutomation_Document_ExtraBonus_IsCashPrize1,OfficeAutomation_Document_ExtraBonus_IsCashPrize2,OfficeAutomation_Document_ExtraBonus_IsCashPrize3,OfficeAutomation_Document_ExtraBonus_IsCashPrize4,OfficeAutomation_Document_ExtraBonus_CashPrize1,OfficeAutomation_Document_ExtraBonus_CashPrize2,OfficeAutomation_Document_ExtraBonus_CashPrize3,OfficeAutomation_Document_ExtraBonus_CashPrize4,OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1,OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2,OfficeAutomation_Document_ExtraBonus_AgencyEndDate1,OfficeAutomation_Document_ExtraBonus_AgencyEndDate2,OfficeAutomation_Document_ExtraBonus_IsPFear1,OfficeAutomation_Document_ExtraBonus_IsPFear2,OfficeAutomation_Document_ExtraBonus_IsPFear3,OfficeAutomation_Document_ExtraBonus_IsPFear4,OfficeAutomation_Document_ExtraBonus_PFear1,OfficeAutomation_Document_ExtraBonus_PFear2,OfficeAutomation_Document_ExtraBonus_PFear3,OfficeAutomation_Document_ExtraBonus_PFear4,OfficeAutomation_Document_ExtraBonus_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ExtraBonus ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ExtraBonus ");
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
				strSql.Append("order by T.OfficeAutomation_Document_ExtraBonus_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ExtraBonus T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_ExtraBonus";
			parameters[1].Value = "OfficeAutomation_Document_ExtraBonus_ID";
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
}

