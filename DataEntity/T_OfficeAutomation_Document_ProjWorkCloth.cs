/*
* T_OfficeAutomation_Document_ProjWorkCloth.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_ProjWorkCloth
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/16 15:54:53    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 项目工衣申请表
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_ProjWorkCloth
	{
		public T_OfficeAutomation_Document_ProjWorkCloth()
		{}
		#region Model
		private Guid _officeautomation_document_projworkcloth_id;
		private Guid _officeautomation_document_projworkcloth_mainid;
		private string _officeautomation_document_projworkcloth_department;
		private DateTime _officeautomation_document_projworkcloth_applydate;
		private string _officeautomation_document_projworkcloth_apply;
		private string _officeautomation_document_projworkcloth_replyphone;
		private string _officeautomation_document_projworkcloth_applyid;
		private string _officeautomation_document_projworkcloth_projname;
		private string _officeautomation_document_projworkcloth_developername;
		private string _officeautomation_document_projworkcloth_projaddress;
        private string _officeautomation_document_projworkcloth_agentstart;
        private string _officeautomation_document_projworkcloth_agentend;
		private string _officeautomation_document_projworkcloth_saledate;
		private string _officeautomation_document_projworkcloth_dealofficetypeids;
		private string _officeautomation_document_projworkcloth_dealofficeother;
		private string _officeautomation_document_projworkcloth_goodsquantity;
		private string _officeautomation_document_projworkcloth_goodsvalue;
		private string _officeautomation_document_projworkcloth_precomm;
		private int _officeautomation_document_projworkcloth_agentmodel;
		private string _officeautomation_document_projworkcloth_commpoint;
		private string _officeautomation_document_projworkcloth_womannum;
		private string _officeautomation_document_projworkcloth_womanparts;
		private string _officeautomation_document_projworkcloth_womanunitprice;
		private string _officeautomation_document_projworkcloth_womansumprice;
		private string _officeautomation_document_projworkcloth_mannum;
		private string _officeautomation_document_projworkcloth_manparts;
		private string _officeautomation_document_projworkcloth_manunitprice;
		private string _officeautomation_document_projworkcloth_mansumprice;
		private string _officeautomation_document_projworkcloth_sumprice;
		private string _officeautomation_document_projworkcloth_remark;
        private string _officeautomation_document_projworkcloth_instruction;
		private string _officeautomation_document_projworkcloth_sign;
		/// <summary>
		/// 主键
		/// </summary>
		public Guid OfficeAutomation_Document_ProjWorkCloth_ID
		{
			set{ _officeautomation_document_projworkcloth_id=value;}
			get{return _officeautomation_document_projworkcloth_id;}
		}
		/// <summary>
		/// 公文流转主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_ProjWorkCloth_MainID
		{
			set{ _officeautomation_document_projworkcloth_mainid=value;}
			get{return _officeautomation_document_projworkcloth_mainid;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_Department
		{
			set{ _officeautomation_document_projworkcloth_department=value;}
			get{return _officeautomation_document_projworkcloth_department;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ProjWorkCloth_ApplyDate
		{
			set{ _officeautomation_document_projworkcloth_applydate=value;}
			get{return _officeautomation_document_projworkcloth_applydate;}
		}
		/// <summary>
		/// 填写人
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_Apply
		{
			set{ _officeautomation_document_projworkcloth_apply=value;}
			get{return _officeautomation_document_projworkcloth_apply;}
		}
		/// <summary>
		/// 回复电话
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_ReplyPhone
		{
			set{ _officeautomation_document_projworkcloth_replyphone=value;}
			get{return _officeautomation_document_projworkcloth_replyphone;}
		}
		/// <summary>
		/// 发文编号
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_ApplyID
		{
			set{ _officeautomation_document_projworkcloth_applyid=value;}
			get{return _officeautomation_document_projworkcloth_applyid;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_ProjName
		{
			set{ _officeautomation_document_projworkcloth_projname=value;}
			get{return _officeautomation_document_projworkcloth_projname;}
		}
		/// <summary>
		/// 开发商名称
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_DeveloperName
		{
			set{ _officeautomation_document_projworkcloth_developername=value;}
			get{return _officeautomation_document_projworkcloth_developername;}
		}
		/// <summary>
		/// 项目地址
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_ProjAddress
		{
			set{ _officeautomation_document_projworkcloth_projaddress=value;}
			get{return _officeautomation_document_projworkcloth_projaddress;}
		}
		/// <summary>
		/// 项目代理开始日期
		/// </summary>
        public string OfficeAutomation_Document_ProjWorkCloth_AgentStart
		{
			set{ _officeautomation_document_projworkcloth_agentstart=value;}
			get{return _officeautomation_document_projworkcloth_agentstart;}
		}
		/// <summary>
		/// 项目代理结束日期
		/// </summary>
        public string OfficeAutomation_Document_ProjWorkCloth_AgentEnd
		{
			set{ _officeautomation_document_projworkcloth_agentend=value;}
			get{return _officeautomation_document_projworkcloth_agentend;}
		}
		/// <summary>
		/// 开售日
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_SaleDate
		{
			set{ _officeautomation_document_projworkcloth_saledate=value;}
			get{return _officeautomation_document_projworkcloth_saledate;}
		}
		/// <summary>
		/// 物业性质
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs
		{
			set{ _officeautomation_document_projworkcloth_dealofficetypeids=value;}
			get{return _officeautomation_document_projworkcloth_dealofficetypeids;}
		}
		/// <summary>
		/// 其他物业性质描述
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther
		{
			set{ _officeautomation_document_projworkcloth_dealofficeother=value;}
			get{return _officeautomation_document_projworkcloth_dealofficeother;}
		}
		/// <summary>
		/// 货量
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity
		{
			set{ _officeautomation_document_projworkcloth_goodsquantity=value;}
			get{return _officeautomation_document_projworkcloth_goodsquantity;}
		}
		/// <summary>
		/// 货值
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_GoodsValue
		{
			set{ _officeautomation_document_projworkcloth_goodsvalue=value;}
			get{return _officeautomation_document_projworkcloth_goodsvalue;}
		}
		/// <summary>
		/// 预计创佣
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_PreComm
		{
			set{ _officeautomation_document_projworkcloth_precomm=value;}
			get{return _officeautomation_document_projworkcloth_precomm;}
		}
		/// <summary>
		/// 代理模式
		/// </summary>
		public int OfficeAutomation_Document_ProjWorkCloth_AgentModel
		{
			set{ _officeautomation_document_projworkcloth_agentmodel=value;}
			get{return _officeautomation_document_projworkcloth_agentmodel;}
		}
		/// <summary>
		/// 佣金点数
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_CommPoint
		{
			set{ _officeautomation_document_projworkcloth_commpoint=value;}
			get{return _officeautomation_document_projworkcloth_commpoint;}
		}
		/// <summary>
		/// 女装数量
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_WomanNum
		{
			set{ _officeautomation_document_projworkcloth_womannum=value;}
			get{return _officeautomation_document_projworkcloth_womannum;}
		}
		/// <summary>
		/// 女装工衣配件
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_WomanParts
		{
			set{ _officeautomation_document_projworkcloth_womanparts=value;}
			get{return _officeautomation_document_projworkcloth_womanparts;}
		}
		/// <summary>
		/// 女装单价
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice
		{
			set{ _officeautomation_document_projworkcloth_womanunitprice=value;}
			get{return _officeautomation_document_projworkcloth_womanunitprice;}
		}
		/// <summary>
		/// 女装小计
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice
		{
			set{ _officeautomation_document_projworkcloth_womansumprice=value;}
			get{return _officeautomation_document_projworkcloth_womansumprice;}
		}
		/// <summary>
		/// 男装数量
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_ManNum
		{
			set{ _officeautomation_document_projworkcloth_mannum=value;}
			get{return _officeautomation_document_projworkcloth_mannum;}
		}
		/// <summary>
		/// 男装工衣配件
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_ManParts
		{
			set{ _officeautomation_document_projworkcloth_manparts=value;}
			get{return _officeautomation_document_projworkcloth_manparts;}
		}
		/// <summary>
		/// 男装单价
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice
		{
			set{ _officeautomation_document_projworkcloth_manunitprice=value;}
			get{return _officeautomation_document_projworkcloth_manunitprice;}
		}
		/// <summary>
		/// 男装小计
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_ManSumPrice
		{
			set{ _officeautomation_document_projworkcloth_mansumprice=value;}
			get{return _officeautomation_document_projworkcloth_mansumprice;}
		}
		/// <summary>
		/// 总计
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_SumPrice
		{
			set{ _officeautomation_document_projworkcloth_sumprice=value;}
			get{return _officeautomation_document_projworkcloth_sumprice;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_Remark
		{
			set{ _officeautomation_document_projworkcloth_remark=value;}
			get{return _officeautomation_document_projworkcloth_remark;}
		}
        /// <summary>
        /// 说明栏
        /// </summary>
        public string Officeautomation_Document_Projworkcloth_Instruction
        {
            get { return _officeautomation_document_projworkcloth_instruction; }
            set { _officeautomation_document_projworkcloth_instruction = value; }
        }
		/// <summary>
		/// 标记
		/// </summary>
		public string OfficeAutomation_Document_ProjWorkCloth_Sign
		{
			set{ _officeautomation_document_projworkcloth_sign=value;}
			get{return _officeautomation_document_projworkcloth_sign;}
		}
		#endregion Model

	}
}

