using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 签名信息表
    /// </summary>
    public class T_OfficeAutomation_Sign
    {
        private int officeAutomation_Sign_ID;
        /// <summary>
        /// 签名信息主键
        /// </summary>
        public int OfficeAutomation_Sign_ID
        {
            get { return officeAutomation_Sign_ID; }
            set { officeAutomation_Sign_ID = value; }
        }
        private string officeAutomation_Sign_EmployeeID;
        /// <summary>
        /// 工号
        /// </summary>
        public string OfficeAutomation_Sign_EmployeeID
        {
            get { return officeAutomation_Sign_EmployeeID; }
            set { officeAutomation_Sign_EmployeeID = value; }
        }
        private string officeAutomation_Sign_Employee;
        /// <summary>
        /// 姓名
        /// </summary>
        public string OfficeAutomation_Sign_Employee
        {
            get { return officeAutomation_Sign_Employee; }
            set { officeAutomation_Sign_Employee = value; }
        }
        private string officeAutomation_Sign_Path;
        /// <summary>
        /// 图片路径
        /// </summary>
        public string OfficeAutomation_Sign_Path
        {
            get { return officeAutomation_Sign_Path; }
            set { officeAutomation_Sign_Path = value; }
        }
    }
}
