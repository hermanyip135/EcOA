using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_DealOffice_Operate:SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_DealOffice _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_DealOffice]"
                                                        + "           ([OfficeAutomation_Document_DealOffice_ID]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_MainID]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_Apply]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_Department]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_ReplyFax]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_WorkArea]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_Branch]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_TypeID]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_OfficeArea]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_OfficeAddress]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealArea]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealPrice]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealOwnerMoney]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealOwnerPercent]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealClientMoney]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealClientPercent]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealMoney]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealPercent]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseArea]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeasePrice]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseOwnerMoney]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseOwnerPercent]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseClientMoney]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseClientPercent]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseMoney]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeasePercent]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_CrossAreaRemark]"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_MoneyRemark])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_DealOffice_ID"
                                                        + "           ,@guidOfficeAutomation_Document_DealOffice_MainID"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_DealOffice_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_Department"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_ReplyPhone"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_ReplyFax"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_WorkArea"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_Branch"
                                                        + "           ,@iOfficeAutomation_Document_DealOffice_TypeID"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_OfficeArea"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_OfficeAddress"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_DealArea"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_DealPrice"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_DealOwnerMoney"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_DealOwnerPercent"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_DealClientMoney"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_DealClientPercent"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_DealMoney"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_DealPercent"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_LeaseArea"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_LeasePrice"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_LeaseOwnerMoney"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_LeaseOwnerPercent"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_LeaseClientMoney"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_LeaseClientPercent"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_LeaseMoney"
                                                        + "           ,@fOfficeAutomation_Document_DealOffice_LeasePercent"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_CrossAreaRemark"
                                                        + "           ,@sOfficeAutomation_Document_DealOffice_MoneyRemark)";  

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_DealOffice)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_DealOffice_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_DealOffice_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_DealOffice_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_ReplyFax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_ReplyFax));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_WorkArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_WorkArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_DealOffice_TypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_TypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_OfficeArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_OfficeArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_OfficeAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_OfficeAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealArea", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealPrice", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealOwnerMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealOwnerMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealOwnerPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealOwnerPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealClientMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealClientMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealClientPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealClientPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseArea", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeasePrice", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeasePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseOwnerMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseOwnerMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseOwnerPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseOwnerPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseClientMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseClientMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseClientPercent", SqlDbType.Float, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseClientPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeasePercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeasePercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_CrossAreaRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_CrossAreaRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_MoneyRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_MoneyRemark));

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
            cmdToExecute.CommandText = "dbo.[pr_DealOffice_Delete]";
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









        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(DataEntity.T_OfficeAutomation_Document_DealOffice model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update t_OfficeAutomation_Document_DealOffice set ");
        //    //strSql.Append("OfficeAutomation_Document_DealOffice_MainID=@OfficeAutomation_Document_DealOffice_MainID,");
        //    //strSql.Append("OfficeAutomation_Document_DealOffice_Apply=@OfficeAutomation_Document_DealOffice_Apply,");
        //    //strSql.Append("OfficeAutomation_Document_DealOffice_ApplyDate=@OfficeAutomation_Document_DealOffice_ApplyDate,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_Department=@OfficeAutomation_Document_DealOffice_Department,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_ReplyPhone=@OfficeAutomation_Document_DealOffice_ReplyPhone,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_ReplyFax=@OfficeAutomation_Document_DealOffice_ReplyFax,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_WorkArea=@OfficeAutomation_Document_DealOffice_WorkArea,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_Branch=@OfficeAutomation_Document_DealOffice_Branch,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_TypeID=@OfficeAutomation_Document_DealOffice_TypeID,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_OfficeArea=@OfficeAutomation_Document_DealOffice_OfficeArea,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_OfficeAddress=@OfficeAutomation_Document_DealOffice_OfficeAddress,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_DealArea=@OfficeAutomation_Document_DealOffice_DealArea,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_DealPrice=@OfficeAutomation_Document_DealOffice_DealPrice,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_DealOwnerMoney=@OfficeAutomation_Document_DealOffice_DealOwnerMoney,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_DealOwnerPercent=@OfficeAutomation_Document_DealOffice_DealOwnerPercent,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_DealClientMoney=@OfficeAutomation_Document_DealOffice_DealClientMoney,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_DealClientPercent=@OfficeAutomation_Document_DealOffice_DealClientPercent,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_DealMoney=@OfficeAutomation_Document_DealOffice_DealMoney,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_DealPercent=@OfficeAutomation_Document_DealOffice_DealPercent,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_LeaseArea=@OfficeAutomation_Document_DealOffice_LeaseArea,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_LeasePrice=@OfficeAutomation_Document_DealOffice_LeasePrice,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_LeaseOwnerMoney=@OfficeAutomation_Document_DealOffice_LeaseOwnerMoney,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_LeaseOwnerPercent=@OfficeAutomation_Document_DealOffice_LeaseOwnerPercent,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_LeaseClientMoney=@OfficeAutomation_Document_DealOffice_LeaseClientMoney,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_LeaseClientPercent=@OfficeAutomation_Document_DealOffice_LeaseClientPercent,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_LeaseMoney=@OfficeAutomation_Document_DealOffice_LeaseMoney,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_LeasePercent=@OfficeAutomation_Document_DealOffice_LeasePercent,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_CrossAreaRemark=@OfficeAutomation_Document_DealOffice_CrossAreaRemark,");
        //    strSql.Append("OfficeAutomation_Document_DealOffice_MoneyRemark=@OfficeAutomation_Document_DealOffice_MoneyRemark");
        //    strSql.Append(" where OfficeAutomation_Document_DealOffice_ID=@OfficeAutomation_Document_DealOffice_ID ");
        //    strSql.Append(" AND OfficeAutomation_Document_DealOffice_MainID=@OfficeAutomation_Document_DealOffice_MainID ");
        //    SqlParameter[] parameters = {
                    
        //            //new SqlParameter("@OfficeAutomation_Document_DealOffice_Apply", SqlDbType.NVarChar,80),
        //            //new SqlParameter("@OfficeAutomation_Document_DealOffice_ApplyDate", SqlDbType.DateTime),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_Department", SqlDbType.NVarChar,80),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_ReplyPhone", SqlDbType.NVarChar,80),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_ReplyFax", SqlDbType.NVarChar,80),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_WorkArea", SqlDbType.NVarChar,80),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_Branch", SqlDbType.NVarChar,80),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_TypeID", SqlDbType.Int,4),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_OfficeArea", SqlDbType.NVarChar,80),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_OfficeAddress", SqlDbType.NVarChar,200),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_DealArea", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_DealPrice", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_DealOwnerMoney", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_DealOwnerPercent", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_DealClientMoney", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_DealClientPercent", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_DealMoney", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_DealPercent", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_LeaseArea", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_LeasePrice", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_LeaseOwnerMoney", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_LeaseOwnerPercent", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_LeaseClientMoney", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_LeaseClientPercent", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_LeaseMoney", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_LeasePercent", SqlDbType.Decimal, 32),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_CrossAreaRemark", SqlDbType.NVarChar,200),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_MoneyRemark", SqlDbType.NVarChar,200),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_ID", SqlDbType.UniqueIdentifier,16),
        //            new SqlParameter("@OfficeAutomation_Document_DealOffice_MainID", SqlDbType.UniqueIdentifier,16)};
            
        //    //parameters[1].Value = model.OfficeAutomation_Document_DealOffice_Apply;
        //    //parameters[2].Value = model.OfficeAutomation_Document_DealOffice_ApplyDate;
        //    parameters[0].Value = model.OfficeAutomation_Document_DealOffice_Department;
        //    parameters[1].Value = model.OfficeAutomation_Document_DealOffice_ReplyPhone;
        //    parameters[2].Value = model.OfficeAutomation_Document_DealOffice_ReplyFax;
        //    parameters[3].Value = model.OfficeAutomation_Document_DealOffice_WorkArea;
        //    parameters[4].Value = model.OfficeAutomation_Document_DealOffice_Branch;
        //    parameters[5].Value = model.OfficeAutomation_Document_DealOffice_TypeID;
        //    parameters[6].Value = model.OfficeAutomation_Document_DealOffice_OfficeArea;
        //    parameters[7].Value = model.OfficeAutomation_Document_DealOffice_OfficeAddress;
        //    parameters[8].Value = model.OfficeAutomation_Document_DealOffice_DealArea;
        //    parameters[9].Value = model.OfficeAutomation_Document_DealOffice_DealPrice;
        //    parameters[10].Value = model.OfficeAutomation_Document_DealOffice_DealOwnerMoney;
        //    parameters[11].Value = model.OfficeAutomation_Document_DealOffice_DealOwnerPercent;
        //    parameters[12].Value = model.OfficeAutomation_Document_DealOffice_DealClientMoney;
        //    parameters[13].Value = model.OfficeAutomation_Document_DealOffice_DealClientPercent;
        //    parameters[14].Value = model.OfficeAutomation_Document_DealOffice_DealMoney;
        //    parameters[15].Value = model.OfficeAutomation_Document_DealOffice_DealPercent;
        //    parameters[16].Value = model.OfficeAutomation_Document_DealOffice_LeaseArea;
        //    parameters[17].Value = model.OfficeAutomation_Document_DealOffice_LeasePrice;
        //    parameters[18].Value = model.OfficeAutomation_Document_DealOffice_LeaseOwnerMoney;
        //    parameters[19].Value = model.OfficeAutomation_Document_DealOffice_LeaseOwnerPercent;
        //    parameters[20].Value = model.OfficeAutomation_Document_DealOffice_LeaseClientMoney;
        //    parameters[21].Value = model.OfficeAutomation_Document_DealOffice_LeaseClientPercent;
        //    parameters[22].Value = model.OfficeAutomation_Document_DealOffice_LeaseMoney;
        //    parameters[23].Value = model.OfficeAutomation_Document_DealOffice_LeasePercent;
        //    parameters[24].Value = model.OfficeAutomation_Document_DealOffice_CrossAreaRemark;
        //    parameters[25].Value = model.OfficeAutomation_Document_DealOffice_MoneyRemark;
        //    parameters[26].Value = model.OfficeAutomation_Document_DealOffice_ID;
        //    parameters[27].Value = model.OfficeAutomation_Document_DealOffice_MainID;

        //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}











        #region 更新记录
        public override bool Update(object obj)
        //public bool Update2(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            //            cmdToExecute.CommandText = "update t_OfficeAutomation_Document_DealOffice "
            //+ "set OfficeAutomation_Document_DealOffice_MainID='7783613D-882F-40F0-88E8-BA2A0D79705B'"
            //+ ",OfficeAutomation_Document_DealOffice_Apply='吴卓霖'"
            //+ ",OfficeAutomation_Document_DealOffice_ApplyDate='2014-08-07'"
            //+ ",OfficeAutomation_Document_DealOffice_Department='22222222222'"
            //+ ",OfficeAutomation_Document_DealOffice_ReplyPhone='1'"
            //+ ",OfficeAutomation_Document_DealOffice_ReplyFax='1'"
            //+ ",OfficeAutomation_Document_DealOffice_WorkArea='1'"
            //+ ",OfficeAutomation_Document_DealOffice_Branch='1'"
            //+ ",OfficeAutomation_Document_DealOffice_TypeID='1'"
            //+ ",OfficeAutomation_Document_DealOffice_OfficeArea='1'"
            //+ ",OfficeAutomation_Document_DealOffice_OfficeAddress='1'"
            //+ ",OfficeAutomation_Document_DealOffice_DealArea='1'"
            //+ ",OfficeAutomation_Document_DealOffice_DealPrice='1'"
            //+ ",OfficeAutomation_Document_DealOffice_DealOwnerMoney='1'"
            //+ ",OfficeAutomation_Document_DealOffice_DealOwnerPercent='1'"
            //+ ",OfficeAutomation_Document_DealOffice_DealClientMoney='1'"
            //+ ",OfficeAutomation_Document_DealOffice_DealClientPercent='1'"
            //+ ",OfficeAutomation_Document_DealOffice_DealMoney='1'"
            //+ ",OfficeAutomation_Document_DealOffice_DealPercent='1'"
            //+ ",OfficeAutomation_Document_DealOffice_LeaseArea='1'"
            //+ ",OfficeAutomation_Document_DealOffice_LeasePrice='1'"
            //+ ",OfficeAutomation_Document_DealOffice_LeaseOwnerMoney='1'"
            //+ ",OfficeAutomation_Document_DealOffice_LeaseOwnerPercent='1'"
            //+ ",OfficeAutomation_Document_DealOffice_LeaseClientMoney='1'"
            //+ ",OfficeAutomation_Document_DealOffice_LeaseClientPercent='1'"
            //+ ",OfficeAutomation_Document_DealOffice_LeaseMoney='1'"
            //+ ",OfficeAutomation_Document_DealOffice_LeasePercent='1'"
            //+ ",OfficeAutomation_Document_DealOffice_CrossAreaRemark='1'"
            //+ ",OfficeAutomation_Document_DealOffice_MoneyRemark='1' "
            //+ "where OfficeAutomation_Document_DealOffice_ID='" + _objMessage.OfficeAutomation_Document_DealOffice_ID + "' ";
            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_DealOffice]"
                                                        + "   SET   [OfficeAutomation_Document_DealOffice_Department]=@sOfficeAutomation_Document_DealOffice_Department"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_ReplyPhone]=@sOfficeAutomation_Document_DealOffice_ReplyPhone"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_ReplyFax]=@sOfficeAutomation_Document_DealOffice_ReplyFax"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_WorkArea]=@sOfficeAutomation_Document_DealOffice_WorkArea"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_Branch]=@sOfficeAutomation_Document_DealOffice_Branch"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_TypeID]=@iOfficeAutomation_Document_DealOffice_TypeID"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_OfficeArea]=@sOfficeAutomation_Document_DealOffice_OfficeArea"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_OfficeAddress]=@sOfficeAutomation_Document_DealOffice_OfficeAddress"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealArea]=@fOfficeAutomation_Document_DealOffice_DealArea"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealPrice]=@fOfficeAutomation_Document_DealOffice_DealPrice"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealOwnerMoney]=@fOfficeAutomation_Document_DealOffice_DealOwnerMoney"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealOwnerPercent]=@fOfficeAutomation_Document_DealOffice_DealOwnerPercent"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealClientMoney]=@fOfficeAutomation_Document_DealOffice_DealMoney"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealClientPercent]=@fOfficeAutomation_Document_DealOffice_DealPercent"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealMoney]=@fOfficeAutomation_Document_DealOffice_DealMoney"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_DealPercent]=@fOfficeAutomation_Document_DealOffice_DealPercent"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseArea]=@fOfficeAutomation_Document_DealOffice_LeaseArea"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeasePrice]=@fOfficeAutomation_Document_DealOffice_LeasePrice"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseOwnerMoney]=@fOfficeAutomation_Document_DealOffice_LeaseOwnerMoney"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseOwnerPercent]=@fOfficeAutomation_Document_DealOffice_LeaseOwnerPercent"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseClientMoney]=@fOfficeAutomation_Document_DealOffice_LeaseClientMoney"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseClientPercent]=@fOfficeAutomation_Document_DealOffice_LeaseClientPercent"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeaseMoney]=@fOfficeAutomation_Document_DealOffice_LeaseMoney"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_LeasePercent]=@fOfficeAutomation_Document_DealOffice_LeasePercent"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_CrossAreaRemark]=@sOfficeAutomation_Document_DealOffice_CrossAreaRemark"
                                                        + "           ,[OfficeAutomation_Document_DealOffice_MoneyRemark]=@sOfficeAutomation_Document_DealOffice_MoneyRemark"
                                + " WHERE [OfficeAutomation_Document_DealOffice_ID]=@guidOfficeAutomation_Document_DealOffice_ID"
                                + "     AND [OfficeAutomation_Document_DealOffice_MainID] = @guidOfficeAutomation_Document_DealOffice_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_DealOffice)obj;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_ReplyFax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_ReplyFax));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_WorkArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_WorkArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_DealOffice_TypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_TypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_OfficeArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_OfficeArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_OfficeAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_OfficeAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealArea", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealPrice", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealOwnerMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealOwnerMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealOwnerPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealOwnerPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealClientMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealClientMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealClientPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealClientPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_DealPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_DealPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseArea", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeasePrice", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeasePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseOwnerMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseOwnerMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseOwnerPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseOwnerPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseClientMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseClientMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseClientPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseClientPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeaseMoney", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeaseMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@fOfficeAutomation_Document_DealOffice_LeasePercent", SqlDbType.Decimal, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_LeasePercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_CrossAreaRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_CrossAreaRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_DealOffice_MoneyRemark", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_MoneyRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_DealOffice_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_DealOffice_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_DealOffice_MainID));

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

    public class DA_Dic_OfficeAutomation_DealOfficeType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_DealOfficeType_ID]"
                            + "         ,[OfficeAutomation_DealOfficeType_Name]"
                            + "         ,[OfficeAutomation_DealOfficeType_DocumentID]"
                            + "         ,[OfficeAutomation_DealOfficeType_IsEnable]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DealOfficeType]";

            return RunSQL(sql);
        }

        public DataSet SelectByDocumentID(int documentID)
        {
            string sql = "SELECT [OfficeAutomation_DealOfficeType_ID]"
                            + "         ,[OfficeAutomation_DealOfficeType_Name]"
                            + "         ,[OfficeAutomation_DealOfficeType_DocumentID]"
                            + "         ,[OfficeAutomation_DealOfficeType_IsEnable]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DealOfficeType]"
                            + "  where OfficeAutomation_DealOfficeType_DocumentID = " + documentID
                            + "            and OfficeAutomation_DealOfficeType_IsEnable = 1";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id字符串获得相关类型名称：id格式为"1|2|3"
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>格式如'商铺,写字楼'</returns>
        public string SelectNamesByIDs(string ids)
        {
            string[] id = ids.Split('|');
            ids="";
            if (id[0] != "")
            {
                foreach (string s in id)
                {
                    ids += "'" + s + "',";
                }

                ids = ids.Substring(0, ids.Length - 1);

                string sql = "SELECT DISTINCT Stuff((SELECT ','"                   
                    + "                                                        + [OfficeAutomation_DealOfficeType_Name]"                
                    + "                                              FROM   [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DealOfficeType]"
                    + "                                              WHERE  OfficeAutomation_DealOfficeType_ID IN (" + ids + " )"
                    + "                                              FOR XML PATH('')), 1, 1, '')AS [OfficeAutomation_DealOfficeType_Name]"
                    + "           FROM   [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DealOfficeType] ";

                return RunSQL(sql).Tables[0].Rows[0][0].ToString();
            }

            return "";
        }
    }
}
