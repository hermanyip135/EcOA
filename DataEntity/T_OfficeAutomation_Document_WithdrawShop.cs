/*
* T_OfficeAutomation_Document_WithdrawShop.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_WithdrawShop
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/16 14:32:39    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 撤铺/转铺申请表
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_WithdrawShop
	{
		public T_OfficeAutomation_Document_WithdrawShop()
		{}
		#region Model
		private Guid _officeautomation_document_withdrawshop_id;
		private Guid _officeautomation_document_withdrawshop_mainid;
		private string _officeautomation_document_withdrawshop_apply;
		private string _officeautomation_document_withdrawshop_applyid;
		private DateTime _officeautomation_document_withdrawshop_applydate;
		private string _officeautomation_document_withdrawshop_department;
		private string _officeautomation_document_withdrawshop_replyphone;
		private string _officeautomation_document_withdrawshop_replyfax;
		private int _officeautomation_document_withdrawshop_applytypeid;
		private int _officeautomation_document_withdrawshop_departmenttypeid;
		private int _officeautomation_document_withdrawshop_majordomoid;
		private string _officeautomation_document_withdrawshop_departmentname;
		private string _officeautomation_document_withdrawshop_departmentaddress;
		private DateTime _officeautomation_document_withdrawshop_expiredate;
		private DateTime _officeautomation_document_withdrawshop_plandate;
		private string _officeautomation_document_withdrawshop_reason;
		private string _officeautomation_document_withdrawshop_assethandleids;
		private string _officeautomation_document_withdrawshop_assethandleother;
		private int _officeautomation_document_withdrawshop_phonehandleid;
		private bool _officeautomation_document_withdrawshop_isflyline;
		private string _officeautomation_document_withdrawshop_flylinefrom;
		private string _officeautomation_document_withdrawshop_flylineto;
		private bool _officeautomation_document_withdrawshop_canbackdeposit;
		private string _officeautomation_document_withdrawshop_backdeposit;
		private bool _officeautomation_document_withdrawshop_willliquidateddamages;
        private string _officeautomation_document_withdrawshop_liquidateddamages;
        private DateTime _officeautomation_document_withdrawshop_paymentamortizeenddate;
        private string _officeautomation_document_withdrawshop_paymentamortizeremaining;
		private string _officeautomation_document_withdrawshop_remark;

        private string _officeAutomation_Document_WithdrawShop_Deposit;
        private string _officeAutomation_Document_WithdrawShop_NoBackDeposit;

		/// <summary>
		/// 主键
		/// </summary>
        [CProperty("Key")]
		public Guid OfficeAutomation_Document_WithdrawShop_ID
		{
			set{ _officeautomation_document_withdrawshop_id=value;}
			get{return _officeautomation_document_withdrawshop_id;}
		}
		/// <summary>
		/// 公文流转主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_WithdrawShop_MainID
		{
			set{ _officeautomation_document_withdrawshop_mainid=value;}
			get{return _officeautomation_document_withdrawshop_mainid;}
		}
		/// <summary>
		/// 填写人
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_Apply
		{
			set{ _officeautomation_document_withdrawshop_apply=value;}
			get{return _officeautomation_document_withdrawshop_apply;}
		}
		/// <summary>
		/// 发文编号
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_ApplyID
		{
			set{ _officeautomation_document_withdrawshop_applyid=value;}
			get{return _officeautomation_document_withdrawshop_applyid;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_WithdrawShop_ApplyDate
		{
			set{ _officeautomation_document_withdrawshop_applydate=value;}
			get{return _officeautomation_document_withdrawshop_applydate;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_Department
		{
			set{ _officeautomation_document_withdrawshop_department=value;}
			get{return _officeautomation_document_withdrawshop_department;}
		}
		/// <summary>
		/// 回复电话
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_ReplyPhone
		{
			set{ _officeautomation_document_withdrawshop_replyphone=value;}
			get{return _officeautomation_document_withdrawshop_replyphone;}
		}
		/// <summary>
		/// 回复传真
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_ReplyFax
		{
			set{ _officeautomation_document_withdrawshop_replyfax=value;}
			get{return _officeautomation_document_withdrawshop_replyfax;}
		}
		/// <summary>
		/// 申请类型
		/// </summary>
		public int OfficeAutomation_Document_WithdrawShop_ApplyTypeID
		{
			set{ _officeautomation_document_withdrawshop_applytypeid=value;}
			get{return _officeautomation_document_withdrawshop_applytypeid;}
		}
		/// <summary>
		/// 部门类型
		/// </summary>
		public int OfficeAutomation_Document_WithdrawShop_DepartmentTypeID
		{
			set{ _officeautomation_document_withdrawshop_departmenttypeid=value;}
			get{return _officeautomation_document_withdrawshop_departmenttypeid;}
		}
		/// <summary>
		/// 总监
		/// </summary>
		public int OfficeAutomation_Document_WithdrawShop_MajordomoID
		{
			set{ _officeautomation_document_withdrawshop_majordomoid=value;}
			get{return _officeautomation_document_withdrawshop_majordomoid;}
		}
		/// <summary>
		/// 操作部门名称
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_DepartmentName
		{
			set{ _officeautomation_document_withdrawshop_departmentname=value;}
			get{return _officeautomation_document_withdrawshop_departmentname;}
		}
		/// <summary>
		/// 操作部门地址
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_DepartmentAddress
		{
			set{ _officeautomation_document_withdrawshop_departmentaddress=value;}
			get{return _officeautomation_document_withdrawshop_departmentaddress;}
		}
		/// <summary>
		/// 租约届满日期
		/// </summary>
		public DateTime OfficeAutomation_Document_WithdrawShop_ExpireDate
		{
			set{ _officeautomation_document_withdrawshop_expiredate=value;}
			get{return _officeautomation_document_withdrawshop_expiredate;}
		}
		/// <summary>
		/// 计划实行日期
		/// </summary>
		public DateTime OfficeAutomation_Document_WithdrawShop_PlanDate
		{
			set{ _officeautomation_document_withdrawshop_plandate=value;}
			get{return _officeautomation_document_withdrawshop_plandate;}
		}
		/// <summary>
		/// 原因
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_Reason
		{
			set{ _officeautomation_document_withdrawshop_reason=value;}
			get{return _officeautomation_document_withdrawshop_reason;}
		}
		/// <summary>
		/// 资产处理
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_AssetHandleIDs
		{
			set{ _officeautomation_document_withdrawshop_assethandleids=value;}
			get{return _officeautomation_document_withdrawshop_assethandleids;}
		}
		/// <summary>
		/// 其他资产处理情况
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_AssetHandleOther
		{
			set{ _officeautomation_document_withdrawshop_assethandleother=value;}
			get{return _officeautomation_document_withdrawshop_assethandleother;}
		}
		/// <summary>
		/// 电话处理
		/// </summary>
		public int OfficeAutomation_Document_WithdrawShop_PhoneHandleID
		{
			set{ _officeautomation_document_withdrawshop_phonehandleid=value;}
			get{return _officeautomation_document_withdrawshop_phonehandleid;}
		}
		/// <summary>
		/// 是否飞线
		/// </summary>
		public bool OfficeAutomation_Document_WithdrawShop_IsFlyLine
		{
			set{ _officeautomation_document_withdrawshop_isflyline=value;}
			get{return _officeautomation_document_withdrawshop_isflyline;}
		}
		/// <summary>
		/// 飞线分行
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_FlyLineFrom
		{
			set{ _officeautomation_document_withdrawshop_flylinefrom=value;}
			get{return _officeautomation_document_withdrawshop_flylinefrom;}
		}
		/// <summary>
		/// 飞线到的分行
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_FlyLineTo
		{
			set{ _officeautomation_document_withdrawshop_flylineto=value;}
			get{return _officeautomation_document_withdrawshop_flylineto;}
		}
		/// <summary>
		/// 能否收回押金
		/// </summary>
		public bool OfficeAutomation_Document_WithdrawShop_CanBackDeposit
		{
			set{ _officeautomation_document_withdrawshop_canbackdeposit=value;}
			get{return _officeautomation_document_withdrawshop_canbackdeposit;}
		}
		/// <summary>
		/// 收回押金数目
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_BackDeposit
		{
			set{ _officeautomation_document_withdrawshop_backdeposit=value;}
			get{return _officeautomation_document_withdrawshop_backdeposit;}
		}
		/// <summary>
		/// 是否产生违约金
		/// </summary>
		public bool OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages
		{
			set{ _officeautomation_document_withdrawshop_willliquidateddamages=value;}
			get{return _officeautomation_document_withdrawshop_willliquidateddamages;}
		}
		/// <summary>
		/// 产生违约金的数目
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_LiquidatedDamages
		{
			set{ _officeautomation_document_withdrawshop_liquidateddamages=value;}
			get{return _officeautomation_document_withdrawshop_liquidateddamages;}
		}

        private string _OfficeAutomation_Document_WithdrawShop_A1;

        public string OfficeAutomation_Document_WithdrawShop_A1
        {
            get { return _OfficeAutomation_Document_WithdrawShop_A1; }
            set { _OfficeAutomation_Document_WithdrawShop_A1 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_A2;

        public string OfficeAutomation_Document_WithdrawShop_A2
        {
            get { return _OfficeAutomation_Document_WithdrawShop_A2; }
            set { _OfficeAutomation_Document_WithdrawShop_A2 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_A3;

        public string OfficeAutomation_Document_WithdrawShop_A3
        {
            get { return _OfficeAutomation_Document_WithdrawShop_A3; }
            set { _OfficeAutomation_Document_WithdrawShop_A3 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_B1;

        public string OfficeAutomation_Document_WithdrawShop_B1
        {
            get { return _OfficeAutomation_Document_WithdrawShop_B1; }
            set { _OfficeAutomation_Document_WithdrawShop_B1 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_B2;

        public string OfficeAutomation_Document_WithdrawShop_B2
        {
            get { return _OfficeAutomation_Document_WithdrawShop_B2; }
            set { _OfficeAutomation_Document_WithdrawShop_B2 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_B3;

        public string OfficeAutomation_Document_WithdrawShop_B3
        {
            get { return _OfficeAutomation_Document_WithdrawShop_B3; }
            set { _OfficeAutomation_Document_WithdrawShop_B3 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_C1;

        public string OfficeAutomation_Document_WithdrawShop_C1
        {
            get { return _OfficeAutomation_Document_WithdrawShop_C1; }
            set { _OfficeAutomation_Document_WithdrawShop_C1 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_C2;

        public string OfficeAutomation_Document_WithdrawShop_C2
        {
            get { return _OfficeAutomation_Document_WithdrawShop_C2; }
            set { _OfficeAutomation_Document_WithdrawShop_C2 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_C3;

        public string OfficeAutomation_Document_WithdrawShop_C3
        {
            get { return _OfficeAutomation_Document_WithdrawShop_C3; }
            set { _OfficeAutomation_Document_WithdrawShop_C3 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_D1;

        public string OfficeAutomation_Document_WithdrawShop_D1
        {
            get { return _OfficeAutomation_Document_WithdrawShop_D1; }
            set { _OfficeAutomation_Document_WithdrawShop_D1 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_E1;

        public string OfficeAutomation_Document_WithdrawShop_E1
        {
            get { return _OfficeAutomation_Document_WithdrawShop_E1; }
            set { _OfficeAutomation_Document_WithdrawShop_E1 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_E2;

        public string OfficeAutomation_Document_WithdrawShop_E2
        {
            get { return _OfficeAutomation_Document_WithdrawShop_E2; }
            set { _OfficeAutomation_Document_WithdrawShop_E2 = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_E3;

        public string OfficeAutomation_Document_WithdrawShop_E3
        {
            get { return _OfficeAutomation_Document_WithdrawShop_E3; }
            set { _OfficeAutomation_Document_WithdrawShop_E3 = value; }
        }

        /// <summary>
        /// 工程款摊销结束日
        /// </summary>
        public DateTime OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate
        {
            set { _officeautomation_document_withdrawshop_paymentamortizeenddate = value; }
            get { return _officeautomation_document_withdrawshop_paymentamortizeenddate; }
        }

        /// <summary>
        /// 工程款摊销余额
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining
        {
            set { _officeautomation_document_withdrawshop_paymentamortizeremaining = value; }
            get { return _officeautomation_document_withdrawshop_paymentamortizeremaining; }
        }


		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_WithdrawShop_Remark
		{
			set{ _officeautomation_document_withdrawshop_remark=value;}
			get{return _officeautomation_document_withdrawshop_remark;}
		}

        /// <summary>
        /// 不能回收部分
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_NoBackDeposit
        {
            get { return _officeAutomation_Document_WithdrawShop_NoBackDeposit; }
            set { _officeAutomation_Document_WithdrawShop_NoBackDeposit = value; }
        }

        /// <summary>
        /// 押金数目
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_Deposit
        {
            get { return _officeAutomation_Document_WithdrawShop_Deposit; }
            set { _officeAutomation_Document_WithdrawShop_Deposit = value; }
        }

        private DateTime _OfficeAutomation_Document_WithdrawShop_StartDate;

        public DateTime OfficeAutomation_Document_WithdrawShop_StartDate
        {
            get { return _OfficeAutomation_Document_WithdrawShop_StartDate; }
            set { _OfficeAutomation_Document_WithdrawShop_StartDate = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance;

        public string OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance
        {
            get { return _OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance; }
            set { _OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining;

        public string OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining
        {
            get { return _OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining; }
            set { _OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining = value; }
        }

        private DateTime _OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate;

        public DateTime OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate
        {
            get { return _OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate; }
            set { _OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_AreaLastYear;

        public string OfficeAutomation_Document_WithdrawShop_AreaLastYear
        {
            get { return _OfficeAutomation_Document_WithdrawShop_AreaLastYear; }
            set { _OfficeAutomation_Document_WithdrawShop_AreaLastYear = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_AreaLastYearResults;

        public string OfficeAutomation_Document_WithdrawShop_AreaLastYearResults
        {
            get { return _OfficeAutomation_Document_WithdrawShop_AreaLastYearResults; }
            set { _OfficeAutomation_Document_WithdrawShop_AreaLastYearResults = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit;

        public string OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit
        {
            get { return _OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit; }
            set { _OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit = value; }
        }

        private DateTime _OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate;

        public DateTime OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate
        {
            get { return _OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate; }
            set { _OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate = value; }
        }

        private DateTime _OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate;

        public DateTime OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate
        {
            get { return _OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate; }
            set { _OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_AreaThisYResults;

        public string OfficeAutomation_Document_WithdrawShop_AreaThisYResults
        {
            get { return _OfficeAutomation_Document_WithdrawShop_AreaThisYResults; }
            set { _OfficeAutomation_Document_WithdrawShop_AreaThisYResults = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_AreaThisYProfit;

        public string OfficeAutomation_Document_WithdrawShop_AreaThisYProfit
        {
            get { return _OfficeAutomation_Document_WithdrawShop_AreaThisYProfit; }
            set { _OfficeAutomation_Document_WithdrawShop_AreaThisYProfit = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_BranchLastYear;

        public string OfficeAutomation_Document_WithdrawShop_BranchLastYear
        {
            get { return _OfficeAutomation_Document_WithdrawShop_BranchLastYear; }
            set { _OfficeAutomation_Document_WithdrawShop_BranchLastYear = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_BranchLastYResults;

        public string OfficeAutomation_Document_WithdrawShop_BranchLastYResults
        {
            get { return _OfficeAutomation_Document_WithdrawShop_BranchLastYResults; }
            set { _OfficeAutomation_Document_WithdrawShop_BranchLastYResults = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_BranchLastYProfit;

        public string OfficeAutomation_Document_WithdrawShop_BranchLastYProfit
        {
            get { return _OfficeAutomation_Document_WithdrawShop_BranchLastYProfit; }
            set { _OfficeAutomation_Document_WithdrawShop_BranchLastYProfit = value; }
        }


        private DateTime _OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate;

        public DateTime OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate
        {
            get { return _OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate; }
            set { _OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate = value; }
        }

        private DateTime _OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate;

        public DateTime OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate
        {
            get { return _OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate; }
            set { _OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_BranchThisYResults;

        public string OfficeAutomation_Document_WithdrawShop_BranchThisYResults
        {
            get { return _OfficeAutomation_Document_WithdrawShop_BranchThisYResults; }
            set { _OfficeAutomation_Document_WithdrawShop_BranchThisYResults = value; }
        }

        private string _OfficeAutomation_Document_WithdrawShop_BranchThisYProfit;

        public string OfficeAutomation_Document_WithdrawShop_BranchThisYProfit
        {
            get { return _OfficeAutomation_Document_WithdrawShop_BranchThisYProfit; }
            set { _OfficeAutomation_Document_WithdrawShop_BranchThisYProfit = value; }
        }

		#endregion Model

	}
}

