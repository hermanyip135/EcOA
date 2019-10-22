using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 退佣申请表
    /// </summary>
    public class T_OfficeAutomation_Document_ProjBaComm
    {
        private Guid officeAutomation_Document_ProjBaComm_ID;
        /// <summary>
        ///主键
        /// </summary>
        public Guid OfficeAutomation_Document_ProjBaComm_ID
        {
            get { return officeAutomation_Document_ProjBaComm_ID; }
            set { officeAutomation_Document_ProjBaComm_ID = value; }
        }

        private Guid officeAutomation_Document_ProjBaComm_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ProjBaComm_MainID
        {
            get { return officeAutomation_Document_ProjBaComm_MainID; }
            set { officeAutomation_Document_ProjBaComm_MainID = value; }
        }

        private string officeAutomation_Document_ProjBaComm_Apply;
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_ProjBaComm_Apply
        {
            get { return officeAutomation_Document_ProjBaComm_Apply; }
            set { officeAutomation_Document_ProjBaComm_Apply = value; }
        }

        private DateTime officeAutomation_Document_ProjBaComm_ApplyDate;
        /// <summary>
        /// 填写日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ProjBaComm_ApplyDate
        {
            get { return officeAutomation_Document_ProjBaComm_ApplyDate; }
            set { officeAutomation_Document_ProjBaComm_ApplyDate = value; }
        }

        private string officeAutomation_Document_ProjBaComm_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_ProjBaComm_ApplyID
        {
            get { return officeAutomation_Document_ProjBaComm_ApplyID; }
            set { officeAutomation_Document_ProjBaComm_ApplyID = value; }
        }

        private string officeAutomation_Document_ProjBaComm_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_ProjBaComm_Department
        {
            get { return officeAutomation_Document_ProjBaComm_Department; }
            set { officeAutomation_Document_ProjBaComm_Department = value; }
        }

        private string officeAutomation_Document_ProjBaComm_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ProjBaComm_ReplyPhone
        {
            get { return officeAutomation_Document_ProjBaComm_ReplyPhone; }
            set { officeAutomation_Document_ProjBaComm_ReplyPhone = value; }
        }

        private string officeAutomation_Document_ProjBaComm_Building;
        /// <summary>
        /// 楼盘单位
        /// </summary>
        public string OfficeAutomation_Document_ProjBaComm_Building
        {
            get { return officeAutomation_Document_ProjBaComm_Building; }
            set { officeAutomation_Document_ProjBaComm_Building = value; }
        }

        private string officeAutomation_Document_ProjBaComm_Reason;
        /// <summary>
        /// 退佣原因
        /// </summary>
        public string OfficeAutomation_Document_ProjBaComm_Reason
        {
            get { return officeAutomation_Document_ProjBaComm_Reason; }
            set { officeAutomation_Document_ProjBaComm_Reason = value; }
        }

        private decimal officeAutomation_Document_ProjBaComm_MoneyCount;
        /// <summary>
        /// 合计退佣金额
        /// </summary>
        public decimal OfficeAutomation_Document_ProjBaComm_MoneyCount
        {
            get { return officeAutomation_Document_ProjBaComm_MoneyCount; }
            set { officeAutomation_Document_ProjBaComm_MoneyCount = value; }
        }

        private string officeAutomation_Document_ProjBaComm_Measure;
        /// <summary>
        /// 内部处理方案
        /// </summary>
        public string OfficeAutomation_Document_ProjBaComm_Measure
        {
            get { return officeAutomation_Document_ProjBaComm_Measure; }
            set { officeAutomation_Document_ProjBaComm_Measure = value; }
        }

        private string officeAutomation_Document_ProjBaComm_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_ProjBaComm_Remark
        {
            get { return officeAutomation_Document_ProjBaComm_Remark; }
            set { officeAutomation_Document_ProjBaComm_Remark = value; }
        }

        private string _OfficeAutomation_Document_ProjBaComm_TurnBack;

        public string OfficeAutomation_Document_ProjBaComm_TurnBack
        {
            get { return _OfficeAutomation_Document_ProjBaComm_TurnBack; }
            set { _OfficeAutomation_Document_ProjBaComm_TurnBack = value; }
        }

        private string _OfficeAutomation_Document_ProjBaComm_BDeveloper;

        public string OfficeAutomation_Document_ProjBaComm_BDeveloper
        {
            get { return _OfficeAutomation_Document_ProjBaComm_BDeveloper; }
            set { _OfficeAutomation_Document_ProjBaComm_BDeveloper = value; }
        }
    }
}
