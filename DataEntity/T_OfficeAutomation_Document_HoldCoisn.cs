using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
	public class T_OfficeAutomation_Document_HoldCoisn
	{
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_HoldCoisn_ID { get; set; }

        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_HoldCoisn_MainID { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Apply { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_HoldCoisn_ApplyDate { get; set; }

        /// <summary>
        /// 成交编号
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_ApplyID { get; set; }

        /// <summary>
        /// 分行（组别）
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Department { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Area { get; set; }

        /// <summary>
        /// 营业员
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Clerk { get; set; }

        /// <summary>
        /// 成交日期
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_DealDate { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Address { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Reason { get; set; }

        /// <summary>
        /// 完成网上转介审核时间
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_TurnDate { get; set; }

        /// <summary>
        /// 其他原因
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_OtherReason { get; set; }

        /// <summary>
        /// 原因类型,|分隔
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_ReasonType { get; set; }

        /// <summary>
        /// 解hold条件，0：不承办，1：承办
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Condition { get; set; }

	}
}