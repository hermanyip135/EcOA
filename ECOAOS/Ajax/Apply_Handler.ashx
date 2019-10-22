<%@ WebHandler Language="C#" Class="Apply_Handler" %>

using System;
using System.Web;

using System.Text.RegularExpressions;
using System.Data;

using DataAccess.Operate;
using DataEntity;

public class Apply_Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string action = BasePage.GetFormString("action");

        switch (action)
        {
            case "saveitpowerdeal":
                SaveITPowerDeal(context);
                break;
            case "savesysreqfollower":
                SaveSysReqFollower(context);
                break;
            case "savesysreqplantime":
                SaveSysReqPlanTime(context);
                break;
            case "savesyslogistfollower":
                SaveSysLogistFollower(context);
                break;
            case "savesyslogistplantime":
                SaveSysLogistPlanTime(context);
                break;
            case "savesyspowerdeal":
                SaveSysPowerDeal(context);
                break;
            case "savescrapremark":
                SaveScrapRemark(context);
                break;
            case "saveassettransferdetail":
                SaveAssetTransferDetail(context);
                break;
            case "savepersinterestsremark":
                SavePersInterestsRemark(context);
                break;
            case "saveassettransferremark":
                SaveAssetTransferRemark(context);
                break;
            case "sendITBuyEmail":
                SendITBuyEmail(context);
                break;
            case "saveSurplusValueNotify":
                SaveSurplusValueNotify(context);
                break;
            case "signLegalDeal":
                SignLegalDeal(context);
                break;
            case "GetAssetDic":
                GetAssetDic(context);
                break;
            case "UtControl":
                UtControl(context);
                break;
            case "FeasibilityMenberAuto":
                FeasibilityMenberAuto(context);
                break;
            case "reimbursementsituation":          //52100
                ReimbursementSituation(context);
                break;
            case "getchangesNsInfoByApplyID":          //52100
                GetChangesNsInfoByApplyID(context);
                break;
            case "saveITSpecialModifyfollower":
                SaveITSpecialModifyFollower(context);
                break;
            case "saveITSpecialModifyplantime":
                SaveITSpecialModifyPlanTime(context);
                break;    
               
            default:
                break;
        }
    }

    public void FeasibilityMenberAuto(HttpContext context) //20151014
    {
        DA_OfficeAutomation_Document_Feasibility_Menber_Inherit da_OfficeAutomation_Document_Feasibility_Menber_Inherit = new DA_OfficeAutomation_Document_Feasibility_Menber_Inherit();
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Document_Feasibility_Menber_Inherit.FeasibilityMenber_Auto(BasePage.GetFormString("aid"));
        try
        {
            context.Response.Write(
                ds.Tables[0].Rows[0]["EmployeeID"].ToString() + "|"
                + ds.Tables[0].Rows[0]["EmployeeName"].ToString() + "|"
                + ds.Tables[0].Rows[0]["PositionName"].ToString() + "|"
                + ds.Tables[0].Rows[0]["Licensed"].ToString() + "|"
                );
        }
        catch
        {
            context.Response.Write("");
        }
    }

    public void UtControl(HttpContext context) //20150923
    {
        T_OfficeAutomation_Flow flows;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        DA_OfficeAutomation_Document_UtContract_Inherit da_OfficeAutomation_Document_UtContract_Inherit = new DA_OfficeAutomation_Document_UtContract_Inherit();
        DataSet ds = new DataSet();
        string s1 = null, s2 = null, s3 = null, s4 = null, s5 = "", s6 = "",s7 = "",s8 = "";
        string[] as1,as2;
        //try
        //{
            try
            {
                ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectContract(BasePage.GetFormString("i"), BasePage.GetFormString("n")); //先从续约表查找
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectNewProj(BasePage.GetFormString("n")); //再从新盘表查找
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectNewUnderTP(BasePage.GetFormString("n")); //都找不到，就从项目报备中查找
                        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(ds.Tables[0].Rows[0]["OfficeAutomation_Document_UndertakeProj_MainID"].ToString(), 2);
                        s1 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UndertakeProj_ProjectArea"].ToString();
                        s2 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UndertakeProj_ProjectAddress"].ToString();
                        s3 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UndertakeProj_ReportAddress"].ToString();
                        s4 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UndertakeProj_TermsOfMajorIssues"].ToString();
                    }
                    else
                    {
                        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtNewProj_MainID"].ToString(), 2);
                        s1 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtNewProj_ProjectArea"].ToString();
                        s2 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtNewProj_txtProjectAddress"].ToString();
                        s3 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtNewProj_txtReportAddress"].ToString();
                        s4 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtNewProj_TermsOfMajorIssues"].ToString();
                    }
                }
                else
                {
                    //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_MainID"].ToString(), 2);
                    s1 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_ProjectArea"].ToString();
                    s2 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_txtProjectAddress"].ToString();
                    s3 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_txtReportAddress"].ToString();
                    s4 = ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtContract_TermsOfMajorIssues"].ToString();
                }
            }
            catch
            {
            }

            ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectContractAll(BasePage.GetFormString("i"), BasePage.GetFormString("n")); //先从续约表查找
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(ds.Tables[0].Rows[i]["OfficeAutomation_Document_UtContract_MainID"].ToString(), 2);
                try
                {
                    s5 += flows.OfficeAutomation_Flow_EmployeeID + ",";
                    s6 += flows.OfficeAutomation_Flow_Employee + ",";
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(ds.Tables[0].Rows[i]["OfficeAutomation_Document_UtContract_MainID"].ToString(), 3);
                try
                {
                    s5 += flows.OfficeAutomation_Flow_EmployeeID + ",";
                    s6 += flows.OfficeAutomation_Flow_Employee + ",";
                }
                catch
                {
                }
            }
            ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectNewProjAll(BasePage.GetFormString("n")); //再从新盘表查找
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(ds.Tables[0].Rows[0]["OfficeAutomation_Document_UtNewProj_MainID"].ToString(), 2);
                try
                {
                    s5 += flows.OfficeAutomation_Flow_EmployeeID + ",";
                    s6 += flows.OfficeAutomation_Flow_Employee + ",";
                    }
                catch
                {
                }
            }
            ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectNewUnderTPAll(BasePage.GetFormString("n")); //都找不到，就从项目报备中查找
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(ds.Tables[0].Rows[0]["OfficeAutomation_Document_UndertakeProj_MainID"].ToString(), 3);
                try
                {
                    s5 += flows.OfficeAutomation_Flow_EmployeeID + ",";
                    s6 += flows.OfficeAutomation_Flow_Employee + ",";
                    }
                catch
                {
                }
            }
            try
            {
                string sr = BasePage.GetFormString("n");
                sr = sr.Remove(sr.IndexOf('('));
                ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectReportDataAll(sr); //从项目报数中查找
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjRepoData_MainID"].ToString(), 2);
                    try
                    {
                        s5 += flows.OfficeAutomation_Flow_EmployeeID + ",";
                        s6 += flows.OfficeAutomation_Flow_Employee + ",";
                    }
                    catch
                    {
                    }
                }
                ds = da_OfficeAutomation_Document_UtContract_Inherit.SelectLinkReportDataAll(sr); //从项目联动报数中查找
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(ds.Tables[0].Rows[0]["OfficeAutomation_Document_ProjLinkRepoData_MainID"].ToString(), 2);
                    try
                    {
                        s5 += flows.OfficeAutomation_Flow_EmployeeID + ",";
                        s6 += flows.OfficeAutomation_Flow_Employee + ",";
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            try
            {
                s5 = s5.Remove(s5.Length - 1);
                s6 = s6.Remove(s6.Length - 1);
                as1 = s5.Split(',');
                as2 = s6.Split(',');
                for (int i2 = 0; i2 < as1.Length; i2++)
                {
                    //20170614谢旭昀离职，排除谢旭昀
                    if (as1[i2] != "18530")
                    {
                        if (!s7.Contains(as1[i2]))
                            s7 += as1[i2] + ",";
                    }
                }
                for (int i2 = 0; i2 < as2.Length; i2++)
                {
                    //20170614谢旭昀离职，排除谢旭昀
                    if (as2[i2] != "谢旭昀")
                    {
                        if (!s8.Contains(as2[i2]))
                            s8 += as2[i2] + ",";
                    }
                }
                s7 = s7.Remove(s7.Length - 1);
                s8 = s8.Remove(s8.Length - 1);
            }
            catch
            {
                s7 = "";
                s8 = "";
            }
        //}
        //catch
        //{
        //}
        context.Response.Write(s1 + "|" + s2 + "|" + s3 + "|" + s4 + "|" + s7 + "|" + s8);
    }

    public void GetAssetDic(HttpContext context)
    {
        //context.Response.Write("test!!!");
        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
        string s = ws.GetKeyValue("place", BasePage.GetFormString("value"));
        context.Response.Write(s);
    }
 
    public void SaveITPowerDeal(HttpContext context)
    {
        string itpowerid = BasePage.GetFormString("itpowerid");
        string deal = BasePage.GetFormString("deal");
        if (itpowerid != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_ITPower_Inherit da_OfficeAutomation_Document_ITPower_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_ITPower_Inherit();
            context.Response.Write(da_OfficeAutomation_Document_ITPower_Inherit.UpdateDealByID_II(itpowerid, deal) ? "success" : "fail");
        }
        else
            context.Response.Write("fail");
    }

    public void SaveSysReqFollower(HttpContext context)
    {
        string id = BasePage.GetFormString("sysreqid");
        string follower = BasePage.GetFormString("follower");
        string apply = BasePage.GetFormString("apply");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_SysReq_Inherit da_OfficeAutomation_Document_SysReq_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_SysReq_Inherit();
            DataAccess.Operate.DA_Employee_Inherit da_Employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();
            System.Data.DataRow dr = da_OfficeAutomation_Document_SysReq_Inherit.SelectByID(id).Tables[0].Rows[0];

            if (da_OfficeAutomation_Document_SysReq_Inherit.UpdateFollowerByID(id, follower))
            {
                //通知跟进人处理申请表
                string messageBody, email;
                string[] followers = follower.Split(',');
                for (int i = 0; i < followers.Length; i++)
                {
                    if (followers[i] != "")
                    {
                        messageBody = "您好，" + followers[i] + "：您有编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的软件系统开发需求申请需要您来处理，请在查看后填写资讯科技部预计完成时间。申请表地址为"
                           + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "Apply/SysReq/Apply_SysReq_Detail.aspx?MainID=" + dr["OfficeAutomation_Document_SysReq_MainID"].ToString();
                        email = followers[i];
                        Common.SendMessageEX(false, email, "有份软件系统开发需求申请表需要处理", messageBody, messageBody);
                    }
                }

                messageBody = "您好，" + apply + "：您的编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的软件系统开发需求申请，已安排资讯科技部跟进人为：" + follower + "。登陆地址为："
                        + System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString();
                email = apply;
                Common.SendMessageEX(false, email, "软件系统开发需求申请已安排跟进人", messageBody, messageBody);
                
                context.Response.Write("success");
            }
            else
                context.Response.Write("fail");
        }
        else
            context.Response.Write("fail");
    }

    public void SaveSysReqPlanTime(HttpContext context)
    {
        string id = BasePage.GetFormString("sysreqid");
        string planTime = BasePage.GetFormString("plantime");
        string apply = BasePage.GetFormString("apply");
        string follower = BasePage.GetFormString("follower");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_SysReq_Inherit da_OfficeAutomation_Document_SysReq_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_SysReq_Inherit();
            DataAccess.Operate.DA_Employee_Inherit da_Employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();
            System.Data.DataRow dr = da_OfficeAutomation_Document_SysReq_Inherit.SelectByID(id).Tables[0].Rows[0]; 
            
            if (da_OfficeAutomation_Document_SysReq_Inherit.UpdateITPlanTimeByID(id, planTime))
            {
                //通知申请人：跟进人已填写预计完成时间
                string messageBody = "您好，" + apply + "：您的编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的软件系统开发需求申请，资讯科技部跟进人：" 
                    + follower + "，已填写预计完成时间：" + planTime + "。请查看。申请表地址为" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() 
                    + "Apply/SysReq/Apply_SysReq_Detail.aspx?MainID=" + dr["OfficeAutomation_Document_SysReq_MainID"].ToString();
                string email = apply;
                Common.SendMessageEX(false, email, "有份软件系统开发需求申请表已填写预计完成时间", messageBody, messageBody);

                //通知软件组主管：跟进人已填写预计完成时间
                email = CommonConst.EMP_IT_SOFTWARE_MANAGER_NAME;
                messageBody = "您好，" + email + "：编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的软件系统开发需求申请，资讯科技部跟进人："
                    + follower + "，已填写预计完成时间：" + planTime + "。请查看。申请表地址为" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString()
                    + "Apply/SysReq/Apply_SysReq_Detail.aspx?MainID=" + dr["OfficeAutomation_Document_SysReq_MainID"].ToString();
                Common.SendMessageEX(false, email, "有份软件系统开发需求申请表已填写预计完成时间", messageBody, messageBody);
                
                context.Response.Write("success");
            }
            else
                context.Response.Write("fail");
        }
        else
            context.Response.Write("fail");
    }

    public void SaveSysLogistFollower(HttpContext context)
    {
        string id = BasePage.GetFormString("sysreqid");
        string follower = BasePage.GetFormString("follower");
        string apply = BasePage.GetFormString("apply");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_SysLogist_Inherit da_OfficeAutomation_Document_SysLogist_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_SysLogist_Inherit();
            DataAccess.Operate.DA_Employee_Inherit da_Employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();
            System.Data.DataRow dr = da_OfficeAutomation_Document_SysLogist_Inherit.SelectByID(id).Tables[0].Rows[0];

            if (da_OfficeAutomation_Document_SysLogist_Inherit.UpdateFollowerByID(id, follower))
            {
                //通知跟进人处理申请表
                string messageBody, email;
                string[] followers = follower.Split(',');
                for (int i = 0; i < followers.Length; i++)
                {
                    if (followers[i] != "")
                    {
                        messageBody = "您好，" + followers[i] + "：您有编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的申请内容修改申请表需要您来处理，请在查看后填写资讯科技部预计完成时间。申请表地址为"
                           + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "Apply/SysLogist/Apply_SysLogist_Detail.aspx?MainID=" + dr["OfficeAutomation_Document_SysLogist_MainID"].ToString();
                        email = followers[i];
                        Common.SendMessageEX(false, email, "有份申请内容修改申请表需要处理", messageBody, messageBody);
                    }
                }

                messageBody = "您好，" + apply + "：您的编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的申请内容修改申请表，已安排资讯科技部跟进人为：" + follower + "。登陆地址为："
                        + System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString();
                email = apply;
                Common.SendMessageEX(false, email, "申请内容修改申请表已安排跟进人", messageBody, messageBody);

                context.Response.Write("success");
            }
            else
                context.Response.Write("fail");
        }
        else
            context.Response.Write("fail");
    }

    public void SaveSysLogistPlanTime(HttpContext context)
    {
        string id = BasePage.GetFormString("sysreqid");
        string planTime = BasePage.GetFormString("plantime");
        string apply = BasePage.GetFormString("apply");
        string follower = BasePage.GetFormString("follower");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_SysLogist_Inherit da_OfficeAutomation_Document_SysLogist_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_SysLogist_Inherit();
            DataAccess.Operate.DA_Employee_Inherit da_Employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();
            System.Data.DataRow dr = da_OfficeAutomation_Document_SysLogist_Inherit.SelectByID(id).Tables[0].Rows[0];

            if (da_OfficeAutomation_Document_SysLogist_Inherit.UpdateITPlanTimeByID(id, planTime))
            {
                //通知申请人：跟进人已填写预计完成时间
                string messageBody = "您好，" + apply + "：您的编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的申请内容修改申请表，资讯科技部跟进人："
                    + follower + "，已填写预计完成时间：" + planTime + "。请查看。申请表地址为" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString()
                    + "Apply/SysLogist/Apply_SysLogist_Detail.aspx?MainID=" + dr["OfficeAutomation_Document_SysLogist_MainID"].ToString();
                string email = apply;
                Common.SendMessageEX(false, email, "有份申请内容修改申请表已填写预计完成时间", messageBody, messageBody);

                //通知软件组主管：跟进人已填写预计完成时间
                email = CommonConst.EMP_IT_SOFTWARE_MANAGER_NAME;
                messageBody = "您好，" + email + "：编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的申请内容修改申请表，资讯科技部跟进人："
                    + follower + "，已填写预计完成时间：" + planTime + "。请查看。申请表地址为" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString()
                    + "Apply/SysLogist/Apply_SysLogist_Detail.aspx?MainID=" + dr["OfficeAutomation_Document_SysLogist_MainID"].ToString();
                Common.SendMessageEX(false, email, "有份申请内容修改申请表已填写预计完成时间", messageBody, messageBody);

                context.Response.Write("success");
            }
            else
                context.Response.Write("fail");
        }
        else
            context.Response.Write("fail");
    }

    public void SaveSysPowerDeal(HttpContext context)
    {
        string syspowerid = BasePage.GetFormString("syspowerid");
        string deal = BasePage.GetFormString("deal");
        if (syspowerid != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_SysPower_Inherit da_OfficeAutomation_Document_SysPower_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_SysPower_Inherit();
            context.Response.Write(da_OfficeAutomation_Document_SysPower_Inherit.UpdateDealByID(syspowerid, deal) ? "success" : "fail");
        }
        else
            context.Response.Write("fail");
    }

    public void SaveScrapRemark(HttpContext context)
    {
        string id = BasePage.GetFormString("id");
        string remark = BasePage.GetFormString("remark");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Scrap_Inherit();
            //context.Response.Write(da_OfficeAutomation_Document_Scrap_Inherit.AddRemarkByID(id, remark) ? "success" : "fail");
            context.Response.Write(da_OfficeAutomation_Document_Scrap_Inherit.AddRemarkByID_II(id, remark) ? "success" : "fail");
        }
        else
            context.Response.Write("fail");
    }

    public void SaveAssetTransferDetail(HttpContext context)
    {
        T_OfficeAutomation_Document_AssetTransfer_Detail t_OfficeAutomation_Document_AssetTransfer_Detail;
        DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
        DA_Dic_OfficeAutomation_AssetType_Operate da_Dic_OfficeAutomation_AssetType_Operate = new DA_Dic_OfficeAutomation_AssetType_Operate();
        
        string id = BasePage.GetFormString("id");
        string[] details = Regex.Split(BasePage.GetFormString("detail"), "\\|\\|");

        if(details[0]=="")
            context.Response.Write("详细情况为空！");
        else
        {
            //DataSet dsDetail = new DataSet();
            //dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(MainID);
            da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Delete(id);
        
            for (int i = 0; i < details.Length; i++)
            {
                string[] detail = Regex.Split(details[i], "\\@\\@");
                t_OfficeAutomation_Document_AssetTransfer_Detail = new T_OfficeAutomation_Document_AssetTransfer_Detail();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_ID = Guid.NewGuid();
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_MainID = new Guid(id);
                try
                {
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = int.Parse(detail[0]);
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = "";
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = "";
                }
                catch
                {
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetName = detail[0];
                    t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID = 0;

                    //t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = dsDetail.Tables[0].Rows[i]["OfficeAutomation_Document_AssetTransfer_Detail_AssetAID"].ToString();

                    //wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                    //string s = GetAssetPlaceByName(txtImportPlace.Text), t;
                    //s = s.Substring(s.IndexOf(":") + 1, s.IndexOf(",") - s.IndexOf(":") - 1);
                    //t = ws.Adjustment(detail[1], int.Parse(s), 1, txtExportDepartment.Text, txtApplyDate.Text, 1);
                    //if (t.Contains("*"))
                    //    ViewState["AssetWrong"] = t.Replace("*", string.Empty);
                    //t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = t;
                }
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_AssetTag = detail[1];
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Number = detail[2];
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_Model = detail[3];

                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = "";
                t_OfficeAutomation_Document_AssetTransfer_Detail.OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = "";
                
                //context.Response.Write(da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.Insert(t_OfficeAutomation_Document_AssetTransfer_Detail) ? "success" : "fail");
                context.Response.Write("success");
            }
        }
    }

    public void SavePersInterestsRemark(HttpContext context)
    {
        DA_OfficeAutomation_Document_PersInterests_Inherit da_OfficeAutomation_Document_PersInterests_Inherit = new DA_OfficeAutomation_Document_PersInterests_Inherit();
        string id = BasePage.GetFormString("id");
        //string remark = BasePage.GetFormString("remark");
        if (id != "")
        {
            string remark = "√";
            context.Response.Write(da_OfficeAutomation_Document_PersInterests_Inherit.UpdateRemarkByID(id, remark) ? "success" : "fail");
        }
        else
            context.Response.Write("fail");        
    }

    public void SaveAssetTransferRemark(HttpContext context)
    {
        DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
        string id = BasePage.GetFormString("id");
        string remark = BasePage.GetFormString("remark");
        if (id != "")
        {
            context.Response.Write(da_OfficeAutomation_Document_AssetTransfer_Inherit.AddRemarkByID_II(id, remark) ? "success" : "fail");
        }
        else
            context.Response.Write("fail");            
    }

    public void SendITBuyEmail(HttpContext context)
    {
        try
        {
            DA_OfficeAutomation_Document_ITBuy_Inherit da_OfficeAutomation_Document_ITBuy_Inherit = new DA_OfficeAutomation_Document_ITBuy_Inherit();
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            string id = BasePage.GetFormString("id");
            string mainid = BasePage.GetFormString("mainid");
            string remark = BasePage.GetFormString("remark");

            da_OfficeAutomation_Document_ITBuy_Inherit.UpdateRemarkByID(id, remark);
            
            string employname, email, msnBody = "", mailBody = "", title;
            string[] employnames;

            DataSet ds = new DataSet();
            ds = da_OfficeAutomation_Document_ITBuy_Inherit.SelectByMainID(mainid);
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string department = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ITBuy_Department"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
            string applyer = ds.Tables[0].Rows[0]["OfficeAutomation_Document_ITBuy_Apply"].ToString();
            title = "关于" + department + "购买计算机或相关设备的申请";

            ds = da_OfficeAutomation_Flow_Inherit.GetAuditedByMainID(mainid);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string idx = dr["OfficeAutomation_Flow_Idx"].ToString();
                if (idx == "1" || idx == "2" || idx == "3" || idx == "5" || idx == "6" || idx == "9")
                {
                    employname = dr["OfficeAutomation_Flow_Auditor"].ToString();
                    employnames = employname.Split(',');
                    for (int i = 0; i < employnames.Length; i++)
                    {
                        if (employnames[i] != CommonConst.EMP_LOGISTICS_MANAGER_NAME && employnames[i] != "")
                        {
                            msnBody = "您好，" + employnames[i] + "：" + DateTime.Now.ToString("MM月dd日") + "行政部已收到供应商运送来“" + department + "”的" + remark + "，并已通知资讯科技部到货情况，IT设备具体安装时间，请与IT部沟通，谢谢！";
                            email = employnames[i];
                            Common.SendMessageEX(false, email, title, msnBody + mailBody, msnBody);
                        }
                    }
                }
            }

            email = applyer;
            msnBody = "您好，" + email + "：" + DateTime.Now.ToString("MM月dd日") + "行政部已收到供应商运送来“" + department + "”的" + remark + "，并已通知资讯科技部到货情况，IT设备具体安装时间，请与IT部沟通，谢谢！";
            Common.SendMessageEX(false, email, title, msnBody + mailBody, msnBody);
            
            email = CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME;
            msnBody = "您好，" + email + "：" + DateTime.Now.ToString("MM月dd日") + "行政部已收到供应商运送来“" + department + "”的" + remark + "，并已通知资讯科技部到货情况，IT设备具体安装时间，请与IT部沟通，谢谢！";            
            Common.SendMessageEX(false, email, title, msnBody + mailBody, msnBody);

            email = CommonConst.EMP_IT_OPERATOR_NAME;
            msnBody = "您好，" + email + "：" + DateTime.Now.ToString("MM月dd日") + "行政部已收到供应商运送来“" + department + "”的" + remark + "，并已通知资讯科技部到货情况，IT设备具体安装时间，请与IT部沟通，谢谢！";
            Common.SendMessageEX(false, email, title, msnBody + mailBody, msnBody);

            email = "梁锐华";
            msnBody = "您好，" + email + "：" + DateTime.Now.ToString("MM月dd日") + "行政部已收到供应商运送来“" + department + "”的" + remark + "，并已通知资讯科技部到货情况，IT设备具体安装时间，请与IT部沟通，谢谢！";
            Common.SendMessageEX(false, email, title, msnBody + mailBody, msnBody);

            context.Response.Write("success");
        }
        catch
        {
            context.Response.Write("fail");            
        }
    }
    
    public void SaveSurplusValueNotify(HttpContext context)
    {
        string id = BasePage.GetFormString("id");
        string surplusValueNotify = BasePage.GetFormString("surplusValueNotify");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_Scrap_Inherit();
            context.Response.Write(da_OfficeAutomation_Document_Scrap_Inherit.UpdateSurplusValueNotifyByID(id, surplusValueNotify) ? "success" : "fail");
        }
        else
            context.Response.Write("fail");
    }

    public void SignLegalDeal(HttpContext context)
    {
        string id = BasePage.GetFormString("id");
        string remark = BasePage.GetFormString("remark");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_BadDebts_Inherit();
            context.Response.Write(da_OfficeAutomation_Document_BadDebts_Inherit.AddRemarkByID_II(id, remark) ? "success" : "fail");
        }
        else
            context.Response.Write("fail");
    }

    public void ReimbursementSituation(HttpContext context) 
    {
        string id = BasePage.GetFormString("id");
        string amount = BasePage.GetFormString("amount");
        string date = BasePage.GetFormString("date");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_WYRecruit_Operate da_OfficeAutomation_Document_WYRecruit_Operate = new DA_OfficeAutomation_Document_WYRecruit_Operate();
            context.Response.Write(da_OfficeAutomation_Document_WYRecruit_Operate.AddReimbursement(id,amount,date) ? "success" : "fail");
        } else 
        {
            context.Response.Write("fail");
        }
    }

    //根据成交编号查找信息
    public void GetChangesNsInfoByApplyID(HttpContext context)
    {
        string applyID = BasePage.GetFormString("applyid");
        DA_OfficeAutomation_Document_ChangeNS_Inherit changens_Inherit=new DA_OfficeAutomation_Document_ChangeNS_Inherit();
        if (applyID != "")
        {
            DataSet ds = changens_Inherit.GetInfoByApplyID(applyID);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                context.Response.Write(dr["Report_Main_Address"].ToString() + "|"
                    + dr["Report_Detail_Owner1"].ToString() + "|"
                    + dr["Report_Detail_Client1"].ToString() + "|"
                    
                    );
                return;
            }
        }
        context.Response.Write("fail");
    }

    public void SaveITSpecialModifyFollower(HttpContext context)
    {
        string id = BasePage.GetFormString("sysreqid");
        string follower = BasePage.GetFormString("follower");
        string apply = BasePage.GetFormString("apply");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_ITSpecialModify_Inherit da_OfficeAutomation_Document_ITSpecialModify_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_ITSpecialModify_Inherit();
            DataAccess.Operate.DA_Employee_Inherit da_Employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();
            System.Data.DataRow dr = da_OfficeAutomation_Document_ITSpecialModify_Inherit.SelectByID(id).Tables[0].Rows[0];

            if (da_OfficeAutomation_Document_ITSpecialModify_Inherit.UpdateFollowerByID(id, follower))
            {
                //通知跟进人处理申请表
                string messageBody, email;
                string[] followers = follower.Split(',');
                for (int i = 0; i < followers.Length; i++)
                {
                    if (followers[i] != "")
                    {
                        messageBody = "您好，" + followers[i] + "：您有编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的软件系统特殊修改申请需要您来处理，请在查看后填写资讯科技部预计完成时间。申请表地址为"
                           + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString() + "Apply/SysReq/Apply_SysReq_Detail.aspx?MainID=" + dr["OfficeAutomation_Document_ITSpecialModify_MainID"].ToString();
                        email = followers[i];
                        Common.SendMessageEX(false, email, "有份软件系统特殊修改申请表需要处理", messageBody, messageBody);
                    }
                }

                messageBody = "您好，" + apply + "：您的编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的软件系统特殊修改申请，已安排资讯科技部跟进人为：" + follower + "。登陆地址为："
                        + System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString();
                email = apply;
                Common.SendMessageEX(false, email, "软件系统特殊修改申请已安排跟进人", messageBody, messageBody);

                context.Response.Write("success");
            }
            else
                context.Response.Write("fail");
        }
        else
            context.Response.Write("fail");
    }

    public void SaveITSpecialModifyPlanTime(HttpContext context)
    {
        string id = BasePage.GetFormString("sysreqid");
        string planTime = BasePage.GetFormString("plantime");
        string apply = BasePage.GetFormString("apply");
        string follower = BasePage.GetFormString("follower");
        if (id != "")
        {
            DataAccess.Operate.DA_OfficeAutomation_Document_ITSpecialModify_Inherit da_OfficeAutomation_Document_ITSpecialModify_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Document_ITSpecialModify_Inherit();
            DataAccess.Operate.DA_Employee_Inherit da_Employee_Inherit = new DataAccess.Operate.DA_Employee_Inherit();
            System.Data.DataRow dr = da_OfficeAutomation_Document_ITSpecialModify_Inherit.SelectByID(id).Tables[0].Rows[0];

            if (da_OfficeAutomation_Document_ITSpecialModify_Inherit.UpdateITPlanTimeByID(id, planTime))
            {
                //通知申请人：跟进人已填写预计完成时间
                string messageBody = "您好，" + apply + "：您的编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的软件系统开发需求申请，资讯科技部跟进人："
                    + follower + "，已填写预计完成时间：" + planTime + "。请查看。申请表地址为" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString()
                    + "Apply/SysReq/Apply_SysReq_Detail.aspx?MainID=" + dr["OfficeAutomation_Document_ITSpecialModify_MainID"].ToString();
                string email = apply;
                Common.SendMessageEX(false, email, "有份软件系统开发需求申请表已填写预计完成时间", messageBody, messageBody);

                //通知软件组主管：跟进人已填写预计完成时间
                email = CommonConst.EMP_IT_SOFTWARE_MANAGER_NAME;
                messageBody = "您好，" + email + "：编号为" + dr["OfficeAutomation_SerialNumber"].ToString() + "的软件系统开发需求申请，资讯科技部跟进人："
                    + follower + "，已填写预计完成时间：" + planTime + "。请查看。申请表地址为" + System.Configuration.ConfigurationManager.AppSettings["URL"].ToString()
                    + "Apply/SysReq/Apply_SysReq_Detail.aspx?MainID=" + dr["OfficeAutomation_Document_ITSpecialModify_MainID"].ToString();
                Common.SendMessageEX(false, email, "有份软件系统开发需求申请表已填写预计完成时间", messageBody, messageBody);

                context.Response.Write("success");
            }
            else
                context.Response.Write("fail");
        }
        else
            context.Response.Write("fail");
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }
}