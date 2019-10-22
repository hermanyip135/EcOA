/*
* T_OfficeAutomation_Document_ProjLinkRepoData.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_ProjLinkRepoData
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/6/4 10:00:02    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 项目联动报数申请表
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_ProjLinkRepoData
	{
		public T_OfficeAutomation_Document_ProjLinkRepoData()
		{}
		#region Model
		private Guid _officeautomation_document_projlinkrepodata_id;
		private Guid _officeautomation_document_projlinkrepodata_mainid;
		private string _officeautomation_document_projlinkrepodata_department;
		private DateTime _officeautomation_document_projlinkrepodata_applydate;
		private string _officeautomation_document_projlinkrepodata_apply;
		private string _officeautomation_document_projlinkrepodata_replyphone;
		private string _officeautomation_document_projlinkrepodata_applyid;
		private string _officeautomation_document_projlinkrepodata_projname;
		private bool _officeautomation_document_projlinkrepodata_havepresaleid;
		private string _officeautomation_document_projlinkrepodata_presaleid;
		private string _officeautomation_document_projlinkrepodata_projaddress;
		private string _officeautomation_document_projlinkrepodata_developername;
		private string _officeautomation_document_projlinkrepodata_groupname;
		private string _officeautomation_document_projlinkrepodata_dealofficetypeids;
		private string _officeautomation_document_projlinkrepodata_dealofficeother;
		private string _officeautomation_document_projlinkrepodata_agentstartdate;
		private string _officeautomation_document_projlinkrepodata_agentenddate;
		private string _officeautomation_document_projlinkrepodata_precomm;
		private string _officeautomation_document_projlinkrepodata_goodsquantity;
		private string _officeautomation_document_projlinkrepodata_goodsvalue;
		private string _officeautomation_document_projlinkrepodata_commpoint;
		private int _officeautomation_document_projlinkrepodata_agentmodel;
		private int _officeautomation_document_projlinkrepodata_contracttype;
		private string _officeautomation_document_projlinkrepodata_contracttypeother;
		private bool _officeautomation_document_projlinkrepodata_havecoopcost;
		private bool _officeautomation_document_projlinkrepodata_havecoopconf;
		private bool _officeautomation_document_projlinkrepodata_issignback;
		private string _officeautomation_document_projlinkrepodata_contractpresignbackdate;
		private string _officeautomation_document_projlinkrepodata_remark;
		private string _officeautomation_document_projlinkrepodata_linkstartdate;
		private string _officeautomation_document_projlinkrepodata_linkenddate;
		private string _officeautomation_document_projlinkrepodata_commcalcget;
		private string _officeautomation_document_projlinkrepodata_projdepcount;
		private string _officeautomation_document_projlinkrepodata_projdepprice;
		private string _officeautomation_document_projlinkrepodata_projdepcomm;
		private string _officeautomation_document_projlinkrepodata_propdepcount;
		private string _officeautomation_document_projlinkrepodata_propdepprice;
		private string _officeautomation_document_projlinkrepodata_propdepcomm;
		private int _officeautomation_document_projlinkrepodata_calcgettype;
		private string _officeautomation_document_projlinkrepodata_calcgettypeother;
		private int _officeautomation_document_projlinkrepodata_assumetype;
		private string _officeautomation_document_projlinkrepodata_assumetypeother;
		private string _officeautomation_document_projlinkrepodata_addremark;
		private int _officeautomation_document_projlinkrepodata_projtype;
		private string _officeautomation_document_projlinkrepodata_projdepprecount;
		private string _officeautomation_document_projlinkrepodata_projdepprecomm;
		private string _officeautomation_document_projlinkrepodata_propdeppreinfo;
		private DateTime? _officeautomation_document_projlinkrepodata_dealhistorystartdate;
		private DateTime? _officeautomation_document_projlinkrepodata_dealhistoryenddate;
        private DateTime? _officeautomation_document_projlinkrepodata_totalprofitstartdate;
        private DateTime? _officeautomation_document_projlinkrepodata_totalprofitenddate;
		private string _officeautomation_document_projlinkrepodata_hisindepcount;
		private string _officeautomation_document_projlinkrepodata_hisindepperformance;
		private string _officeautomation_document_projlinkrepodata_hislinkcount;
		private string _officeautomation_document_projlinkrepodata_hislinkperformance;
		private string _officeautomation_document_projlinkrepodata_histotalprofit;
		private string _officeautomation_document_projlinkrepodata_sign;
		/// <summary>
		/// 主键
		/// </summary>
        [CProperty("Key")]
		public Guid OfficeAutomation_Document_ProjLinkRepoData_ID
		{
			set{ _officeautomation_document_projlinkrepodata_id=value;}
			get{return _officeautomation_document_projlinkrepodata_id;}
		}
		/// <summary>
		/// 公文流转主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_ProjLinkRepoData_MainID
		{
			set{ _officeautomation_document_projlinkrepodata_mainid=value;}
			get{return _officeautomation_document_projlinkrepodata_mainid;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_Department
		{
			set{ _officeautomation_document_projlinkrepodata_department=value;}
			get{return _officeautomation_document_projlinkrepodata_department;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ProjLinkRepoData_ApplyDate
		{
			set{ _officeautomation_document_projlinkrepodata_applydate=value;}
			get{return _officeautomation_document_projlinkrepodata_applydate;}
		}
		/// <summary>
		/// 填写人
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_Apply
		{
			set{ _officeautomation_document_projlinkrepodata_apply=value;}
			get{return _officeautomation_document_projlinkrepodata_apply;}
		}
		/// <summary>
		/// 回复电话
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone
		{
			set{ _officeautomation_document_projlinkrepodata_replyphone=value;}
			get{return _officeautomation_document_projlinkrepodata_replyphone;}
		}
		/// <summary>
		/// 发文编号
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ApplyID
		{
			set{ _officeautomation_document_projlinkrepodata_applyid=value;}
			get{return _officeautomation_document_projlinkrepodata_applyid;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ProjName
		{
			set{ _officeautomation_document_projlinkrepodata_projname=value;}
			get{return _officeautomation_document_projlinkrepodata_projname;}
		}
		/// <summary>
		/// 是否有预售证
		/// </summary>
		public bool OfficeAutomation_Document_ProjLinkRepoData_HavePreSaleID
		{
			set{ _officeautomation_document_projlinkrepodata_havepresaleid=value;}
			get{return _officeautomation_document_projlinkrepodata_havepresaleid;}
		}
		/// <summary>
		/// 预售证号
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_PreSaleID
		{
			set{ _officeautomation_document_projlinkrepodata_presaleid=value;}
			get{return _officeautomation_document_projlinkrepodata_presaleid;}
		}
		/// <summary>
		/// 项目地址
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ProjAddress
		{
			set{ _officeautomation_document_projlinkrepodata_projaddress=value;}
			get{return _officeautomation_document_projlinkrepodata_projaddress;}
		}
		/// <summary>
		/// 开发商名称
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_DeveloperName
		{
			set{ _officeautomation_document_projlinkrepodata_developername=value;}
			get{return _officeautomation_document_projlinkrepodata_developername;}
		}
		/// <summary>
		/// 所属集团名称
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_GroupName
		{
			set{ _officeautomation_document_projlinkrepodata_groupname=value;}
			get{return _officeautomation_document_projlinkrepodata_groupname;}
		}
		/// <summary>
		/// 物业性质
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs
		{
			set{ _officeautomation_document_projlinkrepodata_dealofficetypeids=value;}
			get{return _officeautomation_document_projlinkrepodata_dealofficetypeids;}
		}
		/// <summary>
		/// 其他物业性质描述
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_DealOfficeOther
		{
			set{ _officeautomation_document_projlinkrepodata_dealofficeother=value;}
			get{return _officeautomation_document_projlinkrepodata_dealofficeother;}
		}
		/// <summary>
		/// 项目代理开始日期
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate
		{
			set{ _officeautomation_document_projlinkrepodata_agentstartdate=value;}
			get{return _officeautomation_document_projlinkrepodata_agentstartdate;}
		}
		/// <summary>
		/// 项目代理结束日期
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate
		{
			set{ _officeautomation_document_projlinkrepodata_agentenddate=value;}
			get{return _officeautomation_document_projlinkrepodata_agentenddate;}
		}
		/// <summary>
		/// 预计创佣
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_PreComm
		{
			set{ _officeautomation_document_projlinkrepodata_precomm=value;}
			get{return _officeautomation_document_projlinkrepodata_precomm;}
		}
		/// <summary>
		/// 代理期内可售货量
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity
		{
			set{ _officeautomation_document_projlinkrepodata_goodsquantity=value;}
			get{return _officeautomation_document_projlinkrepodata_goodsquantity;}
		}
		/// <summary>
		/// 代理期内可售货值
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_GoodsValue
		{
			set{ _officeautomation_document_projlinkrepodata_goodsvalue=value;}
			get{return _officeautomation_document_projlinkrepodata_goodsvalue;}
		}
		/// <summary>
		/// 申请报数点数
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_CommPoint
		{
			set{ _officeautomation_document_projlinkrepodata_commpoint=value;}
			get{return _officeautomation_document_projlinkrepodata_commpoint;}
		}
		/// <summary>
		/// 代理模式
		/// </summary>
		public int OfficeAutomation_Document_ProjLinkRepoData_AgentModel
		{
			set{ _officeautomation_document_projlinkrepodata_agentmodel=value;}
			get{return _officeautomation_document_projlinkrepodata_agentmodel;}
		}
		/// <summary>
		/// 合同类型
		/// </summary>
		public int OfficeAutomation_Document_ProjLinkRepoData_ContractType
		{
			set{ _officeautomation_document_projlinkrepodata_contracttype=value;}
			get{return _officeautomation_document_projlinkrepodata_contracttype;}
		}
		/// <summary>
		/// 其他合同类型描述
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ContractTypeOther
		{
			set{ _officeautomation_document_projlinkrepodata_contracttypeother=value;}
			get{return _officeautomation_document_projlinkrepodata_contracttypeother;}
		}
		/// <summary>
		/// 是否有合作费
		/// </summary>
		public bool OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost
		{
			set{ _officeautomation_document_projlinkrepodata_havecoopcost=value;}
			get{return _officeautomation_document_projlinkrepodata_havecoopcost;}
		}
		/// <summary>
		/// 是否有合作确认函
		/// </summary>
		public bool OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf
		{
			set{ _officeautomation_document_projlinkrepodata_havecoopconf=value;}
			get{return _officeautomation_document_projlinkrepodata_havecoopconf;}
		}
		/// <summary>
		/// 合同是否签回
		/// </summary>
		public bool OfficeAutomation_Document_ProjLinkRepoData_IsSignBack
		{
			set{ _officeautomation_document_projlinkrepodata_issignback=value;}
			get{return _officeautomation_document_projlinkrepodata_issignback;}
		}
		/// <summary>
		/// 合同预计签回时间
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ContractPreSignBackDate
		{
			set{ _officeautomation_document_projlinkrepodata_contractpresignbackdate=value;}
			get{return _officeautomation_document_projlinkrepodata_contractpresignbackdate;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_Remark
		{
			set{ _officeautomation_document_projlinkrepodata_remark=value;}
			get{return _officeautomation_document_projlinkrepodata_remark;}
		}
		/// <summary>
		/// 联动开始时间
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate
		{
			set{ _officeautomation_document_projlinkrepodata_linkstartdate=value;}
			get{return _officeautomation_document_projlinkrepodata_linkstartdate;}
		}
		/// <summary>
		/// 联动结束时间
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate
		{
			set{ _officeautomation_document_projlinkrepodata_linkenddate=value;}
			get{return _officeautomation_document_projlinkrepodata_linkenddate;}
		}
		/// <summary>
		/// 佣金计提
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet
		{
			set{ _officeautomation_document_projlinkrepodata_commcalcget=value;}
			get{return _officeautomation_document_projlinkrepodata_commcalcget;}
		}
		/// <summary>
		/// 项目部宗数
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount
		{
			set{ _officeautomation_document_projlinkrepodata_projdepcount=value;}
			get{return _officeautomation_document_projlinkrepodata_projdepcount;}
		}
		/// <summary>
		/// 项目部报数成交价
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice
		{
			set{ _officeautomation_document_projlinkrepodata_projdepprice=value;}
			get{return _officeautomation_document_projlinkrepodata_projdepprice;}
		}
		/// <summary>
		/// 项目部应收佣金
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm
		{
			set{ _officeautomation_document_projlinkrepodata_projdepcomm=value;}
			get{return _officeautomation_document_projlinkrepodata_projdepcomm;}
		}
		/// <summary>
		/// 物业部宗数
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_PropDepCount
		{
			set{ _officeautomation_document_projlinkrepodata_propdepcount=value;}
			get{return _officeautomation_document_projlinkrepodata_propdepcount;}
		}
		/// <summary>
		/// 物业部报数成交价
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice
		{
			set{ _officeautomation_document_projlinkrepodata_propdepprice=value;}
			get{return _officeautomation_document_projlinkrepodata_propdepprice;}
		}
		/// <summary>
		/// 物业部应收佣金
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_PropDepComm
		{
			set{ _officeautomation_document_projlinkrepodata_propdepcomm=value;}
			get{return _officeautomation_document_projlinkrepodata_propdepcomm;}
		}
		/// <summary>
		/// 项目合作费计提类型
		/// </summary>
		public int OfficeAutomation_Document_ProjLinkRepoData_CalcGetType
		{
			set{ _officeautomation_document_projlinkrepodata_calcgettype=value;}
			get{return _officeautomation_document_projlinkrepodata_calcgettype;}
		}
		/// <summary>
		/// 其他项目合作费计提类型描述
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_CalcGetTypeOther
		{
			set{ _officeautomation_document_projlinkrepodata_calcgettypeother=value;}
			get{return _officeautomation_document_projlinkrepodata_calcgettypeother;}
		}
		/// <summary>
		/// 项目合作费承担类型
		/// </summary>
		public int OfficeAutomation_Document_ProjLinkRepoData_AssumeType
		{
			set{ _officeautomation_document_projlinkrepodata_assumetype=value;}
			get{return _officeautomation_document_projlinkrepodata_assumetype;}
		}
		/// <summary>
		/// 其他项目合作费承担类型描述
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_AssumeTypeOther
		{
			set{ _officeautomation_document_projlinkrepodata_assumetypeother=value;}
			get{return _officeautomation_document_projlinkrepodata_assumetypeother;}
		}
		/// <summary>
		/// 补充说明
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_AddRemark
		{
			set{ _officeautomation_document_projlinkrepodata_addremark=value;}
			get{return _officeautomation_document_projlinkrepodata_addremark;}
		}
		/// <summary>
		/// 项目类型
		/// </summary>
		public int OfficeAutomation_Document_ProjLinkRepoData_ProjType
		{
			set{ _officeautomation_document_projlinkrepodata_projtype=value;}
			get{return _officeautomation_document_projlinkrepodata_projtype;}
		}
		/// <summary>
		/// 项目部联动预期成交宗数
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreCount
		{
			set{ _officeautomation_document_projlinkrepodata_projdepprecount=value;}
			get{return _officeautomation_document_projlinkrepodata_projdepprecount;}
		}
		/// <summary>
		/// 项目部联动预期成交创佣
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_ProjDepPreComm
		{
			set{ _officeautomation_document_projlinkrepodata_projdepprecomm=value;}
			get{return _officeautomation_document_projlinkrepodata_projdepprecomm;}
		}
		/// <summary>
		/// 物业部联动逾期成交数据
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_PropDepPreInfo
		{
			set{ _officeautomation_document_projlinkrepodata_propdeppreinfo=value;}
			get{return _officeautomation_document_projlinkrepodata_propdeppreinfo;}
		}
		/// <summary>
		/// 历史成交开始日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_ProjLinkRepoData_DealHistoryStartDate
		{
			set{ _officeautomation_document_projlinkrepodata_dealhistorystartdate=value;}
			get{return _officeautomation_document_projlinkrepodata_dealhistorystartdate;}
		}
		/// <summary>
		/// 历史成交结束日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_ProjLinkRepoData_DealHistoryEndDate
		{
			set{ _officeautomation_document_projlinkrepodata_dealhistoryenddate=value;}
			get{return _officeautomation_document_projlinkrepodata_dealhistoryenddate;}
		}
        /// <summary>
        /// 累计利润开始日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_ProjLinkRepoData_TotalProfitStartDate
        {
            set { _officeautomation_document_projlinkrepodata_totalprofitstartdate = value; }
            get { return _officeautomation_document_projlinkrepodata_totalprofitstartdate; }
        }
        /// <summary>
        /// 累计利润结束日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_ProjLinkRepoData_TotalProfitEndDate
        {
            set { _officeautomation_document_projlinkrepodata_totalprofitenddate = value; }
            get { return _officeautomation_document_projlinkrepodata_totalprofitenddate; }
        }
		/// <summary>
		/// 历史独立成交宗数
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_HisIndepCount
		{
			set{ _officeautomation_document_projlinkrepodata_hisindepcount=value;}
			get{return _officeautomation_document_projlinkrepodata_hisindepcount;}
		}
		/// <summary>
		/// 历史独立成交业绩
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_HisIndepPerformance
		{
			set{ _officeautomation_document_projlinkrepodata_hisindepperformance=value;}
			get{return _officeautomation_document_projlinkrepodata_hisindepperformance;}
		}
		/// <summary>
		/// 历史联动成交宗数
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_HisLinkCount
		{
			set{ _officeautomation_document_projlinkrepodata_hislinkcount=value;}
			get{return _officeautomation_document_projlinkrepodata_hislinkcount;}
		}
		/// <summary>
		/// 历史联动成交业绩
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_HisLinkPerformance
		{
			set{ _officeautomation_document_projlinkrepodata_hislinkperformance=value;}
			get{return _officeautomation_document_projlinkrepodata_hislinkperformance;}
		}
		/// <summary>
		/// 历史期间累计税前利润
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_HisTotalProfit
		{
			set{ _officeautomation_document_projlinkrepodata_histotalprofit=value;}
			get{return _officeautomation_document_projlinkrepodata_histotalprofit;}
		}
		/// <summary>
		/// 标记
		/// </summary>
		public string OfficeAutomation_Document_ProjLinkRepoData_Sign
		{
			set{ _officeautomation_document_projlinkrepodata_sign=value;}
			get{return _officeautomation_document_projlinkrepodata_sign;}
		}

        //20141027+
        private int _OfficeAutomation_Document_ProjLinkRepoData_JOrT;
        /// <summary>
        /// 是否与行家联合代理或轮流代理
        /// </summary>
        public int OfficeAutomation_Document_ProjLinkRepoData_JOrT
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_JOrT; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_JOrT = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1;
        /// <summary>
        /// 同场代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX1 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2;
        /// <summary>
        /// 同场代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_SamePlaceXX2 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1;
        /// <summary>
        /// 轮流代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX1 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2;
        /// <summary>
        /// 轮流代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_TurnsAgentXX2 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1;
        /// <summary>
        /// 同场代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee1 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2;
        /// <summary>
        /// 同场代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee2 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3;
        /// <summary>
        /// 轮流代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee3 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4;
        /// <summary>
        /// 轮流代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_AgencyFee4 = value; }
        }

        private bool _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1;
        /// <summary>
        /// 是否有同场代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize1 = value; }
        }

        private bool _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2;
        /// <summary>
        /// 是否有同场代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3;
        /// <summary>
        /// 是否有轮流代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize3 = value; }
        }

        private bool _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4;
        /// <summary>
        /// 是否有轮流代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_IsCashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_CashPrize1;
        /// <summary>
        /// 同场代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_CashPrize1
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_CashPrize1; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_CashPrize1 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_CashPrize2;
        /// <summary>
        /// 同场代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_CashPrize2
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_CashPrize2; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_CashPrize2 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_CashPrize3;
        /// <summary>
        /// 轮流代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_CashPrize3
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_CashPrize3; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_CashPrize3 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_CashPrize4;
        /// <summary>
        /// 轮流代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_CashPrize4
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_CashPrize4; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_CashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1;
        /// <summary>
        /// 轮流代理行家代理开始期1
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate1 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2;
        /// <summary>
        /// 轮流代理行家代理开始期2
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_AgencyBeginDate2 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1;
        /// <summary>
        /// 轮流代理行家代理结束期1
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate1 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2;
        /// <summary>
        /// 轮流代理行家代理结束期2
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_AgencyEndDate2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjLinkRepoData_IsPFear1;
        /// <summary>
        /// 是否有项目费用1
        /// </summary>
        public bool OfficeAutomation_Document_ProjLinkRepoData_IsPFear1
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_IsPFear1; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_IsPFear1 = value; }
        }

        private bool _OfficeAutomation_Document_ProjLinkRepoData_IsPFear2;
        /// <summary>
        /// 是否有项目费用2
        /// </summary>
        public bool OfficeAutomation_Document_ProjLinkRepoData_IsPFear2
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_IsPFear2; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_IsPFear2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjLinkRepoData_IsPFear3;
        /// <summary>
        /// 是否有项目费用3
        /// </summary>
        public bool OfficeAutomation_Document_ProjLinkRepoData_IsPFear3
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_IsPFear3; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_IsPFear3 = value; }
        }

        private bool _OfficeAutomation_Document_ProjLinkRepoData_IsPFear4;
        /// <summary>
        /// 是否有项目费用4
        /// </summary>
        public bool OfficeAutomation_Document_ProjLinkRepoData_IsPFear4
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_IsPFear4; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_IsPFear4 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_PFear1;
        /// <summary>
        /// 项目费用1
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_PFear1
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_PFear1; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_PFear1 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_PFear2;
        /// <summary>
        /// 项目费用2
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_PFear2
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_PFear2; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_PFear2 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_PFear3;
        /// <summary>
        /// 项目费用3
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_PFear3
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_PFear3; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_PFear3 = value; }
        }

        private string _OfficeAutomation_Document_ProjLinkRepoData_PFear4;
        /// <summary>
        /// 项目费用4
        /// </summary>
        public string OfficeAutomation_Document_ProjLinkRepoData_PFear4
        {
            get { return _OfficeAutomation_Document_ProjLinkRepoData_PFear4; }
            set { _OfficeAutomation_Document_ProjLinkRepoData_PFear4 = value; }
        }
        //20141027+

		#endregion Model

	}
}

