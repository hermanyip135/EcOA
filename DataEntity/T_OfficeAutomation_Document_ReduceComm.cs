using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 减佣让佣申请表
    /// </summary>
    [Serializable]
    public partial class T_OfficeAutomation_Document_ReduceComm
    {
        public T_OfficeAutomation_Document_ReduceComm()
        { }
        #region Model
        private Guid _officeautomation_document_reducecomm_id;
        private Guid _officeautomation_document_reducecomm_mainid;
        private string _officeautomation_document_reducecomm_apply;
        private string _officeautomation_document_reducecomm_applyforname;
        private string _officeautomation_document_reducecomm_applyforcode;
        private DateTime _officeautomation_document_reducecomm_applydate;
        private int _officeautomation_document_reducecomm_departmenttypeid;
        private string _officeautomation_document_reducecomm_subject;
        private string _officeautomation_document_reducecomm_department;
        private Guid _officeautomation_document_reducecomm_departmentid;
        private string _officeautomation_document_reducecomm_replyphone;
        private string _officeautomation_document_reducecomm_reason;
        private string _officeautomation_document_reducecomm_remark;
        private string _officeautomation_document_reducecomm_dealdepartment;
        private string _officeautomation_document_reducecomm_originaldealprice;
        private string _officeautomation_document_reducecomm_finaldealprice;
        private string _officeautomation_document_reducecomm_commpoint;
        private string _officeautomation_document_reducecomm_originalcomm;
        private string _officeautomation_document_reducecomm_reducecashbonus;
        private string _officeautomation_document_reducecomm_reducecomm;
        private string _officeautomation_document_reducecomm_totalreduce;
        private string _officeautomation_document_reducecomm_actualreportmoney;
       
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_ReduceComm_ID
        {
            set { _officeautomation_document_reducecomm_id = value; }
            get { return _officeautomation_document_reducecomm_id; }
        }
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ReduceComm_MainID
        {
            set { _officeautomation_document_reducecomm_mainid = value; }
            get { return _officeautomation_document_reducecomm_mainid; }
        }
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Apply
        {
            set { _officeautomation_document_reducecomm_apply = value; }
            get { return _officeautomation_document_reducecomm_apply; }
        }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_ApplyForName
        {
            set { _officeautomation_document_reducecomm_applyforname = value; }
            get { return _officeautomation_document_reducecomm_applyforname; }
        }
        /// <summary>
        /// 申请人工号
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_ApplyForCode
        {
            set { _officeautomation_document_reducecomm_applyforcode = value; }
            get { return _officeautomation_document_reducecomm_applyforcode; }
        }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ReduceComm_ApplyDate
        {
            set { _officeautomation_document_reducecomm_applydate = value; }
            get { return _officeautomation_document_reducecomm_applydate; }
        }
        /// <summary>
        /// 区域类别ID
        /// </summary>
        public int OfficeAutomation_Document_ReduceComm_DepartmentTypeID
        {
            set { _officeautomation_document_reducecomm_departmenttypeid = value; }
            get { return _officeautomation_document_reducecomm_departmenttypeid; }
        }
        /// <summary>
        /// 主题
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Subject
        {
            set { _officeautomation_document_reducecomm_subject = value; }
            get { return _officeautomation_document_reducecomm_subject; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Department
        {
            set { _officeautomation_document_reducecomm_department = value; }
            get { return _officeautomation_document_reducecomm_department; }
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_ReduceComm_DepartmentID
        {
            set { _officeautomation_document_reducecomm_departmentid = value; }
            get { return _officeautomation_document_reducecomm_departmentid; }
        }
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_ReplyPhone
        {
            set { _officeautomation_document_reducecomm_replyphone = value; }
            get { return _officeautomation_document_reducecomm_replyphone; }
        }
        /// <summary>
        /// 原因
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Reason
        {
            set { _officeautomation_document_reducecomm_reason = value; }
            get { return _officeautomation_document_reducecomm_reason; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_Remark
        {
            set { _officeautomation_document_reducecomm_remark = value; }
            get { return _officeautomation_document_reducecomm_remark; }
        }
        
        /// <summary>
        /// 成交套数
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_DealDepartment
        {
            set { _officeautomation_document_reducecomm_dealdepartment = value; }
            get { return _officeautomation_document_reducecomm_dealdepartment; }
        }
        /// <summary>
        /// 原成交价
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_OriginalDealPrice
        {
            set { _officeautomation_document_reducecomm_originaldealprice = value; }
            get { return _officeautomation_document_reducecomm_originaldealprice; }
        }
        /// <summary>
        /// 客户最终成交价
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_FinalDealPrice
        {
            set { _officeautomation_document_reducecomm_finaldealprice = value; }
            get { return _officeautomation_document_reducecomm_finaldealprice; }
        }
        /// <summary>
        /// 代理费点数
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_CommPoint
        {
            set { _officeautomation_document_reducecomm_commpoint = value; }
            get { return _officeautomation_document_reducecomm_commpoint; }
        }
        /// <summary>
        /// 原佣金
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_OriginalComm
        {
            set { _officeautomation_document_reducecomm_originalcomm = value; }
            get { return _officeautomation_document_reducecomm_originalcomm; }
        }
        /// <summary>
        /// 让现金奖金额
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_ReduceCashBonus
        {
            set { _officeautomation_document_reducecomm_reducecashbonus = value; }
            get { return _officeautomation_document_reducecomm_reducecashbonus; }
        }
        /// <summary>
        /// 让佣金额
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_ReduceComm
        {
            set { _officeautomation_document_reducecomm_reducecomm = value; }
            get { return _officeautomation_document_reducecomm_reducecomm; }
        }
        /// <summary>
        /// 总让佣金额
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_TotalReduce
        {
            set { _officeautomation_document_reducecomm_totalreduce = value; }
            get { return _officeautomation_document_reducecomm_totalreduce; }
        }
        /// <summary>
        /// 实际上数金额
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_ActualReportMoney
        {
            set { _officeautomation_document_reducecomm_actualreportmoney = value; }
            get { return _officeautomation_document_reducecomm_actualreportmoney; }
        }

        private string _OfficeAutomation_Document_ReduceComm_ReduceWay;
        /// <summary>
        /// 减佣/让佣方式
        /// </summary>
        public string OfficeAutomation_Document_ReduceComm_ReduceWay
        {
            get { return _OfficeAutomation_Document_ReduceComm_ReduceWay; }
            set { _OfficeAutomation_Document_ReduceComm_ReduceWay = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_EBCommPoint;

        public string OfficeAutomation_Document_ReduceComm_EBCommPoint
        {
            get { return _OfficeAutomation_Document_ReduceComm_EBCommPoint; }
            set { _OfficeAutomation_Document_ReduceComm_EBCommPoint = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_CaCommPoint;

        public string OfficeAutomation_Document_ReduceComm_CaCommPoint
        {
            get { return _OfficeAutomation_Document_ReduceComm_CaCommPoint; }
            set { _OfficeAutomation_Document_ReduceComm_CaCommPoint = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_EBOriginalComm;

        public string OfficeAutomation_Document_ReduceComm_EBOriginalComm
        {
            get { return _OfficeAutomation_Document_ReduceComm_EBOriginalComm; }
            set { _OfficeAutomation_Document_ReduceComm_EBOriginalComm = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_CaOriginalComm;

        public string OfficeAutomation_Document_ReduceComm_CaOriginalComm
        {
            get { return _OfficeAutomation_Document_ReduceComm_CaOriginalComm; }
            set { _OfficeAutomation_Document_ReduceComm_CaOriginalComm = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_EBReduceCashBonus;

        public string OfficeAutomation_Document_ReduceComm_EBReduceCashBonus
        {
            get { return _OfficeAutomation_Document_ReduceComm_EBReduceCashBonus; }
            set { _OfficeAutomation_Document_ReduceComm_EBReduceCashBonus = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_CaReduceCashBonus;

        public string OfficeAutomation_Document_ReduceComm_CaReduceCashBonus
        {
            get { return _OfficeAutomation_Document_ReduceComm_CaReduceCashBonus; }
            set { _OfficeAutomation_Document_ReduceComm_CaReduceCashBonus = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_EBReduceComm;

        public string OfficeAutomation_Document_ReduceComm_EBReduceComm
        {
            get { return _OfficeAutomation_Document_ReduceComm_EBReduceComm; }
            set { _OfficeAutomation_Document_ReduceComm_EBReduceComm = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_CaReduceComm;

        public string OfficeAutomation_Document_ReduceComm_CaReduceComm
        {
            get { return _OfficeAutomation_Document_ReduceComm_CaReduceComm; }
            set { _OfficeAutomation_Document_ReduceComm_CaReduceComm = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_KSa;

        public string OfficeAutomation_Document_ReduceComm_KSa
        {
            get { return _OfficeAutomation_Document_ReduceComm_KSa; }
            set { _OfficeAutomation_Document_ReduceComm_KSa = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_KSb;

        public string OfficeAutomation_Document_ReduceComm_KSb
        {
            get { return _OfficeAutomation_Document_ReduceComm_KSb; }
            set { _OfficeAutomation_Document_ReduceComm_KSb = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_KSc;

        public string OfficeAutomation_Document_ReduceComm_KSc
        {
            get { return _OfficeAutomation_Document_ReduceComm_KSc; }
            set { _OfficeAutomation_Document_ReduceComm_KSc = value; }
        }

        private string _OfficeAutomation_Document_ReduceComm_KSd;

        public string OfficeAutomation_Document_ReduceComm_KSd
        {
            get { return _OfficeAutomation_Document_ReduceComm_KSd; }
            set { _OfficeAutomation_Document_ReduceComm_KSd = value; }
        }
        public string OfficeAutomation_Document_ReduceComm_Type { get; set; }
        #endregion Model

    }
}
