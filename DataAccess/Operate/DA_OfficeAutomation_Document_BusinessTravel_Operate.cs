using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using ECOA.Common;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BusinessTravel_Operate
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BusinessTravel> dal;
        public DA_OfficeAutomation_Document_BusinessTravel_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BusinessTravel>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_BusinessTravel> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_BusinessTravel>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_BusinessTravel Add(T_OfficeAutomation_Document_BusinessTravel t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_BusinessTravel Edit(T_OfficeAutomation_Document_BusinessTravel t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_BusinessTravel t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_BusinessTravel GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_BusinessTravel>(where);
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
