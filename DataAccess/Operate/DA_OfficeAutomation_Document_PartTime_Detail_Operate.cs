using System;
using System.Linq;
using System.Text;
using SqlDatabase;
using DataEntity;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ECOA.Common;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PartTime_Detail_Operate
    {
        private DAL.DalDetailBase<DataEntity.T_OfficeAutomation_Document_PartTime_Detail> dal;
        public DA_OfficeAutomation_Document_PartTime_Detail_Operate()
        {
            dal = new DAL.DalDetailBase<DataEntity.T_OfficeAutomation_Document_PartTime_Detail>("t_OfficeAutomation_Document_PartTime");
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_PartTime_Detail> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_PartTime_Detail>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_PartTime_Detail Add(T_OfficeAutomation_Document_PartTime_Detail t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_PartTime_Detail Edit(T_OfficeAutomation_Document_PartTime_Detail t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_PartTime_Detail t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_PartTime_Detail GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_PartTime_Detail>(where);
        }

        public DataSet SelectByMainID(string mainID)
        {
            return dal.SelectByMainID(mainID); ;
        }

        public IList<T_OfficeAutomation_Document_PartTime_Detail> SelectListByMainID(string mainID)
        {
            var ds = SelectByMainID(mainID);
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ECOA.Common.SerializationHelper.GetEntities<T_OfficeAutomation_Document_PartTime_Detail>(ds.Tables[0]);
        }

        public bool DelByMainID(string MainID)
        {
            return dal.DelByMainID(MainID);
        }
        #endregion
    }
}
