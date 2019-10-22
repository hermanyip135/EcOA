using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_FinAffairsTransfer
    {
        [CProperty("Key")]
       public Guid OfficeAutomation_Document_FinAffairsTransfer_ID { get; set; }
       public Guid OfficeAutomation_Document_FinAffairsTransfer_MainID { get; set; }
       //移交人工号
       public string OfficeAutomation_Document_FinAffairsTransfer_HandoverCode { get; set; }
       //移交人
       public string OfficeAutomation_Document_FinAffairsTransfer_Apply { get; set; }
       //申请时间
       public DateTime? OfficeAutomation_Document_FinAffairsTransfer_ApplyDate { get; set; }
       //移交人负责分行
       public string OfficeAutomation_Document_FinAffairsTransfer_Department { get; set; }
       //移交人邮箱
       public string OfficeAutomation_Document_FinAffairsTransfer_HandoverEmail { get; set; }
         //接收人工号
       public string OfficeAutomation_Document_FinAffairsTransfer_SendeeCode { get; set; }
       //接收人
       public string OfficeAutomation_Document_FinAffairsTransfer_Sendee { get; set; }
       //接收人负责分行
       public string OfficeAutomation_Document_FinAffairsTransfer_SendeeDept { get; set; }
       //接收人邮箱
       public string OfficeAutomation_Document_FinAffairsTransfer_SendeeEmail { get; set; }
       //代收款收据本
       public string OfficeAutomation_Document_FinAffairsTransfer_ReceivablesBook { get; set; }
      //交接分行
       public string OfficeAutomation_Document_FinAffairsTransfer_HandoverDepts { get; set; }
       //代收款收据已开收据起止号
       //public string OfficeAutomation_Document_FinAffairsTransfer_ReceivablesOpenNum { get; set; }
       ////代收款收据已开收据起止号1
       //public string OfficeAutomation_Document_FinAffairsTransfer_ReceivablesOpenNum1 { get; set; }
       ////代收款收据已开收据起止号2
       //public string OfficeAutomation_Document_FinAffairsTransfer_ReceivablesOpenNum2 { get; set; }
       ////代收款收据空白收据起止号
       //public string OfficeAutomation_Document_FinAffairsTransfer_ReceivablesBlankNum { get; set; }
       ////代收款收据空白收据起止号1
       //public string OfficeAutomation_Document_FinAffairsTransfer_ReceivablesBlankNum1 { get; set; }
       ////代收款收据空白收据起止号2
       //public string OfficeAutomation_Document_FinAffairsTransfer_ReceivablesBlankNum2 { get; set; }
      
       
       //代收款备用金余额
       public string OfficeAutomation_Document_FinAffairsTransfer_ReceivablesSpareGoldMoeny { get; set; }
       //待补款收据号码
       public string OfficeAutomation_Document_FinAffairsTransfer_SupplementNum { get; set; }
       //待补款金额
       public string OfficeAutomation_Document_FinAffairsTransfer_SupplementMoeny { get; set; }
       //代收款备用金总额
       public string OfficeAutomation_Document_FinAffairsTransfer_ReceivablesSpareGoldSumMoeny { get; set; }
       //是否变更代收款备用金台账录入人
       public string OfficeAutomation_Document_FinAffairsTransfer_ISSpareGoldInput { get; set; }
       //是否变更代收款系统录入
       public string OfficeAutomation_Document_FinAffairsTransfer_ISReceivablesInput { get; set; }
       //发票打印机台
       public string OfficeAutomation_Document_FinAffairsTransfer_Platform { get; set; }
       //发票打印机编号
       public string OfficeAutomation_Document_FinAffairsTransfer_PlatformNum { get; set; }
       //佣金发票多少份
       public string OfficeAutomation_Document_FinAffairsTransfer_CommissionInvoiceNum { get; set; }
       //佣金发票已开发票
       public string OfficeAutomation_Document_FinAffairsTransfer_CommissionOpenInvoiceNum { get; set; }
       //佣金发票作废发票
       public string OfficeAutomation_Document_FinAffairsTransfer_CommissionCancelInvoiceNum { get; set; }
       //佣金发票空白发票
       public string OfficeAutomation_Document_FinAffairsTransfer_CommissionBlankInvoiceNum { get; set; }
       //备用金存折余款
       public string OfficeAutomation_Document_FinAffairsTransfer_SpareGoldPassbookMoney { get; set; }
       //现金余额
       public string OfficeAutomation_Document_FinAffairsTransfer_SpareGoldCashMoney { get; set; }
       //已用金额
       public string OfficeAutomation_Document_FinAffairsTransfer_SpareGoldUseMoney { get; set; }
       //是否保管人 1是 2否
       public string OfficeAutomation_Document_FinAffairsTransfer_ISSpareGoldCustodian { get; set; }
       //往来帐备用金合计金额
       public string OfficeAutomation_Document_FinAffairsTransfer_SpareGoldSumMoney { get; set; }
       //开户名
       public string OfficeAutomation_Document_FinAffairsTransfer_AccountName { get; set; }
       //开户行
       public string OfficeAutomation_Document_FinAffairsTransfer_AccountBank { get; set; }
       //帐户
       public string OfficeAutomation_Document_FinAffairsTransfer_Account { get; set; }
       //帐户余额
       public string OfficeAutomation_Document_FinAffairsTransfer_AccountBalance { get; set; }
       //开户名1
       public string OfficeAutomation_Document_FinAffairsTransfer_AccountName1 { get; set; }
       //开户行1
       public string OfficeAutomation_Document_FinAffairsTransfer_AccountBank1 { get; set; }
       //帐户1
       public string OfficeAutomation_Document_FinAffairsTransfer_Account1 { get; set; }
       //帐户余额1
       public string OfficeAutomation_Document_FinAffairsTransfer_AccountBalance1 { get; set; }
       //post机帐号
       public string OfficeAutomation_Document_FinAffairsTransfer_PostMachineAccounts { get; set; }
       //post机密码接收人
       public string OfficeAutomation_Document_FinAffairsTransfer_PostMachineRecipient { get; set; }
       //是否需要填写《代收款收据及发票待处理的明细》 1是 2否
        public string OfficeAutomation_Document_FinAffairsTransfer_ISFillDetail{get;set;}
       //1离职 2调铺
        public string OfficeAutomation_Document_FinAffairsTransfer_Action{get;set;}
       //备注
       public string OfficeAutomation_Document_FinAffairsTransfer_ActionRemark{get;set;}
    }
}
