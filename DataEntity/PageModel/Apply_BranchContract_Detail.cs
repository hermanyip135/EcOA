using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_BranchContract_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_BranchContract_M BranchContract_M { get; set; }
        public List<T_OfficeAutomation_Document_BranchContract_LeaseTerm> LeaseTerm { get; set; }
        public List<T_OfficeAutomation_Document_BranchContract_Statistical> Statistical { get; set; }
    }
    public class T_OfficeAutomation_Document_BranchContract_M
    {
        /// <summary>
        /// 
        /// </summary>
        [CProperty("Key")]
        public string OfficeAutomation_Document_BranchContract_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_MainID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Apply { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ApplyDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ApplyID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Department { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Telephone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ApplyPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Branch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ContractEndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LastMonthRent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_FirstYearRent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_RentAmplitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ContractPeriod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_StampDuty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_RentDP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ManagementDP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ManagementDPAnother { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LeaseDeposit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_OtherFees { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ResponsibleName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ResponsibleCall { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_RecentlyBeginData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_RecentlyEndData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_CumulativePerformance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_CumulativeProfits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LastYear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LastYearResults { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LastYearProfit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ThisYearAsOfData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ThisYearCP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ThisYearPS2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AmortizationBeginData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AmortizationMoney { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AmortizationEndData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_StatisticalBeginData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_StatisticalEndData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumGzspsNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumGzspsRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumEveryNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumEveryRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumRichNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumRichRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumYuFengNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumYuFengRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumFreeNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumFreeRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumOtherNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumOtherRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Reason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_OtherSummy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_LastBeginDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_LastEndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_LastSumNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_LastResults { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CumulativeEndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CumulativeNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CumulativeResults { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_SumTurnover { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_BranchSuqare { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_BranchAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumQFangNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumQFangRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AreaPart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AreaSumOfBuild { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AreaCNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AreaCRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LossAgreementContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LossAgreementPS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LossAgreementAward { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LossAgreementPercentage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LossAgreementCharge { get; set; }

        public string OfficeAutomation_Document_BranchContract_BranchRecentlyStartDate { get; set; }
        public string OfficeAutomation_Document_BranchContract_BranchRecentlyEndDate { get; set; }
        public string OfficeAutomation_Document_BranchContract_AvgMonthStandardRate { get; set; }
        public string OfficeAutomation_Document_BranchContract_SalesAvgMthLoginCount { get; set; }
        public string OfficeAutomation_Document_BranchContract_ManagerAvgMthLoginCount { get; set; }
        public string OfficeAutomation_Document_BranchContract_AreaManagerAvgMthLoginCount { get; set; }
        public string OfficeAutomation_Document_BranchContract_DirectorAvgMthLoginCount { get; set; }
        public string OfficeAutomation_Document_BranchContract_HouseNum { get; set; }
        public string OfficeAutomation_Document_BranchContract_PlatefulRate { get; set; }
        public string OfficeAutomation_Document_BranchContract_ValidHouseNum { get; set; }
        public string OfficeAutomation_Document_BranchContract_ValidHouseProportion { get; set; }
        public string OfficeAutomation_Document_BranchContract_SecondTeGongStartDate { get; set; }
        public string OfficeAutomation_Document_BranchContract_AvgMthPeopleNum { get; set; }
        public string OfficeAutomation_Document_BranchContract_AvgPerMthNewHouse { get; set; }
        public string OfficeAutomation_Document_BranchContract_AvgPerMthNewCustom { get; set; }
        public string OfficeAutomation_Document_BranchContract_AvgPerMthTakeWath { get; set; }
        public string OfficeAutomation_Document_BranchContract_SecondTeGongEndDate { get; set; }

    }

}
