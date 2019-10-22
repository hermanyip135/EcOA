using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 员工个人利益申请表
    /// </summary>
    public class T_OfficeAutomation_Document_PersInterests
    {
        private Guid officeAutomation_Document_PersInterests_ID;
        /// <summary>
        ///员工个人利益申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_PersInterests_ID
        {
            get { return officeAutomation_Document_PersInterests_ID; }
            set { officeAutomation_Document_PersInterests_ID = value; }
        }
        private Guid officeAutomation_Document_PersInterests_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_PersInterests_MainID
        {
            get { return officeAutomation_Document_PersInterests_MainID; }
            set { officeAutomation_Document_PersInterests_MainID = value; }
        }

        private int officeAutomation_Document_PersInterests_DepartmentTypeID;
        /// <summary>
        /// 申请部门性质主键
        /// </summary>
        public int OfficeAutomation_Document_PersInterests_DepartmentTypeID
        {
            get { return officeAutomation_Document_PersInterests_DepartmentTypeID; }
            set { officeAutomation_Document_PersInterests_DepartmentTypeID = value; }
        }

        private string officeAutomation_Document_PersInterests_Department;
        /// <summary>
        /// 申请部门
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_Department
        {
            get { return officeAutomation_Document_PersInterests_Department; }
            set { officeAutomation_Document_PersInterests_Department = value; }
        }

        private string officeAutomation_Document_PersInterests_Apply;
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_Apply
        {
            get { return officeAutomation_Document_PersInterests_Apply; }
            set { officeAutomation_Document_PersInterests_Apply = value; }
        }

        private DateTime officeAutomation_Document_PersInterests_ApplyDate;
        /// <summary>
        /// 填写日期
        /// </summary>
        public DateTime OfficeAutomation_Document_PersInterests_ApplyDate
        {
            get { return officeAutomation_Document_PersInterests_ApplyDate; }
            set { officeAutomation_Document_PersInterests_ApplyDate = value; }
        }

        private string officeAutomation_Document_PersInterests_ApplyForID;
        /// <summary>
        /// 申请人工号
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_ApplyForID
        {
            get { return officeAutomation_Document_PersInterests_ApplyForID; }
            set { officeAutomation_Document_PersInterests_ApplyForID = value; }
        }

        private string officeAutomation_Document_PersInterests_ApplyFor;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_ApplyFor
        {
            get { return officeAutomation_Document_PersInterests_ApplyFor; }
            set { officeAutomation_Document_PersInterests_ApplyFor = value; }
        }

        private DateTime officeAutomation_Document_PersInterests_ApplyForDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_PersInterests_ApplyForDate
        {
            get { return officeAutomation_Document_PersInterests_ApplyForDate; }
            set { officeAutomation_Document_PersInterests_ApplyForDate = value; }
        }

        private int officeAutomation_Document_PersInterests_InterestsTypeID;
        /// <summary>
        /// 利益申报类别主键
        /// </summary>
        public int OfficeAutomation_Document_PersInterests_InterestsTypeID
        {
            get { return officeAutomation_Document_PersInterests_InterestsTypeID; }
            set { officeAutomation_Document_PersInterests_InterestsTypeID = value; }
        }

        private string officeAutomation_Document_PersInterests_FollowerID;
        /// <summary>
        /// 跟进人工号
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_FollowerID
        {
            get { return officeAutomation_Document_PersInterests_FollowerID; }
            set { officeAutomation_Document_PersInterests_FollowerID = value; }
        }

        private string officeAutomation_Document_PersInterests_Follower;
        /// <summary>
        /// 跟进人
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_Follower
        {
            get { return officeAutomation_Document_PersInterests_Follower; }
            set { officeAutomation_Document_PersInterests_Follower = value; }
        }

        private string officeAutomation_Document_PersInterests_FollowerDepartment;
        /// <summary>
        /// 跟进分行
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_FollowerDepartment
        {
            get { return officeAutomation_Document_PersInterests_FollowerDepartment; }
            set { officeAutomation_Document_PersInterests_FollowerDepartment = value; }
        }

        private string officeAutomation_Document_PersInterests_Address;
        /// <summary>
        /// 房产地址
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_Address
        {
            get { return officeAutomation_Document_PersInterests_Address; }
            set { officeAutomation_Document_PersInterests_Address = value; }
        }

        private int officeAutomation_Document_PersInterests_DealTypeID;
        /// <summary>
        /// 房产成交性质主键
        /// </summary>
        public int OfficeAutomation_Document_PersInterests_DealTypeID
        {
            get { return officeAutomation_Document_PersInterests_DealTypeID; }
            set { officeAutomation_Document_PersInterests_DealTypeID = value; }
        }

        private string officeAutomation_Document_PersInterests_Relative;
        /// <summary>
        /// 亲属姓名
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_Relative
        {
            get { return officeAutomation_Document_PersInterests_Relative; }
            set { officeAutomation_Document_PersInterests_Relative = value; }
        }

        private string officeAutomation_Document_PersInterests_RelativeDepartment;
        /// <summary>
        /// 亲属所在部门
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_RelativeDepartment
        {
            get { return officeAutomation_Document_PersInterests_RelativeDepartment; }
            set { officeAutomation_Document_PersInterests_RelativeDepartment = value; }
        }

        private string officeAutomation_Document_PersInterests_RelativePosition;
        /// <summary>
        /// 亲属担任职位
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_RelativePosition
        {
            get { return officeAutomation_Document_PersInterests_RelativePosition; }
            set { officeAutomation_Document_PersInterests_RelativePosition = value; }
        }

        private string officeAutomation_Document_PersInterests_RelativeRelation;
        /// <summary>
        /// 与亲属关系
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_RelativeRelation
        {
            get { return officeAutomation_Document_PersInterests_RelativeRelation; }
            set { officeAutomation_Document_PersInterests_RelativeRelation = value; }
        }

        private string officeAutomation_Document_PersInterests_ApplyDetail;
        /// <summary>
        /// 申请内容
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_ApplyDetail
        {
            get { return officeAutomation_Document_PersInterests_ApplyDetail; }
            set { officeAutomation_Document_PersInterests_ApplyDetail = value; }
        }

        private string officeAutomation_Document_PersInterests_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_PersInterests_Remark
        {
            get { return officeAutomation_Document_PersInterests_Remark; }
            set { officeAutomation_Document_PersInterests_Remark = value; }
        }
    }
}
