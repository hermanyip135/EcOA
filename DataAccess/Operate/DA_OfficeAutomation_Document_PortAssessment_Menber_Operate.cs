using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PortAssessment_Menber_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_PortAssessment_Menber _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PortAssessment_Menber]"
                                                        + "           ([OfficeAutomation_Document_PortAssessment_Menber_ID]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_MainID]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridAx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridBx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridCx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridDx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridEx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridFx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridGx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridHx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridIx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridJx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridKx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridLx]"
                                                        + "           ,[OfficeAutomation_Document_PortAssessment_Menber_GridMx])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_PortAssessment_Menber_ID"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_MainID"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridAx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridBx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridCx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridDx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridEx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridFx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridGx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridHx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridIx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridJx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridKx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridLx"
                                                        + "           ,@OfficeAutomation_Document_PortAssessment_Menber_GridMx)";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PortAssessment_Menber)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridAx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridAx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridBx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridBx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridCx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridCx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridDx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridDx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridEx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridEx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridFx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridFx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridGx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridGx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridHx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridHx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridIx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridIx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridJx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridJx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridKx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridKx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridLx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridLx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridMx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridMx));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PortAssessment_Menber]"
                                + " WHERE [OfficeAutomation_Document_PortAssessment_Menber_MainID]=@sOfficeAutomation_Document_PortAssessment_Menber_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PortAssessment_Menber_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PortAssessment_Menber]"
                                                        + "     SET [OfficeAutomation_Document_PortAssessment_Menber_GridAx]=@OfficeAutomation_Document_PortAssessment_Menber_GridAx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridBx]=@OfficeAutomation_Document_PortAssessment_Menber_GridBx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridCx]=@OfficeAutomation_Document_PortAssessment_Menber_GridCx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridDx]=@OfficeAutomation_Document_PortAssessment_Menber_GridDx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridEx]=@OfficeAutomation_Document_PortAssessment_Menber_GridEx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridFx]=@OfficeAutomation_Document_PortAssessment_Menber_GridFx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridGx]=@OfficeAutomation_Document_PortAssessment_Menber_GridGx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridHx]=@OfficeAutomation_Document_PortAssessment_Menber_GridHx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridIx]=@OfficeAutomation_Document_PortAssessment_Menber_GridIx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridJx]=@OfficeAutomation_Document_PortAssessment_Menber_GridJx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridKx]=@OfficeAutomation_Document_PortAssessment_Menber_GridKx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridLx]=@OfficeAutomation_Document_PortAssessment_Menber_GridLx"
                                                        + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridMx]=@OfficeAutomation_Document_PortAssessment_Menber_GridMx"
                                                        + " WHERE [OfficeAutomation_Document_PortAssessment_Menber_ID]=@OfficeAutomation_Document_PortAssessment_Menber_ID"
                                                        + "     AND [OfficeAutomation_Document_PortAssessment_Menber_MainID] = @OfficeAutomation_Document_PortAssessment_Menber_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PortAssessment_Menber)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridAx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridAx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridBx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridBx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridCx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridCx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridDx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridDx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridEx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridEx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridFx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridFx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridGx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridGx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridHx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridHx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridIx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridIx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridJx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridJx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridKx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridKx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridLx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridLx));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_GridMx", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_GridMx));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PortAssessment_Menber_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PortAssessment_Menber_MainID));

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
