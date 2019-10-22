using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_Recruit_Detail : PageModelBase
    {
        public T_OfficeAutomation_Document_Recruit Recruit { get; set; }
        public List<T_OfficeAutomation_Document_Recruit_Detail> list { get; set; }
    }
}
