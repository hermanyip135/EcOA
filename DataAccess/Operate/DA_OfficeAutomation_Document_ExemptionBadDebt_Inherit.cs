using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ExemptionBadDebt_Inherit : DA_OfficeAutomation_Document_ExemptionBadDebt_Operate
    {
        /// <summary>
        /// 通过MainID查询软件系统开发需求申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = @"    SELECT todi.*
                                    ,toam.OfficeAutomation_SerialNumber
                                    ,OfficeAutomation_Main_Apply
                                    ,tdoad.OfficeAutomation_Document_Name
                                    ,OfficeAutomation_Main_Department
                                   ,toam.OfficeAutomation_Main_FlowStateID
                           FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ExemptionBadDebt] todi
                           LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ExemptionBadDebt_MainID
                            LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID
                           WHERE OfficeAutomation_Document_ExemptionBadDebt_MainID='" + mainID + "'";

            return RunSQL(sql);
        }
        /// <summary>
        /// 通过ID查询软件系统开发需求申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = @"    SELECT todi.*
                                    ,toam.OfficeAutomation_SerialNumber
                                     ,tdoad.OfficeAutomation_Document_Name
                            FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ExemptionBadDebt] todi
                            LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ExemptionBadDebt_MainID
                            LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID
                            WHERE OfficeAutomation_Document_ExemptionBadDebt_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
