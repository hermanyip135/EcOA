using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_UtNewProj_Detail_New : PageModelBase
    {
        public T_OfficeAutomation_Document_UtNewProj_New UtNewProjNew { get; set; }
        public List<T_OfficeAutomation_Document_UtNewProj_New_Detail> UtNewProjNew_Detail { get; set; }
    }
}
