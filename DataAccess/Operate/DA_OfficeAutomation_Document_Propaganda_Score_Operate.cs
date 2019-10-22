using DataEntity;
using ECOA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
   public class DA_OfficeAutomation_Document_Propaganda_Score_Operate
    {
       private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_Propaganda_Score> dal;
         public DA_OfficeAutomation_Document_Propaganda_Score_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_Propaganda_Score>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_Propaganda_Score> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_Propaganda_Score>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_Propaganda_Score Add(T_OfficeAutomation_Document_Propaganda_Score t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_Propaganda_Score Edit(T_OfficeAutomation_Document_Propaganda_Score t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_Propaganda_Score t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_Propaganda_Score GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_Propaganda_Score>(where);
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
