using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
  public  class DA_OfficeAutomation_Document_Image_Inherit : DA_OfficeAutomation_Document_Image_Operate
    {
      public DataSet SearchImageDesc(string MainID)
      {
          string sql = @" SELECT  top 1 * FROM [t_OfficeAutomation_Document_Image]
                WHERE OfficeAutomation_Document_Image_MainID ='" + MainID + "' ORDER BY OfficeAutomation_Document_Image_CreateTime desc";
         return OperationSQL(sql);
      }
    }
}
