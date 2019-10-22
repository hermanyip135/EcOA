using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 小汽车津贴申请表
    /// </summary>
    public class T_OfficeAutomation_Document_CarAllowance
    {
        private Guid officeAutomation_Document_CarAllowance_ID;
        /// <summary>
        ///主键
        /// </summary>
        public Guid OfficeAutomation_Document_CarAllowance_ID
        {
            get { return officeAutomation_Document_CarAllowance_ID; }
            set { officeAutomation_Document_CarAllowance_ID = value; }
        }

        private Guid officeAutomation_Document_CarAllowance_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_CarAllowance_MainID
        {
            get { return officeAutomation_Document_CarAllowance_MainID; }
            set { officeAutomation_Document_CarAllowance_MainID = value; }
        }

        private string officeAutomation_Document_CarAllowance_Apply;
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_CarAllowance_Apply
        {
            get { return officeAutomation_Document_CarAllowance_Apply; }
            set { officeAutomation_Document_CarAllowance_Apply = value; }
        }

        private DateTime officeAutomation_Document_CarAllowance_ApplyDate;
        /// <summary>
        /// 填写日期
        /// </summary>
        public DateTime OfficeAutomation_Document_CarAllowance_ApplyDate
        {
            get { return officeAutomation_Document_CarAllowance_ApplyDate; }
            set { officeAutomation_Document_CarAllowance_ApplyDate = value; }
        }

        private string officeAutomation_Document_CarAllowance_ApplyForName;
        /// <summary>
        /// 申报人姓名
        /// </summary>
        public string OfficeAutomation_Document_CarAllowance_ApplyForName
        {
            get { return officeAutomation_Document_CarAllowance_ApplyForName; }
            set { officeAutomation_Document_CarAllowance_ApplyForName = value; }
        }

        private string officeAutomation_Document_CarAllowance_ApplyForCode;
        /// <summary>
        /// 申报人工号
        /// </summary>
        public string OfficeAutomation_Document_CarAllowance_ApplyForCode
        {
            get { return officeAutomation_Document_CarAllowance_ApplyForCode; }
            set { officeAutomation_Document_CarAllowance_ApplyForCode = value; }
        }

        private DateTime officeAutomation_Document_CarAllowance_EntryDate;
        /// <summary>
        /// 申报人入职日期
        /// </summary>
        public DateTime OfficeAutomation_Document_CarAllowance_EntryDate
        {
            get { return officeAutomation_Document_CarAllowance_EntryDate; }
            set { officeAutomation_Document_CarAllowance_EntryDate = value; }
        }

        private string officeAutomation_Document_CarAllowance_Department;
        /// <summary>
        /// 申报人现任职部门
        /// </summary>
        public string OfficeAutomation_Document_CarAllowance_Department
        {
            get { return officeAutomation_Document_CarAllowance_Department; }
            set { officeAutomation_Document_CarAllowance_Department = value; }
        }

        private string officeAutomation_Document_CarAllowance_Position;
        /// <summary>
        /// 申报人现职位
        /// </summary>
        public string OfficeAutomation_Document_CarAllowance_Position
        {
            get { return officeAutomation_Document_CarAllowance_Position; }
            set { officeAutomation_Document_CarAllowance_Position = value; }
        }
        
        private string officeAutomation_Document_CarAllowance_Grade;
        /// <summary>
        /// 申报人现职级
        /// </summary>
        public string OfficeAutomation_Document_CarAllowance_Grade
        {
            get { return officeAutomation_Document_CarAllowance_Grade; }
            set { officeAutomation_Document_CarAllowance_Grade = value; }
        }

        private bool officeAutomation_Document_CarAllowance_IsPositive;
        /// <summary>
        /// 是否通过试用期
        /// </summary>
        public bool OfficeAutomation_Document_CarAllowance_IsPositive
        {
            get { return officeAutomation_Document_CarAllowance_IsPositive; }
            set { officeAutomation_Document_CarAllowance_IsPositive = value; }
        }

        private int officeAutomation_Document_CarAllowance_MoneyGradeID;
        /// <summary>
        /// 申请金额档次主键
        /// </summary>
        public int OfficeAutomation_Document_CarAllowance_MoneyGradeID
        {
            get { return officeAutomation_Document_CarAllowance_MoneyGradeID; }
            set { officeAutomation_Document_CarAllowance_MoneyGradeID = value; }
        }

        private DateTime officeAutomation_Document_CarAllowance_EffectiveDate;
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime OfficeAutomation_Document_CarAllowance_EffectiveDate
        {
            get { return officeAutomation_Document_CarAllowance_EffectiveDate; }
            set { officeAutomation_Document_CarAllowance_EffectiveDate = value; }
        }

        private int officeAutomation_Document_CarAllowance_AgreeMoneyGradeID;
        /// <summary>
        /// 同意申请金额档次主键
        /// </summary>
        public int OfficeAutomation_Document_CarAllowance_AgreeMoneyGradeID
        {
            get { return officeAutomation_Document_CarAllowance_AgreeMoneyGradeID; }
            set { officeAutomation_Document_CarAllowance_AgreeMoneyGradeID = value; }
        }

        private string officeAutomation_Document_CarAllowance_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_CarAllowance_Remark
        {
            get { return officeAutomation_Document_CarAllowance_Remark; }
            set { officeAutomation_Document_CarAllowance_Remark = value; }
        }
    }
}
