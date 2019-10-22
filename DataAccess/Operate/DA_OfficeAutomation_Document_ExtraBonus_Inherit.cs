using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_ExtraBonus_Inherit : DA_OfficeAutomation_Document_ExtraBonus_Operate
    {
        public DA_OfficeAutomation_Document_ExtraBonus_Inherit()
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
                             + "         ,tdosm.OfficeAutomation_RewardPayType_Name"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ExtraBonus] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ExtraBonus_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_RewardPayType tdosm ON tdosm.OfficeAutomation_RewardPayType_ID = todi.OfficeAutomation_Document_ExtraBonus_RewardPayTypeID"
                             + " WHERE OfficeAutomation_Document_ExtraBonus_MainID='" + mainID + "'";

            return DbHelperSQL.Query(sql);
        }
    }
}

