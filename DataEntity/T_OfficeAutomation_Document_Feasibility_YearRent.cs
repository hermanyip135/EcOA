using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 新开分行年租金递增表
    /// </summary>
    public class T_OfficeAutomation_Document_Feasibility_YearRent
    {
        private Guid _OfficeAutomation_Document_Feasibility_YearRent_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_Feasibility_YearRent_ID
        {
            get { return _OfficeAutomation_Document_Feasibility_YearRent_ID; }
            set { _OfficeAutomation_Document_Feasibility_YearRent_ID = value; }
        }

        private Guid _OfficeAutomation_Document_Feasibility_YearRent_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_Feasibility_YearRent_MainID
        {
            get { return _OfficeAutomation_Document_Feasibility_YearRent_MainID; }
            set { _OfficeAutomation_Document_Feasibility_YearRent_MainID = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_YearRent_YearNo;
        /// <summary>
        /// 年数
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_YearRent_YearNo
        {
            get { return _OfficeAutomation_Document_Feasibility_YearRent_YearNo; }
            set { _OfficeAutomation_Document_Feasibility_YearRent_YearNo = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_YearRent_NoTaxRent;
        /// <summary>
        /// 不含税租金
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_YearRent_NoTaxRent
        {
            get { return _OfficeAutomation_Document_Feasibility_YearRent_NoTaxRent; }
            set { _OfficeAutomation_Document_Feasibility_YearRent_NoTaxRent = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_YearRent_HasTaxRent;
        /// <summary>
        /// 含税租金
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_YearRent_HasTaxRent
        {
            get { return _OfficeAutomation_Document_Feasibility_YearRent_HasTaxRent; }
            set { _OfficeAutomation_Document_Feasibility_YearRent_HasTaxRent = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_YearRent_RentCoast;
        /// <summary>
        /// 税费
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_YearRent_RentCoast
        {
            get { return _OfficeAutomation_Document_Feasibility_YearRent_RentCoast; }
            set { _OfficeAutomation_Document_Feasibility_YearRent_RentCoast = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_YearRent_RateOfAdd;
        /// <summary>
        /// 递增率
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_YearRent_RateOfAdd
        {
            get { return _OfficeAutomation_Document_Feasibility_YearRent_RateOfAdd; }
            set { _OfficeAutomation_Document_Feasibility_YearRent_RateOfAdd = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_YearRent_RentOfAdd;
        /// <summary>
        /// 税率
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_YearRent_RentOfAdd
        {
            get { return _OfficeAutomation_Document_Feasibility_YearRent_RentOfAdd; }
            set { _OfficeAutomation_Document_Feasibility_YearRent_RentOfAdd = value; }
        }
    }
}
