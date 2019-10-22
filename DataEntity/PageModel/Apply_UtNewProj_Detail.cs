using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_UtNewProj_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_UtNewProj UtNewProj { get; set; }
        public List<T_OfficeAutomation_Document_UtNewProj_Detail> UtNewProj_Detail { get; set; }
    }
}
