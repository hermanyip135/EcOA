using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 小汽车津贴申请表
    /// </summary>
    public class T_OfficeAutomation_Document_ProjectCarAllowance
    {
        private Guid officeAutomation_Document_ProjectCarAllowance_ID;
        /// <summary>
        ///主键
        /// </summary>
        public Guid OfficeAutomation_Document_ProjectCarAllowance_ID
        {
            get { return officeAutomation_Document_ProjectCarAllowance_ID; }
            set { officeAutomation_Document_ProjectCarAllowance_ID = value; }
        }

        private Guid officeAutomation_Document_ProjectCarAllowance_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ProjectCarAllowance_MainID
        {
            get { return officeAutomation_Document_ProjectCarAllowance_MainID; }
            set { officeAutomation_Document_ProjectCarAllowance_MainID = value; }
        }

        private string officeAutomation_Document_ProjectCarAllowance_Apply;
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_ProjectCarAllowance_Apply
        {
            get { return officeAutomation_Document_ProjectCarAllowance_Apply; }
            set { officeAutomation_Document_ProjectCarAllowance_Apply = value; }
        }

        private DateTime officeAutomation_Document_ProjectCarAllowance_ApplyDate;
        /// <summary>
        /// 填写日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ProjectCarAllowance_ApplyDate
        {
            get { return officeAutomation_Document_ProjectCarAllowance_ApplyDate; }
            set { officeAutomation_Document_ProjectCarAllowance_ApplyDate = value; }
        }

        private string officeAutomation_Document_ProjectCarAllowance_ApplyForName;
        /// <summary>
        /// 申报人姓名
        /// </summary>
        public string OfficeAutomation_Document_ProjectCarAllowance_ApplyForName
        {
            get { return officeAutomation_Document_ProjectCarAllowance_ApplyForName; }
            set { officeAutomation_Document_ProjectCarAllowance_ApplyForName = value; }
        }

        private string officeAutomation_Document_ProjectCarAllowance_ApplyForCode;
        /// <summary>
        /// 申报人工号
        /// </summary>
        public string OfficeAutomation_Document_ProjectCarAllowance_ApplyForCode
        {
            get { return officeAutomation_Document_ProjectCarAllowance_ApplyForCode; }
            set { officeAutomation_Document_ProjectCarAllowance_ApplyForCode = value; }
        }

        private DateTime officeAutomation_Document_ProjectCarAllowance_EntryDate;
        /// <summary>
        /// 申报人入职日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ProjectCarAllowance_EntryDate
        {
            get { return officeAutomation_Document_ProjectCarAllowance_EntryDate; }
            set { officeAutomation_Document_ProjectCarAllowance_EntryDate = value; }
        }

        private string officeAutomation_Document_ProjectCarAllowance_Department;
        /// <summary>
        /// 申报人现任职部门
        /// </summary>
        public string OfficeAutomation_Document_ProjectCarAllowance_Department
        {
            get { return officeAutomation_Document_ProjectCarAllowance_Department; }
            set { officeAutomation_Document_ProjectCarAllowance_Department = value; }
        }

        private string officeAutomation_Document_ProjectCarAllowance_Position;
        /// <summary>
        /// 申报人现职位
        /// </summary>
        public string OfficeAutomation_Document_ProjectCarAllowance_Position
        {
            get { return officeAutomation_Document_ProjectCarAllowance_Position; }
            set { officeAutomation_Document_ProjectCarAllowance_Position = value; }
        }

        private string officeAutomation_Document_ProjectCarAllowance_Grade;
        /// <summary>
        /// 申报人现职级
        /// </summary>
        public string OfficeAutomation_Document_ProjectCarAllowance_Grade
        {
            get { return officeAutomation_Document_ProjectCarAllowance_Grade; }
            set { officeAutomation_Document_ProjectCarAllowance_Grade = value; }
        }

        private bool officeAutomation_Document_ProjectCarAllowance_IsPositive;
        /// <summary>
        /// 是否通过试用期
        /// </summary>
        public bool OfficeAutomation_Document_ProjectCarAllowance_IsPositive
        {
            get { return officeAutomation_Document_ProjectCarAllowance_IsPositive; }
            set { officeAutomation_Document_ProjectCarAllowance_IsPositive = value; }
        }

        private int officeAutomation_Document_ProjectCarAllowance_MoneyGradeID;
        /// <summary>
        /// 申请金额档次主键
        /// </summary>
        public int OfficeAutomation_Document_ProjectCarAllowance_MoneyGradeID
        {
            get { return officeAutomation_Document_ProjectCarAllowance_MoneyGradeID; }
            set { officeAutomation_Document_ProjectCarAllowance_MoneyGradeID = value; }
        }

        private DateTime officeAutomation_Document_ProjectCarAllowance_EffectiveDate;
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ProjectCarAllowance_EffectiveDate
        {
            get { return officeAutomation_Document_ProjectCarAllowance_EffectiveDate; }
            set { officeAutomation_Document_ProjectCarAllowance_EffectiveDate = value; }
        }

        private int officeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID;
        /// <summary>
        /// 同意申请金额档次主键
        /// </summary>
        public int OfficeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID
        {
            get { return officeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID; }
            set { officeAutomation_Document_ProjectCarAllowance_AgreeMoneyGradeID = value; }
        }

        private string officeAutomation_Document_ProjectCarAllowance_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_ProjectCarAllowance_Remark
        {
            get { return officeAutomation_Document_ProjectCarAllowance_Remark; }
            set { officeAutomation_Document_ProjectCarAllowance_Remark = value; }
        }
        public bool OfficeAutomation_Document_ProjectCarAllowance_ApplyType { get; set; }
    }
}
