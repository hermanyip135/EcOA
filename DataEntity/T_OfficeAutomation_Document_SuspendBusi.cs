/*
* T_OfficeAutomation_Document_SuspendBusi.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_SuspendBusi
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/17 12:15:32    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 暂停营业申请表
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_SuspendBusi
	{
		public T_OfficeAutomation_Document_SuspendBusi()
		{}
		#region Model
		private Guid _officeautomation_document_suspendbusi_id;
		private Guid _officeautomation_document_suspendbusi_mainid;
		private string _officeautomation_document_suspendbusi_apply;
		private string _officeautomation_document_suspendbusi_applyid;
		private DateTime _officeautomation_document_suspendbusi_applydate;
		private string _officeautomation_document_suspendbusi_department;
		private string _officeautomation_document_suspendbusi_replyphone;
		private string _officeautomation_document_suspendbusi_replyfax;
		private int _officeautomation_document_suspendbusi_departmenttypeid;
		private int _officeautomation_document_suspendbusi_majordomoid;
		private string _officeautomation_document_suspendbusi_departmentname;
		private string _officeautomation_document_suspendbusi_departmentaddress;
		private DateTime _officeautomation_document_suspendbusi_expiredate;
		private DateTime _officeautomation_document_suspendbusi_startdate;
		private DateTime _officeautomation_document_suspendbusi_enddate;
		private string _officeautomation_document_suspendbusi_reason;
		private int _officeautomation_document_suspendbusi_leasestateid;
        private string _officeautomation_document_suspendbusi_assethandleids;
		private string _officeautomation_document_suspendbusi_assethandleother;
		private int _officeautomation_document_suspendbusi_phonehandleid;
		private int _officeautomation_document_suspendbusi_insurehandleid;
		private bool _officeautomation_document_suspendbusi_isflyline;
		private string _officeautomation_document_suspendbusi_flylinefrom;
		private string _officeautomation_document_suspendbusi_flylineto;
		private int _officeautomation_document_suspendbusi_rayhandleid;
		private int _officeautomation_document_suspendbusi_adhandleid;
		private int _officeautomation_document_suspendbusi_stationeryhandleid;
        private DateTime _officeautomation_document_suspendbusi_paymentamortizeenddate;
        private string _officeautomation_document_suspendbusi_paymentamortizeremaining;
		private string _officeautomation_document_suspendbusi_remark;
		/// <summary>
		/// 主键
		/// </summary>
		public Guid OfficeAutomation_Document_SuspendBusi_ID
		{
			set{ _officeautomation_document_suspendbusi_id=value;}
			get{return _officeautomation_document_suspendbusi_id;}
		}
		/// <summary>
		/// 公文流转主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_SuspendBusi_MainID
		{
			set{ _officeautomation_document_suspendbusi_mainid=value;}
			get{return _officeautomation_document_suspendbusi_mainid;}
		}
		/// <summary>
		/// 填写人
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_Apply
		{
			set{ _officeautomation_document_suspendbusi_apply=value;}
			get{return _officeautomation_document_suspendbusi_apply;}
		}
		/// <summary>
		/// 发文编号
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_ApplyID
		{
			set{ _officeautomation_document_suspendbusi_applyid=value;}
			get{return _officeautomation_document_suspendbusi_applyid;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_SuspendBusi_ApplyDate
		{
			set{ _officeautomation_document_suspendbusi_applydate=value;}
			get{return _officeautomation_document_suspendbusi_applydate;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_Department
		{
			set{ _officeautomation_document_suspendbusi_department=value;}
			get{return _officeautomation_document_suspendbusi_department;}
		}
		/// <summary>
		/// 回复电话
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_ReplyPhone
		{
			set{ _officeautomation_document_suspendbusi_replyphone=value;}
			get{return _officeautomation_document_suspendbusi_replyphone;}
		}
		/// <summary>
		/// 回复传真
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_ReplyFax
		{
			set{ _officeautomation_document_suspendbusi_replyfax=value;}
			get{return _officeautomation_document_suspendbusi_replyfax;}
		}
		/// <summary>
		/// 部门类型
		/// </summary>
		public int OfficeAutomation_Document_SuspendBusi_DepartmentTypeID
		{
			set{ _officeautomation_document_suspendbusi_departmenttypeid=value;}
			get{return _officeautomation_document_suspendbusi_departmenttypeid;}
		}
		/// <summary>
		/// 总监
		/// </summary>
		public int OfficeAutomation_Document_SuspendBusi_MajordomoID
		{
			set{ _officeautomation_document_suspendbusi_majordomoid=value;}
			get{return _officeautomation_document_suspendbusi_majordomoid;}
		}
		/// <summary>
		/// 操作部门名称
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_DepartmentName
		{
			set{ _officeautomation_document_suspendbusi_departmentname=value;}
			get{return _officeautomation_document_suspendbusi_departmentname;}
		}
		/// <summary>
		/// 操作部门地址
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_DepartmentAddress
		{
			set{ _officeautomation_document_suspendbusi_departmentaddress=value;}
			get{return _officeautomation_document_suspendbusi_departmentaddress;}
		}
		/// <summary>
		/// 租约届满日期
		/// </summary>
		public DateTime OfficeAutomation_Document_SuspendBusi_ExpireDate
		{
			set{ _officeautomation_document_suspendbusi_expiredate=value;}
			get{return _officeautomation_document_suspendbusi_expiredate;}
		}
		/// <summary>
		/// 开始日期
		/// </summary>
		public DateTime OfficeAutomation_Document_SuspendBusi_StartDate
		{
			set{ _officeautomation_document_suspendbusi_startdate=value;}
			get{return _officeautomation_document_suspendbusi_startdate;}
		}
		/// <summary>
		/// 结束日期
		/// </summary>
		public DateTime OfficeAutomation_Document_SuspendBusi_EndDate
		{
			set{ _officeautomation_document_suspendbusi_enddate=value;}
			get{return _officeautomation_document_suspendbusi_enddate;}
		}
		/// <summary>
		/// 原因
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_Reason
		{
			set{ _officeautomation_document_suspendbusi_reason=value;}
			get{return _officeautomation_document_suspendbusi_reason;}
		}
		/// <summary>
		/// 分行租赁状况
		/// </summary>
		public int OfficeAutomation_Document_SuspendBusi_LeaseStateID
		{
			set{ _officeautomation_document_suspendbusi_leasestateid=value;}
			get{return _officeautomation_document_suspendbusi_leasestateid;}
		}
		/// <summary>
		/// 资产处理
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_AssetHandleIDs
		{
			set{ _officeautomation_document_suspendbusi_assethandleids=value;}
			get{return _officeautomation_document_suspendbusi_assethandleids;}
		}
		/// <summary>
		/// 其他资产处理情况
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_AssetHandleOther
		{
			set{ _officeautomation_document_suspendbusi_assethandleother=value;}
			get{return _officeautomation_document_suspendbusi_assethandleother;}
		}
		/// <summary>
		/// 电话处理
		/// </summary>
		public int OfficeAutomation_Document_SuspendBusi_PhoneHandleID
		{
			set{ _officeautomation_document_suspendbusi_phonehandleid=value;}
			get{return _officeautomation_document_suspendbusi_phonehandleid;}
		}
		/// <summary>
		/// 保险处理方式
		/// </summary>
		public int OfficeAutomation_Document_SuspendBusi_InsureHandleID
		{
			set{ _officeautomation_document_suspendbusi_insurehandleid=value;}
			get{return _officeautomation_document_suspendbusi_insurehandleid;}
		}
		/// <summary>
		/// 是否飞线
		/// </summary>
		public bool OfficeAutomation_Document_SuspendBusi_IsFlyLine
		{
			set{ _officeautomation_document_suspendbusi_isflyline=value;}
			get{return _officeautomation_document_suspendbusi_isflyline;}
		}
		/// <summary>
		/// 飞线分行
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_FlyLineFrom
		{
			set{ _officeautomation_document_suspendbusi_flylinefrom=value;}
			get{return _officeautomation_document_suspendbusi_flylinefrom;}
		}
		/// <summary>
		/// 飞线到的分行
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_FlyLineTo
		{
			set{ _officeautomation_document_suspendbusi_flylineto=value;}
			get{return _officeautomation_document_suspendbusi_flylineto;}
		}
		/// <summary>
		/// 光纤处理方式
		/// </summary>
		public int OfficeAutomation_Document_SuspendBusi_RayHandleID
		{
			set{ _officeautomation_document_suspendbusi_rayhandleid=value;}
			get{return _officeautomation_document_suspendbusi_rayhandleid;}
		}
		/// <summary>
		/// AD处理方式
		/// </summary>
		public int OfficeAutomation_Document_SuspendBusi_ADHandleID
		{
			set{ _officeautomation_document_suspendbusi_adhandleid=value;}
			get{return _officeautomation_document_suspendbusi_adhandleid;}
		}
		/// <summary>
		/// 文具处理方式
		/// </summary>
		public int OfficeAutomation_Document_SuspendBusi_StationeryHandleID
		{
			set{ _officeautomation_document_suspendbusi_stationeryhandleid=value;}
			get{return _officeautomation_document_suspendbusi_stationeryhandleid;}
		}

        /// <summary>
        /// 工程款摊销结束日
        /// </summary>
        public DateTime OfficeAutomation_Document_SuspendBusi_PaymentAmortizeEndDate
        {
            set { _officeautomation_document_suspendbusi_paymentamortizeenddate = value; }
            get { return _officeautomation_document_suspendbusi_paymentamortizeenddate; }
        }

        /// <summary>
        /// 工程款摊销余额
        /// </summary>
        public string OfficeAutomation_Document_SuspendBusi_PaymentAmortizeRemaining
        {
            set { _officeautomation_document_suspendbusi_paymentamortizeremaining = value; }
            get { return _officeautomation_document_suspendbusi_paymentamortizeremaining; }
        }

		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_SuspendBusi_Remark
		{
			set{ _officeautomation_document_suspendbusi_remark=value;}
			get{return _officeautomation_document_suspendbusi_remark;}
		}

        private string _OfficeAutomation_Document_SuspendBusi_Rent;

        public string OfficeAutomation_Document_SuspendBusi_Rent
        {
            get { return _OfficeAutomation_Document_SuspendBusi_Rent; }
            set { _OfficeAutomation_Document_SuspendBusi_Rent = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate;

        public string OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate
        {
            get { return _OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate; }
            set { _OfficeAutomation_Document_SuspendBusi_SuspensionBeginDate = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_SuspensionEndDate;

        public string OfficeAutomation_Document_SuspendBusi_SuspensionEndDate
        {
            get { return _OfficeAutomation_Document_SuspendBusi_SuspensionEndDate; }
            set { _OfficeAutomation_Document_SuspendBusi_SuspensionEndDate = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_SuspensionMonth;

        public string OfficeAutomation_Document_SuspendBusi_SuspensionMonth
        {
            get { return _OfficeAutomation_Document_SuspendBusi_SuspensionMonth; }
            set { _OfficeAutomation_Document_SuspendBusi_SuspensionMonth = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_SEMonth;

        public string OfficeAutomation_Document_SuspendBusi_SEMonth
        {
            get { return _OfficeAutomation_Document_SuspendBusi_SEMonth; }
            set { _OfficeAutomation_Document_SuspendBusi_SEMonth = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_Default;

        public string OfficeAutomation_Document_SuspendBusi_Default
        {
            get { return _OfficeAutomation_Document_SuspendBusi_Default; }
            set { _OfficeAutomation_Document_SuspendBusi_Default = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_Deposit;

        public string OfficeAutomation_Document_SuspendBusi_Deposit
        {
            get { return _OfficeAutomation_Document_SuspendBusi_Deposit; }
            set { _OfficeAutomation_Document_SuspendBusi_Deposit = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_MoneyD1;

        public string OfficeAutomation_Document_SuspendBusi_MoneyD1
        {
            get { return _OfficeAutomation_Document_SuspendBusi_MoneyD1; }
            set { _OfficeAutomation_Document_SuspendBusi_MoneyD1 = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_Aeposit;

        public string OfficeAutomation_Document_SuspendBusi_Aeposit
        {
            get { return _OfficeAutomation_Document_SuspendBusi_Aeposit; }
            set { _OfficeAutomation_Document_SuspendBusi_Aeposit = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_MoneyD2;

        public string OfficeAutomation_Document_SuspendBusi_MoneyD2
        {
            get { return _OfficeAutomation_Document_SuspendBusi_MoneyD2; }
            set { _OfficeAutomation_Document_SuspendBusi_MoneyD2 = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_IsD;

        public string OfficeAutomation_Document_SuspendBusi_IsD
        {
            get { return _OfficeAutomation_Document_SuspendBusi_IsD; }
            set { _OfficeAutomation_Document_SuspendBusi_IsD = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_MoneyD3;

        public string OfficeAutomation_Document_SuspendBusi_MoneyD3
        {
            get { return _OfficeAutomation_Document_SuspendBusi_MoneyD3; }
            set { _OfficeAutomation_Document_SuspendBusi_MoneyD3 = value; }
        }

        private string _OfficeAutomation_Document_SuspendBusi_ExpireEndDate;

        public string OfficeAutomation_Document_SuspendBusi_ExpireEndDate
        {
            get { return _OfficeAutomation_Document_SuspendBusi_ExpireEndDate; }
            set { _OfficeAutomation_Document_SuspendBusi_ExpireEndDate = value; }
        }


		#endregion Model

	}
}

