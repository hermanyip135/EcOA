using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_PullafewTwo_Detail : PageModelBase
    {
        public T_OfficeAutomation_Document_PullafewTwo PullafewTwo { get; set; }
        public List<T_OfficeAutomation_Document_PullafewTwo_Detail> PullafewTwo_Detail { get; set; }
        public List<T_OfficeAutomation_Document_PullafewTwo_LeaseTerm> LeaseTerm { get; set; }
        public List<T_OfficeAutomation_Document_PullafewTwo_Statistical> Statistical { get; set; }
    }
}
