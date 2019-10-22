/*
* DA_OfficeAutomation_Document_ProjLinkRepoData_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ProjLinkRepoData_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/6/4 10:00:02    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_ProjLinkRepoData_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_ProjLinkRepoData_Operate
	{
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData> dal;

		public DA_OfficeAutomation_Document_ProjLinkRepoData_Operate()
		{
            dal = new DAL.DalBase<T_OfficeAutomation_Document_ProjLinkRepoData>();
        }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ProjLinkRepoData_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ProjLinkRepoData");
			strSql.Append(" where OfficeAutomation_Document_ProjLinkRepoData_ID=@OfficeAutomation_Document_ProjLinkRepoData_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjLinkRepoData_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_OfficeAutomation_Document_ProjLinkRepoData(");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ID,OfficeAutomation_Document_ProjLinkRepoData_MainID,OfficeAutomation_Document_ProjLinkRepoData_Department,OfficeAutomation_Document_ProjLinkRepoData_ApplyDate,OfficeAutomation_Document_ProjLinkRepoData_Apply,OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone,OfficeAutomation_Document_ProjLinkRepoData_ApplyID,OfficeAutomation_Document_ProjLinkRepoData_ProjName,OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID,OfficeAutomation_Document_ProjLinkRepoData_PreSaleID,OfficeAutomation_Document_ProjLinkRepoData_ProjAddress,OfficeAutomation_Document_ProjLinkRepoData_DeveloperName,OfficeAutomation_Document_ProjLinkRepoData_GroupName,OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs,OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther,OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate,OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate,OfficeAutomation_Document_ProjLinkRepoData_PreComm,OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity,OfficeAutomation_Document_ProjLinkRepoData_GoodsValue,OfficeAutomation_Document_ProjLinkRepoData_CommPoint,OfficeAutomation_Document_ProjLinkRepoData_AgentModel,OfficeAutomation_Document_ProjLinkRepoData_ContractType,OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther,OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost,OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf,OfficeAutomation_Document_ProjLinkRepoData_IsSignBack,OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate,OfficeAutomation_Document_ProjLinkRepoData_Remark,OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate,OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate,OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet,OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice,OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm,OfficeAutomation_Document_ProjLinkRepoData_PropDepCount,OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice,OfficeAutomation_Document_ProjLinkRepoData_PropDepComm,OfficeAutomation_Document_ProjLinkRepoData_CalcGetType,OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther,OfficeAutomation_Document_ProjLinkRepoData_AssumeType,OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther,OfficeAutomation_Document_ProjLinkRepoData_AddRemark,OfficeAutomation_Document_ProjLinkRepoData_ProjType,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm,OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo,OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate,OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate,OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate,OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate,OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount,OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance,OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount,OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance,OfficeAutomation_Document_ProjLinkRepoData_JOrT,OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1,OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2,OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1,OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4,OfficeAutomation_Document_ProjLinkRepoData_CashPrize1,OfficeAutomation_Document_ProjLinkRepoData_CashPrize2,OfficeAutomation_Document_ProjLinkRepoData_CashPrize3,OfficeAutomation_Document_ProjLinkRepoData_CashPrize4,OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1,OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2,OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1,OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2,OfficeAutomation_Document_ProjLinkRepoData_IsPFear1,OfficeAutomation_Document_ProjLinkRepoData_IsPFear2,OfficeAutomation_Document_ProjLinkRepoData_IsPFear3,OfficeAutomation_Document_ProjLinkRepoData_IsPFear4,OfficeAutomation_Document_ProjLinkRepoData_PFear1,OfficeAutomation_Document_ProjLinkRepoData_PFear2,OfficeAutomation_Document_ProjLinkRepoData_PFear3,OfficeAutomation_Document_ProjLinkRepoData_PFear4,OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit,OfficeAutomation_Document_ProjLinkRepoData_Sign)");
            strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ProjLinkRepoData_ID,@OfficeAutomation_Document_ProjLinkRepoData_MainID,@OfficeAutomation_Document_ProjLinkRepoData_Department,@OfficeAutomation_Document_ProjLinkRepoData_ApplyDate,@OfficeAutomation_Document_ProjLinkRepoData_Apply,@OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone,@OfficeAutomation_Document_ProjLinkRepoData_ApplyID,@OfficeAutomation_Document_ProjLinkRepoData_ProjName,@OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID,@OfficeAutomation_Document_ProjLinkRepoData_PreSaleID,@OfficeAutomation_Document_ProjLinkRepoData_ProjAddress,@OfficeAutomation_Document_ProjLinkRepoData_DeveloperName,@OfficeAutomation_Document_ProjLinkRepoData_GroupName,@OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs,@OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther,@OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate,@OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate,@OfficeAutomation_Document_ProjLinkRepoData_PreComm,@OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity,@OfficeAutomation_Document_ProjLinkRepoData_GoodsValue,@OfficeAutomation_Document_ProjLinkRepoData_CommPoint,@OfficeAutomation_Document_ProjLinkRepoData_AgentModel,@OfficeAutomation_Document_ProjLinkRepoData_ContractType,@OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther,@OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost,@OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf,@OfficeAutomation_Document_ProjLinkRepoData_IsSignBack,@OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate,@OfficeAutomation_Document_ProjLinkRepoData_Remark,@OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate,@OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate,@OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet,@OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount,@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice,@OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm,@OfficeAutomation_Document_ProjLinkRepoData_PropDepCount,@OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice,@OfficeAutomation_Document_ProjLinkRepoData_PropDepComm,@OfficeAutomation_Document_ProjLinkRepoData_CalcGetType,@OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther,@OfficeAutomation_Document_ProjLinkRepoData_AssumeType,@OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther,@OfficeAutomation_Document_ProjLinkRepoData_AddRemark,@OfficeAutomation_Document_ProjLinkRepoData_ProjType,@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount,@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm,@OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo,@OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate,@OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate,@OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate,@OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate,@OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount,@OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance,@OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount,@OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance,@OfficeAutomation_Document_ProjLinkRepoData_JOrT,@OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1,@OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2,@OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1,@OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2,@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1,@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2,@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3,@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4,@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1,@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2,@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3,@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4,@OfficeAutomation_Document_ProjLinkRepoData_CashPrize1,@OfficeAutomation_Document_ProjLinkRepoData_CashPrize2,@OfficeAutomation_Document_ProjLinkRepoData_CashPrize3,@OfficeAutomation_Document_ProjLinkRepoData_CashPrize4,@OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1,@OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2,@OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1,@OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2,@OfficeAutomation_Document_ProjLinkRepoData_IsPFear1,@OfficeAutomation_Document_ProjLinkRepoData_IsPFear2,@OfficeAutomation_Document_ProjLinkRepoData_IsPFear3,@OfficeAutomation_Document_ProjLinkRepoData_IsPFear4,@OfficeAutomation_Document_ProjLinkRepoData_PFear1,@OfficeAutomation_Document_ProjLinkRepoData_PFear2,@OfficeAutomation_Document_ProjLinkRepoData_PFear3,@OfficeAutomation_Document_ProjLinkRepoData_PFear4,@OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit,@OfficeAutomation_Document_ProjLinkRepoData_Sign)"); 
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PreSaleID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_GroupName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ContractType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsSignBack", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PropDepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PropDepComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CalcGetType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AssumeType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AddRemark", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PFear4", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_Sign", SqlDbType.NVarChar,80)};
            parameters[0].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ProjLinkRepoData_MainID;
            parameters[2].Value = model.OfficeAutomation_Document_ProjLinkRepoData_Department;
            parameters[3].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ApplyDate;
            parameters[4].Value = model.OfficeAutomation_Document_ProjLinkRepoData_Apply;
            parameters[5].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone;
            parameters[6].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ApplyID;
            parameters[7].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjName;
            parameters[8].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID;
            parameters[9].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PreSaleID;
            parameters[10].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjAddress;
            parameters[11].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DeveloperName;
            parameters[12].Value = model.OfficeAutomation_Document_ProjLinkRepoData_GroupName;
            parameters[13].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs;
            parameters[14].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther;
            parameters[15].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate;
            parameters[16].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate;
            parameters[17].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PreComm;
            parameters[18].Value = model.OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity;
            parameters[19].Value = model.OfficeAutomation_Document_ProjLinkRepoData_GoodsValue;
            parameters[20].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CommPoint;
            parameters[21].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgentModel;
            parameters[22].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ContractType;
            parameters[23].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther;
            parameters[24].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost;
            parameters[25].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf;
            parameters[26].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsSignBack;
            parameters[27].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate;
            parameters[28].Value = model.OfficeAutomation_Document_ProjLinkRepoData_Remark;
            parameters[29].Value = model.OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate;
            parameters[30].Value = model.OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate;
            parameters[31].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet;
            parameters[32].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount;
            parameters[33].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice;
            parameters[34].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm;
            parameters[35].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PropDepCount;
            parameters[36].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice;
            parameters[37].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PropDepComm;
            parameters[38].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetType;
            parameters[39].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther;
            parameters[40].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AssumeType;
            parameters[41].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther;
            parameters[42].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AddRemark;
            parameters[43].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjType;
            parameters[44].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount;
            parameters[45].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm;
            parameters[46].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo;
            parameters[47].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate;
            parameters[48].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate;
            parameters[49].Value = model.OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate;
            parameters[50].Value = model.OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate;
            parameters[51].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount;
            parameters[52].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance;
            parameters[53].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount;
            parameters[54].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance;

            parameters[55].Value = model.OfficeAutomation_Document_ProjLinkRepoData_JOrT;
            parameters[56].Value = model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1;
            parameters[57].Value = model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2;
            parameters[58].Value = model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1;
            parameters[59].Value = model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2;
            parameters[60].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1;
            parameters[61].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2;
            parameters[62].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3;
            parameters[63].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4;
            parameters[64].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1;
            parameters[65].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2;
            parameters[66].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3;
            parameters[67].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4;
            parameters[68].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize1;
            parameters[69].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize2;
            parameters[70].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize3;
            parameters[71].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize4;
            parameters[72].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1;
            parameters[73].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2;
            parameters[74].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1;
            parameters[75].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2;
            parameters[76].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear1;
            parameters[77].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear2;
            parameters[78].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear3;
            parameters[79].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear4;
            parameters[80].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PFear1;
            parameters[81].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PFear2;
            parameters[82].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PFear3;
            parameters[83].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PFear4;

            parameters[84].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit;
            parameters[85].Value = model.OfficeAutomation_Document_ProjLinkRepoData_Sign;

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
		public bool Update(DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ProjLinkRepoData set ");
			//strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_MainID=@OfficeAutomation_Document_ProjLinkRepoData_MainID,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_Department=@OfficeAutomation_Document_ProjLinkRepoData_Department,");
			//strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ApplyDate=@OfficeAutomation_Document_ProjLinkRepoData_ApplyDate,");
			//strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_Apply=@OfficeAutomation_Document_ProjLinkRepoData_Apply,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone=@OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ApplyID=@OfficeAutomation_Document_ProjLinkRepoData_ApplyID,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ProjName=@OfficeAutomation_Document_ProjLinkRepoData_ProjName,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID=@OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PreSaleID=@OfficeAutomation_Document_ProjLinkRepoData_PreSaleID,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ProjAddress=@OfficeAutomation_Document_ProjLinkRepoData_ProjAddress,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_DeveloperName=@OfficeAutomation_Document_ProjLinkRepoData_DeveloperName,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_GroupName=@OfficeAutomation_Document_ProjLinkRepoData_GroupName,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs=@OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther=@OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate=@OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate=@OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PreComm=@OfficeAutomation_Document_ProjLinkRepoData_PreComm,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity=@OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_GoodsValue=@OfficeAutomation_Document_ProjLinkRepoData_GoodsValue,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_CommPoint=@OfficeAutomation_Document_ProjLinkRepoData_CommPoint,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgentModel=@OfficeAutomation_Document_ProjLinkRepoData_AgentModel,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ContractType=@OfficeAutomation_Document_ProjLinkRepoData_ContractType,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther=@OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost=@OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf=@OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_IsSignBack=@OfficeAutomation_Document_ProjLinkRepoData_IsSignBack,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate=@OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_Remark=@OfficeAutomation_Document_ProjLinkRepoData_Remark,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate=@OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate=@OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet=@OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount=@OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice=@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm=@OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PropDepCount=@OfficeAutomation_Document_ProjLinkRepoData_PropDepCount,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice=@OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PropDepComm=@OfficeAutomation_Document_ProjLinkRepoData_PropDepComm,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_CalcGetType=@OfficeAutomation_Document_ProjLinkRepoData_CalcGetType,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther=@OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AssumeType=@OfficeAutomation_Document_ProjLinkRepoData_AssumeType,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther=@OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AddRemark=@OfficeAutomation_Document_ProjLinkRepoData_AddRemark,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ProjType=@OfficeAutomation_Document_ProjLinkRepoData_ProjType,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount=@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm=@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo=@OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate=@OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate=@OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate=@OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate=@OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount=@OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance=@OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount=@OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount,");
			strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance=@OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance,");

            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_JOrT=@OfficeAutomation_Document_ProjLinkRepoData_JOrT,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1=@OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2=@OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1=@OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2=@OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1=@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2=@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3=@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4=@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1=@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2=@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3=@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4=@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_CashPrize1=@OfficeAutomation_Document_ProjLinkRepoData_CashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_CashPrize2=@OfficeAutomation_Document_ProjLinkRepoData_CashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_CashPrize3=@OfficeAutomation_Document_ProjLinkRepoData_CashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_CashPrize4=@OfficeAutomation_Document_ProjLinkRepoData_CashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1=@OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2=@OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1=@OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2=@OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_IsPFear1=@OfficeAutomation_Document_ProjLinkRepoData_IsPFear1,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_IsPFear2=@OfficeAutomation_Document_ProjLinkRepoData_IsPFear2,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_IsPFear3=@OfficeAutomation_Document_ProjLinkRepoData_IsPFear3,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_IsPFear4=@OfficeAutomation_Document_ProjLinkRepoData_IsPFear4,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PFear1=@OfficeAutomation_Document_ProjLinkRepoData_PFear1,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PFear2=@OfficeAutomation_Document_ProjLinkRepoData_PFear2,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PFear3=@OfficeAutomation_Document_ProjLinkRepoData_PFear3,");
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_PFear4=@OfficeAutomation_Document_ProjLinkRepoData_PFear4,");
            
            strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit=@OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit");
			//strSql.Append("OfficeAutomation_Document_ProjLinkRepoData_Sign=@OfficeAutomation_Document_ProjLinkRepoData_Sign");
			strSql.Append(" where OfficeAutomation_Document_ProjLinkRepoData_ID=@OfficeAutomation_Document_ProjLinkRepoData_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_Department", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ApplyDate", SqlDbType.DateTime),
					//new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PreSaleID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_GroupName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ContractType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsSignBack", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PropDepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PropDepComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CalcGetType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AssumeType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AddRemark", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_PFear4", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_Sign", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_ProjLinkRepoData_MainID;
			parameters[0].Value = model.OfficeAutomation_Document_ProjLinkRepoData_Department;
			//parameters[2].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ApplyDate;
			//parameters[3].Value = model.OfficeAutomation_Document_ProjLinkRepoData_Apply;
			parameters[1].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone;
			parameters[2].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ApplyID;
			parameters[3].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjName;
			parameters[4].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID;
			parameters[5].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PreSaleID;
			parameters[6].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjAddress;
			parameters[7].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DeveloperName;
			parameters[8].Value = model.OfficeAutomation_Document_ProjLinkRepoData_GroupName;
			parameters[9].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs;
			parameters[10].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther;
			parameters[11].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate;
			parameters[12].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate;
			parameters[13].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PreComm;
			parameters[14].Value = model.OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity;
			parameters[15].Value = model.OfficeAutomation_Document_ProjLinkRepoData_GoodsValue;
			parameters[16].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CommPoint;
			parameters[17].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgentModel;
			parameters[18].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ContractType;
			parameters[19].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther;
			parameters[20].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost;
			parameters[21].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf;
			parameters[22].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsSignBack;
			parameters[23].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate;
			parameters[24].Value = model.OfficeAutomation_Document_ProjLinkRepoData_Remark;
			parameters[25].Value = model.OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate;
			parameters[26].Value = model.OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate;
			parameters[27].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet;
			parameters[28].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount;
			parameters[29].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice;
			parameters[30].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm;
			parameters[31].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PropDepCount;
			parameters[32].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice;
			parameters[33].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PropDepComm;
			parameters[34].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetType;
			parameters[35].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther;
			parameters[36].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AssumeType;
			parameters[37].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther;
			parameters[38].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AddRemark;
			parameters[39].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjType;
			parameters[40].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount;
			parameters[41].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm;
			parameters[42].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo;
			parameters[43].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate;
			parameters[44].Value = model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate;
            parameters[45].Value = model.OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate;
            parameters[46].Value = model.OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate;
            parameters[47].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount;
			parameters[48].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance;
			parameters[49].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount;
			parameters[50].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance;

            parameters[51].Value = model.OfficeAutomation_Document_ProjLinkRepoData_JOrT;
            parameters[52].Value = model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1;
            parameters[53].Value = model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2;
            parameters[54].Value = model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1;
            parameters[55].Value = model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2;
            parameters[56].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1;
            parameters[57].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2;
            parameters[58].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3;
            parameters[59].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4;
            parameters[60].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1;
            parameters[61].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2;
            parameters[62].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3;
            parameters[63].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4;
            parameters[64].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize1;
            parameters[65].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize2;
            parameters[66].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize3;
            parameters[67].Value = model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize4;
            parameters[68].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1;
            parameters[69].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2;
            parameters[70].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1;
            parameters[71].Value = model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2;
            parameters[72].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear1;
            parameters[73].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear2;
            parameters[74].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear3;
            parameters[75].Value = model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear4;
            parameters[76].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PFear1;
            parameters[77].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PFear2;
            parameters[78].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PFear3;
            parameters[79].Value = model.OfficeAutomation_Document_ProjLinkRepoData_PFear4;

			parameters[80].Value = model.OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit;
			//parameters[53].Value = model.OfficeAutomation_Document_ProjLinkRepoData_Sign;
			parameters[81].Value = model.OfficeAutomation_Document_ProjLinkRepoData_ID;

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
		public bool Delete(string OfficeAutomation_Document_ProjLinkRepoData_ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_ProjLinkRepoData_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ProjLinkRepoData_ID);

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
		public bool DeleteList(string OfficeAutomation_Document_ProjLinkRepoData_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ProjLinkRepoData ");
			strSql.Append(" where OfficeAutomation_Document_ProjLinkRepoData_ID in ("+OfficeAutomation_Document_ProjLinkRepoData_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData GetModel(Guid OfficeAutomation_Document_ProjLinkRepoData_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_ProjLinkRepoData_ID,OfficeAutomation_Document_ProjLinkRepoData_MainID,OfficeAutomation_Document_ProjLinkRepoData_Department,OfficeAutomation_Document_ProjLinkRepoData_ApplyDate,OfficeAutomation_Document_ProjLinkRepoData_Apply,OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone,OfficeAutomation_Document_ProjLinkRepoData_ApplyID,OfficeAutomation_Document_ProjLinkRepoData_ProjName,OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID,OfficeAutomation_Document_ProjLinkRepoData_PreSaleID,OfficeAutomation_Document_ProjLinkRepoData_ProjAddress,OfficeAutomation_Document_ProjLinkRepoData_DeveloperName,OfficeAutomation_Document_ProjLinkRepoData_GroupName,OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs,OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther,OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate,OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate,OfficeAutomation_Document_ProjLinkRepoData_PreComm,OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity,OfficeAutomation_Document_ProjLinkRepoData_GoodsValue,OfficeAutomation_Document_ProjLinkRepoData_CommPoint,OfficeAutomation_Document_ProjLinkRepoData_AgentModel,OfficeAutomation_Document_ProjLinkRepoData_ContractType,OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther,OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost,OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf,OfficeAutomation_Document_ProjLinkRepoData_IsSignBack,OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate,OfficeAutomation_Document_ProjLinkRepoData_Remark,OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate,OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate,OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet,OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice,OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm,OfficeAutomation_Document_ProjLinkRepoData_PropDepCount,OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice,OfficeAutomation_Document_ProjLinkRepoData_PropDepComm,OfficeAutomation_Document_ProjLinkRepoData_CalcGetType,OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther,OfficeAutomation_Document_ProjLinkRepoData_AssumeType,OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther,OfficeAutomation_Document_ProjLinkRepoData_AddRemark,OfficeAutomation_Document_ProjLinkRepoData_ProjType,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm,OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo,OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate,OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate,OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount,OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance,OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount,OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance,OfficeAutomation_Document_ProjLinkRepoData_JOrT,OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1,OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2,OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1,OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4,OfficeAutomation_Document_ProjLinkRepoData_CashPrize1,OfficeAutomation_Document_ProjLinkRepoData_CashPrize2,OfficeAutomation_Document_ProjLinkRepoData_CashPrize3,OfficeAutomation_Document_ProjLinkRepoData_CashPrize4,OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1,OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2,OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1,OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2,OfficeAutomation_Document_ProjLinkRepoData_IsPFear1,OfficeAutomation_Document_ProjLinkRepoData_IsPFear2,OfficeAutomation_Document_ProjLinkRepoData_IsPFear3,OfficeAutomation_Document_ProjLinkRepoData_IsPFear4,OfficeAutomation_Document_ProjLinkRepoData_PFear1,OfficeAutomation_Document_ProjLinkRepoData_PFear2,OfficeAutomation_Document_ProjLinkRepoData_PFear3,OfficeAutomation_Document_ProjLinkRepoData_PFear4,OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit,OfficeAutomation_Document_ProjLinkRepoData_Sign from t_OfficeAutomation_Document_ProjLinkRepoData ");
			strSql.Append(" where OfficeAutomation_Document_ProjLinkRepoData_ID=@OfficeAutomation_Document_ProjLinkRepoData_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjLinkRepoData_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjLinkRepoData_ID;

			DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData model=new DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData();
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
		public DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData model=new DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ID"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ID= new Guid(row["OfficeAutomation_Document_ProjLinkRepoData_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_MainID"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_MainID= new Guid(row["OfficeAutomation_Document_ProjLinkRepoData_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_Department"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_Department=row["OfficeAutomation_Document_ProjLinkRepoData_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ApplyDate"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_ApplyDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_Apply"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_Apply=row["OfficeAutomation_Document_ProjLinkRepoData_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone=row["OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ApplyID"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ApplyID=row["OfficeAutomation_Document_ProjLinkRepoData_ApplyID"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ProjName"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ProjName=row["OfficeAutomation_Document_ProjLinkRepoData_ProjName"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID"].ToString()=="1")||(row["OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID=true;
					}
					else
					{
						model.OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID=false;
					}
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_PreSaleID"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_PreSaleID=row["OfficeAutomation_Document_ProjLinkRepoData_PreSaleID"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ProjAddress"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ProjAddress=row["OfficeAutomation_Document_ProjLinkRepoData_ProjAddress"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_DeveloperName"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_DeveloperName=row["OfficeAutomation_Document_ProjLinkRepoData_DeveloperName"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_GroupName"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_GroupName=row["OfficeAutomation_Document_ProjLinkRepoData_GroupName"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs=row["OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther=row["OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate=row["OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate=row["OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_PreComm"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_PreComm=row["OfficeAutomation_Document_ProjLinkRepoData_PreComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity=row["OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_GoodsValue"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_GoodsValue=row["OfficeAutomation_Document_ProjLinkRepoData_GoodsValue"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_CommPoint"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_CommPoint=row["OfficeAutomation_Document_ProjLinkRepoData_CommPoint"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_AgentModel"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_AgentModel"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_AgentModel=int.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_AgentModel"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ContractType"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_ContractType"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ContractType=int.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_ContractType"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther=row["OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost"].ToString()=="1")||(row["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost=true;
					}
					else
					{
						model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost=false;
					}
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf"].ToString()=="1")||(row["OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf=true;
					}
					else
					{
						model.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf=false;
					}
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_IsSignBack"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_IsSignBack"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_ProjLinkRepoData_IsSignBack"].ToString()=="1")||(row["OfficeAutomation_Document_ProjLinkRepoData_IsSignBack"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_ProjLinkRepoData_IsSignBack=true;
					}
					else
					{
						model.OfficeAutomation_Document_ProjLinkRepoData_IsSignBack=false;
					}
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate"]!=null )
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate=row["OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_Remark"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_Remark=row["OfficeAutomation_Document_ProjLinkRepoData_Remark"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate=row["OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate=row["OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet=row["OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount=row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice=row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm=row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_PropDepCount"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_PropDepCount=row["OfficeAutomation_Document_ProjLinkRepoData_PropDepCount"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice=row["OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_PropDepComm"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_PropDepComm=row["OfficeAutomation_Document_ProjLinkRepoData_PropDepComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_CalcGetType"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_CalcGetType"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetType=int.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_CalcGetType"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther=row["OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_AssumeType"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_AssumeType"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_AssumeType=int.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_AssumeType"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther=row["OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_AddRemark"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_AddRemark=row["OfficeAutomation_Document_ProjLinkRepoData_AddRemark"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ProjType"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_ProjType"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ProjType=int.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_ProjType"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount=row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm=row["OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo=row["OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate=DateTime.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate"]!=null && row["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate=DateTime.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount=row["OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance=row["OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount=row["OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance=row["OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance"].ToString();
				}

                if (row["OfficeAutomation_Document_ProjLinkRepoData_JOrT"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_JOrT = int.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_JOrT"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1 = row["OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2 = row["OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1 = row["OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2 = row["OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1 = row["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2 = row["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3 = row["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4 = row["OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1 = bool.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2 = bool.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3 = bool.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4 = bool.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_CashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize1 = row["OfficeAutomation_Document_ProjLinkRepoData_CashPrize1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_CashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize2 = row["OfficeAutomation_Document_ProjLinkRepoData_CashPrize2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_CashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize3 = row["OfficeAutomation_Document_ProjLinkRepoData_CashPrize3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_CashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_CashPrize4 = row["OfficeAutomation_Document_ProjLinkRepoData_CashPrize4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1 = row["OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2 = row["OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1 = row["OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2 = row["OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_IsPFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear1 = bool.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_IsPFear1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_IsPFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear2 = bool.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_IsPFear2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_IsPFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear3 = bool.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_IsPFear3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_IsPFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_IsPFear4 = bool.Parse(row["OfficeAutomation_Document_ProjLinkRepoData_IsPFear4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_PFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_PFear1 = row["OfficeAutomation_Document_ProjLinkRepoData_PFear1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_PFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_PFear2 = row["OfficeAutomation_Document_ProjLinkRepoData_PFear2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_PFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_PFear3 = row["OfficeAutomation_Document_ProjLinkRepoData_PFear3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjLinkRepoData_PFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjLinkRepoData_PFear4 = row["OfficeAutomation_Document_ProjLinkRepoData_PFear4"].ToString();
                }

				if(row["OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit=row["OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjLinkRepoData_Sign"]!=null)
				{
					model.OfficeAutomation_Document_ProjLinkRepoData_Sign=row["OfficeAutomation_Document_ProjLinkRepoData_Sign"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_ProjLinkRepoData_ID,OfficeAutomation_Document_ProjLinkRepoData_MainID,OfficeAutomation_Document_ProjLinkRepoData_Department,OfficeAutomation_Document_ProjLinkRepoData_ApplyDate,OfficeAutomation_Document_ProjLinkRepoData_Apply,OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone,OfficeAutomation_Document_ProjLinkRepoData_ApplyID,OfficeAutomation_Document_ProjLinkRepoData_ProjName,OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID,OfficeAutomation_Document_ProjLinkRepoData_PreSaleID,OfficeAutomation_Document_ProjLinkRepoData_ProjAddress,OfficeAutomation_Document_ProjLinkRepoData_DeveloperName,OfficeAutomation_Document_ProjLinkRepoData_GroupName,OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs,OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther,OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate,OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate,OfficeAutomation_Document_ProjLinkRepoData_PreComm,OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity,OfficeAutomation_Document_ProjLinkRepoData_GoodsValue,OfficeAutomation_Document_ProjLinkRepoData_CommPoint,OfficeAutomation_Document_ProjLinkRepoData_AgentModel,OfficeAutomation_Document_ProjLinkRepoData_ContractType,OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther,OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost,OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf,OfficeAutomation_Document_ProjLinkRepoData_IsSignBack,OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate,OfficeAutomation_Document_ProjLinkRepoData_Remark,OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate,OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate,OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet,OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice,OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm,OfficeAutomation_Document_ProjLinkRepoData_PropDepCount,OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice,OfficeAutomation_Document_ProjLinkRepoData_PropDepComm,OfficeAutomation_Document_ProjLinkRepoData_CalcGetType,OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther,OfficeAutomation_Document_ProjLinkRepoData_AssumeType,OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther,OfficeAutomation_Document_ProjLinkRepoData_AddRemark,OfficeAutomation_Document_ProjLinkRepoData_ProjType,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm,OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo,OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate,OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate,OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount,OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance,OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount,OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance,OfficeAutomation_Document_ProjLinkRepoData_JOrT,OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1,OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2,OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1,OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4,OfficeAutomation_Document_ProjLinkRepoData_CashPrize1,OfficeAutomation_Document_ProjLinkRepoData_CashPrize2,OfficeAutomation_Document_ProjLinkRepoData_CashPrize3,OfficeAutomation_Document_ProjLinkRepoData_CashPrize4,OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1,OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2,OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1,OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2,OfficeAutomation_Document_ProjLinkRepoData_IsPFear1,OfficeAutomation_Document_ProjLinkRepoData_IsPFear2,OfficeAutomation_Document_ProjLinkRepoData_IsPFear3,OfficeAutomation_Document_ProjLinkRepoData_IsPFear4,OfficeAutomation_Document_ProjLinkRepoData_PFear1,OfficeAutomation_Document_ProjLinkRepoData_PFear2,OfficeAutomation_Document_ProjLinkRepoData_PFear3,OfficeAutomation_Document_ProjLinkRepoData_PFear4,OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit,OfficeAutomation_Document_ProjLinkRepoData_Sign ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjLinkRepoData ");
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
            strSql.Append(" OfficeAutomation_Document_ProjLinkRepoData_ID,OfficeAutomation_Document_ProjLinkRepoData_MainID,OfficeAutomation_Document_ProjLinkRepoData_Department,OfficeAutomation_Document_ProjLinkRepoData_ApplyDate,OfficeAutomation_Document_ProjLinkRepoData_Apply,OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone,OfficeAutomation_Document_ProjLinkRepoData_ApplyID,OfficeAutomation_Document_ProjLinkRepoData_ProjName,OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID,OfficeAutomation_Document_ProjLinkRepoData_PreSaleID,OfficeAutomation_Document_ProjLinkRepoData_ProjAddress,OfficeAutomation_Document_ProjLinkRepoData_DeveloperName,OfficeAutomation_Document_ProjLinkRepoData_GroupName,OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs,OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther,OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate,OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate,OfficeAutomation_Document_ProjLinkRepoData_PreComm,OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity,OfficeAutomation_Document_ProjLinkRepoData_GoodsValue,OfficeAutomation_Document_ProjLinkRepoData_CommPoint,OfficeAutomation_Document_ProjLinkRepoData_AgentModel,OfficeAutomation_Document_ProjLinkRepoData_ContractType,OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther,OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost,OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf,OfficeAutomation_Document_ProjLinkRepoData_IsSignBack,OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate,OfficeAutomation_Document_ProjLinkRepoData_Remark,OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate,OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate,OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet,OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice,OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm,OfficeAutomation_Document_ProjLinkRepoData_PropDepCount,OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice,OfficeAutomation_Document_ProjLinkRepoData_PropDepComm,OfficeAutomation_Document_ProjLinkRepoData_CalcGetType,OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther,OfficeAutomation_Document_ProjLinkRepoData_AssumeType,OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther,OfficeAutomation_Document_ProjLinkRepoData_AddRemark,OfficeAutomation_Document_ProjLinkRepoData_ProjType,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount,OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm,OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo,OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate,OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate,OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount,OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance,OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount,OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance,OfficeAutomation_Document_ProjLinkRepoData_JOrT,OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1,OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2,OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1,OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3,OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3,OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4,OfficeAutomation_Document_ProjLinkRepoData_CashPrize1,OfficeAutomation_Document_ProjLinkRepoData_CashPrize2,OfficeAutomation_Document_ProjLinkRepoData_CashPrize3,OfficeAutomation_Document_ProjLinkRepoData_CashPrize4,OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1,OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2,OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1,OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2,OfficeAutomation_Document_ProjLinkRepoData_IsPFear1,OfficeAutomation_Document_ProjLinkRepoData_IsPFear2,OfficeAutomation_Document_ProjLinkRepoData_IsPFear3,OfficeAutomation_Document_ProjLinkRepoData_IsPFear4,OfficeAutomation_Document_ProjLinkRepoData_PFear1,OfficeAutomation_Document_ProjLinkRepoData_PFear2,OfficeAutomation_Document_ProjLinkRepoData_PFear3,OfficeAutomation_Document_ProjLinkRepoData_PFear4,OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit,OfficeAutomation_Document_ProjLinkRepoData_Sign ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjLinkRepoData ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ProjLinkRepoData ");
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
				strSql.Append("order by T.OfficeAutomation_Document_ProjLinkRepoData_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ProjLinkRepoData T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_ProjLinkRepoData";
			parameters[1].Value = "OfficeAutomation_Document_ProjLinkRepoData_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod

        #region  ExtensionMethod
        public T_OfficeAutomation_Document_ProjLinkRepoData Insert(T_OfficeAutomation_Document_ProjLinkRepoData t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_ProjLinkRepoData Edit(T_OfficeAutomation_Document_ProjLinkRepoData t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_ProjLinkRepoData t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_ProjLinkRepoData GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_ProjLinkRepoData>(where);
        }
        #endregion  ExtensionMethod
	}
}

