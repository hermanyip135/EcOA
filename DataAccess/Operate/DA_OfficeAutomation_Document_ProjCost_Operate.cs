/*
* DA_OfficeAutomation_Document_ProjCost.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ProjCost
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/30 17:58:32    张榕     初版
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
    /// 数据访问类:DA_OfficeAutomation_Document_ProjCost_Operate
    /// </summary>
    public partial class DA_OfficeAutomation_Document_ProjCost_Operate
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_ProjCost> dal;
        public DA_OfficeAutomation_Document_ProjCost_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_ProjCost>();
        }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid OfficeAutomation_Document_ProjCost_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_OfficeAutomation_Document_ProjCost");
            strSql.Append(" where OfficeAutomation_Document_ProjCost_ID=@OfficeAutomation_Document_ProjCost_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = OfficeAutomation_Document_ProjCost_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataEntity.T_OfficeAutomation_Document_ProjCost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_OfficeAutomation_Document_ProjCost(");
            strSql.Append("OfficeAutomation_Document_ProjCost_ID,OfficeAutomation_Document_ProjCost_MainID,OfficeAutomation_Document_ProjCost_Apply,OfficeAutomation_Document_ProjCost_ApplyForName,OfficeAutomation_Document_ProjCost_ApplyForCode,OfficeAutomation_Document_ProjCost_Department,OfficeAutomation_Document_ProjCost_DepartmentID,OfficeAutomation_Document_ProjCost_ApplyDate,OfficeAutomation_Document_ProjCost_ReplyPhone,OfficeAutomation_Document_ProjCost_Project,OfficeAutomation_Document_ProjCost_Developer,OfficeAutomation_Document_ProjCost_ProjLeader,OfficeAutomation_Document_ProjCost_ProjBusiLeader,OfficeAutomation_Document_ProjCost_DealOfficeTypeID,OfficeAutomation_Document_ProjCost_Square,OfficeAutomation_Document_ProjCost_PreProjAgenceFee,OfficeAutomation_Document_ProjCost_BrokerCostApply,OfficeAutomation_Document_ProjCost_Receiver,OfficeAutomation_Document_ProjCost_BrokerCostReason,OfficeAutomation_Document_ProjCost_BrokerName,OfficeAutomation_Document_ProjCost_JOrT,OfficeAutomation_Document_ProjCost_SamePlaceXX1,OfficeAutomation_Document_ProjCost_SamePlaceXX2,OfficeAutomation_Document_ProjCost_TurnsAgentXX1,OfficeAutomation_Document_ProjCost_TurnsAgentXX2,OfficeAutomation_Document_ProjCost_AgencyFee1,OfficeAutomation_Document_ProjCost_AgencyFee2,OfficeAutomation_Document_ProjCost_AgencyFee3,OfficeAutomation_Document_ProjCost_AgencyFee4,OfficeAutomation_Document_ProjCost_IsCashPrize1,OfficeAutomation_Document_ProjCost_IsCashPrize2,OfficeAutomation_Document_ProjCost_IsCashPrize3,OfficeAutomation_Document_ProjCost_IsCashPrize4,OfficeAutomation_Document_ProjCost_CashPrize1,OfficeAutomation_Document_ProjCost_CashPrize2,OfficeAutomation_Document_ProjCost_CashPrize3,OfficeAutomation_Document_ProjCost_CashPrize4,OfficeAutomation_Document_ProjCost_AgencyBeginDate1,OfficeAutomation_Document_ProjCost_AgencyBeginDate2,OfficeAutomation_Document_ProjCost_AgencyEndDate1,OfficeAutomation_Document_ProjCost_AgencyEndDate2,OfficeAutomation_Document_ProjCost_IsPFear1,OfficeAutomation_Document_ProjCost_IsPFear2,OfficeAutomation_Document_ProjCost_IsPFear3,OfficeAutomation_Document_ProjCost_IsPFear4,OfficeAutomation_Document_ProjCost_PFear1,OfficeAutomation_Document_ProjCost_PFear2,OfficeAutomation_Document_ProjCost_PFear3,OfficeAutomation_Document_ProjCost_PFear4)");
            strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ProjCost_ID,@OfficeAutomation_Document_ProjCost_MainID,@OfficeAutomation_Document_ProjCost_Apply,@OfficeAutomation_Document_ProjCost_ApplyForName,@OfficeAutomation_Document_ProjCost_ApplyForCode,@OfficeAutomation_Document_ProjCost_Department,@OfficeAutomation_Document_ProjCost_DepartmentID,@OfficeAutomation_Document_ProjCost_ApplyDate,@OfficeAutomation_Document_ProjCost_ReplyPhone,@OfficeAutomation_Document_ProjCost_Project,@OfficeAutomation_Document_ProjCost_Developer,@OfficeAutomation_Document_ProjCost_ProjLeader,@OfficeAutomation_Document_ProjCost_ProjBusiLeader,@OfficeAutomation_Document_ProjCost_DealOfficeTypeID,@OfficeAutomation_Document_ProjCost_Square,@OfficeAutomation_Document_ProjCost_PreProjAgenceFee,@OfficeAutomation_Document_ProjCost_BrokerCostApply,@OfficeAutomation_Document_ProjCost_Receiver,@OfficeAutomation_Document_ProjCost_BrokerCostReason,@OfficeAutomation_Document_ProjCost_BrokerName,@OfficeAutomation_Document_ProjCost_JOrT,@OfficeAutomation_Document_ProjCost_SamePlaceXX1,@OfficeAutomation_Document_ProjCost_SamePlaceXX2,@OfficeAutomation_Document_ProjCost_TurnsAgentXX1,@OfficeAutomation_Document_ProjCost_TurnsAgentXX2,@OfficeAutomation_Document_ProjCost_AgencyFee1,@OfficeAutomation_Document_ProjCost_AgencyFee2,@OfficeAutomation_Document_ProjCost_AgencyFee3,@OfficeAutomation_Document_ProjCost_AgencyFee4,@OfficeAutomation_Document_ProjCost_IsCashPrize1,@OfficeAutomation_Document_ProjCost_IsCashPrize2,@OfficeAutomation_Document_ProjCost_IsCashPrize3,@OfficeAutomation_Document_ProjCost_IsCashPrize4,@OfficeAutomation_Document_ProjCost_CashPrize1,@OfficeAutomation_Document_ProjCost_CashPrize2,@OfficeAutomation_Document_ProjCost_CashPrize3,@OfficeAutomation_Document_ProjCost_CashPrize4,@OfficeAutomation_Document_ProjCost_AgencyBeginDate1,@OfficeAutomation_Document_ProjCost_AgencyBeginDate2,@OfficeAutomation_Document_ProjCost_AgencyEndDate1,@OfficeAutomation_Document_ProjCost_AgencyEndDate2,@OfficeAutomation_Document_ProjCost_IsPFear1,@OfficeAutomation_Document_ProjCost_IsPFear2,@OfficeAutomation_Document_ProjCost_IsPFear3,@OfficeAutomation_Document_ProjCost_IsPFear4,@OfficeAutomation_Document_ProjCost_PFear1,@OfficeAutomation_Document_ProjCost_PFear2,@OfficeAutomation_Document_ProjCost_PFear3,@OfficeAutomation_Document_ProjCost_PFear4)");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ApplyForCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_DepartmentID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Project", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Developer", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ProjLeader", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ProjBusiLeader", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_DealOfficeTypeID", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Square", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PreProjAgenceFee", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_BrokerCostApply", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Receiver", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_BrokerCostReason", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_BrokerName", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjCost_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PFear4", SqlDbType.NVarChar,80)};

            parameters[0].Value = model.OfficeAutomation_Document_ProjCost_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ProjCost_MainID;
            parameters[2].Value = model.OfficeAutomation_Document_ProjCost_Apply;
            parameters[3].Value = model.OfficeAutomation_Document_ProjCost_ApplyForName;
            parameters[4].Value = model.OfficeAutomation_Document_ProjCost_ApplyForCode;
            parameters[5].Value = model.OfficeAutomation_Document_ProjCost_Department;
            parameters[6].Value = model.OfficeAutomation_Document_ProjCost_DepartmentID;
            parameters[7].Value = model.OfficeAutomation_Document_ProjCost_ApplyDate;
            parameters[8].Value = model.OfficeAutomation_Document_ProjCost_ReplyPhone;
            parameters[9].Value = model.OfficeAutomation_Document_ProjCost_Project;
            parameters[10].Value = model.OfficeAutomation_Document_ProjCost_Developer;
            parameters[11].Value = model.OfficeAutomation_Document_ProjCost_ProjLeader;
            parameters[12].Value = model.OfficeAutomation_Document_ProjCost_ProjBusiLeader;
            parameters[13].Value = model.OfficeAutomation_Document_ProjCost_DealOfficeTypeID;
            parameters[14].Value = model.OfficeAutomation_Document_ProjCost_Square;
            parameters[15].Value = model.OfficeAutomation_Document_ProjCost_PreProjAgenceFee;
            parameters[16].Value = model.OfficeAutomation_Document_ProjCost_BrokerCostApply;
            parameters[17].Value = model.OfficeAutomation_Document_ProjCost_Receiver;
            parameters[18].Value = model.OfficeAutomation_Document_ProjCost_BrokerCostReason;
            parameters[19].Value = model.OfficeAutomation_Document_ProjCost_BrokerName;

            parameters[20].Value = model.OfficeAutomation_Document_ProjCost_JOrT;
            parameters[21].Value = model.OfficeAutomation_Document_ProjCost_SamePlaceXX1;
            parameters[22].Value = model.OfficeAutomation_Document_ProjCost_SamePlaceXX2;
            parameters[23].Value = model.OfficeAutomation_Document_ProjCost_TurnsAgentXX1;
            parameters[24].Value = model.OfficeAutomation_Document_ProjCost_TurnsAgentXX2;
            parameters[25].Value = model.OfficeAutomation_Document_ProjCost_AgencyFee1;
            parameters[26].Value = model.OfficeAutomation_Document_ProjCost_AgencyFee2;
            parameters[27].Value = model.OfficeAutomation_Document_ProjCost_AgencyFee3;
            parameters[28].Value = model.OfficeAutomation_Document_ProjCost_AgencyFee4;
            parameters[29].Value = model.OfficeAutomation_Document_ProjCost_IsCashPrize1;
            parameters[30].Value = model.OfficeAutomation_Document_ProjCost_IsCashPrize2;
            parameters[31].Value = model.OfficeAutomation_Document_ProjCost_IsCashPrize3;
            parameters[32].Value = model.OfficeAutomation_Document_ProjCost_IsCashPrize4;
            parameters[33].Value = model.OfficeAutomation_Document_ProjCost_CashPrize1;
            parameters[34].Value = model.OfficeAutomation_Document_ProjCost_CashPrize2;
            parameters[35].Value = model.OfficeAutomation_Document_ProjCost_CashPrize3;
            parameters[36].Value = model.OfficeAutomation_Document_ProjCost_CashPrize4;
            parameters[37].Value = model.OfficeAutomation_Document_ProjCost_AgencyBeginDate1;
            parameters[38].Value = model.OfficeAutomation_Document_ProjCost_AgencyBeginDate2;
            parameters[39].Value = model.OfficeAutomation_Document_ProjCost_AgencyEndDate1;
            parameters[40].Value = model.OfficeAutomation_Document_ProjCost_AgencyEndDate2;
            parameters[41].Value = model.OfficeAutomation_Document_ProjCost_IsPFear1;
            parameters[42].Value = model.OfficeAutomation_Document_ProjCost_IsPFear2;
            parameters[43].Value = model.OfficeAutomation_Document_ProjCost_IsPFear3;
            parameters[44].Value = model.OfficeAutomation_Document_ProjCost_IsPFear4;
            parameters[45].Value = model.OfficeAutomation_Document_ProjCost_PFear1;
            parameters[46].Value = model.OfficeAutomation_Document_ProjCost_PFear2;
            parameters[47].Value = model.OfficeAutomation_Document_ProjCost_PFear3;
            parameters[48].Value = model.OfficeAutomation_Document_ProjCost_PFear4;

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
        public bool Update(DataEntity.T_OfficeAutomation_Document_ProjCost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_OfficeAutomation_Document_ProjCost set ");
            //strSql.Append("OfficeAutomation_Document_ProjCost_MainID=@OfficeAutomation_Document_ProjCost_MainID,");
            //strSql.Append("OfficeAutomation_Document_ProjCost_Apply=@OfficeAutomation_Document_ProjCost_Apply,");
            strSql.Append("OfficeAutomation_Document_ProjCost_ApplyForName=@OfficeAutomation_Document_ProjCost_ApplyForName,");
            strSql.Append("OfficeAutomation_Document_ProjCost_ApplyForCode=@OfficeAutomation_Document_ProjCost_ApplyForCode,");
            strSql.Append("OfficeAutomation_Document_ProjCost_Department=@OfficeAutomation_Document_ProjCost_Department,");
            strSql.Append("OfficeAutomation_Document_ProjCost_DepartmentID=@OfficeAutomation_Document_ProjCost_DepartmentID,");
            //strSql.Append("OfficeAutomation_Document_ProjCost_ApplyDate=@OfficeAutomation_Document_ProjCost_ApplyDate,");
            strSql.Append("OfficeAutomation_Document_ProjCost_ReplyPhone=@OfficeAutomation_Document_ProjCost_ReplyPhone,");
            strSql.Append("OfficeAutomation_Document_ProjCost_Project=@OfficeAutomation_Document_ProjCost_Project,");
            strSql.Append("OfficeAutomation_Document_ProjCost_Developer=@OfficeAutomation_Document_ProjCost_Developer,");
            strSql.Append("OfficeAutomation_Document_ProjCost_ProjLeader=@OfficeAutomation_Document_ProjCost_ProjLeader,");
            strSql.Append("OfficeAutomation_Document_ProjCost_ProjBusiLeader=@OfficeAutomation_Document_ProjCost_ProjBusiLeader,");
            strSql.Append("OfficeAutomation_Document_ProjCost_DealOfficeTypeID=@OfficeAutomation_Document_ProjCost_DealOfficeTypeID,");
            strSql.Append("OfficeAutomation_Document_ProjCost_Square=@OfficeAutomation_Document_ProjCost_Square,");
            strSql.Append("OfficeAutomation_Document_ProjCost_PreProjAgenceFee=@OfficeAutomation_Document_ProjCost_PreProjAgenceFee,");
            strSql.Append("OfficeAutomation_Document_ProjCost_BrokerCostApply=@OfficeAutomation_Document_ProjCost_BrokerCostApply,");
            strSql.Append("OfficeAutomation_Document_ProjCost_Receiver=@OfficeAutomation_Document_ProjCost_Receiver,");
            strSql.Append("OfficeAutomation_Document_ProjCost_BrokerCostReason=@OfficeAutomation_Document_ProjCost_BrokerCostReason,");
            strSql.Append("OfficeAutomation_Document_ProjCost_BrokerName=@OfficeAutomation_Document_ProjCost_BrokerName,");

            strSql.Append("OfficeAutomation_Document_ProjCost_JOrT=@OfficeAutomation_Document_ProjCost_JOrT,");
            strSql.Append("OfficeAutomation_Document_ProjCost_SamePlaceXX1=@OfficeAutomation_Document_ProjCost_SamePlaceXX1,");
            strSql.Append("OfficeAutomation_Document_ProjCost_SamePlaceXX2=@OfficeAutomation_Document_ProjCost_SamePlaceXX2,");
            strSql.Append("OfficeAutomation_Document_ProjCost_TurnsAgentXX1=@OfficeAutomation_Document_ProjCost_TurnsAgentXX1,");
            strSql.Append("OfficeAutomation_Document_ProjCost_TurnsAgentXX2=@OfficeAutomation_Document_ProjCost_TurnsAgentXX2,");
            strSql.Append("OfficeAutomation_Document_ProjCost_AgencyFee1=@OfficeAutomation_Document_ProjCost_AgencyFee1,");
            strSql.Append("OfficeAutomation_Document_ProjCost_AgencyFee2=@OfficeAutomation_Document_ProjCost_AgencyFee2,");
            strSql.Append("OfficeAutomation_Document_ProjCost_AgencyFee3=@OfficeAutomation_Document_ProjCost_AgencyFee3,");
            strSql.Append("OfficeAutomation_Document_ProjCost_AgencyFee4=@OfficeAutomation_Document_ProjCost_AgencyFee4,");
            strSql.Append("OfficeAutomation_Document_ProjCost_IsCashPrize1=@OfficeAutomation_Document_ProjCost_IsCashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjCost_IsCashPrize2=@OfficeAutomation_Document_ProjCost_IsCashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjCost_IsCashPrize3=@OfficeAutomation_Document_ProjCost_IsCashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjCost_IsCashPrize4=@OfficeAutomation_Document_ProjCost_IsCashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjCost_CashPrize1=@OfficeAutomation_Document_ProjCost_CashPrize1,");
            strSql.Append("OfficeAutomation_Document_ProjCost_CashPrize2=@OfficeAutomation_Document_ProjCost_CashPrize2,");
            strSql.Append("OfficeAutomation_Document_ProjCost_CashPrize3=@OfficeAutomation_Document_ProjCost_CashPrize3,");
            strSql.Append("OfficeAutomation_Document_ProjCost_CashPrize4=@OfficeAutomation_Document_ProjCost_CashPrize4,");
            strSql.Append("OfficeAutomation_Document_ProjCost_AgencyBeginDate1=@OfficeAutomation_Document_ProjCost_AgencyBeginDate1,");
            strSql.Append("OfficeAutomation_Document_ProjCost_AgencyBeginDate2=@OfficeAutomation_Document_ProjCost_AgencyBeginDate2,");
            strSql.Append("OfficeAutomation_Document_ProjCost_AgencyEndDate1=@OfficeAutomation_Document_ProjCost_AgencyEndDate1,");
            strSql.Append("OfficeAutomation_Document_ProjCost_AgencyEndDate2=@OfficeAutomation_Document_ProjCost_AgencyEndDate2,");
            strSql.Append("OfficeAutomation_Document_ProjCost_IsPFear1=@OfficeAutomation_Document_ProjCost_IsPFear1,");
            strSql.Append("OfficeAutomation_Document_ProjCost_IsPFear2=@OfficeAutomation_Document_ProjCost_IsPFear2,");
            strSql.Append("OfficeAutomation_Document_ProjCost_IsPFear3=@OfficeAutomation_Document_ProjCost_IsPFear3,");
            strSql.Append("OfficeAutomation_Document_ProjCost_IsPFear4=@OfficeAutomation_Document_ProjCost_IsPFear4,");
            strSql.Append("OfficeAutomation_Document_ProjCost_PFear1=@OfficeAutomation_Document_ProjCost_PFear1,");
            strSql.Append("OfficeAutomation_Document_ProjCost_PFear2=@OfficeAutomation_Document_ProjCost_PFear2,");
            strSql.Append("OfficeAutomation_Document_ProjCost_PFear3=@OfficeAutomation_Document_ProjCost_PFear3,");
            strSql.Append("OfficeAutomation_Document_ProjCost_PFear4=@OfficeAutomation_Document_ProjCost_PFear4");

            //strSql.Append("OfficeAutomation_Document_ProjCost_Remark=@OfficeAutomation_Document_ProjCost_Remark");
            strSql.Append(" where OfficeAutomation_Document_ProjCost_ID=@OfficeAutomation_Document_ProjCost_ID ");
            SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ProjCost_MainID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_ProjCost_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ApplyForCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_DepartmentID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_ProjCost_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Project", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Developer", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ProjLeader", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ProjBusiLeader", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_DealOfficeTypeID", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Square", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PreProjAgenceFee", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_BrokerCostApply", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_Receiver", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_BrokerCostReason", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_BrokerName", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ProjCost_JOrT", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_SamePlaceXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_SamePlaceXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_TurnsAgentXX1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_TurnsAgentXX2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyFee1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyFee2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyFee3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyFee4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsCashPrize1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsCashPrize2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsCashPrize3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsCashPrize4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_CashPrize1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_CashPrize2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_CashPrize3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_CashPrize4", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyBeginDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyBeginDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyEndDate1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_AgencyEndDate2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsPFear1", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsPFear2", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsPFear3", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_IsPFear4", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PFear1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PFear2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PFear3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_PFear4", SqlDbType.NVarChar,80),

					//new SqlParameter("@OfficeAutomation_Document_ProjCost_Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ID", SqlDbType.UniqueIdentifier,16)};
            //parameters[0].Value = model.OfficeAutomation_Document_ProjCost_MainID;
            //parameters[1].Value = model.OfficeAutomation_Document_ProjCost_Apply;
            parameters[0].Value = model.OfficeAutomation_Document_ProjCost_ApplyForName;
            parameters[1].Value = model.OfficeAutomation_Document_ProjCost_ApplyForCode;
            parameters[2].Value = model.OfficeAutomation_Document_ProjCost_Department;
            parameters[3].Value = model.OfficeAutomation_Document_ProjCost_DepartmentID;
            //parameters[4].Value = model.OfficeAutomation_Document_ProjCost_ApplyDate;
            parameters[4].Value = model.OfficeAutomation_Document_ProjCost_ReplyPhone;
            parameters[5].Value = model.OfficeAutomation_Document_ProjCost_Project;
            parameters[6].Value = model.OfficeAutomation_Document_ProjCost_Developer;
            parameters[7].Value = model.OfficeAutomation_Document_ProjCost_ProjLeader;
            parameters[8].Value = model.OfficeAutomation_Document_ProjCost_ProjBusiLeader;
            parameters[9].Value = model.OfficeAutomation_Document_ProjCost_DealOfficeTypeID;
            parameters[10].Value = model.OfficeAutomation_Document_ProjCost_Square;
            parameters[11].Value = model.OfficeAutomation_Document_ProjCost_PreProjAgenceFee;
            parameters[12].Value = model.OfficeAutomation_Document_ProjCost_BrokerCostApply;
            parameters[13].Value = model.OfficeAutomation_Document_ProjCost_Receiver;
            parameters[14].Value = model.OfficeAutomation_Document_ProjCost_BrokerCostReason;
            parameters[15].Value = model.OfficeAutomation_Document_ProjCost_BrokerName;

            parameters[16].Value = model.OfficeAutomation_Document_ProjCost_JOrT;
            parameters[17].Value = model.OfficeAutomation_Document_ProjCost_SamePlaceXX1;
            parameters[18].Value = model.OfficeAutomation_Document_ProjCost_SamePlaceXX2;
            parameters[19].Value = model.OfficeAutomation_Document_ProjCost_TurnsAgentXX1;
            parameters[20].Value = model.OfficeAutomation_Document_ProjCost_TurnsAgentXX2;
            parameters[21].Value = model.OfficeAutomation_Document_ProjCost_AgencyFee1;
            parameters[22].Value = model.OfficeAutomation_Document_ProjCost_AgencyFee2;
            parameters[23].Value = model.OfficeAutomation_Document_ProjCost_AgencyFee3;
            parameters[24].Value = model.OfficeAutomation_Document_ProjCost_AgencyFee4;
            parameters[25].Value = model.OfficeAutomation_Document_ProjCost_IsCashPrize1;
            parameters[26].Value = model.OfficeAutomation_Document_ProjCost_IsCashPrize2;
            parameters[27].Value = model.OfficeAutomation_Document_ProjCost_IsCashPrize3;
            parameters[28].Value = model.OfficeAutomation_Document_ProjCost_IsCashPrize4;
            parameters[29].Value = model.OfficeAutomation_Document_ProjCost_CashPrize1;
            parameters[30].Value = model.OfficeAutomation_Document_ProjCost_CashPrize2;
            parameters[31].Value = model.OfficeAutomation_Document_ProjCost_CashPrize3;
            parameters[32].Value = model.OfficeAutomation_Document_ProjCost_CashPrize4;
            parameters[33].Value = model.OfficeAutomation_Document_ProjCost_AgencyBeginDate1;
            parameters[34].Value = model.OfficeAutomation_Document_ProjCost_AgencyBeginDate2;
            parameters[35].Value = model.OfficeAutomation_Document_ProjCost_AgencyEndDate1;
            parameters[36].Value = model.OfficeAutomation_Document_ProjCost_AgencyEndDate2;
            parameters[37].Value = model.OfficeAutomation_Document_ProjCost_IsPFear1;
            parameters[38].Value = model.OfficeAutomation_Document_ProjCost_IsPFear2;
            parameters[39].Value = model.OfficeAutomation_Document_ProjCost_IsPFear3;
            parameters[40].Value = model.OfficeAutomation_Document_ProjCost_IsPFear4;
            parameters[41].Value = model.OfficeAutomation_Document_ProjCost_PFear1;
            parameters[42].Value = model.OfficeAutomation_Document_ProjCost_PFear2;
            parameters[43].Value = model.OfficeAutomation_Document_ProjCost_PFear3;
            parameters[44].Value = model.OfficeAutomation_Document_ProjCost_PFear4;

            //parameters[19].Value = model.OfficeAutomation_Document_ProjCost_Remark;
            parameters[45].Value = model.OfficeAutomation_Document_ProjCost_ID;

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
        public bool Delete(string OfficeAutomation_Document_ProjCost_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_ProjCost_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ProjCost_ID);

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
        public bool DeleteList(string OfficeAutomation_Document_ProjCost_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_OfficeAutomation_Document_ProjCost ");
            strSql.Append(" where OfficeAutomation_Document_ProjCost_ID in (" + OfficeAutomation_Document_ProjCost_IDlist + ")  ");
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
        public DataEntity.T_OfficeAutomation_Document_ProjCost GetModel(Guid OfficeAutomation_Document_ProjCost_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_ProjCost_ID,OfficeAutomation_Document_ProjCost_MainID,OfficeAutomation_Document_ProjCost_Apply,OfficeAutomation_Document_ProjCost_ApplyForName,OfficeAutomation_Document_ProjCost_ApplyForCode,OfficeAutomation_Document_ProjCost_Department,OfficeAutomation_Document_ProjCost_DepartmentID,OfficeAutomation_Document_ProjCost_ApplyDate,OfficeAutomation_Document_ProjCost_ReplyPhone,OfficeAutomation_Document_ProjCost_Project,OfficeAutomation_Document_ProjCost_Developer,OfficeAutomation_Document_ProjCost_ProjLeader,OfficeAutomation_Document_ProjCost_ProjBusiLeader,OfficeAutomation_Document_ProjCost_DealOfficeTypeID,OfficeAutomation_Document_ProjCost_Square,OfficeAutomation_Document_ProjCost_PreProjAgenceFee,OfficeAutomation_Document_ProjCost_BrokerCostApply,OfficeAutomation_Document_ProjCost_Receiver,OfficeAutomation_Document_ProjCost_BrokerCostReason,OfficeAutomation_Document_ProjCost_BrokerName,OfficeAutomation_Document_ProjCost_JOrT,OfficeAutomation_Document_ProjCost_SamePlaceXX1,OfficeAutomation_Document_ProjCost_SamePlaceXX2,OfficeAutomation_Document_ProjCost_TurnsAgentXX1,OfficeAutomation_Document_ProjCost_TurnsAgentXX2,OfficeAutomation_Document_ProjCost_AgencyFee1,OfficeAutomation_Document_ProjCost_AgencyFee2,OfficeAutomation_Document_ProjCost_AgencyFee3,OfficeAutomation_Document_ProjCost_AgencyFee4,OfficeAutomation_Document_ProjCost_IsCashPrize1,OfficeAutomation_Document_ProjCost_IsCashPrize2,OfficeAutomation_Document_ProjCost_IsCashPrize3,OfficeAutomation_Document_ProjCost_IsCashPrize4,OfficeAutomation_Document_ProjCost_CashPrize1,OfficeAutomation_Document_ProjCost_CashPrize2,OfficeAutomation_Document_ProjCost_CashPrize3,OfficeAutomation_Document_ProjCost_CashPrize4,OfficeAutomation_Document_ProjCost_AgencyBeginDate1,OfficeAutomation_Document_ProjCost_AgencyBeginDate2,OfficeAutomation_Document_ProjCost_AgencyEndDate1,OfficeAutomation_Document_ProjCost_AgencyEndDate2,OfficeAutomation_Document_ProjCost_IsPFear1,OfficeAutomation_Document_ProjCost_IsPFear2,OfficeAutomation_Document_ProjCost_IsPFear3,OfficeAutomation_Document_ProjCost_IsPFear4,OfficeAutomation_Document_ProjCost_PFear1,OfficeAutomation_Document_ProjCost_PFear2,OfficeAutomation_Document_ProjCost_PFear3,OfficeAutomation_Document_ProjCost_PFear4,OfficeAutomation_Document_ProjCost_Remark from t_OfficeAutomation_Document_ProjCost ");
            strSql.Append(" where OfficeAutomation_Document_ProjCost_ID=@OfficeAutomation_Document_ProjCost_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjCost_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = OfficeAutomation_Document_ProjCost_ID;

            DataEntity.T_OfficeAutomation_Document_ProjCost model = new DataEntity.T_OfficeAutomation_Document_ProjCost();
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
        public DataEntity.T_OfficeAutomation_Document_ProjCost DataRowToModel(DataRow row)
        {
            DataEntity.T_OfficeAutomation_Document_ProjCost model = new DataEntity.T_OfficeAutomation_Document_ProjCost();
            if (row != null)
            {
                if (row["OfficeAutomation_Document_ProjCost_ID"] != null && row["OfficeAutomation_Document_ProjCost_ID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjCost_ID = new Guid(row["OfficeAutomation_Document_ProjCost_ID"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_MainID"] != null && row["OfficeAutomation_Document_ProjCost_MainID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjCost_MainID = new Guid(row["OfficeAutomation_Document_ProjCost_MainID"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_Apply"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_Apply = row["OfficeAutomation_Document_ProjCost_Apply"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_ApplyForName"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_ApplyForName = row["OfficeAutomation_Document_ProjCost_ApplyForName"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_ApplyForCode"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_ApplyForCode = row["OfficeAutomation_Document_ProjCost_ApplyForCode"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_Department"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_Department = row["OfficeAutomation_Document_ProjCost_Department"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_DepartmentID"] != null && row["OfficeAutomation_Document_ProjCost_DepartmentID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjCost_DepartmentID = new Guid(row["OfficeAutomation_Document_ProjCost_DepartmentID"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_ApplyDate"] != null && row["OfficeAutomation_Document_ProjCost_ApplyDate"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ProjCost_ApplyDate = DateTime.Parse(row["OfficeAutomation_Document_ProjCost_ApplyDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_ReplyPhone"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_ReplyPhone = row["OfficeAutomation_Document_ProjCost_ReplyPhone"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_Project"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_Project = row["OfficeAutomation_Document_ProjCost_Project"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_Developer"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_Developer = row["OfficeAutomation_Document_ProjCost_Developer"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_ProjLeader"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_ProjLeader = row["OfficeAutomation_Document_ProjCost_ProjLeader"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_ProjBusiLeader"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_ProjBusiLeader = row["OfficeAutomation_Document_ProjCost_ProjBusiLeader"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_DealOfficeTypeID"] != null )
                {
                    model.OfficeAutomation_Document_ProjCost_DealOfficeTypeID = row["OfficeAutomation_Document_ProjCost_DealOfficeTypeID"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_Square"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_Square = row["OfficeAutomation_Document_ProjCost_Square"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_PreProjAgenceFee"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_PreProjAgenceFee = row["OfficeAutomation_Document_ProjCost_PreProjAgenceFee"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_BrokerCostApply"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_BrokerCostApply = row["OfficeAutomation_Document_ProjCost_BrokerCostApply"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_Receiver"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_Receiver = row["OfficeAutomation_Document_ProjCost_Receiver"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_BrokerCostReason"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_BrokerCostReason = row["OfficeAutomation_Document_ProjCost_BrokerCostReason"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_BrokerName"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_BrokerName = row["OfficeAutomation_Document_ProjCost_BrokerName"].ToString();
                }

                if (row["OfficeAutomation_Document_ProjCost_JOrT"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_JOrT = int.Parse(row["OfficeAutomation_Document_ProjCost_JOrT"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_SamePlaceXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_SamePlaceXX1 = row["OfficeAutomation_Document_ProjCost_SamePlaceXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_SamePlaceXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_SamePlaceXX2 = row["OfficeAutomation_Document_ProjCost_SamePlaceXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_TurnsAgentXX1"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_TurnsAgentXX1 = row["OfficeAutomation_Document_ProjCost_TurnsAgentXX1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_TurnsAgentXX2"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_TurnsAgentXX2 = row["OfficeAutomation_Document_ProjCost_TurnsAgentXX2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_AgencyFee1"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_AgencyFee1 = row["OfficeAutomation_Document_ProjCost_AgencyFee1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_AgencyFee2"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_AgencyFee2 = row["OfficeAutomation_Document_ProjCost_AgencyFee2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_AgencyFee3"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_AgencyFee3 = row["OfficeAutomation_Document_ProjCost_AgencyFee3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_AgencyFee4"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_AgencyFee4 = row["OfficeAutomation_Document_ProjCost_AgencyFee4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_IsCashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_IsCashPrize1 = bool.Parse(row["OfficeAutomation_Document_ProjCost_IsCashPrize1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_IsCashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_IsCashPrize2 = bool.Parse(row["OfficeAutomation_Document_ProjCost_IsCashPrize2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_IsCashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_IsCashPrize3 = bool.Parse(row["OfficeAutomation_Document_ProjCost_IsCashPrize3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_IsCashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_IsCashPrize4 = bool.Parse(row["OfficeAutomation_Document_ProjCost_IsCashPrize4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_CashPrize1"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_CashPrize1 = row["OfficeAutomation_Document_ProjCost_CashPrize1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_CashPrize2"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_CashPrize2 = row["OfficeAutomation_Document_ProjCost_CashPrize2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_CashPrize3"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_CashPrize3 = row["OfficeAutomation_Document_ProjCost_CashPrize3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_CashPrize4"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_CashPrize4 = row["OfficeAutomation_Document_ProjCost_CashPrize4"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_AgencyBeginDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_AgencyBeginDate1 = row["OfficeAutomation_Document_ProjCost_AgencyBeginDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_AgencyBeginDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_AgencyBeginDate2 = row["OfficeAutomation_Document_ProjCost_AgencyBeginDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_AgencyEndDate1"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_AgencyEndDate1 = row["OfficeAutomation_Document_ProjCost_AgencyEndDate1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_AgencyEndDate2"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_AgencyEndDate2 = row["OfficeAutomation_Document_ProjCost_AgencyEndDate2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_IsPFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_IsPFear1 = bool.Parse(row["OfficeAutomation_Document_ProjCost_IsPFear1"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_IsPFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_IsPFear2 = bool.Parse(row["OfficeAutomation_Document_ProjCost_IsPFear2"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_IsPFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_IsPFear3 = bool.Parse(row["OfficeAutomation_Document_ProjCost_IsPFear3"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_IsPFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_IsPFear4 = bool.Parse(row["OfficeAutomation_Document_ProjCost_IsPFear4"].ToString());
                }
                if (row["OfficeAutomation_Document_ProjCost_PFear1"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_PFear1 = row["OfficeAutomation_Document_ProjCost_PFear1"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_PFear2"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_PFear2 = row["OfficeAutomation_Document_ProjCost_PFear2"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_PFear3"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_PFear3 = row["OfficeAutomation_Document_ProjCost_PFear3"].ToString();
                }
                if (row["OfficeAutomation_Document_ProjCost_PFear4"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_PFear4 = row["OfficeAutomation_Document_ProjCost_PFear4"].ToString();
                }

                if (row["OfficeAutomation_Document_ProjCost_Remark"] != null)
                {
                    model.OfficeAutomation_Document_ProjCost_Remark = row["OfficeAutomation_Document_ProjCost_Remark"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_ProjCost_ID,OfficeAutomation_Document_ProjCost_MainID,OfficeAutomation_Document_ProjCost_Apply,OfficeAutomation_Document_ProjCost_ApplyForName,OfficeAutomation_Document_ProjCost_ApplyForCode,OfficeAutomation_Document_ProjCost_Department,OfficeAutomation_Document_ProjCost_DepartmentID,OfficeAutomation_Document_ProjCost_ApplyDate,OfficeAutomation_Document_ProjCost_ReplyPhone,OfficeAutomation_Document_ProjCost_Project,OfficeAutomation_Document_ProjCost_Developer,OfficeAutomation_Document_ProjCost_ProjLeader,OfficeAutomation_Document_ProjCost_ProjBusiLeader,OfficeAutomation_Document_ProjCost_DealOfficeTypeID,OfficeAutomation_Document_ProjCost_Square,OfficeAutomation_Document_ProjCost_PreProjAgenceFee,OfficeAutomation_Document_ProjCost_BrokerCostApply,OfficeAutomation_Document_ProjCost_Receiver,OfficeAutomation_Document_ProjCost_BrokerCostReason,OfficeAutomation_Document_ProjCost_BrokerName,OfficeAutomation_Document_ProjCost_JOrT,OfficeAutomation_Document_ProjCost_SamePlaceXX1,OfficeAutomation_Document_ProjCost_SamePlaceXX2,OfficeAutomation_Document_ProjCost_TurnsAgentXX1,OfficeAutomation_Document_ProjCost_TurnsAgentXX2,OfficeAutomation_Document_ProjCost_AgencyFee1,OfficeAutomation_Document_ProjCost_AgencyFee2,OfficeAutomation_Document_ProjCost_AgencyFee3,OfficeAutomation_Document_ProjCost_AgencyFee4,OfficeAutomation_Document_ProjCost_IsCashPrize1,OfficeAutomation_Document_ProjCost_IsCashPrize2,OfficeAutomation_Document_ProjCost_IsCashPrize3,OfficeAutomation_Document_ProjCost_IsCashPrize4,OfficeAutomation_Document_ProjCost_CashPrize1,OfficeAutomation_Document_ProjCost_CashPrize2,OfficeAutomation_Document_ProjCost_CashPrize3,OfficeAutomation_Document_ProjCost_CashPrize4,OfficeAutomation_Document_ProjCost_AgencyBeginDate1,OfficeAutomation_Document_ProjCost_AgencyBeginDate2,OfficeAutomation_Document_ProjCost_AgencyEndDate1,OfficeAutomation_Document_ProjCost_AgencyEndDate2,OfficeAutomation_Document_ProjCost_IsPFear1,OfficeAutomation_Document_ProjCost_IsPFear2,OfficeAutomation_Document_ProjCost_IsPFear3,OfficeAutomation_Document_ProjCost_IsPFear4,OfficeAutomation_Document_ProjCost_PFear1,OfficeAutomation_Document_ProjCost_PFear2,OfficeAutomation_Document_ProjCost_PFear3,OfficeAutomation_Document_ProjCost_PFear4,OfficeAutomation_Document_ProjCost_Remark ");
            strSql.Append(" FROM t_OfficeAutomation_Document_ProjCost ");
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
            strSql.Append(" OfficeAutomation_Document_ProjCost_ID,OfficeAutomation_Document_ProjCost_MainID,OfficeAutomation_Document_ProjCost_Apply,OfficeAutomation_Document_ProjCost_ApplyForName,OfficeAutomation_Document_ProjCost_ApplyForCode,OfficeAutomation_Document_ProjCost_Department,OfficeAutomation_Document_ProjCost_DepartmentID,OfficeAutomation_Document_ProjCost_ApplyDate,OfficeAutomation_Document_ProjCost_ReplyPhone,OfficeAutomation_Document_ProjCost_Project,OfficeAutomation_Document_ProjCost_Developer,OfficeAutomation_Document_ProjCost_ProjLeader,OfficeAutomation_Document_ProjCost_ProjBusiLeader,OfficeAutomation_Document_ProjCost_DealOfficeTypeID,OfficeAutomation_Document_ProjCost_Square,OfficeAutomation_Document_ProjCost_PreProjAgenceFee,OfficeAutomation_Document_ProjCost_BrokerCostApply,OfficeAutomation_Document_ProjCost_Receiver,OfficeAutomation_Document_ProjCost_BrokerCostReason,OfficeAutomation_Document_ProjCost_BrokerName,OfficeAutomation_Document_ProjCost_JOrT,OfficeAutomation_Document_ProjCost_SamePlaceXX1,OfficeAutomation_Document_ProjCost_SamePlaceXX2,OfficeAutomation_Document_ProjCost_TurnsAgentXX1,OfficeAutomation_Document_ProjCost_TurnsAgentXX2,OfficeAutomation_Document_ProjCost_AgencyFee1,OfficeAutomation_Document_ProjCost_AgencyFee2,OfficeAutomation_Document_ProjCost_AgencyFee3,OfficeAutomation_Document_ProjCost_AgencyFee4,OfficeAutomation_Document_ProjCost_IsCashPrize1,OfficeAutomation_Document_ProjCost_IsCashPrize2,OfficeAutomation_Document_ProjCost_IsCashPrize3,OfficeAutomation_Document_ProjCost_IsCashPrize4,OfficeAutomation_Document_ProjCost_CashPrize1,OfficeAutomation_Document_ProjCost_CashPrize2,OfficeAutomation_Document_ProjCost_CashPrize3,OfficeAutomation_Document_ProjCost_CashPrize4,OfficeAutomation_Document_ProjCost_AgencyBeginDate1,OfficeAutomation_Document_ProjCost_AgencyBeginDate2,OfficeAutomation_Document_ProjCost_AgencyEndDate1,OfficeAutomation_Document_ProjCost_AgencyEndDate2,OfficeAutomation_Document_ProjCost_IsPFear1,OfficeAutomation_Document_ProjCost_IsPFear2,OfficeAutomation_Document_ProjCost_IsPFear3,OfficeAutomation_Document_ProjCost_IsPFear4,OfficeAutomation_Document_ProjCost_PFear1,OfficeAutomation_Document_ProjCost_PFear2,OfficeAutomation_Document_ProjCost_PFear3,OfficeAutomation_Document_ProjCost_PFear4,OfficeAutomation_Document_ProjCost_Remark ");
            strSql.Append(" FROM t_OfficeAutomation_Document_ProjCost ");
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
            strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ProjCost ");
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
                strSql.Append("order by T.OfficeAutomation_Document_ProjCost_ID desc");
            }
            strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ProjCost T ");
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
            parameters[0].Value = "t_OfficeAutomation_Document_ProjCost";
            parameters[1].Value = "OfficeAutomation_Document_ProjCost_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public T_OfficeAutomation_Document_ProjCost Insert(T_OfficeAutomation_Document_ProjCost t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_ProjCost Edit(T_OfficeAutomation_Document_ProjCost t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_ProjCost t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_ProjCost GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_ProjCost>(where);
        }
        #endregion  ExtensionMethod
    }
}

