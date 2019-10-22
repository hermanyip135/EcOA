using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 特殊上数申请表
    /// </summary>
    public class T_OfficeAutomation_Document_SpecialNumber
    {
        private Guid _OfficeAutomation_Document_SpecialNumber_ID;
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_SpecialNumber_ID
        {
            get { return _OfficeAutomation_Document_SpecialNumber_ID; }
            set { _OfficeAutomation_Document_SpecialNumber_ID = value; }
        }

        private Guid _OfficeAutomation_Document_SpecialNumber_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_SpecialNumber_MainID
        {
            get { return _OfficeAutomation_Document_SpecialNumber_MainID; }
            set { _OfficeAutomation_Document_SpecialNumber_MainID = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_Apply;
        /// <summary>
        /// 发文人员
        /// </summary>
        public string OfficeAutomation_Document_SpecialNumber_Apply
        {
            get { return _OfficeAutomation_Document_SpecialNumber_Apply; }
            set { _OfficeAutomation_Document_SpecialNumber_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_SpecialNumber_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_SpecialNumber_ApplyDate
        {
            get { return _OfficeAutomation_Document_SpecialNumber_ApplyDate; }
            set { _OfficeAutomation_Document_SpecialNumber_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_SpecialNumber_ApplyID
        {
            get { return _OfficeAutomation_Document_SpecialNumber_ApplyID; }
            set { _OfficeAutomation_Document_SpecialNumber_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_SpecialNumber_Department
        {
            get { return _OfficeAutomation_Document_SpecialNumber_Department; }
            set { _OfficeAutomation_Document_SpecialNumber_Department = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_Subject;
        /// <summary>
        /// 文件主题
        /// </summary>
        public string OfficeAutomation_Document_SpecialNumber_Subject
        {
            get { return _OfficeAutomation_Document_SpecialNumber_Subject; }
            set { _OfficeAutomation_Document_SpecialNumber_Subject = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_SpecialNumber_ReplyPhone
        {
            get { return _OfficeAutomation_Document_SpecialNumber_ReplyPhone; }
            set { _OfficeAutomation_Document_SpecialNumber_ReplyPhone = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_Fax;
        /// <summary>
        /// 回复传真
        /// </summary>
        public string OfficeAutomation_Document_SpecialNumber_Fax
        {
            get { return _OfficeAutomation_Document_SpecialNumber_Fax; }
            set { _OfficeAutomation_Document_SpecialNumber_Fax = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_Describe;
        /// <summary>
        /// 原因详述
        /// </summary>
        public string OfficeAutomation_Document_SpecialNumber_Describe
        {
            get { return _OfficeAutomation_Document_SpecialNumber_Describe; }
            set { _OfficeAutomation_Document_SpecialNumber_Describe = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_DealNature;

        public string OfficeAutomation_Document_SpecialNumber_DealNature
        {
            get { return _OfficeAutomation_Document_SpecialNumber_DealNature; }
            set { _OfficeAutomation_Document_SpecialNumber_DealNature = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_Names;

        public string OfficeAutomation_Document_SpecialNumber_Names
        {
            get { return _OfficeAutomation_Document_SpecialNumber_Names; }
            set { _OfficeAutomation_Document_SpecialNumber_Names = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_Period;

        public string OfficeAutomation_Document_SpecialNumber_Period
        {
            get { return _OfficeAutomation_Document_SpecialNumber_Period; }
            set { _OfficeAutomation_Document_SpecialNumber_Period = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_ApplyNo;

        public string OfficeAutomation_Document_SpecialNumber_ApplyNo
        {
            get { return _OfficeAutomation_Document_SpecialNumber_ApplyNo; }
            set { _OfficeAutomation_Document_SpecialNumber_ApplyNo = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs;

        public string OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs
        {
            get { return _OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs; }
            set { _OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_DealOfficeOther;

        public string OfficeAutomation_Document_SpecialNumber_DealOfficeOther
        {
            get { return _OfficeAutomation_Document_SpecialNumber_DealOfficeOther; }
            set { _OfficeAutomation_Document_SpecialNumber_DealOfficeOther = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_AgentModel;

        public string OfficeAutomation_Document_SpecialNumber_AgentModel
        {
            get { return _OfficeAutomation_Document_SpecialNumber_AgentModel; }
            set { _OfficeAutomation_Document_SpecialNumber_AgentModel = value; }
        }

        private string _OfficeAutomation_Document_SpecialNumber_TheReason;

        public string OfficeAutomation_Document_SpecialNumber_TheReason
        {
            get { return _OfficeAutomation_Document_SpecialNumber_TheReason; }
            set { _OfficeAutomation_Document_SpecialNumber_TheReason = value; }
        }

    }
}
