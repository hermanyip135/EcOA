using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_ResumeBusi_Inherit : DA_OfficeAutomation_Document_ResumeBusi_Operate
    {
        public DA_OfficeAutomation_Document_ResumeBusi_Inherit()
        { }

        /// <summary>
        /// 通过MainID查询员工恢复营业申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT todi.*"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + "         ,tdoad1.OfficeAutomation_DepartmentType_Name"
                             + "         ,tdoad2.OfficeAutomation_Majordomo_Name"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ResumeBusi] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ResumeBusi_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DepartmentType tdoad1 ON tdoad1.OfficeAutomation_DepartmentType_ID = todi.OfficeAutomation_Document_ResumeBusi_DepartmentTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Majordomo tdoad2 ON tdoad2.OfficeAutomation_Majordomo_ID = todi.OfficeAutomation_Document_ResumeBusi_MajordomoID"
                             + " WHERE OfficeAutomation_Document_ResumeBusi_MainID='" + mainID + "'";


            return DbHelperSQL.Query(sql);
        }
    }
}

