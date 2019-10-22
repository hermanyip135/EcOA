using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OfficialSeal_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_OfficialSeal _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal]"
                                                        + "           ([OfficeAutomation_Document_OfficialSeal_ID]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_MainID]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Apply]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Department]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Species]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_AnotherSeal]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_FileSpecies]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_AnotherFile]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_FileCount]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_RecyclingData]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_SureDepartment]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_SureMenber]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_SureData]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_BranchPhone]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_SurePhone]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_SureCommissioner])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_OfficialSeal_ID"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_MainID"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Apply"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Department"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Species"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_AnotherSeal"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_FileSpecies"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_AnotherFile"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_FileCount"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_RecyclingData"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_SureDepartment"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_SureMenber"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_SureData"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_BranchPhone"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_SurePhone"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_SureCommissioner)";


            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OfficialSeal)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Species", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Species));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_AnotherSeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_AnotherSeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_FileSpecies", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_FileSpecies));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_AnotherFile", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_AnotherFile));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_FileCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_FileCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_RecyclingData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_RecyclingData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SureDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SureDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SureMenber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SureMenber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SureData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SureData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_BranchPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_BranchPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SurePhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SurePhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SureCommissioner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SureCommissioner));

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
            cmdToExecute.CommandText = "dbo.[pr_OfficialSeal_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal]"
                                                        + "     SET   [OfficeAutomation_Document_OfficialSeal_ApplyID]=@OfficeAutomation_Document_OfficialSeal_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_Department]=@OfficeAutomation_Document_OfficialSeal_Department"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_Species]=@OfficeAutomation_Document_OfficialSeal_Species"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_AnotherSeal]=@OfficeAutomation_Document_OfficialSeal_AnotherSeal"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_FileSpecies]=@OfficeAutomation_Document_OfficialSeal_FileSpecies"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_AnotherFile]=@OfficeAutomation_Document_OfficialSeal_AnotherFile"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_FileCount]=@OfficeAutomation_Document_OfficialSeal_FileCount"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_RecyclingData]=@OfficeAutomation_Document_OfficialSeal_RecyclingData"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_SureDepartment]=@OfficeAutomation_Document_OfficialSeal_SureDepartment"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_SureMenber]=@OfficeAutomation_Document_OfficialSeal_SureMenber"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_SureData]=@OfficeAutomation_Document_OfficialSeal_SureData"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_BranchPhone]=@OfficeAutomation_Document_OfficialSeal_BranchPhone"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_SurePhone]=@OfficeAutomation_Document_OfficialSeal_SurePhone"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_SureCommissioner]=@OfficeAutomation_Document_OfficialSeal_SureCommissioner"
                                                        + " WHERE [OfficeAutomation_Document_OfficialSeal_ID]=@OfficeAutomation_Document_OfficialSeal_ID"
                                                        + "     AND [OfficeAutomation_Document_OfficialSeal_MainID] = @OfficeAutomation_Document_OfficialSeal_MainID";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OfficialSeal)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Species", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Species));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_AnotherSeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_AnotherSeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_FileSpecies", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_FileSpecies));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_AnotherFile", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_AnotherFile));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_FileCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_FileCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_RecyclingData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_RecyclingData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SureDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SureDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SureMenber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SureMenber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SureData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SureData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_BranchPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_BranchPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SurePhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SurePhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_SureCommissioner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_SureCommissioner));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_MainID));

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
