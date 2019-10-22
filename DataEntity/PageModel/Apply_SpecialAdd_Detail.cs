using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_SpecialAdd_Detail : PageModelBase
    {
        public T_OfficeAutomation_Document_SpecialAdd SpecialAdd { get; set; }
        public List<T_OfficeAutomation_Document_SpecialAdd_Statistical> Statisticals { get; set; }
    }
}