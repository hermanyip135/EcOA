/*
* DA_OfficeAutomation_Document_SuspendBusi_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_SuspendBusi_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/17 12:15:32    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_SuspendBusi_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_SuspendBusi_Operate
	{
		public DA_OfficeAutomation_Document_SuspendBusi_Operate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_SuspendBusi_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_SuspendBusi");
			strSql.Append(" where OfficeAutomation_Document_SuspendBusi_ID=@OfficeAutomation_Document_SuspendBusi_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_SuspendBusi_ID;

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
            string sSql = "select top 1 OfficeAutomation_Document_SuspendBusi_ApplyID from t_OfficeAutomation_Document_SuspendBusi where OfficeAutomation_Document_SuspendBusi_ApplyID like '" + prefix + "%' order by OfficeAutomation_Document_SuspendBusi_ApplyDate desc";

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
		public bool Add(DataEntity.T_OfficeAutomation_Document_SuspendBusi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_SuspendBusi(");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_ID,OfficeAutomation_Document_SuspendBusi_MainID,OfficeAutomation_Document_SuspendBusi_Apply,OfficeAutomation_Document_SuspendBusi_ApplyID,OfficeAutomation_Document_SuspendBusi_ApplyDate,OfficeAutomation_Document_SuspendBusi_Department,OfficeAutomation_Document_SuspendBusi_ReplyPhone,OfficeAutomation_Document_SuspendBusi_ReplyFax,OfficeAutomation_Document_SuspendBusi_DepartmentTypeID,OfficeAutomation_Document_SuspendBusi_MajordomoID,OfficeAutomation_Document_SuspendBusi_DepartmentName,OfficeAutomation_Document_SuspendBusi_DepartmentAddress,OfficeAutomation_Document_SuspendBusi_ExpireDate,OfficeAutomation_Document_SuspendBusi_StartDate,OfficeAutomation_Document_SuspendBusi_EndDate,OfficeAutomation_Document_SuspendBusi_Rent,OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate,OfficeAutomation_Document_SuspendBusi_SuspensionEndDate,OfficeAutomation_Document_SuspendBusi_SuspensionMonth,OfficeAutomation_Document_SuspendBusi_SEMonth,OfficeAutomation_Document_SuspendBusi_Default,OfficeAutomation_Document_SuspendBusi_Deposit,OfficeAutomation_Document_SuspendBusi_MoneyD1,OfficeAutomation_Document_SuspendBusi_Aeposit,OfficeAutomation_Document_SuspendBusi_MoneyD2,OfficeAutomation_Document_SuspendBusi_IsD,OfficeAutomation_Document_SuspendBusi_MoneyD3,OfficeAutomation_Document_SuspendBusi_ExpireEndDate,OfficeAutomation_Document_SuspendBusi_Reason,OfficeAutomation_Document_SuspendBusi_LeaseStateID,OfficeAutomation_Document_SuspendBusi_AssetHandleIDs,OfficeAutomation_Document_SuspendBusi_AssetHandleOther,OfficeAutomation_Document_SuspendBusi_PhoneHandleID,OfficeAutomation_Document_SuspendBusi_InsureHandleID,OfficeAutomation_Document_SuspendBusi_IsFlyLine,OfficeAutomation_Document_SuspendBusi_FlyLineFrom,OfficeAutomation_Document_SuspendBusi_FlyLineTo,OfficeAutomation_Document_SuspendBusi_RayHandleID,OfficeAutomation_Document_SuspendBusi_ADHandleID,OfficeAutomation_Document_SuspendBusi_StationeryHandleID,OfficeAutomation_Document_SuspendBusi_PaymentAmortizeEndDate,OfficeAutomation_Document_SuspendBusi_PaymentAmortizeRemaining,OfficeAutomation_Document_SuspendBusi_Remark)");
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_SuspendBusi_ID,@OfficeAutomation_Document_SuspendBusi_MainID,@OfficeAutomation_Document_SuspendBusi_Apply,@OfficeAutomation_Document_SuspendBusi_ApplyID,@OfficeAutomation_Document_SuspendBusi_ApplyDate,@OfficeAutomation_Document_SuspendBusi_Department,@OfficeAutomation_Document_SuspendBusi_ReplyPhone,@OfficeAutomation_Document_SuspendBusi_ReplyFax,@OfficeAutomation_Document_SuspendBusi_DepartmentTypeID,@OfficeAutomation_Document_SuspendBusi_MajordomoID,@OfficeAutomation_Document_SuspendBusi_DepartmentName,@OfficeAutomation_Document_SuspendBusi_DepartmentAddress,@OfficeAutomation_Document_SuspendBusi_ExpireDate,@OfficeAutomation_Document_SuspendBusi_StartDate,@OfficeAutomation_Document_SuspendBusi_EndDate,@OfficeAutomation_Document_SuspendBusi_Rent,@OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate,@OfficeAutomation_Document_SuspendBusi_SuspensionEndDate,@OfficeAutomation_Document_SuspendBusi_SuspensionMonth,@OfficeAutomation_Document_SuspendBusi_SEMonth,@OfficeAutomation_Document_SuspendBusi_Default,@OfficeAutomation_Document_SuspendBusi_Deposit,@OfficeAutomation_Document_SuspendBusi_MoneyD1,@OfficeAutomation_Document_SuspendBusi_Aeposit,@OfficeAutomation_Document_SuspendBusi_MoneyD2,@OfficeAutomation_Document_SuspendBusi_IsD,@OfficeAutomation_Document_SuspendBusi_MoneyD3,@OfficeAutomation_Document_SuspendBusi_ExpireEndDate,@OfficeAutomation_Document_SuspendBusi_Reason,@OfficeAutomation_Document_SuspendBusi_LeaseStateID,@OfficeAutomation_Document_SuspendBusi_AssetHandleIDs,@OfficeAutomation_Document_SuspendBusi_AssetHandleOther,@OfficeAutomation_Document_SuspendBusi_PhoneHandleID,@OfficeAutomation_Document_SuspendBusi_InsureHandleID,@OfficeAutomation_Document_SuspendBusi_IsFlyLine,@OfficeAutomation_Document_SuspendBusi_FlyLineFrom,@OfficeAutomation_Document_SuspendBusi_FlyLineTo,@OfficeAutomation_Document_SuspendBusi_RayHandleID,@OfficeAutomation_Document_SuspendBusi_ADHandleID,@OfficeAutomation_Document_SuspendBusi_StationeryHandleID,@OfficeAutomation_Document_SuspendBusi_PaymentAmortizeEndDate,@OfficeAutomation_Document_SuspendBusi_PaymentAmortizeRemaining,@OfficeAutomation_Document_SuspendBusi_Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ReplyFax", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MajordomoID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_DepartmentName", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_DepartmentAddress", SqlDbType.NVarChar,400),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_StartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_EndDate", SqlDbType.DateTime),

					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Rent", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_SuspensionEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_SuspensionMonth", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_SEMonth", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Default", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Deposit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MoneyD1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Aeposit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MoneyD2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_IsD", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MoneyD3", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ExpireEndDate", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Reason", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_LeaseStateID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_AssetHandleIDs", SqlDbType.VarChar,16),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_AssetHandleOther", SqlDbType.NVarChar,400),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_PhoneHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_InsureHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_IsFlyLine", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_FlyLineFrom", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_FlyLineTo", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_RayHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ADHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_StationeryHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_PaymentAmortizeEndDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_PaymentAmortizeRemaining", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.OfficeAutomation_Document_SuspendBusi_ID;
            parameters[1].Value = model.OfficeAutomation_Document_SuspendBusi_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_SuspendBusi_Apply;
            parameters[3].Value = GetNewSerialNum(model.OfficeAutomation_Document_SuspendBusi_Department, DateTime.Now.ToString());
            parameters[4].Value = model.OfficeAutomation_Document_SuspendBusi_ApplyDate;
			parameters[5].Value = model.OfficeAutomation_Document_SuspendBusi_Department;
			parameters[6].Value = model.OfficeAutomation_Document_SuspendBusi_ReplyPhone;
			parameters[7].Value = model.OfficeAutomation_Document_SuspendBusi_ReplyFax;
			parameters[8].Value = model.OfficeAutomation_Document_SuspendBusi_DepartmentTypeID;
			parameters[9].Value = model.OfficeAutomation_Document_SuspendBusi_MajordomoID;
			parameters[10].Value = model.OfficeAutomation_Document_SuspendBusi_DepartmentName;
			parameters[11].Value = model.OfficeAutomation_Document_SuspendBusi_DepartmentAddress;
			parameters[12].Value = model.OfficeAutomation_Document_SuspendBusi_ExpireDate;
			parameters[13].Value = model.OfficeAutomation_Document_SuspendBusi_StartDate;
			parameters[14].Value = model.OfficeAutomation_Document_SuspendBusi_EndDate;

			parameters[15].Value = model.OfficeAutomation_Document_SuspendBusi_Rent;
			parameters[16].Value = model.OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate;
			parameters[17].Value = model.OfficeAutomation_Document_SuspendBusi_SuspensionEndDate;
			parameters[18].Value = model.OfficeAutomation_Document_SuspendBusi_SuspensionMonth;
			parameters[19].Value = model.OfficeAutomation_Document_SuspendBusi_SEMonth;
			parameters[20].Value = model.OfficeAutomation_Document_SuspendBusi_Default;
			parameters[21].Value = model.OfficeAutomation_Document_SuspendBusi_Deposit;
			parameters[22].Value = model.OfficeAutomation_Document_SuspendBusi_MoneyD1;
			parameters[23].Value = model.OfficeAutomation_Document_SuspendBusi_Aeposit;
			parameters[24].Value = model.OfficeAutomation_Document_SuspendBusi_MoneyD2;
			parameters[25].Value = model.OfficeAutomation_Document_SuspendBusi_IsD;
            parameters[26].Value = model.OfficeAutomation_Document_SuspendBusi_MoneyD3;
            parameters[27].Value = model.OfficeAutomation_Document_SuspendBusi_ExpireEndDate;

			parameters[28].Value = model.OfficeAutomation_Document_SuspendBusi_Reason;
			parameters[29].Value = model.OfficeAutomation_Document_SuspendBusi_LeaseStateID;
			parameters[30].Value = model.OfficeAutomation_Document_SuspendBusi_AssetHandleIDs;
			parameters[31].Value = model.OfficeAutomation_Document_SuspendBusi_AssetHandleOther;
			parameters[32].Value = model.OfficeAutomation_Document_SuspendBusi_PhoneHandleID;
			parameters[33].Value = model.OfficeAutomation_Document_SuspendBusi_InsureHandleID;
			parameters[34].Value = model.OfficeAutomation_Document_SuspendBusi_IsFlyLine;
			parameters[35].Value = model.OfficeAutomation_Document_SuspendBusi_FlyLineFrom;
			parameters[36].Value = model.OfficeAutomation_Document_SuspendBusi_FlyLineTo;
			parameters[37].Value = model.OfficeAutomation_Document_SuspendBusi_RayHandleID;
			parameters[38].Value = model.OfficeAutomation_Document_SuspendBusi_ADHandleID;
            parameters[39].Value = model.OfficeAutomation_Document_SuspendBusi_StationeryHandleID;
            parameters[40].Value = model.OfficeAutomation_Document_SuspendBusi_PaymentAmortizeEndDate;
            parameters[41].Value = model.OfficeAutomation_Document_SuspendBusi_PaymentAmortizeRemaining;
			parameters[42].Value = model.OfficeAutomation_Document_SuspendBusi_Remark;

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
		public bool Update(DataEntity.T_OfficeAutomation_Document_SuspendBusi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_SuspendBusi set ");
			//strSql.Append("OfficeAutomation_Document_SuspendBusi_MainID=@OfficeAutomation_Document_SuspendBusi_MainID,");
			//strSql.Append("OfficeAutomation_Document_SuspendBusi_Apply=@OfficeAutomation_Document_SuspendBusi_Apply,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_ApplyID=@OfficeAutomation_Document_SuspendBusi_ApplyID,");
			//strSql.Append("OfficeAutomation_Document_SuspendBusi_ApplyDate=@OfficeAutomation_Document_SuspendBusi_ApplyDate,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_Department=@OfficeAutomation_Document_SuspendBusi_Department,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_ReplyPhone=@OfficeAutomation_Document_SuspendBusi_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_ReplyFax=@OfficeAutomation_Document_SuspendBusi_ReplyFax,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_DepartmentTypeID=@OfficeAutomation_Document_SuspendBusi_DepartmentTypeID,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_MajordomoID=@OfficeAutomation_Document_SuspendBusi_MajordomoID,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_DepartmentName=@OfficeAutomation_Document_SuspendBusi_DepartmentName,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_DepartmentAddress=@OfficeAutomation_Document_SuspendBusi_DepartmentAddress,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_ExpireDate=@OfficeAutomation_Document_SuspendBusi_ExpireDate,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_StartDate=@OfficeAutomation_Document_SuspendBusi_StartDate,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_EndDate=@OfficeAutomation_Document_SuspendBusi_EndDate,");

            strSql.Append("OfficeAutomation_Document_SuspendBusi_Rent=@OfficeAutomation_Document_SuspendBusi_Rent,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate=@OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_SuspensionEndDate=@OfficeAutomation_Document_SuspendBusi_SuspensionEndDate,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_SuspensionMonth=@OfficeAutomation_Document_SuspendBusi_SuspensionMonth,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_SEMonth=@OfficeAutomation_Document_SuspendBusi_SEMonth,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_Default=@OfficeAutomation_Document_SuspendBusi_Default,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_Deposit=@OfficeAutomation_Document_SuspendBusi_Deposit,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_MoneyD1=@OfficeAutomation_Document_SuspendBusi_MoneyD1,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_Aeposit=@OfficeAutomation_Document_SuspendBusi_Aeposit,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_MoneyD2=@OfficeAutomation_Document_SuspendBusi_MoneyD2,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_IsD=@OfficeAutomation_Document_SuspendBusi_IsD,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_MoneyD3=@OfficeAutomation_Document_SuspendBusi_MoneyD3,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_ExpireEndDate=@OfficeAutomation_Document_SuspendBusi_ExpireEndDate,");

			strSql.Append("OfficeAutomation_Document_SuspendBusi_Reason=@OfficeAutomation_Document_SuspendBusi_Reason,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_LeaseStateID=@OfficeAutomation_Document_SuspendBusi_LeaseStateID,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_AssetHandleIDs=@OfficeAutomation_Document_SuspendBusi_AssetHandleIDs,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_AssetHandleOther=@OfficeAutomation_Document_SuspendBusi_AssetHandleOther,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_PhoneHandleID=@OfficeAutomation_Document_SuspendBusi_PhoneHandleID,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_InsureHandleID=@OfficeAutomation_Document_SuspendBusi_InsureHandleID,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_IsFlyLine=@OfficeAutomation_Document_SuspendBusi_IsFlyLine,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_FlyLineFrom=@OfficeAutomation_Document_SuspendBusi_FlyLineFrom,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_FlyLineTo=@OfficeAutomation_Document_SuspendBusi_FlyLineTo,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_RayHandleID=@OfficeAutomation_Document_SuspendBusi_RayHandleID,");
			strSql.Append("OfficeAutomation_Document_SuspendBusi_ADHandleID=@OfficeAutomation_Document_SuspendBusi_ADHandleID,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_StationeryHandleID=@OfficeAutomation_Document_SuspendBusi_StationeryHandleID,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_PaymentAmortizeEndDate=@OfficeAutomation_Document_SuspendBusi_PaymentAmortizeEndDate,");
            strSql.Append("OfficeAutomation_Document_SuspendBusi_PaymentAmortizeRemaining=@OfficeAutomation_Document_SuspendBusi_PaymentAmortizeRemaining");
			//strSql.Append("OfficeAutomation_Document_SuspendBusi_Remark=@OfficeAutomation_Document_SuspendBusi_Remark");
            strSql.Append(" where OfficeAutomation_Document_SuspendBusi_ID=@OfficeAutomation_Document_SuspendBusi_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MainID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ApplyID", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ReplyFax", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MajordomoID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_DepartmentName", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_DepartmentAddress", SqlDbType.NVarChar,400),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_StartDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_EndDate", SqlDbType.DateTime),

					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Rent", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_SuspensionEndDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_SuspensionMonth", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_SEMonth", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Default", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Deposit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MoneyD1", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Aeposit", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MoneyD2", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_IsD", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_MoneyD3", SqlDbType.NVarChar,80),
                    new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ExpireEndDate", SqlDbType.NVarChar,80),

					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Reason", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_LeaseStateID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_AssetHandleIDs", SqlDbType.VarChar,16),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_AssetHandleOther", SqlDbType.NVarChar,400),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_PhoneHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_InsureHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_IsFlyLine", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_FlyLineFrom", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_FlyLineTo", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_RayHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ADHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_StationeryHandleID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_PaymentAmortizeEndDate", SqlDbType.DateTime),
                    new SqlParameter("@OfficeAutomation_Document_SuspendBusi_PaymentAmortizeRemaining", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_SuspendBusi_Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_SuspendBusi_MainID;
			//parameters[1].Value = model.OfficeAutomation_Document_SuspendBusi_Apply;
			parameters[0].Value = model.OfficeAutomation_Document_SuspendBusi_ApplyID;
			//parameters[1].Value = model.OfficeAutomation_Document_SuspendBusi_ApplyDate;
			parameters[1].Value = model.OfficeAutomation_Document_SuspendBusi_Department;
			parameters[2].Value = model.OfficeAutomation_Document_SuspendBusi_ReplyPhone;
			parameters[3].Value = model.OfficeAutomation_Document_SuspendBusi_ReplyFax;
			parameters[4].Value = model.OfficeAutomation_Document_SuspendBusi_DepartmentTypeID;
			parameters[5].Value = model.OfficeAutomation_Document_SuspendBusi_MajordomoID;
			parameters[6].Value = model.OfficeAutomation_Document_SuspendBusi_DepartmentName;
			parameters[7].Value = model.OfficeAutomation_Document_SuspendBusi_DepartmentAddress;
			parameters[8].Value = model.OfficeAutomation_Document_SuspendBusi_ExpireDate;
			parameters[9].Value = model.OfficeAutomation_Document_SuspendBusi_StartDate;
			parameters[10].Value = model.OfficeAutomation_Document_SuspendBusi_EndDate;

			parameters[11].Value = model.OfficeAutomation_Document_SuspendBusi_Rent;
			parameters[12].Value = model.OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate;
			parameters[13].Value = model.OfficeAutomation_Document_SuspendBusi_SuspensionEndDate;
			parameters[14].Value = model.OfficeAutomation_Document_SuspendBusi_SuspensionMonth;
			parameters[15].Value = model.OfficeAutomation_Document_SuspendBusi_SEMonth;
			parameters[16].Value = model.OfficeAutomation_Document_SuspendBusi_Default;
			parameters[17].Value = model.OfficeAutomation_Document_SuspendBusi_Deposit;
			parameters[18].Value = model.OfficeAutomation_Document_SuspendBusi_MoneyD1;
			parameters[19].Value = model.OfficeAutomation_Document_SuspendBusi_Aeposit;
			parameters[20].Value = model.OfficeAutomation_Document_SuspendBusi_MoneyD2;
			parameters[21].Value = model.OfficeAutomation_Document_SuspendBusi_IsD;
            parameters[22].Value = model.OfficeAutomation_Document_SuspendBusi_MoneyD3;
            parameters[23].Value = model.OfficeAutomation_Document_SuspendBusi_ExpireEndDate;

			parameters[24].Value = model.OfficeAutomation_Document_SuspendBusi_Reason;
			parameters[25].Value = model.OfficeAutomation_Document_SuspendBusi_LeaseStateID;
			parameters[26].Value = model.OfficeAutomation_Document_SuspendBusi_AssetHandleIDs;
			parameters[27].Value = model.OfficeAutomation_Document_SuspendBusi_AssetHandleOther;
			parameters[28].Value = model.OfficeAutomation_Document_SuspendBusi_PhoneHandleID;
			parameters[29].Value = model.OfficeAutomation_Document_SuspendBusi_InsureHandleID;
			parameters[30].Value = model.OfficeAutomation_Document_SuspendBusi_IsFlyLine;
			parameters[31].Value = model.OfficeAutomation_Document_SuspendBusi_FlyLineFrom;
			parameters[32].Value = model.OfficeAutomation_Document_SuspendBusi_FlyLineTo;
			parameters[33].Value = model.OfficeAutomation_Document_SuspendBusi_RayHandleID;
			parameters[34].Value = model.OfficeAutomation_Document_SuspendBusi_ADHandleID;
			parameters[35].Value = model.OfficeAutomation_Document_SuspendBusi_StationeryHandleID;
			//parameters[26].Value = model.OfficeAutomation_Document_SuspendBusi_Remark;
            parameters[36].Value = model.OfficeAutomation_Document_SuspendBusi_PaymentAmortizeEndDate;
            parameters[37].Value = model.OfficeAutomation_Document_SuspendBusi_PaymentAmortizeRemaining;
			parameters[38].Value = model.OfficeAutomation_Document_SuspendBusi_ID;

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
		public bool Delete(string OfficeAutomation_Document_SuspendBusi_ID)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_SuspendBusi_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_SuspendBusi_ID);

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
		public bool DeleteList(string OfficeAutomation_Document_SuspendBusi_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_SuspendBusi ");
			strSql.Append(" where OfficeAutomation_Document_SuspendBusi_ID in ("+OfficeAutomation_Document_SuspendBusi_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_SuspendBusi GetModel(Guid OfficeAutomation_Document_SuspendBusi_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_SuspendBusi_ID,OfficeAutomation_Document_SuspendBusi_MainID,OfficeAutomation_Document_SuspendBusi_Apply,OfficeAutomation_Document_SuspendBusi_ApplyID,OfficeAutomation_Document_SuspendBusi_ApplyDate,OfficeAutomation_Document_SuspendBusi_Department,OfficeAutomation_Document_SuspendBusi_ReplyPhone,OfficeAutomation_Document_SuspendBusi_ReplyFax,OfficeAutomation_Document_SuspendBusi_DepartmentTypeID,OfficeAutomation_Document_SuspendBusi_MajordomoID,OfficeAutomation_Document_SuspendBusi_DepartmentName,OfficeAutomation_Document_SuspendBusi_DepartmentAddress,OfficeAutomation_Document_SuspendBusi_ExpireDate,OfficeAutomation_Document_SuspendBusi_StartDate,OfficeAutomation_Document_SuspendBusi_EndDate,OfficeAutomation_Document_SuspendBusi_Rent,OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate,OfficeAutomation_Document_SuspendBusi_SuspensionEndDate,OfficeAutomation_Document_SuspendBusi_SuspensionMonth,OfficeAutomation_Document_SuspendBusi_SEMonth,OfficeAutomation_Document_SuspendBusi_Default,OfficeAutomation_Document_SuspendBusi_Deposit,OfficeAutomation_Document_SuspendBusi_MoneyD1,OfficeAutomation_Document_SuspendBusi_Aeposit,OfficeAutomation_Document_SuspendBusi_MoneyD2,OfficeAutomation_Document_SuspendBusi_IsD,OfficeAutomation_Document_SuspendBusi_MoneyD3,OfficeAutomation_Document_SuspendBusi_ExpireEndDate,OfficeAutomation_Document_SuspendBusi_Reason,OfficeAutomation_Document_SuspendBusi_LeaseStateID,OfficeAutomation_Document_SuspendBusi_AssetHandleIDs,OfficeAutomation_Document_SuspendBusi_AssetHandleOther,OfficeAutomation_Document_SuspendBusi_PhoneHandleID,OfficeAutomation_Document_SuspendBusi_InsureHandleID,OfficeAutomation_Document_SuspendBusi_IsFlyLine,OfficeAutomation_Document_SuspendBusi_FlyLineFrom,OfficeAutomation_Document_SuspendBusi_FlyLineTo,OfficeAutomation_Document_SuspendBusi_RayHandleID,OfficeAutomation_Document_SuspendBusi_ADHandleID,OfficeAutomation_Document_SuspendBusi_StationeryHandleID,OfficeAutomation_Document_SuspendBusi_Remark from t_OfficeAutomation_Document_SuspendBusi ");
			strSql.Append(" where OfficeAutomation_Document_SuspendBusi_ID=@OfficeAutomation_Document_SuspendBusi_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_SuspendBusi_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_SuspendBusi_ID;

			DataEntity.T_OfficeAutomation_Document_SuspendBusi model=new DataEntity.T_OfficeAutomation_Document_SuspendBusi();
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
		public DataEntity.T_OfficeAutomation_Document_SuspendBusi DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_SuspendBusi model=new DataEntity.T_OfficeAutomation_Document_SuspendBusi();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_SuspendBusi_ID"]!=null && row["OfficeAutomation_Document_SuspendBusi_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_ID= new Guid(row["OfficeAutomation_Document_SuspendBusi_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_MainID"]!=null && row["OfficeAutomation_Document_SuspendBusi_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_MainID= new Guid(row["OfficeAutomation_Document_SuspendBusi_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_Apply"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_Apply=row["OfficeAutomation_Document_SuspendBusi_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_ApplyID"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_ApplyID=row["OfficeAutomation_Document_SuspendBusi_ApplyID"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_ApplyDate"]!=null && row["OfficeAutomation_Document_SuspendBusi_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_SuspendBusi_ApplyDate"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_Department"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_Department=row["OfficeAutomation_Document_SuspendBusi_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_ReplyPhone"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_ReplyPhone=row["OfficeAutomation_Document_SuspendBusi_ReplyPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_ReplyFax"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_ReplyFax=row["OfficeAutomation_Document_SuspendBusi_ReplyFax"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_DepartmentTypeID"]!=null && row["OfficeAutomation_Document_SuspendBusi_DepartmentTypeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_DepartmentTypeID=int.Parse(row["OfficeAutomation_Document_SuspendBusi_DepartmentTypeID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_MajordomoID"]!=null && row["OfficeAutomation_Document_SuspendBusi_MajordomoID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_MajordomoID=int.Parse(row["OfficeAutomation_Document_SuspendBusi_MajordomoID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_DepartmentName"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_DepartmentName=row["OfficeAutomation_Document_SuspendBusi_DepartmentName"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_DepartmentAddress"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_DepartmentAddress=row["OfficeAutomation_Document_SuspendBusi_DepartmentAddress"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_ExpireDate"]!=null && row["OfficeAutomation_Document_SuspendBusi_ExpireDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_ExpireDate=DateTime.Parse(row["OfficeAutomation_Document_SuspendBusi_ExpireDate"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_StartDate"]!=null && row["OfficeAutomation_Document_SuspendBusi_StartDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_StartDate=DateTime.Parse(row["OfficeAutomation_Document_SuspendBusi_StartDate"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_EndDate"]!=null && row["OfficeAutomation_Document_SuspendBusi_EndDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_EndDate=DateTime.Parse(row["OfficeAutomation_Document_SuspendBusi_EndDate"].ToString());
				}

                if (row["OfficeAutomation_Document_SuspendBusi_Rent"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_Rent = row["OfficeAutomation_Document_SuspendBusi_Rent"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate = row["OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_SuspensionEndDate"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_SuspensionEndDate = row["OfficeAutomation_Document_SuspendBusi_SuspensionEndDate"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_SuspensionMonth"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_SuspensionMonth = row["OfficeAutomation_Document_SuspendBusi_SuspensionMonth"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_SEMonth"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_SEMonth = row["OfficeAutomation_Document_SuspendBusi_SEMonth"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_Default"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_Default = row["OfficeAutomation_Document_SuspendBusi_Default"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_Deposit"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_Deposit = row["OfficeAutomation_Document_SuspendBusi_Deposit"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_MoneyD1"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_MoneyD1 = row["OfficeAutomation_Document_SuspendBusi_MoneyD1"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_Aeposit"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_Aeposit = row["OfficeAutomation_Document_SuspendBusi_Aeposit"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_MoneyD2"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_MoneyD2 = row["OfficeAutomation_Document_SuspendBusi_MoneyD2"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_IsD"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_IsD = row["OfficeAutomation_Document_SuspendBusi_IsD"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_MoneyD3"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_MoneyD3 = row["OfficeAutomation_Document_SuspendBusi_MoneyD3"].ToString();
                }
                if (row["OfficeAutomation_Document_SuspendBusi_ExpireEndDate"] != null)
                {
                    model.OfficeAutomation_Document_SuspendBusi_ExpireEndDate = row["OfficeAutomation_Document_SuspendBusi_ExpireEndDate"].ToString();
                }

				if(row["OfficeAutomation_Document_SuspendBusi_Reason"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_Reason=row["OfficeAutomation_Document_SuspendBusi_Reason"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_LeaseStateID"]!=null && row["OfficeAutomation_Document_SuspendBusi_LeaseStateID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_LeaseStateID=int.Parse(row["OfficeAutomation_Document_SuspendBusi_LeaseStateID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_AssetHandleIDs"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_AssetHandleIDs=row["OfficeAutomation_Document_SuspendBusi_AssetHandleIDs"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_AssetHandleOther"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_AssetHandleOther=row["OfficeAutomation_Document_SuspendBusi_AssetHandleOther"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_PhoneHandleID"]!=null && row["OfficeAutomation_Document_SuspendBusi_PhoneHandleID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_PhoneHandleID=int.Parse(row["OfficeAutomation_Document_SuspendBusi_PhoneHandleID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_InsureHandleID"]!=null && row["OfficeAutomation_Document_SuspendBusi_InsureHandleID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_InsureHandleID=int.Parse(row["OfficeAutomation_Document_SuspendBusi_InsureHandleID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_IsFlyLine"]!=null && row["OfficeAutomation_Document_SuspendBusi_IsFlyLine"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_SuspendBusi_IsFlyLine"].ToString()=="1")||(row["OfficeAutomation_Document_SuspendBusi_IsFlyLine"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_SuspendBusi_IsFlyLine=true;
					}
					else
					{
						model.OfficeAutomation_Document_SuspendBusi_IsFlyLine=false;
					}
				}
				if(row["OfficeAutomation_Document_SuspendBusi_FlyLineFrom"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_FlyLineFrom=row["OfficeAutomation_Document_SuspendBusi_FlyLineFrom"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_FlyLineTo"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_FlyLineTo=row["OfficeAutomation_Document_SuspendBusi_FlyLineTo"].ToString();
				}
				if(row["OfficeAutomation_Document_SuspendBusi_RayHandleID"]!=null && row["OfficeAutomation_Document_SuspendBusi_RayHandleID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_RayHandleID=int.Parse(row["OfficeAutomation_Document_SuspendBusi_RayHandleID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_ADHandleID"]!=null && row["OfficeAutomation_Document_SuspendBusi_ADHandleID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_ADHandleID=int.Parse(row["OfficeAutomation_Document_SuspendBusi_ADHandleID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_StationeryHandleID"]!=null && row["OfficeAutomation_Document_SuspendBusi_StationeryHandleID"].ToString()!="")
				{
					model.OfficeAutomation_Document_SuspendBusi_StationeryHandleID=int.Parse(row["OfficeAutomation_Document_SuspendBusi_StationeryHandleID"].ToString());
				}
				if(row["OfficeAutomation_Document_SuspendBusi_Remark"]!=null)
				{
					model.OfficeAutomation_Document_SuspendBusi_Remark=row["OfficeAutomation_Document_SuspendBusi_Remark"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_SuspendBusi_ID,OfficeAutomation_Document_SuspendBusi_MainID,OfficeAutomation_Document_SuspendBusi_Apply,OfficeAutomation_Document_SuspendBusi_ApplyID,OfficeAutomation_Document_SuspendBusi_ApplyDate,OfficeAutomation_Document_SuspendBusi_Department,OfficeAutomation_Document_SuspendBusi_ReplyPhone,OfficeAutomation_Document_SuspendBusi_ReplyFax,OfficeAutomation_Document_SuspendBusi_DepartmentTypeID,OfficeAutomation_Document_SuspendBusi_MajordomoID,OfficeAutomation_Document_SuspendBusi_DepartmentName,OfficeAutomation_Document_SuspendBusi_DepartmentAddress,OfficeAutomation_Document_SuspendBusi_ExpireDate,OfficeAutomation_Document_SuspendBusi_StartDate,OfficeAutomation_Document_SuspendBusi_EndDate,OfficeAutomation_Document_SuspendBusi_Rent,OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate,OfficeAutomation_Document_SuspendBusi_SuspensionEndDate,OfficeAutomation_Document_SuspendBusi_SuspensionMonth,OfficeAutomation_Document_SuspendBusi_SEMonth,OfficeAutomation_Document_SuspendBusi_Default,OfficeAutomation_Document_SuspendBusi_Deposit,OfficeAutomation_Document_SuspendBusi_MoneyD1,OfficeAutomation_Document_SuspendBusi_Aeposit,OfficeAutomation_Document_SuspendBusi_MoneyD2,OfficeAutomation_Document_SuspendBusi_IsD,OfficeAutomation_Document_SuspendBusi_MoneyD3,OfficeAutomation_Document_SuspendBusi_ExpireEndDate,OfficeAutomation_Document_SuspendBusi_Reason,OfficeAutomation_Document_SuspendBusi_LeaseStateID,OfficeAutomation_Document_SuspendBusi_AssetHandleIDs,OfficeAutomation_Document_SuspendBusi_AssetHandleOther,OfficeAutomation_Document_SuspendBusi_PhoneHandleID,OfficeAutomation_Document_SuspendBusi_InsureHandleID,OfficeAutomation_Document_SuspendBusi_IsFlyLine,OfficeAutomation_Document_SuspendBusi_FlyLineFrom,OfficeAutomation_Document_SuspendBusi_FlyLineTo,OfficeAutomation_Document_SuspendBusi_RayHandleID,OfficeAutomation_Document_SuspendBusi_ADHandleID,OfficeAutomation_Document_SuspendBusi_StationeryHandleID,OfficeAutomation_Document_SuspendBusi_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_SuspendBusi ");
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
            strSql.Append(" OfficeAutomation_Document_SuspendBusi_ID,OfficeAutomation_Document_SuspendBusi_MainID,OfficeAutomation_Document_SuspendBusi_Apply,OfficeAutomation_Document_SuspendBusi_ApplyID,OfficeAutomation_Document_SuspendBusi_ApplyDate,OfficeAutomation_Document_SuspendBusi_Department,OfficeAutomation_Document_SuspendBusi_ReplyPhone,OfficeAutomation_Document_SuspendBusi_ReplyFax,OfficeAutomation_Document_SuspendBusi_DepartmentTypeID,OfficeAutomation_Document_SuspendBusi_MajordomoID,OfficeAutomation_Document_SuspendBusi_DepartmentName,OfficeAutomation_Document_SuspendBusi_DepartmentAddress,OfficeAutomation_Document_SuspendBusi_ExpireDate,OfficeAutomation_Document_SuspendBusi_StartDate,OfficeAutomation_Document_SuspendBusi_EndDate,OfficeAutomation_Document_SuspendBusi_Rent,OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate,OfficeAutomation_Document_SuspendBusi_SuspensionEndDate,OfficeAutomation_Document_SuspendBusi_SuspensionMonth,OfficeAutomation_Document_SuspendBusi_SEMonth,OfficeAutomation_Document_SuspendBusi_Default,OfficeAutomation_Document_SuspendBusi_Deposit,OfficeAutomation_Document_SuspendBusi_MoneyD1,OfficeAutomation_Document_SuspendBusi_Aeposit,OfficeAutomation_Document_SuspendBusi_MoneyD2,OfficeAutomation_Document_SuspendBusi_IsD,OfficeAutomation_Document_SuspendBusi_MoneyD3,OfficeAutomation_Document_SuspendBusi_ExpireEndDate,OfficeAutomation_Document_SuspendBusi_Reason,OfficeAutomation_Document_SuspendBusi_LeaseStateID,OfficeAutomation_Document_SuspendBusi_AssetHandleIDs,OfficeAutomation_Document_SuspendBusi_AssetHandleOther,OfficeAutomation_Document_SuspendBusi_PhoneHandleID,OfficeAutomation_Document_SuspendBusi_InsureHandleID,OfficeAutomation_Document_SuspendBusi_IsFlyLine,OfficeAutomation_Document_SuspendBusi_FlyLineFrom,OfficeAutomation_Document_SuspendBusi_FlyLineTo,OfficeAutomation_Document_SuspendBusi_RayHandleID,OfficeAutomation_Document_SuspendBusi_ADHandleID,OfficeAutomation_Document_SuspendBusi_StationeryHandleID,OfficeAutomation_Document_SuspendBusi_Remark ");
			strSql.Append(" FROM t_OfficeAutomation_Document_SuspendBusi ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_SuspendBusi ");
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
				strSql.Append("order by T.OfficeAutomation_Document_SuspendBusi_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_SuspendBusi T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_SuspendBusi";
			parameters[1].Value = "OfficeAutomation_Document_SuspendBusi_ID";
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

