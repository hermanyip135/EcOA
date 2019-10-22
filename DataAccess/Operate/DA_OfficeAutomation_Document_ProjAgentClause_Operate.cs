/*
* DA_OfficeAutomation_Document_ProjAgentClause_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ProjAgentClause_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/15 11:43:20    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_ProjAgentClause_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_ProjAgentClause_Operate
	{
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_ProjAgentClause> dal;
		public DA_OfficeAutomation_Document_ProjAgentClause_Operate()
		{
            dal = new DAL.DalBase<T_OfficeAutomation_Document_ProjAgentClause>();
        }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ProjAgentClause_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ProjAgentClause");
			strSql.Append(" where OfficeAutomation_Document_ProjAgentClause_ID=@OfficeAutomation_Document_ProjAgentClause_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjAgentClause_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ProjAgentClause model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_ProjAgentClause(");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_ID,OfficeAutomation_Document_ProjAgentClause_MainID,OfficeAutomation_Document_ProjAgentClause_Department,OfficeAutomation_Document_ProjAgentClause_ApplyDate,OfficeAutomation_Document_ProjAgentClause_Apply,OfficeAutomation_Document_ProjAgentClause_ReplyPhone,OfficeAutomation_Document_ProjAgentClause_ApplyID,OfficeAutomation_Document_ProjAgentClause_ProjName,OfficeAutomation_Document_ProjAgentClause_DeveloperName,OfficeAutomation_Document_ProjAgentClause_ProjAddress,OfficeAutomation_Document_ProjAgentClause_AgentStart,OfficeAutomation_Document_ProjAgentClause_AgentEnd,OfficeAutomation_Document_ProjAgentClause_SaleDate,OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs,OfficeAutomation_Document_ProjAgentClause_DealOfficeOther,OfficeAutomation_Document_ProjAgentClause_GoodsQuantity,OfficeAutomation_Document_ProjAgentClause_GoodsValue,OfficeAutomation_Document_ProjAgentClause_PreComm,OfficeAutomation_Document_ProjAgentClause_AgentModel,OfficeAutomation_Document_ProjAgentClause_PorjectExam,OfficeAutomation_Document_ProjAgentClause_CommPoint,OfficeAutomation_Document_ProjAgentClause_ContractType,OfficeAutomation_Document_ProjAgentClause_ContractTypeOther,OfficeAutomation_Document_ProjAgentClause_Remark,OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm,OfficeAutomation_Document_ProjAgentClause_ClauseFine,OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit,OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck,OfficeAutomation_Document_ProjAgentClause_ClauseHonest,OfficeAutomation_Document_ProjAgentClause_JOrT,OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1,OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2,OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1,OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2,OfficeAutomation_Document_ProjAgentClause_AgencyFee1,OfficeAutomation_Document_ProjAgentClause_AgencyFee2,OfficeAutomation_Document_ProjAgentClause_AgencyFee3,OfficeAutomation_Document_ProjAgentClause_AgencyFee4,OfficeAutomation_Document_ProjAgentClause_IsCashPrize1,OfficeAutomation_Document_ProjAgentClause_IsCashPrize2,OfficeAutomation_Document_ProjAgentClause_IsCashPrize3,OfficeAutomation_Document_ProjAgentClause_IsCashPrize4,OfficeAutomation_Document_ProjAgentClause_CashPrize1,OfficeAutomation_Document_ProjAgentClause_CashPrize2,OfficeAutomation_Document_ProjAgentClause_CashPrize3,OfficeAutomation_Document_ProjAgentClause_CashPrize4,OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1,OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2,OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1,OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2,OfficeAutomation_Document_ProjAgentClause_IsPFear1,OfficeAutomation_Document_ProjAgentClause_IsPFear2,OfficeAutomation_Document_ProjAgentClause_IsPFear3,OfficeAutomation_Document_ProjAgentClause_IsPFear4,OfficeAutomation_Document_ProjAgentClause_PFear1,OfficeAutomation_Document_ProjAgentClause_PFear2,OfficeAutomation_Document_ProjAgentClause_PFear3,OfficeAutomation_Document_ProjAgentClause_PFear4,OfficeAutomation_Document_ProjAgentClause_ClauseOther,OfficeAutomation_Document_ProjAgentClause_Sign)");
            //strSql.Append("OfficeAutomation_Document_ProjAgentClause_ID,OfficeAutomation_Document_ProjAgentClause_MainID,OfficeAutomation_Document_ProjAgentClause_Department,OfficeAutomation_Document_ProjAgentClause_ApplyDate,OfficeAutomation_Document_ProjAgentClause_Apply,OfficeAutomation_Document_ProjAgentClause_ReplyPhone,OfficeAutomation_Document_ProjAgentClause_ApplyID,OfficeAutomation_Document_ProjAgentClause_ProjName,OfficeAutomation_Document_ProjAgentClause_DeveloperName,OfficeAutomation_Document_ProjAgentClause_ProjAddress,OfficeAutomation_Document_ProjAgentClause_AgentStart,OfficeAutomation_Document_ProjAgentClause_AgentEnd,OfficeAutomation_Document_ProjAgentClause_SaleDate,OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs,OfficeAutomation_Document_ProjAgentClause_DealOfficeOther,OfficeAutomation_Document_ProjAgentClause_GoodsQuantity,OfficeAutomation_Document_ProjAgentClause_GoodsValue,OfficeAutomation_Document_ProjAgentClause_PreComm,OfficeAutomation_Document_ProjAgentClause_AgentModel,OfficeAutomation_Document_ProjAgentClause_PorjectExam,OfficeAutomation_Document_ProjAgentClause_CommPoint,OfficeAutomation_Document_ProjAgentClause_ContractType,OfficeAutomation_Document_ProjAgentClause_ContractTypeOther,OfficeAutomation_Document_ProjAgentClause_Remark,OfficeAutomation_Document_ProjAgentClause_PerformanceProfitInfo,OfficeAutomation_Document_ProjAgentClause_SumPerformance,OfficeAutomation_Document_ProjAgentClause_SumProfit,OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm,OfficeAutomation_Document_ProjAgentClause_ClauseFine,OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit,OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck,OfficeAutomation_Document_ProjAgentClause_ClauseHonest,OfficeAutomation_Document_ProjAgentClause_ClauseOther,OfficeAutomation_Document_ProjAgentClause_Sign)");
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ProjAgentClause_ID,@OfficeAutomation_Document_ProjAgentClause_MainID,@OfficeAutomation_Document_ProjAgentClause_Department,@OfficeAutomation_Document_ProjAgentClause_ApplyDate,@OfficeAutomation_Document_ProjAgentClause_Apply,@OfficeAutomation_Document_ProjAgentClause_ReplyPhone,@OfficeAutomation_Document_ProjAgentClause_ApplyID,@OfficeAutomation_Document_ProjAgentClause_ProjName,@OfficeAutomation_Document_ProjAgentClause_DeveloperName,@OfficeAutomation_Document_ProjAgentClause_ProjAddress,@OfficeAutomation_Document_ProjAgentClause_AgentStart,@OfficeAutomation_Document_ProjAgentClause_AgentEnd,@OfficeAutomation_Document_ProjAgentClause_SaleDate,@OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs,@OfficeAutomation_Document_ProjAgentClause_DealOfficeOther,@OfficeAutomation_Document_ProjAgentClause_GoodsQuantity,@OfficeAutomation_Document_ProjAgentClause_GoodsValue,@OfficeAutomation_Document_ProjAgentClause_PreComm,@OfficeAutomation_Document_ProjAgentClause_AgentModel,@OfficeAutomation_Document_ProjAgentClause_PorjectExam,@OfficeAutomation_Document_ProjAgentClause_CommPoint,@OfficeAutomation_Document_ProjAgentClause_ContractType,@OfficeAutomation_Document_ProjAgentClause_ContractTypeOther,@OfficeAutomation_Document_ProjAgentClause_Remark,@OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm,@OfficeAutomation_Document_ProjAgentClause_ClauseFine,@OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit,@OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck,@OfficeAutomation_Document_ProjAgentClause_ClauseHonest,@OfficeAutomation_Document_ProjAgentClause_JOrT,@OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1,@OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2,@OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1,@OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2,@OfficeAutomation_Document_ProjAgentClause_AgencyFee1,@OfficeAutomation_Document_ProjAgentClause_AgencyFee2,@OfficeAutomation_Document_ProjAgentClause_AgencyFee3,@OfficeAutomation_Document_ProjAgentClause_AgencyFee4,@OfficeAutomation_Document_ProjAgentClause_IsCashPrize1,@OfficeAutomation_Document_ProjAgentClause_IsCashPrize2,@OfficeAutomation_Document_ProjAgentClause_IsCashPrize3,@OfficeAutomation_Document_ProjAgentClause_IsCashPrize4,@OfficeAutomation_Document_ProjAgentClause_CashPrize1,@OfficeAutomation_Document_ProjAgentClause_CashPrize2,@OfficeAutomation_Document_ProjAgentClause_CashPrize3,@OfficeAutomation_Document_ProjAgentClause_CashPrize4,@OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1,@OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2,@OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1,@OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2,@OfficeAutomation_Document_ProjAgentClause_IsPFear1,@OfficeAutomation_Document_ProjAgentClause_IsPFear2,@OfficeAutomation_Document_ProjAgentClause_IsPFear3,@OfficeAutomation_Document_ProjAgentClause_IsPFear4,@OfficeAutomation_Document_ProjAgentClause_PFear1,@OfficeAutomation_Document_ProjAgentClause_PFear2,@OfficeAutomation_Document_ProjAgentClause_PFear3,@OfficeAutomation_Document_ProjAgentClause_PFear4,@OfficeAutomation_Document_ProjAgentClause_ClauseOther,@OfficeAutomation_Document_ProjAgentClause_Sign)");
            //strSql.Append("@OfficeAutomation_Document_ProjAgentClause_ID,@OfficeAutomation_Document_ProjAgentClause_MainID,@OfficeAutomation_Document_ProjAgentClause_Department,@OfficeAutomation_Document_ProjAgentClause_ApplyDate,@OfficeAutomation_Document_ProjAgentClause_Apply,@OfficeAutomation_Document_ProjAgentClause_ReplyPhone,@OfficeAutomation_Document_ProjAgentClause_ApplyID,@OfficeAutomation_Document_ProjAgentClause_ProjName,@OfficeAutomation_Document_ProjAgentClause_DeveloperName,@OfficeAutomation_Document_ProjAgentClause_ProjAddress,@OfficeAutomation_Document_ProjAgentClause_AgentStart,@OfficeAutomation_Document_ProjAgentClause_AgentEnd,@OfficeAutomation_Document_ProjAgentClause_SaleDate,@OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs,@OfficeAutomation_Document_ProjAgentClause_DealOfficeOther,@OfficeAutomation_Document_ProjAgentClause_GoodsQuantity,@OfficeAutomation_Document_ProjAgentClause_GoodsValue,@OfficeAutomation_Document_ProjAgentClause_PreComm,@OfficeAutomation_Document_ProjAgentClause_AgentModel,@OfficeAutomation_Document_ProjAgentClause_PorjectExam,@OfficeAutomation_Document_ProjAgentClause_CommPoint,@OfficeAutomation_Document_ProjAgentClause_ContractType,@OfficeAutomation_Document_ProjAgentClause_ContractTypeOther,@OfficeAutomation_Document_ProjAgentClause_Remark,@OfficeAutomation_Document_ProjAgentClause_PerformanceProfitInfo,@OfficeAutomation_Document_ProjAgentClause_SumPerformance,@OfficeAutomation_Document_ProjAgentClause_SumProfit,@OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm,@OfficeAutomation_Document_ProjAgentClause_ClauseFine,@OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit,@OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck,@OfficeAutomation_Document_ProjAgentClause_ClauseHonest,@OfficeAutomation_Document_ProjAgentClause_ClauseOther,@OfficeAutomation_Document_ProjAgentClause_Sign)");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgentStart", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgentEnd", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SaleDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgentModel", SqlDbType.Int,4),

                    new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PorjectExam", SqlDbType.Bit,1),

					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ContractType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ContractTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_Remark", SqlDbType.NVarChar,-1),
                    //new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PerformanceProfitInfo", SqlDbType.NVarChar,-1),
                    //new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SumPerformance", SqlDbType.NVarChar,80),
                    //new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SumProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseFine", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseHonest", SqlDbType.NVarChar,-1),

					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PFear4", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseOther", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_Sign", SqlDbType.NVarChar,80)};
            parameters[0].Value = model.OfficeAutomation_Document_ProjAgentClause_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ProjAgentClause_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_ProjAgentClause_Department;
			parameters[3].Value = model.OfficeAutomation_Document_ProjAgentClause_ApplyDate;
			parameters[4].Value = model.OfficeAutomation_Document_ProjAgentClause_Apply;
			parameters[5].Value = model.OfficeAutomation_Document_ProjAgentClause_ReplyPhone;
			parameters[6].Value = model.OfficeAutomation_Document_ProjAgentClause_ApplyID;
			parameters[7].Value = model.OfficeAutomation_Document_ProjAgentClause_ProjName;
			parameters[8].Value = model.OfficeAutomation_Document_ProjAgentClause_DeveloperName;
			parameters[9].Value = model.OfficeAutomation_Document_ProjAgentClause_ProjAddress;
			parameters[10].Value = model.OfficeAutomation_Document_ProjAgentClause_AgentStart;
			parameters[11].Value = model.OfficeAutomation_Document_ProjAgentClause_AgentEnd;
			parameters[12].Value = model.OfficeAutomation_Document_ProjAgentClause_SaleDate;
			parameters[13].Value = model.OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs;
			parameters[14].Value = model.OfficeAutomation_Document_ProjAgentClause_DealOfficeOther;
			parameters[15].Value = model.OfficeAutomation_Document_ProjAgentClause_GoodsQuantity;
			parameters[16].Value = model.OfficeAutomation_Document_ProjAgentClause_GoodsValue;
			parameters[17].Value = model.OfficeAutomation_Document_ProjAgentClause_PreComm;
			parameters[18].Value = model.OfficeAutomation_Document_ProjAgentClause_AgentModel;

            parameters[19].Value = model.OfficeAutomation_Document_ProjAgentClause_PorjectExam;

			parameters[20].Value = model.OfficeAutomation_Document_ProjAgentClause_CommPoint;
			parameters[21].Value = model.OfficeAutomation_Document_ProjAgentClause_ContractType;
			parameters[22].Value = model.OfficeAutomation_Document_ProjAgentClause_ContractTypeOther;
			parameters[23].Value = model.OfficeAutomation_Document_ProjAgentClause_Remark;
            parameters[24].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm;
            parameters[25].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseFine;
            parameters[26].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit;
            parameters[27].Value = model.OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck;
            parameters[28].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseHonest;

            parameters[29].Value = model.OfficeAutomation_Document_ProjAgentClause_JOrT;
            parameters[30].Value = model.OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1;
            parameters[31].Value = model.OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2;
            parameters[32].Value = model.OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1;
            parameters[33].Value = model.OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2;
            parameters[34].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyFee1;
            parameters[35].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyFee2;
            parameters[36].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyFee3;
            parameters[37].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyFee4;
            parameters[38].Value = model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize1;
            parameters[39].Value = model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize2;
            parameters[40].Value = model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize3;
            parameters[41].Value = model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize4;
            parameters[42].Value = model.OfficeAutomation_Document_ProjAgentClause_CashPrize1;
            parameters[43].Value = model.OfficeAutomation_Document_ProjAgentClause_CashPrize2;
            parameters[44].Value = model.OfficeAutomation_Document_ProjAgentClause_CashPrize3;
            parameters[45].Value = model.OfficeAutomation_Document_ProjAgentClause_CashPrize4;
            parameters[46].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1;
            parameters[47].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2;
            parameters[48].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1;
            parameters[49].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2;
            parameters[50].Value = model.OfficeAutomation_Document_ProjAgentClause_IsPFear1;
            parameters[51].Value = model.OfficeAutomation_Document_ProjAgentClause_IsPFear2;
            parameters[52].Value = model.OfficeAutomation_Document_ProjAgentClause_IsPFear3;
            parameters[53].Value = model.OfficeAutomation_Document_ProjAgentClause_IsPFear4;
            parameters[54].Value = model.OfficeAutomation_Document_ProjAgentClause_PFear1;
            parameters[55].Value = model.OfficeAutomation_Document_ProjAgentClause_PFear2;
            parameters[56].Value = model.OfficeAutomation_Document_ProjAgentClause_PFear3;
            parameters[57].Value = model.OfficeAutomation_Document_ProjAgentClause_PFear4;

            parameters[58].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseOther;
            parameters[59].Value = model.OfficeAutomation_Document_ProjAgentClause_Sign;
            //parameters[23].Value = model.OfficeAutomation_Document_ProjAgentClause_PerformanceProfitInfo;
            //parameters[24].Value = model.OfficeAutomation_Document_ProjAgentClause_SumPerformance;
            //parameters[25].Value = model.OfficeAutomation_Document_ProjAgentClause_SumProfit;
            //parameters[26].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm;
            //parameters[27].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseFine;
            //parameters[28].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit;
            //parameters[29].Value = model.OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck;
            //parameters[30].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseHonest;
            //parameters[31].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseOther;
            //parameters[32].Value = model.OfficeAutomation_Document_ProjAgentClause_Sign;

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
		public bool Update(DataEntity.T_OfficeAutomation_Document_ProjAgentClause model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ProjAgentClause set ");
			//strSql.Append("OfficeAutomation_Document_ProjAgentClause_MainID=@OfficeAutomation_Document_ProjAgentClause_MainID,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_Department=@OfficeAutomation_Document_ProjAgentClause_Department,");
			//strSql.Append("OfficeAutomation_Document_ProjAgentClause_ApplyDate=@OfficeAutomation_Document_ProjAgentClause_ApplyDate,");
			//strSql.Append("OfficeAutomation_Document_ProjAgentClause_Apply=@OfficeAutomation_Document_ProjAgentClause_Apply,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ReplyPhone=@OfficeAutomation_Document_ProjAgentClause_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ApplyID=@OfficeAutomation_Document_ProjAgentClause_ApplyID,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ProjName=@OfficeAutomation_Document_ProjAgentClause_ProjName,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_DeveloperName=@OfficeAutomation_Document_ProjAgentClause_DeveloperName,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ProjAddress=@OfficeAutomation_Document_ProjAgentClause_ProjAddress,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgentStart=@OfficeAutomation_Document_ProjAgentClause_AgentStart,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgentEnd=@OfficeAutomation_Document_ProjAgentClause_AgentEnd,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_SaleDate=@OfficeAutomation_Document_ProjAgentClause_SaleDate,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs=@OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_DealOfficeOther=@OfficeAutomation_Document_ProjAgentClause_DealOfficeOther,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_GoodsQuantity=@OfficeAutomation_Document_ProjAgentClause_GoodsQuantity,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_GoodsValue=@OfficeAutomation_Document_ProjAgentClause_GoodsValue,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_PreComm=@OfficeAutomation_Document_ProjAgentClause_PreComm,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgentModel=@OfficeAutomation_Document_ProjAgentClause_AgentModel,");

            strSql.Append("OfficeAutomation_Document_ProjAgentClause_PorjectExam=@OfficeAutomation_Document_ProjAgentClause_PorjectExam,");

			strSql.Append("OfficeAutomation_Document_ProjAgentClause_CommPoint=@OfficeAutomation_Document_ProjAgentClause_CommPoint,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ContractType=@OfficeAutomation_Document_ProjAgentClause_ContractType,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ContractTypeOther=@OfficeAutomation_Document_ProjAgentClause_ContractTypeOther,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_Remark=@OfficeAutomation_Document_ProjAgentClause_Remark,");
            //strSql.Append("OfficeAutomation_Document_ProjAgentClause_PerformanceProfitInfo=@OfficeAutomation_Document_ProjAgentClause_PerformanceProfitInfo,");
            //strSql.Append("OfficeAutomation_Document_ProjAgentClause_SumPerformance=@OfficeAutomation_Document_ProjAgentClause_SumPerformance,");
            //strSql.Append("OfficeAutomation_Document_ProjAgentClause_SumProfit=@OfficeAutomation_Document_ProjAgentClause_SumProfit,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm=@OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ClauseFine=@OfficeAutomation_Document_ProjAgentClause_ClauseFine,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit=@OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck=@OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck,");
			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ClauseHonest=@OfficeAutomation_Document_ProjAgentClause_ClauseHonest,");

            strSql.Append("OfficeAutomation_Document_ProjAgentClause_JOrT=@OfficeAutomation_Document_ProjAgentClause_JOrT,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1=@OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2=@OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1=@OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2=@OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgencyFee1=@OfficeAutomation_Document_ProjAgentClause_AgencyFee1,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgencyFee2=@OfficeAutomation_Document_ProjAgentClause_AgencyFee2,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgencyFee3=@OfficeAutomation_Document_ProjAgentClause_AgencyFee3,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgencyFee4=@OfficeAutomation_Document_ProjAgentClause_AgencyFee4,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_IsCashPrize1=@OfficeAutomation_Document_ProjAgentClause_IsCashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_IsCashPrize2=@OfficeAutomation_Document_ProjAgentClause_IsCashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_IsCashPrize3=@OfficeAutomation_Document_ProjAgentClause_IsCashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_IsCashPrize4=@OfficeAutomation_Document_ProjAgentClause_IsCashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_CashPrize1=@OfficeAutomation_Document_ProjAgentClause_CashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_CashPrize2=@OfficeAutomation_Document_ProjAgentClause_CashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_CashPrize3=@OfficeAutomation_Document_ProjAgentClause_CashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_CashPrize4=@OfficeAutomation_Document_ProjAgentClause_CashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1=@OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2=@OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1=@OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2=@OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_IsPFear1=@OfficeAutomation_Document_ProjAgentClause_IsPFear1,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_IsPFear2=@OfficeAutomation_Document_ProjAgentClause_IsPFear2,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_IsPFear3=@OfficeAutomation_Document_ProjAgentClause_IsPFear3,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_IsPFear4=@OfficeAutomation_Document_ProjAgentClause_IsPFear4,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_PFear1=@OfficeAutomation_Document_ProjAgentClause_PFear1,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_PFear2=@OfficeAutomation_Document_ProjAgentClause_PFear2,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_PFear3=@OfficeAutomation_Document_ProjAgentClause_PFear3,");
            strSql.Append("OfficeAutomation_Document_ProjAgentClause_PFear4=@OfficeAutomation_Document_ProjAgentClause_PFear4,");


			strSql.Append("OfficeAutomation_Document_ProjAgentClause_ClauseOther=@OfficeAutomation_Document_ProjAgentClause_ClauseOther");
			//strSql.Append("OfficeAutomation_Document_ProjAgentClause_Sign=@OfficeAutomation_Document_ProjAgentClause_Sign");
			strSql.Append(" where OfficeAutomation_Document_ProjAgentClause_ID=@OfficeAutomation_Document_ProjAgentClause_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_Department", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ApplyDate", SqlDbType.DateTime),
					//new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgentStart", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgentEnd", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SaleDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgentModel", SqlDbType.Int,4),

                    new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PorjectExam", SqlDbType.Bit,1),

					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ContractType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ContractTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_Remark", SqlDbType.NVarChar,-1),
                    //new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PerformanceProfitInfo", SqlDbType.NVarChar,-1),
                    //new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SumPerformance", SqlDbType.NVarChar,80),
                    //new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SumProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseFine", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseHonest", SqlDbType.NVarChar,-1),

                    new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_PFear4", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ClauseOther", SqlDbType.NVarChar,-1),
					//new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_Sign", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_ProjAgentClause_MainID;
			parameters[0].Value = model.OfficeAutomation_Document_ProjAgentClause_Department;
			//parameters[2].Value = model.OfficeAutomation_Document_ProjAgentClause_ApplyDate;
			//parameters[3].Value = model.OfficeAutomation_Document_ProjAgentClause_Apply;
			parameters[1].Value = model.OfficeAutomation_Document_ProjAgentClause_ReplyPhone;
			parameters[2].Value = model.OfficeAutomation_Document_ProjAgentClause_ApplyID;
			parameters[3].Value = model.OfficeAutomation_Document_ProjAgentClause_ProjName;
			parameters[4].Value = model.OfficeAutomation_Document_ProjAgentClause_DeveloperName;
			parameters[5].Value = model.OfficeAutomation_Document_ProjAgentClause_ProjAddress;
			parameters[6].Value = model.OfficeAutomation_Document_ProjAgentClause_AgentStart;
			parameters[7].Value = model.OfficeAutomation_Document_ProjAgentClause_AgentEnd;
			parameters[8].Value = model.OfficeAutomation_Document_ProjAgentClause_SaleDate;
			parameters[9].Value = model.OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs;
			parameters[10].Value = model.OfficeAutomation_Document_ProjAgentClause_DealOfficeOther;
			parameters[11].Value = model.OfficeAutomation_Document_ProjAgentClause_GoodsQuantity;
			parameters[12].Value = model.OfficeAutomation_Document_ProjAgentClause_GoodsValue;
			parameters[13].Value = model.OfficeAutomation_Document_ProjAgentClause_PreComm;
			parameters[14].Value = model.OfficeAutomation_Document_ProjAgentClause_AgentModel;

            parameters[15].Value = model.OfficeAutomation_Document_ProjAgentClause_PorjectExam;

			parameters[16].Value = model.OfficeAutomation_Document_ProjAgentClause_CommPoint;
			parameters[17].Value = model.OfficeAutomation_Document_ProjAgentClause_ContractType;
			parameters[18].Value = model.OfficeAutomation_Document_ProjAgentClause_ContractTypeOther;
			parameters[19].Value = model.OfficeAutomation_Document_ProjAgentClause_Remark;
            //parameters[19].Value = model.OfficeAutomation_Document_ProjAgentClause_PerformanceProfitInfo;
            //parameters[20].Value = model.OfficeAutomation_Document_ProjAgentClause_SumPerformance;
            //parameters[21].Value = model.OfficeAutomation_Document_ProjAgentClause_SumProfit;
            //parameters[22].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm;
            //parameters[23].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseFine;
            //parameters[24].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit;
            //parameters[25].Value = model.OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck;
            //parameters[26].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseHonest;
            //parameters[27].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseOther;
            ////parameters[28].Value = model.OfficeAutomation_Document_ProjAgentClause_Sign;
            //parameters[28].Value = model.OfficeAutomation_Document_ProjAgentClause_ID; 
            parameters[20].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm;
            parameters[21].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseFine;
            parameters[22].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit;
            parameters[23].Value = model.OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck;
            parameters[24].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseHonest;

            parameters[25].Value = model.OfficeAutomation_Document_ProjAgentClause_JOrT;
            parameters[26].Value = model.OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1;
            parameters[27].Value = model.OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2;
            parameters[28].Value = model.OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1;
            parameters[29].Value = model.OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2;
            parameters[30].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyFee1;
            parameters[31].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyFee2;
            parameters[32].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyFee3;
            parameters[33].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyFee4;
            parameters[34].Value = model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize1;
            parameters[35].Value = model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize2;
            parameters[36].Value = model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize3;
            parameters[37].Value = model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize4;
            parameters[38].Value = model.OfficeAutomation_Document_ProjAgentClause_CashPrize1;
            parameters[39].Value = model.OfficeAutomation_Document_ProjAgentClause_CashPrize2;
            parameters[40].Value = model.OfficeAutomation_Document_ProjAgentClause_CashPrize3;
            parameters[41].Value = model.OfficeAutomation_Document_ProjAgentClause_CashPrize4;
            parameters[42].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1;
            parameters[43].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2;
            parameters[44].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1;
            parameters[45].Value = model.OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2;
            parameters[46].Value = model.OfficeAutomation_Document_ProjAgentClause_IsPFear1;
            parameters[47].Value = model.OfficeAutomation_Document_ProjAgentClause_IsPFear2;
            parameters[48].Value = model.OfficeAutomation_Document_ProjAgentClause_IsPFear3;
            parameters[49].Value = model.OfficeAutomation_Document_ProjAgentClause_IsPFear4;
            parameters[50].Value = model.OfficeAutomation_Document_ProjAgentClause_PFear1;
            parameters[51].Value = model.OfficeAutomation_Document_ProjAgentClause_PFear2;
            parameters[52].Value = model.OfficeAutomation_Document_ProjAgentClause_PFear3;
            parameters[53].Value = model.OfficeAutomation_Document_ProjAgentClause_PFear4;

            parameters[54].Value = model.OfficeAutomation_Document_ProjAgentClause_ClauseOther;
            parameters[55].Value = model.OfficeAutomation_Document_ProjAgentClause_ID;

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
		public bool Delete(string OfficeAutomation_Document_ProjAgentClause_ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_ProjAgentClause_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ProjAgentClause_ID);

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
		public bool DeleteList(string OfficeAutomation_Document_ProjAgentClause_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ProjAgentClause ");
			strSql.Append(" where OfficeAutomation_Document_ProjAgentClause_ID in ("+OfficeAutomation_Document_ProjAgentClause_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_ProjAgentClause GetModel(Guid OfficeAutomation_Document_ProjAgentClause_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_ProjAgentClause_ID,OfficeAutomation_Document_ProjAgentClause_MainID,OfficeAutomation_Document_ProjAgentClause_Department,OfficeAutomation_Document_ProjAgentClause_ApplyDate,OfficeAutomation_Document_ProjAgentClause_Apply,OfficeAutomation_Document_ProjAgentClause_ReplyPhone,OfficeAutomation_Document_ProjAgentClause_ApplyID,OfficeAutomation_Document_ProjAgentClause_ProjName,OfficeAutomation_Document_ProjAgentClause_DeveloperName,OfficeAutomation_Document_ProjAgentClause_ProjAddress,OfficeAutomation_Document_ProjAgentClause_AgentStart,OfficeAutomation_Document_ProjAgentClause_AgentEnd,OfficeAutomation_Document_ProjAgentClause_SaleDate,OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs,OfficeAutomation_Document_ProjAgentClause_DealOfficeOther,OfficeAutomation_Document_ProjAgentClause_GoodsQuantity,OfficeAutomation_Document_ProjAgentClause_GoodsValue,OfficeAutomation_Document_ProjAgentClause_PreComm,OfficeAutomation_Document_ProjAgentClause_AgentModel,OfficeAutomation_Document_ProjAgentClause_PorjectExam,OfficeAutomation_Document_ProjAgentClause_CommPoint,OfficeAutomation_Document_ProjAgentClause_ContractType,OfficeAutomation_Document_ProjAgentClause_ContractTypeOther,OfficeAutomation_Document_ProjAgentClause_Remark,OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm,OfficeAutomation_Document_ProjAgentClause_ClauseFine,OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit,OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck,OfficeAutomation_Document_ProjAgentClause_ClauseHonest,OfficeAutomation_Document_ProjAgentClause_JOrT,OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1,OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2,OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1,OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2,OfficeAutomation_Document_ProjAgentClause_AgencyFee1,OfficeAutomation_Document_ProjAgentClause_AgencyFee2,OfficeAutomation_Document_ProjAgentClause_AgencyFee3,OfficeAutomation_Document_ProjAgentClause_AgencyFee4,OfficeAutomation_Document_ProjAgentClause_IsCashPrize1,OfficeAutomation_Document_ProjAgentClause_IsCashPrize2,OfficeAutomation_Document_ProjAgentClause_IsCashPrize3,OfficeAutomation_Document_ProjAgentClause_IsCashPrize4,OfficeAutomation_Document_ProjAgentClause_CashPrize1,OfficeAutomation_Document_ProjAgentClause_CashPrize2,OfficeAutomation_Document_ProjAgentClause_CashPrize3,OfficeAutomation_Document_ProjAgentClause_CashPrize4,OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1,OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2,OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1,OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2,OfficeAutomation_Document_ProjAgentClause_IsPFear1,OfficeAutomation_Document_ProjAgentClause_IsPFear2,OfficeAutomation_Document_ProjAgentClause_IsPFear3,OfficeAutomation_Document_ProjAgentClause_IsPFear4,OfficeAutomation_Document_ProjAgentClause_PFear1,OfficeAutomation_Document_ProjAgentClause_PFear2,OfficeAutomation_Document_ProjAgentClause_PFear3,OfficeAutomation_Document_ProjAgentClause_PFear4,OfficeAutomation_Document_ProjAgentClause_ClauseOther,OfficeAutomation_Document_ProjAgentClause_Sign from t_OfficeAutomation_Document_ProjAgentClause ");
			strSql.Append(" where OfficeAutomation_Document_ProjAgentClause_ID=@OfficeAutomation_Document_ProjAgentClause_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjAgentClause_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjAgentClause_ID;

			DataEntity.T_OfficeAutomation_Document_ProjAgentClause model=new DataEntity.T_OfficeAutomation_Document_ProjAgentClause();
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
		public DataEntity.T_OfficeAutomation_Document_ProjAgentClause DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_ProjAgentClause model=new DataEntity.T_OfficeAutomation_Document_ProjAgentClause();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_ProjAgentClause_ID"]!=null && row["OfficeAutomation_Document_ProjAgentClause_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjAgentClause_ID= new Guid(row["OfficeAutomation_Document_ProjAgentClause_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_MainID"]!=null && row["OfficeAutomation_Document_ProjAgentClause_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjAgentClause_MainID= new Guid(row["OfficeAutomation_Document_ProjAgentClause_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_Department"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_Department=row["OfficeAutomation_Document_ProjAgentClause_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ApplyDate"]!=null && row["OfficeAutomation_Document_ProjAgentClause_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjAgentClause_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_ProjAgentClause_ApplyDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_Apply"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_Apply=row["OfficeAutomation_Document_ProjAgentClause_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ReplyPhone"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ReplyPhone=row["OfficeAutomation_Document_ProjAgentClause_ReplyPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ApplyID"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ApplyID=row["OfficeAutomation_Document_ProjAgentClause_ApplyID"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ProjName"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ProjName=row["OfficeAutomation_Document_ProjAgentClause_ProjName"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_DeveloperName"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_DeveloperName=row["OfficeAutomation_Document_ProjAgentClause_DeveloperName"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ProjAddress"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ProjAddress=row["OfficeAutomation_Document_ProjAgentClause_ProjAddress"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_AgentStart"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_AgentStart=row["OfficeAutomation_Document_ProjAgentClause_AgentStart"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_AgentEnd"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_AgentEnd=row["OfficeAutomation_Document_ProjAgentClause_AgentEnd"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_SaleDate"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_SaleDate=row["OfficeAutomation_Document_ProjAgentClause_SaleDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs=row["OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_DealOfficeOther"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_DealOfficeOther=row["OfficeAutomation_Document_ProjAgentClause_DealOfficeOther"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_GoodsQuantity"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_GoodsQuantity=row["OfficeAutomation_Document_ProjAgentClause_GoodsQuantity"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_GoodsValue"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_GoodsValue=row["OfficeAutomation_Document_ProjAgentClause_GoodsValue"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_PreComm"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_PreComm=row["OfficeAutomation_Document_ProjAgentClause_PreComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_AgentModel"]!=null && row["OfficeAutomation_Document_ProjAgentClause_AgentModel"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjAgentClause_AgentModel=int.Parse(row["OfficeAutomation_Document_ProjAgentClause_AgentModel"].ToString());
				}

                if (row["OfficeAutomation_Document_ProjAgentClause_PorjectExam"] != null && row["OfficeAutomation_Document_ProjAgentClause_PorjectExam"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjAgentClause_PorjectExam = bool.Parse(row["OfficeAutomation_Document_ProjAgentClause_PorjectExam"].ToString());
                }

				if(row["OfficeAutomation_Document_ProjAgentClause_CommPoint"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_CommPoint=row["OfficeAutomation_Document_ProjAgentClause_CommPoint"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ContractType"]!=null && row["OfficeAutomation_Document_ProjAgentClause_ContractType"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjAgentClause_ContractType=int.Parse(row["OfficeAutomation_Document_ProjAgentClause_ContractType"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ContractTypeOther"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ContractTypeOther=row["OfficeAutomation_Document_ProjAgentClause_ContractTypeOther"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_Remark"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_Remark=row["OfficeAutomation_Document_ProjAgentClause_Remark"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm=row["OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ClauseFine"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ClauseFine=row["OfficeAutomation_Document_ProjAgentClause_ClauseFine"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit=row["OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck=row["OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_ClauseHonest"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ClauseHonest=row["OfficeAutomation_Document_ProjAgentClause_ClauseHonest"].ToString();
				}

                if (row["OfficeAutomation_Document_ProjAgentClause_JOrT"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_JOrT = int.Parse( row["OfficeAutomation_Document_ProjAgentClause_JOrT"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1 = row["OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2 = row["OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1 = row["OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2 = row["OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_AgencyFee1"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_AgencyFee1 = row["OfficeAutomation_Document_ProjAgentClause_AgencyFee1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_AgencyFee2"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_AgencyFee2 = row["OfficeAutomation_Document_ProjAgentClause_AgencyFee2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_AgencyFee3"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_AgencyFee3 = row["OfficeAutomation_Document_ProjAgentClause_AgencyFee3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_AgencyFee4"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_AgencyFee4 = row["OfficeAutomation_Document_ProjAgentClause_AgencyFee4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_IsCashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize1 = bool.Parse( row["OfficeAutomation_Document_ProjAgentClause_IsCashPrize1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_IsCashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize2 = bool.Parse(row["OfficeAutomation_Document_ProjAgentClause_IsCashPrize2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_IsCashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize3 = bool.Parse(row["OfficeAutomation_Document_ProjAgentClause_IsCashPrize3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_IsCashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_IsCashPrize4 = bool.Parse(row["OfficeAutomation_Document_ProjAgentClause_IsCashPrize4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_CashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_CashPrize1 = row["OfficeAutomation_Document_ProjAgentClause_CashPrize1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_CashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_CashPrize2 = row["OfficeAutomation_Document_ProjAgentClause_CashPrize2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_CashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_CashPrize3 = row["OfficeAutomation_Document_ProjAgentClause_CashPrize3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_CashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_CashPrize4 = row["OfficeAutomation_Document_ProjAgentClause_CashPrize4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1 = row["OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2 = row["OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1 = row["OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2 = row["OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_IsPFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_IsPFear1 = bool.Parse(row["OfficeAutomation_Document_ProjAgentClause_IsPFear1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_IsPFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_IsPFear2 = bool.Parse(row["OfficeAutomation_Document_ProjAgentClause_IsPFear2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_IsPFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_IsPFear3 = bool.Parse(row["OfficeAutomation_Document_ProjAgentClause_IsPFear3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_IsPFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_IsPFear4 = bool.Parse(row["OfficeAutomation_Document_ProjAgentClause_IsPFear4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_PFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_PFear1 = row["OfficeAutomation_Document_ProjAgentClause_PFear1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_PFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_PFear2 = row["OfficeAutomation_Document_ProjAgentClause_PFear2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_PFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_PFear3 = row["OfficeAutomation_Document_ProjAgentClause_PFear3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjAgentClause_PFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjAgentClause_PFear4 = row["OfficeAutomation_Document_ProjAgentClause_PFear4"].ToString();
                }

				if(row["OfficeAutomation_Document_ProjAgentClause_ClauseOther"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_ClauseOther=row["OfficeAutomation_Document_ProjAgentClause_ClauseOther"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjAgentClause_Sign"]!=null)
				{
					model.OfficeAutomation_Document_ProjAgentClause_Sign=row["OfficeAutomation_Document_ProjAgentClause_Sign"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_ProjAgentClause_ID,OfficeAutomation_Document_ProjAgentClause_MainID,OfficeAutomation_Document_ProjAgentClause_Department,OfficeAutomation_Document_ProjAgentClause_ApplyDate,OfficeAutomation_Document_ProjAgentClause_Apply,OfficeAutomation_Document_ProjAgentClause_ReplyPhone,OfficeAutomation_Document_ProjAgentClause_ApplyID,OfficeAutomation_Document_ProjAgentClause_ProjName,OfficeAutomation_Document_ProjAgentClause_DeveloperName,OfficeAutomation_Document_ProjAgentClause_ProjAddress,OfficeAutomation_Document_ProjAgentClause_AgentStart,OfficeAutomation_Document_ProjAgentClause_AgentEnd,OfficeAutomation_Document_ProjAgentClause_SaleDate,OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs,OfficeAutomation_Document_ProjAgentClause_DealOfficeOther,OfficeAutomation_Document_ProjAgentClause_GoodsQuantity,OfficeAutomation_Document_ProjAgentClause_GoodsValue,OfficeAutomation_Document_ProjAgentClause_PreComm,OfficeAutomation_Document_ProjAgentClause_AgentModel,OfficeAutomation_Document_ProjAgentClause_PorjectExam,OfficeAutomation_Document_ProjAgentClause_CommPoint,OfficeAutomation_Document_ProjAgentClause_ContractType,OfficeAutomation_Document_ProjAgentClause_ContractTypeOther,OfficeAutomation_Document_ProjAgentClause_Remark,OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm,OfficeAutomation_Document_ProjAgentClause_ClauseFine,OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit,OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck,OfficeAutomation_Document_ProjAgentClause_ClauseHonest,OfficeAutomation_Document_ProjAgentClause_JOrT,OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1,OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2,OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1,OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2,OfficeAutomation_Document_ProjAgentClause_AgencyFee1,OfficeAutomation_Document_ProjAgentClause_AgencyFee2,OfficeAutomation_Document_ProjAgentClause_AgencyFee3,OfficeAutomation_Document_ProjAgentClause_AgencyFee4,OfficeAutomation_Document_ProjAgentClause_IsCashPrize1,OfficeAutomation_Document_ProjAgentClause_IsCashPrize2,OfficeAutomation_Document_ProjAgentClause_IsCashPrize3,OfficeAutomation_Document_ProjAgentClause_IsCashPrize4,OfficeAutomation_Document_ProjAgentClause_CashPrize1,OfficeAutomation_Document_ProjAgentClause_CashPrize2,OfficeAutomation_Document_ProjAgentClause_CashPrize3,OfficeAutomation_Document_ProjAgentClause_CashPrize4,OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1,OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2,OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1,OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2,OfficeAutomation_Document_ProjAgentClause_IsPFear1,OfficeAutomation_Document_ProjAgentClause_IsPFear2,OfficeAutomation_Document_ProjAgentClause_IsPFear3,OfficeAutomation_Document_ProjAgentClause_IsPFear4,OfficeAutomation_Document_ProjAgentClause_PFear1,OfficeAutomation_Document_ProjAgentClause_PFear2,OfficeAutomation_Document_ProjAgentClause_PFear3,OfficeAutomation_Document_ProjAgentClause_PFear4,OfficeAutomation_Document_ProjAgentClause_ClauseOther,OfficeAutomation_Document_ProjAgentClause_Sign ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjAgentClause ");
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
            strSql.Append(" OfficeAutomation_Document_ProjAgentClause_ID,OfficeAutomation_Document_ProjAgentClause_MainID,OfficeAutomation_Document_ProjAgentClause_Department,OfficeAutomation_Document_ProjAgentClause_ApplyDate,OfficeAutomation_Document_ProjAgentClause_Apply,OfficeAutomation_Document_ProjAgentClause_ReplyPhone,OfficeAutomation_Document_ProjAgentClause_ApplyID,OfficeAutomation_Document_ProjAgentClause_ProjName,OfficeAutomation_Document_ProjAgentClause_DeveloperName,OfficeAutomation_Document_ProjAgentClause_ProjAddress,OfficeAutomation_Document_ProjAgentClause_AgentStart,OfficeAutomation_Document_ProjAgentClause_AgentEnd,OfficeAutomation_Document_ProjAgentClause_SaleDate,OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs,OfficeAutomation_Document_ProjAgentClause_DealOfficeOther,OfficeAutomation_Document_ProjAgentClause_GoodsQuantity,OfficeAutomation_Document_ProjAgentClause_GoodsValue,OfficeAutomation_Document_ProjAgentClause_PreComm,OfficeAutomation_Document_ProjAgentClause_AgentModel,OfficeAutomation_Document_ProjAgentClause_PorjectExam,OfficeAutomation_Document_ProjAgentClause_CommPoint,OfficeAutomation_Document_ProjAgentClause_ContractType,OfficeAutomation_Document_ProjAgentClause_ContractTypeOther,OfficeAutomation_Document_ProjAgentClause_Remark,OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm,OfficeAutomation_Document_ProjAgentClause_ClauseFine,OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit,OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck,OfficeAutomation_Document_ProjAgentClause_ClauseHonest,OfficeAutomation_Document_ProjAgentClause_JOrT,OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1,OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2,OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1,OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2,OfficeAutomation_Document_ProjAgentClause_AgencyFee1,OfficeAutomation_Document_ProjAgentClause_AgencyFee2,OfficeAutomation_Document_ProjAgentClause_AgencyFee3,OfficeAutomation_Document_ProjAgentClause_AgencyFee4,OfficeAutomation_Document_ProjAgentClause_IsCashPrize1,OfficeAutomation_Document_ProjAgentClause_IsCashPrize2,OfficeAutomation_Document_ProjAgentClause_IsCashPrize3,OfficeAutomation_Document_ProjAgentClause_IsCashPrize4,OfficeAutomation_Document_ProjAgentClause_CashPrize1,OfficeAutomation_Document_ProjAgentClause_CashPrize2,OfficeAutomation_Document_ProjAgentClause_CashPrize3,OfficeAutomation_Document_ProjAgentClause_CashPrize4,OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1,OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2,OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1,OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2,OfficeAutomation_Document_ProjAgentClause_IsPFear1,OfficeAutomation_Document_ProjAgentClause_IsPFear2,OfficeAutomation_Document_ProjAgentClause_IsPFear3,OfficeAutomation_Document_ProjAgentClause_IsPFear4,OfficeAutomation_Document_ProjAgentClause_PFear1,OfficeAutomation_Document_ProjAgentClause_PFear2,OfficeAutomation_Document_ProjAgentClause_PFear3,OfficeAutomation_Document_ProjAgentClause_PFear4,OfficeAutomation_Document_ProjAgentClause_ClauseOther,OfficeAutomation_Document_ProjAgentClause_Sign ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjAgentClause ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ProjAgentClause ");
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
				strSql.Append("order by T.OfficeAutomation_Document_ProjAgentClause_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ProjAgentClause T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_ProjAgentClause";
			parameters[1].Value = "OfficeAutomation_Document_ProjAgentClause_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public T_OfficeAutomation_Document_ProjAgentClause Insert(T_OfficeAutomation_Document_ProjAgentClause t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_ProjAgentClause Edit(T_OfficeAutomation_Document_ProjAgentClause t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_ProjAgentClause t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_ProjAgentClause GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_ProjAgentClause>(where);
        }
		#endregion  ExtensionMethod
	}
}

