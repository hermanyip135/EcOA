/*
* DA_OfficeAutomation_Document_ResumeBusi_Operate.cs
*
* 功 能： 
* 类 名： DA_OfficeAutomation_Document_ResumeBusi_Operate
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/15 10:47:32    张榕     初版
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
	/// 数据访问类:DA_OfficeAutomation_Document_ResumeBusi_Operate
	/// </summary>
	public partial class DA_OfficeAutomation_Document_ResumeBusi_Operate
	{
		public DA_OfficeAutomation_Document_ResumeBusi_Operate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid OfficeAutomation_Document_ResumeBusi_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OfficeAutomation_Document_ResumeBusi");
			strSql.Append(" where OfficeAutomation_Document_ResumeBusi_ID=@OfficeAutomation_Document_ResumeBusi_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ResumeBusi_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DataEntity.T_OfficeAutomation_Document_ResumeBusi model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_OfficeAutomation_Document_ResumeBusi(");
            strSql.Append("OfficeAutomation_Document_ResumeBusi_ID,OfficeAutomation_Document_ResumeBusi_MainID,OfficeAutomation_Document_ResumeBusi_Apply,OfficeAutomation_Document_ResumeBusi_ApplyID,OfficeAutomation_Document_ResumeBusi_ApplyDate,OfficeAutomation_Document_ResumeBusi_Department,OfficeAutomation_Document_ResumeBusi_ReplyPhone,OfficeAutomation_Document_ResumeBusi_ReplyFax,OfficeAutomation_Document_ResumeBusi_DepartmentTypeID,OfficeAutomation_Document_ResumeBusi_MajordomoID,OfficeAutomation_Document_ResumeBusi_DepartmentName,OfficeAutomation_Document_ResumeBusi_PlanDate,OfficeAutomation_Document_ResumeBusi_Reason,OfficeAutomation_Document_ResumeBusi_Remark)");
            strSql.Append(" values (");
            strSql.Append("@OfficeAutomation_Document_ResumeBusi_ID,@OfficeAutomation_Document_ResumeBusi_MainID,@OfficeAutomation_Document_ResumeBusi_Apply,@OfficeAutomation_Document_ResumeBusi_ApplyID,@OfficeAutomation_Document_ResumeBusi_ApplyDate,@OfficeAutomation_Document_ResumeBusi_Department,@OfficeAutomation_Document_ResumeBusi_ReplyPhone,@OfficeAutomation_Document_ResumeBusi_ReplyFax,@OfficeAutomation_Document_ResumeBusi_DepartmentTypeID,@OfficeAutomation_Document_ResumeBusi_MajordomoID,@OfficeAutomation_Document_ResumeBusi_DepartmentName,@OfficeAutomation_Document_ResumeBusi_PlanDate,@OfficeAutomation_Document_ResumeBusi_Reason,@OfficeAutomation_Document_ResumeBusi_Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_MainID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ApplyID", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ReplyFax", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_MajordomoID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_DepartmentName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_PlanDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_Reason", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.OfficeAutomation_Document_ResumeBusi_ID;
            parameters[1].Value = model.OfficeAutomation_Document_ResumeBusi_MainID;
            parameters[2].Value = model.OfficeAutomation_Document_ResumeBusi_Apply;
            parameters[3].Value = GetNewSerialNum(model.OfficeAutomation_Document_ResumeBusi_Department, DateTime.Now.ToString());
            parameters[4].Value = model.OfficeAutomation_Document_ResumeBusi_ApplyDate;
            parameters[5].Value = model.OfficeAutomation_Document_ResumeBusi_Department;
            parameters[6].Value = model.OfficeAutomation_Document_ResumeBusi_ReplyPhone;
            parameters[7].Value = model.OfficeAutomation_Document_ResumeBusi_ReplyFax;
            parameters[8].Value = model.OfficeAutomation_Document_ResumeBusi_DepartmentTypeID;
            parameters[9].Value = model.OfficeAutomation_Document_ResumeBusi_MajordomoID;
            parameters[10].Value = model.OfficeAutomation_Document_ResumeBusi_DepartmentName;
            parameters[11].Value = model.OfficeAutomation_Document_ResumeBusi_PlanDate;
            parameters[12].Value = model.OfficeAutomation_Document_ResumeBusi_Reason;
            parameters[13].Value = model.OfficeAutomation_Document_ResumeBusi_Remark;

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

        #region 获得分行最新流水号
        /// <summary>
        /// 获得分行最新流水号
        /// </summary>
        /// <param name="department"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetNewSerialNum(string department, string date)
        {
            date = DateTime.Parse(date).ToString("yyyyMMdd");
            string prefix = department + "-" + date + "-";
            string result = prefix + "01";
            string sSql = "select top 1 OfficeAutomation_Document_ResumeBusi_ApplyID from t_OfficeAutomation_Document_ResumeBusi where OfficeAutomation_Document_ResumeBusi_ApplyID like '" + prefix + "%' order by OfficeAutomation_Document_ResumeBusi_ApplyDate desc";

            DataSet ds = DbHelperSQL.Query(sSql);

            if (!(ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0))
            {
                int newnum = int.Parse(ds.Tables[0].Rows[0][0].ToString().Substring(prefix.Length)) + 1;
                result = prefix + newnum.ToString().PadLeft(2, '0');
            }

            return result;
        }
        #endregion

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DataEntity.T_OfficeAutomation_Document_ResumeBusi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OfficeAutomation_Document_ResumeBusi set ");
			//strSql.Append("OfficeAutomation_Document_ResumeBusi_MainID=@OfficeAutomation_Document_ResumeBusi_MainID,");
			//strSql.Append("OfficeAutomation_Document_ResumeBusi_Apply=@OfficeAutomation_Document_ResumeBusi_Apply,");
			strSql.Append("OfficeAutomation_Document_ResumeBusi_ApplyID=@OfficeAutomation_Document_ResumeBusi_ApplyID,");
			//strSql.Append("OfficeAutomation_Document_ResumeBusi_ApplyDate=@OfficeAutomation_Document_ResumeBusi_ApplyDate,");
			strSql.Append("OfficeAutomation_Document_ResumeBusi_Department=@OfficeAutomation_Document_ResumeBusi_Department,");
			strSql.Append("OfficeAutomation_Document_ResumeBusi_ReplyPhone=@OfficeAutomation_Document_ResumeBusi_ReplyPhone,");
			strSql.Append("OfficeAutomation_Document_ResumeBusi_ReplyFax=@OfficeAutomation_Document_ResumeBusi_ReplyFax,");
            strSql.Append("OfficeAutomation_Document_ResumeBusi_DepartmentTypeID=@OfficeAutomation_Document_ResumeBusi_DepartmentTypeID,");
            strSql.Append("OfficeAutomation_Document_ResumeBusi_MajordomoID=@OfficeAutomation_Document_ResumeBusi_MajordomoID,");
            strSql.Append("OfficeAutomation_Document_ResumeBusi_DepartmentName=@OfficeAutomation_Document_ResumeBusi_DepartmentName,");
            strSql.Append("OfficeAutomation_Document_ResumeBusi_PlanDate=@OfficeAutomation_Document_ResumeBusi_PlanDate,");
            strSql.Append("OfficeAutomation_Document_ResumeBusi_Reason=@OfficeAutomation_Document_ResumeBusi_Reason,");
            strSql.Append("OfficeAutomation_Document_ResumeBusi_Remark=@OfficeAutomation_Document_ResumeBusi_Remark");
            strSql.Append(" where OfficeAutomation_Document_ResumeBusi_ID=@OfficeAutomation_Document_ResumeBusi_ID ");
			SqlParameter[] parameters = {
					//new SqlParameter("@OfficeAutomation_Document_ResumeBusi_MainID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@OfficeAutomation_Document_ResumeBusi_Apply", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ApplyID", SqlDbType.NVarChar,80),
					//new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_Department", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ReplyPhone", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ReplyFax", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_DepartmentTypeID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_MajordomoID", SqlDbType.Int,4),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_DepartmentName", SqlDbType.NVarChar,80),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_PlanDate", SqlDbType.DateTime),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_Reason", SqlDbType.NVarChar,-1),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ID", SqlDbType.UniqueIdentifier,16)};
			//parameters[0].Value = model.OfficeAutomation_Document_ResumeBusi_MainID;
			//parameters[1].Value = model.OfficeAutomation_Document_ResumeBusi_Apply;
			parameters[0].Value = model.OfficeAutomation_Document_ResumeBusi_ApplyID;
			//parameters[3].Value = model.OfficeAutomation_Document_ResumeBusi_ApplyDate;
			parameters[1].Value = model.OfficeAutomation_Document_ResumeBusi_Department;
			parameters[2].Value = model.OfficeAutomation_Document_ResumeBusi_ReplyPhone;
			parameters[3].Value = model.OfficeAutomation_Document_ResumeBusi_ReplyFax;
            parameters[4].Value = model.OfficeAutomation_Document_ResumeBusi_DepartmentTypeID;
            parameters[5].Value = model.OfficeAutomation_Document_ResumeBusi_MajordomoID;
            parameters[6].Value = model.OfficeAutomation_Document_ResumeBusi_DepartmentName;
            parameters[7].Value = model.OfficeAutomation_Document_ResumeBusi_PlanDate;
            parameters[8].Value = model.OfficeAutomation_Document_ResumeBusi_Reason;
            parameters[9].Value = model.OfficeAutomation_Document_ResumeBusi_Remark;
            parameters[10].Value = model.OfficeAutomation_Document_ResumeBusi_ID;

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
        public bool Delete(string OfficeAutomation_Document_ResumeBusi_ID)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("dbo.[pr_ResumeBusi_Delete]");
            SqlParameter[] parameters = {
					new SqlParameter("@sMainID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(OfficeAutomation_Document_ResumeBusi_ID);

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
		public bool DeleteList(string OfficeAutomation_Document_ResumeBusi_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OfficeAutomation_Document_ResumeBusi ");
			strSql.Append(" where OfficeAutomation_Document_ResumeBusi_ID in ("+OfficeAutomation_Document_ResumeBusi_IDlist + ")  ");
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
		public DataEntity.T_OfficeAutomation_Document_ResumeBusi GetModel(Guid OfficeAutomation_Document_ResumeBusi_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OfficeAutomation_Document_ResumeBusi_ID,OfficeAutomation_Document_ResumeBusi_MainID,OfficeAutomation_Document_ResumeBusi_Apply,OfficeAutomation_Document_ResumeBusi_ApplyID,OfficeAutomation_Document_ResumeBusi_ApplyDate,OfficeAutomation_Document_ResumeBusi_Department,OfficeAutomation_Document_ResumeBusi_ReplyPhone,OfficeAutomation_Document_ResumeBusi_ReplyFax,OfficeAutomation_Document_ResumeBusi_Reason,OfficeAutomation_Document_ResumeBusi_Remark from t_OfficeAutomation_Document_ResumeBusi ");
			strSql.Append(" where OfficeAutomation_Document_ResumeBusi_ID=@OfficeAutomation_Document_ResumeBusi_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OfficeAutomation_Document_ResumeBusi_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = OfficeAutomation_Document_ResumeBusi_ID;

			DataEntity.T_OfficeAutomation_Document_ResumeBusi model=new DataEntity.T_OfficeAutomation_Document_ResumeBusi();
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
        public DataEntity.T_OfficeAutomation_Document_ResumeBusi DataRowToModel(DataRow row)
        {
            DataEntity.T_OfficeAutomation_Document_ResumeBusi model = new DataEntity.T_OfficeAutomation_Document_ResumeBusi();
            if (row != null)
            {
                if (row["OfficeAutomation_Document_ResumeBusi_ID"] != null && row["OfficeAutomation_Document_ResumeBusi_ID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ResumeBusi_ID = new Guid(row["OfficeAutomation_Document_ResumeBusi_ID"].ToString());
                }
                if (row["OfficeAutomation_Document_ResumeBusi_MainID"] != null && row["OfficeAutomation_Document_ResumeBusi_MainID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ResumeBusi_MainID = new Guid(row["OfficeAutomation_Document_ResumeBusi_MainID"].ToString());
                }
                if (row["OfficeAutomation_Document_ResumeBusi_Apply"] != null)
                {
                    model.OfficeAutomation_Document_ResumeBusi_Apply = row["OfficeAutomation_Document_ResumeBusi_Apply"].ToString();
                }
                if (row["OfficeAutomation_Document_ResumeBusi_ApplyID"] != null)
                {
                    model.OfficeAutomation_Document_ResumeBusi_ApplyID = row["OfficeAutomation_Document_ResumeBusi_ApplyID"].ToString();
                }
                if (row["OfficeAutomation_Document_ResumeBusi_ApplyDate"] != null && row["OfficeAutomation_Document_ResumeBusi_ApplyDate"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ResumeBusi_ApplyDate = DateTime.Parse(row["OfficeAutomation_Document_ResumeBusi_ApplyDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ResumeBusi_Department"] != null)
                {
                    model.OfficeAutomation_Document_ResumeBusi_Department = row["OfficeAutomation_Document_ResumeBusi_Department"].ToString();
                }
                if (row["OfficeAutomation_Document_ResumeBusi_ReplyPhone"] != null)
                {
                    model.OfficeAutomation_Document_ResumeBusi_ReplyPhone = row["OfficeAutomation_Document_ResumeBusi_ReplyPhone"].ToString();
                }
                if (row["OfficeAutomation_Document_ResumeBusi_ReplyFax"] != null)
                {
                    model.OfficeAutomation_Document_ResumeBusi_ReplyFax = row["OfficeAutomation_Document_ResumeBusi_ReplyFax"].ToString();
                }
                if (row["OfficeAutomation_Document_ResumeBusi_DepartmentTypeID"] != null && row["OfficeAutomation_Document_ResumeBusi_DepartmentTypeID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ResumeBusi_DepartmentTypeID = int.Parse(row["OfficeAutomation_Document_ResumeBusi_DepartmentTypeID"].ToString());
                }
                if (row["OfficeAutomation_Document_ResumeBusi_MajordomoID"] != null && row["OfficeAutomation_Document_ResumeBusi_MajordomoID"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ResumeBusi_MajordomoID = int.Parse(row["OfficeAutomation_Document_ResumeBusi_MajordomoID"].ToString());
                }
                if (row["OfficeAutomation_Document_ResumeBusi_DepartmentName"] != null)
                {
                    model.OfficeAutomation_Document_ResumeBusi_DepartmentName = row["OfficeAutomation_Document_ResumeBusi_DepartmentName"].ToString();
                }
                if (row["OfficeAutomation_Document_ResumeBusi_PlanDate"] != null && row["OfficeAutomation_Document_ResumeBusi_PlanDate"].ToString() != "")
                {
                    model.OfficeAutomation_Document_ResumeBusi_PlanDate = DateTime.Parse(row["OfficeAutomation_Document_ResumeBusi_PlanDate"].ToString());
                }
                if (row["OfficeAutomation_Document_ResumeBusi_Reason"] != null)
                {
                    model.OfficeAutomation_Document_ResumeBusi_Reason = row["OfficeAutomation_Document_ResumeBusi_Reason"].ToString();
                }
                if (row["OfficeAutomation_Document_ResumeBusi_Remark"] != null)
                {
                    model.OfficeAutomation_Document_ResumeBusi_Remark = row["OfficeAutomation_Document_ResumeBusi_Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OfficeAutomation_Document_ResumeBusi_ID,OfficeAutomation_Document_ResumeBusi_MainID,OfficeAutomation_Document_ResumeBusi_Apply,OfficeAutomation_Document_ResumeBusi_ApplyID,OfficeAutomation_Document_ResumeBusi_ApplyDate,OfficeAutomation_Document_ResumeBusi_Department,OfficeAutomation_Document_ResumeBusi_ReplyPhone,OfficeAutomation_Document_ResumeBusi_ReplyFax,OfficeAutomation_Document_ResumeBusi_DepartmentTypeID,OfficeAutomation_Document_ResumeBusi_MajordomoID,OfficeAutomation_Document_ResumeBusi_DepartmentName,OfficeAutomation_Document_ResumeBusi_PlanDate,OfficeAutomation_Document_ResumeBusi_Reason,OfficeAutomation_Document_ResumeBusi_Remark ");
            strSql.Append(" FROM t_OfficeAutomation_Document_ResumeBusi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OfficeAutomation_Document_ResumeBusi_ID,OfficeAutomation_Document_ResumeBusi_MainID,OfficeAutomation_Document_ResumeBusi_Apply,OfficeAutomation_Document_ResumeBusi_ApplyID,OfficeAutomation_Document_ResumeBusi_ApplyDate,OfficeAutomation_Document_ResumeBusi_Department,OfficeAutomation_Document_ResumeBusi_ReplyPhone,OfficeAutomation_Document_ResumeBusi_ReplyFax,OfficeAutomation_Document_ResumeBusi_DepartmentTypeID,OfficeAutomation_Document_ResumeBusi_MajordomoID,OfficeAutomation_Document_ResumeBusi_DepartmentName,OfficeAutomation_Document_ResumeBusi_PlanDate,OfficeAutomation_Document_ResumeBusi_Reason,OfficeAutomation_Document_ResumeBusi_Remark ");
            strSql.Append(" FROM t_OfficeAutomation_Document_ResumeBusi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_OfficeAutomation_Document_ResumeBusi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.OfficeAutomation_Document_ResumeBusi_ID desc");
            }
            strSql.Append(")AS Row, T.*  from t_OfficeAutomation_Document_ResumeBusi T ");
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
            parameters[0].Value = "t_OfficeAutomation_Document_ResumeBusi";
            parameters[1].Value = "OfficeAutomation_Document_ResumeBusi_ID";
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


