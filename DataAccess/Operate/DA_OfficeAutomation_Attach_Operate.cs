using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Attach_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Attach _objMessage = null;
        #endregion

        #region 返回一记录
        /// <summary>
        /// 返回主表一记录
        /// </summary>
        /// <returns></returns>
        public override object SelectOne(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_OfficeAutomation_Attach_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            DataSet toReturn = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            cmdToExecute.Connection = _mainConnection;

            try
            {
                this._objMessage = new DataEntity.T_OfficeAutomation_Attach();

                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Attach_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _objMessage.OfficeAutomation_Attach_ID));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(toReturn);

                if (toReturn.Tables[0].Rows.Count > 0)
                {
                    this._objMessage.OfficeAutomation_Attach_ID = new Guid(toReturn.Tables[0].Rows[0]["OfficeAutomation_Attach_ID"].ToString());
                    this._objMessage.OfficeAutomation_Attach_MainID = new Guid(toReturn.Tables[0].Rows[0]["OfficeAutomation_Attach_MainID"].ToString());
                    this._objMessage.OfficeAutomation_Attach_Name = (string)toReturn.Tables[0].Rows[0]["OfficeAutomation_Attach_Name"];
                    this._objMessage.OfficeAutomation_Attach_Path = (string)toReturn.Tables[0].Rows[0]["OfficeAutomation_Attach_Path"];
                }

                return this._objMessage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();

                adapter.Dispose();
            }

        }
        #endregion

        #region 修改记录
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns></returns>
        public override bool Update(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_OfficeAutomation_Attach_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Attach)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Attach_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Attach_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Attach_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Attach_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Attach_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Attach_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Attach_Path", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Attach_Path));

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

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_OfficeAutomation_Attach_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            this._objMessage = (DataEntity.T_OfficeAutomation_Attach)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Attach_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Attach_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Attach_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Attach_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Attach_Path", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Attach_Path));

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
        public override bool Delete(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_OfficeAutomation_Attach_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Attach_ID", SqlDbType.UniqueIdentifier, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(obj.ToString())));

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
