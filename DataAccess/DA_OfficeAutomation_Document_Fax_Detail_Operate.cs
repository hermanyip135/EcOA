using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess
{
   public class DA_OfficeAutomation_Document_Fax_Detail_Operate
    {
         #region 自定义变量
        private DAL.DalBase<T_OfficeAutomation_Document_Fax_Detail> dal;
        #endregion
        public DA_OfficeAutomation_Document_Fax_Detail_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_Fax_Detail>();
        }
            public T_OfficeAutomation_Document_Fax_Detail Add(T_OfficeAutomation_Document_Fax_Detail t)
        {
            return dal.Add(t);
        }

            public T_OfficeAutomation_Document_Fax_Detail Edit(T_OfficeAutomation_Document_Fax_Detail t)
        {
            return dal.Edit(t);
        }
            public T_OfficeAutomation_Document_Fax_Detail GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_Fax_Detail>(where);
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
    }
}
