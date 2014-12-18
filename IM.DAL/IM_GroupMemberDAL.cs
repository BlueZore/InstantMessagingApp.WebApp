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
    /// 数据访问类:IM_GroupMemberDAL
    /// </summary>
    public partial class IM_GroupMemberDAL
    {
        public IM_GroupMemberDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_GroupMemberInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append(@"if exists(select 1 from IM_GroupMember where UserID=@UserID and GroupID=@GroupID)
                             begin
                                    select -1 as ifCanDo
                                    return
                             end ");
            strSql.Append("insert into IM_GroupMember(");
            strSql.Append("ID,GroupID,UserID,OrderIndex)");
            strSql.Append(" values (");
            strSql.Append("@ID,@GroupID,@UserID,@OrderIndex)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4)};
            parameters[n++].Value = model.ID;
            parameters[n++].Value = model.GroupID;
            parameters[n++].Value = model.UserID;
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
        public bool Update(IM_GroupMemberInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("update IM_GroupMember set ");
            strSql.Append("GroupID=@GroupID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("OrderIndex=@OrderIndex");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[n++].Value = model.GroupID;
            parameters[n++].Value = model.UserID;
            parameters[n++].Value = model.OrderIndex;
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
            strSql.Append("update IM_GroupMember set IsDelete=1 ");
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
        public IM_GroupMemberInfo GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GroupID,UserID,OrderIndex from IM_GroupMember ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            IM_GroupMemberInfo model = new IM_GroupMemberInfo();
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
        public IM_GroupMemberInfo DataRowToModel(DataRow row)
        {
            IM_GroupMemberInfo model = new IM_GroupMemberInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                {
                    model.GroupID = new Guid(row["GroupID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = new Guid(row["UserID"].ToString());
                }
                if (row["OrderIndex"] != null && row["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(row["OrderIndex"].ToString());
                }
            }
            return model;
        }


        /// <summary>
        /// 获得前几行数据
        /// <param name="QueryBuilder"></param>
        /// </summary>
        public List<IM_GroupMemberInfo> GetList(QueryBuilder queryBuilder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (queryBuilder.Top > 0)
            {
                strSql.Append(" top " + queryBuilder.Top);
            }
            strSql.Append(" ID,GroupID,UserID,OrderIndex ");
            strSql.Append(" FROM IM_GroupMember ");
            strSql.Append(queryBuilder.Where);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<IM_GroupMemberInfo> list = new List<IM_GroupMemberInfo>();
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
            sbSql.Append("SELECT * FROM IM_GroupMember" + queryBuilder.Where);
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
            DataSet ds = DbHelperSQL.RunProcedure("ExecutePaging", para, "IM_GroupMember");
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
        /// 获取所有组成员
        /// <param name="userID"></param>
        /// </summary>
        public List<IM_GroupMemberInfo> GetListAllMenberForUser(Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select [IM_GroupMember].*,UserName,Pic from [IM_GroupMember]
inner join
(select * from [IM_GroupMember] where UserID=@UserID)a
on [IM_GroupMember].GroupID=a.GroupID
inner join [dbo].[IM_User]
on [IM_GroupMember].UserID=[IM_User].ID

");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = userID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<IM_GroupMemberInfo> list = new List<IM_GroupMemberInfo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                IM_GroupMemberInfo model = new IM_GroupMemberInfo();
                if (row != null)
                {
                    if (row["ID"] != null && row["ID"].ToString() != "")
                    {
                        model.ID = new Guid(row["ID"].ToString());
                    }
                    if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                    {
                        model.GroupID = new Guid(row["GroupID"].ToString());
                    }
                    if (row["UserID"] != null && row["UserID"].ToString() != "")
                    {
                        model.UserID = new Guid(row["UserID"].ToString());
                    }
                    if (row["OrderIndex"] != null && row["OrderIndex"].ToString() != "")
                    {
                        model.OrderIndex = int.Parse(row["OrderIndex"].ToString());
                    }
                    if (row["UserName"] != null && row["UserName"].ToString() != "")
                    {
                        model.UserName = row["UserName"].ToString();
                    }
                    if (row["Pic"] != null && row["Pic"].ToString() != "")
                    {
                        model.Pic = row["Pic"].ToString();
                    }
                }
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 获取群内成员
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// </summary>
        public List<IM_GroupMemberInfo> GetListForMenber(Guid userID, Guid groupID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select [IM_GroupMember].*,UserName,Pic from [IM_GroupMember]
inner join
(select * from [IM_GroupMember] where UserID=@UserID and GroupID=@GroupID)a
on [IM_GroupMember].GroupID=a.GroupID
inner join [dbo].[IM_User]
on [IM_GroupMember].UserID=[IM_User].ID

");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = userID;
            parameters[1].Value = groupID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<IM_GroupMemberInfo> list = new List<IM_GroupMemberInfo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                IM_GroupMemberInfo model = new IM_GroupMemberInfo();
                if (row != null)
                {
                    if (row["ID"] != null && row["ID"].ToString() != "")
                    {
                        model.ID = new Guid(row["ID"].ToString());
                    }
                    if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                    {
                        model.GroupID = new Guid(row["GroupID"].ToString());
                    }
                    if (row["UserID"] != null && row["UserID"].ToString() != "")
                    {
                        model.UserID = new Guid(row["UserID"].ToString());
                    }
                    if (row["OrderIndex"] != null && row["OrderIndex"].ToString() != "")
                    {
                        model.OrderIndex = int.Parse(row["OrderIndex"].ToString());
                    }
                    if (row["UserName"] != null && row["UserName"].ToString() != "")
                    {
                        model.UserName = row["UserName"].ToString();
                    }
                    if (row["Pic"] != null && row["Pic"].ToString() != "")
                    {
                        model.Pic = row["Pic"].ToString();
                    }
                }
                list.Add(model);
            }
            return list;
        }


        /// <summary>
        /// 删除成员
        /// <param name="userID">userID</param>
        /// <param name="groupID">groupID</param>
        /// </summary>
        public bool Delete(Guid userID, Guid groupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IM_GroupMember ");
            strSql.Append(" where UserID=@UserID and GroupID=@GourpID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@GourpID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = userID;
            parameters[1].Value = groupID;

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

        #endregion  ExtensionMethod
    }
}

