using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BadDebts_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_BadDebts _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BadDebts> dal;

        #endregion

        #region 无参构造函数

        public DA_OfficeAutomation_Document_BadDebts_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BadDebts>();
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

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts]"
                                                        + "           ([OfficeAutomation_Document_BadDebts_ID]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_MainID]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Apply]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Department]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Building]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Reason]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_OneOrTwo]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_SumBDMoney]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_MoneyCount])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_BadDebts_ID"
                                                        + "           ,@guidOfficeAutomation_Document_BadDebts_MainID"
                                                        + "           ,@sOfficeAutomation_Document_BadDebts_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_BadDebts_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_BadDebts_ApplyID"
                                                        + "           ,@sOfficeAutomation_Document_BadDebts_Department"
                                                        + "           ,@sOfficeAutomation_Document_BadDebts_ReplyPhone"
                                                        + "           ,@sOfficeAutomation_Document_BadDebts_Building"
                                                        + "           ,@sOfficeAutomation_Document_BadDebts_Reason"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_OneOrTwo"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_SumBDMoney"
                                                        + "           ,@dcmOfficeAutomation_Document_BadDebts_MoneyCount)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BadDebts)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BadDebts_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BadDebts_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_BadDebts_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Reason", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_OneOrTwo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_OneOrTwo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_SumBDMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_SumBDMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_BadDebts_MoneyCount", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_MoneyCount));

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
            cmdToExecute.CommandText = "dbo.[pr_BadDebts_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts]"
                                                        + "     SET  [OfficeAutomation_Document_BadDebts_ApplyID]=@sOfficeAutomation_Document_BadDebts_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Department]=@sOfficeAutomation_Document_BadDebts_Department"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_ReplyPhone]=@sOfficeAutomation_Document_BadDebts_ReplyPhone"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Building]=@sOfficeAutomation_Document_BadDebts_Building"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Reason]=@sOfficeAutomation_Document_BadDebts_Reason"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_OneOrTwo]=@OfficeAutomation_Document_BadDebts_OneOrTwo"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_SumBDMoney]=@OfficeAutomation_Document_BadDebts_SumBDMoney"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_MoneyCount]=@dcmOfficeAutomation_Document_BadDebts_MoneyCount"
                                                        + " WHERE [OfficeAutomation_Document_BadDebts_ID]=@guidOfficeAutomation_Document_BadDebts_ID"
                                                        + "     AND [OfficeAutomation_Document_BadDebts_MainID] = @guidOfficeAutomation_Document_BadDebts_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BadDebts)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Reason", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_OneOrTwo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_OneOrTwo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_SumBDMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_SumBDMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_BadDebts_MoneyCount", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_MoneyCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BadDebts_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BadDebts_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_MainID));
                
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
        public T_OfficeAutomation_Document_BadDebts Add(T_OfficeAutomation_Document_BadDebts t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_BadDebts Edit(T_OfficeAutomation_Document_BadDebts t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_BadDebts t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_BadDebts GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_BadDebts>(where);
        }
        #endregion 
    }
}
