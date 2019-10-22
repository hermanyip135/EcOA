using DataAccess.Operate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using DataEntity.DTO;

/// <summary>
/// SignClass 签名相关的方法
/// </summary>
public class SignClass
{
    private string _empID;
    private string _empName;
    private List<AgentDto> _agents;
    /// <summary>
    /// 
    /// </summary>
    public SignClass(UserInfo user)
    {
        if (user == null)
            throw new Exception("SignClass:Init Error:User can't null");
        _empID = user.EmpID;
        _empName = user.EmpName;
        
        if (user.Agents != null && user.Agents.Count() > 0)
        {
            _agents = new List<AgentDto>();
            foreach (var a in user.Agents)
            {
                _agents.Add(new AgentDto { 
                    AgentEmpID = a.AgentEmpID,
                    AgentEmpName = a.AgentEmpName
                });
            }
        }
    }

    public SignResult Sign(SignDto dto)
    {
        SignResult result = new SignResult();
        result.Flag = true;
        result.Message = "";
        result.SignAllComplete = false;

        if (!CheckGIFIsExist(_empID))
        {
            //没有电子签名图片（CheckGiFIsExist最好重写（通过HTTP协议访问效率没有直接物理访问好））
            result.Flag = false;
            result.Message = CommonConst.MSG_NO_SIGNIMAGE;
            return result;
        }

        DA_OfficeAutomation_Main_Inherit MainBLL = new DA_OfficeAutomation_Main_Inherit();
        var MainObj = MainBLL.GetModel("OfficeAutomation_Main_ID='" + dto.ReportMainID + "'");
        if (MainObj.OfficeAutomation_Main_WillDelete)
        {
            result.Flag = false;
            result.Message = "该表即将被删除，暂停签名、撤销及修改等操作";
            return result;
        }
        if (MainObj.OfficeAutomation_Main_IsDelete)
        {
            result.Flag = false;
            result.Message = "该表已被删除不能再签名";
            return result;
        }

        DA_OfficeAutomation_Flow_Inherit FlowBLL = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsFlow = FlowBLL.SelectByMainID(dto.ReportMainID.ToString());
        var flows = FlowBLL.GetFlowList(dsFlow);

        //当前审批流之前是否有流程未审批的
        if (flows.Exists(m => m.OfficeAutomation_Flow_Idx < dto.Idx && m.OfficeAutomation_Flow_Audit == false))
        {
            result.Flag = false;
            result.Message = "您之前的审批环节已被撤销，请稍后再审";
            return result;
        }
        var signflow = flows.Find(m => m.OfficeAutomation_Flow_Idx == dto.Idx);
        if (signflow.OfficeAutomation_Flow_Audit)
        {
            result.Flag = false;
            result.Message = "当前审批流已完成审核，不需再审";
            return result;
        }

        string signEmpName = _empName;  //签名人的姓名
        string signEmpId = _empID;      //签名人的工号
        bool canAudit = false;
        if ((signflow.OfficeAutomation_Flow_Employee + ",").Contains(_empName + ",") && (signflow.OfficeAutomation_Flow_EmployeeID + ",").Contains(_empID + ","))
        {
            //当前审批流包含审批人
            canAudit = true;
        }
        else
        {
            //审批流不含当前审批人，看是否代理人
            if (_agents.Count > 0)
            {
                foreach (var a in _agents)
                {
                    if ((signflow.OfficeAutomation_Flow_Employee + ",").Contains(a.AgentEmpName + ",") && (signflow.OfficeAutomation_Flow_EmployeeID + ",").Contains(a.AgentEmpID + ","))
                    {
                        signEmpName = a.AgentEmpName;   //使用代理人的姓名及工号去签名
                        signEmpId = a.AgentEmpID;       //使用代理人的姓名及工号去签名
                        canAudit = true;
                        break;
                    }
                }
            }
        }
        if (!canAudit)
        {
            result.Flag = false;
            result.Message = "该环节你不用签名";
            return result;
        }

        //判断审批人是否已审核（审核人已签名，但还需要其他人签）
        if (!string.IsNullOrEmpty(signflow.OfficeAutomation_Flow_Auditor) && !string.IsNullOrEmpty(signflow.OfficeAutomation_Flow_AuditorID))
        {
            if ((signflow.OfficeAutomation_Flow_Auditor + ",").Contains(_empName + ",") && (signflow.OfficeAutomation_Flow_AuditorID + ",").Contains(_empID + ","))
            {
                result.Flag = false;
                result.Message = "你已经签名无需再签";
                return result;
            }
            //判断代理人是否已签名
            if (_agents != null && _agents.Count > 0)
            {
                foreach (var a in _agents)
                {
                    if ((signflow.OfficeAutomation_Flow_Auditor + ",").Contains(a.AgentEmpName + ",") && (signflow.OfficeAutomation_Flow_AuditorID + ",").Contains(a.AgentEmpID + ","))
                    {
                        result.Flag = false;
                        result.Message = "你的代理人已经签名无需再签";
                        return result;
                    }
                }
            }
        }

        //签名
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        int flowstateId = 2;
        string employeeidsum = "";
        string employeenamesum = "";

        result.SignEmpName = signEmpName;
        result.SignEmpID = signEmpId;

        if (dto.IsSingle)
        {
            //单人审核
            int lastflow = 0;

            //update flows
            for (int i = 0; i < flows.Count(); i++)
            {
                if (flows[i].OfficeAutomation_Flow_Idx == dto.Idx)
                {
                    flows[i].OfficeAutomation_Flow_Audit = true;
                    flows[i].OfficeAutomation_Flow_AuditDate = DateTime.Now;
                    flows[i].OfficeAutomation_Flow_Auditor = signEmpName;
                    flows[i].OfficeAutomation_Flow_AuditorID = signEmpId;
                    flows[i].OfficeAutomation_Flow_IsAgree = dto.IsAgree;
                }

                if (flows[i].OfficeAutomation_Flow_Audit)
                    result.CompleteFlows.Add(flows[i]);     //插入已完成列表
                else
                    result.NotCompleteFlows.Add(flows[i]);  //插入未完成列表

                if (i == flows.Count - 1)
                    lastflow = flows[i].OfficeAutomation_Flow_Idx;  //获取最后一步idx

                //去重
                if (!(employeeidsum + ",").Contains(flows[i].OfficeAutomation_Flow_AuditorID + ",") && !(employeenamesum + ",").Contains(flows[i].OfficeAutomation_Flow_Auditor + ","))
                {
                    employeeidsum += flows[i].OfficeAutomation_Flow_AuditorID + ",";
                    employeenamesum += flows[i].OfficeAutomation_Flow_Auditor + ",";
                }
            }
            //流程为最后一步
            if (lastflow == dto.Idx)
            {
                flowstateId = 3;                //主表审核状态
                result.SignAllComplete = true;  //最后一步流程
            }
            else
            {
                //审批流未走完,主表OfficeAutomation_Main_AuditorIDsSum、OfficeAutomation_Main_AuditorNamesSum值为null
                employeeidsum = null;
                employeenamesum = null;
            }

            FlowBLL.UpdateContainIsAgreeForSignNew(dto.ReportMainID.ToString(), signEmpId, signEmpName, dto.Suggestion, dto.Idx.ToString(), dto.IsAgree.ToString(), signflow.OfficeAutomation_Flow_ID.ToString(), flowstateId, employeeidsum, employeenamesum);
        }
        else
        {
            //多人审核
            int lastflow = 0;
            int islastemp = 0;
            //update flows
            for (int i = 0; i < flows.Count(); i++)
            {
                if (flows[i].OfficeAutomation_Flow_Idx == dto.Idx)
                {
                    flows[i].OfficeAutomation_Flow_AuditDate = DateTime.Now;
                    flows[i].OfficeAutomation_Flow_IsAgree = dto.IsAgree;

                    int auditorCount = 0;       //已审核次数
                    if (!string.IsNullOrEmpty(flows[i].OfficeAutomation_Flow_AuditorID))
                    {
                        var splitids = flows[i].OfficeAutomation_Flow_AuditorID.Split(',');
                        auditorCount = splitids.Count();
                    }

                    int count = flows[i].OfficeAutomation_Flow_Employee.Split(',').Count();     //待审核次数
                    if (count - auditorCount == 1)
                    {
                        flows[i].OfficeAutomation_Flow_Audit = true;
                        islastemp = 1;
                    }

                    if (string.IsNullOrEmpty(flows[i].OfficeAutomation_Flow_Auditor))
                    {
                        flows[i].OfficeAutomation_Flow_Auditor = signEmpName;
                        flows[i].OfficeAutomation_Flow_AuditorID = signEmpId;
                    }
                    else
                    {
                        flows[i].OfficeAutomation_Flow_Auditor += "," + signEmpName;
                        flows[i].OfficeAutomation_Flow_AuditorID += "," + signEmpId;
                    }

                    signEmpName = flows[i].OfficeAutomation_Flow_Auditor;
                    signEmpId = flows[i].OfficeAutomation_Flow_AuditorID;
                }

                if (flows[i].OfficeAutomation_Flow_Audit)
                    result.CompleteFlows.Add(flows[i]);     //插入已完成列表
                else
                    result.NotCompleteFlows.Add(flows[i]);  //插入未完成列表

                if (i == flows.Count - 1)
                    lastflow = flows[i].OfficeAutomation_Flow_Idx;  //获取最后一步idx

                //去重
                if (!(employeeidsum + ",").Contains(flows[i].OfficeAutomation_Flow_AuditorID + ",") && !(employeenamesum + ",").Contains(flows[i].OfficeAutomation_Flow_Auditor + ","))
                {
                    employeeidsum += flows[i].OfficeAutomation_Flow_AuditorID + ",";
                    employeenamesum += flows[i].OfficeAutomation_Flow_Auditor + ",";
                }
            }

            //流程为最后一步
            if (lastflow == dto.Idx && result.NotCompleteFlows.Count() == 0)
            {
                flowstateId = 3;                //主表审核状态
                result.SignAllComplete = true;  //最后一步流程
            }
            else
            {
                //审批流未走完,主表OfficeAutomation_Main_AuditorIDsSum、OfficeAutomation_Main_AuditorNamesSum值为null
                employeeidsum = null;
                employeenamesum = null;
            }

            FlowBLL.UpdateContainIsAgreeForSignAndMultiNew_V2(dto.ReportMainID.ToString(), signEmpId, signEmpName.TrimEnd(','), dto.Suggestion, dto.Idx.ToString(), dto.IsAgree.ToString(), signflow.OfficeAutomation_Flow_ID.ToString(), flowstateId, employeeidsum, employeenamesum, islastemp);
        }

        return result;
    }

