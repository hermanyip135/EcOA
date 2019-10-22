using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 文档主表
    /// </summary>
    public class T_OfficeAutomation_Document_UtNewProj_New
    {
        //申请表主键
        public Guid OfficeAutomation_Document_UtNewProj_New_ID { get; set; }
        //申请表主表主键
        public Guid OfficeAutomation_Document_UtNewProj_New_MainID { get; set; }
        //申请人工号
        public string OfficeAutomation_Document_UtNewProj_New_ApplyEmpCode { get; set; }
        //申请人姓名
        public string OfficeAutomation_Document_UtNewProj_New_ApplyEmpName { get; set; }
        //申请日期
        public DateTime OfficeAutomation_Document_UtNewProj_New_ApplyDate { get; set; }
        //申请人部门ID
        public string OfficeAutomation_Document_UtNewProj_New_ApplyDeptID { get; set; }
        //项目ID
        public Int32 OfficeAutomation_Document_UtNewProj_New_ProjectID { get; set; }
        //项目名称
        public string OfficeAutomation_Document_UtNewProj_New_Project { get; set; }
        //项目地址（根据公司划分区域）
        public string OfficeAutomation_Document_UtNewProj_New_ProjectLocation { get; set; }
        //项目实际地址
        public string OfficeAutomation_Document_UtNewProj_New_ProjectAddress { get; set; }
        //预售证发展商（小业主）
        public string OfficeAutomation_Document_UtNewProj_New_Developer { get; set; }
        //发展商联系人
        public string OfficeAutomation_Document_UtNewProj_New_DeveloperContacter { get; set; }
        //发展商联系人职位
        public string OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPosition { get; set; }
        //发展商联系方式
        public string OfficeAutomation_Document_UtNewProj_New_DeveloperContacterPhone { get; set; }
        //统筹人工号
        public string OfficeAutomation_Document_UtNewProj_New_CoordinatorCode { get; set; }
        //统筹人姓名
        public string OfficeAutomation_Document_UtNewProj_New_CoordinatorName { get; set; }
        //统筹人电话
        public string OfficeAutomation_Document_UtNewProj_New_CoordinatorPhone { get; set; }
        //统筹部门
        public string OfficeAutomation_Document_UtNewProj_New_CoordinatorDept { get; set; }
        //驻场工号
        public string OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerCode { get; set; }
        //驻场姓名
        public string OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerName { get; set; }
        //驻场联系方式
        public string OfficeAutomation_Document_UtNewProj_New_AreaCheckDataerPhone { get; set; }
        //是否有预售证
        public bool OfficeAutomation_Document_UtNewProj_New_IsPreSale { get; set; }
        //项目性质（一手项目、二手批量）
        public bool OfficeAutomation_Document_UtNewProj_New_IsOneOrTwo { get; set; }
        //代理类型（1.买卖、2租赁、3.买卖及租赁）
        public Int32 OfficeAutomation_Document_UtNewProj_New_DealType { get; set; }
        //物业类型总数
        public Int32 OfficeAutomation_Document_UtNewProj_New_DealOfficeType { get; set; }
        //场内代理（1.中原项目部、2.合富辉煌、3.世联、4.其它）
        public string OfficeAutomation_Document_UtNewProj_New_BaseAgent { get; set; }
        //场内代理（其它）内容
        public string OfficeAutomation_Document_UtNewProj_New_BaseAgentOther { get; set; }
        //行家信息总数
        public Int32 OfficeAutomation_Document_UtNewProj_New_AgentCompanyInfo { get; set; }
        //是否刷卡
        public bool OfficeAutomation_Document_UtNewProj_New_IsSwipeCard { get; set; }
        //预付多少元抵房价
        public string OfficeAutomation_Document_UtNewProj_New_PrePayMoney { get; set; }
        //预付抵多少房价
        public string OfficeAutomation_Document_UtNewProj_New_DiscountMoney { get; set; }
        //是否需要改造
        public bool OfficeAutomation_Document_UtNewProj_New_IsRenovation { get; set; }
        //改造费用
        public string OfficeAutomation_Document_UtNewProj_New_RenovationFee { get; set; }
        //其他额外支出
        public bool OfficeAutomation_Document_UtNewProj_New_IsOther { get; set; }
        //其他支付类型
        public string OfficeAutomation_Document_UtNewProj_New_OtherFeeType { get; set; }
        //其他支付费用
        public string OfficeAutomation_Document_UtNewProj_New_OtherFee { get; set; }
        //代理期开始
        public DateTime OfficeAutomation_Document_UtNewProj_New_AgentStartDate { get; set; }
        //代理期结束
        public DateTime OfficeAutomation_Document_UtNewProj_New_AgentEndDate { get; set; }
        //客户保护期开始
        public DateTime OfficeAutomation_Document_UtNewProj_New_ClientGuardStartDate { get; set; }
        //客户保护期结束
        public DateTime OfficeAutomation_Document_UtNewProj_New_ClientGuardEndDate { get; set; }
        //代理费类型总数
        public Int32 OfficeAutomation_Document_UtNewProj_New_CommFeeTypeInfo { get; set; }
        //是否有现金奖
        public bool OfficeAutomation_Document_UtNewProj_New_IsHaveCashPrize { get; set; }
        //签约公司名称
        public string OfficeAutomation_Document_UtNewProj_New_CorporateName { get; set; }
        //签约公司类型
        public string OfficeAutomation_Document_UtNewProj_New_CorporateType { get; set; }
        ////现金奖数额
        //public string OfficeAutomation_Document_UtNewProj_New_CashPrize { get; set; }

        //现金奖计算方式（1、固定金额，2、成交价百分比，3、实物奖励）
        public string OfficeAutomation_Document_UtNewProj_New_CalCashPrizeWay { get; set; }
        //现金奖计算条件（1、代理期内现金奖相同，2、按条件划分现金奖，3、其余情况）
        public string OfficeAutomation_Document_UtNewProj_New_CalCashPrizeConditions { get; set; }
        //按条件划分现金奖所选择的条件（1、物业类型，2、成交日期，3、成交套数，4、成交面积，5、成交价）
        public string OfficeAutomation_Document_UtNewProj_New_CalCashPrizeColumns { get; set; }

        //合同约定现金奖支付条件
        public string OfficeAutomation_Document_UtNewProj_New_PayCashPrizeConditions { get; set; }
        //现金奖发放方式（1.现金奖由发展商划入公司账户，随薪佣发放、2.现金奖由发展商直接支付现金，接收人必须是申请部门负责人。）
        public string OfficeAutomation_Document_UtNewProj_New_CashPrizePayType { get; set; }
        //现金奖是否需开具发票并由我司支付税费（1.是、2.否）
        public bool OfficeAutomation_Document_UtNewProj_New_IsMyPay { get; set; }
        //区域是否已提交发展商奖金确认书（1.是、2.否）
        public bool OfficeAutomation_Document_UtNewProj_New_IsAreaConfirm { get; set; }
        //区域承诺交回公司日期
        public DateTime OfficeAutomation_Document_UtNewProj_New_ReturnBackDate { get; set; }
        //盘方陀地公司-中原
        public bool OfficeAutomation_Document_UtNewProj_New_IsChoiceZY { get; set; }
        //房友圈
        public bool OfficeAutomation_Document_UtNewProj_New_IsChoiceFYQ { get; set; }
        //盘方陀地公司拆分比例
        public string OfficeAutomation_Document_UtNewProj_New_PanFangRate { get; set; }
        //新房中心拆分比例
        public string OfficeAutomation_Document_UtNewProj_New_NewHouseRate { get; set; }
        //广州中原是否直接与发展商签代理合同/联动协议
        public bool OfficeAutomation_Document_UtNewProj_New_IsDeveloperAndZYHaveContract { get; set; }
        //代理合同有禁止给客户让佣条款
        public bool OfficeAutomation_Document_UtNewProj_New_IsNoCashback { get; set; }
        //附加廉洁条款违约责任
        public bool OfficeAutomation_Document_UtNewProj_New_IsProbity { get; set; }
        //接盘区域限制（排他条款）
        public bool OfficeAutomation_Document_UtNewProj_New_IsZoneRestrictions { get; set; }
        //接盘区域限制（排他条款）内容
        public string OfficeAutomation_Document_UtNewProj_New_LimitArea { get; set; }
        //已上传资料
        public string OfficeAutomation_Document_UtNewProj_New_Lack { get; set; }
        //结佣条件-一次性付款-前佣
        public string OfficeAutomation_Document_UtNewProj_New_OneFront { get; set; }
        //结佣条件-一次性付款-后佣
        public string OfficeAutomation_Document_UtNewProj_New_OneAfter { get; set; }
        //结佣条件-按揭-前佣
        public string OfficeAutomation_Document_UtNewProj_New_TurnFront { get; set; }
        //结佣条件-按揭-后佣
        public string OfficeAutomation_Document_UtNewProj_New_TurnAfter { get; set; }
        //是否新项目合同
        public bool OfficeAutomation_Document_UtNewProj_New_IsNew { get; set; }
    }
}
