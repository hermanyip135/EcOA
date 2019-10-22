using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BranchContract_Inherit : DA_OfficeAutomation_Document_BranchContract_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BranchContract_ID]"
                           + "           ,[OfficeAutomation_Document_BranchContract_MainID]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Apply]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Department]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Telephone]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Name]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ApplyPhone]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Branch]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ContractEndDate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LastMonthRent]"
                           + "           ,[OfficeAutomation_Document_BranchContract_FirstYearRent]"
                           + "           ,[OfficeAutomation_Document_BranchContract_RentAmplitude]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ContractPeriod]"
                           + "           ,[OfficeAutomation_Document_BranchContract_BranchSuqare]"
                           + "           ,[OfficeAutomation_Document_BranchContract_BranchAddress]"
                           + "           ,[OfficeAutomation_Document_BranchContract_StampDuty]"
                           + "           ,[OfficeAutomation_Document_BranchContract_RentDP]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ManagementDP]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ManagementDPAnother]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LeaseDeposit]"
                           + "           ,[OfficeAutomation_Document_BranchContract_OtherFees]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ResponsibleName]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ResponsibleCall]"
                           + "           ,[OfficeAutomation_Document_BranchContract_RecentlyBeginData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_RecentlyEndData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_CumulativePerformance]"
                           + "           ,[OfficeAutomation_Document_BranchContract_CumulativeProfits]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LastYear]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LastYearResults]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LastYearProfit]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ThisYearAsOfData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ThisYearCP]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ThisYearPS2]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AmortizationBeginData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AmortizationMoney]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AmortizationEndData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_StatisticalBeginData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_StatisticalEndData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumCount]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumGzspsNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumGzspsRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumEveryNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumEveryRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumRichNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumRichRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumYuFengNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumYuFengRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumFreeNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumFreeRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumOtherNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumOtherRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumQFangNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumQFangRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AreaPart]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AreaSumOfBuild]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AreaCNo]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AreaCRate]"

                           + "           ,[OfficeAutomation_Document_BranchContract_OtherSummy]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Reason]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementContent]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementPS]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementAward]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementPercentage]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementCharge]"
                           + "           ,[OfficeAutomation_Document_BranchContract_BranchRecentlyStartDate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_BranchRecentlyEndDate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AvgMonthStandardRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SalesAvgMthLoginCount]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ManagerAvgMthLoginCount]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AreaManagerAvgMthLoginCount]"
                           + "           ,[OfficeAutomation_Document_BranchContract_DirectorAvgMthLoginCount]"
                           + "           ,[OfficeAutomation_Document_BranchContract_HouseNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_PlatefulRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ValidHouseNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ValidHouseProportion]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SecondTeGongStartDate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AvgMthPeopleNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AvgPerMthNewHouse]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AvgPerMthNewCustom]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AvgPerMthTakeWath]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SecondTeGongEndDate]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BranchContract] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BranchContract_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BranchContract_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_BranchContract_ID]"
                           + "           ,[OfficeAutomation_Document_BranchContract_MainID]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Apply]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ApplyID]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Department]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Telephone]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Name]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ApplyPhone]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Branch]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ContractEndDate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LastMonthRent]"
                           + "           ,[OfficeAutomation_Document_BranchContract_FirstYearRent]"
                           + "           ,[OfficeAutomation_Document_BranchContract_RentAmplitude]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ContractPeriod]"
                           + "           ,[OfficeAutomation_Document_BranchContract_BranchSuqare]"
                           + "           ,[OfficeAutomation_Document_BranchContract_BranchAddress]"
                           + "           ,[OfficeAutomation_Document_BranchContract_StampDuty]"
                           + "           ,[OfficeAutomation_Document_BranchContract_RentDP]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ManagementDP]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ManagementDPAnother]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LeaseDeposit]"
                           + "           ,[OfficeAutomation_Document_BranchContract_OtherFees]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ResponsibleName]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ResponsibleCall]"
                           + "           ,[OfficeAutomation_Document_BranchContract_RecentlyBeginData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_RecentlyEndData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_CumulativePerformance]"
                           + "           ,[OfficeAutomation_Document_BranchContract_CumulativeProfits]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LastYear]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LastYearResults]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LastYearProfit]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ThisYearAsOfData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ThisYearCP]"
                           + "           ,[OfficeAutomation_Document_BranchContract_ThisYearPS2]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AmortizationBeginData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AmortizationMoney]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AmortizationEndData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_StatisticalBeginData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_StatisticalEndData]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumCount]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumGzspsNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumGzspsRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumEveryNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumEveryRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumRichNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumRichRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumYuFengNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumYuFengRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumFreeNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumFreeRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumOtherNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumOtherRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumQFangNum]"
                           + "           ,[OfficeAutomation_Document_BranchContract_SumQFangRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AreaPart]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AreaSumOfBuild]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AreaCNo]"
                           + "           ,[OfficeAutomation_Document_BranchContract_AreaCRate]"
                           + "           ,[OfficeAutomation_Document_BranchContract_OtherSummy]"
                           + "           ,[OfficeAutomation_Document_BranchContract_Reason]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementContent]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementPS]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementAward]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementPercentage]"
                           + "           ,[OfficeAutomation_Document_BranchContract_LossAgreementCharge]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BranchContract] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_BranchContract_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_BranchContract_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.PageModel.T_OfficeAutomation_Document_BranchContract_M obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_BranchContract_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_BranchContract();
            Baseobj.OfficeAutomation_Document_BranchContract_ID = new Guid(obj.OfficeAutomation_Document_BranchContract_ID);
            Baseobj.OfficeAutomation_Document_BranchContract_MainID = new Guid(obj.OfficeAutomation_Document_BranchContract_MainID);
            Baseobj.OfficeAutomation_Document_BranchContract_Apply = obj.OfficeAutomation_Document_BranchContract_Apply;
            Baseobj.OfficeAutomation_Document_BranchContract_ApplyDate = Convert.ToDateTime(obj.OfficeAutomation_Document_BranchContract_ApplyDate);
            Baseobj.OfficeAutomation_Document_BranchContract_ApplyID = obj.OfficeAutomation_Document_BranchContract_ApplyID;
            Baseobj.OfficeAutomation_Document_BranchContract_Department = obj.OfficeAutomation_Document_BranchContract_Department;


            //obj是否已经存在
            var where = "[OfficeAutomation_Document_BranchContract_MainID]='" + obj.OfficeAutomation_Document_BranchContract_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_BranchContract resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Add(Baseobj);
            }
            return resultobj != null;
        }

        #endregion

        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_BranchContract _objMessage = null;
        #endregion

        #region 后勤事务部更新内容
        public bool UpdateForLogistics(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BranchContract]"
                                + "         SET [OfficeAutomation_Document_BranchContract_BranchRecentlyStartDate] = @OfficeAutomation_Document_BranchContract_BranchRecentlyStartDate"
                                + "         ,[OfficeAutomation_Document_BranchContract_BranchRecentlyEndDate] = @OfficeAutomation_Document_BranchContract_BranchRecentlyEndDate"
                                + "         ,[OfficeAutomation_Document_BranchContract_AvgMonthStandardRate] = @OfficeAutomation_Document_BranchContract_AvgMonthStandardRate"
                                + "         ,[OfficeAutomation_Document_BranchContract_SalesAvgMthLoginCount] = @OfficeAutomation_Document_BranchContract_SalesAvgMthLoginCount"
                                + "         ,[OfficeAutomation_Document_BranchContract_ManagerAvgMthLoginCount] = @OfficeAutomation_Document_BranchContract_ManagerAvgMthLoginCount"
                                + "         ,[OfficeAutomation_Document_BranchContract_AreaManagerAvgMthLoginCount] = @OfficeAutomation_Document_BranchContract_AreaManagerAvgMthLoginCount"
                                + "         ,[OfficeAutomation_Document_BranchContract_DirectorAvgMthLoginCount] = @OfficeAutomation_Document_BranchContract_DirectorAvgMthLoginCount"
                                + "         ,[OfficeAutomation_Document_BranchContract_HouseNum] = @OfficeAutomation_Document_BranchContract_HouseNum"
                                + "         ,[OfficeAutomation_Document_BranchContract_PlatefulRate] = @OfficeAutomation_Document_BranchContract_PlatefulRate"
                                + "         ,[OfficeAutomation_Document_BranchContract_ValidHouseNum] = @OfficeAutomation_Document_BranchContract_ValidHouseNum"
                                + "         ,[OfficeAutomation_Document_BranchContract_ValidHouseProportion] = @OfficeAutomation_Document_BranchContract_ValidHouseProportion"
                                + "         ,[OfficeAutomation_Document_BranchContract_SecondTeGongStartDate] = @OfficeAutomation_Document_BranchContract_SecondTeGongStartDate"
                                + "         ,[OfficeAutomation_Document_BranchContract_AvgMthPeopleNum] = @OfficeAutomation_Document_BranchContract_AvgMthPeopleNum"
                                + "         ,[OfficeAutomation_Document_BranchContract_AvgPerMthNewHouse] = @OfficeAutomation_Document_BranchContract_AvgPerMthNewHouse"
                                + "         ,[OfficeAutomation_Document_BranchContract_AvgPerMthNewCustom] = @OfficeAutomation_Document_BranchContract_AvgPerMthNewCustom"
                                + "         ,[OfficeAutomation_Document_BranchContract_AvgPerMthTakeWath] = @OfficeAutomation_Document_BranchContract_AvgPerMthTakeWath"
                                + "         ,[OfficeAutomation_Document_BranchContract_SecondTeGongEndDate] = @OfficeAutomation_Document_BranchContract_SecondTeGongEndDate"
                                + "         WHERE [OfficeAutomation_Document_BranchContract_ID]=@OfficeAutomation_Document_BranchContract_ID"
                                + "         AND [OfficeAutomation_Document_BranchContract_MainID]=@OfficeAutomation_Document_BranchContract_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BranchContract)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_BranchRecentlyStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_BranchRecentlyStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_BranchRecentlyEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_BranchRecentlyEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AvgMonthStandardRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AvgMonthStandardRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SalesAvgMthLoginCount", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SalesAvgMthLoginCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ManagerAvgMthLoginCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ManagerAvgMthLoginCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AreaManagerAvgMthLoginCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AreaManagerAvgMthLoginCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_DirectorAvgMthLoginCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_DirectorAvgMthLoginCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_HouseNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_HouseNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_PlatefulRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_PlatefulRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ValidHouseNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ValidHouseNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ValidHouseProportion", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ValidHouseProportion));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SecondTeGongStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SecondTeGongStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AvgMthPeopleNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AvgMthPeopleNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AvgPerMthNewHouse", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AvgPerMthNewHouse));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AvgPerMthNewCustom", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AvgPerMthNewCustom));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_AvgPerMthTakeWath", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_AvgPerMthTakeWath));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_SecondTeGongEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_SecondTeGongEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BranchContract_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BranchContract_MainID));

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
