/*
* DA_OfficeAutomation_Document_ReduceComm.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ReduceComm
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
	/// 数据访问类:DA_OfficeAutomation_Document_ReduceComm
	/// </summary>
    public partial class DA_OfficeAutomation_Document_ReduceComm_Operate
	{
        private DAL.DalBase<T_OfficeAutomation_Document_ReduceComm> dal;
		public DA_OfficeAutomation_Document_ReduceComm_Operate()
		{
            dal = new DAL.DalBase<T_OfficeAutomation_Document_ReduceComm>();
        }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ReduceComm_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ReduceComm");
			strSql.Append(" where OfficeAutomation_Document_ReduceComm_ID=@OfficeAutomation_Document_ReduceComm_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ReduceComm_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ReduceComm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_ReduceComm(");
            strSql.Append("OfficeAutomation_Document_ReduceComm_ID,OfficeAutomation_Document_ReduceComm_MainID,OfficeAutomation_Document_ReduceComm_Apply,OfficeAutomation_Document_ReduceComm_ApplyForName,OfficeAutomation_Document_ReduceComm_ApplyForCode,OfficeAutomation_Document_ReduceComm_ApplyDate,OfficeAutomation_Document_ReduceComm_DepartmentTypeID,OfficeAutomation_Document_ReduceComm_Subject,OfficeAutomation_Document_ReduceComm_Department,OfficeAutomation_Document_ReduceComm_DepartmentID,OfficeAutomation_Document_ReduceComm_ReplyPhone,OfficeAutomation_Document_ReduceComm_Reason,OfficeAutomation_Document_ReduceComm_Remark,OfficeAutomation_Document_ReduceComm_DealDepartment,OfficeAutomation_Document_ReduceComm_OriginalDealPrice,OfficeAutomation_Document_ReduceComm_FinalDealPrice,OfficeAutomation_Document_ReduceComm_CommPoint,OfficeAutomation_Document_ReduceComm_OriginalComm,OfficeAutomation_Document_ReduceComm_ReduceCashBonus,OfficeAutomation_Document_ReduceComm_ReduceComm,OfficeAutomation_Document_ReduceComm_EBCommPoint,OfficeAutomation_Document_ReduceComm_CaCommPoint,OfficeAutomation_Document_ReduceComm_EBOriginalComm,OfficeAutomation_Document_ReduceComm_CaOriginalComm,OfficeAutomation_Document_ReduceComm_EBReduceCashBonus,OfficeAutomation_Document_ReduceComm_CaReduceCashBonus,OfficeAutomation_Document_ReduceComm_EBReduceComm,OfficeAutomation_Document_ReduceComm_CaReduceComm,OfficeAutomation_Document_ReduceComm_KSa,OfficeAutomation_Document_ReduceComm_KSb,OfficeAutomation_Document_ReduceComm_KSc,OfficeAutomation_Document_ReduceComm_KSd,OfficeAutomation_Document_ReduceComm_TotalReduce,OfficeAutomation_Document_ReduceComm_ActualReportMoney,OfficeAutomation_Document_ReduceComm_ReduceWay,OfficeAutomation_Document_ReduceComm_Type)");
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ReduceComm_ID,@OfficeAutomation_Document_ReduceComm_MainID,@OfficeAutomation_Document_ReduceComm_Apply,@OfficeAutomation_Document_ReduceComm_ApplyForName,@OfficeAutomation_Document_ReduceComm_ApplyForCode,@OfficeAutomation_Document_ReduceComm_ApplyDate,@OfficeAutomation_Document_ReduceComm_DepartmentTypeID,@OfficeAutomation_Document_ReduceComm_Subject,@OfficeAutomation_Document_ReduceComm_Department,@OfficeAutomation_Document_ReduceComm_DepartmentID,@OfficeAutomation_Document_ReduceComm_ReplyPhone,@OfficeAutomation_Document_ReduceComm_Reason,@OfficeAutomation_Document_ReduceComm_Remark,@OfficeAutomation_Document_ReduceComm_DealDepartment,@OfficeAutomation_Document_ReduceComm_OriginalDealPrice,@OfficeAutomation_Document_ReduceComm_FinalDealPrice,@OfficeAutomation_Document_ReduceComm_CommPoint,@OfficeAutomation_Document_ReduceComm_OriginalComm,@OfficeAutomation_Document_ReduceComm_ReduceCashBonus,@OfficeAutomation_Document_ReduceComm_ReduceComm,@OfficeAutomation_Document_ReduceComm_EBCommPoint,@OfficeAutomation_Document_ReduceComm_CaCommPoint,@OfficeAutomation_Document_ReduceComm_EBOriginalComm,@OfficeAutomation_Document_ReduceComm_CaOriginalComm,@OfficeAutomation_Document_ReduceComm_EBReduceCashBonus,@OfficeAutomation_Document_ReduceComm_CaReduceCashBonus,@OfficeAutomation_Document_ReduceComm_EBReduceComm,@OfficeAutomation_Document_ReduceComm_CaReduceComm,@OfficeAutomation_Document_ReduceComm_KSa,@OfficeAutomation_Document_ReduceComm_KSb,@OfficeAutomation_Document_ReduceComm_KSc,@OfficeAutomation_Document_ReduceComm_KSd,@OfficeAutomation_Document_ReduceComm_TotalReduce,@OfficeAutomation_Document_ReduceComm_ActualReportMoney,@OfficeAutomation_Document_ReduceComm_ReduceWay,@OfficeAutomation_Document_ReduceComm_Type)");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ApplyForCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Subject", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_DepartmentID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Reason", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_DealDepartment", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_OriginalDealPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_FinalDealPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_OriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ReduceComm", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ReduceComm_EBCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CaCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_EBOriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CaOriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_EBReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CaReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_EBReduceComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CaReduceComm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_KSa", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_KSb", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_KSc", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_KSd", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ReduceComm_TotalReduce", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ActualReportMoney", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_ReduceWay", SqlDbType.NVarChar,80),//,
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_Type", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.OfficeAutomation_Document_ReduceComm_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ReduceComm_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_ReduceComm_Apply;
			parameters[3].Value = model.OfficeAutomation_Document_ReduceComm_ApplyForName;
			parameters[4].Value = model.OfficeAutomation_Document_ReduceComm_ApplyForCode;
			parameters[5].Value = model.OfficeAutomation_Document_ReduceComm_ApplyDate;
			parameters[6].Value = model.OfficeAutomation_Document_ReduceComm_DepartmentTypeID;
			parameters[7].Value = model.OfficeAutomation_Document_ReduceComm_Subject;
			parameters[8].Value = model.OfficeAutomation_Document_ReduceComm_Department;
            parameters[9].Value = model.OfficeAutomation_Document_ReduceComm_DepartmentID;
			parameters[10].Value = model.OfficeAutomation_Document_ReduceComm_ReplyPhone;
			parameters[11].Value = model.OfficeAutomation_Document_ReduceComm_Reason;
			parameters[12].Value = model.OfficeAutomation_Document_ReduceComm_Remark;
            parameters[13].Value = model.OfficeAutomation_Document_ReduceComm_DealDepartment;
            parameters[14].Value = model.OfficeAutomation_Document_ReduceComm_OriginalDealPrice;
            parameters[15].Value = model.OfficeAutomation_Document_ReduceComm_FinalDealPrice;
            parameters[16].Value = model.OfficeAutomation_Document_ReduceComm_CommPoint;
            parameters[17].Value = model.OfficeAutomation_Document_ReduceComm_OriginalComm;
            parameters[18].Value = model.OfficeAutomation_Document_ReduceComm_ReduceCashBonus;
            parameters[19].Value = model.OfficeAutomation_Document_ReduceComm_ReduceComm;

            parameters[20].Value = model.OfficeAutomation_Document_ReduceComm_EBCommPoint;
            parameters[21].Value = model.OfficeAutomation_Document_ReduceComm_CaCommPoint;
            parameters[22].Value = model.OfficeAutomation_Document_ReduceComm_EBOriginalComm;
            parameters[23].Value = model.OfficeAutomation_Document_ReduceComm_CaOriginalComm;
            parameters[24].Value = model.OfficeAutomation_Document_ReduceComm_EBReduceCashBonus;
            parameters[25].Value = model.OfficeAutomation_Document_ReduceComm_CaReduceCashBonus;
            parameters[26].Value = model.OfficeAutomation_Document_ReduceComm_EBReduceComm;
            parameters[27].Value = model.OfficeAutomation_Document_ReduceComm_CaReduceComm;
            parameters[28].Value = model.OfficeAutomation_Document_ReduceComm_KSa;
            parameters[29].Value = model.OfficeAutomation_Document_ReduceComm_KSb;
            parameters[30].Value = model.OfficeAutomation_Document_ReduceComm_KSc;
            parameters[31].Value = model.OfficeAutomation_Document_ReduceComm_KSd;

            parameters[32].Value = model.OfficeAutomation_Document_ReduceComm_TotalReduce;
            parameters[33].Value = model.OfficeAutomation_Document_ReduceComm_ActualReportMoney;
            parameters[34].Value = model.OfficeAutomation_Document_ReduceComm_ReduceWay;
            parameters[35].Value = model.OfficeAutomation_Document_ReduceComm_Type;
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
		public bool Update(DataEntity.T_OfficeAutomation_Document_ReduceComm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ReduceComm set ");
			//strSql.Append("OfficeAutomation_Document_ReduceComm_MainID=@OfficeAutomation_Document_ReduceComm_MainID,");
			//strSql.Append("OfficeAutomation_Document_ReduceComm_Apply=@OfficeAutomation_Document_ReduceComm_Apply,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_ApplyForName=@OfficeAutomation_Document_ReduceComm_ApplyForName,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_ApplyForCode=@OfficeAutomation_Document_ReduceComm_ApplyForCode,");
			//strSql.Append("OfficeAutomation_Document_ReduceComm_ApplyDate=@OfficeAutomation_Document_ReduceComm_ApplyDate,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_DepartmentTypeID=@OfficeAutomation_Document_ReduceComm_DepartmentTypeID,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Subject=@OfficeAutomation_Document_ReduceComm_Subject,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Department=@OfficeAutomation_Document_ReduceComm_Department,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_DepartmentID=@OfficeAutomation_Document_ReduceComm_DepartmentID,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_ReplyPhone=@OfficeAutomation_Document_ReduceComm_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_ReduceComm_Reason=@OfficeAutomation_Document_ReduceComm_Reason,");
            //strSql.Append("OfficeAutomation_Document_ReduceComm_Remark=@OfficeAutomation_Document_ReduceComm_Remark");
            strSql.Append("OfficeAutomation_Document_ReduceComm_DealDepartment=@OfficeAutomation_Document_ReduceComm_DealDepartment,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_OriginalDealPrice=@OfficeAutomation_Document_ReduceComm_OriginalDealPrice,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_FinalDealPrice=@OfficeAutomation_Document_ReduceComm_FinalDealPrice,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_CommPoint=@OfficeAutomation_Document_ReduceComm_CommPoint,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_OriginalComm=@OfficeAutomation_Document_ReduceComm_OriginalComm,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_ReduceCashBonus=@OfficeAutomation_Document_ReduceComm_ReduceCashBonus,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_ReduceComm=@OfficeAutomation_Document_ReduceComm_ReduceComm,");

            strSql.Append("OfficeAutomation_Document_ReduceComm_EBCommPoint=@OfficeAutomation_Document_ReduceComm_EBCommPoint,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_CaCommPoint=@OfficeAutomation_Document_ReduceComm_CaCommPoint,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_EBOriginalComm=@OfficeAutomation_Document_ReduceComm_EBOriginalComm,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_CaOriginalComm=@OfficeAutomation_Document_ReduceComm_CaOriginalComm,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_EBReduceCashBonus=@OfficeAutomation_Document_ReduceComm_EBReduceCashBonus,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_CaReduceCashBonus=@OfficeAutomation_Document_ReduceComm_CaReduceCashBonus,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_EBReduceComm=@OfficeAutomation_Document_ReduceComm_EBReduceComm,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_CaReduceComm=@OfficeAutomation_Document_ReduceComm_CaReduceComm,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_KSa=@OfficeAutomation_Document_ReduceComm_KSa,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_KSb=@OfficeAutomation_Document_ReduceComm_KSb,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_KSc=@OfficeAutomation_Document_ReduceComm_KSc,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_KSd=@OfficeAutomation_Document_ReduceComm_KSd,");

            strSql.Append("OfficeAutomation_Document_ReduceComm_TotalReduce=@OfficeAutomation_Document_ReduceComm_TotalReduce,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_ActualReportMoney=@OfficeAutomation_Document_ReduceComm_ActualReportMoney,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_ReduceWay=@OfficeAutomation_Document_ReduceComm_ReduceWay,");
            strSql.Append("OfficeAutomation_Document_ReduceComm_Type=@OfficeAutomation_Document_ReduceComm_Type");
			strSql.Append(" where OfficeAutomation_Document_ReduceComm_ID=@OfficeAutomation_Document_ReduceComm_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ReduceComm_MainID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_ReduceComm_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ApplyForCode", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ReduceComm_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Subject", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_DepartmentID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_Reason", SqlDbType.NVarChar,-1),
					//new SqlParameter("@OfficeAutomation_Document_ReduceComm_Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_DealDepartment", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_OriginalDealPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_FinalDealPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_OriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ReduceComm", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ReduceComm_EBCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CaCommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_EBOriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CaOriginalComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_EBReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CaReduceCashBonus", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_EBReduceComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_CaReduceComm", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_KSa", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_KSb", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_KSc", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_KSd", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_ReduceComm_TotalReduce", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ActualReportMoney", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_ReduceComm_ReduceWay", SqlDbType.NVarChar,80),
                      new SqlParameter("@OfficeAutomation_Document_ReduceComm_Type", SqlDbType.NVarChar,30),
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_ReduceComm_MainID;
			//parameters[1].Value = model.OfficeAutomation_Document_ReduceComm_Apply;
			parameters[0].Value = model.OfficeAutomation_Document_ReduceComm_ApplyForName;
			parameters[1].Value = model.OfficeAutomation_Document_ReduceComm_ApplyForCode;
			//parameters[4].Value = model.OfficeAutomation_Document_ReduceComm_ApplyDate;
			parameters[2].Value = model.OfficeAutomation_Document_ReduceComm_DepartmentTypeID;
			parameters[3].Value = model.OfficeAutomation_Document_ReduceComm_Subject;
			parameters[4].Value = model.OfficeAutomation_Document_ReduceComm_Department;
			parameters[5].Value = model.OfficeAutomation_Document_ReduceComm_DepartmentID;
			parameters[6].Value = model.OfficeAutomation_Document_ReduceComm_ReplyPhone;
			parameters[7].Value = model.OfficeAutomation_Document_ReduceComm_Reason;
            //parameters[11].Value = model.OfficeAutomation_Document_ReduceComm_Remark;
            parameters[8].Value = model.OfficeAutomation_Document_ReduceComm_DealDepartment;
            parameters[9].Value = model.OfficeAutomation_Document_ReduceComm_OriginalDealPrice;
            parameters[10].Value = model.OfficeAutomation_Document_ReduceComm_FinalDealPrice;
            parameters[11].Value = model.OfficeAutomation_Document_ReduceComm_CommPoint;
            parameters[12].Value = model.OfficeAutomation_Document_ReduceComm_OriginalComm;
            parameters[13].Value = model.OfficeAutomation_Document_ReduceComm_ReduceCashBonus;
            parameters[14].Value = model.OfficeAutomation_Document_ReduceComm_ReduceComm;

            parameters[15].Value = model.OfficeAutomation_Document_ReduceComm_EBCommPoint;
            parameters[16].Value = model.OfficeAutomation_Document_ReduceComm_CaCommPoint;
            parameters[17].Value = model.OfficeAutomation_Document_ReduceComm_EBOriginalComm;
            parameters[18].Value = model.OfficeAutomation_Document_ReduceComm_CaOriginalComm;
            parameters[19].Value = model.OfficeAutomation_Document_ReduceComm_EBReduceCashBonus;
            parameters[20].Value = model.OfficeAutomation_Document_ReduceComm_CaReduceCashBonus;
            parameters[21].Value = model.OfficeAutomation_Document_ReduceComm_EBReduceComm;
            parameters[22].Value = model.OfficeAutomation_Document_ReduceComm_CaReduceComm;
            parameters[23].Value = model.OfficeAutomation_Document_ReduceComm_KSa;
            parameters[24].Value = model.OfficeAutomation_Document_ReduceComm_KSb;
            parameters[25].Value = model.OfficeAutomation_Document_ReduceComm_KSc;
            parameters[26].Value = model.OfficeAutomation_Document_ReduceComm_KSd;

            parameters[27].Value = model.OfficeAutomation_Document_ReduceComm_TotalReduce;
            parameters[28].Value = model.OfficeAutomation_Document_ReduceComm_ActualReportMoney;
            parameters[29].Value = model.OfficeAutomation_Document_ReduceComm_ReduceWay;
            parameters[30].Value = model.OfficeAutomation_Document_ReduceComm_Type;
			parameters[31].Value = model.OfficeAutomation_Document_ReduceComm_ID;

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
		public bool Delete(string OfficeAutomation_Document_ReduceComm_ID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("dbo.[pr_ReduceComm_Delete]");
			SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ReduceComm_ID);

            int rows;
            DbHelperSQL.RunProcedure(strSql.ToString(), parameters,out rows);
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
		public bool DeleteList(string OfficeAutomation_Document_ReduceComm_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ReduceComm ");
			strSql.Append(" where OfficeAutomation_Document_ReduceComm_ID in ("+OfficeAutomation_Document_ReduceComm_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_ReduceComm GetModel(Guid OfficeAutomation_Document_ReduceComm_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OfficeAutomation_Document_ReduceComm_ID,OfficeAutomation_Document_ReduceComm_MainID,OfficeAutomation_Document_ReduceComm_Apply,OfficeAutomation_Document_ReduceComm_ApplyForName,OfficeAutomation_Document_ReduceComm_ApplyForCode,OfficeAutomation_Document_ReduceComm_ApplyDate,OfficeAutomation_Document_ReduceComm_DepartmentTypeID,OfficeAutomation_Document_ReduceComm_Subject,OfficeAutomation_Document_ReduceComm_Department,OfficeAutomation_Document_ReduceComm_DepartmentID,OfficeAutomation_Document_ReduceComm_ReplyPhone,OfficeAutomation_Document_ReduceComm_Reason,OfficeAutomation_Document_ReduceComm_Remark from t_OfficeAutomation_Document_ReduceComm ");
			strSql.Append(" where OfficeAutomation_Document_ReduceComm_ID=@OfficeAutomation_Document_ReduceComm_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ReduceComm_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ReduceComm_ID;

			DataEntity.T_OfficeAutomation_Document_ReduceComm model=new DataEntity.T_OfficeAutomation_Document_ReduceComm();
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
		public DataEntity.T_OfficeAutomation_Document_ReduceComm DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_ReduceComm model=new DataEntity.T_OfficeAutomation_Document_ReduceComm();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_ReduceComm_ID"]!=null && row["OfficeAutomation_Document_ReduceComm_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ReduceComm_ID= new Guid(row["OfficeAutomation_Document_ReduceComm_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_ReduceComm_MainID"]!=null && row["OfficeAutomation_Document_ReduceComm_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ReduceComm_MainID= new Guid(row["OfficeAutomation_Document_ReduceComm_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_ReduceComm_Apply"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Apply=row["OfficeAutomation_Document_ReduceComm_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_ApplyForName"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_ApplyForName=row["OfficeAutomation_Document_ReduceComm_ApplyForName"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_ApplyForCode"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_ApplyForCode=row["OfficeAutomation_Document_ReduceComm_ApplyForCode"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_ApplyDate"]!=null && row["OfficeAutomation_Document_ReduceComm_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ReduceComm_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_ReduceComm_ApplyDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ReduceComm_DepartmentTypeID"]!=null && row["OfficeAutomation_Document_ReduceComm_DepartmentTypeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ReduceComm_DepartmentTypeID=int.Parse(row["OfficeAutomation_Document_ReduceComm_DepartmentTypeID"].ToString());
				}
				if(row["OfficeAutomation_Document_ReduceComm_Subject"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Subject=row["OfficeAutomation_Document_ReduceComm_Subject"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Department"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Department=row["OfficeAutomation_Document_ReduceComm_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_DepartmentID"]!=null && row["OfficeAutomation_Document_ReduceComm_DepartmentID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ReduceComm_DepartmentID= new Guid(row["OfficeAutomation_Document_ReduceComm_DepartmentID"].ToString());
				}
				if(row["OfficeAutomation_Document_ReduceComm_ReplyPhone"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_ReplyPhone=row["OfficeAutomation_Document_ReduceComm_ReplyPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Reason"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Reason=row["OfficeAutomation_Document_ReduceComm_Reason"].ToString();
				}
				if(row["OfficeAutomation_Document_ReduceComm_Remark"]!=null)
				{
					model.OfficeAutomation_Document_ReduceComm_Remark=row["OfficeAutomation_Document_ReduceComm_Remark"].ToString();
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
			strSql.Append("select OfficeAutomation_Document_ReduceComm_ID,OfficeAutomation_Document_ReduceComm_MainID,OfficeAutomation_Document_ReduceComm_Apply,OfficeAutomation_Document_ReduceComm_ApplyForName,OfficeAutomation_Document_ReduceComm_ApplyForCode,OfficeAutomation_Document_ReduceComm_ApplyDate,OfficeAutomation_Document_ReduceComm_DepartmentTypeID,OfficeAutomation_Document_ReduceComm_Subject,OfficeAutomation_Document_ReduceComm_Department,OfficeAutomation_Document_ReduceComm_DepartmentID,OfficeAutomation_Document_ReduceComm_ReplyPhone,OfficeAutomation_Document_ReduceComm_Reason,OfficeAutomation_Document_ReduceComm_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ReduceComm ");
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
			strSql.Append(" OfficeAutomation_Document_ReduceComm_ID,OfficeAutomation_Document_ReduceComm_MainID,OfficeAutomation_Document_ReduceComm_Apply,OfficeAutomation_Document_ReduceComm_ApplyForName,OfficeAutomation_Document_ReduceComm_ApplyForCode,OfficeAutomation_Document_ReduceComm_ApplyDate,OfficeAutomation_Document_ReduceComm_DepartmentTypeID,OfficeAutomation_Document_ReduceComm_Subject,OfficeAutomation_Document_ReduceComm_Department,OfficeAutomation_Document_ReduceComm_DepartmentID,OfficeAutomation_Document_ReduceComm_ReplyPhone,OfficeAutomation_Document_ReduceComm_Reason,OfficeAutomation_Document_ReduceComm_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ReduceComm ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ReduceComm ");
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
				strSql.Append("order by T.OfficeAutomation_Document_ReduceComm_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ReduceComm T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_ReduceComm";
			parameters[1].Value = "OfficeAutomation_Document_ReduceComm_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public T_OfficeAutomation_Document_ReduceComm TemAdd(T_OfficeAutomation_Document_ReduceComm t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_ReduceComm TemEdit(T_OfficeAutomation_Document_ReduceComm t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_ReduceComm t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_ReduceComm GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_ReduceComm>(where);
        }
		#endregion  ExtensionMethod
	}
}

