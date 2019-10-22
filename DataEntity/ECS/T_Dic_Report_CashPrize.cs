using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace DataEntity
{
	public class T_Dic_Report_CashPrize : DBInteractionBase
	{
        #region Class Property Declarations
        public Guid CashPrize_ID { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string CashPrize_Num { get; set; }

        /// <summary>
        /// ECOA单套现金奖ID
        /// </summary>
        public int CashPrize_HaveSingleReward { get; set; }

        /// <summary>
        /// 金额（现金奖）
        /// </summary>
        public decimal CashPrize_Money { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime CashPrize_DateBegin { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime CashPrize_DateEnd { get; set; }

        /// <summary>
        /// 黄生签批状态（未签批，同意1，不同意0，其他意见2）
        /// </summary>
        public int CashPrize_AuditID { get; set; }
        #endregion
	}
}
