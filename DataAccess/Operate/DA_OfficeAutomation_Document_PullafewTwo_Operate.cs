using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using SqlDatabase;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PullafewTwo_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_PullafewTwo _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_PullafewTwo> dal;
        #endregion
        public DA_OfficeAutomation_Document_PullafewTwo_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_PullafewTwo>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo]"
                                                        + "           ([OfficeAutomation_Document_PullafewTwo_ID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_MainID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Apply]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Department]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1a]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1b]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1c]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1d]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1e]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1f]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1g]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1h]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1i]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1ii]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1j]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1k]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1l]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1m]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1n]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1o]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1p]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1q]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1r]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1s]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1t]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1u]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_1v]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_2a]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_2b]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_2c]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_2cc]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_2d]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_2f]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_2g]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_2h]"

                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_4a]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_4b]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_4c]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_4cc]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_4d]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_4dd]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_4e]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_4f]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_4g])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_PullafewTwo_ID"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_MainID"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Apply"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Department"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1a"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1b"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1c"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1d"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1e"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1f"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1g"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1h"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1i"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1ii"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1j"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1k"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1l"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1m"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1n"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1o"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1p"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1q"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1r"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1s"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1t"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1u"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_1v"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_2a"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_2b"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_2c"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_2cc"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_2d"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_2f"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_2g"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_2h"

                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_4a"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_4b"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_4c"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_4cc"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_4d"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_4dd"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_4e"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_4f"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_4g)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PullafewTwo)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1h));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1i", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1i));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1ii", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1ii));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1j", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1j));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1k", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1k));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1l", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1l));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1m", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1m));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1n", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1n));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1o", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1o));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1p", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1p));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1q", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1q));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1r", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1r));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1s", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1s));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1t", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1t));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1u", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1u));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1v", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1v));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2cc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2cc));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2h));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4cc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4cc));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4dd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4dd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4g));

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
            cmdToExecute.CommandText = "dbo.[pr_PullafewTwo_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo]"
                                + "         SET [OfficeAutomation_Document_PullafewTwo_ApplyID] = @OfficeAutomation_Document_PullafewTwo_ApplyID"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_Department] = @OfficeAutomation_Document_PullafewTwo_Department"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1a] = @OfficeAutomation_Document_PullafewTwo_1a"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1b] = @OfficeAutomation_Document_PullafewTwo_1b"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1c] = @OfficeAutomation_Document_PullafewTwo_1c"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1d] = @OfficeAutomation_Document_PullafewTwo_1d"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1e] = @OfficeAutomation_Document_PullafewTwo_1e"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1f] = @OfficeAutomation_Document_PullafewTwo_1f"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1g] = @OfficeAutomation_Document_PullafewTwo_1g"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1h] = @OfficeAutomation_Document_PullafewTwo_1h"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1i] = @OfficeAutomation_Document_PullafewTwo_1i"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1ii] = @OfficeAutomation_Document_PullafewTwo_1ii"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1j] = @OfficeAutomation_Document_PullafewTwo_1j"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1k] = @OfficeAutomation_Document_PullafewTwo_1k"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1l] = @OfficeAutomation_Document_PullafewTwo_1l"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1m] = @OfficeAutomation_Document_PullafewTwo_1m"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1n] = @OfficeAutomation_Document_PullafewTwo_1n"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1o] = @OfficeAutomation_Document_PullafewTwo_1o"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1p] = @OfficeAutomation_Document_PullafewTwo_1p"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1q] = @OfficeAutomation_Document_PullafewTwo_1q"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1r] = @OfficeAutomation_Document_PullafewTwo_1r"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1s] = @OfficeAutomation_Document_PullafewTwo_1s"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1t] = @OfficeAutomation_Document_PullafewTwo_1t"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1u] = @OfficeAutomation_Document_PullafewTwo_1u"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_1v] = @OfficeAutomation_Document_PullafewTwo_1v"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_2a] = @OfficeAutomation_Document_PullafewTwo_2a"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_2b] = @OfficeAutomation_Document_PullafewTwo_2b"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_2c] = @OfficeAutomation_Document_PullafewTwo_2c"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_2cc] = @OfficeAutomation_Document_PullafewTwo_2cc"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_2d] = @OfficeAutomation_Document_PullafewTwo_2d"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_2f] = @OfficeAutomation_Document_PullafewTwo_2f"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_2g] = @OfficeAutomation_Document_PullafewTwo_2g"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_2h] = @OfficeAutomation_Document_PullafewTwo_2h"

                                + "         ,[OfficeAutomation_Document_PullafewTwo_4a] = @OfficeAutomation_Document_PullafewTwo_4a"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_4b] = @OfficeAutomation_Document_PullafewTwo_4b"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_4c] = @OfficeAutomation_Document_PullafewTwo_4c"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_4cc] = @OfficeAutomation_Document_PullafewTwo_4cc"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_4d] = @OfficeAutomation_Document_PullafewTwo_4d"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_4dd] = @OfficeAutomation_Document_PullafewTwo_4dd"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_4e] = @OfficeAutomation_Document_PullafewTwo_4e"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_4f] = @OfficeAutomation_Document_PullafewTwo_4f"
                                + "         ,[OfficeAutomation_Document_PullafewTwo_4g] = @OfficeAutomation_Document_PullafewTwo_4g"

                                + "         WHERE [OfficeAutomation_Document_PullafewTwo_ID]=@OfficeAutomation_Document_PullafewTwo_ID"
                                + "         AND [OfficeAutomation_Document_PullafewTwo_MainID]=@OfficeAutomation_Document_PullafewTwo_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PullafewTwo)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1h));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1i", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1i));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1ii", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1ii));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1j", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1j));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1k", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1k));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1l", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1l));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1m", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1m));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1n", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1n));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1o", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1o));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1p", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1p));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1q", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1q));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1r", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1r));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1s", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1s));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1t", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1t));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1u", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1u));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_1v", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_1v));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2cc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2cc));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_2h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_2h));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4cc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4cc));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4dd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4dd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_4g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_4g));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_MainID));

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
        public T_OfficeAutomation_Document_PullafewTwo Add(T_OfficeAutomation_Document_PullafewTwo t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_PullafewTwo Edit(T_OfficeAutomation_Document_PullafewTwo t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_PullafewTwo t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_PullafewTwo GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_PullafewTwo>(where);
        }
        #endregion
    }
}
