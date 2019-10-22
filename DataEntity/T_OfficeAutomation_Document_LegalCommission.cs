using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 法律部追佣合作费处理申请
    /// </summary>
    public class T_OfficeAutomation_Document_LegalCommission
    {
        private Guid _OfficeAutomation_Document_LegalCommission_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_LegalCommission_ID
        {
            get { return _OfficeAutomation_Document_LegalCommission_ID; }
            set { _OfficeAutomation_Document_LegalCommission_ID = value; }
        }

        private Guid _OfficeAutomation_Document_LegalCommission_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_LegalCommission_MainID
        {
            get { return _OfficeAutomation_Document_LegalCommission_MainID; }
            set { _OfficeAutomation_Document_LegalCommission_MainID = value; }
        }

        private string _OfficeAutomation_Document_LegalCommission_Apply;
        /// <summary>
        /// 发文人员
        /// </summary>
        public string OfficeAutomation_Document_LegalCommission_Apply
        {
            get { return _OfficeAutomation_Document_LegalCommission_Apply; }
            set { _OfficeAutomation_Document_LegalCommission_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_LegalCommission_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_LegalCommission_ApplyDate
        {
            get { return _OfficeAutomation_Document_LegalCommission_ApplyDate; }
            set { _OfficeAutomation_Document_LegalCommission_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_LegalCommission_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_LegalCommission_ApplyID
        {
            get { return _OfficeAutomation_Document_LegalCommission_ApplyID; }
            set { _OfficeAutomation_Document_LegalCommission_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_LegalCommission_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_LegalCommission_Department
        {
            get { return _OfficeAutomation_Document_LegalCommission_Department; }
            set { _OfficeAutomation_Document_LegalCommission_Department = value; }
        }

        private string _OfficeAutomation_Document_LegalCommission_Subject;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string OfficeAutomation_Document_LegalCommission_Subject
        {
            get { return _OfficeAutomation_Document_LegalCommission_Subject; }
            set { _OfficeAutomation_Document_LegalCommission_Subject = value; }
        }

        private string _OfficeAutomation_Document_LegalCommission_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_LegalCommission_ReplyPhone
        {
            get { return _OfficeAutomation_Document_LegalCommission_ReplyPhone; }
            set { _OfficeAutomation_Document_LegalCommission_ReplyPhone = value; }
        }

        private string _OfficeAutomation_Document_LegalCommission_TotalCoast;
        /// <summary>
        /// 合作费用
        /// </summary>
        public string OfficeAutomation_Document_LegalCommission_TotalCoast
        {
            get { return _OfficeAutomation_Document_LegalCommission_TotalCoast; }
            set { _OfficeAutomation_Document_LegalCommission_TotalCoast = value; }
        }

        private string _OfficeAutomation_Document_LegalCommission_ACMoney;
        /// <summary>
        /// 法律部追佣金额
        /// </summary>
        public string OfficeAutomation_Document_LegalCommission_ACMoney
        {
            get { return _OfficeAutomation_Document_LegalCommission_ACMoney; }
            set { _OfficeAutomation_Document_LegalCommission_ACMoney = value; }
        }

        private bool _OfficeAutomation_Document_LegalCommission_Cooperation;
        /// <summary>
        /// 是否支付合作费
        /// </summary>
        public bool OfficeAutomation_Document_LegalCommission_Cooperation
        {
            get { return _OfficeAutomation_Document_LegalCommission_Cooperation; }
            set { _OfficeAutomation_Document_LegalCommission_Cooperation = value; }
        }

        private string _OfficeAutomation_Document_LegalCommission_Reason;
        /// <summary>
        /// 支付合作费原因
        /// </summary>
        public string OfficeAutomation_Document_LegalCommission_Reason
        {
            get { return _OfficeAutomation_Document_LegalCommission_Reason; }
            set { _OfficeAutomation_Document_LegalCommission_Reason = value; }
        }

        private string _OfficeAutomation_Document_LegalCommission_Cname;
        /// <summary>
        /// 合作人员名称
        /// </summary>
        public string OfficeAutomation_Document_LegalCommission_Cname
        {
            get { return _OfficeAutomation_Document_LegalCommission_Cname; }
            set { _OfficeAutomation_Document_LegalCommission_Cname = value; }
        }
    }
}
