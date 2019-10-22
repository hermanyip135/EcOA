using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_ProjCost_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_ProjCost_M ProjCost_M { get; set; }
    }
    public class T_OfficeAutomation_Document_ProjCost_M
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public string OfficeAutomation_Document_ProjCost_ID { get; set; }

        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_MainID { get; set; }

        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Apply { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ApplyForName { get; set; }

        /// <summary>
        /// 申请人工号
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ApplyForCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Department { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_DepartmentID { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ApplyDate { get; set; }

        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ReplyPhone { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Project { get; set; }

        /// <summary>
        /// 发展商
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Developer { get; set; }

        /// <summary>
        /// 项目负责人
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ProjLeader { get; set; }

        /// <summary>
        /// 项目拓展负责人
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_ProjBusiLeader { get; set; }

        /// <summary>
        /// 物业性质ID
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_DealOfficeTypeID { get; set; }

        /// <summary>
        /// 可售面积
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Square { get; set; }

        /// <summary>
        /// 预计项目代理费计提
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PreProjAgenceFee { get; set; }

        /// <summary>
        /// 居间费用计提申请
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_BrokerCostApply { get; set; }

        /// <summary>
        /// 收款人姓名
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Receiver { get; set; }

        /// <summary>
        /// 居间费用计提原因
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_BrokerCostReason { get; set; }

        /// <summary>
        /// 居间人姓名
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_BrokerName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_Remark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_JOrT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_SamePlaceXX1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_SamePlaceXX2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_SamePlaceXX3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_SamePlaceXX4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_TurnsAgentXX1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_TurnsAgentXX2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_TurnsAgentXX3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_TurnsAgentXX4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyFee1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyFee2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyFee3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyFee4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_IsCashPrize1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_IsCashPrize2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_IsCashPrize3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_IsCashPrize4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_CashPrize1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_CashPrize2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_CashPrize3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_CashPrize4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyBeginDate1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyBeginDate2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyEndDate1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_AgencyEndDate2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_IsPFear1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_IsPFear2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_IsPFear3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_IsPFear4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PFear1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PFear2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PFear3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjCost_PFear4 { get; set; }

    }

}
