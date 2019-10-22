using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_ExemptionBadDebt_Detail
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_ExemptionBadDebt_Detail_ID { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        public Guid OfficeAutomation_Document_ExemptionBadDebt_Detail_MainID { get; set; }

        /// <summary>
        /// 统筹区域
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Detail_a { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Detail_b { get; set; }

        /// <summary>
        /// 项目所在地
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Detail_c { get; set; }

        /// <summary>
        /// 成交宗数
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_Detail_d { get; set; }

        /// <summary>
        /// 成交总佣
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_Detail_e { get; set; }

        /// <summary>
        /// 申请宗数
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_Detail_f { get; set; }

        /// <summary>
        /// 申请总额
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_Detail_g { get; set; }

        /// <summary>
        /// 未签约原因
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Detail_h { get; set; }

        /// <summary>
        /// 应收款管理组网络核查结果
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Detail_i { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? OfficeAutomation_Document_ExemptionBadDebt_Detail_Sort { get; set; }
        /// <summary>
        /// 项目统筹人
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Detail_j { get; set; }
    }

}
