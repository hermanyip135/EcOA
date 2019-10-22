/*
* T_OfficeAutomation_Document_UndertakeProj_Detail.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_UndertakeProj_Detail
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/8 11:41:58    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 物业部承接一手项目等报备申请表明细
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_UndertakeProj_Detail
	{
		public T_OfficeAutomation_Document_UndertakeProj_Detail()
		{}
		#region Model
		private Guid _officeautomation_document_undertakeproj_detail_id;
		private Guid _officeautomation_document_undertakeproj_detail_mainid;
		private int _officeautomation_document_undertakeproj_detail_commtype;
		private string _officeautomation_document_undertakeproj_detail_setnumberstart;
		private string _officeautomation_document_undertakeproj_detail_setnumberend;
		private string _officeautomation_document_undertakeproj_detail_moneystart;
		private string _officeautomation_document_undertakeproj_detail_moneyend;
		private string _officeautomation_document_undertakeproj_detail_scale;
		private int _officeautomation_document_undertakeproj_detail_orderby;
		/// <summary>
		/// 主键
		/// </summary>
		public Guid OfficeAutomation_Document_UndertakeProj_Detail_ID
		{
			set{ _officeautomation_document_undertakeproj_detail_id=value;}
			get{return _officeautomation_document_undertakeproj_detail_id;}
		}
		/// <summary>
		/// 申请表主键
		/// </summary>
		public Guid OfficeAutomation_Document_UndertakeProj_Detail_MainID
		{
			set{ _officeautomation_document_undertakeproj_detail_mainid=value;}
			get{return _officeautomation_document_undertakeproj_detail_mainid;}
		}
		/// <summary>
		/// 佣金类型
		/// </summary>
		public int OfficeAutomation_Document_UndertakeProj_Detail_CommType
		{
			set{ _officeautomation_document_undertakeproj_detail_commtype=value;}
			get{return _officeautomation_document_undertakeproj_detail_commtype;}
		}
		/// <summary>
		/// 套数上限
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Detail_SetNumberStart
		{
			set{ _officeautomation_document_undertakeproj_detail_setnumberstart=value;}
			get{return _officeautomation_document_undertakeproj_detail_setnumberstart;}
		}
		/// <summary>
		/// 套数下限
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Detail_SetNumberEnd
		{
			set{ _officeautomation_document_undertakeproj_detail_setnumberend=value;}
			get{return _officeautomation_document_undertakeproj_detail_setnumberend;}
		}
		/// <summary>
		/// 金额上限
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Detail_MoneyStart
		{
			set{ _officeautomation_document_undertakeproj_detail_moneystart=value;}
			get{return _officeautomation_document_undertakeproj_detail_moneystart;}
		}
		/// <summary>
		/// 金额下限
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Detail_MoneyEnd
		{
			set{ _officeautomation_document_undertakeproj_detail_moneyend=value;}
			get{return _officeautomation_document_undertakeproj_detail_moneyend;}
		}
		/// <summary>
        /// 合同代理费
		/// </summary>
		public string OfficeAutomation_Document_UndertakeProj_Detail_Scale
		{
			set{ _officeautomation_document_undertakeproj_detail_scale=value;}
			get{return _officeautomation_document_undertakeproj_detail_scale;}
		}
		/// <summary>
		/// 序号
		/// </summary>
		public int OfficeAutomation_Document_UndertakeProj_Detail_OrderBy
		{
			set{ _officeautomation_document_undertakeproj_detail_orderby=value;}
			get{return _officeautomation_document_undertakeproj_detail_orderby;}
		}

        private string _OfficeAutomation_Document_UndertakeProj_Detail_PublishedScale;
        /// <summary>
        /// 公布代理费
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_Detail_PublishedScale
        {
            get { return _OfficeAutomation_Document_UndertakeProj_Detail_PublishedScale; }
            set { _OfficeAutomation_Document_UndertakeProj_Detail_PublishedScale = value; }
        }

        private string _OfficeAutomation_Document_UndertakeProj_Detail_OwnerCommFloatKind;
        /// <summary>
        /// 合同代理费类型
        /// </summary>
        public string OfficeAutomation_Document_UndertakeProj_Detail_OwnerCommFloatKind
        {
            get { return _OfficeAutomation_Document_UndertakeProj_Detail_OwnerCommFloatKind; }
            set { _OfficeAutomation_Document_UndertakeProj_Detail_OwnerCommFloatKind = value; }
        }

		#endregion Model

	}
}

