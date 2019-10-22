using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SysPower_Inherit : DA_OfficeAutomation_Document_SysPower_Operate
    {
        /// <summary>
        /// 通过MainID查询(汇瀚/二级市场/后勤)IT权限申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_SysPower_ID]"
                           + "           ,[OfficeAutomation_Document_SysPower_MainID]"
                           + "           ,[OfficeAutomation_Document_SysPower_DepartmentID]"
                           + "           ,[OfficeAutomation_Document_SysPower_Department]"
                           + "           ,[OfficeAutomation_Document_SysPower_Apply]"
                           + "           ,[OfficeAutomation_Document_SysPower_Phone]"
                           + "           ,[OfficeAutomation_Document_SysPower_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SysPower_ReqContent]"
                           + "           ,[OfficeAutomation_Document_SysPower_Deal]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + "          ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysPower] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysPower_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SysPower_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询(汇瀚/二级市场/后勤)IT权限申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT [OfficeAutomation_Document_SysPower_ID]"
                           + "           ,[OfficeAutomation_Document_SysPower_MainID]"
                           + "           ,[OfficeAutomation_Document_SysPower_DepartmentID]"
                           + "           ,[OfficeAutomation_Document_SysPower_Department]"
                           + "           ,[OfficeAutomation_Document_SysPower_Apply]"
                           + "           ,[OfficeAutomation_Document_SysPower_Phone]"
                           + "           ,[OfficeAutomation_Document_SysPower_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SysPower_ReqContent]"
                           + "           ,[OfficeAutomation_Document_SysPower_Deal]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysPower] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SysPower_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SysPower_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据id给对应(汇瀚/二级市场/后勤)IT权限申请表处理情况
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public bool UpdateDealByID(string id, string deal)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysPower]"
                                + "   SET [OfficeAutomation_Document_SysPower_Deal] = '" + deal + "'"
                                + " WHERE [OfficeAutomation_Document_SysPower_ID]='" + id + "'";
            return RunNoneSQL(sql);
        }
    }
}
