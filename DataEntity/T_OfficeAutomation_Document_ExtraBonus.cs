/*
* T_OfficeAutomation_Document_ExtraBonus.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_ExtraBonus
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/10 16:25:40    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 项目发展商额外奖金报备
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_ExtraBonus
	{
		public T_OfficeAutomation_Document_ExtraBonus()
		{}
		#region Model
		private Guid _officeautomation_document_extrabonus_id;
		private Guid _officeautomation_document_extrabonus_mainid;
		private string _officeautomation_document_extrabonus_apply;
		private string _officeautomation_document_extrabonus_applyforname;
		private string _officeautomation_document_extrabonus_applyforcode;
		private string _officeautomation_document_extrabonus_department;
		private Guid _officeautomation_document_extrabonus_departmentid;
		private DateTime _officeautomation_document_extrabonus_applydate;
		private string _officeautomation_document_extrabonus_replyphone;
        private string _officeautomation_document_extrabonus_project;
		private DateTime _officeautomation_document_extrabonus_agentstartdate;
		private DateTime _officeautomation_document_extrabonus_agentenddate;
		private DateTime _officeautomation_document_extrabonus_clientguardstartdate;
		private DateTime _officeautomation_document_extrabonus_clientguardenddate;
		private string _officeautomation_document_extrabonus_agentrule;
		private DateTime _officeautomation_document_extrabonus_applycashrewardvaliditydurationstartdate;
		private DateTime _officeautomation_document_extrabonus_applycashrewardvaliditydurationenddate;
		private bool _officeautomation_document_extrabonus_isfullpay;
		private string _officeautomation_document_extrabonus_rewardrule;
		private int _officeautomation_document_extrabonus_rewardpaytypeid;
		private string _officeautomation_document_extrabonus_payername;
		private string _officeautomation_document_extrabonus_payerposition;
		private string _officeautomation_document_extrabonus_payerphone;
		private string _officeautomation_document_extrabonus_receviecashrewardaccountname;
		private string _officeautomation_document_extrabonus_receviecashrewardaccounts;
		private bool _officeautomation_document_extrabonus_isneedpayfee;
		private string _officeautomation_document_extrabonus_rewardpaytypeothercase;
		private bool _officeautomation_document_extrabonus_issubmitconfirmation;
		private DateTime? _officeautomation_document_extrabonus_areapromisesubmitdate;
		private string _officeautomation_document_extrabonus_remark;
		/// <summary>
		/// 主键
		/// </summary>
		public Guid OfficeAutomation_Document_ExtraBonus_ID
		{
			set{ _officeautomation_document_extrabonus_id=value;}
			get{return _officeautomation_document_extrabonus_id;}
		}
		/// <summary>
		/// 公文流转主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_ExtraBonus_MainID
		{
			set{ _officeautomation_document_extrabonus_mainid=value;}
			get{return _officeautomation_document_extrabonus_mainid;}
		}
		/// <summary>
		/// 填写人
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Apply
		{
			set{ _officeautomation_document_extrabonus_apply=value;}
			get{return _officeautomation_document_extrabonus_apply;}
		}
		/// <summary>
		/// 申请人姓名
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_ApplyForName
		{
			set{ _officeautomation_document_extrabonus_applyforname=value;}
			get{return _officeautomation_document_extrabonus_applyforname;}
		}
		/// <summary>
		/// 申请人工号
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_ApplyForCode
		{
			set{ _officeautomation_document_extrabonus_applyforcode=value;}
			get{return _officeautomation_document_extrabonus_applyforcode;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Department
		{
			set{ _officeautomation_document_extrabonus_department=value;}
			get{return _officeautomation_document_extrabonus_department;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public Guid OfficeAutomation_Document_ExtraBonus_DepartmentID
		{
			set{ _officeautomation_document_extrabonus_departmentid=value;}
			get{return _officeautomation_document_extrabonus_departmentid;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ExtraBonus_ApplyDate
		{
			set{ _officeautomation_document_extrabonus_applydate=value;}
			get{return _officeautomation_document_extrabonus_applydate;}
		}
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_ReplyPhone
        {
            set { _officeautomation_document_extrabonus_replyphone = value; }
            get { return _officeautomation_document_extrabonus_replyphone; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_Project
        {
            set { _officeautomation_document_extrabonus_project = value; }
            get { return _officeautomation_document_extrabonus_project; }
        }
		/// <summary>
		/// 项目代理期开始日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ExtraBonus_AgentStartDate
		{
			set{ _officeautomation_document_extrabonus_agentstartdate=value;}
			get{return _officeautomation_document_extrabonus_agentstartdate;}
		}
		/// <summary>
		/// 项目代理期结束日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ExtraBonus_AgentEndDate
		{
			set{ _officeautomation_document_extrabonus_agentenddate=value;}
			get{return _officeautomation_document_extrabonus_agentenddate;}
		}
		/// <summary>
		/// 客户保护期开始日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ExtraBonus_ClientGuardStartDate
		{
			set{ _officeautomation_document_extrabonus_clientguardstartdate=value;}
			get{return _officeautomation_document_extrabonus_clientguardstartdate;}
		}
		/// <summary>
		/// 客户保护期结束日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ExtraBonus_ClientGuardEndDate
		{
			set{ _officeautomation_document_extrabonus_clientguardenddate=value;}
			get{return _officeautomation_document_extrabonus_clientguardenddate;}
		}
		/// <summary>
		/// 项目代理标准
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_AgentRule
		{
			set{ _officeautomation_document_extrabonus_agentrule=value;}
			get{return _officeautomation_document_extrabonus_agentrule;}
		}
		/// <summary>
		/// 申请现金奖有效期开始日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationStartDate
		{
			set{ _officeautomation_document_extrabonus_applycashrewardvaliditydurationstartdate=value;}
			get{return _officeautomation_document_extrabonus_applycashrewardvaliditydurationstartdate;}
		}
		/// <summary>
		/// 申请现金奖有效期结束日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ExtraBonus_ApplyCashRewardValidityDurationEndDate
		{
			set{ _officeautomation_document_extrabonus_applycashrewardvaliditydurationenddate=value;}
			get{return _officeautomation_document_extrabonus_applycashrewardvaliditydurationenddate;}
		}
		/// <summary>
		/// 是否全额发放现金奖
		/// </summary>
		public bool OfficeAutomation_Document_ExtraBonus_IsFullPay
		{
			set{ _officeautomation_document_extrabonus_isfullpay=value;}
			get{return _officeautomation_document_extrabonus_isfullpay;}
		}
		/// <summary>
		/// 现金奖的标准
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_RewardRule
		{
			set{ _officeautomation_document_extrabonus_rewardrule=value;}
			get{return _officeautomation_document_extrabonus_rewardrule;}
		}
		/// <summary>
		/// 现金奖的发放方式
		/// </summary>
		public int OfficeAutomation_Document_ExtraBonus_RewardPayTypeID
		{
			set{ _officeautomation_document_extrabonus_rewardpaytypeid=value;}
			get{return _officeautomation_document_extrabonus_rewardpaytypeid;}
		}
		/// <summary>
		/// 现金奖发放统筹人员姓名
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_PayerName
		{
			set{ _officeautomation_document_extrabonus_payername=value;}
			get{return _officeautomation_document_extrabonus_payername;}
		}
		/// <summary>
		/// 现金奖发放统筹人员职务
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_PayerPosition
		{
			set{ _officeautomation_document_extrabonus_payerposition=value;}
			get{return _officeautomation_document_extrabonus_payerposition;}
		}
		/// <summary>
		/// 现金奖发放统筹人员联系电话
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_PayerPhone
		{
			set{ _officeautomation_document_extrabonus_payerphone=value;}
			get{return _officeautomation_document_extrabonus_payerphone;}
		}
		/// <summary>
		/// 接收现金奖银行帐号的帐户姓名
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccountName
		{
			set{ _officeautomation_document_extrabonus_receviecashrewardaccountname=value;}
			get{return _officeautomation_document_extrabonus_receviecashrewardaccountname;}
		}
		/// <summary>
		/// 接收现金奖银行帐号
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_RecevieCashRewardAccounts
		{
			set{ _officeautomation_document_extrabonus_receviecashrewardaccounts=value;}
			get{return _officeautomation_document_extrabonus_receviecashrewardaccounts;}
		}
		/// <summary>
		/// 现金奖是否需开具发票并由我司支付税费
		/// </summary>
		public bool OfficeAutomation_Document_ExtraBonus_IsNeedPayFee
		{
			set{ _officeautomation_document_extrabonus_isneedpayfee=value;}
			get{return _officeautomation_document_extrabonus_isneedpayfee;}
		}
		/// <summary>
		/// 现金奖发放类型其他情况
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_RewardPayTypeOtherCase
		{
			set{ _officeautomation_document_extrabonus_rewardpaytypeothercase=value;}
			get{return _officeautomation_document_extrabonus_rewardpaytypeothercase;}
		}
		/// <summary>
		/// 区域是否已提交发展商奖金确认书
		/// </summary>
		public bool OfficeAutomation_Document_ExtraBonus_IsSubmitConfirmation
		{
			set{ _officeautomation_document_extrabonus_issubmitconfirmation=value;}
			get{return _officeautomation_document_extrabonus_issubmitconfirmation;}
		}
		/// <summary>
		/// 承诺提交日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_ExtraBonus_AreaPromiseSubmitDate
		{
			set{ _officeautomation_document_extrabonus_areapromisesubmitdate=value;}
			get{return _officeautomation_document_extrabonus_areapromisesubmitdate;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Remark
		{
			set{ _officeautomation_document_extrabonus_remark=value;}
			get{return _officeautomation_document_extrabonus_remark;}
		}

        //20141027+
        private int _OfficeAutomation_Document_ExtraBonus_JOrT;
        /// <summary>
        /// 是否与行家联合代理或轮流代理
        /// </summary>
        public int OfficeAutomation_Document_ExtraBonus_JOrT
        {
            get { return _OfficeAutomation_Document_ExtraBonus_JOrT; }
            set { _OfficeAutomation_Document_ExtraBonus_JOrT = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_SamePlaceXX1;
        /// <summary>
        /// 同场代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_SamePlaceXX1
        {
            get { return _OfficeAutomation_Document_ExtraBonus_SamePlaceXX1; }
            set { _OfficeAutomation_Document_ExtraBonus_SamePlaceXX1 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_SamePlaceXX2;
        /// <summary>
        /// 同场代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_SamePlaceXX2
        {
            get { return _OfficeAutomation_Document_ExtraBonus_SamePlaceXX2; }
            set { _OfficeAutomation_Document_ExtraBonus_SamePlaceXX2 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1;
        /// <summary>
        /// 轮流代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1
        {
            get { return _OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1; }
            set { _OfficeAutomation_Document_ExtraBonus_TurnsAgentXX1 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2;
        /// <summary>
        /// 轮流代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2
        {
            get { return _OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2; }
            set { _OfficeAutomation_Document_ExtraBonus_TurnsAgentXX2 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_AgencyFee1;
        /// <summary>
        /// 同场代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_AgencyFee1
        {
            get { return _OfficeAutomation_Document_ExtraBonus_AgencyFee1; }
            set { _OfficeAutomation_Document_ExtraBonus_AgencyFee1 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_AgencyFee2;
        /// <summary>
        /// 同场代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_AgencyFee2
        {
            get { return _OfficeAutomation_Document_ExtraBonus_AgencyFee2; }
            set { _OfficeAutomation_Document_ExtraBonus_AgencyFee2 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_AgencyFee3;
        /// <summary>
        /// 轮流代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_AgencyFee3
        {
            get { return _OfficeAutomation_Document_ExtraBonus_AgencyFee3; }
            set { _OfficeAutomation_Document_ExtraBonus_AgencyFee3 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_AgencyFee4;
        /// <summary>
        /// 轮流代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_AgencyFee4
        {
            get { return _OfficeAutomation_Document_ExtraBonus_AgencyFee4; }
            set { _OfficeAutomation_Document_ExtraBonus_AgencyFee4 = value; }
        }

        private bool _OfficeAutomation_Document_ExtraBonus_IsCashPrize1;
        /// <summary>
        /// 是否有同场代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ExtraBonus_IsCashPrize1
        {
            get { return _OfficeAutomation_Document_ExtraBonus_IsCashPrize1; }
            set { _OfficeAutomation_Document_ExtraBonus_IsCashPrize1 = value; }
        }

        private bool _OfficeAutomation_Document_ExtraBonus_IsCashPrize2;
        /// <summary>
        /// 是否有同场代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ExtraBonus_IsCashPrize2
        {
            get { return _OfficeAutomation_Document_ExtraBonus_IsCashPrize2; }
            set { _OfficeAutomation_Document_ExtraBonus_IsCashPrize2 = value; }
        }

        private bool _OfficeAutomation_Document_ExtraBonus_IsCashPrize3;
        /// <summary>
        /// 是否有轮流代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ExtraBonus_IsCashPrize3
        {
            get { return _OfficeAutomation_Document_ExtraBonus_IsCashPrize3; }
            set { _OfficeAutomation_Document_ExtraBonus_IsCashPrize3 = value; }
        }

        private bool _OfficeAutomation_Document_ExtraBonus_IsCashPrize4;
        /// <summary>
        /// 是否有轮流代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ExtraBonus_IsCashPrize4
        {
            get { return _OfficeAutomation_Document_ExtraBonus_IsCashPrize4; }
            set { _OfficeAutomation_Document_ExtraBonus_IsCashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_CashPrize1;
        /// <summary>
        /// 同场代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_CashPrize1
        {
            get { return _OfficeAutomation_Document_ExtraBonus_CashPrize1; }
            set { _OfficeAutomation_Document_ExtraBonus_CashPrize1 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_CashPrize2;
        /// <summary>
        /// 同场代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_CashPrize2
        {
            get { return _OfficeAutomation_Document_ExtraBonus_CashPrize2; }
            set { _OfficeAutomation_Document_ExtraBonus_CashPrize2 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_CashPrize3;
        /// <summary>
        /// 轮流代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_CashPrize3
        {
            get { return _OfficeAutomation_Document_ExtraBonus_CashPrize3; }
            set { _OfficeAutomation_Document_ExtraBonus_CashPrize3 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_CashPrize4;
        /// <summary>
        /// 轮流代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_CashPrize4
        {
            get { return _OfficeAutomation_Document_ExtraBonus_CashPrize4; }
            set { _OfficeAutomation_Document_ExtraBonus_CashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1;
        /// <summary>
        /// 轮流代理行家代理开始期1
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1
        {
            get { return _OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1; }
            set { _OfficeAutomation_Document_ExtraBonus_AgencyBeginDate1 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2;
        /// <summary>
        /// 轮流代理行家代理开始期2
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2
        {
            get { return _OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2; }
            set { _OfficeAutomation_Document_ExtraBonus_AgencyBeginDate2 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_AgencyEndDate1;
        /// <summary>
        /// 轮流代理行家代理结束期1
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_AgencyEndDate1
        {
            get { return _OfficeAutomation_Document_ExtraBonus_AgencyEndDate1; }
            set { _OfficeAutomation_Document_ExtraBonus_AgencyEndDate1 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_AgencyEndDate2;
        /// <summary>
        /// 轮流代理行家代理结束期2
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_AgencyEndDate2
        {
            get { return _OfficeAutomation_Document_ExtraBonus_AgencyEndDate2; }
            set { _OfficeAutomation_Document_ExtraBonus_AgencyEndDate2 = value; }
        }

        private bool _OfficeAutomation_Document_ExtraBonus_IsPFear1;
        /// <summary>
        /// 是否有项目费用1
        /// </summary>
        public bool OfficeAutomation_Document_ExtraBonus_IsPFear1
        {
            get { return _OfficeAutomation_Document_ExtraBonus_IsPFear1; }
            set { _OfficeAutomation_Document_ExtraBonus_IsPFear1 = value; }
        }

        private bool _OfficeAutomation_Document_ExtraBonus_IsPFear2;
        /// <summary>
        /// 是否有项目费用2
        /// </summary>
        public bool OfficeAutomation_Document_ExtraBonus_IsPFear2
        {
            get { return _OfficeAutomation_Document_ExtraBonus_IsPFear2; }
            set { _OfficeAutomation_Document_ExtraBonus_IsPFear2 = value; }
        }

        private bool _OfficeAutomation_Document_ExtraBonus_IsPFear3;
        /// <summary>
        /// 是否有项目费用3
        /// </summary>
        public bool OfficeAutomation_Document_ExtraBonus_IsPFear3
        {
            get { return _OfficeAutomation_Document_ExtraBonus_IsPFear3; }
            set { _OfficeAutomation_Document_ExtraBonus_IsPFear3 = value; }
        }

        private bool _OfficeAutomation_Document_ExtraBonus_IsPFear4;
        /// <summary>
        /// 是否有项目费用4
        /// </summary>
        public bool OfficeAutomation_Document_ExtraBonus_IsPFear4
        {
            get { return _OfficeAutomation_Document_ExtraBonus_IsPFear4; }
            set { _OfficeAutomation_Document_ExtraBonus_IsPFear4 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_PFear1;
        /// <summary>
        /// 项目费用1
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_PFear1
        {
            get { return _OfficeAutomation_Document_ExtraBonus_PFear1; }
            set { _OfficeAutomation_Document_ExtraBonus_PFear1 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_PFear2;
        /// <summary>
        /// 项目费用2
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_PFear2
        {
            get { return _OfficeAutomation_Document_ExtraBonus_PFear2; }
            set { _OfficeAutomation_Document_ExtraBonus_PFear2 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_PFear3;
        /// <summary>
        /// 项目费用3
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_PFear3
        {
            get { return _OfficeAutomation_Document_ExtraBonus_PFear3; }
            set { _OfficeAutomation_Document_ExtraBonus_PFear3 = value; }
        }

        private string _OfficeAutomation_Document_ExtraBonus_PFear4;
        /// <summary>
        /// 项目费用4
        /// </summary>
        public string OfficeAutomation_Document_ExtraBonus_PFear4
        {
            get { return _OfficeAutomation_Document_ExtraBonus_PFear4; }
            set { _OfficeAutomation_Document_ExtraBonus_PFear4 = value; }
        }
        //20141027+

		#endregion Model

	}
}

