using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 应收佣金调整报告坏帐明细表
    /// </summary>
    public class T_OfficeAutomation_Document_CommissionAdjust_Detail
    {
        private Guid _OfficeAutomation_Document_CommissionAdjust_Detail_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_CommissionAdjust_Detail_ID
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_ID; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_ID = value; }
        }

        private Guid _OfficeAutomation_Document_CommissionAdjust_Detail_MainID;
        /// <summary>
        /// 申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_CommissionAdjust_Detail_MainID
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_MainID; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_MainID = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_Property;
        /// <summary>
        /// 物业
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_Property
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_Property; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_Property = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_Controler;
        /// <summary>
        /// 经办人
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_Controler
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_Controler; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_Controler = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID;
        /// <summary>
        /// 物业成交编号
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate;
        /// <summary>
        /// 物业成交日期
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal;
        /// <summary>
        /// 原成交价
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal;
        /// <summary>
        /// 现成交价
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal;
        /// <summary>
        /// 成交价调整
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm;
        /// <summary>
        /// 应收佣金
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm;
        /// <summary>
        /// 实收佣金
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm;
        /// <summary>
        /// 调整佣金
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm = value; }
        }

        private int _OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason;
        /// <summary>
        /// 是否特殊调整
        /// </summary>
        public int OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_Cname;

        public string OfficeAutomation_Document_CommissionAdjust_Detail_Cname
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_Cname; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_Cname = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_Commitment;
        /// <summary>
        /// 客户联系电话
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_Commitment
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_Commitment; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_Commitment = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_Reason;
        /// <summary>
        /// 坏帐原因
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_Reason
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_Reason; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_Reason = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_pNo;
        /// <summary>
        /// 序号
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_pNo
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_pNo; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_pNo = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_DealType;
        /// <summary>
        /// 成交类型
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_DealType
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_DealType; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_DealType = value; }
        }

        private string _OfficeAutomation_Document_CommissionAdjust_Detail_ChangeType;
        /// <summary>
        /// 坏帐原因
        /// </summary>
        public string OfficeAutomation_Document_CommissionAdjust_Detail_ChangeType
        {
            get { return _OfficeAutomation_Document_CommissionAdjust_Detail_ChangeType; }
            set { _OfficeAutomation_Document_CommissionAdjust_Detail_ChangeType = value; }
        }
        
    }
}
