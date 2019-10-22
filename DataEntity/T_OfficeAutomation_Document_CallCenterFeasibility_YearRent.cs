using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 新开分行年租金递增表
    /// </summary>
    public class T_OfficeAutomation_Document_CallCenterFeasibility_YearRent
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_CallCenterFeasibility_YearRent_ID { get; set; }

        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_CallCenterFeasibility_YearRent_MainID { get; set; }

        /// <summary>
        /// 年数
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_YearRent_YearNo
        { get; set; }

        /// <summary>
        /// 不含税租金
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_YearRent_NoTaxRent { get; set; }

        /// <summary>
        /// 含税租金
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_YearRent_HasTaxRent { get; set; }

        /// <summary>
        /// 税费
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_YearRent_RentCoast { get; set; }

        /// <summary>
        /// 递增率
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_YearRent_RateOfAdd { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_YearRent_RentOfAdd { get; set; }
    }
}
