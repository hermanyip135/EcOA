using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAL;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Flow_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Flow _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_OfficeAutomation_Flow_Insert";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Flow)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Employee", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Employee));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_EmployeeID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_EmployeeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_Idx", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Idx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Flow_Audit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Audit));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Suggestion", this._objMessage.OfficeAutomation_Flow_Suggestion));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Flow_AuditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_AuditDate));

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
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Update(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_OfficeAutomation_Flow_Update";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Flow)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Employee", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Employee));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_EmployeeID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_EmployeeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_Idx", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Idx));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Flow_Audit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Audit));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Suggestion", this._objMessage.OfficeAutomation_Flow_Suggestion));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Flow_AuditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_AuditDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Auditor", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Auditor));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_AuditorID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_AuditorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_IsAgree", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_IsAgree));

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
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateByMainIDAndIdx(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_OfficeAutomation_Flow_UpdateByMainIDAndIdx";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Flow)obj;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Employee", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Employee));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_EmployeeID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_EmployeeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_Idx", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Idx));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Flow_Audit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Audit));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Suggestion", this._objMessage.OfficeAutomation_Flow_Suggestion));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Flow_AuditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_AuditDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Auditor", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_Auditor));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_AuditorID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_AuditorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_IsAgree", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Flow_IsAgree));

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

       
    }
}
