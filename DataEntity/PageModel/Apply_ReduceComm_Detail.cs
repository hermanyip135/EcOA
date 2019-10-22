using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_ReduceComm_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_ReduceComm ReduceComm { get; set; }
        public List<T_OfficeAutomation_Document_ReduceComm_Detail> ReduceComm_Detail { get; set; }
    }
}
