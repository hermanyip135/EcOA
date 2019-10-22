using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 新开分行可行性报告人员编排表
    /// </summary>
    public class T_OfficeAutomation_Document_CallCenterFeasibility_Menber
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_CallCenterFeasibility_Menber_ID { get; set; }

        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_CallCenterFeasibility_Menber_MainID { get; set; }

        public string OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorDirector { get; set; }

        public string OfficeAutomation_Document_CallCenterFeasibility_Menber_RegionalDirector { get; set; }

        public string OfficeAutomation_Document_CallCenterFeasibility_Menber_RegionalDeputyDirector { get; set; }

        public string OfficeAutomation_Document_CallCenterFeasibility_Menber_AreaManager { get; set; }

        public string OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorManager { get; set; }

        public string OfficeAutomation_Document_CallCenterFeasibility_Menber_UpperManager { get; set; }

        public string OfficeAutomation_Document_CallCenterFeasibility_Menber_businessManager { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_Menber_Name { get; set; }

        /// <summary>
        /// 执业证号
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_Menber_Num { get; set; }
    }
}
