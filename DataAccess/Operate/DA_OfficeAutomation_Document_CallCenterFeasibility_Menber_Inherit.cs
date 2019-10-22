using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CallCenterFeasibility_Menber_Inherit : SqlInteractionBase
    {
        DAL.DalBase<T_OfficeAutomation_Document_CallCenterFeasibility_Menber> dal;
        public DA_OfficeAutomation_Document_CallCenterFeasibility_Menber_Inherit()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_CallCenterFeasibility_Menber>();
        }

        public T_OfficeAutomation_Document_CallCenterFeasibility_Menber Add(T_OfficeAutomation_Document_CallCenterFeasibility_Menber obj)
        {
            return dal.Add(obj);
        }

        public T_OfficeAutomation_Document_CallCenterFeasibility_Menber Edit(T_OfficeAutomation_Document_CallCenterFeasibility_Menber obj)
        {
            return dal.Edit(obj);
        }
        public bool Del(string MainID)
        {
            return dal.DelByMainID(MainID);
        }
        /// <summary>
        /// 获取人员架构2
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID2(string id)
        {
            string sql = "SELECT * "
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CallCenterFeasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_CallCenterFeasibility_Menber_MainID]='" + id + "' AND [OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorManager] = '2'"
                          + " ORDER BY [OfficeAutomation_Document_CallCenterFeasibility_Menber_AreaManager],[OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 获取人员架构3
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID3(string id)
        {
            string sql = "SELECT * "
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CallCenterFeasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_CallCenterFeasibility_Menber_MainID]='" + id + "' AND [OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorManager] = '3'"
                          + " ORDER BY [OfficeAutomation_Document_CallCenterFeasibility_Menber_AreaManager],[OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 获取人员架构4
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID4(string id)
        {
            string sql = "SELECT * "
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CallCenterFeasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_CallCenterFeasibility_Menber_MainID]='" + id + "' AND [OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorManager] = '4'"
                          + " ORDER BY [OfficeAutomation_Document_CallCenterFeasibility_Menber_AreaManager],[OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 获取人员架构2
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID5(string id)
        {
            string sql = "SELECT * "
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CallCenterFeasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_CallCenterFeasibility_Menber_MainID]='" + id + "' AND [OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorManager] = '5'"
                          + " ORDER BY [OfficeAutomation_Document_CallCenterFeasibility_Menber_AreaManager],[OfficeAutomation_Document_CallCenterFeasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }
    }
}
