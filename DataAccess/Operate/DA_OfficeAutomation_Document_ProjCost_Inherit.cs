using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_ProjCost_Inherit : DA_OfficeAutomation_Document_ProjCost_Operate
    {
        public DA_OfficeAutomation_Document_ProjCost_Inherit()
        { }

        /// <summary>
        /// 通过MainID查询员工项目费用申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT todi.*"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjCost] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjCost_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " WHERE OfficeAutomation_Document_ProjCost_MainID='" + mainID + "'";

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
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjCost]"
                                + "   SET [OfficeAutomation_Document_ProjCost_Remark] = CASE WHEN [OfficeAutomation_Document_ProjCost_Remark] IS NULL THEN '" + remark + "'"
                                + "                                                                                       WHEN CHARINDEX('" + remark + "',[OfficeAutomation_Document_ProjCost_Remark])!=0 THEN [OfficeAutomation_Document_ProjCost_Remark]"
                                + "                                                                                        ELSE  [OfficeAutomation_Document_ProjCost_Remark] + '" + remark + "' END"
                                + " WHERE [OfficeAutomation_Document_ProjCost_ID]='" + id + "'";

            return DbHelperSQL.ExecuteSql(sql);
        }

        public int AddRemarkByID_II(string id, string remark)
        {
            string sql =
@"DECLARE @Remark nvarchar(80)
DECLARE @MainID uniqueidentifier
SELECT @Remark=OfficeAutomation_Document_ProjCost_Remark,@MainID=OfficeAutomation_Document_ProjCost_MainID FROM [t_OfficeAutomation_Document_ProjCost] WHERE [OfficeAutomation_Document_ProjCost_MainID]='{0}'
IF @Remark IS NULL
    BEGIN
        SET @Remark='{1}'
    END
ELSE IF CHARINDEX('{1}',@Remark)!=0
    BEGIN
		SET @Remark=@Remark
	END
ELSE 
    BEGIN
        SET @Remark=@Remark+'{1}'
    END
UPDATE [t_OfficeAutomation_Document_ProjCost] SET OfficeAutomation_Document_ProjCost_Remark=@Remark WHERE [OfficeAutomation_Document_ProjCost_MainID]='{0}'
UPDATE [t_OfficeAutomation_Main] SET [OfficeAutomation_Main_Sremark]=@Remark WHERE OfficeAutomation_Main_ID=@MainID";

            sql = string.Format(sql, id, remark);
            return DbHelperSQL.ExecuteSql(sql);
        }

        //插入或者修改关键内容
        public bool HandleBase(DataEntity.PageModel.T_OfficeAutomation_Document_ProjCost_M obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_ProjCost_MainID == null)
            { return false; }

            #region 必填字段
            var Baseobj = new DataEntity.T_OfficeAutomation_Document_ProjCost();
            Baseobj.OfficeAutomation_Document_ProjCost_ID = new Guid(obj.OfficeAutomation_Document_ProjCost_ID);
            Baseobj.OfficeAutomation_Document_ProjCost_MainID = new Guid(obj.OfficeAutomation_Document_ProjCost_MainID);
            Baseobj.OfficeAutomation_Document_ProjCost_Apply = obj.OfficeAutomation_Document_ProjCost_Apply;
            Baseobj.OfficeAutomation_Document_ProjCost_ApplyForName = obj.OfficeAutomation_Document_ProjCost_ApplyForName;
            Baseobj.OfficeAutomation_Document_ProjCost_ApplyForCode = obj.OfficeAutomation_Document_ProjCost_ApplyForCode;
            Baseobj.OfficeAutomation_Document_ProjCost_Department = obj.OfficeAutomation_Document_ProjCost_Department;
            Baseobj.OfficeAutomation_Document_ProjCost_DepartmentID = new Guid(obj.OfficeAutomation_Document_ProjCost_DepartmentID);
            Baseobj.OfficeAutomation_Document_ProjCost_ApplyDate = Convert.ToDateTime(obj.OfficeAutomation_Document_ProjCost_ApplyDate);
            Baseobj.OfficeAutomation_Document_ProjCost_ReplyPhone = obj.OfficeAutomation_Document_ProjCost_ReplyPhone;
            Baseobj.OfficeAutomation_Document_ProjCost_Project = obj.OfficeAutomation_Document_ProjCost_Project;
            Baseobj.OfficeAutomation_Document_ProjCost_Developer = obj.OfficeAutomation_Document_ProjCost_Developer;
            Baseobj.OfficeAutomation_Document_ProjCost_ProjLeader = obj.OfficeAutomation_Document_ProjCost_ProjLeader;
            Baseobj.OfficeAutomation_Document_ProjCost_ProjBusiLeader = obj.OfficeAutomation_Document_ProjCost_ProjBusiLeader;
            Baseobj.OfficeAutomation_Document_ProjCost_DealOfficeTypeID = obj.OfficeAutomation_Document_ProjCost_DealOfficeTypeID;
            Baseobj.OfficeAutomation_Document_ProjCost_Square = obj.OfficeAutomation_Document_ProjCost_Square;
            Baseobj.OfficeAutomation_Document_ProjCost_PreProjAgenceFee = obj.OfficeAutomation_Document_ProjCost_PreProjAgenceFee;
            Baseobj.OfficeAutomation_Document_ProjCost_BrokerCostApply = obj.OfficeAutomation_Document_ProjCost_BrokerCostApply;
            Baseobj.OfficeAutomation_Document_ProjCost_Receiver = obj.OfficeAutomation_Document_ProjCost_Receiver;
            Baseobj.OfficeAutomation_Document_ProjCost_BrokerCostReason = obj.OfficeAutomation_Document_ProjCost_BrokerCostReason;
            Baseobj.OfficeAutomation_Document_ProjCost_BrokerName = obj.OfficeAutomation_Document_ProjCost_BrokerName;
            #endregion
            //obj是否已经存在
            var where = "[OfficeAutomation_Document_ProjCost_MainID]='" + obj.OfficeAutomation_Document_ProjCost_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_ProjCost resultobj;
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

