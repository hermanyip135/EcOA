using System;

namespace DataEntity
{
    /// <summary>
    /// (汇瀚/二级市场/后勤)IT权限申请表
    /// </summary>
    public class T_OfficeAutomation_Document_SysPower
    {
        private Guid officeAutomation_Document_SysPower_ID;
        /// <summary>
        ///(汇瀚/二级市场/后勤)IT权限申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_SysPower_ID
        {
            get { return officeAutomation_Document_SysPower_ID; }
            set { officeAutomation_Document_SysPower_ID = value; }
        }
        private Guid officeAutomation_Document_SysPower_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_SysPower_MainID
        {
            get { return officeAutomation_Document_SysPower_MainID; }
            set { officeAutomation_Document_SysPower_MainID = value; }
        }
        private Guid officeAutomation_Document_SysPower_DepartmentID;
        /// <summary>
        /// 发文部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_SysPower_DepartmentID
        {
            get { return officeAutomation_Document_SysPower_DepartmentID; }
            set { officeAutomation_Document_SysPower_DepartmentID = value; }
        }
        private string officeAutomation_Document_SysPower_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_SysPower_Department
        {
            get { return officeAutomation_Document_SysPower_Department; }
            set { officeAutomation_Document_SysPower_Department = value; }
        }
        private string officeAutomation_Document_SysPower_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_SysPower_Apply
        {
            get { return officeAutomation_Document_SysPower_Apply; }
            set { officeAutomation_Document_SysPower_Apply = value; }
        }
        private string officeAutomation_Document_SysPower_Phone;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string OfficeAutomation_Document_SysPower_Phone
        {
            get { return officeAutomation_Document_SysPower_Phone; }
            set { officeAutomation_Document_SysPower_Phone = value; }
        }
        private DateTime officeAutomation_Document_SysPower_ApplyDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_SysPower_ApplyDate
        {
            get { return officeAutomation_Document_SysPower_ApplyDate; }
            set { officeAutomation_Document_SysPower_ApplyDate = value; }
        }

        private string officeAutomation_Document_SysPower_ReqContent;
        /// <summary>
        /// 申请内容
        /// </summary>
        public string OfficeAutomation_Document_SysPower_ReqContent
        {
            get { return officeAutomation_Document_SysPower_ReqContent; }
            set { officeAutomation_Document_SysPower_ReqContent = value; }
        }

        private string officeAutomation_Document_SysPower_Deal;
        /// <summary>
        /// 处理情况
        /// </summary>
        public string OfficeAutomation_Document_SysPower_Deal
        {
            get { return officeAutomation_Document_SysPower_Deal; }
            set { officeAutomation_Document_SysPower_Deal = value; }
        }
    }
}
