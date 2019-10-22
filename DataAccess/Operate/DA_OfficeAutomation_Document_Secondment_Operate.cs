using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Secondment_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Secondment _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Secondment]"
                                                        + "           ([OfficeAutomation_Document_Secondment_ID]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_Department]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_BorrowDepartment]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_InDptm]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_InDptmContact]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_AssetsName]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_TheMessage]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_Number]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_BorrowDate]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_ExpectReturnDate]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_SalesDate]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_Sales]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_ReturnDate]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_Returner]"
                                                        + "           ,[OfficeAutomation_Document_Secondment_Reason])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_Secondment_ID"
                                                        + "           ,@OfficeAutomation_Document_Secondment_MainID"
                                                        + "           ,@OfficeAutomation_Document_Secondment_Apply"
                                                        + "           ,@OfficeAutomation_Document_Secondment_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Secondment_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Secondment_Department"
                                                        + "           ,@OfficeAutomation_Document_Secondment_BorrowDepartment"
                                                        + "           ,@OfficeAutomation_Document_Secondment_InDptm"
                                                        + "           ,@OfficeAutomation_Document_Secondment_InDptmContact"
                                                        + "           ,@OfficeAutomation_Document_Secondment_AssetsName"
                                                        + "           ,@OfficeAutomation_Document_Secondment_TheMessage"
                                                        + "           ,@OfficeAutomation_Document_Secondment_Number"
                                                        + "           ,@OfficeAutomation_Document_Secondment_BorrowDate"
                                                        + "           ,@OfficeAutomation_Document_Secondment_ExpectReturnDate"
                                                        + "           ,@OfficeAutomation_Document_Secondment_SalesDate"
                                                        + "           ,@OfficeAutomation_Document_Secondment_Sales"
                                                        + "           ,@OfficeAutomation_Document_Secondment_ReturnDate"
                                                        + "           ,@OfficeAutomation_Document_Secondment_Returner"
                                                        + "           ,@OfficeAutomation_Document_Secondment_Reason)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Secondment)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_BorrowDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_BorrowDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_InDptm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_InDptm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_InDptmContact", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_InDptmContact));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_AssetsName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_AssetsName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_TheMessage", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_TheMessage));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Number", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_BorrowDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_BorrowDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ExpectReturnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ExpectReturnDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_SalesDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Sales", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ReturnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Returner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Reason));

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
            cmdToExecute.CommandText = "dbo.[pr_Secondment_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Secondment]"
                                + "         SET [OfficeAutomation_Document_Secondment_ApplyID] = @OfficeAutomation_Document_Secondment_ApplyID"
                                + "         ,[OfficeAutomation_Document_Secondment_Department] = @OfficeAutomation_Document_Secondment_Department"
                                + "         ,[OfficeAutomation_Document_Secondment_BorrowDepartment] = @OfficeAutomation_Document_Secondment_BorrowDepartment"
                                + "         ,[OfficeAutomation_Document_Secondment_InDptm] = @OfficeAutomation_Document_Secondment_InDptm"
                                + "         ,[OfficeAutomation_Document_Secondment_InDptmContact] = @OfficeAutomation_Document_Secondment_InDptmContact"
                                + "         ,[OfficeAutomation_Document_Secondment_AssetsName] = @OfficeAutomation_Document_Secondment_AssetsName"
                                + "         ,[OfficeAutomation_Document_Secondment_TheMessage] = @OfficeAutomation_Document_Secondment_TheMessage"
                                + "         ,[OfficeAutomation_Document_Secondment_Number] = @OfficeAutomation_Document_Secondment_Number"
                                + "         ,[OfficeAutomation_Document_Secondment_BorrowDate] = @OfficeAutomation_Document_Secondment_BorrowDate"
                                + "         ,[OfficeAutomation_Document_Secondment_ExpectReturnDate] = @OfficeAutomation_Document_Secondment_ExpectReturnDate"
                                //+ "         ,[OfficeAutomation_Document_Secondment_SalesDate] = @OfficeAutomation_Document_Secondment_SalesDate"
                                //+ "         ,[OfficeAutomation_Document_Secondment_Sales] = @OfficeAutomation_Document_Secondment_Sales"
                                //+ "         ,[OfficeAutomation_Document_Secondment_ReturnDate] = @OfficeAutomation_Document_Secondment_ReturnDate"
                                //+ "         ,[OfficeAutomation_Document_Secondment_Returner] = @OfficeAutomation_Document_Secondment_Returner"
                                + "         ,[OfficeAutomation_Document_Secondment_Reason] = @OfficeAutomation_Document_Secondment_Reason"
                                + "         WHERE [OfficeAutomation_Document_Secondment_ID]=@OfficeAutomation_Document_Secondment_ID"
                                + "         AND [OfficeAutomation_Document_Secondment_MainID]=@OfficeAutomation_Document_Secondment_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Secondment)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_BorrowDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_BorrowDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_InDptm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_InDptm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_InDptmContact", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_InDptmContact));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_AssetsName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_AssetsName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_TheMessage", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_TheMessage));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Number", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_BorrowDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_BorrowDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ExpectReturnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ExpectReturnDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_SalesDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_SalesDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Sales", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Sales));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ReturnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ReturnDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Returner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Returner));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_MainID));

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

        #region 更新记录2
        public bool Update2(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Secondment]"
                                + "         SET [OfficeAutomation_Document_Secondment_SalesDate] = @OfficeAutomation_Document_Secondment_SalesDate"
                                + "         ,[OfficeAutomation_Document_Secondment_Sales] = @OfficeAutomation_Document_Secondment_Sales"
                                + "         ,[OfficeAutomation_Document_Secondment_ReturnDate] = @OfficeAutomation_Document_Secondment_ReturnDate"
                                + "         ,[OfficeAutomation_Document_Secondment_Returner] = @OfficeAutomation_Document_Secondment_Returner"
                                + "         WHERE [OfficeAutomation_Document_Secondment_ID]=@OfficeAutomation_Document_Secondment_ID"
                                + "         AND [OfficeAutomation_Document_Secondment_MainID]=@OfficeAutomation_Document_Secondment_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Secondment)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_SalesDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_SalesDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Sales", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Sales));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ReturnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ReturnDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_Returner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_Returner));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Secondment_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Secondment_MainID));

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
