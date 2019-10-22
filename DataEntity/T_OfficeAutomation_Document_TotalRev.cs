using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 新分行总启费用申请表
    /// </summary>
    public class T_OfficeAutomation_Document_TotalRev
    {
        private Guid _OfficeAutomation_Document_TotalRev_ID;
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_TotalRev_ID
        {
            get { return _OfficeAutomation_Document_TotalRev_ID; }
            set { _OfficeAutomation_Document_TotalRev_ID = value; }
        }

        private Guid _OfficeAutomation_Document_TotalRev_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_TotalRev_MainID
        {
            get { return _OfficeAutomation_Document_TotalRev_MainID; }
            set { _OfficeAutomation_Document_TotalRev_MainID = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_Apply;
        /// <summary>
        /// 发文人员
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_Apply
        {
            get { return _OfficeAutomation_Document_TotalRev_Apply; }
            set { _OfficeAutomation_Document_TotalRev_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_TotalRev_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_TotalRev_ApplyDate
        {
            get { return _OfficeAutomation_Document_TotalRev_ApplyDate; }
            set { _OfficeAutomation_Document_TotalRev_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_ApplyID
        {
            get { return _OfficeAutomation_Document_TotalRev_ApplyID; }
            set { _OfficeAutomation_Document_TotalRev_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_Department
        {
            get { return _OfficeAutomation_Document_TotalRev_Department; }
            set { _OfficeAutomation_Document_TotalRev_Department = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_Subject;
        /// <summary>
        /// 文件主题
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_Subject
        {
            get { return _OfficeAutomation_Document_TotalRev_Subject; }
            set { _OfficeAutomation_Document_TotalRev_Subject = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_ReplyPhone
        {
            get { return _OfficeAutomation_Document_TotalRev_ReplyPhone; }
            set { _OfficeAutomation_Document_TotalRev_ReplyPhone = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ReplyFax;

        public string OfficeAutomation_Document_TotalRev_ReplyFax
        {
            get { return _OfficeAutomation_Document_TotalRev_ReplyFax; }
            set { _OfficeAutomation_Document_TotalRev_ReplyFax = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_Address;
        /// <summary>
        /// 营运地点
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_Address
        {
            get { return _OfficeAutomation_Document_TotalRev_Address; }
            set { _OfficeAutomation_Document_TotalRev_Address = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_BranchName;
        /// <summary>
        /// 分行命名
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_BranchName
        {
            get { return _OfficeAutomation_Document_TotalRev_BranchName; }
            set { _OfficeAutomation_Document_TotalRev_BranchName = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_BSquare;
        /// <summary>
        /// 建筑面积
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_BSquare
        {
            get { return _OfficeAutomation_Document_TotalRev_BSquare; }
            set { _OfficeAutomation_Document_TotalRev_BSquare = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_CSquare;
        /// <summary>
        /// 实用面积
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_CSquare
        {
            get { return _OfficeAutomation_Document_TotalRev_CSquare; }
            set { _OfficeAutomation_Document_TotalRev_CSquare = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_Rent;
        /// <summary>
        /// 租金
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_Rent
        {
            get { return _OfficeAutomation_Document_TotalRev_Rent; }
            set { _OfficeAutomation_Document_TotalRev_Rent = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_Percent;
        /// <summary>
        /// 每年递增额
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_Percent
        {
            get { return _OfficeAutomation_Document_TotalRev_Percent; }
            set { _OfficeAutomation_Document_TotalRev_Percent = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_1hYear;
        /// <summary>
        /// 第1年金额
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_1hYear
        {
            get { return _OfficeAutomation_Document_TotalRev_1hYear; }
            set { _OfficeAutomation_Document_TotalRev_1hYear = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_2hYear;
        /// <summary>
        /// 第2年金额
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_2hYear
        {
            get { return _OfficeAutomation_Document_TotalRev_2hYear; }
            set { _OfficeAutomation_Document_TotalRev_2hYear = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_3hYear;
        /// <summary>
        /// 第3年金额
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_3hYear
        {
            get { return _OfficeAutomation_Document_TotalRev_3hYear; }
            set { _OfficeAutomation_Document_TotalRev_3hYear = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_4hYear;
        /// <summary>
        /// 第5年金额
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_4hYear
        {
            get { return _OfficeAutomation_Document_TotalRev_4hYear; }
            set { _OfficeAutomation_Document_TotalRev_4hYear = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_5hYear;
        /// <summary>
        /// 第5年金额
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_5hYear
        {
            get { return _OfficeAutomation_Document_TotalRev_5hYear; }
            set { _OfficeAutomation_Document_TotalRev_5hYear = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_RentYear;
        /// <summary>
        /// 租赁期（年）
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_RentYear
        {
            get { return _OfficeAutomation_Document_TotalRev_RentYear; }
            set { _OfficeAutomation_Document_TotalRev_RentYear = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_RentMonth;
        /// <summary>
        /// 租赁期（月）
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_RentMonth
        {
            get { return _OfficeAutomation_Document_TotalRev_RentMonth; }
            set { _OfficeAutomation_Document_TotalRev_RentMonth = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_RentBeginDate;
        /// <summary>
        /// 租赁起始期
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_RentBeginDate
        {
            get { return _OfficeAutomation_Document_TotalRev_RentBeginDate; }
            set { _OfficeAutomation_Document_TotalRev_RentBeginDate = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_RentEndDate;
        /// <summary>
        /// 租赁结束期
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_RentEndDate
        {
            get { return _OfficeAutomation_Document_TotalRev_RentEndDate; }
            set { _OfficeAutomation_Document_TotalRev_RentEndDate = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_OBeginDate;
        /// <summary>
        /// 免租起始期
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_OBeginDate
        {
            get { return _OfficeAutomation_Document_TotalRev_OBeginDate; }
            set { _OfficeAutomation_Document_TotalRev_OBeginDate = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_OEndDate;
        /// <summary>
        /// 免租结束期
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_OEndDate
        {
            get { return _OfficeAutomation_Document_TotalRev_OEndDate; }
            set { _OfficeAutomation_Document_TotalRev_OEndDate = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_OCount;
        /// <summary>
        /// 免租天数
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_OCount
        {
            get { return _OfficeAutomation_Document_TotalRev_OCount; }
            set { _OfficeAutomation_Document_TotalRev_OCount = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_McoastMonth;
        /// <summary>
        /// 管理费/月
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_McoastMonth
        {
            get { return _OfficeAutomation_Document_TotalRev_McoastMonth; }
            set { _OfficeAutomation_Document_TotalRev_McoastMonth = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_Mcoast;
        /// <summary>
        /// 管理费
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_Mcoast
        {
            get { return _OfficeAutomation_Document_TotalRev_Mcoast; }
            set { _OfficeAutomation_Document_TotalRev_Mcoast = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_MProvide;
        /// <summary>
        /// 管理费提供方
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_MProvide
        {
            get { return _OfficeAutomation_Document_TotalRev_MProvide; }
            set { _OfficeAutomation_Document_TotalRev_MProvide = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_WaterCost;
        /// <summary>
        /// 水费
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_WaterCost
        {
            get { return _OfficeAutomation_Document_TotalRev_WaterCost; }
            set { _OfficeAutomation_Document_TotalRev_WaterCost = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ElectCost;
        /// <summary>
        /// 电费
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_ElectCost
        {
            get { return _OfficeAutomation_Document_TotalRev_ElectCost; }
            set { _OfficeAutomation_Document_TotalRev_ElectCost = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_WEProvide;
        /// <summary>
        /// 水电费提供方
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_WEProvide
        {
            get { return _OfficeAutomation_Document_TotalRev_WEProvide; }
            set { _OfficeAutomation_Document_TotalRev_WEProvide = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_Tbranch;
        /// <summary>
        /// 总启分行
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_Tbranch
        {
            get { return _OfficeAutomation_Document_TotalRev_Tbranch; }
            set { _OfficeAutomation_Document_TotalRev_Tbranch = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_Tcoast;
        /// <summary>
        /// 总启费用
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_Tcoast
        {
            get { return _OfficeAutomation_Document_TotalRev_Tcoast; }
            set { _OfficeAutomation_Document_TotalRev_Tcoast = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_1BC;
        /// <summary>
        /// 第一部分预算费
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_1BC
        {
            get { return _OfficeAutomation_Document_TotalRev_1BC; }
            set { _OfficeAutomation_Document_TotalRev_1BC = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_FirstRentBudget;
        /// <summary>
        /// 首月租金预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_FirstRentBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_FirstRentBudget; }
            set { _OfficeAutomation_Document_TotalRev_FirstRentBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_RentTaxBudget;
        /// <summary>
        /// 租赁印花税预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_RentTaxBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_RentTaxBudget; }
            set { _OfficeAutomation_Document_TotalRev_RentTaxBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_FirstMonthBudget;
        /// <summary>
        /// 首月管理费预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_FirstMonthBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_FirstMonthBudget; }
            set { _OfficeAutomation_Document_TotalRev_FirstMonthBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_DepositBudget;
        /// <summary>
        /// 租赁按金预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_DepositBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_DepositBudget; }
            set { _OfficeAutomation_Document_TotalRev_DepositBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_WEDBudget;
        /// <summary>
        /// 水电按金预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_WEDBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_WEDBudget; }
            set { _OfficeAutomation_Document_TotalRev_WEDBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ManageBudget;
        /// <summary>
        /// 管理费按金预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_ManageBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_ManageBudget; }
            set { _OfficeAutomation_Document_TotalRev_ManageBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_SendBudget;
        /// <summary>
        /// 顶手费预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_SendBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_SendBudget; }
            set { _OfficeAutomation_Document_TotalRev_SendBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_OtherBudget;
        /// <summary>
        /// 其它按金预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_OtherBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_OtherBudget; }
            set { _OfficeAutomation_Document_TotalRev_OtherBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_1SumBudget;
        /// <summary>
        /// 第一部分合计预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_1SumBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_1SumBudget; }
            set { _OfficeAutomation_Document_TotalRev_1SumBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_2BC;
        /// <summary>
        /// 第二部分预算费
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_2BC
        {
            get { return _OfficeAutomation_Document_TotalRev_2BC; }
            set { _OfficeAutomation_Document_TotalRev_2BC = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_PhotoBudget;
        /// <summary>
        /// 装修图预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_PhotoBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_PhotoBudget; }
            set { _OfficeAutomation_Document_TotalRev_PhotoBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_DecorateProjectBudget;
        /// <summary>
        /// 装修工程预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_DecorateProjectBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_DecorateProjectBudget; }
            set { _OfficeAutomation_Document_TotalRev_DecorateProjectBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget;
        /// <summary>
        /// 电话及监控工程预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget; }
            set { _OfficeAutomation_Document_TotalRev_PhoneAndMonitoringBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_FurnitureBudget;
        /// <summary>
        /// 办公家具预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_FurnitureBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_FurnitureBudget; }
            set { _OfficeAutomation_Document_TotalRev_FurnitureBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_StationeryBudget;
        /// <summary>
        /// 办公文具、设备预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_StationeryBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_StationeryBudget; }
            set { _OfficeAutomation_Document_TotalRev_StationeryBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_AirConditioningBudget;
        /// <summary>
        /// 空调设备预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_AirConditioningBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_AirConditioningBudget; }
            set { _OfficeAutomation_Document_TotalRev_AirConditioningBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ConputerBudget;
        /// <summary>
        /// 电脑设备预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_ConputerBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_ConputerBudget; }
            set { _OfficeAutomation_Document_TotalRev_ConputerBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_SignatureBudget;
        /// <summary>
        /// 招牌灯箱预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_SignatureBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_SignatureBudget; }
            set { _OfficeAutomation_Document_TotalRev_SignatureBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_CertificateBudget;
        /// <summary>
        /// 证照、架、字等预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_CertificateBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_CertificateBudget; }
            set { _OfficeAutomation_Document_TotalRev_CertificateBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_OpticalFiberBudget;
        /// <summary>
        /// 光纤工程预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_OpticalFiberBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_OpticalFiberBudget; }
            set { _OfficeAutomation_Document_TotalRev_OpticalFiberBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ForestBudget;
        /// <summary>
        /// 开荒清洁费预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_ForestBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_ForestBudget; }
            set { _OfficeAutomation_Document_TotalRev_ForestBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_MonthCleanBudget;
        /// <summary>
        /// 月清洁费预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_MonthCleanBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_MonthCleanBudget; }
            set { _OfficeAutomation_Document_TotalRev_MonthCleanBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_YearInsuranceBudget;
        /// <summary>
        /// 年保险费预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_YearInsuranceBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_YearInsuranceBudget; }
            set { _OfficeAutomation_Document_TotalRev_YearInsuranceBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_RegistrationBudget;
        /// <summary>
        /// 办证费预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_RegistrationBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_RegistrationBudget; }
            set { _OfficeAutomation_Document_TotalRev_RegistrationBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_2SumBudget;
        /// <summary>
        /// 第二部分合计预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_2SumBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_2SumBudget; }
            set { _OfficeAutomation_Document_TotalRev_2SumBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_3BC;
        /// <summary>
        /// 第三部分预算费
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_3BC
        {
            get { return _OfficeAutomation_Document_TotalRev_3BC; }
            set { _OfficeAutomation_Document_TotalRev_3BC = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_BasisBudget;
        /// <summary>
        /// 基础水电拉设费用预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_BasisBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_BasisBudget; }
            set { _OfficeAutomation_Document_TotalRev_BasisBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_AddElectricBudget;
        /// <summary>
        /// 电力增容费用预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_AddElectricBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_AddElectricBudget; }
            set { _OfficeAutomation_Document_TotalRev_AddElectricBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_FireBudget;
        /// <summary>
        /// 消防报建预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_FireBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_FireBudget; }
            set { _OfficeAutomation_Document_TotalRev_FireBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_3SumBudget;
        /// <summary>
        /// 第三部分合计预算
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_3SumBudget
        {
            get { return _OfficeAutomation_Document_TotalRev_3SumBudget; }
            set { _OfficeAutomation_Document_TotalRev_3SumBudget = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_FirstRentRemark;
        /// <summary>
        /// 首月租金备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_FirstRentRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_FirstRentRemark; }
            set { _OfficeAutomation_Document_TotalRev_FirstRentRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_RentTaxRemark;
        /// <summary>
        /// 租赁印花税备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_RentTaxRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_RentTaxRemark; }
            set { _OfficeAutomation_Document_TotalRev_RentTaxRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_FirstMonthRemark;
        /// <summary>
        /// 首月管理费备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_FirstMonthRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_FirstMonthRemark; }
            set { _OfficeAutomation_Document_TotalRev_FirstMonthRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_DepositRemark;
        /// <summary>
        /// 租赁按金备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_DepositRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_DepositRemark; }
            set { _OfficeAutomation_Document_TotalRev_DepositRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_WEDRemark;
        /// <summary>
        /// 水电按金备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_WEDRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_WEDRemark; }
            set { _OfficeAutomation_Document_TotalRev_WEDRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ManageRemark;
        /// <summary>
        /// 管理费按金备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_ManageRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_ManageRemark; }
            set { _OfficeAutomation_Document_TotalRev_ManageRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_SendRemark;
        /// <summary>
        /// 顶手费备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_SendRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_SendRemark; }
            set { _OfficeAutomation_Document_TotalRev_SendRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_OtherRemark;
        /// <summary>
        /// 其它按金备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_OtherRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_OtherRemark; }
            set { _OfficeAutomation_Document_TotalRev_OtherRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_PhotoRemark;
        /// <summary>
        /// 装修图备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_PhotoRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_PhotoRemark; }
            set { _OfficeAutomation_Document_TotalRev_PhotoRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_DecorateProjectRemark;
        /// <summary>
        /// 装修工程备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_DecorateProjectRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_DecorateProjectRemark; }
            set { _OfficeAutomation_Document_TotalRev_DecorateProjectRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark;
        /// <summary>
        /// 电话及监控工程备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark; }
            set { _OfficeAutomation_Document_TotalRev_PhoneAndMonitoringRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_FurnitureRemark;
        /// <summary>
        /// 办公家具备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_FurnitureRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_FurnitureRemark; }
            set { _OfficeAutomation_Document_TotalRev_FurnitureRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_StationeryRemark;
        /// <summary>
        /// 办公文具、设备备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_StationeryRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_StationeryRemark; }
            set { _OfficeAutomation_Document_TotalRev_StationeryRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_AirConditioningRemark;
        /// <summary>
        /// 空调设备备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_AirConditioningRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_AirConditioningRemark; }
            set { _OfficeAutomation_Document_TotalRev_AirConditioningRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ConputerRemark;
        /// <summary>
        /// 电脑设备备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_ConputerRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_ConputerRemark; }
            set { _OfficeAutomation_Document_TotalRev_ConputerRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_SignatureRemark;
        /// <summary>
        /// 招牌灯箱备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_SignatureRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_SignatureRemark; }
            set { _OfficeAutomation_Document_TotalRev_SignatureRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_CertificateRemark;
        /// <summary>
        /// 证照、架、字等备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_CertificateRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_CertificateRemark; }
            set { _OfficeAutomation_Document_TotalRev_CertificateRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_OpticalFiberRemark;
        /// <summary>
        /// 光纤工程备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_OpticalFiberRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_OpticalFiberRemark; }
            set { _OfficeAutomation_Document_TotalRev_OpticalFiberRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_ForestRemark;
        /// <summary>
        /// 开荒清洁费备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_ForestRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_ForestRemark; }
            set { _OfficeAutomation_Document_TotalRev_ForestRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_MonthCleanRemark;
        /// <summary>
        /// 月清洁费备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_MonthCleanRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_MonthCleanRemark; }
            set { _OfficeAutomation_Document_TotalRev_MonthCleanRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_YearInsuranceRemark;
        /// <summary>
        /// 年保险费备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_YearInsuranceRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_YearInsuranceRemark; }
            set { _OfficeAutomation_Document_TotalRev_YearInsuranceRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_RegistrationRemark;
        /// <summary>
        /// 办证费备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_RegistrationRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_RegistrationRemark; }
            set { _OfficeAutomation_Document_TotalRev_RegistrationRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_BasisRemark;
        /// <summary>
        /// 基础水电拉设费用备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_BasisRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_BasisRemark; }
            set { _OfficeAutomation_Document_TotalRev_BasisRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_AddElectricRemark;
        /// <summary>
        /// 电力增容费用备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_AddElectricRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_AddElectricRemark; }
            set { _OfficeAutomation_Document_TotalRev_AddElectricRemark = value; }
        }

        private string _OfficeAutomation_Document_TotalRev_FireRemark;
        /// <summary>
        /// 消防报建备注
        /// </summary>
        public string OfficeAutomation_Document_TotalRev_FireRemark
        {
            get { return _OfficeAutomation_Document_TotalRev_FireRemark; }
            set { _OfficeAutomation_Document_TotalRev_FireRemark = value; }
        }

        //第三部分其他费用(用||分隔)
        public string OfficeAutomation_Document_TotalRev_Part3OtherBudget { get; set; }
        //第三部分其他费用备注(用||分隔)
        public string OfficeAutomation_Document_TotalRev_Part3OtherRemark { get; set; }
    }
}
