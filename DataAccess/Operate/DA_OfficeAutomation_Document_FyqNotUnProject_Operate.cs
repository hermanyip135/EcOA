using DataEntity;
using ECOA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_FyqNotUnProject_Operate
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_FyqNotUnProject> dal;
     public DA_OfficeAutomation_Document_FyqNotUnProject_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_FyqNotUnProject>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_FyqNotUnProject> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_FyqNotUnProject>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_FyqNotUnProject Add(T_OfficeAutomation_Document_FyqNotUnProject t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_FyqNotUnProject Edit(T_OfficeAutomation_Document_FyqNotUnProject t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_FyqNotUnProject t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_FyqNotUnProject GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_FyqNotUnProject>(where);
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
