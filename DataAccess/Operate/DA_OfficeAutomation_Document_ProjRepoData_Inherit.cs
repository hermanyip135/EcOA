using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_ProjRepoData_Inherit : DA_OfficeAutomation_Document_ProjRepoData_Operate
    {
        public DA_OfficeAutomation_Document_ProjRepoData_Inherit()
        { }

        /// <summary>
        /// 通过MainID查询申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT todi.*"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjRepoData] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjRepoData_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " WHERE OfficeAutomation_Document_ProjRepoData_MainID='" + mainID + "'";

            return DbHelperSQL.Query(sql);
        }

        /// <summary>
        /// 根据id给对应退佣申请表备注,不进行重复标注。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deal"></param>
        /// <returns></returns>
        public int AddRemarkByID(string id, string remark)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjRepoData]"
                                + "   SET [OfficeAutomation_Document_ProjRepoData_Remark] = CASE WHEN [OfficeAutomation_Document_ProjRepoData_Remark] IS NULL THEN '" + remark + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_ProjRepoData_Remark])!=0 THEN [OfficeAutomation_Document_ProjRepoData_Remark]"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_ProjRepoData_Remark] + '" + remark + "' END"
                                + " WHERE [OfficeAutomation_Document_ProjRepoData_ID]='" + id + "'";

            return DbHelperSQL.ExecuteSql(sql);
        }

        //插入或者修改关键内容 2016/8/23 52100
        public bool HandleBase(DataEntity.PageModel.T_OfficeAutomation_Document_ProjRepoData_M obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_ProjRepoData_MainID == null)
            { return false; }

            #region 实体属性赋值
            var Baseobj = new DataEntity.T_OfficeAutomation_Document_ProjRepoData();
            Baseobj.OfficeAutomation_Document_ProjRepoData_ID = new Guid(obj.OfficeAutomation_Document_ProjRepoData_ID);
            Baseobj.OfficeAutomation_Document_ProjRepoData_MainID = new Guid(obj.OfficeAutomation_Document_ProjRepoData_MainID);
            Baseobj.OfficeAutomation_Document_ProjRepoData_Department = obj.OfficeAutomation_Document_ProjRepoData_Department;
            Baseobj.OfficeAutomation_Document_ProjRepoData_ApplyDate = Convert.ToDateTime(obj.OfficeAutomation_Document_ProjRepoData_ApplyDate);
            Baseobj.OfficeAutomation_Document_ProjRepoData_ReplyPhone = obj.OfficeAutomation_Document_ProjRepoData_ReplyPhone;
            Baseobj.OfficeAutomation_Document_ProjRepoData_ApplyID = obj.OfficeAutomation_Document_ProjRepoData_ApplyID;
            Baseobj.OfficeAutomation_Document_ProjRepoData_ApplyTypeRate = obj.OfficeAutomation_Document_ProjRepoData_ApplyTypeRate;
            Baseobj.OfficeAutomation_Document_ProjRepoData_ProjName = obj.OfficeAutomation_Document_ProjRepoData_ProjName;
            Baseobj.OfficeAutomation_Document_ProjRepoData_HavePreSaleID = Convert.ToBoolean(obj.OfficeAutomation_Document_ProjRepoData_HavePreSaleID);
            Baseobj.OfficeAutomation_Document_ProjRepoData_ProjAddress = obj.OfficeAutomation_Document_ProjRepoData_ProjAddress;
            Baseobj.OfficeAutomation_Document_ProjRepoData_DeveloperName = obj.OfficeAutomation_Document_ProjRepoData_DeveloperName;
            Baseobj.OfficeAutomation_Document_ProjRepoData_GroupName = obj.OfficeAutomation_Document_ProjRepoData_GroupName;
            Baseobj.OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs = obj.OfficeAutomation_Document_ProjRepoData_DealOfficeTypeIDs;
            Baseobj.OfficeAutomation_Document_ProjRepoData_DealOfficeOther = obj.OfficeAutomation_Document_ProjRepoData_DealOfficeOther;
            Baseobj.OfficeAutomation_Document_ProjRepoData_AgentStartDate = obj.OfficeAutomation_Document_ProjRepoData_AgentStartDate;
            Baseobj.OfficeAutomation_Document_ProjRepoData_AgentEndDate = obj.OfficeAutomation_Document_ProjRepoData_AgentEndDate;
            Baseobj.OfficeAutomation_Document_ProjRepoData_PreComm = obj.OfficeAutomation_Document_ProjRepoData_PreComm;
            Baseobj.OfficeAutomation_Document_ProjRepoData_GoodsQuantity = obj.OfficeAutomation_Document_ProjRepoData_GoodsQuantity;
            Baseobj.OfficeAutomation_Document_ProjRepoData_GoodsValue = obj.OfficeAutomation_Document_ProjRepoData_GoodsValue;
            Baseobj.OfficeAutomation_Document_ProjRepoData_CommPoint = obj.OfficeAutomation_Document_ProjRepoData_CommPoint;
            Baseobj.OfficeAutomation_Document_ProjRepoData_AgentModel = Convert.ToInt32(obj.OfficeAutomation_Document_ProjRepoData_AgentModel);
            Baseobj.OfficeAutomation_Document_ProjRepoData_ContractType = Convert.ToInt32(obj.OfficeAutomation_Document_ProjRepoData_ContractType);
            Baseobj.OfficeAutomation_Document_ProjRepoData_HaveCoopCost = Convert.ToBoolean(obj.OfficeAutomation_Document_ProjRepoData_HaveCoopCost);
            Baseobj.OfficeAutomation_Document_ProjRepoData_HaveCoopConf = Convert.ToBoolean(obj.OfficeAutomation_Document_ProjRepoData_HaveCoopConf);
            Baseobj.OfficeAutomation_Document_ProjRepoData_IsSignBack = Convert.ToBoolean(obj.OfficeAutomation_Document_ProjRepoData_IsSignBack);
            Baseobj.OfficeAutomation_Document_ProjRepoData_ProjType = Convert.ToInt32(obj.OfficeAutomation_Document_ProjRepoData_ProjType);
            Baseobj.OfficeAutomation_Document_ProjRepoData_Apply = obj.OfficeAutomation_Document_ProjRepoData_Apply;
            #endregion

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_ProjRepoData_MainID]='" + obj.OfficeAutomation_Document_ProjRepoData_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_ProjRepoData resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Insert(Baseobj);
            }
            return resultobj != null;
        }
    }
}

