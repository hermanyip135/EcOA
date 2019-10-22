using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.DTO
{
    public class SearchFilterDto
    {
        /// <summary>
        /// 是否法律部
        /// </summary>
        public bool IsLawer { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 申请部门
        /// </summary>
        public string AppDepartment { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string Applicant { get; set; }

        /// <summary>
        /// 申请开始时间
        /// </summary>
        public DateTime? BeginApplyTime { get; set; }

        /// <summary>
        /// 申请结束时间
        /// </summary>
        public DateTime? EndApplyTime { get; set; }

        /// <summary>
        /// 文档类型
        /// </summary>
        public int ApplyType { get; set; }

        /// <summary>
        /// 申请状态
        /// </summary>
        public int ApplyState { get; set; }

        /// <summary>
        /// 搜索人姓名
        /// </summary>
        public string Employee { get; set; }

        /// <summary>
        /// 搜索人工号
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// 权限字符窜
        /// </summary>
        public string Purview { get; set; }

        /// <summary>
        /// 文档编码
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord { get; set; }

        /// <summary>
        /// 排序类型1：按最后申请日期排序；2：按最后审批时间排序
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 待定，不明确
        /// </summary>
        public string Cstatue { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string Approver { get; set; }

        /// <summary>
        /// 审核开始时间
        /// </summary>
        public DateTime? AppTime { get; set; }

        /// <summary>
        /// 审核结束时间
        /// </summary>
        public DateTime? AppToTime { get; set; }

        /// <summary>
        /// 是否即将删除
        /// </summary>
        public bool WillDelete { get; set; }

        /// <summary>
        /// 申报类别(个人利益申请中使用)
        /// </summary>
        public string InterestsType { get; set; }

        /// <summary>
        /// 允许访问的IDS(登录时生成)
        /// </summary>
        public string AllowIDS { get; set; }

        /// <summary>
        /// 没权限访问的IDS(登录时生成)
        /// </summary>
        public string NotAllowIDS { get; set; }

        /// <summary>
        /// 代理人
        /// </summary>
        public List<AgentDto> Agents { get; set; }

        /// <summary>
        /// 关键字全库查询
        /// </summary>
        public bool KeyWordAllTB { get; set; }
        /// <summary>
        /// 是否经集团审批
        /// </summary>
        public bool IsGroups { get; set; }
    }

    public class AgentDto
    {
        public string AgentEmpID { get; set; }
        public string AgentEmpName { get; set; }
    }
}
