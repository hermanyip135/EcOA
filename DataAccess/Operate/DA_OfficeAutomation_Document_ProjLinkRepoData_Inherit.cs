using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit : DA_OfficeAutomation_Document_ProjLinkRepoData_Operate
    {
        public DA_OfficeAutomation_Document_ProjLinkRepoData_Inherit()
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
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjLinkRepoData] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjLinkRepoData_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " WHERE OfficeAutomation_Document_ProjLinkRepoData_MainID='" + mainID + "'";

            return DbHelperSQL.Query(sql);
        }

        //插入或者修改关键内容
        public bool HandleBase(DataEntity.PageModel.T_OfficeAutomation_Document_ProjLinkRepoData_M obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_ProjLinkRepoData_MainID == null)
            { return false; }

            #region 实体属性赋值
            var Baseobj = new DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData();
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ID = new Guid(obj.OfficeAutomation_Document_ProjLinkRepoData_ID);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_MainID = new Guid(obj.OfficeAutomation_Document_ProjLinkRepoData_MainID);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_Apply = obj.OfficeAutomation_Document_ProjLinkRepoData_Apply;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ApplyDate = Convert.ToDateTime(obj.OfficeAutomation_Document_ProjLinkRepoData_ApplyDate);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_Department = obj.OfficeAutomation_Document_ProjLinkRepoData_Department;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone = obj.OfficeAutomation_Document_ProjLinkRepoData_ReplyPhone;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ApplyID = obj.OfficeAutomation_Document_ProjLinkRepoData_ApplyID;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ProjName = obj.OfficeAutomation_Document_ProjLinkRepoData_ProjName;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ProjAddress = obj.OfficeAutomation_Document_ProjLinkRepoData_ProjAddress;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_DeveloperName = obj.OfficeAutomation_Document_ProjLinkRepoData_DeveloperName;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_GroupName = obj.OfficeAutomation_Document_ProjLinkRepoData_GroupName;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs = obj.OfficeAutomation_Document_ProjLinkRepoData_DealOfficeTypeIDs;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate = obj.OfficeAutomation_Document_ProjLinkRepoData_AgentStartDate;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate = obj.OfficeAutomation_Document_ProjLinkRepoData_AgentEndDate;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_PreComm = obj.OfficeAutomation_Document_ProjLinkRepoData_PreComm;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity = obj.OfficeAutomation_Document_ProjLinkRepoData_GoodsQuantity;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_GoodsValue = obj.OfficeAutomation_Document_ProjLinkRepoData_GoodsValue;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_CommPoint = obj.OfficeAutomation_Document_ProjLinkRepoData_CommPoint;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_AgentModel = Convert.ToInt32(obj.OfficeAutomation_Document_ProjLinkRepoData_AgentModel);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ContractType = Convert.ToInt32(obj.OfficeAutomation_Document_ProjLinkRepoData_ContractType);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost = Convert.ToBoolean(obj.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopCost);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf = Convert.ToBoolean(obj.OfficeAutomation_Document_ProjLinkRepoData_HaveCoopConf);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_IsSignBack = Convert.ToBoolean(obj.OfficeAutomation_Document_ProjLinkRepoData_IsSignBack);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate = obj.OfficeAutomation_Document_ProjLinkRepoData_LinkStartDate;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate = obj.OfficeAutomation_Document_ProjLinkRepoData_LinkEndDate;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount = obj.OfficeAutomation_Document_ProjLinkRepoData_ProjDepCount;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm = obj.OfficeAutomation_Document_ProjLinkRepoData_ProjDepComm;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice = obj.OfficeAutomation_Document_ProjLinkRepoData_PropDepPrice;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_CalcGetType = Convert.ToInt32(obj.OfficeAutomation_Document_ProjLinkRepoData_CalcGetType);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_AssumeType = Convert.ToInt32(obj.OfficeAutomation_Document_ProjLinkRepoData_AssumeType);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ProjType = Convert.ToInt32(obj.OfficeAutomation_Document_ProjLinkRepoData_ProjType);
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet = obj.OfficeAutomation_Document_ProjLinkRepoData_CommCalcGet;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice = obj.OfficeAutomation_Document_ProjLinkRepoData_ProjDepPrice;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_PropDepCount = obj.OfficeAutomation_Document_ProjLinkRepoData_PropDepCount;
            Baseobj.OfficeAutomation_Document_ProjLinkRepoData_PropDepComm = obj.OfficeAutomation_Document_ProjLinkRepoData_PropDepComm;

            #endregion

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_ProjLinkRepoData_MainID]='" + obj.OfficeAutomation_Document_ProjLinkRepoData_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_ProjLinkRepoData resultobj;
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

