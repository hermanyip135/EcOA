using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Maintenance_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Maintenance _objMessage = null;
        private DAL.DalBase<T_OfficeAutomation_Document_Maintenance> dal;
        #endregion

        public DA_OfficeAutomation_Document_Maintenance_Operate() 
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_Maintenance>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Maintenance]"
                                                        + "           ([OfficeAutomation_Document_Maintenance_ID]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_Department]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ReceiveDepartment]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_CCDepartment]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_Subject]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_Fax]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_StartDate]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_Cycle]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_DepreciationB]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_DContent]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_DueToDate]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_RenovationDate]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_RContent]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_Rprice]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ResultsBeginDate]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ResultsEndDate]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ProfitBeginDate]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ProfitEndDate]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_LeaseDate]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ResultsCoast]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_ProfitCoast]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_IsLease]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_StartDateMonth]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_CycleMonth]"
                                                        + "           ,[OfficeAutomation_Document_Maintenance_Describe])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_Maintenance_ID"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_MainID"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_Apply"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_Department"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ReceiveDepartment"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_CCDepartment"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_Subject"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ReplyPhone"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_Fax"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_StartDate"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_Cycle"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_DepreciationB"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_DContent"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_DueToDate"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_RenovationDate"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_RContent"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_Rprice"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ResultsBeginDate"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ResultsEndDate"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ProfitBeginDate"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ProfitEndDate"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_LeaseDate"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ResultsCoast"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_ProfitCoast"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_IsLease"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_StartDateMonth"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_CycleMonth"
                                                        + "           ,@OfficeAutomation_Document_Maintenance_Describe)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Maintenance)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ReceiveDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ReceiveDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_CCDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_CCDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_StartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_StartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Cycle", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Cycle));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_DepreciationB", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_DepreciationB));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_DContent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_DContent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_DueToDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_DueToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_RenovationDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_RenovationDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_RContent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_RContent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Rprice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Rprice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ResultsBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ResultsBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ResultsEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ResultsEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ProfitBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ProfitBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ProfitEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ProfitEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_LeaseDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_LeaseDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ResultsCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ResultsCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ProfitCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ProfitCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_IsLease", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_IsLease));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_StartDateMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_StartDateMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_CycleMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_CycleMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Describe", SqlDbType.Text, 999999, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Describe));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public bool Delete(string mainID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_Maintenance_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sMainID", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, mainID));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }

                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }
        #endregion

        #region 更新记录
        public override bool Update(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Maintenance]"
                                + "         SET [OfficeAutomation_Document_Maintenance_ApplyID] = @OfficeAutomation_Document_Maintenance_ApplyID"
                                + "         ,[OfficeAutomation_Document_Maintenance_Department] = @OfficeAutomation_Document_Maintenance_Department"
                                + "         ,[OfficeAutomation_Document_Maintenance_ReceiveDepartment] = @OfficeAutomation_Document_Maintenance_ReceiveDepartment"
                                + "         ,[OfficeAutomation_Document_Maintenance_CCDepartment] = @OfficeAutomation_Document_Maintenance_CCDepartment"
                                + "         ,[OfficeAutomation_Document_Maintenance_Subject] = @OfficeAutomation_Document_Maintenance_Subject"
                                + "         ,[OfficeAutomation_Document_Maintenance_ReplyPhone] = @OfficeAutomation_Document_Maintenance_ReplyPhone"
                                + "         ,[OfficeAutomation_Document_Maintenance_Fax] = @OfficeAutomation_Document_Maintenance_Fax"
                                + "         ,[OfficeAutomation_Document_Maintenance_StartDate] = @OfficeAutomation_Document_Maintenance_StartDate"
                                + "         ,[OfficeAutomation_Document_Maintenance_Cycle] = @OfficeAutomation_Document_Maintenance_Cycle"
                                + "         ,[OfficeAutomation_Document_Maintenance_DepreciationB] = @OfficeAutomation_Document_Maintenance_DepreciationB"
                                + "         ,[OfficeAutomation_Document_Maintenance_DContent] = @OfficeAutomation_Document_Maintenance_DContent"
                                + "         ,[OfficeAutomation_Document_Maintenance_DueToDate] = @OfficeAutomation_Document_Maintenance_DueToDate"
                                + "         ,[OfficeAutomation_Document_Maintenance_RenovationDate] = @OfficeAutomation_Document_Maintenance_RenovationDate"
                                + "         ,[OfficeAutomation_Document_Maintenance_RContent] = @OfficeAutomation_Document_Maintenance_RContent"
                                + "         ,[OfficeAutomation_Document_Maintenance_Rprice] = @OfficeAutomation_Document_Maintenance_Rprice"
                                + "         ,[OfficeAutomation_Document_Maintenance_ResultsBeginDate] = @OfficeAutomation_Document_Maintenance_ResultsBeginDate"
                                + "         ,[OfficeAutomation_Document_Maintenance_ResultsEndDate] = @OfficeAutomation_Document_Maintenance_ResultsEndDate"
                                + "         ,[OfficeAutomation_Document_Maintenance_ProfitBeginDate] = @OfficeAutomation_Document_Maintenance_ProfitBeginDate"
                                + "         ,[OfficeAutomation_Document_Maintenance_ProfitEndDate] = @OfficeAutomation_Document_Maintenance_ProfitEndDate"
                                + "         ,[OfficeAutomation_Document_Maintenance_LeaseDate] = @OfficeAutomation_Document_Maintenance_LeaseDate"
                                + "         ,[OfficeAutomation_Document_Maintenance_ResultsCoast] = @OfficeAutomation_Document_Maintenance_ResultsCoast"
                                + "         ,[OfficeAutomation_Document_Maintenance_ProfitCoast] = @OfficeAutomation_Document_Maintenance_ProfitCoast"
                                + "         ,[OfficeAutomation_Document_Maintenance_IsLease] = @OfficeAutomation_Document_Maintenance_IsLease"
                                + "         ,[OfficeAutomation_Document_Maintenance_StartDateMonth] = @OfficeAutomation_Document_Maintenance_StartDateMonth"
                                + "         ,[OfficeAutomation_Document_Maintenance_CycleMonth] = @OfficeAutomation_Document_Maintenance_CycleMonth"
                                + "         ,[OfficeAutomation_Document_Maintenance_Describe] = @OfficeAutomation_Document_Maintenance_Describe"
                                + "         WHERE [OfficeAutomation_Document_Maintenance_ID]=@OfficeAutomation_Document_Maintenance_ID"
                                + "         AND [OfficeAutomation_Document_Maintenance_MainID]=@OfficeAutomation_Document_Maintenance_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Maintenance)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ReceiveDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ReceiveDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_CCDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_CCDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_StartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_StartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Cycle", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Cycle));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_DepreciationB", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_DepreciationB));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_DContent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_DContent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_DueToDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_DueToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_RenovationDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_RenovationDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_RContent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_RContent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Rprice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Rprice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ResultsBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ResultsBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ResultsEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ResultsEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ProfitBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ProfitBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ProfitEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ProfitEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_LeaseDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_LeaseDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ResultsCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ResultsCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ProfitCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ProfitCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_IsLease", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_IsLease));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_StartDateMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_StartDateMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_CycleMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_CycleMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_Describe", SqlDbType.Text, 999999, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_Describe));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Maintenance_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Maintenance_MainID));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }
        #endregion

        #region  ExtensionMethod
        public T_OfficeAutomation_Document_Maintenance Insert(T_OfficeAutomation_Document_Maintenance t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_Maintenance Edit(T_OfficeAutomation_Document_Maintenance t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_Maintenance t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_Maintenance GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_Maintenance>(where);
        }
        #endregion  ExtensionMethod
    }
}
