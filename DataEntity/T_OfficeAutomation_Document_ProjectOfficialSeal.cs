using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_ProjectOfficialSeal
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_ProjectOfficialSeal_ID { get; set; }

        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ProjectOfficialSeal_MainID { get; set; }

        /// <summary>
        /// 发文人员
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_Apply { get; set; }

        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ProjectOfficialSeal_ApplyDate { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_ApplyID { get; set; }

        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_Department { get; set; }

        /// <summary>
        /// 申请盖章的种类
        /// </summary>
        public bool? OfficeAutomation_Document_ProjectOfficialSeal_Species { get; set; }

        /// <summary>
        /// 其它印章
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_AnotherSeal { get; set; }

        /// <summary>
        /// 申请盖章文件的种类
        /// </summary>
        public int? OfficeAutomation_Document_ProjectOfficialSeal_FileSpecies { get; set; }

        /// <summary>
        /// 对佣（请款）金额
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_AnotherFile { get; set; }

        /// <summary>
        /// 申请盖章文件的份数
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_FileCount { get; set; }

        /// <summary>
        /// 预计回收日期
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_RecyclingData { get; set; }

        /// <summary>
        /// 确认盖章部门
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_SureDepartment { get; set; }

        /// <summary>
        /// 确认盖章人员
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_SureMenber { get; set; }

        /// <summary>
        /// 确认盖章日期
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_SureData { get; set; }

        /// <summary>
        /// 盖章专责人员
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_SureCommissioner { get; set; }

        /// <summary>
        /// 分行电话
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_BranchPhone { get; set; }

        /// <summary>
        /// 确认人电话
        /// </summary>
        public string OfficeAutomation_Document_ProjectOfficialSeal_SurePhone { get; set; }

    }

}
