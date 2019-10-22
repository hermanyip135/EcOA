using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_TotalRev_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_TotalRev TotalRev { get; set; }
        public List<T_OfficeAutomation_Document_GeneralApply_Detail> GeneralApply_Detail { get; set; }
    }
}
