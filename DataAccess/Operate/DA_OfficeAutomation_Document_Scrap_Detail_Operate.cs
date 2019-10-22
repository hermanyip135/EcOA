using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Scrap_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Scrap_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail]"
                                                        + "           ([OfficeAutomation_Document_Scrap_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetTypeID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetTag]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_Model]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetName]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_PlaceRec]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetAID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_Number]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_BuyDate]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue]"
                                                        +"            ,[OfficeAutomation_Document_Scrap_Detail_Cost]"
                                                        +"            ,[OfficeAutomation_Document_Scrap_Detail_CreateTime]"
                                                        +"            ,[OfficeAutomation_Document_Scrap_Detail_PlaceExp]"
                                                        +"            ,[OfficeAutomation_Document_Scrap_Detail_DpmExp]"
                                                        +"            ,[OfficeAutomation_Document_Scrap_Detail_PlaceExpId]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_CV]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AdjustmentID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_Type]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_DpmRec] )"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_Scrap_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_Scrap_Detail_MainID"
                                                        + "           ,@iOfficeAutomation_Document_Scrap_Detail_AssetTypeID"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_AssetTag"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_Model"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_AssetName"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_PlaceRec"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_AssetAID"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_Number"
                                                        + "           ,@dtOfficeAutomation_Document_Scrap_Detail_BuyDate"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_SurplusValue"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_Cost"
                                                        + "           ,@dOfficeAutomation_Document_Scrap_Detail_CreateTime"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_PlaceExp"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_DpmExp"
                                                        + "           ,@iOfficeAutomation_Document_Scrap_Detail_PlaceExpId"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_CV"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_AdjustmentID"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_Type"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_DpmRec)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Scrap_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_Scrap_Detail_AssetTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_AssetTag", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetTag));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_Model", SqlDbType.NVarChar, 64, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Model));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AssetName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_PlaceRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_PlaceRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AssetAID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetAID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_Number", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_Scrap_Detail_BuyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_BuyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_SurplusValue", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_SurplusValue));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_Cost", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Cost));
                cmdToExecute.Parameters.Add(new SqlParameter("@dOfficeAutomation_Document_Scrap_Detail_CreateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_CreateTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_PlaceExp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_PlaceExp));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_DpmExp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_DpmExp));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_Scrap_Detail_PlaceExpId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_PlaceExpId));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AdjustmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AdjustmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_CV", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_CV));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_DpmRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_DpmRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_Type", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Type));
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail]"
                                + "   SET [OfficeAutomation_Document_Scrap_Detail_AssetTypeID] =@iOfficeAutomation_Document_Scrap_Detail_AssetTypeID"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_AssetTag] = @sOfficeAutomation_Document_Scrap_Detail_AssetTag"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_Model] = @sOfficeAutomation_Document_Scrap_Detail_Model"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_AssetName]= @OfficeAutomation_Document_Scrap_Detail_AssetName"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_PlaceRec]= @OfficeAutomation_Document_Scrap_Detail_PlaceRec"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_AssetAID]= @OfficeAutomation_Document_Scrap_Detail_AssetAID"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_Number] = @sOfficeAutomation_Document_Scrap_Detail_Number"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_BuyDate] = @dtOfficeAutomation_Document_Scrap_Detail_BuyDate"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue]= @sOfficeAutomation_Document_Scrap_Detail_SurplusValue"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_Cost]= @OfficeAutomation_Document_Scrap_Detail_Cost"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_CreateTime]= @dOfficeAutomation_Document_Scrap_Detail_CreateTime"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_PlaceExp]= @sOfficeAutomation_Document_Scrap_Detail_PlaceExp"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_DpmExp]= @sOfficeAutomation_Document_Scrap_Detail_DpmExp"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_PlaceExpId]= @iOfficeAutomation_Document_Scrap_Detail_PlaceExpId"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_CV]= @sOfficeAutomation_Document_Scrap_Detail_CV"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_AdjustmentID]= @OfficeAutomation_Document_Scrap_Detail_AdjustmentID"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_Type]= @OfficeAutomation_Document_Scrap_Detail_Type"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_DpmRec]= @sOfficeAutomation_Document_Scrap_Detail_DpmRec"
                                + " WHERE [OfficeAutomation_Document_Scrap_Detail_ID]=@guidOfficeAutomation_Document_Scrap_Detail_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Scrap_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_Scrap_Detail_AssetTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_AssetTag", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetTag));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_Model", SqlDbType.NVarChar, 64, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Model));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AssetName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_PlaceRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_PlaceRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AssetAID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetAID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_Number", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_Scrap_Detail_BuyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_BuyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_SurplusValue", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_SurplusValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_ID));


                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_Cost", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Cost));
                cmdToExecute.Parameters.Add(new SqlParameter("@dOfficeAutomation_Document_Scrap_Detail_CreateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_CreateTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_PlaceExp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_PlaceExp));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_DpmExp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_DpmExp));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_Scrap_Detail_PlaceExpId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_PlaceExpId));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_CV", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_CV));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AdjustmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AdjustmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_DpmRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_DpmRec));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_Type", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Type));
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
            cmdToExecute.CommandText = "dbo.[pr_Scrap_Detail_Delete]";
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


        public bool DeleteByID(Guid ID)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail]"
                                + " WHERE [OfficeAutomation_Document_Scrap_Detail_ID]=@OfficeAutomation_Document_Scrap_Detail_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ID));

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
        

        #region 插入临时记录
        /// <summary>
        /// 插入临时记录
        /// </summary>
        /// <returns></returns>
        public bool InsertTemporary(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail_Temp]"
                                                        + "           ([OfficeAutomation_Document_Scrap_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetTypeID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetTag]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_Model]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetName]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_PlaceRec]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetAID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_Number]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_BuyDate]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_Scrap_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_Scrap_Detail_MainID"
                                                        + "           ,@iOfficeAutomation_Document_Scrap_Detail_AssetTypeID"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_AssetTag"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_Model"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_AssetName"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_PlaceRec"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_AssetAID"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_Number"
                                                        + "           ,@dtOfficeAutomation_Document_Scrap_Detail_BuyDate"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_SurplusValue)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Scrap_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_Scrap_Detail_AssetTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_AssetTag", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetTag));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_Model", SqlDbType.NVarChar, 64, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Model));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AssetName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_PlaceRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_PlaceRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AssetAID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetAID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_Number", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_Scrap_Detail_BuyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_BuyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_SurplusValue", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_SurplusValue));

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

        #region 更新临时记录
        public bool UpdateTemp(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail_Temp]"
                                + "   SET [OfficeAutomation_Document_Scrap_Detail_BuyDate] =@OfficeAutomation_Document_Scrap_Detail_BuyDate"
                                + "         ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue] = @OfficeAutomation_Document_Scrap_Detail_SurplusValue"
                                + " WHERE [OfficeAutomation_Document_Scrap_Detail_MainID]=@OfficeAutomation_Document_Scrap_Detail_MainID"
                                + " AND OfficeAutomation_Document_Scrap_Detail_AssetTag = @OfficeAutomation_Document_Scrap_Detail_AssetTag";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Scrap_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_BuyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_BuyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_SurplusValue", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_SurplusValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AssetTag", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetTag));

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

        #region 插入没有购买时间及折旧摊分剩余费用的记录
        /// <summary>
        /// 插入没有购买时间及折旧摊分剩余费用的记录
        /// </summary>
        /// <returns></returns>
        public bool InsertHaventDate(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap_Detail]"
                                                        + "           ([OfficeAutomation_Document_Scrap_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetTypeID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetTag]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_Model]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetName]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_PlaceRec]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_AssetAID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Detail_Number])"
                                                        //+ "           ,[OfficeAutomation_Document_Scrap_Detail_BuyDate]"
                                                        //+ "           ,[OfficeAutomation_Document_Scrap_Detail_SurplusValue])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_Scrap_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_Scrap_Detail_MainID"
                                                        + "           ,@iOfficeAutomation_Document_Scrap_Detail_AssetTypeID"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_AssetTag"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_Model"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_AssetName"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_PlaceRec"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Detail_AssetAID"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Detail_Number)";
                                                        //+ "           ,@dtOfficeAutomation_Document_Scrap_Detail_BuyDate"
                                                        //+ "           ,@sOfficeAutomation_Document_Scrap_Detail_SurplusValue)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Scrap_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_Scrap_Detail_AssetTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_AssetTag", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetTag));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_Model", SqlDbType.NVarChar, 64, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Model));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AssetName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_PlaceRec", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_PlaceRec));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Detail_AssetAID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_AssetAID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_Number", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_Number));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_Scrap_Detail_BuyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_BuyDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Detail_SurplusValue", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Detail_SurplusValue));

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
