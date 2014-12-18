using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using XSAT.Lib2014.System.Data;//Please add references
using IM.Model;

namespace IM.DAL
{
    /// <summary>
    /// 数据访问类:IM_GroupDAL
    /// </summary>
    public partial class IM_GroupDAL
    {
        public IM_GroupDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_GroupInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("insert into IM_Group(");
            strSql.Append("ID,UserID,GroupName,OrderIndex)");
            strSql.Append(" values (");
            strSql.Append("@ID,@UserID,@GroupName,@OrderIndex)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4)};
            parameters[n++].Value = model.ID;
            parameters[n++].Value = model.UserID;
            parameters[n++].Value = model.GroupName;
            parameters[n++].Value = model.OrderIndex;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// <param name="model">实体</param>
        /// </summary>
        public bool Update(IM_GroupInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("update IM_Group set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("GroupName=@GroupName,");
            strSql.Append("OrderIndex=@OrderIndex,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[n++].Value = model.UserID;
            parameters[n++].Value = model.GroupName;
            parameters[n++].Value = model.OrderIndex;
            parameters[n++].Value = model.CreateDate;
            parameters[n++].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// <param name="ID">ID</param>
        /// </summary>
        public bool Delete(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update IM_Group set IsDelete=1 ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// <param name="ID">ID</param>
        /// </summary>
        public IM_GroupInfo GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,GroupName,OrderIndex,CreateDate from IM_Group ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            IM_GroupInfo model = new IM_GroupInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public IM_GroupInfo DataRowToModel(DataRow row)
        {
            IM_GroupInfo model = new IM_GroupInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = new Guid(row["UserID"].ToString());
                }
                if (row["GroupName"] != null)
                {
                    model.GroupName = row["GroupName"].ToString();
                }
                if (row["OrderIndex"] != null && row["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(row["OrderIndex"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
            }
            return model;
        }


        /// <summary>
        /// 获得前几行数据
        /// <param name="QueryBuilder"></param>
        /// </summary>
        public List<IM_GroupInfo> GetList(QueryBuilder queryBuilder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (queryBuilder.Top > 0)
            {
                strSql.Append(" top " + queryBuilder.Top);
            }
            strSql.Append(" ID,UserID,GroupName,OrderIndex,CreateDate ");
            strSql.Append(" FROM IM_Group ");
            strSql.Append(queryBuilder.Where);
            strSql.Append(queryBuilder.Order);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<IM_GroupInfo> list = new List<IM_GroupInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(dr));
            }
            return list;
        }

        /// <summary>
        /// 分页获取数据列表
        /// <param name="queryBuilder"></param>
        /// <param name="iRecordCount"></param>
        /// </summary>
        public DataTable GetListByPage(QueryBuilder queryBuilder, ref int iRecordCount)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM IM_Group" + queryBuilder.Where);
            IDataParameter[] para = new IDataParameter[] 
			{
				new SqlParameter("@PageIndex",SqlDbType.Int),
				new SqlParameter("@PageSize",SqlDbType.Int),
				new SqlParameter("@strSql",SqlDbType.VarChar),
				new SqlParameter("@Field",SqlDbType.VarChar),
				new SqlParameter("@OrderField",SqlDbType.VarChar)
			};
            para[0].Value = queryBuilder.PageIndex;
            para[1].Value = queryBuilder.PageSize;
            para[2].Value = sbSql.ToString();
            para[3].Value = queryBuilder.OrderField;
            para[4].Value = queryBuilder.OrderType;
            DataSet ds = DbHelperSQL.RunProcedure("ExecutePaging", para, "IM_Group");
            try
            {
                iRecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取群
        /// <param name="userID"></param>
        /// </summary>
        public List<IM_GroupInfo> GetListGroupForUser(Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select [IM_Group].* from [dbo].[IM_GroupMember]
inner join [dbo].[IM_Group]
on [IM_GroupMember].GroupID=[IM_Group].ID
where [IM_GroupMember].UserID=@UserID order by [IM_Group].GroupName asc ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = userID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<IM_GroupInfo> list = new List<IM_GroupInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(dr));
            }
            return list;
        }

        /// <summary>
        /// 查找未添加群
        /// <param name="userID"></param>
        /// <param name="groupName"></param>
        /// </summary>
        public List<IM_GroupInfo> GetListForNoAddGroup(Guid userID, string groupName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select distinct [IM_Group].* from [dbo].[IM_Group]
inner join [dbo].[IM_GroupMember]
on [IM_Group].ID=[GroupID]
where [IM_GroupMember].[UserID]<>@UserID and GroupName like '%" + groupName + @"%'
order by GroupName asc");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = userID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<IM_GroupInfo> list = new List<IM_GroupInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(dr));
            }
            return list;
        }
        #endregion  ExtensionMethod
    }
}

