using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_PullafewRd_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_PullafewRd PullafewRd { get; set; }
        public List<T_OfficeAutomation_Document_PullafewRd_Detail> PullafewRd_Detail { get; set; }
        public List<T_OfficeAutomation_Document_PullafewRd_LeaseTerm> PullafewRd_LeaseTerm { get; set; }
        public List<T_OfficeAutomation_Document_PullafewRd_Statistical> PullafewRd_Statistical { get; set; }
    }
}
