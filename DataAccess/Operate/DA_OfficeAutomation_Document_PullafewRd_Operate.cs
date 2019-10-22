using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PullafewRd_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_PullafewRd _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_PullafewRd> dal;

        public DA_OfficeAutomation_Document_PullafewRd_Operate() 
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_PullafewRd>();
        }
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewRd]"
                                                        + "           ([OfficeAutomation_Document_PullafewRd_ID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_MainID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_Apply]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_Department]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1a]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1b]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1c]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1d]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1e]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1f]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1g]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1h]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1i]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1j]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1k]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1l]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1m]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1n]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1o]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1p]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1q]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1r]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1s]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1t]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1ut]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1u]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1v]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_2a]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_2b]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_2c]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_2d]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_2e]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_2f]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4a]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4b]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4c]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4cc]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4d]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4dd]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4e]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4f]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4g]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_4h]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1pa]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_1fc]"
                                                        + "           )"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_PullafewRd_ID"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_MainID"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_Apply"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_Department"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1a"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1b"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1c"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1d"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1e"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1f"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1g"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1h"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1i"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1j"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1k"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1l"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1m"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1n"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1o"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1p"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1q"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1r"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1s"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1t"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1ut"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1u"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1v"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_2a"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_2b"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_2c"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_2d"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_2e"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_2f"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4a"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4b"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4c"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4cc"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4d"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4dd"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4e"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4f"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4g"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_4h"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1pa"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_1fc"
                                                        + "           )";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PullafewRd)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1h));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1i", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1i));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1j", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1j));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1k", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1k));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1l", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1l));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1m", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1m));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1n", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1n));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1o", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1o));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1p", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1p));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1q", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1q));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1r", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1r));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1s", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1s));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1t", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1t));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1ut", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1ut));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1u", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1u));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1v", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1v));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2f));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4cc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4cc));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4dd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4dd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4h));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1pa", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1pa));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1fc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1fc));
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
            cmdToExecute.CommandText = "dbo.[pr_PullafewRd_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewRd]"
                                + "         SET [OfficeAutomation_Document_PullafewRd_ApplyID] = @OfficeAutomation_Document_PullafewRd_ApplyID"
                                + "         ,[OfficeAutomation_Document_PullafewRd_Department] = @OfficeAutomation_Document_PullafewRd_Department"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1a] = @OfficeAutomation_Document_PullafewRd_1a"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1b] = @OfficeAutomation_Document_PullafewRd_1b"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1c] = @OfficeAutomation_Document_PullafewRd_1c"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1d] = @OfficeAutomation_Document_PullafewRd_1d"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1e] = @OfficeAutomation_Document_PullafewRd_1e"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1f] = @OfficeAutomation_Document_PullafewRd_1f"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1g] = @OfficeAutomation_Document_PullafewRd_1g"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1h] = @OfficeAutomation_Document_PullafewRd_1h"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1i] = @OfficeAutomation_Document_PullafewRd_1i"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1j] = @OfficeAutomation_Document_PullafewRd_1j"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1k] = @OfficeAutomation_Document_PullafewRd_1k"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1l] = @OfficeAutomation_Document_PullafewRd_1l"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1m] = @OfficeAutomation_Document_PullafewRd_1m"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1n] = @OfficeAutomation_Document_PullafewRd_1n"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1o] = @OfficeAutomation_Document_PullafewRd_1o"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1p] = @OfficeAutomation_Document_PullafewRd_1p"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1q] = @OfficeAutomation_Document_PullafewRd_1q"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1r] = @OfficeAutomation_Document_PullafewRd_1r"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1s] = @OfficeAutomation_Document_PullafewRd_1s"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1t] = @OfficeAutomation_Document_PullafewRd_1t"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1ut] = @OfficeAutomation_Document_PullafewRd_1ut"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1u] = @OfficeAutomation_Document_PullafewRd_1u"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1v] = @OfficeAutomation_Document_PullafewRd_1v"
                                + "         ,[OfficeAutomation_Document_PullafewRd_2a] = @OfficeAutomation_Document_PullafewRd_2a"
                                + "         ,[OfficeAutomation_Document_PullafewRd_2b] = @OfficeAutomation_Document_PullafewRd_2b"
                                + "         ,[OfficeAutomation_Document_PullafewRd_2c] = @OfficeAutomation_Document_PullafewRd_2c"
                                + "         ,[OfficeAutomation_Document_PullafewRd_2d] = @OfficeAutomation_Document_PullafewRd_2d"
                                + "         ,[OfficeAutomation_Document_PullafewRd_2e] = @OfficeAutomation_Document_PullafewRd_2e"
                                + "         ,[OfficeAutomation_Document_PullafewRd_2f] = @OfficeAutomation_Document_PullafewRd_2f"

                                + "         ,[OfficeAutomation_Document_PullafewRd_4a] = @OfficeAutomation_Document_PullafewRd_4a"
                                + "         ,[OfficeAutomation_Document_PullafewRd_4b] = @OfficeAutomation_Document_PullafewRd_4b"
                                + "         ,[OfficeAutomation_Document_PullafewRd_4c] = @OfficeAutomation_Document_PullafewRd_4c"
                                + "         ,[OfficeAutomation_Document_PullafewRd_4cc] = @OfficeAutomation_Document_PullafewRd_4cc"
                                + "         ,[OfficeAutomation_Document_PullafewRd_4d] = @OfficeAutomation_Document_PullafewRd_4d"
                                + "         ,[OfficeAutomation_Document_PullafewRd_4dd] = @OfficeAutomation_Document_PullafewRd_4dd"
                                + "         ,[OfficeAutomation_Document_PullafewRd_4e] = @OfficeAutomation_Document_PullafewRd_4e"
                                + "         ,[OfficeAutomation_Document_PullafewRd_4f] = @OfficeAutomation_Document_PullafewRd_4f"
                                + "         ,[OfficeAutomation_Document_PullafewRd_4g] = @OfficeAutomation_Document_PullafewRd_4g"
                                + "         ,[OfficeAutomation_Document_PullafewRd_4h] = @OfficeAutomation_Document_PullafewRd_4h"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1pa] = @OfficeAutomation_Document_PullafewRd_1pa"
                                + "         ,[OfficeAutomation_Document_PullafewRd_1fc] = @OfficeAutomation_Document_PullafewRd_1fc"
                                + "         WHERE [OfficeAutomation_Document_PullafewRd_ID]=@OfficeAutomation_Document_PullafewRd_ID"
                                + "         AND [OfficeAutomation_Document_PullafewRd_MainID]=@OfficeAutomation_Document_PullafewRd_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PullafewRd)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1h));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1i", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1i));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1j", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1j));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1k", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1k));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1l", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1l));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1m", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1m));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1n", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1n));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1o", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1o));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1p", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1p));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1q", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1q));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1r", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1r));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1s", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1s));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1t", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1t));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1ut", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1ut));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1u", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1u));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1v", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1v));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_2f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_2f));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4cc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4cc));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4dd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4dd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_4h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_4h));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1pa", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1pa));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_1fc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_1fc));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_MainID));

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

        #region 自定义方法
        public T_OfficeAutomation_Document_PullafewRd Add(T_OfficeAutomation_Document_PullafewRd t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_PullafewRd Edit(T_OfficeAutomation_Document_PullafewRd t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_PullafewRd t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_PullafewRd GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_PullafewRd>(where);
        }
        #endregion
    }
}
