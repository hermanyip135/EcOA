using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 分行续约申请报告
    /// </summary>
    public class T_OfficeAutomation_Document_BranchContract
    {
        private Guid _OfficeAutomation_Document_BranchContract_ID;
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_BranchContract_ID
        {
            get { return _OfficeAutomation_Document_BranchContract_ID; }
            set { _OfficeAutomation_Document_BranchContract_ID = value; }
        }

        private Guid _OfficeAutomation_Document_BranchContract_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_BranchContract_MainID
        {
            get { return _OfficeAutomation_Document_BranchContract_MainID; }
            set { _OfficeAutomation_Document_BranchContract_MainID = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_Apply;
        /// <summary>
        /// 申请跟进人
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Apply
        {
            get { return _OfficeAutomation_Document_BranchContract_Apply; }
            set { _OfficeAutomation_Document_BranchContract_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_BranchContract_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_BranchContract_ApplyDate
        {
            get { return _OfficeAutomation_Document_BranchContract_ApplyDate; }
            set { _OfficeAutomation_Document_BranchContract_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ApplyID
        {
            get { return _OfficeAutomation_Document_BranchContract_ApplyID; }
            set { _OfficeAutomation_Document_BranchContract_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Department
        {
            get { return _OfficeAutomation_Document_BranchContract_Department; }
            set { _OfficeAutomation_Document_BranchContract_Department = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_Telephone;
        /// <summary>
        /// 分行电话
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Telephone
        {
            get { return _OfficeAutomation_Document_BranchContract_Telephone; }
            set { _OfficeAutomation_Document_BranchContract_Telephone = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_Name;
        /// <summary>
        /// 分行名
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Name
        {
            get { return _OfficeAutomation_Document_BranchContract_Name; }
            set { _OfficeAutomation_Document_BranchContract_Name = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ApplyPhone;
        /// <summary>
        /// 跟进人联系手机
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ApplyPhone
        {
            get { return _OfficeAutomation_Document_BranchContract_ApplyPhone; }
            set { _OfficeAutomation_Document_BranchContract_ApplyPhone = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_Branch;
        /// <summary>
        /// 分行情况（分行）
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Branch
        {
            get { return _OfficeAutomation_Document_BranchContract_Branch; }
            set { _OfficeAutomation_Document_BranchContract_Branch = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ContractEndDate;
        /// <summary>
        /// 租约到期日
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ContractEndDate
        {
            get { return _OfficeAutomation_Document_BranchContract_ContractEndDate; }
            set { _OfficeAutomation_Document_BranchContract_ContractEndDate = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_LastMonthRent;
        /// <summary>
        /// 最后一个月含税租金
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LastMonthRent
        {
            get { return _OfficeAutomation_Document_BranchContract_LastMonthRent; }
            set { _OfficeAutomation_Document_BranchContract_LastMonthRent = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_FirstYearRent;
        /// <summary>
        /// 续租首年含税月租金
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_FirstYearRent
        {
            get { return _OfficeAutomation_Document_BranchContract_FirstYearRent; }
            set { _OfficeAutomation_Document_BranchContract_FirstYearRent = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_RentAmplitude;
        /// <summary>
        /// 租金增加或减少幅度
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_RentAmplitude
        {
            get { return _OfficeAutomation_Document_BranchContract_RentAmplitude; }
            set { _OfficeAutomation_Document_BranchContract_RentAmplitude = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ContractPeriod;
        /// <summary>
        /// 计划续约期限（年）
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ContractPeriod
        {
            get { return _OfficeAutomation_Document_BranchContract_ContractPeriod; }
            set { _OfficeAutomation_Document_BranchContract_ContractPeriod = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_BranchSuqare;
        /// <summary>
        /// 分行面积
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_BranchSuqare
        {
            get { return _OfficeAutomation_Document_BranchContract_BranchSuqare; }
            set { _OfficeAutomation_Document_BranchContract_BranchSuqare = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_BranchAddress;
        /// <summary>
        /// 分行地址
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_BranchAddress
        {
            get { return _OfficeAutomation_Document_BranchContract_BranchAddress; }
            set { _OfficeAutomation_Document_BranchContract_BranchAddress = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_StampDuty;
        /// <summary>
        /// 租赁登记印花税
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_StampDuty
        {
            get { return _OfficeAutomation_Document_BranchContract_StampDuty; }
            set { _OfficeAutomation_Document_BranchContract_StampDuty = value; }
        }

        private bool _OfficeAutomation_Document_BranchContract_RentDP;
        /// <summary>
        /// 租金发票提供方
        /// </summary>
        public bool OfficeAutomation_Document_BranchContract_RentDP
        {
            get { return _OfficeAutomation_Document_BranchContract_RentDP; }
            set { _OfficeAutomation_Document_BranchContract_RentDP = value; }
        }

        private bool _OfficeAutomation_Document_BranchContract_ManagementDP;
        /// <summary>
        /// 管理费发票提供方
        /// </summary>
        public bool OfficeAutomation_Document_BranchContract_ManagementDP
        {
            get { return _OfficeAutomation_Document_BranchContract_ManagementDP; }
            set { _OfficeAutomation_Document_BranchContract_ManagementDP = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ManagementDPAnother;
        /// <summary>
        /// 其它管理费发票提供方
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ManagementDPAnother
        {
            get { return _OfficeAutomation_Document_BranchContract_ManagementDPAnother; }
            set { _OfficeAutomation_Document_BranchContract_ManagementDPAnother = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_LeaseDeposit;
        /// <summary>
        /// 租赁按金
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LeaseDeposit
        {
            get { return _OfficeAutomation_Document_BranchContract_LeaseDeposit; }
            set { _OfficeAutomation_Document_BranchContract_LeaseDeposit = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_OtherFees;
        /// <summary>
        /// 其他费用
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_OtherFees
        {
            get { return _OfficeAutomation_Document_BranchContract_OtherFees; }
            set { _OfficeAutomation_Document_BranchContract_OtherFees = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ResponsibleName;
        /// <summary>
        /// 责任人姓名
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ResponsibleName
        {
            get { return _OfficeAutomation_Document_BranchContract_ResponsibleName; }
            set { _OfficeAutomation_Document_BranchContract_ResponsibleName = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ResponsibleCall;
        /// <summary>
        /// 责任人电话
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ResponsibleCall
        {
            get { return _OfficeAutomation_Document_BranchContract_ResponsibleCall; }
            set { _OfficeAutomation_Document_BranchContract_ResponsibleCall = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_RecentlyBeginData;
        /// <summary>
        /// 最近12个月起始日期
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_RecentlyBeginData
        {
            get { return _OfficeAutomation_Document_BranchContract_RecentlyBeginData; }
            set { _OfficeAutomation_Document_BranchContract_RecentlyBeginData = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_RecentlyEndData;
        /// <summary>
        /// 最近12个月结束日期
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_RecentlyEndData
        {
            get { return _OfficeAutomation_Document_BranchContract_RecentlyEndData; }
            set { _OfficeAutomation_Document_BranchContract_RecentlyEndData = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_CumulativePerformance;
        /// <summary>
        /// 累计业绩
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_CumulativePerformance
        {
            get { return _OfficeAutomation_Document_BranchContract_CumulativePerformance; }
            set { _OfficeAutomation_Document_BranchContract_CumulativePerformance = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_CumulativeProfits;
        /// <summary>
        /// 累计利润
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_CumulativeProfits
        {
            get { return _OfficeAutomation_Document_BranchContract_CumulativeProfits; }
            set { _OfficeAutomation_Document_BranchContract_CumulativeProfits = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_LastYear;
        /// <summary>
        /// 上一年度
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LastYear
        {
            get { return _OfficeAutomation_Document_BranchContract_LastYear; }
            set { _OfficeAutomation_Document_BranchContract_LastYear = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_LastYearResults;
        /// <summary>
        /// 上一年度累计业绩
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LastYearResults
        {
            get { return _OfficeAutomation_Document_BranchContract_LastYearResults; }
            set { _OfficeAutomation_Document_BranchContract_LastYearResults = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_LastYearProfit;
        /// <summary>
        /// 上一年度累计盈利
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LastYearProfit
        {
            get { return _OfficeAutomation_Document_BranchContract_LastYearProfit; }
            set { _OfficeAutomation_Document_BranchContract_LastYearProfit = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ThisYearAsOfData;
        /// <summary>
        /// 分行本年度申请开始日期
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ThisYearAsOfData
        {
            get { return _OfficeAutomation_Document_BranchContract_ThisYearAsOfData; }
            set { _OfficeAutomation_Document_BranchContract_ThisYearAsOfData = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData;
        /// <summary>
        /// 分行本年度申请截至日期
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData
        {
            get { return _OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData; }
            set { _OfficeAutomation_Document_BranchContract_ThisYearAsOfEndData = value; }
        }


        private string _OfficeAutomation_Document_BranchContract_ThisYearCP;
        /// <summary>
        /// 分行本年度累计业绩
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ThisYearCP
        {
            get { return _OfficeAutomation_Document_BranchContract_ThisYearCP; }
            set { _OfficeAutomation_Document_BranchContract_ThisYearCP = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_ThisYearPS2;
        /// <summary>
        /// 分行本年度累计利润
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_ThisYearPS2
        {
            get { return _OfficeAutomation_Document_BranchContract_ThisYearPS2; }
            set { _OfficeAutomation_Document_BranchContract_ThisYearPS2 = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_AmortizationBeginData;
        /// <summary>
        /// 分行摊销余额截至日期
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AmortizationBeginData
        {
            get { return _OfficeAutomation_Document_BranchContract_AmortizationBeginData; }
            set { _OfficeAutomation_Document_BranchContract_AmortizationBeginData = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_AmortizationMoney;
        /// <summary>
        /// 分行摊销金额
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AmortizationMoney
        {
            get { return _OfficeAutomation_Document_BranchContract_AmortizationMoney; }
            set { _OfficeAutomation_Document_BranchContract_AmortizationMoney = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_AmortizationEndData;
        /// <summary>
        /// 分行摊销余额结束日期
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_AmortizationEndData
        {
            get { return _OfficeAutomation_Document_BranchContract_AmortizationEndData; }
            set { _OfficeAutomation_Document_BranchContract_AmortizationEndData = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_StatisticalBeginData;
        /// <summary>
        /// 主打盘占率统计起始日
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_StatisticalBeginData
        {
            get { return _OfficeAutomation_Document_BranchContract_StatisticalBeginData; }
            set { _OfficeAutomation_Document_BranchContract_StatisticalBeginData = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_StatisticalEndData;
        /// <summary>
        /// 主打盘占率统计结束日
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_StatisticalEndData
        {
            get { return _OfficeAutomation_Document_BranchContract_StatisticalEndData; }
            set { _OfficeAutomation_Document_BranchContract_StatisticalEndData = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumCount;
        /// <summary>
        /// 合计总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumCount
        {
            get { return _OfficeAutomation_Document_BranchContract_SumCount; }
            set { _OfficeAutomation_Document_BranchContract_SumCount = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumGzspsNum;
        /// <summary>
        /// 中原宗数总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumGzspsNum
        {
            get { return _OfficeAutomation_Document_BranchContract_SumGzspsNum; }
            set { _OfficeAutomation_Document_BranchContract_SumGzspsNum = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumGzspsRate;
        /// <summary>
        /// 中原市占率总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumGzspsRate
        {
            get { return _OfficeAutomation_Document_BranchContract_SumGzspsRate; }
            set { _OfficeAutomation_Document_BranchContract_SumGzspsRate = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumEveryNum;
        /// <summary>
        /// 满堂红宗数总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumEveryNum
        {
            get { return _OfficeAutomation_Document_BranchContract_SumEveryNum; }
            set { _OfficeAutomation_Document_BranchContract_SumEveryNum = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumEveryRate;
        /// <summary>
        /// 满堂红市占率总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumEveryRate
        {
            get { return _OfficeAutomation_Document_BranchContract_SumEveryRate; }
            set { _OfficeAutomation_Document_BranchContract_SumEveryRate = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumRichNum;
        /// <summary>
        /// 合富宗数总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumRichNum
        {
            get { return _OfficeAutomation_Document_BranchContract_SumRichNum; }
            set { _OfficeAutomation_Document_BranchContract_SumRichNum = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumRichRate;
        /// <summary>
        /// 合富市占率总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumRichRate
        {
            get { return _OfficeAutomation_Document_BranchContract_SumRichRate; }
            set { _OfficeAutomation_Document_BranchContract_SumRichRate = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumYuFengNum;
        /// <summary>
        /// 裕丰宗数总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumYuFengNum
        {
            get { return _OfficeAutomation_Document_BranchContract_SumYuFengNum; }
            set { _OfficeAutomation_Document_BranchContract_SumYuFengNum = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumYuFengRate;
        /// <summary>
        /// 裕丰市占率总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumYuFengRate
        {
            get { return _OfficeAutomation_Document_BranchContract_SumYuFengRate; }
            set { _OfficeAutomation_Document_BranchContract_SumYuFengRate = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumFreeNum;
        /// <summary>
        /// 自行交易宗数总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumFreeNum
        {
            get { return _OfficeAutomation_Document_BranchContract_SumFreeNum; }
            set { _OfficeAutomation_Document_BranchContract_SumFreeNum = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumFreeRate;
        /// <summary>
        /// 自行交易市占率总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumFreeRate
        {
            get { return _OfficeAutomation_Document_BranchContract_SumFreeRate; }
            set { _OfficeAutomation_Document_BranchContract_SumFreeRate = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumOtherNum;
        /// <summary>
        /// 其它交易宗数总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumOtherNum
        {
            get { return _OfficeAutomation_Document_BranchContract_SumOtherNum; }
            set { _OfficeAutomation_Document_BranchContract_SumOtherNum = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumOtherRate;
        /// <summary>
        /// 其它交易市占率总计
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_SumOtherRate
        {
            get { return _OfficeAutomation_Document_BranchContract_SumOtherRate; }
            set { _OfficeAutomation_Document_BranchContract_SumOtherRate = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_OtherSummy;
        /// <summary>
        /// 其实费用详述
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_OtherSummy
        {
            get { return _OfficeAutomation_Document_BranchContract_OtherSummy; }
            set { _OfficeAutomation_Document_BranchContract_OtherSummy = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_Reason;
        /// <summary>
        /// 续租理由
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_Reason
        {
            get { return _OfficeAutomation_Document_BranchContract_Reason; }
            set { _OfficeAutomation_Document_BranchContract_Reason = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumQFangNum;

        public string OfficeAutomation_Document_BranchContract_SumQFangNum
        {
            get { return _OfficeAutomation_Document_BranchContract_SumQFangNum; }
            set { _OfficeAutomation_Document_BranchContract_SumQFangNum = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_SumQFangRate;

        public string OfficeAutomation_Document_BranchContract_SumQFangRate
        {
            get { return _OfficeAutomation_Document_BranchContract_SumQFangRate; }
            set { _OfficeAutomation_Document_BranchContract_SumQFangRate = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_AreaPart;

        public string OfficeAutomation_Document_BranchContract_AreaPart
        {
            get { return _OfficeAutomation_Document_BranchContract_AreaPart; }
            set { _OfficeAutomation_Document_BranchContract_AreaPart = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_AreaSumOfBuild;

        public string OfficeAutomation_Document_BranchContract_AreaSumOfBuild
        {
            get { return _OfficeAutomation_Document_BranchContract_AreaSumOfBuild; }
            set { _OfficeAutomation_Document_BranchContract_AreaSumOfBuild = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_AreaCNo;

        public string OfficeAutomation_Document_BranchContract_AreaCNo
        {
            get { return _OfficeAutomation_Document_BranchContract_AreaCNo; }
            set { _OfficeAutomation_Document_BranchContract_AreaCNo = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_AreaCRate;

        public string OfficeAutomation_Document_BranchContract_AreaCRate
        {
            get { return _OfficeAutomation_Document_BranchContract_AreaCRate; }
            set { _OfficeAutomation_Document_BranchContract_AreaCRate = value; }
        }
        public string OfficeAutomation_Document_BranchContract_LossAgreementContent { get; set; }
        public bool? OfficeAutomation_Document_BranchContract_LossAgreementPS { get; set; }
        public bool? OfficeAutomation_Document_BranchContract_LossAgreementAward { get; set; }
        public int? OfficeAutomation_Document_BranchContract_LossAgreementPercentage { get; set; }
        public int? OfficeAutomation_Document_BranchContract_LossAgreementCharge { get; set; }

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
