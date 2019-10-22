using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 公章使用申请表
    /// </summary>
    public class T_OfficeAutomation_Document_OfficialSeal
    {
        private Guid _OfficeAutomation_Document_OfficialSeal_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_OfficialSeal_ID
        {
            get { return _OfficeAutomation_Document_OfficialSeal_ID; }
            set { _OfficeAutomation_Document_OfficialSeal_ID = value; }
        }

        private Guid _OfficeAutomation_Document_OfficialSeal_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_OfficialSeal_MainID
        {
            get { return _OfficeAutomation_Document_OfficialSeal_MainID; }
            set { _OfficeAutomation_Document_OfficialSeal_MainID = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_Apply;
        /// <summary>
        /// 发文人员
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_Apply
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Apply; }
            set { _OfficeAutomation_Document_OfficialSeal_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_OfficialSeal_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_OfficialSeal_ApplyDate
        {
            get { return _OfficeAutomation_Document_OfficialSeal_ApplyDate; }
            set { _OfficeAutomation_Document_OfficialSeal_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_ApplyID;
        /// <summary>
        /// 编号
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_ApplyID
        {
            get { return _OfficeAutomation_Document_OfficialSeal_ApplyID; }
            set { _OfficeAutomation_Document_OfficialSeal_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_Department
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Department; }
            set { _OfficeAutomation_Document_OfficialSeal_Department = value; }
        }

        private bool _OfficeAutomation_Document_OfficialSeal_Species;
        /// <summary>
        /// 申请盖章的种类
        /// </summary>
        public bool OfficeAutomation_Document_OfficialSeal_Species
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Species; }
            set { _OfficeAutomation_Document_OfficialSeal_Species = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_AnotherSeal;
        /// <summary>
        /// 其它印章
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_AnotherSeal
        {
            get { return _OfficeAutomation_Document_OfficialSeal_AnotherSeal; }
            set { _OfficeAutomation_Document_OfficialSeal_AnotherSeal = value; }
        }

        private int _OfficeAutomation_Document_OfficialSeal_FileSpecies;
        /// <summary>
        /// 申请盖章文件的种类
        /// </summary>
        public int OfficeAutomation_Document_OfficialSeal_FileSpecies
        {
            get { return _OfficeAutomation_Document_OfficialSeal_FileSpecies; }
            set { _OfficeAutomation_Document_OfficialSeal_FileSpecies = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_AnotherFile;
        /// <summary>
        /// 对佣（请款）金额
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_AnotherFile
        {
            get { return _OfficeAutomation_Document_OfficialSeal_AnotherFile; }
            set { _OfficeAutomation_Document_OfficialSeal_AnotherFile = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_FileCount;
        /// <summary>
        /// 申请盖章文件的份数
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_FileCount
        {
            get { return _OfficeAutomation_Document_OfficialSeal_FileCount; }
            set { _OfficeAutomation_Document_OfficialSeal_FileCount = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_RecyclingData;
        /// <summary>
        /// 预计回收日期
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_RecyclingData
        {
            get { return _OfficeAutomation_Document_OfficialSeal_RecyclingData; }
            set { _OfficeAutomation_Document_OfficialSeal_RecyclingData = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_SureDepartment;
        /// <summary>
        /// 确认盖章部门
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_SureDepartment
        {
            get { return _OfficeAutomation_Document_OfficialSeal_SureDepartment; }
            set { _OfficeAutomation_Document_OfficialSeal_SureDepartment = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_SureMenber;
        /// <summary>
        /// 确认盖章人员
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_SureMenber
        {
            get { return _OfficeAutomation_Document_OfficialSeal_SureMenber; }
            set { _OfficeAutomation_Document_OfficialSeal_SureMenber = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_SureData;
        /// <summary>
        /// 确认盖章日期
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_SureData
        {
            get { return _OfficeAutomation_Document_OfficialSeal_SureData; }
            set { _OfficeAutomation_Document_OfficialSeal_SureData = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_BranchPhone;
        /// <summary>
        /// 分行电话
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_BranchPhone
        {
            get { return _OfficeAutomation_Document_OfficialSeal_BranchPhone; }
            set { _OfficeAutomation_Document_OfficialSeal_BranchPhone = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_SurePhone;
        /// <summary>
        /// 确认人电话
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_SurePhone
        {
            get { return _OfficeAutomation_Document_OfficialSeal_SurePhone; }
            set { _OfficeAutomation_Document_OfficialSeal_SurePhone = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_SureCommissioner;
        /// <summary>
        /// 盖章专责人员
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_SureCommissioner
        {
            get { return _OfficeAutomation_Document_OfficialSeal_SureCommissioner; }
            set { _OfficeAutomation_Document_OfficialSeal_SureCommissioner = value; }
        }
    }
}
