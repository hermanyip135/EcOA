using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataEntity;
using DataAccess.Operate;
//2016921-52100
using System.Text;
using System.Data;
//

/// <summary>
/// FlowCommonMethod 的摘要说明
/// </summary>
public class FlowCommonMethod
{
	public FlowCommonMethod()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 20160328 200idx复审
    /// </summary>
    /// <param name="sug">建议</param>
    /// <param name="flowManager">主管流程</param>
    /// <param name="MainID">主表ID</param>
    /// <param name="EmployeeName">登录人名</param>
    /// <param name="EmployeeID">登录人工号</param>
    /// <param name="sisa">0不同意，1同意，2其他意见</param>
    /// <returns></returns>
    public string Review(string sug, T_OfficeAutomation_Flow flowManager, string MainID, string EmployeeName, string EmployeeID, string sisa,int Idx)
    {
        var IdxH = 220;         //黄生复审默认idx
        if (Idx == 0)
        { 
            Idx = 200;
            IdxH = 220;
        }
        else if (Idx == 20000)
        {
            IdxH = 22000;
        }
        var da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        var flowsa = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, Idx);  //获取200流程

        //建议
        if (!string.IsNullOrEmpty(sug))
        {
            sug = "<p>" + sug + "</p>" +
                "<p style=\"text-align:right\">" + EmployeeName + "（复审）</p>" +
                "<p style=\"text-align:right\">日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</p>";
        }

