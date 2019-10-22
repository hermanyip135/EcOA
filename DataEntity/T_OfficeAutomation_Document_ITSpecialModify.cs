using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 软件系统特殊修改申请表
    /// </summary>
    public class T_OfficeAutomation_Document_ITSpecialModify
    {
        private Guid officeAutomation_Document_ITSpecialModify_ID;
        /// <summary>
        ///软件系统特殊修改申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITSpecialModify_ID
        {
            get { return officeAutomation_Document_ITSpecialModify_ID; }
            set { officeAutomation_Document_ITSpecialModify_ID = value; }
        }
        private Guid officeAutomation_Document_ITSpecialModify_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITSpecialModify_MainID
        {
            get { return officeAutomation_Document_ITSpecialModify_MainID; }
            set { officeAutomation_Document_ITSpecialModify_MainID = value; }
        }
        private Guid officeAutomation_Document_ITSpecialModify_DepartmentID;
        /// <summary>
        /// 发文部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_ITSpecialModify_DepartmentID
        {
            get { return officeAutomation_Document_ITSpecialModify_DepartmentID; }
            set { officeAutomation_Document_ITSpecialModify_DepartmentID = value; }
        }
        private string officeAutomation_Document_ITSpecialModify_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_ITSpecialModify_Department
        {
            get { return officeAutomation_Document_ITSpecialModify_Department; }
            set { officeAutomation_Document_ITSpecialModify_Department = value; }
        }
        private string officeAutomation_Document_ITSpecialModify_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_ITSpecialModify_Apply
        {
            get { return officeAutomation_Document_ITSpecialModify_Apply; }
            set { officeAutomation_Document_ITSpecialModify_Apply = value; }
        }
        private string officeAutomation_Document_ITSpecialModify_ApplyDepHeader;
        /// <summary>
        /// 申请部门主管
        /// </summary>
        public string OfficeAutomation_Document_ITSpecialModify_ApplyDepHeader
        {
            get { return officeAutomation_Document_ITSpecialModify_ApplyDepHeader; }
            set { officeAutomation_Document_ITSpecialModify_ApplyDepHeader = value; }
        }
        private DateTime officeAutomation_Document_ITSpecialModify_ApplyDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ITSpecialModify_ApplyDate
        {
            get { return officeAutomation_Document_ITSpecialModify_ApplyDate; }
            set { officeAutomation_Document_ITSpecialModify_ApplyDate = value; }
        }

        private DateTime officeAutomation_Document_ITSpecialModify_HopeDate;
        /// <summary>
        /// 期望完成日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ITSpecialModify_HopeDate
        {
            get { return officeAutomation_Document_ITSpecialModify_HopeDate; }
            set { officeAutomation_Document_ITSpecialModify_HopeDate = value; }
        }

        private string officeAutomation_Document_ITSpecialModify_SystemName;
        /// <summary>
        /// 系统名称
        /// </summary>
        public string OfficeAutomation_Document_ITSpecialModify_SystemName
        {
            get { return officeAutomation_Document_ITSpecialModify_SystemName; }
            set { officeAutomation_Document_ITSpecialModify_SystemName = value; }
        }

        private string officeAutomation_Document_ITSpecialModify_ReqContent;
        /// <summary>
        /// 需求内容
        /// </summary>
        public string OfficeAutomation_Document_ITSpecialModify_ReqContent
        {
            get { return officeAutomation_Document_ITSpecialModify_ReqContent; }
            set { officeAutomation_Document_ITSpecialModify_ReqContent = value; }
        }

        private string officeAutomation_Document_ITSpecialModify_Follower;
        /// <summary>
        /// 跟进人
        /// </summary>
        public string OfficeAutomation_Document_ITSpecialModify_Follower
        {
            get { return officeAutomation_Document_ITSpecialModify_Follower; }
            set { officeAutomation_Document_ITSpecialModify_Follower = value; }
        }

        private string officeAutomation_Document_ITSpecialModify_PlanTime;
        /// <summary>
        /// IT部预计完成时间
        /// </summary>
        public string OfficeAutomation_Document_ITSpecialModify_PlanTime
        {
            get { return officeAutomation_Document_ITSpecialModify_PlanTime; }
            set { officeAutomation_Document_ITSpecialModify_PlanTime = value; }
        }

        private string officeAutomation_Document_ITSpecialModify_TransferRemark;
        /// <summary>
        /// 转发说明
        /// </summary>
        public string OfficeAutomation_Document_ITSpecialModify_TransferRemark
        {
            get { return officeAutomation_Document_ITSpecialModify_TransferRemark; }
            set { officeAutomation_Document_ITSpecialModify_TransferRemark = value; }
        }
    }
}
