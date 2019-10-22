using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_AssetTransfer_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_AssetTransfer_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail]"
                                                        + "           ([OfficeAutomation_Document_AssetTransfer_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetName]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetAID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTag]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_Model]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmExp]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmRec]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_CV]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_CreateTime]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_Number]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_TxtType]"
                                                        + "              )"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_AssetTransfer_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_AssetTransfer_Detail_MainID"
                                                        + "           ,@iOfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_AssetName"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Detail_AssetTag"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Detail_Model"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_DpmExp"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_CV"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_CreateTime"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Detail_Number"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Detail_TxtType"
                                                        + "           )";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_AssetTransfer_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_AssetTransfer_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_AssetTransfer_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_AssetName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_AssetAID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_AssetTag", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_Model", SqlDbType.NVarChar, 64, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_Model));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_DpmExp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_DpmRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_CV", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_CV));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_CreateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_CreateTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_Number", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_TxtType", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_TxtType));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail]"
                                + "   SET [OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID] =@iOfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetName] = @OfficeAutomation_Document_AssetTransfer_Detail_AssetName"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetAID] = @OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTag] = @sOfficeAutomation_Document_AssetTransfer_Detail_AssetTag"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_Model] = @sOfficeAutomation_Document_AssetTransfer_Detail_Model"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmExp] = @OfficeAutomation_Document_AssetTransfer_Detail_DpmExp"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmRec] = @OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec] = @OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp] = @OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_CV] = @OfficeAutomation_Document_AssetTransfer_Detail_CV"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_CreateTime] = @OfficeAutomation_Document_AssetTransfer_Detail_CreateTime"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID] = @OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_Number] = @sOfficeAutomation_Document_AssetTransfer_Detail_Number"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_Detail_TxtType] = @sOfficeAutomation_Document_AssetTransfer_Detail_TxtType"
                                + " WHERE [OfficeAutomation_Document_AssetTransfer_Detail_ID]=@guidOfficeAutomation_Document_AssetTransfer_Detail_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_AssetTransfer_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_AssetName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_AssetAID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_AssetTag", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_Model", SqlDbType.NVarChar, 64, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_Model));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_DpmExp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_DpmRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_Number", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_AssetTransfer_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_CV", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_CV));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_CreateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_CreateTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_TxtType", SqlDbType.DateTime, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_TxtType));
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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail]"
                                + " WHERE [OfficeAutomation_Document_AssetTransfer_Detail_MainID]=@guidOfficeAutomation_Document_AssetTransfer_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_AssetTransfer_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

        public bool DeleteByID(string ID)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer_Detail]"
                                + " WHERE [OfficeAutomation_Document_AssetTransfer_Detail_ID]=@OfficeAutomation_Document_AssetTransfer_Detail_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(ID)));

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

        #region 插入临时记录
        /// <summary>
        /// 插入临时记录
        /// </summary>
        /// <returns></returns>
        public bool InsertTemporary(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            //cmdToExecute.CommandText = "IF OBJECT_ID('tempdb..#AssetTransfer_Detail') is not null drop table #AssetTransfer_Detail  CREATE TABLE #AssetTransfer_Detail"
            //                                            + "           ([OfficeAutomation_Document_AssetTransfer_Detail_ID] uniqueidentifier,"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_MainID] uniqueidentifier,"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID] int,"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_AssetTag] nvarchar(200),"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_Model] nvarchar(64),"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_AssetName] nvarchar(80),"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_AssetAID] nvarchar(80),"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_DpmExp] nvarchar(80),"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_DpmRec] nvarchar(80),"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec] nvarchar(80),"
            //                                            + "           [OfficeAutomation_Document_AssetTransfer_Detail_Number] nvarchar(32))"
            cmdToExecute.CommandText = ""
                                                        + "           INSERT INTO t_OfficeAutomation_Document_AssetTransfer_Detail_Temp"
                                                        + "           ([OfficeAutomation_Document_AssetTransfer_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetName]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetAID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_AssetTag]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_Model]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmExp]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_DpmRec]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_Number]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Detail_TxtType]"
                                                        + "            )"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_AssetTransfer_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_AssetTransfer_Detail_MainID"
                                                        + "           ,@iOfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_AssetName"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Detail_AssetTag"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Detail_Model"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_DpmExp"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_DpmRec"
                                                        + "           ,@OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Detail_Number"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Detail_TxtType"
                                                        + "           )"
                                                        //+ "           INSERT INTO AssetTransfer_Detail select * from #AssetTransfer_Detail"
                                                        ;

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_AssetTransfer_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_AssetTransfer_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_AssetTransfer_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_AssetName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_AssetAID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_AssetTag", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_Model", SqlDbType.NVarChar, 64, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_Model));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_DpmExp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_DpmRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_Number", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Detail_TxtType", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Detail_TxtType));
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
