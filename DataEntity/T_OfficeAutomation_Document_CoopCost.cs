/*
* T_OfficeAutomation_Document_CoopCost.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_CoopCost
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/3 11:58:00    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 合作费申请表
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_CoopCost
	{
		public T_OfficeAutomation_Document_CoopCost()
		{}
		#region Model
		private Guid _officeautomation_document_coopcost_id;
		private Guid _officeautomation_document_coopcost_mainid;
		private string _officeautomation_document_coopcost_apply;
		private string _officeautomation_document_coopcost_applyforname;
		private string _officeautomation_document_coopcost_applyforcode;
		private string _officeautomation_document_coopcost_department;
		private Guid _officeautomation_document_coopcost_departmentid;
		private DateTime _officeautomation_document_coopcost_applydate;
		private string _officeautomation_document_coopcost_replyphone;
		private int _officeautomation_document_coopcost_departmenttypeid;
		private DateTime _officeautomation_document_coopcost_dealdate;
		private string _officeautomation_document_coopcost_propertyname;
		private string _officeautomation_document_coopcost_reportid;
		private int _officeautomation_document_coopcost_dealtypeid;
		private string _officeautomation_document_coopcost_area;
		private string _officeautomation_document_coopcost_dealprice;
		private string _officeautomation_document_coopcost_ownercomm;
		private string _officeautomation_document_coopcost_ownerscale;
		private string _officeautomation_document_coopcost_clientcomm;
		private string _officeautomation_document_coopcost_clientscale;
		private string _officeautomation_document_coopcost_totalcomm;
		private string _officeautomation_document_coopcost_totalscale;
		private string _officeautomation_document_coopcost_billtypeowner;
		private string _officeautomation_document_coopcost_ownername;
		private bool _officeautomation_document_coopcost_isowner;
		private string _officeautomation_document_coopcost_ownercoopcondition;
		private string _officeautomation_document_coopcost_ownercoopmoney;
		private string _officeautomation_document_coopcost_ownercoopscale;
		private string _officeautomation_document_coopcost_ownercooptotalscale;
		private string _officeautomation_document_coopcost_billtypeclient;
		private string _officeautomation_document_coopcost_clientname;
		private bool _officeautomation_document_coopcost_isclient;
		private string _officeautomation_document_coopcost_clientcoopcondition;
		private string _officeautomation_document_coopcost_clientcoopmoney;
		private string _officeautomation_document_coopcost_clientcoopscale;
		private string _officeautomation_document_coopcost_clientcooptotalscale;
		private string _officeautomation_document_coopcost_coopmoney;
		private string _officeautomation_document_coopcost_cooptotalscale;
		private string _officeautomation_document_coopcost_actualcomm;
		private string _officeautomation_document_coopcost_actualcommscale;
		private string _officeautomation_document_coopcost_remark;
		/// <summary>
		/// 主键
		/// </summary>
        [CProperty("Key")]
		public Guid OfficeAutomation_Document_CoopCost_ID
		{
			set{ _officeautomation_document_coopcost_id=value;}
			get{return _officeautomation_document_coopcost_id;}
		}
		/// <summary>
		/// 公文流转主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_CoopCost_MainID
		{
			set{ _officeautomation_document_coopcost_mainid=value;}
			get{return _officeautomation_document_coopcost_mainid;}
		}
		/// <summary>
		/// 填写人
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_Apply
		{
			set{ _officeautomation_document_coopcost_apply=value;}
			get{return _officeautomation_document_coopcost_apply;}
		}
		/// <summary>
		/// 申请人姓名
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ApplyForName
		{
			set{ _officeautomation_document_coopcost_applyforname=value;}
			get{return _officeautomation_document_coopcost_applyforname;}
		}
		/// <summary>
		/// 申请人工号
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ApplyForCode
		{
			set{ _officeautomation_document_coopcost_applyforcode=value;}
			get{return _officeautomation_document_coopcost_applyforcode;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_Department
		{
			set{ _officeautomation_document_coopcost_department=value;}
			get{return _officeautomation_document_coopcost_department;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public Guid OfficeAutomation_Document_CoopCost_DepartmentID
		{
			set{ _officeautomation_document_coopcost_departmentid=value;}
			get{return _officeautomation_document_coopcost_departmentid;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_CoopCost_ApplyDate
		{
			set{ _officeautomation_document_coopcost_applydate=value;}
			get{return _officeautomation_document_coopcost_applydate;}
		}
		/// <summary>
		/// 回复电话
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ReplyPhone
		{
			set{ _officeautomation_document_coopcost_replyphone=value;}
			get{return _officeautomation_document_coopcost_replyphone;}
		}
		/// <summary>
		/// 部门类别ID
		/// </summary>
		public int OfficeAutomation_Document_CoopCost_DepartmentTypeID
		{
			set{ _officeautomation_document_coopcost_departmenttypeid=value;}
			get{return _officeautomation_document_coopcost_departmenttypeid;}
		}
		/// <summary>
		/// 成交日期
		/// </summary>
		public DateTime OfficeAutomation_Document_CoopCost_DealDate
		{
			set{ _officeautomation_document_coopcost_dealdate=value;}
			get{return _officeautomation_document_coopcost_dealdate;}
		}
		/// <summary>
		/// 物业名称
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_PropertyName
		{
			set{ _officeautomation_document_coopcost_propertyname=value;}
			get{return _officeautomation_document_coopcost_propertyname;}
		}
		/// <summary>
		/// 成交报告编号
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ReportID
		{
			set{ _officeautomation_document_coopcost_reportid=value;}
			get{return _officeautomation_document_coopcost_reportid;}
		}
		/// <summary>
		/// 交易性质ID
		/// </summary>
		public int OfficeAutomation_Document_CoopCost_DealTypeID
		{
			set{ _officeautomation_document_coopcost_dealtypeid=value;}
			get{return _officeautomation_document_coopcost_dealtypeid;}
		}
		/// <summary>
		/// 面积
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_Area
		{
			set{ _officeautomation_document_coopcost_area=value;}
			get{return _officeautomation_document_coopcost_area;}
		}
		/// <summary>
		/// 成交价/月租金
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_DealPrice
		{
			set{ _officeautomation_document_coopcost_dealprice=value;}
			get{return _officeautomation_document_coopcost_dealprice;}
		}
		/// <summary>
		/// 业佣
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_OwnerComm
		{
			set{ _officeautomation_document_coopcost_ownercomm=value;}
			get{return _officeautomation_document_coopcost_ownercomm;}
		}
		/// <summary>
		/// 业佣比例
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_OwnerScale
		{
			set{ _officeautomation_document_coopcost_ownerscale=value;}
			get{return _officeautomation_document_coopcost_ownerscale;}
		}
		/// <summary>
		/// 客佣
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ClientComm
		{
			set{ _officeautomation_document_coopcost_clientcomm=value;}
			get{return _officeautomation_document_coopcost_clientcomm;}
		}
		/// <summary>
		/// 客佣比例
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ClientScale
		{
			set{ _officeautomation_document_coopcost_clientscale=value;}
			get{return _officeautomation_document_coopcost_clientscale;}
		}
		/// <summary>
		/// 总佣金
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_TotalComm
		{
			set{ _officeautomation_document_coopcost_totalcomm=value;}
			get{return _officeautomation_document_coopcost_totalcomm;}
		}
		/// <summary>
		/// 总比例
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_TotalScale
		{
			set{ _officeautomation_document_coopcost_totalscale=value;}
			get{return _officeautomation_document_coopcost_totalscale;}
		}
		/// <summary>
		/// 业主发票抬头类型
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_BillTypeOwner
		{
			set{ _officeautomation_document_coopcost_billtypeowner=value;}
			get{return _officeautomation_document_coopcost_billtypeowner;}
		}
		/// <summary>
		/// 业主发票抬头姓名
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_OwnerName
		{
			set{ _officeautomation_document_coopcost_ownername=value;}
			get{return _officeautomation_document_coopcost_ownername;}
		}
		/// <summary>
		/// 是否业主本人
		/// </summary>
		public bool OfficeAutomation_Document_CoopCost_IsOwner
		{
			set{ _officeautomation_document_coopcost_isowner=value;}
			get{return _officeautomation_document_coopcost_isowner;}
		}
		/// <summary>
		/// 业主合作条件
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_OwnerCoopCondition
		{
			set{ _officeautomation_document_coopcost_ownercoopcondition=value;}
			get{return _officeautomation_document_coopcost_ownercoopcondition;}
		}
		/// <summary>
		/// 业主合作金额
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_OwnerCoopMoney
		{
			set{ _officeautomation_document_coopcost_ownercoopmoney=value;}
			get{return _officeautomation_document_coopcost_ownercoopmoney;}
		}
		/// <summary>
		/// 业主合作费占业佣比例
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_OwnerCoopScale
		{
			set{ _officeautomation_document_coopcost_ownercoopscale=value;}
			get{return _officeautomation_document_coopcost_ownercoopscale;}
		}
		/// <summary>
		/// 业主合作费占总佣金比例
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale
		{
			set{ _officeautomation_document_coopcost_ownercooptotalscale=value;}
			get{return _officeautomation_document_coopcost_ownercooptotalscale;}
		}
		/// <summary>
		/// 买家发票抬头类型
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_BillTypeClient
		{
			set{ _officeautomation_document_coopcost_billtypeclient=value;}
			get{return _officeautomation_document_coopcost_billtypeclient;}
		}
		/// <summary>
		/// 买家发票抬头姓名
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ClientName
		{
			set{ _officeautomation_document_coopcost_clientname=value;}
			get{return _officeautomation_document_coopcost_clientname;}
		}
		/// <summary>
		/// 是否买家本人
		/// </summary>
		public bool OfficeAutomation_Document_CoopCost_IsClient
		{
			set{ _officeautomation_document_coopcost_isclient=value;}
			get{return _officeautomation_document_coopcost_isclient;}
		}
		/// <summary>
		/// 买家合作条件
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ClientCoopCondition
		{
			set{ _officeautomation_document_coopcost_clientcoopcondition=value;}
			get{return _officeautomation_document_coopcost_clientcoopcondition;}
		}
		/// <summary>
		/// 买家合作金额
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ClientCoopMoney
		{
			set{ _officeautomation_document_coopcost_clientcoopmoney=value;}
			get{return _officeautomation_document_coopcost_clientcoopmoney;}
		}
		/// <summary>
		/// 买家合作费占客佣比例
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ClientCoopScale
		{
			set{ _officeautomation_document_coopcost_clientcoopscale=value;}
			get{return _officeautomation_document_coopcost_clientcoopscale;}
		}
		/// <summary>
		/// 买家合作费占总佣金比例
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ClientCoopTotalScale
		{
			set{ _officeautomation_document_coopcost_clientcooptotalscale=value;}
			get{return _officeautomation_document_coopcost_clientcooptotalscale;}
		}
		/// <summary>
		/// 合作金额
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_CoopMoney
		{
			set{ _officeautomation_document_coopcost_coopmoney=value;}
			get{return _officeautomation_document_coopcost_coopmoney;}
		}
		/// <summary>
		/// 合作费占总佣金比例
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_CoopTotalScale
		{
			set{ _officeautomation_document_coopcost_cooptotalscale=value;}
			get{return _officeautomation_document_coopcost_cooptotalscale;}
		}
		/// <summary>
		/// 公司实收佣金金额
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ActualComm
		{
			set{ _officeautomation_document_coopcost_actualcomm=value;}
			get{return _officeautomation_document_coopcost_actualcomm;}
		}
		/// <summary>
		/// 实际收佣比例
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_ActualCommScale
		{
			set{ _officeautomation_document_coopcost_actualcommscale=value;}
			get{return _officeautomation_document_coopcost_actualcommscale;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_CoopCost_Remark
		{
			set{ _officeautomation_document_coopcost_remark=value;}
			get{return _officeautomation_document_coopcost_remark;}
		}
        /// <summary>
        /// 业主合作原因、合作方背景及所起作用
        /// </summary>
        public string OfficeAutomation_Document_CoopCost_OwnerReason { get; set; }
        /// <summary>
        /// 买家合作原因、合作方背景及所起作用
        /// </summary>
        public string OfficeAutomation_Document_CoopCost_ClientReason { get; set; }
        /// <summary>
        /// 物业详细地址及房号
        /// </summary>
        public string OfficeAutomation_Document_CoopCost_AddressDetail { get; set; }
		#endregion Model

	}
}

