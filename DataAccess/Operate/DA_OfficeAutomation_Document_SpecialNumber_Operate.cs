using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SpecialNumber_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_SpecialNumber _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_SpecialNumber> dal;
        #endregion
        public DA_OfficeAutomation_Document_SpecialNumber_Operate() 
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_SpecialNumber>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialNumber]"
                                                        + "           ([OfficeAutomation_Document_SpecialNumber_ID]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_MainID]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_Apply]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_Department]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_Subject]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_Fax]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_DealNature]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_Names]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_Period]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_ApplyNo]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_DealOfficeOther]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_AgentModel]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_TheReason]"
                                                        + "           ,[OfficeAutomation_Document_SpecialNumber_Describe])"
                                                        + " VALUES"
                                                        +"            (@OfficeAutomation_Document_SpecialNumber_ID"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_MainID"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_Apply"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_Department"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_Subject"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_ReplyPhone"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_Fax"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_DealNature"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_Names"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_Period"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_ApplyNo"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_DealOfficeOther"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_AgentModel"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_TheReason"
                                                        + "           ,@OfficeAutomation_Document_SpecialNumber_Describe)";


            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SpecialNumber)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Fax));
                
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_DealNature", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_DealNature));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Names", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Names));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Period", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Period));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_ApplyNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_ApplyNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_DealOfficeOther", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_DealOfficeOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_AgentModel", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_AgentModel));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_TheReason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_TheReason));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Describe));

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
            cmdToExecute.CommandText = "dbo.[pr_SpecialNumber_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialNumber]"
                                + "         SET [OfficeAutomation_Document_SpecialNumber_ApplyID] = @OfficeAutomation_Document_SpecialNumber_ApplyID"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_Department] = @OfficeAutomation_Document_SpecialNumber_Department"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_Subject] = @OfficeAutomation_Document_SpecialNumber_Subject"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_ReplyPhone] = @OfficeAutomation_Document_SpecialNumber_ReplyPhone"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_Fax] = @OfficeAutomation_Document_SpecialNumber_Fax"

                                + "         ,[OfficeAutomation_Document_SpecialNumber_DealNature] = @OfficeAutomation_Document_SpecialNumber_DealNature"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_Names] = @OfficeAutomation_Document_SpecialNumber_Names"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_Period] = @OfficeAutomation_Document_SpecialNumber_Period"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_ApplyNo] = @OfficeAutomation_Document_SpecialNumber_ApplyNo"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs] = @OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_DealOfficeOther] = @OfficeAutomation_Document_SpecialNumber_DealOfficeOther"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_AgentModel] = @OfficeAutomation_Document_SpecialNumber_AgentModel"
                                + "         ,[OfficeAutomation_Document_SpecialNumber_TheReason] = @OfficeAutomation_Document_SpecialNumber_TheReason"

                                + "         ,[OfficeAutomation_Document_SpecialNumber_Describe] = @OfficeAutomation_Document_SpecialNumber_Describe"
                                + "         WHERE [OfficeAutomation_Document_SpecialNumber_ID]=@OfficeAutomation_Document_SpecialNumber_ID"
                                + "         AND [OfficeAutomation_Document_SpecialNumber_MainID]=@OfficeAutomation_Document_SpecialNumber_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SpecialNumber)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_DealNature", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_DealNature));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Names", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Names));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Period", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Period));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_ApplyNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_ApplyNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_DealOfficeOther", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_DealOfficeOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_AgentModel", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_AgentModel));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_TheReason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_TheReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_Describe));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialNumber_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialNumber_MainID));

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
        public T_OfficeAutomation_Document_SpecialNumber TemAdd(T_OfficeAutomation_Document_SpecialNumber t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_SpecialNumber TemEdit(T_OfficeAutomation_Document_SpecialNumber t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_SpecialNumber t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_SpecialNumber GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_SpecialNumber>(where);
        }
        #endregion  ExtensionMethod
    }
}
