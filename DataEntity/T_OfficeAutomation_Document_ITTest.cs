using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 软件系统测试需求申请表
    /// </summary>
    public class T_OfficeAutomation_Document_ITTest
    {
        private Guid officeAutomation_Document_ITTest_ID;
        /// <summary>
        /// 软件系统测试需求申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITTest_ID
        {
            get { return officeAutomation_Document_ITTest_ID; }
            set { officeAutomation_Document_ITTest_ID = value; }
        }


        private Guid officeAutomation_Document_ITTest_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITTest_MainID
        {
            get { return officeAutomation_Document_ITTest_MainID; }
            set { officeAutomation_Document_ITTest_MainID = value; }
        }

        private string officeAutomation_Document_ITTest_Apply;
        /// <summary>
        ///申请人
        /// </summary>
        public string OfficeAutomation_Document_ITTest_Apply
        {
            get { return officeAutomation_Document_ITTest_Apply; }
            set { officeAutomation_Document_ITTest_Apply = value; }
        }

        private DateTime officeAutomation_Document_ITTest_HopeDate;
        /// <summary>
        ///期望完成时间
        /// </summary>
        public DateTime OfficeAutomation_Document_ITTest_HopeDate
        {
            get { return officeAutomation_Document_ITTest_HopeDate; }
            set { officeAutomation_Document_ITTest_HopeDate = value; }
        }


        private DateTime officeAutomation_Document_ITTest_ApplyDate;
        /// <summary>
        ///申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ITTest_ApplyDate
        {
            get { return officeAutomation_Document_ITTest_ApplyDate; }
            set { officeAutomation_Document_ITTest_ApplyDate = value; }
        }


        private string officeAutomation_Document_ITTest_ReqContent;
        /// <summary>
        ///测试内容
        /// </summary>
        public string OfficeAutomation_Document_ITTest_ReqContent
        {
            get { return officeAutomation_Document_ITTest_ReqContent; }
            set { officeAutomation_Document_ITTest_ReqContent = value; }
        }

        private string officeAutomation_Document_ITTest_ReqReply;
        /// <summary>
        ///测试回复
        /// </summary>
        public string OfficeAutomation_Document_ITTest_ReqReply
        {
            get { return officeAutomation_Document_ITTest_ReqReply; }
            set { officeAutomation_Document_ITTest_ReqReply = value; }
        }


        private Nullable<DateTime> officeAutomation_Document_ITTest_ReqReplyDate;
        /// <summary>
        ///测试回复时间
        /// </summary>
        public Nullable<DateTime> OfficeAutomation_Document_ITTest_ReqReplyDate
        {
            get { return officeAutomation_Document_ITTest_ReqReplyDate; }
            set { officeAutomation_Document_ITTest_ReqReplyDate = value; }
        }


        private string officeAutomation_Document_ITTest_SystemName;
        /// <summary>
        ///系统名称
        /// </summary>
        public string OfficeAutomation_Document_ITTest_SystemName
        {
            get { return officeAutomation_Document_ITTest_SystemName; }
            set { officeAutomation_Document_ITTest_SystemName = value; }
        }

        private string officeAutomation_Document_ITTest_Receiver;
        /// <summary>
        ///测试人
        /// </summary>
        public string OfficeAutomation_Document_ITTest_Receiver
        {
            get { return officeAutomation_Document_ITTest_Receiver; }
            set { officeAutomation_Document_ITTest_Receiver = value; }
        }

        private Guid officeAutomation_Document_ITTest_DepartmentID;
        /// <summary>
        ///发文部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_ITTest_DepartmentID
        {
            get { return officeAutomation_Document_ITTest_DepartmentID; }
            set { officeAutomation_Document_ITTest_DepartmentID = value; }
        }

        private string officeAutomation_Document_ITTest_Department;
        /// <summary>
        ///发文部门
        /// </summary>
        public string OfficeAutomation_Document_ITTest_Department
        {
            get { return officeAutomation_Document_ITTest_Department; }
            set { officeAutomation_Document_ITTest_Department = value; }
        }
    }
}
