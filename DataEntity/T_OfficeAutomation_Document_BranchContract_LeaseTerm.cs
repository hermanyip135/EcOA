using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 分行续约租赁期及租金详情表
    /// </summary>
    public class T_OfficeAutomation_Document_BranchContract_LeaseTerm
    {
        private Guid _OfficeAutomation_Document_BranchContract_LeaseTerm_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_BranchContract_LeaseTerm_ID
        {
            get { return _OfficeAutomation_Document_BranchContract_LeaseTerm_ID; }
            set { _OfficeAutomation_Document_BranchContract_LeaseTerm_ID = value; }
        }

        private Guid _OfficeAutomation_Document_BranchContract_LeaseTerm_MainID;
        /// <summary>
        /// 申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_BranchContract_LeaseTerm_MainID
        {
            get { return _OfficeAutomation_Document_BranchContract_LeaseTerm_MainID; }
            set { _OfficeAutomation_Document_BranchContract_LeaseTerm_MainID = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_LeaseTerm_BeginData;
        /// <summary>
        /// 租期起租日
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LeaseTerm_BeginData
        {
            get { return _OfficeAutomation_Document_BranchContract_LeaseTerm_BeginData; }
            set { _OfficeAutomation_Document_BranchContract_LeaseTerm_BeginData = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_LeaseTerm_EndData;
        /// <summary>
        /// 租期截止日
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LeaseTerm_EndData
        {
            get { return _OfficeAutomation_Document_BranchContract_LeaseTerm_EndData; }
            set { _OfficeAutomation_Document_BranchContract_LeaseTerm_EndData = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_LeaseTerm_TaxRent;
        /// <summary>
        /// 不含税租金
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LeaseTerm_TaxRent
        {
            get { return _OfficeAutomation_Document_BranchContract_LeaseTerm_TaxRent; }
            set { _OfficeAutomation_Document_BranchContract_LeaseTerm_TaxRent = value; }
        }

        private string _OfficeAutomation_Document_BranchContract_LeaseTerm_Rent;
        /// <summary>
        /// 含税租金
        /// </summary>
        public string OfficeAutomation_Document_BranchContract_LeaseTerm_Rent
        {
            get { return _OfficeAutomation_Document_BranchContract_LeaseTerm_Rent; }
            set { _OfficeAutomation_Document_BranchContract_LeaseTerm_Rent = value; }
        }
    }
}
