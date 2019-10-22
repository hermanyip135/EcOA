using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 成交商铺/写字楼备案申请表
    /// </summary>
    public class T_OfficeAutomation_Document_DealOffice
    {
        private Guid officeAutomation_Document_DealOffice_ID;
        /// <summary>
        ///成交商铺/写字楼备案申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_DealOffice_ID
        {
            get { return officeAutomation_Document_DealOffice_ID; }
            set { officeAutomation_Document_DealOffice_ID = value; }
        }
        private Guid officeAutomation_Document_DealOffice_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_DealOffice_MainID
        {
            get { return officeAutomation_Document_DealOffice_MainID; }
            set { officeAutomation_Document_DealOffice_MainID = value; }
        }

        private string officeAutomation_Document_DealOffice_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_Apply
        {
            get { return officeAutomation_Document_DealOffice_Apply; }
            set { officeAutomation_Document_DealOffice_Apply = value; }
        }

        private DateTime officeAutomation_Document_DealOffice_ApplyDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_DealOffice_ApplyDate
        {
            get { return officeAutomation_Document_DealOffice_ApplyDate; }
            set { officeAutomation_Document_DealOffice_ApplyDate = value; }
        }

        private string officeAutomation_Document_DealOffice_Department;
        /// <summary>
        /// 申请部门
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_Department
        {
            get { return officeAutomation_Document_DealOffice_Department; }
            set { officeAutomation_Document_DealOffice_Department = value; }
        }

        private string officeAutomation_Document_DealOffice_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_ReplyPhone
        {
            get { return officeAutomation_Document_DealOffice_ReplyPhone; }
            set { officeAutomation_Document_DealOffice_ReplyPhone = value; }
        }

        private string officeAutomation_Document_DealOffice_ReplyFax;
        /// <summary>
        /// 回复传真
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_ReplyFax
        {
            get { return officeAutomation_Document_DealOffice_ReplyFax; }
            set { officeAutomation_Document_DealOffice_ReplyFax = value; }
        }

        private string officeAutomation_Document_DealOffice_WorkArea;
        /// <summary>
        /// 分行所在区域
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_WorkArea
        {
            get { return officeAutomation_Document_DealOffice_WorkArea; }
            set { officeAutomation_Document_DealOffice_WorkArea = value; }
        }

        private string officeAutomation_Document_DealOffice_Branch;
        /// <summary>
        /// 成交分行
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_Branch
        {
            get { return officeAutomation_Document_DealOffice_Branch; }
            set { officeAutomation_Document_DealOffice_Branch = value; }
        }

        private int officeAutomation_Document_DealOffice_TypeID;
        /// <summary>
        /// 物业类型
        /// </summary>
        public int OfficeAutomation_Document_DealOffice_TypeID
        {
            get { return officeAutomation_Document_DealOffice_TypeID; }
            set { officeAutomation_Document_DealOffice_TypeID = value; }
        }

        private string officeAutomation_Document_DealOffice_OfficeArea;
        /// <summary>
        /// 物业所在区域
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_OfficeArea
        {
            get { return officeAutomation_Document_DealOffice_OfficeArea; }
            set { officeAutomation_Document_DealOffice_OfficeArea = value; }
        }

        private string officeAutomation_Document_DealOffice_OfficeAddress;
        /// <summary>
        /// 物业所在地址
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_OfficeAddress
        {
            get { return officeAutomation_Document_DealOffice_OfficeAddress; }
            set { officeAutomation_Document_DealOffice_OfficeAddress = value; }
        }

        private decimal officeAutomation_Document_DealOffice_DealArea;
        /// <summary>
        /// 买卖面积
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_DealArea
        {
            get { return officeAutomation_Document_DealOffice_DealArea; }
            set { officeAutomation_Document_DealOffice_DealArea = value; }
        }

        private decimal officeAutomation_Document_DealOffice_DealPrice;
        /// <summary>
        /// 买卖成交价
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_DealPrice
        {
            get { return officeAutomation_Document_DealOffice_DealPrice; }
            set { officeAutomation_Document_DealOffice_DealPrice = value; }
        }

        private decimal officeAutomation_Document_DealOffice_DealOwnerMoney;
        /// <summary>
        /// 买卖业佣
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_DealOwnerMoney
        {
            get { return officeAutomation_Document_DealOffice_DealOwnerMoney; }
            set { officeAutomation_Document_DealOffice_DealOwnerMoney = value; }
        }

        private decimal officeAutomation_Document_DealOffice_DealOwnerPercent;
        /// <summary>
        /// 买卖业佣比例
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_DealOwnerPercent
        {
            get { return officeAutomation_Document_DealOffice_DealOwnerPercent; }
            set { officeAutomation_Document_DealOffice_DealOwnerPercent = value; }
        }

        private decimal officeAutomation_Document_DealOffice_DealClientMoney;
        /// <summary>
        /// 买卖客佣
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_DealClientMoney
        {
            get { return officeAutomation_Document_DealOffice_DealClientMoney; }
            set { officeAutomation_Document_DealOffice_DealClientMoney = value; }
        }

        private decimal officeAutomation_Document_DealOffice_DealClientPercent;
        /// <summary>
        /// 买卖客佣比例
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_DealClientPercent
        {
            get { return officeAutomation_Document_DealOffice_DealClientPercent; }
            set { officeAutomation_Document_DealOffice_DealClientPercent = value; }
        }

        private decimal officeAutomation_Document_DealOffice_DealMoney;
        /// <summary>
        /// 买卖合计
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_DealMoney
        {
            get { return officeAutomation_Document_DealOffice_DealMoney; }
            set { officeAutomation_Document_DealOffice_DealMoney = value; }
        }

        private decimal officeAutomation_Document_DealOffice_DealPercent;
        /// <summary>
        /// 买卖总佣比例
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_DealPercent
        {
            get { return officeAutomation_Document_DealOffice_DealPercent; }
            set { officeAutomation_Document_DealOffice_DealPercent = value; }
        }

        private decimal officeAutomation_Document_DealOffice_LeaseArea;
        /// <summary>
        /// 租赁面积
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_LeaseArea
        {
            get { return officeAutomation_Document_DealOffice_LeaseArea; }
            set { officeAutomation_Document_DealOffice_LeaseArea = value; }
        }

        private decimal officeAutomation_Document_DealOffice_LeasePrice;
        /// <summary>
        /// 租赁成交价
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_LeasePrice
        {
            get { return officeAutomation_Document_DealOffice_LeasePrice; }
            set { officeAutomation_Document_DealOffice_LeasePrice = value; }
        }

        private decimal officeAutomation_Document_DealOffice_LeaseOwnerMoney;
        /// <summary>
        /// 租赁业佣
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_LeaseOwnerMoney
        {
            get { return officeAutomation_Document_DealOffice_LeaseOwnerMoney; }
            set { officeAutomation_Document_DealOffice_LeaseOwnerMoney = value; }
        }

        private decimal officeAutomation_Document_DealOffice_LeaseOwnerPercent;
        /// <summary>
        /// 租赁业佣比例
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_LeaseOwnerPercent
        {
            get { return officeAutomation_Document_DealOffice_LeaseOwnerPercent; }
            set { officeAutomation_Document_DealOffice_LeaseOwnerPercent = value; }
        }

        private decimal officeAutomation_Document_DealOffice_LeaseClientMoney;
        /// <summary>
        /// 租赁客佣
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_LeaseClientMoney
        {
            get { return officeAutomation_Document_DealOffice_LeaseClientMoney; }
            set { officeAutomation_Document_DealOffice_LeaseClientMoney = value; }
        }

        private decimal officeAutomation_Document_DealOffice_LeaseClientPercent;
        /// <summary>
        /// 租赁客佣比例
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_LeaseClientPercent
        {
            get { return officeAutomation_Document_DealOffice_LeaseClientPercent; }
            set { officeAutomation_Document_DealOffice_LeaseClientPercent = value; }
        }

        private decimal officeAutomation_Document_DealOffice_LeaseMoney;
        /// <summary>
        /// 租赁合计
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_LeaseMoney
        {
            get { return officeAutomation_Document_DealOffice_LeaseMoney; }
            set { officeAutomation_Document_DealOffice_LeaseMoney = value; }
        }

        private decimal officeAutomation_Document_DealOffice_LeasePercent;
        /// <summary>
        /// 租赁总佣比例
        /// </summary>
        public decimal OfficeAutomation_Document_DealOffice_LeasePercent
        {
            get { return officeAutomation_Document_DealOffice_LeasePercent; }
            set { officeAutomation_Document_DealOffice_LeasePercent = value; }
        }

        private string officeAutomation_Document_DealOffice_CrossAreaRemark;
        /// <summary>
        /// 跨区成交说明
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_CrossAreaRemark
        {
            get { return officeAutomation_Document_DealOffice_CrossAreaRemark; }
            set { officeAutomation_Document_DealOffice_CrossAreaRemark = value; }
        }

        private string officeAutomation_Document_DealOffice_MoneyRemark;
        /// <summary>
        /// 佣金过低说明
        /// </summary>
        public string OfficeAutomation_Document_DealOffice_MoneyRemark
        {
            get { return officeAutomation_Document_DealOffice_MoneyRemark; }
            set { officeAutomation_Document_DealOffice_MoneyRemark = value; }
        }
    }
}
