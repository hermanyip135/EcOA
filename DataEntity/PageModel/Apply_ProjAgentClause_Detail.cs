using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_ProjAgentClause_Detail : PageModelBase
    {
        public T_OfficeAutomation_Document_ProjAgentClause_M ProjAgentClause { get; set; }
    }
    public class T_OfficeAutomation_Document_ProjAgentClause_M 
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ID { get; set; }

        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_MainID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_Department { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ApplyDate { get; set; }

        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_Apply { get; set; }

        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ReplyPhone { get; set; }

        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ApplyID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ProjName { get; set; }

        /// <summary>
        /// 开发商名称
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_DeveloperName { get; set; }

        /// <summary>
        /// 项目地址
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ProjAddress { get; set; }

        /// <summary>
        /// 项目代理开始日期
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgentStart { get; set; }

        /// <summary>
        /// 项目代理结束日期
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgentEnd { get; set; }

        /// <summary>
        /// 开售日
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_SaleDate { get; set; }

        /// <summary>
        /// 物业性质
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs { get; set; }

        /// <summary>
        /// 其他物业性质描述
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_DealOfficeOther { get; set; }

        /// <summary>
        /// 货量
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_GoodsQuantity { get; set; }

        /// <summary>
        /// 货值
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_GoodsValue { get; set; }

        /// <summary>
        /// 预计创佣
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PreComm { get; set; }

        /// <summary>
        /// 代理模式
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgentModel { get; set; }

        public string OfficeAutomation_Document_ProjAgentClause_CommPoint { get; set; }

        /// <summary>
        /// 佣金点数
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_CommPostring { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ContractType { get; set; }

        /// <summary>
        /// 其他合同类型描述
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ContractTypeOther { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_Remark { get; set; }

        /// <summary>
        /// 结佣条件条款
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm { get; set; }

        /// <summary>
        /// 扣罚条款
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ClauseFine { get; set; }

        /// <summary>
        /// 区域限制条款
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit { get; set; }

        /// <summary>
        /// 绩效考核条款
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck { get; set; }

        /// <summary>
        /// 廉洁条款
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ClauseHonest { get; set; }

        /// <summary>
        /// 其他条款
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_ClauseOther { get; set; }

        /// <summary>
        /// 标记
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_Sign { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PorjectExam { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_JOrT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_SamePlaceXX1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_SamePlaceXX2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_TurnsAgentXX2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyFee1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyFee2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyFee3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyFee4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_IsCashPrize1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_IsCashPrize2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_IsCashPrize3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_IsCashPrize4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_CashPrize1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_CashPrize2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_CashPrize3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_CashPrize4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyBeginDate2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyEndDate1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_AgencyEndDate2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_IsPFear1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_IsPFear2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_IsPFear3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_IsPFear4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PFear1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PFear2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PFear3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjAgentClause_PFear4 { get; set; }
    }
}
