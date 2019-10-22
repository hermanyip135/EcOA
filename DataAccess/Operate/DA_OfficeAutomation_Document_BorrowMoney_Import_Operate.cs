using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class DA_OfficeAutomation_Document_BorrowMoney_Import_Operate : SqlInteractionBase
    {
         private   DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BorrowMoney_Import> dal;

         public DA_OfficeAutomation_Document_BorrowMoney_Import_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_BorrowMoney_Import>();
        }
         public T_OfficeAutomation_Document_BorrowMoney_Import Add(T_OfficeAutomation_Document_BorrowMoney_Import t)
        {
            return dal.Add(t);
        }

         public T_OfficeAutomation_Document_BorrowMoney_Import Edit(T_OfficeAutomation_Document_BorrowMoney_Import t)
        {
            return dal.Edit(t);
        }
         public T_OfficeAutomation_Document_BorrowMoney_Import GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_BorrowMoney_Import>(where);
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
