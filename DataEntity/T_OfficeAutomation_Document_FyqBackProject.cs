using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_FyqBackProject
    {
            [CProperty("Key")]
        public Guid OfficeAutomation_Document_FyqBackProject_ID { get; set; }
        public Guid OfficeAutomation_Document_FyqBackProject_MainId { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_Apply { get; set; }
        public DateTime OfficeAutomation_Document_FyqBackProject_ApplyDate { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_Department { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_ApplyPhone { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_Location { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_Master { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_Buyers { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_OldLoanBank { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_LoandMoney { get; set; }

        public int  OfficeAutomation_Document_FyqBackProject_Progress { get; set; }
        public int OfficeAutomation_Document_FyqBackProject_NoProjectType { get; set; }
        public int OfficeAutomation_Document_FyqBackProject_NoProjectCause { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_OthersTypeMemo { get; set; }
        public bool OfficeAutomation_Document_FyqBackProject_BackData1 { get; set; }
        public bool OfficeAutomation_Document_FyqBackProject_BackData2 { get; set; }
        public bool OfficeAutomation_Document_FyqBackProject_BackData3 { get; set; }
        public bool OfficeAutomation_Document_FyqBackProject_BackData4 { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_OtherData { get; set; }
        public string OfficeAutomation_Document_FyqBackProject_ProjectNo { get; set; }
        /// <summary>
        /// 买家合计共缴交按揭费及税费人民币
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_BuySumM { get; set; }
        /// <summary>
        /// 卖家合计共缴交按揭费及税费人民币
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_SellSumM { get; set; }
        /// <summary>
        /// 产权查册
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_BuyPropertyM { get; set; }
        /// <summary>
        /// 家庭证明费
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_BuyFamilyProofM { get; set; }
        /// <summary>
        /// 评估费
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_BuyAssessmentM { get; set; }
        /// <summary>
        /// 按揭代理费
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_BuyMortgageAgentM { get; set; }
        /// <summary>
        ///担保费
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_BuySecurityFeeM { get; set; }
        /// <summary>
        ///税费
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_BuyTaxM { get; set; }
        /// <summary>
        ///买家上述费用合共人民币
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_BuyUpSumM { get; set; }
        /// <summary>
        ///退买家费用为人民币
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_BuyRetreatM { get; set; }

       //
        /// <summary>
        ///卖家担保费
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_SellSecurityFeeM { get; set; }
        /// <summary>
        ///卖家税费
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_SellTaxM { get; set; }
        /// <summary>
        ///卖家买家上述费用合共人民币
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_SellUpSumM { get; set; }
        /// <summary>
        ///卖家退买家费用为人民币
        /// </summary>
        public string OfficeAutomation_Document_FyqBackProject_SellRetreatM { get; set; }
        ////月
        //public string OfficeAutomation_Document_FyqBackProject_SellMonth { get; set; }
        ////日
        //public string OfficeAutomation_Document_FyqBackProject_Sellday { get; set; }
        //日期
        public string OfficeAutomation_Document_FyqBackProject_SellDate { get; set; }
        //跟进部门
        public string OfficeAutomation_Document_FyqBackProject_FollwDept{ get; set; }
        //根据人员
        public string OfficeAutomation_Document_FyqBackProject_FollwStaff { get; set; }
        //根据人员工号
        public string OfficeAutomation_Document_FyqBackProject_FollwStaffCode { get; set; }

    }
}
