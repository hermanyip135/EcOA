using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtNewProj_New_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_UtNewProj_New _objMessage = null;
        private DAL.DalBase<T_OfficeAutomation_Document_UtNewProj_New> dal;
        public DA_OfficeAutomation_Document_UtNewProj_New_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_UtNewProj_New>();
        }
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_OfficeAutomation_Document_UtNewProj_New_InsertOrUpdate";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtNewProj_New)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_MainID));


                #region string字段
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ApplyEmpCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ApplyEmpCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ApplyEmpName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ApplyEmpName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ApplyDeptID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ApplyDeptID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Project", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Project));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ProjectLocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ProjectLocation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ProjectAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ProjectAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Developer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Developer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DeveloperContacter", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DeveloperContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPosition", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CoordinatorCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CoordinatorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CoordinatorName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CoordinatorName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CoordinatorPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CoordinatorPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CoordinatorDept", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CoordinatorDept));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_BaseAgent", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_BaseAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_BaseAgentOther", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_BaseAgentOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_PrePayMoney", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_PrePayMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DiscountMoney", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DiscountMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_RenovationFee", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_RenovationFee));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_OtherFeeType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_OtherFeeType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_OtherFee", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_OtherFee));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CorporateName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CorporateName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CorporateType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CorporateType));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CashPrize", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CashPrize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CalCashPrizeWay", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CalCashPrizeWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CalCashPrizeConditions", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CalCashPrizeConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CalCashPrizeColumns", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CalCashPrizeColumns));


                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_PayCashPrizeConditions", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_PayCashPrizeConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CashPrizePayType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CashPrizePayType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_PanFangRate", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_PanFangRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_NewHouseRate", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_NewHouseRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_LimitArea", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_LimitArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Lack", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Lack)); 
                #endregion

                #region int字段
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ProjectID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ProjectID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DealType", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DealType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DealOfficeType", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DealOfficeType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AgentCompanyInfo", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AgentCompanyInfo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CommFeeTypeInfo", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CommFeeTypeInfo)); 
                #endregion

                #region datetime字段
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ApplyDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AgentStartDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AgentStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AgentEndDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AgentEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ClientGuardStartDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ClientGuardStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ClientGuardEndDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ClientGuardEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ReturnBackDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ReturnBackDate)); 
                #endregion

                #region bool字段
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsPreSale", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsPreSale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsOneOrTwo", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsOneOrTwo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsSwipeCard", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsSwipeCard));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsRenovation", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsRenovation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsOther", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsHaveCashPrize", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsHaveCashPrize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsMyPay", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsMyPay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsAreaConfirm", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsAreaConfirm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsChoiceZY", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsChoiceZY));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsChoiceFYQ", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsChoiceFYQ));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsDeveloperAndZYHaveContract", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsDeveloperAndZYHaveContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsNoCashback", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsNoCashback));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsProbity", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsProbity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsZoneRestrictions", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsZoneRestrictions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsNew", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsNew));
                #endregion


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

            cmdToExecute.CommandText = "pr_OfficeAutomation_Document_UtNewProj_New_InsertOrUpdate";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtNewProj_New)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_MainID));


                #region string字段
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ApplyEmpCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ApplyEmpCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ApplyEmpName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ApplyEmpName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ApplyDeptID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ApplyDeptID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Project", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Project));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ProjectLocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ProjectLocation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ProjectAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ProjectAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Developer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Developer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DeveloperContacter", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DeveloperContacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPosition", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CoordinatorCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CoordinatorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CoordinatorName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CoordinatorName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CoordinatorPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CoordinatorPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CoordinatorDept", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CoordinatorDept));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_BaseAgent", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_BaseAgent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_BaseAgentOther", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_BaseAgentOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_PrePayMoney", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_PrePayMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DiscountMoney", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DiscountMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_RenovationFee", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_RenovationFee));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_OtherFeeType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_OtherFeeType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_OtherFee", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_OtherFee));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CorporateName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CorporateName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CorporateType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CorporateType));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CashPrize", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CashPrize));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CalCashPrizeWay", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CalCashPrizeWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CalCashPrizeConditions", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CalCashPrizeConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CalCashPrizeColumns", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CalCashPrizeColumns));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_PayCashPrizeConditions", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_PayCashPrizeConditions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CashPrizePayType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CashPrizePayType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_PanFangRate", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_PanFangRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_NewHouseRate", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_NewHouseRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_LimitArea", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_LimitArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_Lack", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_Lack));
                #endregion

                #region int字段
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ProjectID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ProjectID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DealType", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DealType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_DealOfficeType", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_DealOfficeType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AgentCompanyInfo", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AgentCompanyInfo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_CommFeeTypeInfo", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_CommFeeTypeInfo));
                #endregion

                #region datetime字段
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ApplyDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AgentStartDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AgentStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_AgentEndDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_AgentEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ClientGuardStartDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ClientGuardStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ClientGuardEndDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ClientGuardEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_ReturnBackDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_ReturnBackDate));
                #endregion

                #region bool字段
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsPreSale", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsPreSale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsOneOrTwo", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsOneOrTwo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsSwipeCard", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsSwipeCard));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsRenovation", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsRenovation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsOther", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsHaveCashPrize", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsHaveCashPrize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsMyPay", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsMyPay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsAreaConfirm", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsAreaConfirm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsChoiceZY", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsChoiceZY));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsChoiceFYQ", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsChoiceFYQ));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsDeveloperAndZYHaveContract", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsDeveloperAndZYHaveContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsNoCashback", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsNoCashback));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsProbity", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsProbity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsZoneRestrictions", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_New_IsZoneRestrictions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_IsNew", SqlDbType.Bit, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "false"));
                #endregion


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
                UPDATE toadunpn
                SET [OfficeAutomation_Document_UtNewProj_New_IsDelete] = 1
                FROM t_OfficeAutomation_Document_UtNewProj_New AS toadunpn
                WHERE toadunpn.OfficeAutomation_Document_UtNewProj_New_MainID = @OfficeAutomation_Document_UtNewProj_New_MainID
            ";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_New_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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
        public IList<T_OfficeAutomation_Document_UtNewProj_New> GetAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = @" SELECT * FROM t_OfficeAutomation_Document_UtNewProj_New ";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            IList<T_OfficeAutomation_Document_UtNewProj_New> rList = new List<T_OfficeAutomation_Document_UtNewProj_New>();
            T_OfficeAutomation_Document_UtNewProj_New obj = null;
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
                        obj = new T_OfficeAutomation_Document_UtNewProj_New();

                        obj.OfficeAutomation_Document_UtNewProj_New_ID = new Guid(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ID"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_MainID = new Guid(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_MainID"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_ApplyEmpCode = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ApplyEmpCode"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_ApplyEmpName = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ApplyEmpName"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_ApplyDate = Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ApplyDate"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_ApplyDeptID = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ApplyDeptID"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Project = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Project"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_ProjectAddress = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ProjectAddress"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_ProjectLocation = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ProjectLocation"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Developer = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Developer"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_DeveloperContacter = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_DeveloperContacter"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPosition = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPosition"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPhone = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPhone"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_CoordinatorCode = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CoordinatorCode"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_CoordinatorName = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CoordinatorName"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_CoordinatorPhone = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CoordinatorPhone"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_CoordinatorDept = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CoordinatorDept"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerCode = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerCode"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerName = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerName"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerPhone = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerPhone"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_IsPreSale = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsPreSale"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_IsOneOrTwo = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsOneOrTwo"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_DealType = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_DealType"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_DealOfficeType = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_DealOfficeType"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_BaseAgent = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_BaseAgent"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_BaseAgentOther = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_BaseAgentOther"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_AgentCompanyInfo = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_AgentCompanyInfo"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_IsSwipeCard = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsSwipeCard"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_PrePayMoney = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_PrePayMoney"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_DiscountMoney = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_DiscountMoney"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_IsRenovation = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsRenovation"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_RenovationFee = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_RenovationFee"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_IsOther = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsOther"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_OtherFeeType = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_OtherFeeType"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_OtherFee = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_OtherFee"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_AgentStartDate = Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_AgentStartDate"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_AgentEndDate = Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_AgentEndDate"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_ClientGuardStartDate = Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ClientGuardStartDate"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_ClientGuardEndDate = Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ClientGuardEndDate"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_CommFeeTypeInfo = Convert.ToInt32(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CommFeeTypeInfo"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_IsHaveCashPrize = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsHaveCashPrize"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_CorporateName = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CorporateName"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_CorporateType = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CorporateType"].ToString();
                        //obj.OfficeAutomation_Document_UtNewProj_New_CashPrize = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CashPrize"].ToString();

                        obj.OfficeAutomation_Document_UtNewProj_New_CalCashPrizeWay = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CalCashPrizeWay"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_CalCashPrizeConditions = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CalCashPrizeConditions"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_CalCashPrizeColumns = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CalCashPrizeColumns"].ToString();


                        obj.OfficeAutomation_Document_UtNewProj_New_PayCashPrizeConditions = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_PayCashPrizeConditions"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_CashPrizePayType = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_CashPrizePayType"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_IsMyPay = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsMyPay"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_IsAreaConfirm = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsAreaConfirm"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_ReturnBackDate = Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_ReturnBackDate"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_IsChoiceZY = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsChoiceZY"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_IsChoiceFYQ = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsChoiceFYQ"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_PanFangRate = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_PanFangRate"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_NewHouseRate = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_NewHouseRate"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_IsDeveloperAndZYHaveContract = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsDeveloperAndZYHaveContract"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_IsNoCashback = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsNoCashback"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_IsProbity = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsProbity"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_IsZoneRestrictions = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsZoneRestrictions"].ToString());
                        obj.OfficeAutomation_Document_UtNewProj_New_LimitArea = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_LimitArea"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_Lack = dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_Lack"].ToString();
                        obj.OfficeAutomation_Document_UtNewProj_New_IsNew = Convert.ToBoolean(dt.Rows[i]["OfficeAutomation_Document_UtNewProj_New_IsNew"].ToString());

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

        #region 自定义
        public T_OfficeAutomation_Document_UtNewProj_New Add(T_OfficeAutomation_Document_UtNewProj_New t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_UtNewProj_New Edit(T_OfficeAutomation_Document_UtNewProj_New t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_UtNewProj_New t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_UtNewProj_New GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_UtNewProj_New>(where);
        }
        #endregion
    }
}
