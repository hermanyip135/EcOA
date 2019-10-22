using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Repair_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Repair_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Repair_Detail]"
                                                        + "           ([OfficeAutomation_Document_Repair_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Detail_No]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Detail_Pname]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Detail_Brand]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Detail_Unit]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Detail_Price]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Detail_Num]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Detail_Money]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Detail_Summary])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_Repair_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_Repair_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_Repair_Detail_No"
                                                        + "           ,@OfficeAutomation_Document_Repair_Detail_Pname"
                                                        + "           ,@OfficeAutomation_Document_Repair_Detail_Brand"
                                                        + "           ,@OfficeAutomation_Document_Repair_Detail_Unit"
                                                        + "           ,@OfficeAutomation_Document_Repair_Detail_Price"
                                                        + "           ,@OfficeAutomation_Document_Repair_Detail_Num"
                                                        + "           ,@OfficeAutomation_Document_Repair_Detail_Money"
                                                        + "           ,@OfficeAutomation_Document_Repair_Detail_Summary)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Repair_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Repair_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Repair_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_No", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Pname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Pname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Brand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Brand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Unit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Unit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Price", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Price));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Num", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Num));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Money", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Money));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Summary", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Summary));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Repair_Detail]"
                                + "   SET [OfficeAutomation_Document_Repair_Detail_No] =@OfficeAutomation_Document_Repair_Detail_No"

                                + "         ,[OfficeAutomation_Document_Repair_Detail_Pname] = @OfficeAutomation_Document_Repair_Detail_Pname"
                                + "         ,[OfficeAutomation_Document_Repair_Detail_Brand] = @OfficeAutomation_Document_Repair_Detail_Brand"
                                + "         ,[OfficeAutomation_Document_Repair_Detail_Unit] = @OfficeAutomation_Document_Repair_Detail_Unit"
                                + "         ,[OfficeAutomation_Document_Repair_Detail_Price] = @OfficeAutomation_Document_Repair_Detail_Price"
                                + "         ,[OfficeAutomation_Document_Repair_Detail_Num] = @OfficeAutomation_Document_Repair_Detail_Num"
                                + "         ,[OfficeAutomation_Document_Repair_Detail_Money] = @OfficeAutomation_Document_Repair_Detail_Money"
                                + "         ,[OfficeAutomation_Document_Repair_Detail_Summary] = @OfficeAutomation_Document_Repair_Detail_Summary"

                                + " WHERE [OfficeAutomation_Document_Repair_Detail_ID]=@guidOfficeAutomation_Document_Repair_Detail_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Repair_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_No", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Pname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Pname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Brand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Brand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Unit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Unit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Price", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Price));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Num", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Num));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Money", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Money));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Detail_Summary", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_Summary));

                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Repair_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Detail_ID));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Repair_Detail]"
                                + " WHERE [OfficeAutomation_Document_Repair_Detail_MainID]=@guidOfficeAutomation_Document_Repair_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Repair_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

    #region 供应商类

    /// <summary>
    /// 供应商类
    /// </summary>
    public class DA_Dic_OfficeAutomation_Supplier_Operate : SqlInteractionBase
    {
        public DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_Document_Supplier_No]"
                            + "         ,[OfficeAutomation_Document_Supplier_Supply]"
                            + "         ,[OfficeAutomation_Document_Supplier_Conneter]"
                            + "         ,[OfficeAutomation_Document_Supplier_Telephone]"
                            + "         ,[OfficeAutomation_Document_Supplier_Email]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Supplier]";

            return RunSQL(sql);
        }

        public DataSet SelectSupplyByName(string n)
        {
            string sql = "SELECT [OfficeAutomation_Document_Supplier_No]"
                            + "         ,[OfficeAutomation_Document_Supplier_Supply]"
                            + "         ,[OfficeAutomation_Document_Supplier_Conneter]"
                            + "         ,[OfficeAutomation_Document_Supplier_Telephone]"
                            + "         ,[OfficeAutomation_Document_Supplier_Email]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Supplier]"
                            + "  WHERE OfficeAutomation_Document_Supplier_Supply = '" + n + "'";

            return RunSQL(sql);
        }

        public DataSet SelectSupply()
        {
            string sql = "SELECT OfficeAutomation_Document_Supplier_No,OfficeAutomation_Document_Supplier_Supply FROM t_OfficeAutomation_Document_Supplier";
            return RunSQL(sql);
        }
    }

    #endregion
}
