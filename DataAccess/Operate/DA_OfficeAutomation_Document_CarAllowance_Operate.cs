using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CarAllowance_Operate:SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_CarAllowance _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CarAllowance]"
                                                        + "           ([OfficeAutomation_Document_CarAllowance_ID]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_MainID]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_Apply]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_ApplyForName]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_ApplyForCode]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_EntryDate]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_Department]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_Position]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_Grade]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_IsPositive]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_MoneyGradeID]"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_EffectiveDate])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_CarAllowance_ID"
                                                        + "           ,@guidOfficeAutomation_Document_CarAllowance_MainID"
                                                        + "           ,@sOfficeAutomation_Document_CarAllowance_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_CarAllowance_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_CarAllowance_ApplyForName"
                                                        + "           ,@sOfficeAutomation_Document_CarAllowance_ApplyForCode"
                                                        + "           ,@dtOfficeAutomation_Document_CarAllowance_EntryDate"
                                                        + "           ,@sOfficeAutomation_Document_CarAllowance_Department"
                                                        + "           ,@sOfficeAutomation_Document_CarAllowance_Position"
                                                        + "           ,@sOfficeAutomation_Document_CarAllowance_Grade"
                                                        + "           ,@bOfficeAutomation_Document_CarAllowance_IsPositive"
                                                        + "           ,@iOfficeAutomation_Document_CarAllowance_MoneyGradeID"
                                                        + "           ,@dtOfficeAutomation_Document_CarAllowance_EffectiveDate)";  
                                                        //+ "           ,@iOfficeAutomation_Document_CarAllowance_AgreeMoneyGradeID"
                                                        //+ "           ,@sOfficeAutomation_Document_CarAllowance_Remark)";  

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CarAllowance)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_CarAllowance_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_CarAllowance_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_CarAllowance_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_ApplyForName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_ApplyForName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_ApplyForCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_ApplyForCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_CarAllowance_EntryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_EntryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_Grade", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_Grade));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Document_CarAllowance_IsPositive", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_IsPositive));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_CarAllowance_MoneyGradeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_MoneyGradeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_CarAllowance_EffectiveDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_EffectiveDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_CarAllowance_AgreeMoneyGradeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_AgreeMoneyGradeID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_Remark", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_Remark));

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
            cmdToExecute.CommandText = "dbo.[pr_CarAllowance_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CarAllowance]"
                                                        + "   SET  [OfficeAutomation_Document_CarAllowance_ApplyForName]=@sOfficeAutomation_Document_CarAllowance_ApplyForName"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_ApplyForCode]=@sOfficeAutomation_Document_CarAllowance_ApplyForCode"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_EntryDate]=@dtOfficeAutomation_Document_CarAllowance_EntryDate"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_Department]=@sOfficeAutomation_Document_CarAllowance_Department"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_Position]=@sOfficeAutomation_Document_CarAllowance_Position"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_Grade]=@sOfficeAutomation_Document_CarAllowance_Grade"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_IsPositive]=@bOfficeAutomation_Document_CarAllowance_IsPositive"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_MoneyGradeID]=@iOfficeAutomation_Document_CarAllowance_MoneyGradeID"
                                                        + "           ,[OfficeAutomation_Document_CarAllowance_EffectiveDate]=@dtOfficeAutomation_Document_CarAllowance_EffectiveDate"
                                + " WHERE [OfficeAutomation_Document_CarAllowance_ID]=@guidOfficeAutomation_Document_CarAllowance_ID"
                                + "     AND [OfficeAutomation_Document_CarAllowance_MainID] = @guidOfficeAutomation_Document_CarAllowance_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CarAllowance)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_ApplyForName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_ApplyForName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_ApplyForCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_ApplyForCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_CarAllowance_EntryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_EntryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CarAllowance_Grade", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_Grade));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Document_CarAllowance_IsPositive", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_IsPositive));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_CarAllowance_MoneyGradeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_MoneyGradeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_CarAllowance_EffectiveDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_EffectiveDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_CarAllowance_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_CarAllowance_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CarAllowance_MainID));
                
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
    public class DA_Dic_OfficeAutomation_MoneyGrade_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_MoneyGrade_ID]"
                            + "         ,[OfficeAutomation_MoneyGrade_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_MoneyGrade]"
                            + " WHERE OfficeAutomation_MoneyGrade_ID <= 2";

            return RunSQL(sql);
        }
    }

    #endregion
}
