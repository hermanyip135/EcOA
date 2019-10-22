using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_BackComm_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_BackComm BackComm { get; set; }
        public List<T_OfficeAutomation_Document_BackComm_Detail> BackComm_Detail { get; set; }
    }
}
