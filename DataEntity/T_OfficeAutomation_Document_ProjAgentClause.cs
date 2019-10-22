/*
* T_OfficeAutomation_Document_ProjAgentClause.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_ProjAgentClause
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/15 11:43:19    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 项目销售代理合同条款申请表
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_ProjAgentClause
	{
		public T_OfficeAutomation_Document_ProjAgentClause()
		{}
		#region Model
		private Guid _officeautomation_document_projagentclause_id;
		private Guid _officeautomation_document_projagentclause_mainid;
		private string _officeautomation_document_projagentclause_department;
		private DateTime _officeautomation_document_projagentclause_applydate;
		private string _officeautomation_document_projagentclause_apply;
		private string _officeautomation_document_projagentclause_replyphone;
		private string _officeautomation_document_projagentclause_applyid;
		private string _officeautomation_document_projagentclause_projname;
		private string _officeautomation_document_projagentclause_developername;
		private string _officeautomation_document_projagentclause_projaddress;
        private string _officeautomation_document_projagentclause_agentstart;
        private string _officeautomation_document_projagentclause_agentend;
        private string _officeautomation_document_projagentclause_saledate;
		private string _officeautomation_document_projagentclause_dealofficetypeids;
		private string _officeautomation_document_projagentclause_dealofficeother;
		private string _officeautomation_document_projagentclause_goodsquantity;
		private string _officeautomation_document_projagentclause_goodsvalue;
		private string _officeautomation_document_projagentclause_precomm;
		private int _officeautomation_document_projagentclause_agentmodel;
		private string _officeautomation_document_projagentclause_commpoint;
		private int _officeautomation_document_projagentclause_contracttype;
		private string _officeautomation_document_projagentclause_contracttypeother;
		private string _officeautomation_document_projagentclause_remark;
        //private string _officeautomation_document_projagentclause_performanceprofitinfo;
        //private string _officeautomation_document_projagentclause_sumperformance;
        //private string _officeautomation_document_projagentclause_sumprofit;
		private string _officeautomation_document_projagentclause_clausesettlecomm;
		private string _officeautomation_document_projagentclause_clausefine;
		private string _officeautomation_document_projagentclause_clausearealimit;
		private string _officeautomation_document_projagentclause_clauseperforcheck;
		private string _officeautomation_document_projagentclause_clausehonest;
		private string _officeautomation_document_projagentclause_clauseother;
		private string _officeautomation_document_projagentclause_sign;

        private bool _OfficeAutomation_Document_ProjAgentClause_PorjectExam;


		/// <summary>
		/// 主键
		/// </summary>
        [CProperty("Key")]
		public Guid OfficeAutomation_Document_ProjAgentClause_ID
		{
			set{ _officeautomation_document_projagentclause_id=value;}
			get{return _officeautomation_document_projagentclause_id;}
		}
		/// <summary>
		/// 公文流转主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_ProjAgentClause_MainID
		{
			set{ _officeautomation_document_projagentclause_mainid=value;}
			get{return _officeautomation_document_projagentclause_mainid;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_Department
		{
			set{ _officeautomation_document_projagentclause_department=value;}
			get{return _officeautomation_document_projagentclause_department;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ProjAgentClause_ApplyDate
		{
			set{ _officeautomation_document_projagentclause_applydate=value;}
			get{return _officeautomation_document_projagentclause_applydate;}
		}
		/// <summary>
		/// 填写人
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_Apply
		{
			set{ _officeautomation_document_projagentclause_apply=value;}
			get{return _officeautomation_document_projagentclause_apply;}
		}
		/// <summary>
		/// 回复电话
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ReplyPhone
		{
			set{ _officeautomation_document_projagentclause_replyphone=value;}
			get{return _officeautomation_document_projagentclause_replyphone;}
		}
		/// <summary>
		/// 发文编号
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ApplyID
		{
			set{ _officeautomation_document_projagentclause_applyid=value;}
			get{return _officeautomation_document_projagentclause_applyid;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ProjName
		{
			set{ _officeautomation_document_projagentclause_projname=value;}
			get{return _officeautomation_document_projagentclause_projname;}
		}
		/// <summary>
		/// 开发商名称
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_DeveloperName
		{
			set{ _officeautomation_document_projagentclause_developername=value;}
			get{return _officeautomation_document_projagentclause_developername;}
		}
		/// <summary>
		/// 项目地址
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ProjAddress
		{
			set{ _officeautomation_document_projagentclause_projaddress=value;}
			get{return _officeautomation_document_projagentclause_projaddress;}
		}
		/// <summary>
		/// 项目代理开始日期
		/// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgentStart
		{
			set{ _officeautomation_document_projagentclause_agentstart=value;}
			get{return _officeautomation_document_projagentclause_agentstart;}
		}
		/// <summary>
		/// 项目代理结束日期
		/// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgentEnd
		{
			set{ _officeautomation_document_projagentclause_agentend=value;}
			get{return _officeautomation_document_projagentclause_agentend;}
		}
		/// <summary>
		/// 开售日
		/// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_SaleDate
		{
			set{ _officeautomation_document_projagentclause_saledate=value;}
			get{return _officeautomation_document_projagentclause_saledate;}
		}
		/// <summary>
		/// 物业性质
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs
		{
			set{ _officeautomation_document_projagentclause_dealofficetypeids=value;}
			get{return _officeautomation_document_projagentclause_dealofficetypeids;}
		}
		/// <summary>
		/// 其他物业性质描述
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_DealOfficeOther
		{
			set{ _officeautomation_document_projagentclause_dealofficeother=value;}
			get{return _officeautomation_document_projagentclause_dealofficeother;}
		}
		/// <summary>
		/// 货量
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_GoodsQuantity
		{
			set{ _officeautomation_document_projagentclause_goodsquantity=value;}
			get{return _officeautomation_document_projagentclause_goodsquantity;}
		}
		/// <summary>
		/// 货值
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_GoodsValue
		{
			set{ _officeautomation_document_projagentclause_goodsvalue=value;}
			get{return _officeautomation_document_projagentclause_goodsvalue;}
		}
		/// <summary>
		/// 预计创佣
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_PreComm
		{
			set{ _officeautomation_document_projagentclause_precomm=value;}
			get{return _officeautomation_document_projagentclause_precomm;}
		}
		/// <summary>
		/// 代理模式
		/// </summary>
		public int OfficeAutomation_Document_ProjAgentClause_AgentModel
		{
			set{ _officeautomation_document_projagentclause_agentmodel=value;}
			get{return _officeautomation_document_projagentclause_agentmodel;}
		}
		/// <summary>
		/// 佣金点数
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_CommPoint
		{
			set{ _officeautomation_document_projagentclause_commpoint=value;}
			get{return _officeautomation_document_projagentclause_commpoint;}
		}
		/// <summary>
		/// 合同类型
		/// </summary>
		public int OfficeAutomation_Document_ProjAgentClause_ContractType
		{
			set{ _officeautomation_document_projagentclause_contracttype=value;}
			get{return _officeautomation_document_projagentclause_contracttype;}
		}
		/// <summary>
		/// 其他合同类型描述
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ContractTypeOther
		{
			set{ _officeautomation_document_projagentclause_contracttypeother=value;}
			get{return _officeautomation_document_projagentclause_contracttypeother;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_Remark
		{
			set{ _officeautomation_document_projagentclause_remark=value;}
			get{return _officeautomation_document_projagentclause_remark;}
		}
        ///// <summary>
        ///// 业绩利润信息
        ///// </summary>
        //public string OfficeAutomation_Document_ProjAgentClause_PerformanceProfitInfo
        //{
        //    set { _officeautomation_document_projagentclause_performanceprofitinfo = value; }
        //    get { return _officeautomation_document_projagentclause_performanceprofitinfo; }
        //}
        ///// <summary>
        ///// 累计业绩合计
        ///// </summary>
        //public string OfficeAutomation_Document_ProjAgentClause_SumPerformance
        //{
        //    set { _officeautomation_document_projagentclause_sumperformance = value; }
        //    get { return _officeautomation_document_projagentclause_sumperformance; }
        //}
        ///// <summary>
        ///// 累计利润合计
        ///// </summary>
        //public string OfficeAutomation_Document_ProjAgentClause_SumProfit
        //{
        //    set { _officeautomation_document_projagentclause_sumprofit = value; }
        //    get { return _officeautomation_document_projagentclause_sumprofit; }
        //}
		/// <summary>
		/// 结佣条件条款
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm
		{
			set{ _officeautomation_document_projagentclause_clausesettlecomm=value;}
			get{return _officeautomation_document_projagentclause_clausesettlecomm;}
		}
		/// <summary>
		/// 扣罚条款
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ClauseFine
		{
			set{ _officeautomation_document_projagentclause_clausefine=value;}
			get{return _officeautomation_document_projagentclause_clausefine;}
		}
		/// <summary>
		/// 区域限制条款
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit
		{
			set{ _officeautomation_document_projagentclause_clausearealimit=value;}
			get{return _officeautomation_document_projagentclause_clausearealimit;}
		}
		/// <summary>
		/// 绩效考核条款
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck
		{
			set{ _officeautomation_document_projagentclause_clauseperforcheck=value;}
			get{return _officeautomation_document_projagentclause_clauseperforcheck;}
		}
		/// <summary>
		/// 廉洁条款
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ClauseHonest
		{
			set{ _officeautomation_document_projagentclause_clausehonest=value;}
			get{return _officeautomation_document_projagentclause_clausehonest;}
		}
		/// <summary>
		/// 其他条款
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_ClauseOther
		{
			set{ _officeautomation_document_projagentclause_clauseother=value;}
			get{return _officeautomation_document_projagentclause_clauseother;}
		}
		/// <summary>
		/// 标记
		/// </summary>
		public string OfficeAutomation_Document_ProjAgentClause_Sign
		{
			set{ _officeautomation_document_projagentclause_sign=value;}
			get{return _officeautomation_document_projagentclause_sign;}
		}
        /// <summary>
        /// 项目报备是否已审批
        /// </summary>
        public bool OfficeAutomation_Document_ProjAgentClause_PorjectExam
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_PorjectExam; }
            set { _OfficeAutomation_Document_ProjAgentClause_PorjectExam = value; }
        }

        //20141027+
        private int _OfficeAutomation_Document_ProjAgentClause_JOrT;
        /// <summary>
        /// 是否与行家联合代理或轮流代理
        /// </summary>
        public int OfficeAutomation_Document_ProjAgentClause_JOrT
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_JOrT; }
            set { _OfficeAutomation_Document_ProjAgentClause_JOrT = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1;
        /// <summary>
        /// 同场代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1; }
            set { _OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2;
        /// <summary>
        /// 同场代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2; }
            set { _OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1;
        /// <summary>
        /// 轮流代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1; }
            set { _OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2;
        /// <summary>
        /// 轮流代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2; }
            set { _OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_AgencyFee1;
        /// <summary>
        /// 同场代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyFee1
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_AgencyFee1; }
            set { _OfficeAutomation_Document_ProjAgentClause_AgencyFee1 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_AgencyFee2;
        /// <summary>
        /// 同场代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyFee2
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_AgencyFee2; }
            set { _OfficeAutomation_Document_ProjAgentClause_AgencyFee2 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_AgencyFee3;
        /// <summary>
        /// 轮流代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyFee3
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_AgencyFee3; }
            set { _OfficeAutomation_Document_ProjAgentClause_AgencyFee3 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_AgencyFee4;
        /// <summary>
        /// 轮流代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyFee4
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_AgencyFee4; }
            set { _OfficeAutomation_Document_ProjAgentClause_AgencyFee4 = value; }
        }

        private bool _OfficeAutomation_Document_ProjAgentClause_IsCashPrize1;
        /// <summary>
        /// 是否有同场代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ProjAgentClause_IsCashPrize1
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_IsCashPrize1; }
            set { _OfficeAutomation_Document_ProjAgentClause_IsCashPrize1 = value; }
        }

        private bool _OfficeAutomation_Document_ProjAgentClause_IsCashPrize2;
        /// <summary>
        /// 是否有同场代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ProjAgentClause_IsCashPrize2
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_IsCashPrize2; }
            set { _OfficeAutomation_Document_ProjAgentClause_IsCashPrize2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjAgentClause_IsCashPrize3;
        /// <summary>
        /// 是否有轮流代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ProjAgentClause_IsCashPrize3
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_IsCashPrize3; }
            set { _OfficeAutomation_Document_ProjAgentClause_IsCashPrize3 = value; }
        }

        private bool _OfficeAutomation_Document_ProjAgentClause_IsCashPrize4;
        /// <summary>
        /// 是否有轮流代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ProjAgentClause_IsCashPrize4
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_IsCashPrize4; }
            set { _OfficeAutomation_Document_ProjAgentClause_IsCashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_CashPrize1;
        /// <summary>
        /// 同场代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_CashPrize1
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_CashPrize1; }
            set { _OfficeAutomation_Document_ProjAgentClause_CashPrize1 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_CashPrize2;
        /// <summary>
        /// 同场代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_CashPrize2
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_CashPrize2; }
            set { _OfficeAutomation_Document_ProjAgentClause_CashPrize2 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_CashPrize3;
        /// <summary>
        /// 轮流代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_CashPrize3
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_CashPrize3; }
            set { _OfficeAutomation_Document_ProjAgentClause_CashPrize3 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_CashPrize4;
        /// <summary>
        /// 轮流代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_CashPrize4
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_CashPrize4; }
            set { _OfficeAutomation_Document_ProjAgentClause_CashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1;
        /// <summary>
        /// 轮流代理行家代理开始期1
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1; }
            set { _OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2;
        /// <summary>
        /// 轮流代理行家代理开始期2
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2; }
            set { _OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1;
        /// <summary>
        /// 轮流代理行家代理结束期1
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1; }
            set { _OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2;
        /// <summary>
        /// 轮流代理行家代理结束期2
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2; }
            set { _OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjAgentClause_IsPFear1;
        /// <summary>
        /// 是否有项目费用1
        /// </summary>
        public bool OfficeAutomation_Document_ProjAgentClause_IsPFear1
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_IsPFear1; }
            set { _OfficeAutomation_Document_ProjAgentClause_IsPFear1 = value; }
        }

        private bool _OfficeAutomation_Document_ProjAgentClause_IsPFear2;
        /// <summary>
        /// 是否有项目费用2
        /// </summary>
        public bool OfficeAutomation_Document_ProjAgentClause_IsPFear2
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_IsPFear2; }
            set { _OfficeAutomation_Document_ProjAgentClause_IsPFear2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjAgentClause_IsPFear3;
        /// <summary>
        /// 是否有项目费用3
        /// </summary>
        public bool OfficeAutomation_Document_ProjAgentClause_IsPFear3
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_IsPFear3; }
            set { _OfficeAutomation_Document_ProjAgentClause_IsPFear3 = value; }
        }

        private bool _OfficeAutomation_Document_ProjAgentClause_IsPFear4;
        /// <summary>
        /// 是否有项目费用4
        /// </summary>
        public bool OfficeAutomation_Document_ProjAgentClause_IsPFear4
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_IsPFear4; }
            set { _OfficeAutomation_Document_ProjAgentClause_IsPFear4 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_PFear1;
        /// <summary>
        /// 项目费用1
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PFear1
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_PFear1; }
            set { _OfficeAutomation_Document_ProjAgentClause_PFear1 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_PFear2;
        /// <summary>
        /// 项目费用2
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PFear2
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_PFear2; }
            set { _OfficeAutomation_Document_ProjAgentClause_PFear2 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_PFear3;
        /// <summary>
        /// 项目费用3
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PFear3
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_PFear3; }
            set { _OfficeAutomation_Document_ProjAgentClause_PFear3 = value; }
        }

        private string _OfficeAutomation_Document_ProjAgentClause_PFear4;
        /// <summary>
        /// 项目费用4
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PFear4
        {
            get { return _OfficeAutomation_Document_ProjAgentClause_PFear4; }
            set { _OfficeAutomation_Document_ProjAgentClause_PFear4 = value; }
        }
        //20141027+

		#endregion Model

	}
}

