using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BuyBuilding_Inherit : DA_OfficeAutomation_Document_BuyBuilding_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BuyBuilding_ID]"
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
                           + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode]"
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
                           + "           ,[OfficeAutomation_Document_BuyBuilding_AuditNOs]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_Remark]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerIsEmployee]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_DepartmentType]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_FollowNo]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_TransNo]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_TransAddress]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_TransDate]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_HouseRegistrant]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_IsRebate]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_RebateDate]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_Instruction]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + "           ,tdoadt.OfficeAutomation_DealType_Name"
                           + "           ,tdoaot.OfficeAutomation_OwnerType_Name"
                           + "           ,tdoapt.OfficeAutomation_PayType_Name"
                           + "           ,tdoaft.OfficeAutomation_FollowType_Name"
                           + "           ,tdoamat.OfficeAutomation_MortgageAddressType_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBuilding] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BuyBuilding_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_DealType tdoadt ON tdoadt.OfficeAutomation_DealType_ID = todi.OfficeAutomation_Document_BuyBuilding_DealTypeID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_OwnerType tdoaot ON tdoaot.OfficeAutomation_OwnerType_ID = todi.OfficeAutomation_Document_BuyBuilding_OwnerTypeID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_PayType tdoapt ON tdoapt.OfficeAutomation_PayType_ID = todi.OfficeAutomation_Document_BuyBuilding_PayTypeID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_FollowType tdoaft ON tdoaft.OfficeAutomation_FollowType_ID = todi.OfficeAutomation_Document_BuyBuilding_FollowTypeID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_MortgageAddressType tdoamat ON tdoamat.OfficeAutomation_MortgageAddressType_ID = todi.OfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID"
                           + " WHERE OfficeAutomation_Document_BuyBuilding_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BuyBuilding_ID]"
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
                           + "           ,[OfficeAutomation_Document_BuyBuilding_AuditNOs]"
                           + "           ,[OfficeAutomation_Document_BuyBuilding_Remark]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + "           ,tdoadt.OfficeAutomation_DealType_Name"
                           + "           ,tdoaot.OfficeAutomation_OwnerType_Name"
                           + "           ,tdoapt.OfficeAutomation_PayType_Name"
                           + "           ,tdoaft.OfficeAutomation_FollowType_Name"
                           + "           ,tdoamat.OfficeAutomation_MortgageAddressType_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBuilding] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BuyBuilding_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_DealType tdoadt ON tdoadt.OfficeAutomation_DealType_ID = todi.OfficeAutomation_Document_BuyBuilding_DealTypeID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_OwnerType tdoaot ON tdoaot.OfficeAutomation_OwnerType_ID = todi.OfficeAutomation_Document_BuyBuilding_OwnerTypeID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_PayType tdoapt ON tdoapt.OfficeAutomation_PayType_ID = todi.OfficeAutomation_Document_BuyBuilding_PayTypeID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_FollowType tdoaft ON tdoaft.OfficeAutomation_FollowType_ID = todi.OfficeAutomation_Document_BuyBuilding_FollowTypeID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_MortgageAddressType tdoamat ON tdoamat.OfficeAutomation_MortgageAddressType_ID = todi.OfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID"
                           + " WHERE OfficeAutomation_Document_BuyBuilding_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应报废申请表备注,不进行重复标注。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool AddRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBuilding]"
                                + "   SET [OfficeAutomation_Document_BuyBuilding_Remark] = CASE WHEN [OfficeAutomation_Document_BuyBuilding_Remark] IS NULL THEN '" + remark + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_BuyBuilding_Remark])!=0 THEN [OfficeAutomation_Document_BuyBuilding_Remark]"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_BuyBuilding_Remark] + '" + remark + "' END"
                                + " WHERE [OfficeAutomation_Document_BuyBuilding_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据id给对应特殊审批序号。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool AddAuditNOsByID(string id, string auditNO)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBuilding]"
                                + "   SET [OfficeAutomation_Document_BuyBuilding_AuditNOs] = CASE WHEN [OfficeAutomation_Document_BuyBuilding_AuditNOs] IS NULL THEN '" + auditNO + "'"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_BuyBuilding_AuditNOs] + '|" + auditNO + "' END"
                                + " WHERE [OfficeAutomation_Document_BuyBuilding_ID]='" + id + "'";

            return RunNoneSQL(sql);
        }

        private DataEntity.T_OfficeAutomation_Document_BuyBuilding _objMessage = null;

        //财务部登记
        public bool updateForCaiWu(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBuilding]"
                                + "         SET [OfficeAutomation_Document_BuyBuilding_TransNo] = @OfficeAutomation_Document_BuyBuilding_TransNo"
                                + "         ,[OfficeAutomation_Document_BuyBuilding_TransAddress] = @OfficeAutomation_Document_BuyBuilding_TransAddress"
                                + "         ,[OfficeAutomation_Document_BuyBuilding_TransDate] = @OfficeAutomation_Document_BuyBuilding_TransDate"
                                + "         ,[OfficeAutomation_Document_BuyBuilding_HouseRegistrant] = @OfficeAutomation_Document_BuyBuilding_HouseRegistrant"
                                + "         ,[OfficeAutomation_Document_BuyBuilding_IsRebate] = @OfficeAutomation_Document_BuyBuilding_IsRebate"
                                + "         ,[OfficeAutomation_Document_BuyBuilding_RebateDate] = @OfficeAutomation_Document_BuyBuilding_RebateDate"
                                + "         ,[OfficeAutomation_Document_BuyBuilding_Instruction] = @OfficeAutomation_Document_BuyBuilding_Instruction"
                                + "         WHERE [OfficeAutomation_Document_BuyBuilding_ID]=@OfficeAutomation_Document_BuyBuilding_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BuyBuilding)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_TransNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_TransNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_TransAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_TransAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_TransDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_TransDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_HouseRegistrant", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_HouseRegistrant));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_IsRebate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_IsRebate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_RebateDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_RebateDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_Instruction", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_Instruction));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBuilding_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBuilding_ID));

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

    }
}
