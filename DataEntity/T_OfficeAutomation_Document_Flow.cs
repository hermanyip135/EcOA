using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 公文流转流程表
    /// </summary>
    public class T_OfficeAutomation_Document_Flow
    {
        private int officeAutomation_Document_Flow_ID;
        /// <summary>
        /// 公文流转流程主键
        /// </summary>
        public int OfficeAutomation_Document_Flow_ID
        {
            get { return officeAutomation_Document_Flow_ID; }
            set { officeAutomation_Document_Flow_ID = value; }
        }
        private int officeAutomation_Document_Flow_MainID;
        /// <summary>
        /// 对照公文名称ID
        /// </summary>
        public int OfficeAutomation_Document_Flow_MainID
        {
            get { return officeAutomation_Document_Flow_MainID; }
            set { officeAutomation_Document_Flow_MainID = value; }
        }
        private int officeAutomation_Document_Flow_Idx;
        /// <summary>
        /// 公文流转流程索引
        /// </summary>
        public int OfficeAutomation_Document_Flow_Idx
        {
            get { return officeAutomation_Document_Flow_Idx; }
            set { officeAutomation_Document_Flow_Idx = value; }
        }
        private Guid officeAutomation_Document_Flow_PositionID;
        /// <summary>
        /// 公文流转审批职位ID
        /// </summary>
        public Guid OfficeAutomation_Document_Flow_PositionID
        {
            get { return officeAutomation_Document_Flow_PositionID; }
            set { officeAutomation_Document_Flow_PositionID = value; }
        }
        private string officeAutomation_Document_Flow_Position;
        /// <summary>
        /// 公文流转审批职位
        /// </summary>
        public string OfficeAutomation_Document_Flow_Position
        {
            get { return officeAutomation_Document_Flow_Position; }
            set { officeAutomation_Document_Flow_Position = value; }
        }
        private string officeAutomation_Document_Flow_AuditName;
        /// <summary>
        /// 审批人姓名
        /// </summary>
        public string OfficeAutomation_Document_Flow_AuditName
        {
            get { return officeAutomation_Document_Flow_AuditName; }
            set { officeAutomation_Document_Flow_AuditName = value; }
        }
        private string officeAutomation_Document_Flow_AuditCode;
        /// <summary>
        /// 审批人工号
        /// </summary>
        public string OfficeAutomation_Document_Flow_AuditCode
        {
            get { return officeAutomation_Document_Flow_AuditCode; }
            set { officeAutomation_Document_Flow_AuditCode = value; }
        }
        private bool officeAutomation_Document_Flow_AllowEdit;
        /// <summary>
        /// 是否允许修改
        /// </summary>
        public bool OfficeAutomation_Document_Flow_AllowEdit
        {
            get { return officeAutomation_Document_Flow_AllowEdit; }
            set { officeAutomation_Document_Flow_AllowEdit = value; }
        }
    }
}
