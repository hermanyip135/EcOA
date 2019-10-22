using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 减佣让佣申请表明细
    /// </summary>
    [Serializable]
    public partial class T_OfficeAutomation_Document_ReduceComm_Detail
    {
        public T_OfficeAutomation_Document_ReduceComm_Detail()
        { }
        #region Model
        private Guid _officeautomation_document_reducecomm_detail_id;
        private Guid _officeautomation_document_reducecomm_detail_mainid;
        private DateTime _officeautomation_document_reducecomm_detail_dealdate;
        private string _officeautomation_document_reducecomm_detail_dealdepartment;
        private string _officeautomation_document_reducecomm_detail_originaldealprice;
        private string _officeautomation_document_reducecomm_detail_finaldealprice;
        private string _officeautomation_document_reducecomm_detail_commpoint;
        private string _officeautomation_document_reducecomm_detail_originalcomm;
        private string _officeautomation_document_reducecomm_detail_reducecashbonus;
        private string _officeautomation_document_reducecomm_detail_reducecomm;
        private string _officeautomation_document_reducecomm_detail_totalreduce;
        private string _officeautomation_document_reducecomm_detail_actualreportmoney;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_ReduceComm_Detail_ID
        {
            set { _officeautomation_document_reducecomm_detail_id = value; }
            get { return _officeautomation_document_reducecomm_detail_id; }
        }
        /// <summary>
        /// 申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ReduceComm_Detail_MainID
        {
            set { _officeautomation_document_reducecomm_detail_mainid = value; }
            get { return _officeautomation_document_reducecomm_detail_mainid; }
        }
        /// <summary>
        /// 成交日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ReduceComm_Detail_DealDate
        {
            set { _officeautomation_document_reducecomm_detail_dealdate = value; }
            get { return _officeautomation_document_reducecomm_detail_dealdate; }
        }
        /// <summary>
        /// 成交单位
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Detail_DealDepartment
        {
            set { _officeautomation_document_reducecomm_detail_dealdepartment = value; }
            get { return _officeautomation_document_reducecomm_detail_dealdepartment; }
        }
        /// <summary>
        /// 原成交价
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Detail_OriginalDealPrice
        {
            set { _officeautomation_document_reducecomm_detail_originaldealprice = value; }
            get { return _officeautomation_document_reducecomm_detail_originaldealprice; }
        }
        /// <summary>
        /// 客户最终成交价
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Detail_FinalDealPrice
        {
            set { _officeautomation_document_reducecomm_detail_finaldealprice = value; }
            get { return _officeautomation_document_reducecomm_detail_finaldealprice; }
        }
        /// <summary>
        /// 代理费点数
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Detail_CommPoint
        {
            set { _officeautomation_document_reducecomm_detail_commpoint = value; }
            get { return _officeautomation_document_reducecomm_detail_commpoint; }
        }
        /// <summary>
        /// 原佣金
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Detail_OriginalComm
        {
            set { _officeautomation_document_reducecomm_detail_originalcomm = value; }
            get { return _officeautomation_document_reducecomm_detail_originalcomm; }
        }
        /// <summary>
        /// 让现金奖金额
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Detail_ReduceCashBonus
        {
            set { _officeautomation_document_reducecomm_detail_reducecashbonus = value; }
            get { return _officeautomation_document_reducecomm_detail_reducecashbonus; }
        }
        /// <summary>
        /// 让佣金额
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Detail_ReduceComm
        {
            set { _officeautomation_document_reducecomm_detail_reducecomm = value; }
            get { return _officeautomation_document_reducecomm_detail_reducecomm; }
        }
        /// <summary>
        /// 总让佣金额
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Detail_TotalReduce
        {
            set { _officeautomation_document_reducecomm_detail_totalreduce = value; }
            get { return _officeautomation_document_reducecomm_detail_totalreduce; }
        }
        /// <summary>
        /// 实际上数金额
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Detail_ActualReportMoney
        {
            set { _officeautomation_document_reducecomm_detail_actualreportmoney = value; }
            get { return _officeautomation_document_reducecomm_detail_actualreportmoney; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint;

        public string OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_EBCommPoint = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint;

        public string OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_CaCommPoint = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm;

        public string OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_EBOriginalComm = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm;

        public string OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_CaOriginalComm = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus;

        public string OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_EBReduceCashBonus = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus;

        public string OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_CaReduceCashBonus = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm;

        public string OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_EBReduceComm = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm;

        public string OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_CaReduceComm = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_KSa;

        public string OfficeAutomation_Document_ReduceComm_Detail_KSa
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_KSa; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_KSa = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_KSb;

        public string OfficeAutomation_Document_ReduceComm_Detail_KSb
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_KSb; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_KSb = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_KSc;

        public string OfficeAutomation_Document_ReduceComm_Detail_KSc
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_KSc; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_KSc = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_KSd;

        public string OfficeAutomation_Document_ReduceComm_Detail_KSd
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_KSd; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_KSd = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_Detail_BudingName;

        public string OfficeAutomation_Document_ReduceComm_Detail_BudingName
        {
            get { return _OfficeAutomation_Document_ReduceComm_Detail_BudingName; }
            set { _OfficeAutomation_Document_ReduceComm_Detail_BudingName = value; }
        }

        #endregion Model

    }
}
