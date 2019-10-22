using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_UtContract_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_UtContract UtContract { get; set; }
        public List<T_OfficeAutomation_Document_UtContract_Detail> UtContract_Detail { get; set; }
    }
}
