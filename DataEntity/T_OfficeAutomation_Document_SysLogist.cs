using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 软件系统开发需求申请表
    /// </summary>
    public class T_OfficeAutomation_Document_SysLogist
    {
        private Guid officeAutomation_Document_SysLogist_ID;
        /// <summary>
        ///软件系统开发需求申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_SysLogist_ID
        {
            get { return officeAutomation_Document_SysLogist_ID; }
            set { officeAutomation_Document_SysLogist_ID = value; }
        }
        private Guid officeAutomation_Document_SysLogist_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_SysLogist_MainID
        {
            get { return officeAutomation_Document_SysLogist_MainID; }
            set { officeAutomation_Document_SysLogist_MainID = value; }
        }
        private Guid officeAutomation_Document_SysLogist_DepartmentID;
        /// <summary>
        /// 发文部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_SysLogist_DepartmentID
        {
            get { return officeAutomation_Document_SysLogist_DepartmentID; }
            set { officeAutomation_Document_SysLogist_DepartmentID = value; }
        }
        private string officeAutomation_Document_SysLogist_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_SysLogist_Department
        {
            get { return officeAutomation_Document_SysLogist_Department; }
            set { officeAutomation_Document_SysLogist_Department = value; }
        }
        private string officeAutomation_Document_SysLogist_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_SysLogist_Apply
        {
            get { return officeAutomation_Document_SysLogist_Apply; }
            set { officeAutomation_Document_SysLogist_Apply = value; }
        }
        private string officeAutomation_Document_SysLogist_ApplyDepHeader;
        /// <summary>
        /// 申请部门主管
        /// </summary>
        public string OfficeAutomation_Document_SysLogist_ApplyDepHeader
        {
            get { return officeAutomation_Document_SysLogist_ApplyDepHeader; }
            set { officeAutomation_Document_SysLogist_ApplyDepHeader = value; }
        }
        private DateTime officeAutomation_Document_SysLogist_ApplyDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_SysLogist_ApplyDate
        {
            get { return officeAutomation_Document_SysLogist_ApplyDate; }
            set { officeAutomation_Document_SysLogist_ApplyDate = value; }
        }

        private DateTime officeAutomation_Document_SysLogist_HopeDate;
        /// <summary>
        /// 期望完成日期
        /// </summary>
        public DateTime OfficeAutomation_Document_SysLogist_HopeDate
        {
            get { return officeAutomation_Document_SysLogist_HopeDate; }
            set { officeAutomation_Document_SysLogist_HopeDate = value; }
        }

        private string officeAutomation_Document_SysLogist_SystemName;
        /// <summary>
        /// 系统名称
        /// </summary>
        public string OfficeAutomation_Document_SysLogist_SystemName
        {
            get { return officeAutomation_Document_SysLogist_SystemName; }
            set { officeAutomation_Document_SysLogist_SystemName = value; }
        }

        private string officeAutomation_Document_SysLogist_ReqContent;
        /// <summary>
        /// 需求内容
        /// </summary>
        public string OfficeAutomation_Document_SysLogist_ReqContent
        {
            get { return officeAutomation_Document_SysLogist_ReqContent; }
            set { officeAutomation_Document_SysLogist_ReqContent = value; }
        }

        private string officeAutomation_Document_SysLogist_Follower;
        /// <summary>
        /// 跟进人
        /// </summary>
        public string OfficeAutomation_Document_SysLogist_Follower
        {
            get { return officeAutomation_Document_SysLogist_Follower; }
            set { officeAutomation_Document_SysLogist_Follower = value; }
        }

        private string officeAutomation_Document_SysLogist_PlanTime;
        /// <summary>
        /// IT部预计完成时间
        /// </summary>
        public string OfficeAutomation_Document_SysLogist_PlanTime
        {
            get { return officeAutomation_Document_SysLogist_PlanTime; }
            set { officeAutomation_Document_SysLogist_PlanTime = value; }
        }

        private string officeAutomation_Document_SysLogist_TransferRemark;
        /// <summary>
        /// 转发说明
        /// </summary>
        public string OfficeAutomation_Document_SysLogist_TransferRemark
        {
            get { return officeAutomation_Document_SysLogist_TransferRemark; }
            set { officeAutomation_Document_SysLogist_TransferRemark = value; }
        }
    }
}
