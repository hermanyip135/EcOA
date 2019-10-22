using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using SqlDatabase;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SpecialAdd_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_SpecialAdd _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_SpecialAdd> dal;
        #endregion

        public DA_OfficeAutomation_Document_SpecialAdd_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_SpecialAdd>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialAdd]"
                                                        + "           ([OfficeAutomation_Document_SpecialAdd_ID]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_MainID]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Apply]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Department]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_ReceiveD]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_CCDpm]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Subject]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Phone]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Fax]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Group]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Year1]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Year2]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Year3]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Year4]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Year5]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Month1]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Month2]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Month3]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Month4]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Month5]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Results1]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Results2]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Results3]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Results4]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Results5]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Profits1]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Profits2]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Profits3]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Profits4]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Profits5]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear1]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear2]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear3]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear4]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear5]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost1]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost2]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost3]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost4]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost5]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_HoldRat]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_GPlace]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumBuild]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_CountComplete]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_CompleteRat]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_RentYearStart]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_RentMonthStart]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_RentYearEnd]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_RentMonthEnd]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_UseRat]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumCount]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumGzspsNum]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumGzspsRate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumEveryNum]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumEveryRate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumRichNum]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumRichRate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumYuFengNum]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumYuFengRate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumFreeNum]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumFreeRate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumOtherNum]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumOtherRate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumQFangNum]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SumQFangRate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_AddOne]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand1]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand2]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand3]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand4]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand5]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG1]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG2]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG3]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG4]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG5]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_KeyCount]"
                                                        + "           ,[OfficeAutomation_Document_SpecialAdd_Reason])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_SpecialAdd_ID"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_MainID"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Apply"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Department"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_ReceiveD"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_CCDpm"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Subject"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Phone"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Fax"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Group"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Year1"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Year2"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Year3"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Year4"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Year5"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Month1"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Month2"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Month3"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Month4"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Month5"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Results1"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Results2"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Results3"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Results4"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Results5"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Profits1"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Profits2"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Profits3"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Profits4"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Profits5"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumFear1"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumFear2"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumFear3"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumFear4"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumFear5"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_BDLost1"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_BDLost2"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_BDLost3"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_BDLost4"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_BDLost5"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_HoldRat"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_GPlace"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumBuild"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_CountComplete"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_CompleteRat"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_RentYearStart"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_RentMonthStart"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_RentYearEnd"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_RentMonthEnd"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_UseRat"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumCount"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumGzspsNum"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumGzspsRate"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumEveryNum"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumEveryRate"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumRichNum"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumRichRate"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumYuFengNum"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumYuFengRate"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumFreeNum"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumFreeRate"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumOtherNum"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumOtherRate"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumQFangNum"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SumQFangRate"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_AddOne"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SecHand1"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SecHand2"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SecHand3"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SecHand4"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_SecHand5"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_IsTG1"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_IsTG2"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_IsTG3"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_IsTG4"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_IsTG5"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_KeyCount"
                                                        + "           ,@OfficeAutomation_Document_SpecialAdd_Reason)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SpecialAdd)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_ReceiveD", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_ReceiveD));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_CCDpm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_CCDpm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Group", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Group));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_HoldRat", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_HoldRat));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_GPlace", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_GPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumBuild", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumBuild));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_CountComplete", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_CountComplete));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_CompleteRat", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_CompleteRat));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_RentYearStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_RentYearStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_RentMonthStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_RentMonthStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_RentYearEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_RentYearEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_RentMonthEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_RentMonthEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_UseRat", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_UseRat));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumGzspsNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumGzspsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumGzspsRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumGzspsRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumEveryNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumEveryNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumEveryRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumEveryRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumRichNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumRichNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumRichRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumRichRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumYuFengNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumYuFengNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumYuFengRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumYuFengRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFreeNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFreeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFreeRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFreeRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumOtherNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumOtherNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumOtherRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumOtherRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumQFangNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumQFangNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumQFangRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumQFangRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_AddOne", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_AddOne));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand3", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand4", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand5", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand5));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG3", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG4", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG5", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG5));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_KeyCount", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_KeyCount));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Reason));

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
            cmdToExecute.CommandText = "dbo.[pr_SpecialAdd_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialAdd]"
                                + "         SET [OfficeAutomation_Document_SpecialAdd_ApplyID] = @OfficeAutomation_Document_SpecialAdd_ApplyID"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Department] = @OfficeAutomation_Document_SpecialAdd_Department"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_ReceiveD] = @OfficeAutomation_Document_SpecialAdd_ReceiveD"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_CCDpm] = @OfficeAutomation_Document_SpecialAdd_CCDpm"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Subject] = @OfficeAutomation_Document_SpecialAdd_Subject"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Phone] = @OfficeAutomation_Document_SpecialAdd_Phone"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Fax] = @OfficeAutomation_Document_SpecialAdd_Fax"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Group] = @OfficeAutomation_Document_SpecialAdd_Group"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Year1] = @OfficeAutomation_Document_SpecialAdd_Year1"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Year2] = @OfficeAutomation_Document_SpecialAdd_Year2"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Year3] = @OfficeAutomation_Document_SpecialAdd_Year3"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Year4] = @OfficeAutomation_Document_SpecialAdd_Year4"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Year5] = @OfficeAutomation_Document_SpecialAdd_Year5"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Month1] = @OfficeAutomation_Document_SpecialAdd_Month1"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Month2] = @OfficeAutomation_Document_SpecialAdd_Month2"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Month3] = @OfficeAutomation_Document_SpecialAdd_Month3"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Month4] = @OfficeAutomation_Document_SpecialAdd_Month4"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Month5] = @OfficeAutomation_Document_SpecialAdd_Month5"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Results1] = @OfficeAutomation_Document_SpecialAdd_Results1"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Results2] = @OfficeAutomation_Document_SpecialAdd_Results2"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Results3] = @OfficeAutomation_Document_SpecialAdd_Results3"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Results4] = @OfficeAutomation_Document_SpecialAdd_Results4"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Results5] = @OfficeAutomation_Document_SpecialAdd_Results5"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Profits1] = @OfficeAutomation_Document_SpecialAdd_Profits1"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Profits2] = @OfficeAutomation_Document_SpecialAdd_Profits2"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Profits3] = @OfficeAutomation_Document_SpecialAdd_Profits3"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Profits4] = @OfficeAutomation_Document_SpecialAdd_Profits4"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Profits5] = @OfficeAutomation_Document_SpecialAdd_Profits5"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumFear1] = @OfficeAutomation_Document_SpecialAdd_SumFear1"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumFear2] = @OfficeAutomation_Document_SpecialAdd_SumFear2"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumFear3] = @OfficeAutomation_Document_SpecialAdd_SumFear3"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumFear4] = @OfficeAutomation_Document_SpecialAdd_SumFear4"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumFear5] = @OfficeAutomation_Document_SpecialAdd_SumFear5"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_BDLost1] = @OfficeAutomation_Document_SpecialAdd_BDLost1"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_BDLost2] = @OfficeAutomation_Document_SpecialAdd_BDLost2"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_BDLost3] = @OfficeAutomation_Document_SpecialAdd_BDLost3"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_BDLost4] = @OfficeAutomation_Document_SpecialAdd_BDLost4"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_BDLost5] = @OfficeAutomation_Document_SpecialAdd_BDLost5"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_HoldRat] = @OfficeAutomation_Document_SpecialAdd_HoldRat"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_GPlace] = @OfficeAutomation_Document_SpecialAdd_GPlace"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumBuild] = @OfficeAutomation_Document_SpecialAdd_SumBuild"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_CountComplete] = @OfficeAutomation_Document_SpecialAdd_CountComplete"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_CompleteRat] = @OfficeAutomation_Document_SpecialAdd_CompleteRat"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_RentYearStart] = @OfficeAutomation_Document_SpecialAdd_RentYearStart"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_RentMonthStart] = @OfficeAutomation_Document_SpecialAdd_RentMonthStart"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_RentYearEnd] = @OfficeAutomation_Document_SpecialAdd_RentYearEnd"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_RentMonthEnd] = @OfficeAutomation_Document_SpecialAdd_RentMonthEnd"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_UseRat] = @OfficeAutomation_Document_SpecialAdd_UseRat"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumCount] = @OfficeAutomation_Document_SpecialAdd_SumCount"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumGzspsNum] = @OfficeAutomation_Document_SpecialAdd_SumGzspsNum"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumGzspsRate] = @OfficeAutomation_Document_SpecialAdd_SumGzspsRate"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumEveryNum] = @OfficeAutomation_Document_SpecialAdd_SumEveryNum"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumEveryRate] = @OfficeAutomation_Document_SpecialAdd_SumEveryRate"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumRichNum] = @OfficeAutomation_Document_SpecialAdd_SumRichNum"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumRichRate] = @OfficeAutomation_Document_SpecialAdd_SumRichRate"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumYuFengNum] = @OfficeAutomation_Document_SpecialAdd_SumYuFengNum"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumYuFengRate] = @OfficeAutomation_Document_SpecialAdd_SumYuFengRate"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumFreeNum] = @OfficeAutomation_Document_SpecialAdd_SumFreeNum"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumFreeRate] = @OfficeAutomation_Document_SpecialAdd_SumFreeRate"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumOtherNum] = @OfficeAutomation_Document_SpecialAdd_SumOtherNum"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumOtherRate] = @OfficeAutomation_Document_SpecialAdd_SumOtherRate"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumQFangNum] = @OfficeAutomation_Document_SpecialAdd_SumQFangNum"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SumQFangRate] = @OfficeAutomation_Document_SpecialAdd_SumQFangRate"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_AddOne] = @OfficeAutomation_Document_SpecialAdd_AddOne"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_Reason] = @OfficeAutomation_Document_SpecialAdd_Reason"

                                + "         ,[OfficeAutomation_Document_SpecialAdd_SecHand1] = @OfficeAutomation_Document_SpecialAdd_SecHand1"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SecHand2] = @OfficeAutomation_Document_SpecialAdd_SecHand2"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SecHand3] = @OfficeAutomation_Document_SpecialAdd_SecHand3"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SecHand4] = @OfficeAutomation_Document_SpecialAdd_SecHand4"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_SecHand5] = @OfficeAutomation_Document_SpecialAdd_SecHand5"

                                + "         ,[OfficeAutomation_Document_SpecialAdd_IsTG1] = @OfficeAutomation_Document_SpecialAdd_IsTG1"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_IsTG2] = @OfficeAutomation_Document_SpecialAdd_IsTG2"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_IsTG3] = @OfficeAutomation_Document_SpecialAdd_IsTG3"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_IsTG4] = @OfficeAutomation_Document_SpecialAdd_IsTG4"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_IsTG5] = @OfficeAutomation_Document_SpecialAdd_IsTG5"
                                + "         ,[OfficeAutomation_Document_SpecialAdd_KeyCount] = @OfficeAutomation_Document_SpecialAdd_KeyCount"

                                + "         WHERE [OfficeAutomation_Document_SpecialAdd_ID]=@OfficeAutomation_Document_SpecialAdd_ID"
                                + "         AND [OfficeAutomation_Document_SpecialAdd_MainID]=@OfficeAutomation_Document_SpecialAdd_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SpecialAdd)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_ReceiveD", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_ReceiveD));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_CCDpm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_CCDpm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Group", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Group));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Year5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Year5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Month5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Month5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Results5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Results5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Profits5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Profits5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFear5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFear5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_BDLost5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_BDLost5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_HoldRat", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_HoldRat));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_GPlace", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_GPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumBuild", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumBuild));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_CountComplete", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_CountComplete));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_CompleteRat", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_CompleteRat));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_RentYearStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_RentYearStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_RentMonthStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_RentMonthStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_RentYearEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_RentYearEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_RentMonthEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_RentMonthEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_UseRat", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_UseRat));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumGzspsNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumGzspsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumGzspsRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumGzspsRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumEveryNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumEveryNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumEveryRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumEveryRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumRichNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumRichNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumRichRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumRichRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumYuFengNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumYuFengNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumYuFengRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumYuFengRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFreeNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFreeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumFreeRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumFreeRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumOtherNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumOtherNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumOtherRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumOtherRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumQFangNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumQFangNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SumQFangRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SumQFangRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_AddOne", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_AddOne));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_Reason));
                
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand3", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand4", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_SecHand5", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_SecHand5));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG3", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG4", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_IsTG5", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_IsTG5));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_KeyCount", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_KeyCount));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialAdd_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialAdd_MainID));

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


        #region 自定义方法
        public T_OfficeAutomation_Document_SpecialAdd Add(T_OfficeAutomation_Document_SpecialAdd t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_SpecialAdd Edit(T_OfficeAutomation_Document_SpecialAdd t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_SpecialAdd t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_SpecialAdd GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_SpecialAdd>(where);
        }
        #endregion
    }
}
