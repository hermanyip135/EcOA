using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtNewProj_New_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_UtNewProj_New_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_OfficeAutomation_Document_UtNewProj_New_Detail_InsertOrUpdate";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtNewProj_New_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_TypeID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_TypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DiskSourceID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DiskSourceID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_TotalSize", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_TotalSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_TotalUnitCount", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_TotalUnitCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_UnitPrice", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_UnitPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_SizeSegments", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_SizeSegments));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_PreCompleteCount", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_PreCompleteCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_PreComm", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_PreComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_AgentFeeAndCashPrizeSituation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_AgentFeeAndCashPrizeSituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_CommFeeTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_CommFeeTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_ContractingCompanyName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_ContractingCompanyName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_OwnerCommJump", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_OwnerCommJump));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_AgentConditions", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_AgentConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_CommConditions", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_CommConditions));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeForCashPrize", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeForCashPrize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealDateStartAndEnd", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealDateStartAndEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealSetMinAndMax", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealSetMinAndMax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealSizeMinAndMax", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealSizeMinAndMax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealPrizeMinAndMax", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealPrizeMinAndMax));



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

            cmdToExecute.CommandText = "pr_t_OfficeAutomation_Document_UtNewProj_New_Detail_InsertOrUpdate";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtNewProj_New_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_TypeID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_TypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DiskSourceID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DiskSourceID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_TotalSize", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_TotalSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_TotalUnitCount", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_TotalUnitCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_UnitPrice", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_UnitPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_SizeSegments", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_SizeSegments));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_PreCompleteCount", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_PreCompleteCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_PreComm", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_PreComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_AgentFeeAndCashPrizeSituation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_AgentFeeAndCashPrizeSituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_CommFeeTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_CommFeeTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_ContractingCompanyName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_ContractingCompanyName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_OwnerCommJump", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_OwnerCommJump));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_AgentConditions", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_AgentConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_CommConditions", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_CommConditions));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeForCashPrize", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeForCashPrize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealDateStartAndEnd", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealDateStartAndEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealSetMinAndMax", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealSetMinAndMax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealSizeMinAndMax", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealSizeMinAndMax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_DealPrizeMinAndMax", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Detail_DealPrizeMinAndMax));

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

            cmdToExecute.CommandText = @"
                DELETE FROM t_OfficeAutomation_Document_UtNewProj_New_Detail 
                WHERE OfficeAutomation_Document_UtNewProj_New_Detail_MainID = @OfficeAutomation_Document_UtNewProj_New_Detail_MainID
            ";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

        #region [查询所有数据]
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public IList<T_OfficeAutomation_Document_UtNewProj_New_Detail> GetAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = @" SELECT * FROM t_OfficeAutomation_Document_UtNewProj_New_Detail ";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            IList<T_OfficeAutomation_Document_UtNewProj_New_Detail> rList = new List<T_OfficeAutomation_Document_UtNewProj_New_Detail>();
            T_OfficeAutomation_Document_UtNewProj_New_Detail obj = null;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            try
            {


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

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        obj = new T_OfficeAutomation_Document_UtNewProj_New_Detail();

                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_ID = new Guid(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_ID"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_MainID = new Guid(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_MainID"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_TypeID = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_TypeID"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeID = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeID"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_DiskSourceID = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_DiskSourceID"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_TotalSize = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_TotalSize"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_TotalUnitCount = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_TotalUnitCount"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_UnitPrice = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_UnitPrice"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_SizeSegments = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_SizeSegments"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_PreCompleteCount = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_PreCompleteCount"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_PreComm = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_PreComm"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyName = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyName"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyTypeID = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyTypeID"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_AgentFeeAndCashPrizeSituation = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_AgentFeeAndCashPrizeSituation"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_CommFeeTypeID = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_CommFeeTypeID"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_ContractingCompanyName = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_ContractingCompanyName"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_OwnerCommJump = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_OwnerCommJump"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_AgentConditions = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_AgentConditions"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Detail_CommConditions = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Detail_CommConditions"].ToString();

                        rList.Add(obj);
                    }


                }

                return rList;
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
