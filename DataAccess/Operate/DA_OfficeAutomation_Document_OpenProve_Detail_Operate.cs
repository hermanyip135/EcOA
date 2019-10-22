using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OpenProve_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_OpenProve_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OpenProve_Detail]"
                                                        + "           ([OfficeAutomation_Document_OpenProve_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Detail_Prove]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Detail_No]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Detail_Reasondb]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Detail_Address]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Detail_Sdate]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Detail_AnotherR]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Detail_Kind]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Detail_AnotherKind])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_OpenProve_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_OpenProve_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Detail_Prove"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Detail_No"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Detail_Reasondb"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Detail_Address"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Detail_Sdate"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Detail_AnotherR"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Detail_Kind"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Detail_AnotherKind)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OpenProve_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_OpenProve_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_OpenProve_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Prove", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Prove));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_No", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Reasondb", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Reasondb));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Address", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Sdate", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Sdate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_AnotherR", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_AnotherR));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Kind", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Kind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_AnotherKind", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_AnotherKind));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OpenProve_Detail]"
                                + " WHERE [OfficeAutomation_Document_OpenProve_Detail_MainID]=@guidOfficeAutomation_Document_OpenProve_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_OpenProve_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OpenProve_Detail]"
                                                        + "     SET  [OfficeAutomation_Document_OpenProve_Detail_Department]=@sOfficeAutomation_Document_OpenProve_Detail_Department"
                                                        + "            ,[OfficeAutomation_Document_OpenProve_Detail_Sales]=@sOfficeAutomation_Document_OpenProve_Detail_Sales"
                                                        + "            ,[OfficeAutomation_Document_OpenProve_Detail_Team]=@sOfficeAutomation_Document_OpenProve_Detail_Team"
                                                        + "            ,[OfficeAutomation_Document_OpenProve_Detail_BackMoney]=@dcmOfficeAutomation_Document_OpenProve_Detail_BackMoney"
                                                        + "            ,[OfficeAutomation_Document_OpenProve_Detail_IsOnJob]=@bOfficeAutomation_Document_OpenProve_Detail_IsOnJob"
                                                        + "            ,[OfficeAutomation_Document_OpenProve_Detail_IsPayComm]=@bOfficeAutomation_Document_OpenProve_Detail_IsPayComm"
                                                        + " WHERE [OfficeAutomation_Document_OpenProve_Detail_ID]=@guidOfficeAutomation_Document_OpenProve_Detail_ID"
                                                        + "     AND [OfficeAutomation_Document_OpenProve_Detail_MainID] = @guidOfficeAutomation_Document_OpenProve_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OpenProve_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Prove", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Prove));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_No", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Reasondb", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Reasondb));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Address", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Sdate", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Sdate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_AnotherR", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_AnotherR));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_Kind", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_Kind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Detail_AnotherKind", SqlDbType.NChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_AnotherKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_OpenProve_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_OpenProve_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Detail_MainID));

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
