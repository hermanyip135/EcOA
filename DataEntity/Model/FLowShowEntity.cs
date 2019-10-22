using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.Model
{
    public class FLowShowEntity
    {
        /// <summary>
        /// 是否已审核
        /// </summary>
        public bool Audit { get; set; }

        /// <summary>
        /// 流程序数
        /// </summary>
        public int Idx { get; set; }

        /// <summary>
        /// 待审核人
        /// </summary>
        public string Employee { get; set; }

        /// <summary>
        /// 待审核人工号
        /// </summary>
        public string EmployeeID { get; set; }

        /// <summary>
        /// 签名人
        /// </summary>
        public string Auditor { get; set; }

        /// <summary>
        /// 签名人工号
        /// </summary>
        public string AuditorID { get; set; }

    }
}
