using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Propaganda_Statistical_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Propaganda_Statistical _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda_Statistical]"
                                                        + "           ([OfficeAutomation_Document_Propaganda_Statistical_ID]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Statistical_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Statistical_SNo]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Statistical_SDepartment]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Statistical_Address]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Statistical_SCount])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_Propaganda_Statistical_ID"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Statistical_MainID"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Statistical_SNo"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Statistical_SDepartment"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Statistical_Address"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Statistical_SCount)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Propaganda_Statistical)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_SNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_SNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_SDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_SDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_SCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_SCount));
                
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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda_Statistical]"
                                + " WHERE [OfficeAutomation_Document_Propaganda_Statistical_MainID]=@sOfficeAutomation_Document_Propaganda_Statistical_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Propaganda_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda_Statistical]"
                                                       + "     SET  [OfficeAutomation_Document_Propaganda_Statistical_SNo]=@OfficeAutomation_Document_Propaganda_Statistical_SNo"
                                                        + "            ,[OfficeAutomation_Document_Propaganda_Statistical_SDepartment]=@OfficeAutomation_Document_Propaganda_Statistical_SDepartment"
                                                        + "            ,[OfficeAutomation_Document_Propaganda_Statistical_Address]=@OfficeAutomation_Document_Propaganda_Statistical_Address"
                                                        + "            ,[OfficeAutomation_Document_Propaganda_Statistical_SCount]=@OfficeAutomation_Document_Propaganda_Statistical_SCount"
                                                        + " WHERE [OfficeAutomation_Document_Propaganda_Statistical_ID]=@OfficeAutomation_Document_Propaganda_Statistical_ID"
                                                        + "     AND [OfficeAutomation_Document_Propaganda_Statistical_MainID] = @OfficeAutomation_Document_Propaganda_Statistical_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Propaganda_Statistical)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_SNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_SNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_SDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_SDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_SCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_SCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Statistical_MainID));

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
