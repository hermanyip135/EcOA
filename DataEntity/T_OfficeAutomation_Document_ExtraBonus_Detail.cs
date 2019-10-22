/*
* T_OfficeAutomation_Document_ExtraBonus_Detail.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_ExtraBonus_Detail
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/10 16:25:41    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 项目发展商额外奖金报备明细
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_ExtraBonus_Detail
	{
		public T_OfficeAutomation_Document_ExtraBonus_Detail()
		{}
		#region Model
		private Guid _officeautomation_document_extrabonus_detail_id;
		private Guid _officeautomation_document_extrabonus_detail_mainid;
		private string _officeautomation_document_extrabonus_detail_setnumber;
		private string _officeautomation_document_extrabonus_detail_pricerange;
		private string _officeautomation_document_extrabonus_detail_unitprice;
		private string _officeautomation_document_extrabonus_detail_actualcomm;
		private string _officeautomation_document_extrabonus_detail_rewardscale;
		private string _officeautomation_document_extrabonus_detail_payperset;
		private string _officeautomation_document_extrabonus_detail_payactualscale;
		private int _officeautomation_document_extrabonus_detail_orderby;
		/// <summary>
		/// 主键
		/// </summary>
		public Guid OfficeAutomation_Document_ExtraBonus_Detail_ID
		{
			set{ _officeautomation_document_extrabonus_detail_id=value;}
			get{return _officeautomation_document_extrabonus_detail_id;}
		}
		/// <summary>
		/// 申请表主键
		/// </summary>
		public Guid OfficeAutomation_Document_ExtraBonus_Detail_MainID
		{
			set{ _officeautomation_document_extrabonus_detail_mainid=value;}
			get{return _officeautomation_document_extrabonus_detail_mainid;}
		}
		/// <summary>
		/// 货量（套）
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Detail_SetNumber
		{
			set{ _officeautomation_document_extrabonus_detail_setnumber=value;}
			get{return _officeautomation_document_extrabonus_detail_setnumber;}
		}
		/// <summary>
		/// 价格区间（万元）
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Detail_PriceRange
		{
			set{ _officeautomation_document_extrabonus_detail_pricerange=value;}
			get{return _officeautomation_document_extrabonus_detail_pricerange;}
		}
		/// <summary>
		/// 单套均价（万元）
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice
		{
			set{ _officeautomation_document_extrabonus_detail_unitprice=value;}
			get{return _officeautomation_document_extrabonus_detail_unitprice;}
		}
		/// <summary>
		/// 公司实收佣（元）
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Detail_ActualComm
		{
			set{ _officeautomation_document_extrabonus_detail_actualcomm=value;}
			get{return _officeautomation_document_extrabonus_detail_actualcomm;}
		}
		/// <summary>
		/// 奖金比例（%）
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Detail_RewardScale
		{
			set{ _officeautomation_document_extrabonus_detail_rewardscale=value;}
			get{return _officeautomation_document_extrabonus_detail_rewardscale;}
		}
		/// <summary>
		/// 可发放奖金金额（元/套）
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet
		{
			set{ _officeautomation_document_extrabonus_detail_payperset=value;}
			get{return _officeautomation_document_extrabonus_detail_payperset;}
		}
		/// <summary>
		/// 奖金实际发放比例
		/// </summary>
		public string OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale
		{
			set{ _officeautomation_document_extrabonus_detail_payactualscale=value;}
			get{return _officeautomation_document_extrabonus_detail_payactualscale;}
		}
		/// <summary>
		/// 序号
		/// </summary>
		public int OfficeAutomation_Document_ExtraBonus_Detail_OrderBy
		{
			set{ _officeautomation_document_extrabonus_detail_orderby=value;}
			get{return _officeautomation_document_extrabonus_detail_orderby;}
		}
		#endregion Model

	}
}

