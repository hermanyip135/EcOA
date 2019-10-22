using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Fax_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DAL.DalBase<T_OfficeAutomation_Document_Fax> dal;
        #endregion
            public DA_OfficeAutomation_Document_Fax_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_Fax>();
        }
            public T_OfficeAutomation_Document_Fax Add(T_OfficeAutomation_Document_Fax t)
        {
            return dal.Add(t);
        }

            public T_OfficeAutomation_Document_Fax Edit(T_OfficeAutomation_Document_Fax t)
        {
            return dal.Edit(t);
        }
            public T_OfficeAutomation_Document_Fax GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_Fax>(where);
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
