using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_GeneralApply_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_GeneralApply_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply_Detail]"
                                                        + "           ([OfficeAutomation_Document_GeneralApply_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_Num]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_Department]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_Branch]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_Cmodel]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_IsOpen])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_GeneralApply_Detail_ID"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_Num"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_Department"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_Branch"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_Cmodel"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_IsOpen)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_GeneralApply_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Num", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Num));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Cmodel", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Cmodel));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_IsOpen", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_IsOpen));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply_Detail]"
                                + " WHERE [OfficeAutomation_Document_GeneralApply_Detail_MainID]=@OfficeAutomation_Document_GeneralApply_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply_Detail]"
                                                        + "     SET  [OfficeAutomation_Document_GeneralApply_Detail_Num]=@OfficeAutomation_Document_GeneralApply_Detail_Num"
                                                        + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Department]=@OfficeAutomation_Document_GeneralApply_Detail_Department"
                                                        + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Branch]=@OfficeAutomation_Document_GeneralApply_Detail_Branch"
                                                        + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Cmodel]=@OfficeAutomation_Document_GeneralApply_Detail_Cmodel"
                                                        + "            ,[OfficeAutomation_Document_GeneralApply_Detail_IsOpen]=@OfficeAutomation_Document_GeneralApply_Detail_IsOpen"
                                                        + " WHERE [OfficeAutomation_Document_GeneralApply_Detail_ID]=@OfficeAutomation_Document_GeneralApply_Detail_ID"
                                                        + "     AND [OfficeAutomation_Document_GeneralApply_Detail_MainID] = @OfficeAutomation_Document_GeneralApply_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_GeneralApply_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Num", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Num));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Cmodel", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Cmodel));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_IsOpen", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_IsOpen));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_MainID));

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
