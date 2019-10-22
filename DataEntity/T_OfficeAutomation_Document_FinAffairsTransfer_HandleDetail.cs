using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_FinAffairsTransfer_HandleDetail
    {
        /// <summary>
        /// 表ID
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_FinAffairsTransfer_HandleDetail_ID { get; set; }

        /// <summary>
        /// 申请表ID
        /// </summary>
        public Guid? OfficeAutomation_Document_FinAffairsTransfer_HandleDetail_MainID { get; set; }

        /// <summary>
        /// 收据或发票编号
        /// </summary>
        public string OfficeAutomation_Document_FinAffairsTransfer_HandleDetail_Number { get; set; }

        /// <summary>
        /// 欠缺内容事项
        /// </summary>
        public string OfficeAutomation_Document_FinAffairsTransfer_HandleDetail_Matter { get; set; }

        /// <summary>
        /// 无法处理的原因
        /// </summary>
        public string OfficeAutomation_Document_FinAffairsTransfer_HandleDetail_Reason { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? OfficeAutomation_Document_FinAffairsTransfer_HandleDetail_Sort { get; set; }

    }
}
