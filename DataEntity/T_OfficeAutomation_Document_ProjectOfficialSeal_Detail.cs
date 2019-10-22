using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_ProjectOfficialSeal_Detail
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_ProjectOfficialSeal_Detail_ID { get; set; }

        /// <summary>
        /// 申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ProjectOfficialSeal_Detail_MainID { get; set; }

        /// <summary>
        /// 事务文件
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_Detail_TransFile { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_Detail_FileName { get; set; }

        /// <summary>
        /// 代理期开始时间
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_Detail_AgentBeginData { get; set; }

        /// <summary>
        /// 代理期结束时间
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_Detail_AgentEndData { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_Detail_Use { get; set; }

        /// <summary>
        /// 项目（楼盘）名称/文件名称
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_Detail_BN { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_Detail_Company { get; set; }

    }

}
