using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_FinAffairsTransfer_Operate : SqlInteractionBase
    {
      private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_FinAffairsTransfer> dal;

           public DA_OfficeAutomation_Document_FinAffairsTransfer_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_FinAffairsTransfer>();
        }
           public T_OfficeAutomation_Document_FinAffairsTransfer Add(T_OfficeAutomation_Document_FinAffairsTransfer t)
        {
            return dal.Add(t);
        }

           public T_OfficeAutomation_Document_FinAffairsTransfer Edit(T_OfficeAutomation_Document_FinAffairsTransfer t)
        {
            return dal.Edit(t);
        }
           public T_OfficeAutomation_Document_FinAffairsTransfer GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_FinAffairsTransfer>(where);
        }
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }
        public bool Delete(string mainID)
        {
            return dal.Delete(mainID);
        }
        
    }
}
