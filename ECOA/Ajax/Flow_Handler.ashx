<%@ WebHandler Language="C#" Class="Flow_Handler" %>

using System;
using System.Web;

using System.Data;

using DataAccess.Operate;
using DataEntity;

public class Flow_Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string action = BasePage.GetFormString("action");

        switch (action)
        {
            case "save":
                SaveFlow(context);
                break;
            case "saveSysReqFlow":
                SaveSysReqFlow(context);
                break;
            case "saveUIReqFlow":
                SaveUIReqFlow(context);
                break;
            case "saveSysPowerFlow":
                SaveSysPowerFlow(context);
                break;
            case "saveScrapFlow":
                SaveScrapFlow(context);
                break;
            case "saveAssetTransferFlow":
                SaveAssetTransferFlow(context);
                break;
            case "saveDealOfficeFlow":
                SaveDealOfficeFlow(context);
                break;
            case "saveITBuyFlow":
                SaveITBuyFlow(context);
                break;
            case "savePersInterestsFlow":
                SavePersInterestsFlow(context);
                break;
            case "saveBuyBuildingFlow":
                SaveBuyBuildingFlow(context);
                break;
            case "saveCarAllowanceFlow":
                SaveCarAllowanceFlow(context);
                break;
            case "saveBackCommFlow":
                SaveBackCommFlow(context);
                break;
            case "saveBadDebtsFlow":
                SaveBadDebtsFlow(context);
                break;
            case "saveReduceCommFlow":
                SaveReduceCommFlow(context);
                break;
            case "saveGMOFlow":
                SaveGMOFlow(context);
                break;
            case "saveCommonFlow":
                SaveCommonFlow(context);
                break;
            case "saveCommonFlow2":
                SaveCommonFlow2(context);
                break;
            case "SaveCommonFlowLogistics":
                SaveCommonFlowLogistics(context);
                break;
            case "SaveCommonTableFlow":
                SaveCommonTableFlow(context);
                break;
            case "SaveCommonFlowLogistics2":
                SaveCommonFlowLogistics2(context);
                break;
            case "SaveOfficialSealFlow":
                SaveOfficialSealFlow(context);
                break;
            case "DeleteFlow":
                DeleteFlow(context);
                break;
            case "saveITSpecialModifyFlow":
                SaveITSpecialModifyFlow(context);
                break;
            case "SaveGroups":
                SaveGroups(context);
                break;
            case "SaveGeneralApplyGroups":
                SaveGeneralApplyGroups(context);
                break;
            case "CancelGroups":
                CancelGroups(context);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 获取员工资料
    /// </summary>
    /// <param name="alIDx"></param>
    /// <param name="idx"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    private static DataSet GetEmployeeInfo(System.Collections.ArrayList alIDx, string idx, string name)
    {
        if (name.Contains("陈洁丽（项目部）"))
            name = name.Replace("陈洁丽（项目部）", "陈洁丽A");
        else if (name.Contains("陈洁丽（法律及客服）"))
            name = name.Replace("陈洁丽（法律及客服）", "陈洁丽");
        wsFinance.Service ws = new wsFinance.Service();
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

        //if (alIDx.Contains(idx))
            return da_Employee_Inherit.GetEmployeeInfoByEmployeeName(name);
        //else
        //    return ws.GetManagesByNames(name);
    }

    /// <summary>
    /// 获取员工资料，并按职级排列
    /// </summary>
    /// <param name="alIDx"></param>
    /// <param name="idx"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    private static DataSet GetEmployeeInfo2(System.Collections.ArrayList alIDx, string idx, string name)
    {
        if (name.Contains("陈洁丽（项目部）"))
            name = name.Replace("陈洁丽（项目部）", "陈洁丽A");
        else if (name.Contains("陈洁丽（法律及客服）"))
            name = name.Replace("陈洁丽（法律及客服）", "陈洁丽");
        wsFinance.Service ws = new wsFinance.Service();
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();

        //if (alIDx.Contains(idx))
        return da_Employee_Inherit.GetEmployeeInfoByEmployeeName2(name);
        //else
        //    return ws.GetManagesByNames(name);
    }

    /// <summary>
    /// 推送手机通知审批人 2014-05-21
    /// </summary>
    /// <param name="code"></param>
    /// <param name="documentName"></param>
    private static void SendDirectPushMessage(string code, string documentName)
    {
        string[] employids = code.Split(',');
        for (int n = 0; n < employids.Length; n++)
        {
            Common.SendDirectPushMessageByEmpCodeAndApplyName(documentName, employids[n]);
        }
    }

    #region 保存IT权限申请表流程
    public void SaveFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string content = BasePage.GetFormString("content");
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (content != "")
                {
                    content = content.Replace("，", ",");
                    string mainid = content.Split('|')[0];
                    string[] flows = content.Split('|')[1].Split(';');

                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_ITPower_Inherit da_OfficeAutomation_Document_ITPower_Inherit = new DA_OfficeAutomation_Document_ITPower_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_ITPower_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                    }
                    catch
                    {
                    }

                    string email, messageBody;

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectIDxByDocumentName("(物业部/工商铺)IT权限申请表");

                    //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in ds.Tables[0].Rows)
                    //    {
                    //        alIDx.Add(dr[0].ToString());
                    //    }
                    //}

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainID(mainid);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch(Exception ee){throw (ee);}
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        email = employnames[x];
                                        messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch(Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }
    #endregion
    /// <summary>
    /// 保存UI设计需求申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveUIReqFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_UIReq_Inherit da_OfficeAutomation_Document_UIReq_Inherit = new DA_OfficeAutomation_Document_UIReq_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_UIReq_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                        DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                        if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                        {
                            context.Response.Write("Conpleted");
                            return;
                        }
                    }
                    catch
                    {
                    }

                    string email, messageBody;

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectIDxByDocumentName("软件系统开发需求申请表");

                    //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in ds.Tables[0].Rows)
                    //    {
                    //        alIDx.Add(dr[0].ToString());
                    //    }
                    //}

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {

                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }

                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        email = employnames[x];
                                        messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存软件系统开发需求申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveSysReqFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_SysReq_Inherit da_OfficeAutomation_Document_SysReq_Inherit = new DA_OfficeAutomation_Document_SysReq_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_SysReq_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    string email, messageBody;

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();
                    
                    //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectIDxByDocumentName("软件系统开发需求申请表");

                    //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in ds.Tables[0].Rows)
                    //    {
                    //        alIDx.Add(dr[0].ToString());
                    //    }
                    //}

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识
                    
                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);
                        
                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {

                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        email = employnames[x];
                                        messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody,mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }


    /// <summary>
    /// 保存软件系统开发需求申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveITSpecialModifyFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_ITSpecialModify_Inherit da_OfficeAutomation_Document_ITSpecialModify_Inherit = new DA_OfficeAutomation_Document_ITSpecialModify_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_ITSpecialModify_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                        DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                        if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                        {
                            context.Response.Write("Conpleted");
                            return;
                        }
                    }
                    catch
                    {
                    }

                    string email, messageBody;

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectIDxByDocumentName("软件系统开发需求申请表");

                    //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in ds.Tables[0].Rows)
                    //    {
                    //        alIDx.Add(dr[0].ToString());
                    //    }
                    //}

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {

                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }

                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        email = employnames[x];
                                        messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存(汇瀚/二级市场/后勤)IT权限申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveSysPowerFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_SysPower_Inherit da_OfficeAutomation_Document_SysPower_Inherit = new DA_OfficeAutomation_Document_SysPower_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_SysPower_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    string email, messageBody;

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectIDxByDocumentName("(汇瀚/二级市场/后勤)IT权限申请表");

                    //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in ds.Tables[0].Rows)
                    //    {
                    //        alIDx.Add(dr[0].ToString());
                    //    }
                    //}
                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainID(mainid);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        email = employnames[x];
                                        messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存报废申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveScrapFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_Scrap_Inherit da_OfficeAutomation_Document_Scrap_Inherit = new DA_OfficeAutomation_Document_Scrap_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_Scrap_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectIDxByDocumentName("报废申请表");

                    //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in ds.Tables[0].Rows)
                    //    {
                    //        alIDx.Add(dr[0].ToString());
                    //    }
                    //}
                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdxs(mainid, "3,4,5,6,7,8");
                        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);
                        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 4);
                        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 5);

                        bool hasSurplusValueNotify = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(mainid, 2) != null;//是否有净值知会函（即是否有财务部经办人流程）
                        
                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                int id = int.Parse(idx);
                                
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = id;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow))//插入流程成功
                                {
                                    if (i == 0)//且为第一条流程
                                    {
                                        Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                        //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                        string email = CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME;
                                        string messageBody = "您好，" + CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }

                                    if (hasSurplusValueNotify)
                                    {
                                        //插入净值知会函流程
                                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = id - 1;
                                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存资产调动表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveAssetTransferFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_AssetTransfer_Inherit da_OfficeAutomation_Document_AssetTransfer_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_AssetTransfer_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectIDxByDocumentName("资产调动表");

                    //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in ds.Tables[0].Rows)
                    //    {
                    //        alIDx.Add(dr[0].ToString());
                    //    }
                    //}
                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 4);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 5);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 6);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 7);
                        
                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string email = CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME;
                                    string messageBody = "您好，" + CommonConst.EMP_ADMINISTRATION_OPERATOR_NAME + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                    Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存成交商铺/写字楼备案申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveDealOfficeFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_DealOffice_Inherit da_OfficeAutomation_Document_DealOffice_Inherit = new DA_OfficeAutomation_Document_DealOffice_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_DealOffice_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectIDxByDocumentName("物业部成交商铺/写字楼备案申请表");

                    //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in ds.Tables[0].Rows)
                    //    {
                    //        alIDx.Add(dr[0].ToString());
                    //    }
                    //}
                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存计算机及相关设备购买申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveITBuyFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_ITBuy_Inherit da_OfficeAutomation_Document_ITBuy_Inherit = new DA_OfficeAutomation_Document_ITBuy_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_ITBuy_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    //ds = da_OfficeAutomation_Document_Flow_Inherit.SelectIDxByDocumentName("计算机及相关设备购买申请表");

                    //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in ds.Tables[0].Rows)
                    //    {
                    //        alIDx.Add(dr[0].ToString());
                    //    }
                    //}
                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存员工个人利益申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SavePersInterestsFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_PersInterests_Inherit da_OfficeAutomation_Document_PersInterests_Inherit = new DA_OfficeAutomation_Document_PersInterests_Inherit();
                    DA_OfficeAutomation_Document_NewPersInterests_Inherit da_OfficeAutomation_Document_NewPersInterests_Inherit = new DA_OfficeAutomation_Document_NewPersInterests_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    string serialNumber;
                    try
                    {
                        ds = da_OfficeAutomation_Document_PersInterests_Inherit.SelectByMainID(mainid);
                        serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    }
                    catch
                    {
                        ds = da_OfficeAutomation_Document_NewPersInterests_Inherit.SelectByMainID(mainid);
                        serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    }
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 4);
                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存员工购租楼宇申报及免佣福利申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveBuyBuildingFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_BuyBuilding_Inherit da_OfficeAutomation_Document_BuyBuilding_Inherit = new DA_OfficeAutomation_Document_BuyBuilding_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_BuyBuilding_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存小汽车津贴申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveCarAllowanceFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_CarAllowance_Inherit da_OfficeAutomation_Document_CarAllowance_Inherit = new DA_OfficeAutomation_Document_CarAllowance_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_CarAllowance_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存退佣申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveBackCommFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_BackComm_Inherit da_OfficeAutomation_Document_BackComm_Inherit = new DA_OfficeAutomation_Document_BackComm_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_BackComm_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存坏账申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveBadDebtsFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                string is3 = BasePage.GetFormString("is3");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_BadDebts_Inherit da_OfficeAutomation_Document_BadDebts_Inherit = new DA_OfficeAutomation_Document_BadDebts_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_BadDebts_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 2);
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);

                        
                        
                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                //如果编辑流程修改了第三步跟进人的话，根据报告编号查找到部门负责人和申请人输入部门查找到的部门负责人一起添加到第三步跟进人

                                string employeeid = code, employeename = name;
                                string empidbyreportid = "", empnamebyreportid = "";
                                //SYSREQ201902251041115241532  统筹区域负责人依然审批，成交区负责人不用审批，同时应收款小组每月会汇总坏账明细发出给成交区负责人
                                //if (idx == "3")
                                //{
                                   
                                //    string reportid = da_OfficeAutomation_Document_BadDebts_Inherit.GetReportIdByMainId(mainid);

                                //    wsFinance.Service wsf = new wsFinance.Service();
                                //    DataSet dsmanager = wsf.fnGetAreaManageByReportNOs(reportid);

                                //    if (dsmanager.Tables[0].Rows.Count > 0)
                                //    {
                                //        //第3步跟进人与成交报告编号查找的部门负责人是否有重复，如果有重复则不添加，反之，则添加
                                //        for (var k = 0; k < dsmanager.Tables[0].Rows.Count; k++)
                                //        {
                                //            string [] arrname = name.Split(',');
                                //            if (dsmanager.Tables[0].Rows[k]["Scale_Employee"].ToString() != "黄轩明")
                                //            {
                                //                if (Array.IndexOf(arrname, dsmanager.Tables[0].Rows[k]["Scale_Employee"].ToString()) == -1)
                                //                {
                                //                    employeeid += "," + dsmanager.Tables[0].Rows[k]["Scale_EmployeeCode"];
                                //                    employeename += "," + dsmanager.Tables[0].Rows[k]["Scale_Employee"];
                                //                }

                                //                empidbyreportid += dsmanager.Tables[0].Rows[k]["Scale_EmployeeCode"] + ",";
                                //                empnamebyreportid += dsmanager.Tables[0].Rows[k]["Scale_Employee"] + ",";
                                //            }
                                //        }
                                //    }

                                //}

                                if (idx == "3" && code.Contains("0001"))
                                {
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = empidbyreportid;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = empnamebyreportid;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                                    T_OfficeAutomation_Flow flows2a = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(mainid, 11);
                                    if (flows2a == null)
                                    {
                                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                                    }
                                }
                                else
                                {


                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = employeeid;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = employeename;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                    if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                    {
                                        Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                        //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }

                                        string[] employnames = name.Split(',');
                                        for (int x = 0; x < employnames.Length; x++)
                                        {
                                            string email = employnames[x];
                                            string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                            Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                        }
                                    }
                                }
                            }
                        }
                        
                        //T_OfficeAutomation_Flow flows2a;//789
                        //flows2a = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(mainid, 3);
                        //if (flows2a.OfficeAutomation_Flow_EmployeeID.Contains("0001"))
                        //{
                        //    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 3);
                            
                            
                        //}
                        //if (is3 == "1")
                        //{
                        //    flows2a = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(mainid, 11);
                        //    if (flows2a == null)
                        //    {
                        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
                        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
                        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                        //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                        //    }
                        //}
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }


    /// <summary>
    /// 保存减佣让佣申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveReduceCommFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Document_ReduceComm_Inherit da_OfficeAutomation_Document_ReduceComm_Inherit = new DA_OfficeAutomation_Document_ReduceComm_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Document_ReduceComm_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }
    /// <summary>
    /// 保存总办5张申请表流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveGMOFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, 1);

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }
                                    
                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存通用流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveCommonFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                string[] deleteidxs = BasePage.GetFormString("deleteidxs").Split('|');
                if (flows.Length > 0 && !string.IsNullOrEmpty(content))
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                        DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                        if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                        {
                            context.Response.Write("Conpleted");
                            return;
                        }
                    }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        foreach (string deleteidx in deleteidxs)
                        {
                            if (!string.IsNullOrEmpty(deleteidx))
                                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, int.Parse(deleteidx));
                        }

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            //ds = GetEmployeeInfo(alIDx, idx, name); 由于市场部内部审批需要按职位顺序，此方法不符合给予注释-52100-2016/10/17
                            ds = GetEmployeeInfo2(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                                //if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                //{
                                //    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                //    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                //    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName);}catch { }

                                //    string[] employnames = name.Split(',');
                                //    for (int x = 0; x < employnames.Length; x++)
                                //    {
                                //        string email = employnames[x];
                                //        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                //        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                //    }
                                //}
                            }
                        }
                        context.Response.Write("success");
                    }
                }
                else
                {
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    foreach (string deleteidx in deleteidxs)
                    {
                        if (!string.IsNullOrEmpty(deleteidx))
                            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, int.Parse(deleteidx));
                    }
                    context.Response.Write("success");
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存通用流程2（同一流程中，姓名按职级排列，职级相同的话同按职位ID排列）
    /// </summary>
    /// <param name="context"></param>
    public void SaveCommonFlow2(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                string[] deleteidxs = BasePage.GetFormString("deleteidxs").Split('|');
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";
                        if (string.IsNullOrEmpty(name))
                        { continue; }
                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);

                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        foreach (string deleteidx in deleteidxs)
                        {
                            if (!string.IsNullOrEmpty(deleteidx))
                                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, int.Parse(deleteidx));
                        }

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo2(alIDx, idx, name); //改

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName); }
                                    //catch { }

                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }







    /// <summary>
    /// 保存后勤增加的流程（同一流程中，姓名按职级排列，并把黄瑛之后的审批流程按deleteidxs增加）
    /// </summary>
    /// <param name="context"></param>
    public void SaveCommonFlowLogistics2(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                string deleteidxs = BasePage.GetFormString("deleteidxs");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);
                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        //foreach (string deleteidx in deleteidxs)
                        //{
                        //    if (!string.IsNullOrEmpty(deleteidx))
                        da_OfficeAutomation_Flow_Inherit.AddByMainIDAndAfterIdxs(mainid, int.Parse(deleteidxs), 800);
                        //}

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo2(alIDx, idx, name); //改

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName); }
                                    //catch { }

                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }
    
    
    
    
    
    
    

    /// <summary>
    /// 保存后勤增加的流程（同一流程中，姓名按职级排列，并删除黄瑛之后的审批流程）
    /// </summary>
    /// <param name="context"></param>
    public void SaveCommonFlowLogistics(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                string deleteidxs = BasePage.GetFormString("deleteidxs");
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                                            }
                    catch
                    {
                    }

                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);
                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        //foreach (string deleteidx in deleteidxs)
                        //{
                        //    if (!string.IsNullOrEmpty(deleteidx))
                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdxs(mainid, int.Parse(deleteidxs));
                        //}

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            
                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo2(alIDx, idx, name); //改

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                if (code == "0001")
                                {
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 131;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                                }
                                else
                                {
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                                }

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName); }
                                    //catch { }

                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }
    
    /// <summary>
    /// 删除相应的流程
    /// </summary>
    /// <param name="context"></param>
    public void DeleteFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            string mainid = BasePage.GetFormString("mainid");
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            string[] deleteidxs = BasePage.GetFormString("deleteidxs").Split('|');
            foreach (string deleteidx in deleteidxs)
            {
                if (!string.IsNullOrEmpty(deleteidx))
                    da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, int.Parse(deleteidx));
            }
            context.Response.Write("success");
        }
        else
            context.Response.Write("NoPower");
    }

    /// <summary>
    /// 保存通用申请表流程（同一流程中，姓名按职级排列，不发文档编码，申请人重复的话不发第一份邮件）
    /// </summary>
    /// <param name="context"></param>
    public void SaveCommonTableFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
          
                string[] deleteidxs = BasePage.GetFormString("deleteidxs").Split('|');
               int flga = int.Parse(BasePage.GetFormString("flga")); 
             
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    try
                    {
                        DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                        if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                        {
                            context.Response.Write("Conpleted");
                            return;
                        }
                    }
                    catch
                    {
                    }
                    try { da_OfficeAutomation_Flow_Inherit.InsertFlowsByAlter(mainid, 10000); }
                    catch { }
                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";

                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo2(alIDx, idx, name); //改
                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds, name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        foreach (string deleteidx in deleteidxs)
                        {
                            if (!string.IsNullOrEmpty(deleteidx))
                                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, int.Parse(deleteidx));
                        }

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo2(alIDx, idx, name); //改

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);
                                
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    try
                                    {
                                        Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                        if (flga == 1)
                                        {
                                            string documentName = BasePage.GetFormString("tablename"); //da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                            //try { 
                                            //    if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")
                                            //    SendDirectPushMessage(code, documentName); }
                                            //catch { }

                                            string[] employnames = name.Split(',');
                                            for (int x = 0; x < employnames.Length; x++)
                                            {
                                                string email = employnames[x];
                                                string messageBody = "您好，" + employnames[x] + "：有一份" + documentName + "需要您审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                                Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                            }
                                        }
                                    }
                                    catch(Exception ee)
                                    {
                                        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdx(mainid, 0);
                                        context.Response.Write(ee);
                                        return;
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }

    

    /// <summary>
    /// 保存公章使用申请表的流程
    /// </summary>
    /// <param name="context"></param>
    public void SaveOfficialSealFlow(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
                string content = BasePage.GetFormString("content").Replace("，", ",");
                string[] flows = content.Split(';');
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                string[] deleteidxs = BasePage.GetFormString("deleteidxs").Split('|');
                if (flows.Length > 0)
                {
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                    DataSet ds = new DataSet();
                    ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
                    string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();

                    try
                    {
                        DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                        if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                        {
                            context.Response.Write("Conpleted");
                            return;
                        }
                    }
                    catch
                    {
                    }
                    
                    System.Collections.ArrayList alIDx = new System.Collections.ArrayList();

                    string idx, name, code;
                    string[] names;
                    bool flag = true;//用于下方逻辑做标识

                    #region 判断流程中人名是否存在，如果不是则该流程不允许保存
                    for (int i = 0; i < flows.Length; i++)
                    {
                        idx = flows[i].Split(':')[0];
                        names = flows[i].Split(':')[1].Split(',');
                        name = "";
                      
                        for (int n = 0; n < names.Length; n++)
                        {
                            name += "'" + names[n] + "',";
                        }

                        name = name.Substring(0, name.Length - 1);
                        ds = GetEmployeeInfo(alIDx, idx, name);
                        //判读是否有潘宇馥
                        ds = IsPYHAudit(ds,name);
                        if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
                        {
                            context.Response.Write("fail");
                            flag = false;
                            break;
                        }
                    }
                    #endregion

                    if (flag)
                    {
                        foreach (string deleteidx in deleteidxs)
                        {
                            if (!string.IsNullOrEmpty(deleteidx))
                                da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(mainid, int.Parse(deleteidx));
                        }

                        for (int i = 0; i < flows.Length; i++)
                        {
                            idx = flows[i].Split(':')[0];
                            names = flows[i].Split(':')[1].Split(',');
                            name = "";

                            for (int n = 0; n < names.Length; n++)
                            {
                                name += "'" + names[n] + "',";
                            }

                            name = name.Substring(0, name.Length - 1);
                            ds = GetEmployeeInfo(alIDx, idx, name);

                            code = "";
                            name = "";
                            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    code += dr["code"].ToString() + ",";
                                    name += dr["employeename"].ToString() + ",";
                                }
                                code = code.Substring(0, code.Length - 1);
                                name = name.Substring(0, name.Length - 1);

                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = code;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = name;
                                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

                                if (da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow) && i == 0)//插入流程成功，且为第一条流程
                                {
                                    Common.AddLog(emid, emname, 3, new Guid(mainid), 2);//添加日志，修改流程

                                    string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
                                    //try { if (System.Configuration.ConfigurationManager.AppSettings["IsPush"] == "True")SendDirectPushMessage(code, documentName); }
                                    //catch { }

                                    string[] employnames = name.Split(',');
                                    for (int x = 0; x < employnames.Length; x++)
                                    {
                                        string email = employnames[x];
                                        string messageBody = "您好，" + employnames[x] + "：您有编号为" + serialNumber + "的" + documentName + "需要您的审批。<br />申请表地址为：" + context.Request.UrlReferrer.ToString().Replace("Flow", "Detail") + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                                        Common.SendMessageEX(true, documentName, email, "请审批", messageBody, messageBody, mainid);
                                    }
                                }
                            }
                        }
                        context.Response.Write("success");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }
    /// <summary>
    /// 通用增加集团审批
    /// </summary>
    /// <param name="context"></param>
    public void SaveGeneralApplyGroups(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");

                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");

                wsFinance.Service ws = new wsFinance.Service();
                T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                string serialNumber = dsgffs.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                DataSet ds = new DataSet();
                try
                {

                    if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                    {
                        context.Response.Write("Conpleted");
                        return;
                    }
                    //if ("1".Equals(dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_IsGroups"].ToString()))
                    //{
                    //    context.Response.Write("Existed");
                    //    return;
                    //}
                }
                catch
                {
                }

                da_OfficeAutomation_Main_Inherit.updateGroups(mainid,"1");
                da_OfficeAutomation_Flow_Inherit.AddGeneralApplyFlow(mainid);
                Common.AddLog(emid, emname, 87, new Guid(mainid), 1);//添加集团审批
                context.Response.Write("success");
            }

            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }
    /// <summary>
    /// 增加集团审批
    /// </summary>
    /// <param name="context"></param>
     public void SaveGroups(HttpContext context)
    {
        string purview = BasePage.GetFormString("purview");
        if (purview.Contains("OA_ITPower_001"))
        {
            try
            {
                string mainid = BasePage.GetFormString("mainid");
        
                string emid = BasePage.GetFormString("id");
                string emname = BasePage.GetFormString("name");
                string idx =  BasePage.GetFormString("idx");
              
                    wsFinance.Service ws = new wsFinance.Service();
                    T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
                    DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
                    DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
                    DataSet dsgffs = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); //20150123：M_EditFlowC
                    string serialNumber = dsgffs.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
                    DataSet ds = new DataSet();
                    try
                    {
                        
                        if (dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"].ToString() == "3")
                        {
                            context.Response.Write("Conpleted");
                            return;
                        }
                        if ("1".Equals(dsgffs.Tables[0].Rows[0]["OfficeAutomation_Main_IsGroups"].ToString() ))
                        {
                           // context.Response.Write("Existed");
                           // return;
                        }
                    }
                    catch
                    {
                    }

                    string email, messageBody;
                    da_OfficeAutomation_Main_Inherit.updateGroups(mainid,"1");
                    T_OfficeAutomation_Flow flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(mainid, int.Parse(idx));
                    if(flows == null)
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(idx);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0001";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄轩明";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                       
                     }
                    //int idx = int.Parse(idx) + 20;
                    T_OfficeAutomation_Flow flows1 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(mainid, 1000);
                    if (flows1 == null)
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(mainid);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 1000;
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "58318";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "梁健菁";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);

                    }
                    Common.AddLog(emid, emname, 87, new Guid(mainid), 1);//添加日志，修改流程
                        context.Response.Write("success");
                    
                }
            
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        else
            context.Response.Write("NoPower");
    }
    /// <summary>
    /// 取消集团审批
    /// </summary>
    /// <param name="context"></param>
     public void CancelGroups(HttpContext context)
     {
         try
         {
             DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
             string mainid = BasePage.GetFormString("mainid");
             string emid = BasePage.GetFormString("id");
             string emname = BasePage.GetFormString("name");
             da_OfficeAutomation_Main_Inherit.updateGroups(mainid, "0");
             Common.AddLog(emid, emname, 87, new Guid(mainid), 3);//添加日志，修改流程
             context.Response.Write("success");
         }
         catch (Exception ex)
         {
             context.Response.Write(ex.Message);
         }
        
     }
    /// <summary>
     /// 判读是否有潘宇馥审核
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="name"></param>
    /// <returns></returns>
     private DataSet IsPYHAudit(DataSet ds,string name)
     {
         bool isPYHAudit = false;//潘宇馥是否可以审核
         if (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) < Convert.ToDateTime("2019-02-01"))
         {
             isPYHAudit = true;
         }
         //判断是否有潘宇馥审核人
         if (name.Contains("潘宇馥") && isPYHAudit == true)
         {
             DataRow dr = ds.Tables[0].NewRow();
             dr["EmployeeName"] = "潘宇馥";
             dr["Code"] = 1909;
             ds.Tables[0].Rows.Add(dr);
         }
         return ds;
     }


    
    
    
    
    
    
    
    
    
    
    
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }
}