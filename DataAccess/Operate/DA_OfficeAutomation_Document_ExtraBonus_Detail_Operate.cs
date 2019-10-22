/*
* DA_OfficeAutomation_Document_ExtraBonus_Detail_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ExtraBonus_Detail_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/10 16:25:41    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_ExtraBonus_Detail_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_ExtraBonus_Detail_Operate
	{
		public DA_OfficeAutomation_Document_ExtraBonus_Detail_Operate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ExtraBonus_Detail_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ExtraBonus_Detail");
			strSql.Append(" where OfficeAutomation_Document_ExtraBonus_Detail_ID=@OfficeAutomation_Document_ExtraBonus_Detail_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ExtraBonus_Detail_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ExtraBonus_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_OfficeAutomation_Document_ExtraBonus_Detail(");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_ID,OfficeAutomation_Document_ExtraBonus_Detail_MainID,OfficeAutomation_Document_ExtraBonus_Detail_SetNumber,OfficeAutomation_Document_ExtraBonus_Detail_PriceRange,OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice,OfficeAutomation_Document_ExtraBonus_Detail_ActualComm,OfficeAutomation_Document_ExtraBonus_Detail_RewardScale,OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet,OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale,OfficeAutomation_Document_ExtraBonus_Detail_OrderBy)");
			strSql.Append(" values (");
			strSql.Append("@OfficeAutomation_Document_ExtraBonus_Detail_ID,@OfficeAutomation_Document_ExtraBonus_Detail_MainID,@OfficeAutomation_Document_ExtraBonus_Detail_SetNumber,@OfficeAutomation_Document_ExtraBonus_Detail_PriceRange,@OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice,@OfficeAutomation_Document_ExtraBonus_Detail_ActualComm,@OfficeAutomation_Document_ExtraBonus_Detail_RewardScale,@OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet,@OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale,@OfficeAutomation_Document_ExtraBonus_Detail_OrderBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_SetNumber", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_PriceRange", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_ActualComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_RewardScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_OrderBy", SqlDbType.Int,4)};
			parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_MainID;
			parameters[2].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_SetNumber;
			parameters[3].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_PriceRange;
			parameters[4].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice;
			parameters[5].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_ActualComm;
			parameters[6].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_RewardScale;
			parameters[7].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet;
			parameters[8].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale;
			parameters[9].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_OrderBy;

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
		public bool Update(DataEntity.T_OfficeAutomation_Document_ExtraBonus_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ExtraBonus_Detail set ");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_MainID=@OfficeAutomation_Document_ExtraBonus_Detail_MainID,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_SetNumber=@OfficeAutomation_Document_ExtraBonus_Detail_SetNumber,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_PriceRange=@OfficeAutomation_Document_ExtraBonus_Detail_PriceRange,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice=@OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_ActualComm=@OfficeAutomation_Document_ExtraBonus_Detail_ActualComm,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_RewardScale=@OfficeAutomation_Document_ExtraBonus_Detail_RewardScale,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet=@OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale=@OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale,");
			strSql.Append("OfficeAutomation_Document_ExtraBonus_Detail_OrderBy=@OfficeAutomation_Document_ExtraBonus_Detail_OrderBy");
			strSql.Append(" where OfficeAutomation_Document_ExtraBonus_Detail_ID=@OfficeAutomation_Document_ExtraBonus_Detail_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_SetNumber", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_PriceRange", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_ActualComm", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_RewardScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_OrderBy", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_MainID;
			parameters[0].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_SetNumber;
			parameters[1].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_PriceRange;
			parameters[2].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice;
			parameters[3].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_ActualComm;
			parameters[4].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_RewardScale;
			parameters[5].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet;
			parameters[6].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale;
			parameters[7].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_OrderBy;
			parameters[8].Value = model.OfficeAutomation_Document_ExtraBonus_Detail_ID;

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
		public bool Delete(Guid OfficeAutomation_Document_ExtraBonus_Detail_MainID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ExtraBonus_Detail ");
            strSql.Append(" where OfficeAutomation_Document_ExtraBonus_Detail_MainID=@OfficeAutomation_Document_ExtraBonus_Detail_MainID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_MainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = OfficeAutomation_Document_ExtraBonus_Detail_MainID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string OfficeAutomation_Document_ExtraBonus_Detail_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ExtraBonus_Detail ");
			strSql.Append(" where OfficeAutomation_Document_ExtraBonus_Detail_ID in ("+OfficeAutomation_Document_ExtraBonus_Detail_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_ExtraBonus_Detail GetModel(Guid OfficeAutomation_Document_ExtraBonus_Detail_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OfficeAutomation_Document_ExtraBonus_Detail_ID,OfficeAutomation_Document_ExtraBonus_Detail_MainID,OfficeAutomation_Document_ExtraBonus_Detail_SetNumber,OfficeAutomation_Document_ExtraBonus_Detail_PriceRange,OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice,OfficeAutomation_Document_ExtraBonus_Detail_ActualComm,OfficeAutomation_Document_ExtraBonus_Detail_RewardScale,OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet,OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale,OfficeAutomation_Document_ExtraBonus_Detail_OrderBy from t_OfficeAutomation_Document_ExtraBonus_Detail ");
			strSql.Append(" where OfficeAutomation_Document_ExtraBonus_Detail_ID=@OfficeAutomation_Document_ExtraBonus_Detail_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ExtraBonus_Detail_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ExtraBonus_Detail_ID;

			DataEntity.T_OfficeAutomation_Document_ExtraBonus_Detail model=new DataEntity.T_OfficeAutomation_Document_ExtraBonus_Detail();
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
		public DataEntity.T_OfficeAutomation_Document_ExtraBonus_Detail DataRowToModel(DataRow row)
		{
			DataEntity.T_OfficeAutomation_Document_ExtraBonus_Detail model=new DataEntity.T_OfficeAutomation_Document_ExtraBonus_Detail();
			if (row != null)
			{
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_ID"]!=null && row["OfficeAutomation_Document_ExtraBonus_Detail_ID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_ID= new Guid(row["OfficeAutomation_Document_ExtraBonus_Detail_ID"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_MainID"]!=null && row["OfficeAutomation_Document_ExtraBonus_Detail_MainID"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_MainID= new Guid(row["OfficeAutomation_Document_ExtraBonus_Detail_MainID"].ToString());
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_SetNumber"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_SetNumber=row["OfficeAutomation_Document_ExtraBonus_Detail_SetNumber"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_PriceRange"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_PriceRange=row["OfficeAutomation_Document_ExtraBonus_Detail_PriceRange"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice=row["OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_ActualComm"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_ActualComm=row["OfficeAutomation_Document_ExtraBonus_Detail_ActualComm"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_RewardScale"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_RewardScale=row["OfficeAutomation_Document_ExtraBonus_Detail_RewardScale"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet=row["OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale"]!=null)
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale=row["OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale"].ToString();
				}
				if(row["OfficeAutomation_Document_ExtraBonus_Detail_OrderBy"]!=null && row["OfficeAutomation_Document_ExtraBonus_Detail_OrderBy"].ToString()!="")
				{
					model.OfficeAutomation_Document_ExtraBonus_Detail_OrderBy=int.Parse(row["OfficeAutomation_Document_ExtraBonus_Detail_OrderBy"].ToString());
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
			strSql.Append("select OfficeAutomation_Document_ExtraBonus_Detail_ID,OfficeAutomation_Document_ExtraBonus_Detail_MainID,OfficeAutomation_Document_ExtraBonus_Detail_SetNumber,OfficeAutomation_Document_ExtraBonus_Detail_PriceRange,OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice,OfficeAutomation_Document_ExtraBonus_Detail_ActualComm,OfficeAutomation_Document_ExtraBonus_Detail_RewardScale,OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet,OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale,OfficeAutomation_Document_ExtraBonus_Detail_OrderBy ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ExtraBonus_Detail ");
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
			strSql.Append(" OfficeAutomation_Document_ExtraBonus_Detail_ID,OfficeAutomation_Document_ExtraBonus_Detail_MainID,OfficeAutomation_Document_ExtraBonus_Detail_SetNumber,OfficeAutomation_Document_ExtraBonus_Detail_PriceRange,OfficeAutomation_Document_ExtraBonus_Detail_UnitPrice,OfficeAutomation_Document_ExtraBonus_Detail_ActualComm,OfficeAutomation_Document_ExtraBonus_Detail_RewardScale,OfficeAutomation_Document_ExtraBonus_Detail_PayPerSet,OfficeAutomation_Document_ExtraBonus_Detail_PayActualScale,OfficeAutomation_Document_ExtraBonus_Detail_OrderBy ");
			strSql.Append(" FROM t_OfficeAutomation_Document_ExtraBonus_Detail ");
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
			strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ExtraBonus_Detail ");
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
				strSql.Append("order by T.OfficeAutomation_Document_ExtraBonus_Detail_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ExtraBonus_Detail T ");
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
			parameters[0].Value = "t_OfficeAutomation_Document_ExtraBonus_Detail";
			parameters[1].Value = "OfficeAutomation_Document_ExtraBonus_Detail_ID";
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

