/*
* DA_OfficeAutomation_Document_WithdrawShop_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_WithdrawShop_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/16 14:32:39    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_WithdrawShop_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_WithdrawShop_Operate
	{
        private DAL.DalBase<T_OfficeAutomation_Document_WithdrawShop> dal;
		public DA_OfficeAutomation_Document_WithdrawShop_Operate()
		{
            dal = new DAL.DalBase<T_OfficeAutomation_Document_WithdrawShop>();
        }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_WithdrawShop_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_WithdrawShop");
			strSql.Append(" where OfficeAutomation_Document_WithdrawShop_ID=@OfficeAutomation_Document_WithdrawShop_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_WithdrawShop_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        #region 获得分行最新流水号
        /// <summary>
        /// 获得分行最新流水号
        /// </summary>
        /// <param name="department"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetNewSerialNum(string department, string date)
        {
            date = DateTime.Parse(date).ToString("yyyyMMdd");
            string prefix = department + "-" + date + "-";
            string result = prefix + "01";
            string sSql = "select top 1 OfficeAutomation_Document_WithdrawShop_ApplyID from t_OfficeAutomation_Document_WithdrawShop where OfficeAutomation_Document_WithdrawShop_ApplyID like '" + prefix + "%' order by OfficeAutomation_Document_WithdrawShop_ApplyDate desc";

            DataSet ds = DbHelperSQL.Query(sSql);

            if (!(ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0))
            {
                int newnum = int.Parse(ds.Tables[0].Rows[0][0].ToString().Substring(prefix.Length)) + 1;
                result = prefix + newnum.ToString().PadLeft(2, '0');
            }

            return result;
        }
        #endregion

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_WithdrawShop model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_WithdrawShop(");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_ID,OfficeAutomation_Document_WithdrawShop_MainID,OfficeAutomation_Document_WithdrawShop_Apply,OfficeAutomation_Document_WithdrawShop_ApplyID,OfficeAutomation_Document_WithdrawShop_ApplyDate,OfficeAutomation_Document_WithdrawShop_Department,OfficeAutomation_Document_WithdrawShop_ReplyPhone,OfficeAutomation_Document_WithdrawShop_ReplyFax,OfficeAutomation_Document_WithdrawShop_ApplyTypeID,OfficeAutomation_Document_WithdrawShop_DepartmentTypeID,OfficeAutomation_Document_WithdrawShop_MajordomoID,OfficeAutomation_Document_WithdrawShop_DepartmentName,OfficeAutomation_Document_WithdrawShop_DepartmentAddress,OfficeAutomation_Document_WithdrawShop_ExpireDate,OfficeAutomation_Document_WithdrawShop_PlanDate,OfficeAutomation_Document_WithdrawShop_Reason,OfficeAutomation_Document_WithdrawShop_AssetHandleIDs,OfficeAutomation_Document_WithdrawShop_AssetHandleOther,OfficeAutomation_Document_WithdrawShop_PhoneHandleID,OfficeAutomation_Document_WithdrawShop_IsFlyLine,OfficeAutomation_Document_WithdrawShop_FlyLineFrom,OfficeAutomation_Document_WithdrawShop_FlyLineTo,OfficeAutomation_Document_WithdrawShop_CanBackDeposit,OfficeAutomation_Document_WithdrawShop_BackDeposit,OfficeAutomation_Document_WithdrawShop_Deposit,OfficeAutomation_Document_WithdrawShop_NoBackDeposit,OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages,OfficeAutomation_Document_WithdrawShop_LiquidatedDamages,OfficeAutomation_Document_WithdrawShop_A1,OfficeAutomation_Document_WithdrawShop_A2,OfficeAutomation_Document_WithdrawShop_A3,OfficeAutomation_Document_WithdrawShop_B1,OfficeAutomation_Document_WithdrawShop_B2,OfficeAutomation_Document_WithdrawShop_B3,OfficeAutomation_Document_WithdrawShop_C1,OfficeAutomation_Document_WithdrawShop_C2,OfficeAutomation_Document_WithdrawShop_C3,OfficeAutomation_Document_WithdrawShop_D1,OfficeAutomation_Document_WithdrawShop_E1,OfficeAutomation_Document_WithdrawShop_E2,OfficeAutomation_Document_WithdrawShop_E3,OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate,OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining,OfficeAutomation_Document_WithdrawShop_Remark,OfficeAutomation_Document_WithdrawShop_StartDate,OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance,OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining,OfficeAutomation_Document_WithdrawShop_AreaLastYear,OfficeAutomation_Document_WithdrawShop_AreaLastYearResults,OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit,OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate,OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate,OfficeAutomation_Document_WithdrawShop_AreaThisYResults,OfficeAutomation_Document_WithdrawShop_AreaThisYProfit,OfficeAutomation_Document_WithdrawShop_BranchLastYear,OfficeAutomation_Document_WithdrawShop_BranchLastYResults,OfficeAutomation_Document_WithdrawShop_BranchLastYProfit,OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate,OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate,OfficeAutomation_Document_WithdrawShop_BranchThisYResults,OfficeAutomation_Document_WithdrawShop_BranchThisYProfit)");
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_WithdrawShop_ID,@OfficeAutomation_Document_WithdrawShop_MainID,@OfficeAutomation_Document_WithdrawShop_Apply,@OfficeAutomation_Document_WithdrawShop_ApplyID,@OfficeAutomation_Document_WithdrawShop_ApplyDate,@OfficeAutomation_Document_WithdrawShop_Department,@OfficeAutomation_Document_WithdrawShop_ReplyPhone,@OfficeAutomation_Document_WithdrawShop_ReplyFax,@OfficeAutomation_Document_WithdrawShop_ApplyTypeID,@OfficeAutomation_Document_WithdrawShop_DepartmentTypeID,@OfficeAutomation_Document_WithdrawShop_MajordomoID,@OfficeAutomation_Document_WithdrawShop_DepartmentName,@OfficeAutomation_Document_WithdrawShop_DepartmentAddress,@OfficeAutomation_Document_WithdrawShop_ExpireDate,@OfficeAutomation_Document_WithdrawShop_PlanDate,@OfficeAutomation_Document_WithdrawShop_Reason,@OfficeAutomation_Document_WithdrawShop_AssetHandleIDs,@OfficeAutomation_Document_WithdrawShop_AssetHandleOther,@OfficeAutomation_Document_WithdrawShop_PhoneHandleID,@OfficeAutomation_Document_WithdrawShop_IsFlyLine,@OfficeAutomation_Document_WithdrawShop_FlyLineFrom,@OfficeAutomation_Document_WithdrawShop_FlyLineTo,@OfficeAutomation_Document_WithdrawShop_CanBackDeposit,@OfficeAutomation_Document_WithdrawShop_BackDeposit,@OfficeAutomation_Document_WithdrawShop_Deposit,@OfficeAutomation_Document_WithdrawShop_NoBackDeposit,@OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages,@OfficeAutomation_Document_WithdrawShop_LiquidatedDamages,@OfficeAutomation_Document_WithdrawShop_A1,@OfficeAutomation_Document_WithdrawShop_A2,@OfficeAutomation_Document_WithdrawShop_A3,@OfficeAutomation_Document_WithdrawShop_B1,@OfficeAutomation_Document_WithdrawShop_B2,@OfficeAutomation_Document_WithdrawShop_B3,@OfficeAutomation_Document_WithdrawShop_C1,@OfficeAutomation_Document_WithdrawShop_C2,@OfficeAutomation_Document_WithdrawShop_C3,@OfficeAutomation_Document_WithdrawShop_D1,@OfficeAutomation_Document_WithdrawShop_E1,@OfficeAutomation_Document_WithdrawShop_E2,@OfficeAutomation_Document_WithdrawShop_E3,@OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate,@OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining,@OfficeAutomation_Document_WithdrawShop_Remark,@OfficeAutomation_Document_WithdrawShop_StartDate,@OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance,@OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining,@OfficeAutomation_Document_WithdrawShop_AreaLastYear,@OfficeAutomation_Document_WithdrawShop_AreaLastYearResults,@OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit,@OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate,@OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate,@OfficeAutomation_Document_WithdrawShop_AreaThisYResults,@OfficeAutomation_Document_WithdrawShop_AreaThisYProfit,@OfficeAutomation_Document_WithdrawShop_BranchLastYear,@OfficeAutomation_Document_WithdrawShop_BranchLastYResults,@OfficeAutomation_Document_WithdrawShop_BranchLastYProfit,@OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate,@OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate,@OfficeAutomation_Document_WithdrawShop_BranchThisYResults,@OfficeAutomation_Document_WithdrawShop_BranchThisYProfit)");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ReplyFax", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ApplyTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_MajordomoID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_DepartmentName", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_DepartmentAddress", SqlDbType.NVarChar,400),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_PlanDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Reason", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AssetHandleIDs", SqlDbType.VarChar,16),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AssetHandleOther", SqlDbType.NVarChar,400),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_PhoneHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_IsFlyLine", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_FlyLineFrom", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_FlyLineTo", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_CanBackDeposit", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BackDeposit", SqlDbType.NVarChar,8),

                    new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Deposit", SqlDbType.NVarChar,8),
                    new SqlParameter("@OfficeAutomation_Document_WithdrawShop_NoBackDeposit", SqlDbType.NVarChar,8),

					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_LiquidatedDamages", SqlDbType.NVarChar,8),

					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_A1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_A2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_A3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_B1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_B2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_B3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_C1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_C2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_C3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_D1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_E1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_E2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_E3", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Remark", SqlDbType.NVarChar,200),
                                        
                                        
                    new SqlParameter("@OfficeAutomation_Document_WithdrawShop_StartDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining", SqlDbType.NVarChar,80),
                    //new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaLastYear", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaLastYearResults", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaThisYResults", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaThisYProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchLastYear", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchLastYResults", SqlDbType.NVarChar,80),                             
                    new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchLastYProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchThisYResults", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchThisYProfit", SqlDbType.NVarChar,80)};
                    


            parameters[0].Value = model.OfficeAutomation_Document_WithdrawShop_ID;
            parameters[1].Value = model.OfficeAutomation_Document_WithdrawShop_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_WithdrawShop_Apply;
            parameters[3].Value = GetNewSerialNum(model.OfficeAutomation_Document_WithdrawShop_Department, DateTime.Now.ToString());
			parameters[4].Value = model.OfficeAutomation_Document_WithdrawShop_ApplyDate;
			parameters[5].Value = model.OfficeAutomation_Document_WithdrawShop_Department;
			parameters[6].Value = model.OfficeAutomation_Document_WithdrawShop_ReplyPhone;
			parameters[7].Value = model.OfficeAutomation_Document_WithdrawShop_ReplyFax;
			parameters[8].Value = model.OfficeAutomation_Document_WithdrawShop_ApplyTypeID;
			parameters[9].Value = model.OfficeAutomation_Document_WithdrawShop_DepartmentTypeID;
			parameters[10].Value = model.OfficeAutomation_Document_WithdrawShop_MajordomoID;
			parameters[11].Value = model.OfficeAutomation_Document_WithdrawShop_DepartmentName;
			parameters[12].Value = model.OfficeAutomation_Document_WithdrawShop_DepartmentAddress;
			parameters[13].Value = model.OfficeAutomation_Document_WithdrawShop_ExpireDate;
			parameters[14].Value = model.OfficeAutomation_Document_WithdrawShop_PlanDate;
			parameters[15].Value = model.OfficeAutomation_Document_WithdrawShop_Reason;
			parameters[16].Value = model.OfficeAutomation_Document_WithdrawShop_AssetHandleIDs;
			parameters[17].Value = model.OfficeAutomation_Document_WithdrawShop_AssetHandleOther;
			parameters[18].Value = model.OfficeAutomation_Document_WithdrawShop_PhoneHandleID;
			parameters[19].Value = model.OfficeAutomation_Document_WithdrawShop_IsFlyLine;
			parameters[20].Value = model.OfficeAutomation_Document_WithdrawShop_FlyLineFrom;
			parameters[21].Value = model.OfficeAutomation_Document_WithdrawShop_FlyLineTo;
			parameters[22].Value = model.OfficeAutomation_Document_WithdrawShop_CanBackDeposit;
			parameters[23].Value = model.OfficeAutomation_Document_WithdrawShop_BackDeposit;

            parameters[24].Value = model.OfficeAutomation_Document_WithdrawShop_Deposit;
            parameters[25].Value = model.OfficeAutomation_Document_WithdrawShop_NoBackDeposit;

			parameters[26].Value = model.OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages;
            parameters[27].Value = model.OfficeAutomation_Document_WithdrawShop_LiquidatedDamages;

            parameters[28].Value = model.OfficeAutomation_Document_WithdrawShop_A1;
            parameters[29].Value = model.OfficeAutomation_Document_WithdrawShop_A2;
            parameters[30].Value = model.OfficeAutomation_Document_WithdrawShop_A3;
            parameters[31].Value = model.OfficeAutomation_Document_WithdrawShop_B1;
            parameters[32].Value = model.OfficeAutomation_Document_WithdrawShop_B2;
            parameters[33].Value = model.OfficeAutomation_Document_WithdrawShop_B3;
            parameters[34].Value = model.OfficeAutomation_Document_WithdrawShop_C1;
            parameters[35].Value = model.OfficeAutomation_Document_WithdrawShop_C2;
            parameters[36].Value = model.OfficeAutomation_Document_WithdrawShop_C3;
            parameters[37].Value = model.OfficeAutomation_Document_WithdrawShop_D1;
            parameters[38].Value = model.OfficeAutomation_Document_WithdrawShop_E1;
            parameters[39].Value = model.OfficeAutomation_Document_WithdrawShop_E2;
            parameters[40].Value = model.OfficeAutomation_Document_WithdrawShop_E3;

            parameters[41].Value = model.OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate;
            parameters[42].Value = model.OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining;
			parameters[43].Value = model.OfficeAutomation_Document_WithdrawShop_Remark;

            parameters[44].Value = model.OfficeAutomation_Document_WithdrawShop_StartDate;
            parameters[45].Value = model.OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance;
            parameters[46].Value = model.OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining;
            parameters[47].Value = model.OfficeAutomation_Document_WithdrawShop_AreaLastYear;
            parameters[48].Value = model.OfficeAutomation_Document_WithdrawShop_AreaLastYearResults;
            parameters[49].Value = model.OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit;
            parameters[50].Value = model.OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate;
            parameters[51].Value = model.OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate;
            parameters[52].Value = model.OfficeAutomation_Document_WithdrawShop_AreaThisYResults;
            parameters[53].Value = model.OfficeAutomation_Document_WithdrawShop_AreaThisYProfit;
            parameters[54].Value = model.OfficeAutomation_Document_WithdrawShop_BranchLastYear;
            parameters[55].Value = model.OfficeAutomation_Document_WithdrawShop_BranchLastYResults;
            parameters[56].Value = model.OfficeAutomation_Document_WithdrawShop_BranchLastYProfit;
            parameters[57].Value = model.OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate;
            parameters[58].Value = model.OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate;
            parameters[59].Value = model.OfficeAutomation_Document_WithdrawShop_BranchThisYResults;
            parameters[60].Value = model.OfficeAutomation_Document_WithdrawShop_BranchThisYProfit;
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
		public bool Update(DataEntity.T_OfficeAutomation_Document_WithdrawShop model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_WithdrawShop set ");
			//strSql.Append("OfficeAutomation_Document_WithdrawShop_MainID=@OfficeAutomation_Document_WithdrawShop_MainID,");
			//strSql.Append("OfficeAutomation_Document_WithdrawShop_Apply=@OfficeAutomation_Document_WithdrawShop_Apply,");
			//strSql.Append("OfficeAutomation_Document_WithdrawShop_ApplyID=@OfficeAutomation_Document_WithdrawShop_ApplyID,");
			//strSql.Append("OfficeAutomation_Document_WithdrawShop_ApplyDate=@OfficeAutomation_Document_WithdrawShop_ApplyDate,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_Department=@OfficeAutomation_Document_WithdrawShop_Department,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_ReplyPhone=@OfficeAutomation_Document_WithdrawShop_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_ReplyFax=@OfficeAutomation_Document_WithdrawShop_ReplyFax,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_ApplyTypeID=@OfficeAutomation_Document_WithdrawShop_ApplyTypeID,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_DepartmentTypeID=@OfficeAutomation_Document_WithdrawShop_DepartmentTypeID,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_MajordomoID=@OfficeAutomation_Document_WithdrawShop_MajordomoID,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_DepartmentName=@OfficeAutomation_Document_WithdrawShop_DepartmentName,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_DepartmentAddress=@OfficeAutomation_Document_WithdrawShop_DepartmentAddress,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_ExpireDate=@OfficeAutomation_Document_WithdrawShop_ExpireDate,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_PlanDate=@OfficeAutomation_Document_WithdrawShop_PlanDate,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_Reason=@OfficeAutomation_Document_WithdrawShop_Reason,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_AssetHandleIDs=@OfficeAutomation_Document_WithdrawShop_AssetHandleIDs,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_AssetHandleOther=@OfficeAutomation_Document_WithdrawShop_AssetHandleOther,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_PhoneHandleID=@OfficeAutomation_Document_WithdrawShop_PhoneHandleID,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_IsFlyLine=@OfficeAutomation_Document_WithdrawShop_IsFlyLine,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_FlyLineFrom=@OfficeAutomation_Document_WithdrawShop_FlyLineFrom,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_FlyLineTo=@OfficeAutomation_Document_WithdrawShop_FlyLineTo,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_CanBackDeposit=@OfficeAutomation_Document_WithdrawShop_CanBackDeposit,");
			strSql.Append("OfficeAutomation_Document_WithdrawShop_BackDeposit=@OfficeAutomation_Document_WithdrawShop_BackDeposit,");

            strSql.Append("OfficeAutomation_Document_WithdrawShop_Deposit=@OfficeAutomation_Document_WithdrawShop_Deposit,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_NoBackDeposit=@OfficeAutomation_Document_WithdrawShop_NoBackDeposit,");

			strSql.Append("OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages=@OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_LiquidatedDamages=@OfficeAutomation_Document_WithdrawShop_LiquidatedDamages,");

            strSql.Append("OfficeAutomation_Document_WithdrawShop_A1=@OfficeAutomation_Document_WithdrawShop_A1,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_A2=@OfficeAutomation_Document_WithdrawShop_A2,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_A3=@OfficeAutomation_Document_WithdrawShop_A3,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_B1=@OfficeAutomation_Document_WithdrawShop_B1,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_B2=@OfficeAutomation_Document_WithdrawShop_B2,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_B3=@OfficeAutomation_Document_WithdrawShop_B3,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_C1=@OfficeAutomation_Document_WithdrawShop_C1,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_C2=@OfficeAutomation_Document_WithdrawShop_C2,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_C3=@OfficeAutomation_Document_WithdrawShop_C3,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_D1=@OfficeAutomation_Document_WithdrawShop_D1,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_E1=@OfficeAutomation_Document_WithdrawShop_E1,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_E2=@OfficeAutomation_Document_WithdrawShop_E2,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_E3=@OfficeAutomation_Document_WithdrawShop_E3,");

            strSql.Append("OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate=@OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining=@OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining,");
			//strSql.Append("OfficeAutomation_Document_WithdrawShop_Remark=@OfficeAutomation_Document_WithdrawShop_Remark");


            strSql.Append("OfficeAutomation_Document_WithdrawShop_StartDate=@OfficeAutomation_Document_WithdrawShop_StartDate,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance=@OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining=@OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining,");
            //strSql.Append("OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate=@OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_AreaLastYear=@OfficeAutomation_Document_WithdrawShop_AreaLastYear,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_AreaLastYearResults=@OfficeAutomation_Document_WithdrawShop_AreaLastYearResults,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit=@OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate=@OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate=@OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_AreaThisYResults=@OfficeAutomation_Document_WithdrawShop_AreaThisYResults,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_AreaThisYProfit=@OfficeAutomation_Document_WithdrawShop_AreaThisYProfit,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_BranchLastYear=@OfficeAutomation_Document_WithdrawShop_BranchLastYear,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_BranchLastYResults=@OfficeAutomation_Document_WithdrawShop_BranchLastYResults,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_BranchLastYProfit=@OfficeAutomation_Document_WithdrawShop_BranchLastYProfit,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate=@OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate=@OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_BranchThisYResults=@OfficeAutomation_Document_WithdrawShop_BranchThisYResults,");
            strSql.Append("OfficeAutomation_Document_WithdrawShop_BranchThisYProfit=@OfficeAutomation_Document_WithdrawShop_BranchThisYProfit");


            strSql.Append(" where OfficeAutomation_Document_WithdrawShop_ID=@OfficeAutomation_Document_WithdrawShop_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_WithdrawShop_MainID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Apply", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ApplyID", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ReplyFax", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ApplyTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_MajordomoID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_DepartmentName", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_DepartmentAddress", SqlDbType.NVarChar,400),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_PlanDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Reason", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AssetHandleIDs", SqlDbType.VarChar,16),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AssetHandleOther", SqlDbType.NVarChar,400),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_PhoneHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_IsFlyLine", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_FlyLineFrom", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_FlyLineTo", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_CanBackDeposit", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BackDeposit", SqlDbType.NVarChar,8),

                    new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Deposit", SqlDbType.NVarChar,8),
                    new SqlParameter("@OfficeAutomation_Document_WithdrawShop_NoBackDeposit", SqlDbType.NVarChar,8),

					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_LiquidatedDamages", SqlDbType.NVarChar,8),

					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_A1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_A2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_A3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_B1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_B2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_B3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_C1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_C2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_C3", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_D1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_E1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_E2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_E3", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate", SqlDbType.DateTime),
                    new SqlParameter("@OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_WithdrawShop_Remark", SqlDbType.NVarChar,200),

                    new SqlParameter("@OfficeAutomation_Document_WithdrawShop_StartDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining", SqlDbType.NVarChar,80),
                    //new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaLastYear", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaLastYearResults", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaThisYResults", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_AreaThisYProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchLastYear", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchLastYResults", SqlDbType.NVarChar,80),                             
                    new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchLastYProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate", SqlDbType.DateTime,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchThisYResults", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_BranchThisYProfit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ID", SqlDbType.UniqueIdentifier,16)};
            //parameters[0].Value = model.OfficeAutomation_Document_WithdrawShop_MainID;
            //parameters[1].Value = model.OfficeAutomation_Document_WithdrawShop_Apply;
            //parameters[2].Value = model.OfficeAutomation_Document_WithdrawShop_ApplyID;
            //parameters[3].Value = model.OfficeAutomation_Document_WithdrawShop_ApplyDate;
			parameters[0].Value = model.OfficeAutomation_Document_WithdrawShop_Department;
			parameters[1].Value = model.OfficeAutomation_Document_WithdrawShop_ReplyPhone;
			parameters[2].Value = model.OfficeAutomation_Document_WithdrawShop_ReplyFax;
			parameters[3].Value = model.OfficeAutomation_Document_WithdrawShop_ApplyTypeID;
			parameters[4].Value = model.OfficeAutomation_Document_WithdrawShop_DepartmentTypeID;
			parameters[5].Value = model.OfficeAutomation_Document_WithdrawShop_MajordomoID;
			parameters[6].Value = model.OfficeAutomation_Document_WithdrawShop_DepartmentName;
			parameters[7].Value = model.OfficeAutomation_Document_WithdrawShop_DepartmentAddress;
			parameters[8].Value = model.OfficeAutomation_Document_WithdrawShop_ExpireDate;
			parameters[9].Value = model.OfficeAutomation_Document_WithdrawShop_PlanDate;
			parameters[10].Value = model.OfficeAutomation_Document_WithdrawShop_Reason;
			parameters[11].Value = model.OfficeAutomation_Document_WithdrawShop_AssetHandleIDs;
			parameters[12].Value = model.OfficeAutomation_Document_WithdrawShop_AssetHandleOther;
			parameters[13].Value = model.OfficeAutomation_Document_WithdrawShop_PhoneHandleID;
			parameters[14].Value = model.OfficeAutomation_Document_WithdrawShop_IsFlyLine;
			parameters[15].Value = model.OfficeAutomation_Document_WithdrawShop_FlyLineFrom;
			parameters[16].Value = model.OfficeAutomation_Document_WithdrawShop_FlyLineTo;
			parameters[17].Value = model.OfficeAutomation_Document_WithdrawShop_CanBackDeposit;
			parameters[18].Value = model.OfficeAutomation_Document_WithdrawShop_BackDeposit;

            parameters[19].Value = model.OfficeAutomation_Document_WithdrawShop_Deposit;
            parameters[20].Value = model.OfficeAutomation_Document_WithdrawShop_NoBackDeposit;

			parameters[21].Value = model.OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages;
            parameters[22].Value = model.OfficeAutomation_Document_WithdrawShop_LiquidatedDamages;

            parameters[23].Value = model.OfficeAutomation_Document_WithdrawShop_A1;
            parameters[24].Value = model.OfficeAutomation_Document_WithdrawShop_A2;
            parameters[25].Value = model.OfficeAutomation_Document_WithdrawShop_A3;
            parameters[26].Value = model.OfficeAutomation_Document_WithdrawShop_B1;
            parameters[27].Value = model.OfficeAutomation_Document_WithdrawShop_B2;
            parameters[28].Value = model.OfficeAutomation_Document_WithdrawShop_B3;
            parameters[29].Value = model.OfficeAutomation_Document_WithdrawShop_C1;
            parameters[30].Value = model.OfficeAutomation_Document_WithdrawShop_C2;
            parameters[31].Value = model.OfficeAutomation_Document_WithdrawShop_C3;
            parameters[32].Value = model.OfficeAutomation_Document_WithdrawShop_D1;
            parameters[33].Value = model.OfficeAutomation_Document_WithdrawShop_E1;
            parameters[34].Value = model.OfficeAutomation_Document_WithdrawShop_E2;
            parameters[35].Value = model.OfficeAutomation_Document_WithdrawShop_E3;

            parameters[36].Value = model.OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate;
            parameters[37].Value = model.OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining;
            //parameters[25].Value = model.OfficeAutomation_Document_WithdrawShop_Remark;

            parameters[38].Value = model.OfficeAutomation_Document_WithdrawShop_StartDate;
            parameters[39].Value = model.OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance;
            parameters[40].Value = model.OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining;
            //parameters[41].Value = model.OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate;
            parameters[41].Value = model.OfficeAutomation_Document_WithdrawShop_AreaLastYear;
            parameters[42].Value = model.OfficeAutomation_Document_WithdrawShop_AreaLastYearResults;
            parameters[43].Value = model.OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit;
            parameters[44].Value = model.OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate;
            parameters[45].Value = model.OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate;
            parameters[46].Value = model.OfficeAutomation_Document_WithdrawShop_AreaThisYResults;
            parameters[47].Value = model.OfficeAutomation_Document_WithdrawShop_AreaThisYProfit;
            parameters[48].Value = model.OfficeAutomation_Document_WithdrawShop_BranchLastYear;
            parameters[49].Value = model.OfficeAutomation_Document_WithdrawShop_BranchLastYResults;
            parameters[50].Value = model.OfficeAutomation_Document_WithdrawShop_BranchLastYProfit;
            parameters[51].Value = model.OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate;
            parameters[52].Value = model.OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate;
            parameters[53].Value = model.OfficeAutomation_Document_WithdrawShop_BranchThisYResults;
            parameters[54].Value = model.OfficeAutomation_Document_WithdrawShop_BranchThisYProfit;

			parameters[55].Value = model.OfficeAutomation_Document_WithdrawShop_ID;

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
        public bool Delete(string OfficeAutomation_Document_WithdrawShop_ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_WithdrawShop_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_WithdrawShop_ID);

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
		public bool DeleteList(string OfficeAutomation_Document_WithdrawShop_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_WithdrawShop ");
			strSql.Append(" where OfficeAutomation_Document_WithdrawShop_ID in ("+OfficeAutomation_Document_WithdrawShop_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_WithdrawShop GetModel(Guid OfficeAutomation_Document_WithdrawShop_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_WithdrawShop_ID,OfficeAutomation_Document_WithdrawShop_MainID,OfficeAutomation_Document_WithdrawShop_Apply,OfficeAutomation_Document_WithdrawShop_ApplyID,OfficeAutomation_Document_WithdrawShop_ApplyDate,OfficeAutomation_Document_WithdrawShop_Department,OfficeAutomation_Document_WithdrawShop_ReplyPhone,OfficeAutomation_Document_WithdrawShop_ReplyFax,OfficeAutomation_Document_WithdrawShop_ApplyTypeID,OfficeAutomation_Document_WithdrawShop_DepartmentTypeID,OfficeAutomation_Document_WithdrawShop_MajordomoID,OfficeAutomation_Document_WithdrawShop_DepartmentName,OfficeAutomation_Document_WithdrawShop_DepartmentAddress,OfficeAutomation_Document_WithdrawShop_ExpireDate,OfficeAutomation_Document_WithdrawShop_PlanDate,OfficeAutomation_Document_WithdrawShop_Reason,OfficeAutomation_Document_WithdrawShop_AssetHandleIDs,OfficeAutomation_Document_WithdrawShop_AssetHandleOther,OfficeAutomation_Document_WithdrawShop_PhoneHandleID,OfficeAutomation_Document_WithdrawShop_IsFlyLine,OfficeAutomation_Document_WithdrawShop_FlyLineFrom,OfficeAutomation_Document_WithdrawShop_FlyLineTo,OfficeAutomation_Document_WithdrawShop_CanBackDeposit,OfficeAutomation_Document_WithdrawShop_BackDeposit,OfficeAutomation_Document_WithdrawShop_Deposit,OfficeAutomation_Document_WithdrawShop_NoBackDeposit,OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages,OfficeAutomation_Document_WithdrawShop_LiquidatedDamages,OfficeAutomation_Document_WithdrawShop_A1,OfficeAutomation_Document_WithdrawShop_A2,OfficeAutomation_Document_WithdrawShop_A3,OfficeAutomation_Document_WithdrawShop_B1,OfficeAutomation_Document_WithdrawShop_B2,OfficeAutomation_Document_WithdrawShop_B3,OfficeAutomation_Document_WithdrawShop_C1,OfficeAutomation_Document_WithdrawShop_C2,OfficeAutomation_Document_WithdrawShop_C3,OfficeAutomation_Document_WithdrawShop_D1,OfficeAutomation_Document_WithdrawShop_E1,OfficeAutomation_Document_WithdrawShop_E2,OfficeAutomation_Document_WithdrawShop_E3,OfficeAutomation_Document_WithdrawShop_Remark from t_OfficeAutomation_Document_WithdrawShop ");
			strSql.Append(" where OfficeAutomation_Document_WithdrawShop_ID=@OfficeAutomation_Document_WithdrawShop_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_WithdrawShop_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_WithdrawShop_ID;

			DataEntity.T_OfficeAutomation_Document_WithdrawShop model=new DataEntity.T_OfficeAutomation_Document_WithdrawShop();
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
		public DataEntity.T_OfficeAutomation_Document_WithdrawShop DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_WithdrawShop model=new DataEntity.T_OfficeAutomation_Document_WithdrawShop();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_WithdrawShop_ID"]!=null && row["OfficeAutomation_Document_WithdrawShop_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_WithdrawShop_ID= new Guid(row["OfficeAutomation_Document_WithdrawShop_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_WithdrawShop_MainID"]!=null && row["OfficeAutomation_Document_WithdrawShop_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_WithdrawShop_MainID= new Guid(row["OfficeAutomation_Document_WithdrawShop_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_WithdrawShop_Apply"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_Apply=row["OfficeAutomation_Document_WithdrawShop_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_ApplyID"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_ApplyID=row["OfficeAutomation_Document_WithdrawShop_ApplyID"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_ApplyDate"]!=null && row["OfficeAutomation_Document_WithdrawShop_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_WithdrawShop_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_WithdrawShop_ApplyDate"].ToString());
				}
				if(row["OfficeAutomation_Document_WithdrawShop_Department"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_Department=row["OfficeAutomation_Document_WithdrawShop_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_ReplyPhone"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_ReplyPhone=row["OfficeAutomation_Document_WithdrawShop_ReplyPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_ReplyFax"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_ReplyFax=row["OfficeAutomation_Document_WithdrawShop_ReplyFax"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_ApplyTypeID"]!=null && row["OfficeAutomation_Document_WithdrawShop_ApplyTypeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_WithdrawShop_ApplyTypeID=int.Parse(row["OfficeAutomation_Document_WithdrawShop_ApplyTypeID"].ToString());
				}
				if(row["OfficeAutomation_Document_WithdrawShop_DepartmentTypeID"]!=null && row["OfficeAutomation_Document_WithdrawShop_DepartmentTypeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_WithdrawShop_DepartmentTypeID=int.Parse(row["OfficeAutomation_Document_WithdrawShop_DepartmentTypeID"].ToString());
				}
				if(row["OfficeAutomation_Document_WithdrawShop_MajordomoID"]!=null && row["OfficeAutomation_Document_WithdrawShop_MajordomoID"].ToString()!="")
				{
					model.OfficeAutomation_Document_WithdrawShop_MajordomoID=int.Parse(row["OfficeAutomation_Document_WithdrawShop_MajordomoID"].ToString());
				}
				if(row["OfficeAutomation_Document_WithdrawShop_DepartmentName"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_DepartmentName=row["OfficeAutomation_Document_WithdrawShop_DepartmentName"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_DepartmentAddress"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_DepartmentAddress=row["OfficeAutomation_Document_WithdrawShop_DepartmentAddress"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_ExpireDate"]!=null && row["OfficeAutomation_Document_WithdrawShop_ExpireDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_WithdrawShop_ExpireDate=DateTime.Parse(row["OfficeAutomation_Document_WithdrawShop_ExpireDate"].ToString());
				}
				if(row["OfficeAutomation_Document_WithdrawShop_PlanDate"]!=null && row["OfficeAutomation_Document_WithdrawShop_PlanDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_WithdrawShop_PlanDate=DateTime.Parse(row["OfficeAutomation_Document_WithdrawShop_PlanDate"].ToString());
				}
				if(row["OfficeAutomation_Document_WithdrawShop_Reason"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_Reason=row["OfficeAutomation_Document_WithdrawShop_Reason"].ToString();
				}
                if (row["OfficeAutomation_Document_WithdrawShop_AssetHandleIDs"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_AssetHandleIDs = row["OfficeAutomation_Document_WithdrawShop_AssetHandleIDs"].ToString();
                }
				if(row["OfficeAutomation_Document_WithdrawShop_AssetHandleOther"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_AssetHandleOther=row["OfficeAutomation_Document_WithdrawShop_AssetHandleOther"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_PhoneHandleID"]!=null && row["OfficeAutomation_Document_WithdrawShop_PhoneHandleID"].ToString()!="")
				{
					model.OfficeAutomation_Document_WithdrawShop_PhoneHandleID=int.Parse(row["OfficeAutomation_Document_WithdrawShop_PhoneHandleID"].ToString());
				}
				if(row["OfficeAutomation_Document_WithdrawShop_IsFlyLine"]!=null && row["OfficeAutomation_Document_WithdrawShop_IsFlyLine"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_WithdrawShop_IsFlyLine"].ToString()=="1")||(row["OfficeAutomation_Document_WithdrawShop_IsFlyLine"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_WithdrawShop_IsFlyLine=true;
					}
					else
					{
						model.OfficeAutomation_Document_WithdrawShop_IsFlyLine=false;
					}
				}
				if(row["OfficeAutomation_Document_WithdrawShop_FlyLineFrom"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_FlyLineFrom=row["OfficeAutomation_Document_WithdrawShop_FlyLineFrom"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_FlyLineTo"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_FlyLineTo=row["OfficeAutomation_Document_WithdrawShop_FlyLineTo"].ToString();
				}
				if(row["OfficeAutomation_Document_WithdrawShop_CanBackDeposit"]!=null && row["OfficeAutomation_Document_WithdrawShop_CanBackDeposit"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_WithdrawShop_CanBackDeposit"].ToString()=="1")||(row["OfficeAutomation_Document_WithdrawShop_CanBackDeposit"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_WithdrawShop_CanBackDeposit=true;
					}
					else
					{
						model.OfficeAutomation_Document_WithdrawShop_CanBackDeposit=false;
					}
				}
				if(row["OfficeAutomation_Document_WithdrawShop_BackDeposit"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_BackDeposit=row["OfficeAutomation_Document_WithdrawShop_BackDeposit"].ToString();
				}

                if (row["OfficeAutomation_Document_WithdrawShop_Deposit"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_Deposit = row["OfficeAutomation_Document_WithdrawShop_Deposit"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_NoBackDeposit"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_NoBackDeposit = row["OfficeAutomation_Document_WithdrawShop_NoBackDeposit"].ToString();
                }

				if(row["OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages"]!=null && row["OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages"].ToString()=="1")||(row["OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages=true;
					}
					else
					{
						model.OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages=false;
					}
				}
				if(row["OfficeAutomation_Document_WithdrawShop_LiquidatedDamages"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_LiquidatedDamages=row["OfficeAutomation_Document_WithdrawShop_LiquidatedDamages"].ToString();
				}

                if (row["OfficeAutomation_Document_WithdrawShop_A1"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_A1 = row["OfficeAutomation_Document_WithdrawShop_A1"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_A2"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_A2 = row["OfficeAutomation_Document_WithdrawShop_A2"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_A3"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_A3 = row["OfficeAutomation_Document_WithdrawShop_A3"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_B1"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_B1 = row["OfficeAutomation_Document_WithdrawShop_B1"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_B2"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_B2 = row["OfficeAutomation_Document_WithdrawShop_B2"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_B3"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_B3 = row["OfficeAutomation_Document_WithdrawShop_B3"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_C1"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_C1 = row["OfficeAutomation_Document_WithdrawShop_C1"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_C2"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_C2 = row["OfficeAutomation_Document_WithdrawShop_C2"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_C3"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_C3 = row["OfficeAutomation_Document_WithdrawShop_C3"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_D1"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_D1 = row["OfficeAutomation_Document_WithdrawShop_D1"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_E1"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_E1 = row["OfficeAutomation_Document_WithdrawShop_E1"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_E2"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_E2 = row["OfficeAutomation_Document_WithdrawShop_E2"].ToString();
                }
                if (row["OfficeAutomation_Document_WithdrawShop_E3"] != null)
                {
                    model.OfficeAutomation_Document_WithdrawShop_E3 = row["OfficeAutomation_Document_WithdrawShop_E3"].ToString();
                }

				if(row["OfficeAutomation_Document_WithdrawShop_Remark"]!=null)
				{
					model.OfficeAutomation_Document_WithdrawShop_Remark=row["OfficeAutomation_Document_WithdrawShop_Remark"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_WithdrawShop_ID,OfficeAutomation_Document_WithdrawShop_MainID,OfficeAutomation_Document_WithdrawShop_Apply,OfficeAutomation_Document_WithdrawShop_ApplyID,OfficeAutomation_Document_WithdrawShop_ApplyDate,OfficeAutomation_Document_WithdrawShop_Department,OfficeAutomation_Document_WithdrawShop_ReplyPhone,OfficeAutomation_Document_WithdrawShop_ReplyFax,OfficeAutomation_Document_WithdrawShop_ApplyTypeID,OfficeAutomation_Document_WithdrawShop_DepartmentTypeID,OfficeAutomation_Document_WithdrawShop_MajordomoID,OfficeAutomation_Document_WithdrawShop_DepartmentName,OfficeAutomation_Document_WithdrawShop_DepartmentAddress,OfficeAutomation_Document_WithdrawShop_ExpireDate,OfficeAutomation_Document_WithdrawShop_PlanDate,OfficeAutomation_Document_WithdrawShop_Reason,OfficeAutomation_Document_WithdrawShop_AssetHandleIDs,OfficeAutomation_Document_WithdrawShop_AssetHandleOther,OfficeAutomation_Document_WithdrawShop_PhoneHandleID,OfficeAutomation_Document_WithdrawShop_IsFlyLine,OfficeAutomation_Document_WithdrawShop_FlyLineFrom,OfficeAutomation_Document_WithdrawShop_FlyLineTo,OfficeAutomation_Document_WithdrawShop_CanBackDeposit,OfficeAutomation_Document_WithdrawShop_BackDeposit,OfficeAutomation_Document_WithdrawShop_Deposit,OfficeAutomation_Document_WithdrawShop_NoBackDeposit,OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages,OfficeAutomation_Document_WithdrawShop_LiquidatedDamages,OfficeAutomation_Document_WithdrawShop_A1,OfficeAutomation_Document_WithdrawShop_A2,OfficeAutomation_Document_WithdrawShop_A3,OfficeAutomation_Document_WithdrawShop_B1,OfficeAutomation_Document_WithdrawShop_B2,OfficeAutomation_Document_WithdrawShop_B3,OfficeAutomation_Document_WithdrawShop_C1,OfficeAutomation_Document_WithdrawShop_C2,OfficeAutomation_Document_WithdrawShop_C3,OfficeAutomation_Document_WithdrawShop_D1,OfficeAutomation_Document_WithdrawShop_E1,OfficeAutomation_Document_WithdrawShop_E2,OfficeAutomation_Document_WithdrawShop_E3,OfficeAutomation_Document_WithdrawShop_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_WithdrawShop ");
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
            strSql.Append(" OfficeAutomation_Document_WithdrawShop_ID,OfficeAutomation_Document_WithdrawShop_MainID,OfficeAutomation_Document_WithdrawShop_Apply,OfficeAutomation_Document_WithdrawShop_ApplyID,OfficeAutomation_Document_WithdrawShop_ApplyDate,OfficeAutomation_Document_WithdrawShop_Department,OfficeAutomation_Document_WithdrawShop_ReplyPhone,OfficeAutomation_Document_WithdrawShop_ReplyFax,OfficeAutomation_Document_WithdrawShop_ApplyTypeID,OfficeAutomation_Document_WithdrawShop_DepartmentTypeID,OfficeAutomation_Document_WithdrawShop_MajordomoID,OfficeAutomation_Document_WithdrawShop_DepartmentName,OfficeAutomation_Document_WithdrawShop_DepartmentAddress,OfficeAutomation_Document_WithdrawShop_ExpireDate,OfficeAutomation_Document_WithdrawShop_PlanDate,OfficeAutomation_Document_WithdrawShop_Reason,OfficeAutomation_Document_WithdrawShop_AssetHandleIDs,OfficeAutomation_Document_WithdrawShop_AssetHandleOther,OfficeAutomation_Document_WithdrawShop_PhoneHandleID,OfficeAutomation_Document_WithdrawShop_IsFlyLine,OfficeAutomation_Document_WithdrawShop_FlyLineFrom,OfficeAutomation_Document_WithdrawShop_FlyLineTo,OfficeAutomation_Document_WithdrawShop_CanBackDeposit,OfficeAutomation_Document_WithdrawShop_BackDeposit,OfficeAutomation_Document_WithdrawShop_Deposit,OfficeAutomation_Document_WithdrawShop_NoBackDeposit,OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages,OfficeAutomation_Document_WithdrawShop_LiquidatedDamages,OfficeAutomation_Document_WithdrawShop_A1,OfficeAutomation_Document_WithdrawShop_A2,OfficeAutomation_Document_WithdrawShop_A3,OfficeAutomation_Document_WithdrawShop_B1,OfficeAutomation_Document_WithdrawShop_B2,OfficeAutomation_Document_WithdrawShop_B3,OfficeAutomation_Document_WithdrawShop_C1,OfficeAutomation_Document_WithdrawShop_C2,OfficeAutomation_Document_WithdrawShop_C3,OfficeAutomation_Document_WithdrawShop_D1,OfficeAutomation_Document_WithdrawShop_E1,OfficeAutomation_Document_WithdrawShop_E2,OfficeAutomation_Document_WithdrawShop_E3,OfficeAutomation_Document_WithdrawShop_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_WithdrawShop ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_WithdrawShop ");
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
				strSql.Append("order by T.OfficeAutomation_Document_WithdrawShop_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_WithdrawShop T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_WithdrawShop";
			parameters[1].Value = "OfficeAutomation_Document_WithdrawShop_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public T_OfficeAutomation_Document_WithdrawShop Insert(T_OfficeAutomation_Document_WithdrawShop t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_WithdrawShop Edit(T_OfficeAutomation_Document_WithdrawShop t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_WithdrawShop t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_WithdrawShop GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_WithdrawShop>(where);
        }
		#endregion  ExtensionMethod
	}

    #region 字典表类库

    /// <summary>
    /// 总监字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_Majordomo_Operate : SqlInteractionBase
    {
        public DataSet SelectByDocumentID(int documentID)
        {
            string sql = "SELECT [OfficeAutomation_Majordomo_ID]"
                            + "         ,[OfficeAutomation_Majordomo_Name]"
                            + "         ,[OfficeAutomation_Majordomo_DocumentID]"
                            + "         ,[OfficeAutomation_Majordomo_IsEnable]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_Majordomo]"
                            + "  where OfficeAutomation_Majordomo_DocumentID = " + documentID
                            + "            and OfficeAutomation_Majordomo_IsEnable = 1";

            return RunSQL(sql);
        }
    }

    #endregion
}

