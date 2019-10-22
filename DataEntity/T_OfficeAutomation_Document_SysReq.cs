using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 软件系统开发需求申请表
    /// </summary>
    public class T_OfficeAutomation_Document_SysReq
    {
        private Guid officeAutomation_Document_SysReq_ID;
        /// <summary>
        ///软件系统开发需求申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_SysReq_ID
        {
            get { return officeAutomation_Document_SysReq_ID; }
            set { officeAutomation_Document_SysReq_ID = value; }
        }
        private Guid officeAutomation_Document_SysReq_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_SysReq_MainID
        {
            get { return officeAutomation_Document_SysReq_MainID; }
            set { officeAutomation_Document_SysReq_MainID = value; }
        }
        private Guid officeAutomation_Document_SysReq_DepartmentID;
        /// <summary>
        /// 发文部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_SysReq_DepartmentID
        {
            get { return officeAutomation_Document_SysReq_DepartmentID; }
            set { officeAutomation_Document_SysReq_DepartmentID = value; }
        }
        private string officeAutomation_Document_SysReq_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_SysReq_Department
        {
            get { return officeAutomation_Document_SysReq_Department; }
            set { officeAutomation_Document_SysReq_Department = value; }
        }
        private string officeAutomation_Document_SysReq_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_SysReq_Apply
        {
            get { return officeAutomation_Document_SysReq_Apply; }
            set { officeAutomation_Document_SysReq_Apply = value; }
        }
        private string officeAutomation_Document_SysReq_ApplyDepHeader;
        /// <summary>
        /// 申请部门主管
        /// </summary>
        public string OfficeAutomation_Document_SysReq_ApplyDepHeader
        {
            get { return officeAutomation_Document_SysReq_ApplyDepHeader; }
            set { officeAutomation_Document_SysReq_ApplyDepHeader = value; }
        }
        private DateTime officeAutomation_Document_SysReq_ApplyDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_SysReq_ApplyDate
        {
            get { return officeAutomation_Document_SysReq_ApplyDate; }
            set { officeAutomation_Document_SysReq_ApplyDate = value; }
        }

        private DateTime officeAutomation_Document_SysReq_HopeDate;
        /// <summary>
        /// 期望完成日期
        /// </summary>
        public DateTime OfficeAutomation_Document_SysReq_HopeDate
        {
            get { return officeAutomation_Document_SysReq_HopeDate; }
            set { officeAutomation_Document_SysReq_HopeDate = value; }
        }

        private string officeAutomation_Document_SysReq_SystemName;
        /// <summary>
        /// 系统名称
        /// </summary>
        public string OfficeAutomation_Document_SysReq_SystemName
        {
            get { return officeAutomation_Document_SysReq_SystemName; }
            set { officeAutomation_Document_SysReq_SystemName = value; }
        }

        private string officeAutomation_Document_SysReq_ReqContent;
        /// <summary>
        /// 需求内容
        /// </summary>
        public string OfficeAutomation_Document_SysReq_ReqContent
        {
            get { return officeAutomation_Document_SysReq_ReqContent; }
            set { officeAutomation_Document_SysReq_ReqContent = value; }
        }

        private string officeAutomation_Document_SysReq_Follower;
        /// <summary>
        /// 跟进人
        /// </summary>
        public string OfficeAutomation_Document_SysReq_Follower
        {
            get { return officeAutomation_Document_SysReq_Follower; }
            set { officeAutomation_Document_SysReq_Follower = value; }
        }

        private string officeAutomation_Document_SysReq_PlanTime;
        /// <summary>
        /// IT部预计完成时间
        /// </summary>
        public string OfficeAutomation_Document_SysReq_PlanTime
        {
            get { return officeAutomation_Document_SysReq_PlanTime; }
            set { officeAutomation_Document_SysReq_PlanTime = value; }
        }

        private string officeAutomation_Document_SysReq_TransferRemark;
        /// <summary>
        /// 转发说明
        /// </summary>
        public string OfficeAutomation_Document_SysReq_TransferRemark
        {
            get { return officeAutomation_Document_SysReq_TransferRemark; }
            set { officeAutomation_Document_SysReq_TransferRemark = value; }
        }
    }
}
