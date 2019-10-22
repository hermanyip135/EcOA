using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;//52100

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BackComm_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_BackComm _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BackComm> dal;
        #endregion

        #region 无参构造函数
        public DA_OfficeAutomation_Document_BackComm_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BackComm>();
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

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BackComm]"
                                                        + "           ([OfficeAutomation_Document_BackComm_ID]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_MainID]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_Apply]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_Department]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_Building]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_Reason]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_MoneyCount]"
                                                        + "           ,[OfficeAutomation_Document_BackComm_Measure])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_BackComm_ID"
                                                        + "           ,@guidOfficeAutomation_Document_BackComm_MainID"
                                                        + "           ,@sOfficeAutomation_Document_BackComm_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_BackComm_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_BackComm_ApplyID"
                                                        + "           ,@sOfficeAutomation_Document_BackComm_Department"
                                                        + "           ,@sOfficeAutomation_Document_BackComm_ReplyPhone"
                                                        + "           ,@sOfficeAutomation_Document_BackComm_Building"
                                                        + "           ,@sOfficeAutomation_Document_BackComm_Reason"
                                                        + "           ,@dcmOfficeAutomation_Document_BackComm_MoneyCount"
                                                        + "           ,@sOfficeAutomation_Document_BackComm_Measure)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BackComm)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BackComm_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BackComm_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_BackComm_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_Reason", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_BackComm_MoneyCount", SqlDbType.Decimal, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_MoneyCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_Measure", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_Measure));

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
            cmdToExecute.CommandText = "dbo.[pr_BackComm_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BackComm]"
                                                        + "     SET  [OfficeAutomation_Document_BackComm_ApplyID]=@sOfficeAutomation_Document_BackComm_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_BackComm_Department]=@sOfficeAutomation_Document_BackComm_Department"
                                                        + "            ,[OfficeAutomation_Document_BackComm_ReplyPhone]=@sOfficeAutomation_Document_BackComm_ReplyPhone"
                                                        + "            ,[OfficeAutomation_Document_BackComm_Building]=@sOfficeAutomation_Document_BackComm_Building"
                                                        + "            ,[OfficeAutomation_Document_BackComm_Reason]=@sOfficeAutomation_Document_BackComm_Reason"
                                                        + "            ,[OfficeAutomation_Document_BackComm_MoneyCount]=@dcmOfficeAutomation_Document_BackComm_MoneyCount"
                                                        + "            ,[OfficeAutomation_Document_BackComm_Measure]=@sOfficeAutomation_Document_BackComm_Measure"
                                                        + " WHERE [OfficeAutomation_Document_BackComm_ID]=@guidOfficeAutomation_Document_BackComm_ID"
                                                        + "     AND [OfficeAutomation_Document_BackComm_MainID] = @guidOfficeAutomation_Document_BackComm_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BackComm)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_Reason", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_BackComm_MoneyCount", SqlDbType.Decimal, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_MoneyCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BackComm_Measure", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_Measure));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BackComm_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BackComm_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BackComm_MainID));
                
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

        #region 自定义
        public T_OfficeAutomation_Document_BackComm Add(T_OfficeAutomation_Document_BackComm t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_BackComm Edit(T_OfficeAutomation_Document_BackComm t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_BackComm t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_BackComm GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_BackComm>(where);
        }
        #endregion
    }
}
