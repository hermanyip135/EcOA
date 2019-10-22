/*
* DA_OfficeAutomation_Document_CoopCost_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_CoopCost_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/3 11:58:00    张榕     初版
*
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataEntity;//52100

namespace DataAccess.Operate
{
	/// <summary>
	/// 数据访问类:DA_OfficeAutomation_Document_CoopCost_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_CoopCost_Operate
	{
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_CoopCost> dal;
		public DA_OfficeAutomation_Document_CoopCost_Operate()
		{
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_CoopCost>();
        }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_CoopCost_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_CoopCost");
			strSql.Append(" where OfficeAutomation_Document_CoopCost_ID=@OfficeAutomation_Document_CoopCost_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_CoopCost_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_CoopCost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_CoopCost(");
            strSql.Append("OfficeAutomation_Document_CoopCost_ID,OfficeAutomation_Document_CoopCost_MainID,OfficeAutomation_Document_CoopCost_Apply,OfficeAutomation_Document_CoopCost_ApplyForName,OfficeAutomation_Document_CoopCost_ApplyForCode,OfficeAutomation_Document_CoopCost_Department,OfficeAutomation_Document_CoopCost_DepartmentID,OfficeAutomation_Document_CoopCost_ApplyDate,OfficeAutomation_Document_CoopCost_ReplyPhone,OfficeAutomation_Document_CoopCost_DepartmentTypeID,OfficeAutomation_Document_CoopCost_DealDate,OfficeAutomation_Document_CoopCost_PropertyName,OfficeAutomation_Document_CoopCost_ReportID,OfficeAutomation_Document_CoopCost_DealTypeID,OfficeAutomation_Document_CoopCost_Area,OfficeAutomation_Document_CoopCost_DealPrice,OfficeAutomation_Document_CoopCost_OwnerComm,OfficeAutomation_Document_CoopCost_OwnerScale,OfficeAutomation_Document_CoopCost_ClientComm,OfficeAutomation_Document_CoopCost_ClientScale,OfficeAutomation_Document_CoopCost_TotalComm,OfficeAutomation_Document_CoopCost_TotalScale,OfficeAutomation_Document_CoopCost_BillTypeOwner,OfficeAutomation_Document_CoopCost_OwnerName,OfficeAutomation_Document_CoopCost_IsOwner,OfficeAutomation_Document_CoopCost_OwnerCoopCondition,OfficeAutomation_Document_CoopCost_OwnerCoopMoney,OfficeAutomation_Document_CoopCost_OwnerCoopScale,OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale,OfficeAutomation_Document_CoopCost_BillTypeClient,OfficeAutomation_Document_CoopCost_ClientName,OfficeAutomation_Document_CoopCost_IsClient,OfficeAutomation_Document_CoopCost_ClientCoopCondition,OfficeAutomation_Document_CoopCost_ClientCoopMoney,OfficeAutomation_Document_CoopCost_ClientCoopScale,OfficeAutomation_Document_CoopCost_ClientCoopTotalScale,OfficeAutomation_Document_CoopCost_CoopMoney,OfficeAutomation_Document_CoopCost_CoopTotalScale,OfficeAutomation_Document_CoopCost_ActualComm,OfficeAutomation_Document_CoopCost_ActualCommScale,OfficeAutomation_Document_CoopCost_Remark,OfficeAutomation_Document_CoopCost_OwnerReason,OfficeAutomation_Document_CoopCost_ClientReason,OfficeAutomation_Document_CoopCost_AddressDetail)");
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_CoopCost_ID,@OfficeAutomation_Document_CoopCost_MainID,@OfficeAutomation_Document_CoopCost_Apply,@OfficeAutomation_Document_CoopCost_ApplyForName,@OfficeAutomation_Document_CoopCost_ApplyForCode,@OfficeAutomation_Document_CoopCost_Department,@OfficeAutomation_Document_CoopCost_DepartmentID,@OfficeAutomation_Document_CoopCost_ApplyDate,@OfficeAutomation_Document_CoopCost_ReplyPhone,@OfficeAutomation_Document_CoopCost_DepartmentTypeID,@OfficeAutomation_Document_CoopCost_DealDate,@OfficeAutomation_Document_CoopCost_PropertyName,@OfficeAutomation_Document_CoopCost_ReportID,@OfficeAutomation_Document_CoopCost_DealTypeID,@OfficeAutomation_Document_CoopCost_Area,@OfficeAutomation_Document_CoopCost_DealPrice,@OfficeAutomation_Document_CoopCost_OwnerComm,@OfficeAutomation_Document_CoopCost_OwnerScale,@OfficeAutomation_Document_CoopCost_ClientComm,@OfficeAutomation_Document_CoopCost_ClientScale,@OfficeAutomation_Document_CoopCost_TotalComm,@OfficeAutomation_Document_CoopCost_TotalScale,@OfficeAutomation_Document_CoopCost_BillTypeOwner,@OfficeAutomation_Document_CoopCost_OwnerName,@OfficeAutomation_Document_CoopCost_IsOwner,@OfficeAutomation_Document_CoopCost_OwnerCoopCondition,@OfficeAutomation_Document_CoopCost_OwnerCoopMoney,@OfficeAutomation_Document_CoopCost_OwnerCoopScale,@OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale,@OfficeAutomation_Document_CoopCost_BillTypeClient,@OfficeAutomation_Document_CoopCost_ClientName,@OfficeAutomation_Document_CoopCost_IsClient,@OfficeAutomation_Document_CoopCost_ClientCoopCondition,@OfficeAutomation_Document_CoopCost_ClientCoopMoney,@OfficeAutomation_Document_CoopCost_ClientCoopScale,@OfficeAutomation_Document_CoopCost_ClientCoopTotalScale,@OfficeAutomation_Document_CoopCost_CoopMoney,@OfficeAutomation_Document_CoopCost_CoopTotalScale,@OfficeAutomation_Document_CoopCost_ActualComm,@OfficeAutomation_Document_CoopCost_ActualCommScale,@OfficeAutomation_Document_CoopCost_Remark,@OfficeAutomation_Document_CoopCost_OwnerReason,@OfficeAutomation_Document_CoopCost_ClientReason,@OfficeAutomation_Document_CoopCost_AddressDetail)");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ApplyForCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DepartmentID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DealDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_PropertyName", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ReportID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DealTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_Area", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DealPrice", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerComm", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientComm", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_TotalComm", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_TotalScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_BillTypeOwner", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_IsOwner", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerCoopCondition", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerCoopMoney", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerCoopScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_BillTypeClient", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_IsClient", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientCoopCondition", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientCoopMoney", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientCoopScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientCoopTotalScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_CoopMoney", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_CoopTotalScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ActualComm", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ActualCommScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerReason", SqlDbType.NVarChar,200),
                    new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientReason", SqlDbType.NVarChar,200),
                     new SqlParameter("@OfficeAutomation_Document_CoopCost_AddressDetail", SqlDbType.NVarChar,300), 
                                                                                                             };
            parameters[0].Value = model.OfficeAutomation_Document_CoopCost_ID;
            parameters[1].Value = model.OfficeAutomation_Document_CoopCost_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_CoopCost_Apply;
			parameters[3].Value = model.OfficeAutomation_Document_CoopCost_ApplyForName;
			parameters[4].Value = model.OfficeAutomation_Document_CoopCost_ApplyForCode;
			parameters[5].Value = model.OfficeAutomation_Document_CoopCost_Department;
            parameters[6].Value = model.OfficeAutomation_Document_CoopCost_DepartmentID;
			parameters[7].Value = model.OfficeAutomation_Document_CoopCost_ApplyDate;
			parameters[8].Value = model.OfficeAutomation_Document_CoopCost_ReplyPhone;
			parameters[9].Value = model.OfficeAutomation_Document_CoopCost_DepartmentTypeID;
			parameters[10].Value = model.OfficeAutomation_Document_CoopCost_DealDate;
			parameters[11].Value = model.OfficeAutomation_Document_CoopCost_PropertyName;
			parameters[12].Value = model.OfficeAutomation_Document_CoopCost_ReportID;
			parameters[13].Value = model.OfficeAutomation_Document_CoopCost_DealTypeID;
			parameters[14].Value = model.OfficeAutomation_Document_CoopCost_Area;
			parameters[15].Value = model.OfficeAutomation_Document_CoopCost_DealPrice;
			parameters[16].Value = model.OfficeAutomation_Document_CoopCost_OwnerComm;
			parameters[17].Value = model.OfficeAutomation_Document_CoopCost_OwnerScale;
			parameters[18].Value = model.OfficeAutomation_Document_CoopCost_ClientComm;
			parameters[19].Value = model.OfficeAutomation_Document_CoopCost_ClientScale;
			parameters[20].Value = model.OfficeAutomation_Document_CoopCost_TotalComm;
			parameters[21].Value = model.OfficeAutomation_Document_CoopCost_TotalScale;
			parameters[22].Value = model.OfficeAutomation_Document_CoopCost_BillTypeOwner;
			parameters[23].Value = model.OfficeAutomation_Document_CoopCost_OwnerName;
			parameters[24].Value = model.OfficeAutomation_Document_CoopCost_IsOwner;
			parameters[25].Value = model.OfficeAutomation_Document_CoopCost_OwnerCoopCondition;
			parameters[26].Value = model.OfficeAutomation_Document_CoopCost_OwnerCoopMoney;
			parameters[27].Value = model.OfficeAutomation_Document_CoopCost_OwnerCoopScale;
			parameters[28].Value = model.OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale;
			parameters[29].Value = model.OfficeAutomation_Document_CoopCost_BillTypeClient;
			parameters[30].Value = model.OfficeAutomation_Document_CoopCost_ClientName;
			parameters[31].Value = model.OfficeAutomation_Document_CoopCost_IsClient;
			parameters[32].Value = model.OfficeAutomation_Document_CoopCost_ClientCoopCondition;
			parameters[33].Value = model.OfficeAutomation_Document_CoopCost_ClientCoopMoney;
			parameters[34].Value = model.OfficeAutomation_Document_CoopCost_ClientCoopScale;
			parameters[35].Value = model.OfficeAutomation_Document_CoopCost_ClientCoopTotalScale;
			parameters[36].Value = model.OfficeAutomation_Document_CoopCost_CoopMoney;
			parameters[37].Value = model.OfficeAutomation_Document_CoopCost_CoopTotalScale;
			parameters[38].Value = model.OfficeAutomation_Document_CoopCost_ActualComm;
			parameters[39].Value = model.OfficeAutomation_Document_CoopCost_ActualCommScale;
            parameters[40].Value = model.OfficeAutomation_Document_CoopCost_Remark;
            parameters[41].Value = model.OfficeAutomation_Document_CoopCost_OwnerReason;
            parameters[42].Value = model.OfficeAutomation_Document_CoopCost_ClientReason;
            parameters[43].Value = model.OfficeAutomation_Document_CoopCost_AddressDetail;
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
		public bool Update(DataEntity.T_OfficeAutomation_Document_CoopCost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_CoopCost set ");
			//strSql.Append("OfficeAutomation_Document_CoopCost_MainID=@OfficeAutomation_Document_CoopCost_MainID,");
			//strSql.Append("OfficeAutomation_Document_CoopCost_Apply=@OfficeAutomation_Document_CoopCost_Apply,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ApplyForName=@OfficeAutomation_Document_CoopCost_ApplyForName,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ApplyForCode=@OfficeAutomation_Document_CoopCost_ApplyForCode,");
			strSql.Append("OfficeAutomation_Document_CoopCost_Department=@OfficeAutomation_Document_CoopCost_Department,");
			strSql.Append("OfficeAutomation_Document_CoopCost_DepartmentID=@OfficeAutomation_Document_CoopCost_DepartmentID,");
			//strSql.Append("OfficeAutomation_Document_CoopCost_ApplyDate=@OfficeAutomation_Document_CoopCost_ApplyDate,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ReplyPhone=@OfficeAutomation_Document_CoopCost_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_CoopCost_DepartmentTypeID=@OfficeAutomation_Document_CoopCost_DepartmentTypeID,");
			strSql.Append("OfficeAutomation_Document_CoopCost_DealDate=@OfficeAutomation_Document_CoopCost_DealDate,");
			strSql.Append("OfficeAutomation_Document_CoopCost_PropertyName=@OfficeAutomation_Document_CoopCost_PropertyName,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ReportID=@OfficeAutomation_Document_CoopCost_ReportID,");
			strSql.Append("OfficeAutomation_Document_CoopCost_DealTypeID=@OfficeAutomation_Document_CoopCost_DealTypeID,");
			strSql.Append("OfficeAutomation_Document_CoopCost_Area=@OfficeAutomation_Document_CoopCost_Area,");
			strSql.Append("OfficeAutomation_Document_CoopCost_DealPrice=@OfficeAutomation_Document_CoopCost_DealPrice,");
			strSql.Append("OfficeAutomation_Document_CoopCost_OwnerComm=@OfficeAutomation_Document_CoopCost_OwnerComm,");
			strSql.Append("OfficeAutomation_Document_CoopCost_OwnerScale=@OfficeAutomation_Document_CoopCost_OwnerScale,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ClientComm=@OfficeAutomation_Document_CoopCost_ClientComm,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ClientScale=@OfficeAutomation_Document_CoopCost_ClientScale,");
			strSql.Append("OfficeAutomation_Document_CoopCost_TotalComm=@OfficeAutomation_Document_CoopCost_TotalComm,");
			strSql.Append("OfficeAutomation_Document_CoopCost_TotalScale=@OfficeAutomation_Document_CoopCost_TotalScale,");
			strSql.Append("OfficeAutomation_Document_CoopCost_BillTypeOwner=@OfficeAutomation_Document_CoopCost_BillTypeOwner,");
			strSql.Append("OfficeAutomation_Document_CoopCost_OwnerName=@OfficeAutomation_Document_CoopCost_OwnerName,");
			strSql.Append("OfficeAutomation_Document_CoopCost_IsOwner=@OfficeAutomation_Document_CoopCost_IsOwner,");
			strSql.Append("OfficeAutomation_Document_CoopCost_OwnerCoopCondition=@OfficeAutomation_Document_CoopCost_OwnerCoopCondition,");
			strSql.Append("OfficeAutomation_Document_CoopCost_OwnerCoopMoney=@OfficeAutomation_Document_CoopCost_OwnerCoopMoney,");
			strSql.Append("OfficeAutomation_Document_CoopCost_OwnerCoopScale=@OfficeAutomation_Document_CoopCost_OwnerCoopScale,");
			strSql.Append("OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale=@OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale,");
			strSql.Append("OfficeAutomation_Document_CoopCost_BillTypeClient=@OfficeAutomation_Document_CoopCost_BillTypeClient,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ClientName=@OfficeAutomation_Document_CoopCost_ClientName,");
			strSql.Append("OfficeAutomation_Document_CoopCost_IsClient=@OfficeAutomation_Document_CoopCost_IsClient,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ClientCoopCondition=@OfficeAutomation_Document_CoopCost_ClientCoopCondition,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ClientCoopMoney=@OfficeAutomation_Document_CoopCost_ClientCoopMoney,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ClientCoopScale=@OfficeAutomation_Document_CoopCost_ClientCoopScale,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ClientCoopTotalScale=@OfficeAutomation_Document_CoopCost_ClientCoopTotalScale,");
			strSql.Append("OfficeAutomation_Document_CoopCost_CoopMoney=@OfficeAutomation_Document_CoopCost_CoopMoney,");
			strSql.Append("OfficeAutomation_Document_CoopCost_CoopTotalScale=@OfficeAutomation_Document_CoopCost_CoopTotalScale,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ActualComm=@OfficeAutomation_Document_CoopCost_ActualComm,");
			strSql.Append("OfficeAutomation_Document_CoopCost_ActualCommScale=@OfficeAutomation_Document_CoopCost_ActualCommScale,");

            strSql.Append("OfficeAutomation_Document_CoopCost_OwnerReason=@OfficeAutomation_Document_CoopCost_OwnerReason,");
            strSql.Append("OfficeAutomation_Document_CoopCost_ClientReason=@OfficeAutomation_Document_CoopCost_ClientReason,");
            strSql.Append("OfficeAutomation_Document_CoopCost_AddressDetail=@OfficeAutomation_Document_CoopCost_AddressDetail");
			//strSql.Append("OfficeAutomation_Document_CoopCost_Remark=@OfficeAutomation_Document_CoopCost_Remark");
			strSql.Append(" where OfficeAutomation_Document_CoopCost_ID=@OfficeAutomation_Document_CoopCost_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_CoopCost_MainID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_CoopCost_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ApplyForName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ApplyForCode", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DepartmentID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_CoopCost_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DealDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_PropertyName", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ReportID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DealTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_Area", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_DealPrice", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerComm", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientComm", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_TotalComm", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_TotalScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_BillTypeOwner", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_IsOwner", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerCoopCondition", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerCoopMoney", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerCoopScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_BillTypeClient", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_IsClient", SqlDbType.Bit,1),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientCoopCondition", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientCoopMoney", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientCoopScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientCoopTotalScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_CoopMoney", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_CoopTotalScale", SqlDbType.NVarChar,8),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ActualComm", SqlDbType.NVarChar,16),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ActualCommScale", SqlDbType.NVarChar,8),

                    new SqlParameter("@OfficeAutomation_Document_CoopCost_OwnerReason", SqlDbType.NVarChar,200),
                    new SqlParameter("@OfficeAutomation_Document_CoopCost_ClientReason", SqlDbType.NVarChar,200),
                     new SqlParameter("@OfficeAutomation_Document_CoopCost_AddressDetail", SqlDbType.NVarChar,300),
					//new SqlParameter("@OfficeAutomation_Document_CoopCost_Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_CoopCost_MainID;
			//parameters[1].Value = model.OfficeAutomation_Document_CoopCost_Apply;
			parameters[0].Value = model.OfficeAutomation_Document_CoopCost_ApplyForName;
			parameters[1].Value = model.OfficeAutomation_Document_CoopCost_ApplyForCode;
			parameters[2].Value = model.OfficeAutomation_Document_CoopCost_Department;
			parameters[3].Value = model.OfficeAutomation_Document_CoopCost_DepartmentID;
			//parameter[6].Value = model.OfficeAutomation_Document_CoopCost_ApplyDate;
			parameters[4].Value = model.OfficeAutomation_Document_CoopCost_ReplyPhone;
			parameters[5].Value = model.OfficeAutomation_Document_CoopCost_DepartmentTypeID;
			parameters[6].Value = model.OfficeAutomation_Document_CoopCost_DealDate;
			parameters[7].Value = model.OfficeAutomation_Document_CoopCost_PropertyName;
			parameters[8].Value = model.OfficeAutomation_Document_CoopCost_ReportID;
			parameters[9].Value = model.OfficeAutomation_Document_CoopCost_DealTypeID;
			parameters[10].Value = model.OfficeAutomation_Document_CoopCost_Area;
			parameters[11].Value = model.OfficeAutomation_Document_CoopCost_DealPrice;
			parameters[12].Value = model.OfficeAutomation_Document_CoopCost_OwnerComm;
			parameters[13].Value = model.OfficeAutomation_Document_CoopCost_OwnerScale;
			parameters[14].Value = model.OfficeAutomation_Document_CoopCost_ClientComm;
			parameters[15].Value = model.OfficeAutomation_Document_CoopCost_ClientScale;
			parameters[16].Value = model.OfficeAutomation_Document_CoopCost_TotalComm;
			parameters[17].Value = model.OfficeAutomation_Document_CoopCost_TotalScale;
			parameters[18].Value = model.OfficeAutomation_Document_CoopCost_BillTypeOwner;
			parameters[19].Value = model.OfficeAutomation_Document_CoopCost_OwnerName;
			parameters[20].Value = model.OfficeAutomation_Document_CoopCost_IsOwner;
			parameters[21].Value = model.OfficeAutomation_Document_CoopCost_OwnerCoopCondition;
			parameters[22].Value = model.OfficeAutomation_Document_CoopCost_OwnerCoopMoney;
			parameters[23].Value = model.OfficeAutomation_Document_CoopCost_OwnerCoopScale;
			parameters[24].Value = model.OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale;
			parameters[25].Value = model.OfficeAutomation_Document_CoopCost_BillTypeClient;
			parameters[26].Value = model.OfficeAutomation_Document_CoopCost_ClientName;
			parameters[27].Value = model.OfficeAutomation_Document_CoopCost_IsClient;
			parameters[28].Value = model.OfficeAutomation_Document_CoopCost_ClientCoopCondition;
			parameters[29].Value = model.OfficeAutomation_Document_CoopCost_ClientCoopMoney;
			parameters[30].Value = model.OfficeAutomation_Document_CoopCost_ClientCoopScale;
			parameters[31].Value = model.OfficeAutomation_Document_CoopCost_ClientCoopTotalScale;
			parameters[32].Value = model.OfficeAutomation_Document_CoopCost_CoopMoney;
			parameters[33].Value = model.OfficeAutomation_Document_CoopCost_CoopTotalScale;
			parameters[34].Value = model.OfficeAutomation_Document_CoopCost_ActualComm;
			parameters[35].Value = model.OfficeAutomation_Document_CoopCost_ActualCommScale;
			//parameters[39].Value = model.OfficeAutomation_Document_CoopCost_Remark;
            parameters[36].Value = model.OfficeAutomation_Document_CoopCost_OwnerReason;
            parameters[37].Value = model.OfficeAutomation_Document_CoopCost_ClientReason;
            parameters[38].Value = model.OfficeAutomation_Document_CoopCost_AddressDetail;
            parameters[39].Value = model.OfficeAutomation_Document_CoopCost_ID;

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
		public bool Delete(string OfficeAutomation_Document_CoopCost_ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_CoopCost_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_CoopCost_ID);

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
		public bool DeleteList(string OfficeAutomation_Document_CoopCost_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_CoopCost ");
			strSql.Append(" where OfficeAutomation_Document_CoopCost_ID in ("+OfficeAutomation_Document_CoopCost_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_CoopCost GetModel(Guid OfficeAutomation_Document_CoopCost_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OfficeAutomation_Document_CoopCost_ID,OfficeAutomation_Document_CoopCost_MainID,OfficeAutomation_Document_CoopCost_Apply,OfficeAutomation_Document_CoopCost_ApplyForName,OfficeAutomation_Document_CoopCost_ApplyForCode,OfficeAutomation_Document_CoopCost_Department,OfficeAutomation_Document_CoopCost_DepartmentID,OfficeAutomation_Document_CoopCost_ApplyDate,OfficeAutomation_Document_CoopCost_ReplyPhone,OfficeAutomation_Document_CoopCost_DepartmentTypeID,OfficeAutomation_Document_CoopCost_DealDate,OfficeAutomation_Document_CoopCost_PropertyName,OfficeAutomation_Document_CoopCost_ReportID,OfficeAutomation_Document_CoopCost_DealTypeID,OfficeAutomation_Document_CoopCost_Area,OfficeAutomation_Document_CoopCost_DealPrice,OfficeAutomation_Document_CoopCost_OwnerComm,OfficeAutomation_Document_CoopCost_OwnerScale,OfficeAutomation_Document_CoopCost_ClientComm,OfficeAutomation_Document_CoopCost_ClientScale,OfficeAutomation_Document_CoopCost_TotalComm,OfficeAutomation_Document_CoopCost_TotalScale,OfficeAutomation_Document_CoopCost_BillTypeOwner,OfficeAutomation_Document_CoopCost_OwnerName,OfficeAutomation_Document_CoopCost_IsOwner,OfficeAutomation_Document_CoopCost_OwnerCoopCondition,OfficeAutomation_Document_CoopCost_OwnerCoopMoney,OfficeAutomation_Document_CoopCost_OwnerCoopScale,OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale,OfficeAutomation_Document_CoopCost_BillTypeClient,OfficeAutomation_Document_CoopCost_ClientName,OfficeAutomation_Document_CoopCost_IsClient,OfficeAutomation_Document_CoopCost_ClientCoopCondition,OfficeAutomation_Document_CoopCost_ClientCoopMoney,OfficeAutomation_Document_CoopCost_ClientCoopScale,OfficeAutomation_Document_CoopCost_ClientCoopTotalScale,OfficeAutomation_Document_CoopCost_CoopMoney,OfficeAutomation_Document_CoopCost_CoopTotalScale,OfficeAutomation_Document_CoopCost_ActualComm,OfficeAutomation_Document_CoopCost_ActualCommScale,OfficeAutomation_Document_CoopCost_Remark,OfficeAutomation_Document_CoopCost_OwnerReason,OfficeAutomation_Document_CoopCost_ClientReason from t_OfficeAutomation_Document_CoopCost ");
			strSql.Append(" where OfficeAutomation_Document_CoopCost_ID=@OfficeAutomation_Document_CoopCost_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_CoopCost_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_CoopCost_ID;

			DataEntity.T_OfficeAutomation_Document_CoopCost model=new DataEntity.T_OfficeAutomation_Document_CoopCost();
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
		public DataEntity.T_OfficeAutomation_Document_CoopCost DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_CoopCost model=new DataEntity.T_OfficeAutomation_Document_CoopCost();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_CoopCost_ID"]!=null && row["OfficeAutomation_Document_CoopCost_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_CoopCost_ID= new Guid(row["OfficeAutomation_Document_CoopCost_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_CoopCost_MainID"]!=null && row["OfficeAutomation_Document_CoopCost_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_CoopCost_MainID= new Guid(row["OfficeAutomation_Document_CoopCost_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_CoopCost_Apply"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_Apply=row["OfficeAutomation_Document_CoopCost_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ApplyForName"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ApplyForName=row["OfficeAutomation_Document_CoopCost_ApplyForName"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ApplyForCode"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ApplyForCode=row["OfficeAutomation_Document_CoopCost_ApplyForCode"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_Department"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_Department=row["OfficeAutomation_Document_CoopCost_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_DepartmentID"]!=null && row["OfficeAutomation_Document_CoopCost_DepartmentID"].ToString()!="")
				{
					model.OfficeAutomation_Document_CoopCost_DepartmentID= new Guid(row["OfficeAutomation_Document_CoopCost_DepartmentID"].ToString());
				}
				if(row["OfficeAutomation_Document_CoopCost_ApplyDate"]!=null && row["OfficeAutomation_Document_CoopCost_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_CoopCost_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_CoopCost_ApplyDate"].ToString());
				}
				if(row["OfficeAutomation_Document_CoopCost_ReplyPhone"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ReplyPhone=row["OfficeAutomation_Document_CoopCost_ReplyPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_DepartmentTypeID"]!=null && row["OfficeAutomation_Document_CoopCost_DepartmentTypeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_CoopCost_DepartmentTypeID=int.Parse(row["OfficeAutomation_Document_CoopCost_DepartmentTypeID"].ToString());
				}
				if(row["OfficeAutomation_Document_CoopCost_DealDate"]!=null && row["OfficeAutomation_Document_CoopCost_DealDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_CoopCost_DealDate=DateTime.Parse(row["OfficeAutomation_Document_CoopCost_DealDate"].ToString());
				}
				if(row["OfficeAutomation_Document_CoopCost_PropertyName"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_PropertyName=row["OfficeAutomation_Document_CoopCost_PropertyName"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ReportID"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ReportID=row["OfficeAutomation_Document_CoopCost_ReportID"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_DealTypeID"]!=null && row["OfficeAutomation_Document_CoopCost_DealTypeID"].ToString()!="")
				{
					model.OfficeAutomation_Document_CoopCost_DealTypeID=int.Parse(row["OfficeAutomation_Document_CoopCost_DealTypeID"].ToString());
				}
				if(row["OfficeAutomation_Document_CoopCost_Area"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_Area=row["OfficeAutomation_Document_CoopCost_Area"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_DealPrice"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_DealPrice=row["OfficeAutomation_Document_CoopCost_DealPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_OwnerComm"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_OwnerComm=row["OfficeAutomation_Document_CoopCost_OwnerComm"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_OwnerScale"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_OwnerScale=row["OfficeAutomation_Document_CoopCost_OwnerScale"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ClientComm"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ClientComm=row["OfficeAutomation_Document_CoopCost_ClientComm"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ClientScale"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ClientScale=row["OfficeAutomation_Document_CoopCost_ClientScale"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_TotalComm"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_TotalComm=row["OfficeAutomation_Document_CoopCost_TotalComm"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_TotalScale"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_TotalScale=row["OfficeAutomation_Document_CoopCost_TotalScale"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_BillTypeOwner"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_BillTypeOwner=row["OfficeAutomation_Document_CoopCost_BillTypeOwner"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_OwnerName"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_OwnerName=row["OfficeAutomation_Document_CoopCost_OwnerName"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_IsOwner"]!=null && row["OfficeAutomation_Document_CoopCost_IsOwner"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_CoopCost_IsOwner"].ToString()=="1")||(row["OfficeAutomation_Document_CoopCost_IsOwner"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_CoopCost_IsOwner=true;
					}
					else
					{
						model.OfficeAutomation_Document_CoopCost_IsOwner=false;
					}
				}
				if(row["OfficeAutomation_Document_CoopCost_OwnerCoopCondition"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_OwnerCoopCondition=row["OfficeAutomation_Document_CoopCost_OwnerCoopCondition"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_OwnerCoopMoney"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_OwnerCoopMoney=row["OfficeAutomation_Document_CoopCost_OwnerCoopMoney"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_OwnerCoopScale"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_OwnerCoopScale=row["OfficeAutomation_Document_CoopCost_OwnerCoopScale"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale=row["OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_BillTypeClient"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_BillTypeClient=row["OfficeAutomation_Document_CoopCost_BillTypeClient"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ClientName"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ClientName=row["OfficeAutomation_Document_CoopCost_ClientName"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_IsClient"]!=null && row["OfficeAutomation_Document_CoopCost_IsClient"].ToString()!="")
				{
					if((row["OfficeAutomation_Document_CoopCost_IsClient"].ToString()=="1")||(row["OfficeAutomation_Document_CoopCost_IsClient"].ToString().ToLower()=="true"))
					{
						model.OfficeAutomation_Document_CoopCost_IsClient=true;
					}
					else
					{
						model.OfficeAutomation_Document_CoopCost_IsClient=false;
					}
				}
				if(row["OfficeAutomation_Document_CoopCost_ClientCoopCondition"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ClientCoopCondition=row["OfficeAutomation_Document_CoopCost_ClientCoopCondition"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ClientCoopMoney"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ClientCoopMoney=row["OfficeAutomation_Document_CoopCost_ClientCoopMoney"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ClientCoopScale"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ClientCoopScale=row["OfficeAutomation_Document_CoopCost_ClientCoopScale"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ClientCoopTotalScale"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ClientCoopTotalScale=row["OfficeAutomation_Document_CoopCost_ClientCoopTotalScale"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_CoopMoney"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_CoopMoney=row["OfficeAutomation_Document_CoopCost_CoopMoney"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_CoopTotalScale"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_CoopTotalScale=row["OfficeAutomation_Document_CoopCost_CoopTotalScale"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ActualComm"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ActualComm=row["OfficeAutomation_Document_CoopCost_ActualComm"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_ActualCommScale"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_ActualCommScale=row["OfficeAutomation_Document_CoopCost_ActualCommScale"].ToString();
				}
				if(row["OfficeAutomation_Document_CoopCost_Remark"]!=null)
				{
					model.OfficeAutomation_Document_CoopCost_Remark=row["OfficeAutomation_Document_CoopCost_Remark"].ToString();
				}
                if (row["OfficeAutomation_Document_CoopCost_OwnerReason"] != null)
                {
                    model.OfficeAutomation_Document_CoopCost_OwnerReason = row["OfficeAutomation_Document_CoopCost_OwnerReason"].ToString();
                }
                if (row["OfficeAutomation_Document_CoopCost_ClientReason"] != null)
                {
                    model.OfficeAutomation_Document_CoopCost_ClientReason = row["OfficeAutomation_Document_CoopCost_ClientReason"].ToString();
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
            strSql.Append("select OfficeAutomation_Document_CoopCost_ID,OfficeAutomation_Document_CoopCost_MainID,OfficeAutomation_Document_CoopCost_Apply,OfficeAutomation_Document_CoopCost_ApplyForName,OfficeAutomation_Document_CoopCost_ApplyForCode,OfficeAutomation_Document_CoopCost_Department,OfficeAutomation_Document_CoopCost_DepartmentID,OfficeAutomation_Document_CoopCost_ApplyDate,OfficeAutomation_Document_CoopCost_ReplyPhone,OfficeAutomation_Document_CoopCost_DepartmentTypeID,OfficeAutomation_Document_CoopCost_DealDate,OfficeAutomation_Document_CoopCost_PropertyName,OfficeAutomation_Document_CoopCost_ReportID,OfficeAutomation_Document_CoopCost_DealTypeID,OfficeAutomation_Document_CoopCost_Area,OfficeAutomation_Document_CoopCost_DealPrice,OfficeAutomation_Document_CoopCost_OwnerComm,OfficeAutomation_Document_CoopCost_OwnerScale,OfficeAutomation_Document_CoopCost_ClientComm,OfficeAutomation_Document_CoopCost_ClientScale,OfficeAutomation_Document_CoopCost_TotalComm,OfficeAutomation_Document_CoopCost_TotalScale,OfficeAutomation_Document_CoopCost_BillTypeOwner,OfficeAutomation_Document_CoopCost_OwnerName,OfficeAutomation_Document_CoopCost_IsOwner,OfficeAutomation_Document_CoopCost_OwnerCoopCondition,OfficeAutomation_Document_CoopCost_OwnerCoopMoney,OfficeAutomation_Document_CoopCost_OwnerCoopScale,OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale,OfficeAutomation_Document_CoopCost_BillTypeClient,OfficeAutomation_Document_CoopCost_ClientName,OfficeAutomation_Document_CoopCost_IsClient,OfficeAutomation_Document_CoopCost_ClientCoopCondition,OfficeAutomation_Document_CoopCost_ClientCoopMoney,OfficeAutomation_Document_CoopCost_ClientCoopScale,OfficeAutomation_Document_CoopCost_ClientCoopTotalScale,OfficeAutomation_Document_CoopCost_CoopMoney,OfficeAutomation_Document_CoopCost_CoopTotalScale,OfficeAutomation_Document_CoopCost_ActualComm,OfficeAutomation_Document_CoopCost_ActualCommScale,OfficeAutomation_Document_CoopCost_Remark,OfficeAutomation_Document_CoopCost_OwnerReason,OfficeAutomation_Document_CoopCost_ClientReason ");
			strSql.Append(" FROM t_OfficeAutomation_Document_CoopCost ");
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
            strSql.Append(" OfficeAutomation_Document_CoopCost_ID,OfficeAutomation_Document_CoopCost_MainID,OfficeAutomation_Document_CoopCost_Apply,OfficeAutomation_Document_CoopCost_ApplyForName,OfficeAutomation_Document_CoopCost_ApplyForCode,OfficeAutomation_Document_CoopCost_Department,OfficeAutomation_Document_CoopCost_DepartmentID,OfficeAutomation_Document_CoopCost_ApplyDate,OfficeAutomation_Document_CoopCost_ReplyPhone,OfficeAutomation_Document_CoopCost_DepartmentTypeID,OfficeAutomation_Document_CoopCost_DealDate,OfficeAutomation_Document_CoopCost_PropertyName,OfficeAutomation_Document_CoopCost_ReportID,OfficeAutomation_Document_CoopCost_DealTypeID,OfficeAutomation_Document_CoopCost_Area,OfficeAutomation_Document_CoopCost_DealPrice,OfficeAutomation_Document_CoopCost_OwnerComm,OfficeAutomation_Document_CoopCost_OwnerScale,OfficeAutomation_Document_CoopCost_ClientComm,OfficeAutomation_Document_CoopCost_ClientScale,OfficeAutomation_Document_CoopCost_TotalComm,OfficeAutomation_Document_CoopCost_TotalScale,OfficeAutomation_Document_CoopCost_BillTypeOwner,OfficeAutomation_Document_CoopCost_OwnerName,OfficeAutomation_Document_CoopCost_IsOwner,OfficeAutomation_Document_CoopCost_OwnerCoopCondition,OfficeAutomation_Document_CoopCost_OwnerCoopMoney,OfficeAutomation_Document_CoopCost_OwnerCoopScale,OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale,OfficeAutomation_Document_CoopCost_BillTypeClient,OfficeAutomation_Document_CoopCost_ClientName,OfficeAutomation_Document_CoopCost_IsClient,OfficeAutomation_Document_CoopCost_ClientCoopCondition,OfficeAutomation_Document_CoopCost_ClientCoopMoney,OfficeAutomation_Document_CoopCost_ClientCoopScale,OfficeAutomation_Document_CoopCost_ClientCoopTotalScale,OfficeAutomation_Document_CoopCost_CoopMoney,OfficeAutomation_Document_CoopCost_CoopTotalScale,OfficeAutomation_Document_CoopCost_ActualComm,OfficeAutomation_Document_CoopCost_ActualCommScale,OfficeAutomation_Document_CoopCost_Remark,OfficeAutomation_Document_CoopCost_OwnerReason,OfficeAutomation_Document_CoopCost_ClientReason ");
			strSql.Append(" FROM t_OfficeAutomation_Document_CoopCost ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_CoopCost ");
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
				strSql.Append("order by T.OfficeAutomation_Document_CoopCost_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_CoopCost T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_CoopCost";
			parameters[1].Value = "OfficeAutomation_Document_CoopCost_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public T_OfficeAutomation_Document_CoopCost TemAdd(T_OfficeAutomation_Document_CoopCost t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_CoopCost TemEdit(T_OfficeAutomation_Document_CoopCost t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_CoopCost t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_CoopCost GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_CoopCost>(where);
        }
		#endregion  ExtensionMethod
	}
}

