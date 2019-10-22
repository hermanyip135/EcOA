using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PullafewTwo_Inherit : DA_OfficeAutomation_Document_PullafewTwo_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PullafewTwo_ID]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_MainID]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_Apply]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_ApplyID]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_Department]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1a]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1b]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1c]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1d]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1e]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1f]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1g]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1h]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1i]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1ii]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1j]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1k]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1l]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1m]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1n]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1o]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1p]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1q]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1r]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1s]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1t]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1u]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1v]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2a]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2b]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2c]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2cc]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2d]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2f]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2g]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2h]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_4a]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_4b]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_4c]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_4cc]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_4d]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_4dd]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_4e]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_4f]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_4g]"

                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PullafewTwo_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_PullafewTwo_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PullafewTwo_ID]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_MainID]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_Apply]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_ApplyID]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_Department]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1a]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1b]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1c]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1d]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1e]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1f]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1g]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1h]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1i]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1ii]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1j]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1k]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1l]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1m]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1n]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1o]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1p]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1q]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1r]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1s]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1t]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1u]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_1v]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2a]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2b]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2c]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2cc]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2d]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2f]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2g]"
                           + "           ,[OfficeAutomation_Document_PullafewTwo_2h]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PullafewTwo_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_PullafewTwo_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 自定义

        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_PullafewTwo obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_PullafewTwo_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_PullafewTwo();
            Baseobj.OfficeAutomation_Document_PullafewTwo_ID = obj.OfficeAutomation_Document_PullafewTwo_ID;
            Baseobj.OfficeAutomation_Document_PullafewTwo_MainID = obj.OfficeAutomation_Document_PullafewTwo_MainID;
            Baseobj.OfficeAutomation_Document_PullafewTwo_Apply = obj.OfficeAutomation_Document_PullafewTwo_Apply;
            Baseobj.OfficeAutomation_Document_PullafewTwo_ApplyDate = obj.OfficeAutomation_Document_PullafewTwo_ApplyDate;
            Baseobj.OfficeAutomation_Document_PullafewTwo_Department = obj.OfficeAutomation_Document_PullafewTwo_Department;

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_PullafewTwo_MainID]='" + obj.OfficeAutomation_Document_PullafewTwo_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_PullafewTwo resultobj;
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
