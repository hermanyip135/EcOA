using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.DTO
{
    public class SignDto
    {
        /// <summary>
        /// 签名的审批环节
        /// </summary>
        public int Idx { get; set; }

        /// <summary>
        /// 签名意见
        /// </summary>
        public string Suggestion { get; set; }

        /// <summary>
        /// 是否同意{0:不同意,1:同意,2:其他意见}
        /// </summary>
        public int IsAgree { get; set; }

        /// <summary>
        /// 申请主键
        /// </summary>
        public Guid ReportMainID { get; set; }

        ///// <summary>
        ///// 签名人姓名
        ///// </summary>
        //public string SignEmpName { get; set; }

        ///// <summary>
        ///// 签名人工号
        ///// </summary>
        //public string SignEmpID { get; set; }

        ///// <summary>
        ///// 代理列表
        ///// </summary>
        //public List<AgentDto> Agents { get; set; }

        /// <summary>
        /// 是否单人审
        /// </summary>
        public bool IsSingle { get; set; }
    }
}
