using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 合同条款申请表
    /// </summary>
    public class T_OfficeAutomation_Document_ContractTerms
    {
        private Guid _OfficeAutomation_Document_ContractTerms_ID;
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_ContractTerms_ID
        {
            get { return _OfficeAutomation_Document_ContractTerms_ID; }
            set { _OfficeAutomation_Document_ContractTerms_ID = value; }
        }

        private Guid _OfficeAutomation_Document_ContractTerms_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ContractTerms_MainID
        {
            get { return _OfficeAutomation_Document_ContractTerms_MainID; }
            set { _OfficeAutomation_Document_ContractTerms_MainID = value; }
        }

        private string _OfficeAutomation_Document_ContractTerms_Apply;
        /// <summary>
        /// 发文人员
        /// </summary>
        public string OfficeAutomation_Document_ContractTerms_Apply
        {
            get { return _OfficeAutomation_Document_ContractTerms_Apply; }
            set { _OfficeAutomation_Document_ContractTerms_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_ContractTerms_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ContractTerms_ApplyDate
        {
            get { return _OfficeAutomation_Document_ContractTerms_ApplyDate; }
            set { _OfficeAutomation_Document_ContractTerms_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_ContractTerms_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_ContractTerms_ApplyID
        {
            get { return _OfficeAutomation_Document_ContractTerms_ApplyID; }
            set { _OfficeAutomation_Document_ContractTerms_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_ContractTerms_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_ContractTerms_Department
        {
            get { return _OfficeAutomation_Document_ContractTerms_Department; }
            set { _OfficeAutomation_Document_ContractTerms_Department = value; }
        }

        private string _OfficeAutomation_Document_ContractTerms_Subject;
        /// <summary>
        /// 文件主题
        /// </summary>
        public string OfficeAutomation_Document_ContractTerms_Subject
        {
            get { return _OfficeAutomation_Document_ContractTerms_Subject; }
            set { _OfficeAutomation_Document_ContractTerms_Subject = value; }
        }

        private string _OfficeAutomation_Document_ContractTerms_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ContractTerms_ReplyPhone
        {
            get { return _OfficeAutomation_Document_ContractTerms_ReplyPhone; }
            set { _OfficeAutomation_Document_ContractTerms_ReplyPhone = value; }
        }

        private string _OfficeAutomation_Document_ContractTerms_Fax;
        /// <summary>
        /// 回复传真
        /// </summary>
        public string OfficeAutomation_Document_ContractTerms_Fax
        {
            get { return _OfficeAutomation_Document_ContractTerms_Fax; }
            set { _OfficeAutomation_Document_ContractTerms_Fax = value; }
        }

        private string _OfficeAutomation_Document_ContractTerms_ReceiveDepartment;
        /// <summary>
        /// 收文部门
        /// </summary>
        public string OfficeAutomation_Document_ContractTerms_ReceiveDepartment
        {
            get { return _OfficeAutomation_Document_ContractTerms_ReceiveDepartment; }
            set { _OfficeAutomation_Document_ContractTerms_ReceiveDepartment = value; }
        }

        private string _OfficeAutomation_Document_ContractTerms_OSDepartment;
        /// <summary>
        /// 抄送部门
        /// </summary>
        public string OfficeAutomation_Document_ContractTerms_OSDepartment
        {
            get { return _OfficeAutomation_Document_ContractTerms_OSDepartment; }
            set { _OfficeAutomation_Document_ContractTerms_OSDepartment = value; }
        }

        private bool _OfficeAutomation_Document_ContractTerms_IsApproval;
        /// <summary>
        /// 项目报备是否已审批
        /// </summary>
        public bool OfficeAutomation_Document_ContractTerms_IsApproval
        {
            get { return _OfficeAutomation_Document_ContractTerms_IsApproval; }
            set { _OfficeAutomation_Document_ContractTerms_IsApproval = value; }
        }

        private string _OfficeAutomation_Document_ContractTerms_Describe;
        /// <summary>
        /// 原因详述
        /// </summary>
        public string OfficeAutomation_Document_ContractTerms_Describe
        {
            get { return _OfficeAutomation_Document_ContractTerms_Describe; }
            set { _OfficeAutomation_Document_ContractTerms_Describe = value; }
        }
    }
}
