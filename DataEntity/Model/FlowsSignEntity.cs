using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.Model
{
    public class FlowsSignEntity
    {
        /// <summary>
        /// 签名人列表
        /// </summary>
        public List<SignEmp> Auditors { get; set; }
        
        /// <summary>
        /// 流程
        /// </summary>
        public int Idx { get; set; }
        
        /// <summary>
        /// 签名时间(最新时间)
        /// </summary>
        public string AuditDate { get; set; }

        /// <summary>
        /// 是否显示签名按钮
        /// </summary>
        public bool SignbtnShow { get; set; }

        /// <summary>
        /// 意见
        /// </summary>
        public string Suggestion { get; set; }

        /// <summary>
        /// 审核是否通过
        /// </summary>
        public bool Audit { get; set; }

        /// <summary>
        /// 审核结果(通常情况 0:不同意;1:同意;2:其他意见)
        /// </summary>
        public string IsAgree { get; set; }

        /// <summary>
        /// 需要审核的人
        /// </summary>
        public string Employee { get; set; }

        /// <summary>
        /// 需要审核人的工号
        /// </summary>
        public string EmployeeID { get; set; }
    }

    public class SignEmp
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 签名图片
        /// </summary>
        public string SignPic { get; set; }

        /// <summary>
        /// 是否显示取消签名按钮
        /// </summary>
        public bool CancelSignbtnShow { get; set; }
    }
}
