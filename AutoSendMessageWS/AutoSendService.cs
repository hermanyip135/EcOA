using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using DataAccess.Operate;
using System.Net.Mail;
using DataAccess.SendMessage;

namespace AutoSendMessageWS
{
    partial class AutoSendService : ServiceBase
    {
        public AutoSendService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.SendTimer.Enabled = true;
        }

        protected override void OnStop()
        {
            this.SendTimer.Enabled = false;
        }

        private void SendTimer_Elapsed(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
            ds = da_OfficeAutomation_Message_Inherit.SelectUnSendMessage();

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    SendMessage(dr["OfficeAutomation_Message_ID"].ToString(), dr["OfficeAutomation_Message_ToEmail"].ToString(), dr["OfficeAutomation_Message_Title"].ToString(), dr["OfficeAutomation_Message_Body"].ToString(), dr["OfficeAutomation_Message_MessBody"].ToString());
                }
            }
        }

        /// <summary>
        /// 发送提示信息，包含发送邮件及MSN提醒。
        /// </summary>
        /// <returns></returns>
        public static void SendMessage(string sID, string sMailTo, string sMailSubject, string sMailBody, string sMSNBody)
        {
            try
            {
                LCSService LCSSendMessage = new LCSService();

                if (sMailTo.Length > 10)
                {
                    //if (SendEmail(sMailTo, sMailSubject, sMailBody))
                    //{
                        LCSSendMessage.SendMessage("CentaGZ07928E53-5228-457D-A586-2C67CF4F8017", sMailTo, sMailSubject, sMSNBody);

                        DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
                        da_OfficeAutomation_Message_Inherit.UpdateWhenPostSuccess(sID);
                    //}
                }
            }
            catch
            { }
        }

        #region 本地smtp发送Email
        /// <summary>
        /// 本地smtp发送Email
        /// </summary>
        /// <param name="MailTo">接收Email地址</param>
        /// <param name="MailFrom">发送翻Email地址</param>
        /// <param name="MailSubject">邮件主题</param>
        /// <param name="MailBody">邮件内容</param>
        /// <param name="isHtml">是否为Html格式</param>
        /// <returns>布尔值表示发送成功与否</returns>
        public static bool SendEmail(string MailTo, string MailSubject, string MailBody)
        {
            string MailFrom = System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();
            MailMessage myMail = new MailMessage(MailFrom, MailTo);
            SmtpClient smtp = new SmtpClient();
            bool isReturn = false;

            try
            {
                myMail.BodyEncoding = Encoding.GetEncoding("utf-8");
                myMail.IsBodyHtml = Convert.ToBoolean("True");
                myMail.Subject = MailSubject;
                myMail.Body = MailBody;
                myMail.Priority = MailPriority.High;
                smtp.Host = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();

                smtp.Send(myMail);

                isReturn = true;
            }
            catch
            { }

            return isReturn;
        }
        #endregion
    }
}
