using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PartTime_Inherit : DA_OfficeAutomation_Document_PartTime_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PartTime_ID]"
                           + "           ,[OfficeAutomation_Document_PartTime_MainID]"
                           + "           ,[OfficeAutomation_Document_PartTime_Apply]"
                           + "           ,[OfficeAutomation_Document_PartTime_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_PartTime_ApplyID]"
                           + "           ,[OfficeAutomation_Document_PartTime_Department]"
                           + "           ,[OfficeAutomation_Document_PartTime_1taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_2taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_3taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_4taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_5taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_6taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_7taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_8taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_9taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_DealOfficeTypeIDs]"
                           + "           ,[OfficeAutomation_Document_PartTime_10taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_11taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_12taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_13taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_14taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_15taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_16taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_17taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_18taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_19taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_20taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_21taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_22taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_23taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_24taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_25taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_26taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_27taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_28taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_29taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_30taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_31taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_32taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_33taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_34taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_35taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_36taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_37taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_38taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_39taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_40taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_41taC]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PartTime] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PartTime_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_PartTime_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_PartTime_ID]"
                           + "           ,[OfficeAutomation_Document_PartTime_MainID]"
                           + "           ,[OfficeAutomation_Document_PartTime_Apply]"
                           + "           ,[OfficeAutomation_Document_PartTime_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_PartTime_ApplyID]"
                           + "           ,[OfficeAutomation_Document_PartTime_Department]"
                           + "           ,[OfficeAutomation_Document_PartTime_1taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_2taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_3taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_4taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_5taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_6taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_7taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_8taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_9taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_DealOfficeTypeIDs]"
                           + "           ,[OfficeAutomation_Document_PartTime_10taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_11taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_12taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_13taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_14taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_15taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_16taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_17taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_18taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_19taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_20taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_21taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_22taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_23taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_24taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_25taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_26taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_27taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_28taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_29taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_30taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_31taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_32taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_33taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_34taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_35taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_36taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_37taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_38taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_39taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_40taC]"
                           + "           ,[OfficeAutomation_Document_PartTime_41taC]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PartTime] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_PartTime_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_PartTime_ID='" + ID + "'";

            return RunSQL(sql);
        }

        public DataEntity.T_OfficeAutomation_Document_PartTime Add(DataEntity.T_OfficeAutomation_Document_PartTime obj)
        {
            DAL.DalBase<DataEntity.T_OfficeAutomation_Document_PartTime> dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_PartTime>();
            return dal.Add(obj);
        }
        public DataEntity.T_OfficeAutomation_Document_PartTime Edit(DataEntity.T_OfficeAutomation_Document_PartTime obj)
        {
            DAL.DalBase<DataEntity.T_OfficeAutomation_Document_PartTime> dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_PartTime>();
            return dal.Edit(obj);
        }
    }
}
