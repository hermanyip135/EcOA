using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_FinAffairsTransfer_Inherit : DA_OfficeAutomation_Document_FinAffairsTransfer_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = @"SELECT  todi.*
                                    ,toam.OfficeAutomation_SerialNumber
                                     ,toam.OfficeAutomation_Main_FlowStateID
                                    ,toam.OfficeAutomation_Main_Creater
                                    ,toam.OfficeAutomation_Main_Apply
                                    ,toam.OfficeAutomation_Main_CrTime
                                    ,toam.OfficeAutomation_Main_ApplyDate
                                    ,toam.OfficeAutomation_Main_Department   
                           FROM [DB_EcOfficeAutomation].[dbo].[T_OfficeAutomation_Document_FinAffairsTransfer] todi
                           LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_FinAffairsTransfer_MainID
                           LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID
                            WHERE OfficeAutomation_Document_FinAffairsTransfer_MainID='" + mainID + "'";

            return RunSQL(sql);
        }
    }
}
