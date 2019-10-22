using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
   public class DA_OfficeAutomation_Document_Fax_Detail_Flow_Operate
    {
          #region 自定义变量
        private DAL.DalBase<T_OfficeAutomation_Document_Fax_Detail_Flow> dal;
        #endregion
        public DA_OfficeAutomation_Document_Fax_Detail_Flow_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_Fax_Detail_Flow>();
        }
        public T_OfficeAutomation_Document_Fax_Detail_Flow Add(T_OfficeAutomation_Document_Fax_Detail_Flow t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_Fax_Detail_Flow Edit(T_OfficeAutomation_Document_Fax_Detail_Flow t)
        {
            return dal.Edit(t);
        }
        public T_OfficeAutomation_Document_Fax_Detail_Flow GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_Fax_Detail_Flow>(where);
        }
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }
        public bool Delete(string mainID)
        {
            return dal.Delete(mainID);
        }
        public DataSet OperationSQL(string sql)
        {
            return dal.OperationSQL(sql);
        }
        public bool DelByMainID(string mainID)
        {
            return dal.DelByMainID(mainID);
        }
       
    }
}
