using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
  public  class DA_OfficeAutomation_Document_Propaganda_Score_Inherit
    {
      DA_OfficeAutomation_Document_Propaganda_Score_Operate dal = new DA_OfficeAutomation_Document_Propaganda_Score_Operate();
     /// <summary>
     /// 
     /// </summary>
     /// <param name="mainID">申请表ID</param>
     /// <returns></returns>
      public T_OfficeAutomation_Document_Propaganda_Score GetModel(string mainID)
      {
          string where = " OfficeAutomation_Document_Propaganda_Score_MainID='" + mainID + "'";
          return dal.GetModel(where);
      }
      public T_OfficeAutomation_Document_Propaganda_Score Add(T_OfficeAutomation_Document_Propaganda_Score t)
      {
          return dal.Add(t);
      }
      public T_OfficeAutomation_Document_Propaganda_Score Edit(T_OfficeAutomation_Document_Propaganda_Score t)
      {
          return dal.Edit(t);
      }
    }

}
