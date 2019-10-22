using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_BadDebts_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_BadDebts BadDebts { get; set; }
        public List<T_OfficeAutomation_Document_BadDebts_Detail> BadDebts_Detail { get; set; }
    }
}
