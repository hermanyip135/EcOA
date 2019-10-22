using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OndutyVacation_Inherit : DA_OfficeAutomation_Document_OndutyVacation_Operate
    {
        public T_OfficeAutomation_Document_OndutyVacation GetModelByMainID(string MainID)
        {
            string where = " OfficeAutomation_Document_OndutyVacation_MainID ='" + MainID + "'";
            return GetModel(where);
        }
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = @"SELECT * 
                                 ,toam.OfficeAutomation_SerialNumber
                                 ,tdoad.OfficeAutomation_Document_Name
                                 ,toam.OfficeAutomation_Main_FlowStateID
                           FROM [DB_EcOfficeAutomation].[dbo].t_OfficeAutomation_Document_OndutyVacation todi
                           LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_OndutyVacation_MainID
                           LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID
                           WHERE OfficeAutomation_Document_OndutyVacation_MainID='" + mainID + "'";

            return RunSQL(sql);
        }
    }
}
