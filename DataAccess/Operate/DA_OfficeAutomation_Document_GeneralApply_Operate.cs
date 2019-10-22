using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_GeneralApply_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_GeneralApply _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_GeneralApply> dal;
        #endregion

        public DA_OfficeAutomation_Document_GeneralApply_Operate() 
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_GeneralApply>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply]"
                                                        + "           ([OfficeAutomation_Document_GeneralApply_ID]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_MainID]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Apply]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Department]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_ReceiveDepartment]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_CCDepartment]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Subject]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Fax]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Describe])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_GeneralApply_ID"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_MainID"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Apply"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Department"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_ReceiveDepartment"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_CCDepartment"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Subject"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_ReplyPhone"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Fax"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Describe)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_GeneralApply)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_ReceiveDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_ReceiveDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_CCDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_CCDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Describe", SqlDbType.Text,999999, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Describe));

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
            cmdToExecute.CommandText = "dbo.[pr_GeneralApply_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply]"
                                +"         SET [OfficeAutomation_Document_GeneralApply_ApplyID]=@OfficeAutomation_Document_GeneralApply_ApplyID"
                                + "         ,[OfficeAutomation_Document_GeneralApply_Department]=@OfficeAutomation_Document_GeneralApply_Department"
                                + "         ,[OfficeAutomation_Document_GeneralApply_ReceiveDepartment]=@OfficeAutomation_Document_GeneralApply_ReceiveDepartment"
                                + "         ,[OfficeAutomation_Document_GeneralApply_CCDepartment]=@OfficeAutomation_Document_GeneralApply_CCDepartment"
                                + "         ,[OfficeAutomation_Document_GeneralApply_Subject]=@OfficeAutomation_Document_GeneralApply_Subject"
                                + "         ,[OfficeAutomation_Document_GeneralApply_ReplyPhone]=@OfficeAutomation_Document_GeneralApply_ReplyPhone"
                                + "         ,[OfficeAutomation_Document_GeneralApply_Fax]=@OfficeAutomation_Document_GeneralApply_Fax"
                                + "         ,[OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID]=@OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID"
                                + "         ,[OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName]=@OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName"
                                + "         ,[OfficeAutomation_Document_GeneralApply_Describe]=@OfficeAutomation_Document_GeneralApply_Describe"
                                + "         WHERE [OfficeAutomation_Document_GeneralApply_ID]=@OfficeAutomation_Document_GeneralApply_ID"
                                + "     AND [OfficeAutomation_Document_GeneralApply_MainID]=@OfficeAutomation_Document_GeneralApply_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_GeneralApply)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_ReceiveDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_ReceiveDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_CCDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_CCDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Describe", SqlDbType.Text,999999, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Describe));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_MainID));

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
        public T_OfficeAutomation_Document_GeneralApply Add(T_OfficeAutomation_Document_GeneralApply t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_GeneralApply Edit(T_OfficeAutomation_Document_GeneralApply t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_GeneralApply t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_GeneralApply GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_GeneralApply>(where);
        }
        #endregion 
    }
}
