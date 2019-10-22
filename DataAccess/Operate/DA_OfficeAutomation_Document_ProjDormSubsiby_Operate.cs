/*
* DA_OfficeAutomation_Document_ProjDormSubsiby_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ProjDormSubsiby_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/19 14:20:51    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_ProjDormSubsiby_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_ProjDormSubsiby_Operate
	{
		public DA_OfficeAutomation_Document_ProjDormSubsiby_Operate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ProjDormSubsiby_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ProjDormSubsiby");
			strSql.Append(" where OfficeAutomation_Document_ProjDormSubsiby_ID=@OfficeAutomation_Document_ProjDormSubsiby_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjDormSubsiby_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ProjDormSubsiby model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_ProjDormSubsiby(");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ID,OfficeAutomation_Document_ProjDormSubsiby_MainID,OfficeAutomation_Document_ProjDormSubsiby_Department,OfficeAutomation_Document_ProjDormSubsiby_ApplyDate,OfficeAutomation_Document_ProjDormSubsiby_Apply,OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone,OfficeAutomation_Document_ProjDormSubsiby_ApplyID,OfficeAutomation_Document_ProjDormSubsiby_ProjName,OfficeAutomation_Document_ProjDormSubsiby_DeveloperName,OfficeAutomation_Document_ProjDormSubsiby_ProjAddress,OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate,OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate,OfficeAutomation_Document_ProjDormSubsiby_SaleDate,OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs,OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther,OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity,OfficeAutomation_Document_ProjDormSubsiby_GoodsValue,OfficeAutomation_Document_ProjDormSubsiby_PreComm,OfficeAutomation_Document_ProjDormSubsiby_AgentModel,OfficeAutomation_Document_ProjDormSubsiby_CommPoint,OfficeAutomation_Document_ProjDormSubsiby_RentStartDate,OfficeAutomation_Document_ProjDormSubsiby_RentEndDate,OfficeAutomation_Document_ProjDormSubsiby_RentType,OfficeAutomation_Document_ProjDormSubsiby_LiveNumber,OfficeAutomation_Document_ProjDormSubsiby_DormAddress,OfficeAutomation_Document_ProjDormSubsiby_DormArea,OfficeAutomation_Document_ProjDormSubsiby_DormType,OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent,OfficeAutomation_Document_ProjDormSubsiby_Deposit,OfficeAutomation_Document_ProjDormSubsiby_AgencyFee,OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost,OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost,OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge,OfficeAutomation_Document_ProjDormSubsiby_WaterCharge,OfficeAutomation_Document_ProjDormSubsiby_GasCharge,OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost,OfficeAutomation_Document_ProjDormSubsiby_DormRemark,OfficeAutomation_Document_ProjDormSubsiby_StartPlace,OfficeAutomation_Document_ProjDormSubsiby_EndPlace,OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney,OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes,OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney,OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate,OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate,OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark,OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo,OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo,OfficeAutomation_Document_ProjDormSubsiby_SumPerformance,OfficeAutomation_Document_ProjDormSubsiby_SumProfit,OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity,OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue,OfficeAutomation_Document_ProjDormSubsiby_ProjCommission,OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint,OfficeAutomation_Document_ProjDormSubsiby_DormSumCost,OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost,OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale,OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale,OfficeAutomation_Document_ProjDormSubsiby_Remark,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm,OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate,OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate,OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark,OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney,OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney,OfficeAutomation_Document_ProjDormSubsiby_LastYear,OfficeAutomation_Document_ProjDormSubsiby_LastMonth,OfficeAutomation_Document_ProjDormSubsiby_LastRent,OfficeAutomation_Document_ProjDormSubsiby_Sign)");
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ProjDormSubsiby_ID,@OfficeAutomation_Document_ProjDormSubsiby_MainID,@OfficeAutomation_Document_ProjDormSubsiby_Department,@OfficeAutomation_Document_ProjDormSubsiby_ApplyDate,@OfficeAutomation_Document_ProjDormSubsiby_Apply,@OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone,@OfficeAutomation_Document_ProjDormSubsiby_ApplyID,@OfficeAutomation_Document_ProjDormSubsiby_ProjName,@OfficeAutomation_Document_ProjDormSubsiby_DeveloperName,@OfficeAutomation_Document_ProjDormSubsiby_ProjAddress,@OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate,@OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate,@OfficeAutomation_Document_ProjDormSubsiby_SaleDate,@OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs,@OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther,@OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity,@OfficeAutomation_Document_ProjDormSubsiby_GoodsValue,@OfficeAutomation_Document_ProjDormSubsiby_PreComm,@OfficeAutomation_Document_ProjDormSubsiby_AgentModel,@OfficeAutomation_Document_ProjDormSubsiby_CommPoint,@OfficeAutomation_Document_ProjDormSubsiby_RentStartDate,@OfficeAutomation_Document_ProjDormSubsiby_RentEndDate,@OfficeAutomation_Document_ProjDormSubsiby_RentType,@OfficeAutomation_Document_ProjDormSubsiby_LiveNumber,@OfficeAutomation_Document_ProjDormSubsiby_DormAddress,@OfficeAutomation_Document_ProjDormSubsiby_DormArea,@OfficeAutomation_Document_ProjDormSubsiby_DormType,@OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent,@OfficeAutomation_Document_ProjDormSubsiby_Deposit,@OfficeAutomation_Document_ProjDormSubsiby_AgencyFee,@OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost,@OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost,@OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge,@OfficeAutomation_Document_ProjDormSubsiby_WaterCharge,@OfficeAutomation_Document_ProjDormSubsiby_GasCharge,@OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost,@OfficeAutomation_Document_ProjDormSubsiby_DormRemark,@OfficeAutomation_Document_ProjDormSubsiby_StartPlace,@OfficeAutomation_Document_ProjDormSubsiby_EndPlace,@OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney,@OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes,@OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney,@OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate,@OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate,@OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark,@OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo,@OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo,@OfficeAutomation_Document_ProjDormSubsiby_SumPerformance,@OfficeAutomation_Document_ProjDormSubsiby_SumProfit,@OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity,@OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue,@OfficeAutomation_Document_ProjDormSubsiby_ProjCommission,@OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint,@OfficeAutomation_Document_ProjDormSubsiby_DormSumCost,@OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost,@OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale,@OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale,@OfficeAutomation_Document_ProjDormSubsiby_Remark,@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth,@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan,@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm,@OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate,@OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate,@OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark,@OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney,@OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney,@OfficeAutomation_Document_ProjDormSubsiby_LastYear,@OfficeAutomation_Document_ProjDormSubsiby_LastMonth,@OfficeAutomation_Document_ProjDormSubsiby_LastRent,@OfficeAutomation_Document_ProjDormSubsiby_Sign)");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SaleDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_RentStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_RentEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_RentType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_LiveNumber", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormArea", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormType", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Deposit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_AgencyFee", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_WaterCharge", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_GasCharge", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_StartPlace", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_EndPlace", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SumPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SumProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjCommission", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormSumCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Remark", SqlDbType.NVarChar,1000),

                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate", SqlDbType.DateTime),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate", SqlDbType.DateTime),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark", SqlDbType.NVarChar,1000),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_LastYear", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_LastMonth", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_LastRent", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Sign", SqlDbType.NVarChar,80)};
            parameters[0].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ProjDormSubsiby_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Department;
			parameters[3].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ApplyDate;
			parameters[4].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Apply;
			parameters[5].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone;
			parameters[6].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ApplyID;
			parameters[7].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjName;
			parameters[8].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DeveloperName;
			parameters[9].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjAddress;
			parameters[10].Value = model.OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate;
			parameters[11].Value = model.OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate;
			parameters[12].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SaleDate;
			parameters[13].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs;
			parameters[14].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther;
			parameters[15].Value = model.OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity;
			parameters[16].Value = model.OfficeAutomation_Document_ProjDormSubsiby_GoodsValue;
			parameters[17].Value = model.OfficeAutomation_Document_ProjDormSubsiby_PreComm;
			parameters[18].Value = model.OfficeAutomation_Document_ProjDormSubsiby_AgentModel;
			parameters[19].Value = model.OfficeAutomation_Document_ProjDormSubsiby_CommPoint;
			parameters[20].Value = model.OfficeAutomation_Document_ProjDormSubsiby_RentStartDate;
			parameters[21].Value = model.OfficeAutomation_Document_ProjDormSubsiby_RentEndDate;
			parameters[22].Value = model.OfficeAutomation_Document_ProjDormSubsiby_RentType;
			parameters[23].Value = model.OfficeAutomation_Document_ProjDormSubsiby_LiveNumber;
			parameters[24].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormAddress;
			parameters[25].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormArea;
			parameters[26].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormType;
			parameters[27].Value = model.OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent;
			parameters[28].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Deposit;
			parameters[29].Value = model.OfficeAutomation_Document_ProjDormSubsiby_AgencyFee;
			parameters[30].Value = model.OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost;
			parameters[31].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost;
			parameters[32].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge;
			parameters[33].Value = model.OfficeAutomation_Document_ProjDormSubsiby_WaterCharge;
			parameters[34].Value = model.OfficeAutomation_Document_ProjDormSubsiby_GasCharge;
			parameters[35].Value = model.OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost;
			parameters[36].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormRemark;
			parameters[37].Value = model.OfficeAutomation_Document_ProjDormSubsiby_StartPlace;
			parameters[38].Value = model.OfficeAutomation_Document_ProjDormSubsiby_EndPlace;
			parameters[39].Value = model.OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney;
			parameters[40].Value = model.OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes;
			parameters[41].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney;
			parameters[42].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate;
			parameters[43].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate;
			parameters[44].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark;
			parameters[45].Value = model.OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo;
			parameters[46].Value = model.OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo;
			parameters[47].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SumPerformance;
			parameters[48].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SumProfit;
			parameters[49].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity;
			parameters[50].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue;
			parameters[51].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjCommission;
			parameters[52].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint;
			parameters[53].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormSumCost;
			parameters[54].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost;
			parameters[55].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale;
			parameters[56].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale;
			parameters[57].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Remark;

            parameters[58].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth;
            parameters[59].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan;
            parameters[60].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm;
            parameters[61].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate;
            parameters[62].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate;
            parameters[63].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark;
            parameters[64].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney;
            parameters[65].Value = model.OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney;

            parameters[66].Value = model.OfficeAutomation_Document_ProjDormSubsiby_LastYear;
            parameters[67].Value = model.OfficeAutomation_Document_ProjDormSubsiby_LastMonth;
            parameters[68].Value = model.OfficeAutomation_Document_ProjDormSubsiby_LastRent;

			parameters[69].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Sign;

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
		public bool Update(DataEntity.T_OfficeAutomation_Document_ProjDormSubsiby model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ProjDormSubsiby set ");
			//strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_MainID=@OfficeAutomation_Document_ProjDormSubsiby_MainID,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_Department=@OfficeAutomation_Document_ProjDormSubsiby_Department,");
			//strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ApplyDate=@OfficeAutomation_Document_ProjDormSubsiby_ApplyDate,");
			//strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_Apply=@OfficeAutomation_Document_ProjDormSubsiby_Apply,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone=@OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ApplyID=@OfficeAutomation_Document_ProjDormSubsiby_ApplyID,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ProjName=@OfficeAutomation_Document_ProjDormSubsiby_ProjName,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DeveloperName=@OfficeAutomation_Document_ProjDormSubsiby_DeveloperName,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ProjAddress=@OfficeAutomation_Document_ProjDormSubsiby_ProjAddress,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate=@OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate=@OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_SaleDate=@OfficeAutomation_Document_ProjDormSubsiby_SaleDate,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs=@OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther=@OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity=@OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_GoodsValue=@OfficeAutomation_Document_ProjDormSubsiby_GoodsValue,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_PreComm=@OfficeAutomation_Document_ProjDormSubsiby_PreComm,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_AgentModel=@OfficeAutomation_Document_ProjDormSubsiby_AgentModel,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_CommPoint=@OfficeAutomation_Document_ProjDormSubsiby_CommPoint,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_RentStartDate=@OfficeAutomation_Document_ProjDormSubsiby_RentStartDate,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_RentEndDate=@OfficeAutomation_Document_ProjDormSubsiby_RentEndDate,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_RentType=@OfficeAutomation_Document_ProjDormSubsiby_RentType,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_LiveNumber=@OfficeAutomation_Document_ProjDormSubsiby_LiveNumber,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormAddress=@OfficeAutomation_Document_ProjDormSubsiby_DormAddress,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormArea=@OfficeAutomation_Document_ProjDormSubsiby_DormArea,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormType=@OfficeAutomation_Document_ProjDormSubsiby_DormType,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent=@OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_Deposit=@OfficeAutomation_Document_ProjDormSubsiby_Deposit,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_AgencyFee=@OfficeAutomation_Document_ProjDormSubsiby_AgencyFee,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost=@OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost=@OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge=@OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_WaterCharge=@OfficeAutomation_Document_ProjDormSubsiby_WaterCharge,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_GasCharge=@OfficeAutomation_Document_ProjDormSubsiby_GasCharge,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost=@OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormRemark=@OfficeAutomation_Document_ProjDormSubsiby_DormRemark,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_StartPlace=@OfficeAutomation_Document_ProjDormSubsiby_StartPlace,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_EndPlace=@OfficeAutomation_Document_ProjDormSubsiby_EndPlace,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney=@OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes=@OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney=@OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate=@OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate=@OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark=@OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo=@OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo=@OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_SumPerformance=@OfficeAutomation_Document_ProjDormSubsiby_SumPerformance,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_SumProfit=@OfficeAutomation_Document_ProjDormSubsiby_SumProfit,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity=@OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue=@OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ProjCommission=@OfficeAutomation_Document_ProjDormSubsiby_ProjCommission,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint=@OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormSumCost=@OfficeAutomation_Document_ProjDormSubsiby_DormSumCost,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost=@OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale=@OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale=@OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale,");
			strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_Remark=@OfficeAutomation_Document_ProjDormSubsiby_Remark,");

            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth=@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth,");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan=@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan,");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm=@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm,");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate=@OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate,");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate=@OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate,");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark=@OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark,");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney=@OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney,");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney=@OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney,");

            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_LastYear=@OfficeAutomation_Document_ProjDormSubsiby_LastYear,");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_LastMonth=@OfficeAutomation_Document_ProjDormSubsiby_LastMonth,");
            strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_LastRent=@OfficeAutomation_Document_ProjDormSubsiby_LastRent");

			//strSql.Append("OfficeAutomation_Document_ProjDormSubsiby_Sign=@OfficeAutomation_Document_ProjDormSubsiby_Sign");
			strSql.Append(" where OfficeAutomation_Document_ProjDormSubsiby_ID=@OfficeAutomation_Document_ProjDormSubsiby_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Department", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ApplyDate", SqlDbType.DateTime),
					//new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SaleDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_RentStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_RentEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_RentType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_LiveNumber", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormArea", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormType", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Deposit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_AgencyFee", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_WaterCharge", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_GasCharge", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_StartPlace", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_EndPlace", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SumPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SumProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjCommission", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormSumCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Remark", SqlDbType.NVarChar,1000),

                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate", SqlDbType.DateTime),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate", SqlDbType.DateTime),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark", SqlDbType.NVarChar,1000),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_LastYear", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_LastMonth", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_LastRent", SqlDbType.NVarChar,80),

					//new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_Sign", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_ProjDormSubsiby_MainID;
			parameters[0].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Department;
			//parameters[2].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ApplyDate;
			//parameters[3].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Apply;
			parameters[1].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone;
			parameters[2].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ApplyID;
			parameters[3].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjName;
			parameters[4].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DeveloperName;
			parameters[5].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjAddress;
			parameters[6].Value = model.OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate;
			parameters[7].Value = model.OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate;
			parameters[8].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SaleDate;
			parameters[9].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs;
			parameters[10].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther;
			parameters[11].Value = model.OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity;
			parameters[12].Value = model.OfficeAutomation_Document_ProjDormSubsiby_GoodsValue;
			parameters[13].Value = model.OfficeAutomation_Document_ProjDormSubsiby_PreComm;
			parameters[14].Value = model.OfficeAutomation_Document_ProjDormSubsiby_AgentModel;
			parameters[15].Value = model.OfficeAutomation_Document_ProjDormSubsiby_CommPoint;
			parameters[16].Value = model.OfficeAutomation_Document_ProjDormSubsiby_RentStartDate;
			parameters[17].Value = model.OfficeAutomation_Document_ProjDormSubsiby_RentEndDate;
			parameters[18].Value = model.OfficeAutomation_Document_ProjDormSubsiby_RentType;
			parameters[19].Value = model.OfficeAutomation_Document_ProjDormSubsiby_LiveNumber;
			parameters[20].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormAddress;
			parameters[21].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormArea;
			parameters[22].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormType;
			parameters[23].Value = model.OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent;
			parameters[24].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Deposit;
			parameters[25].Value = model.OfficeAutomation_Document_ProjDormSubsiby_AgencyFee;
			parameters[26].Value = model.OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost;
			parameters[27].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost;
			parameters[28].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge;
			parameters[29].Value = model.OfficeAutomation_Document_ProjDormSubsiby_WaterCharge;
			parameters[30].Value = model.OfficeAutomation_Document_ProjDormSubsiby_GasCharge;
			parameters[31].Value = model.OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost;
			parameters[32].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormRemark;
			parameters[33].Value = model.OfficeAutomation_Document_ProjDormSubsiby_StartPlace;
			parameters[34].Value = model.OfficeAutomation_Document_ProjDormSubsiby_EndPlace;
			parameters[35].Value = model.OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney;
			parameters[36].Value = model.OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes;
			parameters[37].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney;
			parameters[38].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate;
			parameters[39].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate;
			parameters[40].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark;
			parameters[41].Value = model.OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo;
			parameters[42].Value = model.OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo;
			parameters[43].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SumPerformance;
			parameters[44].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SumProfit;
			parameters[45].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity;
			parameters[46].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue;
			parameters[47].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjCommission;
			parameters[48].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint;
			parameters[49].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormSumCost;
			parameters[50].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost;
			parameters[51].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale;
			parameters[52].Value = model.OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale;
			parameters[53].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Remark;

            parameters[54].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth;
            parameters[55].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan;
            parameters[56].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm;
            parameters[57].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate;
            parameters[58].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate;
            parameters[59].Value = model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark;
            parameters[60].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney;
            parameters[61].Value = model.OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney;

            parameters[62].Value = model.OfficeAutomation_Document_ProjDormSubsiby_LastYear;
            parameters[63].Value = model.OfficeAutomation_Document_ProjDormSubsiby_LastMonth;
            parameters[64].Value = model.OfficeAutomation_Document_ProjDormSubsiby_LastRent;

			//parameters[57].Value = model.OfficeAutomation_Document_ProjDormSubsiby_Sign;
			parameters[65].Value = model.OfficeAutomation_Document_ProjDormSubsiby_ID;

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
		public bool Delete(string OfficeAutomation_Document_ProjDormSubsiby_ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_ProjDormSubsiby_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ProjDormSubsiby_ID);

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
		public bool DeleteList(string OfficeAutomation_Document_ProjDormSubsiby_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ProjDormSubsiby ");
			strSql.Append(" where OfficeAutomation_Document_ProjDormSubsiby_ID in ("+OfficeAutomation_Document_ProjDormSubsiby_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_ProjDormSubsiby GetModel(Guid OfficeAutomation_Document_ProjDormSubsiby_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_ProjDormSubsiby_ID,OfficeAutomation_Document_ProjDormSubsiby_MainID,OfficeAutomation_Document_ProjDormSubsiby_Department,OfficeAutomation_Document_ProjDormSubsiby_ApplyDate,OfficeAutomation_Document_ProjDormSubsiby_Apply,OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone,OfficeAutomation_Document_ProjDormSubsiby_ApplyID,OfficeAutomation_Document_ProjDormSubsiby_ProjName,OfficeAutomation_Document_ProjDormSubsiby_DeveloperName,OfficeAutomation_Document_ProjDormSubsiby_ProjAddress,OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate,OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate,OfficeAutomation_Document_ProjDormSubsiby_SaleDate,OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs,OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther,OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity,OfficeAutomation_Document_ProjDormSubsiby_GoodsValue,OfficeAutomation_Document_ProjDormSubsiby_PreComm,OfficeAutomation_Document_ProjDormSubsiby_AgentModel,OfficeAutomation_Document_ProjDormSubsiby_CommPoint,OfficeAutomation_Document_ProjDormSubsiby_RentStartDate,OfficeAutomation_Document_ProjDormSubsiby_RentEndDate,OfficeAutomation_Document_ProjDormSubsiby_RentType,OfficeAutomation_Document_ProjDormSubsiby_LiveNumber,OfficeAutomation_Document_ProjDormSubsiby_DormAddress,OfficeAutomation_Document_ProjDormSubsiby_DormArea,OfficeAutomation_Document_ProjDormSubsiby_DormType,OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent,OfficeAutomation_Document_ProjDormSubsiby_Deposit,OfficeAutomation_Document_ProjDormSubsiby_AgencyFee,OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost,OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost,OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge,OfficeAutomation_Document_ProjDormSubsiby_WaterCharge,OfficeAutomation_Document_ProjDormSubsiby_GasCharge,OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost,OfficeAutomation_Document_ProjDormSubsiby_DormRemark,OfficeAutomation_Document_ProjDormSubsiby_StartPlace,OfficeAutomation_Document_ProjDormSubsiby_EndPlace,OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney,OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes,OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney,OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate,OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate,OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark,OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo,OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo,OfficeAutomation_Document_ProjDormSubsiby_SumPerformance,OfficeAutomation_Document_ProjDormSubsiby_SumProfit,OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity,OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue,OfficeAutomation_Document_ProjDormSubsiby_ProjCommission,OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint,OfficeAutomation_Document_ProjDormSubsiby_DormSumCost,OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost,OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale,OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale,OfficeAutomation_Document_ProjDormSubsiby_Remark,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm,OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate,OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate,OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark,OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney,OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney,OfficeAutomation_Document_ProjDormSubsiby_LastYear,OfficeAutomation_Document_ProjDormSubsiby_LastMonth,OfficeAutomation_Document_ProjDormSubsiby_LastRent,OfficeAutomation_Document_ProjDormSubsiby_Sign from t_OfficeAutomation_Document_ProjDormSubsiby ");
			strSql.Append(" where OfficeAutomation_Document_ProjDormSubsiby_ID=@OfficeAutomation_Document_ProjDormSubsiby_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjDormSubsiby_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjDormSubsiby_ID;

			DataEntity.T_OfficeAutomation_Document_ProjDormSubsiby model=new DataEntity.T_OfficeAutomation_Document_ProjDormSubsiby();
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
		public DataEntity.T_OfficeAutomation_Document_ProjDormSubsiby DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_ProjDormSubsiby model=new DataEntity.T_OfficeAutomation_Document_ProjDormSubsiby();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ID"]!=null && row["OfficeAutomation_Document_ProjDormSubsiby_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ID= new Guid(row["OfficeAutomation_Document_ProjDormSubsiby_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_MainID"]!=null && row["OfficeAutomation_Document_ProjDormSubsiby_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_MainID= new Guid(row["OfficeAutomation_Document_ProjDormSubsiby_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_Department"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_Department=row["OfficeAutomation_Document_ProjDormSubsiby_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ApplyDate"]!=null && row["OfficeAutomation_Document_ProjDormSubsiby_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_ProjDormSubsiby_ApplyDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_Apply"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_Apply=row["OfficeAutomation_Document_ProjDormSubsiby_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone=row["OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ApplyID"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ApplyID=row["OfficeAutomation_Document_ProjDormSubsiby_ApplyID"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ProjName"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ProjName=row["OfficeAutomation_Document_ProjDormSubsiby_ProjName"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_DeveloperName"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_DeveloperName=row["OfficeAutomation_Document_ProjDormSubsiby_DeveloperName"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ProjAddress"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ProjAddress=row["OfficeAutomation_Document_ProjDormSubsiby_ProjAddress"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate=row["OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate=row["OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_SaleDate"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_SaleDate=row["OfficeAutomation_Document_ProjDormSubsiby_SaleDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs=row["OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther=row["OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity=row["OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_GoodsValue"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_GoodsValue=row["OfficeAutomation_Document_ProjDormSubsiby_GoodsValue"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_PreComm"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_PreComm=row["OfficeAutomation_Document_ProjDormSubsiby_PreComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_AgentModel"]!=null && row["OfficeAutomation_Document_ProjDormSubsiby_AgentModel"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_AgentModel=int.Parse(row["OfficeAutomation_Document_ProjDormSubsiby_AgentModel"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_CommPoint"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_CommPoint=row["OfficeAutomation_Document_ProjDormSubsiby_CommPoint"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_RentStartDate"]!=null && row["OfficeAutomation_Document_ProjDormSubsiby_RentStartDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_RentStartDate=DateTime.Parse(row["OfficeAutomation_Document_ProjDormSubsiby_RentStartDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_RentEndDate"]!=null && row["OfficeAutomation_Document_ProjDormSubsiby_RentEndDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_RentEndDate=DateTime.Parse(row["OfficeAutomation_Document_ProjDormSubsiby_RentEndDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_RentType"]!=null && row["OfficeAutomation_Document_ProjDormSubsiby_RentType"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_RentType=int.Parse(row["OfficeAutomation_Document_ProjDormSubsiby_RentType"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_LiveNumber"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_LiveNumber=row["OfficeAutomation_Document_ProjDormSubsiby_LiveNumber"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_DormAddress"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_DormAddress=row["OfficeAutomation_Document_ProjDormSubsiby_DormAddress"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_DormArea"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_DormArea=row["OfficeAutomation_Document_ProjDormSubsiby_DormArea"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_DormType"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_DormType=row["OfficeAutomation_Document_ProjDormSubsiby_DormType"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent=row["OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_Deposit"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_Deposit=row["OfficeAutomation_Document_ProjDormSubsiby_Deposit"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_AgencyFee"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_AgencyFee=row["OfficeAutomation_Document_ProjDormSubsiby_AgencyFee"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost=row["OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost=row["OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge=row["OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_WaterCharge"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_WaterCharge=row["OfficeAutomation_Document_ProjDormSubsiby_WaterCharge"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_GasCharge"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_GasCharge=row["OfficeAutomation_Document_ProjDormSubsiby_GasCharge"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost=row["OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_DormRemark"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_DormRemark=row["OfficeAutomation_Document_ProjDormSubsiby_DormRemark"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_StartPlace"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_StartPlace=row["OfficeAutomation_Document_ProjDormSubsiby_StartPlace"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_EndPlace"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_EndPlace=row["OfficeAutomation_Document_ProjDormSubsiby_EndPlace"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney=row["OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes=row["OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney=row["OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate"]!=null && row["OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate=DateTime.Parse(row["OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate"]!=null && row["OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate=DateTime.Parse(row["OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark=row["OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo=row["OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo=row["OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_SumPerformance"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_SumPerformance=row["OfficeAutomation_Document_ProjDormSubsiby_SumPerformance"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_SumProfit"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_SumProfit=row["OfficeAutomation_Document_ProjDormSubsiby_SumProfit"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity=row["OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue=row["OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ProjCommission"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ProjCommission=row["OfficeAutomation_Document_ProjDormSubsiby_ProjCommission"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint=row["OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_DormSumCost"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_DormSumCost=row["OfficeAutomation_Document_ProjDormSubsiby_DormSumCost"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost=row["OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale=row["OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale=row["OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjDormSubsiby_Remark"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_Remark=row["OfficeAutomation_Document_ProjDormSubsiby_Remark"].ToString();
				}

                if (row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth = row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan = row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm = row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate = DateTime.Parse(row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate = DateTime.Parse(row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark = row["OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark"].ToString();
                }

                if (row["OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney = row["OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney"].ToString();
                }

                if (row["OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney = row["OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney"].ToString();
                }

                if (row["OfficeAutomation_Document_ProjDormSubsiby_LastYear"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_LastYear = row["OfficeAutomation_Document_ProjDormSubsiby_LastYear"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjDormSubsiby_LastMonth"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_LastMonth = row["OfficeAutomation_Document_ProjDormSubsiby_LastMonth"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjDormSubsiby_LastRent"] != null)
                {
                    model.OfficeAutomation_Document_ProjDormSubsiby_LastRent = row["OfficeAutomation_Document_ProjDormSubsiby_LastRent"].ToString();
                }

				if(row["OfficeAutomation_Document_ProjDormSubsiby_Sign"]!=null)
				{
					model.OfficeAutomation_Document_ProjDormSubsiby_Sign=row["OfficeAutomation_Document_ProjDormSubsiby_Sign"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_ProjDormSubsiby_ID,OfficeAutomation_Document_ProjDormSubsiby_MainID,OfficeAutomation_Document_ProjDormSubsiby_Department,OfficeAutomation_Document_ProjDormSubsiby_ApplyDate,OfficeAutomation_Document_ProjDormSubsiby_Apply,OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone,OfficeAutomation_Document_ProjDormSubsiby_ApplyID,OfficeAutomation_Document_ProjDormSubsiby_ProjName,OfficeAutomation_Document_ProjDormSubsiby_DeveloperName,OfficeAutomation_Document_ProjDormSubsiby_ProjAddress,OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate,OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate,OfficeAutomation_Document_ProjDormSubsiby_SaleDate,OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs,OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther,OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity,OfficeAutomation_Document_ProjDormSubsiby_GoodsValue,OfficeAutomation_Document_ProjDormSubsiby_PreComm,OfficeAutomation_Document_ProjDormSubsiby_AgentModel,OfficeAutomation_Document_ProjDormSubsiby_CommPoint,OfficeAutomation_Document_ProjDormSubsiby_RentStartDate,OfficeAutomation_Document_ProjDormSubsiby_RentEndDate,OfficeAutomation_Document_ProjDormSubsiby_RentType,OfficeAutomation_Document_ProjDormSubsiby_LiveNumber,OfficeAutomation_Document_ProjDormSubsiby_DormAddress,OfficeAutomation_Document_ProjDormSubsiby_DormArea,OfficeAutomation_Document_ProjDormSubsiby_DormType,OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent,OfficeAutomation_Document_ProjDormSubsiby_Deposit,OfficeAutomation_Document_ProjDormSubsiby_AgencyFee,OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost,OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost,OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge,OfficeAutomation_Document_ProjDormSubsiby_WaterCharge,OfficeAutomation_Document_ProjDormSubsiby_GasCharge,OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost,OfficeAutomation_Document_ProjDormSubsiby_DormRemark,OfficeAutomation_Document_ProjDormSubsiby_StartPlace,OfficeAutomation_Document_ProjDormSubsiby_EndPlace,OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney,OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes,OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney,OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate,OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate,OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark,OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo,OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo,OfficeAutomation_Document_ProjDormSubsiby_SumPerformance,OfficeAutomation_Document_ProjDormSubsiby_SumProfit,OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity,OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue,OfficeAutomation_Document_ProjDormSubsiby_ProjCommission,OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint,OfficeAutomation_Document_ProjDormSubsiby_DormSumCost,OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost,OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale,OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale,OfficeAutomation_Document_ProjDormSubsiby_Remark,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm,OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate,OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate,OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark,OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney,OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney,OfficeAutomation_Document_ProjDormSubsiby_LastYear,OfficeAutomation_Document_ProjDormSubsiby_LastMonth,OfficeAutomation_Document_ProjDormSubsiby_LastRent,OfficeAutomation_Document_ProjDormSubsiby_Sign ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjDormSubsiby ");
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
            strSql.Append(" OfficeAutomation_Document_ProjDormSubsiby_ID,OfficeAutomation_Document_ProjDormSubsiby_MainID,OfficeAutomation_Document_ProjDormSubsiby_Department,OfficeAutomation_Document_ProjDormSubsiby_ApplyDate,OfficeAutomation_Document_ProjDormSubsiby_Apply,OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone,OfficeAutomation_Document_ProjDormSubsiby_ApplyID,OfficeAutomation_Document_ProjDormSubsiby_ProjName,OfficeAutomation_Document_ProjDormSubsiby_DeveloperName,OfficeAutomation_Document_ProjDormSubsiby_ProjAddress,OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate,OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate,OfficeAutomation_Document_ProjDormSubsiby_SaleDate,OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs,OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther,OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity,OfficeAutomation_Document_ProjDormSubsiby_GoodsValue,OfficeAutomation_Document_ProjDormSubsiby_PreComm,OfficeAutomation_Document_ProjDormSubsiby_AgentModel,OfficeAutomation_Document_ProjDormSubsiby_CommPoint,OfficeAutomation_Document_ProjDormSubsiby_RentStartDate,OfficeAutomation_Document_ProjDormSubsiby_RentEndDate,OfficeAutomation_Document_ProjDormSubsiby_RentType,OfficeAutomation_Document_ProjDormSubsiby_LiveNumber,OfficeAutomation_Document_ProjDormSubsiby_DormAddress,OfficeAutomation_Document_ProjDormSubsiby_DormArea,OfficeAutomation_Document_ProjDormSubsiby_DormType,OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent,OfficeAutomation_Document_ProjDormSubsiby_Deposit,OfficeAutomation_Document_ProjDormSubsiby_AgencyFee,OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost,OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost,OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge,OfficeAutomation_Document_ProjDormSubsiby_WaterCharge,OfficeAutomation_Document_ProjDormSubsiby_GasCharge,OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost,OfficeAutomation_Document_ProjDormSubsiby_DormRemark,OfficeAutomation_Document_ProjDormSubsiby_StartPlace,OfficeAutomation_Document_ProjDormSubsiby_EndPlace,OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney,OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes,OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney,OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate,OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate,OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark,OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo,OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo,OfficeAutomation_Document_ProjDormSubsiby_SumPerformance,OfficeAutomation_Document_ProjDormSubsiby_SumProfit,OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity,OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue,OfficeAutomation_Document_ProjDormSubsiby_ProjCommission,OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint,OfficeAutomation_Document_ProjDormSubsiby_DormSumCost,OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost,OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale,OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale,OfficeAutomation_Document_ProjDormSubsiby_Remark,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan,OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm,OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate,OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate,OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark,OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney,OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney,OfficeAutomation_Document_ProjDormSubsiby_LastYear,OfficeAutomation_Document_ProjDormSubsiby_LastMonth,OfficeAutomation_Document_ProjDormSubsiby_LastRent,OfficeAutomation_Document_ProjDormSubsiby_Sign ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjDormSubsiby ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ProjDormSubsiby ");
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
				strSql.Append("order by T.OfficeAutomation_Document_ProjDormSubsiby_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ProjDormSubsiby T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_ProjDormSubsiby";
			parameters[1].Value = "OfficeAutomation_Document_ProjDormSubsiby_ID";
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

