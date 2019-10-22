/*
* DA_OfficeAutomation_Document_ProjWorkCloth_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ProjWorkCloth_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/16 15:54:53    张榕     初版
*
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
	/// <summary>
	/// 数据访问类:DA_OfficeAutomation_Document_ProjWorkCloth_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_ProjWorkCloth_Operate
	{
		public DA_OfficeAutomation_Document_ProjWorkCloth_Operate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ProjWorkCloth_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ProjWorkCloth");
			strSql.Append(" where OfficeAutomation_Document_ProjWorkCloth_ID=@OfficeAutomation_Document_ProjWorkCloth_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjWorkCloth_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ProjWorkCloth model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_ProjWorkCloth(");
            strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ID,OfficeAutomation_Document_ProjWorkCloth_MainID,OfficeAutomation_Document_ProjWorkCloth_Department,OfficeAutomation_Document_ProjWorkCloth_ApplyDate,OfficeAutomation_Document_ProjWorkCloth_Apply,OfficeAutomation_Document_ProjWorkCloth_ReplyPhone,OfficeAutomation_Document_ProjWorkCloth_ApplyID,OfficeAutomation_Document_ProjWorkCloth_ProjName,OfficeAutomation_Document_ProjWorkCloth_DeveloperName,OfficeAutomation_Document_ProjWorkCloth_ProjAddress,OfficeAutomation_Document_ProjWorkCloth_AgentStart,OfficeAutomation_Document_ProjWorkCloth_AgentEnd,OfficeAutomation_Document_ProjWorkCloth_SaleDate,OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs,OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther,OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity,OfficeAutomation_Document_ProjWorkCloth_GoodsValue,OfficeAutomation_Document_ProjWorkCloth_PreComm,OfficeAutomation_Document_ProjWorkCloth_AgentModel,OfficeAutomation_Document_ProjWorkCloth_CommPoint,OfficeAutomation_Document_ProjWorkCloth_WomanNum,OfficeAutomation_Document_ProjWorkCloth_WomanParts,OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice,OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice,OfficeAutomation_Document_ProjWorkCloth_ManNum,OfficeAutomation_Document_ProjWorkCloth_ManParts,OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice,OfficeAutomation_Document_ProjWorkCloth_ManSumPrice,OfficeAutomation_Document_ProjWorkCloth_SumPrice,OfficeAutomation_Document_ProjWorkCloth_Remark,Officeautomation_Document_Projworkcloth_Instruction,OfficeAutomation_Document_ProjWorkCloth_Sign)");
			strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ProjWorkCloth_ID,@OfficeAutomation_Document_ProjWorkCloth_MainID,@OfficeAutomation_Document_ProjWorkCloth_Department,@OfficeAutomation_Document_ProjWorkCloth_ApplyDate,@OfficeAutomation_Document_ProjWorkCloth_Apply,@OfficeAutomation_Document_ProjWorkCloth_ReplyPhone,@OfficeAutomation_Document_ProjWorkCloth_ApplyID,@OfficeAutomation_Document_ProjWorkCloth_ProjName,@OfficeAutomation_Document_ProjWorkCloth_DeveloperName,@OfficeAutomation_Document_ProjWorkCloth_ProjAddress,@OfficeAutomation_Document_ProjWorkCloth_AgentStart,@OfficeAutomation_Document_ProjWorkCloth_AgentEnd,@OfficeAutomation_Document_ProjWorkCloth_SaleDate,@OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs,@OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther,@OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity,@OfficeAutomation_Document_ProjWorkCloth_GoodsValue,@OfficeAutomation_Document_ProjWorkCloth_PreComm,@OfficeAutomation_Document_ProjWorkCloth_AgentModel,@OfficeAutomation_Document_ProjWorkCloth_CommPoint,@OfficeAutomation_Document_ProjWorkCloth_WomanNum,@OfficeAutomation_Document_ProjWorkCloth_WomanParts,@OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice,@OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice,@OfficeAutomation_Document_ProjWorkCloth_ManNum,@OfficeAutomation_Document_ProjWorkCloth_ManParts,@OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice,@OfficeAutomation_Document_ProjWorkCloth_ManSumPrice,@OfficeAutomation_Document_ProjWorkCloth_SumPrice,@OfficeAutomation_Document_ProjWorkCloth_Remark,@Officeautomation_Document_Projworkcloth_Instruction,@OfficeAutomation_Document_ProjWorkCloth_Sign)");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_AgentStart", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_AgentEnd", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_SaleDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_WomanNum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_WomanParts", SqlDbType.NVarChar,300),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ManNum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ManParts", SqlDbType.NVarChar,300),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ManSumPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_SumPrice", SqlDbType.NVarChar,80),
                    new SqlParameter("@Officeautomation_Document_Projworkcloth_Instruction", SqlDbType.NVarChar,4000),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_Remark", SqlDbType.NVarChar,4000),
                    
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_Sign", SqlDbType.NVarChar,80)};
            parameters[0].Value = model.OfficeAutomation_Document_ProjWorkCloth_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ProjWorkCloth_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_ProjWorkCloth_Department;
			parameters[3].Value = model.OfficeAutomation_Document_ProjWorkCloth_ApplyDate;
			parameters[4].Value = model.OfficeAutomation_Document_ProjWorkCloth_Apply;
			parameters[5].Value = model.OfficeAutomation_Document_ProjWorkCloth_ReplyPhone;
			parameters[6].Value = model.OfficeAutomation_Document_ProjWorkCloth_ApplyID;
			parameters[7].Value = model.OfficeAutomation_Document_ProjWorkCloth_ProjName;
			parameters[8].Value = model.OfficeAutomation_Document_ProjWorkCloth_DeveloperName;
			parameters[9].Value = model.OfficeAutomation_Document_ProjWorkCloth_ProjAddress;
			parameters[10].Value = model.OfficeAutomation_Document_ProjWorkCloth_AgentStart;
			parameters[11].Value = model.OfficeAutomation_Document_ProjWorkCloth_AgentEnd;
			parameters[12].Value = model.OfficeAutomation_Document_ProjWorkCloth_SaleDate;
			parameters[13].Value = model.OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs;
			parameters[14].Value = model.OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther;
			parameters[15].Value = model.OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity;
			parameters[16].Value = model.OfficeAutomation_Document_ProjWorkCloth_GoodsValue;
			parameters[17].Value = model.OfficeAutomation_Document_ProjWorkCloth_PreComm;
			parameters[18].Value = model.OfficeAutomation_Document_ProjWorkCloth_AgentModel;
			parameters[19].Value = model.OfficeAutomation_Document_ProjWorkCloth_CommPoint;
			parameters[20].Value = model.OfficeAutomation_Document_ProjWorkCloth_WomanNum;
			parameters[21].Value = model.OfficeAutomation_Document_ProjWorkCloth_WomanParts;
			parameters[22].Value = model.OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice;
			parameters[23].Value = model.OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice;
			parameters[24].Value = model.OfficeAutomation_Document_ProjWorkCloth_ManNum;
			parameters[25].Value = model.OfficeAutomation_Document_ProjWorkCloth_ManParts;
			parameters[26].Value = model.OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice;
			parameters[27].Value = model.OfficeAutomation_Document_ProjWorkCloth_ManSumPrice;
			parameters[28].Value = model.OfficeAutomation_Document_ProjWorkCloth_SumPrice;
            parameters[29].Value = model.Officeautomation_Document_Projworkcloth_Instruction;
			parameters[30].Value = model.OfficeAutomation_Document_ProjWorkCloth_Remark;
            
			parameters[31].Value = model.OfficeAutomation_Document_ProjWorkCloth_Sign;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DataEntity.T_OfficeAutomation_Document_ProjWorkCloth model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ProjWorkCloth set ");
			//strSql.Append("OfficeAutomation_Document_ProjWorkCloth_MainID=@OfficeAutomation_Document_ProjWorkCloth_MainID,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_Department=@OfficeAutomation_Document_ProjWorkCloth_Department,");
			//strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ApplyDate=@OfficeAutomation_Document_ProjWorkCloth_ApplyDate,");
			//strSql.Append("OfficeAutomation_Document_ProjWorkCloth_Apply=@OfficeAutomation_Document_ProjWorkCloth_Apply,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ReplyPhone=@OfficeAutomation_Document_ProjWorkCloth_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ApplyID=@OfficeAutomation_Document_ProjWorkCloth_ApplyID,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ProjName=@OfficeAutomation_Document_ProjWorkCloth_ProjName,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_DeveloperName=@OfficeAutomation_Document_ProjWorkCloth_DeveloperName,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ProjAddress=@OfficeAutomation_Document_ProjWorkCloth_ProjAddress,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_AgentStart=@OfficeAutomation_Document_ProjWorkCloth_AgentStart,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_AgentEnd=@OfficeAutomation_Document_ProjWorkCloth_AgentEnd,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_SaleDate=@OfficeAutomation_Document_ProjWorkCloth_SaleDate,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs=@OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther=@OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity=@OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_GoodsValue=@OfficeAutomation_Document_ProjWorkCloth_GoodsValue,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_PreComm=@OfficeAutomation_Document_ProjWorkCloth_PreComm,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_AgentModel=@OfficeAutomation_Document_ProjWorkCloth_AgentModel,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_CommPoint=@OfficeAutomation_Document_ProjWorkCloth_CommPoint,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_WomanNum=@OfficeAutomation_Document_ProjWorkCloth_WomanNum,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_WomanParts=@OfficeAutomation_Document_ProjWorkCloth_WomanParts,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice=@OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice=@OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ManNum=@OfficeAutomation_Document_ProjWorkCloth_ManNum,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ManParts=@OfficeAutomation_Document_ProjWorkCloth_ManParts,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice=@OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_ManSumPrice=@OfficeAutomation_Document_ProjWorkCloth_ManSumPrice,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_SumPrice=@OfficeAutomation_Document_ProjWorkCloth_SumPrice,");
            strSql.Append("Officeautomation_Document_Projworkcloth_Instruction=@Officeautomation_Document_Projworkcloth_Instruction,");
			strSql.Append("OfficeAutomation_Document_ProjWorkCloth_Remark=@OfficeAutomation_Document_ProjWorkCloth_Remark");
            
			//strSql.Append("OfficeAutomation_Document_ProjWorkCloth_Sign=@OfficeAutomation_Document_ProjWorkCloth_Sign");
			strSql.Append(" where OfficeAutomation_Document_ProjWorkCloth_ID=@OfficeAutomation_Document_ProjWorkCloth_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_Department", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ApplyDate", SqlDbType.DateTime),
					//new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ProjName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_DeveloperName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ProjAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_AgentStart", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_AgentEnd", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_SaleDate", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity", SqlDbType.NVarChar,800),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_GoodsValue", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_PreComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_AgentModel", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_CommPoint", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_WomanNum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_WomanParts", SqlDbType.NVarChar,300),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ManNum", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ManParts", SqlDbType.NVarChar,300),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ManSumPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_SumPrice", SqlDbType.NVarChar,80),
                    new SqlParameter("@Officeautomation_Document_Projworkcloth_Instruction", SqlDbType.NVarChar,4000),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_Remark", SqlDbType.NVarChar,4000),
                    
					//new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_Sign", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_ProjWorkCloth_MainID;
			parameters[0].Value = model.OfficeAutomation_Document_ProjWorkCloth_Department;
			//parameters[2].Value = model.OfficeAutomation_Document_ProjWorkCloth_ApplyDate;
			//parameters[3].Value = model.OfficeAutomation_Document_ProjWorkCloth_Apply;
			parameters[1].Value = model.OfficeAutomation_Document_ProjWorkCloth_ReplyPhone;
			parameters[2].Value = model.OfficeAutomation_Document_ProjWorkCloth_ApplyID;
			parameters[3].Value = model.OfficeAutomation_Document_ProjWorkCloth_ProjName;
			parameters[4].Value = model.OfficeAutomation_Document_ProjWorkCloth_DeveloperName;
			parameters[5].Value = model.OfficeAutomation_Document_ProjWorkCloth_ProjAddress;
			parameters[6].Value = model.OfficeAutomation_Document_ProjWorkCloth_AgentStart;
			parameters[7].Value = model.OfficeAutomation_Document_ProjWorkCloth_AgentEnd;
			parameters[8].Value = model.OfficeAutomation_Document_ProjWorkCloth_SaleDate;
			parameters[9].Value = model.OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs;
			parameters[10].Value = model.OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther;
			parameters[11].Value = model.OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity;
			parameters[12].Value = model.OfficeAutomation_Document_ProjWorkCloth_GoodsValue;
			parameters[13].Value = model.OfficeAutomation_Document_ProjWorkCloth_PreComm;
			parameters[14].Value = model.OfficeAutomation_Document_ProjWorkCloth_AgentModel;
			parameters[15].Value = model.OfficeAutomation_Document_ProjWorkCloth_CommPoint;
			parameters[16].Value = model.OfficeAutomation_Document_ProjWorkCloth_WomanNum;
			parameters[17].Value = model.OfficeAutomation_Document_ProjWorkCloth_WomanParts;
			parameters[18].Value = model.OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice;
			parameters[19].Value = model.OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice;
			parameters[20].Value = model.OfficeAutomation_Document_ProjWorkCloth_ManNum;
			parameters[21].Value = model.OfficeAutomation_Document_ProjWorkCloth_ManParts;
			parameters[22].Value = model.OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice;
			parameters[23].Value = model.OfficeAutomation_Document_ProjWorkCloth_ManSumPrice;
			parameters[24].Value = model.OfficeAutomation_Document_ProjWorkCloth_SumPrice;
            parameters[25].Value = model.Officeautomation_Document_Projworkcloth_Instruction;
			parameters[26].Value = model.OfficeAutomation_Document_ProjWorkCloth_Remark;
            
			//parameters[29].Value = model.OfficeAutomation_Document_ProjWorkCloth_Sign;
			parameters[27].Value = model.OfficeAutomation_Document_ProjWorkCloth_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string OfficeAutomation_Document_ProjWorkCloth_ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_ProjWorkCloth_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ProjWorkCloth_ID);

            int rows;
            DbHelperSQL.RunProcedure(strSql.ToString(), parameters, out rows);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string OfficeAutomation_Document_ProjWorkCloth_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ProjWorkCloth ");
			strSql.Append(" where OfficeAutomation_Document_ProjWorkCloth_ID in ("+OfficeAutomation_Document_ProjWorkCloth_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DataEntity.T_OfficeAutomation_Document_ProjWorkCloth GetModel(Guid OfficeAutomation_Document_ProjWorkCloth_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 OfficeAutomation_Document_ProjWorkCloth_ID,OfficeAutomation_Document_ProjWorkCloth_MainID,OfficeAutomation_Document_ProjWorkCloth_Department,OfficeAutomation_Document_ProjWorkCloth_ApplyDate,OfficeAutomation_Document_ProjWorkCloth_Apply,OfficeAutomation_Document_ProjWorkCloth_ReplyPhone,OfficeAutomation_Document_ProjWorkCloth_ApplyID,OfficeAutomation_Document_ProjWorkCloth_ProjName,OfficeAutomation_Document_ProjWorkCloth_DeveloperName,OfficeAutomation_Document_ProjWorkCloth_ProjAddress,OfficeAutomation_Document_ProjWorkCloth_AgentStart,OfficeAutomation_Document_ProjWorkCloth_AgentEnd,OfficeAutomation_Document_ProjWorkCloth_SaleDate,OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs,OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther,OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity,OfficeAutomation_Document_ProjWorkCloth_GoodsValue,OfficeAutomation_Document_ProjWorkCloth_PreComm,OfficeAutomation_Document_ProjWorkCloth_AgentModel,OfficeAutomation_Document_ProjWorkCloth_CommPoint,OfficeAutomation_Document_ProjWorkCloth_WomanNum,OfficeAutomation_Document_ProjWorkCloth_WomanParts,OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice,OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice,OfficeAutomation_Document_ProjWorkCloth_ManNum,OfficeAutomation_Document_ProjWorkCloth_ManParts,OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice,OfficeAutomation_Document_ProjWorkCloth_ManSumPrice,OfficeAutomation_Document_ProjWorkCloth_SumPrice,OfficeAutomation_Document_ProjWorkCloth_Remark,Officeautomation_Document_Projworkcloth_Instruction,OfficeAutomation_Document_ProjWorkCloth_Sign from t_OfficeAutomation_Document_ProjWorkCloth ");
			strSql.Append(" where OfficeAutomation_Document_ProjWorkCloth_ID=@OfficeAutomation_Document_ProjWorkCloth_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ProjWorkCloth_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ProjWorkCloth_ID;

			DataEntity.T_OfficeAutomation_Document_ProjWorkCloth model=new DataEntity.T_OfficeAutomation_Document_ProjWorkCloth();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DataEntity.T_OfficeAutomation_Document_ProjWorkCloth DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_ProjWorkCloth model=new DataEntity.T_OfficeAutomation_Document_ProjWorkCloth();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_ProjWorkCloth_ID"]!=null && row["OfficeAutomation_Document_ProjWorkCloth_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ID= new Guid(row["OfficeAutomation_Document_ProjWorkCloth_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_MainID"]!=null && row["OfficeAutomation_Document_ProjWorkCloth_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjWorkCloth_MainID= new Guid(row["OfficeAutomation_Document_ProjWorkCloth_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_Department"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_Department=row["OfficeAutomation_Document_ProjWorkCloth_Department"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_ApplyDate"]!=null && row["OfficeAutomation_Document_ProjWorkCloth_ApplyDate"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ApplyDate=DateTime.Parse(row["OfficeAutomation_Document_ProjWorkCloth_ApplyDate"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_Apply"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_Apply=row["OfficeAutomation_Document_ProjWorkCloth_Apply"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_ReplyPhone"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ReplyPhone=row["OfficeAutomation_Document_ProjWorkCloth_ReplyPhone"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_ApplyID"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ApplyID=row["OfficeAutomation_Document_ProjWorkCloth_ApplyID"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_ProjName"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ProjName=row["OfficeAutomation_Document_ProjWorkCloth_ProjName"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_DeveloperName"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_DeveloperName=row["OfficeAutomation_Document_ProjWorkCloth_DeveloperName"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_ProjAddress"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ProjAddress=row["OfficeAutomation_Document_ProjWorkCloth_ProjAddress"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_AgentStart"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_AgentStart=row["OfficeAutomation_Document_ProjWorkCloth_AgentStart"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_AgentEnd"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_AgentEnd=row["OfficeAutomation_Document_ProjWorkCloth_AgentEnd"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_SaleDate"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_SaleDate=row["OfficeAutomation_Document_ProjWorkCloth_SaleDate"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs=row["OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther=row["OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity=row["OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_GoodsValue"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_GoodsValue=row["OfficeAutomation_Document_ProjWorkCloth_GoodsValue"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_PreComm"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_PreComm=row["OfficeAutomation_Document_ProjWorkCloth_PreComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_AgentModel"]!=null && row["OfficeAutomation_Document_ProjWorkCloth_AgentModel"].ToString()!="")
				{
					model.OfficeAutomation_Document_ProjWorkCloth_AgentModel=int.Parse(row["OfficeAutomation_Document_ProjWorkCloth_AgentModel"].ToString());
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_CommPoint"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_CommPoint=row["OfficeAutomation_Document_ProjWorkCloth_CommPoint"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_WomanNum"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_WomanNum=row["OfficeAutomation_Document_ProjWorkCloth_WomanNum"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_WomanParts"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_WomanParts=row["OfficeAutomation_Document_ProjWorkCloth_WomanParts"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice=row["OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice=row["OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_ManNum"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ManNum=row["OfficeAutomation_Document_ProjWorkCloth_ManNum"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_ManParts"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ManParts=row["OfficeAutomation_Document_ProjWorkCloth_ManParts"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice=row["OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_ManSumPrice"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_ManSumPrice=row["OfficeAutomation_Document_ProjWorkCloth_ManSumPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_SumPrice"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_SumPrice=row["OfficeAutomation_Document_ProjWorkCloth_SumPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_Remark"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_Remark=row["OfficeAutomation_Document_ProjWorkCloth_Remark"].ToString();
				}
                if (row["Officeautomation_Document_Projworkcloth_Instruction"] != null)
				{
                    model.Officeautomation_Document_Projworkcloth_Instruction = row["Officeautomation_Document_Projworkcloth_Instruction"].ToString();
				}
				if(row["OfficeAutomation_Document_ProjWorkCloth_Sign"]!=null)
				{
					model.OfficeAutomation_Document_ProjWorkCloth_Sign=row["OfficeAutomation_Document_ProjWorkCloth_Sign"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select OfficeAutomation_Document_ProjWorkCloth_ID,OfficeAutomation_Document_ProjWorkCloth_MainID,OfficeAutomation_Document_ProjWorkCloth_Department,OfficeAutomation_Document_ProjWorkCloth_ApplyDate,OfficeAutomation_Document_ProjWorkCloth_Apply,OfficeAutomation_Document_ProjWorkCloth_ReplyPhone,OfficeAutomation_Document_ProjWorkCloth_ApplyID,OfficeAutomation_Document_ProjWorkCloth_ProjName,OfficeAutomation_Document_ProjWorkCloth_DeveloperName,OfficeAutomation_Document_ProjWorkCloth_ProjAddress,OfficeAutomation_Document_ProjWorkCloth_AgentStart,OfficeAutomation_Document_ProjWorkCloth_AgentEnd,OfficeAutomation_Document_ProjWorkCloth_SaleDate,OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs,OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther,OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity,OfficeAutomation_Document_ProjWorkCloth_GoodsValue,OfficeAutomation_Document_ProjWorkCloth_PreComm,OfficeAutomation_Document_ProjWorkCloth_AgentModel,OfficeAutomation_Document_ProjWorkCloth_CommPoint,OfficeAutomation_Document_ProjWorkCloth_WomanNum,OfficeAutomation_Document_ProjWorkCloth_WomanParts,OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice,OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice,OfficeAutomation_Document_ProjWorkCloth_ManNum,OfficeAutomation_Document_ProjWorkCloth_ManParts,OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice,OfficeAutomation_Document_ProjWorkCloth_ManSumPrice,OfficeAutomation_Document_ProjWorkCloth_SumPrice,OfficeAutomation_Document_ProjWorkCloth_Remark,Officeautomation_Document_Projworkcloth_Instruction,OfficeAutomation_Document_ProjWorkCloth_Sign ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjWorkCloth ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" OfficeAutomation_Document_ProjWorkCloth_ID,OfficeAutomation_Document_ProjWorkCloth_MainID,OfficeAutomation_Document_ProjWorkCloth_Department,OfficeAutomation_Document_ProjWorkCloth_ApplyDate,OfficeAutomation_Document_ProjWorkCloth_Apply,OfficeAutomation_Document_ProjWorkCloth_ReplyPhone,OfficeAutomation_Document_ProjWorkCloth_ApplyID,OfficeAutomation_Document_ProjWorkCloth_ProjName,OfficeAutomation_Document_ProjWorkCloth_DeveloperName,OfficeAutomation_Document_ProjWorkCloth_ProjAddress,OfficeAutomation_Document_ProjWorkCloth_AgentStart,OfficeAutomation_Document_ProjWorkCloth_AgentEnd,OfficeAutomation_Document_ProjWorkCloth_SaleDate,OfficeAutomation_Document_ProjWorkCloth_DealOfficeTypeIDs,OfficeAutomation_Document_ProjWorkCloth_DealOfficeOther,OfficeAutomation_Document_ProjWorkCloth_GoodsQuantity,OfficeAutomation_Document_ProjWorkCloth_GoodsValue,OfficeAutomation_Document_ProjWorkCloth_PreComm,OfficeAutomation_Document_ProjWorkCloth_AgentModel,OfficeAutomation_Document_ProjWorkCloth_CommPoint,OfficeAutomation_Document_ProjWorkCloth_WomanNum,OfficeAutomation_Document_ProjWorkCloth_WomanParts,OfficeAutomation_Document_ProjWorkCloth_WomanUnitPrice,OfficeAutomation_Document_ProjWorkCloth_WomanSumPrice,OfficeAutomation_Document_ProjWorkCloth_ManNum,OfficeAutomation_Document_ProjWorkCloth_ManParts,OfficeAutomation_Document_ProjWorkCloth_ManUnitPrice,OfficeAutomation_Document_ProjWorkCloth_ManSumPrice,OfficeAutomation_Document_ProjWorkCloth_SumPrice,OfficeAutomation_Document_ProjWorkCloth_Remark,Officeautomation_Document_Projworkcloth_Instruction,OfficeAutomation_Document_ProjWorkCloth_Sign ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ProjWorkCloth ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ProjWorkCloth ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.OfficeAutomation_Document_ProjWorkCloth_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ProjWorkCloth T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_OfficeAutomation_Document_ProjWorkCloth";
			parameters[1].Value = "OfficeAutomation_Document_ProjWorkCloth_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

