using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 项目费用申请表
    /// </summary>
    [Serializable]
    public partial class T_OfficeAutomation_Document_ProjCost
    {
        public T_OfficeAutomation_Document_ProjCost()
        { }
        #region Model
        private Guid _officeautomation_document_projcost_id;
        private Guid _officeautomation_document_projcost_mainid;
        private string _officeautomation_document_projcost_apply;
        private string _officeautomation_document_projcost_applyforname;
        private string _officeautomation_document_projcost_applyforcode;
        private string _officeautomation_document_projcost_department;
        private Guid _officeautomation_document_projcost_departmentid;
        private DateTime _officeautomation_document_projcost_applydate;
        private string _officeautomation_document_projcost_replyphone;
        private string _officeautomation_document_projcost_project;
        private string _officeautomation_document_projcost_developer;
        private string _officeautomation_document_projcost_projleader;
        private string _officeautomation_document_projcost_projbusileader;
        private string _officeautomation_document_projcost_dealofficetypeid;
        private string _officeautomation_document_projcost_square;
        private string _officeautomation_document_projcost_preprojagencefee;
        private string _officeautomation_document_projcost_brokercostapply;
        private string _officeautomation_document_projcost_receiver;
        private string _officeautomation_document_projcost_brokercostreason;
        private string _officeautomation_document_projcost_brokername;
        private string _officeautomation_document_projcost_remark;
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_ProjCost_ID
        {
            set { _officeautomation_document_projcost_id = value; }
            get { return _officeautomation_document_projcost_id; }
        }
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ProjCost_MainID
        {
            set { _officeautomation_document_projcost_mainid = value; }
            get { return _officeautomation_document_projcost_mainid; }
        }
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Apply
        {
            set { _officeautomation_document_projcost_apply = value; }
            get { return _officeautomation_document_projcost_apply; }
        }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ApplyForName
        {
            set { _officeautomation_document_projcost_applyforname = value; }
            get { return _officeautomation_document_projcost_applyforname; }
        }
        /// <summary>
        /// 申请人工号
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ApplyForCode
        {
            set { _officeautomation_document_projcost_applyforcode = value; }
            get { return _officeautomation_document_projcost_applyforcode; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Department
        {
            set { _officeautomation_document_projcost_department = value; }
            get { return _officeautomation_document_projcost_department; }
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid OfficeAutomation_Document_ProjCost_DepartmentID
        {
            set { _officeautomation_document_projcost_departmentid = value; }
            get { return _officeautomation_document_projcost_departmentid; }
        }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ProjCost_ApplyDate
        {
            set { _officeautomation_document_projcost_applydate = value; }
            get { return _officeautomation_document_projcost_applydate; }
        }
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ReplyPhone
        {
            set { _officeautomation_document_projcost_replyphone = value; }
            get { return _officeautomation_document_projcost_replyphone; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Project
        {
            set { _officeautomation_document_projcost_project = value; }
            get { return _officeautomation_document_projcost_project; }
        }
        /// <summary>
        /// 发展商
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Developer
        {
            set { _officeautomation_document_projcost_developer = value; }
            get { return _officeautomation_document_projcost_developer; }
        }
        /// <summary>
        /// 项目负责人
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ProjLeader
        {
            set { _officeautomation_document_projcost_projleader = value; }
            get { return _officeautomation_document_projcost_projleader; }
        }
        /// <summary>
        /// 项目拓展负责人
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ProjBusiLeader
        {
            set { _officeautomation_document_projcost_projbusileader = value; }
            get { return _officeautomation_document_projcost_projbusileader; }
        }
        /// <summary>
        /// 物业性质ID
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_DealOfficeTypeID
        {
            set { _officeautomation_document_projcost_dealofficetypeid = value; }
            get { return _officeautomation_document_projcost_dealofficetypeid; }
        }
        /// <summary>
        /// 可售面积
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Square
        {
            set { _officeautomation_document_projcost_square = value; }
            get { return _officeautomation_document_projcost_square; }
        }
        /// <summary>
        /// 预计项目代理费计提
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PreProjAgenceFee
        {
            set { _officeautomation_document_projcost_preprojagencefee = value; }
            get { return _officeautomation_document_projcost_preprojagencefee; }
        }
        /// <summary>
        /// 居间费用计提申请
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_BrokerCostApply
        {
            set { _officeautomation_document_projcost_brokercostapply = value; }
            get { return _officeautomation_document_projcost_brokercostapply; }
        }
        /// <summary>
        /// 收款人姓名
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Receiver
        {
            set { _officeautomation_document_projcost_receiver = value; }
            get { return _officeautomation_document_projcost_receiver; }
        }
        /// <summary>
        /// 居间费用计提原因
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_BrokerCostReason
        {
            set { _officeautomation_document_projcost_brokercostreason = value; }
            get { return _officeautomation_document_projcost_brokercostreason; }
        }
        /// <summary>
        /// 居间人姓名
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_BrokerName
        {
            set { _officeautomation_document_projcost_brokername = value; }
            get { return _officeautomation_document_projcost_brokername; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Remark
        {
            set { _officeautomation_document_projcost_remark = value; }
            get { return _officeautomation_document_projcost_remark; }
        }

        //20141027+
        private int _OfficeAutomation_Document_ProjCost_JOrT;
        /// <summary>
        /// 是否与行家联合代理或轮流代理
        /// </summary>
        public int OfficeAutomation_Document_ProjCost_JOrT
        {
            get { return _OfficeAutomation_Document_ProjCost_JOrT; }
            set { _OfficeAutomation_Document_ProjCost_JOrT = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_SamePlaceXX1;
        /// <summary>
        /// 同场代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_SamePlaceXX1
        {
            get { return _OfficeAutomation_Document_ProjCost_SamePlaceXX1; }
            set { _OfficeAutomation_Document_ProjCost_SamePlaceXX1 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_SamePlaceXX2;
        /// <summary>
        /// 同场代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_SamePlaceXX2
        {
            get { return _OfficeAutomation_Document_ProjCost_SamePlaceXX2; }
            set { _OfficeAutomation_Document_ProjCost_SamePlaceXX2 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_TurnsAgentXX1;
        /// <summary>
        /// 轮流代理的行家名称1
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_TurnsAgentXX1
        {
            get { return _OfficeAutomation_Document_ProjCost_TurnsAgentXX1; }
            set { _OfficeAutomation_Document_ProjCost_TurnsAgentXX1 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_TurnsAgentXX2;
        /// <summary>
        /// 轮流代理的行家名称2
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_TurnsAgentXX2
        {
            get { return _OfficeAutomation_Document_ProjCost_TurnsAgentXX2; }
            set { _OfficeAutomation_Document_ProjCost_TurnsAgentXX2 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_AgencyFee1;
        /// <summary>
        /// 同场代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyFee1
        {
            get { return _OfficeAutomation_Document_ProjCost_AgencyFee1; }
            set { _OfficeAutomation_Document_ProjCost_AgencyFee1 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_AgencyFee2;
        /// <summary>
        /// 同场代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyFee2
        {
            get { return _OfficeAutomation_Document_ProjCost_AgencyFee2; }
            set { _OfficeAutomation_Document_ProjCost_AgencyFee2 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_AgencyFee3;
        /// <summary>
        /// 轮流代理行家代理费1
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyFee3
        {
            get { return _OfficeAutomation_Document_ProjCost_AgencyFee3; }
            set { _OfficeAutomation_Document_ProjCost_AgencyFee3 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_AgencyFee4;
        /// <summary>
        /// 轮流代理行家代理费2
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyFee4
        {
            get { return _OfficeAutomation_Document_ProjCost_AgencyFee4; }
            set { _OfficeAutomation_Document_ProjCost_AgencyFee4 = value; }
        }

        private bool _OfficeAutomation_Document_ProjCost_IsCashPrize1;
        /// <summary>
        /// 是否有同场代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ProjCost_IsCashPrize1
        {
            get { return _OfficeAutomation_Document_ProjCost_IsCashPrize1; }
            set { _OfficeAutomation_Document_ProjCost_IsCashPrize1 = value; }
        }

        private bool _OfficeAutomation_Document_ProjCost_IsCashPrize2;
        /// <summary>
        /// 是否有同场代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ProjCost_IsCashPrize2
        {
            get { return _OfficeAutomation_Document_ProjCost_IsCashPrize2; }
            set { _OfficeAutomation_Document_ProjCost_IsCashPrize2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjCost_IsCashPrize3;
        /// <summary>
        /// 是否有轮流代理行家现金奖1
        /// </summary>
        public bool OfficeAutomation_Document_ProjCost_IsCashPrize3
        {
            get { return _OfficeAutomation_Document_ProjCost_IsCashPrize3; }
            set { _OfficeAutomation_Document_ProjCost_IsCashPrize3 = value; }
        }

        private bool _OfficeAutomation_Document_ProjCost_IsCashPrize4;
        /// <summary>
        /// 是否有轮流代理行家现金奖2
        /// </summary>
        public bool OfficeAutomation_Document_ProjCost_IsCashPrize4
        {
            get { return _OfficeAutomation_Document_ProjCost_IsCashPrize4; }
            set { _OfficeAutomation_Document_ProjCost_IsCashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_CashPrize1;
        /// <summary>
        /// 同场代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_CashPrize1
        {
            get { return _OfficeAutomation_Document_ProjCost_CashPrize1; }
            set { _OfficeAutomation_Document_ProjCost_CashPrize1 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_CashPrize2;
        /// <summary>
        /// 同场代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_CashPrize2
        {
            get { return _OfficeAutomation_Document_ProjCost_CashPrize2; }
            set { _OfficeAutomation_Document_ProjCost_CashPrize2 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_CashPrize3;
        /// <summary>
        /// 轮流代理行家现金奖1
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_CashPrize3
        {
            get { return _OfficeAutomation_Document_ProjCost_CashPrize3; }
            set { _OfficeAutomation_Document_ProjCost_CashPrize3 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_CashPrize4;
        /// <summary>
        /// 轮流代理行家现金奖2
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_CashPrize4
        {
            get { return _OfficeAutomation_Document_ProjCost_CashPrize4; }
            set { _OfficeAutomation_Document_ProjCost_CashPrize4 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_AgencyBeginDate1;
        /// <summary>
        /// 轮流代理行家代理开始期1
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyBeginDate1
        {
            get { return _OfficeAutomation_Document_ProjCost_AgencyBeginDate1; }
            set { _OfficeAutomation_Document_ProjCost_AgencyBeginDate1 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_AgencyBeginDate2;
        /// <summary>
        /// 轮流代理行家代理开始期2
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyBeginDate2
        {
            get { return _OfficeAutomation_Document_ProjCost_AgencyBeginDate2; }
            set { _OfficeAutomation_Document_ProjCost_AgencyBeginDate2 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_AgencyEndDate1;
        /// <summary>
        /// 轮流代理行家代理结束期1
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyEndDate1
        {
            get { return _OfficeAutomation_Document_ProjCost_AgencyEndDate1; }
            set { _OfficeAutomation_Document_ProjCost_AgencyEndDate1 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_AgencyEndDate2;
        /// <summary>
        /// 轮流代理行家代理结束期2
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyEndDate2
        {
            get { return _OfficeAutomation_Document_ProjCost_AgencyEndDate2; }
            set { _OfficeAutomation_Document_ProjCost_AgencyEndDate2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjCost_IsPFear1;
        /// <summary>
        /// 是否有项目费用1
        /// </summary>
        public bool OfficeAutomation_Document_ProjCost_IsPFear1
        {
            get { return _OfficeAutomation_Document_ProjCost_IsPFear1; }
            set { _OfficeAutomation_Document_ProjCost_IsPFear1 = value; }
        }

        private bool _OfficeAutomation_Document_ProjCost_IsPFear2;
        /// <summary>
        /// 是否有项目费用2
        /// </summary>
        public bool OfficeAutomation_Document_ProjCost_IsPFear2
        {
            get { return _OfficeAutomation_Document_ProjCost_IsPFear2; }
            set { _OfficeAutomation_Document_ProjCost_IsPFear2 = value; }
        }

        private bool _OfficeAutomation_Document_ProjCost_IsPFear3;
        /// <summary>
        /// 是否有项目费用3
        /// </summary>
        public bool OfficeAutomation_Document_ProjCost_IsPFear3
        {
            get { return _OfficeAutomation_Document_ProjCost_IsPFear3; }
            set { _OfficeAutomation_Document_ProjCost_IsPFear3 = value; }
        }

        private bool _OfficeAutomation_Document_ProjCost_IsPFear4;
        /// <summary>
        /// 是否有项目费用4
        /// </summary>
        public bool OfficeAutomation_Document_ProjCost_IsPFear4
        {
            get { return _OfficeAutomation_Document_ProjCost_IsPFear4; }
            set { _OfficeAutomation_Document_ProjCost_IsPFear4 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_PFear1;
        /// <summary>
        /// 项目费用1
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PFear1
        {
            get { return _OfficeAutomation_Document_ProjCost_PFear1; }
            set { _OfficeAutomation_Document_ProjCost_PFear1 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_PFear2;
        /// <summary>
        /// 项目费用2
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PFear2
        {
            get { return _OfficeAutomation_Document_ProjCost_PFear2; }
            set { _OfficeAutomation_Document_ProjCost_PFear2 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_PFear3;
        /// <summary>
        /// 项目费用3
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PFear3
        {
            get { return _OfficeAutomation_Document_ProjCost_PFear3; }
            set { _OfficeAutomation_Document_ProjCost_PFear3 = value; }
        }

        private string _OfficeAutomation_Document_ProjCost_PFear4;
        /// <summary>
        /// 项目费用4
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PFear4
        {
            get { return _OfficeAutomation_Document_ProjCost_PFear4; }
            set { _OfficeAutomation_Document_ProjCost_PFear4 = value; }
        }
        //20141027+

        #endregion Model
    }
}
