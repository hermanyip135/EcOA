/*
* T_OfficeAutomation_Document_ProjDormSubsiby.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_ProjDormSubsiby
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/19 14:20:51    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 项目宿舍及津贴费用申请表
	/// </summary>
	[Serializable]
	public partial class T_OfficeAutomation_Document_ProjDormSubsiby
	{
		public T_OfficeAutomation_Document_ProjDormSubsiby()
		{}
		#region Model
		private Guid _officeautomation_document_projdormsubsiby_id;
		private Guid _officeautomation_document_projdormsubsiby_mainid;
		private string _officeautomation_document_projdormsubsiby_department;
		private DateTime _officeautomation_document_projdormsubsiby_applydate;
		private string _officeautomation_document_projdormsubsiby_apply;
		private string _officeautomation_document_projdormsubsiby_replyphone;
		private string _officeautomation_document_projdormsubsiby_applyid;
		private string _officeautomation_document_projdormsubsiby_projname;
		private string _officeautomation_document_projdormsubsiby_developername;
		private string _officeautomation_document_projdormsubsiby_projaddress;
        private string _officeautomation_document_projdormsubsiby_agentstartdate;
        private string _officeautomation_document_projdormsubsiby_agentenddate;
		private string _officeautomation_document_projdormsubsiby_saledate;
		private string _officeautomation_document_projdormsubsiby_dealofficetypeids;
		private string _officeautomation_document_projdormsubsiby_dealofficeother;
		private string _officeautomation_document_projdormsubsiby_goodsquantity;
		private string _officeautomation_document_projdormsubsiby_goodsvalue;
		private string _officeautomation_document_projdormsubsiby_precomm;
		private int _officeautomation_document_projdormsubsiby_agentmodel;
		private string _officeautomation_document_projdormsubsiby_commpoint;
		private DateTime? _officeautomation_document_projdormsubsiby_rentstartdate;
		private DateTime? _officeautomation_document_projdormsubsiby_rentenddate;
		private int? _officeautomation_document_projdormsubsiby_renttype;
		private string _officeautomation_document_projdormsubsiby_livenumber;
		private string _officeautomation_document_projdormsubsiby_dormaddress;
		private string _officeautomation_document_projdormsubsiby_dormarea;
		private string _officeautomation_document_projdormsubsiby_dormtype;
		private string _officeautomation_document_projdormsubsiby_monthlyrent;
		private string _officeautomation_document_projdormsubsiby_deposit;
		private string _officeautomation_document_projdormsubsiby_agencyfee;
		private string _officeautomation_document_projdormsubsiby_monthlyestimatedcost;
		private string _officeautomation_document_projdormsubsiby_managermentcost;
		private string _officeautomation_document_projdormsubsiby_electriccharge;
		private string _officeautomation_document_projdormsubsiby_watercharge;
		private string _officeautomation_document_projdormsubsiby_gascharge;
		private string _officeautomation_document_projdormsubsiby_monthlycost;
		private string _officeautomation_document_projdormsubsiby_dormremark;
		private string _officeautomation_document_projdormsubsiby_startplace;
		private string _officeautomation_document_projdormsubsiby_endplace;
		private string _officeautomation_document_projdormsubsiby_roundtripmoney;
		private string _officeautomation_document_projdormsubsiby_numberoftimes;
		private string _officeautomation_document_projdormsubsiby_sumofmoney;
		private DateTime? _officeautomation_document_projdormsubsiby_subsibyvaliditystartdate;
		private DateTime? _officeautomation_document_projdormsubsiby_subsibyvalidityenddate;
		private string _officeautomation_document_projdormsubsiby_subsibyremark;
		private string _officeautomation_document_projdormsubsiby_enjoypersoninfo;
		private string _officeautomation_document_projdormsubsiby_performanceprofitinfo;
		private string _officeautomation_document_projdormsubsiby_sumperformance;
		private string _officeautomation_document_projdormsubsiby_sumprofit;
		private string _officeautomation_document_projdormsubsiby_projgoodsquantity;
		private string _officeautomation_document_projdormsubsiby_projgoodsvalue;
		private string _officeautomation_document_projdormsubsiby_projcommission;
		private string _officeautomation_document_projdormsubsiby_projcommpoint;
		private string _officeautomation_document_projdormsubsiby_dormsumcost;
		private string _officeautomation_document_projdormsubsiby_subsibysumcost;
		private string _officeautomation_document_projdormsubsiby_dormsumcostscale;
		private string _officeautomation_document_projdormsubsiby_subsibysumcostscale;
		private string _officeautomation_document_projdormsubsiby_remark;
		private string _officeautomation_document_projdormsubsiby_sign;

        private string officeAutomation_Document_ProjDormSubsiby_DormitoryMonth;
        private string officeAutomation_Document_ProjDormSubsiby_DormitoryMan;
        private string officeAutomation_Document_ProjDormSubsiby_DormitoryMdm;
        private DateTime? officeAutomation_Document_ProjDormSubsiby_DormitoryStartDate;
        private DateTime? officeAutomation_Document_ProjDormSubsiby_DormitoryEndDate;
        private string officeAutomation_Document_ProjDormSubsiby_DormitoryRemark;



		/// <summary>
		/// 主键
		/// </summary>
		public Guid OfficeAutomation_Document_ProjDormSubsiby_ID
		{
			set{ _officeautomation_document_projdormsubsiby_id=value;}
			get{return _officeautomation_document_projdormsubsiby_id;}
		}
		/// <summary>
		/// 公文流转主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_ProjDormSubsiby_MainID
		{
			set{ _officeautomation_document_projdormsubsiby_mainid=value;}
			get{return _officeautomation_document_projdormsubsiby_mainid;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_Department
		{
			set{ _officeautomation_document_projdormsubsiby_department=value;}
			get{return _officeautomation_document_projdormsubsiby_department;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_ProjDormSubsiby_ApplyDate
		{
			set{ _officeautomation_document_projdormsubsiby_applydate=value;}
			get{return _officeautomation_document_projdormsubsiby_applydate;}
		}
		/// <summary>
		/// 填写人
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_Apply
		{
			set{ _officeautomation_document_projdormsubsiby_apply=value;}
			get{return _officeautomation_document_projdormsubsiby_apply;}
		}
		/// <summary>
		/// 回复电话
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ReplyPhone
		{
			set{ _officeautomation_document_projdormsubsiby_replyphone=value;}
			get{return _officeautomation_document_projdormsubsiby_replyphone;}
		}
		/// <summary>
		/// 发文编号
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ApplyID
		{
			set{ _officeautomation_document_projdormsubsiby_applyid=value;}
			get{return _officeautomation_document_projdormsubsiby_applyid;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ProjName
		{
			set{ _officeautomation_document_projdormsubsiby_projname=value;}
			get{return _officeautomation_document_projdormsubsiby_projname;}
		}
		/// <summary>
		/// 开发商名称
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_DeveloperName
		{
			set{ _officeautomation_document_projdormsubsiby_developername=value;}
			get{return _officeautomation_document_projdormsubsiby_developername;}
		}
		/// <summary>
		/// 项目地址
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ProjAddress
		{
			set{ _officeautomation_document_projdormsubsiby_projaddress=value;}
			get{return _officeautomation_document_projdormsubsiby_projaddress;}
		}
		/// <summary>
		/// 项目代理开始日期
		/// </summary>
        public string OfficeAutomation_Document_ProjDormSubsiby_AgentStartDate
		{
			set{ _officeautomation_document_projdormsubsiby_agentstartdate=value;}
			get{return _officeautomation_document_projdormsubsiby_agentstartdate;}
		}
		/// <summary>
		/// 项目代理结束日期
		/// </summary>
        public string OfficeAutomation_Document_ProjDormSubsiby_AgentEndDate
		{
			set{ _officeautomation_document_projdormsubsiby_agentenddate=value;}
			get{return _officeautomation_document_projdormsubsiby_agentenddate;}
		}
		/// <summary>
		/// 开售日
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_SaleDate
		{
			set{ _officeautomation_document_projdormsubsiby_saledate=value;}
			get{return _officeautomation_document_projdormsubsiby_saledate;}
		}
		/// <summary>
		/// 物业性质
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_DealOfficeTypeIDs
		{
			set{ _officeautomation_document_projdormsubsiby_dealofficetypeids=value;}
			get{return _officeautomation_document_projdormsubsiby_dealofficetypeids;}
		}
		/// <summary>
		/// 其他物业性质描述
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_DealOfficeOther
		{
			set{ _officeautomation_document_projdormsubsiby_dealofficeother=value;}
			get{return _officeautomation_document_projdormsubsiby_dealofficeother;}
		}
		/// <summary>
		/// 货量
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_GoodsQuantity
		{
			set{ _officeautomation_document_projdormsubsiby_goodsquantity=value;}
			get{return _officeautomation_document_projdormsubsiby_goodsquantity;}
		}
		/// <summary>
		/// 货值
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_GoodsValue
		{
			set{ _officeautomation_document_projdormsubsiby_goodsvalue=value;}
			get{return _officeautomation_document_projdormsubsiby_goodsvalue;}
		}
		/// <summary>
		/// 预计创佣
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_PreComm
		{
			set{ _officeautomation_document_projdormsubsiby_precomm=value;}
			get{return _officeautomation_document_projdormsubsiby_precomm;}
		}
		/// <summary>
		/// 代理模式
		/// </summary>
		public int OfficeAutomation_Document_ProjDormSubsiby_AgentModel
		{
			set{ _officeautomation_document_projdormsubsiby_agentmodel=value;}
			get{return _officeautomation_document_projdormsubsiby_agentmodel;}
		}
		/// <summary>
		/// 佣金点数
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_CommPoint
		{
			set{ _officeautomation_document_projdormsubsiby_commpoint=value;}
			get{return _officeautomation_document_projdormsubsiby_commpoint;}
		}
		/// <summary>
		/// 租赁合同开始日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_ProjDormSubsiby_RentStartDate
		{
			set{ _officeautomation_document_projdormsubsiby_rentstartdate=value;}
			get{return _officeautomation_document_projdormsubsiby_rentstartdate;}
		}
		/// <summary>
		/// 租赁合同结束日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_ProjDormSubsiby_RentEndDate
		{
			set{ _officeautomation_document_projdormsubsiby_rentenddate=value;}
			get{return _officeautomation_document_projdormsubsiby_rentenddate;}
		}
		/// <summary>
		/// 租赁类型
		/// </summary>
		public int? OfficeAutomation_Document_ProjDormSubsiby_RentType
		{
			set{ _officeautomation_document_projdormsubsiby_renttype=value;}
			get{return _officeautomation_document_projdormsubsiby_renttype;}
		}
		/// <summary>
		/// 居住人数
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_LiveNumber
		{
			set{ _officeautomation_document_projdormsubsiby_livenumber=value;}
			get{return _officeautomation_document_projdormsubsiby_livenumber;}
		}
		/// <summary>
		/// 宿舍地址
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_DormAddress
		{
			set{ _officeautomation_document_projdormsubsiby_dormaddress=value;}
			get{return _officeautomation_document_projdormsubsiby_dormaddress;}
		}
		/// <summary>
		/// 租住面积
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_DormArea
		{
			set{ _officeautomation_document_projdormsubsiby_dormarea=value;}
			get{return _officeautomation_document_projdormsubsiby_dormarea;}
		}
		/// <summary>
		/// 户型
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_DormType
		{
			set{ _officeautomation_document_projdormsubsiby_dormtype=value;}
			get{return _officeautomation_document_projdormsubsiby_dormtype;}
		}
		/// <summary>
		/// 月租金
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_MonthlyRent
		{
			set{ _officeautomation_document_projdormsubsiby_monthlyrent=value;}
			get{return _officeautomation_document_projdormsubsiby_monthlyrent;}
		}
		/// <summary>
		/// 按金
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_Deposit
		{
			set{ _officeautomation_document_projdormsubsiby_deposit=value;}
			get{return _officeautomation_document_projdormsubsiby_deposit;}
		}
		/// <summary>
		/// 中介费
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_AgencyFee
		{
			set{ _officeautomation_document_projdormsubsiby_agencyfee=value;}
			get{return _officeautomation_document_projdormsubsiby_agencyfee;}
		}
		/// <summary>
		/// 每月预计支出费用
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_MonthlyEstimatedCost
		{
			set{ _officeautomation_document_projdormsubsiby_monthlyestimatedcost=value;}
			get{return _officeautomation_document_projdormsubsiby_monthlyestimatedcost;}
		}
		/// <summary>
		/// 管理费
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ManagermentCost
		{
			set{ _officeautomation_document_projdormsubsiby_managermentcost=value;}
			get{return _officeautomation_document_projdormsubsiby_managermentcost;}
		}
		/// <summary>
		/// 电费
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ElectricCharge
		{
			set{ _officeautomation_document_projdormsubsiby_electriccharge=value;}
			get{return _officeautomation_document_projdormsubsiby_electriccharge;}
		}
		/// <summary>
		/// 水费
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_WaterCharge
		{
			set{ _officeautomation_document_projdormsubsiby_watercharge=value;}
			get{return _officeautomation_document_projdormsubsiby_watercharge;}
		}
		/// <summary>
		/// 煤气费
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_GasCharge
		{
			set{ _officeautomation_document_projdormsubsiby_gascharge=value;}
			get{return _officeautomation_document_projdormsubsiby_gascharge;}
		}
		/// <summary>
		/// 每月支出合计
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_MonthlyCost
		{
			set{ _officeautomation_document_projdormsubsiby_monthlycost=value;}
			get{return _officeautomation_document_projdormsubsiby_monthlycost;}
		}
		/// <summary>
		/// 宿舍费用备注
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_DormRemark
		{
			set{ _officeautomation_document_projdormsubsiby_dormremark=value;}
			get{return _officeautomation_document_projdormsubsiby_dormremark;}
		}
		/// <summary>
		/// 津贴出发地
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_StartPlace
		{
			set{ _officeautomation_document_projdormsubsiby_startplace=value;}
			get{return _officeautomation_document_projdormsubsiby_startplace;}
		}
		/// <summary>
		/// 津贴目的地
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_EndPlace
		{
			set{ _officeautomation_document_projdormsubsiby_endplace=value;}
			get{return _officeautomation_document_projdormsubsiby_endplace;}
		}
		/// <summary>
		/// 双程金额
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_RoundTripMoney
		{
			set{ _officeautomation_document_projdormsubsiby_roundtripmoney=value;}
			get{return _officeautomation_document_projdormsubsiby_roundtripmoney;}
		}
		/// <summary>
		/// 次数
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_NumberOfTimes
		{
			set{ _officeautomation_document_projdormsubsiby_numberoftimes=value;}
			get{return _officeautomation_document_projdormsubsiby_numberoftimes;}
		}
		/// <summary>
		/// 津贴总金额
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_SumOfMoney
		{
			set{ _officeautomation_document_projdormsubsiby_sumofmoney=value;}
			get{return _officeautomation_document_projdormsubsiby_sumofmoney;}
		}
		/// <summary>
		/// 津贴有效开始日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityStartDate
		{
			set{ _officeautomation_document_projdormsubsiby_subsibyvaliditystartdate=value;}
			get{return _officeautomation_document_projdormsubsiby_subsibyvaliditystartdate;}
		}
		/// <summary>
		/// 津贴有效结束日期
		/// </summary>
		public DateTime? OfficeAutomation_Document_ProjDormSubsiby_SubsibyValidityEndDate
		{
			set{ _officeautomation_document_projdormsubsiby_subsibyvalidityenddate=value;}
			get{return _officeautomation_document_projdormsubsiby_subsibyvalidityenddate;}
		}
		/// <summary>
		/// 津贴费用说明
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_SubsibyRemark
		{
			set{ _officeautomation_document_projdormsubsiby_subsibyremark=value;}
			get{return _officeautomation_document_projdormsubsiby_subsibyremark;}
		}
		/// <summary>
		/// 享受人员信息
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_EnjoyPersonInfo
		{
			set{ _officeautomation_document_projdormsubsiby_enjoypersoninfo=value;}
			get{return _officeautomation_document_projdormsubsiby_enjoypersoninfo;}
		}
		/// <summary>
		/// 业绩利润信息
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_PerformanceProfitInfo
		{
			set{ _officeautomation_document_projdormsubsiby_performanceprofitinfo=value;}
			get{return _officeautomation_document_projdormsubsiby_performanceprofitinfo;}
		}
		/// <summary>
		/// 累计业绩合计
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_SumPerformance
		{
			set{ _officeautomation_document_projdormsubsiby_sumperformance=value;}
			get{return _officeautomation_document_projdormsubsiby_sumperformance;}
		}
		/// <summary>
		/// 累计利润合计
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_SumProfit
		{
			set{ _officeautomation_document_projdormsubsiby_sumprofit=value;}
			get{return _officeautomation_document_projdormsubsiby_sumprofit;}
		}
		/// <summary>
		/// 项目货量
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsQuantity
		{
			set{ _officeautomation_document_projdormsubsiby_projgoodsquantity=value;}
			get{return _officeautomation_document_projdormsubsiby_projgoodsquantity;}
		}
		/// <summary>
		/// 项目货值
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ProjGoodsValue
		{
			set{ _officeautomation_document_projdormsubsiby_projgoodsvalue=value;}
			get{return _officeautomation_document_projdormsubsiby_projgoodsvalue;}
		}
		/// <summary>
		/// 项目预计创佣
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ProjCommission
		{
			set{ _officeautomation_document_projdormsubsiby_projcommission=value;}
			get{return _officeautomation_document_projdormsubsiby_projcommission;}
		}
		/// <summary>
		/// 项目佣金点数
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_ProjCommPoint
		{
			set{ _officeautomation_document_projdormsubsiby_projcommpoint=value;}
			get{return _officeautomation_document_projdormsubsiby_projcommpoint;}
		}
		/// <summary>
		/// 宿舍费用总额
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_DormSumCost
		{
			set{ _officeautomation_document_projdormsubsiby_dormsumcost=value;}
			get{return _officeautomation_document_projdormsubsiby_dormsumcost;}
		}
		/// <summary>
		/// 津贴费用总额
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCost
		{
			set{ _officeautomation_document_projdormsubsiby_subsibysumcost=value;}
			get{return _officeautomation_document_projdormsubsiby_subsibysumcost;}
		}
		/// <summary>
		/// 宿舍费用占比
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_DormSumCostScale
		{
			set{ _officeautomation_document_projdormsubsiby_dormsumcostscale=value;}
			get{return _officeautomation_document_projdormsubsiby_dormsumcostscale;}
		}
		/// <summary>
		/// 津贴费用占比
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_SubsibySumCostScale
		{
			set{ _officeautomation_document_projdormsubsiby_subsibysumcostscale=value;}
			get{return _officeautomation_document_projdormsubsiby_subsibysumcostscale;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_Remark
		{
			set{ _officeautomation_document_projdormsubsiby_remark=value;}
			get{return _officeautomation_document_projdormsubsiby_remark;}
		}
		/// <summary>
		/// 标记
		/// </summary>
		public string OfficeAutomation_Document_ProjDormSubsiby_Sign
		{
			set{ _officeautomation_document_projdormsubsiby_sign=value;}
			get{return _officeautomation_document_projdormsubsiby_sign;}
		}

        /// <summary>
        /// 人均宿舍津贴（元/月）
        /// </summary>
        public string OfficeAutomation_Document_ProjDormSubsiby_DormitoryMonth
        {
            get { return officeAutomation_Document_ProjDormSubsiby_DormitoryMonth; }
            set { officeAutomation_Document_ProjDormSubsiby_DormitoryMonth = value; }
        }

        /// <summary>
        /// 人均宿舍津贴（人数）
        /// </summary>
        public string OfficeAutomation_Document_ProjDormSubsiby_DormitoryMan
        {
            get { return officeAutomation_Document_ProjDormSubsiby_DormitoryMan; }
            set { officeAutomation_Document_ProjDormSubsiby_DormitoryMan = value; }
        }

        /// <summary>
        /// 人均宿舍津贴（元/人/月）
        /// </summary>
        public string OfficeAutomation_Document_ProjDormSubsiby_DormitoryMdm
        {
            get { return officeAutomation_Document_ProjDormSubsiby_DormitoryMdm; }
            set { officeAutomation_Document_ProjDormSubsiby_DormitoryMdm = value; }
        }

        /// <summary>
        /// 津贴有效期开始时间
        /// </summary>
        public DateTime? OfficeAutomation_Document_ProjDormSubsiby_DormitoryStartDate
        {
            get { return officeAutomation_Document_ProjDormSubsiby_DormitoryStartDate; }
            set { officeAutomation_Document_ProjDormSubsiby_DormitoryStartDate = value; }
        }

        /// <summary>
        /// 津贴有效期结束时间
        /// </summary>
        public DateTime? OfficeAutomation_Document_ProjDormSubsiby_DormitoryEndDate
        {
            get { return officeAutomation_Document_ProjDormSubsiby_DormitoryEndDate; }
            set { officeAutomation_Document_ProjDormSubsiby_DormitoryEndDate = value; }
        }

        /// <summary>
        /// 津贴费用说明
        /// </summary>
        public string OfficeAutomation_Document_ProjDormSubsiby_DormitoryRemark
        {
            get { return officeAutomation_Document_ProjDormSubsiby_DormitoryRemark; }
            set { officeAutomation_Document_ProjDormSubsiby_DormitoryRemark = value; }
        }

        private string _OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney;
        /// <summary>
        /// 宿舍津贴申请发放金额
        /// </summary>
        public string OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney
        {
            get { return _OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney; }
            set { _OfficeAutomation_Document_ProjDormSubsiby_ApplyMoney = value; }
        }

        private string _OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney;
        /// <summary>
        /// 交通津贴申请发放金额
        /// </summary>
        public string OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney
        {
            get { return _OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney; }
            set { _OfficeAutomation_Document_ProjDormSubsiby_TrafficApplyMoney = value; }
        }

        private string _OfficeAutomation_Document_ProjDormSubsiby_LastYear;

        public string OfficeAutomation_Document_ProjDormSubsiby_LastYear
        {
            get { return _OfficeAutomation_Document_ProjDormSubsiby_LastYear; }
            set { _OfficeAutomation_Document_ProjDormSubsiby_LastYear = value; }
        }

        private string _OfficeAutomation_Document_ProjDormSubsiby_LastMonth;

        public string OfficeAutomation_Document_ProjDormSubsiby_LastMonth
        {
            get { return _OfficeAutomation_Document_ProjDormSubsiby_LastMonth; }
            set { _OfficeAutomation_Document_ProjDormSubsiby_LastMonth = value; }
        }

        private string _OfficeAutomation_Document_ProjDormSubsiby_LastRent;

        public string OfficeAutomation_Document_ProjDormSubsiby_LastRent
        {
            get { return _OfficeAutomation_Document_ProjDormSubsiby_LastRent; }
            set { _OfficeAutomation_Document_ProjDormSubsiby_LastRent = value; }
        }


		#endregion Model

	}
}

