using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_NewPersInterests_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_NewPersInterests _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NewPersInterests]"
                                                        + "           ([OfficeAutomation_Document_NewPersInterests_ID]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_MainID]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Apply]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Department]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_DepartmentTypeID]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyForID]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Phone]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_InterestsTypeID]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyContent]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_DealKind]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_DealProperty]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_FollowerNo]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_PropertyHander]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_MeAndHim]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Relationship]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_RelationName]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Building]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Square]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_PriceScope]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_LeaseTerm]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_PayWay]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Requirements]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_FollowWay]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_ApplySomething]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_GiftName]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_GiftPrice]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_CrashOrCard]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherName]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherPrice]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_GiverOrCompany]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Entrust]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_BuildingKind]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherBuilding]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_EntrustNo]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherActivity]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Investment]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Ipossition]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherSummary]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_IsInApply]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Relationship1]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_IsCompanyStaff]"
                                                        +"            ,[OfficeAutomation_Document_NewPersInterests_AddressNum]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_txtTfid1]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_possition]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_EntryDate]"
                                                         + "           ,[OfficeAutomation_Document_NewPersInterests_ProbationDate]"
                                                        + "            )"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_NewPersInterests_ID"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_MainID"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Apply"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Department"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_DepartmentTypeID"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_ApplyForID"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Phone"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_InterestsTypeID"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_ApplyContent"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_DealKind"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_DealProperty"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_FollowerNo"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_PropertyHander"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_MeAndHim"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Relationship"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_RelationName"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Building"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Square"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_PriceScope"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_LeaseTerm"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_PayWay"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Requirements"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_FollowWay"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_ApplySomething"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_GiftName"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_GiftPrice"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_CrashOrCard"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_AnotherName"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_AnotherPrice"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_GiverOrCompany"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Entrust"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_BuildingKind"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_AnotherBuilding"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_EntrustNo"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_AnotherActivity"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Investment"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Ipossition"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_AnotherSummary"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_IsInApply"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Relationship1"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_IsCompanyStaff"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_AddressNum"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_txtTfid1"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_possition"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_EntryDate"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_ProbationDate"
                                                        + "            )";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_NewPersInterests)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_DepartmentTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_DepartmentTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ApplyForID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ApplyForID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_InterestsTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_InterestsTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ApplyContent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ApplyContent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_DealKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_DealKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_DealProperty", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_DealProperty));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_FollowerNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_FollowerNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_PropertyHander", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_PropertyHander));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_MeAndHim", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_MeAndHim));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Relationship", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_RelationName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_RelationName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Square", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Square));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_PriceScope", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_PriceScope));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_LeaseTerm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_LeaseTerm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_PayWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Requirements", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Requirements));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_FollowWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_FollowWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ApplySomething", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ApplySomething));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_GiftName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_GiftName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_GiftPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_GiftPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_CrashOrCard", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_CrashOrCard));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_GiverOrCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_GiverOrCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Entrust", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Entrust));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_BuildingKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_BuildingKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherBuilding", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherBuilding));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_EntrustNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_EntrustNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherActivity", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherActivity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Investment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Investment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Ipossition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Ipossition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherSummary", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherSummary));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_IsInApply", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_IsInApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Relationship1", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Relationship1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_IsCompanyStaff", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_IsCompanyStaff));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AddressNum", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AddressNum));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_txtTfid1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_txtTfid1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_possition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_possition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_EntryDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_EntryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ProbationDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ProbationDate));
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
            cmdToExecute.CommandText = "dbo.[pr_NewPersInterests_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NewPersInterests]"
                                + "         SET [OfficeAutomation_Document_NewPersInterests_ApplyID] = @OfficeAutomation_Document_NewPersInterests_ApplyID"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Department] = @OfficeAutomation_Document_NewPersInterests_Department"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_DepartmentTypeID] = @OfficeAutomation_Document_NewPersInterests_DepartmentTypeID"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_ApplyForID] = @OfficeAutomation_Document_NewPersInterests_ApplyForID"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Phone] = @OfficeAutomation_Document_NewPersInterests_Phone"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_InterestsTypeID] = @OfficeAutomation_Document_NewPersInterests_InterestsTypeID"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_ApplyContent] = @OfficeAutomation_Document_NewPersInterests_ApplyContent"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_DealKind] = @OfficeAutomation_Document_NewPersInterests_DealKind"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_DealProperty] = @OfficeAutomation_Document_NewPersInterests_DealProperty"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_FollowerNo] = @OfficeAutomation_Document_NewPersInterests_FollowerNo"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_PropertyHander] = @OfficeAutomation_Document_NewPersInterests_PropertyHander"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_MeAndHim] = @OfficeAutomation_Document_NewPersInterests_MeAndHim"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Relationship] = @OfficeAutomation_Document_NewPersInterests_Relationship"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_RelationName] = @OfficeAutomation_Document_NewPersInterests_RelationName"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Building] = @OfficeAutomation_Document_NewPersInterests_Building"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Square] = @OfficeAutomation_Document_NewPersInterests_Square"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_PriceScope] = @OfficeAutomation_Document_NewPersInterests_PriceScope"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_LeaseTerm] = @OfficeAutomation_Document_NewPersInterests_LeaseTerm"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_PayWay] = @OfficeAutomation_Document_NewPersInterests_PayWay"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Requirements] = @OfficeAutomation_Document_NewPersInterests_Requirements"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_FollowWay] = @OfficeAutomation_Document_NewPersInterests_FollowWay"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_ApplySomething] = @OfficeAutomation_Document_NewPersInterests_ApplySomething"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_GiftName] = @OfficeAutomation_Document_NewPersInterests_GiftName"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_GiftPrice] = @OfficeAutomation_Document_NewPersInterests_GiftPrice"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_CrashOrCard] = @OfficeAutomation_Document_NewPersInterests_CrashOrCard"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_AnotherName] = @OfficeAutomation_Document_NewPersInterests_AnotherName"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_AnotherPrice] = @OfficeAutomation_Document_NewPersInterests_AnotherPrice"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_GiverOrCompany] = @OfficeAutomation_Document_NewPersInterests_GiverOrCompany"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Entrust] = @OfficeAutomation_Document_NewPersInterests_Entrust"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_BuildingKind] = @OfficeAutomation_Document_NewPersInterests_BuildingKind"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_AnotherBuilding] = @OfficeAutomation_Document_NewPersInterests_AnotherBuilding"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_EntrustNo] = @OfficeAutomation_Document_NewPersInterests_EntrustNo"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_AnotherActivity] = @OfficeAutomation_Document_NewPersInterests_AnotherActivity"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Investment] = @OfficeAutomation_Document_NewPersInterests_Investment"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Ipossition] = @OfficeAutomation_Document_NewPersInterests_Ipossition"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_AnotherSummary] = @OfficeAutomation_Document_NewPersInterests_AnotherSummary"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_IsInApply] = @OfficeAutomation_Document_NewPersInterests_IsInApply"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Relationship1] = @OfficeAutomation_Document_NewPersInterests_Relationship1"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_IsCompanyStaff] = @OfficeAutomation_Document_NewPersInterests_IsCompanyStaff"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_AddressNum] = @OfficeAutomation_Document_NewPersInterests_AddressNum"

                                + "         ,[OfficeAutomation_Document_NewPersInterests_txtTfid1] = @OfficeAutomation_Document_NewPersInterests_txtTfid1"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_possition] = @OfficeAutomation_Document_NewPersInterests_possition"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_EntryDate] = @OfficeAutomation_Document_NewPersInterests_EntryDate"
                                 + "         ,[OfficeAutomation_Document_NewPersInterests_ProbationDate] = @OfficeAutomation_Document_NewPersInterests_ProbationDate"

                                + "          ,OfficeAutomation_Document_NewPersInterests_Apply = @OfficeAutomation_Document_NewPersInterests_Apply"
                                + "         WHERE [OfficeAutomation_Document_NewPersInterests_ID]=@OfficeAutomation_Document_NewPersInterests_ID"
                                + "         AND [OfficeAutomation_Document_NewPersInterests_MainID]=@OfficeAutomation_Document_NewPersInterests_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_NewPersInterests)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_DepartmentTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_DepartmentTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ApplyForID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ApplyForID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_InterestsTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_InterestsTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ApplyContent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ApplyContent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_DealKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_DealKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_DealProperty", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_DealProperty));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_FollowerNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_FollowerNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_PropertyHander", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_PropertyHander));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_MeAndHim", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_MeAndHim));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Relationship", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_RelationName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_RelationName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Square", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Square));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_PriceScope", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_PriceScope));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_LeaseTerm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_LeaseTerm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_PayWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Requirements", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Requirements));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_FollowWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_FollowWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ApplySomething", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ApplySomething));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_GiftName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_GiftName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_GiftPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_GiftPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_CrashOrCard", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_CrashOrCard));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_GiverOrCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_GiverOrCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Entrust", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Entrust));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_BuildingKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_BuildingKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherBuilding", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherBuilding));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_EntrustNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_EntrustNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherActivity", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherActivity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Investment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Investment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Ipossition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Ipossition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AnotherSummary", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AnotherSummary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_IsInApply", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_IsInApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Relationship1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Relationship1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_IsCompanyStaff", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_IsCompanyStaff));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_AddressNum", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_AddressNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Apply));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_txtTfid1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_txtTfid1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_possition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_possition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_EntryDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_EntryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ProbationDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ProbationDate));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_MainID));

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
