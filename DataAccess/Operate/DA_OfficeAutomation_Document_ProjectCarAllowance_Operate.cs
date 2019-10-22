using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ProjectCarAllowance_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ProjectCarAllowance _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectCarAllowance]"
                                                        + "           ([OfficeAutomation_Document_ProjectCarAllowance_ID]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Apply]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyForName]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyForCode]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_EntryDate]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Department]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Position]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Grade]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_IsPositive]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyType]"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_EffectiveDate])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_ProjectCarAllowance_ID"
                                                        + "           ,@guidOfficeAutomation_Document_ProjectCarAllowance_MainID"
                                                        + "           ,@sOfficeAutomation_Document_ProjectCarAllowance_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_ProjectCarAllowance_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_ProjectCarAllowance_ApplyForName"
                                                        + "           ,@sOfficeAutomation_Document_ProjectCarAllowance_ApplyForCode"
                                                        + "           ,@dtOfficeAutomation_Document_ProjectCarAllowance_EntryDate"
                                                        + "           ,@sOfficeAutomation_Document_ProjectCarAllowance_Department"
                                                        + "           ,@sOfficeAutomation_Document_ProjectCarAllowance_Position"
                                                        + "           ,@sOfficeAutomation_Document_ProjectCarAllowance_Grade"
                                                        + "           ,@bOfficeAutomation_Document_ProjectCarAllowance_IsPositive"
                                                        + "           ,@iOfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID"
                                                        + "           ,@bOfficeAutomation_Document_ProjectCarAllowance_ApplyType"
                                                        + "           ,@dtOfficeAutomation_Document_ProjectCarAllowance_EffectiveDate)";
            //+ "           ,@iOfficeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID"
            //+ "           ,@sOfficeAutomation_Document_ProjectCarAllowance_Remark)";  

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ProjectCarAllowance)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ProjectCarAllowance_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ProjectCarAllowance_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ProjectCarAllowance_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_ApplyForName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_ApplyForName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_ApplyForCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_ApplyForCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ProjectCarAllowance_EntryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_EntryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_Grade", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_Grade));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Document_ProjectCarAllowance_IsPositive", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_IsPositive));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Document_ProjectCarAllowance_ApplyType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_ApplyType));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ProjectCarAllowance_EffectiveDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_EffectiveDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_Remark", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_Remark));

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
            cmdToExecute.CommandText = "dbo.[pr_ProjectCarAllowance_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectCarAllowance]"
                                                        + "   SET  [OfficeAutomation_Document_ProjectCarAllowance_ApplyForName]=@sOfficeAutomation_Document_ProjectCarAllowance_ApplyForName"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyForCode]=@sOfficeAutomation_Document_ProjectCarAllowance_ApplyForCode"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_EntryDate]=@dtOfficeAutomation_Document_ProjectCarAllowance_EntryDate"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Department]=@sOfficeAutomation_Document_ProjectCarAllowance_Department"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Position]=@sOfficeAutomation_Document_ProjectCarAllowance_Position"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_Grade]=@sOfficeAutomation_Document_ProjectCarAllowance_Grade"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_IsPositive]=@bOfficeAutomation_Document_ProjectCarAllowance_IsPositive"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID]=@iOfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_EffectiveDate]=@dtOfficeAutomation_Document_ProjectCarAllowance_EffectiveDate"
                                                        + "           ,[OfficeAutomation_Document_ProjectCarAllowance_ApplyType]=@bOfficeAutomation_Document_ProjectCarAllowance_ApplyType"
                                + " WHERE [OfficeAutomation_Document_ProjectCarAllowance_ID]=@guidOfficeAutomation_Document_ProjectCarAllowance_ID"
                                + "     AND [OfficeAutomation_Document_ProjectCarAllowance_MainID] = @guidOfficeAutomation_Document_ProjectCarAllowance_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ProjectCarAllowance)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_ApplyForName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_ApplyForName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_ApplyForCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_ApplyForCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ProjectCarAllowance_EntryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_EntryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjectCarAllowance_Grade", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_Grade));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Document_ProjectCarAllowance_IsPositive", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_IsPositive));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Document_ProjectCarAllowance_ApplyType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_ApplyType));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ProjectCarAllowance_EffectiveDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_EffectiveDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ProjectCarAllowance_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ProjectCarAllowance_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjectCarAllowance_MainID));

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

    #region 字典表

    /// <summary>
    /// 申请金额级别字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_MoneyGrade_Operate2 : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_MoneyGrade_ID]"
                            + "         ,[OfficeAutomation_MoneyGrade_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_MoneyGrade]"
                            + " WHERE OfficeAutomation_MoneyGrade_ID > 2";

            return RunSQL(sql);
        }
    }

    #endregion
}
