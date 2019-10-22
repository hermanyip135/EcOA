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
    public class DA_OfficeAutomation_Document_StaffDataCheck_Operate : SqlInteractionBase
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_StaffDataCheck> dal;
        public DA_OfficeAutomation_Document_StaffDataCheck_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_StaffDataCheck>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_StaffDataCheck> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_StaffDataCheck>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_StaffDataCheck Add(T_OfficeAutomation_Document_StaffDataCheck t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_StaffDataCheck Edit(T_OfficeAutomation_Document_StaffDataCheck t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_StaffDataCheck t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_StaffDataCheck GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_StaffDataCheck>(where);
        }

        public DataSet SelectByMainID(string mainID)
        {
            return dal.SelectByMainID(mainID); 
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

