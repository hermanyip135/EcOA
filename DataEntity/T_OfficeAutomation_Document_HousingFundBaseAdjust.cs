using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
  public class T_OfficeAutomation_Document_HousingFundBaseAdjust
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_HousingFundBaseAdjust_ID { get; set; }

        /// <summary>
        /// 对应主表ID
        /// </summary>
        public Guid? OfficeAutomation_Document_HousingFundBaseAdjust_MainID { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Apply { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? OfficeAutomation_Document_HousingFundBaseAdjust_ApplyDate { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Department { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_ApplyID { get; set; }

    }
}
