using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_NewPersInterests_Detail_Inherit : DA_OfficeAutomation_Document_NewPersInterests_Detail_Operate
    {
        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_NewPersInterests_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_RelativesName]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_InDepartment]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_Position]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_Relationship]"
                    //+ "            ,[OfficeAutomation_Document_NewPersInterests_Detail_RelationshipOne]"
                    //+ "            ,[OfficeAutomation_Document_NewPersInterests_Detail_RelationshipTwo]"
                    +"              ,OfficeAutomation_Document_NewPersInterests_Detail_rdInApply"
                    +"              ,OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID"
                    +"              ,OfficeAutomation_Document_NewPersInterests_Detail_txtTfid"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NewPersInterests_Detail]"
                    + "      WHERE [OfficeAutomation_Document_NewPersInterests_Detail_MainID]='" + id + "'"
                    + "  ORDER BY [OfficeAutomation_Document_NewPersInterests_Detail_RelativesName] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_NewPersInterests_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_RelativesName]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_InDepartment]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_Position]"
                    + "            ,[OfficeAutomation_Document_NewPersInterests_Detail_Relationship]"
                    //+ "            ,[OfficeAutomation_Document_NewPersInterests_Detail_RelationshipOne]"
                    //+ "            ,[OfficeAutomation_Document_NewPersInterests_Detail_RelationshipTwo]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NewPersInterests_Detail]"
                    + "      WHERE [OfficeAutomation_Document_NewPersInterests_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_NewPersInterests_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_NewPersInterests toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_NewPersInterests_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_NewPersInterests_Detail_RelativesName] ASC";

            return RunSQL(sql);
        }


        //根据mainid查找出需要导出的数据
        public DataSet GetInterestsInfoByMainIDs(string mainid, int intereststype,string orderids)
        {
            string sql = "";
            if (intereststype == 7)
            {
                sql = "select p.OfficeAutomation_Document_NewPersInterests_ApplyForID as 申请人工号,p.OfficeAutomation_Document_NewPersInterests_Apply as 申请人姓名,p.OfficeAutomation_Document_NewPersInterests_Department as 部门分行 ,de.OfficeAutomation_DepartmentType_Name as 部门性质," +
                        "p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 申请日期,p.OfficeAutomation_Document_NewPersInterests_Apply as 填表人,p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 填表日期," +
                        "case when p.OfficeAutomation_Document_NewPersInterests_DealKind=1 then '买卖'" +
                        " when p.OfficeAutomation_Document_NewPersInterests_DealKind=2 then '租赁'" +
                        " when p.OfficeAutomation_Document_NewPersInterests_DealKind=3 then '买'" +
                        " when p.OfficeAutomation_Document_NewPersInterests_DealKind=4 then '卖' "+
                        " else '租赁' end as 交易类型," +
                        "case when p.OfficeAutomation_Document_NewPersInterests_DealProperty=1 then '一手代理项目' else '二手物业' end as 交易类别,p.OfficeAutomation_Document_NewPersInterests_FollowerNo as 跟进人工号,be.emp_name as 跟进人姓名,be.dept_name as 跟进人分行," +
                        "case p.OfficeAutomation_Document_NewPersInterests_PropertyHander when 1 then '本人' when 2 then '本人及联名('+p.OfficeAutomation_Document_NewPersInterests_MeAndHim+')'  else '直系亲属(关系：'+p.OfficeAutomation_Document_NewPersInterests_Relationship+',姓名：'+p.OfficeAutomation_Document_NewPersInterests_RelationName+')' end  as 业权人, " +
                        " p.OfficeAutomation_Document_NewPersInterests_Building as 物业地址,p.OfficeAutomation_Document_NewPersInterests_AnotherSummary as 其他情况申报说明,d.dept_id"
                         + " ,(select '['+OfficeAutomation_Attach_Name+']' from t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID =  OfficeAutomation_Document_NewPersInterests_MainID FOR XML PATH('')) as 附件名称" +
                        " from t_OfficeAutomation_Document_NewPersInterests as p " +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_employee] as e on p.OfficeAutomation_Document_NewPersInterests_ApplyForID=e.emp_code" +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_employee] as be on p.OfficeAutomation_Document_NewPersInterests_FollowerNo=be.emp_code" +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_department] as d on e.dept_code=d.full_dept_code" +
                        " left join t_Dic_OfficeAutomation_DepartmentType as de on p.OfficeAutomation_Document_NewPersInterests_DepartmentTypeID=de.OfficeAutomation_DepartmentType_ID" +
                        " where OfficeAutomation_Document_NewPersInterests_MainID in (" + mainid + ")";
            }
            else if (intereststype == 8)
            {
                sql = "select p.OfficeAutomation_Document_NewPersInterests_ApplyForID as 申请人工号,p.OfficeAutomation_Document_NewPersInterests_Apply as 申请人姓名,p.OfficeAutomation_Document_NewPersInterests_Department as 部门分行 ,de.OfficeAutomation_DepartmentType_Name as 部门性质," +
                        "p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 申请日期,p.OfficeAutomation_Document_NewPersInterests_Apply as 填表人,p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 填表日期," +
                        "pd.OfficeAutomation_Document_NewPersInterests_Detail_RelativesName as 亲属姓名,pd.OfficeAutomation_Document_NewPersInterests_Detail_InDepartment as 所在部门," +
                        "pd.OfficeAutomation_Document_NewPersInterests_Detail_Position as 担任职位,pd.OfficeAutomation_Document_NewPersInterests_Detail_Relationship as 亲属关系,p.OfficeAutomation_Document_NewPersInterests_AnotherSummary as 其他情况申报说明,d.dept_id" +
                         " ,(select '['+OfficeAutomation_Attach_Name+']' from t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID =  OfficeAutomation_Document_NewPersInterests_MainID FOR XML PATH('')) as 附件名称" +
                        " from t_OfficeAutomation_Document_NewPersInterests as p" +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_employee] as e on p.OfficeAutomation_Document_NewPersInterests_ApplyForID=e.emp_code" +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_department] as d on e.dept_code=d.full_dept_code" +
                        " left join t_Dic_OfficeAutomation_DepartmentType as de on p.OfficeAutomation_Document_NewPersInterests_DepartmentTypeID=de.OfficeAutomation_DepartmentType_ID" +
                        " right join t_OfficeAutomation_Document_NewPersInterests_Detail as pd on p.OfficeAutomation_Document_NewPersInterests_ID=pd.OfficeAutomation_Document_NewPersInterests_Detail_MainID" +
                        " where OfficeAutomation_Document_NewPersInterests_MainID in (" + mainid + ")";
            }
            else if (intereststype == 9)
            {
                sql = "select p.OfficeAutomation_Document_NewPersInterests_ApplyForID as 申请人工号,p.OfficeAutomation_Document_NewPersInterests_Apply as 申请人姓名,p.OfficeAutomation_Document_NewPersInterests_Department as 部门分行 ,de.OfficeAutomation_DepartmentType_Name as 部门性质," +
                    " p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 申请日期,p.OfficeAutomation_Document_NewPersInterests_Apply as 填表人,p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 填表日期," +
                    " case p.OfficeAutomation_Document_NewPersInterests_ApplySomething when 1 then '礼物赠品(名称：'+p.OfficeAutomation_Document_NewPersInterests_GiftName+',价值：'+p.OfficeAutomation_Document_NewPersInterests_GiftPrice+'元)' when 2 then '现金/购物卡'+p.OfficeAutomation_Document_NewPersInterests_CrashOrCard+'元' when 3 then '其他(名称：'+p.OfficeAutomation_Document_NewPersInterests_AnotherName+',价值：'+p.OfficeAutomation_Document_NewPersInterests_AnotherPrice+'元)' else '' end  as 申请事项," +
                    " p.OfficeAutomation_Document_NewPersInterests_GiverOrCompany as '赠送人/单位',p.OfficeAutomation_Document_NewPersInterests_AnotherSummary as 其他情况申报说明,d.dept_id" +
                      " ,(select '['+OfficeAutomation_Attach_Name+']' from t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID =  OfficeAutomation_Document_NewPersInterests_MainID FOR XML PATH('')) as 附件名称" +
                    " from t_OfficeAutomation_Document_NewPersInterests  as p left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_employee] as e " +
                    " on p.OfficeAutomation_Document_NewPersInterests_ApplyForID=e.emp_code" +
                    " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_employee] as be on p.OfficeAutomation_Document_NewPersInterests_FollowerNo=be.emp_code" +
                    " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_department] as d on e.dept_code=d.full_dept_code" +
                    " left join t_Dic_OfficeAutomation_DepartmentType as de on p.OfficeAutomation_Document_NewPersInterests_DepartmentTypeID=de.OfficeAutomation_DepartmentType_ID" +
                    " where OfficeAutomation_Document_NewPersInterests_MainID in (" + mainid + ")";
            }
            else if (intereststype == 10)
            {
                sql = "select p.OfficeAutomation_Document_NewPersInterests_ApplyForID as 申请人工号,p.OfficeAutomation_Document_NewPersInterests_Apply as 申请人姓名,p.OfficeAutomation_Document_NewPersInterests_Department as 部门分行 ,de.OfficeAutomation_DepartmentType_Name as 部门性质," +
                        "p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 申请日期,p.OfficeAutomation_Document_NewPersInterests_Apply as 填表人,p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 填表日期," +
                        "case p.OfficeAutomation_Document_NewPersInterests_Entrust when 1 then '是' else '否' end  as 委托公司代理中介服务, " +
                        "case p.OfficeAutomation_Document_NewPersInterests_BuildingKind when 1 then '住宅' when 2 then '商铺' else '其他:'+OfficeAutomation_Document_NewPersInterests_AnotherBuilding end  as 物业类型, " +
                        "p.OfficeAutomation_Document_NewPersInterests_EntrustNo as 跟进人工号,be.emp_name as 跟进人姓名, be.dept_name as 跟进人分行,p.OfficeAutomation_Document_NewPersInterests_AnotherSummary as 其他情况申报说明,d.dept_id" +
                          " ,(select '['+OfficeAutomation_Attach_Name+']' from t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID =  OfficeAutomation_Document_NewPersInterests_MainID FOR XML PATH('')) as 附件名称" +
                        " from t_OfficeAutomation_Document_NewPersInterests as p" +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_employee] as e on p.OfficeAutomation_Document_NewPersInterests_ApplyForID=e.emp_code" +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_employee] as be on p.OfficeAutomation_Document_NewPersInterests_EntrustNo=be.emp_code " +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_department] as d on e.dept_code=d.full_dept_code" +
                        " left join t_Dic_OfficeAutomation_DepartmentType as de on p.OfficeAutomation_Document_NewPersInterests_DepartmentTypeID=de.OfficeAutomation_DepartmentType_ID" +
                        " where OfficeAutomation_Document_NewPersInterests_MainID in (" + mainid + ")";
            }
            else if (intereststype == 11)
            {
                sql = "select p.OfficeAutomation_Document_NewPersInterests_ApplyForID as 申请人工号,p.OfficeAutomation_Document_NewPersInterests_Apply as 申请人姓名,p.OfficeAutomation_Document_NewPersInterests_Department as 部门分行 ,de.OfficeAutomation_DepartmentType_Name as 部门性质," +
                        "p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 申请日期,p.OfficeAutomation_Document_NewPersInterests_Apply as 填表人,p.OfficeAutomation_Document_NewPersInterests_ApplyDate as 填表日期," +
                        "case p.OfficeAutomation_Document_NewPersInterests_AnotherActivity when 1 then '投资非上市公司并作为该公司股东' else '外部兼职' end  as 申请事项, " +
                        "p.OfficeAutomation_Document_NewPersInterests_Investment as 投资或兼职公司名称,p.OfficeAutomation_Document_NewPersInterests_Ipossition as 投资或兼职职位,p.OfficeAutomation_Document_NewPersInterests_AnotherSummary as 其他情况申报说明,d.dept_id" +
                        " ,(select '['+OfficeAutomation_Attach_Name+']' from t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID =  OfficeAutomation_Document_NewPersInterests_MainID FOR XML PATH('')) as 附件名称" +
                        " from t_OfficeAutomation_Document_NewPersInterests as p" +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_employee] as e on p.OfficeAutomation_Document_NewPersInterests_ApplyForID=e.emp_code" +
                        " left join [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_department] as d on e.dept_code=d.full_dept_code" +
                        " left join t_Dic_OfficeAutomation_DepartmentType as de on p.OfficeAutomation_Document_NewPersInterests_DepartmentTypeID=de.OfficeAutomation_DepartmentType_ID" +
                        " where OfficeAutomation_Document_NewPersInterests_MainID in (" + mainid + ")";
            }

            sql = sql + " Order By charindex(','+rtrim(cast(OfficeAutomation_Document_NewPersInterests_MainID as nvarchar(100)))+',', '," + orderids + ",')";

            return RunSQL(sql);
        }




    }
}