        if (flowsa == null)
        {
            //流程不存在
            flowsa = new T_OfficeAutomation_Flow();
            //申请人是否是负责人流程中的审核人
            if (flowManager != null && !(flowManager.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && flowManager.OfficeAutomation_Flow_Employee.Contains(EmployeeName)))
            {
                //不是，增加200流程时添加负责人流程的审核
                flowsa.OfficeAutomation_Flow_EmployeeID = EmployeeID + "," + flowManager.OfficeAutomation_Flow_EmployeeID;
                flowsa.OfficeAutomation_Flow_Employee = EmployeeName + "," + flowManager.OfficeAutomation_Flow_Employee;
                flowsa.OfficeAutomation_Flow_Audit = false;
            }
            else
            {
                //是，把负责人添加到审核人
                flowsa.OfficeAutomation_Flow_EmployeeID = EmployeeID;
                flowsa.OfficeAutomation_Flow_Employee = EmployeeName;
                flowsa.OfficeAutomation_Flow_Audit = true;
            }

            flowsa.OfficeAutomation_Flow_MainID = new Guid(MainID);
            flowsa.OfficeAutomation_Flow_Suggestion = sug;
            flowsa.OfficeAutomation_Flow_ID = Guid.NewGuid();
            flowsa.OfficeAutomation_Flow_Idx = Idx;
            flowsa.OfficeAutomation_Flow_Auditor = EmployeeName + "（复审）";
            flowsa.OfficeAutomation_Flow_AuditorID = EmployeeID;
            flowsa.OfficeAutomation_Flow_IsAgree = int.Parse(sisa);
            flowsa.OfficeAutomation_Flow_AuditDate = DateTime.Now;
            da_OfficeAutomation_Flow_Inherit.Add(flowsa);
        }
        else
        {
            //200流程存在
            if (flowsa.OfficeAutomation_Flow_Audit)
            {
                //流程完成(流程已经完成，申请人、flowManager中的审核人可以再次提出复审)
                //用"-----"把上一次的复审分隔
                flowsa.OfficeAutomation_Flow_Suggestion += "<p style=\"margin:10px 0\">--------------------------------------------------------------------------</p>" + sug;
                flowsa.OfficeAutomation_Flow_Auditor = EmployeeName + "（复审）";
                flowsa.OfficeAutomation_Flow_AuditorID = EmployeeID;
                //申请人是否是负责人流程中的审核人
                if (flowManager != null && !(flowManager.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID) && flowManager.OfficeAutomation_Flow_Employee.Contains(EmployeeName)))
                {
                    //不是，增加200流程时添加负责人流程的审核
                    flowsa.OfficeAutomation_Flow_Audit = false;
                }
                else
                {
                    //是，把负责人添加到审核人
                    flowsa.OfficeAutomation_Flow_Audit = true;
                }
                flowsa.OfficeAutomation_Flow_AuditDate = DateTime.Now;
                da_OfficeAutomation_Flow_Inherit.Update(flowsa);
            }
            else
            {
                //流程没有完成
                flowsa.OfficeAutomation_Flow_Suggestion += sug;
                flowsa.OfficeAutomation_Flow_Auditor += "," + EmployeeName + "（复审）";
                flowsa.OfficeAutomation_Flow_AuditorID += "," + EmployeeID;

                //判断流程是否已完成
                flowsa.OfficeAutomation_Flow_Audit = IsAudit(flowsa);
                da_OfficeAutomation_Flow_Inherit.Update(flowsa);
            }
        }

        //黄生复审流程
        var flowsh = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, IdxH);  //获取220流程
        if (flowsh == null)
        {
            flowsh = new T_OfficeAutomation_Flow();
            flowsh.OfficeAutomation_Flow_MainID = new Guid(MainID);
            flowsh.OfficeAutomation_Flow_Suggestion = "";
            flowsh.OfficeAutomation_Flow_ID = Guid.NewGuid();
            flowsh.OfficeAutomation_Flow_EmployeeID = CommonConst.EMP_GENERALMANAGER_ID;
            flowsh.OfficeAutomation_Flow_Employee = CommonConst.EMP_GENERALMANAGER_NAME;
            flowsh.OfficeAutomation_Flow_Idx = IdxH;
            da_OfficeAutomation_Flow_Inherit.Insert(flowsh);
        }
        else
        {
            flowsh.OfficeAutomation_Flow_Audit = false;
            flowsh.OfficeAutomation_Flow_Auditor = "";
            flowsh.OfficeAutomation_Flow_AuditorID = "";

            da_OfficeAutomation_Flow_Inherit.Update(flowsh);
        }
        da_OfficeAutomation_Flow_Inherit.SetNullByMainIDAndAfterIdxs(MainID, IdxH); //M_AlterM：20150826
        da_OfficeAutomation_Main_Inherit.UpdateFlowForCancel(MainID);

        if (sisa == "0")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 5); //添加日志，复审
        else if (sisa == "1")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 4); //添加日志，复审
        else
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 6); //添加日志，复审

        return "0|复审意见已保存";
    }

    /// <summary>
    /// 总经理复审
    /// </summary>
    /// <param name="sug">建议</param>
    public string Review_Manager(string sug, string MainID, string EmployeeName, string EmployeeID, string sisa, int IdxH)
    {
        //if (!string.IsNullOrEmpty(sug))
        //{
        //    sug = sug + "\r\n\r\n 　　　　　　　　　　　　　　　　　　　　　　　　" + EmployeeName + "（复审）"
        //              + "\r\n 　　　　　　　　　　　　　　　　　　　　　　　　日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        //              + "\r\n\r\n----------------------------------------------------------------------------------------------------------------\r\n\r\n"
        //          ;
        //}
        var da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        var da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

        var flowsa = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, IdxH);  //获取220流程

        if (!string.IsNullOrEmpty(sug))
        {
            if (string.IsNullOrEmpty(flowsa.OfficeAutomation_Flow_Suggestion))
            {
                sug = "<p>" + sug + "</p>" +
                     "<p style=\"text-align:right\">" + EmployeeName + "（复审）</p>" +
                     "<p style=\"text-align:right\">日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "<p>";
            }
            else
            {
                sug = "<p style=\"margin:10px 0\">--------------------------------------------------------------------------</p>" +
                       "<p>" + sug + "</p>" +
                       "<p style=\"text-align:right\">" + EmployeeName + "（复审）</p>" +
                       "<p style=\"text-align:right\">" + "日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</p>";
                                     ;
            }
        }

        //220审核人提交建议?
        if (!(flowsa.OfficeAutomation_Flow_Employee.Contains(EmployeeName) && flowsa.OfficeAutomation_Flow_EmployeeID.Contains(EmployeeID)))
        {
            //不是
            return "1|复审意见保存失败";
        }

        flowsa.OfficeAutomation_Flow_Auditor = EmployeeName + "（复审）";
        flowsa.OfficeAutomation_Flow_AuditorID = EmployeeID;
        flowsa.OfficeAutomation_Flow_AuditDate = DateTime.Now;
        flowsa.OfficeAutomation_Flow_Suggestion += sug;
        flowsa.OfficeAutomation_Flow_IsAgree = int.Parse(sisa);
        flowsa.OfficeAutomation_Flow_Audit = IsAudit(flowsa);
        da_OfficeAutomation_Flow_Inherit.Update(flowsa);

        //220流程完成?
        if (flowsa.OfficeAutomation_Flow_Audit)
        {
            //更新main表
            da_OfficeAutomation_Main_Inherit.UpdateWhenFlowEnd(MainID);
        }

        if (sisa == "0")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 5); //添加日志，复审
        else if (sisa == "1")
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 4); //添加日志，复审
        else
            Common.AddLog(EmployeeID, EmployeeName, 3, new Guid(MainID), 6); //添加日志，复审

        return "0|复审意见已保存！";
    }

    private bool IsAudit(T_OfficeAutomation_Flow flow)
    {
        try
        {
            var Auditors = flow.OfficeAutomation_Flow_Auditor;
            var AuditorIDs = flow.OfficeAutomation_Flow_AuditorID;

            var Employees = flow.OfficeAutomation_Flow_Employee.Split(',');
            var EmployeeIDs = flow.OfficeAutomation_Flow_EmployeeID.Split(',');
            //是否所有审核人都签名了
            for (int i = 0; i < Employees.Length; i++)
            {
                if (!Auditors.Contains(Employees[i] + "（复审）") || !AuditorIDs.Contains(EmployeeIDs[i]))
                {
                    //有一个没有签名就返回false
                    return false;
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 删除流程显示的通用方法
    /// </summary>
    /// <param name="MainID">公共主表ID</param>
    public StringBuilder ShowDelFlow(string MainID) 
    {
        StringBuilder SbFlow = new StringBuilder();
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        #region 显示删除流程示意图
        SbFlow.Append("<div class=\"flow\">");
        SbFlow.Append("删除流程:");
        DataSet ds = new DataSet();
        ds = da_OfficeAutomation_Flow_Inherit.SelectAllDeleteFlowsByMID(MainID);
        #region 已删除
        DataRow[] dr = ds.Tables[0].Select("OfficeAutomation_DeletedFlow_AuditorID IS NULL");
        for (int i = 0; i < dr.Length; i++)
        {
            string curemp = dr[i]["OfficeAutomation_DeletedFlow_Employee"].ToString();

            SbFlow.Append("<span class=\"");
            SbFlow.Append("other\">" + curemp + "已确认删除");
            SbFlow.Append("</span>");

            //箭头图片

            SbFlow.Append("<img src=\"/Images/forward.png\" class=\"forward\"/>");
        }
        #endregion
        #region 待删除
        dr = ds.Tables[0].Select("OfficeAutomation_DeletedFlow_AuditorID IS NOT NULL");
        for (int i = 0; i < dr.Length; i++)
        {
            string curemp = dr[i]["OfficeAutomation_DeletedFlow_Employee"].ToString();

            SbFlow.Append("<span class=\"");
            SbFlow.Append("auditing\">待" + curemp + "删除");
            SbFlow.Append("</span>");

            //箭头图片
            if (i != (dr.Length - 1))//如果不是最后一项
            {
                SbFlow.Append("<img src=\"/Images/forward_skip.png\" class=\"forward\"/>");
            }
        }
        #endregion
        SbFlow.Append("</div>");
        #endregion
        return SbFlow;
    }
}