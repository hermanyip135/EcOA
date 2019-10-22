using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Feasibility_DealOfRecord_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Feasibility_DealOfRecord _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_DealOfRecord]"
                                                        + "           ([OfficeAutomation_Document_Feasibility_DealOfRecord_ID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_DealOfRecord_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_Feasibility_DealOfRecord_ID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_DealOfRecord_MainID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent)";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility_DealOfRecord)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_DealOfRecord]"
                                + " WHERE [OfficeAutomation_Document_Feasibility_DealOfRecord_MainID]=@sOfficeAutomation_Document_Feasibility_DealOfRecord_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Feasibility_DealOfRecord_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_DealOfRecord]"
                                                        + "     SET [OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding]=@OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate]=@OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate]=@OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet]=@OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent]=@OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent"
                                                        + " WHERE [OfficeAutomation_Document_Feasibility_DealOfRecord_ID]=@OfficeAutomation_Document_Feasibility_DealOfRecord_ID"
                                                        + "     AND [OfficeAutomation_Document_Feasibility_DealOfRecord_MainID] = @OfficeAutomation_Document_Feasibility_DealOfRecord_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility_DealOfRecord)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_DealOfRecord_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_DealOfRecord_MainID));

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
