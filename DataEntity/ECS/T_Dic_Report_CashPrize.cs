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
        /// ��ˮ��
        /// </summary>
        public string CashPrize_Num { get; set; }

        /// <summary>
        /// ECOA�����ֽ�ID
        /// </summary>
        public int CashPrize_HaveSingleReward { get; set; }

        /// <summary>
        /// ���ֽ𽱣�
        /// </summary>
        public decimal CashPrize_Money { get; set; }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        public DateTime CashPrize_DateBegin { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime CashPrize_DateEnd { get; set; }

        /// <summary>
        /// ����ǩ��״̬��δǩ����ͬ��1����ͬ��0���������2��
        /// </summary>
        public int CashPrize_AuditID { get; set; }
        #endregion
	}
}
