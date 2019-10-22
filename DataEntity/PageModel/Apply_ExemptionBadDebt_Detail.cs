using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_ExemptionBadDebt_Detail : PageModelBase
    {
        public T_OfficeAutomation_Document_ExemptionBadDebt ExemptionBadDebt { get; set; }
        public List<T_OfficeAutomation_Document_ExemptionBadDebt_Detail> ExemptionBadDebt_Detail { get; set; }
        public List<T_OfficeAutomation_Document_ExemptionBadDebt_AreaComm> ExemptionBadDebt_AreaComm { get; set; }
    }
}
