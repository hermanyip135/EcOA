using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PullafewRd_Inherit : DA_OfficeAutomation_Document_PullafewRd_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PullafewRd_ID]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_MainID]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_Apply]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_ApplyID]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_Department]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1a]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1b]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1c]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1d]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1e]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1f]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1g]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1h]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1i]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1j]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1k]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1l]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1m]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1n]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1o]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1p]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1q]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1r]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1s]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1t]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1ut]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1u]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1v]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2a]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2b]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2c]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2d]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2e]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2f]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4a]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4b]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4c]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4cc]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4d]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4dd]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4e]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4f]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4g]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_4h]"
                           + "           ,OfficeAutomation_Document_PullafewRd_1pa"
                           + "           ,OfficeAutomation_Document_PullafewRd_1fc"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewRd] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PullafewRd_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_PullafewRd_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PullafewRd_ID]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_MainID]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_Apply]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_ApplyID]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_Department]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1a]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1b]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1c]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1d]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1e]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1f]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1g]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1h]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1i]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1j]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1k]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1l]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1m]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1n]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1o]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1p]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1q]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1r]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1s]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1t]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1ut]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1u]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_1v]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2a]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2b]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2c]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2d]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2e]"
                           + "           ,[OfficeAutomation_Document_PullafewRd_2f]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewRd] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PullafewRd_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_PullafewRd_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_PullafewRd obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_PullafewRd_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_PullafewRd();
            Baseobj.OfficeAutomation_Document_PullafewRd_ID = obj.OfficeAutomation_Document_PullafewRd_ID;
            Baseobj.OfficeAutomation_Document_PullafewRd_MainID = obj.OfficeAutomation_Document_PullafewRd_MainID;
            Baseobj.OfficeAutomation_Document_PullafewRd_Apply = obj.OfficeAutomation_Document_PullafewRd_Apply;
            Baseobj.OfficeAutomation_Document_PullafewRd_ApplyDate = obj.OfficeAutomation_Document_PullafewRd_ApplyDate;
            Baseobj.OfficeAutomation_Document_PullafewRd_Department = obj.OfficeAutomation_Document_PullafewRd_Department;

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_PullafewRd_MainID]='" + obj.OfficeAutomation_Document_PullafewRd_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_PullafewRd resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Add(Baseobj);
            }
            return resultobj != null;
        }

        #endregion
    }
}
