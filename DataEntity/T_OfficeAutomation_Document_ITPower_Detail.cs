using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// IT权限申请明细表
    /// </summary>
    public class T_OfficeAutomation_Document_ITPower_Detail
    {
        private Guid officeAutomation_Document_ITPower_Detail_ID;
        /// <summary>
        /// IT权限申请明细主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITPower_Detail_ID
        {
            get { return officeAutomation_Document_ITPower_Detail_ID; }
            set { officeAutomation_Document_ITPower_Detail_ID = value; }
        }
        private Guid officeAutomation_Document_ITPower_Detail_MainID;
        /// <summary>
        /// IT权限申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITPower_Detail_MainID
        {
            get { return officeAutomation_Document_ITPower_Detail_MainID; }
            set { officeAutomation_Document_ITPower_Detail_MainID = value; }
        }
        private string officeAutomation_Document_ITPower_Detail_EmployeeID;
        /// <summary>
        /// 工号
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Detail_EmployeeID
        {
            get { return officeAutomation_Document_ITPower_Detail_EmployeeID; }
            set { officeAutomation_Document_ITPower_Detail_EmployeeID = value; }
        }
        private string officeAutomation_Document_ITPower_Detail_Employee;
        /// <summary>
        /// 姓名
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Detail_Employee
        {
            get { return officeAutomation_Document_ITPower_Detail_Employee; }
            set { officeAutomation_Document_ITPower_Detail_Employee = value; }
        }
        private string officeAutomation_Document_ITPower_Detail_Position;
        /// <summary>
        /// 职位
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Detail_Position
        {
            get { return officeAutomation_Document_ITPower_Detail_Position; }
            set { officeAutomation_Document_ITPower_Detail_Position = value; }
        }
        private string officeAutomation_Document_ITPower_Detail_Department;
        /// <summary>
        /// 部门
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Detail_Department
        {
            get { return officeAutomation_Document_ITPower_Detail_Department; }
            set { officeAutomation_Document_ITPower_Detail_Department = value; }
        }
        private Guid officeAutomation_Document_ITPower_Detail_DepartmentID;
        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_ITPower_Detail_DepartmentID
        {
            get { return officeAutomation_Document_ITPower_Detail_DepartmentID; }
            set { officeAutomation_Document_ITPower_Detail_DepartmentID = value; }
        }
        private DateTime officeAutomation_Document_ITPower_Detail_BeginDate;
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ITPower_Detail_BeginDate
        {
            get { return officeAutomation_Document_ITPower_Detail_BeginDate; }
            set { officeAutomation_Document_ITPower_Detail_BeginDate = value; }
        }
        private int officeAutomation_Document_ITPower_Detail_ApplyTypeID;
        /// <summary>
        /// 申请性质ID
        /// </summary>
        public int OfficeAutomation_Document_ITPower_Detail_ApplyTypeID
        {
            get { return officeAutomation_Document_ITPower_Detail_ApplyTypeID; }
            set { officeAutomation_Document_ITPower_Detail_ApplyTypeID = value; }
        }
        private string officeAutomation_Document_ITPower_Detail_Client;
        /// <summary>
        /// 客源转移
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Detail_Client
        {
            get { return officeAutomation_Document_ITPower_Detail_Client; }
            set { officeAutomation_Document_ITPower_Detail_Client = value; }
        }
        private string officeAutomation_Document_ITPower_Detail_House;
        /// <summary>
        /// 房源转移
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Detail_House
        {
            get { return officeAutomation_Document_ITPower_Detail_House; }
            set { officeAutomation_Document_ITPower_Detail_House = value; }
        }
        private string officeAutomation_Document_ITPower_Detail_ImportDepartment;
        /// <summary>
        /// 调入部门
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Detail_ImportDepartment
        {
            get { return officeAutomation_Document_ITPower_Detail_ImportDepartment; }
            set { officeAutomation_Document_ITPower_Detail_ImportDepartment = value; }
        }
        private Guid officeAutomation_Document_ITPower_Detail_ImportDeaprtmentID;
        /// <summary>
        /// 调入部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_ITPower_Detail_ImportDeaprtmentID
        {
            get { return officeAutomation_Document_ITPower_Detail_ImportDeaprtmentID; }
            set { officeAutomation_Document_ITPower_Detail_ImportDeaprtmentID = value; }
        }
        private string officeAutomation_Document_ITPower_Detail_ExportDepartment;
        /// <summary>
        /// 调出部门
        /// </summary>
        public string OfficeAutomation_Document_ITPower_Detail_ExportDepartment
        {
            get { return officeAutomation_Document_ITPower_Detail_ExportDepartment; }
            set { officeAutomation_Document_ITPower_Detail_ExportDepartment = value; }
        }
        private Guid officeAutomation_Document_ITPower_Detail_ExportDepartmentID;
        /// <summary>
        /// 调出部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_ITPower_Detail_ExportDepartmentID
        {
            get { return officeAutomation_Document_ITPower_Detail_ExportDepartmentID; }
            set { officeAutomation_Document_ITPower_Detail_ExportDepartmentID = value; }
        }
        //A+主号
        public string OfficeAutomation_Document_ITPower_Detail_ANumber { get; set; }
    }
}
