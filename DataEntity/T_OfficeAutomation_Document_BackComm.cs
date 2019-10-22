using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 退佣申请表
    /// </summary>
    public class T_OfficeAutomation_Document_BackComm
    {
        private Guid officeAutomation_Document_BackComm_ID;
        /// <summary>
        ///主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_BackComm_ID
        {
            get { return officeAutomation_Document_BackComm_ID; }
            set { officeAutomation_Document_BackComm_ID = value; }
        }

        private Guid officeAutomation_Document_BackComm_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_BackComm_MainID
        {
            get { return officeAutomation_Document_BackComm_MainID; }
            set { officeAutomation_Document_BackComm_MainID = value; }
        }

        private string officeAutomation_Document_BackComm_Apply;
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Apply
        {
            get { return officeAutomation_Document_BackComm_Apply; }
            set { officeAutomation_Document_BackComm_Apply = value; }
        }

        private DateTime officeAutomation_Document_BackComm_ApplyDate;
        /// <summary>
        /// 填写日期
        /// </summary>
        public DateTime OfficeAutomation_Document_BackComm_ApplyDate
        {
            get { return officeAutomation_Document_BackComm_ApplyDate; }
            set { officeAutomation_Document_BackComm_ApplyDate = value; }
        }

        private string officeAutomation_Document_BackComm_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_BackComm_ApplyID
        {
            get { return officeAutomation_Document_BackComm_ApplyID; }
            set { officeAutomation_Document_BackComm_ApplyID = value; }
        }

        private string officeAutomation_Document_BackComm_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Department
        {
            get { return officeAutomation_Document_BackComm_Department; }
            set { officeAutomation_Document_BackComm_Department = value; }
        }

        private string officeAutomation_Document_BackComm_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_BackComm_ReplyPhone
        {
            get { return officeAutomation_Document_BackComm_ReplyPhone; }
            set { officeAutomation_Document_BackComm_ReplyPhone = value; }
        }

        private string officeAutomation_Document_BackComm_Building;
        /// <summary>
        /// 楼盘单位
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Building
        {
            get { return officeAutomation_Document_BackComm_Building; }
            set { officeAutomation_Document_BackComm_Building = value; }
        }

        private string officeAutomation_Document_BackComm_Reason;
        /// <summary>
        /// 退佣原因
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Reason
        {
            get { return officeAutomation_Document_BackComm_Reason; }
            set { officeAutomation_Document_BackComm_Reason = value; }
        }

        private decimal officeAutomation_Document_BackComm_MoneyCount;
        /// <summary>
        /// 合计退佣金额
        /// </summary>
        public decimal OfficeAutomation_Document_BackComm_MoneyCount
        {
            get { return officeAutomation_Document_BackComm_MoneyCount; }
            set { officeAutomation_Document_BackComm_MoneyCount = value; }
        }

        private string officeAutomation_Document_BackComm_Measure;
        /// <summary>
        /// 内部处理方案
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Measure
        {
            get { return officeAutomation_Document_BackComm_Measure; }
            set { officeAutomation_Document_BackComm_Measure = value; }
        }

        private string officeAutomation_Document_BackComm_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Remark
        {
            get { return officeAutomation_Document_BackComm_Remark; }
            set { officeAutomation_Document_BackComm_Remark = value; }
        }
    }
}
