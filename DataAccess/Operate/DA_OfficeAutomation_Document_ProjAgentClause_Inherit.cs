using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_ProjAgentClause_Inherit : DA_OfficeAutomation_Document_ProjAgentClause_Operate
    {
        public DA_OfficeAutomation_Document_ProjAgentClause_Inherit()
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
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjAgentClause] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjAgentClause_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " WHERE OfficeAutomation_Document_ProjAgentClause_MainID='" + mainID + "'";

            return DbHelperSQL.Query(sql);
        }

        //插入或者修改关键内容
        public bool HandleBase(DataEntity.PageModel.T_OfficeAutomation_Document_ProjAgentClause_M obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_ProjAgentClause_MainID == null)
            { return false; }

            #region 实体属性赋值
            var Baseobj = new DataEntity.T_OfficeAutomation_Document_ProjAgentClause();
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ID = new Guid(obj.OfficeAutomation_Document_ProjAgentClause_ID);
            Baseobj.OfficeAutomation_Document_ProjAgentClause_MainID = new Guid(obj.OfficeAutomation_Document_ProjAgentClause_MainID);
            Baseobj.OfficeAutomation_Document_ProjAgentClause_Apply = obj.OfficeAutomation_Document_ProjAgentClause_Apply;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ApplyDate = Convert.ToDateTime(obj.OfficeAutomation_Document_ProjAgentClause_ApplyDate);
            Baseobj.OfficeAutomation_Document_ProjAgentClause_Department = obj.OfficeAutomation_Document_ProjAgentClause_Department;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ReplyPhone = obj.OfficeAutomation_Document_ProjAgentClause_ReplyPhone;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ApplyID = obj.OfficeAutomation_Document_ProjAgentClause_ApplyID;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ProjName = obj.OfficeAutomation_Document_ProjAgentClause_ProjName;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ProjAddress = obj.OfficeAutomation_Document_ProjAgentClause_ProjAddress;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_DeveloperName = obj.OfficeAutomation_Document_ProjAgentClause_DeveloperName;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ProjAddress = obj.OfficeAutomation_Document_ProjAgentClause_ProjAddress;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_AgentStart = obj.OfficeAutomation_Document_ProjAgentClause_AgentStart;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_AgentEnd = obj.OfficeAutomation_Document_ProjAgentClause_AgentEnd;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_SaleDate = obj.OfficeAutomation_Document_ProjAgentClause_SaleDate;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs = obj.OfficeAutomation_Document_ProjAgentClause_DealOfficeTypeIDs;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_DealOfficeOther = obj.OfficeAutomation_Document_ProjAgentClause_DealOfficeOther;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_GoodsQuantity = obj.OfficeAutomation_Document_ProjAgentClause_GoodsQuantity;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_GoodsValue = obj.OfficeAutomation_Document_ProjAgentClause_GoodsValue;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_PreComm = obj.OfficeAutomation_Document_ProjAgentClause_PreComm;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_AgentModel = Convert.ToInt32(obj.OfficeAutomation_Document_ProjAgentClause_AgentModel);
            Baseobj.OfficeAutomation_Document_ProjAgentClause_CommPoint = obj.OfficeAutomation_Document_ProjAgentClause_CommPoint;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ContractType = Convert.ToInt32(obj.OfficeAutomation_Document_ProjAgentClause_ContractType);
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ContractTypeOther = obj.OfficeAutomation_Document_ProjAgentClause_ContractTypeOther;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm = obj.OfficeAutomation_Document_ProjAgentClause_ClauseSettleComm;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ClauseFine = obj.OfficeAutomation_Document_ProjAgentClause_ClauseFine;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit = obj.OfficeAutomation_Document_ProjAgentClause_ClauseAreaLimit;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck = obj.OfficeAutomation_Document_ProjAgentClause_ClausePerforCheck;
            Baseobj.OfficeAutomation_Document_ProjAgentClause_ClauseHonest = obj.OfficeAutomation_Document_ProjAgentClause_ClauseHonest;

            #endregion

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_ProjAgentClause_MainID]='" + obj.OfficeAutomation_Document_ProjAgentClause_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_ProjAgentClause resultobj;
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

