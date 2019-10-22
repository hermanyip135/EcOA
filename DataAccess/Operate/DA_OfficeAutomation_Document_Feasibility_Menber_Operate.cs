using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Feasibility_Menber_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Feasibility_Menber _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Menber]"
                                                        + "           ([OfficeAutomation_Document_Feasibility_Menber_ID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Menber_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Menber_SeniorDirector]"
                                                        //+ "           ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDirector]"
                                                        //+ "           ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Menber_AreaManager]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Menber_SeniorManager]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Menber_UpperManager]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Menber_businessManager]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Menber_Name]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Menber_Num])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_Feasibility_Menber_ID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Menber_MainID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Menber_SeniorDirector"
                                                        //+ "           ,@OfficeAutomation_Document_Feasibility_Menber_RegionalDirector"
                                                        //+ "           ,@OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Menber_AreaManager"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Menber_SeniorManager"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Menber_UpperManager"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Menber_businessManager"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Menber_Name"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Menber_Num)";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility_Menber)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_SeniorDirector", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_SeniorDirector));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_RegionalDirector", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_RegionalDirector));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_AreaManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_AreaManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_SeniorManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_SeniorManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_UpperManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_UpperManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_businessManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_businessManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_Num", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_Num));
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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Menber]"
                                + " WHERE [OfficeAutomation_Document_Feasibility_Menber_MainID]=@sOfficeAutomation_Document_Feasibility_Menber_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Feasibility_Menber_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Menber]"
                                                        + "     SET [OfficeAutomation_Document_Feasibility_Menber_SeniorDirector]=@OfficeAutomation_Document_Feasibility_Menber_SeniorDirector"
                                                        //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDirector]=@OfficeAutomation_Document_Feasibility_Menber_RegionalDirector"
                                                        //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector]=@OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Menber_AreaManager]=@OfficeAutomation_Document_Feasibility_Menber_AreaManager"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorManager]=@OfficeAutomation_Document_Feasibility_Menber_SeniorManager"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Menber_UpperManager]=@OfficeAutomation_Document_Feasibility_Menber_UpperManager"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Menber_businessManager]=@OfficeAutomation_Document_Feasibility_Menber_businessManager"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Menber_Name]=@OfficeAutomation_Document_Feasibility_Menber_Name"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Menber_Num]=@OfficeAutomation_Document_Feasibility_Menber_Num"
                                                        + " WHERE [OfficeAutomation_Document_Feasibility_Menber_ID]=@OfficeAutomation_Document_Feasibility_Menber_ID"
                                                        + "     AND [OfficeAutomation_Document_Feasibility_Menber_MainID] = @OfficeAutomation_Document_Feasibility_Menber_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility_Menber)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_SeniorDirector", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_SeniorDirector));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_RegionalDirector", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_RegionalDirector));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_AreaManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_AreaManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_SeniorManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_SeniorManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_UpperManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_UpperManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_businessManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_businessManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_Num", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_Num));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Menber_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Menber_MainID));

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
