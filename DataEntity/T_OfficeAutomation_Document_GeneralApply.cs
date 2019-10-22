using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 通用申请表
    /// </summary>
    public class T_OfficeAutomation_Document_GeneralApply
    {
        private Guid _OfficeAutomation_Document_GeneralApply_ID;
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_GeneralApply_ID
        {
            get { return _OfficeAutomation_Document_GeneralApply_ID; }
            set { _OfficeAutomation_Document_GeneralApply_ID = value; }
        }

        private Guid _OfficeAutomation_Document_GeneralApply_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_GeneralApply_MainID
        {
            get { return _OfficeAutomation_Document_GeneralApply_MainID; }
            set { _OfficeAutomation_Document_GeneralApply_MainID = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_Apply;
        /// <summary>
        /// 发文人员
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_Apply
        {
            get { return _OfficeAutomation_Document_GeneralApply_Apply; }
            set { _OfficeAutomation_Document_GeneralApply_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_GeneralApply_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_GeneralApply_ApplyDate
        {
            get { return _OfficeAutomation_Document_GeneralApply_ApplyDate; }
            set { _OfficeAutomation_Document_GeneralApply_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_ApplyID
        {
            get { return _OfficeAutomation_Document_GeneralApply_ApplyID; }
            set { _OfficeAutomation_Document_GeneralApply_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_Department
        {
            get { return _OfficeAutomation_Document_GeneralApply_Department; }
            set { _OfficeAutomation_Document_GeneralApply_Department = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_ReceiveDepartment;
        /// <summary>
        /// 收文部门
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_ReceiveDepartment
        {
            get { return _OfficeAutomation_Document_GeneralApply_ReceiveDepartment; }
            set { _OfficeAutomation_Document_GeneralApply_ReceiveDepartment = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_CCDepartment;
        /// <summary>
        /// 抄送部门
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_CCDepartment
        {
            get { return _OfficeAutomation_Document_GeneralApply_CCDepartment; }
            set { _OfficeAutomation_Document_GeneralApply_CCDepartment = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_Subject;
        /// <summary>
        /// 文件主题
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_Subject
        {
            get { return _OfficeAutomation_Document_GeneralApply_Subject; }
            set { _OfficeAutomation_Document_GeneralApply_Subject = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_ReplyPhone
        {
            get { return _OfficeAutomation_Document_GeneralApply_ReplyPhone; }
            set { _OfficeAutomation_Document_GeneralApply_ReplyPhone = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_Fax;
        /// <summary>
        /// 回复传真
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_Fax
        {
            get { return _OfficeAutomation_Document_GeneralApply_Fax; }
            set { _OfficeAutomation_Document_GeneralApply_Fax = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName;
        /// <summary>
        /// 可见人姓名
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName
        {
            get { return _OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName; }
            set { _OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID;
        /// <summary>
        /// 可见人工号
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID
        {
            get { return _OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID; }
            set { _OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID = value; }
        }


        private string _OfficeAutomation_Document_GeneralApply_Describe;
        /// <summary>
        /// 正文
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_Describe
        {
            get { return _OfficeAutomation_Document_GeneralApply_Describe; }
            set { _OfficeAutomation_Document_GeneralApply_Describe = value; }
        }
    }
}
