using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 员工购租楼宇申报及免佣福利申请表
    /// </summary>
    public class T_OfficeAutomation_Document_BuyBuilding
    {
        private Guid officeAutomation_Document_BuyBuilding_ID;
        /// <summary>
        ///主键
        /// </summary>
        public Guid OfficeAutomation_Document_BuyBuilding_ID
        {
            get { return officeAutomation_Document_BuyBuilding_ID; }
            set { officeAutomation_Document_BuyBuilding_ID = value; }
        }

        private Guid officeAutomation_Document_BuyBuilding_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_BuyBuilding_MainID
        {
            get { return officeAutomation_Document_BuyBuilding_MainID; }
            set { officeAutomation_Document_BuyBuilding_MainID = value; }
        }

        private string officeAutomation_Document_BuyBuilding_Apply;
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_Apply
        {
            get { return officeAutomation_Document_BuyBuilding_Apply; }
            set { officeAutomation_Document_BuyBuilding_Apply = value; }
        }

        private DateTime officeAutomation_Document_BuyBuilding_ApplyDate;
        /// <summary>
        /// 填写日期
        /// </summary>
        public DateTime OfficeAutomation_Document_BuyBuilding_ApplyDate
        {
            get { return officeAutomation_Document_BuyBuilding_ApplyDate; }
            set { officeAutomation_Document_BuyBuilding_ApplyDate = value; }
        }

        private string officeAutomation_Document_BuyBuilding_ApplyForName;
        /// <summary>
        /// 申报人姓名
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_ApplyForName
        {
            get { return officeAutomation_Document_BuyBuilding_ApplyForName; }
            set { officeAutomation_Document_BuyBuilding_ApplyForName = value; }
        }

        private string officeAutomation_Document_BuyBuilding_ApplyForCode;
        /// <summary>
        /// 申报人工号
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_ApplyForCode
        {
            get { return officeAutomation_Document_BuyBuilding_ApplyForCode; }
            set { officeAutomation_Document_BuyBuilding_ApplyForCode = value; }
        }

        private string officeAutomation_Document_BuyBuilding_IDNumber;
        /// <summary>
        /// 申报人身份证号
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_IDNumber
        {
            get { return officeAutomation_Document_BuyBuilding_IDNumber; }
            set { officeAutomation_Document_BuyBuilding_IDNumber = value; }
        }

        private string officeAutomation_Document_BuyBuilding_Department;
        /// <summary>
        /// 申报人部门
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_Department
        {
            get { return officeAutomation_Document_BuyBuilding_Department; }
            set { officeAutomation_Document_BuyBuilding_Department = value; }
        }

        private string officeAutomation_Document_BuyBuilding_Position;
        /// <summary>
        /// 申报人职位
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_Position
        {
            get { return officeAutomation_Document_BuyBuilding_Position; }
            set { officeAutomation_Document_BuyBuilding_Position = value; }
        }

        private DateTime officeAutomation_Document_BuyBuilding_EntryDate;
        /// <summary>
        /// 申报人入职日期
        /// </summary>
        public DateTime OfficeAutomation_Document_BuyBuilding_EntryDate
        {
            get { return officeAutomation_Document_BuyBuilding_EntryDate; }
            set { officeAutomation_Document_BuyBuilding_EntryDate = value; }
        }

        private DateTime officeAutomation_Document_BuyBuilding_PositiveDate;
        /// <summary>
        /// 申报人转正日期
        /// </summary>
        public DateTime OfficeAutomation_Document_BuyBuilding_PositiveDate
        {
            get { return officeAutomation_Document_BuyBuilding_PositiveDate; }
            set { officeAutomation_Document_BuyBuilding_PositiveDate = value; }
        }

        private string officeAutomation_Document_BuyBuilding_Phone;
        /// <summary>
        /// 申报人联系电话
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_Phone
        {
            get { return officeAutomation_Document_BuyBuilding_Phone; }
            set { officeAutomation_Document_BuyBuilding_Phone = value; }
        }

        private string officeAutomation_Document_BuyBuilding_ContactAddress;
        /// <summary>
        /// 申报人联系地址
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_ContactAddress
        {
            get { return officeAutomation_Document_BuyBuilding_ContactAddress; }
            set { officeAutomation_Document_BuyBuilding_ContactAddress = value; }
        }

        private int officeAutomation_Document_BuyBuilding_DealTypeID;
        /// <summary>
        /// 意向(即交易类型)
        /// </summary>
        public int OfficeAutomation_Document_BuyBuilding_DealTypeID
        {
            get { return officeAutomation_Document_BuyBuilding_DealTypeID; }
            set { officeAutomation_Document_BuyBuilding_DealTypeID = value; }
        }

        private int officeAutomation_Document_BuyBuilding_OwnerTypeID;
        /// <summary>
        /// 业权人类型主键
        /// </summary>
        public int OfficeAutomation_Document_BuyBuilding_OwnerTypeID
        {
            get { return officeAutomation_Document_BuyBuilding_OwnerTypeID; }
            set { officeAutomation_Document_BuyBuilding_OwnerTypeID = value; }
        }

        private string officeAutomation_Document_BuyBuilding_OwnerRelation;
        /// <summary>
        /// 业权人姓名关系
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_OwnerRelation
        {
            get { return officeAutomation_Document_BuyBuilding_OwnerRelation; }
            set { officeAutomation_Document_BuyBuilding_OwnerRelation = value; }
        }

        private string officeAutomation_Document_BuyBuilding_BuildingAddress;
        /// <summary>
        /// 物业位置
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_BuildingAddress
        {
            get { return officeAutomation_Document_BuyBuilding_BuildingAddress; }
            set { officeAutomation_Document_BuyBuilding_BuildingAddress = value; }
        }

        private string officeAutomation_Document_BuyBuilding_Area;
        /// <summary>
        /// 物业面积
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_Area
        {
            get { return officeAutomation_Document_BuyBuilding_Area; }
            set { officeAutomation_Document_BuyBuilding_Area = value; }
        }

        private string officeAutomation_Document_BuyBuilding_PriceRange;
        /// <summary>
        /// 价格范围
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_PriceRange
        {
            get { return officeAutomation_Document_BuyBuilding_PriceRange; }
            set { officeAutomation_Document_BuyBuilding_PriceRange = value; }
        }

        private string officeAutomation_Document_BuyBuilding_LeaseDeadline;
        /// <summary>
        /// 租赁期限
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_LeaseDeadline
        {
            get { return officeAutomation_Document_BuyBuilding_LeaseDeadline; }
            set { officeAutomation_Document_BuyBuilding_LeaseDeadline = value; }
        }

        private int officeAutomation_Document_BuyBuilding_PayTypeID;
        /// <summary>
        /// 付款方式
        /// </summary>
        public int OfficeAutomation_Document_BuyBuilding_PayTypeID
        {
            get { return officeAutomation_Document_BuyBuilding_PayTypeID; }
            set { officeAutomation_Document_BuyBuilding_PayTypeID = value; }
        }

        private string officeAutomation_Document_BuyBuilding_SpecialRequest;
        /// <summary>
        /// 其他特别要求
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_SpecialRequest
        {
            get { return officeAutomation_Document_BuyBuilding_SpecialRequest; }
            set { officeAutomation_Document_BuyBuilding_SpecialRequest = value; }
        }

        private int officeAutomation_Document_BuyBuilding_FollowTypeID;
        /// <summary>
        /// 跟进方式
        /// </summary>
        public int OfficeAutomation_Document_BuyBuilding_FollowTypeID
        {
            get { return officeAutomation_Document_BuyBuilding_FollowTypeID; }
            set { officeAutomation_Document_BuyBuilding_FollowTypeID = value; }
        }

        private string officeAutomation_Document_BuyBuilding_FreeTypeIDs;
        /// <summary>
        /// 申请项目
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_FreeTypeIDs
        {
            get { return officeAutomation_Document_BuyBuilding_FreeTypeIDs; }
            set { officeAutomation_Document_BuyBuilding_FreeTypeIDs = value; }
        }

        private string officeAutomation_Document_BuyBuilding_FollowBranch;
        /// <summary>
        /// 跟进分行
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_FollowBranch
        {
            get { return officeAutomation_Document_BuyBuilding_FollowBranch; }
            set { officeAutomation_Document_BuyBuilding_FollowBranch = value; }
        }

        private string officeAutomation_Document_BuyBuilding_FollowSales;
        /// <summary>
        /// 跟进营业员
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_FollowSales
        {
            get { return officeAutomation_Document_BuyBuilding_FollowSales; }
            set { officeAutomation_Document_BuyBuilding_FollowSales = value; }
        }

        private int officeAutomation_Document_BuyBuilding_MortgageAddressTypeID;
        /// <summary>
        /// 按揭办理地点
        /// </summary>
        public int OfficeAutomation_Document_BuyBuilding_MortgageAddressTypeID
        {
            get { return officeAutomation_Document_BuyBuilding_MortgageAddressTypeID; }
            set { officeAutomation_Document_BuyBuilding_MortgageAddressTypeID = value; }
        }

        private string officeAutomation_Document_BuyBuilding_MortgageAddressRemark;
        /// <summary>
        /// 按揭办理地点备注
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_MortgageAddressRemark
        {
            get { return officeAutomation_Document_BuyBuilding_MortgageAddressRemark; }
            set { officeAutomation_Document_BuyBuilding_MortgageAddressRemark = value; }
        }

        private string _OfficeAutomation_Document_BuyBuilding_DealBuild;

        public string OfficeAutomation_Document_BuyBuilding_DealBuild
        {
            get { return _OfficeAutomation_Document_BuyBuilding_DealBuild; }
            set { _OfficeAutomation_Document_BuyBuilding_DealBuild = value; }
        }

        private string officeAutomation_Document_BuyBuilding_PersInterestsURL;
        /// <summary>
        /// 个人利益申请表地址
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_PersInterestsURL
        {
            get { return officeAutomation_Document_BuyBuilding_PersInterestsURL; }
            set { officeAutomation_Document_BuyBuilding_PersInterestsURL = value; }
        }

        private string officeAutomation_Document_BuyBuilding_AuditNOs;
        /// <summary>
        /// 特殊审批序号
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_AuditNOs
        {
            get { return officeAutomation_Document_BuyBuilding_AuditNOs; }
            set { officeAutomation_Document_BuyBuilding_AuditNOs = value; }
        }

        private string officeAutomation_Document_BuyBuilding_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_BuyBuilding_Remark
        {
            get { return officeAutomation_Document_BuyBuilding_Remark; }
            set { officeAutomation_Document_BuyBuilding_Remark = value; }
        }
        public bool OfficeAutomation_Document_BuyBuilding_OwnerIsEmployee{ get; set; }
        public string OfficeAutomation_Document_BuyBuilding_OwnerFamilyRelation { get; set; }
        public string OfficeAutomation_Document_BuyBuilding_OwnerEmployeeCode { get; set; }

        public string OfficeAutomation_Document_BuyBuilding_DepartmentType { get; set; }
        public string OfficeAutomation_Document_BuyBuilding_FollowNo { get; set; }
        public string OfficeAutomation_Document_BuyBuilding_TransNo { get; set; }
        public string OfficeAutomation_Document_BuyBuilding_TransAddress { get; set; }
        public string OfficeAutomation_Document_BuyBuilding_TransDate { get; set; }
        public string OfficeAutomation_Document_BuyBuilding_HouseRegistrant { get; set; }
        public string OfficeAutomation_Document_BuyBuilding_IsRebate { get; set; }
        public string OfficeAutomation_Document_BuyBuilding_RebateDate { get; set; }
        public string OfficeAutomation_Document_BuyBuilding_Instruction { get; set; }
    }
}
