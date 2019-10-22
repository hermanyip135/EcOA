using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlDatabase;
using DataEntity;
using System.Data;
using System.Data.SqlClient;
using ECOA.Common;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Print_Operate
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_Print> dal;
        public DA_OfficeAutomation_Document_Print_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_Print>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_Print> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_Print>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_Print Add(T_OfficeAutomation_Document_Print t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_Print Edit(T_OfficeAutomation_Document_Print t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_Print t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_Print GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_Print>(where);
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
