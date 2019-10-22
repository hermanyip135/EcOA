using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 坏账申请相关情况表
    /// </summary>
    public class T_OfficeAutomation_Document_BadDebts_Detail
    {
        private Guid officeAutomation_Document_BadDebts_Detail_ID;
        /// <summary>
        ///主键
        /// </summary>
        public Guid OfficeAutomation_Document_BadDebts_Detail_ID
        {
            get { return officeAutomation_Document_BadDebts_Detail_ID; }
            set { officeAutomation_Document_BadDebts_Detail_ID = value; }
        }

        private Guid officeAutomation_Document_BadDebts_Detail_MainID;
        /// <summary>
        /// 坏账申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_BadDebts_Detail_MainID
        {
            get { return officeAutomation_Document_BadDebts_Detail_MainID; }
            set { officeAutomation_Document_BadDebts_Detail_MainID = value; }
        }

        private string officeAutomation_Document_BadDebts_Detail_ReportID;
        /// <summary>
        /// 成交报告编号
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_Detail_ReportID
        {
            get { return officeAutomation_Document_BadDebts_Detail_ReportID; }
            set { officeAutomation_Document_BadDebts_Detail_ReportID = value; }
        }

        private string officeAutomation_Document_BadDebts_Detail_Address;
        /// <summary>
        /// 成交地址
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_Detail_Address
        {
            get { return officeAutomation_Document_BadDebts_Detail_Address; }
            set { officeAutomation_Document_BadDebts_Detail_Address = value; }
        }

        private string _OfficeAutomation_Document_BadDebts_Detail_Owner;

        public string OfficeAutomation_Document_BadDebts_Detail_Owner
        {
            get { return _OfficeAutomation_Document_BadDebts_Detail_Owner; }
            set { _OfficeAutomation_Document_BadDebts_Detail_Owner = value; }
        }

        private string _OfficeAutomation_Document_BadDebts_Detail_Client;

        public string OfficeAutomation_Document_BadDebts_Detail_Client
        {
            get { return _OfficeAutomation_Document_BadDebts_Detail_Client; }
            set { _OfficeAutomation_Document_BadDebts_Detail_Client = value; }
        }

        private decimal officeAutomation_Document_BadDebts_Detail_OwnerBadMoney;
        /// <summary>
        /// 业主坏账金额
        /// </summary>
        public decimal OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney
        {
            get { return officeAutomation_Document_BadDebts_Detail_OwnerBadMoney; }
            set { officeAutomation_Document_BadDebts_Detail_OwnerBadMoney = value; }
        }

        private decimal officeAutomation_Document_BadDebts_Detail_ClientBadMoney;
        /// <summary>
        /// 客户坏账金额
        /// </summary>
        public decimal OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney
        {
            get { return officeAutomation_Document_BadDebts_Detail_ClientBadMoney; }
            set { officeAutomation_Document_BadDebts_Detail_ClientBadMoney = value; }
        }

        private string officeAutomation_Document_BadDebts_Detail_BadReason;
        /// <summary>
        /// 坏账原因
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_Detail_BadReason
        {
            get { return officeAutomation_Document_BadDebts_Detail_BadReason; }
            set { officeAutomation_Document_BadDebts_Detail_BadReason = value; }
        }

        private bool officeAutomation_Document_BadDebts_Detail_IsSpecialAdjust;
        /// <summary>
        /// 是否特殊调整
        /// </summary>
        public bool OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust
        {
            get { return officeAutomation_Document_BadDebts_Detail_IsSpecialAdjust; }
            set { officeAutomation_Document_BadDebts_Detail_IsSpecialAdjust = value; }
        }

        private bool _OfficeAutomation_Document_BadDebts_Detail_IsAutoBad;
        /// <summary>
        /// 是否已自动坏账
        /// </summary>
        public bool OfficeAutomation_Document_BadDebts_Detail_IsAutoBad
        {
            get { return _OfficeAutomation_Document_BadDebts_Detail_IsAutoBad; }
            set { _OfficeAutomation_Document_BadDebts_Detail_IsAutoBad = value; }
        }

        private string _OfficeAutomation_Document_BadDebts_Detail_AutoBadDate;
        /// <summary>
        /// 自动坏账时间
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_Detail_AutoBadDate
        {
            get { return _OfficeAutomation_Document_BadDebts_Detail_AutoBadDate; }
            set { _OfficeAutomation_Document_BadDebts_Detail_AutoBadDate = value; }
        }

        private string _OfficeAutomation_Document_BadDebts_Detail_No;

        public string OfficeAutomation_Document_BadDebts_Detail_No
        {
            get { return _OfficeAutomation_Document_BadDebts_Detail_No; }
            set { _OfficeAutomation_Document_BadDebts_Detail_No = value; }
        }

        private string _OfficeAutomation_Document_BadDebts_Detail_DealDate;

        public string OfficeAutomation_Document_BadDebts_Detail_DealDate
        {
            get { return _OfficeAutomation_Document_BadDebts_Detail_DealDate; }
            set { _OfficeAutomation_Document_BadDebts_Detail_DealDate = value; }
        }

        private string _OfficeAutomation_Document_BadDebts_Detail_BadDate;

        public string OfficeAutomation_Document_BadDebts_Detail_BadDate
        {
            get { return _OfficeAutomation_Document_BadDebts_Detail_BadDate; }
            set { _OfficeAutomation_Document_BadDebts_Detail_BadDate = value; }
        }

        private string _OfficeAutomation_Document_BadDebts_Detail_Area;

        public string OfficeAutomation_Document_BadDebts_Detail_Area
        {
            get { return _OfficeAutomation_Document_BadDebts_Detail_Area; }
            set { _OfficeAutomation_Document_BadDebts_Detail_Area = value; }
        }
    }
}
