using DataEntity;
using ECOA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
   public class DA_OfficeAutomation_Document_UIReq_Operate : SqlInteractionBase
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_UIReq> dal;
        public DA_OfficeAutomation_Document_UIReq_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_UIReq>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_UIReq> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_UIReq>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_UIReq Add(T_OfficeAutomation_Document_UIReq t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_UIReq Edit(T_OfficeAutomation_Document_UIReq t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_UIReq t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_UIReq GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_UIReq>(where);
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
