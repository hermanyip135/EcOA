using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
   public class DA_OfficeAutomation_Document_FinAffairsTransfer_Detail_Inherit : DA_OfficeAutomation_Document_FinAffairsTransfer_Detail_Operate
    {
       public IList<T_OfficeAutomation_Document_FinAffairsTransfer_Detail> SelectListByMainID(string mainID)
       {
           DataTable dt = SelectByMainID(mainID).Tables[0];
           if (dt == null || dt.Rows.Count == 0)
           {
               return null;
           }
           DataTable dtCopy = dt.Copy();

           DataView dv = dt.DefaultView;
           dv.Sort = "OfficeAutomation_Document_FinAffairsTransfer_Detail_Sort";
           dtCopy = dv.ToTable();
           return ECOA.Common.SerializationHelper.GetEntities<T_OfficeAutomation_Document_FinAffairsTransfer_Detail>(dtCopy);
       }
    }
}
