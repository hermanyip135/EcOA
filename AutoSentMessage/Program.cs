using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using DataAccess.Operate;
using System.Net.Mail;
using DataAccess.SendMessage;

using DataEntity;
using System.Net;

namespace AutoSentMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();

            //20160321 凡事发给黄生的审批已完成的邮件都不发，故这里做删除处理
            da_OfficeAutomation_Message_Inherit.DeleteUnSendMessage();

            ds = da_OfficeAutomation_Message_Inherit.SelectUnSendMessage();
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0) //循环发送邮件
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        Console.WriteLine(dr["OfficeAutomation_Message_ToEmail"].ToString());
                        SendMessage(dr["OfficeAutomation_Message_ID"].ToString(), dr["OfficeAutomation_Message_ToEmail"].ToString(), dr["OfficeAutomation_Message_Title"].ToString(), dr["OfficeAutomation_Message_Body"].ToString(), dr["OfficeAutomation_Message_MessBody"].ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(dr["OfficeAutomation_Message_ToEmail"].ToString() + "：" + ex.Message);
                    }
                }
            }
            try
            {
                DataSet dsm = new DataSet();
                DataSet dsg = new DataSet();
                DataSet dst = new DataSet();
                T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
                dsm = da_OfficeAutomation_Message_Inherit.SelectMainNotBackUp();
                string TableName;
                Guid AID, Main_ID;
                if (dsm != null && dsm.Tables != null && dsm.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsm.Tables[0].Rows) //20141128：数据备份
                    {
                        try
                        {
                            Main_ID = new Guid(dr["OfficeAutomation_Main_ID"].ToString());
                            t_OfficeAutomation_Main.OfficeAutomation_Main_ID = Main_ID;
                            t_OfficeAutomation_Main.OfficeAutomation_SerialNumber = dr["OfficeAutomation_SerialNumber"].ToString();
                            t_OfficeAutomation_Main.OfficeAutomation_DocumentID = int.Parse(dr["OfficeAutomation_DocumentID"].ToString());
                            t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = int.Parse(dr["OfficeAutomation_Main_FlowStateID"].ToString());
                            t_OfficeAutomation_Main.OfficeAutomation_Main_AuditorIDsSum = dr["OfficeAutomation_Main_AuditorIDsSum"].ToString();
                            t_OfficeAutomation_Main.OfficeAutomation_Main_AuditorNamesSum = dr["OfficeAutomation_Main_AuditorNamesSum"].ToString();
                            t_OfficeAutomation_Main.OfficeAutomation_Main_IsBackUp = true;
                            da_OfficeAutomation_Message_Inherit.InsertMainBackUp(t_OfficeAutomation_Main);

                            dsg = da_OfficeAutomation_Message_Inherit.SelectAnotherTableBackUp(Main_ID);
                            TableName = dsg.Tables[0].Rows[0]["OfficeAutomation_Document_TableName"].ToString();
                            da_OfficeAutomation_Message_Inherit.InsertAnotherTableBackUp(TableName, Main_ID);
                            try { da_OfficeAutomation_Message_Inherit.InsertFlowsBUp(Main_ID); }
                            catch { }
                            try { da_OfficeAutomation_Message_Inherit.InsertDeletedFlowsBUp(Main_ID); }
                            catch { }
                            try { da_OfficeAutomation_Message_Inherit.InsertAttachBUp(Main_ID); }
                            catch { }

                            //详情表备份必须保证在主表中，ID是第一位，MainID是第二位，否则dst.Tables[0].Rows[0][0].ToString()等会出错
                            dst = da_OfficeAutomation_Message_Inherit.SelectTableByMainID(TableName, Main_ID);
                            AID = new Guid(dst.Tables[0].Rows[0][0].ToString());
                            try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_Detail", TableName, AID); }
                            catch { }

                            if (TableName != "t_OfficeAutomation_Document_GeneralApply")
                                try { da_OfficeAutomation_Message_Inherit.InsertAddFlows(AID); }
                                catch { }

                            if (TableName == "t_OfficeAutomation_Document_BranchContract")
                            {
                                try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_LeaseTerm", TableName, AID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_Statistical", TableName, AID); }
                                catch { }
                            }
                            if (TableName == "t_OfficeAutomation_Document_Feasibility")
                            {
                                try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_Diagram", TableName, new Guid(dst.Tables[0].Rows[0][1].ToString())); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_Menber", TableName, AID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_BuildingSituation", TableName, AID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_Competitors", TableName, AID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_DealOfRecord", TableName, AID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_Statistical", TableName, AID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.InsertDetailsBUp("_YearRent", TableName, AID); }
                                catch { }
                            }
                            da_OfficeAutomation_Message_Inherit.UpdateMainBackUp(Main_ID);
                        }
                        catch
                        {
                            try
                            {
                                //string TableName;
                                //Guid AID;
                                //DataSet dsg = new DataSet();
                                //DataSet dst = new DataSet();
                                //DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
                                Main_ID = new Guid(dr["OfficeAutomation_Main_ID"].ToString());
                                dsg = da_OfficeAutomation_Message_Inherit.SelectAnotherTableBackUp(Main_ID);
                                TableName = dsg.Tables[0].Rows[0]["OfficeAutomation_Document_TableName"].ToString();

                                dst = da_OfficeAutomation_Message_Inherit.SelectTableByMainID(TableName, Main_ID);
                                AID = new Guid(dst.Tables[0].Rows[0][0].ToString());
                                try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_Detail", TableName, AID); }
                                catch { }
                                if (TableName == "t_OfficeAutomation_Document_BranchContract")
                                {
                                    try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_LeaseTerm", TableName, AID); }
                                    catch { }
                                    try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_Statistical", TableName, AID); }
                                    catch { }
                                }
                                if (TableName == "t_OfficeAutomation_Document_Feasibility")
                                {
                                    try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_Diagram", TableName, new Guid(dst.Tables[0].Rows[0][1].ToString())); }
                                    catch { }
                                    try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_Menber", TableName, AID); }
                                    catch { }
                                    try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_BuildingSituation", TableName, AID); }
                                    catch { }
                                    try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_Competitors", TableName, AID); }
                                    catch { }
                                    try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_DealOfRecord", TableName, AID); }
                                    catch { }
                                    try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_Statistical", TableName, AID); }
                                    catch { }
                                    try { da_OfficeAutomation_Message_Inherit.DeleteDetailsBUp("_YearRent", TableName, AID); }
                                    catch { }
                                }

                                try { da_OfficeAutomation_Message_Inherit.DeleteMainBup(Main_ID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.DeleteTableBUp(TableName, Main_ID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.DeleteFlowsBup(Main_ID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.DeleteDeletedFlowsBup(Main_ID); }
                                catch { }
                                try { da_OfficeAutomation_Message_Inherit.DeleteAttachBup(Main_ID); }
                                catch { }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            try
            {
                DataSet dtg = da_OfficeAutomation_Message_Inherit.SelectMessageOverD1();
                for (int i = 0; i < dtg.Tables[0].Rows.Count; i++)
                {
                    string messageBody = "您好，" + dtg.Tables[0].Rows[i]["Aut"].ToString() + "：您有一份电子申请超过3天未被审批！申请表文档编码为：" + dtg.Tables[0].Rows[i]["SerialNumber"].ToString() + "请登陆电子审批系统查看。";
                    SendMessageEX(true, dtg.Tables[0].Rows[i]["Aut"].ToString(), "您有一份申请超过3天未被审批", messageBody, messageBody);
                    da_OfficeAutomation_Message_Inherit.UpdateMessageOverD(dtg.Tables[0].Rows[i]["SerialNumber"].ToString());
                }
                dtg = da_OfficeAutomation_Message_Inherit.SelectMessageOverD2();
                for (int i = 0; i < dtg.Tables[0].Rows.Count; i++)
                {
                    string messageBody = "您好，" + dtg.Tables[0].Rows[i]["Aut"].ToString() + "：您有一份电子申请超过3天未被审批。申请表文档编码为：" + dtg.Tables[0].Rows[i]["SerialNumber"].ToString() + "请登陆电子审批系统查看。";
                    SendMessageEX(true, dtg.Tables[0].Rows[i]["Aut"].ToString(), "您有一份申请超过3天未被审批", messageBody, messageBody);
                    da_OfficeAutomation_Message_Inherit.UpdateMessageOverD(dtg.Tables[0].Rows[i]["SerialNumber"].ToString());
                }
            }
            catch
            {
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
                //LCSService LCSSendMessage = new LCSService();

                if (sMailTo.Length > 10)
                {
                    if (SendEmail(sMailTo, sMailSubject, sMailBody))
                    {
                        //LCSSendMessage.SendMessage("CentaGZ07928E53-5228-457D-A586-2C67CF4F8017", sMailTo, sMailSubject, sMSNBody);

                        DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
                        da_OfficeAutomation_Message_Inherit.UpdateWhenPostSuccess(sID);
                    }
                }
            }
            catch(Exception ex)
            {
                //LogCommonFunction.AddErrorLog(sMailTo + ":" + ex.Message);
                throw ex;
            }
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

                //smtp.Credentials = new NetworkCredential("HHajxt", "GZ..000"); //M_Warning： 20150902 测试时用；正式平台注释掉，并在App.config中也把FromEmail的Value改为：EmailAlert@centaline.com.cn

                smtp.Send(myMail);

                isReturn = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return isReturn;
        }
        #endregion











            /// 发送提示信息，包含发送邮件及MSN提醒，插入至通知信息表，延迟发送。（20131120 将代理人考虑其中。如果设置了代理人，则只发送给代理人邮件）
    /// </summary>
    /// <param name="applyTableName">推送表名</param>
    /// <param name="sMailToUserName">发送姓名</param>
    /// <param name="sMailSubject">主题</param>
    /// <param name="sMailBody">邮件内容</param>
    /// <param name="sMSNBody">内M内容</param>
    public static void SendMessageEX(bool isa, string applyTableName, string sMailToUserName, string sMailSubject, string sMailBody, string sMSNBody)
    {
        if (sMailToUserName.Contains("陈洁丽（项目部）"))
            sMailToUserName = sMailToUserName.Replace("陈洁丽（项目部）", "陈洁丽A");
        else if (sMailToUserName.Contains("陈洁丽（法律及客服）"))
            sMailToUserName = sMailToUserName.Replace("陈洁丽（法律及客服）", "陈洁丽");
        DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
        DataEntity.T_OfficeAutomation_Message t_OfficeAutomation_Message = new DataEntity.T_OfficeAutomation_Message();
        t_OfficeAutomation_Message.OfficeAutomation_Message_Title = sMailSubject;
        t_OfficeAutomation_Message.OfficeAutomation_Message_Body = sMailBody;
        t_OfficeAutomation_Message.OfficeAutomation_Message_MessBody = sMSNBody;
        DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
        if (System.Configuration.ConfigurationSettings.AppSettings["IsTesting"].ToString() == "True")//如果在测试，则发送至开发人员邮箱
        {
            try
            {
                t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = System.Configuration.ConfigurationSettings.AppSettings["TestEmail"].ToString();
                DataSet ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeNames(sMailToUserName);
                //SendDirectPushMessage(applyTableName, ds.Tables[0].Rows[0]["Code"].ToString()); //手机推送
                da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
            }
            catch
            {
            }
        }
        else
        {
            string sMailToUserNames = da_OfficeAutomation_Agent_Inherit.SelectAgentByAuditor(sMailToUserName, isa);
            string[] names = sMailToUserNames.Split(',');
            foreach (string name in names)
            {
                try
                {
                    t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = da_Employee_Inherit.getDomainUserEmail(name);
                    DataSet ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeNames(name);
                    //SendDirectPushMessage(applyTableName, ds.Tables[0].Rows[0]["Code"].ToString()); //手机推送
                    da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
                }
                catch
                {
                }
            }
        }
    }

    /// <summary>
    /// 发送提示信息，包含发送邮件及MSN提醒，插入至通知信息表，延迟发送。（20131120 将代理人考虑其中。如果设置了代理人，则只发送给代理人邮件）
    /// </summary>
    /// <param name="sMailToUserName">发送姓名</param>
    /// <param name="sMailSubject">主题</param>
    /// <param name="sMailBody">邮件内容</param>
    /// <param name="sMSNBody">内M内容</param>
    public static void SendMessageEX(bool isa, string sMailToUserName, string sMailSubject, string sMailBody, string sMSNBody)
    {
        if (sMailToUserName.Contains("陈洁丽（项目部）"))
            sMailToUserName = sMailToUserName.Replace("陈洁丽（项目部）", "陈洁丽A");
        else if(sMailToUserName.Contains("陈洁丽（法律及客服）"))
            sMailToUserName = sMailToUserName.Replace("陈洁丽（法律及客服）", "陈洁丽");
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
            string sMailToUserNames = da_OfficeAutomation_Agent_Inherit.SelectAgentByAuditor(sMailToUserName, isa);
            string[] names = sMailToUserNames.Split(',');
            foreach (string name in names)
            {
                t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = da_Employee_Inherit.getDomainUserEmail(name);
                da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
            }
        }
    }

    /// <summary>
    /// 根据邮件地址发送提示信息，包含发送邮件及MSN提醒，插入至通知信息表，延迟发送。
    /// </summary>
    /// <param name="applyTableName">推送表名</param>
    /// <param name="sMailAddress">收件地址</param>
    /// <param name="sMailSubject">主题</param>
    /// <param name="sMailBody">邮件内容</param>
    /// <param name="sMSNBody">内M内容</param>
    public static void SendMessageByEmailAddress(string applyTableName, string sMailAddress, string sMailSubject, string sMailBody, string sMSNBody)
    {

        DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
        DataEntity.T_OfficeAutomation_Message t_OfficeAutomation_Message = new DataEntity.T_OfficeAutomation_Message();
        t_OfficeAutomation_Message.OfficeAutomation_Message_Title = sMailSubject;
        t_OfficeAutomation_Message.OfficeAutomation_Message_Body = sMailBody;
        t_OfficeAutomation_Message.OfficeAutomation_Message_MessBody = sMSNBody;
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
        //string code;

        if (System.Configuration.ConfigurationSettings.AppSettings["IsTesting"].ToString() == "True")//如果在测试，则发送至开发人员邮箱
        {
            t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = System.Configuration.ConfigurationSettings.AppSettings["TestEmail"].ToString();
            
            da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
        }
        else
        {
            string[] addresses = sMailAddress.Split('|');
            foreach (string address in addresses)
            {
                //code = da_Employee_Inherit.getUserNameByEmail(address);
                //if (code == "")
                //    code = da_Employee_Inherit.getSTByEmail(address);
                //SendDirectPushMessage(applyTableName, code); //手机推送
                t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = address;
                da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
            }
        }
    }




    #region 新增日志
    /// <summary>
    /// 新增日志
    /// </summary>
    /// <param name="sOperateID">操作人工号</param>
    /// <param name="sOperate">操作人</param>
    /// <param name="iModuleID">操作模块ID</param>
    /// <param name="gModuleMainID">操作模块主键</param>
    /// <param name="iOperateID">操作方式ID</param>
    /// /// <param name="sOperateDesc">操作记录</param>
    /// <returns></returns>
    public static bool AddLog(String sOperateID, string sOperate, int iModuleID, Guid gModuleMainID, int iOperateID)
    {
        bool isReturn = false;
        DataEntity.T_OfficeAutomation_Log Log = new DataEntity.T_OfficeAutomation_Log();
        DataAccess.Operate.DA_OfficeAutomation_Log_Operate Log_Operate = new DataAccess.Operate.DA_OfficeAutomation_Log_Operate();

        try
        {
            Log.OfficeAutomation_Log_EmployeeID = sOperateID;
            Log.OfficeAutomation_Log_EmployeeName = sOperate;
            Log.OfficeAutomation_Log_OperateID = iOperateID;
            Log.OfficeAutomation_Log_OperateModuleID = iModuleID;
            Log.OfficeAutomation_Log_OperateModuleMainID = gModuleMainID;
            Log.OfficeAutomation_Log_OperateTime = DateTime.Now;
            Log.OfficeAutomation_Log_OperateDesc = "";

            Log_Operate.Insert(Log);

            isReturn = true;
        }
        catch
        {

        }
        finally
        {
            Log_Operate = null;
        }

        return isReturn;
    }
    #endregion

    #region
    

    #endregion

    //#region 移动设备推送通知

    ///// <summary>
    ///// 推送手机通知审批人 2014-05-21
    ///// </summary>
    ///// <param name="code"></param>
    ///// <param name="documentName"></param>
    //public static void SendDirectPushMessage(string documentName, string code)
    //{
    //    string[] employids = code.Split(',');
    //    for (int n = 0; n < employids.Length; n++)
    //    {
    //        SendDirectPushMessageByEmpCodeAndApplyName(documentName, employids[n]);
    //    }
    //}

    ///// <summary>
    ///// 以工号消息直推
    ///// </summary>
    ///// <param name="applyTableName">申请表中文名</param>
    ///// <param name="empCode">接收员工号</param>
    ///// <returns></returns>
    //public static string SendDirectPushMessageByEmpCodeAndApplyName(string applyTableName, string empCode)
    //{
    //    string jsonData = "{\"table_name\":\"" + applyTableName + "\"}";
    //    return SendDirectPushMessageByEmpCode(jsonData, empCode);
    //}

    ///// <summary>
    ///// 以工号消息直推
    ///// </summary>
    ///// <param name="pushId">mcoa提供的固定推送id</param>
    ///// <param name="jsonData">推送参数json结构</param>
    ///// <param name="empCode">接收员工号</param>
    ///// <returns></returns>
    //public static string SendDirectPushMessageByEmpCode(string jsonData, string empCode)
    //{
    //    MCOAWS.McoaWS ws = new MCOAWS.McoaWS();
    //    if (System.Configuration.ConfigurationSettings.AppSettings["IsTesting"] == "True")
    //        empCode = System.Configuration.ConfigurationSettings.AppSettings["TesterCode"];
    //    string s = ws.SendDirecePushMessageByEmpCode(System.Configuration.ConfigurationSettings.AppSettings["PushID"], jsonData, empCode);
    //    return s;
    //}

    //#endregion

    }
}
