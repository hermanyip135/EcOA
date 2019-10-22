using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using SqlDatabase;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Main_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Main _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            //cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Main]"
            cmdToExecute.CommandText = "INSERT INTO [t_OfficeAutomation_Main]"
                                                        +"           ([OfficeAutomation_Main_ID]"
                                                        +"           ,[OfficeAutomation_SerialNumber]"

                                                        + "           ,[OfficeAutomation_Main_Creater]"
                                                        + "           ,[OfficeAutomation_Main_CrTime]"

                                                        +"           ,[OfficeAutomation_DocumentID]"
                                                        +"           ,[OfficeAutomation_Main_Department]"
                                                        +"           ,[OfficeAutomation_Main_Apply]"
                                                        +"           ,[OfficeAutomation_Main_ApplyDate]"
                                                        + "          ,[OfficeAutomation_Main_FlowStateID]"
                                                        + "          ,[OfficeAutomation_Main_Summary]"
                                                        + ")"
                                                        +"     VALUES"
                                                        + "           (@guidOfficeAutomation_Main_ID"
                                                        +"            ,@sOfficeAutomation_SerialNumber"

                                                        + "            ,@OfficeAutomation_Main_Creater"
                                                        + "            ,@OfficeAutomation_Main_CrTime"

                                                        + "           ,@iOfficeAutomation_DocumentID"
                                                        + "           ,@sOfficeAutomation_Main_Department"
                                                        + "           ,@sOfficeAutomation_Main_Apply"
                                                        + "           ,@sOfficeAutomation_Main_ApplyDate"
                                                        + "           ,1"
                                                        + "           ,@sOfficeAutomation_Main_Summary"
                                                        + "           )";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Main)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Main_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_SerialNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_SerialNumber));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_Creater", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_Creater));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_CrTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_CrTime));

                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Main_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Main_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Main_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_ApplyDate));
                
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_DocumentID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_DocumentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Main_Summary", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_Summary));

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

        public override bool Update(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = " UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Main]"
                                                        + "       SET [OfficeAutomation_Main_FlowStateID] = @iOfficeAutomation_Main_FlowStateID"
                                                        + " WHERE [OfficeAutomation_Main_ID]=@guidOfficeAutomation_Main_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Main)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Main_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Main_FlowStateID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_FlowStateID));

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

        public bool UpdateAndBk(object obj) //20141204
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = " UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Main]"
                                                        + "       SET [OfficeAutomation_Main_FlowStateID] = @iOfficeAutomation_Main_FlowStateID"
                                                        + "       ,[OfficeAutomation_Main_IsBackUp] = @OfficeAutomation_Main_IsBackUp"
                                                        + "       ,[OfficeAutomation_Main_AuditorIDsSum] = @OfficeAutomation_Main_AuditorIDsSum"
                                                        + "       ,[OfficeAutomation_Main_AuditorNamesSum] = @OfficeAutomation_Main_AuditorNamesSum"
                                                        + " WHERE [OfficeAutomation_Main_ID]=@guidOfficeAutomation_Main_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Main)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Main_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Main_FlowStateID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_FlowStateID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_IsBackUp", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_IsBackUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_AuditorIDsSum", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_AuditorNamesSum", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

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

        public bool UpdateWillDelete(object obj) //20141225
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = " UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Main]"
                                                        + "       SET [OfficeAutomation_Main_WillDelete] = @OfficeAutomation_Main_WillDelete"
                                                        + " WHERE [OfficeAutomation_Main_ID]=@guidOfficeAutomation_Main_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Main)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Main_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_WillDelete", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Main_WillDelete));

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

        #region 自定义方法
        public DataEntity.T_OfficeAutomation_Main Add(DataEntity.T_OfficeAutomation_Main t)
        {
            var dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Main>();
            return dal.Add(t);
        }

        public T_OfficeAutomation_Main Edit(T_OfficeAutomation_Main t)
        {
            var dal = new DAL.DalBase<T_OfficeAutomation_Main>();
            return dal.Edit(t);
        }

        public bool Exist(DataEntity.T_OfficeAutomation_Main t)
        {
            var dal = new DAL.DalBase<T_OfficeAutomation_Main>();
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            var dal = new DAL.DalBase<T_OfficeAutomation_Main>();
            return dal.Exist(where);
        }

        public DataEntity.T_OfficeAutomation_Main GetModel(string where)
        {
            var dal = new DAL.DalBase<T_OfficeAutomation_Main>();
            return dal.GetModel<T_OfficeAutomation_Main>(where);
        }
        #endregion

    }
}
