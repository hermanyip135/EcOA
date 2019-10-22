using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
   public class DA_OfficeAutomation_Document_BorrowMoney_Detail_Operate
    {
         private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BorrowMoney_Detail> dal;
         public DA_OfficeAutomation_Document_BorrowMoney_Detail_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_BorrowMoney_Detail>();
        }
       #region 基本方法
       public DataSet SelectAll()
       {
           return dal.SelectAll();
       }
       public DataSet SelectByMainID(string mainID)
       {
           return dal.SelectByMainID(mainID); ;
       }
       public IList<T_OfficeAutomation_Document_BorrowMoney_Detail> SelectListByMainID(string mainID)
       {
           DataTable dt = SelectByMainID(mainID).Tables[0];
           if ( dt == null || dt.Rows.Count == 0)
           {
               return null;
           }
           DataTable dtCopy = dt.Copy();

           DataView dv = dt.DefaultView;
           dv.Sort = "OfficeAutomation_Document_BorrowMoney_Detail_Sort";
           dtCopy = dv.ToTable();
           return ECOA.Common.SerializationHelper.GetEntities<T_OfficeAutomation_Document_BorrowMoney_Detail>(dtCopy);
       }
       public T_OfficeAutomation_Document_BorrowMoney_Detail Add(T_OfficeAutomation_Document_BorrowMoney_Detail t)
       {
           return dal.Add(t);
       }

       public T_OfficeAutomation_Document_BorrowMoney_Detail Edit(T_OfficeAutomation_Document_BorrowMoney_Detail t)
       {
           return dal.Edit(t);
       }
       public bool DelByMainID(string MainID)
       {
           return dal.DelByMainID(MainID);
       }
       #endregion
    }
}
