using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.PageModel
{
    public class Apply_Feasibility_Detail:PageModelBase
    {
        public T_OfficeAutomation_Document_Feasibility Feasibility { get; set; }
        public List<T_OfficeAutomation_Document_Feasibility_BuildingSituation> BuildingSituation { get; set; }
        public List<T_OfficeAutomation_Document_Feasibility_DealOfRecord> DealOfRecord { get; set; }
        public List<T_OfficeAutomation_Document_Feasibility_Competitors> Competitors { get; set; }
        public List<T_OfficeAutomation_Document_Feasibility_Menber> Menber{get;set;}
        public List<T_OfficeAutomation_Document_Feasibility_Statistical> Statistical { get; set; }
        public List<T_OfficeAutomation_Document_Feasibility_YearRent> YearRent { get; set; }
    }
}
