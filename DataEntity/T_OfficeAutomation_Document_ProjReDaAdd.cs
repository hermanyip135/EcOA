
using System;
namespace DataEntity
{
    /// <summary>
    /// 项目报数申请表
    /// </summary>
    [Serializable]
    public partial class T_OfficeAutomation_Document_ProjReDaAdd
    {
        public T_OfficeAutomation_Document_ProjReDaAdd()
        { }
        #region Model
        private Guid _officeautomation_document_projrepodata_id;
        private Guid _officeautomation_document_projrepodata_mainid;
        private string _officeautomation_document_projrepodata_department;
        private DateTime _officeautomation_document_projrepodata_applydate;
        private string _officeautomation_document_projrepodata_apply;
        private string _officeautomation_document_projrepodata_replyphone;
        private string _officeautomation_document_projrepodata_applyid;
        private int _officeautomation_document_projrepodata_applytype;
        private string _officeautomation_document_projrepodata_applytyperate;
        private string _officeautomation_document_projrepodata_applytypeother;
        private string _officeautomation_document_projrepodata_projname;
        private bool _officeautomation_document_projrepodata_havepresaleid;
        private string _officeautomation_document_projrepodata_presaleid;
        private string _officeautomation_document_projrepodata_projaddress;
        private string _officeautomation_document_projrepodata_developername;
        private string _officeautomation_document_projrepodata_groupname;
        private string _officeautomation_document_projrepodata_dealofficetypeids;
        private string _officeautomation_document_projrepodata_dealofficeother;
        private string _officeautomation_document_projrepodata_agentstartdate;
        private string _officeautomation_document_projrepodata_agentenddate;
        private string _officeautomation_document_projrepodata_precomm;
        private string _officeautomation_document_projrepodata_goodsquantity;
        private string _officeautomation_document_projrepodata_goodsvalue;
        private string _officeautomation_document_projrepodata_commpoint;
        private int _officeautomation_document_projrepodata_agentmodel;
        private int _officeautomation_document_projrepodata_contracttype;
        private string _officeautomation_document_projrepodata_contracttypeother;
        private bool _officeautomation_document_projrepodata_havecoopcost;
        private bool _officeautomation_document_projrepodata_havecoopconf;
        private bool _officeautomation_document_projrepodata_issignback;
        private string _officeautomation_document_projrepodata_contractpresignbackdate;
        private string _officeautomation_document_projrepodata_remark;
        private int _officeautomation_document_projrepodata_projtype;
        private DateTime? _officeautomation_document_projrepodata_dealhistorystartdate;
        private DateTime? _officeautomation_document_projrepodata_dealhistoryenddate;
        private DateTime? _officeautomation_document_projrepodata_totalprofitstartdate;
        private DateTime? _officeautomation_document_projrepodata_totalprofitenddate;
        private string _officeautomation_document_projrepodata_indepcount;
        private string _officeautomation_document_projrepodata_indepperformance;
        private string _officeautomation_document_projrepodata_linkcount;
        private string _officeautomation_document_projrepodata_linkperformance;
        private string _officeautomation_document_projrepodata_totalprofit;
        private string _officeautomation_document_projrepodata_sign;
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_ProjReDaAdd_ID
        {
            set { _officeautomation_document_projrepodata_id = value; }
            get { return _officeautomation_document_projrepodata_id; }
        }
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ProjReDaAdd_MainID
        {
            set { _officeautomation_document_projrepodata_mainid = value; }
            get { return _officeautomation_document_projrepodata_mainid; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_Department
        {
            set { _officeautomation_document_projrepodata_department = value; }
            get { return _officeautomation_document_projrepodata_department; }
        }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ProjReDaAdd_ApplyDate
        {
            set { _officeautomation_document_projrepodata_applydate = value; }
            get { return _officeautomation_document_projrepodata_applydate; }
        }
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_Apply
        {
            set { _officeautomation_document_projrepodata_apply = value; }
            get { return _officeautomation_document_projrepodata_apply; }
        }
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_ReplyPhone
        {
            set { _officeautomation_document_projrepodata_replyphone = value; }
            get { return _officeautomation_document_projrepodata_replyphone; }
        }
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_ApplyID
        {
            set { _officeautomation_document_projrepodata_applyid = value; }
            get { return _officeautomation_document_projrepodata_applyid; }
        }
        /// <summary>
        /// 申请类别
        /// </summary>
        public int OfficeAutomation_Document_ProjReDaAdd_ApplyType
        {
            set { _officeautomation_document_projrepodata_applytype = value; }
            get { return _officeautomation_document_projrepodata_applytype; }
        }
        /// <summary>
        /// 申请比例
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_ApplyTypeRate
        {
            set { _officeautomation_document_projrepodata_applytyperate = value; }
            get { return _officeautomation_document_projrepodata_applytyperate; }
        }
        /// <summary>
        /// 其他申请类别描述
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_ApplyTypeOther
        {
            set { _officeautomation_document_projrepodata_applytypeother = value; }
            get { return _officeautomation_document_projrepodata_applytypeother; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_ProjName
        {
            set { _officeautomation_document_projrepodata_projname = value; }
            get { return _officeautomation_document_projrepodata_projname; }
        }
        /// <summary>
        /// 是否有预售证
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_HavePreSaleID
        {
            set { _officeautomation_document_projrepodata_havepresaleid = value; }
            get { return _officeautomation_document_projrepodata_havepresaleid; }
        }
        /// <summary>
        /// 预售证号
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_PreSaleID
        {
            set { _officeautomation_document_projrepodata_presaleid = value; }
            get { return _officeautomation_document_projrepodata_presaleid; }
        }
        /// <summary>
        /// 项目地址
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_ProjAddress
        {
            set { _officeautomation_document_projrepodata_projaddress = value; }
            get { return _officeautomation_document_projrepodata_projaddress; }
        }
        /// <summary>
        /// 开发商名称
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_DeveloperName
        {
            set { _officeautomation_document_projrepodata_developername = value; }
            get { return _officeautomation_document_projrepodata_developername; }
        }
        /// <summary>
        /// 所属集团名称
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_GroupName
        {
            set { _officeautomation_document_projrepodata_groupname = value; }
            get { return _officeautomation_document_projrepodata_groupname; }
        }
        /// <summary>
        /// 物业性质
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_DealOfficeTypeIDs
        {
            set { _officeautomation_document_projrepodata_dealofficetypeids = value; }
            get { return _officeautomation_document_projrepodata_dealofficetypeids; }
        }
        /// <summary>
        /// 其他物业性质描述
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_DealOfficeOther
        {
            set { _officeautomation_document_projrepodata_dealofficeother = value; }
            get { return _officeautomation_document_projrepodata_dealofficeother; }
        }
        /// <summary>
        /// 项目代理开始日期
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgentStartDate
        {
            set { _officeautomation_document_projrepodata_agentstartdate = value; }
            get { return _officeautomation_document_projrepodata_agentstartdate; }
        }
        /// <summary>
        /// 项目代理结束日期
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgentEndDate
        {
            set { _officeautomation_document_projrepodata_agentenddate = value; }
            get { return _officeautomation_document_projrepodata_agentenddate; }
        }
        /// <summary>
        /// 预计创佣
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_PreComm
        {
            set { _officeautomation_document_projrepodata_precomm = value; }
            get { return _officeautomation_document_projrepodata_precomm; }
        }
        /// <summary>
        /// 代理期内可售货量
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_GoodsQuantity
        {
            set { _officeautomation_document_projrepodata_goodsquantity = value; }
            get { return _officeautomation_document_projrepodata_goodsquantity; }
        }
        /// <summary>
        /// 代理期内可售货值
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_GoodsValue
        {
            set { _officeautomation_document_projrepodata_goodsvalue = value; }
            get { return _officeautomation_document_projrepodata_goodsvalue; }
        }
        /// <summary>
        /// 申请报数点数
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_CommPoint
        {
            set { _officeautomation_document_projrepodata_commpoint = value; }
            get { return _officeautomation_document_projrepodata_commpoint; }
        }
        /// <summary>
        /// 代理模式
        /// </summary>
        public int OfficeAutomation_Document_ProjReDaAdd_AgentModel
        {
            set { _officeautomation_document_projrepodata_agentmodel = value; }
            get { return _officeautomation_document_projrepodata_agentmodel; }
        }
        /// <summary>
        /// 合同类型
        /// </summary>
        public int OfficeAutomation_Document_ProjReDaAdd_ContractType
        {
            set { _officeautomation_document_projrepodata_contracttype = value; }
            get { return _officeautomation_document_projrepodata_contracttype; }
        }
        /// <summary>
        /// 其他合同类型描述
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_ContractTypeOther
        {
            set { _officeautomation_document_projrepodata_contracttypeother = value; }
            get { return _officeautomation_document_projrepodata_contracttypeother; }
        }
        /// <summary>
        /// 是否有合作费
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_HaveCoopCost
        {
            set { _officeautomation_document_projrepodata_havecoopcost = value; }
            get { return _officeautomation_document_projrepodata_havecoopcost; }
        }
        /// <summary>
        /// 是否有合作确认函
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_HaveCoopConf
        {
            set { _officeautomation_document_projrepodata_havecoopconf = value; }
            get { return _officeautomation_document_projrepodata_havecoopconf; }
        }
        /// <summary>
        /// 合同是否签回
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_IsSignBack
        {
            set { _officeautomation_document_projrepodata_issignback = value; }
            get { return _officeautomation_document_projrepodata_issignback; }
        }
        /// <summary>
        /// 合同预计签回时间
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_ContractPreSignBackDate
        {
            set { _officeautomation_document_projrepodata_contractpresignbackdate = value; }
            get { return _officeautomation_document_projrepodata_contractpresignbackdate; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_Remark
        {
            set { _officeautomation_document_projrepodata_remark = value; }
            get { return _officeautomation_document_projrepodata_remark; }
        }
        /// <summary>
        /// 项目类别
        /// </summary>
        public int OfficeAutomation_Document_ProjReDaAdd_ProjType
        {
            set { _officeautomation_document_projrepodata_projtype = value; }
            get { return _officeautomation_document_projrepodata_projtype; }
        }
        /// <summary>
        /// 历史成交开始日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_ProjReDaAdd_DealHistoryStartDate
        {
            set { _officeautomation_document_projrepodata_dealhistorystartdate = value; }
            get { return _officeautomation_document_projrepodata_dealhistorystartdate; }
        }
        /// <summary>
        /// 历史成交结束日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_ProjReDaAdd_DealHistoryEndDate
        {
            set { _officeautomation_document_projrepodata_dealhistoryenddate = value; }
            get { return _officeautomation_document_projrepodata_dealhistoryenddate; }
        }
        /// <summary>
        /// 累计利润开始日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_ProjReDaAdd_TotalProfitStartDate
        {
            set { _officeautomation_document_projrepodata_totalprofitstartdate = value; }
            get { return _officeautomation_document_projrepodata_totalprofitstartdate; }
        }
        /// <summary>
        /// 累计利润结束日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_ProjReDaAdd_TotalProfitEndDate
        {
            set { _officeautomation_document_projrepodata_totalprofitenddate = value; }
            get { return _officeautomation_document_projrepodata_totalprofitenddate; }
        }
        /// <summary>
        /// 独立成交宗数
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_IndepCount
        {
            set { _officeautomation_document_projrepodata_indepcount = value; }
            get { return _officeautomation_document_projrepodata_indepcount; }
        }
        /// <summary>
        /// 独立成交业绩
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_IndepPerformance
        {
            set { _officeautomation_document_projrepodata_indepperformance = value; }
            get { return _officeautomation_document_projrepodata_indepperformance; }
        }
        /// <summary>
        /// 联动成交宗数
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_LinkCount
        {
            set { _officeautomation_document_projrepodata_linkcount = value; }
            get { return _officeautomation_document_projrepodata_linkcount; }
        }
        /// <summary>
        /// 联动成交业绩
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_LinkPerformance
        {
            set { _officeautomation_document_projrepodata_linkperformance = value; }
            get { return _officeautomation_document_projrepodata_linkperformance; }
        }
        /// <summary>
        /// 期间累计税前利润
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_TotalProfit
        {
            set { _officeautomation_document_projrepodata_totalprofit = value; }
            get { return _officeautomation_document_projrepodata_totalprofit; }
        }
        /// <summary>
        /// 标记
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_Sign
        {
            set { _officeautomation_document_projrepodata_sign = value; }
            get { return _officeautomation_document_projrepodata_sign; }
        }

        //20141027+
        private int _OfficeAutomation_Document_ProjReDaAdd_JOrT;
        /// <summary>
        /// 是否与行家联合代理或轮流代理
        /// </summary>
        public int OfficeAutomation_Document_ProjReDaAdd_JOrT
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_JOrT; }
            set { _OfficeAutomation_Document_ProjReDaAdd_JOrT = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1;
        /// <summary>
        /// 同场代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1; }
            set { _OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX1 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2;
        /// <summary>
        /// 同场代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2; }
            set { _OfficeAutomation_Document_ProjReDaAdd_SamePlaceXX2 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1;
        /// <summary>
        /// 轮流代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1; }
            set { _OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX1 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2;
        /// <summary>
        /// 轮流代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2; }
            set { _OfficeAutomation_Document_ProjReDaAdd_TurnsAgentXX2 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_AgencyFee1;
        /// <summary>
        /// 同场代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgencyFee1
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AgencyFee1; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AgencyFee1 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_AgencyFee2;
        /// <summary>
        /// 同场代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgencyFee2
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AgencyFee2; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AgencyFee2 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_AgencyFee3;
        /// <summary>
        /// 轮流代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgencyFee3
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AgencyFee3; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AgencyFee3 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_AgencyFee4;
        /// <summary>
        /// 轮流代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgencyFee4
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AgencyFee4; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AgencyFee4 = value; }
        }

        private bool _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1;
        /// <summary>
        /// 是否有同场代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1; }
            set { _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize1 = value; }
        }

        private bool _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2;
        /// <summary>
        /// 是否有同场代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2; }
            set { _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3;
        /// <summary>
        /// 是否有轮流代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3; }
            set { _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize3 = value; }
        }

        private bool _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4;
        /// <summary>
        /// 是否有轮流代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4; }
            set { _OfficeAutomation_Document_ProjReDaAdd_IsCashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_CashPrize1;
        /// <summary>
        /// 同场代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_CashPrize1
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_CashPrize1; }
            set { _OfficeAutomation_Document_ProjReDaAdd_CashPrize1 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_CashPrize2;
        /// <summary>
        /// 同场代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_CashPrize2
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_CashPrize2; }
            set { _OfficeAutomation_Document_ProjReDaAdd_CashPrize2 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_CashPrize3;
        /// <summary>
        /// 轮流代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_CashPrize3
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_CashPrize3; }
            set { _OfficeAutomation_Document_ProjReDaAdd_CashPrize3 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_CashPrize4;
        /// <summary>
        /// 轮流代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_CashPrize4
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_CashPrize4; }
            set { _OfficeAutomation_Document_ProjReDaAdd_CashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1;
        /// <summary>
        /// 轮流代理行家代理开始期1
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate1 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2;
        /// <summary>
        /// 轮流代理行家代理开始期2
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AgencyBeginDate2 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1;
        /// <summary>
        /// 轮流代理行家代理结束期1
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate1 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2;
        /// <summary>
        /// 轮流代理行家代理结束期2
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AgencyEndDate2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjReDaAdd_IsPFear1;
        /// <summary>
        /// 是否有项目费用1
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_IsPFear1
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_IsPFear1; }
            set { _OfficeAutomation_Document_ProjReDaAdd_IsPFear1 = value; }
        }

        private bool _OfficeAutomation_Document_ProjReDaAdd_IsPFear2;
        /// <summary>
        /// 是否有项目费用2
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_IsPFear2
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_IsPFear2; }
            set { _OfficeAutomation_Document_ProjReDaAdd_IsPFear2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjReDaAdd_IsPFear3;
        /// <summary>
        /// 是否有项目费用3
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_IsPFear3
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_IsPFear3; }
            set { _OfficeAutomation_Document_ProjReDaAdd_IsPFear3 = value; }
        }

        private bool _OfficeAutomation_Document_ProjReDaAdd_IsPFear4;
        /// <summary>
        /// 是否有项目费用4
        /// </summary>
        public bool OfficeAutomation_Document_ProjReDaAdd_IsPFear4
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_IsPFear4; }
            set { _OfficeAutomation_Document_ProjReDaAdd_IsPFear4 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_PFear1;
        /// <summary>
        /// 项目费用1
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_PFear1
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_PFear1; }
            set { _OfficeAutomation_Document_ProjReDaAdd_PFear1 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_PFear2;
        /// <summary>
        /// 项目费用2
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_PFear2
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_PFear2; }
            set { _OfficeAutomation_Document_ProjReDaAdd_PFear2 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_PFear3;
        /// <summary>
        /// 项目费用3
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_PFear3
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_PFear3; }
            set { _OfficeAutomation_Document_ProjReDaAdd_PFear3 = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_PFear4;
        /// <summary>
        /// 项目费用4
        /// </summary>
        public string OfficeAutomation_Document_ProjReDaAdd_PFear4
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_PFear4; }
            set { _OfficeAutomation_Document_ProjReDaAdd_PFear4 = value; }
        }
        //20141027+

        private string _OfficeAutomation_Document_ProjReDaAdd_AreaProj;

        public string OfficeAutomation_Document_ProjReDaAdd_AreaProj
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AreaProj; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AreaProj = value; }
        }

        private string _OfficeAutomation_Document_ProjReDaAdd_AreaMaster;

        public string OfficeAutomation_Document_ProjReDaAdd_AreaMaster
        {
            get { return _OfficeAutomation_Document_ProjReDaAdd_AreaMaster; }
            set { _OfficeAutomation_Document_ProjReDaAdd_AreaMaster = value; }
        }


        #endregion Model
    }
}

