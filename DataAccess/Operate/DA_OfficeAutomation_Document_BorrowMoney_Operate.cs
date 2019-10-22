using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BorrowMoney_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private   DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BorrowMoney> dal;
        #endregion
      
        public DA_OfficeAutomation_Document_BorrowMoney_Operate()
        {
            dal =new DAL.DalBase<T_OfficeAutomation_Document_BorrowMoney> ();
        }
        public T_OfficeAutomation_Document_BorrowMoney Add(T_OfficeAutomation_Document_BorrowMoney t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_BorrowMoney Edit(T_OfficeAutomation_Document_BorrowMoney t)
        {
            return dal.Edit(t);
        }
        public T_OfficeAutomation_Document_BorrowMoney GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_BorrowMoney>(where);
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
