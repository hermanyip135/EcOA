using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_UndertakeProj_Inherit : DA_OfficeAutomation_Document_UndertakeProj_Operate
    {
        public DA_OfficeAutomation_Document_UndertakeProj_Inherit()
        { }

        /// <summary>
        /// 通过MainID查询物业部承接一手项目等报备申请表
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
                             + "         ,tdopp.OfficeAutomation_ProjectProperty_Name"
                             + "         ,tdodte.OfficeAutomation_DealType_Name"
                             + "         ,tdoap.OfficeAutomation_AgentProperty_Name"
                             + "         ,tdosm.OfficeAutomation_SaleMode_Name"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UndertakeProj] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_UndertakeProj_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DepartmentType tdodt ON tdodt.OfficeAutomation_DepartmentType_ID = todi.OfficeAutomation_Document_UndertakeProj_DepartmentTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_ProjectProperty tdopp ON tdopp.OfficeAutomation_ProjectProperty_ID = todi.OfficeAutomation_Document_UndertakeProj_ProjectPropertyID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DealType tdodte ON tdodte.OfficeAutomation_DealType_ID = todi.OfficeAutomation_Document_UndertakeProj_DealTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_AgentProperty tdoap ON tdoap.OfficeAutomation_AgentProperty_ID = todi.OfficeAutomation_Document_UndertakeProj_AgentPropertyID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_SaleMode tdosm ON tdosm.OfficeAutomation_SaleMode_ID = todi.OfficeAutomation_Document_UndertakeProj_SaleModeID"
                             + " WHERE OfficeAutomation_Document_UndertakeProj_MainID='" + mainID + "'";


            return DbHelperSQL.Query(sql);
        }


        /// <summary>
        /// 通过项目名称查找申请过物业部承接项目报备申请表、项目联动报数申请表及项目报数申请表的部门
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectFlange(string prjn)
        {
            string sql = "SELECT DISTINCT OfficeAutomation_Document_UndertakeProj_Department AS Dpms FROM t_OfficeAutomation_Document_UndertakeProj"
                       + " WHERE OfficeAutomation_Document_UndertakeProj_Project LIKE '" + prjn + "%' UNION"
                       + " SELECT DISTINCT OfficeAutomation_Document_UtContract_Department AS Dpms FROM t_OfficeAutomation_Document_UtContract"
                       + " WHERE OfficeAutomation_Document_UtContract_Name1 LIKE '" + prjn + "%' OR OfficeAutomation_Document_UtContract_Name2 LIKE '" + prjn + "%' UNION"
                       + " SELECT DISTINCT OfficeAutomation_Document_UtNewProj_Department AS Dpms FROM t_OfficeAutomation_Document_UtNewProj"
                       + " WHERE OfficeAutomation_Document_UtNewProj_Project LIKE '" + prjn + "%' UNION"
                       + " SELECT DISTINCT OfficeAutomation_Document_ProjLinkRepoData_Department AS Dpms FROM t_OfficeAutomation_Document_ProjLinkRepoData"
                       + " WHERE OfficeAutomation_Document_ProjLinkRepoData_ProjName LIKE '" + prjn + "%' UNION"
                       + " SELECT DISTINCT OfficeAutomation_Document_ProjRepoData_Department AS Dpms FROM t_OfficeAutomation_Document_ProjRepoData"
                       + " WHERE OfficeAutomation_Document_ProjRepoData_ProjName LIKE '" + prjn + "%'";

            return DbHelperSQL.Query(sql);
        }

        /// <summary>
        /// 根据部门名称查找区域等信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectStByDpm(string n)
        {
            string sql = "select * from [gzs-fineccdb01].DB_EcCommission.dbo.v_AreaDepartmentDetail"
                       + " where DepartmentName = '" + n + "'";

            return DbHelperSQL.Query(sql);
        }
    }
}