    /// <summary>
    /// 获取签名图片是否存在
    /// </summary>
    /// <param name="employeeid"></param>
    /// <returns></returns>
    private bool CheckGIFIsExist(string employeeid)
    {
        string SignImageURL = System.Configuration.ConfigurationManager.AppSettings["SignImageURL"];
        bool result = false;
        WebResponse response = null;
        try
        {
            WebRequest req = WebRequest.Create(SignImageURL + employeeid + ".gif");
            response = req.GetResponse();
            result = response == null ? false : true;
        }
        catch (Exception ex)
        {
            result = false;
        }
        finally
        {
            if (response != null)
            {
                response.Close();
            }
        }
        return result;
    }
}

public class SignResult
{
    public SignResult()
    {
        CompleteFlows = new List<DataEntity.T_OfficeAutomation_Flow>();
        NotCompleteFlows = new List<DataEntity.T_OfficeAutomation_Flow>();
    }
    public bool Flag { get; set; }
    public string Message { get; set; }
    public bool SignAllComplete { get; set; }
    public string SignEmpName { get; set; }
    public string SignEmpID { get; set; }


    //已完成的审核
    public List<DataEntity.T_OfficeAutomation_Flow> CompleteFlows { get; set; }

    //未审核列表
    public List<DataEntity.T_OfficeAutomation_Flow> NotCompleteFlows { get; set; }
}