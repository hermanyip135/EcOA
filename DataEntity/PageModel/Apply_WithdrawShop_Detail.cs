using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_WithdrawShop_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_WithdrawShop_M WithdrawShop_M { get; set; }
    }
    public class T_OfficeAutomation_Document_WithdrawShop_M
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public string OfficeAutomation_Document_WithdrawShop_ID { get; set; }

        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_MainID { get; set; }

        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_Apply { get; set; }

        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_ApplyID { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_ApplyDate { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_Department { get; set; }

        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_ReplyPhone { get; set; }

        /// <summary>
        /// 回复传真
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_ReplyFax { get; set; }

        /// <summary>
        /// 申请类型
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_ApplyTypeID { get; set; }

        /// <summary>
        /// 部门类型
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_DepartmentTypeID { get; set; }

        /// <summary>
        /// 总监
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_MajordomoID { get; set; }

        /// <summary>
        /// 操作部门名称
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_DepartmentName { get; set; }

        /// <summary>
        /// 操作部门地址
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_DepartmentAddress { get; set; }

        /// <summary>
        /// 租约届满日期
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_ExpireDate { get; set; }

        /// <summary>
        /// 计划实行日期
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_PlanDate { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_Reason { get; set; }

        /// <summary>
        /// 资产处理
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_AssetHandleIDs { get; set; }

        /// <summary>
        /// 其他资产处理情况
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_AssetHandleOther { get; set; }

        /// <summary>
        /// 电话处理
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_PhoneHandleID { get; set; }

        /// <summary>
        /// 是否飞线
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_IsFlyLine { get; set; }

        /// <summary>
        /// 飞线分行
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_FlyLineFrom { get; set; }

        /// <summary>
        /// 飞线到的分行
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_FlyLineTo { get; set; }

        /// <summary>
        /// 能否收回押金
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_CanBackDeposit { get; set; }

        /// <summary>
        /// 收回押金数目
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_BackDeposit { get; set; }

        /// <summary>
        /// 是否产生违约金
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages { get; set; }

        /// <summary>
        /// 产生违约金的数目
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_LiquidatedDamages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_Remark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_Deposit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_NoBackDeposit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_A1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_A2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_A3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_B1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_B2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_B3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_C1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_C2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_C3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_D1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_E1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_E2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_WithdrawShop_E3 { get; set; }





        public string OfficeAutomation_Document_WithdrawShop_StartDate { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_AreaLastYear { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_AreaLastYearResults { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_AreaThisYResults { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_AreaThisYProfit { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_BranchLastYear { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_BranchLastYResults { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_BranchLastYProfit { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_BranchThisYResults { get; set; }

        public string OfficeAutomation_Document_WithdrawShop_BranchThisYProfit { get; set; }

    }
}
