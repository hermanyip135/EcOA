using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using DataAccess.Operate;

namespace CheckUnAuditService
{
    partial class CheckUnAuditService : ServiceBase
    {
        public CheckUnAuditService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();

            TimeSpan ts = new TimeSpan();
            ts = DateTime.Now > DateTime.Now.Date.AddHours(10) ? (DateTime.Now.Date.AddDays(1).AddHours(10) - DateTime.Now) : (DateTime.Now.Date.AddHours(10) - DateTime.Now);
            //ts = TimeSpan.Parse("0:0:1");//测试间隔1秒

            timer.Interval = ts.TotalMilliseconds;
            timer.Start();
            timer.Elapsed += timer_Elapsed;
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DataSet ds = new DataSet();

            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            ds = da_OfficeAutomation_Flow_Inherit.SelectUnAudioLongTime(7);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string email = dr["OfficeAutomation_Flow_Employee"].ToString();
                    string messageBody = "您好，" + email + "：" + dr["Department"] + "的文档编码为" + dr["OfficeAutomation_SerialNumber"] + "的"
                        + da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(dr["OfficeAutomation_Flow_MainID"].ToString()) + "（http://gzs-terminal01:8003/Apply/"
                        + dr["Type"] + "/Apply_" + dr["Type"] + "_Detail.aspx?MainID=" + dr["OfficeAutomation_Flow_MainID"] + "），需要您的审理，已搁置超过"
                        + dr["Days"] + "天，请尽快登录系统进行审理";
                    SendMessageEX(email, "审理超时提醒", messageBody, messageBody);

                    email = dr["Apply"].ToString();
                    messageBody = "您好，" + email + "：" + dr["Department"] + "的文档编码为" + dr["OfficeAutomation_SerialNumber"] + "的"
                        + da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(dr["OfficeAutomation_Flow_MainID"].ToString()) + "（http://gzs-terminal01:8003/Apply/"
                        + dr["Type"] + "/Apply_" + dr["Type"] + "_Detail.aspx?MainID=" + dr["OfficeAutomation_Flow_MainID"] + "），目前在"
                        + dr["OfficeAutomation_Flow_Employee"] + "阶段已搁置超过" + dr["Days"] + "天，请提醒相关人员进行审理。";
                    SendMessageEX(email, "提醒审理超时", messageBody, messageBody);
                }
            }

            System.Timers.Timer t = (System.Timers.Timer)sender;
            t.Interval = 24 * 60 * 60 * 1000;//间隔1天
            //t.Interval = 20 * 1000;//测试间隔20秒
        }

        /// <summary>
        /// 发送提示信息，包含发送邮件及MSN提醒，插入至通知信息表，延迟发送。（20131120 将代理人考虑其中。如果设置了代理人，则只发送给代理人邮件）
        /// </summary>
        /// <param name="sMailToUserName">发送姓名</param>
        /// <param name="sMailSubject">主题</param>
        /// <param name="sMailBody">邮件内容</param>
        /// <param name="sMSNBody">内M内容</param>
        public static void SendMessageEX(string sMailToUserName, string sMailSubject, string sMailBody, string sMSNBody)
        {
            DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
            DataEntity.T_OfficeAutomation_Message t_OfficeAutomation_Message = new DataEntity.T_OfficeAutomation_Message();
            t_OfficeAutomation_Message.OfficeAutomation_Message_Title = sMailSubject;
            t_OfficeAutomation_Message.OfficeAutomation_Message_Body = sMailBody;
            t_OfficeAutomation_Message.OfficeAutomation_Message_MessBody = sMSNBody;

            if (System.Configuration.ConfigurationSettings.AppSettings["IsTesting"].ToString() == "True")//如果在测试，则发送至开发人员邮箱
            {
                t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = System.Configuration.ConfigurationSettings.AppSettings["TestEmail"].ToString();

                da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
            }
            else
            {
                DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                string sMailToUserNames = da_OfficeAutomation_Agent_Inherit.SelectAgentByAuditor(sMailToUserName,true);
                string[] names = sMailToUserNames.Split(',');
                foreach (string name in names)
                {
                    t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = da_Employee_Inherit.getDomainUserEmail(name);
                    da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
                }
            }
        }
    }
}
