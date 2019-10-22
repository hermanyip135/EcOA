using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 公文流转主表 
    /// </summary>
    public class T_OfficeAutomation_Main
    {
        
        private Guid officeAutomation_Main_ID;
        
        /// <summary>
        /// 公文流转主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Main_ID
        {
            get { return officeAutomation_Main_ID; }
            set { officeAutomation_Main_ID = value; }
        }
        private string officeAutomation_SerialNumber;
        /// <summary>
        /// 公文流转流水号
        /// </summary>
        public string OfficeAutomation_SerialNumber
        {
            get { return officeAutomation_SerialNumber; }
            set { officeAutomation_SerialNumber = value; }
        }
        private int officeAutomation_DocumentID;
        /// <summary>
        /// 对应公文名称ID
        /// </summary>
        public int OfficeAutomation_DocumentID
        {
            get { return officeAutomation_DocumentID; }
            set { officeAutomation_DocumentID = value; }
        }

        private int officeAutomation_Main_FlowStateID;
        /// <summary>
        /// 流转状态ID
        /// </summary>
        public int OfficeAutomation_Main_FlowStateID
        {
            get { return officeAutomation_Main_FlowStateID; }
            set { officeAutomation_Main_FlowStateID = value; }
        }

        private string _OfficeAutomation_Main_AuditorIDsSum;
        /// <summary>
        /// 申请结束后审批人工号集合
        /// </summary>
        public string OfficeAutomation_Main_AuditorIDsSum
        {
            get { return _OfficeAutomation_Main_AuditorIDsSum; }
            set { _OfficeAutomation_Main_AuditorIDsSum = value; }
        }

        private string _OfficeAutomation_Main_AuditorNamesSum;
        /// <summary>
        /// 申请结束后审批人姓名集合
        /// </summary>
        public string OfficeAutomation_Main_AuditorNamesSum
        {
            get { return _OfficeAutomation_Main_AuditorNamesSum; }
            set { _OfficeAutomation_Main_AuditorNamesSum = value; }
        }

        private bool _OfficeAutomation_Main_IsBackUp;
        /// <summary>
        /// 是否已备份
        /// </summary>
        public bool OfficeAutomation_Main_IsBackUp
        {
            get { return _OfficeAutomation_Main_IsBackUp; }
            set { _OfficeAutomation_Main_IsBackUp = value; }
        }

        private bool _OfficeAutomation_Main_WillDelete;
        /// <summary>
        /// 是否即将被删除
        /// </summary>
        public bool OfficeAutomation_Main_WillDelete
        {
            get { return _OfficeAutomation_Main_WillDelete; }
            set { _OfficeAutomation_Main_WillDelete = value; }
        }

        private string _OfficeAutomation_Main_Creater;

        public string OfficeAutomation_Main_Creater
        {
            get { return _OfficeAutomation_Main_Creater; }
            set { _OfficeAutomation_Main_Creater = value; }
        }

        private DateTime? _OfficeAutomation_Main_CrTime;

        public DateTime? OfficeAutomation_Main_CrTime
        {
            get { return _OfficeAutomation_Main_CrTime; }
            set { _OfficeAutomation_Main_CrTime = value; }
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool OfficeAutomation_Main_IsDelete { get; set; }

        /// <summary>
        /// 申请部门
        /// </summary>
        public string OfficeAutomation_Main_Department { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Main_Apply { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime OfficeAutomation_Main_ApplyDate { get; set; }

        public string OfficeAutomation_Main_Sremark { get; set; }
        public string OfficeAutomation_Main_Summary { get; set; }
        public string OfficeAutomation_Main_IsGroups { get; set; }
    }
}
