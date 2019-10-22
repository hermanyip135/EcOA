using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 公文流转审批流程表
    /// </summary>
    public class T_OfficeAutomation_Flow
    {
        private Guid officeAutomation_Flow_ID;
        /// <summary>
        /// 公文流转审批流程主键
        /// </summary>
        public Guid OfficeAutomation_Flow_ID
        {
            get { return officeAutomation_Flow_ID; }
            set { officeAutomation_Flow_ID = value; }
        }
        private Guid officeAutomation_Flow_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Flow_MainID
        {
            get { return officeAutomation_Flow_MainID; }
            set { officeAutomation_Flow_MainID = value; }
        }
        private string officeAutomation_Flow_Employee;
        /// <summary>
        /// 可审批人
        /// </summary>
        public string OfficeAutomation_Flow_Employee
        {
            get { return officeAutomation_Flow_Employee; }
            set { officeAutomation_Flow_Employee = value; }
        }
        private string officeAutomation_Flow_EmployeeID;
        /// <summary>
        /// 可审批人工号
        /// </summary>
        public string OfficeAutomation_Flow_EmployeeID
        {
            get { return officeAutomation_Flow_EmployeeID; }
            set { officeAutomation_Flow_EmployeeID = value; }
        }
        private int officeAutomation_Flow_Idx;
        /// <summary>
        /// 审批索引
        /// </summary>
        public int OfficeAutomation_Flow_Idx
        {
            get { return officeAutomation_Flow_Idx; }
            set { officeAutomation_Flow_Idx = value; }
        }
        private bool officeAutomation_Flow_Audit;
        /// <summary>
        /// 是否已经审批
        /// </summary>
        public bool OfficeAutomation_Flow_Audit
        {
            get { return officeAutomation_Flow_Audit; }
            set { officeAutomation_Flow_Audit = value; }
        }
        private string officeAutomation_Flow_Suggestion;
        /// <summary>
        /// 审批意见
        /// </summary>
        public string OfficeAutomation_Flow_Suggestion
        {
            get { return officeAutomation_Flow_Suggestion; }
            set { officeAutomation_Flow_Suggestion = value; }
        }
        private DateTime officeAutomation_Flow_AuditDate;
        /// <summary>
        /// 审批日期
        /// </summary>
        public DateTime OfficeAutomation_Flow_AuditDate
        {
            get { return officeAutomation_Flow_AuditDate; }
            set { officeAutomation_Flow_AuditDate = value; }
        }

        private string officeAutomation_Flow_Auditor;
        /// <summary>
        /// 最终审批人
        /// </summary>
        public string OfficeAutomation_Flow_Auditor
        {
            get { return officeAutomation_Flow_Auditor; }
            set { officeAutomation_Flow_Auditor = value; }
        }
        private string officeAutomation_Flow_AuditorID;
        /// <summary>
        /// 最终审批人工号
        /// </summary>
        public string OfficeAutomation_Flow_AuditorID
        {
            get { return officeAutomation_Flow_AuditorID; }
            set { officeAutomation_Flow_AuditorID = value; }
        }

        private int officeAutomation_Flow_IsAgree;
        /// <summary>
        /// 是否同意
        /// </summary>
        public int OfficeAutomation_Flow_IsAgree
        {
            get { return officeAutomation_Flow_IsAgree; }
            set { officeAutomation_Flow_IsAgree = value; }
        }
    }
}
