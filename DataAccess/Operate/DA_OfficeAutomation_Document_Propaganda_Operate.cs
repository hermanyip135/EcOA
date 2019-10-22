using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Propaganda_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Propaganda _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda]"
                                                        + "           ([OfficeAutomation_Document_Propaganda_ID]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Department]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Conneter]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_BranchAddress]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_SumPrice]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_KindOfAdvertising]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_AnotherAdvertising]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_KindOfPrinting]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_AnotherPrinting]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_KindOfMaterial]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_AnotherMaterial]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_KindOfActivity]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_AnotherActivity]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_KindOfMap]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_AnotherMap]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_KindOfGift]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_AnotherGift]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_KindOfSend]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_AnotherSend]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_KindOfAnother]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_AnotherAnother]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Summary]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Width]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Height]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Count]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Package]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_DemandDate]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_PaySituation]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_PayProjectName]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_FearNo]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_AcceptDate]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Accepter]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Designer]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Reason]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Verifyer]"
                                                        //+ "           ,[OfficeAutomation_Document_Propaganda_TNo]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_VerifyDate]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_PayAnother]"
                                                        + "           ,[OfficeAutomation_Document_Propaganda_Grade])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_Propaganda_ID"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_MainID"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Apply"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Department"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Conneter"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_BranchAddress"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_SumPrice"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_KindOfAdvertising"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_AnotherAdvertising"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_KindOfPrinting"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_AnotherPrinting"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_KindOfMaterial"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_AnotherMaterial"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_KindOfActivity"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_AnotherActivity"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_KindOfMap"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_AnotherMap"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_KindOfGift"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_AnotherGift"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_KindOfSend"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_AnotherSend"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_KindOfAnother"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_AnotherAnother"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Summary"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Width"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Height"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Count"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Package"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_DemandDate"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_PaySituation"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_PayProjectName"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_FearNo"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_AcceptDate"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Accepter"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Designer"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Reason"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Verifyer"
                                                        //+ "           ,@OfficeAutomation_Document_Propaganda_TNo"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_VerifyDate"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_PayAnother"
                                                        + "           ,@OfficeAutomation_Document_Propaganda_Grade)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Propaganda)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Conneter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Conneter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_BranchAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_BranchAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_SumPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_SumPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfAdvertising", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfAdvertising));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherAdvertising", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherAdvertising));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfPrinting", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfPrinting));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherPrinting", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherPrinting));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfMaterial", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfMaterial));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherMaterial", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherMaterial));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfActivity", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfActivity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherActivity", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherActivity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfMap", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfMap));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherMap", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherMap));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfGift", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfGift));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherGift", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherGift));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfSend", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfSend));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherSend", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherSend));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfAnother", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfAnother));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherAnother", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherAnother));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Summary", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Summary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Width", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Width));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Height", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Height));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Count", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Count));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Package", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Package));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_DemandDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_DemandDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_PaySituation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_PaySituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_PayProjectName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_PayProjectName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_FearNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_FearNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AcceptDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AcceptDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Accepter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Accepter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Designer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Designer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Verifyer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Verifyer));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_TNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_TNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_VerifyDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_VerifyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_PayAnother", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_PayAnother));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Grade", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Grade));

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
            cmdToExecute.CommandText = "dbo.[pr_Propaganda_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda]"
                                + "         SET [OfficeAutomation_Document_Propaganda_ApplyID] = @OfficeAutomation_Document_Propaganda_ApplyID"
                                + "         ,[OfficeAutomation_Document_Propaganda_Department] = @OfficeAutomation_Document_Propaganda_Department"
                                + "         ,[OfficeAutomation_Document_Propaganda_Conneter] = @OfficeAutomation_Document_Propaganda_Conneter"
                                + "         ,[OfficeAutomation_Document_Propaganda_BranchAddress] = @OfficeAutomation_Document_Propaganda_BranchAddress"
                                + "         ,[OfficeAutomation_Document_Propaganda_SumPrice] = @OfficeAutomation_Document_Propaganda_SumPrice"
                                + "         ,[OfficeAutomation_Document_Propaganda_KindOfAdvertising] = @OfficeAutomation_Document_Propaganda_KindOfAdvertising"
                                + "         ,[OfficeAutomation_Document_Propaganda_AnotherAdvertising] = @OfficeAutomation_Document_Propaganda_AnotherAdvertising"
                                + "         ,[OfficeAutomation_Document_Propaganda_KindOfPrinting] = @OfficeAutomation_Document_Propaganda_KindOfPrinting"
                                + "         ,[OfficeAutomation_Document_Propaganda_AnotherPrinting] = @OfficeAutomation_Document_Propaganda_AnotherPrinting"
                                + "         ,[OfficeAutomation_Document_Propaganda_KindOfMaterial] = @OfficeAutomation_Document_Propaganda_KindOfMaterial"
                                + "         ,[OfficeAutomation_Document_Propaganda_AnotherMaterial] = @OfficeAutomation_Document_Propaganda_AnotherMaterial"
                                + "         ,[OfficeAutomation_Document_Propaganda_KindOfActivity] = @OfficeAutomation_Document_Propaganda_KindOfActivity"
                                + "         ,[OfficeAutomation_Document_Propaganda_AnotherActivity] = @OfficeAutomation_Document_Propaganda_AnotherActivity"
                                + "         ,[OfficeAutomation_Document_Propaganda_KindOfMap] = @OfficeAutomation_Document_Propaganda_KindOfMap"
                                + "         ,[OfficeAutomation_Document_Propaganda_AnotherMap] = @OfficeAutomation_Document_Propaganda_AnotherMap"
                                + "         ,[OfficeAutomation_Document_Propaganda_KindOfGift] = @OfficeAutomation_Document_Propaganda_KindOfGift"
                                + "         ,[OfficeAutomation_Document_Propaganda_AnotherGift] = @OfficeAutomation_Document_Propaganda_AnotherGift"
                                + "         ,[OfficeAutomation_Document_Propaganda_KindOfSend] = @OfficeAutomation_Document_Propaganda_KindOfSend"
                                + "         ,[OfficeAutomation_Document_Propaganda_AnotherSend] = @OfficeAutomation_Document_Propaganda_AnotherSend"
                                + "         ,[OfficeAutomation_Document_Propaganda_KindOfAnother] = @OfficeAutomation_Document_Propaganda_KindOfAnother"
                                + "         ,[OfficeAutomation_Document_Propaganda_AnotherAnother] = @OfficeAutomation_Document_Propaganda_AnotherAnother"
                                + "         ,[OfficeAutomation_Document_Propaganda_Summary] = @OfficeAutomation_Document_Propaganda_Summary"
                                + "         ,[OfficeAutomation_Document_Propaganda_Width] = @OfficeAutomation_Document_Propaganda_Width"
                                + "         ,[OfficeAutomation_Document_Propaganda_Height] = @OfficeAutomation_Document_Propaganda_Height"
                                + "         ,[OfficeAutomation_Document_Propaganda_Count] = @OfficeAutomation_Document_Propaganda_Count"
                                + "         ,[OfficeAutomation_Document_Propaganda_Package] = @OfficeAutomation_Document_Propaganda_Package"
                                + "         ,[OfficeAutomation_Document_Propaganda_DemandDate] = @OfficeAutomation_Document_Propaganda_DemandDate"
                                + "         ,[OfficeAutomation_Document_Propaganda_PaySituation] = @OfficeAutomation_Document_Propaganda_PaySituation"
                                + "         ,[OfficeAutomation_Document_Propaganda_PayProjectName] = @OfficeAutomation_Document_Propaganda_PayProjectName"
                                + "         ,[OfficeAutomation_Document_Propaganda_FearNo] = @OfficeAutomation_Document_Propaganda_FearNo"
                                + "         ,[OfficeAutomation_Document_Propaganda_AcceptDate] = @OfficeAutomation_Document_Propaganda_AcceptDate"
                                + "         ,[OfficeAutomation_Document_Propaganda_Accepter] = @OfficeAutomation_Document_Propaganda_Accepter"
                                + "         ,[OfficeAutomation_Document_Propaganda_Designer] = @OfficeAutomation_Document_Propaganda_Designer"
                                + "         ,[OfficeAutomation_Document_Propaganda_Reason] = @OfficeAutomation_Document_Propaganda_Reason"
                                + "         ,[OfficeAutomation_Document_Propaganda_Verifyer] = @OfficeAutomation_Document_Propaganda_Verifyer"
                                //+ "         ,[OfficeAutomation_Document_Propaganda_TNo] = @OfficeAutomation_Document_Propaganda_TNo"
                                + "         ,[OfficeAutomation_Document_Propaganda_VerifyDate] = @OfficeAutomation_Document_Propaganda_VerifyDate"
                                + "         ,[OfficeAutomation_Document_Propaganda_PayAnother] = @OfficeAutomation_Document_Propaganda_PayAnother"
                                + "         ,[OfficeAutomation_Document_Propaganda_Grade] = @OfficeAutomation_Document_Propaganda_Grade"
                                + "         WHERE [OfficeAutomation_Document_Propaganda_ID]=@OfficeAutomation_Document_Propaganda_ID"
                                + "         AND [OfficeAutomation_Document_Propaganda_MainID]=@OfficeAutomation_Document_Propaganda_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Propaganda)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Conneter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Conneter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_BranchAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_BranchAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_SumPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_SumPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfAdvertising", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfAdvertising));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherAdvertising", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherAdvertising));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfPrinting", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfPrinting));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherPrinting", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherPrinting));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfMaterial", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfMaterial));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherMaterial", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherMaterial));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfActivity", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfActivity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherActivity", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherActivity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfMap", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfMap));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherMap", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherMap));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfGift", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfGift));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherGift", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherGift));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfSend", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfSend));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherSend", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherSend));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_KindOfAnother", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_KindOfAnother));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AnotherAnother", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AnotherAnother));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Summary", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Summary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Width", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Width));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Height", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Height));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Count", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Count));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Package", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Package));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_DemandDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_DemandDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_PaySituation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_PaySituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_PayProjectName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_PayProjectName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_FearNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_FearNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AcceptDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AcceptDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Accepter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Accepter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Designer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Designer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Verifyer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Verifyer));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_TNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_TNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_VerifyDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_VerifyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_PayAnother", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_PayAnother));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Grade", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Grade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_MainID));

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

        #region 签名时更新一些内容
        public bool UpdateForSign(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda]"
                                + "         SET [OfficeAutomation_Document_Propaganda_AcceptDate] = @OfficeAutomation_Document_Propaganda_AcceptDate"
                                + "         ,[OfficeAutomation_Document_Propaganda_Accepter] = @OfficeAutomation_Document_Propaganda_Accepter"
                                + "         ,[OfficeAutomation_Document_Propaganda_Designer] = @OfficeAutomation_Document_Propaganda_Designer"
                                + "         ,[OfficeAutomation_Document_Propaganda_Reason] = @OfficeAutomation_Document_Propaganda_Reason"
                                + "         ,[OfficeAutomation_Document_Propaganda_Verifyer] = @OfficeAutomation_Document_Propaganda_Verifyer"
                                + "         ,[OfficeAutomation_Document_Propaganda_VerifyDate] = @OfficeAutomation_Document_Propaganda_VerifyDate"
                                + "         ,[OfficeAutomation_Document_Propaganda_Grade] = @OfficeAutomation_Document_Propaganda_Grade"
                                + "         WHERE [OfficeAutomation_Document_Propaganda_ID]=@OfficeAutomation_Document_Propaganda_ID"
                                + "         AND [OfficeAutomation_Document_Propaganda_MainID]=@OfficeAutomation_Document_Propaganda_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Propaganda)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_AcceptDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_AcceptDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Accepter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Accepter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Designer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Designer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Verifyer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Verifyer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_VerifyDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_VerifyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_Grade", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_Grade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Propaganda_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Propaganda_MainID));

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
