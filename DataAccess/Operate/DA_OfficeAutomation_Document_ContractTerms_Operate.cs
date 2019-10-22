using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ContractTerms_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ContractTerms _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_ContractTerms> dal;
        #endregion

        public DA_OfficeAutomation_Document_ContractTerms_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_ContractTerms>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ContractTerms]"
                                                        + "           ([OfficeAutomation_Document_ContractTerms_ID]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_Apply]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_Department]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_Subject]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_Fax]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_ReceiveDepartment]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_OSDepartment]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_IsApproval]"
                                                        + "           ,[OfficeAutomation_Document_ContractTerms_Describe])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_ContractTerms_ID"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_MainID"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_Apply"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_Department"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_Subject"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_ReplyPhone"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_Fax"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_ReceiveDepartment"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_OSDepartment"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_IsApproval"
                                                        + "           ,@OfficeAutomation_Document_ContractTerms_Describe)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ContractTerms)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_ApplyDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_ReceiveDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_ReceiveDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_OSDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_OSDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_IsApproval", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_IsApproval));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_Describe));

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
            cmdToExecute.CommandText = "dbo.[pr_ContractTerms_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ContractTerms]"
                                                        + "     SET   [OfficeAutomation_Document_ContractTerms_ApplyID]=@OfficeAutomation_Document_ContractTerms_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_ContractTerms_Department]=@OfficeAutomation_Document_ContractTerms_Department"
                                                        + "            ,[OfficeAutomation_Document_ContractTerms_Subject]=@OfficeAutomation_Document_ContractTerms_Subject"
                                                        + "            ,[OfficeAutomation_Document_ContractTerms_ReplyPhone]=@OfficeAutomation_Document_ContractTerms_ReplyPhone"
                                                        + "            ,[OfficeAutomation_Document_ContractTerms_Fax]=@OfficeAutomation_Document_ContractTerms_Fax"
                                                        + "            ,[OfficeAutomation_Document_ContractTerms_ReceiveDepartment]=@OfficeAutomation_Document_ContractTerms_ReceiveDepartment"
                                                        + "            ,[OfficeAutomation_Document_ContractTerms_OSDepartment]=@OfficeAutomation_Document_ContractTerms_OSDepartment"
                                                        + "            ,[OfficeAutomation_Document_ContractTerms_IsApproval]=@OfficeAutomation_Document_ContractTerms_IsApproval"
                                                        + "            ,[OfficeAutomation_Document_ContractTerms_Describe]=@OfficeAutomation_Document_ContractTerms_Describe"

                                                        + " WHERE [OfficeAutomation_Document_ContractTerms_ID]=@OfficeAutomation_Document_ContractTerms_ID"
                                                        + "     AND [OfficeAutomation_Document_ContractTerms_MainID] = @OfficeAutomation_Document_ContractTerms_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ContractTerms)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_ReceiveDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_ReceiveDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_OSDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_OSDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_IsApproval", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_IsApproval));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_Describe));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ContractTerms_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ContractTerms_MainID));
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

        #region  ExtensionMethod
        public T_OfficeAutomation_Document_ContractTerms TemAdd(T_OfficeAutomation_Document_ContractTerms t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_ContractTerms TemEdit(T_OfficeAutomation_Document_ContractTerms t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_ContractTerms t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_ContractTerms GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_ContractTerms>(where);
        }
        #endregion  ExtensionMethod
    }
}
