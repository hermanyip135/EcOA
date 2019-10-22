
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    /// <summary>
    /// 数据访问类:DA_OfficeAutomation_Document_ProjReDaAdd_Operate
    /// </summary>
    public partial class DA_OfficeAutomation_Document_ProjReDaAdd_Operate
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_ProjReDaAdd> dal;

        public DA_OfficeAutomation_Document_ProjReDaAdd_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_ProjReDaAdd>();
        }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid OfficeAutomation_Document_ProjReDaAdd_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_OfficeAutomation_Document_ProjReDaAdd");
            strSql.Append(" where OfficeAutomation_Document_ProjReDaAdd_ID=@OfficeAutomation_Document_ProjReDaAdd_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = OfficeAutomation_Document_ProjReDaAdd_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataEntity.T_OfficeAutomation_Document_ProjReDaAdd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_OfficeAutomation_Document_ProjReDaAdd(");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ID,OfficeAutomation_Document_ProjReDaAdd_MainID,OfficeAutomation_Document_ProjReDaAdd_Department,OfficeAutomation_Document_ProjReDaAdd_ApplyDate,OfficeAutomation_Document_ProjReDaAdd_Apply,OfficeAutomation_Document_ProjReDaAdd_ReplyPhone,OfficeAutomation_Document_ProjReDaAdd_ApplyID,OfficeAutomation_Document_ProjReDaAdd_ApplyType,OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate,OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther,OfficeAutomation_Document_ProjReDaAdd_ProjName,OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID,OfficeAutomation_Document_ProjReDaAdd_PreSaleID,OfficeAutomation_Document_ProjReDaAdd_ProjAddress,OfficeAutomation_Document_ProjReDaAdd_DeveloperName,OfficeAutomation_Document_ProjReDaAdd_GroupName,OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs,OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther,OfficeAutomation_Document_ProjReDaAdd_AgentStartDate,OfficeAutomation_Document_ProjReDaAdd_AgentEndDate,OfficeAutomation_Document_ProjReDaAdd_PreComm,OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity,OfficeAutomation_Document_ProjReDaAdd_GoodsValue,OfficeAutomation_Document_ProjReDaAdd_CommPoint,OfficeAutomation_Document_ProjReDaAdd_AgentModel,OfficeAutomation_Document_ProjReDaAdd_ContractType,OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther,OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost,OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf,OfficeAutomation_Document_ProjReDaAdd_IsSignBack,OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate,OfficeAutomation_Document_ProjReDaAdd_Remark,OfficeAutomation_Document_ProjReDaAdd_ProjType,OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate,OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate,OfficeAutomation_Document_ProjReDaAdd_TotalProfitStartDate,OfficeAutomation_Document_ProjReDaAdd_TotalProfitEndDate,OfficeAutomation_Document_ProjReDaAdd_IndepCount,OfficeAutomation_Document_ProjReDaAdd_IndepPerformance,OfficeAutomation_Document_ProjReDaAdd_LinkCount,OfficeAutomation_Document_ProjReDaAdd_JOrT,OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1,OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2,OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1,OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2,OfficeAutomation_Document_ProjReDaAdd_AgencyFee1,OfficeAutomation_Document_ProjReDaAdd_AgencyFee2,OfficeAutomation_Document_ProjReDaAdd_AgencyFee3,OfficeAutomation_Document_ProjReDaAdd_AgencyFee4,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4,OfficeAutomation_Document_ProjReDaAdd_CashPrize1,OfficeAutomation_Document_ProjReDaAdd_CashPrize2,OfficeAutomation_Document_ProjReDaAdd_CashPrize3,OfficeAutomation_Document_ProjReDaAdd_CashPrize4,OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1,OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2,OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1,OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2,OfficeAutomation_Document_ProjReDaAdd_IsPFear1,OfficeAutomation_Document_ProjReDaAdd_IsPFear2,OfficeAutomation_Document_ProjReDaAdd_IsPFear3,OfficeAutomation_Document_ProjReDaAdd_IsPFear4,OfficeAutomation_Document_ProjReDaAdd_PFear1,OfficeAutomation_Document_ProjReDaAdd_PFear2,OfficeAutomation_Document_ProjReDaAdd_PFear3,OfficeAutomation_Document_ProjReDaAdd_PFear4,OfficeAutomation_Document_ProjReDaAdd_AreaProj,OfficeAutomation_Document_ProjReDaAdd_AreaMaster,OfficeAutomation_Document_ProjReDaAdd_LinkPerformance,OfficeAutomation_Document_ProjReDaAdd_TotalProfit,OfficeAutomation_Document_ProjReDaAdd_Sign)");
            strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ProjReDaAdd_ID,@OfficeAutomation_Document_ProjReDaAdd_MainID,@OfficeAutomation_Document_ProjReDaAdd_Department,@OfficeAutomation_Document_ProjReDaAdd_ApplyDate,@OfficeAutomation_Document_ProjReDaAdd_Apply,@OfficeAutomation_Document_ProjReDaAdd_ReplyPhone,@OfficeAutomation_Document_ProjReDaAdd_ApplyID,@OfficeAutomation_Document_ProjReDaAdd_ApplyType,@OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate,@OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther,@OfficeAutomation_Document_ProjReDaAdd_ProjName,@OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID,@OfficeAutomation_Document_ProjReDaAdd_PreSaleID,@OfficeAutomation_Document_ProjReDaAdd_ProjAddress,@OfficeAutomation_Document_ProjReDaAdd_DeveloperName,@OfficeAutomation_Document_ProjReDaAdd_GroupName,@OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs,@OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther,@OfficeAutomation_Document_ProjReDaAdd_AgentStartDate,@OfficeAutomation_Document_ProjReDaAdd_AgentEndDate,@OfficeAutomation_Document_ProjReDaAdd_PreComm,@OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity,@OfficeAutomation_Document_ProjReDaAdd_GoodsValue,@OfficeAutomation_Document_ProjReDaAdd_CommPoint,@OfficeAutomation_Document_ProjReDaAdd_AgentModel,@OfficeAutomation_Document_ProjReDaAdd_ContractType,@OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther,@OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost,@OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf,@OfficeAutomation_Document_ProjReDaAdd_IsSignBack,@OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate,@OfficeAutomation_Document_ProjReDaAdd_Remark,@OfficeAutomation_Document_ProjReDaAdd_ProjType,@OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate,@OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate,@OfficeAutomation_Document_ProjReDaAdd_TotalProfitStartDate,@OfficeAutomation_Document_ProjReDaAdd_TotalProfitEndDate,@OfficeAutomation_Document_ProjReDaAdd_IndepCount,@OfficeAutomation_Document_ProjReDaAdd_IndepPerformance,@OfficeAutomation_Document_ProjReDaAdd_LinkCount,@OfficeAutomation_Document_ProjReDaAdd_JOrT,@OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1,@OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2,@OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1,@OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2,@OfficeAutomation_Document_ProjReDaAdd_AgencyFee1,@OfficeAutomation_Document_ProjReDaAdd_AgencyFee2,@OfficeAutomation_Document_ProjReDaAdd_AgencyFee3,@OfficeAutomation_Document_ProjReDaAdd_AgencyFee4,@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1,@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2,@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3,@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4,@OfficeAutomation_Document_ProjReDaAdd_CashPrize1,@OfficeAutomation_Document_ProjReDaAdd_CashPrize2,@OfficeAutomation_Document_ProjReDaAdd_CashPrize3,@OfficeAutomation_Document_ProjReDaAdd_CashPrize4,@OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1,@OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2,@OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1,@OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2,@OfficeAutomation_Document_ProjReDaAdd_IsPFear1,@OfficeAutomation_Document_ProjReDaAdd_IsPFear2,@OfficeAutomation_Document_ProjReDaAdd_IsPFear3,@OfficeAutomation_Document_ProjReDaAdd_IsPFear4,@OfficeAutomation_Document_ProjReDaAdd_PFear1,@OfficeAutomation_Document_ProjReDaAdd_PFear2,@OfficeAutomation_Document_ProjReDaAdd_PFear3,@OfficeAutomation_Document_ProjReDaAdd_PFear4,@OfficeAutomation_Document_ProjReDaAdd_AreaProj,@OfficeAutomation_Document_ProjReDaAdd_AreaMaster,@OfficeAutomation_Document_ProjReDaAdd_LinkPerformance,@OfficeAutomation_Document_ProjReDaAdd_TotalProfit,@OfficeAutomation_Document_ProjReDaAdd_Sign)");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PreSaleID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_GroupName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgentStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgentEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ContractType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsSignBack", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ProjType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TotalProfitStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TotalProfitEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IndepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IndepPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_LinkCount", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PFear4", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AreaProj", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AreaMaster", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_LinkPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TotalProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_Sign", SqlDbType.NVarChar,80)};
            parameters[0].Value = model.OfficeAutomation_Document_ProjReDaAdd_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ProjReDaAdd_MainID;
            parameters[2].Value = model.OfficeAutomation_Document_ProjReDaAdd_Department;
            parameters[3].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyDate;
            parameters[4].Value = model.OfficeAutomation_Document_ProjReDaAdd_Apply;
            parameters[5].Value = model.OfficeAutomation_Document_ProjReDaAdd_ReplyPhone;
            parameters[6].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyID;
            parameters[7].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyType;
            parameters[8].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate;
            parameters[9].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther;
            parameters[10].Value = model.OfficeAutomation_Document_ProjReDaAdd_ProjName;
            parameters[11].Value = model.OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID;
            parameters[12].Value = model.OfficeAutomation_Document_ProjReDaAdd_PreSaleID;
            parameters[13].Value = model.OfficeAutomation_Document_ProjReDaAdd_ProjAddress;
            parameters[14].Value = model.OfficeAutomation_Document_ProjReDaAdd_DeveloperName;
            parameters[15].Value = model.OfficeAutomation_Document_ProjReDaAdd_GroupName;
            parameters[16].Value = model.OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs;
            parameters[17].Value = model.OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther;
            parameters[18].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgentStartDate;
            parameters[19].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgentEndDate;
            parameters[20].Value = model.OfficeAutomation_Document_ProjReDaAdd_PreComm;
            parameters[21].Value = model.OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity;
            parameters[22].Value = model.OfficeAutomation_Document_ProjReDaAdd_GoodsValue;
            parameters[23].Value = model.OfficeAutomation_Document_ProjReDaAdd_CommPoint;
            parameters[24].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgentModel;
            parameters[25].Value = model.OfficeAutomation_Document_ProjReDaAdd_ContractType;
            parameters[26].Value = model.OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther;
            parameters[27].Value = model.OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost;
            parameters[28].Value = model.OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf;
            parameters[29].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsSignBack;
            parameters[30].Value = model.OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate;
            parameters[31].Value = model.OfficeAutomation_Document_ProjReDaAdd_Remark;
            parameters[32].Value = model.OfficeAutomation_Document_ProjReDaAdd_ProjType;
            parameters[33].Value = model.OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate;
            parameters[34].Value = model.OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate;
            parameters[35].Value = model.OfficeAutomation_Document_ProjReDaAdd_TotalProfitStartDate;
            parameters[36].Value = model.OfficeAutomation_Document_ProjReDaAdd_TotalProfitEndDate;
            parameters[37].Value = model.OfficeAutomation_Document_ProjReDaAdd_IndepCount;
            parameters[38].Value = model.OfficeAutomation_Document_ProjReDaAdd_IndepPerformance;
            parameters[39].Value = model.OfficeAutomation_Document_ProjReDaAdd_LinkCount;

            parameters[40].Value = model.OfficeAutomation_Document_ProjReDaAdd_JOrT;
            parameters[41].Value = model.OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1;
            parameters[42].Value = model.OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2;
            parameters[43].Value = model.OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1;
            parameters[44].Value = model.OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2;
            parameters[45].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee1;
            parameters[46].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee2;
            parameters[47].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee3;
            parameters[48].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee4;
            parameters[49].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1;
            parameters[50].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2;
            parameters[51].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3;
            parameters[52].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4;
            parameters[53].Value = model.OfficeAutomation_Document_ProjReDaAdd_CashPrize1;
            parameters[54].Value = model.OfficeAutomation_Document_ProjReDaAdd_CashPrize2;
            parameters[55].Value = model.OfficeAutomation_Document_ProjReDaAdd_CashPrize3;
            parameters[56].Value = model.OfficeAutomation_Document_ProjReDaAdd_CashPrize4;
            parameters[57].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1;
            parameters[58].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2;
            parameters[59].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1;
            parameters[60].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2;
            parameters[61].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsPFear1;
            parameters[62].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsPFear2;
            parameters[63].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsPFear3;
            parameters[64].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsPFear4;
            parameters[65].Value = model.OfficeAutomation_Document_ProjReDaAdd_PFear1;
            parameters[66].Value = model.OfficeAutomation_Document_ProjReDaAdd_PFear2;
            parameters[67].Value = model.OfficeAutomation_Document_ProjReDaAdd_PFear3;
            parameters[68].Value = model.OfficeAutomation_Document_ProjReDaAdd_PFear4;
            parameters[69].Value = model.OfficeAutomation_Document_ProjReDaAdd_AreaProj;
            parameters[70].Value = model.OfficeAutomation_Document_ProjReDaAdd_AreaMaster;

            parameters[71].Value = model.OfficeAutomation_Document_ProjReDaAdd_LinkPerformance;
            parameters[72].Value = model.OfficeAutomation_Document_ProjReDaAdd_TotalProfit;
            parameters[73].Value = model.OfficeAutomation_Document_ProjReDaAdd_Sign;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(DataEntity.T_OfficeAutomation_Document_ProjReDaAdd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_OfficeAutomation_Document_ProjReDaAdd set ");
            //strSql.Append("OfficeAutomation_Document_ProjReDaAdd_MainID=@OfficeAutomation_Document_ProjReDaAdd_MainID,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_Department=@OfficeAutomation_Document_ProjReDaAdd_Department,");
            //strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ApplyDate=@OfficeAutomation_Document_ProjReDaAdd_ApplyDate,");
            //strSql.Append("OfficeAutomation_Document_ProjReDaAdd_Apply=@OfficeAutomation_Document_ProjReDaAdd_Apply,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ReplyPhone=@OfficeAutomation_Document_ProjReDaAdd_ReplyPhone,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ApplyID=@OfficeAutomation_Document_ProjReDaAdd_ApplyID,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ApplyType=@OfficeAutomation_Document_ProjReDaAdd_ApplyType,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate=@OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther=@OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ProjName=@OfficeAutomation_Document_ProjReDaAdd_ProjName,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID=@OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_PreSaleID=@OfficeAutomation_Document_ProjReDaAdd_PreSaleID,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ProjAddress=@OfficeAutomation_Document_ProjReDaAdd_ProjAddress,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_DeveloperName=@OfficeAutomation_Document_ProjReDaAdd_DeveloperName,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_GroupName=@OfficeAutomation_Document_ProjReDaAdd_GroupName,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs=@OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther=@OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgentStartDate=@OfficeAutomation_Document_ProjReDaAdd_AgentStartDate,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgentEndDate=@OfficeAutomation_Document_ProjReDaAdd_AgentEndDate,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_PreComm=@OfficeAutomation_Document_ProjReDaAdd_PreComm,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity=@OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_GoodsValue=@OfficeAutomation_Document_ProjReDaAdd_GoodsValue,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_CommPoint=@OfficeAutomation_Document_ProjReDaAdd_CommPoint,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgentModel=@OfficeAutomation_Document_ProjReDaAdd_AgentModel,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ContractType=@OfficeAutomation_Document_ProjReDaAdd_ContractType,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther=@OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost=@OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf=@OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IsSignBack=@OfficeAutomation_Document_ProjReDaAdd_IsSignBack,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate=@OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_Remark=@OfficeAutomation_Document_ProjReDaAdd_Remark,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_ProjType=@OfficeAutomation_Document_ProjReDaAdd_ProjType,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate=@OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate=@OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_TotalProfitStartDate=@OfficeAutomation_Document_ProjReDaAdd_TotalProfitStartDate,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_TotalProfitEndDate=@OfficeAutomation_Document_ProjReDaAdd_TotalProfitEndDate,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IndepCount=@OfficeAutomation_Document_ProjReDaAdd_IndepCount,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IndepPerformance=@OfficeAutomation_Document_ProjReDaAdd_IndepPerformance,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_LinkCount=@OfficeAutomation_Document_ProjReDaAdd_LinkCount,");

            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_JOrT=@OfficeAutomation_Document_ProjReDaAdd_JOrT,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1=@OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2=@OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1=@OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2=@OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgencyFee1=@OfficeAutomation_Document_ProjReDaAdd_AgencyFee1,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgencyFee2=@OfficeAutomation_Document_ProjReDaAdd_AgencyFee2,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgencyFee3=@OfficeAutomation_Document_ProjReDaAdd_AgencyFee3,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgencyFee4=@OfficeAutomation_Document_ProjReDaAdd_AgencyFee4,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1=@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2=@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3=@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4=@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_CashPrize1=@OfficeAutomation_Document_ProjReDaAdd_CashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_CashPrize2=@OfficeAutomation_Document_ProjReDaAdd_CashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_CashPrize3=@OfficeAutomation_Document_ProjReDaAdd_CashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_CashPrize4=@OfficeAutomation_Document_ProjReDaAdd_CashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1=@OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2=@OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1=@OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2=@OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IsPFear1=@OfficeAutomation_Document_ProjReDaAdd_IsPFear1,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IsPFear2=@OfficeAutomation_Document_ProjReDaAdd_IsPFear2,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IsPFear3=@OfficeAutomation_Document_ProjReDaAdd_IsPFear3,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_IsPFear4=@OfficeAutomation_Document_ProjReDaAdd_IsPFear4,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_PFear1=@OfficeAutomation_Document_ProjReDaAdd_PFear1,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_PFear2=@OfficeAutomation_Document_ProjReDaAdd_PFear2,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_PFear3=@OfficeAutomation_Document_ProjReDaAdd_PFear3,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_PFear4=@OfficeAutomation_Document_ProjReDaAdd_PFear4,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AreaProj=@OfficeAutomation_Document_ProjReDaAdd_AreaProj,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_AreaMaster=@OfficeAutomation_Document_ProjReDaAdd_AreaMaster,");

            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_LinkPerformance=@OfficeAutomation_Document_ProjReDaAdd_LinkPerformance,");
            strSql.Append("OfficeAutomation_Document_ProjReDaAdd_TotalProfit=@OfficeAutomation_Document_ProjReDaAdd_TotalProfit");
            //strSql.Append("OfficeAutomation_Document_ProjReDaAdd_Sign=@OfficeAutomation_Document_ProjReDaAdd_Sign");
            strSql.Append(" where OfficeAutomation_Document_ProjReDaAdd_ID=@OfficeAutomation_Document_ProjReDaAdd_ID ");
            SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_Department", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyDate", SqlDbType.DateTime),
					//new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PreSaleID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_GroupName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgentStartDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgentEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ContractType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsSignBack", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ProjType", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TotalProfitStartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TotalProfitEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IndepCount", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IndepPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_LinkCount", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_PFear4", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AreaProj", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_AreaMaster", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_LinkPerformance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_TotalProfit", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_Sign", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ID", SqlDbType.UniqueIdentifier,16)};
            //parameters[0].Value = model.OfficeAutomation_Document_ProjReDaAdd_MainID;
            parameters[0].Value = model.OfficeAutomation_Document_ProjReDaAdd_Department;
            //parameters[2].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyDate;
            //parameters[3].Value = model.OfficeAutomation_Document_ProjReDaAdd_Apply;
            parameters[1].Value = model.OfficeAutomation_Document_ProjReDaAdd_ReplyPhone;
            parameters[2].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyID;
            parameters[3].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyType;
            parameters[4].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate;
            parameters[5].Value = model.OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther;
            parameters[6].Value = model.OfficeAutomation_Document_ProjReDaAdd_ProjName;
            parameters[7].Value = model.OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID;
            parameters[8].Value = model.OfficeAutomation_Document_ProjReDaAdd_PreSaleID;
            parameters[9].Value = model.OfficeAutomation_Document_ProjReDaAdd_ProjAddress;
            parameters[10].Value = model.OfficeAutomation_Document_ProjReDaAdd_DeveloperName;
            parameters[11].Value = model.OfficeAutomation_Document_ProjReDaAdd_GroupName;
            parameters[12].Value = model.OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs;
            parameters[13].Value = model.OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther;
            parameters[14].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgentStartDate;
            parameters[15].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgentEndDate;
            parameters[16].Value = model.OfficeAutomation_Document_ProjReDaAdd_PreComm;
            parameters[17].Value = model.OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity;
            parameters[18].Value = model.OfficeAutomation_Document_ProjReDaAdd_GoodsValue;
            parameters[19].Value = model.OfficeAutomation_Document_ProjReDaAdd_CommPoint;
            parameters[20].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgentModel;
            parameters[21].Value = model.OfficeAutomation_Document_ProjReDaAdd_ContractType;
            parameters[22].Value = model.OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther;
            parameters[23].Value = model.OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost;
            parameters[24].Value = model.OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf;
            parameters[25].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsSignBack;
            parameters[26].Value = model.OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate;
            parameters[27].Value = model.OfficeAutomation_Document_ProjReDaAdd_Remark;
            parameters[28].Value = model.OfficeAutomation_Document_ProjReDaAdd_ProjType;
            parameters[29].Value = model.OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate;
            parameters[30].Value = model.OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate;
            parameters[31].Value = model.OfficeAutomation_Document_ProjReDaAdd_TotalProfitStartDate;
            parameters[32].Value = model.OfficeAutomation_Document_ProjReDaAdd_TotalProfitEndDate;
            parameters[33].Value = model.OfficeAutomation_Document_ProjReDaAdd_IndepCount;
            parameters[34].Value = model.OfficeAutomation_Document_ProjReDaAdd_IndepPerformance;
            parameters[35].Value = model.OfficeAutomation_Document_ProjReDaAdd_LinkCount;

            parameters[36].Value = model.OfficeAutomation_Document_ProjReDaAdd_JOrT;
            parameters[37].Value = model.OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1;
            parameters[38].Value = model.OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2;
            parameters[39].Value = model.OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1;
            parameters[40].Value = model.OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2;
            parameters[41].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee1;
            parameters[42].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee2;
            parameters[43].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee3;
            parameters[44].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee4;
            parameters[45].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1;
            parameters[46].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2;
            parameters[47].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3;
            parameters[48].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4;
            parameters[49].Value = model.OfficeAutomation_Document_ProjReDaAdd_CashPrize1;
            parameters[50].Value = model.OfficeAutomation_Document_ProjReDaAdd_CashPrize2;
            parameters[51].Value = model.OfficeAutomation_Document_ProjReDaAdd_CashPrize3;
            parameters[52].Value = model.OfficeAutomation_Document_ProjReDaAdd_CashPrize4;
            parameters[53].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1;
            parameters[54].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2;
            parameters[55].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1;
            parameters[56].Value = model.OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2;
            parameters[57].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsPFear1;
            parameters[58].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsPFear2;
            parameters[59].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsPFear3;
            parameters[60].Value = model.OfficeAutomation_Document_ProjReDaAdd_IsPFear4;
            parameters[61].Value = model.OfficeAutomation_Document_ProjReDaAdd_PFear1;
            parameters[62].Value = model.OfficeAutomation_Document_ProjReDaAdd_PFear2;
            parameters[63].Value = model.OfficeAutomation_Document_ProjReDaAdd_PFear3;
            parameters[64].Value = model.OfficeAutomation_Document_ProjReDaAdd_PFear4;
            parameters[65].Value = model.OfficeAutomation_Document_ProjReDaAdd_AreaProj;
            parameters[66].Value = model.OfficeAutomation_Document_ProjReDaAdd_AreaMaster;

            parameters[67].Value = model.OfficeAutomation_Document_ProjReDaAdd_LinkPerformance;
            parameters[68].Value = model.OfficeAutomation_Document_ProjReDaAdd_TotalProfit;
            //parameters[35].Value = model.OfficeAutomation_Document_ProjReDaAdd_Sign;
            parameters[69].Value = model.OfficeAutomation_Document_ProjReDaAdd_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string OfficeAutomation_Document_ProjReDaAdd_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_ProjReDaAdd_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ProjReDaAdd_ID);

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
        public bool DeleteList(string OfficeAutomation_Document_ProjReDaAdd_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_OfficeAutomation_Document_ProjReDaAdd ");
            strSql.Append(" where OfficeAutomation_Document_ProjReDaAdd_ID in (" + OfficeAutomation_Document_ProjReDaAdd_IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public DataEntity.T_OfficeAutomation_Document_ProjReDaAdd GetModel(Guid OfficeAutomation_Document_ProjReDaAdd_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_ProjReDaAdd_ID,OfficeAutomation_Document_ProjReDaAdd_MainID,OfficeAutomation_Document_ProjReDaAdd_Department,OfficeAutomation_Document_ProjReDaAdd_ApplyDate,OfficeAutomation_Document_ProjReDaAdd_Apply,OfficeAutomation_Document_ProjReDaAdd_ReplyPhone,OfficeAutomation_Document_ProjReDaAdd_ApplyID,OfficeAutomation_Document_ProjReDaAdd_ApplyType,OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate,OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther,OfficeAutomation_Document_ProjReDaAdd_ProjName,OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID,OfficeAutomation_Document_ProjReDaAdd_PreSaleID,OfficeAutomation_Document_ProjReDaAdd_ProjAddress,OfficeAutomation_Document_ProjReDaAdd_DeveloperName,OfficeAutomation_Document_ProjReDaAdd_GroupName,OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs,OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther,OfficeAutomation_Document_ProjReDaAdd_AgentStartDate,OfficeAutomation_Document_ProjReDaAdd_AgentEndDate,OfficeAutomation_Document_ProjReDaAdd_PreComm,OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity,OfficeAutomation_Document_ProjReDaAdd_GoodsValue,OfficeAutomation_Document_ProjReDaAdd_CommPoint,OfficeAutomation_Document_ProjReDaAdd_AgentModel,OfficeAutomation_Document_ProjReDaAdd_ContractType,OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther,OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost,OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf,OfficeAutomation_Document_ProjReDaAdd_IsSignBack,OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate,OfficeAutomation_Document_ProjReDaAdd_Remark,OfficeAutomation_Document_ProjReDaAdd_ProjType,OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate,OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate,OfficeAutomation_Document_ProjReDaAdd_IndepCount,OfficeAutomation_Document_ProjReDaAdd_IndepPerformance,OfficeAutomation_Document_ProjReDaAdd_LinkCount,OfficeAutomation_Document_ProjReDaAdd_JOrT,OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1,OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2,OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1,OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2,OfficeAutomation_Document_ProjReDaAdd_AgencyFee1,OfficeAutomation_Document_ProjReDaAdd_AgencyFee2,OfficeAutomation_Document_ProjReDaAdd_AgencyFee3,OfficeAutomation_Document_ProjReDaAdd_AgencyFee4,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4,OfficeAutomation_Document_ProjReDaAdd_CashPrize1,OfficeAutomation_Document_ProjReDaAdd_CashPrize2,OfficeAutomation_Document_ProjReDaAdd_CashPrize3,OfficeAutomation_Document_ProjReDaAdd_CashPrize4,OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1,OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2,OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1,OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2,OfficeAutomation_Document_ProjReDaAdd_IsPFear1,OfficeAutomation_Document_ProjReDaAdd_IsPFear2,OfficeAutomation_Document_ProjReDaAdd_IsPFear3,OfficeAutomation_Document_ProjReDaAdd_IsPFear4,OfficeAutomation_Document_ProjReDaAdd_PFear1,OfficeAutomation_Document_ProjReDaAdd_PFear2,OfficeAutomation_Document_ProjReDaAdd_PFear3,OfficeAutomation_Document_ProjReDaAdd_PFear4,OfficeAutomation_Document_ProjReDaAdd_AreaProj,OfficeAutomation_Document_ProjReDaAdd_AreaMaster,OfficeAutomation_Document_ProjReDaAdd_LinkPerformance,OfficeAutomation_Document_ProjReDaAdd_TotalProfit,OfficeAutomation_Document_ProjReDaAdd_Sign from t_OfficeAutomation_Document_ProjReDaAdd ");
            strSql.Append(" where OfficeAutomation_Document_ProjReDaAdd_ID=@OfficeAutomation_Document_ProjReDaAdd_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjReDaAdd_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = OfficeAutomation_Document_ProjReDaAdd_ID;

            DataEntity.T_OfficeAutomation_Document_ProjReDaAdd model = new DataEntity.T_OfficeAutomation_Document_ProjReDaAdd();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public DataEntity.T_OfficeAutomation_Document_ProjReDaAdd DataRowToModel(DataRow row)
        {
            DataEntity.T_OfficeAutomation_Document_ProjReDaAdd model = new DataEntity.T_OfficeAutomation_Document_ProjReDaAdd();
            if (row != null)
            {
                if (row["OfficeAutomation_Document_ProjReDaAdd_ID"] != null && row["OfficeAutomation_Document_ProjReDaAdd_ID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ID = new Guid(row["OfficeAutomation_Document_ProjReDaAdd_ID"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_MainID"] != null && row["OfficeAutomation_Document_ProjReDaAdd_MainID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_MainID = new Guid(row["OfficeAutomation_Document_ProjReDaAdd_MainID"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_Department"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_Department = row["OfficeAutomation_Document_ProjReDaAdd_Department"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ApplyDate"] != null && row["OfficeAutomation_Document_ProjReDaAdd_ApplyDate"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ApplyDate = DateTime.Parse(row["OfficeAutomation_Document_ProjReDaAdd_ApplyDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_Apply"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_Apply = row["OfficeAutomation_Document_ProjReDaAdd_Apply"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ReplyPhone"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ReplyPhone = row["OfficeAutomation_Document_ProjReDaAdd_ReplyPhone"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ApplyID"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ApplyID = row["OfficeAutomation_Document_ProjReDaAdd_ApplyID"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ApplyType"] != null && row["OfficeAutomation_Document_ProjReDaAdd_ApplyType"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ApplyType = int.Parse(row["OfficeAutomation_Document_ProjReDaAdd_ApplyType"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate = row["OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther = row["OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ProjName"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ProjName = row["OfficeAutomation_Document_ProjReDaAdd_ProjName"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID"] != null && row["OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID"].ToString() == "1") || (row["OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID"].ToString().ToLower() == "true"))
                    {
                        model.OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID = true;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID = false;
                    }
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_PreSaleID"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_PreSaleID = row["OfficeAutomation_Document_ProjReDaAdd_PreSaleID"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ProjAddress"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ProjAddress = row["OfficeAutomation_Document_ProjReDaAdd_ProjAddress"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_DeveloperName"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_DeveloperName = row["OfficeAutomation_Document_ProjReDaAdd_DeveloperName"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_GroupName"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_GroupName = row["OfficeAutomation_Document_ProjReDaAdd_GroupName"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs = row["OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther = row["OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgentStartDate"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgentStartDate = row["OfficeAutomation_Document_ProjReDaAdd_AgentStartDate"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgentEndDate"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgentEndDate = row["OfficeAutomation_Document_ProjReDaAdd_AgentEndDate"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_PreComm"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_PreComm = row["OfficeAutomation_Document_ProjReDaAdd_PreComm"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity = row["OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_GoodsValue"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_GoodsValue = row["OfficeAutomation_Document_ProjReDaAdd_GoodsValue"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_CommPoint"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_CommPoint = row["OfficeAutomation_Document_ProjReDaAdd_CommPoint"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgentModel"] != null && row["OfficeAutomation_Document_ProjReDaAdd_AgentModel"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgentModel = int.Parse(row["OfficeAutomation_Document_ProjReDaAdd_AgentModel"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ContractType"] != null && row["OfficeAutomation_Document_ProjReDaAdd_ContractType"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ContractType = int.Parse(row["OfficeAutomation_Document_ProjReDaAdd_ContractType"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther = row["OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost"] != null && row["OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost"].ToString() == "1") || (row["OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost"].ToString().ToLower() == "true"))
                    {
                        model.OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost = true;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost = false;
                    }
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf"] != null && row["OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf"].ToString() == "1") || (row["OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf"].ToString().ToLower() == "true"))
                    {
                        model.OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf = true;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf = false;
                    }
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IsSignBack"] != null && row["OfficeAutomation_Document_ProjReDaAdd_IsSignBack"].ToString() != "")
                {
                    if ((row["OfficeAutomation_Document_ProjReDaAdd_IsSignBack"].ToString() == "1") || (row["OfficeAutomation_Document_ProjReDaAdd_IsSignBack"].ToString().ToLower() == "true"))
                    {
                        model.OfficeAutomation_Document_ProjReDaAdd_IsSignBack = true;
                    }
                    else
                    {
                        model.OfficeAutomation_Document_ProjReDaAdd_IsSignBack = false;
                    }
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate = row["OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_Remark"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_Remark = row["OfficeAutomation_Document_ProjReDaAdd_Remark"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_ProjType"] != null && row["OfficeAutomation_Document_ProjReDaAdd_ProjType"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_ProjType = int.Parse(row["OfficeAutomation_Document_ProjReDaAdd_ProjType"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate"] != null && row["OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate = DateTime.Parse(row["OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate"] != null && row["OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate = DateTime.Parse(row["OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IndepCount"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IndepCount = row["OfficeAutomation_Document_ProjReDaAdd_IndepCount"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IndepPerformance"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IndepPerformance = row["OfficeAutomation_Document_ProjReDaAdd_IndepPerformance"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_LinkCount"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_LinkCount = row["OfficeAutomation_Document_ProjReDaAdd_LinkCount"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_JOrT"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_JOrT = int.Parse(row["OfficeAutomation_Document_ProjReDaAdd_JOrT"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1 = row["OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2 = row["OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1 = row["OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2 = row["OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgencyFee1"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee1 = row["OfficeAutomation_Document_ProjReDaAdd_AgencyFee1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgencyFee2"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee2 = row["OfficeAutomation_Document_ProjReDaAdd_AgencyFee2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgencyFee3"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee3 = row["OfficeAutomation_Document_ProjReDaAdd_AgencyFee3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgencyFee4"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgencyFee4 = row["OfficeAutomation_Document_ProjReDaAdd_AgencyFee4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1 = bool.Parse(row["OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2 = bool.Parse(row["OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3 = bool.Parse(row["OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4 = bool.Parse(row["OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_CashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_CashPrize1 = row["OfficeAutomation_Document_ProjReDaAdd_CashPrize1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_CashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_CashPrize2 = row["OfficeAutomation_Document_ProjReDaAdd_CashPrize2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_CashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_CashPrize3 = row["OfficeAutomation_Document_ProjReDaAdd_CashPrize3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_CashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_CashPrize4 = row["OfficeAutomation_Document_ProjReDaAdd_CashPrize4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1 = row["OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2 = row["OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1 = row["OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2 = row["OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IsPFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IsPFear1 = bool.Parse(row["OfficeAutomation_Document_ProjReDaAdd_IsPFear1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IsPFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IsPFear2 = bool.Parse(row["OfficeAutomation_Document_ProjReDaAdd_IsPFear2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IsPFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IsPFear3 = bool.Parse(row["OfficeAutomation_Document_ProjReDaAdd_IsPFear3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_IsPFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_IsPFear4 = bool.Parse(row["OfficeAutomation_Document_ProjReDaAdd_IsPFear4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_PFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_PFear1 = row["OfficeAutomation_Document_ProjReDaAdd_PFear1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_PFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_PFear2 = row["OfficeAutomation_Document_ProjReDaAdd_PFear2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_PFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_PFear3 = row["OfficeAutomation_Document_ProjReDaAdd_PFear3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_PFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_PFear4 = row["OfficeAutomation_Document_ProjReDaAdd_PFear4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AreaProj"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AreaProj = row["OfficeAutomation_Document_ProjReDaAdd_AreaProj"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_AreaMaster"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_AreaMaster = row["OfficeAutomation_Document_ProjReDaAdd_AreaMaster"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_LinkPerformance"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_LinkPerformance = row["OfficeAutomation_Document_ProjReDaAdd_LinkPerformance"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_TotalProfit"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_TotalProfit = row["OfficeAutomation_Document_ProjReDaAdd_TotalProfit"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjReDaAdd_Sign"] != null)
                {
                    model.OfficeAutomation_Document_ProjReDaAdd_Sign = row["OfficeAutomation_Document_ProjReDaAdd_Sign"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OfficeAutomation_Document_ProjReDaAdd_ID,OfficeAutomation_Document_ProjReDaAdd_MainID,OfficeAutomation_Document_ProjReDaAdd_Department,OfficeAutomation_Document_ProjReDaAdd_ApplyDate,OfficeAutomation_Document_ProjReDaAdd_Apply,OfficeAutomation_Document_ProjReDaAdd_ReplyPhone,OfficeAutomation_Document_ProjReDaAdd_ApplyID,OfficeAutomation_Document_ProjReDaAdd_ApplyType,OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate,OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther,OfficeAutomation_Document_ProjReDaAdd_ProjName,OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID,OfficeAutomation_Document_ProjReDaAdd_PreSaleID,OfficeAutomation_Document_ProjReDaAdd_ProjAddress,OfficeAutomation_Document_ProjReDaAdd_DeveloperName,OfficeAutomation_Document_ProjReDaAdd_GroupName,OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs,OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther,OfficeAutomation_Document_ProjReDaAdd_AgentStartDate,OfficeAutomation_Document_ProjReDaAdd_AgentEndDate,OfficeAutomation_Document_ProjReDaAdd_PreComm,OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity,OfficeAutomation_Document_ProjReDaAdd_GoodsValue,OfficeAutomation_Document_ProjReDaAdd_CommPoint,OfficeAutomation_Document_ProjReDaAdd_AgentModel,OfficeAutomation_Document_ProjReDaAdd_ContractType,OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther,OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost,OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf,OfficeAutomation_Document_ProjReDaAdd_IsSignBack,OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate,OfficeAutomation_Document_ProjReDaAdd_Remark,OfficeAutomation_Document_ProjReDaAdd_ProjType,OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate,OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate,OfficeAutomation_Document_ProjReDaAdd_IndepCount,OfficeAutomation_Document_ProjReDaAdd_IndepPerformance,OfficeAutomation_Document_ProjReDaAdd_LinkCount,OfficeAutomation_Document_ProjReDaAdd_JOrT,OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1,OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2,OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1,OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2,OfficeAutomation_Document_ProjReDaAdd_AgencyFee1,OfficeAutomation_Document_ProjReDaAdd_AgencyFee2,OfficeAutomation_Document_ProjReDaAdd_AgencyFee3,OfficeAutomation_Document_ProjReDaAdd_AgencyFee4,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4,OfficeAutomation_Document_ProjReDaAdd_CashPrize1,OfficeAutomation_Document_ProjReDaAdd_CashPrize2,OfficeAutomation_Document_ProjReDaAdd_CashPrize3,OfficeAutomation_Document_ProjReDaAdd_CashPrize4,OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1,OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2,OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1,OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2,OfficeAutomation_Document_ProjReDaAdd_IsPFear1,OfficeAutomation_Document_ProjReDaAdd_IsPFear2,OfficeAutomation_Document_ProjReDaAdd_IsPFear3,OfficeAutomation_Document_ProjReDaAdd_IsPFear4,OfficeAutomation_Document_ProjReDaAdd_PFear1,OfficeAutomation_Document_ProjReDaAdd_PFear2,OfficeAutomation_Document_ProjReDaAdd_PFear3,OfficeAutomation_Document_ProjReDaAdd_PFear4,OfficeAutomation_Document_ProjReDaAdd_AreaProj,OfficeAutomation_Document_ProjReDaAdd_AreaMaster,OfficeAutomation_Document_ProjReDaAdd_LinkPerformance,OfficeAutomation_Document_ProjReDaAdd_TotalProfit,OfficeAutomation_Document_ProjReDaAdd_Sign ");
            strSql.Append(" FROM t_OfficeAutomation_Document_ProjReDaAdd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OfficeAutomation_Document_ProjReDaAdd_ID,OfficeAutomation_Document_ProjReDaAdd_MainID,OfficeAutomation_Document_ProjReDaAdd_Department,OfficeAutomation_Document_ProjReDaAdd_ApplyDate,OfficeAutomation_Document_ProjReDaAdd_Apply,OfficeAutomation_Document_ProjReDaAdd_ReplyPhone,OfficeAutomation_Document_ProjReDaAdd_ApplyID,OfficeAutomation_Document_ProjReDaAdd_ApplyType,OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate,OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther,OfficeAutomation_Document_ProjReDaAdd_ProjName,OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID,OfficeAutomation_Document_ProjReDaAdd_PreSaleID,OfficeAutomation_Document_ProjReDaAdd_ProjAddress,OfficeAutomation_Document_ProjReDaAdd_DeveloperName,OfficeAutomation_Document_ProjReDaAdd_GroupName,OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs,OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther,OfficeAutomation_Document_ProjReDaAdd_AgentStartDate,OfficeAutomation_Document_ProjReDaAdd_AgentEndDate,OfficeAutomation_Document_ProjReDaAdd_PreComm,OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity,OfficeAutomation_Document_ProjReDaAdd_GoodsValue,OfficeAutomation_Document_ProjReDaAdd_CommPoint,OfficeAutomation_Document_ProjReDaAdd_AgentModel,OfficeAutomation_Document_ProjReDaAdd_ContractType,OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther,OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost,OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf,OfficeAutomation_Document_ProjReDaAdd_IsSignBack,OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate,OfficeAutomation_Document_ProjReDaAdd_Remark,OfficeAutomation_Document_ProjReDaAdd_ProjType,OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate,OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate,OfficeAutomation_Document_ProjReDaAdd_IndepCount,OfficeAutomation_Document_ProjReDaAdd_IndepPerformance,OfficeAutomation_Document_ProjReDaAdd_LinkCount,OfficeAutomation_Document_ProjReDaAdd_JOrT,OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1,OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2,OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1,OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2,OfficeAutomation_Document_ProjReDaAdd_AgencyFee1,OfficeAutomation_Document_ProjReDaAdd_AgencyFee2,OfficeAutomation_Document_ProjReDaAdd_AgencyFee3,OfficeAutomation_Document_ProjReDaAdd_AgencyFee4,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3,OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4,OfficeAutomation_Document_ProjReDaAdd_CashPrize1,OfficeAutomation_Document_ProjReDaAdd_CashPrize2,OfficeAutomation_Document_ProjReDaAdd_CashPrize3,OfficeAutomation_Document_ProjReDaAdd_CashPrize4,OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1,OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2,OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1,OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2,OfficeAutomation_Document_ProjReDaAdd_IsPFear1,OfficeAutomation_Document_ProjReDaAdd_IsPFear2,OfficeAutomation_Document_ProjReDaAdd_IsPFear3,OfficeAutomation_Document_ProjReDaAdd_IsPFear4,OfficeAutomation_Document_ProjReDaAdd_PFear1,OfficeAutomation_Document_ProjReDaAdd_PFear2,OfficeAutomation_Document_ProjReDaAdd_PFear3,OfficeAutomation_Document_ProjReDaAdd_PFear4,OfficeAutomation_Document_ProjReDaAdd_AreaProj,OfficeAutomation_Document_ProjReDaAdd_AreaMaster,OfficeAutomation_Document_ProjReDaAdd_LinkPerformance,OfficeAutomation_Document_ProjReDaAdd_TotalProfit,OfficeAutomation_Document_ProjReDaAdd_Sign ");
            strSql.Append(" FROM t_OfficeAutomation_Document_ProjReDaAdd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ProjReDaAdd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.OfficeAutomation_Document_ProjReDaAdd_ID desc");
            }
            strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ProjReDaAdd T ");
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
            parameters[0].Value = "t_OfficeAutomation_Document_ProjReDaAdd";
            parameters[1].Value = "OfficeAutomation_Document_ProjReDaAdd_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public T_OfficeAutomation_Document_ProjReDaAdd Insert(T_OfficeAutomation_Document_ProjReDaAdd t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_ProjReDaAdd Edit(T_OfficeAutomation_Document_ProjReDaAdd t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_ProjReDaAdd t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_ProjReDaAdd GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_ProjReDaAdd>(where);
        }
        #endregion  ExtensionMethod
    }
}

