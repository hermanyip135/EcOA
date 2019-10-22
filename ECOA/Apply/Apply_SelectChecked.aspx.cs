using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using DataAccess.Operate;
using DataEntity;
using System.Data;
using System.Text;

public partial class Apply_SelectChecked : BasePage
{
    #region Page_Load
    public string mains;
    public string applytype;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //mainid = Request.QueryString["mainID"].ToString();
            //Request.QueryString["empid"].ToString();
            //Request.QueryString["empname"].ToString();
        }
        mains = Request.QueryString["mainID"].ToString();
        applytype = Request.QueryString["ApplyType"].ToString();
    }

    #endregion

    protected void btnAgreeD_Click(object sender, EventArgs e)
    {
        string[] mids = mains.Split(',');
        foreach (string mainid in mids)
        {
            //RunJS("alert('*" + mainid + "*');");

            #region 审批
            DataSet dsg = new DataSet(); //20150105：M_DeleteC
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_InheritDelete = new DA_OfficeAutomation_Main_Inherit();
            dsg = da_OfficeAutomation_Main_InheritDelete.SelectByMainID(mainid);
            if (dsg.Tables[0].Rows[0]["OfficeAutomation_Main_WillDelete"].ToString() == "True")
            {
                RunJS("alert('有一份表即将被删除，暂停签名、撤销及修改等操作');");
                continue;
            }
            DA_OfficeAutomation_Document_CommissionOfMonth_Inherit da_OfficeAutomation_Document_CommissionOfMonth_Inherit = new DA_OfficeAutomation_Document_CommissionOfMonth_Inherit();
            DA_OfficeAutomation_Document_HousingFundChange_Operate da_OfficeAutomation_Document_HousingFundChange_Operate = new DA_OfficeAutomation_Document_HousingFundChange_Operate();
            DA_OfficeAutomation_Document_HousingFundAdjustment_Operate da_OfficeAutomation_Document_HousingFundAdjust_Operate = new DA_OfficeAutomation_Document_HousingFundAdjustment_Operate();
            DA_OfficeAutomation_Document_HousingFundBaseAdjust_Operate da_OfficeAutomation_Document_HousingFundBaseAdjust_Operate = new DA_OfficeAutomation_Document_HousingFundBaseAdjust_Operate();
            DataSet ds=new DataSet();
            if (applytype == "42")
            {
                ds = da_OfficeAutomation_Document_CommissionOfMonth_Inherit.SelectByMainID(mainid);
            }
            else if (applytype == "80")
            {
                ds = da_OfficeAutomation_Document_HousingFundChange_Operate.SelectByMainID(mainid);
            }
            else if (applytype == "84")
            {
                ds = da_OfficeAutomation_Document_HousingFundAdjust_Operate.SelectByMainID(mainid);
            }
            else if (applytype == "95")
            {
                ds = da_OfficeAutomation_Document_HousingFundBaseAdjust_Operate.SelectByMainID(mainid);
            }
            DataRow drRow = ds.Tables[0].Rows[0];
           // ID = drRow["OfficeAutomation_Document_CommissionOfMonth_ID"].ToString();

            string flowIDx = "0";
            string signEmployeeName = EmployeeName;
            string signEmployeeId = EmployeeID;

            if (Purview.Contains("OA_ITPower_002"))
            {
                try
                {
                    if (!CheckGIFIsExist(EmployeeID))
                    {
                        RunJS("alert('" + CommonConst.MSG_NO_SIGNIMAGE + "');window.returnValue='fail';window.close();");
                        return;
                    }

                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DataSet dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(mainid);
                    DataRowCollection drc = dsFlow.Tables[0].Rows;
                    for (int i = 0; i < drc.Count; i++)
                    {
                        if (drc[i]["OfficeAutomation_Flow_Audit"].ToString() == "False")
                        {
                            if (i > 0 && drc[i - 1]["OfficeAutomation_Flow_Audit"].ToString() == "False")
                            {
                                RunJS("alert('有一份表的审批环节已被撤销，需稍后再审。');");
                                continue;
                            }
                            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                            //当前用户为流程中某环节的审核人之一或为代理人且之前都审核通过或未开始审核的，则显示该环节的签名按钮
                            string haveSignPowerEmployee = da_OfficeAutomation_Agent_Inherit.HaveSignPowerEmployee(drc[i]["OfficeAutomation_Flow_Employee"].ToString(), drc[i]["OfficeAutomation_Flow_EmployeeID"].ToString(), EmployeeName, EmployeeID);
                            if (haveSignPowerEmployee != null)
                            {
                                flowIDx = drc[i]["OfficeAutomation_Flow_IDx"].ToString();
                                signEmployeeName = haveSignPowerEmployee.Split('|')[0];
                                signEmployeeId = haveSignPowerEmployee.Split('|')[1];
                                break;
                            }
                        }
                    }

                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

                    //如果为第0步流程则为其一审核即可通过，其他为同时审核。
                    string isagree = "0";
                    if (rdbIsNoAgree1.Checked)
                        isagree = "1";
                    //目前是单人审批，扩展时需修改
                    bool isSignSuccess = da_OfficeAutomation_Flow_Inherit.UpdateContainIsAgreeForSign(mainid, signEmployeeId, signEmployeeName, txtDeleteMessage.Text, flowIDx, isagree);

                    if (isSignSuccess)
                    {
                        string[] employnames;
                        string email;
                        string msnBody, mailBody="", apply="", department="", applyUrl = "";
                        StringBuilder sbMailBody = new StringBuilder();

                        if (applytype == "42")
                        {
                            apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_CommissionOfMonth_Apply"].ToString();
                            department = drRow["OfficeAutomation_Document_CommissionOfMonth_Department"].ToString();
                            applyUrl = "/Apply/CommissionOfMonth/Apply_CommissionOfMonth_Detail.aspx?MainID=" + mainid + "&dep=&apply=&start=&end=&type=42&state=&ctype=0&curpage=0&serialnumber=&keyword=";

                            sbMailBody.Append("<br/><br/>填写人：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Apply"]);
                            sbMailBody.Append("<br/>填写日期：" + drRow["OfficeAutomation_Document_CommissionOfMonth_ApplyDate"]);
                            sbMailBody.Append("<br/>现任职部门：" + DateTime.Parse(drRow["OfficeAutomation_Document_CommissionOfMonth_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                            sbMailBody.Append("<br/>发文编号：" + drRow["OfficeAutomation_Document_CommissionOfMonth_ApplyID"]);
                            sbMailBody.Append("<br/>姓名：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Name"]);
                            sbMailBody.Append("<br/>工号：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Code"]);

                            sbMailBody.Append("<br/>入职日期：" + drRow["OfficeAutomation_Document_CommissionOfMonth_EnterDate"]);
                            sbMailBody.Append("<br/>现职位：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Position"]);
                            sbMailBody.Append("<br/>担任职位：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Position"]);
                            sbMailBody.Append("<br/>现职级：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Rank"]);
                            sbMailBody.Append("<br/>预估本月实收业绩及解HOLD佣实收业绩：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Results"]);
                            sbMailBody.Append("<br/>备注：" + drRow["OfficeAutomation_Document_CommissionOfMonth_Describe"]);

                        }
                        else if (applytype == "80")
                        {
                            apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_HousingFundChange_Apply"].ToString();
                            department = drRow["OfficeAutomation_Document_HousingFundChange_Department"].ToString();
                            applyUrl = "/Apply/HousingFundChange/Apply_HousingFundChange_Detail.aspx?MainID=" + mainid + "&dep=&apply=&start=&end=&type=80&state=&ctype=0&curpage=0&serialnumber=&keyword=";

                            sbMailBody.Append("<br/><br/>填写人：" + drRow["OfficeAutomation_Document_HousingFundChange_Apply"]);
                            sbMailBody.Append("<br/>申请表：公积金特殊申请表");
                            sbMailBody.Append("<br/>填写日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_HousingFundChange_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                            sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_HousingFundChange_Department"].ToString());

                        }
                        else if (applytype == "84")
                        {
                            apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_HousingFundAdjustment_Apply"].ToString();
                            department = drRow["OfficeAutomation_Document_HousingFundAdjustment_Department"].ToString();
                            applyUrl = "/Apply/HousingFundChange/Apply_HousingFundAdjustment_Detail.aspx?MainID=" + mainid + "&dep=&apply=&start=&end=&type=80&state=&ctype=0&curpage=0&serialnumber=&keyword=";

                            sbMailBody.Append("<br/><br/>填写人：" + drRow["OfficeAutomation_Document_HousingFundAdjustment_Apply"]);
                            sbMailBody.Append("<br/>申请表：公积金缴存比例年度调整申请表");
                            sbMailBody.Append("<br/>填写日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_HousingFundAdjustment_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                            sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_HousingFundAdjustment_Department"].ToString());

                        }
                        else if (applytype == "95")
                        {
                            apply = ds.Tables[0].Rows[0]["OfficeAutomation_Document_HousingFundBaseAdjust_Apply"].ToString();
                            department = drRow["OfficeAutomation_Document_HousingFundBaseAdjust_Department"].ToString();
                            applyUrl = "/Apply/HousingFundChange/Apply_HousingFundBaseAdjust_Detail.aspx?MainID=" + mainid + "&dep=&apply=&start=&end=&type=80&state=&ctype=0&curpage=0&serialnumber=&keyword=";

                            sbMailBody.Append("<br/><br/>填写人：" + drRow["OfficeAutomation_Document_HousingFundBaseAdjust_Apply"]);
                            sbMailBody.Append("<br/>申请表：公积金缴存比例年度调整申请表");
                            sbMailBody.Append("<br/>填写日期：" + DateTime.Parse(drRow["OfficeAutomation_Document_HousingFundBaseAdjust_ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                            sbMailBody.Append("<br/>申请部门：" + drRow["OfficeAutomation_Document_HousingFundBaseAdjust_Department"].ToString());

                        }
                         
                        string employname;
                        string serialNumber = drRow["OfficeAutomation_SerialNumber"].ToString();
                        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                         
                        //string applyUrl = Page.Request.Url.ToString();
                       
                        applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
                        applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                            //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

                        //通知已审批的人员，邮件中附带申请资料。
                        
                        

                        sbMailBody.Append("<br/><br/>");

                        mailBody = sbMailBody.ToString();

                        if (rdbIsNoAgree1.Checked)//同意或其他意见
                        {
                            Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(mainid), 4);//添加日志，签名同意

                            //判断审批流程是否完成,通知相应人员
                            if (da_OfficeAutomation_Flow_Inherit.IsFlowComplete(mainid))
                            {
                                //审批流程完成，通知申请人
                                msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                email = apply;
                                //if (hdIsAgree.Value == "2")
                                //    Common.SendMessageEX(false, email, "其他意见", msnBody, msnBody);
                                //else
                                Common.SendMessageEX(false, email, "申请已同意", msnBody, msnBody);

                                string employeeList = "";//该字段用于防止重复发送
                                foreach (DataRow dr in dsFlow.Tables[0].Rows)
                                {
                                    employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                                    employnames = employname.Split(',');
                                    for (int i = 0; i < employnames.Length; i++)
                                    {
                                        if (!employeeList.Contains(employnames[i]))
                                        {
                                            msnBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "已通过所有人的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                            email = employnames[i];
                                            //if (hdIsAgree.Value == "2")
                                            //    Common.SendMessageEX(false, email, "其他意见", msnBody + mailBody, msnBody);
                                            //else
                                            Common.SendMessageEX(false, email, "申请已同意", msnBody + mailBody, msnBody);

                                            employeeList += employnames[i] + "||";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //通知申请人
                                msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                email = apply;
                                Common.SendMessageEX(false, email, "申请已通过" + EmployeeName + "的审理", msnBody, msnBody);

                                //通知下一步需要审批的人员
                                employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
                                if (!employname.Contains(EmployeeName))
                                {
                                    employnames = employname.Split(',');
                                    for (int i = 0; i < employnames.Length; i++)
                                    {
                                        email = employnames[i];
                                        msnBody = "您好，" + employnames[i] + "：您有" + department
                                            + "，编号为" + serialNumber + "的" + documentName + "需要您的审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审理", msnBody + mailBody, msnBody,mainid);
                                    }
                                }
                            }

                            //RunJS("alert('审批成功！');window.location='" + Page.Request.Url + "'");
                        }
                        else //不同意
                        {
                            Common.AddLog(EmployeeID, EmployeeName, 2, new Guid(mainid), 5);//添加日志，签名不同意

                            //通知申请人
                            msnBody = "您好，" + apply + "：您的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + txtDeleteMessage.Text + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            email = apply;
                            Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", msnBody, msnBody);

                            //通知已审批的人员
                            ds = da_OfficeAutomation_Flow_Inherit.SelectByMainID(mainid);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                                employnames = employname.Split(',');
                                for (int i = 0; i < employnames.Length; i++)
                                {
                                    msnBody = "您好，" + employnames[i] + "：您审理过的编号为" + serialNumber + "的" + documentName + "未通过" + signEmployeeName + "的审理。不同意的理由是：" + txtDeleteMessage.Text + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    email = employnames[i];
                                    Common.SendMessageEX(false, email, "申请未通过" + signEmployeeName + "的审理", msnBody + mailBody, msnBody);
                                }
                            }

                            //if (EmployeeID == "0001") //抄送到总办
                            //{
                            //    string sagree = "";
                            //    if (hdSuggestion.Value != "")
                            //        sagree = "<br/>" + signEmployeeName + "的意见：" + hdSuggestion.Value;

                            //    employname = CommonConst.EMP_GMO_NAME;
                            //    employnames = employname.Split(',');
                            //    for (int i = 0; i < employnames.Length; i++)
                            //    {
                            //        msnBody = "您好，" + employnames[i] + "：" + department + "的编号为" + serialNumber + "的" + documentName + "已通过" + signEmployeeName + "的审理。" + sagree + "<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                            //        email = employnames[i];
                            //        Common.SendMessageEX(false, email, "申请不同意", msnBody + mailBody, msnBody);
                            //    }
                            //} //总办

                        }
                    }
                }
                catch
                {
                    RunJS("alert('审理失败！');window.returnValue='fail';window.close();");
                    return;
                }
            }
            else
            {
                RunJS("alert('未开通审核权限！');window.returnValue='fail';window.close();");
                return;
            }
            #endregion
        }
        RunJS("alert('已审批完成！');window.returnValue='success';window.close();");
    }
    protected void btnNotAgreeD_Click(object sender, EventArgs e)
    {
         RunJS("window.returnValue='Back';window.close();");
    }
}
