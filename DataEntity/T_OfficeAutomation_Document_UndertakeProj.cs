/*
* T_OfficeAutomation_Document_UndertakeProj.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_UndertakeProj
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/8 11:41:58    张榕     初版
* V0.02  2014/6/19 13:55:58    张榕     增加所属集团字段
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 物业部承接一手项目等报备申请表
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_UndertakeProj
	{
		public T_OfficeAutomation_Document_UndertakeProj()
		{}
		#region Model
		private Guid _officeautomation_document_undertakeproj_id;
		private Guid _officeautomation_document_undertakeproj_mainid;
		private string _officeautomation_document_undertakeproj_apply;
		private string _officeautomation_document_undertakeproj_applyforname;
		private string _officeautomation_document_undertakeproj_applyforcode;
		private string _officeautomation_document_undertakeproj_department;
		private Guid _officeautomation_document_undertakeproj_departmentid;
		private DateTime _officeautomation_document_undertakeproj_applydate;
		private string _officeautomation_document_undertakeproj_replyphone;
		private int _officeautomation_document_undertakeproj_departmenttypeid;
		private string _officeautomation_document_undertakeproj_project;
        private string _officeautomation_document_undertakeproj_developer;
        private string _officeautomation_document_undertakeproj_groupname;
		private int _officeautomation_document_undertakeproj_projectpropertyid;
		private int _officeautomation_document_undertakeproj_dealtypeid;
		private int _officeautomation_document_undertakeproj_agentpropertyid;
		private string _officeautomation_document_undertakeproj_projectarea;
		private string _officeautomation_document_undertakeproj_dealofficetypeids;
		private string _officeautomation_document_undertakeproj_projectaddress;
		private string _officeautomation_document_undertakeproj_developercontacter;
		private string _officeautomation_document_undertakeproj_developercontacterposition;
		private string _officeautomation_document_undertakeproj_developercontacterphone;
		private string _officeautomation_document_undertakeproj_areafollowercontacter;
		private string _officeautomation_document_undertakeproj_areafollowercontacterposition;
		private string _officeautomation_document_undertakeproj_areafollowercontacterphone;
		private string _officeautomation_document_undertakeproj_areacheckdataer;
		private string _officeautomation_document_undertakeproj_areacheckdataercode;
		private string _officeautomation_document_undertakeproj_areacheckdataerphone;
		private string _officeautomation_document_undertakeproj_square;
		private string _officeautomation_document_undertakeproj_setnumber;
		private string _officeautomation_document_undertakeproj_unitprice;
		private string _officeautomation_document_undertakeproj_totalprice;
		private string _officeautomation_document_undertakeproj_ownercommfixscale;
		private string _officeautomation_document_undertakeproj_clientcommfixscale;
		private string _officeautomation_document_undertakeproj_precommtotal;
		private DateTime _officeautomation_document_undertakeproj_agentstartdate;
		private DateTime _officeautomation_document_undertakeproj_agentenddate;
		private DateTime? _officeautomation_document_undertakeproj_clientguardstartdate;
		private DateTime? _officeautomation_document_undertakeproj_clientguardenddate;
		private string _officeautomation_document_undertakeproj_precompletenumber;
		private string _officeautomation_document_undertakeproj_precompletemoney;
		private string _officeautomation_document_undertakeproj_precompletecomm;
		private Int16 _officeautomation_document_undertakeproj_isprojearlycommback;
		private string _officeautomation_document_undertakeproj_owecommsum;
		private DateTime? _officeautomation_document_undertakeproj_areapromisebackdate;
		private int _officeautomation_document_undertakeproj_havesinglereward;
		private bool _officeautomation_document_undertakeproj_isalljumpbar;
		private bool? _officeautomation_document_undertakeproj_ismallsplit;
		private bool? _officeautomation_document_undertakeproj_ismallopen;
		private bool _officeautomation_document_undertakeproj_isexistmortgage;
		private bool _officeautomation_document_undertakeproj_isexistleasebackrules;
		private bool _officeautomation_document_undertakeproj_havepresalelicenses;
		private bool _officeautomation_document_undertakeproj_isuniteagent;
		private bool _officeautomation_document_undertakeproj_iswithpropertyownersigncontract;
		private int _officeautomation_document_undertakeproj_salemodeid;
		private string _officeautomation_document_undertakeproj_mainareascale;
		private string _officeautomation_document_undertakeproj_dealareascale;
        private int _officeautomation_document_undertakeproj_iscoopwithecommerce;
        private string _officeautomation_document_undertakeproj_ecommercename;
        private bool _officeautomation_document_undertakeproj_isneedextension;
		private bool _officeautomation_document_undertakeproj_isneedbroadcast;
		private string _officeautomation_document_undertakeproj_remark;

        private string _officeAutomation_Document_UndertakeProj_TermsOfContract;
        private string _officeAutomation_Document_UndertakeProj_TermsOfMajorIssues;

        private string _officeAutomation_Document_UndertakeProj_AreaScale;

        

		/// <summary>
		/// 主键
		/// </summary>
		public Guid OfficeAutomation_Document_UndertakeProj_ID
		{
			set{ _officeautomation_document_undertakeproj_id=value;}
			get{return _officeautomation_document_undertakeproj_id;}
		}
		/// <summary>
		/// 公文流转主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_UndertakeProj_MainID
		{
			set{ _officeautomation_document_undertakeproj_mainid=value;}
			get{return _officeautomation_document_undertakeproj_mainid;}
		}
		/// <summary>
		/// 填写人
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Apply
		{
			set{ _officeautomation_document_undertakeproj_apply=value;}
			get{return _officeautomation_document_undertakeproj_apply;}
		}
		/// <summary>
		/// 申请人姓名
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_ApplyForName
		{
			set{ _officeautomation_document_undertakeproj_applyforname=value;}
			get{return _officeautomation_document_undertakeproj_applyforname;}
		}
		/// <summary>
		/// 申请人工号
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_ApplyForCode
		{
			set{ _officeautomation_document_undertakeproj_applyforcode=value;}
			get{return _officeautomation_document_undertakeproj_applyforcode;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Department
		{
			set{ _officeautomation_document_undertakeproj_department=value;}
			get{return _officeautomation_document_undertakeproj_department;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public Guid OfficeAutomation_Document_UndertakeProj_DepartmentID
		{
			set{ _officeautomation_document_undertakeproj_departmentid=value;}
			get{return _officeautomation_document_undertakeproj_departmentid;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_UndertakeProj_ApplyDate
		{
			set{ _officeautomation_document_undertakeproj_applydate=value;}
			get{return _officeautomation_document_undertakeproj_applydate;}
		}
		/// <summary>
		/// 回复电话
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_ReplyPhone
		{
			set{ _officeautomation_document_undertakeproj_replyphone=value;}
			get{return _officeautomation_document_undertakeproj_replyphone;}
		}
		/// <summary>
		/// 申请区域ID
		/// </summary>
		public int OfficeAutomation_Document_UndertakeProj_DepartmentTypeID
		{
			set{ _officeautomation_document_undertakeproj_departmenttypeid=value;}
			get{return _officeautomation_document_undertakeproj_departmenttypeid;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Project
		{
			set{ _officeautomation_document_undertakeproj_project=value;}
			get{return _officeautomation_document_undertakeproj_project;}
		}
        /// <summary>
        /// 项目发展商(小业主)
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_Developer
        {
            set { _officeautomation_document_undertakeproj_developer = value; }
            get { return _officeautomation_document_undertakeproj_developer; }
        }
        /// <summary>
        /// 所属集体名称
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_GroupName
        {
            set { _officeautomation_document_undertakeproj_groupname = value; }
            get { return _officeautomation_document_undertakeproj_groupname; }
        }
		/// <summary>
		/// 项目性质ID
		/// </summary>
		public int OfficeAutomation_Document_UndertakeProj_ProjectPropertyID
		{
			set{ _officeautomation_document_undertakeproj_projectpropertyid=value;}
			get{return _officeautomation_document_undertakeproj_projectpropertyid;}
		}
		/// <summary>
		/// 代理类型ID
		/// </summary>
		public int OfficeAutomation_Document_UndertakeProj_DealTypeID
		{
			set{ _officeautomation_document_undertakeproj_dealtypeid=value;}
			get{return _officeautomation_document_undertakeproj_dealtypeid;}
		}
		/// <summary>
		/// 代理性质ID
		/// </summary>
		public int OfficeAutomation_Document_UndertakeProj_AgentPropertyID
		{
			set{ _officeautomation_document_undertakeproj_agentpropertyid=value;}
			get{return _officeautomation_document_undertakeproj_agentpropertyid;}
		}
		/// <summary>
		/// 项目所在区域
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_ProjectArea
		{
			set{ _officeautomation_document_undertakeproj_projectarea=value;}
			get{return _officeautomation_document_undertakeproj_projectarea;}
		}
		/// <summary>
		/// 物业性质ID,多个则以|隔开
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_DealOfficeTypeIDs
		{
			set{ _officeautomation_document_undertakeproj_dealofficetypeids=value;}
			get{return _officeautomation_document_undertakeproj_dealofficetypeids;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_ProjectAddress
		{
			set{ _officeautomation_document_undertakeproj_projectaddress=value;}
			get{return _officeautomation_document_undertakeproj_projectaddress;}
		}
		/// <summary>
		/// 发展商联系人姓名
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_DeveloperContacter
		{
			set{ _officeautomation_document_undertakeproj_developercontacter=value;}
			get{return _officeautomation_document_undertakeproj_developercontacter;}
		}
		/// <summary>
		/// 发展商联系人职位
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_DeveloperContacterPosition
		{
			set{ _officeautomation_document_undertakeproj_developercontacterposition=value;}
			get{return _officeautomation_document_undertakeproj_developercontacterposition;}
		}
		/// <summary>
		/// 发展商联系人电话
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_DeveloperContacterPhone
		{
			set{ _officeautomation_document_undertakeproj_developercontacterphone=value;}
			get{return _officeautomation_document_undertakeproj_developercontacterphone;}
		}
		/// <summary>
		/// 区域跟进联系人
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_AreaFollowerContacter
		{
			set{ _officeautomation_document_undertakeproj_areafollowercontacter=value;}
			get{return _officeautomation_document_undertakeproj_areafollowercontacter;}
		}
		/// <summary>
		/// 区域跟进联系人职位
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPosition
		{
			set{ _officeautomation_document_undertakeproj_areafollowercontacterposition=value;}
			get{return _officeautomation_document_undertakeproj_areafollowercontacterposition;}
		}
		/// <summary>
		/// 区域跟进联系人电话
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_AreaFollowerContacterPhone
		{
			set{ _officeautomation_document_undertakeproj_areafollowercontacterphone=value;}
			get{return _officeautomation_document_undertakeproj_areafollowercontacterphone;}
		}
		/// <summary>
		/// 区域对数人
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_AreaCheckDataer
		{
			set{ _officeautomation_document_undertakeproj_areacheckdataer=value;}
			get{return _officeautomation_document_undertakeproj_areacheckdataer;}
		}
		/// <summary>
		/// 区域对数人工号
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_AreaCheckDataerCode
		{
			set{ _officeautomation_document_undertakeproj_areacheckdataercode=value;}
			get{return _officeautomation_document_undertakeproj_areacheckdataercode;}
		}
		/// <summary>
		/// 区域对数人电话
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_AreaCheckDataerPhone
		{
			set{ _officeautomation_document_undertakeproj_areacheckdataerphone=value;}
			get{return _officeautomation_document_undertakeproj_areacheckdataerphone;}
		}
		/// <summary>
		/// 承接货量平方米
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Square
		{
			set{ _officeautomation_document_undertakeproj_square=value;}
			get{return _officeautomation_document_undertakeproj_square;}
		}
		/// <summary>
		/// 项目情况承接货量套数
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_SetNumber
		{
			set{ _officeautomation_document_undertakeproj_setnumber=value;}
			get{return _officeautomation_document_undertakeproj_setnumber;}
		}
		/// <summary>
		/// 项目情况预计单价
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_UnitPrice
		{
			set{ _officeautomation_document_undertakeproj_unitprice=value;}
			get{return _officeautomation_document_undertakeproj_unitprice;}
		}
		/// <summary>
		/// 项目情况货量总金额
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_TotalPrice
		{
			set{ _officeautomation_document_undertakeproj_totalprice=value;}
			get{return _officeautomation_document_undertakeproj_totalprice;}
		}
		/// <summary>
		/// 业佣固定收佣比例
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_OwnerCommFixScale
		{
			set{ _officeautomation_document_undertakeproj_ownercommfixscale=value;}
			get{return _officeautomation_document_undertakeproj_ownercommfixscale;}
		}
		/// <summary>
		/// 客佣固定收佣比例
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_ClientCommFixScale
		{
			set{ _officeautomation_document_undertakeproj_clientcommfixscale=value;}
			get{return _officeautomation_document_undertakeproj_clientcommfixscale;}
		}
		/// <summary>
		/// 预计佣金收入总额
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_PreCommTotal
		{
			set{ _officeautomation_document_undertakeproj_precommtotal=value;}
			get{return _officeautomation_document_undertakeproj_precommtotal;}
		}
		/// <summary>
		/// 代理期开始日期
		/// </summary>
		public DateTime OfficeAutomation_Document_UndertakeProj_AgentStartDate
		{
			set{ _officeautomation_document_undertakeproj_agentstartdate=value;}
			get{return _officeautomation_document_undertakeproj_agentstartdate;}
		}
		/// <summary>
		/// 代理期结束日期
		/// </summary>
		public DateTime OfficeAutomation_Document_UndertakeProj_AgentEndDate
		{
			set{ _officeautomation_document_undertakeproj_agentenddate=value;}
			get{return _officeautomation_document_undertakeproj_agentenddate;}
		}
		/// <summary>
		/// 客户保护期开始日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_UndertakeProj_ClientGuardStartDate
		{
			set{ _officeautomation_document_undertakeproj_clientguardstartdate=value;}
			get{return _officeautomation_document_undertakeproj_clientguardstartdate;}
		}
		/// <summary>
		/// 客户保护期结束日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_UndertakeProj_ClientGuardEndDate
		{
			set{ _officeautomation_document_undertakeproj_clientguardenddate=value;}
			get{return _officeautomation_document_undertakeproj_clientguardenddate;}
		}
		/// <summary>
		/// 预估代理期内完成货量套数
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_PreCompleteNumber
		{
			set{ _officeautomation_document_undertakeproj_precompletenumber=value;}
			get{return _officeautomation_document_undertakeproj_precompletenumber;}
		}
		/// <summary>
		/// 预估代理期内完成货量金额
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_PreCompleteMoney
		{
			set{ _officeautomation_document_undertakeproj_precompletemoney=value;}
			get{return _officeautomation_document_undertakeproj_precompletemoney;}
		}
		/// <summary>
		/// 预估代理期内完成货量佣金收入
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_PreCompleteComm
		{
			set{ _officeautomation_document_undertakeproj_precompletecomm=value;}
			get{return _officeautomation_document_undertakeproj_precompletecomm;}
		}
		/// <summary>
		/// 项目前期佣金是否已收回
		/// </summary>
		public Int16 OfficeAutomation_Document_UndertakeProj_IsProjEarlyCommBack
		{
			set{ _officeautomation_document_undertakeproj_isprojearlycommback=value;}
			get{return _officeautomation_document_undertakeproj_isprojearlycommback;}
		}
		/// <summary>
		/// 欠佣金额
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_OweCommSum
		{
			set{ _officeautomation_document_undertakeproj_owecommsum=value;}
			get{return _officeautomation_document_undertakeproj_owecommsum;}
		}
		/// <summary>
		/// 区域承诺收回日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_UndertakeProj_AreaPromiseBackDate
		{
			set{ _officeautomation_document_undertakeproj_areapromisebackdate=value;}
			get{return _officeautomation_document_undertakeproj_areapromisebackdate;}
		}
		/// <summary>
		/// 单套现金奖
		/// </summary>
		public int OfficeAutomation_Document_UndertakeProj_HaveSingleReward
		{
			set{ _officeautomation_document_undertakeproj_havesinglereward=value;}
			get{return _officeautomation_document_undertakeproj_havesinglereward;}
		}
		/// <summary>
		/// 佣金是否全跳bar
		/// </summary>
		public bool OfficeAutomation_Document_UndertakeProj_IsAllJumpBar
		{
			set{ _officeautomation_document_undertakeproj_isalljumpbar=value;}
			get{return _officeautomation_document_undertakeproj_isalljumpbar;}
		}
		/// <summary>
		/// 是否属于商场拆细散卖
		/// </summary>
		public bool? OfficeAutomation_Document_UndertakeProj_IsMallSplit
		{
			set{ _officeautomation_document_undertakeproj_ismallsplit=value;}
			get{return _officeautomation_document_undertakeproj_ismallsplit;}
		}
		/// <summary>
		/// 商场是否已在经营
		/// </summary>
		public bool? OfficeAutomation_Document_UndertakeProj_IsMallOpen
		{
			set{ _officeautomation_document_undertakeproj_ismallopen=value;}
			get{return _officeautomation_document_undertakeproj_ismallopen;}
		}
		/// <summary>
		/// 是否存在抵押
		/// </summary>
		public bool OfficeAutomation_Document_UndertakeProj_IsExistMortgage
		{
			set{ _officeautomation_document_undertakeproj_isexistmortgage=value;}
			get{return _officeautomation_document_undertakeproj_isexistmortgage;}
		}
		/// <summary>
		/// 是否存在返租条款
		/// </summary>
		public bool OfficeAutomation_Document_UndertakeProj_IsExistLeasebackRules
		{
			set{ _officeautomation_document_undertakeproj_isexistleasebackrules=value;}
			get{return _officeautomation_document_undertakeproj_isexistleasebackrules;}
		}
		/// <summary>
		/// 是否有预售许可证或房产证
		/// </summary>
		public bool OfficeAutomation_Document_UndertakeProj_HavePreSaleLicenses
		{
			set{ _officeautomation_document_undertakeproj_havepresalelicenses=value;}
			get{return _officeautomation_document_undertakeproj_havepresalelicenses;}
		}
		/// <summary>
		/// 是否与行家联合代理
		/// </summary>
		public bool OfficeAutomation_Document_UndertakeProj_IsUniteAgent
		{
			set{ _officeautomation_document_undertakeproj_isuniteagent=value;}
			get{return _officeautomation_document_undertakeproj_isuniteagent;}
		}
		/// <summary>
		/// 是否与产权人签署合同
		/// </summary>
		public bool OfficeAutomation_Document_UndertakeProj_IsWithPropertyOwnerSignContract
		{
			set{ _officeautomation_document_undertakeproj_iswithpropertyownersigncontract=value;}
			get{return _officeautomation_document_undertakeproj_iswithpropertyownersigncontract;}
		}
		/// <summary>
		/// 销售模式ID
		/// </summary>
		public int OfficeAutomation_Document_UndertakeProj_SaleModeID
		{
			set{ _officeautomation_document_undertakeproj_salemodeid=value;}
			get{return _officeautomation_document_undertakeproj_salemodeid;}
		}
		/// <summary>
		/// 主区拆分成交占比
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_MainAreaScale
		{
			set{ _officeautomation_document_undertakeproj_mainareascale=value;}
			get{return _officeautomation_document_undertakeproj_mainareascale;}
		}
        /// <summary>
        /// 成交区域占比
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_DealAreaScale
        {
            set { _officeautomation_document_undertakeproj_dealareascale = value; }
            get { return _officeautomation_document_undertakeproj_dealareascale; }
        }
        /// <summary>
        /// 是否需要推广项目信息至外区
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_IsNeedExtension
        {
            set { _officeautomation_document_undertakeproj_isneedextension = value; }
            get { return _officeautomation_document_undertakeproj_isneedextension; }
        }
        /// <summary>
        /// 是否与电商合作
        /// </summary>
        public int OfficeAutomation_Document_UndertakeProj_IsCoopWithECommerce
        {
            set { _officeautomation_document_undertakeproj_iscoopwithecommerce = value; }
            get { return _officeautomation_document_undertakeproj_iscoopwithecommerce; }
        }
        /// <summary>
        /// 电商名称
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_ECommerceName
        {
            set { _officeautomation_document_undertakeproj_ecommercename = value; }
            get { return _officeautomation_document_undertakeproj_ecommercename; }
        }
		/// <summary>
		/// 是否需要公司对外宣传项目信息

		/// </summary>
		public bool OfficeAutomation_Document_UndertakeProj_IsNeedBroadcast
		{
			set{ _officeautomation_document_undertakeproj_isneedbroadcast=value;}
			get{return _officeautomation_document_undertakeproj_isneedbroadcast;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Remark
		{
			set{ _officeautomation_document_undertakeproj_remark=value;}
			get{return _officeautomation_document_undertakeproj_remark;}
		}
        /// <summary>
        /// 合同约定的结佣条款
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_TermsOfContract
        {
            get { return _officeAutomation_Document_UndertakeProj_TermsOfContract; }
            set { _officeAutomation_Document_UndertakeProj_TermsOfContract = value; }
        }
        /// <summary>
        /// 重大问题的合同条款
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues
        {
            get { return _officeAutomation_Document_UndertakeProj_TermsOfMajorIssues; }
            set { _officeAutomation_Document_UndertakeProj_TermsOfMajorIssues = value; }
        }
        /// <summary>
        /// 统筹区
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AreaScale
        {
            get { return _officeAutomation_Document_UndertakeProj_AreaScale; }
            set { _officeAutomation_Document_UndertakeProj_AreaScale = value; }
        }


        private string _OfficeAutomation_Document_UndertakeProj_ReportAddress;
        /// <summary>
        /// 报数地址
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_ReportAddress
        {
            get { return _OfficeAutomation_Document_UndertakeProj_ReportAddress; }
            set { _OfficeAutomation_Document_UndertakeProj_ReportAddress = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_EBCooperation;
        /// <summary>
        /// 是否与电商合作
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_EBCooperation
        {
            get { return _OfficeAutomation_Document_UndertakeProj_EBCooperation; }
            set { _OfficeAutomation_Document_UndertakeProj_EBCooperation = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_EBName;
        /// <summary>
        /// 电商公司名称
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_EBName
        {
            get { return _OfficeAutomation_Document_UndertakeProj_EBName; }
            set { _OfficeAutomation_Document_UndertakeProj_EBName = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_ProjectCost;
        /// <summary>
        /// 项目费用
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_ProjectCost
        {
            get { return _OfficeAutomation_Document_UndertakeProj_ProjectCost; }
            set { _OfficeAutomation_Document_UndertakeProj_ProjectCost = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_PCDeveloper;
        /// <summary>
        /// 发展商项目费用
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_PCDeveloper
        {
            get { return _OfficeAutomation_Document_UndertakeProj_PCDeveloper; }
            set { _OfficeAutomation_Document_UndertakeProj_PCDeveloper = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_EBDeveloper;
        /// <summary>
        /// 电商项目费用
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_EBDeveloper
        {
            get { return _OfficeAutomation_Document_UndertakeProj_EBDeveloper; }
            set { _OfficeAutomation_Document_UndertakeProj_EBDeveloper = value; }
        }

        private int _OfficeAutomation_Document_UndertakeProj_CooperationWay;
        /// <summary>
        /// 合作费承担方式
        /// </summary>
        public int OfficeAutomation_Document_UndertakeProj_CooperationWay
        {
            get { return _OfficeAutomation_Document_UndertakeProj_CooperationWay; }
            set { _OfficeAutomation_Document_UndertakeProj_CooperationWay = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_NHComm;
        /// <summary>
        /// 非本区欠佣金额
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_NHComm
        {
            get { return _OfficeAutomation_Document_UndertakeProj_NHComm; }
            set { _OfficeAutomation_Document_UndertakeProj_NHComm = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_NHName;
        /// <summary>
        /// 非本区名
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_NHName
        {
            get { return _OfficeAutomation_Document_UndertakeProj_NHName; }
            set { _OfficeAutomation_Document_UndertakeProj_NHName = value; }
        }

        private DateTime? _OfficeAutomation_Document_UndertakeProj_NHTime;
        /// <summary>
        /// 非本区收回日
        /// </summary>
        public DateTime? OfficeAutomation_Document_UndertakeProj_NHTime
        {
            get { return _OfficeAutomation_Document_UndertakeProj_NHTime; }
            set { _OfficeAutomation_Document_UndertakeProj_NHTime = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_Here;
        /// <summary>
        /// 本区名
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_Here
        {
            get { return _OfficeAutomation_Document_UndertakeProj_Here; }
            set { _OfficeAutomation_Document_UndertakeProj_Here = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_OwnerCommAgent;
        /// <summary>
        /// 业佣公布代理费
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_OwnerCommAgent
        {
            get { return _OfficeAutomation_Document_UndertakeProj_OwnerCommAgent; }
            set { _OfficeAutomation_Document_UndertakeProj_OwnerCommAgent = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_ClientCommAgent;
        /// <summary>
        /// 客佣公布代理费
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_ClientCommAgent
        {
            get { return _OfficeAutomation_Document_UndertakeProj_ClientCommAgent; }
            set { _OfficeAutomation_Document_UndertakeProj_ClientCommAgent = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_EBComm;
        /// <summary>
        /// 电商固定收佣
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_EBComm
        {
            get { return _OfficeAutomation_Document_UndertakeProj_EBComm; }
            set { _OfficeAutomation_Document_UndertakeProj_EBComm = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_EBCommAgent;
        /// <summary>
        /// 电商公布代理费
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_EBCommAgent
        {
            get { return _OfficeAutomation_Document_UndertakeProj_EBCommAgent; }
            set { _OfficeAutomation_Document_UndertakeProj_EBCommAgent = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_LastBeginDate;
        /// <summary>
        /// 上一代理开始期
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_LastBeginDate
        {
            get { return _OfficeAutomation_Document_UndertakeProj_LastBeginDate; }
            set { _OfficeAutomation_Document_UndertakeProj_LastBeginDate = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_LastEndDate;
        /// <summary>
        /// 上一代理结束期
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_LastEndDate
        {
            get { return _OfficeAutomation_Document_UndertakeProj_LastEndDate; }
            set { _OfficeAutomation_Document_UndertakeProj_LastEndDate = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_LastSumNum;
        /// <summary>
        /// 上一代理成效宗数
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_LastSumNum
        {
            get { return _OfficeAutomation_Document_UndertakeProj_LastSumNum; }
            set { _OfficeAutomation_Document_UndertakeProj_LastSumNum = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_LastResults;
        /// <summary>
        /// 上一代理成交业绩
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_LastResults
        {
            get { return _OfficeAutomation_Document_UndertakeProj_LastResults; }
            set { _OfficeAutomation_Document_UndertakeProj_LastResults = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate;
        /// <summary>
        /// 累计成交开始日
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate
        {
            get { return _OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate; }
            set { _OfficeAutomation_Document_UndertakeProj_CumulativeBeginDate = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_CumulativeEndDate;
        /// <summary>
        /// 累计成交结束日
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CumulativeEndDate
        {
            get { return _OfficeAutomation_Document_UndertakeProj_CumulativeEndDate; }
            set { _OfficeAutomation_Document_UndertakeProj_CumulativeEndDate = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_CumulativeNum;
        /// <summary>
        /// 累计成交宗数
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CumulativeNum
        {
            get { return _OfficeAutomation_Document_UndertakeProj_CumulativeNum; }
            set { _OfficeAutomation_Document_UndertakeProj_CumulativeNum = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_CumulativeResults;
        /// <summary>
        /// 累计成交业绩
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CumulativeResults
        {
            get { return _OfficeAutomation_Document_UndertakeProj_CumulativeResults; }
            set { _OfficeAutomation_Document_UndertakeProj_CumulativeResults = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_Turnover;
        /// <summary>
        /// 成交额
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_Turnover
        {
            get { return _OfficeAutomation_Document_UndertakeProj_Turnover; }
            set { _OfficeAutomation_Document_UndertakeProj_Turnover = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_SumTurnover;
        /// <summary>
        /// 总成交额
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_SumTurnover
        {
            get { return _OfficeAutomation_Document_UndertakeProj_SumTurnover; }
            set { _OfficeAutomation_Document_UndertakeProj_SumTurnover = value; }
        }

        private int _OfficeAutomation_Document_UndertakeProj_JOrT;
        /// <summary>
        /// 是否与行家联合代理或轮流代理
        /// </summary>
        public int OfficeAutomation_Document_UndertakeProj_JOrT
        {
            get { return _OfficeAutomation_Document_UndertakeProj_JOrT; }
            set { _OfficeAutomation_Document_UndertakeProj_JOrT = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_SamePlaceXX1;
        /// <summary>
        /// 同场代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_SamePlaceXX1
        {
            get { return _OfficeAutomation_Document_UndertakeProj_SamePlaceXX1; }
            set { _OfficeAutomation_Document_UndertakeProj_SamePlaceXX1 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_SamePlaceXX2;
        /// <summary>
        /// 同场代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_SamePlaceXX2
        {
            get { return _OfficeAutomation_Document_UndertakeProj_SamePlaceXX2; }
            set { _OfficeAutomation_Document_UndertakeProj_SamePlaceXX2 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_SamePlaceXX3;
        /// <summary>
        /// 同场代理的行家名称3
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_SamePlaceXX3
        {
            get { return _OfficeAutomation_Document_UndertakeProj_SamePlaceXX3; }
            set { _OfficeAutomation_Document_UndertakeProj_SamePlaceXX3 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_SamePlaceXX4;
        /// <summary>
        /// 同场代理的行家名称4
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_SamePlaceXX4
        {
            get { return _OfficeAutomation_Document_UndertakeProj_SamePlaceXX4; }
            set { _OfficeAutomation_Document_UndertakeProj_SamePlaceXX4 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1;
        /// <summary>
        /// 轮流代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1
        {
            get { return _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1; }
            set { _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX1 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2;
        /// <summary>
        /// 轮流代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2
        {
            get { return _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2; }
            set { _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX2 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3;
        /// <summary>
        /// 轮流代理的行家名称3
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3
        {
            get { return _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3; }
            set { _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX3 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4;
        /// <summary>
        /// 轮流代理的行家名称4
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4
        {
            get { return _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4; }
            set { _OfficeAutomation_Document_UndertakeProj_TurnsAgentXX4 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AgencyFee1;
        /// <summary>
        /// 同场代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AgencyFee1
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AgencyFee1; }
            set { _OfficeAutomation_Document_UndertakeProj_AgencyFee1 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AgencyFee2;
        /// <summary>
        /// 同场代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AgencyFee2
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AgencyFee2; }
            set { _OfficeAutomation_Document_UndertakeProj_AgencyFee2 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AgencyFee3;
        /// <summary>
        /// 轮流代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AgencyFee3
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AgencyFee3; }
            set { _OfficeAutomation_Document_UndertakeProj_AgencyFee3 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AgencyFee4;
        /// <summary>
        /// 轮流代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AgencyFee4
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AgencyFee4; }
            set { _OfficeAutomation_Document_UndertakeProj_AgencyFee4 = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_IsCashPrize1;
        /// <summary>
        /// 是否有同场代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_IsCashPrize1
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsCashPrize1; }
            set { _OfficeAutomation_Document_UndertakeProj_IsCashPrize1 = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_IsCashPrize2;
        /// <summary>
        /// 是否有同场代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_IsCashPrize2
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsCashPrize2; }
            set { _OfficeAutomation_Document_UndertakeProj_IsCashPrize2 = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_IsCashPrize3;
        /// <summary>
        /// 是否有轮流代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_IsCashPrize3
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsCashPrize3; }
            set { _OfficeAutomation_Document_UndertakeProj_IsCashPrize3 = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_IsCashPrize4;
        /// <summary>
        /// 是否有轮流代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_IsCashPrize4
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsCashPrize4; }
            set { _OfficeAutomation_Document_UndertakeProj_IsCashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_CashPrize1;
        /// <summary>
        /// 同场代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CashPrize1
        {
            get { return _OfficeAutomation_Document_UndertakeProj_CashPrize1; }
            set { _OfficeAutomation_Document_UndertakeProj_CashPrize1 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_CashPrize2;
        /// <summary>
        /// 同场代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CashPrize2
        {
            get { return _OfficeAutomation_Document_UndertakeProj_CashPrize2; }
            set { _OfficeAutomation_Document_UndertakeProj_CashPrize2 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_CashPrize3;
        /// <summary>
        /// 轮流代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CashPrize3
        {
            get { return _OfficeAutomation_Document_UndertakeProj_CashPrize3; }
            set { _OfficeAutomation_Document_UndertakeProj_CashPrize3 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_CashPrize4;
        /// <summary>
        /// 轮流代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_CashPrize4
        {
            get { return _OfficeAutomation_Document_UndertakeProj_CashPrize4; }
            set { _OfficeAutomation_Document_UndertakeProj_CashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1;
        /// <summary>
        /// 轮流代理行家代理开始期1
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1; }
            set { _OfficeAutomation_Document_UndertakeProj_AgencyBeginDate1 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2;
        /// <summary>
        /// 轮流代理行家代理开始期2
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2; }
            set { _OfficeAutomation_Document_UndertakeProj_AgencyBeginDate2 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AgencyEndDate1;
        /// <summary>
        /// 轮流代理行家代理结束期1
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AgencyEndDate1
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AgencyEndDate1; }
            set { _OfficeAutomation_Document_UndertakeProj_AgencyEndDate1 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AgencyEndDate2;
        /// <summary>
        /// 轮流代理行家代理结束期2
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AgencyEndDate2
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AgencyEndDate2; }
            set { _OfficeAutomation_Document_UndertakeProj_AgencyEndDate2 = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_IsPFear1;
        /// <summary>
        /// 是否有项目费用1
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_IsPFear1
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsPFear1; }
            set { _OfficeAutomation_Document_UndertakeProj_IsPFear1 = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_IsPFear2;
        /// <summary>
        /// 是否有项目费用2
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_IsPFear2
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsPFear2; }
            set { _OfficeAutomation_Document_UndertakeProj_IsPFear2 = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_IsPFear3;
        /// <summary>
        /// 是否有项目费用3
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_IsPFear3
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsPFear3; }
            set { _OfficeAutomation_Document_UndertakeProj_IsPFear3 = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_IsPFear4;
        /// <summary>
        /// 是否有项目费用4
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_IsPFear4
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsPFear4; }
            set { _OfficeAutomation_Document_UndertakeProj_IsPFear4 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_PFear1;
        /// <summary>
        /// 项目费用1
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_PFear1
        {
            get { return _OfficeAutomation_Document_UndertakeProj_PFear1; }
            set { _OfficeAutomation_Document_UndertakeProj_PFear1 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_PFear2;
        /// <summary>
        /// 项目费用2
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_PFear2
        {
            get { return _OfficeAutomation_Document_UndertakeProj_PFear2; }
            set { _OfficeAutomation_Document_UndertakeProj_PFear2 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_PFear3;
        /// <summary>
        /// 项目费用3
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_PFear3
        {
            get { return _OfficeAutomation_Document_UndertakeProj_PFear3; }
            set { _OfficeAutomation_Document_UndertakeProj_PFear3 = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_PFear4;
        /// <summary>
        /// 项目费用4
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_PFear4
        {
            get { return _OfficeAutomation_Document_UndertakeProj_PFear4; }
            set { _OfficeAutomation_Document_UndertakeProj_PFear4 = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_SubmitReward;
        /// <summary>
        /// 是否已同时提交奖金报备
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_SubmitReward
        {
            get { return _OfficeAutomation_Document_UndertakeProj_SubmitReward; }
            set { _OfficeAutomation_Document_UndertakeProj_SubmitReward = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_OwnerCommJump;
        /// <summary>
        /// 业佣跳BAR方式
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_OwnerCommJump
        {
            get { return _OfficeAutomation_Document_UndertakeProj_OwnerCommJump; }
            set { _OfficeAutomation_Document_UndertakeProj_OwnerCommJump = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_ClientCommJump;
        /// <summary>
        /// 客佣跳BAR方式
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_ClientCommJump
        {
            get { return _OfficeAutomation_Document_UndertakeProj_ClientCommJump; }
            set { _OfficeAutomation_Document_UndertakeProj_ClientCommJump = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_EBCommJump;
        /// <summary>
        /// 电商佣跳BAR方式
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_EBCommJump
        {
            get { return _OfficeAutomation_Document_UndertakeProj_EBCommJump; }
            set { _OfficeAutomation_Document_UndertakeProj_EBCommJump = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_RewardSignHave;
        /// <summary>
        /// 大于3%的单套现金奖
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_RewardSignHave
        {
            get { return _OfficeAutomation_Document_UndertakeProj_RewardSignHave; }
            set { _OfficeAutomation_Document_UndertakeProj_RewardSignHave = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_RewardSignHavent;
        /// <summary>
        /// 小于3%的单套现金奖
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_RewardSignHavent
        {
            get { return _OfficeAutomation_Document_UndertakeProj_RewardSignHavent; }
            set { _OfficeAutomation_Document_UndertakeProj_RewardSignHavent = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_DeveloperConditions;
        /// <summary>
        /// 发展商支付现金奖条件
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_DeveloperConditions
        {
            get { return _OfficeAutomation_Document_UndertakeProj_DeveloperConditions; }
            set { _OfficeAutomation_Document_UndertakeProj_DeveloperConditions = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AreaConditions;
        /// <summary>
        /// 区域派发现金奖条件
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AreaConditions
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AreaConditions; }
            set { _OfficeAutomation_Document_UndertakeProj_AreaConditions = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_PayRewardWay;
        /// <summary>
        /// 现金奖的发放方式
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_PayRewardWay
        {
            get { return _OfficeAutomation_Document_UndertakeProj_PayRewardWay; }
            set { _OfficeAutomation_Document_UndertakeProj_PayRewardWay = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_ReceiveRewardName;
        /// <summary>
        /// 现金奖接收人姓名
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_ReceiveRewardName
        {
            get { return _OfficeAutomation_Document_UndertakeProj_ReceiveRewardName; }
            set { _OfficeAutomation_Document_UndertakeProj_ReceiveRewardName = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo;
        /// <summary>
        /// 现金奖接收人账号
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo
        {
            get { return _OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo; }
            set { _OfficeAutomation_Document_UndertakeProj_ReceiveRewardNo = value; }
        }

        private int _OfficeAutomation_Document_UndertakeProj_IsMyPay;
        /// <summary>
        /// 现金奖是否需开具发票并由我司支付税费
        /// </summary>
        public int OfficeAutomation_Document_UndertakeProj_IsMyPay
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsMyPay; }
            set { _OfficeAutomation_Document_UndertakeProj_IsMyPay = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_OtherCondtion;
        /// <summary>
        /// 现金奖的其它情况
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_OtherCondtion
        {
            get { return _OfficeAutomation_Document_UndertakeProj_OtherCondtion; }
            set { _OfficeAutomation_Document_UndertakeProj_OtherCondtion = value; }
        }

        private bool _OfficeAutomation_Document_UndertakeProj_AreaComfirn;
        /// <summary>
        /// 区域是否已提交发展商奖金确认书
        /// </summary>
        public bool OfficeAutomation_Document_UndertakeProj_AreaComfirn
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AreaComfirn; }
            set { _OfficeAutomation_Document_UndertakeProj_AreaComfirn = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_ReturnBackDate;
        /// <summary>
        /// 区域承诺交回公司时间
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_ReturnBackDate
        {
            get { return _OfficeAutomation_Document_UndertakeProj_ReturnBackDate; }
            set { _OfficeAutomation_Document_UndertakeProj_ReturnBackDate = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AnotherRewardC;
        /// <summary>
        /// 单套现金奖其他情况
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_AnotherRewardC
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AnotherRewardC; }
            set { _OfficeAutomation_Document_UndertakeProj_AnotherRewardC = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_PCDeduct;
        /// <summary>
        /// 扣除合作费后实收发展商佣点
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_PCDeduct
        {
            get { return _OfficeAutomation_Document_UndertakeProj_PCDeduct; }
            set { _OfficeAutomation_Document_UndertakeProj_PCDeduct = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_EBDeduct;
        /// <summary>
        /// 扣除合作费后实收电商佣点
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_EBDeduct
        {
            get { return _OfficeAutomation_Document_UndertakeProj_EBDeduct; }
            set { _OfficeAutomation_Document_UndertakeProj_EBDeduct = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_BaseAgent;
        /// <summary>
        /// 场内代理
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_BaseAgent
        {
            get { return _OfficeAutomation_Document_UndertakeProj_BaseAgent; }
            set { _OfficeAutomation_Document_UndertakeProj_BaseAgent = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_BaseAgentOther;
        /// <summary>
        /// 其它场内代理
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_BaseAgentOther
        {
            get { return _OfficeAutomation_Document_UndertakeProj_BaseAgentOther; }
            set { _OfficeAutomation_Document_UndertakeProj_BaseAgentOther = value; }
        }

        private bool? _OfficeAutomation_Document_UndertakeProj_IsUploadPlan;

        public bool? OfficeAutomation_Document_UndertakeProj_IsUploadPlan
        {
            get { return _OfficeAutomation_Document_UndertakeProj_IsUploadPlan; }
            set { _OfficeAutomation_Document_UndertakeProj_IsUploadPlan = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_Flange;

        public string OfficeAutomation_Document_UndertakeProj_Flange
        {
            get { return _OfficeAutomation_Document_UndertakeProj_Flange; }
            set { _OfficeAutomation_Document_UndertakeProj_Flange = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_AnotherCompany;

        public string OfficeAutomation_Document_UndertakeProj_AnotherCompany
        {
            get { return _OfficeAutomation_Document_UndertakeProj_AnotherCompany; }
            set { _OfficeAutomation_Document_UndertakeProj_AnotherCompany = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_Referral;

        public string OfficeAutomation_Document_UndertakeProj_Referral
        {
            get { return _OfficeAutomation_Document_UndertakeProj_Referral; }
            set { _OfficeAutomation_Document_UndertakeProj_Referral = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_BreakUp;

        public string OfficeAutomation_Document_UndertakeProj_BreakUp
        {
            get { return _OfficeAutomation_Document_UndertakeProj_BreakUp; }
            set { _OfficeAutomation_Document_UndertakeProj_BreakUp = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_NCommissions;

        public string OfficeAutomation_Document_UndertakeProj_NCommissions
        {
            get { return _OfficeAutomation_Document_UndertakeProj_NCommissions; }
            set { _OfficeAutomation_Document_UndertakeProj_NCommissions = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_HasAtt;

        public string OfficeAutomation_Document_UndertakeProj_HasAtt
        {
            get { return _OfficeAutomation_Document_UndertakeProj_HasAtt; }
            set { _OfficeAutomation_Document_UndertakeProj_HasAtt = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_WillBreakUp;

        public string OfficeAutomation_Document_UndertakeProj_WillBreakUp
        {
            get { return _OfficeAutomation_Document_UndertakeProj_WillBreakUp; }
            set { _OfficeAutomation_Document_UndertakeProj_WillBreakUp = value; }
        }

		#endregion Model
	}
}

