using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_SYSPWDTransfer
    {
        [CProperty("Key")]
       public Guid OfficeAutomation_Document_SYSPWDTransfer_ID { get; set; }
       public Guid OfficeAutomation_Document_SYSPWDTransfer_MainID { get; set; }
       //部门
       public string OfficeAutomation_Document_SYSPWDTransfer_Department { get; set; }
       //申请人
       public string OfficeAutomation_Document_SYSPWDTransfer_Apply { get; set; }
       //申请时间
       public DateTime OfficeAutomation_Document_SYSPWDTransfer_ApplyDate { get; set; }
       //开机用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_BootUser { get; set; }
       //开机密码
       public string OfficeAutomation_Document_SYSPWDTransfer_BootPwd { get; set; }
       //登录用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_LoginUser { get; set; }
       //登录密码
       public string OfficeAutomation_Document_SYSPWDTransfer_LoginPwd { get; set; }

       //代收款系统用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSysUser { get; set; }
       //代收款系统密码
       public string OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSysPwd { get; set; }

       //发票系统用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_InvoiceSysUser { get; set; }
       //发票系统密码
       public string OfficeAutomation_Document_SYSPWDTransfer_InvoiceSysPwd { get; set; }

       //内部网系统用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_IntranetSysUser { get; set; }
       //内部网系统密码
       public string OfficeAutomation_Document_SYSPWDTransfer_IntranetSysPwd { get; set; }

       //考勤系统用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_TimeSysUser { get; set; }
       //考勤系统密码
       public string OfficeAutomation_Document_SYSPWDTransfer_TimeSysPwd { get; set; }

       //中原门户系统用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_GatewaySysUser { get; set; }
       //中原门户系统密码
       public string OfficeAutomation_Document_SYSPWDTransfer_GatewaySysPwd { get; set; }

       //I－words传真系统系统用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_IWordsSysUser { get; set; }
       //I－words传真系统系统密码
       public string OfficeAutomation_Document_SYSPWDTransfer_IWordsSysPwd { get; set; }

       //三级市场锁匙管理帐户
       public string OfficeAutomation_Document_SYSPWDTransfer_MarketKeyUser { get; set; }
       //三级市场锁匙管理密码
       public string OfficeAutomation_Document_SYSPWDTransfer_MarketKeyPwd { get; set; }

       //POS机系统用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_PostMachineUser { get; set; }
       //POS机系统密码
       public string OfficeAutomation_Document_SYSPWDTransfer_PostMachinePwd { get; set; }

       //租赁报送系统用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_LeaseDeliverySysUser { get; set; }
       //租赁报送系统密码
       public string OfficeAutomation_Document_SYSPWDTransfer_LeaseDeliverySysPwd { get; set; }

       //短信平台用户名
       public string OfficeAutomation_Document_SYSPWDTransfer_MessageUser { get; set; }
       //短信平台密码
       public string OfficeAutomation_Document_SYSPWDTransfer_MessagePwd { get; set; }

       //保险箱密码
       public string OfficeAutomation_Document_SYSPWDTransfer_SafeDepositBoxPwd { get; set; }
       //分行WIFI密码
       public string OfficeAutomation_Document_SYSPWDTransfer_WIFIPwd { get; set; }
       //代收款备用金存折开户名
       public string OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSpareGoldUser { get; set; }
       //代收款备用金存折密码
       public string OfficeAutomation_Document_SYSPWDTransfer_ReceivablesSpareGoldPwd { get; set; }
       //往来款备用金存折开户名
       public string OfficeAutomation_Document_SYSPWDTransfer_IntercourseSpareGoldUser { get; set; }
       //往来款备用金存折密码
       public string OfficeAutomation_Document_SYSPWDTransfer_IntercourseSpareGoldPwd { get; set; }
    }
}
