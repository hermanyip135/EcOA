using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CallCenterFeasibility_Competitors_Inherit:SqlInteractionBase
    {
        DAL.DalBase<T_OfficeAutomation_Document_CallCenterFeasibility_Competitors> dal;
        public DA_OfficeAutomation_Document_CallCenterFeasibility_Competitors_Inherit()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_CallCenterFeasibility_Competitors>();
        }

        public T_OfficeAutomation_Document_CallCenterFeasibility_Competitors Add(T_OfficeAutomation_Document_CallCenterFeasibility_Competitors obj)
        {
            return dal.Add(obj);
        }

        public T_OfficeAutomation_Document_CallCenterFeasibility_Competitors Edit(T_OfficeAutomation_Document_CallCenterFeasibility_Competitors obj)
        {
            return dal.Edit(obj);
        }
        public bool Del(string MainID)
        {
            return dal.DelByMainID(MainID);
        }

        /// <summary>
        /// 根据获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT * "
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CallCenterFeasibility_Competitors]"
                          + " WHERE [OfficeAutomation_Document_CallCenterFeasibility_Competitors_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_CallCenterFeasibility_Competitors_BusinessName] ASC";

            return RunSQL(sql);
        }

        
    }
}
