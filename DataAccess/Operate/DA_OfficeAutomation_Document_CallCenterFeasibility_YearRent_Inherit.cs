using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CallCenterFeasibility_YearRent_Inherit : SqlInteractionBase
    {
        DAL.DalBase<T_OfficeAutomation_Document_CallCenterFeasibility_YearRent> dal;
        public DA_OfficeAutomation_Document_CallCenterFeasibility_YearRent_Inherit()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_CallCenterFeasibility_YearRent>();
        }

        public T_OfficeAutomation_Document_CallCenterFeasibility_YearRent Add(T_OfficeAutomation_Document_CallCenterFeasibility_YearRent obj)
        {
            return dal.Add(obj);
        }

        public T_OfficeAutomation_Document_CallCenterFeasibility_YearRent Edit(T_OfficeAutomation_Document_CallCenterFeasibility_YearRent obj)
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
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CallCenterFeasibility_YearRent]"
                          + " WHERE [OfficeAutomation_Document_CallCenterFeasibility_YearRent_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_CallCenterFeasibility_YearRent_YearNo] ASC";

            return RunSQL(sql);
        }
    }
}
