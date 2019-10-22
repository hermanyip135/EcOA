using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SpecialNumber_Inherit : DA_OfficeAutomation_Document_SpecialNumber_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SpecialNumber_ID]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_MainID]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Apply]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Department]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Subject]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Fax]"

                           + "           ,[OfficeAutomation_Document_SpecialNumber_DealNature]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Names]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Period]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_ApplyNo]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_DealOfficeOther]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_AgentModel]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_TheReason]"

                           + "           ,[OfficeAutomation_Document_SpecialNumber_Describe]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialNumber] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SpecialNumber_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SpecialNumber_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SpecialNumber_ID]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_MainID]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Apply]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Department]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Subject]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_ReplyPhone]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Fax]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_DealNature]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Names]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Period]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_ApplyNo]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_DealOfficeTypeIDs]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_DealOfficeOther]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_AgentModel]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_TheReason]"
                           + "           ,[OfficeAutomation_Document_SpecialNumber_Describe]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialNumber] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SpecialNumber_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SpecialNumber_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_SpecialNumber obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_SpecialNumber_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_SpecialNumber();
            Baseobj = obj;
            //obj是否已经存在
            var where = "[OfficeAutomation_Document_SpecialNumber_MainID]='" + obj.OfficeAutomation_Document_SpecialNumber_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_SpecialNumber resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = TemEdit(Baseobj);
            }
            else
            {
                //Add
                resultobj = TemAdd(Baseobj);
            }
            return resultobj != null;
        }

        #endregion
    }
}
