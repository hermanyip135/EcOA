using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
   public class DA_OfficeAutomation_Document_FinAffairsTransfer_Detail_Operate
    {
        #region 自定义变量
       private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_FinAffairsTransfer_Detail> dal;
        #endregion

        public DA_OfficeAutomation_Document_FinAffairsTransfer_Detail_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_FinAffairsTransfer_Detail>();
        }
        public T_OfficeAutomation_Document_FinAffairsTransfer_Detail Add(T_OfficeAutomation_Document_FinAffairsTransfer_Detail t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_FinAffairsTransfer_Detail Edit(T_OfficeAutomation_Document_FinAffairsTransfer_Detail t)
        {
            return dal.Edit(t);
        }
        public T_OfficeAutomation_Document_FinAffairsTransfer_Detail GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_FinAffairsTransfer_Detail>(where);
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
        public bool DelByMainID(string MainID)
        {
            return dal.DelByMainID(MainID);
        }
        public DataSet SelectByMainID(string mainID)
        {
            return dal.SelectByMainID(mainID); ;
        }
    }
}
