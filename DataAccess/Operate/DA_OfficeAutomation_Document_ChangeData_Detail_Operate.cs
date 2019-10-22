using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ChangeData_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ChangeData_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeData_Detail]"
                                                        + "           ([OfficeAutomation_Document_ChangeData_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_pNo]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_CountOffTime]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_DealNo]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_OtherDataAddress]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_ChangeSituation]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_ChangeReason]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_ProjectName]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_Cname]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_Type]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Detail_ChangeCname])"
                                                        + "     VALUES"
                                                        + "           (@sOfficeAutomation_Document_ChangeData_Detail_ID"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_ChangeData_Detail_pNo"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_CountOffTime"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_DealNo"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_OtherDataAddress"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_ChangeSituation"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_ChangeReason"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_ProjectName"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_Cname"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_Type"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Detail_ChangeCname)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ChangeData_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeData_Detail_pNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_pNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_CountOffTime", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_CountOffTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_DealNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_DealNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_OtherDataAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_OtherDataAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_ChangeSituation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_ChangeSituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_ChangeReason", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_ChangeReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_ProjectName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_ProjectName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_Cname", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_Cname));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_Type", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_ChangeCname", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_ChangeCname));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeData_Detail]"
                                + " WHERE [OfficeAutomation_Document_ChangeData_Detail_MainID]=@sOfficeAutomation_Document_ChangeData_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeData_Detail]"
                                                        + "     SET  [OfficeAutomation_Document_ChangeData_Detail_CountOffTime]=@sOfficeAutomation_Document_ChangeData_Detail_CountOffTime"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_Detail_pNo]=@OfficeAutomation_Document_ChangeData_Detail_pNo"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_Detail_DealNo]=@sOfficeAutomation_Document_ChangeData_Detail_DealNo"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_Detail_OtherDataAddress]=@sOfficeAutomation_Document_ChangeData_Detail_OtherDataAddress"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_Detail_ChangeSituation]=@sOfficeAutomation_Document_ChangeData_Detail_ChangeSituation"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_Detail_ChangeReason]=@sOfficeAutomation_Document_ChangeData_Detail_ChangeReason"
                                                        + " WHERE [OfficeAutomation_Document_ChangeData_Detail_ID]=@sOfficeAutomation_Document_ChangeData_Detail_ID"
                                                        + "     AND [OfficeAutomation_Document_ChangeData_Detail_MainID] = @sOfficeAutomation_Document_ChangeData_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ChangeData_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_CountOffTime", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_CountOffTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeData_Detail_pNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_pNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_DealNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_DealNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_OtherDataAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_OtherDataAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_ChangeSituation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_ChangeSituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_ChangeReason", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_ChangeReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Detail_MainID));

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
