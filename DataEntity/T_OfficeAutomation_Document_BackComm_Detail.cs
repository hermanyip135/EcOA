using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 退佣申请相关情况表
    /// </summary>
    public class T_OfficeAutomation_Document_BackComm_Detail
    {
        private Guid officeAutomation_Document_BackComm_Detail_ID;
        /// <summary>
        ///主键
        /// </summary>
        public Guid OfficeAutomation_Document_BackComm_Detail_ID
        {
            get { return officeAutomation_Document_BackComm_Detail_ID; }
            set { officeAutomation_Document_BackComm_Detail_ID = value; }
        }

        private Guid officeAutomation_Document_BackComm_Detail_MainID;
        /// <summary>
        /// 退佣申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_BackComm_Detail_MainID
        {
            get { return officeAutomation_Document_BackComm_Detail_MainID; }
            set { officeAutomation_Document_BackComm_Detail_MainID = value; }
        }

        private string officeAutomation_Document_BackComm_Detail_Department;
        /// <summary>
        /// 分行/组别
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Detail_Department
        {
            get { return officeAutomation_Document_BackComm_Detail_Department; }
            set { officeAutomation_Document_BackComm_Detail_Department = value; }
        }

        private string officeAutomation_Document_BackComm_Detail_Sales;
        /// <summary>
        /// 营业人员
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Detail_Sales
        {
            get { return officeAutomation_Document_BackComm_Detail_Sales; }
            set { officeAutomation_Document_BackComm_Detail_Sales = value; }
        }

        private string officeAutomation_Document_BackComm_Detail_Team;
        /// <summary>
        /// 各级主管姓名
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Detail_Team
        {
            get { return officeAutomation_Document_BackComm_Detail_Team; }
            set { officeAutomation_Document_BackComm_Detail_Team = value; }
        }

        private decimal officeAutomation_Document_BackComm_Detail_BackMoney;
        /// <summary>
        /// 退佣金额
        /// </summary>
        public decimal OfficeAutomation_Document_BackComm_Detail_BackMoney
        {
            get { return officeAutomation_Document_BackComm_Detail_BackMoney; }
            set { officeAutomation_Document_BackComm_Detail_BackMoney = value; }
        }

        private bool officeAutomation_Document_BackComm_Detail_IsOnJob;
        /// <summary>
        /// 是否在职
        /// </summary>
        public bool OfficeAutomation_Document_BackComm_Detail_IsOnJob
        {
            get { return officeAutomation_Document_BackComm_Detail_IsOnJob; }
            set { officeAutomation_Document_BackComm_Detail_IsOnJob = value; }
        }

        private bool officeAutomation_Document_BackComm_Detail_IsPayComm;
        /// <summary>
        /// 是否已出佣
        /// </summary>
        public bool OfficeAutomation_Document_BackComm_Detail_IsPayComm
        {
            get { return officeAutomation_Document_BackComm_Detail_IsPayComm; }
            set { officeAutomation_Document_BackComm_Detail_IsPayComm = value; }
        }

        private string officeAutomation_Document_BackComm_Detail_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_BackComm_Detail_Remark
        {
            get { return officeAutomation_Document_BackComm_Detail_Remark; }
            set { officeAutomation_Document_BackComm_Detail_Remark = value; }
        }
    }
}
