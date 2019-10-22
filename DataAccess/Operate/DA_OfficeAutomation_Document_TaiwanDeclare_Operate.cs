using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_TaiwanDeclare_Operate : SqlInteractionBase
    {
          private   DAL.DalBase<DataEntity.T_OfficeAutomation_Document_TaiwanDeclare> dal;

          public DA_OfficeAutomation_Document_TaiwanDeclare_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_TaiwanDeclare>();
        }
         public T_OfficeAutomation_Document_TaiwanDeclare Add(T_OfficeAutomation_Document_TaiwanDeclare t)
        {
            return dal.Add(t);
        }

         public T_OfficeAutomation_Document_TaiwanDeclare Edit(T_OfficeAutomation_Document_TaiwanDeclare t)
        {
            return dal.Edit(t);
        }
         public T_OfficeAutomation_Document_TaiwanDeclare GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_TaiwanDeclare>(where);
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
