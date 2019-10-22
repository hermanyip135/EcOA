using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_FurtherEducation_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_FurtherEducation _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_FurtherEducation]"
                                                        + "           ([OfficeAutomation_Document_FurtherEducation_ID]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_MainID]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Apply]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Department]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_No]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_InData]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_OnData]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Position]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Rank]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Srecord]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Welfare]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_IDData]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_School]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Subjects]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_BeginData]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_During]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_EndData]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Fees]"
                //+ "           ,[OfficeAutomation_Document_FurtherEducation_ShouldAllowance]"
                //+ "           ,[OfficeAutomation_Document_FurtherEducation_ApplyAllowance]"
                //+ "           ,[OfficeAutomation_Document_FurtherEducation_ActualyAllowance]"
                //+ "           ,[OfficeAutomation_Document_FurtherEducation_Conditions]"
                //+ "           ,[OfficeAutomation_Document_FurtherEducation_AllowData]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_A]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Name]"
                                                        + "           ,[OfficeAutomation_Document_FurtherEducation_Remark])"
                                                        + "     VALUES"
                                                        + "           (@sOfficeAutomation_Document_FurtherEducation_ID"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_MainID"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Apply"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_ApplyID"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Department"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_No"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_InData"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_OnData"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Position"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Rank"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Srecord"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Welfare"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_IDData"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_School"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Subjects"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_BeginData"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_During"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_EndData"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Fees"
                                                        //+ "           ,@sOfficeAutomation_Document_FurtherEducation_ShouldAllowance"
                                                        //+ "           ,@sOfficeAutomation_Document_FurtherEducation_ApplyAllowance"
                                                        //+ "           ,@sOfficeAutomation_Document_FurtherEducation_ActualyAllowance"
                                                        //+ "           ,@sOfficeAutomation_Document_FurtherEducation_Conditions"
                                                        //+ "           ,@sOfficeAutomation_Document_FurtherEducation_AllowData"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_A"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Name"
                                                        + "           ,@sOfficeAutomation_Document_FurtherEducation_Remark)";




            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_FurtherEducation)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_No", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_InData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_InData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_OnData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_OnData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Srecord", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Srecord));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Welfare", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Welfare));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_IDData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_IDData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_School", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_School));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Subjects", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Subjects));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_BeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_BeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_During", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_During));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_EndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_EndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Fees", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Fees));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ShouldAllowance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ShouldAllowance));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ApplyAllowance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ApplyAllowance));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ActualyAllowance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ActualyAllowance));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Conditions", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Conditions));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_AllowData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_AllowData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_A", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_A));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Remark", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Remark));
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
            cmdToExecute.CommandText = "dbo.[pr_FurtherEducation_Delete]";
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

        #region 更新记录1
        public bool Update1(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_FurtherEducation]"

            + "     SET   [OfficeAutomation_Document_FurtherEducation_ApplyID]=@sOfficeAutomation_Document_FurtherEducation_ApplyID"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Department]=@sOfficeAutomation_Document_FurtherEducation_Department"
            + "            ,[OfficeAutomation_Document_FurtherEducation_No]=@sOfficeAutomation_Document_FurtherEducation_No"
            + "            ,[OfficeAutomation_Document_FurtherEducation_InData]=@sOfficeAutomation_Document_FurtherEducation_InData"
            + "            ,[OfficeAutomation_Document_FurtherEducation_OnData]=@sOfficeAutomation_Document_FurtherEducation_OnData"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Position]=@sOfficeAutomation_Document_FurtherEducation_Position"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Rank]=@sOfficeAutomation_Document_FurtherEducation_Rank"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Srecord]=@sOfficeAutomation_Document_FurtherEducation_Srecord"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Welfare]=@sOfficeAutomation_Document_FurtherEducation_Welfare"
            + "            ,[OfficeAutomation_Document_FurtherEducation_IDData]=@sOfficeAutomation_Document_FurtherEducation_IDData"
            + "            ,[OfficeAutomation_Document_FurtherEducation_School]=@sOfficeAutomation_Document_FurtherEducation_School"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Subjects]=@sOfficeAutomation_Document_FurtherEducation_Subjects"
            + "            ,[OfficeAutomation_Document_FurtherEducation_BeginData]=@sOfficeAutomation_Document_FurtherEducation_BeginData"
            + "            ,[OfficeAutomation_Document_FurtherEducation_During]=@sOfficeAutomation_Document_FurtherEducation_During"
            + "            ,[OfficeAutomation_Document_FurtherEducation_EndData]=@sOfficeAutomation_Document_FurtherEducation_EndData"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Fees]=@sOfficeAutomation_Document_FurtherEducation_Fees"
            //+ "            ,[OfficeAutomation_Document_FurtherEducation_ShouldAllowance]=@sOfficeAutomation_Document_FurtherEducation_ShouldAllowance"
            //+ "            ,[OfficeAutomation_Document_FurtherEducation_ApplyAllowance]=@sOfficeAutomation_Document_FurtherEducation_ApplyAllowance"
            //+ "            ,[OfficeAutomation_Document_FurtherEducation_ActualyAllowance]=@sOfficeAutomation_Document_FurtherEducation_ActualyAllowance"
            //+ "            ,[OfficeAutomation_Document_FurtherEducation_Conditions]=@sOfficeAutomation_Document_FurtherEducation_Conditions"
            //+ "            ,[OfficeAutomation_Document_FurtherEducation_AllowData]=@sOfficeAutomation_Document_FurtherEducation_AllowData"
            + "            ,[OfficeAutomation_Document_FurtherEducation_A]=@sOfficeAutomation_Document_FurtherEducation_A"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Name]=@sOfficeAutomation_Document_FurtherEducation_Name"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Remark]=@sOfficeAutomation_Document_FurtherEducation_Remark"
            + " WHERE [OfficeAutomation_Document_FurtherEducation_ID]=@sOfficeAutomation_Document_FurtherEducation_ID"
            + "     AND [OfficeAutomation_Document_FurtherEducation_MainID]=@sOfficeAutomation_Document_FurtherEducation_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_FurtherEducation)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_No", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_InData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_InData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_OnData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_OnData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Srecord", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Srecord));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Welfare", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Welfare));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_IDData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_IDData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_School", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_School));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Subjects", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Subjects));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_BeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_BeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_During", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_During));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_EndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_EndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Fees", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Fees));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ShouldAllowance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ShouldAllowance));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ApplyAllowance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ApplyAllowance));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ActualyAllowance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ActualyAllowance));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Conditions", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Conditions));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_AllowData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_AllowData));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_A", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_A));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Remark", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Remark));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_MainID));

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

        #region 更新记录2
        public bool Update2(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_FurtherEducation]"

            + "     SET    [OfficeAutomation_Document_FurtherEducation_ShouldAllowance]=@sOfficeAutomation_Document_FurtherEducation_ShouldAllowance"
            + "            ,[OfficeAutomation_Document_FurtherEducation_ApplyAllowance]=@sOfficeAutomation_Document_FurtherEducation_ApplyAllowance"
            + "            ,[OfficeAutomation_Document_FurtherEducation_ActualyAllowance]=@sOfficeAutomation_Document_FurtherEducation_ActualyAllowance"
            + "            ,[OfficeAutomation_Document_FurtherEducation_Conditions]=@sOfficeAutomation_Document_FurtherEducation_Conditions"
            + "            ,[OfficeAutomation_Document_FurtherEducation_AllowData]=@sOfficeAutomation_Document_FurtherEducation_AllowData"
            //+ "            ,[OfficeAutomation_Document_FurtherEducation_A]=@sOfficeAutomation_Document_FurtherEducation_A"
            //+ "            ,[OfficeAutomation_Document_FurtherEducation_Remark]=@sOfficeAutomation_Document_FurtherEducation_Remark"
            + " WHERE [OfficeAutomation_Document_FurtherEducation_ID]=@sOfficeAutomation_Document_FurtherEducation_ID"
            + "     AND [OfficeAutomation_Document_FurtherEducation_MainID]=@sOfficeAutomation_Document_FurtherEducation_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_FurtherEducation)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ShouldAllowance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ShouldAllowance));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ApplyAllowance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ApplyAllowance));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ActualyAllowance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ActualyAllowance));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Conditions", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Conditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_AllowData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_AllowData));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_A", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_A));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_Remark", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_Remark));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_FurtherEducation_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_FurtherEducation_MainID));

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
