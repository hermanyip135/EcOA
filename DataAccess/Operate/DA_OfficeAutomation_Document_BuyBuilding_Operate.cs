using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BuyBuilding_Operate:SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_BuyBuilding _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBuilding]"
                                                        + "           ([OfficeAutomation_Document_BuyBuilding_ID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_MainID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_Apply]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_ApplyForName]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_ApplyForCode]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_IDNumber]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_Department]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_Position]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_EntryDate]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_PositiveDate]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_Phone]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_ContactAddress]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_DealTypeID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerTypeID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerRelation]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_BuildingAddress]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_Area]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_PriceRange]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_LeaseDeadline]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_PayTypeID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_SpecialRequest]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FollowTypeID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FreeTypeIDs]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FollowBranch]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FollowSales]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_MortgageAddressRemark]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_DealBuild]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_PersInterestsURL]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerIsEmployee]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_DepartmentType]"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FollowNo]"
                                                        + ")"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_BuyBuilding_ID"
                                                        + "           ,@guidOfficeAutomation_Document_BuyBuilding_MainID"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_BuyBuilding_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_ApplyForName"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_ApplyForCode"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_IDNumber"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_Department"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_Position"
                                                        + "           ,@dtOfficeAutomation_Document_BuyBuilding_EntryDate"
                                                        + "           ,@dtOfficeAutomation_Document_BuyBuilding_PositiveDate"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_Phone"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_ContactAddress"
                                                        + "           ,@iOfficeAutomation_Document_BuyBuilding_DealTypeID"
                                                        + "           ,@iOfficeAutomation_Document_BuyBuilding_OwnerTypeID"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_OwnerRelation"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_BuildingAddress"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_Area"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_PriceRange"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_LeaseDeadline"
                                                        + "           ,@iOfficeAutomation_Document_BuyBuilding_PayTypeID"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_SpecialRequest"
                                                        + "           ,@iOfficeAutomation_Document_BuyBuilding_FollowTypeID"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_FreeTypeIDs"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_FollowBranch"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_FollowSales"
                                                        + "           ,@iOfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_MortgageAddressRemark"
                                                        + "           ,@OfficeAutomation_Document_BuyBuilding_DealBuild"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_PersInterestsURL"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_OwnerIsEmployee"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation"
                                                        + "           ,@sOfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode"
                                                        + "           ,@OfficeAutomation_Document_BuyBuilding_DepartmentType"
                                                        + "           ,@OfficeAutomation_Document_BuyBuilding_FollowNo"
                                                        + ")";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BuyBuilding)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BuyBuilding_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BuyBuilding_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_BuyBuilding_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_ApplyForName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ApplyForName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_ApplyForCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ApplyForCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_IDNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_IDNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_BuyBuilding_EntryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_EntryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_BuyBuilding_PositiveDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_PositiveDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_ContactAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ContactAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_DealTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_DealTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_OwnerTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_OwnerRelation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerRelation));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_BuildingAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_BuildingAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_PriceRange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_PriceRange));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_LeaseDeadline", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_LeaseDeadline));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_PayTypeID", SqlDbType.Int, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_PayTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_SpecialRequest", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_SpecialRequest));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_FollowTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FollowTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_FreeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FreeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_FollowBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FollowBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_FollowSales", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FollowSales));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_MortgageAddressRemark", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_MortgageAddressRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_DealBuild", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_DealBuild));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_PersInterestsURL", SqlDbType.NVarChar, 160, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_PersInterestsURL));

                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_OwnerIsEmployee", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerIsEmployee));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_DepartmentType", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_DepartmentType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_FollowNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FollowNo));
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
            cmdToExecute.CommandText = "dbo.[pr_BuyBuilding_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBuilding]"
                                                        + "   SET  [OfficeAutomation_Document_BuyBuilding_ApplyForName]=@sOfficeAutomation_Document_BuyBuilding_ApplyForName"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_ApplyForCode]=@sOfficeAutomation_Document_BuyBuilding_ApplyForCode"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_IDNumber]=@sOfficeAutomation_Document_BuyBuilding_IDNumber"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_Department]=@sOfficeAutomation_Document_BuyBuilding_Department"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_Position]=@sOfficeAutomation_Document_BuyBuilding_Position"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_EntryDate]=@dtOfficeAutomation_Document_BuyBuilding_EntryDate"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_PositiveDate]=@dtOfficeAutomation_Document_BuyBuilding_PositiveDate"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_Phone]=@sOfficeAutomation_Document_BuyBuilding_Phone"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_ContactAddress]=@sOfficeAutomation_Document_BuyBuilding_ContactAddress"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_DealTypeID]=@iOfficeAutomation_Document_BuyBuilding_DealTypeID"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerTypeID]=@iOfficeAutomation_Document_BuyBuilding_OwnerTypeID"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerRelation]=@sOfficeAutomation_Document_BuyBuilding_OwnerRelation"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_BuildingAddress]=@sOfficeAutomation_Document_BuyBuilding_BuildingAddress"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_Area]=@sOfficeAutomation_Document_BuyBuilding_Area"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_PriceRange]=@sOfficeAutomation_Document_BuyBuilding_PriceRange"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_LeaseDeadline]=@sOfficeAutomation_Document_BuyBuilding_LeaseDeadline"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_PayTypeID]=@iOfficeAutomation_Document_BuyBuilding_PayTypeID"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_SpecialRequest]=@sOfficeAutomation_Document_BuyBuilding_SpecialRequest"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FollowTypeID]=@iOfficeAutomation_Document_BuyBuilding_FollowTypeID"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FreeTypeIDs]=@sOfficeAutomation_Document_BuyBuilding_FreeTypeIDs"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FollowBranch]=@sOfficeAutomation_Document_BuyBuilding_FollowBranch"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FollowSales]=@sOfficeAutomation_Document_BuyBuilding_FollowSales"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID]=@iOfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_MortgageAddressRemark]=@sOfficeAutomation_Document_BuyBuilding_MortgageAddressRemark"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_DealBuild]=@OfficeAutomation_Document_BuyBuilding_DealBuild"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_PersInterestsURL]=@sOfficeAutomation_Document_BuyBuilding_PersInterestsURL"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerIsEmployee]=@sOfficeAutomation_Document_BuyBuilding_OwnerIsEmployee"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation]=@sOfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode]=@sOfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_DepartmentType]=@sOfficeAutomation_Document_BuyBuilding_DepartmentType"
                                                        + "           ,[OfficeAutomation_Document_BuyBuilding_FollowNo]=@sOfficeAutomation_Document_BuyBuilding_FollowNo"
                                + " WHERE [OfficeAutomation_Document_BuyBuilding_ID]=@guidOfficeAutomation_Document_BuyBuilding_ID"
                                + "     AND [OfficeAutomation_Document_BuyBuilding_MainID] = @guidOfficeAutomation_Document_BuyBuilding_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BuyBuilding)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_ApplyForName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ApplyForName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_ApplyForCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ApplyForCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_IDNumber", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_IDNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_BuyBuilding_EntryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_EntryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_BuyBuilding_PositiveDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_PositiveDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_ContactAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ContactAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_DealTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_DealTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_OwnerTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_OwnerRelation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerRelation));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_BuildingAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_BuildingAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_PriceRange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_PriceRange));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_LeaseDeadline", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_LeaseDeadline));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_PayTypeID", SqlDbType.Int, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_PayTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_SpecialRequest", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_SpecialRequest));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_FollowTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FollowTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_FreeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FreeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_FollowBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FollowBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_FollowSales", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FollowSales));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_MortgageAddressRemark", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_MortgageAddressRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_DealBuild", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_DealBuild));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_PersInterestsURL", SqlDbType.NVarChar, 160, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_PersInterestsURL));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BuyBuilding_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BuyBuilding_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_OwnerIsEmployee", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerIsEmployee));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_DepartmentType", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_DepartmentType));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BuyBuilding_FollowNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_FollowNo));
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
    /// 业权人类型字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_OwnerType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_OwnerType_ID]"
                            + "         ,[OfficeAutomation_OwnerType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_OwnerType]";

            return RunSQL(sql);
        }
    }

    /// <summary>
    /// 付款方式字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_PayType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_PayType_ID]"
                            + "         ,[OfficeAutomation_PayType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_PayType]";

            return RunSQL(sql);
        }
    }

    /// <summary>
    /// 购租楼宇跟进方式字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_FolloweType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_FolloweType_ID]"
                            + "         ,[OfficeAutomation_FolloweType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_FolloweType]";

            return RunSQL(sql);
        }
    }

    /// <summary>
    /// 免佣免按揭申请项目字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_FreeType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_FreeType_ID]"
                            + "         ,[OfficeAutomation_FreeType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_FreeType]";

            return RunSQL(sql);
        }
    }

    /// <summary>
    /// 按揭办理地点字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_MortgageAddressType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_MortgageAddressType_ID]"
                            + "         ,[OfficeAutomation_MortgageAddressType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_MortgageAddressType]";

            return RunSQL(sql);
        }
    }

    #endregion
}
