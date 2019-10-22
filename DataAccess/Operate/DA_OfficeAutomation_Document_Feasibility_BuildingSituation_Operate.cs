using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Feasibility_BuildingSituation_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Feasibility_BuildingSituation _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_BuildingSituation]"
                                                        + "           ([OfficeAutomation_Document_Feasibility_BuildingSituation_ID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BuildingSituation_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BuildingSituation_Csell]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_Feasibility_BuildingSituation_ID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BuildingSituation_MainID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BuildingSituation_Csell"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility_BuildingSituation)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_Csell", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_Csell));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_BuildingSituation]"
                                + " WHERE [OfficeAutomation_Document_Feasibility_BuildingSituation_MainID]=@sOfficeAutomation_Document_Feasibility_BuildingSituation_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Feasibility_BuildingSituation_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_BuildingSituation]"
                                                        + "     SET [OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName]=@OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BuildingSituation_Csell]=@OfficeAutomation_Document_Feasibility_BuildingSituation_Csell"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare]=@OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast]=@OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain]=@OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain"
                                                        + " WHERE [OfficeAutomation_Document_Feasibility_BuildingSituation_ID]=@OfficeAutomation_Document_Feasibility_BuildingSituation_ID"
                                                        + "     AND [OfficeAutomation_Document_Feasibility_BuildingSituation_MainID] = @OfficeAutomation_Document_Feasibility_BuildingSituation_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility_BuildingSituation)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_Csell", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_Csell));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildingSituation_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildingSituation_MainID));

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
