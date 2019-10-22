<%@ WebHandler Language="C#" Class="Editor_Flow" %>

using System;
using System.Web;

using System.Data;
using DataAccess.Operate;
using DataEntity;

public class Editor_Flow : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string MainID = context.Request.QueryString["MainID"].ToString();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
        DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
        
        //string[] employnames;
        string email;
        string msnBody;
        //DA_OfficeAutomation_Document_WithdrawShop_Inherit da_OfficeAutomation_Document_WithdrawShop_Inherit = new DA_OfficeAutomation_Document_WithdrawShop_Inherit();
        //DataSet ds = da_OfficeAutomation_Document_WithdrawShop_Inherit.SelectByMainID(MainID); //在不同的表中要修改
        //DataRow drRow = ds.Tables[0].Rows[0];
        string apply = context.Request.QueryString["apply"].ToString();
        string mid = context.Request.QueryString["mid"].ToString();
        //string employname;
        string serialNumber = context.Request.QueryString["serialNumber"].ToString();
        string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(MainID);
        string department = context.Request.QueryString["department"].ToString();
        string applyUrl = context.Request.QueryString["applyUrl"].ToString();
        string gme = "";
        try
        {
            gme = context.Request.QueryString["GME"].ToString();
        }
        catch
        {
            gme = "";
        }
        DataSet dsDelete = new DataSet();
        DataSet dsFlow = new DataSet();
        string dstr, dns, dfs, fstr, delN = "0", Ssame = "", Sdiff = "", Sid = "";
        string[] delss, floss, dnid;
        bool flgf = true, flgd = true; ;
        serialNumber = serialNumber.Replace(",", string.Empty);
        try
        {
            da_OfficeAutomation_Flow_Inherit.DeleteOtherEmailBySMB(serialNumber); //删除多余的邮件
            dsDelete = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlows(MainID);
            dsFlow = da_OfficeAutomation_Flow_Inherit.SelectByMainID(MainID);
            for (int i = 0; i < dsDelete.Tables[0].Rows.Count; i++)
            {
                dstr = dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Auditor"].ToString();
                dns = dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_AuditorID"].ToString();
                fstr = dsFlow.Tables[0].Rows[i]["OfficeAutomation_Flow_Employee"].ToString();
                dfs = dsFlow.Tables[0].Rows[i]["OfficeAutomation_Flow_EmployeeID"].ToString();
                if (gme == "Alt")
                {
                    dstr = "";
                    fstr = "";
                    flgf = false;
                }
                if (dstr != fstr)
                {
                    delss = dstr.Split(',');
                    dnid = dns.Split(',');
                    floss = fstr.Split(',');
                    if (flgf)
                    {
                        foreach (var mk in floss)
                        {
                            if (!dstr.Contains(mk))
                            {
                                Sdiff += mk + ",";
                                delN = dsFlow.Tables[0].Rows[i]["OfficeAutomation_Flow_Idx"].ToString();
                                try
                                {
                                    dsFlow.Tables[0].Rows[i - 1]["OfficeAutomation_Flow_Idx"].ToString();
                                    t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                                    t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 2;
                                    da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);
                                }
                                catch
                                {
                                    t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(MainID);
                                    t_OfficeAutomation_Main.OfficeAutomation_Main_FlowStateID = 1;
                                    da_OfficeAutomation_Main_Inherit.Update(t_OfficeAutomation_Main);
                                    //M_Wrong：在首环节中，添加多人审批人员时审批状态变成1
                                }
                                da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, int.Parse(delN));
                                flgf = false;
                            }
                        }
                        if (flgf)
                        {
                            delN = dsFlow.Tables[0].Rows[i]["OfficeAutomation_Flow_Idx"].ToString();
                            da_OfficeAutomation_Flow_Inherit.UpdateAfterByMainIDAndIdxs(MainID, int.Parse(delN));
                            if (!string.IsNullOrEmpty(documentName) && "电子传真申请".Equals(documentName))//用于电子传真申请
                            {
                                da_OfficeAutomation_Flow_Inherit.UpdateFaxByMainIDAndIdxsAndOther(MainID, int.Parse(dsFlow.Tables[0].Rows[i]["OfficeAutomation_Flow_Idx"].ToString()), fstr, dfs,
                                dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_AuditDate"].ToString(),
                                dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Suggestion"].ToString(),
                                dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Audit"].ToString() == "True" ? "1" : "0",
                                dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_IsAgree"].ToString(),
                                dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_ID"].ToString()
                                );
                            }
                            else
                            {
                           
                            da_OfficeAutomation_Flow_Inherit.UpdateByMainIDAndIdxsAndOther(MainID, int.Parse(dsFlow.Tables[0].Rows[i]["OfficeAutomation_Flow_Idx"].ToString()), fstr, dfs,
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_AuditDate"].ToString(),
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Suggestion"].ToString(),
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Audit"].ToString() == "True" ? "1" : "0",
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_IsAgree"].ToString());
                            }
                                flgf = false;
                            flgd = false;
                        }
                    }
                    foreach (var mj in delss)
                    {
                        if (fstr.Contains(mj))
                        {
                            Ssame += mj + ",";
                        }
                    }
                    foreach (var mi in dnid)
                    {
                        if (dfs.Contains(mi))
                        {
                            Sid += mi + ",";
                        }
                    }
                    if (Ssame != "" && Sid != "" && flgd)
                    {
                        Ssame = Ssame.Remove(Ssame.Length - 1);
                        Sid = Sid.Remove(Sid.Length - 1);
                        da_OfficeAutomation_Flow_Inherit.UpdateByMainIDAndIdxsAndOther(MainID, int.Parse(dsFlow.Tables[0].Rows[i]["OfficeAutomation_Flow_Idx"].ToString()), Ssame, Sid,
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_AuditDate"].ToString(),
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Suggestion"].ToString(),
                            "0",
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_IsAgree"].ToString());
                        Ssame = "";
                        Sid = "";
                    }
                }
                else if (flgf)
                {
                    if (!string.IsNullOrEmpty(documentName) && "电子传真申请".Equals(documentName))//用于电子传真申请
                    {
                         da_OfficeAutomation_Flow_Inherit.UpdateFaxByMainIDAndIdxsAndOther(MainID, int.Parse(dsFlow.Tables[0].Rows[i]["OfficeAutomation_Flow_Idx"].ToString()), dstr, dns,
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_AuditDate"].ToString(),
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Suggestion"].ToString(),
                            "1",
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_IsAgree"].ToString(),
                             dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_ID"].ToString()
                            
                        );
                    }
                    else
                    {
                        da_OfficeAutomation_Flow_Inherit.UpdateByMainIDAndIdxsAndOther(MainID, int.Parse(dsFlow.Tables[0].Rows[i]["OfficeAutomation_Flow_Idx"].ToString()), dstr, dns,
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_AuditDate"].ToString(),
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Suggestion"].ToString(),
                            "1",
                            dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_IsAgree"].ToString());
                    }
                }
                da_OfficeAutomation_Flow_Inherit.UpdateFlowsSuggestion(MainID, dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Idx"].ToString(), dsDelete.Tables[0].Rows[i]["OfficeAutomation_DeletedFlow_Suggestion"].ToString());
            }
            if (Sdiff != "")
            {
                Sdiff = Sdiff.Remove(Sdiff.Length - 1);
                floss = Sdiff.Split(',');
                for (int i2 = 0; i2 < floss.Length; i2++)
                {
                    msnBody = "您好，" + floss[i2] + "：有一份" + department + "，编号为" + serialNumber + "的" + documentName + "需要您审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                    email = floss[i2]; if (email != "")
                        Common.SendMessageEX(true, documentName, email, "有一份申请表需要您审理", msnBody, msnBody,MainID);
                }
            }
        }
        catch
        {
        }
        da_OfficeAutomation_Flow_Inherit.DDeleteFlows(MainID);
        Common.AddLog(mid, apply, 3, new Guid(MainID), 2); //添加日志，修改流程
        context.Response.Write("<script>window.location='" + context.Request.QueryString["Jhref"].ToString() + "'</script>");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}