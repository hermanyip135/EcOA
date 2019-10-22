/*
* DA_OfficeAutomation_Document_ReduceComm_Detail.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ReduceComm_Detail
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/28 17:59:32    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_ReduceComm_Detail
	/// </summary>
    public partial class DA_OfficeAutomation_Document_ReduceComm_Detail_Operate
	{
		public DA_OfficeAutomation_Document_ReduceComm_Detail_Operate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ReduceComm_Detail_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ReduceComm_Detail");
			strSql.Append(" where OfficeAutomation_Document_ReduceComm_Detail_ID=@OfficeAutomation_Document_ReduceComm_Detail_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ReduceComm_Detail_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ReduceComm_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_ReduceComm_Detail(");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_ID,OfficeAutomation_Document_ReduceComm_Detail_MainID,OfficeAutomation_Document_ReduceComm_Detail_DealDate,OfficeAutomation_Document_ReduceComm_Detail_DealDepartment,OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice,OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice,OfficeAutomation_Document_ReduceComm_Detail_CommPoint,OfficeAutomation_Document_ReduceComm_Detail_OriginalComm,OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_ReduceComm,OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint,OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint,OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm,OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm,OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm,OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm,OfficeAutomation_Document_ReduceComm_Detail_KSa,OfficeAutomation_Document_ReduceComm_Detail_KSb,OfficeAutomation_Document_ReduceComm_Detail_KSc,OfficeAutomation_Document_ReduceComm_Detail_KSd,OfficeAutomation_Document_ReduceComm_Detail_BudingName,OfficeAutomation_Document_ReduceComm_Detail_TotalReduce,OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney)");
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ReduceComm_Detail_ID,@OfficeAutomation_Document_ReduceComm_Detail_MainID,@OfficeAutomation_Document_ReduceComm_Detail_DealDate,@OfficeAutomation_Document_ReduceComm_Detail_DealDepartment,@OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice,@OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice,@OfficeAutomation_Document_ReduceComm_Detail_CommPoint,@OfficeAutomation_Document_ReduceComm_Detail_OriginalComm,@OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus,@OfficeAutomation_Document_ReduceComm_Detail_ReduceComm,@OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint,@OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint,@OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm,@OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm,@OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus,@OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus,@OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm,@OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm,@OfficeAutomation_Document_ReduceComm_Detail_KSa,@OfficeAutomation_Document_ReduceComm_Detail_KSb,@OfficeAutomation_Document_ReduceComm_Detail_KSc,@OfficeAutomation_Document_ReduceComm_Detail_KSd,@OfficeAutomation_Document_ReduceComm_Detail_BudingName,@OfficeAutomation_Document_ReduceComm_Detail_TotalReduce,@OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney)");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_DealDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_DealDepartment", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_OriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ReduceComm", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_KSa", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_KSb", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_KSc", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_KSd", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_BudingName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_TotalReduce", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney", SqlDbType.NVarChar,80)};
			parameters[0].Value = model.OfficeAutomation_Document_ReduceComm_Detail_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ReduceComm_Detail_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_ReduceComm_Detail_DealDate;
			parameters[3].Value = model.OfficeAutomation_Document_ReduceComm_Detail_DealDepartment;
			parameters[4].Value = model.OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice;
			parameters[5].Value = model.OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice;
			parameters[6].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CommPoint;
			parameters[7].Value = model.OfficeAutomation_Document_ReduceComm_Detail_OriginalComm;
			parameters[8].Value = model.OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus;
			parameters[9].Value = model.OfficeAutomation_Document_ReduceComm_Detail_ReduceComm;

			parameters[10].Value = model.OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint;
			parameters[11].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint;
			parameters[12].Value = model.OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm;
			parameters[13].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm;
			parameters[14].Value = model.OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus;
			parameters[15].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus;
			parameters[16].Value = model.OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm;
            parameters[17].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm;
            parameters[18].Value = model.OfficeAutomation_Document_ReduceComm_Detail_KSa;
            parameters[19].Value = model.OfficeAutomation_Document_ReduceComm_Detail_KSb;
            parameters[20].Value = model.OfficeAutomation_Document_ReduceComm_Detail_KSc;
            parameters[21].Value = model.OfficeAutomation_Document_ReduceComm_Detail_KSd;

            parameters[22].Value = model.OfficeAutomation_Document_ReduceComm_Detail_BudingName;
			parameters[23].Value = model.OfficeAutomation_Document_ReduceComm_Detail_TotalReduce;
			parameters[24].Value = model.OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney;

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
		public bool Update(DataEntity.T_OfficeAutomation_Document_ReduceComm_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ReduceComm_Detail set ");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_MainID=@OfficeAutomation_Document_ReduceComm_Detail_MainID,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_DealDate=@OfficeAutomation_Document_ReduceComm_Detail_DealDate,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_DealDepartment=@OfficeAutomation_Document_ReduceComm_Detail_DealDepartment,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice=@OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice=@OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_CommPoint=@OfficeAutomation_Document_ReduceComm_Detail_CommPoint,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_OriginalComm=@OfficeAutomation_Document_ReduceComm_Detail_OriginalComm,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus=@OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_ReduceComm=@OfficeAutomation_Document_ReduceComm_Detail_ReduceComm,");

            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint=@OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint=@OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm=@OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm=@OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus=@OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus=@OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm=@OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm=@OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_KSa=@OfficeAutomation_Document_ReduceComm_Detail_KSa,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_KSb=@OfficeAutomation_Document_ReduceComm_Detail_KSb,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_KSc=@OfficeAutomation_Document_ReduceComm_Detail_KSc,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_KSd=@OfficeAutomation_Document_ReduceComm_Detail_KSd,");

            strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_BudingName=@OfficeAutomation_Document_ReduceComm_Detail_BudingName,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_TotalReduce=@OfficeAutomation_Document_ReduceComm_Detail_TotalReduce,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney=@OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney");
			strSql.Append(" where OfficeAutomation_Document_ReduceComm_Detail_ID=@OfficeAutomation_Document_ReduceComm_Detail_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_DealDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_DealDepartment", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_OriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ReduceComm", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_KSa", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_KSb", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_KSc", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_KSd", SqlDbType.NVarChar,80),

                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_BudingName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_TotalReduce", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ID", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.OfficeAutomation_Document_ReduceComm_Detail_MainID;
			parameters[1].Value = model.OfficeAutomation_Document_ReduceComm_Detail_DealDate;
			parameters[2].Value = model.OfficeAutomation_Document_ReduceComm_Detail_DealDepartment;
			parameters[3].Value = model.OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice;
			parameters[4].Value = model.OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice;
			parameters[5].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CommPoint;
			parameters[6].Value = model.OfficeAutomation_Document_ReduceComm_Detail_OriginalComm;
			parameters[7].Value = model.OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus;
			parameters[8].Value = model.OfficeAutomation_Document_ReduceComm_Detail_ReduceComm;

			parameters[9].Value = model.OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint;
			parameters[10].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint;
			parameters[11].Value = model.OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm;
			parameters[12].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm;
			parameters[13].Value = model.OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus;
			parameters[14].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus;
			parameters[15].Value = model.OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm;
            parameters[16].Value = model.OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm;
            parameters[17].Value = model.OfficeAutomation_Document_ReduceComm_Detail_KSa;
            parameters[18].Value = model.OfficeAutomation_Document_ReduceComm_Detail_KSb;
            parameters[19].Value = model.OfficeAutomation_Document_ReduceComm_Detail_KSc;
            parameters[20].Value = model.OfficeAutomation_Document_ReduceComm_Detail_KSd;

            parameters[21].Value = model.OfficeAutomation_Document_ReduceComm_Detail_BudingName;
			parameters[22].Value = model.OfficeAutomation_Document_ReduceComm_Detail_TotalReduce;
			parameters[23].Value = model.OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney;
			parameters[24].Value = model.OfficeAutomation_Document_ReduceComm_Detail_ID;

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
        /// <param name="OfficeAutomation_Document_ReduceComm_Detail_MainID">申请表ID</param>
        /// <returns></returns>
        public bool Delete(Guid OfficeAutomation_Document_ReduceComm_Detail_MainID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ReduceComm_Detail ");
            strSql.Append(" where OfficeAutomation_Document_ReduceComm_Detail_MainID=@OfficeAutomation_Document_ReduceComm_Detail_MainID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_MainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = OfficeAutomation_Document_ReduceComm_Detail_MainID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string OfficeAutomation_Document_ReduceComm_Detail_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ReduceComm_Detail ");
			strSql.Append(" where OfficeAutomation_Document_ReduceComm_Detail_ID in ("+OfficeAutomation_Document_ReduceComm_Detail_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_ReduceComm_Detail GetModel(Guid OfficeAutomation_Document_ReduceComm_Detail_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_ReduceComm_Detail_ID,OfficeAutomation_Document_ReduceComm_Detail_MainID,OfficeAutomation_Document_ReduceComm_Detail_DealDate,OfficeAutomation_Document_ReduceComm_Detail_DealDepartment,OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice,OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice,OfficeAutomation_Document_ReduceComm_Detail_CommPoint,OfficeAutomation_Document_ReduceComm_Detail_OriginalComm,OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_ReduceComm,OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint,OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint,OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm,OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm,OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm,OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm,OfficeAutomation_Document_ReduceComm_Detail_KSa,OfficeAutomation_Document_ReduceComm_Detail_KSb,OfficeAutomation_Document_ReduceComm_Detail_KSc,OfficeAutomation_Document_ReduceComm_Detail_KSd,OfficeAutomation_Document_ReduceComm_Detail_BudingName,OfficeAutomation_Document_ReduceComm_Detail_TotalReduce,OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney from t_OfficeAutomation_Document_ReduceComm_Detail ");
			strSql.Append(" where OfficeAutomation_Document_ReduceComm_Detail_ID=@OfficeAutomation_Document_ReduceComm_Detail_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Detail_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ReduceComm_Detail_ID;

			DataEntity.T_OfficeAutomation_Document_ReduceComm_Detail model=new DataEntity.T_OfficeAutomation_Document_ReduceComm_Detail();
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
		public DataEntity.T_OfficeAutomation_Document_ReduceComm_Detail DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_ReduceComm_Detail model=new DataEntity.T_OfficeAutomation_Document_ReduceComm_Detail();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_ReduceComm_Detail_ID"]!=null && row["OfficeAutomation_Document_ReduceComm_Detail_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_ID= new Guid(row["OfficeAutomation_Document_ReduceComm_Detail_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_MainID"]!=null && row["OfficeAutomation_Document_ReduceComm_Detail_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_MainID= new Guid(row["OfficeAutomation_Document_ReduceComm_Detail_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_DealDate"]!=null && row["OfficeAutomation_Document_ReduceComm_Detail_DealDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_DealDate=DateTime.Parse(row["OfficeAutomation_Document_ReduceComm_Detail_DealDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_DealDepartment"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_DealDepartment=row["OfficeAutomation_Document_ReduceComm_Detail_DealDepartment"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice=row["OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice=row["OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_CommPoint"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_CommPoint=row["OfficeAutomation_Document_ReduceComm_Detail_CommPoint"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_OriginalComm"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_OriginalComm=row["OfficeAutomation_Document_ReduceComm_Detail_OriginalComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus=row["OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_ReduceComm"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_ReduceComm=row["OfficeAutomation_Document_ReduceComm_Detail_ReduceComm"].ToString();
				}

                if (row["OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint = row["OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint = row["OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm = row["OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm = row["OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus = row["OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus = row["OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm = row["OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm = row["OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_KSa"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_KSa = row["OfficeAutomation_Document_ReduceComm_Detail_KSa"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_KSb"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_KSb = row["OfficeAutomation_Document_ReduceComm_Detail_KSb"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_KSc"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_KSc = row["OfficeAutomation_Document_ReduceComm_Detail_KSc"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_KSd"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_KSd = row["OfficeAutomation_Document_ReduceComm_Detail_KSd"].ToString();
                }
                if (row["OfficeAutomation_Document_ReduceComm_Detail_BudingName"] != null)
                {
                    model.OfficeAutomation_Document_ReduceComm_Detail_BudingName = row["OfficeAutomation_Document_ReduceComm_Detail_BudingName"].ToString();
                }

				if(row["OfficeAutomation_Document_ReduceComm_Detail_TotalReduce"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_TotalReduce=row["OfficeAutomation_Document_ReduceComm_Detail_TotalReduce"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney=row["OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_ReduceComm_Detail_ID,OfficeAutomation_Document_ReduceComm_Detail_MainID,OfficeAutomation_Document_ReduceComm_Detail_DealDate,OfficeAutomation_Document_ReduceComm_Detail_DealDepartment,OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice,OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice,OfficeAutomation_Document_ReduceComm_Detail_CommPoint,OfficeAutomation_Document_ReduceComm_Detail_OriginalComm,OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_ReduceComm,OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint,OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint,OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm,OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm,OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm,OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm,OfficeAutomation_Document_ReduceComm_Detail_KSa,OfficeAutomation_Document_ReduceComm_Detail_KSb,OfficeAutomation_Document_ReduceComm_Detail_KSc,OfficeAutomation_Document_ReduceComm_Detail_KSd,OfficeAutomation_Document_ReduceComm_Detail_BudingName,OfficeAutomation_Document_ReduceComm_Detail_TotalReduce,OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ReduceComm_Detail ");
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
            strSql.Append(" OfficeAutomation_Document_ReduceComm_Detail_ID,OfficeAutomation_Document_ReduceComm_Detail_MainID,OfficeAutomation_Document_ReduceComm_Detail_DealDate,OfficeAutomation_Document_ReduceComm_Detail_DealDepartment,OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice,OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice,OfficeAutomation_Document_ReduceComm_Detail_CommPoint,OfficeAutomation_Document_ReduceComm_Detail_OriginalComm,OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_ReduceComm,OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint,OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint,OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm,OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm,OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus,OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm,OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm,OfficeAutomation_Document_ReduceComm_Detail_KSa,OfficeAutomation_Document_ReduceComm_Detail_KSb,OfficeAutomation_Document_ReduceComm_Detail_KSc,OfficeAutomation_Document_ReduceComm_Detail_KSd,OfficeAutomation_Document_ReduceComm_Detail_BudingName,OfficeAutomation_Document_ReduceComm_Detail_TotalReduce,OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ReduceComm_Detail ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ReduceComm_Detail ");
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
				strSql.Append("order by T.OfficeAutomation_Document_ReduceComm_Detail_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ReduceComm_Detail T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_ReduceComm_Detail";
			parameters[1].Value = "OfficeAutomation_Document_ReduceComm_Detail_ID";
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

