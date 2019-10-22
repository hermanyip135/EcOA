using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 营运部门自组织外出活动申请
    /// </summary>
    public class T_OfficeAutomation_Document_Tourism
    {
        private Guid _OfficeAutomation_Document_Tourism_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_Tourism_ID
        {
            get { return _OfficeAutomation_Document_Tourism_ID; }
            set { _OfficeAutomation_Document_Tourism_ID = value; }
        }

        private Guid _OfficeAutomation_Document_Tourism_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_Tourism_MainID
        {
            get { return _OfficeAutomation_Document_Tourism_MainID; }
            set { _OfficeAutomation_Document_Tourism_MainID = value; }
        }

        private string _OfficeAutomation_Document_Tourism_Apply;
        /// <summary>
        /// 发文人员
        /// </summary>
        public string OfficeAutomation_Document_Tourism_Apply
        {
            get { return _OfficeAutomation_Document_Tourism_Apply; }
            set { _OfficeAutomation_Document_Tourism_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_Tourism_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_Tourism_ApplyDate
        {
            get { return _OfficeAutomation_Document_Tourism_ApplyDate; }
            set { _OfficeAutomation_Document_Tourism_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_Tourism_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_Tourism_ApplyID
        {
            get { return _OfficeAutomation_Document_Tourism_ApplyID; }
            set { _OfficeAutomation_Document_Tourism_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_Tourism_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_Tourism_Department
        {
            get { return _OfficeAutomation_Document_Tourism_Department; }
            set { _OfficeAutomation_Document_Tourism_Department = value; }
        }

        private string _OfficeAutomation_Document_Tourism_Subject;
        /// <summary>
        /// 文件主题
        /// </summary>
        public string OfficeAutomation_Document_Tourism_Subject
        {
            get { return _OfficeAutomation_Document_Tourism_Subject; }
            set { _OfficeAutomation_Document_Tourism_Subject = value; }
        }

        private string _OfficeAutomation_Document_Tourism_ReplyPhone;
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_Tourism_ReplyPhone
        {
            get { return _OfficeAutomation_Document_Tourism_ReplyPhone; }
            set { _OfficeAutomation_Document_Tourism_ReplyPhone = value; }
        }

        private string _OfficeAutomation_Document_Tourism_Reason;
        /// <summary>
        /// 自组织外出活动原因
        /// </summary>
        public string OfficeAutomation_Document_Tourism_Reason
        {
            get { return _OfficeAutomation_Document_Tourism_Reason; }
            set { _OfficeAutomation_Document_Tourism_Reason = value; }
        }

        private string _OfficeAutomation_Document_Tourism_ActivityData;
        /// <summary>
        /// 活动开始时间
        /// </summary>
        public string OfficeAutomation_Document_Tourism_ActivityData
        {
            get { return _OfficeAutomation_Document_Tourism_ActivityData; }
            set { _OfficeAutomation_Document_Tourism_ActivityData = value; }
        }

        private string _OfficeAutomation_Document_Tourism_ActivityEndData;
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public string OfficeAutomation_Document_Tourism_ActivityEndData
        {
            get { return _OfficeAutomation_Document_Tourism_ActivityEndData; }
            set { _OfficeAutomation_Document_Tourism_ActivityEndData = value; }
        }

        private string _OfficeAutomation_Document_Tourism_ActivityPlace;
        /// <summary>
        /// 活动地点
        /// </summary>
        public string OfficeAutomation_Document_Tourism_ActivityPlace
        {
            get { return _OfficeAutomation_Document_Tourism_ActivityPlace; }
            set { _OfficeAutomation_Document_Tourism_ActivityPlace = value; }
        }

        private bool _OfficeAutomation_Document_Tourism_Insurance;
        /// <summary>
        /// 是否购买人身旅游意外保险
        /// </summary>
        public bool OfficeAutomation_Document_Tourism_Insurance
        {
            get { return _OfficeAutomation_Document_Tourism_Insurance; }
            set { _OfficeAutomation_Document_Tourism_Insurance = value; }
        }

        private string _OfficeAutomation_Document_Tourism_NoInsurance;
        /// <summary>
        /// 不买保险原因
        /// </summary>
        public string OfficeAutomation_Document_Tourism_NoInsurance
        {
            get { return _OfficeAutomation_Document_Tourism_NoInsurance; }
            set { _OfficeAutomation_Document_Tourism_NoInsurance = value; }
        }

        private bool _OfficeAutomation_Document_Tourism_Operating;
        /// <summary>
        /// 外出当天分行是否运营
        /// </summary>
        public bool OfficeAutomation_Document_Tourism_Operating
        {
            get { return _OfficeAutomation_Document_Tourism_Operating; }
            set { _OfficeAutomation_Document_Tourism_Operating = value; }
        }

        private string _OfficeAutomation_Document_Tourism_OperatingArrange;
        /// <summary>
        /// 运营安排
        /// </summary>
        public string OfficeAutomation_Document_Tourism_OperatingArrange
        {
            get { return _OfficeAutomation_Document_Tourism_OperatingArrange; }
            set { _OfficeAutomation_Document_Tourism_OperatingArrange = value; }
        }

        private string _OfficeAutomation_Document_Tourism_Area;

        public string OfficeAutomation_Document_Tourism_Area
        {
            get { return _OfficeAutomation_Document_Tourism_Area; }
            set { _OfficeAutomation_Document_Tourism_Area = value; }
        }

        private int _OfficeAutomation_Document_Tourism_Attendance;
        /// <summary>
        /// 考勤处理方式
        /// </summary>
        public int OfficeAutomation_Document_Tourism_Attendance
        {
            get { return _OfficeAutomation_Document_Tourism_Attendance; }
            set { _OfficeAutomation_Document_Tourism_Attendance = value; }
        }

        private string _OfficeAutomation_Document_Tourism_Organizer;
        public string OfficeAutomation_Document_Tourism_Organizer
        {
            get { return _OfficeAutomation_Document_Tourism_Organizer; }
            set { _OfficeAutomation_Document_Tourism_Organizer = value; }
        }

        private string _OfficeAutomation_Document_Tourism_OtherMemo;
        public string OfficeAutomation_Document_Tourism_OtherMemo
        {
            get { return _OfficeAutomation_Document_Tourism_OtherMemo; }
            set { _OfficeAutomation_Document_Tourism_OtherMemo = value; }
        }
    }
}
