using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 文档子表
    /// </summary>
    public class T_OfficeAutomation_Document_UtNewProj_New_Detail
    {
        //子表主键
        public Guid OfficeAutomation_Document_UtNewProj_New_Detail_ID { get; set; }
        //文档主表主键
        public Guid OfficeAutomation_Document_UtNewProj_New_Detail_MainID { get; set; }
        //子表数据类型（1.物业类型、2.行家信息、3.代理费内容、4.现金奖）
        public Int32 OfficeAutomation_Document_UtNewProj_New_Detail_TypeID { get; set; }
        //物业类型
        public Int32 OfficeAutomation_Document_UtNewProj_New_Detail_DealOfficeTypeID { get; set; }
        //AB盘类型
        public Int32 OfficeAutomation_Document_UtNewProj_New_Detail_DiskSourceID { get; set; }
        //承接货量-面积总计
        public string OfficeAutomation_Document_UtNewProj_New_Detail_TotalSize { get; set; }
        //承接货量-套数总计
        public string OfficeAutomation_Document_UtNewProj_New_Detail_TotalUnitCount { get; set; }
        //承接货量-单价
        public string OfficeAutomation_Document_UtNewProj_New_Detail_UnitPrice { get; set; }
        //承接货量-面积段
        public string OfficeAutomation_Document_UtNewProj_New_Detail_SizeSegments { get; set; }
        //预估目标-完成套数
        public string OfficeAutomation_Document_UtNewProj_New_Detail_PreCompleteCount { get; set; }
        //预估目标-佣金收入
        public string OfficeAutomation_Document_UtNewProj_New_Detail_PreComm { get; set; }
        //代理公司名称
        public string OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyName { get; set; }
        //代理公司类型
        public Int32 OfficeAutomation_Document_UtNewProj_New_Detail_AgentCompanyTypeID { get; set; }
        //代理费及现金奖情况
        public string OfficeAutomation_Document_UtNewProj_New_Detail_AgentFeeAndCashPrizeSituation { get; set; }
        //佣金类型
        public Int32 OfficeAutomation_Document_UtNewProj_New_Detail_CommFeeTypeID { get; set; }
        //签约公司名称
        public string OfficeAutomation_Document_UtNewProj_New_Detail_ContractingCompanyName { get; set; }
        //佣金跳BAR方式（1.全跳BAR、2.分级跳BAR、3.无跳BAR）
        public Int32 OfficeAutomation_Document_UtNewProj_New_Detail_OwnerCommJump { get; set; }
        //代理条件
        public string OfficeAutomation_Document_UtNewProj_New_Detail_AgentConditions { get; set; }
        //合同约定结佣条件
        public string OfficeAutomation_Document_UtNewProj_New_Detail_CommConditions { get; set; }
        //现金奖-现金奖（数字）
        public string OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize { get; set; }
        //现金奖-物业类型
        public string OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize_DealOfficeType { get; set; }
        //现金奖-成交日期
        public string OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize_DealDateStartAndEnd { get; set; }
        //现金奖-成交套数
        public string OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize_DealSetMinAndMax { get; set; }
        //现金奖-成交面积
        public string OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize_DealSizeMinAndMax { get; set; }
        //现金奖-成交价
        public string OfficeAutomation_Document_UtNewProj_New_Detail_CashPrize_DealPrizeMinAndMax { get; set; }
    }
}
