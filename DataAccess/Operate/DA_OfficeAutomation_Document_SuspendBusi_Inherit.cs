using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_SuspendBusi_Inherit : DA_OfficeAutomation_Document_SuspendBusi_Operate
    {
        public DA_OfficeAutomation_Document_SuspendBusi_Inherit()
        { }

        /// <summary>
        /// 通过MainID查询撤铺转铺申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT todi.*"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + "         ,tdodt.OfficeAutomation_DepartmentType_Name"
                             + "         ,tdopp.OfficeAutomation_Majordomo_Name"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SuspendBusi] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SuspendBusi_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DepartmentType tdodt ON tdodt.OfficeAutomation_DepartmentType_ID = todi.OfficeAutomation_Document_SuspendBusi_DepartmentTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Majordomo tdopp ON tdopp.OfficeAutomation_Majordomo_ID = todi.OfficeAutomation_Document_SuspendBusi_MajordomoID"
                             + " WHERE OfficeAutomation_Document_SuspendBusi_MainID='" + mainID + "'";

            return DbHelperSQL.Query(sql);
        }
    }
}

