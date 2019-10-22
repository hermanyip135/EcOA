using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// (物业部/工商铺)IT权限申请表
    /// </summary>
    public class T_OfficeAutomation_Document_ITPower
    {
        private Guid officeAutomation_Document_ITPower_ID;
        /// <summary>
        /// IT权限申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITPower_ID
        {
            get { return officeAutomation_Document_ITPower_ID; }
            set { officeAutomation_Document_ITPower_ID = value; }
        }
        private Guid officeAutomation_Document_ITPower_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITPower_MainID
        {
            get { return officeAutomation_Document_ITPower_MainID; }
            set { officeAutomation_Document_ITPower_MainID = value; }
        }
        private Guid officeAutomation_Document_ITPower_DepartmentID;
        /// <summary>
        /// 申请部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_ITPower_DepartmentID
        {
            get { return officeAutomation_Document_ITPower_DepartmentID; }
            set { officeAutomation_Document_ITPower_DepartmentID = value; }
        }
        private string officeAutomation_Document_ITPower_Department;
        /// <summary>
        /// 申请部门
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Department
        {
            get { return officeAutomation_Document_ITPower_Department; }
            set { officeAutomation_Document_ITPower_Department = value; }
        }
        private DateTime officeAutomation_Document_ITPower_ApplyDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ITPower_ApplyDate
        {
            get { return officeAutomation_Document_ITPower_ApplyDate; }
            set { officeAutomation_Document_ITPower_ApplyDate = value; }
        }
        private string officeAutomation_Document_ITPower_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Apply
        {
            get { return officeAutomation_Document_ITPower_Apply; }
            set { officeAutomation_Document_ITPower_Apply = value; }
        }
        private string officeAutomation_Document_ITPower_ApplyReason;
        /// <summary>
        /// 申请原因
        /// </summary>
        public string OfficeAutomation_Document_ITPower_ApplyReason
        {
            get { return officeAutomation_Document_ITPower_ApplyReason; }
            set { officeAutomation_Document_ITPower_ApplyReason = value; }
        }
        private string officeAutomation_Document_ITPower_Deal;
        /// <summary>
        /// 处理情况
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Deal
        {
            get { return officeAutomation_Document_ITPower_Deal; }
            set { officeAutomation_Document_ITPower_Deal = value; }
        }
    }
}
