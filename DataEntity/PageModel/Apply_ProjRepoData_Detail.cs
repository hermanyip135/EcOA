using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_ProjRepoData_Detail : PageModelBase
    {
        public T_OfficeAutomation_Document_ProjRepoData_M ProjRepoData { get;set;}
    }
    public class T_OfficeAutomation_Document_ProjRepoData_M
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ID { get; set; }

        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_MainID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_Department { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ApplyDate { get; set; }

        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_Apply { get; set; }

        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ReplyPhone { get; set; }

        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ApplyID { get; set; }

        /// <summary>
        /// 申请类别
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ApplyType { get; set; }

        /// <summary>
        /// 申请比例
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ApplyTypeRate { get; set; }

        /// <summary>
        /// 其他申请类别描述
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ApplyTypeOther { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ProjName { get; set; }

        /// <summary>
        /// 是否有预售证
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_HavePreSaleID { get; set; }

        /// <summary>
        /// 预售证号
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_PreSaleID { get; set; }

        /// <summary>
        /// 项目地址
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ProjAddress { get; set; }

        /// <summary>
        /// 开发商名称
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_DeveloperName { get; set; }

        /// <summary>
        /// 所属集团名称
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_GroupName { get; set; }

        /// <summary>
        /// 物业性质
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs { get; set; }

        /// <summary>
        /// 其他物业性质描述
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_DealOfficeOther { get; set; }

        /// <summary>
        /// 项目代理开始日期
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_AgentStartDate { get; set; }

        /// <summary>
        /// 项目代理结束日期
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_AgentEndDate { get; set; }

        /// <summary>
        /// 预计创佣
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_PreComm { get; set; }

        /// <summary>
        /// 代理期内可售货量
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_GoodsQuantity { get; set; }

        /// <summary>
        /// 代理期内可售货值
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_GoodsValue { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_CommPoint { get; set; }

        /// <summary>
        /// 申请报数点数
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_CommPostring { get; set; }

        /// <summary>
        /// 代理模式
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_AgentModel { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ContractType { get; set; }

        /// <summary>
        /// 其他合同类型描述
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ContractTypeOther { get; set; }

        /// <summary>
        /// 是否有合作费
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_HaveCoopCost { get; set; }

        /// <summary>
        /// 是否有合作确认函
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_HaveCoopConf { get; set; }

        /// <summary>
        /// 合同是否签回
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_IsSignBack { get; set; }

        /// <summary>
        /// 合同预计签回时间
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ContractPreSignBackDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_Remark { get; set; }

        /// <summary>
        /// 项目类别
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_ProjType { get; set; }

        /// <summary>
        /// 历史成交开始日期
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_DealHistoryStartDate { get; set; }

        /// <summary>
        /// 历史成交结束日期
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_DealHistoryEndDate { get; set; }

        /// <summary>
        /// 累计利润开始日期
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_TotalProfitStartDate { get; set; }

        /// <summary>
        /// 累计利润开始日期
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_TotalProfitEndDate { get; set; }

        /// <summary>
        /// 独立成交宗数
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_IndepCount { get; set; }

        /// <summary>
        /// 独立成交业绩
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_IndepPerformance { get; set; }

        /// <summary>
        /// 联动成交宗数
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_LinkCount { get; set; }

        /// <summary>
        /// 联动成交业绩
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_LinkPerformance { get; set; }

        /// <summary>
        /// 期间累计税前利润
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_TotalProfit { get; set; }

        /// <summary>
        /// 标记
        /// </summary>
        public string OfficeAutomation_Document_ProjRepoData_Sign { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_JOrT { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_SamePlaceXX1 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_SamePlaceXX2 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_TurnsAgentXX1 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_TurnsAgentXX2 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_AgencyFee1 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_AgencyFee2 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_AgencyFee3 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_AgencyFee4 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_IsCashPrize1 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_IsCashPrize2 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_IsCashPrize3 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_IsCashPrize4 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_CashPrize1 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_CashPrize2 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_CashPrize3 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_CashPrize4 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_AgencyBeginDate1 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_AgencyBeginDate2 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_AgencyEndDate1 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_AgencyEndDate2 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_IsPFear1 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_IsPFear2 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_IsPFear3 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_IsPFear4 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_PFear1 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_PFear2 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_PFear3 { get; set; }

        public string OfficeAutomation_Document_ProjRepoData_PFear4 { get; set; }

    }
}
