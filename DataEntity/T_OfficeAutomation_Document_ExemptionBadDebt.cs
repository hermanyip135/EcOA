using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_ExemptionBadDebt
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_ExemptionBadDebt_ID { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        public Guid? OfficeAutomation_Document_ExemptionBadDebt_MainID { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Apply { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_ExemptionBadDebt_ApplyDate { get; set; }

        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_ApplyID { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Department { get; set; }

        /// <summary>
        /// 成交宗数年
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_1Y { get; set; }

        /// <summary>
        /// 成交宗数月
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_1M { get; set; }

        /// <summary>
        /// 成交总佣年
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_2Y { get; set; }

        /// <summary>
        /// 成交总佣月
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_2M { get; set; }

        /// <summary>
        /// 成交宗数合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_UnitSum { get; set; }

        /// <summary>
        /// 成交总佣合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_CommSum { get; set; }

        /// <summary>
        /// 申请总额合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_ApplyTotalSum { get; set; }

        /// <summary>
        /// 海珠合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_HZTotalSum { get; set; }

        /// <summary>
        /// 天河合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_THTotalSum { get; set; }

        /// <summary>
        /// 白云合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_BYTotalSum { get; set; }

        /// <summary>
        /// 越秀合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_YXTotalSum { get; set; }

        /// <summary>
        /// 花都合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_HDTotalSum { get; set; }

        /// <summary>
        /// 番禺合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_PYTotalSum { get; set; }

        /// <summary>
        /// 工商一部合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_GS1TotalSum { get; set; }

        /// <summary>
        /// 工商二部合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_GS2TotalSum { get; set; }

       

        /// <summary>
        /// 芳村南海合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_FCTotalSum { get; set; }

        /// <summary>
        /// 补充内容
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Content { get; set; }

        /// <summary>
        /// 番禺二部合计
        /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_PY2TotalSum { get; set; }

       /// <summary>
       /// 申请宗数合计
       /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_ApplyUnitSum { get; set; }
       /// <summary>
        /// 申请总额合计
       /// </summary>
        public decimal? OfficeAutomation_Document_ExemptionBadDebt_ApplyCommSum { get; set; }
        /// <summary>
        /// 豁免期限
        /// </summary>
        public string OfficeAutomation_Document_ExemptionBadDebt_Term { get; set; }
        /// <summary>
        /// 网络核查日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_ExemptionBadDebt_HopeDate { get; set; }
    }
}
