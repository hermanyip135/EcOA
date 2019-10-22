using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SYSPWDTransfer_Operate : SqlInteractionBase
    {
           private   DAL.DalBase<DataEntity.T_OfficeAutomation_Document_SYSPWDTransfer> dal;

           public DA_OfficeAutomation_Document_SYSPWDTransfer_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_SYSPWDTransfer>();
        }
         public T_OfficeAutomation_Document_SYSPWDTransfer Add(T_OfficeAutomation_Document_SYSPWDTransfer t)
        {
            return dal.Add(t);
        }

         public T_OfficeAutomation_Document_SYSPWDTransfer Edit(T_OfficeAutomation_Document_SYSPWDTransfer t)
        {
            return dal.Edit(t);
        }
         public T_OfficeAutomation_Document_SYSPWDTransfer GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_SYSPWDTransfer>(where);
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
