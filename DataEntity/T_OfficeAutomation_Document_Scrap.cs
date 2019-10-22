using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 报废申请表
    /// </summary>
    public class T_OfficeAutomation_Document_Scrap
    {
        private Guid officeAutomation_Document_Scrap_ID;
        /// <summary>
        ///报废申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_Scrap_ID
        {
            get { return officeAutomation_Document_Scrap_ID; }
            set { officeAutomation_Document_Scrap_ID = value; }
        }
        private Guid officeAutomation_Document_Scrap_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_Scrap_MainID
        {
            get { return officeAutomation_Document_Scrap_MainID; }
            set { officeAutomation_Document_Scrap_MainID = value; }
        }

        private string officeAutomation_Document_Scrap_Department;
        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_Scrap_Department
        {
            get { return officeAutomation_Document_Scrap_Department; }
            set { officeAutomation_Document_Scrap_Department = value; }
        }
        private string officeAutomation_Document_Scrap_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_Scrap_Apply
        {
            get { return officeAutomation_Document_Scrap_Apply; }
            set { officeAutomation_Document_Scrap_Apply = value; }
        }

        private DateTime officeAutomation_Document_Scrap_ApplyDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_Scrap_ApplyDate
        {
            get { return officeAutomation_Document_Scrap_ApplyDate; }
            set { officeAutomation_Document_Scrap_ApplyDate = value; }
        }

        private string officeAutomation_Document_Scrap_UserName;
        /// <summary>
        /// 使用人姓名
        /// </summary>
        public string OfficeAutomation_Document_Scrap_UserName
        {
            get { return officeAutomation_Document_Scrap_UserName; }
            set { officeAutomation_Document_Scrap_UserName = value; }
        }

        private string officeAutomation_Document_Scrap_UserTeam;
        /// <summary>
        /// 使用人职称及组别
        /// </summary>
        public string OfficeAutomation_Document_Scrap_UserTeam
        {
            get { return officeAutomation_Document_Scrap_UserTeam; }
            set { officeAutomation_Document_Scrap_UserTeam = value; }
        }

        private string officeAutomation_Document_Scrap_ReqReason;
        /// <summary>
        /// 申请报废原因
        /// </summary>
        public string OfficeAutomation_Document_Scrap_ReqReason
        {
            get { return officeAutomation_Document_Scrap_ReqReason; }
            set { officeAutomation_Document_Scrap_ReqReason = value; }
        }

        private string officeAutomation_Document_Scrap_SurplusValue;
        /// <summary>
        /// 折旧摊分总剩余费用
        /// </summary>
        public string OfficeAutomation_Document_Scrap_SurplusValue
        {
            get { return officeAutomation_Document_Scrap_SurplusValue; }
            set { officeAutomation_Document_Scrap_SurplusValue = value; }
        }

        private string officeAutomation_Document_Scrap_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_Scrap_Remark
        {
            get { return officeAutomation_Document_Scrap_Remark; }
            set { officeAutomation_Document_Scrap_Remark = value; }
        }

        private string officeAutomation_Document_Scrap_SurplusValueNotify;
        /// <summary>
        /// 净值知会函
        /// </summary>
        public string OfficeAutomation_Document_Scrap_SurplusValueNotify
        {
            get { return officeAutomation_Document_Scrap_SurplusValueNotify; }
            set { officeAutomation_Document_Scrap_SurplusValueNotify = value; }
        }

        private string _OfficeAutomation_Document_Scrap_Suc;

        public string OfficeAutomation_Document_Scrap_Suc
        {
            get { return _OfficeAutomation_Document_Scrap_Suc; }
            set { _OfficeAutomation_Document_Scrap_Suc = value; }
        }
        //申请人工号
        public string OfficeAutomation_Document_Scrap_ApplyID { get; set; }
    }
}
