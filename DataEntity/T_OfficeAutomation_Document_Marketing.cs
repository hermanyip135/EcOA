using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 市场推广费用申请
    /// </summary>
    public class T_OfficeAutomation_Document_Marketing
    {
        private Guid _OfficeAutomation_Document_Marketing_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_Marketing_ID
        {
            get { return _OfficeAutomation_Document_Marketing_ID; }
            set { _OfficeAutomation_Document_Marketing_ID = value; }
        }

        private Guid _OfficeAutomation_Document_Marketing_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_Marketing_MainID
        {
            get { return _OfficeAutomation_Document_Marketing_MainID; }
            set { _OfficeAutomation_Document_Marketing_MainID = value; }
        }

        private string _OfficeAutomation_Document_Marketing_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_Marketing_Apply
        {
            get { return _OfficeAutomation_Document_Marketing_Apply; }
            set { _OfficeAutomation_Document_Marketing_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_Marketing_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_Marketing_ApplyDate
        {
            get { return _OfficeAutomation_Document_Marketing_ApplyDate; }
            set { _OfficeAutomation_Document_Marketing_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_Marketing_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_Marketing_ApplyID
        {
            get { return _OfficeAutomation_Document_Marketing_ApplyID; }
            set { _OfficeAutomation_Document_Marketing_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_Marketing_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_Marketing_Department
        {
            get { return _OfficeAutomation_Document_Marketing_Department; }
            set { _OfficeAutomation_Document_Marketing_Department = value; }
        }

        private string _OfficeAutomation_Document_Marketing_ReceiveDP;
        /// <summary>
        /// 收文部门
        /// </summary>
        public string OfficeAutomation_Document_Marketing_ReceiveDP
        {
            get { return _OfficeAutomation_Document_Marketing_ReceiveDP; }
            set { _OfficeAutomation_Document_Marketing_ReceiveDP = value; }
        }

        private string _OfficeAutomation_Document_Marketing_Telephone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_Marketing_Telephone
        {
            get { return _OfficeAutomation_Document_Marketing_Telephone; }
            set { _OfficeAutomation_Document_Marketing_Telephone = value; }
        }

        private string _OfficeAutomation_Document_Marketing_Fax;
        /// <summary>
        /// 回复传真
        /// </summary>
        public string OfficeAutomation_Document_Marketing_Fax
        {
            get { return _OfficeAutomation_Document_Marketing_Fax; }
            set { _OfficeAutomation_Document_Marketing_Fax = value; }
        }

        private string _OfficeAutomation_Document_Marketing_Subject;
        /// <summary>
        /// 文件主题
        /// </summary>
        public string OfficeAutomation_Document_Marketing_Subject
        {
            get { return _OfficeAutomation_Document_Marketing_Subject; }
            set { _OfficeAutomation_Document_Marketing_Subject = value; }
        }

        private string _OfficeAutomation_Document_Marketing_Describe;
        /// <summary>
        /// 申请正文
        /// </summary>
        public string OfficeAutomation_Document_Marketing_Describe
        {
            get { return _OfficeAutomation_Document_Marketing_Describe; }
            set { _OfficeAutomation_Document_Marketing_Describe = value; }
        }
    }
}
