using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BuyBudiData_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_BuyBudiData _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBudiData]"
                                                        + "           ([OfficeAutomation_Document_BuyBudiData_ID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_MainID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Apply]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Department]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Area]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Writer]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Phone]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Bname]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Baddress]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_DealOfficeOther]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_BDCount]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_BSDCount]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Purpose]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Way]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_HaventTax]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_HaveTax]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Tax]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_AvgHaventTax]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_AvgHaveTax]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_RealP]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_CanUseP]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_EntryP]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Another]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Month1]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Month2]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Month3]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Month4]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Month5]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Month6]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_RCount1]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_RCount2]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_RCount3]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_RCount4]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_RCount5]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_RCount6]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult1]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult2]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult3]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult4]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult5]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_SCresult6]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Profits1]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Profits2]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Profits3]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Profits4]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Profits5]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_Profits6]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_SumRCount]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_SumSCresult]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_ApplyNo]"
                                                        + "           ,[OfficeAutomation_Document_BuyBudiData_SumProfits])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_BuyBudiData_ID"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_MainID"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Apply"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Department"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Area"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Writer"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Phone"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Bname"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Baddress"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_DealOfficeOther"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_BDCount"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_BSDCount"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Purpose"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Way"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_HaventTax"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_HaveTax"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Tax"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_AvgHaventTax"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_AvgHaveTax"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_RealP"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_CanUseP"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_EntryP"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Another"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Month1"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Month2"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Month3"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Month4"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Month5"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Month6"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_RCount1"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_RCount2"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_RCount3"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_RCount4"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_RCount5"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_RCount6"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_SCresult1"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_SCresult2"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_SCresult3"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_SCresult4"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_SCresult5"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_SCresult6"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Profits1"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Profits2"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Profits3"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Profits4"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Profits5"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_Profits6"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_SumRCount"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_SumSCresult"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_ApplyNo"
                                                        + "           ,@OfficeAutomation_Document_BuyBudiData_SumProfits)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BuyBudiData)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Writer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Writer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Bname", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Bname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Baddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Baddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_DealOfficeOther", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_DealOfficeOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_BDCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_BDCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_BSDCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_BSDCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Purpose", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Purpose));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Way", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Way));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_HaventTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_HaventTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_HaveTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_HaveTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Tax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Tax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_AvgHaventTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_AvgHaventTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_AvgHaveTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_AvgHaveTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RealP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RealP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_CanUseP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_CanUseP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_EntryP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_EntryP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Another", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Another));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SumRCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SumRCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SumSCresult", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SumSCresult));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_ApplyNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_ApplyNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SumProfits", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SumProfits));

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
            cmdToExecute.CommandText = "dbo.[pr_BuyBudiData_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BuyBudiData]"
                                + "         SET [OfficeAutomation_Document_BuyBudiData_ApplyID] = @OfficeAutomation_Document_BuyBudiData_ApplyID"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Department] = @OfficeAutomation_Document_BuyBudiData_Department"

                                + "         ,[OfficeAutomation_Document_BuyBudiData_Area] = @OfficeAutomation_Document_BuyBudiData_Area"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Writer] = @OfficeAutomation_Document_BuyBudiData_Writer"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Phone] = @OfficeAutomation_Document_BuyBudiData_Phone"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Bname] = @OfficeAutomation_Document_BuyBudiData_Bname"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Baddress] = @OfficeAutomation_Document_BuyBudiData_Baddress"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs] = @OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_DealOfficeOther] = @OfficeAutomation_Document_BuyBudiData_DealOfficeOther"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_BDCount] = @OfficeAutomation_Document_BuyBudiData_BDCount"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_BSDCount] = @OfficeAutomation_Document_BuyBudiData_BSDCount"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Purpose] = @OfficeAutomation_Document_BuyBudiData_Purpose"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Way] = @OfficeAutomation_Document_BuyBudiData_Way"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_HaventTax] = @OfficeAutomation_Document_BuyBudiData_HaventTax"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_HaveTax] = @OfficeAutomation_Document_BuyBudiData_HaveTax"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Tax] = @OfficeAutomation_Document_BuyBudiData_Tax"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_AvgHaventTax] = @OfficeAutomation_Document_BuyBudiData_AvgHaventTax"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_AvgHaveTax] = @OfficeAutomation_Document_BuyBudiData_AvgHaveTax"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_RealP] = @OfficeAutomation_Document_BuyBudiData_RealP"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_CanUseP] = @OfficeAutomation_Document_BuyBudiData_CanUseP"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_EntryP] = @OfficeAutomation_Document_BuyBudiData_EntryP"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Another] = @OfficeAutomation_Document_BuyBudiData_Another"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Month1] = @OfficeAutomation_Document_BuyBudiData_Month1"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Month2] = @OfficeAutomation_Document_BuyBudiData_Month2"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Month3] = @OfficeAutomation_Document_BuyBudiData_Month3"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Month4] = @OfficeAutomation_Document_BuyBudiData_Month4"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Month5] = @OfficeAutomation_Document_BuyBudiData_Month5"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Month6] = @OfficeAutomation_Document_BuyBudiData_Month6"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_RCount1] = @OfficeAutomation_Document_BuyBudiData_RCount1"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_RCount2] = @OfficeAutomation_Document_BuyBudiData_RCount2"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_RCount3] = @OfficeAutomation_Document_BuyBudiData_RCount3"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_RCount4] = @OfficeAutomation_Document_BuyBudiData_RCount4"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_RCount5] = @OfficeAutomation_Document_BuyBudiData_RCount5"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_RCount6] = @OfficeAutomation_Document_BuyBudiData_RCount6"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_SCresult1] = @OfficeAutomation_Document_BuyBudiData_SCresult1"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_SCresult2] = @OfficeAutomation_Document_BuyBudiData_SCresult2"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_SCresult3] = @OfficeAutomation_Document_BuyBudiData_SCresult3"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_SCresult4] = @OfficeAutomation_Document_BuyBudiData_SCresult4"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_SCresult5] = @OfficeAutomation_Document_BuyBudiData_SCresult5"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_SCresult6] = @OfficeAutomation_Document_BuyBudiData_SCresult6"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Profits1] = @OfficeAutomation_Document_BuyBudiData_Profits1"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Profits2] = @OfficeAutomation_Document_BuyBudiData_Profits2"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Profits3] = @OfficeAutomation_Document_BuyBudiData_Profits3"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Profits4] = @OfficeAutomation_Document_BuyBudiData_Profits4"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Profits5] = @OfficeAutomation_Document_BuyBudiData_Profits5"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_Profits6] = @OfficeAutomation_Document_BuyBudiData_Profits6"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_SumRCount] = @OfficeAutomation_Document_BuyBudiData_SumRCount"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_SumSCresult] = @OfficeAutomation_Document_BuyBudiData_SumSCresult"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_ApplyNo] = @OfficeAutomation_Document_BuyBudiData_ApplyNo"
                                + "         ,[OfficeAutomation_Document_BuyBudiData_SumProfits] = @OfficeAutomation_Document_BuyBudiData_SumProfits"

                                + "         WHERE [OfficeAutomation_Document_BuyBudiData_ID]=@OfficeAutomation_Document_BuyBudiData_ID"
                                + "         AND [OfficeAutomation_Document_BuyBudiData_MainID]=@OfficeAutomation_Document_BuyBudiData_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BuyBudiData)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Writer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Writer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Bname", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Bname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Baddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Baddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_DealOfficeOther", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_DealOfficeOther));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_BDCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_BDCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_BSDCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_BSDCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Purpose", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Purpose));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Way", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Way));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_HaventTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_HaventTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_HaveTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_HaveTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Tax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Tax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_AvgHaventTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_AvgHaventTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_AvgHaveTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_AvgHaveTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RealP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RealP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_CanUseP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_CanUseP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_EntryP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_EntryP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Another", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Another));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Month6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Month6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_RCount6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_RCount6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SCresult6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SCresult6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_Profits6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_Profits6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SumRCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SumRCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SumSCresult", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SumSCresult));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_ApplyNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_ApplyNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_SumProfits", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_SumProfits));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BuyBudiData_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BuyBudiData_MainID));

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
