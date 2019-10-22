using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataAccess.Operate;

namespace AutoOverdue
{
    public class OfficialSealOverdue
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        DA_OfficeAutomation_Document_OfficialSeal_Inherit officialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();

        #region 根据mainid设置公章使用申请表申请日期到至今超过30天的为过期
        public void SetOverdue()
        {
            DataSet ds=officialSeal_Inherit.GetOverdueOfficialSealList();
            
            for(var i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                string mainid = ds.Tables[0].Rows[i]["OfficeAutomation_Document_OfficialSeal_MainID"].ToString();
                da_OfficeAutomation_Main_Inherit.UpdateFlowStateByMainID(mainid);

                DateTime applydate = Convert.ToDateTime(Convert.ToDateTime(ds.Tables[0].Rows[i]["OfficeAutomation_Document_OfficialSeal_ApplyDate"]).ToString("yyyy-MM-dd"));
                if (applydate >= Convert.ToDateTime("2017-02-20"))
                {
                    Messagebody(mainid);
                }
                
            }
        }
        #endregion

        #region 插入邮件表
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
                string sMailToUserNames = da_OfficeAutomation_Agent_Inherit.SelectAgentByAuditor(sMailToUserName, false);
                string[] names = sMailToUserNames.Split(',');
                foreach (string name in names)
                {
                    t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = da_Employee_Inherit.getDomainUserEmail(name);
                    da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
                }
            }
        }
        #endregion

        #region 根据MainID获得申请表的访问地址
        /// <summary>
        /// 根据MainID获得申请表的访问地址
        /// Author:JohnMingle
        /// CreateTime:2016/8/15
        /// </summary>
        /// <param name="sMainID">申请表的MainID</param>
        /// <returns>该申请的访问地址</returns>
        public string GetAddressByMainID(string sMainID,string documentname,string applydate)
        {
            string applyUrl = "http://gzs-terminal01:8003/Apply/";
            wsECOA.ECOAws ECOAws = new wsECOA.ECOAws();
            string PartOfURL = ECOAws.GetDocumentLink(documentname, applydate).Split('|')[0];
            applyUrl += (PartOfURL + ".aspx?MainID=" + sMainID);
            return applyUrl;
        }
        #endregion

        #region 邮件内容
        public void Messagebody(string MainID) 
        {
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();

            DataSet ds = new DataSet();
            string[] employnames;
            string email;
            string msnBody;
            ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(MainID);
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string employname;
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
            DA_OfficeAutomation_Document_OfficialSeal_Inherit da_OfficeAutomation_Document_OfficialSeal_Inherit = new DA_OfficeAutomation_Document_OfficialSeal_Inherit();
            ds = da_OfficeAutomation_Document_OfficialSeal_Inherit.SelectByMainID(MainID); //在不同的表中要修改
            string apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_Apply"].ToString();
            string applydate=ds.Tables[0].Rows[0]["OfficeAutomation_Document_OfficialSeal_ApplyDate"].ToString();

            string applyUrl =GetAddressByMainID(MainID,documentName,applydate);
            applyUrl = "内部网地址：" + applyUrl;



            //通知申请人
            msnBody = "您好" + apply + "，您有一份编号为" + serialNumber + "的" + documentName + "已超期，需重新上申请。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
            SendMessageEX(apply, documentName + "申请超期", msnBody, msnBody);

            //通知已同意的全部人员
            ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(MainID);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    msnBody = "您好" + employnames[i2] + "，您审理过的编号为" + serialNumber + "的" + documentName + "已超期，该申请作废。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                    email = employnames[i2]; if (email != "")
                        SendMessageEX(email, "您审理过的" + documentName + "已超期", msnBody, msnBody);
                }
            }
        }
        #endregion
    }
}
