/*
* DA_OfficeAutomation_Document_ProjRepoData_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ProjRepoData_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/29 17:48:26    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_ProjRepoData_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_ProjRepoData_Operate
	{
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_ProjRepoData> dal;
		public DA_OfficeAutomation_Document_ProjRepoData_Operate()
		{
            dal = new DAL.DalBase<T_OfficeAutomation_Document_ProjRepoData>();
        }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ProjRepoData_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ProjRepoData");
			strSql.Append(" where OfficeAutomation_Document_ProjRepoData_ID=@OfficeAutomation_Document_ProjRepoData_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjRepoData_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ProjRepoData model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_OfficeAutomation_Document_ProjRepoData(");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ID,OfficeAutomation_Document_ProjRepoData_MainID,OfficeAutomation_Document_ProjRepoData_Department,OfficeAutomation_Document_ProjRepoData_ApplyDate,OfficeAutomation_Document_ProjRepoData_Apply,OfficeAutomation_Document_ProjRepoData_ReplyPhone,OfficeAutomation_Document_ProjRepoData_ApplyID,OfficeAutomation_Document_ProjRepoData_ApplyType,OfficeAutomation_Document_ProjRepoData_ApplyTypeRate,OfficeAutomation_Document_ProjRepoData_ApplyTypeOther,OfficeAutomation_Document_ProjRepoData_ProjName,OfficeAutomation_Document_ProjRepoData_HavePreSaleID,OfficeAutomation_Document_ProjRepoData_PreSaleID,OfficeAutomation_Document_ProjRepoData_ProjAddress,OfficeAutomation_Document_ProjRepoData_DeveloperName,OfficeAutomation_Document_ProjRepoData_GroupName,OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs,OfficeAutomation_Document_ProjRepoData_DealOfficeOther,OfficeAutomation_Document_ProjRepoData_AgentStartDate,OfficeAutomation_Document_ProjRepoData_AgentEndDate,OfficeAutomation_Document_ProjRepoData_PreComm,OfficeAutomation_Document_ProjRepoData_GoodsQuantity,OfficeAutomation_Document_ProjRepoData_GoodsValue,OfficeAutomation_Document_ProjRepoData_CommPoint,OfficeAutomation_Document_ProjRepoData_AgentModel,OfficeAutomation_Document_ProjRepoData_ContractType,OfficeAutomation_Document_ProjRepoData_ContractTypeOther,OfficeAutomation_Document_ProjRepoData_HaveCoopCost,OfficeAutomation_Document_ProjRepoData_HaveCoopConf,OfficeAutomation_Document_ProjRepoData_IsSignBack,OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate,OfficeAutomation_Document_ProjRepoData_Remark,OfficeAutomation_Document_ProjRepoData_ProjType,OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate,OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate,OfficeAutomation_Document_ProjRepoData_TotalProfitStartDate,OfficeAutomation_Document_ProjRepoData_TotalProfitEndDate,OfficeAutomation_Document_ProjRepoData_IndepCount,OfficeAutomation_Document_ProjRepoData_IndepPerformance,OfficeAutomation_Document_ProjRepoData_LinkCount,OfficeAutomation_Document_ProjRepoData_JOrT,OfficeAutomation_Document_ProjRepoData_SamePlaceXX1,OfficeAutomation_Document_ProjRepoData_SamePlaceXX2,OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1,OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2,OfficeAutomation_Document_ProjRepoData_AgencyFee1,OfficeAutomation_Document_ProjRepoData_AgencyFee2,OfficeAutomation_Document_ProjRepoData_AgencyFee3,OfficeAutomation_Document_ProjRepoData_AgencyFee4,OfficeAutomation_Document_ProjRepoData_IsCashPrize1,OfficeAutomation_Document_ProjRepoData_IsCashPrize2,OfficeAutomation_Document_ProjRepoData_IsCashPrize3,OfficeAutomation_Document_ProjRepoData_IsCashPrize4,OfficeAutomation_Document_ProjRepoData_CashPrize1,OfficeAutomation_Document_ProjRepoData_CashPrize2,OfficeAutomation_Document_ProjRepoData_CashPrize3,OfficeAutomation_Document_ProjRepoData_CashPrize4,OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1,OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2,OfficeAutomation_Document_ProjRepoData_AgencyEndDate1,OfficeAutomation_Document_ProjRepoData_AgencyEndDate2,OfficeAutomation_Document_ProjRepoData_IsPFear1,OfficeAutomation_Document_ProjRepoData_IsPFear2,OfficeAutomation_Document_ProjRepoData_IsPFear3,OfficeAutomation_Document_ProjRepoData_IsPFear4,OfficeAutomation_Document_ProjRepoData_PFear1,OfficeAutomation_Document_ProjRepoData_PFear2,OfficeAutomation_Document_ProjRepoData_PFear3,OfficeAutomation_Document_ProjRepoData_PFear4,OfficeAutomation_Document_ProjRepoData_LinkPerformance,OfficeAutomation_Document_ProjRepoData_TotalProfit,OfficeAutomation_Document_ProjRepoData_Sign)");
            strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ProjRepoData_ID,@OfficeAutomation_Document_ProjRepoData_MainID,@OfficeAutomation_Document_ProjRepoData_Department,@OfficeAutomation_Document_ProjRepoData_ApplyDate,@OfficeAutomation_Document_ProjRepoData_Apply,@OfficeAutomation_Document_ProjRepoData_ReplyPhone,@OfficeAutomation_Document_ProjRepoData_ApplyID,@OfficeAutomation_Document_ProjRepoData_ApplyType,@OfficeAutomation_Document_ProjRepoData_ApplyTypeRate,@OfficeAutomation_Document_ProjRepoData_ApplyTypeOther,@OfficeAutomation_Document_ProjRepoData_ProjName,@OfficeAutomation_Document_ProjRepoData_HavePreSaleID,@OfficeAutomation_Document_ProjRepoData_PreSaleID,@OfficeAutomation_Document_ProjRepoData_ProjAddress,@OfficeAutomation_Document_ProjRepoData_DeveloperName,@OfficeAutomation_Document_ProjRepoData_GroupName,@OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs,@OfficeAutomation_Document_ProjRepoData_DealOfficeOther,@OfficeAutomation_Document_ProjRepoData_AgentStartDate,@OfficeAutomation_Document_ProjRepoData_AgentEndDate,@OfficeAutomation_Document_ProjRepoData_PreComm,@OfficeAutomation_Document_ProjRepoData_GoodsQuantity,@OfficeAutomation_Document_ProjRepoData_GoodsValue,@OfficeAutomation_Document_ProjRepoData_CommPoint,@OfficeAutomation_Document_ProjRepoData_AgentModel,@OfficeAutomation_Document_ProjRepoData_ContractType,@OfficeAutomation_Document_ProjRepoData_ContractTypeOther,@OfficeAutomation_Document_ProjRepoData_HaveCoopCost,@OfficeAutomation_Document_ProjRepoData_HaveCoopConf,@OfficeAutomation_Document_ProjRepoData_IsSignBack,@OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate,@OfficeAutomation_Document_ProjRepoData_Remark,@OfficeAutomation_Document_ProjRepoData_ProjType,@OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate,@OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate,@OfficeAutomation_Document_ProjRepoData_TotalProfitStartDate,@OfficeAutomation_Document_ProjRepoData_TotalProfitEndDate,@OfficeAutomation_Document_ProjRepoData_IndepCount,@OfficeAutomation_Document_ProjRepoData_IndepPerformance,@OfficeAutomation_Document_ProjRepoData_LinkCount,@OfficeAutomation_Document_ProjRepoData_JOrT,@OfficeAutomation_Document_ProjRepoData_SamePlaceXX1,@OfficeAutomation_Document_ProjRepoData_SamePlaceXX2,@OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1,@OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2,@OfficeAutomation_Document_ProjRepoData_AgencyFee1,@OfficeAutomation_Document_ProjRepoData_AgencyFee2,@OfficeAutomation_Document_ProjRepoData_AgencyFee3,@OfficeAutomation_Document_ProjRepoData_AgencyFee4,@OfficeAutomation_Document_ProjRepoData_IsCashPrize1,@OfficeAutomation_Document_ProjRepoData_IsCashPrize2,@OfficeAutomation_Document_ProjRepoData_IsCashPrize3,@OfficeAutomation_Document_ProjRepoData_IsCashPrize4,@OfficeAutomation_Document_ProjRepoData_CashPrize1,@OfficeAutomation_Document_ProjRepoData_CashPrize2,@OfficeAutomation_Document_ProjRepoData_CashPrize3,@OfficeAutomation_Document_ProjRepoData_CashPrize4,@OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1,@OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2,@OfficeAutomation_Document_ProjRepoData_AgencyEndDate1,@OfficeAutomation_Document_ProjRepoData_AgencyEndDate2,@OfficeAutomation_Document_ProjRepoData_IsPFear1,@OfficeAutomation_Document_ProjRepoData_IsPFear2,@OfficeAutomation_Document_ProjRepoData_IsPFear3,@OfficeAutomation_Document_ProjRepoData_IsPFear4,@OfficeAutomation_Document_ProjRepoData_PFear1,@OfficeAutomation_Document_ProjRepoData_PFear2,@OfficeAutomation_Document_ProjRepoData_PFear3,@OfficeAutomation_Document_ProjRepoData_PFear4,@OfficeAutomation_Document_ProjRepoData_LinkPerformance,@OfficeAutomation_Document_ProjRepoData_TotalProfit,@OfficeAutomation_Document_ProjRepoData_Sign)"); 
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyTypeRate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_HavePreSaleID", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PreSaleID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_GroupName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgentStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgentEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ContractType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ContractTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_HaveCoopCost", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_HaveCoopConf", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsSignBack", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ProjType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TotalProfitStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TotalProfitEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IndepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IndepPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_LinkCount", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_ProjRepoData_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PFear4", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_LinkPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TotalProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_Sign", SqlDbType.NVarChar,80)};
            parameters[0].Value = model.OfficeAutomation_Document_ProjRepoData_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ProjRepoData_MainID;
            parameters[2].Value = model.OfficeAutomation_Document_ProjRepoData_Department;
            parameters[3].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyDate;
            parameters[4].Value = model.OfficeAutomation_Document_ProjRepoData_Apply;
            parameters[5].Value = model.OfficeAutomation_Document_ProjRepoData_ReplyPhone;
            parameters[6].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyID;
            parameters[7].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyType;
            parameters[8].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyTypeRate;
            parameters[9].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyTypeOther;
            parameters[10].Value = model.OfficeAutomation_Document_ProjRepoData_ProjName;
            parameters[11].Value = model.OfficeAutomation_Document_ProjRepoData_HavePreSaleID;
            parameters[12].Value = model.OfficeAutomation_Document_ProjRepoData_PreSaleID;
            parameters[13].Value = model.OfficeAutomation_Document_ProjRepoData_ProjAddress;
            parameters[14].Value = model.OfficeAutomation_Document_ProjRepoData_DeveloperName;
            parameters[15].Value = model.OfficeAutomation_Document_ProjRepoData_GroupName;
            parameters[16].Value = model.OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs;
            parameters[17].Value = model.OfficeAutomation_Document_ProjRepoData_DealOfficeOther;
            parameters[18].Value = model.OfficeAutomation_Document_ProjRepoData_AgentStartDate;
            parameters[19].Value = model.OfficeAutomation_Document_ProjRepoData_AgentEndDate;
            parameters[20].Value = model.OfficeAutomation_Document_ProjRepoData_PreComm;
            parameters[21].Value = model.OfficeAutomation_Document_ProjRepoData_GoodsQuantity;
            parameters[22].Value = model.OfficeAutomation_Document_ProjRepoData_GoodsValue;
            parameters[23].Value = model.OfficeAutomation_Document_ProjRepoData_CommPoint;
            parameters[24].Value = model.OfficeAutomation_Document_ProjRepoData_AgentModel;
            parameters[25].Value = model.OfficeAutomation_Document_ProjRepoData_ContractType;
            parameters[26].Value = model.OfficeAutomation_Document_ProjRepoData_ContractTypeOther;
            parameters[27].Value = model.OfficeAutomation_Document_ProjRepoData_HaveCoopCost;
            parameters[28].Value = model.OfficeAutomation_Document_ProjRepoData_HaveCoopConf;
            parameters[29].Value = model.OfficeAutomation_Document_ProjRepoData_IsSignBack;
            parameters[30].Value = model.OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate;
            parameters[31].Value = model.OfficeAutomation_Document_ProjRepoData_Remark;
            parameters[32].Value = model.OfficeAutomation_Document_ProjRepoData_ProjType;
            parameters[33].Value = model.OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate;
            parameters[34].Value = model.OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate;
            parameters[35].Value = model.OfficeAutomation_Document_ProjRepoData_TotalProfitStartDate;
            parameters[36].Value = model.OfficeAutomation_Document_ProjRepoData_TotalProfitEndDate;
            parameters[37].Value = model.OfficeAutomation_Document_ProjRepoData_IndepCount;
            parameters[38].Value = model.OfficeAutomation_Document_ProjRepoData_IndepPerformance;
            parameters[39].Value = model.OfficeAutomation_Document_ProjRepoData_LinkCount;

            parameters[40].Value = model.OfficeAutomation_Document_ProjRepoData_JOrT;
            parameters[41].Value = model.OfficeAutomation_Document_ProjRepoData_SamePlaceXX1;
            parameters[42].Value = model.OfficeAutomation_Document_ProjRepoData_SamePlaceXX2;
            parameters[43].Value = model.OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1;
            parameters[44].Value = model.OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2;
            parameters[45].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyFee1;
            parameters[46].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyFee2;
            parameters[47].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyFee3;
            parameters[48].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyFee4;
            parameters[49].Value = model.OfficeAutomation_Document_ProjRepoData_IsCashPrize1;
            parameters[50].Value = model.OfficeAutomation_Document_ProjRepoData_IsCashPrize2;
            parameters[51].Value = model.OfficeAutomation_Document_ProjRepoData_IsCashPrize3;
            parameters[52].Value = model.OfficeAutomation_Document_ProjRepoData_IsCashPrize4;
            parameters[53].Value = model.OfficeAutomation_Document_ProjRepoData_CashPrize1;
            parameters[54].Value = model.OfficeAutomation_Document_ProjRepoData_CashPrize2;
            parameters[55].Value = model.OfficeAutomation_Document_ProjRepoData_CashPrize3;
            parameters[56].Value = model.OfficeAutomation_Document_ProjRepoData_CashPrize4;
            parameters[57].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1;
            parameters[58].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2;
            parameters[59].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyEndDate1;
            parameters[60].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyEndDate2;
            parameters[61].Value = model.OfficeAutomation_Document_ProjRepoData_IsPFear1;
            parameters[62].Value = model.OfficeAutomation_Document_ProjRepoData_IsPFear2;
            parameters[63].Value = model.OfficeAutomation_Document_ProjRepoData_IsPFear3;
            parameters[64].Value = model.OfficeAutomation_Document_ProjRepoData_IsPFear4;
            parameters[65].Value = model.OfficeAutomation_Document_ProjRepoData_PFear1;
            parameters[66].Value = model.OfficeAutomation_Document_ProjRepoData_PFear2;
            parameters[67].Value = model.OfficeAutomation_Document_ProjRepoData_PFear3;
            parameters[68].Value = model.OfficeAutomation_Document_ProjRepoData_PFear4;

            parameters[69].Value = model.OfficeAutomation_Document_ProjRepoData_LinkPerformance;
            parameters[70].Value = model.OfficeAutomation_Document_ProjRepoData_TotalProfit;
            parameters[71].Value = model.OfficeAutomation_Document_ProjRepoData_Sign;

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
		public bool Update(DataEntity.T_OfficeAutomation_Document_ProjRepoData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ProjRepoData set ");
			//strSql.Append("OfficeAutomation_Document_ProjRepoData_MainID=@OfficeAutomation_Document_ProjRepoData_MainID,");
			strSql.Append("OfficeAutomation_Document_ProjRepoData_Department=@OfficeAutomation_Document_ProjRepoData_Department,");
			//strSql.Append("OfficeAutomation_Document_ProjRepoData_ApplyDate=@OfficeAutomation_Document_ProjRepoData_ApplyDate,");
			//strSql.Append("OfficeAutomation_Document_ProjRepoData_Apply=@OfficeAutomation_Document_ProjRepoData_Apply,");
			strSql.Append("OfficeAutomation_Document_ProjRepoData_ReplyPhone=@OfficeAutomation_Document_ProjRepoData_ReplyPhone,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ApplyID=@OfficeAutomation_Document_ProjRepoData_ApplyID,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ApplyType=@OfficeAutomation_Document_ProjRepoData_ApplyType,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ApplyTypeRate=@OfficeAutomation_Document_ProjRepoData_ApplyTypeRate,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ApplyTypeOther=@OfficeAutomation_Document_ProjRepoData_ApplyTypeOther,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ProjName=@OfficeAutomation_Document_ProjRepoData_ProjName,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_HavePreSaleID=@OfficeAutomation_Document_ProjRepoData_HavePreSaleID,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_PreSaleID=@OfficeAutomation_Document_ProjRepoData_PreSaleID,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ProjAddress=@OfficeAutomation_Document_ProjRepoData_ProjAddress,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_DeveloperName=@OfficeAutomation_Document_ProjRepoData_DeveloperName,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_GroupName=@OfficeAutomation_Document_ProjRepoData_GroupName,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs=@OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_DealOfficeOther=@OfficeAutomation_Document_ProjRepoData_DealOfficeOther,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgentStartDate=@OfficeAutomation_Document_ProjRepoData_AgentStartDate,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgentEndDate=@OfficeAutomation_Document_ProjRepoData_AgentEndDate,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_PreComm=@OfficeAutomation_Document_ProjRepoData_PreComm,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_GoodsQuantity=@OfficeAutomation_Document_ProjRepoData_GoodsQuantity,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_GoodsValue=@OfficeAutomation_Document_ProjRepoData_GoodsValue,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_CommPoint=@OfficeAutomation_Document_ProjRepoData_CommPoint,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgentModel=@OfficeAutomation_Document_ProjRepoData_AgentModel,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ContractType=@OfficeAutomation_Document_ProjRepoData_ContractType,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ContractTypeOther=@OfficeAutomation_Document_ProjRepoData_ContractTypeOther,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_HaveCoopCost=@OfficeAutomation_Document_ProjRepoData_HaveCoopCost,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_HaveCoopConf=@OfficeAutomation_Document_ProjRepoData_HaveCoopConf,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IsSignBack=@OfficeAutomation_Document_ProjRepoData_IsSignBack,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate=@OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_Remark=@OfficeAutomation_Document_ProjRepoData_Remark,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_ProjType=@OfficeAutomation_Document_ProjRepoData_ProjType,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate=@OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate=@OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_TotalProfitStartDate=@OfficeAutomation_Document_ProjRepoData_TotalProfitStartDate,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_TotalProfitEndDate=@OfficeAutomation_Document_ProjRepoData_TotalProfitEndDate,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IndepCount=@OfficeAutomation_Document_ProjRepoData_IndepCount,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IndepPerformance=@OfficeAutomation_Document_ProjRepoData_IndepPerformance,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_LinkCount=@OfficeAutomation_Document_ProjRepoData_LinkCount,");

            strSql.Append("OfficeAutomation_Document_ProjRepoData_JOrT=@OfficeAutomation_Document_ProjRepoData_JOrT,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_SamePlaceXX1=@OfficeAutomation_Document_ProjRepoData_SamePlaceXX1,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_SamePlaceXX2=@OfficeAutomation_Document_ProjRepoData_SamePlaceXX2,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1=@OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2=@OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgencyFee1=@OfficeAutomation_Document_ProjRepoData_AgencyFee1,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgencyFee2=@OfficeAutomation_Document_ProjRepoData_AgencyFee2,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgencyFee3=@OfficeAutomation_Document_ProjRepoData_AgencyFee3,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgencyFee4=@OfficeAutomation_Document_ProjRepoData_AgencyFee4,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IsCashPrize1=@OfficeAutomation_Document_ProjRepoData_IsCashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IsCashPrize2=@OfficeAutomation_Document_ProjRepoData_IsCashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IsCashPrize3=@OfficeAutomation_Document_ProjRepoData_IsCashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IsCashPrize4=@OfficeAutomation_Document_ProjRepoData_IsCashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_CashPrize1=@OfficeAutomation_Document_ProjRepoData_CashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_CashPrize2=@OfficeAutomation_Document_ProjRepoData_CashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_CashPrize3=@OfficeAutomation_Document_ProjRepoData_CashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_CashPrize4=@OfficeAutomation_Document_ProjRepoData_CashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1=@OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2=@OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgencyEndDate1=@OfficeAutomation_Document_ProjRepoData_AgencyEndDate1,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_AgencyEndDate2=@OfficeAutomation_Document_ProjRepoData_AgencyEndDate2,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IsPFear1=@OfficeAutomation_Document_ProjRepoData_IsPFear1,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IsPFear2=@OfficeAutomation_Document_ProjRepoData_IsPFear2,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IsPFear3=@OfficeAutomation_Document_ProjRepoData_IsPFear3,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_IsPFear4=@OfficeAutomation_Document_ProjRepoData_IsPFear4,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_PFear1=@OfficeAutomation_Document_ProjRepoData_PFear1,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_PFear2=@OfficeAutomation_Document_ProjRepoData_PFear2,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_PFear3=@OfficeAutomation_Document_ProjRepoData_PFear3,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_PFear4=@OfficeAutomation_Document_ProjRepoData_PFear4,");

            strSql.Append("OfficeAutomation_Document_ProjRepoData_LinkPerformance=@OfficeAutomation_Document_ProjRepoData_LinkPerformance,");
            strSql.Append("OfficeAutomation_Document_ProjRepoData_TotalProfit=@OfficeAutomation_Document_ProjRepoData_TotalProfit");
			//strSql.Append("OfficeAutomation_Document_ProjRepoData_Sign=@OfficeAutomation_Document_ProjRepoData_Sign");
			strSql.Append(" where OfficeAutomation_Document_ProjRepoData_ID=@OfficeAutomation_Document_ProjRepoData_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ProjRepoData_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_Department", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyDate", SqlDbType.DateTime),
					//new SqlParameter("@OfficeAutomation_Document_ProjRepoData_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyTypeRate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ApplyTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_HavePreSaleID", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PreSaleID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_GroupName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgentStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgentEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ContractType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ContractTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_HaveCoopCost", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_HaveCoopConf", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsSignBack", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ProjType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TotalProfitStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TotalProfitEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IndepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IndepPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_LinkCount", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_ProjRepoData_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_PFear4", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_LinkPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_TotalProfit", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ProjRepoData_Sign", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_ProjRepoData_MainID;
			parameters[0].Value = model.OfficeAutomation_Document_ProjRepoData_Department;
			//parameters[2].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyDate;
			//parameters[3].Value = model.OfficeAutomation_Document_ProjRepoData_Apply;
			parameters[1].Value = model.OfficeAutomation_Document_ProjRepoData_ReplyPhone;
			parameters[2].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyID;
            parameters[3].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyType;
            parameters[4].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyTypeRate;
            parameters[5].Value = model.OfficeAutomation_Document_ProjRepoData_ApplyTypeOther;
			parameters[6].Value = model.OfficeAutomation_Document_ProjRepoData_ProjName;
			parameters[7].Value = model.OfficeAutomation_Document_ProjRepoData_HavePreSaleID;
			parameters[8].Value = model.OfficeAutomation_Document_ProjRepoData_PreSaleID;
			parameters[9].Value = model.OfficeAutomation_Document_ProjRepoData_ProjAddress;
			parameters[10].Value = model.OfficeAutomation_Document_ProjRepoData_DeveloperName;
			parameters[11].Value = model.OfficeAutomation_Document_ProjRepoData_GroupName;
			parameters[12].Value = model.OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs;
			parameters[13].Value = model.OfficeAutomation_Document_ProjRepoData_DealOfficeOther;
			parameters[14].Value = model.OfficeAutomation_Document_ProjRepoData_AgentStartDate;
			parameters[15].Value = model.OfficeAutomation_Document_ProjRepoData_AgentEndDate;
			parameters[16].Value = model.OfficeAutomation_Document_ProjRepoData_PreComm;
			parameters[17].Value = model.OfficeAutomation_Document_ProjRepoData_GoodsQuantity;
			parameters[18].Value = model.OfficeAutomation_Document_ProjRepoData_GoodsValue;
			parameters[19].Value = model.OfficeAutomation_Document_ProjRepoData_CommPoint;
			parameters[20].Value = model.OfficeAutomation_Document_ProjRepoData_AgentModel;
			parameters[21].Value = model.OfficeAutomation_Document_ProjRepoData_ContractType;
			parameters[22].Value = model.OfficeAutomation_Document_ProjRepoData_ContractTypeOther;
			parameters[23].Value = model.OfficeAutomation_Document_ProjRepoData_HaveCoopCost;
			parameters[24].Value = model.OfficeAutomation_Document_ProjRepoData_HaveCoopConf;
			parameters[25].Value = model.OfficeAutomation_Document_ProjRepoData_IsSignBack;
			parameters[26].Value = model.OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate;
			parameters[27].Value = model.OfficeAutomation_Document_ProjRepoData_Remark;
            parameters[28].Value = model.OfficeAutomation_Document_ProjRepoData_ProjType;
			parameters[29].Value = model.OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate;
			parameters[30].Value = model.OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate;
            parameters[31].Value = model.OfficeAutomation_Document_ProjRepoData_TotalProfitStartDate;
            parameters[32].Value = model.OfficeAutomation_Document_ProjRepoData_TotalProfitEndDate;
            parameters[33].Value = model.OfficeAutomation_Document_ProjRepoData_IndepCount;
			parameters[34].Value = model.OfficeAutomation_Document_ProjRepoData_IndepPerformance;
			parameters[35].Value = model.OfficeAutomation_Document_ProjRepoData_LinkCount;

            parameters[36].Value = model.OfficeAutomation_Document_ProjRepoData_JOrT;
            parameters[37].Value = model.OfficeAutomation_Document_ProjRepoData_SamePlaceXX1;
            parameters[38].Value = model.OfficeAutomation_Document_ProjRepoData_SamePlaceXX2;
            parameters[39].Value = model.OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1;
            parameters[40].Value = model.OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2;
            parameters[41].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyFee1;
            parameters[42].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyFee2;
            parameters[43].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyFee3;
            parameters[44].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyFee4;
            parameters[45].Value = model.OfficeAutomation_Document_ProjRepoData_IsCashPrize1;
            parameters[46].Value = model.OfficeAutomation_Document_ProjRepoData_IsCashPrize2;
            parameters[47].Value = model.OfficeAutomation_Document_ProjRepoData_IsCashPrize3;
            parameters[48].Value = model.OfficeAutomation_Document_ProjRepoData_IsCashPrize4;
            parameters[49].Value = model.OfficeAutomation_Document_ProjRepoData_CashPrize1;
            parameters[50].Value = model.OfficeAutomation_Document_ProjRepoData_CashPrize2;
            parameters[51].Value = model.OfficeAutomation_Document_ProjRepoData_CashPrize3;
            parameters[52].Value = model.OfficeAutomation_Document_ProjRepoData_CashPrize4;
            parameters[53].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1;
            parameters[54].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2;
            parameters[55].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyEndDate1;
            parameters[56].Value = model.OfficeAutomation_Document_ProjRepoData_AgencyEndDate2;
            parameters[57].Value = model.OfficeAutomation_Document_ProjRepoData_IsPFear1;
            parameters[58].Value = model.OfficeAutomation_Document_ProjRepoData_IsPFear2;
            parameters[59].Value = model.OfficeAutomation_Document_ProjRepoData_IsPFear3;
            parameters[60].Value = model.OfficeAutomation_Document_ProjRepoData_IsPFear4;
            parameters[61].Value = model.OfficeAutomation_Document_ProjRepoData_PFear1;
            parameters[62].Value = model.OfficeAutomation_Document_ProjRepoData_PFear2;
            parameters[63].Value = model.OfficeAutomation_Document_ProjRepoData_PFear3;
            parameters[64].Value = model.OfficeAutomation_Document_ProjRepoData_PFear4;

			parameters[65].Value = model.OfficeAutomation_Document_ProjRepoData_LinkPerformance;
			parameters[66].Value = model.OfficeAutomation_Document_ProjRepoData_TotalProfit;
			//parameters[35].Value = model.OfficeAutomation_Document_ProjRepoData_Sign;
			parameters[67].Value = model.OfficeAutomation_Document_ProjRepoData_ID;

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
		public bool Delete(string OfficeAutomation_Document_ProjRepoData_ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_ProjRepoData_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ProjRepoData_ID);

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
		public bool DeleteList(string OfficeAutomation_Document_ProjRepoData_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ProjRepoData ");
			strSql.Append(" where OfficeAutomation_Document_ProjRepoData_ID in ("+OfficeAutomation_Document_ProjRepoData_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_ProjRepoData GetModel(Guid OfficeAutomation_Document_ProjRepoData_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_ProjRepoData_ID,OfficeAutomation_Document_ProjRepoData_MainID,OfficeAutomation_Document_ProjRepoData_Department,OfficeAutomation_Document_ProjRepoData_ApplyDate,OfficeAutomation_Document_ProjRepoData_Apply,OfficeAutomation_Document_ProjRepoData_ReplyPhone,OfficeAutomation_Document_ProjRepoData_ApplyID,OfficeAutomation_Document_ProjRepoData_ApplyType,OfficeAutomation_Document_ProjRepoData_ApplyTypeRate,OfficeAutomation_Document_ProjRepoData_ApplyTypeOther,OfficeAutomation_Document_ProjRepoData_ProjName,OfficeAutomation_Document_ProjRepoData_HavePreSaleID,OfficeAutomation_Document_ProjRepoData_PreSaleID,OfficeAutomation_Document_ProjRepoData_ProjAddress,OfficeAutomation_Document_ProjRepoData_DeveloperName,OfficeAutomation_Document_ProjRepoData_GroupName,OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs,OfficeAutomation_Document_ProjRepoData_DealOfficeOther,OfficeAutomation_Document_ProjRepoData_AgentStartDate,OfficeAutomation_Document_ProjRepoData_AgentEndDate,OfficeAutomation_Document_ProjRepoData_PreComm,OfficeAutomation_Document_ProjRepoData_GoodsQuantity,OfficeAutomation_Document_ProjRepoData_GoodsValue,OfficeAutomation_Document_ProjRepoData_CommPoint,OfficeAutomation_Document_ProjRepoData_AgentModel,OfficeAutomation_Document_ProjRepoData_ContractType,OfficeAutomation_Document_ProjRepoData_ContractTypeOther,OfficeAutomation_Document_ProjRepoData_HaveCoopCost,OfficeAutomation_Document_ProjRepoData_HaveCoopConf,OfficeAutomation_Document_ProjRepoData_IsSignBack,OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate,OfficeAutomation_Document_ProjRepoData_Remark,OfficeAutomation_Document_ProjRepoData_ProjType,OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate,OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate,OfficeAutomation_Document_ProjRepoData_IndepCount,OfficeAutomation_Document_ProjRepoData_IndepPerformance,OfficeAutomation_Document_ProjRepoData_LinkCount,OfficeAutomation_Document_ProjRepoData_JOrT,OfficeAutomation_Document_ProjRepoData_SamePlaceXX1,OfficeAutomation_Document_ProjRepoData_SamePlaceXX2,OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1,OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2,OfficeAutomation_Document_ProjRepoData_AgencyFee1,OfficeAutomation_Document_ProjRepoData_AgencyFee2,OfficeAutomation_Document_ProjRepoData_AgencyFee3,OfficeAutomation_Document_ProjRepoData_AgencyFee4,OfficeAutomation_Document_ProjRepoData_IsCashPrize1,OfficeAutomation_Document_ProjRepoData_IsCashPrize2,OfficeAutomation_Document_ProjRepoData_IsCashPrize3,OfficeAutomation_Document_ProjRepoData_IsCashPrize4,OfficeAutomation_Document_ProjRepoData_CashPrize1,OfficeAutomation_Document_ProjRepoData_CashPrize2,OfficeAutomation_Document_ProjRepoData_CashPrize3,OfficeAutomation_Document_ProjRepoData_CashPrize4,OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1,OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2,OfficeAutomation_Document_ProjRepoData_AgencyEndDate1,OfficeAutomation_Document_ProjRepoData_AgencyEndDate2,OfficeAutomation_Document_ProjRepoData_IsPFear1,OfficeAutomation_Document_ProjRepoData_IsPFear2,OfficeAutomation_Document_ProjRepoData_IsPFear3,OfficeAutomation_Document_ProjRepoData_IsPFear4,OfficeAutomation_Document_ProjRepoData_PFear1,OfficeAutomation_Document_ProjRepoData_PFear2,OfficeAutomation_Document_ProjRepoData_PFear3,OfficeAutomation_Document_ProjRepoData_PFear4,OfficeAutomation_Document_ProjRepoData_LinkPerformance,OfficeAutomation_Document_ProjRepoData_TotalProfit,OfficeAutomation_Document_ProjRepoData_Sign from t_OfficeAutomation_Document_ProjRepoData "); 
			strSql.Append(" where OfficeAutomation_Document_ProjRepoData_ID=@OfficeAutomation_Document_ProjRepoData_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjRepoData_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjRepoData_ID;

			DataEntity.T_OfficeAutomation_Document_ProjRepoData model=new DataEntity.T_OfficeAutomation_Document_ProjRepoData();
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
		public DataEntity.T_OfficeAutomation_Document_ProjRepoData DataRowToModel(DataRow row)
		{
            DataEntity.T_OfficeAutomation_Document_ProjRepoData model = new DataEntity.T_OfficeAutomation_Document_ProjRepoData();
            if (row != null)
            {
                if (row["OfficeAutomation_Document_ProjRepoData_ID"] != null && row["OfficeAutomation_Document_ProjRepoData_ID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjRepoData_ID = new Guid(row["OfficeAutomation_Document_ProjRepoData_ID"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_MainID"] != null && row["OfficeAutomation_Document_ProjRepoData_MainID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjRepoData_MainID = new Guid(row["OfficeAutomation_Document_ProjRepoData_MainID"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_Department"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_Department = row["OfficeAutomation_Document_ProjRepoData_Department"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ApplyDate"] != null && row["OfficeAutomation_Document_ProjRepoData_ApplyDate"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjRepoData_ApplyDate = DateTime.Parse(row["OfficeAutomation_Document_ProjRepoData_ApplyDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_Apply"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_Apply = row["OfficeAutomation_Document_ProjRepoData_Apply"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ReplyPhone"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_ReplyPhone = row["OfficeAutomation_Document_ProjRepoData_ReplyPhone"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ApplyID"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_ApplyID = row["OfficeAutomation_Document_ProjRepoData_ApplyID"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ApplyType"] != null && row["OfficeAutomation_Document_ProjRepoData_ApplyType"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjRepoData_ApplyType = int.Parse(row["OfficeAutomation_Document_ProjRepoData_ApplyType"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ApplyTypeRate"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_ApplyTypeRate = row["OfficeAutomation_Document_ProjRepoData_ApplyTypeRate"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ApplyTypeOther"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_ApplyTypeOther = row["OfficeAutomation_Document_ProjRepoData_ApplyTypeOther"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ProjName"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_ProjName = row["OfficeAutomation_Document_ProjRepoData_ProjName"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_HavePreSaleID"] != null && row["OfficeAutomation_Document_ProjRepoData_HavePreSaleID"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_ProjRepoData_HavePreSaleID"].ToString() == "1") || (row["OfficeAutomation_Document_ProjRepoData_HavePreSaleID"].ToString().ToLower() == "true"))
                    {
                        model.OfficeAutomation_Document_ProjRepoData_HavePreSaleID = true;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_ProjRepoData_HavePreSaleID = false;
                    }
                }
                if (row["OfficeAutomation_Document_ProjRepoData_PreSaleID"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_PreSaleID = row["OfficeAutomation_Document_ProjRepoData_PreSaleID"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ProjAddress"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_ProjAddress = row["OfficeAutomation_Document_ProjRepoData_ProjAddress"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_DeveloperName"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_DeveloperName = row["OfficeAutomation_Document_ProjRepoData_DeveloperName"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_GroupName"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_GroupName = row["OfficeAutomation_Document_ProjRepoData_GroupName"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs = row["OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_DealOfficeOther"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_DealOfficeOther = row["OfficeAutomation_Document_ProjRepoData_DealOfficeOther"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgentStartDate"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgentStartDate = row["OfficeAutomation_Document_ProjRepoData_AgentStartDate"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgentEndDate"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgentEndDate = row["OfficeAutomation_Document_ProjRepoData_AgentEndDate"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_PreComm"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_PreComm = row["OfficeAutomation_Document_ProjRepoData_PreComm"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_GoodsQuantity"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_GoodsQuantity = row["OfficeAutomation_Document_ProjRepoData_GoodsQuantity"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_GoodsValue"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_GoodsValue = row["OfficeAutomation_Document_ProjRepoData_GoodsValue"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_CommPoint"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_CommPoint = row["OfficeAutomation_Document_ProjRepoData_CommPoint"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgentModel"] != null && row["OfficeAutomation_Document_ProjRepoData_AgentModel"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgentModel = int.Parse(row["OfficeAutomation_Document_ProjRepoData_AgentModel"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ContractType"] != null && row["OfficeAutomation_Document_ProjRepoData_ContractType"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjRepoData_ContractType = int.Parse(row["OfficeAutomation_Document_ProjRepoData_ContractType"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ContractTypeOther"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_ContractTypeOther = row["OfficeAutomation_Document_ProjRepoData_ContractTypeOther"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_HaveCoopCost"] != null && row["OfficeAutomation_Document_ProjRepoData_HaveCoopCost"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_ProjRepoData_HaveCoopCost"].ToString() == "1") || (row["OfficeAutomation_Document_ProjRepoData_HaveCoopCost"].ToString().ToLower() == "true"))
                    {
                        model.OfficeAutomation_Document_ProjRepoData_HaveCoopCost = true;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_ProjRepoData_HaveCoopCost = false;
                    }
                }
                if (row["OfficeAutomation_Document_ProjRepoData_HaveCoopConf"] != null && row["OfficeAutomation_Document_ProjRepoData_HaveCoopConf"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_ProjRepoData_HaveCoopConf"].ToString() == "1") || (row["OfficeAutomation_Document_ProjRepoData_HaveCoopConf"].ToString().ToLower() == "true"))
                    {
                        model.OfficeAutomation_Document_ProjRepoData_HaveCoopConf = true;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_ProjRepoData_HaveCoopConf = false;
                    }
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IsSignBack"] != null && row["OfficeAutomation_Document_ProjRepoData_IsSignBack"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_ProjRepoData_IsSignBack"].ToString() == "1") || (row["OfficeAutomation_Document_ProjRepoData_IsSignBack"].ToString().ToLower() == "true"))
                    {
                        model.OfficeAutomation_Document_ProjRepoData_IsSignBack = true;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_ProjRepoData_IsSignBack = false;
                    }
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate = row["OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_Remark"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_Remark = row["OfficeAutomation_Document_ProjRepoData_Remark"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_ProjType"] != null && row["OfficeAutomation_Document_ProjRepoData_ProjType"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjRepoData_ProjType = int.Parse(row["OfficeAutomation_Document_ProjRepoData_ProjType"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate"] != null && row["OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate = DateTime.Parse(row["OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate"] != null && row["OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate = DateTime.Parse(row["OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IndepCount"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IndepCount = row["OfficeAutomation_Document_ProjRepoData_IndepCount"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IndepPerformance"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IndepPerformance = row["OfficeAutomation_Document_ProjRepoData_IndepPerformance"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_LinkCount"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_LinkCount = row["OfficeAutomation_Document_ProjRepoData_LinkCount"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_JOrT"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_JOrT = int.Parse(row["OfficeAutomation_Document_ProjRepoData_JOrT"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_SamePlaceXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_SamePlaceXX1 = row["OfficeAutomation_Document_ProjRepoData_SamePlaceXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_SamePlaceXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_SamePlaceXX2 = row["OfficeAutomation_Document_ProjRepoData_SamePlaceXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1 = row["OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2 = row["OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgencyFee1"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgencyFee1 = row["OfficeAutomation_Document_ProjRepoData_AgencyFee1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgencyFee2"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgencyFee2 = row["OfficeAutomation_Document_ProjRepoData_AgencyFee2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgencyFee3"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgencyFee3 = row["OfficeAutomation_Document_ProjRepoData_AgencyFee3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgencyFee4"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgencyFee4 = row["OfficeAutomation_Document_ProjRepoData_AgencyFee4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IsCashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IsCashPrize1 = bool.Parse(row["OfficeAutomation_Document_ProjRepoData_IsCashPrize1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IsCashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IsCashPrize2 = bool.Parse(row["OfficeAutomation_Document_ProjRepoData_IsCashPrize2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IsCashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IsCashPrize3 = bool.Parse(row["OfficeAutomation_Document_ProjRepoData_IsCashPrize3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IsCashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IsCashPrize4 = bool.Parse(row["OfficeAutomation_Document_ProjRepoData_IsCashPrize4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_CashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_CashPrize1 = row["OfficeAutomation_Document_ProjRepoData_CashPrize1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_CashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_CashPrize2 = row["OfficeAutomation_Document_ProjRepoData_CashPrize2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_CashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_CashPrize3 = row["OfficeAutomation_Document_ProjRepoData_CashPrize3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_CashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_CashPrize4 = row["OfficeAutomation_Document_ProjRepoData_CashPrize4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1 = row["OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2 = row["OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgencyEndDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgencyEndDate1 = row["OfficeAutomation_Document_ProjRepoData_AgencyEndDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_AgencyEndDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_AgencyEndDate2 = row["OfficeAutomation_Document_ProjRepoData_AgencyEndDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IsPFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IsPFear1 = bool.Parse(row["OfficeAutomation_Document_ProjRepoData_IsPFear1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IsPFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IsPFear2 = bool.Parse(row["OfficeAutomation_Document_ProjRepoData_IsPFear2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IsPFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IsPFear3 = bool.Parse(row["OfficeAutomation_Document_ProjRepoData_IsPFear3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_IsPFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_IsPFear4 = bool.Parse(row["OfficeAutomation_Document_ProjRepoData_IsPFear4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjRepoData_PFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_PFear1 = row["OfficeAutomation_Document_ProjRepoData_PFear1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_PFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_PFear2 = row["OfficeAutomation_Document_ProjRepoData_PFear2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_PFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_PFear3 = row["OfficeAutomation_Document_ProjRepoData_PFear3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_PFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_PFear4 = row["OfficeAutomation_Document_ProjRepoData_PFear4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_LinkPerformance"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_LinkPerformance = row["OfficeAutomation_Document_ProjRepoData_LinkPerformance"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_TotalProfit"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_TotalProfit = row["OfficeAutomation_Document_ProjRepoData_TotalProfit"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjRepoData_Sign"] != null)
                {
                    model.OfficeAutomation_Document_ProjRepoData_Sign = row["OfficeAutomation_Document_ProjRepoData_Sign"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_ProjRepoData_ID,OfficeAutomation_Document_ProjRepoData_MainID,OfficeAutomation_Document_ProjRepoData_Department,OfficeAutomation_Document_ProjRepoData_ApplyDate,OfficeAutomation_Document_ProjRepoData_Apply,OfficeAutomation_Document_ProjRepoData_ReplyPhone,OfficeAutomation_Document_ProjRepoData_ApplyID,OfficeAutomation_Document_ProjRepoData_ApplyType,OfficeAutomation_Document_ProjRepoData_ApplyTypeRate,OfficeAutomation_Document_ProjRepoData_ApplyTypeOther,OfficeAutomation_Document_ProjRepoData_ProjName,OfficeAutomation_Document_ProjRepoData_HavePreSaleID,OfficeAutomation_Document_ProjRepoData_PreSaleID,OfficeAutomation_Document_ProjRepoData_ProjAddress,OfficeAutomation_Document_ProjRepoData_DeveloperName,OfficeAutomation_Document_ProjRepoData_GroupName,OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs,OfficeAutomation_Document_ProjRepoData_DealOfficeOther,OfficeAutomation_Document_ProjRepoData_AgentStartDate,OfficeAutomation_Document_ProjRepoData_AgentEndDate,OfficeAutomation_Document_ProjRepoData_PreComm,OfficeAutomation_Document_ProjRepoData_GoodsQuantity,OfficeAutomation_Document_ProjRepoData_GoodsValue,OfficeAutomation_Document_ProjRepoData_CommPoint,OfficeAutomation_Document_ProjRepoData_AgentModel,OfficeAutomation_Document_ProjRepoData_ContractType,OfficeAutomation_Document_ProjRepoData_ContractTypeOther,OfficeAutomation_Document_ProjRepoData_HaveCoopCost,OfficeAutomation_Document_ProjRepoData_HaveCoopConf,OfficeAutomation_Document_ProjRepoData_IsSignBack,OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate,OfficeAutomation_Document_ProjRepoData_Remark,OfficeAutomation_Document_ProjRepoData_ProjType,OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate,OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate,OfficeAutomation_Document_ProjRepoData_IndepCount,OfficeAutomation_Document_ProjRepoData_IndepPerformance,OfficeAutomation_Document_ProjRepoData_LinkCount,OfficeAutomation_Document_ProjRepoData_JOrT,OfficeAutomation_Document_ProjRepoData_SamePlaceXX1,OfficeAutomation_Document_ProjRepoData_SamePlaceXX2,OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1,OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2,OfficeAutomation_Document_ProjRepoData_AgencyFee1,OfficeAutomation_Document_ProjRepoData_AgencyFee2,OfficeAutomation_Document_ProjRepoData_AgencyFee3,OfficeAutomation_Document_ProjRepoData_AgencyFee4,OfficeAutomation_Document_ProjRepoData_IsCashPrize1,OfficeAutomation_Document_ProjRepoData_IsCashPrize2,OfficeAutomation_Document_ProjRepoData_IsCashPrize3,OfficeAutomation_Document_ProjRepoData_IsCashPrize4,OfficeAutomation_Document_ProjRepoData_CashPrize1,OfficeAutomation_Document_ProjRepoData_CashPrize2,OfficeAutomation_Document_ProjRepoData_CashPrize3,OfficeAutomation_Document_ProjRepoData_CashPrize4,OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1,OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2,OfficeAutomation_Document_ProjRepoData_AgencyEndDate1,OfficeAutomation_Document_ProjRepoData_AgencyEndDate2,OfficeAutomation_Document_ProjRepoData_IsPFear1,OfficeAutomation_Document_ProjRepoData_IsPFear2,OfficeAutomation_Document_ProjRepoData_IsPFear3,OfficeAutomation_Document_ProjRepoData_IsPFear4,OfficeAutomation_Document_ProjRepoData_PFear1,OfficeAutomation_Document_ProjRepoData_PFear2,OfficeAutomation_Document_ProjRepoData_PFear3,OfficeAutomation_Document_ProjRepoData_PFear4,OfficeAutomation_Document_ProjRepoData_LinkPerformance,OfficeAutomation_Document_ProjRepoData_TotalProfit,OfficeAutomation_Document_ProjRepoData_Sign "); 
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjRepoData ");
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
            strSql.Append(" OfficeAutomation_Document_ProjRepoData_ID,OfficeAutomation_Document_ProjRepoData_MainID,OfficeAutomation_Document_ProjRepoData_Department,OfficeAutomation_Document_ProjRepoData_ApplyDate,OfficeAutomation_Document_ProjRepoData_Apply,OfficeAutomation_Document_ProjRepoData_ReplyPhone,OfficeAutomation_Document_ProjRepoData_ApplyID,OfficeAutomation_Document_ProjRepoData_ApplyType,OfficeAutomation_Document_ProjRepoData_ApplyTypeRate,OfficeAutomation_Document_ProjRepoData_ApplyTypeOther,OfficeAutomation_Document_ProjRepoData_ProjName,OfficeAutomation_Document_ProjRepoData_HavePreSaleID,OfficeAutomation_Document_ProjRepoData_PreSaleID,OfficeAutomation_Document_ProjRepoData_ProjAddress,OfficeAutomation_Document_ProjRepoData_DeveloperName,OfficeAutomation_Document_ProjRepoData_GroupName,OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs,OfficeAutomation_Document_ProjRepoData_DealOfficeOther,OfficeAutomation_Document_ProjRepoData_AgentStartDate,OfficeAutomation_Document_ProjRepoData_AgentEndDate,OfficeAutomation_Document_ProjRepoData_PreComm,OfficeAutomation_Document_ProjRepoData_GoodsQuantity,OfficeAutomation_Document_ProjRepoData_GoodsValue,OfficeAutomation_Document_ProjRepoData_CommPoint,OfficeAutomation_Document_ProjRepoData_AgentModel,OfficeAutomation_Document_ProjRepoData_ContractType,OfficeAutomation_Document_ProjRepoData_ContractTypeOther,OfficeAutomation_Document_ProjRepoData_HaveCoopCost,OfficeAutomation_Document_ProjRepoData_HaveCoopConf,OfficeAutomation_Document_ProjRepoData_IsSignBack,OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate,OfficeAutomation_Document_ProjRepoData_Remark,OfficeAutomation_Document_ProjRepoData_ProjType,OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate,OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate,OfficeAutomation_Document_ProjRepoData_IndepCount,OfficeAutomation_Document_ProjRepoData_IndepPerformance,OfficeAutomation_Document_ProjRepoData_LinkCount,OfficeAutomation_Document_ProjRepoData_JOrT,OfficeAutomation_Document_ProjRepoData_SamePlaceXX1,OfficeAutomation_Document_ProjRepoData_SamePlaceXX2,OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1,OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2,OfficeAutomation_Document_ProjRepoData_AgencyFee1,OfficeAutomation_Document_ProjRepoData_AgencyFee2,OfficeAutomation_Document_ProjRepoData_AgencyFee3,OfficeAutomation_Document_ProjRepoData_AgencyFee4,OfficeAutomation_Document_ProjRepoData_IsCashPrize1,OfficeAutomation_Document_ProjRepoData_IsCashPrize2,OfficeAutomation_Document_ProjRepoData_IsCashPrize3,OfficeAutomation_Document_ProjRepoData_IsCashPrize4,OfficeAutomation_Document_ProjRepoData_CashPrize1,OfficeAutomation_Document_ProjRepoData_CashPrize2,OfficeAutomation_Document_ProjRepoData_CashPrize3,OfficeAutomation_Document_ProjRepoData_CashPrize4,OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1,OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2,OfficeAutomation_Document_ProjRepoData_AgencyEndDate1,OfficeAutomation_Document_ProjRepoData_AgencyEndDate2,OfficeAutomation_Document_ProjRepoData_IsPFear1,OfficeAutomation_Document_ProjRepoData_IsPFear2,OfficeAutomation_Document_ProjRepoData_IsPFear3,OfficeAutomation_Document_ProjRepoData_IsPFear4,OfficeAutomation_Document_ProjRepoData_PFear1,OfficeAutomation_Document_ProjRepoData_PFear2,OfficeAutomation_Document_ProjRepoData_PFear3,OfficeAutomation_Document_ProjRepoData_PFear4,OfficeAutomation_Document_ProjRepoData_LinkPerformance,OfficeAutomation_Document_ProjRepoData_TotalProfit,OfficeAutomation_Document_ProjRepoData_Sign "); 
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjRepoData ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ProjRepoData ");
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
				strSql.Append("order by T.OfficeAutomation_Document_ProjRepoData_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ProjRepoData T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_ProjRepoData";
			parameters[1].Value = "OfficeAutomation_Document_ProjRepoData_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        //2016/8/23  52100
        public T_OfficeAutomation_Document_ProjRepoData Insert(T_OfficeAutomation_Document_ProjRepoData t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_ProjRepoData Edit(T_OfficeAutomation_Document_ProjRepoData t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_ProjRepoData t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_ProjRepoData GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_ProjRepoData>(where);
        }
		#endregion  ExtensionMethod
	}
}

