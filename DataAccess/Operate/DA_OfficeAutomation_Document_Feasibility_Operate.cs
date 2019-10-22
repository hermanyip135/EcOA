using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Feasibility_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Feasibility _objMessage = null;
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_Feasibility> dal;
        #endregion
        public DA_OfficeAutomation_Document_Feasibility_Operate() 
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_Feasibility>();
        }

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility]"
                                                        + "           ([OfficeAutomation_Document_Feasibility_ID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Department]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_OpenType]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Branch]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_TurnBranch]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AreaManager]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_WorkingDepartmentNum]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_lDepartmentType]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_lMajordomo]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Contacter]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ContactPhone]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LastYearSituation1]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LastYearSituation2]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LastYearSituation3]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LastYearSituation4]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LastYearSituation5]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LastYearSituation6]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LastYearSituation7]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LastYearSituation8]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LastYearSituation9]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearMonth]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearSituation1]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearSituation2]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearSituation3]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearSituation4]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearSituation5]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearSituation6]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearSituation7]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearSituation8]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ThisYearSituation9]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation1]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation2]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation3]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation4]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation5]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation6]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation7]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation8]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation9]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation10]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation11]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation12]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation13]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation14]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation15]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation16]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation17]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BusinessSituation18]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation1]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation2]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation3]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation4]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation5]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation6]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation7]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation8]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation9]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation10]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation11]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation12]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation13]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation14]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation15]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation16]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation17]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ProfitSituation18]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation1]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation2]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation3]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation4]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation5]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation6]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation7]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation8]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation9]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation10]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation11]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation12]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation13]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation14]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_AccumulationSituation15]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RecentlyYear]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RecentlySeason]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation1]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation2]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation3]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation4]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation5]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation6]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation7]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation8]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation9]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation10]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation11]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation12]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation13]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation14]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StandardSituation15]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RateBeginDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RateEndDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Address]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Square]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RentSituation]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Deposit]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_SendCoast]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_PropertySituation]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RentAndTurn]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_PowerAddS]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MTelephone]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MOptical]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MonthlyPerformance]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ReachDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_TotalCost]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_NormalCost]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MonthProfit]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MonthProfitRDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ReturnPeriod]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BankOnForecast]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_BuildArea]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_UsableArea]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LeaseStartDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LeaseEndDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LeaseYears]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LeaseMonths]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_IsRentFree]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RentFreeStart]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_txtRentFreeEnd]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RentFreeCount]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MonthlyRentNoTax]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MothlyTax]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_HasTax]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_MonthlyTaxRate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ManageCoast]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ManageCoast2]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_WCoast]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ECoast]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Invoice]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RentDeposit]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_WEDeposit]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_ManageDeposit]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_PackageInvoice]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_NPackageInvoice]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_PayReason]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_PayWay]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_PayObiect]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_POPhone]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Collection]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_CollectionPhone]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Relationship]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StampDuty]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_StampDuty0]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_CompleteDate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FirstRent]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LeaseDeposit]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FSendCoast]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FWEDeposit]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FManageDeposit]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FFMCoaet]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FirstRentC]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LeaseDepositC]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FSendCoastC]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FWEDepositC]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FManageDepositC]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FFMCoaetC]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FirstRentT]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_LeaseDepositT]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FSendCoastT]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FWEDepositT]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FManageDepositT]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_FFMCoaetT]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RentName]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RentReal]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RentIdentity]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_RentMessage]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_EstateProperties]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_NatureTitle]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_NatureTitleO]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Summary])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_Feasibility_ID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MainID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Apply"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Department"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_OpenType"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Branch"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_TurnBranch"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AreaManager"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_WorkingDepartmentNum"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_lDepartmentType"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_lMajordomo"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Contacter"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ContactPhone"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LastYearSituation1"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LastYearSituation2"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LastYearSituation3"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LastYearSituation4"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LastYearSituation5"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LastYearSituation6"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LastYearSituation7"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LastYearSituation8"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LastYearSituation9"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearMonth"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearSituation1"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearSituation2"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearSituation3"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearSituation4"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearSituation5"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearSituation6"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearSituation7"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearSituation8"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ThisYearSituation9"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation1"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation2"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation3"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation4"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation5"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation6"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation7"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation8"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation9"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation10"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation11"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation12"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation13"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation14"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation15"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation16"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation17"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BusinessSituation18"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation1"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation2"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation3"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation4"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation5"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation6"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation7"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation8"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation9"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation10"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation11"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation12"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation13"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation14"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation15"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation16"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation17"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ProfitSituation18"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation1"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation2"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation3"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation4"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation5"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation6"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation7"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation8"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation9"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation10"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation11"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation12"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation13"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation14"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_AccumulationSituation15"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RecentlyYear"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RecentlySeason"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation1"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation2"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation3"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation4"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation5"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation6"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation7"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation8"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation9"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation10"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation11"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation12"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation13"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation14"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StandardSituation15"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RateBeginDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RateEndDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Address"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Square"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RentSituation"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Deposit"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_SendCoast"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_PropertySituation"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RentAndTurn"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_PowerAddS"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MTelephone"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MOptical"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MonthlyPerformance"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ReachDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_TotalCost"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_NormalCost"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MonthProfit"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MonthProfitRDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ReturnPeriod"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BankOnForecast"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_BuildArea"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_UsableArea"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LeaseStartDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LeaseEndDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LeaseYears"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LeaseMonths"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_IsRentFree"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RentFreeStart"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_txtRentFreeEnd"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RentFreeCount"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MonthlyRentNoTax"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MothlyTax"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_HasTax"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_MonthlyTaxRate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ManageCoast"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ManageCoast2"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_WCoast"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ECoast"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Invoice"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RentDeposit"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_WEDeposit"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_ManageDeposit"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_PackageInvoice"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_NPackageInvoice"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_PayReason"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_PayWay"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_PayObiect"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_POPhone"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Collection"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_CollectionPhone"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Relationship"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StampDuty"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_StampDuty0"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_CompleteDate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FirstRent"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LeaseDeposit"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FSendCoast"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FWEDeposit"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FManageDeposit"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FFMCoaet"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FirstRentC"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LeaseDepositC"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FSendCoastC"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FWEDepositC"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FManageDepositC"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FFMCoaetC"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FirstRentT"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_LeaseDepositT"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FSendCoastT"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FWEDepositT"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FManageDepositT"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_FFMCoaetT"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RentName"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RentReal"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RentIdentity"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_RentMessage"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_EstateProperties"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_NatureTitle"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_NatureTitleO"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Summary)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_OpenType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_OpenType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_TurnBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_TurnBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AreaManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AreaManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_WorkingDepartmentNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_WorkingDepartmentNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_lDepartmentType", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_lDepartmentType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_lMajordomo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_lMajordomo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Contacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Contacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ContactPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ContactPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation10", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation10));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation11", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation11));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation12", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation12));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation13", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation13));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation14", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation14));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation15", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation15));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation16", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation16));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation17", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation17));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation18", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation18));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation10", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation10));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation11", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation11));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation12", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation12));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation13", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation13));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation14", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation14));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation15", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation15));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation16", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation16));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation17", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation17));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation18", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation18));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation10", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation10));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation11", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation11));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation12", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation12));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation13", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation13));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation14", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation14));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation15", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation15));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RecentlyYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RecentlyYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RecentlySeason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RecentlySeason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation10", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation10));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation11", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation11));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation12", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation12));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation13", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation13));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation14", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation14));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation15", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation15));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RateBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RateBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RateEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RateEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Square", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Square));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentSituation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentSituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Deposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Deposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_SendCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_SendCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PropertySituation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PropertySituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentAndTurn", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentAndTurn));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PowerAddS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PowerAddS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MTelephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MTelephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MOptical", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MOptical));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthlyPerformance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthlyPerformance));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ReachDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ReachDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_TotalCost", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_TotalCost));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_NormalCost", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_NormalCost));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthProfit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthProfit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthProfitRDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthProfitRDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ReturnPeriod", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ReturnPeriod));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BankOnForecast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BankOnForecast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_UsableArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_UsableArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseYears", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseYears));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseMonths", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseMonths));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_IsRentFree", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_IsRentFree));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentFreeStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentFreeStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_txtRentFreeEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_txtRentFreeEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentFreeCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentFreeCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthlyRentNoTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthlyRentNoTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MothlyTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MothlyTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_HasTax", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_HasTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthlyTaxRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthlyTaxRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ManageCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ManageCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ManageCoast2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ManageCoast2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_WCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_WCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ECoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ECoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Invoice", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Invoice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_WEDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_WEDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ManageDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ManageDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PackageInvoice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PackageInvoice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_NPackageInvoice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_NPackageInvoice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PayReason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PayReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PayWay", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PayObiect", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PayObiect));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_POPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_POPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Collection", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Collection));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_CollectionPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_CollectionPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Relationship", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StampDuty", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StampDuty));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StampDuty0", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StampDuty0));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_CompleteDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_CompleteDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FirstRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FirstRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FSendCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FSendCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FWEDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FWEDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FManageDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FManageDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FFMCoaet", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FFMCoaet));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FirstRentC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FirstRentC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseDepositC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseDepositC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FSendCoastC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FSendCoastC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FWEDepositC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FWEDepositC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FManageDepositC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FManageDepositC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FFMCoaetC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FFMCoaetC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FirstRentT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FirstRentT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseDepositT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseDepositT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FSendCoastT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FSendCoastT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FWEDepositT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FWEDepositT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FManageDepositT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FManageDepositT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FFMCoaetT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FFMCoaetT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentReal", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentReal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentIdentity", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentIdentity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentMessage", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentMessage));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_EstateProperties", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_EstateProperties));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_NatureTitle", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_NatureTitle));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_NatureTitleO", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_NatureTitleO));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Summary", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Summary));

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
            cmdToExecute.CommandText = "dbo.[pr_Feasibility_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility]"
                                                        + "     SET   [OfficeAutomation_Document_Feasibility_ApplyID]=@OfficeAutomation_Document_Feasibility_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Department]=@OfficeAutomation_Document_Feasibility_Department"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_OpenType]=@OfficeAutomation_Document_Feasibility_OpenType"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Branch]=@OfficeAutomation_Document_Feasibility_Branch"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_TurnBranch]=@OfficeAutomation_Document_Feasibility_TurnBranch"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AreaManager]=@OfficeAutomation_Document_Feasibility_AreaManager"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_WorkingDepartmentNum]=@OfficeAutomation_Document_Feasibility_WorkingDepartmentNum"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum]=@OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_lDepartmentType]=@OfficeAutomation_Document_Feasibility_lDepartmentType"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_lMajordomo]=@OfficeAutomation_Document_Feasibility_lMajordomo"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Contacter]=@OfficeAutomation_Document_Feasibility_Contacter"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ContactPhone]=@OfficeAutomation_Document_Feasibility_ContactPhone"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LastYearSituation1]=@OfficeAutomation_Document_Feasibility_LastYearSituation1"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LastYearSituation2]=@OfficeAutomation_Document_Feasibility_LastYearSituation2"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LastYearSituation3]=@OfficeAutomation_Document_Feasibility_LastYearSituation3"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LastYearSituation4]=@OfficeAutomation_Document_Feasibility_LastYearSituation4"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LastYearSituation5]=@OfficeAutomation_Document_Feasibility_LastYearSituation5"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LastYearSituation6]=@OfficeAutomation_Document_Feasibility_LastYearSituation6"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LastYearSituation7]=@OfficeAutomation_Document_Feasibility_LastYearSituation7"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LastYearSituation8]=@OfficeAutomation_Document_Feasibility_LastYearSituation8"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LastYearSituation9]=@OfficeAutomation_Document_Feasibility_LastYearSituation9"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearMonth]=@OfficeAutomation_Document_Feasibility_ThisYearMonth"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearSituation1]=@OfficeAutomation_Document_Feasibility_ThisYearSituation1"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearSituation2]=@OfficeAutomation_Document_Feasibility_ThisYearSituation2"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearSituation3]=@OfficeAutomation_Document_Feasibility_ThisYearSituation3"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearSituation4]=@OfficeAutomation_Document_Feasibility_ThisYearSituation4"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearSituation5]=@OfficeAutomation_Document_Feasibility_ThisYearSituation5"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearSituation6]=@OfficeAutomation_Document_Feasibility_ThisYearSituation6"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearSituation7]=@OfficeAutomation_Document_Feasibility_ThisYearSituation7"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearSituation8]=@OfficeAutomation_Document_Feasibility_ThisYearSituation8"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ThisYearSituation9]=@OfficeAutomation_Document_Feasibility_ThisYearSituation9"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation1]=@OfficeAutomation_Document_Feasibility_BusinessSituation1"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation2]=@OfficeAutomation_Document_Feasibility_BusinessSituation2"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation3]=@OfficeAutomation_Document_Feasibility_BusinessSituation3"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation4]=@OfficeAutomation_Document_Feasibility_BusinessSituation4"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation5]=@OfficeAutomation_Document_Feasibility_BusinessSituation5"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation6]=@OfficeAutomation_Document_Feasibility_BusinessSituation6"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation7]=@OfficeAutomation_Document_Feasibility_BusinessSituation7"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation8]=@OfficeAutomation_Document_Feasibility_BusinessSituation8"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation9]=@OfficeAutomation_Document_Feasibility_BusinessSituation9"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation10]=@OfficeAutomation_Document_Feasibility_BusinessSituation10"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation11]=@OfficeAutomation_Document_Feasibility_BusinessSituation11"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation12]=@OfficeAutomation_Document_Feasibility_BusinessSituation12"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation13]=@OfficeAutomation_Document_Feasibility_BusinessSituation13"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation14]=@OfficeAutomation_Document_Feasibility_BusinessSituation14"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation15]=@OfficeAutomation_Document_Feasibility_BusinessSituation15"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation16]=@OfficeAutomation_Document_Feasibility_BusinessSituation16"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation17]=@OfficeAutomation_Document_Feasibility_BusinessSituation17"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BusinessSituation18]=@OfficeAutomation_Document_Feasibility_BusinessSituation18"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation1]=@OfficeAutomation_Document_Feasibility_ProfitSituation1"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation2]=@OfficeAutomation_Document_Feasibility_ProfitSituation2"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation3]=@OfficeAutomation_Document_Feasibility_ProfitSituation3"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation4]=@OfficeAutomation_Document_Feasibility_ProfitSituation4"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation5]=@OfficeAutomation_Document_Feasibility_ProfitSituation5"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation6]=@OfficeAutomation_Document_Feasibility_ProfitSituation6"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation7]=@OfficeAutomation_Document_Feasibility_ProfitSituation7"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation8]=@OfficeAutomation_Document_Feasibility_ProfitSituation8"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation9]=@OfficeAutomation_Document_Feasibility_ProfitSituation9"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation10]=@OfficeAutomation_Document_Feasibility_ProfitSituation10"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation11]=@OfficeAutomation_Document_Feasibility_ProfitSituation11"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation12]=@OfficeAutomation_Document_Feasibility_ProfitSituation12"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation13]=@OfficeAutomation_Document_Feasibility_ProfitSituation13"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation14]=@OfficeAutomation_Document_Feasibility_ProfitSituation14"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation15]=@OfficeAutomation_Document_Feasibility_ProfitSituation15"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation16]=@OfficeAutomation_Document_Feasibility_ProfitSituation16"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation17]=@OfficeAutomation_Document_Feasibility_ProfitSituation17"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ProfitSituation18]=@OfficeAutomation_Document_Feasibility_ProfitSituation18"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation1]=@OfficeAutomation_Document_Feasibility_AccumulationSituation1"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation2]=@OfficeAutomation_Document_Feasibility_AccumulationSituation2"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation3]=@OfficeAutomation_Document_Feasibility_AccumulationSituation3"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation4]=@OfficeAutomation_Document_Feasibility_AccumulationSituation4"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation5]=@OfficeAutomation_Document_Feasibility_AccumulationSituation5"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation6]=@OfficeAutomation_Document_Feasibility_AccumulationSituation6"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation7]=@OfficeAutomation_Document_Feasibility_AccumulationSituation7"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation8]=@OfficeAutomation_Document_Feasibility_AccumulationSituation8"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation9]=@OfficeAutomation_Document_Feasibility_AccumulationSituation9"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation10]=@OfficeAutomation_Document_Feasibility_AccumulationSituation10"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation11]=@OfficeAutomation_Document_Feasibility_AccumulationSituation11"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation12]=@OfficeAutomation_Document_Feasibility_AccumulationSituation12"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation13]=@OfficeAutomation_Document_Feasibility_AccumulationSituation13"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation14]=@OfficeAutomation_Document_Feasibility_AccumulationSituation14"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_AccumulationSituation15]=@OfficeAutomation_Document_Feasibility_AccumulationSituation15"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RecentlyYear]=@OfficeAutomation_Document_Feasibility_RecentlyYear"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RecentlySeason]=@OfficeAutomation_Document_Feasibility_RecentlySeason"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation1]=@OfficeAutomation_Document_Feasibility_StandardSituation1"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation2]=@OfficeAutomation_Document_Feasibility_StandardSituation2"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation3]=@OfficeAutomation_Document_Feasibility_StandardSituation3"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation4]=@OfficeAutomation_Document_Feasibility_StandardSituation4"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation5]=@OfficeAutomation_Document_Feasibility_StandardSituation5"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation6]=@OfficeAutomation_Document_Feasibility_StandardSituation6"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation7]=@OfficeAutomation_Document_Feasibility_StandardSituation7"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation8]=@OfficeAutomation_Document_Feasibility_StandardSituation8"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation9]=@OfficeAutomation_Document_Feasibility_StandardSituation9"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation10]=@OfficeAutomation_Document_Feasibility_StandardSituation10"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation11]=@OfficeAutomation_Document_Feasibility_StandardSituation11"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation12]=@OfficeAutomation_Document_Feasibility_StandardSituation12"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation13]=@OfficeAutomation_Document_Feasibility_StandardSituation13"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation14]=@OfficeAutomation_Document_Feasibility_StandardSituation14"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StandardSituation15]=@OfficeAutomation_Document_Feasibility_StandardSituation15"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RateBeginDate]=@OfficeAutomation_Document_Feasibility_RateBeginDate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RateEndDate]=@OfficeAutomation_Document_Feasibility_RateEndDate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Address]=@OfficeAutomation_Document_Feasibility_Address"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Square]=@OfficeAutomation_Document_Feasibility_Square"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RentSituation]=@OfficeAutomation_Document_Feasibility_RentSituation"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Deposit]=@OfficeAutomation_Document_Feasibility_Deposit"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_SendCoast]=@OfficeAutomation_Document_Feasibility_SendCoast"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_PropertySituation]=@OfficeAutomation_Document_Feasibility_PropertySituation"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RentAndTurn]=@OfficeAutomation_Document_Feasibility_RentAndTurn"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_PowerAddS]=@OfficeAutomation_Document_Feasibility_PowerAddS"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_MTelephone]=@OfficeAutomation_Document_Feasibility_MTelephone"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_MOptical]=@OfficeAutomation_Document_Feasibility_MOptical"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_MonthlyPerformance]=@OfficeAutomation_Document_Feasibility_MonthlyPerformance"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ReachDate]=@OfficeAutomation_Document_Feasibility_ReachDate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_TotalCost]=@OfficeAutomation_Document_Feasibility_TotalCost"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_NormalCost]=@OfficeAutomation_Document_Feasibility_NormalCost"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_MonthProfit]=@OfficeAutomation_Document_Feasibility_MonthProfit"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_MonthProfitRDate]=@OfficeAutomation_Document_Feasibility_MonthProfitRDate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ReturnPeriod]=@OfficeAutomation_Document_Feasibility_ReturnPeriod"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BankOnForecast]=@OfficeAutomation_Document_Feasibility_BankOnForecast"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_BuildArea]=@OfficeAutomation_Document_Feasibility_BuildArea"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_UsableArea]=@OfficeAutomation_Document_Feasibility_UsableArea"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LeaseStartDate]=@OfficeAutomation_Document_Feasibility_LeaseStartDate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LeaseEndDate]=@OfficeAutomation_Document_Feasibility_LeaseEndDate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LeaseYears]=@OfficeAutomation_Document_Feasibility_LeaseYears"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LeaseMonths]=@OfficeAutomation_Document_Feasibility_LeaseMonths"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_IsRentFree]=@OfficeAutomation_Document_Feasibility_IsRentFree"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RentFreeStart]=@OfficeAutomation_Document_Feasibility_RentFreeStart"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_txtRentFreeEnd]=@OfficeAutomation_Document_Feasibility_txtRentFreeEnd"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RentFreeCount]=@OfficeAutomation_Document_Feasibility_RentFreeCount"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_MonthlyRentNoTax]=@OfficeAutomation_Document_Feasibility_MonthlyRentNoTax"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax]=@OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_MothlyTax]=@OfficeAutomation_Document_Feasibility_MothlyTax"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_HasTax]=@OfficeAutomation_Document_Feasibility_HasTax"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_MonthlyTaxRate]=@OfficeAutomation_Document_Feasibility_MonthlyTaxRate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ManageCoast]=@OfficeAutomation_Document_Feasibility_ManageCoast"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ManageCoast2]=@OfficeAutomation_Document_Feasibility_ManageCoast2"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_WCoast]=@OfficeAutomation_Document_Feasibility_WCoast"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ECoast]=@OfficeAutomation_Document_Feasibility_ECoast"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Invoice]=@OfficeAutomation_Document_Feasibility_Invoice"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RentDeposit]=@OfficeAutomation_Document_Feasibility_RentDeposit"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_WEDeposit]=@OfficeAutomation_Document_Feasibility_WEDeposit"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_ManageDeposit]=@OfficeAutomation_Document_Feasibility_ManageDeposit"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_PackageInvoice]=@OfficeAutomation_Document_Feasibility_PackageInvoice"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_NPackageInvoice]=@OfficeAutomation_Document_Feasibility_NPackageInvoice"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_PayReason]=@OfficeAutomation_Document_Feasibility_PayReason"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_PayWay]=@OfficeAutomation_Document_Feasibility_PayWay"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_PayObiect]=@OfficeAutomation_Document_Feasibility_PayObiect"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_POPhone]=@OfficeAutomation_Document_Feasibility_POPhone"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Collection]=@OfficeAutomation_Document_Feasibility_Collection"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_CollectionPhone]=@OfficeAutomation_Document_Feasibility_CollectionPhone"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Relationship]=@OfficeAutomation_Document_Feasibility_Relationship"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StampDuty]=@OfficeAutomation_Document_Feasibility_StampDuty"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_StampDuty0]=@OfficeAutomation_Document_Feasibility_StampDuty0"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_CompleteDate]=@OfficeAutomation_Document_Feasibility_CompleteDate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FirstRent]=@OfficeAutomation_Document_Feasibility_FirstRent"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LeaseDeposit]=@OfficeAutomation_Document_Feasibility_LeaseDeposit"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FSendCoast]=@OfficeAutomation_Document_Feasibility_FSendCoast"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FWEDeposit]=@OfficeAutomation_Document_Feasibility_FWEDeposit"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FManageDeposit]=@OfficeAutomation_Document_Feasibility_FManageDeposit"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FFMCoaet]=@OfficeAutomation_Document_Feasibility_FFMCoaet"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FirstRentC]=@OfficeAutomation_Document_Feasibility_FirstRentC"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LeaseDepositC]=@OfficeAutomation_Document_Feasibility_LeaseDepositC"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FSendCoastC]=@OfficeAutomation_Document_Feasibility_FSendCoastC"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FWEDepositC]=@OfficeAutomation_Document_Feasibility_FWEDepositC"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FManageDepositC]=@OfficeAutomation_Document_Feasibility_FManageDepositC"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FFMCoaetC]=@OfficeAutomation_Document_Feasibility_FFMCoaetC"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FirstRentT]=@OfficeAutomation_Document_Feasibility_FirstRentT"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_LeaseDepositT]=@OfficeAutomation_Document_Feasibility_LeaseDepositT"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FSendCoastT]=@OfficeAutomation_Document_Feasibility_FSendCoastT"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FWEDepositT]=@OfficeAutomation_Document_Feasibility_FWEDepositT"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FManageDepositT]=@OfficeAutomation_Document_Feasibility_FManageDepositT"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_FFMCoaetT]=@OfficeAutomation_Document_Feasibility_FFMCoaetT"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RentName]=@OfficeAutomation_Document_Feasibility_RentName"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RentReal]=@OfficeAutomation_Document_Feasibility_RentReal"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RentIdentity]=@OfficeAutomation_Document_Feasibility_RentIdentity"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_RentMessage]=@OfficeAutomation_Document_Feasibility_RentMessage"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_EstateProperties]=@OfficeAutomation_Document_Feasibility_EstateProperties"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_NatureTitle]=@OfficeAutomation_Document_Feasibility_NatureTitle"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_NatureTitleO]=@OfficeAutomation_Document_Feasibility_NatureTitleO"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Summary]=@OfficeAutomation_Document_Feasibility_Summary"
                                                        + " WHERE [OfficeAutomation_Document_Feasibility_ID]=@OfficeAutomation_Document_Feasibility_ID"
                                                        + "     AND [OfficeAutomation_Document_Feasibility_MainID] = @OfficeAutomation_Document_Feasibility_MainID";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_OpenType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_OpenType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_TurnBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_TurnBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AreaManager", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AreaManager));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_WorkingDepartmentNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_WorkingDepartmentNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PrebuildDepartmentNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_lDepartmentType", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_lDepartmentType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_lMajordomo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_lMajordomo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Contacter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Contacter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ContactPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ContactPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LastYearSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LastYearSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearMonth", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ThisYearSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ThisYearSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation10", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation10));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation11", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation11));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation12", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation12));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation13", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation13));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation14", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation14));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation15", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation15));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation16", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation16));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation17", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation17));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BusinessSituation18", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BusinessSituation18));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation10", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation10));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation11", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation11));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation12", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation12));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation13", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation13));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation14", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation14));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation15", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation15));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation16", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation16));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation17", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation17));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ProfitSituation18", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ProfitSituation18));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation10", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation10));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation11", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation11));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation12", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation12));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation13", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation13));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation14", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation14));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_AccumulationSituation15", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_AccumulationSituation15));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RecentlyYear", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RecentlyYear));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RecentlySeason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RecentlySeason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation7", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation7));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation8", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation8));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation9", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation9));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation10", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation10));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation11", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation11));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation12", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation12));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation13", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation13));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation14", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation14));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StandardSituation15", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StandardSituation15));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RateBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RateBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RateEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RateEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Square", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Square));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentSituation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentSituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Deposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Deposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_SendCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_SendCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PropertySituation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PropertySituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentAndTurn", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentAndTurn));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PowerAddS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PowerAddS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MTelephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MTelephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MOptical", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MOptical));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthlyPerformance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthlyPerformance));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ReachDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ReachDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_TotalCost", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_TotalCost));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_NormalCost", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_NormalCost));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthProfit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthProfit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthProfitRDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthProfitRDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ReturnPeriod", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ReturnPeriod));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BankOnForecast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BankOnForecast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_BuildArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_BuildArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_UsableArea", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_UsableArea));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseStartDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseYears", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseYears));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseMonths", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseMonths));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_IsRentFree", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_IsRentFree));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentFreeStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentFreeStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_txtRentFreeEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_txtRentFreeEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentFreeCount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentFreeCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthlyRentNoTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthlyRentNoTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthlyRentIncludeTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MothlyTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MothlyTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_HasTax", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_HasTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MonthlyTaxRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MonthlyTaxRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ManageCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ManageCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ManageCoast2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ManageCoast2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_WCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_WCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ECoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ECoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Invoice", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Invoice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_WEDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_WEDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ManageDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ManageDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PackageInvoice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PackageInvoice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_NPackageInvoice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_NPackageInvoice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PayReason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PayReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PayWay", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_PayObiect", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_PayObiect));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_POPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_POPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Collection", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Collection));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_CollectionPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_CollectionPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Relationship", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StampDuty", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StampDuty));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_StampDuty0", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_StampDuty0));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_CompleteDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_CompleteDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FirstRent", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FirstRent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FSendCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FSendCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FWEDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FWEDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FManageDeposit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FManageDeposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FFMCoaet", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FFMCoaet));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FirstRentC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FirstRentC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseDepositC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseDepositC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FSendCoastC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FSendCoastC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FWEDepositC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FWEDepositC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FManageDepositC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FManageDepositC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FFMCoaetC", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FFMCoaetC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FirstRentT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FirstRentT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_LeaseDepositT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_LeaseDepositT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FSendCoastT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FSendCoastT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FWEDepositT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FWEDepositT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FManageDepositT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FManageDepositT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_FFMCoaetT", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_FFMCoaetT));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentReal", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentReal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentIdentity", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentIdentity));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_RentMessage", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_RentMessage));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_EstateProperties", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_EstateProperties));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_NatureTitle", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_NatureTitle));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_NatureTitleO", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_NatureTitleO));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Summary", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Summary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MainID));

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

        #region 插入图片
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public bool InsertPhoto(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Diagram]"
                                                        + "           ([OfficeAutomation_Document_Feasibility_Diagram_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Diagram_Photo])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_Feasibility_Diagram_MainID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Diagram_Photo)";




            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Diagram_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Diagram_Photo", SqlDbType.Image, 1048576, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Photo));

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

        #region 更新图片
        public bool UpdatePhoto(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Diagram]"

            + "     SET    [OfficeAutomation_Document_Feasibility_Diagram_Photo]=@OfficeAutomation_Document_Feasibility_Diagram_Photo"
            + "            ,[OfficeAutomation_Document_Feasibility_Diagram_AddTime]=GETDATE()"
            + " WHERE [OfficeAutomation_Document_Feasibility_Diagram_MainID]=@OfficeAutomation_Document_Feasibility_Diagram_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Diagram_Photo", SqlDbType.Image, 1048576, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Photo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Diagram_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_MainID));

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

        #region 删除图片
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public bool DeletePhoto(string mainID)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Diagram]"
                                + " WHERE [OfficeAutomation_Document_Feasibility_Diagram_MainID]=@OfficeAutomation_Document_Feasibility_Diagram_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Diagram_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

        #region 自定义
        public T_OfficeAutomation_Document_Feasibility Add(T_OfficeAutomation_Document_Feasibility t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_Feasibility Edit(T_OfficeAutomation_Document_Feasibility t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_Feasibility t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_Feasibility GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_Feasibility>(where);
        }
        #endregion 
    }
}
