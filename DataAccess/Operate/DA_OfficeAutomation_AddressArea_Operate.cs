using DataEntity;
using ECOA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_AddressArea_Operate : SqlInteractionBase
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_AddressArea> dal;
        public DA_OfficeAutomation_AddressArea_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_AddressArea>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }
        public DataSet OperationSQLSelectAll()
        {
            string sql = "select * from t_OfficeAutomation_AddressArea order by OfficeAutomation_AddressArea_Code";
            return dal.OperationSQL(sql);
        }
        public IList<T_OfficeAutomation_AddressArea> SelectAllList()
        {
            var ds = OperationSQLSelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_AddressArea>(ds.Tables[0]);
        }

        public T_OfficeAutomation_AddressArea Add(T_OfficeAutomation_AddressArea t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_AddressArea Edit(T_OfficeAutomation_AddressArea t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_AddressArea t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_AddressArea GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_AddressArea>(where);
        }

        public DataSet SelectByMainID(string mainID)
        {
            return dal.SelectByMainID(mainID); ;
        }

        public bool DelByMainID(string MainID)
        {
            return dal.DelByMainID(MainID);
        }

        public bool Delete(string mainID)
        {
            return dal.Delete(mainID);
        }
        #endregion
    }

}
