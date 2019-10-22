using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 坏账申请表
    /// </summary>
    public class T_OfficeAutomation_Document_BadDebts
    {
        private Guid officeAutomation_Document_BadDebts_ID;
        /// <summary>
        ///主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_BadDebts_ID
        {
            get { return officeAutomation_Document_BadDebts_ID; }
            set { officeAutomation_Document_BadDebts_ID = value; }
        }

        private Guid officeAutomation_Document_BadDebts_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_BadDebts_MainID
        {
            get { return officeAutomation_Document_BadDebts_MainID; }
            set { officeAutomation_Document_BadDebts_MainID = value; }
        }

        private string officeAutomation_Document_BadDebts_Apply;
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_Apply
        {
            get { return officeAutomation_Document_BadDebts_Apply; }
            set { officeAutomation_Document_BadDebts_Apply = value; }
        }

        private DateTime officeAutomation_Document_BadDebts_ApplyDate;
        /// <summary>
        /// 填写日期
        /// </summary>
        public DateTime OfficeAutomation_Document_BadDebts_ApplyDate
        {
            get { return officeAutomation_Document_BadDebts_ApplyDate; }
            set { officeAutomation_Document_BadDebts_ApplyDate = value; }
        }

        private string officeAutomation_Document_BadDebts_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_ApplyID
        {
            get { return officeAutomation_Document_BadDebts_ApplyID; }
            set { officeAutomation_Document_BadDebts_ApplyID = value; }
        }

        private string officeAutomation_Document_BadDebts_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_Department
        {
            get { return officeAutomation_Document_BadDebts_Department; }
            set { officeAutomation_Document_BadDebts_Department = value; }
        }

        private string officeAutomation_Document_BadDebts_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_ReplyPhone
        {
            get { return officeAutomation_Document_BadDebts_ReplyPhone; }
            set { officeAutomation_Document_BadDebts_ReplyPhone = value; }
        }

        private string officeAutomation_Document_BadDebts_Building;
        /// <summary>
        /// 楼盘单位
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_Building
        {
            get { return officeAutomation_Document_BadDebts_Building; }
            set { officeAutomation_Document_BadDebts_Building = value; }
        }

        private string officeAutomation_Document_BadDebts_Reason;
        /// <summary>
        /// 坏账原因
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_Reason
        {
            get { return officeAutomation_Document_BadDebts_Reason; }
            set { officeAutomation_Document_BadDebts_Reason = value; }
        }

        private decimal officeAutomation_Document_BadDebts_MoneyCount;
        /// <summary>
        /// 合计坏账金额
        /// </summary>
        public decimal OfficeAutomation_Document_BadDebts_MoneyCount
        {
            get { return officeAutomation_Document_BadDebts_MoneyCount; }
            set { officeAutomation_Document_BadDebts_MoneyCount = value; }
        }

        private string officeAutomation_Document_BadDebts_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_BadDebts_Remark
        {
            get { return officeAutomation_Document_BadDebts_Remark; }
            set { officeAutomation_Document_BadDebts_Remark = value; }
        }

        private string _OfficeAutomation_Document_BadDebts_OneOrTwo;

        public string OfficeAutomation_Document_BadDebts_OneOrTwo
        {
            get { return _OfficeAutomation_Document_BadDebts_OneOrTwo; }
            set { _OfficeAutomation_Document_BadDebts_OneOrTwo = value; }
        }

        private string _OfficeAutomation_Document_BadDebts_SumBDMoney;

        public string OfficeAutomation_Document_BadDebts_SumBDMoney
        {
            get { return _OfficeAutomation_Document_BadDebts_SumBDMoney; }
            set { _OfficeAutomation_Document_BadDebts_SumBDMoney = value; }
        }
    }
}
